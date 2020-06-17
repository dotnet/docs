<#

.SYNOPSIS
    Invokes dotnet build on the samples sln and project files.

.DESCRIPTION
    Invokes dotnet build on the samples sln and project files.

.PARAMETER RepoRootDir
    The directory of the repository files on the local machine.

.PARAMETER PullRequest
    The pull requst to process. If 0 or not passed, processes the whole repo

.PARAMETER RepoOwner
    The name of the repository owner.
    
.PARAMETER RepoName
    The name of the repository.

.PARAMETER RangeStart
    A range of results to process.

.PARAMETER RangeEnd
    A range of results to process.

.INPUTS
    None

.OUTPUTS
    None

.NOTES
    Version:        1.1
    Author:         adegeo@microsoft.com
    Creation Date:  06/17/2020
    Purpose/Change: Initial release
#>

[CmdletBinding()]
Param(
    [Parameter(Mandatory = $true, ValueFromPipeline = $false)]
    [System.String] $RepoRootDir = $env:RepoRootDir,

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

Write-Host "Gathering solutions and projects..."

if ($PullRequest -ne 0) {
    Write-Host "Running `"LocateProjects `"$RepoRootDir`" --pullrequest $PullRequest --owner $RepoOwner --repo $RepoName`""
    $output = Invoke-Expression "LocateProjects `"$RepoRootDir`" --pullrequest $PullRequest --owner $RepoOwner --repo $RepoName"
}
else {
    Write-Host "Running `"LocateProjects `"$RepoRootDir`""
    $output = Invoke-Expression "LocateProjects `"$RepoRootDir`""
}

if ($LASTEXITCODE -ne 0)
{
    $output
    throw "Error on running LocateProjects"
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
            $projectFile = Resolve-Path "$RepoRootDir\$($data[2])"
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