<#

.SYNOPSIS
    Reads the output.json file and outputs status to GitHub Actions

.DESCRIPTION
    Reads the output.json file and outputs status to GitHub Actions

.INPUTS
    None

.OUTPUTS
    None

.NOTES
    Version:        1.0
    Author:         adegeo@microsoft.com
    Creation Date:  06/17/2020
    Purpose/Change: Initial release
#>

[CmdletBinding()]
Param(
)

$json = Get-Content output.json | ConvertFrom-Json

$errors = $json | Where-Object ErrorCount -ne 0 | Select-Object InputFile -ExpandProperty Errors | Select-Object InputFile, Error, Line

if ($errors.Count -eq 0) {
    Write-Host "All builds passed"
    exit 0
}

Write-Host "Total errors: $($errors.Count)"

foreach ($er in $errors) {
    Write-Host "::error file=$($er.InputFile)::----FILE:  $($er.InputFile)"
    Write-Host "::error file=$($er.InputFile)::    ERROR: $($er.Error)"
    Write-Host "::error file=$($er.InputFile)::    LINE:  $($er.Line)"
}

exit 1