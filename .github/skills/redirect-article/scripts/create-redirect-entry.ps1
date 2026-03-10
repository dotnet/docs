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
    $jsonContent = Get-Content -Path $redirectionFilePath -Raw | ConvertFrom-Json

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

    # Create new redirection entry using source_path_from_root (preferred)
    $newEntry = [PSCustomObject]@{
        source_path_from_root = $sourcePathWithRoot
        redirect_url          = $RedirectUrl
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

    # Insert the new entry at the correct position
    $redirectionsList.Insert($insertIndex, $newEntry)

    # Update the JSON object
    $jsonContent.redirections = $redirectionsList.ToArray()

    # Convert back to JSON with proper formatting
    $jsonOutput = $jsonContent | ConvertTo-Json -Depth 10

    # Write the updated JSON back to the file
    $jsonOutput | Set-Content -Path $redirectionFilePath -Encoding UTF8

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
