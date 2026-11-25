#Requires -Version 7.2
<#
.SYNOPSIS
    Previews or applies approved, metadata-only article edits from a JSON manifest.
.EXAMPLE
    .\update-frontmatter.ps1 -Mode Preview -ManifestPath C:\temp\articles.json
.EXAMPLE
    .\update-frontmatter.ps1 -Mode Apply -ManifestPath C:\temp\articles.json -ApprovedGroups release-notes
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [ValidateSet('Preview', 'Apply')]
    [string]$Mode,

    [Parameter(Mandatory = $true)]
    [string]$ManifestPath,

    [string]$RepositoryRoot = (Get-Location).Path,
    [string[]]$ApprovedGroups = @(),
    [string[]]$ApprovedPaths = @()
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version Latest
$utf8 = [Text.UTF8Encoding]::new($false, $true)
$rootItem = Get-Item -LiteralPath $RepositoryRoot
if ($rootItem -isnot [IO.DirectoryInfo]) {
    throw 'RepositoryRoot must identify a directory'
}
$root = $rootItem.FullName
$manifestFile = [IO.Path]::GetFullPath($ManifestPath)
$pathComparer = $(if ($IsWindows) { [StringComparer]::OrdinalIgnoreCase } else { [StringComparer]::Ordinal })
if ([IO.Path]::GetExtension($manifestFile) -ine '.json') {
    throw 'ManifestPath must identify a JSON file'
}
$relativeManifest = [IO.Path]::GetRelativePath($root, $manifestFile)
if (![IO.Path]::IsPathRooted($relativeManifest) -and ($relativeManifest -split '[\\/]')[0] -ne '..') {
    throw 'Keep the manifest and report outside the article repository'
}

function Get-Hash {
    param([byte[]]$Bytes)
    [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($Bytes)).ToLowerInvariant()
}

