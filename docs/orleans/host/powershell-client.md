---
title: PowerShell client module
description: Learn about the PowerShell client module in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
ms.service: orleans
---

# PowerShell client module

The Orleans PowerShell client module is a set of [PowerShell Cmdlets](/powershell/scripting/developer/cmdlet/cmdlet-overview) wrapping the <xref:Orleans.GrainClient>. It provides convenient commands allowing interaction not just with the `ManagementGrain` but with any `IGrain`, just as a regular Orleans application can, by using PowerShell scripts.

These cmdlets enable various scenarios, from starting maintenance tasks, tests, monitoring, or any other kind of automation by leveraging PowerShell scripts.

## Install the module

To install this module from the source, build the `OrleansPSUtils` project and import it using:

```powershell
Import-Module .\projectOutputDir\Orleans.psd1
```

Although you can do that, a much easier and more interesting way is to install it from the **PowerShell Gallery**. PowerShell modules are easily shared, much like NuGet packages, but instead of nuget.org, they are hosted on the [PowerShell Gallery](https://www.powershellgallery.com).

To install this module from the PowerShell Gallery, run the following command in the desired folder:

```powershell
Save-Module -Name OrleansPSUtils -Path <path>
```

To install it in your PowerShell modules path (**the recommended way**), run:

```powershell
Install-Module -Name OrleansPSUtils
```

If you plan to use this module in [Azure Automation](/azure/automation/overview), [use this link](https://www.powershellgallery.com/packages/Orleans/1.0.0/DeployItemToAzureAutomation?itemType=PSModule&requireLicenseAcceptance=False).

## Use the module

Regardless of how you install it, you need to import the module into the current PowerShell session to make the cmdlets available. Run this command:

```powershell
Import-Module OrleansPSUtils
```

> [!IMPORTANT]
> If building from source, you must import it as suggested in the [Install the module](#install-the-module) section, using the path to the `.psd1` file instead of the module name, since it won't be in the `$env:PSModulePath` PowerShell runtime variable. We highly recommend installing from the PowerShell Gallery instead.

After importing the module (loading it into the PowerShell session), the following cmdlets become available:

- `Start-GrainClient`
- `Stop-GrainClient`
- `Get-Grain`

### Start the `GrainClient`

This module wraps <xref:Orleans.GrainClient.Initialize?displayProperty=nameWithType> and its overloads.

#### `Start-GrainClient`

This is the same as calling <xref:Orleans.GrainClient.Initialize?displayProperty=nameWithType>, which looks for known Orleans client configuration file names:

```powershell
Start-GrainClient [-ConfigFilePath] <string> [[-Timeout] <timespan>]
```

The preceding command uses the provided file path, similar to `GrainClient.Initialize(filePath)`.

```powershell
Start-GrainClient [-ConfigFile] <FileInfo> [[-Timeout] <timespan>]
```

The preceding command uses an instance of the <xref:System.IO.FileInfo> class representing the config file, just like `GrainClient.Initialize(fileInfo)`.

```powershell
Start-GrainClient [-Config] <ClientConfiguration> [[-Timeout] <timespan>]
```

The preceding command uses an instance of <xref:Orleans.Runtime.Configuration.ClientConfiguration>, similar to `GrainClient.Initialize(config)`.

```powershell
Start-GrainClient [-GatewayAddress] <IPEndPoint> [[-OverrideConfig] <bool>] [[-Timeout] <timespan>]
```

The preceding command takes an Orleans cluster gateway address endpoint.

> [!TIP]
> The `Timeout` parameter is optional. If provided and greater than <xref:System.TimeSpan.Zero?displayProperty=nameWithType>, it internally calls <xref:Orleans.GrainClient.SetResponseTimeout(System.TimeSpan)?displayProperty=nameWithType>.

#### Stop the `GrainClient`

To stop the `GrainClient`, call the following command:

```powershell
Stop-GrainClient
```

The preceding command takes no parameters. When called, if the `GrainClient` is initialized, it will be gracefully uninitialized.

#### Get a `Grain`

To get a `Grain`, this cmdlet wraps `GrainClient.GrainFactory.GetGrain<T>()` and its overloads. The mandatory parameter is `-GrainType`. You also need the `-XXXKey` parameter corresponding to the grain key type supported by Orleans (`string`, `Guid`, `long`), and optionally the `-KeyExtension` parameter for grains with compound keys.

This cmdlet returns a grain reference of the type passed via the `-GrainType` parameter. Here's an example of calling the `MyInterfacesNamespace.IMyGrain.SayHelloTo` grain method:

```powershell
Import-Module OrleansPSUtils
$configFilePath = Resolve-Path(".\ClientConfig.xml").Path
Start-GrainClient -ConfigFilePath $configFilePath
Add-Type -Path .\MyGrainInterfaceAssembly.dll
$grainInterfaceType = [MyInterfacesNamespace.IMyGrain]
$grainId = [System.Guid]::Parse("A4CF7B5D-9606-446D-ACE9-C900AC6BA3AD")
$grain = Get-Grain -GrainType $grainInterfaceType -GuidKey $grainId
$message = $grain.SayHelloTo("Gutemberg").Result
Write-Output $message
Hello Gutemberg!
Stop-GrainClient
```

There are additional cmdlets not discussed here, but support exists for _Observers_, _Streams_, and other Orleans core features more natively in PowerShell.

> [!NOTE]
> The intent isn't to reimplement the entire client in PowerShell but rather to give IT and DevOps teams a way to interact with grains without needing to implement a full .NET application.
