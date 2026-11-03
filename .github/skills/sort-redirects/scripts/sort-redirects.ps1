<#
.SYNOPSIS
    Sorts an Open Publishing redirection JSON file alphabetically by path.

.DESCRIPTION
    This script sorts all redirection entries in a JSON file alphabetically by path.
    It handles both 'source_path_from_root' and 'source_path' properties, normalizing
    paths by stripping leading '/' for consistent sorting.

.PARAMETER RedirectionFile
    The name of the redirection JSON file (e.g., '.openpublishing.redirection.csharp.json').

.EXAMPLE
    .\sort-redirects.ps1 -RedirectionFile ".openpublishing.redirection.csharp.json"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string]$RedirectionFile
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

    # Check if file exists
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

    $originalCount = $jsonContent.redirections.Count
    Write-Host "Total redirections found: $originalCount" -ForegroundColor Cyan

    # Sort the redirections alphabetically by normalized path
    $sortedRedirections = $jsonContent.redirections | Sort-Object -Property { Get-NormalizedPath -Path (Get-EntrySourcePath -Entry $_) }

    # Update the JSON object with sorted redirections
    $jsonContent.redirections = $sortedRedirections

    # Convert back to JSON with proper formatting
    $jsonOutput = $jsonContent | ConvertTo-Json -Depth 10

    # Write the updated JSON back to the file
    $jsonOutput | Set-Content -Path $redirectionFilePath -Encoding UTF8

    Write-Host ""
    Write-Host "Successfully sorted $originalCount redirection entries alphabetically" -ForegroundColor Green
    Write-Host "File updated: $redirectionFilePath" -ForegroundColor Green

}
catch {
    Write-Error "An error occurred: $_"
    exit 1
}
