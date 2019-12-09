---
title: Run-time config
description: Learn how to configure .NET Core applications by using run-time configuration settings.
ms.date: 11/13/2019
---
# .NET Core run-time configuration settings

.NET Core supports the use of configuration files and environment variables to configure the behavior of .NET Core applications at run time. Run-time configuration is an attractive option if:

- You don't own or control the source code for an application and therefore are unable to configure it programmatically.

- Multiple instances of your application run at the same time on a single system, and you want to configure each for optimum performance.

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to address the issue. For information on submitting pull requests for the dotnet/docs repository, see the [contributor's guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).

.NET Core provides the following mechanisms for configuring applications at run time:

- The [runtimeconfig.json file](#runtimeconfigjson)

- [Environment variables](#environment-variables)

The articles in this section of the documentation include are organized by category, for example, debugging and garbage collection. Where applicable, configuration options are shown for *runtimeconfig.json* (.NET Core only), *app.config* (.NET Framework only), and environment variables.

## runtimeconfig.json

Specify run-time configuration options in the **configProperties** section of the app's *runtimeconfig.json* file. This section has the form:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "config-property-name1": "config-value1",
         "config-property-name2": "config-value2"
      }
   }
}
```

Here is an example file:

```json
{
   "runtimeOptions": {
      "configProperties": {
         "System.GC.Concurrent": true,
         "System.GC.RetainVM": true,
         "System.Threading.ThreadPool.MinThreads": "4",
         "System.Threading.ThreadPool.MaxThreads": "25"
      }
   }
}
```

The *runtimeconfig.json* file is automatically created in the build directory by the [dotnet build](../tools/dotnet-build.md) command. It's also created when you select the **Build** menu option in Visual Studio. You can then edit the file once it's created.

Some configuration values can also be set programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.

## Environment variables

Environment variables can be used to supply some run-time configuration information. Configuration knobs specified as environment variables generally have the prefix **COMPlus_**.

You can define environment variables from the Windows Control Panel, at the command line, or programmatically by calling the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)?displayProperty=nameWithType> method on both Windows and Unix-based systems.

The following examples show how to set an environment variable at the command line:

```shell
# Windows
set COMPlus_GCRetainVM=1

# Powershell
$env:COMPlus_GCRetainVM="1"

# Unix
export COMPlus_GCRetainVM=1
```
