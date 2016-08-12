## Script that iteratively builds the samples in the repository
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 8/12/2016

## This is needed for JSON parsing
[System.Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")

dotnet --version

$homePath = (Get-Item -Path ".\" -Verbose).FullName

$logIdentifier = [Guid]::NewGuid().ToString()
$logFile = "$homePath\$logIdentifier.buildlog"

$buildResults = @{}

Function LogWrite
{
   Param ([string]$logString)

   Write-Host $logString
   Add-content $logFile -value $logString
}

LogWrite $homePath

## =============================================
## Global Projects
## =============================================

LogWrite "===== Bootstraping build for global projects... ====="

$Content = Get-Content "$homePath\global.projects" | Foreach-Object {
    if ($_) {

        $restorePath = (Get-Item $_.ToString().Trim()).Directory.ToString()
        $restoreFileName = $_.ToString().Trim()

        LogWrite "Bootstraping restore on $restorePath..."

        $rawJson = Get-Content $restoreFileName
        LogWrite "Getting information for $restoreFileName..."

        $ser = New-Object System.Web.Script.Serialization.JavaScriptSerializer
        $globalObject = $ser.DeserializeObject($rawJson)
        $projects = $globalObject.projects

        LogWrite "Ready to work on restore for $restoreFileName. Executing command..."
        Write-Host $restorePath
        cd $restorePath

        dotnet restore | Write-Host
        $buildResults.Add(([GUID]::NewGuid()).GUID, $LastExitCode)

        LogWrite "Restore complete."

        foreach($project in $projects)
        {
            $comboPath = Join-Path $restorePath $project

            $singleProjectContainer = Get-ChildItem $comboPath -Recurse | where {$_.Name -eq "project.json" }

            if ($singleProjectContainer -is [System.IO.FileInfo])
            {
                $projectPath = Split-Path -parent $singleProjectContainer.FullName

                cd $projectPath
                dotnet build | Write-Host
                $buildResults.Add(([GUID]::NewGuid()).GUID, $LastExitCode)
            }
            else
            {
                foreach($sProject in $singleProjects)
                {
                    cd $projectPath
                    dotnet build | Write-Host
                    $buildResults.Add(([GUID]::NewGuid()).GUID, $LastExitCode)
                }
            }
        }
    }
}

$resultsCount = $buildResults.Count
LogWrite "Total samples built by now: $resultsCount"

LogWrite "===== Building of global projects is complete. ====="

## =============================================
## Single Projects
## =============================================
LogWrite "===== Bootstraping build for single projects... ====="
$Content = Get-Content "$homePath\single.projects" | Foreach-Object {
    if ($_) {

        $projectPath = (Get-Item $_.ToString().Trim()).Directory.ToString()
        LogWrite "Working on $projectPath..."

        cd $projectPath
        dotnet restore | Write-Host
        $buildResults.Add(([GUID]::NewGuid()).GUID, $LastExitCode)
        dotnet build | Write-Host
        $buildResults.Add(([GUID]::NewGuid()).GUID, $LastExitCode)
    }
}

$resultsCount = $buildResults.Count
LogWrite "Commands triggered that can result in errors: $resultsCount"
LogWrite "===== Building of single projects is complete. ====="

## Obviously the color does nothing when this shows up in the VSTS console.
LogWrite ($buildResults | Out-String) -ForegroundColor Yellow

$brutalFailures = @($buildResults.GetEnumerator())| where {$_.Value -eq 1}
$numberOfBrutalFailures = $brutalFailures.Count

LogWrite "Number of brutal failures in this build: $numberOfBrutalFailures"

## Check if we have any breaking errors - currently warnings are ignored as those do
## not impede the overall sample performance. Those are still logged.
if ($numberOfBrutalFailures -gt 0)
{
    LogWrite "Build failed. See log for details."
    exit 1
}
else
{
    exit 0
}
