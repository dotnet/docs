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
