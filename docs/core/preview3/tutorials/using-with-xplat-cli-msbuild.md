---
title: Getting started with .NET Core on Windows/Linux/macOS using the command line (SDK Preview 3)
description: Getting started with .NET Core on Windows, Linux, or macOS using the .NET Core command line interface (CLI)
keywords: .NET, .NET Core
author: cartermp
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: be988f09-7349-43b0-97fb-3a703d4587ce
---

# Getting started with .NET Core on Windows/Linux/macOS using the command line (SDK Preview 3)

This guide will show you how to use the .NET Core CLI tooling to build cross-platform console apps.  It will start with the most basic console app and eventually span multiple projects, including testing. You'll add these features step-by-step, building on what you've already seen and built.

If you're unfamiliar with the .NET Core CLI toolset, read [the .NET Core SDK overview](../tools/dotnet.md).

## Prerequisites

Before you begin, ensure you have [.NET Core CLI tooling Preview 3 or later](https://github.com/dotnet/core/blob/master/release-notes/preview3-download.md).  You'll also need a text editor.

## Hello, Console App!

First, navigate to or create a new folder with a name you like.  "Hello" is the name chosen for the sample code, which can be found [here](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/HelloMsBuild).

Open up a command prompt and type the following:

```
$ dotnet new
$ dotnet restore
$ dotnet run
```

Let's do a quick walkthrough:

1. `$ dotnet new`

   [`dotnet new`](../tools/dotnet-new.md) creates an up-to-date `Hello.csproj` project file with the dependencies necessary to build a console app.  It also creates a `Program.cs`, a basic file containing the entry point for the application.
   
   `Hello.csproj`:
   ```xml
    <Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
        <Import Project="$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props" />
        
        <PropertyGroup>
            <OutputType>Exe</OutputType>
            <TargetFramework>netcoreapp1.0</TargetFramework>
        </PropertyGroup>

        <ItemGroup>
            <Compile Include="**\*.cs" />
            <EmbeddedResource Include="**\*.resx" />
        </ItemGroup>

        <ItemGroup>
            <PackageReference Include="Microsoft.NETCore.App">
                <Version>1.0.1</Version>
            </PackageReference>
            <PackageReference Include="Microsoft.NET.Sdk">
                <Version>1.0.0-alpha-20161104-2</Version>
                <PrivateAssets>All</PrivateAssets>
            </PackageReference>
        </ItemGroup>
        
        <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
    </Project>
   ```

   The project file specifies everything that's needed to restore dependencies and build the program.

   * The `Import` tag brings in some properties that are common to all .NET Core projects.
   * The `OutputType` tag specifies that we're building an executable, in other words a console application.
   * The `TargetFramework` tag specifies what .NET runtime we're targeting. In an advance scenario, you can specify multiple target frameworks and build to all those in a single operation. In this tutorial, we'll stick to building only for .NET Core 1.0.
   * The `Compile` tag tells the compiler to build all the files in the current directory and all its subdirectories that have the `.cs` file extension, in other words all the C# files in the project. In advanced scenarios, it is possible to exclude files, but in this tutorial, and in most simple scenarios, this line can be left unchanged.
   * The `EmbeddedResource` tag instructs the build system to embed localization files with the extension `.resx` into the compiled executable. We won't use that feature in this tutorial.
   * The `PackageReference` tags specify what dependency packages must be restored and included when building the application. Each package reference specifies the name of the package under the `Include` attribute, and a version number. In most advanced scenarios, you'll add more package references. It is also possible to reference other projects on disk.

   `Program.cs`:
   ```csharp
   using System;

   namespace ConsoleApplication
   {
       public class Program
       {
           public static void Main(string[] args)
           {
               Console.WriteLine("Hello World!");
           }
       }
   }
   ```

   The program starts by `using System`, which means "bring everything in the `System` namespace into scope for this file". The `System` namespace includes basic constructs such as `string`, or numeric types.

   We then define a namespace called "ConsoleApplication". You can change this to anything you want. A class named "Program" is defined within that namespace, with a `Main` method that takes an array of strings as its argument. This array will contain the list of arguments passed in when the compiled program will be called. As it is, this array is not used: all the program is doing is to write "Hello World!" to the console. We can make things a little more interesting by changing the `Console.WriteLine` into the following code.

   ```csharp
   if (args.Length > 0)
   {
       Console.WriteLine($"Hello {args[0]}!");
   }
   else
   {
       Console.WriteLine("Hello World!");
   }
   ```

2. `$ dotnet restore`

   [`dotnet restore`](../tools/dotnet-restore.md) calls into [NuGet](http://nuget.org) (.NET's package manager) to restore the tree of dependencies. NuGet analyzes the `Hello.csproj` file, downloads the dependencies stated in the file (or grabs them from a cache on your machine), and writes the `obj/project.assets.json` file.  The `project.assets.json` file is necessary to be able to compile and run.
   
   The `project.assets.json` file is a persisted and complete set of the graph of NuGet dependencies and other information describing an app.  This file is read by other tools, such as `dotnet build` and `dotnet run`, enabling them to process the source code with a correct set of NuGet dependencies and binding resolutions.
   
3. `$ dotnet run`

   [`dotnet run`](../tools/dotnet-run.md) calls `dotnet build` to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.
   
    ```
    $ dotnet run
    Hello World!
    ```

    Alternatively, you can also execute [`dotnet build`](../tools/dotnet-build.md) to compile the code without running the build console applications. This results in a `bin/Debug/netcoreapp1.0/Hello.dll` compiled application that can be run with `dotnet bin\Debug\netcoreapp1.0\Hello.dll` on Windows, and `dotnet bin/Debug/netcoreapp1.0/Hello.dll` on other systems. You may specify an additional parameter on the command-line (assuming you are on Windows):

    ```
    $ dotnet bin\Debug\netcoreapp1.0\Hello.dll .NET
    Hello .NET!
    ```

    As an advanced scenario, it's possible to build the application as a self-contained set of platform-specific files that can be deployed and run to a machine that doesn't necessarily have .NET Core installed. See [.NET Core Application Deployment](../deploying/index.md) for details.

### Augmenting the program

Let's change the file just a little bit.  Fibonacci numbers are fun, so let's try that out:

`Program.cs`:

```csharp
using static System.Console;

namespace ConsoleApplication
{
    public class Program
    {
        public static int FibonacciNumber(int n)
        {
            int a = 0;
            int b = 1;
            int tmp;
            
            for (int i = 0; i < n; i++)
            {
                tmp = a;
                a = b;
                b += tmp;
            }
            
            return a;   
        }
        
        public static void Main(string[] args)
        {
            WriteLine("Hello World!");
            WriteLine("Fibonacci Numbers 1-15:");
            
            for (int i = 0; i < 15; i++)
            {
                WriteLine($"{i+1}: {FibonacciNumber(i)}");
            }
        }
    }
}
```

And running the program (assuming you're on Windows, and have changed the project directory name to Fibonacci):

```
$ dotnet build
$ dotnet bin\Debug\netcoreapp1.0\win10-x64\Fibonacci.exe
1: 0
2: 1
3: 1
4: 2
5: 3
6: 5
7: 8
8: 13
9: 21
10: 34
11: 55
12: 89
13: 144
14: 233
15: 377
```

And that's it!  You can augment `Program.cs` any way you like.

## Adding some new files

Single files are fine for simple one-off programs, but chances are you're going to want to break things out into multiple files if you're building anything which has multiple components.  Multiple files are a way to do that.

Create a new file and give it a unique namespace:

```csharp
using System;

namespace NumberFun
{
    // code can go here
} 
```

Next, include it in your `Program.cs` file:

```csharp
using NumberFun;
```

And finally, you can build it:

`$ dotnet build`

Now the fun part: making the new file do something!

### Example: A Fibonacci Sequence Generator

Let's say you want to build off of the previous Fibonacci example by caching some Fibonacci values and add some recursive flair.  Your code for a [better Fibonacci example](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/FibonacciBetterMsBuild) might use a new `FibonacciGenerator.cs` file with the following code.

```csharp
using System;
using System.Collections.Generic;

namespace NumberFun
{
	public class FibonacciGenerator
	{
		private Dictionary<int, int> _cache = new Dictionary<int, int>();
		
		private int Fib(int n) => n < 2 ? n : FibValue(n - 1) + FibValue(n - 2);
		
		private int FibValue(int n)
		{
			if (!_cache.ContainsKey(n))
			{
				_cache.Add(n, Fib(n));
			}
			
			return _cache[n];
		}
		
		public IEnumerable<int> Generate(int n)
		{
			for (int i = 0; i < n; i++)
			{
				yield return FibValue(i);
			}
		}
	}
}
```

Now adjust the `Main()` method in your `Program.cs` file as shown below.

```csharp
using System;
using NumberFun;

class Program
{
    static void Main(string[] args)
    {
        var generator = new FibonacciGenerator();
        foreach (var digit in generator.Generate(15))
        {
            Console.WriteLine(digit);
        }
    }
}
```

Finally, run it!

```
$ dotnet run
0
1
1
2
3
5
8
13
21
34
55
89
144
233
377
```

And that's it!

## Conclusion
 
Hopefully this guide has helped you learn how to create a .NET Core console app, from the basics all the way up to a multi-project system with unit tests.  The next step is to create awesome console apps of your own!
 
If a more advanced example of a console app interests you, check out the next tutorial: [Organizing and testing projects with the .NET Core command line (SDK Preview 3)](using-with-xplat-cli-msbuild-folders.md).
