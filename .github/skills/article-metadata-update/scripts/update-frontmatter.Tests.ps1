#Requires -Version 7.2
$ErrorActionPreference = 'Stop'
$script = Join-Path $PSScriptRoot 'update-frontmatter.ps1'
$testRoot = Join-Path ([IO.Path]::GetTempPath()) ('article-metadata-fixtures-' + [guid]::NewGuid().ToString('N'))
$fixtureRoot = Join-Path $testRoot 'articles'
$utf8 = [Text.UTF8Encoding]::new($false, $true)
[void](New-Item -ItemType Directory -Path $fixtureRoot)
$assertions = 0

function Assert {
    param([bool]$Condition, [string]$Message)
    if (!$Condition) { throw $Message }
    $script:assertions++
}
function Expect-Error {
    param([scriptblock]$Action, [string]$Pattern)
    try { & $Action }
    catch {
        Assert ($_.Exception.Message -like "*$Pattern*") "Unexpected error: $_"
        return
    }
    throw "Expected an error containing: $Pattern"
}
function Write-Fixture {
    param([string]$Name, [string]$Text, [bool]$Bom = $false)
    [byte[]]$bytes = $utf8.GetBytes($Text)
    if ($Bom) { $bytes = [byte[]](@(0xEF, 0xBB, 0xBF) + $bytes) }
    [IO.File]::WriteAllBytes((Join-Path $fixtureRoot $Name), $bytes)
}
function Snapshot {
    param([string]$Name)
    [Convert]::ToBase64String([IO.File]::ReadAllBytes((Join-Path $fixtureRoot $Name)))
}
function Make-Manifest {
    param([string]$Name, [object[]]$Entries, [string]$Value = '3650-days', [string]$Key = 'ms.update-cycle')
    $path = Join-Path $testRoot "$Name.json"
    $rows = foreach ($entry in $Entries) {
        if ($entry -is [string]) { $entry = @{ path = $entry; classification = 'candidate' } }
        @{
            path = $entry.path
            group = 'batch'
            classification = $entry.classification
            reason = 'Fixture scope'
            evidence = "$($entry.path):1: Fixture evidence"
        }
    }
    @{
        schemaVersion = 1
        metadata = @{ key = $Key; value = $Value }
        articles = @($rows)
    } | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $path -Encoding utf8
    $path
}
function Preview {
    param([string]$Manifest)
    $null = & $script -Mode Preview -RepositoryRoot $fixtureRoot -ManifestPath $Manifest
}
function Apply {
    param([string]$Manifest)
    & $script -Mode Apply -RepositoryRoot $fixtureRoot -ManifestPath $Manifest -ApprovedGroups batch
}

