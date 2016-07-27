## Script that iteratively builds the samples in the repository.
## Spec reference:https://microsoft.sharepoint.com/teams/CE_CSI/_layouts/OneNote.aspx?id=%2Fteams%2FCE_CSI%2FSiteAssets%2FCE_CSI%20Notebook&wd=target%28Samples%20CI%2FGeneral%20Architecture.one%7CAF430CFB-930B-4949-BD23-198A8485E1C9%2FSpec%7CB6587481-E481-450D-BDF2-2C2E2C2E70B3%2F%29
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 7/27/2016

$HomePath = (Get-Item -Path ".\" -Verbose).FullName

$buildResults = @{}

$Content = Get-Content "$HomePath\test.txt" | Foreach-Object {
    if ($_) {

        $Folder = (Get-Item $_.ToString().Trim()).Directory.ToString()
        Write-Host "Working on $Folder..."

        $CustomCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $Folder `| dotnet restore 2>&1 `| Write-Host `| dotnet build 2>&1 `| Write-Host "
        
        powershell.exe -Command $CustomCommand

        Write-Host "Exited with EXCODE: " $LastExitCode

        # Add the current build result to the dictionary that tracks the overall success.
        $buildResults.Add($Folder, $LastExitCode)

        if ($LastExitCode) {
            Write-Warning "Build for project failed."
        }
        else
        {
            Write-Host "Build for project OK."
        }
    }
}

Write-Host "Total samples built: " $buildResults.Count

Write-Host ($buildResults | Out-String) -ForegroundColor Yellow

$brutalFailures = $buildResults | where {$_.Value -eq 1}
$numberOfBrutalFailures = $brutalFailures.Count

Write-Host "Number of brutal failures in this build: " $numberOfBrutalFailures

if ($numberOfBrutalFailures > 0)
{
    exit 1
}
else {
    exit 0
}