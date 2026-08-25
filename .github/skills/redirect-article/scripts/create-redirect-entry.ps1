<#
.SYNOPSIS
    Adds a new redirection entry to an Open Publishing redirection JSON file.

.DESCRIPTION
    This script adds a new redirection entry to the specified JSON file. The entry
    is inserted alphabetically by path. The script handles both 'source_path_from_root'
    (preferred) and 'source_path' properties when reading existing entries.

.PARAMETER RedirectionFile
    The name of the redirection JSON file (e.g., '.openpublishing.redirection.csharp.json').

.PARAMETER SourcePath
    The source path of the article being redirected (relative to repo root).
    Example: 'docs/csharp/fundamentals/old-article.md'

.PARAMETER RedirectUrl
    The destination URL to redirect to.
    Example: '/dotnet/csharp/fundamentals/new-article'

.EXAMPLE
    .\create-redirect-entry.ps1 -RedirectionFile ".openpublishing.redirection.csharp.json" -SourcePath "docs/csharp/fundamentals/old-article.md" -RedirectUrl "/dotnet/csharp/fundamentals/new-article"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$RedirectionFile,

    [Parameter(Mandatory = $true)]
    [string]$SourcePath,

    [Parameter(Mandatory = $true)]
    [string]$RedirectUrl
)

# Find the root of the git repository
function Get-GitRepoRoot {
    $currentPath = (Get-Location).Path
    while ($currentPath -ne $null) {
        if (Test-Path (Join-Path $currentPath ".git")) {
            return $currentPath
        }
        $parentPath = Split-Path $currentPath -Parent
        if ($parentPath -eq $currentPath) {
            break
        }
        $currentPath = $parentPath
    }
    return $null
}

# Get the source path from a redirection entry (handles both properties)
function Get-EntrySourcePath {
    param($Entry)
    if ($Entry.source_path_from_root) {
        return $Entry.source_path_from_root
    }
    return $Entry.source_path
}

# Normalize a path for comparison (strip leading /)
function Get-NormalizedPath {
    param([string]$Path)
    return $Path.TrimStart('/')
}

