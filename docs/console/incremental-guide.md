# Writing Console Apps: A Step by Step Guide

This guide will show you how to use the .NET CLI tooling to build cross-platform console apps incrementally.  It will start with the most basic console app and eventually span multiple projects, including testing.

If you're unfamiliar with the .NET CLI toolset, read [the overview](overview.md).  It's also helpful to have an understanding of the [console app paradigm](paradigm.md) and how [native binary compilation](single-binaries.md) works.

## Prerequisites

Before you begin, ensure you have the [latest .NET CLI tooling](http://dotnet.github.io/getting-started/).  You'll also need a text editor.

## Hello, Console App!

First, navigate to or create a new folder with a name you like.  "Hello" is the name chosen for the sample code, which can be found [here](https://github.com/dotnet/core-docs/samples/core-projects/console-apps/Hello).

Open up a command prompt and type the following:

```
$ dotnet new
$ dotnet restore
$ dotnet compile
```

Let's do a quick walkthrough:

1. `$ dotnet init`

   `dotnet init` created an up-to-date `project.json` file with NuGet dependencies necessary to build a console app.  It also created a `Program.cs`, a basic file containing the entry point for the application.
   
   `project.json`:
   ```javascript
   {
        "version": "1.0.0-*",
        "compilationOptions": {
            "emitEntryPoint": true
        },
    
        "dependencies": {
            "Microsoft.NETCore.Runtime": "1.0.1-beta-*",
            "System.IO": "4.0.11-beta-*",
            "System.Console": "4.0.0-beta-*",
            "System.Runtime": "4.0.21-beta-*"
        },
    
        "frameworks": {
            "dnxcore50": { }
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

   `dotnet restore` analyzed the `project.json` file, downloaded the dependencies stated in the file (or grabbed them from a cache on your machine), and wrote the `project.lock.json` file.  The `project.lock.json` file is necessary to be able to compile and run.
   
   The `project.lock.json` file is a persisted and complete set of NuGet dependencies and other information describing an app.  This file is read by other tools, such as `dotnet compile` and `dotnet run`, enabling them to process the source code with a correct set of NuGet dependencies and binding resolutions.
   
3. `$ dotnet run`

   `dotnet compile` compiled the source in Intermediate Language (IL) and generated an executable shim and a `Hello.dll` `.dll` file which contains the IL.
   
You can now invoke the executable.

```
$ /bin/Debug/dnxcore50/Hello.exe
Hello, World!
```

### Other ways to compile

Let's try compiling `dotnet run` to compile and execute the code without generating any build artifacts.  Note that although this has use (mainly by ASP.NET internally), it's not a recommended way to run build and run console applications.

```
$ dotnet run
Hello, World!
```

Let's try compiling a native binary instead.

```
$ dotnet compile --native
$ ./bin/Debug/dnxcore50/native/Basic
Hello World!
```

Note the difference in compile time versus execution time.

### Augmenting the program

Let's change the file just a little bit.  Fibonacci numbers are fun, so let's try that out:

`Program.cs`:

```csharp
using System;

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
            Console.WriteLine("Hello World!");
            Console.WriteLine("Fibonacci Numbers 1-15:");
            
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine($"{i+1}: {FibonacciNumber(i)}");
            }
        }
    }
}
```

And running the program:

```
$ dotnet compile --native
$ ./bin/Debug/dnxcore50/native/Basic
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
using System;
using NumberFun;
```

And finally, you can compile it:

`$ dotnet compile`

Now the fun part: making the new file do something!

### Example: A Fibonacci Sequence Generator

Let's say you want to build off of the previous fibonacci example by caching some fibonacci values and add some corecursive flair.  Your code might look something like this:

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

Note that the use of `Dictionary<int, int>` and `IEnumerable<int>` means incorporating the `System.Collections` library in your `project.json`:

```javascript
{
    "version": "1.0.0-*",
    "compilationOptions": {
        "emitEntryPoint": true
    },

    "dependencies": {
        "Microsoft.NETCore.Runtime": "1.0.1-beta-*",
        "System.IO": "4.0.11-beta-*",
        "System.Console": "4.0.0-beta-*",
        "System.Runtime": "4.0.21-beta-*",
        "System.Collections": "4.0.11-beta-23516"
    },

    "frameworks": {
        "dnxcore50": { }
    }
}
```

Now adjust the `Main()` method in you `Program.cs`:

```csharp
public static void Main(string[] args)
{
    var generator = new FibonacciGenerator();
    foreach (var digit in generator.Generate(15))
    {
        Console.WriteLine(digit);
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
|__Type1.cs
|__Type2.cs
|__project.json
```

This works great when the size of your project is relatively small.  However, if you have a larger app with many different data types and potentially multiple layers, you may wish to organize things logically.  This is where folders come into play.  You can either follow along with [the sample project](https://github.com/dotnet/core-docs/samples/core-projects/console-apps/NewTypes) that this guide covers, or create your own files and folders.

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
   |__Type1.cs
   |__Type2.cs
|__Program.cs
|__project.json
```

Now, just as if they were files in the same directory, give them all the same namespace so you can include them in your `Program.cs`.

### Example: Pet Types

This example creates two new types, `Dog` and `Cat`, and has them implement an interface, `IPet`.

Folder Structure:

```
/NewTypes
|__/Types
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
```javascript
{
    "version": "1.0.0-*",
    "compilationOptions": {
        "emitEntryPoint": true
    },

    "dependencies": {
        "Microsoft.NETCore.Runtime": "1.0.1-beta-*",
        "System.IO": "4.0.11-beta-*",
        "System.Console": "4.0.0-beta-*",
        "System.Runtime": "4.0.21-beta-*",
        "System.Collections": "4.0.11-beta-23516"
    },

    "frameworks": {
        "dnxcore50": { }
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
   ```javascript
   {
   	"projects": [
   		"src", "test"
   	]
   }
   ```

   This file tells the build system that this is a multi-project system, which allows it to look for dependencies in more than just the current folder it happens to be executing in.  This is important because it allows you to place a dependency on the code under test in your test project.
   
### Example: Extending the NewTypes project

Now that the project system is in place, you can create your test project and start writing tests!  From here on out, this guide will use and extend [the sample Types project](https://github.com/dotnet/core-docs/samples/core-projects/console-apps/NewTypes).  Additionally, it will use the [Xunit](https://xunit.github.io/) test framework.  Feel free to follow along or create your own multi-project system with tests.


The whole project structure should look like this:

```
/NewTypes
|__/src
   |__/NewTypes
      |__/Model
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__project.json
|__/test
   |__NewTypesTests
      |__TypesTests.cs
      |__project.json
|__global.json
```

There are two new things to make sure you have in your test project:

1. A correct `project.json` with the following:

   * A reference to `xunit`
   * A reference to `xunit.runner.dnx`
   * A reference to the namespace corresponding to the code under test

2. An Xunit test class.


`NewTypesTests/project.json`:
```javascript
{
    "commands":{
        "test":"xunit.runner.dnx"	
    },
    "dependencies": {
        "Pets":"",
        "System.Runtime": "4.0.21-beta-23516",
        "xunit": "2.1.0",
        "xunit.runner.dnx": "2.1.0-rc1-build204"
    },
    "frameworks":{
        "dnxcore50":{}
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
   
 Now you can run tests!  Make sure you start at the top-level directory.
 
 ```
 $ dotnet restore
 $ cd test/PetTests
 $ dnx test
 ```
 
 Output should look like this:
 
 ```
 xUnit.net DNX Runner (64-bit DNXCore 5.0)
  Discovering: NewTypesTests
  Discovered:  NewTypesTests
  Starting:    NewTypesTests
  Finished:    NewTypesTests
=== TEST EXECUTION SUMMARY ===
   NewTypesTests  Total: 2, Errors: 0, Failed: 0, Skipped: 0, Time: 0.215s
 ```
 
 ## Conclusion
 
 Hopefully this guide has helped you learn how to create a .NET Core console app, from the basics all the way up to a multi-project system with unit tests.  The next step is to create awesome console apps of your own!
 
 If a more advanced example of a console app interests you, check out the next section, [nameof(more_interesting_console_app)](overview.md).