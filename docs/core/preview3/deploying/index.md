---
title: .NET Core Application Deployment | Microsoft Docs
description: .NET Core Application Deployment 
keywords: .NET, .NET Core, .NET Core deployment
author: rpetrusha
ms.author: ronpet
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: da7a31a0-8072-4f23-82aa-8a19184cb701
---

# .NET Core Application Deployment

You can create two types of deployments for .NET Core applications: 

- Framework-dependent deployment. As the name implies, framework-dependent deployment (FDD) relies on a shared system-wide version of .NET Core to be present on the target system. Because .NET Core is already present, your app is also portable between installations of .NET Core. Your app contains only its own code and any third-party dependencies that are outside of the .NET Core libraries. FDDs contain .dll files that can be launched by using the [dotnet utility](../tools/dotnet.md) from the command line. For example, `dotnet app.dll` runs an application named `app`.

- Self-contained deployment. Unlike FDD, a self-contained deployment (SCD) does not rely on any shared components to be present on the target system. All components, including both .NET Core libraries and the .NET Core runtime, are included with the application and are isolated from other .NET Core applications. SCDs include an executable (such as `app.exe` on Windows platforms for an application named `app`), which is  a renamed version of the platform-specific .NET Core host, and a .dll file (such as `app.dll`), which is the actual application.

## Framework-dependent deployments (FDD) ##

For an FDD, you deploy only your app and any third-party dependencies. You do not have to deploy .NET Core, since your app will use the version of .NET Core that's present on the target system. This is the default deployment model for .NET Core apps.

### Why create a framework-dependent deployment? ###

Deploying an FDD has a number of advantages:

- You do not have to define the target operating systems that your .NET Core app will run on in advance. Because .NET Core uses a common PE file format for executables and libraries regardless of operating system, .NET Core can execute your app regardless of the underlying operating system. For more information on the PE file format, see [.NET Assembly File Format](../../../standard/assembly-format.md).

- The size of your deployment package is small. You only have to deploy your app and its dependencies, not .NET Core itself.

- Multiple apps use the same .NET Core installation, which reduces both disk space and memory usage on host systems.

There are also a few disadvantages:

- Your app can run only if the version of .NET Core that you target, or a later version, is already installed on the host system.

- It is possible for the .NET Core runtime and libraries to change without your knowledge in future releases. In rare cases, this may change the behavior of your app.

### Deploying a framework-dependent deployment ###

Deploying a framework-dependent deployment with no third-party dependencies simply involves building, testing, and publishing the app. A simple example written in C# illustrates the process. The example uses the [dotnet utility](../tools/dotnet.md) from the command line; however, you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project; and from the command line, type `[dotnet new console](../tools/dotnet-new.md)` to create a new C# console project.

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

In addition to the application binaries, the installer should also either bundle the shared framework installer or check for it as a prerequisite as part of the application installation.  Installation of the shared framework requires Administrator/root access since it is machine-wide.

### Deploying a framework-dependent deployment with third-party dependencies ###

Deploying a framework-dependent deployment with one or more third-party dependencies involves three additional steps before you can run the `dotnet restore` command:

1. Add references to any third-party libraries to the `<ItemGroup>` section of your `csproj` file. The following  `<ItemGroup>` section shows the `<ItemGroup>` containing the dependencies in the default project with Json.NET as a third-party library.

    ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
      </ItemGroup>
    ```

 Note that the SDK dependency remains in the above example. This is by design, since this dependency is required to restore all the needed targets to allow the command line tools to function.  

2. If you haven't already, download the NuGet package containing the third-party dependency. To download the package, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

Note that a framework-dependent deployment with third-party dependencies will only be as portable as its third-party dependencies. For example, if a third-party library only supports macOS, the app will not be portable to Windows systems. This can happen if the third-party dependency itself depends on native code. A good example of this is Kestrel server. When an FDD is created for an application with this kind of third-party dependency, the published output will contain a folder for each [Runtime Identifier (RID)](../../rid-catalog.md#what-are-rids) that the native dependency supports (and that exists in its NuGet package).

## Self-contained deployments (SCD) ##

For a self-contained deployment, you deploy not only your app and any third-party dependencies, but the version of .NET Core that you build your app with. Creating an SCD does not, however, include the [native dependencies of .NET Core](https://github.com/dotnet/core/blob/master/Documentation/prereqs.md) itself on various platforms (for example, OpenSSL on macOS) so these need to be installed before running the application. 

### Why deploy a Self-contained deployment? ###

Deploying a Self-contained deployment has two major advantages:

- You have sole control of the version of .NET Core that is deployed with your app. .NET Core can be serviced only by you.

- You can be assured that the target system can run your .NET Core app, since you're providing the version of .NET Core that it will run on.

It also has a number of disadvantages:

- Because .NET Core is included in your deployment package, you must select the target platforms for which you build deployment packages in advance.

- The size of your deployment package is relatively large, since you have to include .NET Core as well as your app and its third-party dependencies.

- Deploying numerous self-contained .NET Core apps to a system can consume significant amounts of disk space, since each app duplicates .NET Core files.

### <a name="simpleSelf"></a> Deploying a simple self-contained deployment ###

Deploying a self-contained deployment with no third-party dependencies involves creating the project, modifying the csproj file, building, testing, and publishing the app.  A simple example written in C# illustrates the process. The example uses the `dotnet` utility from the command line; however, you can also use a development environment, such as Visual Studio or Visual Studio Code, to compile, test, and publish the example.

1. Create a directory for your project, and from the command line, type `dotnet new console` to create a new C# console project.

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

3. Create a `<RuntimeIdentifiers>` tag under the `<PropertyGroup>` section in your `csproj` file that defines the platforms your app targets, and specify the runtime identifier of each platform that you target. See [Runtime IDentifier catalog](../../rid-catalog.md) for a list of runtime identifiers. For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

    ```xml
        <PropertyGroup>
          <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
        </PropertyGroup>
    ```
Note that you also need to add a semicolon to separate the RIDs. Also, please note that the `<RuntimeIdentifier>` element can go into any `<PropertyGroup>` that you have in your `csproj` file. A complete sample `csproj` file appears later in this section.

4. Run the `dotnet restore` command to restore the dependencies specified in your project.

5. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets by using the `dotnet publish` command for both target platforms as follows:

   ```console
   dotnet publish -c release -r win10-x64
   dotnet publish -c release -r osx.10.11-x64
   ```
This creates a release (rather than a debug) version of your app for each target platform. The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netcoreapp1.0\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

6. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.

The published files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice. 

The following is the complete `csproj` file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.0</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
</Project>
```