function Resolve-ArticlePath {
    param([string]$Path)
    $relative = $Path.Replace('\', [IO.Path]::DirectorySeparatorChar).Replace('/', [IO.Path]::DirectorySeparatorChar)
    if ([IO.Path]::IsPathRooted($relative) -or $relative -split '[\\/]' -contains '..' -or [IO.Path]::GetExtension($relative) -cne '.md') {
        throw "Expected a repository-relative Markdown path without traversal: $Path"
    }
    $fullPath = [IO.Path]::GetFullPath((Join-Path $root $relative))
    $current = $root
    foreach ($part in $relative -split '[\\/]') {
        $current = Join-Path $current $part
        if ((Get-Item -LiteralPath $current).Attributes -band [IO.FileAttributes]::ReparsePoint) {
            throw "Linked article paths are not supported: $Path"
        }
    }
    if ((Get-Item -LiteralPath $fullPath) -isnot [IO.FileInfo]) {
        throw "Expected an article file: $Path"
    }
    $fullPath
}

function Read-Article {
    param([string]$Path)
    $bytes = [IO.File]::ReadAllBytes($Path)
    $bom = $bytes.Length -ge 3 -and $bytes[0] -eq 0xEF -and $bytes[1] -eq 0xBB -and $bytes[2] -eq 0xBF
    $offset = $(if ($bom) { 3 } else { 0 })
    try {
        $text = $utf8.GetString($bytes, $offset, $bytes.Length - $offset)
    }
    catch [Text.DecoderFallbackException] {
        throw "Article is not valid UTF-8; encoding was not changed: $Path"
    }
    [pscustomobject]@{
        Path = $Path
        Bytes = $bytes
        Text = $text
        Bom = $bom
        Hash = Get-Hash $bytes
    }
}

function ConvertTo-Scalar {
    param([string]$Value)
    if ($Value -cmatch '^(?:[A-Za-z][A-Za-z0-9_.-]*|[0-9]+-[A-Za-z][A-Za-z0-9_.-]*)$' -and
        $Value -notmatch '^(true|false|yes|no|on|off|null)$') {
        return $Value
    }
    "'" + $Value.Replace("'", "''") + "'"
}

function Read-Scalar {
    param([string]$Raw, [string]$Path)
    if ($Raw.StartsWith('#')) {
        return @{ Value = $null; Suffix = ' ' + $Raw; IsString = $false }
    }
    if ($Raw -match "^'(?<value>(?:[^']|'')*)'(?<suffix>[ `t]*(?:#.*)?)$") {
        return @{ Value = $Matches.value.Replace("''", "'"); Suffix = $Matches.suffix; IsString = $true }
    }
    if ($Raw -match '^"(?<value>(?:[^"\\]|\\.)*)"(?<suffix>[ \t]*(?:#.*)?)$') {
        return @{ Value = ('"' + $Matches.value + '"' | ConvertFrom-Json); Suffix = $Matches.suffix; IsString = $true }
    }
    if ($Raw -match '^[ \t]*[|>\[{\&*!''"]' -or $Raw -match ':[ \t]|[ \t][\&*!]') {
        throw "Unsupported or ambiguous target scalar in ${Path}: $Raw"
    }
    $match = [regex]::Match($Raw, '^(?<value>.*?)(?<suffix>[ \t]+#.*)?$')
    $value = $match.Groups['value'].Value.TrimEnd()
    $suffix = $Raw.Substring($value.Length)
    $number = '[-+]?(?:[0-9][0-9_]*(?:\.[0-9_]*)?|\.[0-9_]+)(?:[eE][-+]?[0-9_]+)?'
    $typed = $value -match "^$|^(true|false|yes|no|on|off|null|~|$number|0[xob][0-9a-f]+|[-+]?\.(inf|nan)|[0-9]{4}-[0-9]{2}-[0-9]{2}([Tt ].*)?)$"
    @{ Value = $value; Suffix = $suffix; IsString = !$typed }
}

function Get-Edit {
    param($Article, [string]$Key, [string]$Value)
    $frontmatter = [regex]::Match($Article.Text, '\A---\r?\n(?<body>.*?)^(?<close>---[ \t]*)(?:\r?\n|$)', 'Singleline,Multiline')
    if (!$frontmatter.Success) {
        throw "Expected opening YAML frontmatter delimiters: $($Article.Path)"
    }
    $body = $frontmatter.Groups['body'].Value
    $firstContent = @($body -split '\r?\n' | Where-Object { $_.Trim() -and !$_.TrimStart().StartsWith('#') }) | Select-Object -First 1
    if ($firstContent -and $firstContent -cnotmatch '^[A-Za-z_][A-Za-z0-9_.-]*[ \t]*:') {
        throw "Expected unindented mapping keys in frontmatter: $($Article.Path)"
    }
    $keys = [regex]::Matches($body, '(?m)^(?<key>[A-Za-z_][A-Za-z0-9_.-]*)[ \t]*:')
    $seen = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($entry in $keys) {
        if (!$seen.Add($entry.Groups['key'].Value)) {
            throw "Duplicate frontmatter key '$($entry.Groups['key'].Value)': $($Article.Path)"
        }
    }
    $escapedKey = [regex]::Escape($Key)
    if ($body -match '(?m)^<<[ \t]*:' -or $body -match '(?m)^[''"][^\r\n]*[''"][ \t]*:') {
        throw "YAML merge keys and quoted frontmatter keys are not supported: $($Article.Path)"
    }
    $field = [regex]::Match($body, "(?m)^(?<prefix>${escapedKey}[ `t]*:[ `t]*)(?<raw>[^\r\n]*)(?<newline>\r?\n|$)")
    $currentValue = $null
    $scalar = ConvertTo-Scalar $Value
    if ($field.Success) {
        $parsed = Read-Scalar $field.Groups['raw'].Value $Article.Path
        if ($body.Substring($field.Index + $field.Length) -match '\A(?:[ \t]*(?:#[^\r\n]*)?\r?\n)*[ \t]+[^#\s]') {
            throw "Multiline or structured target values are not supported: $($Article.Path)"
        }
        $currentValue = $parsed.Value
        if ($parsed.IsString -and $currentValue -ceq $Value) {
            return @{ Bytes = $Article.Bytes; CurrentValue = $currentValue }
        }
        $replacement = $field.Groups['prefix'].Value + $scalar + $parsed.Suffix + $field.Groups['newline'].Value
        $updatedBody = $body.Substring(0, $field.Index) + $replacement + $body.Substring($field.Index + $field.Length)
    }
    else {
        $newline = [regex]::Match($frontmatter.Value, '\r?\n').Value
        $date = [regex]::Match($body, '(?m)^ms\.date[ \t]*:[^\r\n]*(?:\r?\n|$)')
        $position = $(if ($date.Success) { $date.Index + $date.Length } else { $body.Length })
        $updatedBody = $body.Insert($position, "${Key}: $scalar$newline")
    }
    $bodyOffset = $frontmatter.Groups['body'].Index
    $updatedText = $Article.Text.Substring(0, $bodyOffset) + $updatedBody + $Article.Text.Substring($bodyOffset + $body.Length)
    [byte[]]$updatedBytes = $utf8.GetBytes($updatedText)
    if ($Article.Bom) {
        $updatedBytes = [byte[]](@(0xEF, 0xBB, 0xBF) + $updatedBytes)
    }
    @{ Bytes = $updatedBytes; CurrentValue = $currentValue }
}

function Save-Manifest {
    $temporary = Join-Path (Split-Path $manifestFile -Parent) ([IO.Path]::GetRandomFileName())
    try {
        [IO.File]::WriteAllText($temporary, ($manifest | ConvertTo-Json -Depth 20) + "`n", $utf8)
        [IO.File]::Move($temporary, $manifestFile, $true)
    }
    finally {
        if (Test-Path -LiteralPath $temporary) {
            Remove-Item -LiteralPath $temporary
        }
    }
    $manifest.articles | Select-Object path, group, classification, status, currentValue,
        @{Name = 'proposedValue'; Expression = { $manifest.metadata.value }}, reason, evidence |
        Export-Csv -LiteralPath ([IO.Path]::ChangeExtension($manifestFile, '.csv')) -NoTypeInformation -Encoding utf8
}

$manifest = Get-Content -LiteralPath $manifestFile -Raw | ConvertFrom-Json -AsHashtable
if ($manifest.schemaVersion -ne 1 -or $manifest.metadata.key -isnot [string] -or
    $manifest.metadata.key -cnotmatch '^[A-Za-z_][A-Za-z0-9_.-]*$' -or $manifest.metadata.value -isnot [string] -or
    $manifest.metadata.value -match '[\x00-\x1F\x7F]' -or $manifest.articles -isnot [array] -or !$manifest.articles.Count) {
    throw 'Expected schemaVersion 1, a top-level metadata key, a single-line string value, and an articles array'
}
$paths = [Collections.Generic.HashSet[string]]::new($pathComparer)
$resolved = [Collections.Generic.Dictionary[string, string]]::new($pathComparer)
foreach ($entry in $manifest.articles) {
    if ($entry.path -isnot [string] -or !$entry.path -or $entry.group -isnot [string] -or $entry.group -cnotmatch '^[a-z0-9][a-z0-9-]*$' -or
        $entry.classification -cnotin @('candidate', 'review', 'excluded') -or
        $entry.reason -isnot [string] -or !$entry.reason.Trim() -or $entry.evidence -isnot [string] -or !$entry.evidence.Trim()) {
        throw 'Each article needs a path, group ID, classification, reason, and evidence'
    }
    $path = Resolve-ArticlePath $entry.path
    if (!$paths.Add($path)) {
        throw "Duplicate article path: $($entry.path)"
    }
    $resolved[$entry.path] = $path
}

if ($Mode -eq 'Preview') {
    if ($ApprovedGroups.Count -or $ApprovedPaths.Count) {
        throw 'Approval arguments are valid only in Apply mode'
    }
    foreach ($entry in $manifest.articles) {
        if ($entry.classification -eq 'excluded') {
            $entry.currentValue = $null
            $entry.sha256 = Get-Hash ([IO.File]::ReadAllBytes($resolved[$entry.path]))
            $entry.expectedSha256 = $entry.sha256
            $entry.status = 'excluded'
            continue
        }
        $article = Read-Article $resolved[$entry.path]
        $edit = Get-Edit $article $manifest.metadata.key $manifest.metadata.value
        $entry.currentValue = $edit.CurrentValue
        $entry.sha256 = $article.Hash
        $entry.expectedSha256 = Get-Hash $edit.Bytes
        $entry.status = $(if ($entry.sha256 -ceq $entry.expectedSha256) { 'already-correct' } else { 'pending' })
    }
    $manifest.repositoryRoot = $root
    $manifest.previewMetadata = @{ key = $manifest.metadata.key; value = $manifest.metadata.value }
    Save-Manifest
    $manifest.articles | Select-Object path, group, classification, status, currentValue
    return
}

if (!$ApprovedGroups.Count -and !$ApprovedPaths.Count) {
    throw 'Apply requires explicit ApprovedGroups or ApprovedPaths'
}
if (!$pathComparer.Equals($manifest.repositoryRoot, $root) -or
    $manifest.previewMetadata.key -cne $manifest.metadata.key -or $manifest.previewMetadata.value -cne $manifest.metadata.value) {
    throw 'Repository or proposed metadata changed; create a fresh preview'
}
$explicitPaths = [Collections.Generic.HashSet[string]]::new($pathComparer)
foreach ($path in $ApprovedPaths) {
    $fullPath = Resolve-ArticlePath $path
    if (!$paths.Contains($fullPath)) {
        throw "Approved path is not in the manifest: $path"
    }
    [void]$explicitPaths.Add($fullPath)
}
foreach ($group in $ApprovedGroups) {
    if (!@($manifest.articles | Where-Object { $_.group -ceq $group -and $_.classification -eq 'candidate' }).Count) {
        throw "Approved group has no candidate entries: $group"
    }
}
$selected = @($manifest.articles | Where-Object {
    $explicitPaths.Contains($resolved[$_.path]) -or ($_.classification -eq 'candidate' -and $_.group -cin $ApprovedGroups)
})
$plans = foreach ($entry in $selected) {
    if ($entry.classification -eq 'excluded') {
        throw "Excluded article cannot be approved: $($entry.path)"
    }
    $article = Read-Article $resolved[$entry.path]
    if ($entry.sha256 -cnotmatch '^[0-9a-f]{64}$' -or $entry.expectedSha256 -cnotmatch '^[0-9a-f]{64}$') {
        throw "Missing or invalid preview snapshot: $($entry.path)"
    }
    if ($article.Hash -cne $entry.sha256 -and $article.Hash -cne $entry.expectedSha256) {
        throw "Stale article; recheck scope and preview again: $($entry.path)"
    }
    $edit = Get-Edit $article $manifest.metadata.key $manifest.metadata.value
    if ((Get-Hash $edit.Bytes) -cne $entry.expectedSha256) {
        throw "Previewed result changed: $($entry.path)"
    }
    [pscustomobject]@{ Entry = $entry; Path = $resolved[$entry.path]; OriginalHash = $article.Hash; Bytes = $edit.Bytes }
}
$changed = 0
$skipped = 0
try {
    foreach ($plan in $plans) {
        [void](Resolve-ArticlePath $plan.Entry.path)
        if ((Get-Hash ([IO.File]::ReadAllBytes($plan.Path))) -cne $plan.OriginalHash) {
            throw "Article changed during apply: $($plan.Entry.path)"
        }
        if ($plan.OriginalHash -cne $plan.Entry.expectedSha256) {
            [IO.File]::WriteAllBytes($plan.Path, $plan.Bytes)
            if ((Get-Hash ([IO.File]::ReadAllBytes($plan.Path))) -cne $plan.Entry.expectedSha256) {
                throw "Article write did not match the preview: $($plan.Entry.path)"
            }
            $changed++
        }
        else {
            $skipped++
        }
        if ($plan.Entry.sha256 -cne $plan.Entry.expectedSha256) {
            $plan.Entry.status = 'applied'
        }
    }
}
finally {
    Save-Manifest
}
[pscustomobject]@{
    Selected = $selected.Count
    Changed = $changed
    AlreadyAtDesiredResult = $skipped
    Remaining = @($manifest.articles | Where-Object { $_.classification -ne 'excluded' -and $_.status -eq 'pending' }).Count
    ManifestPath = $manifestFile
    ReportPath = [IO.Path]::ChangeExtension($manifestFile, '.csv')
}
