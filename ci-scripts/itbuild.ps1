$HomePath = (Get-Item -Path ".\" -Verbose).FullName

$Content = Get-Content "$HomePath\test.txt" | Foreach-Object {
    if ($_) {
        $Folder = (Get-Item $_.ToString().Trim()).Directory.ToString()
        Write-Host "Working on $Folder..."
        $CustomCommand = "dotnet --version; `$core = Get-ChildItem Env:path;Write-Host `$path.Value;`$pathValue = `$core.Value -Replace 'C:\\Program Files\\dotnet','C:\\dotnet';Write-Host `$pathValue;`$env:Path = `$pathValue;dotnet --version;cd $Folder `| dotnet restore `| dotnet build 2>&1 `| Write-Host"
        
        powershell.exe -Command $CustomCommand
        if ($LastExitCode) {
            Write-Warning "Build for project failed."
        }
        else
        {
            Write-Host "Build for project OK."
        }
    }
}