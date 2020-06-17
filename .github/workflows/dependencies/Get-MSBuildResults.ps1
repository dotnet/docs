<#

.SYNOPSIS
    Invokes dotnet build on the samples sln and project files.

.DESCRIPTION
    Invokes dotnet build on the samples sln and project files.

.PARAMETER ScanToolDir
    The directory of the LocateProjects tool source code.

.PARAMETER SamplesRootDir
    The directory of the samples.

.PARAMETER RangeStart
    A range of results to process.

.PARAMETER RangeEnd
    A range of results to process.

.INPUTS
    None

.OUTPUTS
    None

.NOTES
    Version:        1.0
    Author:         adegeo@microsoft.com
    Creation Date:  10/18/2019
    Purpose/Change: Initial release
#>

[CmdletBinding()]
Param(
    [Parameter(Mandatory = $true, ValueFromPipeline = $false)]
    [System.String] $SamplesRootDir = $env:samplesrootdir,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int64] $PullRequest = 0,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.String] $RepoOwner = "",

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.String] $RepoName = "",

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int32] $RangeStart = $env:rangestart,

    [Parameter(Mandatory = $false, ValueFromPipeline = $false)]
    [System.Int32] $RangeEnd = $env:rangeend
)

$Global:statusOutput = @()

#$ScanToolDir = "C:\code\work\dotnet\dotnet-docs-tools\LocateProjects\LocateProjects"
#$SamplesRootDir = "C:\code\work\dotnet\dotnet-docs\samples"

Write-Host "Gathering solutions and projects..."

if ($PullRequest -ne 0) {
    #$output = Invoke-Expression "LocateProjects `"$SamplesRootDir`" --pullrequest $PullRequest --owner $RepoOwner --repo $RepoName"
}
else {
    #$output = Invoke-Expression "LocateProjects `"$SamplesRootDir`""
}

$output = dir .\input.txt | Get-Content

if ($LASTEXITCODE -ne 0)
{
    throw "Error"
}

Write-Host "Found $($output.Count) items"

function New-Result($inputFile, $projectFile, $exitcode, $outputText)
{
    $info = @{}
    
    $info.InputFile = $inputFile
    $info.ProjectFile = $projectFile
    $info.ExitCode = $exitcode
    $info.Output = $outputText

    $object = New-Object -TypeName PSObject -Prop $info
    $Global:statusOutput += $object
}

$workingSet = $output

if (($RangeStart -ne 0) -and ($RangeEnd -ne 0)){
    $workingSet = $output[$RangeStart..$RangeEnd]
}

$counter = 1
$length = $workingSet.Count
$thisExitCode = 0

$ErrorActionPreference = "Continue"

foreach ($item in $workingSet) {
    try {
        Write-Host "$counter/$length"
        Write-Host "Processing $item"
        
        $data = $item.Split('|')

        # Project found, build it
        if ([int]$data[0] -eq 0) {
            $projectFile = Resolve-Path "$SamplesRootDir\$($data[2])"
            Write-Host "Running $projectFile"
            $result = Invoke-Expression "dotnet build `"$projectFile`""
            New-Result $data[1] $projectFile $LASTEXITCODE $result

            if ($LASTEXITCODE -ne 0) {
                $thisExitCode = 1
            }
        }

        # No project found
        elseif ([int]$data[0] -eq 1) {
            New-Result $data[1] "" 1 "No project found"
            $thisExitCode = 1;
        }

        # Too many projects found
        elseif ([int]$data[0] -eq 2) {
            New-Result $data[1] $data[2] 2 "Too many projects found"
            $thisExitCode = 2;
        }
    }
    catch {
        New-Result $data[1] $projectFile 1000 "ERROR: $($_.Exception)"
        $thisExitCode = 2
        Write-Host $_.Exception.Message -Foreground "Red"
        Write-Host $_.ScriptStackTrace -Foreground "DarkGray"
    }

    $counter++
}

#return $Global:statusOutput
$Global:statusOutput | Select-Object InputFile, ProjectFile, ExitCode, Output

exit $thisExitCode