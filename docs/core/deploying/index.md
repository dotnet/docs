---
title: .NET Core Application Deployment 
description: .NET Core Application Deployment 
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: da7a31a0-8072-4f23-82aa-8a19184cb701
---

# .NET Core Application Deployment #

You can deploy your .NET Core app in either of two ways:

- As a portable app. A portable app relies on a shared system-wide version of the .NET Core framework that is present on a system. Portable applications are .dll files that can be launched by using the [dotnet utility](../tools/dotnet.md) from the command line. For example, `dotnet app.dll` runs a portable application named `app`.

- As a self-contained application. All components, including .NET Core itself, are included with the application and are isolated from other .NET Core applications. Self-contained applications include an executable (such as `app.exe` on Windows platforms for a self-contained application named `app`), which is  a renamed version of the platform-specific .NET Core host, and a .dll file (such as `app.dll`), which is the actual application.

For more information on .NET Core application types, see [.NET Core App Types](../app-types.md).

## Portable Applications ##

For a portable app, you deploy only your app and any third-party dependencies. You do not have to deploy .NET Core, since your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core apps.

### Why Deploy a Portable App? ###

Deploying a portable app has a number of advantages:

- You do not have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see [.NET Assembly File Format](../../standard/assembly-format.md).

- The size of your deployment package is small. You only have to deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system.

- It is possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

### Deploying a Simple Portable App ###

Deploying a portable app with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process. The example uses the [dotnet utility](../tools/dotnet.md) from the command line; however, you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project, and from the command line, type [dotnet new](../tools/dotnet-new.md) to create a new C# console project.

2. Open the `Program.cs` file in an editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

    ```cs
    using System;
    using System.Text.RegularExpressions;

    namespace Applications.ConsoleApps
    {
        public class ConsoleParser
        {
            public static void Main()
            {
                 Console.WriteLine("Enter any text, followed by <Enter>:\n");
                 String s = Console.ReadLine();
                 ShowWords(s);
                 Console.Write("\nPress any key to continue... ");
                 Console.ReadKey();
          }

          private static void ShowWords(String s)
          {
              String pattern = @"\w+";
              var matches = Regex.Matches(s, pattern);
              if (matches.Count == 0)
                  Console.WriteLine("\nNo words were identified in your input.");
              else
              {
                  Console.WriteLine("\nThere are {0} words in your string:", matches.Count);
                  for (int ctr = 0; ctr < matches.Count; ctr++)
                      Console.WriteLine("   #{0,2}: '{1}' at position {2}", ctr,
                                        matches[ctr].Value, matches[ctr].Index);
              }
          }
      }
    }
    ```

3. Run the [dotnet restore](../tools/dotnet-restore.md) command to restore the dependencies specified in your project.

4. Create a debug build of your app by using the [dotnet build](../tools/dotnet-build.md) command.

5. After you've debugged and tested the program, you can create the files to be deployed with your app by using the `dotnet publish -f netcoreapp1.0 -c release` command. This creates a release (rather than a debug) version of your app.

   The resulting files are placed in a directory named `publish` that is in a subdirectory of your project's `.\bin\release\netcoreapp1.0` subdirectory.

6. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.

The complete set of application  files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice.

