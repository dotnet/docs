---
title: .NET Runtime config options
description: Learn how to configure the .NET runtime using configuration settings.
ms.topic: article
ms.date: 07/23/2021
---
# .NET runtime configuration settings

.NET provides the following mechanisms for configuring behavior of the .NET runtime:

| Mechanism                                         | Notes                                  |
|---------------------------------------------------|----------------------------------------|
| The [runtimeconfig.json file](#runtimeconfigjson) | Applies the setting to a specific app. Use this file if multiple instances of your app run at the same time on a single system, and you want to configure each for optimum performance. |
| [MSBuild properties](#msbuild-properties)         | Applies the setting to a specific app. MSBuild properties take precedence over settings in *runtimeconfig.json*. |
| [Environment variables](#environment-variables)   | Applies the setting to all .NET apps.  |

Some configuration values can also be set programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.

> [!NOTE]
> The articles in this section concern configuration of the .NET runtime itself. If you're migrating an app from .NET Framework to .NET and are looking for a replacement for the *app.config* file, see [Modernize after upgrading to .NET](../porting/modernize.md#appconfig). For information about supplying custom configuration values to .NET apps, see [Configuration in .NET](../extensions/configuration.md).

The articles in this section of the documentation are organized by category, for example, [debugging](debugging-profiling.md) and [garbage collection](garbage-collector.md). Where applicable, configuration options are shown for *runtimeconfig.json* files, MSBuild properties, environment variables, and, for cross-reference, *app.config* files for .NET Framework projects.

## runtimeconfig.json

When a project is [built](../tools/dotnet-build.md), an *[appname].runtimeconfig.json* file is generated in the output directory. If a *runtimeconfig.template.json* file exists in the same folder as the project file, any configuration options it contains are inserted into the *[appname].runtimeconfig.json* file. If you're building the app yourself, put any configuration options in the *runtimeconfig.template.json* file. If you're just running the app, insert them directly into the *[appname].runtimeconfig.json* file.

> [!NOTE]
>
> - The *[appname].runtimeconfig.json* file will get overwritten on subsequent builds.
> - If your app's `OutputType` is not `Exe` and you want configuration options to be copied from *runtimeconfig.template.json* to *[appname].runtimeconfig.json*, you must explicitly set `GenerateRuntimeConfigurationFiles` to `true` in your project file. For apps that require a *runtimeconfig.json* file, this property defaults to `true`.

Specify runtime configuration options in the **configProperties** section of the *runtimeconfig.json* or *runtimeconfig.template.json* file. This section has the form:

```json
"configProperties": {
  "config-property-name1": "config-value1",
  "config-property-name2": "config-value2"
}
```

### Example [appname].runtimeconfig.json file

If you're placing the options in the *output* JSON file, nest them under the `runtimeOptions` property.

```json
{
  "runtimeOptions": {
    "tfm": "net8.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "8.0.0"
    },
    "configProperties": {
      "System.Globalization.UseNls": true,
      "System.Net.DisableIPv6": true,
      "System.GC.Concurrent": false,
      "System.Threading.ThreadPool.MinThreads": 4,
      "System.Threading.ThreadPool.MaxThreads": 25
    }
  }
}
```

### Example runtimeconfig.template.json file

If you're placing the options in the *template* JSON file, **omit** the `runtimeOptions` property.

```json
{
  "configProperties": {
    "System.Globalization.UseNls": true,
    "System.Net.DisableIPv6": true,
    "System.GC.Concurrent": false,
    "System.Threading.ThreadPool.MinThreads": "4",
    "System.Threading.ThreadPool.MaxThreads": "25"
  }
}
```

## MSBuild properties

Some runtime configuration options can be set using MSBuild properties in the *.csproj* or *.vbproj* file of SDK-style .NET projects. MSBuild properties take precedence over options set in the *runtimeconfig.template.json* file.

For runtime configuration settings that don't have a specific MSBuild property, you can use the `RuntimeHostConfigurationOption` MSBuild item instead. Use the *runtimeconfig.json* setting name as the value of the `Include` attribute.

Here is an example SDK-style project file with MSBuild properties for configuring the behavior of the .NET runtime:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
  </PropertyGroup>

  <PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
    <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
    <ThreadPoolMaxThreads>25</ThreadPoolMaxThreads>
  </PropertyGroup>

  <ItemGroup>
    <RuntimeHostConfigurationOption Include="System.Globalization.UseNls" Value="true" />
    <RuntimeHostConfigurationOption Include="System.Net.DisableIPv6" Value="true" />
  </ItemGroup>

</Project>
```

MSBuild properties for configuring the behavior of the runtime are noted in the individual articles for each area, for example, [garbage collection](garbage-collector.md). They're also listed in the [Runtime configuration](../project-sdk/msbuild-props.md#runtime-configuration-properties) section of the MSBuild properties reference for SDK-style projects.

## Environment variables

Environment variables can be used to supply some runtime configuration information. Configuration knobs specified as environment variables generally have the prefix **DOTNET_**.

[!INCLUDE [complus-prefix](../../../includes/complus-prefix.md)]

You can define environment variables from the Windows Control Panel, at the command line, or programmatically by calling the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)?displayProperty=nameWithType> method on both Windows and Unix-based systems.

The following examples show how to set an environment variable at the command line:

```shell
# Windows
set DOTNET_GCRetainVM=1

# Powershell
$env:DOTNET_GCRetainVM="1"

# Unix
export DOTNET_GCRetainVM=1
```

## See also

- [.NET environment variables](../tools/dotnet-environment-variables.md)