# Main script logic
try {
    # Normalize SourcePath (remove leading / if present for consistent handling)
    $normalizedSourcePath = Get-NormalizedPath -Path $SourcePath

    # Determine the redirection file path
    if ([System.IO.Path]::IsPathRooted($RedirectionFile)) {
        # Absolute path provided
        $redirectionFilePath = $RedirectionFile
    }
    else {
        # Relative path - find repo root and join
        $repoRoot = Get-GitRepoRoot
        if (-not $repoRoot) {
            Write-Error "Could not find git repository root. Make sure you're running this script from within a git repository."
            exit 1
        }
        Write-Host "Repository root: $repoRoot" -ForegroundColor Cyan
        $redirectionFilePath = Join-Path $repoRoot $RedirectionFile
    }

    if (-not (Test-Path $redirectionFilePath)) {
        Write-Error "Redirection file not found: $redirectionFilePath"
        exit 1
    }

    Write-Host "Redirection file: $redirectionFilePath" -ForegroundColor Cyan

    # Read and parse the JSON file
    $rawFileContent = Get-Content -Path $redirectionFilePath -Raw
    $originalLineEnding = if ($rawFileContent -match '\r\n') { "`r`n" } else { "`n" }
    $jsonContent = $rawFileContent | ConvertFrom-Json

    # Check if redirections array exists
    if (-not $jsonContent.redirections) {
        Write-Error "Invalid redirection file format. Expected 'redirections' array not found."
        exit 1
    }

    # Check if entry already exists (check both source_path_from_root and source_path)
    $sourcePathWithRoot = "/$normalizedSourcePath"
    $existingEntry = $jsonContent.redirections | Where-Object { 
        (Get-NormalizedPath -Path (Get-EntrySourcePath -Entry $_)) -eq $normalizedSourcePath
    }
    if ($existingEntry) {
        $existingPath = Get-EntrySourcePath -Entry $existingEntry
        Write-Warning "A redirection entry for '$existingPath' already exists."
        Write-Warning "Existing redirect_url: $($existingEntry.redirect_url)"
        exit 1
    }

    # Convert redirections to a list for easier manipulation
    $redirectionsList = [System.Collections.ArrayList]@($jsonContent.redirections)

    # Find the correct position to insert (alphabetically by normalized path)
    $insertIndex = 0
    for ($i = 0; $i -lt $redirectionsList.Count; $i++) {
        $existingNormalizedPath = Get-NormalizedPath -Path (Get-EntrySourcePath -Entry $redirectionsList[$i])
        if ($existingNormalizedPath -gt $normalizedSourcePath) {
            $insertIndex = $i
            break
        }
        $insertIndex = $i + 1
    }

    # ---------------------------------------------------------------------------
    # NOTE: The block below (commented out) used ConvertTo-Json to rebuild the
    # entire file. This caused indentation reformatting because ConvertTo-Json
    # always outputs 2-space indentation regardless of the original file style.
    # Kept here for reference only.
    # ---------------------------------------------------------------------------
    # $newEntry = [PSCustomObject]@{
    #     source_path_from_root = $sourcePathWithRoot
    #     redirect_url          = $RedirectUrl
    # }
    # $redirectionsList.Insert($insertIndex, $newEntry)
    # $jsonContent.redirections = $redirectionsList.ToArray()
    # $jsonOutput = $jsonContent | ConvertTo-Json -Depth 10
    # $jsonOutput = $jsonOutput -replace '\r\n', "`n"
    # if ($originalLineEnding -eq "`r`n") { $jsonOutput = $jsonOutput -replace "`n", "`r`n" }
    # [System.IO.File]::WriteAllText($redirectionFilePath, $jsonOutput, (New-Object System.Text.UTF8Encoding $false))
    # ---------------------------------------------------------------------------

    # Raw text injection - splices the new entry into the file without touching
    # any other lines, preserving original indentation and formatting exactly.

    $lines = if ($originalLineEnding -eq "`r`n") {
        $rawFileContent -split '\r\n'
    } else {
        $rawFileContent -split '\n'
    }

    # Detect indentation from a sample source_path line and the entry { line above it
    $sampleFieldLineIdx = -1
    for ($i = 0; $i -lt $lines.Count; $i++) {
        if ($lines[$i] -match '^\s+"source_path') {
            $sampleFieldLineIdx = $i
            break
        }
    }
    $fieldIndent = if ($sampleFieldLineIdx -ge 0 -and $lines[$sampleFieldLineIdx] -match '^(\s+)') { $Matches[1] } else { "        " }
    # Walk back from the field line to find the entry's opening { and use its indentation
    $entryIndent = ""
    if ($sampleFieldLineIdx -ge 1) {
        for ($i = $sampleFieldLineIdx - 1; $i -ge 0; $i--) {
            if ($lines[$i] -match '^(\s*)\{\s*$') {
                $entryIndent = $Matches[1]
                break
            }
        }
    }

    # Core lines of the new entry (closing brace has no comma yet - added below per context)
    $newEntryCore = @(
        "$entryIndent{",
        "$fieldIndent`"source_path_from_root`": `"$sourcePathWithRoot`",",
        "$fieldIndent`"redirect_url`": `"$RedirectUrl`"",
        "$entryIndent}"
    )

    $outputLines = [System.Collections.ArrayList]@()

    if ($insertIndex -lt $redirectionsList.Count) {
        # Middle or beginning: insert before the entry currently at $insertIndex.
        # Find that entry's source path in the raw lines to locate its opening {.
        $targetPath = Get-EntrySourcePath -Entry $redirectionsList[$insertIndex]
        $targetLineIdx = -1
        for ($i = 0; $i -lt $lines.Count; $i++) {
            if ($lines[$i] -match [regex]::Escape($targetPath)) {
                $targetLineIdx = $i
                break
            }
        }
        if ($targetLineIdx -lt 0) {
            Write-Error "Could not locate insertion point in file for: $targetPath"
            exit 1
        }
        # Walk back to find the opening { of that entry
        $entryStartIdx = $targetLineIdx
        for ($i = $targetLineIdx - 1; $i -ge 0; $i--) {
            if ($lines[$i].Trim() -eq '{') {
                $entryStartIdx = $i
                break
            }
        }
        # Emit: lines before insertion point, new entry with trailing comma, then rest
        for ($i = 0; $i -lt $entryStartIdx; $i++) { $null = $outputLines.Add($lines[$i]) }
        for ($i = 0; $i -lt ($newEntryCore.Length - 1); $i++) { $null = $outputLines.Add($newEntryCore[$i]) }
        $null = $outputLines.Add("$entryIndent},")   # closing brace with comma (next entry follows)
        for ($i = $entryStartIdx; $i -lt $lines.Count; $i++) { $null = $outputLines.Add($lines[$i]) }
    } else {
        # Append at end: the current last entry has no trailing comma; add one, then
        # insert the new entry (no trailing comma) before the closing ].
        $closingBracketIdx = -1
        for ($i = $lines.Count - 1; $i -ge 0; $i--) {
            if ($lines[$i].TrimStart() -match '^\]\s*$') {
                $closingBracketIdx = $i
                break
            }
        }
        if ($closingBracketIdx -lt 0) {
            Write-Error "Could not find closing ] of redirections array"
            exit 1
        }
        # Find the closing } of the last entry (immediately before the ])
        $lastCloserIdx = -1
        for ($i = $closingBracketIdx - 1; $i -ge 0; $i--) {
            $trimmed = $lines[$i].Trim()
            if ($trimmed -eq '}' -or $trimmed -eq '},') {
                $lastCloserIdx = $i
                break
            }
        }
        if ($lastCloserIdx -lt 0) {
            Write-Error "Could not find last entry closing brace"
            exit 1
        }
        # Emit: all lines up to (not including) last }, then last } with comma,
        # then new entry (no trailing comma), then closing ] onward
        for ($i = 0; $i -lt $lastCloserIdx; $i++) { $null = $outputLines.Add($lines[$i]) }
        $null = $outputLines.Add("$entryIndent},")   # previous last entry now has a comma
        foreach ($l in $newEntryCore) { $null = $outputLines.Add($l) }   # new entry, no trailing comma
        for ($i = $closingBracketIdx; $i -lt $lines.Count; $i++) { $null = $outputLines.Add($lines[$i]) }
    }

    $outputContent = $outputLines -join $originalLineEnding
    [System.IO.File]::WriteAllText($redirectionFilePath, $outputContent, (New-Object System.Text.UTF8Encoding $false))

    Write-Host ""
    Write-Host "Successfully added redirection entry:" -ForegroundColor Green
    Write-Host "  Source:      $sourcePathWithRoot" -ForegroundColor White
    Write-Host "  Redirect to: $RedirectUrl" -ForegroundColor White
    Write-Host "  Inserted at index: $insertIndex" -ForegroundColor Gray
    Write-Host ""
    Write-Host "File updated: $redirectionFilePath" -ForegroundColor Green

}
catch {
    Write-Error "An error occurred: $_"
    exit 1
}