### Deploying a self-contained deployment with third-party dependencies ###

Deploying a self-contained deployment with one or more third-party dependencies involves adding the third party dependency:

1. Add references to any third-party libraries to the `<ItemGroup>` section of your `csproj` file. The following  `<ItemGroup>` section uses Json.NET as a third-party library.

    ```xml
      <ItemGroup>
        <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
      </ItemGroup>
    ```
2. If you haven't already, download the NuGet package containing the third-party dependency to your system. To make the dependency available to your app, execute the `dotnet restore` command after adding the dependency. Because the dependency is resolved out of the local NuGet cache at publish time, it must be available on your system.

The following is the complete csproj file for this project:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp1.0</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Newtonsoft.Json" Version="9.0.1" />
  </ItemGroup>
</Project>
```

When you deploy your application, any third-party dependencies used in your app are also contained with your application files. Third-party libraries do not already have to be present on the system on which the app is running.

Note that you can only deploy a self-contained deployment with a third-party library to platforms supported by that library. This is similar to having third-party dependencies with native dependencies in your framework-dependent deployment. 

### Deploying a self-contained deployment with a smaller footprint ###

If the availability of adequate storage space on target systems is likely to be an issue, you can reduce the overall footprint of your app by excluding some system components. To do this, you explicitly define the .NET Core components that your app includes in your csproj file.

To create a self-contained deployment with a smaller footprint, start by following the first two steps for creating a self-contained deployment. Once you've run the `dotnet new console` command and added the C# source code to your app, do the following:

1. Open the `csproj` file and replace the `<TargetFramework>` element with the following:

  ```xml
  <TargetFramework>netstandard1.6</TargetFramework>
  ```
This operation indicates that, instead of using the entire `netcoreapp1.0` framework, which includes .NET Core CLR, the .NET Core Library, and a number of other system components, our app uses only the .NET Standard Library.

2. Replace the `<ItemGroup>` containing package references with the following:

  ```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.NETCore.Runtime.CoreCLR" Version="1.0.2" />
    <PackageReference Include="Microsoft.NETCore.DotNetHostPolicy" Version="1.0.1" />
  </ItemGroup>
  ```

   This defines the system components used by our app. The system components packaged with our app include the .NET Standard Library, the .NET Core runtime, and the .NET Core host. This produces a self-contained deployment with a smaller footprint.

3. As you did in the [Deploying a simple self-contained deployment](#simpleSelf) example, create a `<RuntimeIdentifiers>` element within a `<PropertyGroup>` in your `csproj` file that defines the platforms your app targets and specify the runtime identifier of each platform that you target. See [Runtime IDentifier catalog](../../rid-catalog.md) for a list of runtime identifiers. For example, the following example indicates that the app runs on 64-bit Windows 10 operating systems and the 64-bit OS X Version 10.11 operating system.

    ```xml
    <PropertyGroup>
      <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
    </PropertyGroup>
    ```
    
   A complete sample `csproj` file appears later in this section.

4. Run the `dotnet restore` command to restore the dependencies specified in your project.

5. After you've debugged and tested the program, you can create the files to be deployed with your app for each platform that it targets by using the `dotnet publish` command for both target platforms as follows:

   ```console
   dotnet publish -c release -r win10-x64
   dotnet publish -c release -r osx.10.11-x64
   ```
This creates a release (rather than a debug) version of your app for each target platform. The resulting files are placed in a subdirectory named `publish` that is in a subdirectory of your project's `.\bin\release\netstandard1.6\<runtime_identifier>` subdirectory. Note that each subdirectory contains the complete set of files (both your app files and all .NET Core files) needed to launch your app.

6. Along with your application's files, the publishing process emits a program database (.pdb) file that contains debugging information about your app. The file is useful primarily for debugging exceptions; you can choose not to package it with your application's files.

The published files can be deployed in any way you'd like. For example, you can package them in a zip file, use a simple `copy` command, or deploy them with any installation package of your choice. 

The following is the complete `csproj` file for this project.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netstandard1.6</TargetFramework>
    <VersionPrefix>1.0.0</VersionPrefix>
    <DebugType>Portable</DebugType>
    <RuntimeIdentifiers>win10-x64;osx.10.11-x64</RuntimeIdentifiers>
  </PropertyGroup>
  <ItemGroup>
    <PackageReference Include="Microsoft.NETCore.Runtime.CoreCLR" Version="1.0.2" />
    <PackageReference Include="Microsoft.NETCore.DotNetHostPolicy" Version="1.0.1" />
  </ItemGroup>
</Project>
```

