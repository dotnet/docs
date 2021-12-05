---
title: Runtime config options
description: Learn how to configure .NET applications by using runtime configuration settings.
ms.date: 07/23/2021
---
# .NET runtime configuration settings

.NET 5+ (including .NET Core versions) supports the use of configuration files and environment variables to configure the behavior of .NET applications at run time. Runtime configuration is an attractive option if:

- You don't own or control the source code for an application and therefore are unable to configure it programmatically.

- Multiple instances of your application run at the same time on a single system, and you want to configure each for optimum performance.

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to address the issue. For information about submitting pull requests for the dotnet/docs repository, see the [contributor's guide](/contribute/dotnet/dotnet-contribute).

.NET provides the following mechanisms for configuring application behavior at run time:

- The [runtimeconfig.json file](#runtimeconfigjson)

- [MSBuild properties](#msbuild-properties)

- [Environment variables](#environment-variables)

> [!TIP]
> Configuring a run-time option by using an environment variable applies the setting to all .NET apps. Configuring a run-time option in the *runtimeconfig.json* or project file applies the setting to that application only.

Some configuration values can also be set programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.

The articles in this section of the documentation are organized by category, for example, [debugging](debugging-profiling.md) and [garbage collection](garbage-collector.md). Where applicable, configuration options are shown for *runtimeconfig.json* files, MSBuild properties, environment variables, and, for cross-reference, *app.config* files for .NET Framework projects.

## runtimeconfig.json

When a project is [built](../tools/dotnet-build.md), an *[appname].runtimeconfig.json* file is generated in the output directory. If a *runtimeconfig.template.json* file exists in the same folder as the project file, any configuration options it contains are inserted into the *[appname].runtimeconfig.json* file. If you're building the app yourself, put any configuration options in the *runtimeconfig.template.json* file. If you're just running the app, insert them directly into the *[appname].runtimeconfig.json* file.

> [!NOTE]
>
> - The *[appname].runtimeconfig.json* file will get overwritten on subsequent builds.
> - If your app's `OutputType` is not `Exe` and you want configuration options to be copied from *runtimeconfig.template.json* to *[appname].runtimeconfig.json*, you must explicitly set `GenerateRuntimeConfigurationFiles` to `true` in your project file. For apps that require a *runtimeconfig.json* file, this property defaults to `true`.

Specify runtime configuration options in the **configProperties** section of the *runtimeconfig.json* files. This section has the form:

```json
"configProperties": {
  "config-property-name1": "config-value1",
  "config-property-name2": "config-value2"
}
```

### Example [appname].runtimeconfig.json file

If you're placing the options in the output JSON file, nest them under the `runtimeOptions` property.

```json
{
  "runtimeOptions": {
    "tfm": "netcoreapp3.1",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "3.1.0"
    },
    "configProperties": {
      "System.GC.Concurrent": false,
      "System.Threading.ThreadPool.MinThreads": 4,
      "System.Threading.ThreadPool.MaxThreads": 25
    }
  }
}
```

### Example runtimeconfig.template.json file

If you're placing the options in the template JSON file, omit the `runtimeOptions` property.

```json
{
  "configProperties": {
    "System.GC.Concurrent": false,
    "System.Threading.ThreadPool.MinThreads": "4",
    "System.Threading.ThreadPool.MaxThreads": "25"
  }
}
```

## MSBuild properties

Some runtime configuration options can be set using MSBuild properties in the *.csproj* or *.vbproj* file of SDK-style .NET Core projects. MSBuild properties take precedence over options set in the *runtimeconfig.template.json* file.

Here is an example SDK-style project file with MSBuild properties for configuring run-time behavior:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
  </PropertyGroup>

  <PropertyGroup>
    <ConcurrentGarbageCollection>false</ConcurrentGarbageCollection>
    <ThreadPoolMinThreads>4</ThreadPoolMinThreads>
    <ThreadPoolMaxThreads>25</ThreadPoolMaxThreads>
  </PropertyGroup>

</Project>
```

MSBuild properties for configuring run-time behavior are noted in the individual articles for each area, for example, [garbage collection](garbage-collector.md). They are also listed in the [Runtime configuration](../project-sdk/msbuild-props.md#runtime-configuration-properties) section of the MSBuild properties reference for SDK-style projects.

## Environment variables

Environment variables can be used to supply some runtime configuration information. Configuring a run-time option by using an environment variable applies the setting to all .NET Core apps. Configuration knobs specified as environment variables generally have the prefix **DOTNET_**.

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
