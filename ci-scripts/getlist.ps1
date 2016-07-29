## Script that gets the list of projects that need to be built.
## Spec reference:https://microsoft.sharepoint.com/teams/CE_CSI/_layouts/OneNote.aspx?id=%2Fteams%2FCE_CSI%2FSiteAssets%2FCE_CSI%20Notebook&wd=target%28Samples%20CI%2FGeneral%20Architecture.one%7CAF430CFB-930B-4949-BD23-198A8485E1C9%2FSpec%7CB6587481-E481-450D-BDF2-2C2E2C2E70B3%2F%29
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 7/29/2016

$homePath = (Get-Item -Path ".\" -Verbose).FullName

[System.Collections.ArrayList]$globalProjects = Get-ChildItem $homePath -Recurse | where {$_.Name -eq "global.json"}
[System.Collections.ArrayList]$singleProjects = Get-ChildItem $homePath -Recurse | where {$_.Name -eq "project.json" }

$itemsToRemove = New-Object "System.Collections.Generic.List[System.Object]"

foreach($item in $singleProjects){
    foreach ($blockedItem in $globalProjects){
        if ($item.Directory.ToString().StartsWith($blockedItem.Directory.ToString() + "\")){
            $itemsToRemove.Add($item)
            break
        }
    }
}

Write-Host "Single projects before cleanup: " $singleProjects.Count

foreach($target in $itemsToRemove)
{
    Write-Host "Removing " $target.Directory " from the list of single projects."
    $singleProjects.Remove($target)
}

Write-Host "Single projects after cleanup: " $singleProjects.Count

$singleProjects | Format-Table FullName -HideTableHeaders | Out-File single.projects
$globalProjects | Format-Table FullName -HideTableHeaders | Out-File global.projects
