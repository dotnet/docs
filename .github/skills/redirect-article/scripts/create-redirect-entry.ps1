<#
.SYNOPSIS
    Adds a new redirection entry to an Open Publishing redirection JSON file.

.DESCRIPTION
    This script finds a redirection JSON file in the root of the current repository
    and adds a new redirection entry. The entry is inserted alphabetically by source_path.

.PARAMETER RedirectionFile
    The name of the redirection JSON file. Defaults to '.openpublishing.redirection.json'.

.PARAMETER SourcePath
    The source path of the article being redirected (relative to repo root).
    Example: 'dotnet-desktop-guide/wpf/controls/old-article.md'

.PARAMETER RedirectUrl
    The destination URL to redirect to.
    Example: '/dotnet/desktop/wpf/controls/new-article'

.EXAMPLE
    .\create-redirect-entry.ps1 -SourcePath "dotnet-desktop-guide/wpf/controls/old-article.md" -RedirectUrl "/dotnet/desktop/wpf/controls/new-article"

.EXAMPLE
    .\create-redirect-entry.ps1 -RedirectionFile ".openpublishing.redirection.winforms.json" -SourcePath "dotnet-desktop-guide/winforms/controls/old-control.md" -RedirectUrl "/dotnet/desktop/winforms/controls/new-control"
#>

[CmdletBinding()]
param(
    [Parameter(Mandatory = $false)]
    [string]$RedirectionFile = ".openpublishing.redirection.json",

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

    # Check if entry already exists
    $existingEntry = $jsonContent.redirections | Where-Object { $_.source_path -eq $SourcePath }
    if ($existingEntry) {
        Write-Warning "A redirection entry for '$SourcePath' already exists."
        Write-Warning "Existing redirect_url: $($existingEntry.redirect_url)"
        exit 1
    }

    # Create new redirection entry
    $newEntry = [PSCustomObject]@{
        source_path  = $SourcePath
        redirect_url = $RedirectUrl
    }

    # Convert redirections to a list for easier manipulation
    $redirectionsList = [System.Collections.ArrayList]@($jsonContent.redirections)

    # Find the correct position to insert (alphabetically by source_path)
    $insertIndex = 0
    for ($i = 0; $i -lt $redirectionsList.Count; $i++) {
        if ($redirectionsList[$i].source_path -gt $SourcePath) {
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
    # Use a custom approach to match the existing file format
    $jsonOutput = $jsonContent | ConvertTo-Json -Depth 10

    # Write the updated JSON back to the file
    $jsonOutput | Set-Content -Path $redirectionFilePath -Encoding UTF8

    Write-Host ""
    Write-Host "Successfully added redirection entry:" -ForegroundColor Green
    Write-Host "  Source:      $SourcePath" -ForegroundColor White
    Write-Host "  Redirect to: $RedirectUrl" -ForegroundColor White
    Write-Host "  Inserted at index: $insertIndex" -ForegroundColor Gray
    Write-Host ""
    Write-Host "File updated: $redirectionFilePath" -ForegroundColor Green

}
catch {
    Write-Error "An error occurred: $_"
    exit 1
}
