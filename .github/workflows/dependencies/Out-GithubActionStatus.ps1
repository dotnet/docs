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

if ((($json.ErrorCount).Count -eq 1) -and (($json.ErrorCount)[0] -eq 0)) {
    # Good status!
    Write-Host "::debug::All tests passed"
    exit 0
}
else {
    $errors = $json | Where-Object ErrorCount -ne 0 | Select-Object InputFile -ExpandProperty Errors | Select-Object InputFile, Error, Line
    
    Write-Host "Total errors: $($errors.Count)"

    foreach ($er in $errors) {
        Write-Error "----FILE: $($er.InputFile)`n    ERROR: $($er.Error)`n    LINE:$($er.Line)"
    }

    exit 1
}