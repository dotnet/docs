## Script that iteratively builds the samples in the repository
## Spec reference:https://microsoft.sharepoint.com/teams/CE_CSI/_layouts/OneNote.aspx?id=%2Fteams%2FCE_CSI%2FSiteAssets%2FCE_CSI%20Notebook&wd=target%28Samples%20CI%2FGeneral%20Architecture.one%7CAF430CFB-930B-4949-BD23-198A8485E1C9%2FSpec%7CB6587481-E481-450D-BDF2-2C2E2C2E70B3%2F%29
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 7/29/2016

## This is needed for JSON parsing
[System.Reflection.Assembly]::LoadWithPartialName("System.Web.Extensions")

$homePath = (Get-Item -Path ".\" -Verbose).FullName

$logIdentifier = [Guid]::NewGuid().ToString()
$logFile = "$homePath\$logIdentifier.txt"

$buildResults = @{}

Function LogWrite
{
   Param ([string]$logString)
   Write-Host $logString
   Add-content $logFile -value $logString
}

Function ProcessBuildCommand ($command, $activePath)
{
    $pinfo = New-Object System.Diagnostics.ProcessStartInfo
    $pinfo.FileName = "powershell.exe"
    $pinfo.RedirectStandardError = $true
    $pinfo.RedirectStandardOutput = $true
    $pinfo.UseShellExecute = $false
    $pinfo.Arguments = "-Command $command"
    $p = New-Object System.Diagnostics.Process
    $p.StartInfo = $pinfo
    $p.Start() | Out-Null
    $p.WaitForExit()
    $stdout = $p.StandardOutput.ReadToEnd()
    $stderr = $p.StandardError.ReadToEnd()
    
    LogWrite "OUT: $stdout"
    LogWrite "ERROR: $stderr"
    LogWrite "EXCODE: "$p.ExitCode

    if ($p.ExitCode) 
    {
        LogWrite "[][$activePath] Failure with current operation."
    }
    else
    {
        LogWrite "[][$activePath] Operation succeeded."
    }

    ## Add the current build result to the dictionary that tracks the overall success.
    $buildResults.Add($activePath, $p.ExitCode)
}

## =============================================
## Global Projects
## =============================================

LogWrite "===== Bootstraping build for global projects... ====="

$Content = Get-Content "$homePath\global.projects" | Foreach-Object {
    if ($_) {

        $restorePath = (Get-Item $_.ToString().Trim()).Directory.ToString()
        LogWrite "Bootstraping restore on $restorePath..."

        $rawJson = Get-Content $_

        $ser = New-Object System.Web.Script.Serialization.JavaScriptSerializer
        $globalObject = $ser.DeserializeObject($rawJson)
        $projects = $globalObject.projects

        $customCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $restorePath `| dotnet restore "

        ProcessBuildCommand $customCommand $restorePath

        LogWrite "Restore complete."
        
        foreach($project in $projects)
        {
            $comboPath = Join-Path $Folder $project
            
            $singleProjectContainer = Get-ChildItem $comboPath -Recurse | where {$_.Name -eq "project.json" }

            if ($singleProjectContainer -is [System.IO.FileInfo])
            {
                $projectPath = Split-Path -parent $singleProjectContainer.FullName

                $customCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $projectPath `| dotnet build "

                ProcessBuildCommand $customCommand $projectPath
            }
            else 
            {
                foreach($sProject in $singleProjects)
                {
                    $projectPath = Split-Path -parent $sProject.FullName
                    $customCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $projectPath `| dotnet build "

                    ProcessBuildCommand $customCommand $projectPath
                }
            }
        }
    }
}

LogWrite "Total samples built by now: " $buildResults.Count
LogWrite "===== Building of global projects is complete. ====="

## =============================================
## Single Projects
## =============================================
LogWrite "===== Bootstraping build for single projects... ====="
$Content = Get-Content "$homePath\single.projects" | Foreach-Object {
    if ($_) {

        $projectPath = (Get-Item $_.ToString().Trim()).Directory.ToString()
        LogWrite "Working on $projectPath..."

        $CustomCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $projectPath `| dotnet restore `| dotnet build "
        
        ProcessBuildCommand $CustomCommand $projectPath
    }
}

LogWrite "Total samples built by now: " $buildResults.Count
LogWrite "===== Building of single projects is complete. ====="

## Obviously the color does nothing when this shows up in the VSTS console.
LogWrite ($buildResults | Out-String) -ForegroundColor Yellow

$brutalFailures = @($buildResults.GetEnumerator())| where {$_.Value -eq 1}
$numberOfBrutalFailures = $brutalFailures.Count

LogWrite "Number of brutal failures in this build: " $numberOfBrutalFailures

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