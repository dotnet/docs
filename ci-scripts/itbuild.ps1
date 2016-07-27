$HomePath = (Get-Item -Path ".\" -Verbose).FullName

$buildResults = New-Object 'System.Collections.Generic.Dictionary[String,Int32]'

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