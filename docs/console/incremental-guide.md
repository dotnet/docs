# Writing Console Apps: An Incremental Guide

This guide will show you how to use the .NET CLI tooling to build cross-platform console apps incrementally.  It will start with the most basic console app and eventually span multiple projects, including testing.

If you're unfamiliar with the .NET CLI toolset, read [the overview](overview.md).  It's also helpful to have an understanding of the [console app paradigm](paradigm.md) and how [native binary compilation](single-binaries.md) works.

## Prerequisites

Before you begin, ensure you have the [latest .NET CLI tooling](http://dotnet.github.io/getting-started/).

## Hello, Console App!

First, navigate to or create a new folder with a name you like.  "incremental" is the name chosen for the sample code, which can be found [here](https://github.com/dotnet/core-docs/samples/core-projects/console-apps/incremental).

Open up a command prompt and type the following:

```
$ dotnet init
$ dotnet restore
$ dotnet run
```

You should see the following:

`Hello World!`

Let's do a quick walkthrough of what happened.

1. `$ dotnet init`

   This created an up-to-date `project.json` file with NuGet dependencies necessary to build a console app.  It also created a `Program.cs`, a basic file containing the entry point for the application.
   
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

   This analyzed the `project.json` file, downloaded the dependencies stated in the file (or grabbed them from a cache on your machine), and wrote the `project.lock.json` file.  The `project.lock.json` file is necessary to be able to compile and run.
   
3. `$ dotnet run`

   This JIT compiled the source, writing "Hello World!" to STDOUT.

Let's try compiling and executing an executable file.In this example, it's named "incremental".  If you named your top-level folder something else, it will have that name.

```
$ dotnet compile
$ bin/Debug/dnxcore50/incremental.exe
Hello, World!
```

Let's try compiling a native binary instead.  Using `dotnet clean` is optional.

```
$ dotnet clean
$ dotnet compile --native
$ ./bin/Debug/dnxcore50/native/incremental
Hello World!
```

Note the difference in compile time versus execution time.

Let's change the file just a little bit.  Fibonacci numbers are fun, so let's try that out:

`Program.cs`:

```csharp
using System;

namespace ConsoleApplication
{
    public class Program
    {
        public int FibonacciNumber(int n)
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
$ dotnet run
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

Single files are fine, but chances are you're going to want to break things out into multiple files.  Let's do exactly that, building on the Fibonacci example above.

First, you can clear out any build artifacts:

`$ dotnet clean`

Next, create a new file and give it a unique namespace:

```csharp
using System;

namespace Fibonacci
{
    // code can go here
} 
```

Next, include it in your `Program.cs` file:

```csharp
using System;
using Fibonacci;
```

And finally, you can compile it:

`$ dotnet compile`

Now the fun part: making the new file do something!

Let's say you want to cache some fibonacci values and add some corecursive flair.  Your code might look something like this:

```csharp
using System;
using System.Collections.Generic;

namespace Fibonacci
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
    Console.WriteLine("Hello World!");
    Console.WriteLine("Fibonacci Numbers 1-15:");
    
    for (int i = 0; i < 15; i++)
    {
        Console.WriteLine($"{i+1}: {FibonacciNumber(i)}");
    }
    
    Console.WriteLine("Using a generator");
    foreach (var digit in new FibonacciGenerator().Generate(15))
    {
        Console.WriteLine(digit);
    }
}
```

Finally, run it!

```
$ dotnet run
Hello World!
Fibonacci Numbers 1-15:
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
Using a generator
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

1. Moving defined types into a Models folder
2. Adding some more types and perhaps an adapter or factory or something?

## Testing your Console App

1. Creating a test project
2. Getting files set up (project.json, global.json, etc)
3. Running tests, changing values, showing tests fail, etc
