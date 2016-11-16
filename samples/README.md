# .NET Core Samples

This folder contains all the sample code that is part of any topic under
the .NET Core documentation. There are several different projects that
are organized in sub-folders. These sub-folders are organized similar
to the organization of the docs for .NET Core.

Some of the articles will have more than one sample associated with them. 

The readme.md file for each sample will refer to the article so that
you can read more about the concepts covered in each sample.

## Building a sample

You build the samples using the .NET CLI. You can download the CLI from
[the .NET Core home page](http://microsoft.com/net/core). Then, execute
these commands from the CLI in the directory of any sample:

```
dotnet restore
dotnet build
dotnet run
```

These will install any needed dependencies, build the project, and run
the project respectively.

Multi-project samples have instructions in their root directory in
a `README.md` file.  

Except where noted, all samples will build from the command line, on
any platform supported by .NET Core. There are a few samples that are
specific to Visual Studio, and will require Visual Studio 2015 Update 3
or a newer version. In addition, some samples show platform specific features,
and will require a specific platform.

## Creating new samples

If you wish to add a code sample:

1. Your sample **must be part of a buildable project**
2. Your sample **cannot be a Visual Studio Project**
	- We do not want Windows and Visual Studio to be a dependency for people building these on their own. The only exception is if your sample highlights particular tooling and is referenced by a topic that explains the prerequisites.
3. Your sample should conform to the [corefx coding style](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md) to maintain consistency.
	- Additionally, we prefer the use of `static` methods rather than instance methods when demonstrating something that doesn't require instantiating a new object.
4. If your sample builds a standalone package, you must include the runtimes used by our CI build system, in addition to any runtimes used by your sample:
    - `win7-x64`
    - `win8-x64`
    - `win81-x64`
    - `ubuntu.16.04-x64`

We will have a CI system in place to build these projects shortly.

To create a sample:

1. File an [issue](https://github.com/dotnet/docs/issues) or add a comment to an existing one that you are working on it.
2. Write the topic that explains the concepts demonstrated in your sample (example: `docs/standard/linq/where-clause.md`) 
3. Write your sample (example: `WhereClause-Sample1.cs`)
4. Create a Program.cs with a Main entry point that calls your samples. If there is already one there, add the call to your sample:
  ```cs
    public class Program
    {
        public void Main(string[] args)
        {
            WhereClause1.QuerySyntaxExample();

			// Add the method syntax as an example.
            WhereClause1.MethodSyntaxExample();
        }
    }
  ```
  To build and run your sample...

5. Restore dependencies

 ```    
	dotnet restore
 ```
6. Go to the sample folder and Build to check for errors.

 ```
    dotnet build
 ```
7. Run!

 ```
    dotnet run
 ```

8. Add a readme.md to the root directory of your sample.
    - This should include a brief description of the code, and refer people to the article that references the sample.