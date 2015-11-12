# .NET Core Samples

The code samples here are simple, buildable projects which augment the .NET Core Documentation with demonstrative code snippets.  These samples are directly embedded into documentation.

If you wish to add a code sample:

1. Your sample **must be part of a buildable project**
2. Your sample **cannot be a Visual Studio Project**

	- We do not want Windows and Visual Studio to be a dependency for people building these on their own.

We will eventually have a CI system in place to build these projects.

To create a sample:

1. File an [issue](https://github.com/dotnet/core-docs/issues) or add a comment to an existing one that you are working on it.
2. For each set of samples that demonstrates a concept, add a project.json with your dependencies and target coreclr:

 ```javascript
 	{ 
		"dependencies": {
		    "System.Runtime":"4.0.0-rc1-*",
		    "System.Linq":"4.0.0-rc1-*",
		    "System.Console": "4.0.0-beta-*"
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
            var sample = new WhereClause1();
            sample.QuerySyntaxExample();
            sample.MethodSyntaxExample();
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
