---
title: How to create a .NET Core Global Tool
description: Describes how to create a Global Tool. The Global Tool is a console application that is installed through the .NET Core CLI.
author: Thraka
ms.author: adegeo
ms.date: 08/22/2018
---

# Create a .NET Core Global Tool using the .NET Core CLI

This article teaches you how to create and package a .NET Core Global Tool. The .NET Core CLI allows you to create a console application as a Global Tool, which others can easily install and run. .NET Core Global Tools are NuGet packages that are installed from the .NET Core CLI. For more information about Global Tools, see [.NET Core Global Tools overview](global-tools.md).

[!INCLUDE [topic-appliesto-net-core-21plus.md](../../../includes/topic-appliesto-net-core-21plus.md)]

## Create a project

This article uses the .NET Core CLI to create and manage a project.

Our example tool will be a console application that generates an ASCII bot and prints a message. First, create a new .NET Core Console Application.

```dotnetcli
dotnet new console -o botsay
```

Navigate to the `botsay` directory created by the previous command.

## Add the code

Open the `Program.cs` file with your favorite text editor, such as `vim` or [Visual Studio Code](https://code.visualstudio.com/).

Add the following `using` directive to the top of the file, this helps shorten the code to display the version information of the application.

```csharp
using System.Reflection;
```

Next, move down to the `Main` method. Replace the method with the following code to process the command-line arguments for your application. If no arguments were passed, a short help message is displayed. Otherwise, all of those arguments are transformed into a string and printed with the bot.

```csharp
static void Main(string[] args)
{
    if (args.Length == 0)
    {
        var versionString = Assembly.GetEntryAssembly()
                                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
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

### Create the bot

Next, add a new method named `ShowBot` that takes a string parameter. This method prints out the message and the ASCII bot. The ASCII bot code was taken from the [dotnetbot](https://github.com/dotnet/core/blob/master/samples/dotnetsay/Program.cs) sample.

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

Run the project and see the output. Try these variations of the command-line to see different results:

```dotnetcli
dotnet run
dotnet run -- "Hello from the bot"
dotnet run -- hello from the bot
```

All arguments after the `--` delimiter are passed to your application.

## Setup the global tool

Before you can pack and distribute the application as a Global Tool, you need to modify the project file. Open the `botsay.csproj` file and add three new XML nodes to the `<Project><PropertyGroup>` node:

- `<PackAsTool>`\
[REQUIRED] Indicates that the application will be packaged for install as a Global Tool.

- `<ToolCommandName>`\
[OPTIONAL] An alternative name for the tool, otherwise the command name for the tool will be named after the project file. You can have multiple tools in a package, choosing a unique and friendly name helps differentiate from other tools in the same package.

- `<PackageOutputPath>`\
[OPTIONAL] Where the NuGet package will be produced. The NuGet package is what the .NET Core CLI Global Tools uses to install your tool.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp2.1</TargetFramework>

    <PackAsTool>true</PackAsTool>
    <ToolCommandName>botsay</ToolCommandName>
    <PackageOutputPath>./nupkg</PackageOutputPath>

  </PropertyGroup>

</Project>
```

Even though `<PackageOutputPath>` is optional, use it in this example. Make sure you set it: `<PackageOutputPath>./nupkg</PackageOutputPath>`.

Next, create a NuGet package for your application.

```dotnetcli
dotnet pack
```

The `botsay.1.0.0.nupkg` file is created in the folder identified by the `<PackageOutputPath>` XML value from the `botsay.csproj` file, which in this example is the `./nupkg` folder. This makes it easy to install and test. When you want to release a tool publicly, upload it to <https://www.nuget.org>. Once the tool is available on NuGet, developers can perform a user-wide installation of the tool using the `--global` option of the [dotnet tool install](dotnet-tool-install.md) command.

Now that you have a package, install the tool from that package:

```dotnetcli
dotnet tool install --global --add-source ./nupkg botsay
```

The `--add-source` parameter tells the .NET Core CLI to temporarily use the `./nupkg` folder (our `<PackageOutputPath>` folder) as an additional source feed for NuGet packages. For more information about installing Global Tools, see [.NET Core Global Tools overview](global-tools.md).

If installation is successful, a message is displayed showing the command used to call the tool and the version installed, similar to the following example:

```output
You can invoke the tool using the following command: botsay
Tool 'botsay' (version '1.0.0') was successfully installed.
```

You should now be able to type `botsay` and get a response from the tool.

> [!NOTE]
> If the install was successful, but you cannot use the `botsay` command, you may need to open a new terminal to refresh the PATH.

## Remove the tool

Once you're done experimenting with the tool, you can remove it with the following command:

```dotnetcli
dotnet tool uninstall -g botsay
```
