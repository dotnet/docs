# Introduction
This tutorial teaches you a number of features in .NET Core and the C# language. You’ll learn:
*	The basics of the .NET Core Command Line Interface (CLI).
*   An overview of C# Language features.
*	The structure of a C# Console Application.
*	Managing dependencies with NuGet
*   HTTP Communications
*   Processing JSON information 

You’ll build an application that issues HTTP Requests to a REST
service on GitHub. You'll read information in JSON format, and convert
that JSON packet into C# objects. Finally, you'll see how to work with
C# objects.

There are a lot of features in this tutorial. Let’s build them one by one. 
# Prerequisites
You’ll need to setup your machine to run .NET core. Instructions are
[here](http://dotnet.github.io/getting-started/). You can run this
application on Windows, Ubuntu Linux, OS X or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.
# Create the Application
The first step is to create a new application. Open a command prompt and
create a new directory for your application. Make that the current
directory. Type the command "dotnet new" at the command prompt. This
creates the starter files for a basic “Hello World” application.

Before you start making modifications, let’s go through the steps to run
the simple Hello World application. After creating the application, type
"dotnet restore" at the command prompt. This command runs the NuGet
package restore process. NuGet is a .NET package manager. This command
downloads any of the missing dependencies for your project. As this is a
new project, none of the dependencies are in place, so the first run will
download the .NET Core framework. After this initial step, you will only
need to run dotnet restore when you add new dependent packages, or update
the versions of any of your dependencies. This process also creates the
project lock file (project.lock.json) in your project directory. This file
helps to manage the project dependencies. It contains the local location
of all the project dependencies. You do not need to put the file in source
control; it will be generated when you run “dotnet restore”. 

After restoring packages, you run “dotnet build”. This executes the build
engine and creates your application. Finally, you execute “dotnet run” to
run your application.

# Adding New Dependencies
One of the key design goals for .NET Core is to minimize the size of
the .NET framewwork installation. The .NET Core Standard library contains
only the most common elements of the .NET full framework. This application
needs more libraries for some of its features. You'll add those
dependencies into your project.json file. You'll need to add the
`System.Net.Http` package so that your application can make HTTP requests.
You'll also need to add the `System.Runtime.Serialization.Json` package
so your application can process JSON responses.

Open your project.json file. Look for the dependencies section. You should
see one line that looks similar to this:

```
"dependencies": {
  "NETStandard.Library": "1.0.0-rc2-23704"
},

```

> Note: The actual version of the .NET Standard Library may be different.

You'll add two lines to this section to include the two new libraries:

```
"dependencies": {
  "NETStandard.Library": "1.0.0-rc2-23704",
  "System.Net.Http": "4.0.1-rc2-23704",
  "System.Runtime.Serialization.Json": "4.0.1-rc2-23704"
},
```

Most code editors will provide completion for different versions of these
libraries. You'll usually want to use the latest version of any package
that you add. However, it is important to make sure that the versions
of all packages match, and that they also match the version of the .NET
Standard Library.

After you've made these changes, you should run dotnet restore again so
that those packages are installed on your system.

# Making Web Requests
Now you're ready to start retrieving data from the web. In this
application, you'll read information from the 
[GitHub API](https://developer.github.com/v3/). Let's read information
about the projects under the
[.NET Foundation](http://www.dotnetfoundation.org/) umbrella. You'll
start by making the request to the Github API to retrieve information
on the projects. The endpoint you'll use is: [https://api.github.com/orgs/dotnet/repos](https://api.github.com/orgs/dotnet/repos). You want to retrieve all the
information about these projects, so you'll use an HTTP GET request.
Your browser also uses HTTP GET requests, so you can paste that URL into
your browser to see what information you'll be receiving and processing.

You use the `HttpClient` class to make web requests. Like all modern .NET
APIs, `HttpClient` supports only async methods for its long-running APIs.
Start by making an async method. You'll fill in the implementation as you
build the functionality of the application. 

```cs
private static async Task ProcessRepositories()
{
    
}
```

You'll need to add a using statement at the top of your `Main()` method so
that the C# compiler recognizes the `Task` type:

```cs
using System.Threading.Tasks;
```

If you build your project at this point, you'll get a warning generated
for this method, because it does not contain any `await` operators and
will run synchronously. Ignore that for now, you'll add `await` operators
as you fill in the method.

Next, update the `Main()` method to call this method. The
`ProcessRepositories()` method returns a Task, and you shouldn't exit the
program before that task finishes. Therefore, you must use the `Wait()`
method to block and wait for the task to finish:

```cs
public static void Main(string[] args)
{
    ProcessRepositories().Wait();
}
```

Now, you have a program that does nothing, but does it asynchronously. Let's go back to the
`ProcessRepositories()` method and fill in a first version of it:

```cs
private static async Task ProcessRepositories()
{
    var client = new HttpClient();
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

    var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

    var msg = await stringTask;
    Console.Write(msg);
}
```

You'll need to also add two new using statements at the top of the file for this to compile:

```cs
using System.Net.Http;
using System.Net.Http.Headers;
```

This first version makes a web request to read the list of all repositories under the dotnet
foundation organization. (The github ID for the .NET Foundation is 'dotnet'). First, you create
a new `HttpClient`. This object handles the request and the responses. The next few lines setup
the `HttpClient` for this request. First, it is configured to accept the Github JSON responses.
This format is simply JSON. The next line adds a User Agent header to all requests from this
object. These two headers are checked by the GitHub server code, and are necessary to retrieve
information from GitHub.

After you've configured the `HttpClient`, you make a web request, and retrieve the response. In
this first version, you use the `GetStringAsync` convenience method. This convenience method
starts a task that makes the web request, and then when the request returns, it will read the
response stream, and extract the content from the stream. The body of the response is returned
as a `string`. The string is avaialable when the task completes. 

The final two lines of this method await that task, and then print the response to the console.
Build the app, and run it. The build warning is gone now, because the `ProcessRepositories` now
does contain an `await` operator. You'll see a long display of JSON formatted text.   

# Processing the JSON Result

At this point, you've written the code to retrieve a response from a web server, and display
the text that is contained in that response. Next, let's convert that JSON response into C#
objects.

The JSON Serializer converts JSON data into C# Objects. Your first task is to define a C# class
type to contain the information you use from this response. Let's build this slowly, so start with
a simple C# type that contains the name of the repository:

```cs
namespace WebAPIClient
{
    public class repo
    {
        public string name;
    }
}
``` 

Put the above code in a new file called 'repo.cs'. This version of the class represents the
simplest path to process JSON data. The class name and the member name match the names used
in the JSON packet, instead of following C# conventions. You'll fix that by providing some
configuration attributes later. This class demonstrates another important feature of JSON
serialization and deserialization: Not all the fields in the JSON packet are part of this class.
The JSON serializer will ignore information that is not included in the class type being used.
This feature makes it easier to create types that work with only a subset of the fields in
the JSON packet.

Now that you've created the type, let's deserialize it. You'll need to create a
`DataContractJsonSerializer` object. This object must know the CLR type expected for the
JSON packet it retrieves. The packet from GitHub contains a sequence of repositories, so a
`List<repo>` is the correct type. Add the following line to your `ProcessRepositories` method:

```cs
var serializer = new DataContractJsonSerializer(typeof(List<repo>));
```

You're using two new namespaces, so you'll need to add those as well:

```cs
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
```

Next, you'll use the serializer to convert JSON into C# objects. Replace the call to
`GetStringAsync()` in your `ProcessRepositories` method with the following two lines:

```cs
var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
var repositories = serializer.ReadObject(await streamTask) as List<repo>;
```

Notice that you're now using `GetStreamAsync` instead of `GetStringAsync`. The serializer
uses a stream instead of a string as its source. Let's explain a couple features of the C#
language that are being used in the second line above. The argument to `ReadObject` is an
`await` expression. Await expressions can appear almost anywhere in your code, even though
up to now, you've only seen them as part of an assignment statement. Secondly, the `as`
operator converts from the compile time type of `object` to `List<repo>`. The declaration
of `ReadObject` declares that it returns an object of type `System.Object`. When you created
the serializer, you told it to create a `List<repo>`. `List<repo>` is derived from `System.Object`,
and the `as` operator converts from the stated type to the runtime type. If the conversion did not
succeed, the `as` operator evaluates to `null`.

You're almost done with this section. Now that you've converted the JSON to C# objects, let's display
the name of each repository:

```cs
foreach (var repo in repositories)
    Console.WriteLine(repo.name);
```

Compile and run the application. It will print out the names of the repositories that are part of the
.NET Foundation.

# Controlling Serialization

# Reading More Information

# Conclusion