try {
    $tokens = $null
    $errors = $null
    [void][Management.Automation.Language.Parser]::ParseFile($script, [ref]$tokens, [ref]$errors)
    Assert ($errors.Count -eq 0) "Script parse errors: $errors"

    $body = "# Fixture`n`nms.update-cycle: unchanged body example`n"
    $base = "---`ntitle: Fixture`nms.date: 01/01/2020`n---`n$body"
    Write-Fixture 'lf.md' $base
    Write-Fixture 'bom.md' ($base.Replace("`n", "`r`n")) $true
    Write-Fixture 'old.md' ($base.Replace("ms.date: 01/01/2020`n", "ms.date: 01/01/2020`nms.update-cycle: '30-days' # preserve comment`n"))
    Write-Fixture 'plain.md' ($base.Replace("ms.date: 01/01/2020`n", "ms.date: 01/01/2020`nms.update-cycle: 3650-days`n"))
    Write-Fixture 'single.md' ($base.Replace("ms.date: 01/01/2020`n", "ms.date: 01/01/2020`nms.update-cycle: '3650-days' # retain quoting`n"))
    Write-Fixture 'double.md' ($base.Replace("ms.date: 01/01/2020`n", "ms.date: 01/01/2020`nms.update-cycle: `"3650-days`"`n"))
    Write-Fixture 'review.md' $base
    Write-Fixture 'excluded.md' $base
    $entries = @('lf.md', 'bom.md', 'old.md', 'plain.md', 'single.md', 'double.md',
        @{ path = 'review.md'; classification = 'review' }, @{ path = 'excluded.md'; classification = 'excluded' })
    $manifest = Make-Manifest main $entries
    $before = @{}
    foreach ($name in 'lf.md', 'bom.md', 'old.md', 'plain.md', 'single.md', 'double.md', 'review.md', 'excluded.md') {
        $before[$name] = Snapshot $name
    }
    Preview $manifest
    foreach ($name in $before.Keys) { Assert ((Snapshot $name) -ceq $before[$name]) "Preview edited $name" }
    Assert (Test-Path ([IO.Path]::ChangeExtension($manifest, '.csv'))) 'Preview omitted the report'
    Expect-Error { & $script -Mode Apply -RepositoryRoot $fixtureRoot -ManifestPath $manifest } 'explicit Approved'
    $result = Apply $manifest
    Assert ($result.Changed -eq 3 -and $result.Selected -eq 6 -and $result.AlreadyAtDesiredResult -eq 3) 'Incorrect group-selection counts'
    $expected = $base.Replace("ms.date: 01/01/2020`n", "ms.date: 01/01/2020`nms.update-cycle: 3650-days`n")
    Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'lf.md')) -ceq $expected) 'LF content changed outside the field'
    [byte[]]$expectedBom = @(0xEF, 0xBB, 0xBF) + $utf8.GetBytes($expected.Replace("`n", "`r`n"))
    Assert ((Snapshot 'bom.md') -ceq [Convert]::ToBase64String($expectedBom)) 'BOM or CRLF changed'
    Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'old.md')) -ceq $expected.Replace("ms.update-cycle: 3650-days`n", "ms.update-cycle: 3650-days # preserve comment`n")) 'Inline comment was lost'
    foreach ($name in 'plain.md', 'single.md', 'double.md', 'review.md', 'excluded.md') {
        Assert ((Snapshot $name) -ceq $before[$name]) "Unselected or correct article changed: $name"
    }
    $result = Apply $manifest
    Assert ($result.Changed -eq 0 -and $result.AlreadyAtDesiredResult -eq 6) 'Repeated apply was not idempotent'
    $result = & $script -Mode Apply -RepositoryRoot $fixtureRoot -ManifestPath $manifest -ApprovedPaths review.md
    Assert ($result.Changed -eq 1) 'Explicit review approval did not apply'
    Expect-Error { & $script -Mode Apply -RepositoryRoot $fixtureRoot -ManifestPath $manifest -ApprovedPaths excluded.md } 'Excluded article'
    Expect-Error { & $script -Mode Apply -RepositoryRoot $fixtureRoot -ManifestPath $manifest -ApprovedGroups missing } 'no candidate entries'
    $saved = Get-Content $manifest -Raw | ConvertFrom-Json
    Assert (@($saved.articles | Where-Object status -eq applied).Count -eq 4) 'Manifest did not record completion'

    Write-Fixture 'first.md' $base
    Write-Fixture 'stale.md' $base
    $manifest = Make-Manifest stale @('first.md', 'stale.md')
    Preview $manifest
    $firstBefore = Snapshot 'first.md'
    Write-Fixture 'stale.md' ($base + 'External edit')
    Expect-Error { Apply $manifest } 'Stale article'
    Assert ((Snapshot 'first.md') -ceq $firstBefore) 'Stale batch partly wrote articles'
    $data = Get-Content $manifest -Raw | ConvertFrom-Json -AsHashtable
    $data.metadata.value = 'different'
    $data | ConvertTo-Json -Depth 10 | Set-Content $manifest -Encoding utf8
    Expect-Error { Apply $manifest } 'proposed metadata changed'

    $badCases = @{
        'duplicate.md' = @{ Text = "---`ntitle: Fixture`nms.update-cycle: old`nms.update-cycle: older`n---`nBody"; Error = 'Duplicate frontmatter key' }
        'quoted-key.md' = @{ Text = "---`ntitle: Fixture`n'ms.update-cycle': old`n---`nBody"; Error = 'quoted frontmatter keys' }
        'merge.md' = @{ Text = "---`ntitle: Fixture`n<<: *defaults`n---`nBody"; Error = 'YAML merge keys' }
        'block.md' = @{ Text = "---`nms.update-cycle: |`n  old`n---`nBody"; Error = 'ambiguous target scalar' }
        'folded.md' = @{ Text = "---`nms.update-cycle: old`n  continuation`n---`nBody"; Error = 'Multiline or structured' }
        'list.md' = @{ Text = "---`nms.update-cycle: [old, older]`n---`nBody"; Error = 'ambiguous target scalar' }
        'missing.md' = @{ Text = 'No frontmatter'; Error = 'opening YAML frontmatter delimiters' }
        'spaced-duplicate.md' = @{ Text = "---`nms.update-cycle: old`nms.update-cycle : older`n---`nBody"; Error = 'Duplicate frontmatter key' }
        'indented.md' = @{ Text = "---`n  ms.update-cycle: old`n---`nBody"; Error = 'unindented mapping keys' }
        'flow.md' = @{ Text = "---`n{ms.update-cycle: old}`n---`nBody"; Error = 'unindented mapping keys' }
    }
    foreach ($name in $badCases.Keys) {
        Write-Fixture $name $badCases[$name].Text
        $manifest = Make-Manifest invalid @($name)
        $beforeBad = Snapshot $name
        Expect-Error { Preview $manifest } $badCases[$name].Error
        Assert ((Snapshot $name) -ceq $beforeBad) "Invalid article changed: $name"
    }
    $manifest = Make-Manifest traversal @('..\outside.md')
    Expect-Error { Preview $manifest } 'without traversal'
    [void](New-Item -ItemType Directory (Join-Path $fixtureRoot 'directory.md'))
    $manifest = Make-Manifest directory @('directory.md')
    Expect-Error { Preview $manifest } 'Expected an article file'
    [IO.File]::WriteAllText((Join-Path $fixtureRoot 'utf16.md'), $base, [Text.Encoding]::Unicode)
    $manifest = Make-Manifest utf16 @('utf16.md')
    Expect-Error { Preview $manifest } 'not valid UTF-8'
    $manifest = Make-Manifest duplicated @('lf.md', '.\lf.md')
    Expect-Error { Preview $manifest } 'Duplicate article path'

    foreach ($value in @('yes', '123', '2026-11-25', 'a: b # c', "it's fine", '')) {
        Write-Fixture 'scalar.md' "---`ntitle: Fixture`n---`nBody without final newline"
        $manifest = Make-Manifest scalar @('scalar.md') $value 'custom.key'
        Preview $manifest
        $null = Apply $manifest
        $expectedScalar = "'" + $value.Replace("'", "''") + "'"
        $expectedText = "---`ntitle: Fixture`ncustom.key: $expectedScalar`n---`nBody without final newline"
        Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'scalar.md')) -ceq $expectedText) "Unsafe YAML string output: $value"
        Preview $manifest
        $result = Apply $manifest
        Assert ($result.Changed -eq 0) "Quoted scalar was not idempotent: $value"
    }
    Write-Fixture 'comment.md' "---`ncustom.key: # empty value`n---`nBody"
    $manifest = Make-Manifest comment @('comment.md') '# empty value' 'custom.key'
    Preview $manifest
    $null = Apply $manifest
    Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'comment.md')) -ceq "---`ncustom.key: '# empty value' # empty value`n---`nBody") 'Empty comment-only value was treated as a string'
    Write-Fixture 'numeric.md' "---`ncustom.key: .01`n---`nBody"
    $manifest = Make-Manifest numeric @('numeric.md') '.01' 'custom.key'
    Preview $manifest
    $result = Apply $manifest
    Assert ($result.Changed -eq 1) 'A numeric YAML scalar was mistaken for an already-correct string'
    Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'numeric.md')) -ceq "---`ncustom.key: '.01'`n---`nBody") 'Numeric string was not quoted'
    Write-Fixture 'spaced.md' "---`ncustom.key  :   old # keep spacing`n---`nBody"
    $manifest = Make-Manifest spaced @('spaced.md') 'new-value' 'custom.key'
    Preview $manifest
    $null = Apply $manifest
    Assert ([IO.File]::ReadAllText((Join-Path $fixtureRoot 'spaced.md')) -ceq "---`ncustom.key  :   new-value # keep spacing`n---`nBody") 'Existing key spacing was lost or a duplicate key was added'
    "Passed $assertions assertions."
}
finally {
    Remove-Item -LiteralPath $testRoot -Recurse -Force
}
