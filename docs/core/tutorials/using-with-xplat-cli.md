---
title: Getting started with .NET Core on Windows/Linux/macOS using the command line
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

# Getting started with .NET Core on Windows/Linux/macOS using the command line

This guide will show you how to use the .NET Core CLI tooling to build basic cross-platform console apps.

If you're unfamiliar with the .NET Core CLI toolset, read [the .NET Core SDK overview](../sdk.md).

## Prerequisites

Before you begin, ensure you have the [latest .NET Core CLI tooling](https://www.microsoft.com/net/core). You'll also need a text editor.

## Hello, Console App!

Navigate to or create a new folder with a name you like. "Hello" is the name chosen for the sample code, which can be found [here](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/Hello).

Open up a command prompt and type the following:

```
$ dotnet new
$ dotnet restore
$ dotnet run
```

Let's do a quick walkthrough:

1. `$ dotnet new`

   [`dotnet new`](../tools/dotnet-new.md) creates an up-to-date `project.json` file with NuGet dependencies necessary to build a console app.  It also creates a `Program.cs`, a basic file containing the entry point for the application.
   
   `project.json`:
   ```json
   {
        "version": "1.0.0-*",
        "buildOptions": {
            "emitEntryPoint": true
        },
        "dependencies": {
            "Microsoft.NETCore.App": {
                "type": "platform",
                "version": "1.0.0"
            }
        },   
       "frameworks": {
            "netcoreapp1.0": {
                "imports": "dnxcore50"
            }
        }
   }
   ```
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

2. `$ dotnet restore`

   [`dotnet restore`](../tools/dotnet-restore.md) calls into NuGet to restore the tree of dependencies. NuGet analyzes the `project.json` file, downloads the dependencies stated in the file (or grabs them from a cache on your machine), and writes the `project.lock.json` file.  The `project.lock.json` file is necessary to be able to compile and run.
   
   The `project.lock.json` file is a persisted and complete set of the graph of NuGet dependencies and other information describing an app.  This file is read by other tools, such as `dotnet build` and `dotnet run`, enabling them to process the source code with a correct set of NuGet dependencies and binding resolutions.
   
3. `$ dotnet run`

   [`dotnet run`](../tools/dotnet-run.md) calls `dotnet build` to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.
   
```
$ dotnet run
Hello, World!
```

You can also execute [`dotnet build`](../tools/dotnet-build.md) to compile the code without running the build console applications.

### Building a self-contained application

Let's try compiling a self-contained application instead of a portable application. You can read more about the [types of portability in .NET Core](../deploying/index.md) to learn about the different application types, and how they are deployed.

You need to make some changes to your `project.json`
file to direct the tools to build a self-contained application. You can see these in the
[HelloNative](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/HelloNative)
project in the samples directory.

The first change is to remove the `"type": "platform"` element from all dependencies. 
This project's only dependency so far is `"Microsoft.NETCore.App"`. The `dependencies` section should look like this:

```json
"dependencies": {
    "Microsoft.NETCore.App": {
        "version": "1.0.0"
    }
},
```

Next, you need to add a `runtimes` node to specify all the target execution environments. For example, the following
`runtimes` node instructs the build system to create executables for the 64 bit version of Windows 10 and the 64 bit version of Mac OS X version 10.11.
The build system will generate native executables for the current environment. If you are following these steps on a Windows machine,
you'll build a Windows executable. If you are following these steps on a Mac, you'll build the OS X executable.

```json 
"runtimes": {
  "win10-x64": {},
  "osx.10.11-x64": {}
}
```

See the full list of supported runtimes in the [RID catalog](../rid-catalog.md). 
 
After making those two changes you execute `dotnet restore`, followed by `dotnet build` to create the native executable. Then, you can run the generated
native executable. 

The following example shows the commands for Windows. The example shows where the native executable gets generated and assumes that the project directory is named HelloNative.

```
$ dotnet restore 
$ dotnet build 
$ .\bin\Debug\netcoreapp1.0\win10-x64\HelloNative.exe
Hello World!
```

You may notice that the native application takes slightly longer to build, but executes slightly faster. This behavior
becomes more noticeable as the application grows.

The build process generates several more files when your `project.json` creates a native build. These files
are created in `bin\Debug\netcoreapp1.0\<platform>` where `<platform>` is the RID chosen. In addition to the
project's `HelloNative.dll` there is a `HelloNative.exe` that loads the runtime and starts the application.
Note that the name of the generated application changed because the project directory's name has changed.  

You may want to package this application to execute it on a machine that does not include the .NET runtime.
You do that using the `dotnet publish` command. The `dotnet publish` command creates a new subdirectory
under the `./bin/Debug/netcoreapp1.0/<platform>` directory called `publish`. It copies the executable,
all dependent DLLs and the framework to this sub directory. You can package that directory to another machine
(or a container) and execute the application there. 

Let's contrast that with the behavior of `dotnet publish` in the first Hello World sample. That application
is a *portable application*, which is the default type of application for .NET Core. A portable application
requires that .NET Core is installed on the target machine. Portable applications can be built on one machine
and executed anywhere. Native applications must be built separately for each target machine. `dotnet publish`
creates a directory that has the application's DLL, and any dependent dlls that are not part of the platform
installation.

### Augmenting the program

Let's change the file just a little bit.  Fibonacci numbers are fun, so let's try that out (using
the native version):

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
$ .\bin\Debug\netcoreapp1.0\win10-x64\Fibonacci.exe
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
using static System.Console;
using NumberFun;
```

And finally, you can build it:

`$ dotnet build`

Now the fun part: making the new file do something!

### Example: A Fibonacci Sequence Generator

Let's say you want to build off of the previous [Fibonacci example](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/Fibonacci) by caching some Fibonacci values and add some recursive flair.  Your code for a [better Fibonacci example](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/FibonacciBetter) might look something like this:

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

Note that the use of `Dictionary<int, int>` and `IEnumerable<int>` means incorporating the `System.Collections` namespace.
The `Microsoft.NetCore.App` package is a *metapackage* that contains many of the core
assemblies from the .NET Framework. By including this metapackage, you've already included
the `System.Collections.dll` assembly as part of your project. You can verify this by
running `dotnet publish` and examining the files that are part of the installed
package. You'll see `System.Collections.dll` in the list. 

```json
{ 
  "version": "1.0.0-*", 
  "buildOptions": { 
    "debugType": "portable", 
    "emitEntryPoint": true 
  }, 
  "dependencies": {}, 
  "frameworks": { 
    "netcoreapp1.0": { 
      "dependencies": { 
        "Microsoft.NETCore.App": { 
          "version": "1.0.0" 
        } 
      }, 
      "imports": "dnxcore50" 
    } 
  },
  "runtimes": {
    "win10-x64": {},
    "osx.10.11-x64": {}
  }
}
```

Now adjust the `Main()` method in your `Program.cs` file as shown below. The example assumes that `Program.cs` has a `using System;` statement. If you have a `using static System.Console;` statement, remove `Console.` from `Console.WriteLine`.  

```csharp
public static void Main(string[] args)
{
    var generator = new FibonacciGenerator();
    foreach (var digit in generator.Generate(15))
    {
        WriteLine(digit);
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

## Using folders to organize code

Say you wanted to introduce some new types to do work on.  You can do this by adding more files and making sure to give them namespaces you can include in your `Program.cs` file.

```
/MyProject
|__Program.cs
|__AccountInformation.cs
|__MonthlyReportRecords.cs
|__project.json
```

This works great when the size of your project is relatively small.  However, if you have a larger app with many different data types and potentially multiple layers, you may wish to organize things logically.  This is where folders come into play.  You can either follow along with [the NewTypes sample project](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypes) that this guide covers, or create your own files and folders.

To begin, create a new folder under the root of your project.  `/Model` is chosen here.

```
/NewTypes
|__/Model
|__Program.cs
|__project.json
```

Now add some new types to the folder:

```
/NewTypes
|__/Model
   |__AccountInformation.cs
   |__MonthlyReportRecords.cs
|__Program.cs
|__project.json
```

Now, just as if they were files in the same directory, give them all the same namespace so you can include them in your `Program.cs`.

### Example: Pet Types

This example creates two new types, `Dog` and `Cat`, and has them implement an interface, `IPet`.

Folder Structure:

```
/NewTypes
|__/Pets
   |__Dog.cs
   |__Cat.cs
   |__IPet.cs
|__Program.cs
|__project.json
```

`IPet.cs`:
```csharp
using System;

namespace Pets
{
	public interface IPet
	{
		string TalkToOwner();
	}
}
```

`Dog.cs`:
```csharp
using System;

namespace Pets
{
	public class Dog : IPet
	{
		public string TalkToOwner() => "Woof!";
	}
}
```

`Cat.cs`:
```csharp
using System;

namespace Pets
{
	public class Cat : IPet
	{
		public string TalkToOwner() => "Meow!";
	}
}
```

`Program.cs`:
```csharp
using System;
using Pets;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IPet> pets = new List<IPet>
            {
                new Dog(),
                new Cat()  
            };
            
            foreach (var pet in pets)
            {
                Console.WriteLine(pet.TalkToOwner());
            }
        }
    }
}
```

`project.json`:
```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "emitEntryPoint": true
  },
  "dependencies": {
    "Microsoft.NETCore.App": {
      "type": "platform",
      "version": "1.0.0"
    }
  },
  "frameworks": {
    "netcoreapp1.0": {
      "imports": "dnxcore50"
    }
  }
}
```

And if you run this:

```
$ dotnet restore
$ dotnet run
Woof!
Meow!
```

New pet types can be added (such as a `Bird`), extending this project.

## Testing your Console App

You'll probably be wanting to test your projects at some point.  Here's a good way to do it:

1. Move any source of your existing project into a new `src` folder.

   ```
   /Project
   |__/src
   ```

2. Create a `/test` directory.

   ```
   /Project
   |__/src
   |__/test
   ```

3. Create a new `global.json` file:

   ```
   /Project
   |__/src
   |__/test
   |__global.json
   ```

   `global.json`:
   ```json
   {
      "projects": [
         "src", "test"
      ]
   }
   ```

   This file tells the build system that this is a multi-project system, which allows it to look for dependencies in more than just the current folder it happens to be executing in.  This is important because it allows you to place a dependency on the code under test in your test project.
   
### Example: Extending the NewTypes project

Now that the project system is in place, you can create your test project and start writing tests!  From here on out, this guide will use and extend [the sample Types project](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypes).  Additionally, it will use the [Xunit](https://xunit.github.io/) test framework.  Feel free to follow along or create your own multi-project system with tests.


The whole project structure should look like this:

```
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__project.json
|__/test
   |__NewTypesTests
      |__PetTests.cs
      |__project.json
|__global.json
```

There are two new things to make sure you have in your test project:

1. A correct `project.json` with the following:

   * A reference to `xunit`
   * A reference to `dotnet-test-xunit`
   * A reference to the namespace corresponding to the code under test

2. An Xunit test class.

`NewTypesTests/project.json`:
```json
{
  "version": "1.0.0-*",
  "testRunner": "xunit",

  "dependencies": {
    "Microsoft.NETCore.App": {
      "type":"platform",
      "version": "1.0.0"
    },
    "xunit":"2.2.0-beta2-build3300",
    "dotnet-test-xunit": "2.2.0-preview2-build1029",
    "NewTypes": "1.0.0"
  },
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dnxcore50",
        "portable-net45+win8" 
      ]
    }
  }
}
```

`PetTests.cs`: 
```csharp
using System;
using Xunit;
using Pets;
public class PetTests
{
    [Fact]
    public void DogTalkToOwnerTest()
    {
        string expected = "Woof!";
        string actual = new Dog().TalkToOwner();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void CatTalkToOwnerTest()
    {
        string expected = "Meow!";
        string actual = new Cat().TalkToOwner();
       	
        Assert.Equal(expected, actual);
    }
}
```
   
Now you can run tests!  The [`dotnet test`](../tools/dotnet-test.md) command runs the test runner you have specified in your project. Make sure you start at the top-level directory.
 
```
$ dotnet restore
$ cd test/NewTypesTests
$ dotnet test
```
 
Output should look like this:
 
```
xUnit.net .NET CLI test runner (64-bit win10-x64)
  Discovering: NewTypesTests
  Discovered:  NewTypesTests
  Starting:    NewTypesTests
  Finished:    NewTypesTests
=== TEST EXECUTION SUMMARY ===
   NewTypesTests  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 0.144s
SUMMARY: Total: 1 targets, Passed: 1, Failed: 0.
```
 
## Conclusion
 
Hopefully this guide has helped you learn how to create a .NET Core console app, from the basics all the way up to a multi-project system with unit tests.  The next step is to create awesome console apps of your own!
 
If a more advanced example of a console app interests you, check out the next tutorial: [Using the CLI tools to write console apps: An advanced step-by-step guide](cli-console-app-tutorial-advanced.md).
