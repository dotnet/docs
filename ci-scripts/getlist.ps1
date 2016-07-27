## Script that gets the list of projects that need to be built.
## Spec reference:https://microsoft.sharepoint.com/teams/CE_CSI/_layouts/OneNote.aspx?id=%2Fteams%2FCE_CSI%2FSiteAssets%2FCE_CSI%20Notebook&wd=target%28Samples%20CI%2FGeneral%20Architecture.one%7CAF430CFB-930B-4949-BD23-198A8485E1C9%2FSpec%7CB6587481-E481-450D-BDF2-2C2E2C2E70B3%2F%29
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 7/27/2016

$HomePath = (Get-Item -Path ".\" -Verbose).FullName

$globalProjects = Get-ChildItem $HomePath -Recurse | where {$_.Name -eq "global.json"}

$globalProjects | Format-Table -Auto

$FullOutput = Get-ChildItem $HomePath -Recurse | where {$_.Name -eq "project.json"}
$FullOutput | Format-Table FullName -HideTableHeaders | Out-File single.projects