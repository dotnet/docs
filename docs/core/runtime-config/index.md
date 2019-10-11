---
title: "Runtime configuration settings"
description: "Learn how to configure .NET Core applications by using runtime configuration settings."
ms.date: "06/19/2019"
---
# .NET Core runtime configuration settings

.NET Core supports the use of configuration files and environment variables to configure the behavior of .NET Core applications at runtime. Runtime configuration is an attractive option if:

- You do not own or control the source code for an application and therefore are unable to configure it programmatically.

- Multiple instances of your application may run at a single time on the same system, and you want to configure each for optimum performance.

> [!NOTE]
> This documentation is a work in progress. If you notice that the information presented here is either incomplete or inaccurate, either [open an issue](https://github.com/dotnet/docs/issues) to let us know about it, or [submit a pull request](https://github.com/dotnet/docs/pulls) to address the issue. For information on submitting pull requests for the dotnet/docs repo, see the [contributor's guide](https://github.com/dotnet/docs/blob/master/CONTRIBUTING.md).
 
.NET Core provides the following mechanisms for configuring applications at runtime:

- The **configProperties** section of the *runtimeconfig.json* file. This section has the form:

   ```json
   {
      "runtimeOptions": {
         "configProperties": {
            "config-property-name1": "config-value1",
            "config-property-name2": config-value2
         }
      }
   }
   ```

   For example:

   ```json
   {
      "runtimeOptions": {
         "configProperties": {
            "System.GC.Concurrent": true,
            "System.GC.RetainVM": true,
            "System.Threading.ThreadPool.MinThreads": 4,
            "System.Threading.ThreadPool.MaxThreads": 25
      }
   }
   ```

   The *runtimeconfig.json* file is automatically created in the build directory by the [dotnet build](../tools/dotnet-build.md) command as well as by selecting the **Build** menu option in Visual Studio. You can then edit he file once it is created.

   Some configuration values can also be set programmatically by calling the <xref:System.AppContext.SetSwitch%2A?displayProperty=nameWithType> method.

   See [Runtime configuration with runtimeconfig.json](runtimeconfig.md) for information on the available configuration options in *runtimeconfig.json*.

- Environment variables.

   You can define an environment variable to supply runtime configuration information. Environment variables can be defined at the command line either interactively or by using a script. They can also be defined programmatically by calling the <xref:System.Environment.SetEnvironmentVariable(System.String,System.String)?displayProperty=nameWithType> method on both Windows and Unix-based systems.

   See [Runtime configuration with environment variables](envvars.md) for a selection of the environment variables supported by .NET Core.
