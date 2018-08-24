---
title: How to create a .NET Core Global Tool
description: Describes how to create a Global Tool. The Global Tool is a console application that is installed through the .NET Core CLI.
author: Thraka
ms.author: adegeo
ms.date: 08/22/2018
---

# Create a .NET Core Global Tool

This article teaches you how to create and package a .NET Core Global Tool. The .NET Core CLI allows you to compile and mark a console application as a Global Tool, which others can easily install. .NET Core Global Tools are NuGet packages that are installed from the .NET Core CLI. For more information about Global Tools, see [.NET Core Global Tools overview][global-tool-info].

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Create a project

This article uses the .NET Core CLI to create and manage a project. Obviously you could use Visual Studio to do some of these steps, but Visual Studio will not be described in this article.

First, create a new .NET Core 2.1 Console Application.

```console
dotnet new console -o botsay
```

Enter the `botsay` directory created by the previous command.

In this example we'll create a console application that generates an ascii bot and prints a message. The first thing we'll do is use the same command line parsing system that makes it easy to parse arguments and provides a help system.

Add reference to the `Microsoft.Extensions.CommandLineUtils` NuGet package.

```console
dotnet add package Microsoft.Extensions.CommandLineUtils
```

## Add the code

Open the `Program.cs` file.

The first thing we'll code is support for the command line options the program will use. Add the following `using` directive to the top of the file, this will help to display the version information of the application.

```csharp
using System.Reflection;
```

Next, move down to the `static void Main(string[] args)` method. Most likely you have a print statement in there. Erase any code inside this method.

Add the following code to process the command line arguments for your application. This code will first check if any arguments were passed. If no arguments were passed, a little help message will be displayed. If arguments were passed, all of those arguments will be transformed into a string and printed with the bot.

```csharp
static void Main(string[] args)
{
    if (args.Length == 0)
    {
        Console.WriteLine($"botsay v{Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyInformationalVersionAttribute>().InformationalVersion}");
        Console.WriteLine("-------------");
        Console.WriteLine("\nUsage:");
        Console.WriteLine("  botsay <message>");
        return;
    }

    ShowBot(string.Join(' ', args));
}
```

### Create the bot

Next, add a new method named `ShowBot` which takes a string parameter. This method will print out the message and the ascii bot. The ascii bot code was taken from the awesome [dotnetbot](https://github.com/dotnet/core/blob/master/samples/dotnetsay/Program.cs) sample.

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

### Test the tool

You can run the project and see the output. Try these variations to run our application:

```csharp
dotnet run
dotnet run -- "Hello from the bot"
dotnet run -- hello from the bot
```

All arguments after the `--` delimiter are passed to our application.

## Setup the global tool

Before you can pack and distribute the application as a Global Tool, you need to modify the project file. Open the `botsay.csproj` file and add three new XML nodes to the `<Project><PropertyGroup>` node:

- \<PackAsTool>  
Indicates that the application will be packaged for install as a Global Tool.

- \<ToolCommandName>  
An alternitive name for the tool, otherwise the tool executable will be named after the project file.

- \<PackageOutputPath>  
Where the NuGet package will be produced. The NuGet package is what the .NET Core CLI Global Tools uses to install your tool.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>

    <PackAsTool>true</PackAsTool>
    <PackageOutputPath>./nupkg</PackageOutputPath>
    <ToolCommandName>botsay</ToolCommandName>

  </PropertyGroup>

</Project>
```

Next, create a NuGet package for your application.

```console
dotnet pack -c Release
```

The `botsay.1.0.0.nupkg` file will be created in the folder identified by the `<PackageOutputPath>` XML value from the `botsay.csproj` file, which should be the `./nupkg` folder.

Now that you have a package, install the tool from that package: 

```console
dotnet tool install -g --add-source ./nupkg botsay`
```

The `--add-source` parameter tells .NET Core to use the `./nupkg` folder (our `<PackageOutputPath>` folder) as an additional feed source for NuGet packages. For more information about installing Global Tools, see [.NET Core Global Tools overview][global-tool-info].

> [!NOTE]
> If the version (default is 1.0.0) of your application is lower than 1.0.0, say 0.1, you will need to specify the `--version 0.1` parameter on the `dotnet tool install` command.

If installation is successful, a message is displayed showing the command used to call the tool and the version installed, similar to the following example:

```
You can invoke the tool using the following command: botsay
Tool 'botsay' (version '1.0.0') was successfully installed.
```

You should now be able to type `botsay` and get a response from the tool.

> [!NOTE]
> If the install was successful, but you cannot use the `botsay` command, you may need to open a new terminal to refresh the your PATH.

## Remove the tool

Once you are done experimenting with the tool, remove it.

```console
dotnet tool uninstall -g botsay
```

## Next steps

Read more information about how [Global Tools work with .NET Core][global-tool-info].


[global-tool-info]: global-tools.md