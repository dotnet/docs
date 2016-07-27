$HomePath = (Get-Item -Path ".\" -Verbose).FullName
$FullOutput = Get-ChildItem $HomePath -Recurse | where {$_.Name -eq "project.json"}
$FullOutput | Format-Table FullName -HideTableHeaders | Out-File single.projects