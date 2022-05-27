---
title: "Tutorial: Create a .NET tool"
description: Learn how to create a .NET tool. A tool is a console application that is installed by using the .NET CLI.
ms.topic: tutorial
ms.date: 10/27/2021
recommendations: false
---

# Tutorial: Create a .NET tool using the .NET CLI

**This article applies to:** ✔️ .NET Core 2.1 SDK and later versions

This tutorial teaches you how to create and package a .NET tool. The .NET CLI lets you create a console application as a tool, which others can install and run. .NET tools are NuGet packages that are installed from the .NET CLI. For more information about tools, see [.NET tools overview](global-tools.md).

The tool that you'll create is a console application that takes a message as input and displays the message along with lines of text that create the image of a robot.

This is the first in a series of three tutorials. In this tutorial, you create and package a tool. In the next two tutorials you [use the tool as a global tool](global-tools-how-to-use.md) and [use the tool as a local tool](local-tools-how-to-use.md). The procedures for creating a tool are the same whether you use it as a global tool or as a local tool.

## Prerequisites

- [.NET SDK 6.0.100](https://dotnet.microsoft.com/download/dotnet/6.0) or a later version.

  This tutorial uses .NET SDK 6.0, but global tools are available starting in .NET Core SDK 2.1. Local tools are available starting in .NET Core SDK 3.0.

- A text editor or code editor of your choice.

## Create a project

1. Open a command prompt and create a folder named *repository*.

1. Navigate to the *repository* folder and enter the following command:

   ```dotnetcli
   dotnet new console -n microsoft.botsay -f net6.0
   ```

   The command creates a new folder named *microsoft.botsay* under the *repository* folder.

   > [!NOTE]
   > For this tutorial you create a tool that targets .NET 6.0. To target a different framework, change the `-f|--framework` option. To target multiple frameworks, change the `TargetFramework` element to a `TargetFrameworks` element in the project file, as shown in the following example:
   >
   > ```xml
   > <Project Sdk="Microsoft.NET.Sdk">
   >   <PropertyGroup>
   >     <OutputType>Exe</OutputType>
   >     <TargetFrameworks>netcoreapp3.1;net5.0;net6.0</TargetFrameworks>
   >   </PropertyGroup>
   > </Project>
   > ```

1. Navigate to the *microsoft.botsay* folder.

   ```console
   cd microsoft.botsay
   ```

## Add the code

1. Open the *Program.cs* file with your code editor.

1. Replace the code in *Program.cs* with the following code:

   ```csharp
   using System.Reflection;

   namespace TeleprompterConsole;

   internal class Program
   {
       static void Main(string[] args)
       {
           Console.WriteLine("Hello World!");
       }
   }
   ```

1. Replace the `Main` method with the following code to process the command-line arguments for the application.

   ```csharp
   static void Main(string[] args)
   {
       if (args.Length == 0)
       {
           var versionString = Assembly.GetEntryAssembly()?
                                   .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                                   .InformationalVersion
                                   .ToString();

           Console.WriteLine($"botsay v{versionString}");
           Console.WriteLine("-------------");
           Console.WriteLine("\nUsage:");
           Console.WriteLine("  botsay <message>");
           return;
       }

       ShowBot(string.Join(' ', args));
   }
   ```

   If no arguments are passed, a short help message is displayed. Otherwise, all of the arguments are concatenated into a single string and printed by calling the `ShowBot` method that you create in the next step.

1. Add a new method named `ShowBot` that takes a string parameter. The method prints out the message and an image of a robot using lines of text.

   ```csharp
   static void ShowBot(string message)
   {
       string bot = $"\n        {message}";
       bot += @"
       __________________
                         \
                          \
                             ....
                             ....'
                              ....
                           ..........
                       .............'..'..
                    ................'..'.....
                  .......'..........'..'..'....
                 ........'..........'..'..'.....
                .'....'..'..........'..'.......'.
                .'..................'...   ......
                .  ......'.........         .....
                .    _            __        ......
               ..    #            ##        ......
              ....       .                 .......
              ......  .......          ............
               ................  ......................
               ........................'................
              ......................'..'......    .......
           .........................'..'.....       .......
        ........    ..'.............'..'....      ..........
      ..'..'...      ...............'.......      ..........
     ...'......     ...... ..........  ......         .......
    ...........   .......              ........        ......
   .......        '...'.'.              '.'.'.'         ....
   .......       .....'..               ..'.....
      ..       ..........               ..'........
             ............               ..............
            .............               '..............
           ...........'..              .'.'............
          ...............              .'.'.............
         .............'..               ..'..'...........
         ...............                 .'..............
          .........                        ..............
           .....
   ";
       Console.WriteLine(bot);
   }
   ```

1. Save your changes.

## Test the application

Run the project and see the output. Try these variations at the command line to see different results:

```dotnetcli
dotnet run
dotnet run -- "Hello from the bot"
dotnet run -- Hello from the bot
```

All arguments after the `--` delimiter are passed to your application.

## Package the tool

Before you can pack and distribute the application as a tool, you need to modify the project file.

1. Open the *microsoft.botsay.csproj* file and add three new XML nodes to the end of the `<PropertyGroup>` node:

   ```xml
   <PackAsTool>true</PackAsTool>
   <ToolCommandName>botsay</ToolCommandName>
   <PackageOutputPath>./nupkg</PackageOutputPath>
   ```

   `<ToolCommandName>` is an optional element that specifies the command that will invoke the tool after it's installed. If this element isn't provided, the command name for the tool is the project file name without the *.csproj* extension.

   `<PackageOutputPath>` is an optional element that determines where the NuGet package will be produced. The NuGet package is what the .NET CLI uses to install your tool.

   The project file now looks like the following example:

   ```xml
   <Project Sdk="Microsoft.NET.Sdk">

     <PropertyGroup>

       <OutputType>Exe</OutputType>
       <TargetFramework>net6.0</TargetFramework>

       <PackAsTool>true</PackAsTool>
       <ToolCommandName>botsay</ToolCommandName>
       <PackageOutputPath>./nupkg</PackageOutputPath>

     </PropertyGroup>

   </Project>
   ```

1. Create a NuGet package by running the [dotnet pack](dotnet-pack.md) command:

   ```dotnetcli
   dotnet pack
   ```

   The *microsoft.botsay.1.0.0.nupkg* file is created in the folder identified by the `<PackageOutputPath>` value from the *microsoft.botsay.csproj* file, which in this example is the *./nupkg* folder.

   When you want to release a tool publicly, you can upload it to `https://www.nuget.org`. Once the tool is available on NuGet, developers can install the tool by using the [dotnet tool install](dotnet-tool-install.md) command. For this tutorial you install the package directly from the local *nupkg* folder, so there's no need to upload the package to NuGet.

## Troubleshoot

If you get an error message while following the tutorial, see [Troubleshoot .NET tool usage issues](troubleshoot-usage-issues.md).

## Next steps

In this tutorial, you created a console application and packaged it as a tool. To learn how to use the tool as a global tool, advance to the next tutorial.

> [!div class="nextstepaction"]
> [Install and use a global tool](global-tools-how-to-use.md)

If you prefer, you can skip the global tools tutorial and go directly to the local tools tutorial.

> [!div class="nextstepaction"]
> [Install and use a local tool](local-tools-how-to-use.md)
