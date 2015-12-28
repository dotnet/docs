# .NET Core Samples

The code samples here are simple, buildable projects which augment the .NET Core Documentation with demonstrative code snippets.  These samples are directly embedded into documentation.

Sample projects are broken up by language.  Here is an example general structure:

```
/samples
   /concept-to-sample
      /csharp
         global.json
         /src
            File1.cs
            project.json
         /test
            Test1.cs
            project.json
      /vb
      /fsharp
```
If you wish to add a code sample:

1. Your sample **must be part of a buildable project**
2. Your sample **cannot be a Visual Studio Project**
	- We do not want Windows and Visual Studio to be a dependency for people building these on their own.
3. Your sample shoud conform to the [corefx coding style](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md) to maintain consistency.
	- Additionally, we prefer the use of `static` methods rather than instance methods when demonstrating something that doesn't require instantiating a new object.

We will eventually have a CI system in place to build these projects.

To create a sample:

1. File an [issue](https://github.com/dotnet/core-docs/issues) or add a comment to an existing one that you are working on it.
2. For each set of samples that demonstrates a concept, add a project.json with your dependencies and target coreclr. Additionally,
add a run command specifying the sample folder so people using VSCode or Visual Studio can run the sample directly:

 ```json
 	{
		"dependencies": {
		    "System.Runtime":"4.0.0-*",
		    "System.Linq":"4.0.0-*",
		    "System.Console": "4.0.0-*"
	    },
      "commands": {
        "run" : "<SAMPLE FOLDER>"
      },
	    "frameworks": {
		    "dnxcore50":{}
	    }
    }
 ```

3. Write your sample (example: `WhereClause-Sample1.cs`)
4. Create a Program.cs with a Main entry point that calls your samples. If there is already one there, add the call to your sample:
  ```c#
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
  To to build and run your sample...

5. Grab the latest coreclr:

 ```    
	dnvm upgrade latest -r coreclr -u
 ```
6. Go to the sample folder and Build to check for errors.

 ```
    dnu build
 ```
7. Run!

 ```
    dnx run
 ```