Before deploying your app, you can also use `crossgen` to convert it to native code. However, its performance impact is smaller than for self-contained apps. For more information, see the [Native Image Generation](#crossgen) section.

In addition to the application binaries, the installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access since it is machine-wide.

### Deploying a Portable App with Third-Party Dependencies ###

Deploying a portable app with one or more third-party dependencies involves three additional steps before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `dependencies` section of your `project.json` file. The following  `dependencies` section uses Json.NET as a third-party library.

    ```json
    "dependencies": {
      "Microsoft.NETCore.App": {
        "type": "platform",
        "version": "1.0.0"
      },
      "Newtonsoft.Json": "9.0.1"
    },
    ```

2. If you haven't already, download the NuGet package containing the third-party dependency. To download the package, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

Note that a portable app with third-party dependencies will only be as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app will not be portable to Windows systems.

When you deploy your application, any third-party dependencies used in your app are resolved from the local NuGet cache of the system on which your app is running. In other words, the third-party library must be present on the target machine for your app to run successfully.

## Self-Contained Applications ##

For a self-contained app, you deploy not only your app and any third-party dependencies, but the version of .NET Core that you build your app with.

### Why Deploy a Self-Contained App? ###

Deploying a self-contained app has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

### <a name="simpleSelf"></a> Deploying a Simple Self-Contained App ###

Deploying a self-contained app with no third-party dependencies involves creating the project, modifying the project.json file, building, testing, and publishing the app.  A simple example written in C# illustrates the process. The example uses the `dotnet` utility from the command line; however, you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project, and from the command line, type `dotnet new` to create a new C# console project.

2. Open the `Program.cs` file in an editor, and replace the auto-generated code with the following code. It prompts the user to enter text, and then displays the individual words entered by the user. It uses the regular expression `\w+` to separate the words in the input text.

    ```cs
    using System;
    using System.Text.RegularExpressions;

    namespace Applications.ConsoleApps
    {
        public class ConsoleParser
        {
            public static void Main()
            {
                 Console.WriteLine("Enter any text, followed by <Enter>:\n");
                 String s = Console.ReadLine();
                 ShowWords(s);
                 Console.Write("\nPress any key to continue... ");
                 Console.ReadKey();
          }

          private static void ShowWords(String s)
          {
              String pattern = @"\w+";
              var matches = Regex.Matches(s, pattern);
              if (matches.Count == 0)
                  Console.WriteLine("\nNo words were identified in your input.");
              else {
                  Console.WriteLine("\nThere are {0} words in your string:", matches.Count);
                  for (int ctr = 0; ctr < matches.Count; ctr++)
                      Console.WriteLine("   #{0,2}: '{1}' at position {2}", ctr,
                                        matches[ctr].Value, matches[ctr].Index);
              }
          }
      }
    }
    ```

3. Open the `project.json` file and replace the `frameworks` section with the following:

    ```json
    "frameworks": {
      "netstandard1.6": { }
    }
    ```

This does two things:

    * It indicates that, instead of using the entire `netcoreapp1.0` framework, which includes .NET Core CLR, the .NET Core Library, and a number of other system components, our app uses only the .NET Standard Library.

    * By removing the `"type": "platform"` attribute, it indicates that the framework is provided as a set of components local to our app, rather than as a system-wide platform package.

4. Replace the `dependencies` section with the following:

    ```json
    "dependencies": {
      "NETStandard.Library": "1.6.0",
      "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
      "Microsoft.NETCore.DotNetHostPolicy":  "1.0.1"
    },
    ```
   This defines the system components used by our app. The system components packaged with our app include the .NET Standard Library, the .NET Core runtime, and the .NET Core host. This produces a self-contained app with a smaller footprint than if you had simply modified the `frameworks` section to indicate that your app is providing the entire `netcoreapp1.0` framework.

5. Create a `runtimes` section in your `project.json` file that defines the platforms your app targets and specify the runtime identifier of each platform that you target. See [Runtime IDentifier catalog](../rid-catalog.md) for a list of runtime identifiers. For example, the following `runtimes` section indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.10 operating system.

    ```json
        "runtimes": {
          "win10-x64": {},
          "osx.10.10-x64": {}
        }
    ```
Note that you also need to add a comma to separate the `runtimes` section from the previous section.
A complete sample `project.json` file appears later in this section.

6. Run the `dotnet restore` command to restore the dependencies specified in your project.

7. Create debug builds of your app on each of the target platforms by using the `dotnet build` command. Unless you specify the runtime identifier you'd like to build, the `dotnet build` command creates a build only for the current system's runtime ID. You can build your app for both target platforms with the commands:

    ```console
    dotnet build -r win10-x64
    dotnet build -r osx.10.10-x64
    ```

8. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets by using the `dotnet publish` command for both target platforms as follows:

   ```console
   dotnet publish -c release -r win10-x64
   dotnet publish -c release -r osx.10.10-x64
   ```

This creates a release (rather than a debug) version of your app for each target platform. The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netstandard1.6\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

9. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.

The published files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice. Before packaging and deploying your app, you can also use `crossgen` to convert it to native code. For more information, see the [Native Image Generation](#crossgen) section.

The following is the complete `project.json` file for this project.

```json
   {
     "version": "1.0.0-*",
     "buildOptions": {
       "debugType": "portable",
       "emitEntryPoint": true
     },
     "dependencies": {
       "NETStandard.Library": "1.6.0",
       "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
       "Microsoft.NETCore.DotNetHostPolicy":  "1.0.1"
     },
     "frameworks": {
       "netstandard1.6": { }
     },
     "runtimes": {
       "win10-x64": {},
       "osx.10.10-x64": {}
     }
   }
```

## Deploying a Self-Contained App with Third-Party Dependencies ##

Deploying a self-contained app with one or more third-party dependencies involves three additional steps before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `dependencies` section of your `project.json` file. The following  `dependencies` section uses Json.NET as a third-party library.

    ```json
    "dependencies": {
      "NETStandard.Library": "1.6.0",
      "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
      "Microsoft.NETCore.DotNetHostPolicy":  "1.0.1",
      "Newtonsoft.Json": "9.0.1"
    },
    ```

2. If you haven't already, download the NuGet package containing the third-party dependency. To download the package, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

When you deploy your application, any third-party dependencies used in your app are also contained with your application files. Third-party libraries do not already have to be present on the system on which the app is running.

Note that you can only deploy a self-contained app with a third-party library to platforms supported by that library.

## Deploying a Modular Self-Contained App ##

The previous two sections on deploying a self-contained app created and deployed an app that contained the entire .NET Core library. You can also deploy a modular self-contained app that includes only the .NET Core assemblies actually needed by your app.

The word parsing example shown earlier in the [Deploying a Simple Self-Contained App](#simpleSelf) section uses the console, which is defined in the System.Console assembly, and the regular expression engine, which is defined in the System.Text.RegularExpressions assembly. Instead of deploying all of the .NET Standard Library with our app, we can deploy just the assemblies we need, the dependencies of those assemblies, and the libraries that contain basic .NET Core types. This requires a modification of the `dependencies` section of our project.json file:

```json
  "dependencies": {
    "System.Console": "4.0.0",
    "System.Text.RegularExpressions": "4.1.0",
    "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
    "Microsoft.NETCore.DotNetHostPolicy": "1.0.1"
  },
```

For more information, see [Reducing Package Dependencies with project.json](reducing-dependencies.md).

Otherwise, the steps required to create a modular self-contained appl are the same as those listed in the [Deploying a Simple Self-Contained App](#simpleSelf) section. The result is an app with a much smaller footprint than the self-contained app that includes the entire .NET Core Class Library. 

The complete project.json file for this modular self-contained app is:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "emitEntryPoint": true
  },
  "dependencies": {
    "System.Console": "4.0.0",
    "System.Text.RegularExpressions": "4.1.0",
    "Microsoft.NETCore.Runtime.CoreCLR": "1.0.2",
    "Microsoft.NETCore.DotNetHostPolicy": "1.0.1"
  },
  "frameworks": {
    "netstandard1.6": {}
  },
  "runtimes": {
    "win10-x64": {},
    "osx.10.10-x64": {}
  }
}
```

## <a name="crossgen"></a> Native Image Generation ##

NET Core uses a just in time (JIT) compiler that stores application code in an intermediate format and compiles it to native code at runtime.  To increase startup performance, the shared framework is pre-compiled using a tool called `crossgen`.  To improve performance of your application, you can use the same tool on your application's binaries.  Its performance impact is more noticeable when deploying a standalone application, since the entire framework is part of the application. Crossgen must be run on a machine of the same platform type that you are targeting, but need not be done on the same machine, unlike ngen for the desktop framework.  If you are producing a platform-specific installer for your application, we recommend that you crossgen as part of the installer build process.
