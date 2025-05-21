---
title: PowerShell client module
description: Learn about the PowerShell client module in .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# PowerShell client module

The Orleans PowerShell client module is a set of [PowerShell Cmdlets](/powershell/scripting/developer/cmdlet/cmdlet-overview) that wraps the <xref:Orleans.GrainClient>. It provides a set of convenient commands, that make it possible to interact with _not_ just the `ManagementGrain` but any `IGrain` just as a regular Orleans application can by using PowerShell scripts.

These cmdlets enable a series of scenarios from start maintenance tasks, tests, monitoring, or any other kind of automation by leveraging PowerShell scripts.

## Install the module

To install this module from the source, you can build using the `OrleansPSUtils` project and just import it with:

```powershell
Import-Module .\projectOutputDir\Orleans.psd1
```

Although you can do that, there is a much easier and more interesting way by installing it from **PowerShell Gallery**. PowerShell modules are easily shared, much like Nuget packages, but instead of nuget.org, they are hosted on the [PowerShell Gallery](https://www.powershellgallery.com).

To install this module from the PowerShell gallery, run the following command in the desired folder:

```powershell
Save-Module -Name OrleansPSUtils -Path <path>
```

To install it on your PowerShell modules path (**the recommended way**), run:

```powershell
Install-Module -Name OrleansPSUtils
```

If you plan to use this module on an [Azure Automation](/azure/automation/overview), [use this link](https://www.powershellgallery.com/packages/Orleans/1.0.0/DeployItemToAzureAutomation?itemType=PSModule&requireLicenseAcceptance=False).

## Use the module

Regardless of the way you decide to install it, you need to import the module on the current PowerShell session so the cmdlets get available by running this:

```powershell
Import-Module OrleansPSUtils
```

> [!IMPORTANT]
> In case of building from source, you must import it as suggested on the [Install the module](#install-the-module) section by using the path to the `.psd1` instead of using the module name since it will not be on the `$env:PSModulePath` PowerShell runtime variable. It is highly recommended that you install from PowerShell Gallery instead.

After the module is imported (which means it is loaded on PowerShell session), you will have the following cmdlets available:

* `Start-GrainClient`
* `Stop-GrainClient`
* `Get-Grain`

### Start the `GrainClient`

This module is a wrapper around <xref:Orleans.GrainClient.Initialize?displayProperty=nameWithType> and its overloads.

#### `Start-GrainClient`

The same as a call to <xref:Orleans.GrainClient.Initialize?displayProperty=nameWithType>, which will look for the known Orleans client configuration file names:

```powershell
Start-GrainClient [-ConfigFilePath] <string> [[-Timeout] <timespan>]
```

The preceding command will use the provided file path as in `GrainClient.Initialize(filePath)`.

```powershell
Start-GrainClient [-ConfigFile] <FileInfo> [[-Timeout] <timespan>]
```

The preceding command will use an instance of the <xref:System.IO.FileInfo> class representing the config file just as `GrainClient.Initialize(fileInfo)`.

```powershell
Start-GrainClient [-Config] <ClientConfiguration> [[-Timeout] <timespan>]
```

The preceding command will use an instance of a <xref:Orleans.Runtime.Configuration.ClientConfiguration> like in `GrainClient.Initialize(config)`.

```powershell
Start-GrainClient [-GatewayAddress] <IPEndPoint> [[-OverrideConfig] <bool>] [[-Timeout] <timespan>]
```

The preceding command takes an Orleans cluster gateway address endpoint.

> [!TIP]
> The `Timeout` parameter is optional and if it is informed and greater than <xref:System.TimeSpan.Zero?displayProperty=nameWithType>, it will call <xref:Orleans.GrainClient.SetResponseTimeout(System.TimeSpan)?displayProperty=nameWithType> internally.

#### Stop the `GrainClient`

To stop the `GrainClient`, call the following command:

```powershell
Stop-GrainClient
```

The preceding command takes no parameters and when called, if the `GrainClient` is initialized will be gracefully uninitialized.

#### Get a `Grain`

To get a `Grain`, this cmdlet is a wrapper around `GrainClient.GrainFactory.GetGrain<T>()` and its overloads. The mandatory parameter is `-GrainType` and the `-XXXKey` for the current Grain key types supported by Orleans (`string`, `Guid`, `long`) and also the `-KeyExtension` that can be used on Grains with compound keys.

This cmdlet returns a grain reference of the type passed by as a parameter on `-GrainType`. As an example on calling `MyInterfacesNamespace.IMyGrain.SayHelloTo` grain method:

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

There are additional cmdlets not discussed, but there is support for _Observers_, _Streams_ and other Orleans core features more natively on PowerShell.

> [!NOTE]
> The intent is not to reimplement the whole client on PowerShell but instead, give IT and DevOps teams a way to interact with the grains without needing to implement a .NET application.
