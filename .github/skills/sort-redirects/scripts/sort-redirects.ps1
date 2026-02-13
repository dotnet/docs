<#
.SYNOPSIS
    Sorts an Open Publishing redirection JSON file alphabetically by source_path.

.DESCRIPTION
    This script finds a redirection JSON file in the root of the current repository
    and sorts all redirection entries alphabetically by source_path.

.PARAMETER RedirectionFile
    The name of the redirection JSON file. Defaults to '.openpublishing.redirection.json'.

.EXAMPLE
    .\sort-redirects.ps1

.EXAMPLE
    .\sort-redirects.ps1 -RedirectionFile ".openpublishing.redirection.winforms.json"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $false)]
    [string]$RedirectionFile = ".openpublishing.redirection.json"
)

# Find the root of the git repository
function Get-GitRepoRoot {
    $currentPath = Get-Location
    while ($currentPath -ne $null) {
        if (Test-Path (Join-Path $currentPath ".git")) {
            return $currentPath.Path
        }
        $parentPath = Split-Path $currentPath -Parent
        if ($parentPath -eq $currentPath) {
            break
        }
        $currentPath = $parentPath
    }
    return $null
}

# Main script logic
try {
    # Find repo root
    $repoRoot = Get-GitRepoRoot
    if (-not $repoRoot) {
        Write-Error "Could not find git repository root. Make sure you're running this script from within a git repository."
        exit 1
    }

    Write-Host "Repository root: $repoRoot" -ForegroundColor Cyan

    # Build full path to redirection file
    $redirectionFilePath = Join-Path $repoRoot $RedirectionFile

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

    # Sort the redirections alphabetically by source_path
    $sortedRedirections = $jsonContent.redirections | Sort-Object -Property source_path

    # Update the JSON object with sorted redirections
    $jsonContent.redirections = $sortedRedirections

    # Convert back to JSON with proper formatting
    $jsonOutput = $jsonContent | ConvertTo-Json -Depth 10

    # Write the updated JSON back to the file
    $jsonOutput | Set-Content -Path $redirectionFilePath -Encoding UTF8

    Write-Host ""
    Write-Host "Successfully sorted $originalCount redirection entries alphabetically by source_path" -ForegroundColor Green
    Write-Host "File updated: $redirectionFilePath" -ForegroundColor Green

}
catch {
    Write-Error "An error occurred: $_"
    exit 1
}
