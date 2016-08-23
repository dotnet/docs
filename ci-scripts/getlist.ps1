## Script that gets the list of projects that need to be built.
## This script it used by the VSTS build agents.
## Author: Den Delimarsky (dendeli)
## Last Modified: 8/12/2016

$homePath = (Get-Item -Path ".\" -Verbose).FullName
$corePath = $homePath + "\samples\core"

[System.Collections.ArrayList]$globalProjects = Get-ChildItem $corePath -Recurse | where {$_.Name -eq "global.json"}
[System.Collections.ArrayList]$singleProjects = Get-ChildItem $corePath -Recurse | where {$_.Name -eq "project.json" }

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

($singleProjects | select-object FullName | ConvertTo-Csv -NoTypeInformation | % { $_ -replace '"', ""} ) | Select-Object -Skip 1 | Set-Content -Path single.projects
($globalProjects | select-object FullName | ConvertTo-Csv -NoTypeInformation | % { $_ -replace '"', ""} ) | Select-Object -Skip 1 | Set-Content -Path global.projects
