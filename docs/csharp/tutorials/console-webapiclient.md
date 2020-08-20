---
title: Create a REST client using .NET Core
description: This tutorial teaches you a number of features in .NET Core and the C# language.
ms.date: 01/09/2020
ms.assetid: 51033ce2-7a53-4cdd-966d-9da15c8204d2
---

# REST client

This tutorial teaches you a number of features in .NET Core and the C# language. You’ll learn:

* The basics of the .NET Core CLI.
* An overview of C# Language features.
* Managing dependencies with NuGet
* HTTP Communications
* Processing JSON information
* Managing configuration with Attributes.

You’ll build an application that issues HTTP Requests to a REST
service on GitHub. You'll read information in JSON format, and convert
that JSON packet into C# objects. Finally, you'll see how to work with
C# objects.

There are many features in this tutorial. Let’s build them one by one.

If you prefer to follow along with the [final sample](https://github.com/dotnet/samples/tree/master/csharp/getting-started/console-webapiclient) for this topic, you can download it. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

## Prerequisites

You’ll need to set up your machine to run .NET core. You can find the
installation instructions on the [.NET Core Downloads](https://dotnet.microsoft.com/download)
page. You can run this
application on Windows, Linux, macOS or in a Docker container.
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/), which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

## Create the Application

The first step is to create a new application. Open a command prompt and
create a new directory for your application. Make that the current
directory. Enter the following command in a console window:

```dotnetcli
dotnet new console --name WebAPIClient
```

This creates the starter files for a basic "Hello World" application. The project name is "WebAPIClient". As this is a new project, none of the dependencies are in place. The first run will download the .NET Core framework, install a development certificate, and run the NuGet package manager to restore missing dependencies.

Before you start making modifications, type
`dotnet run` ([see note](#dotnet-restore-note)) at the command prompt to
run your application. `dotnet run` automatically performs `dotnet restore`
if your environment is missing dependencies. It also performs `dotnet build` if your application needs to be rebuilt.
After your initial setup, you will only need to run `dotnet restore` or `dotnet build`
when it makes sense for your project.

## Adding New Dependencies

One of the key design goals for .NET Core is to minimize the size of
the .NET installation. If an application
needs additional libraries for some of its features, you add those
dependencies into your C# project (\*.csproj) file. For our example, you'll need to add the `System.Runtime.Serialization.Json` package,
so your application can process JSON responses.

You'll need the `System.Runtime.Serialization.Json` package for this application. Add it to your project by running the following [.NET CLI](../../core/tools/dotnet-add-package.md) command:

```dotnetcli
dotnet add package System.Text.Json
```

## Making Web Requests

Now you're ready to start retrieving data from the web. In this
application, you'll read information from the
[GitHub API](https://developer.github.com/v3/). Let's read information
about the projects under the
[.NET Foundation](https://www.dotnetfoundation.org/) umbrella. You'll
start by making the request to the GitHub API to retrieve information
on the projects. The endpoint you'll use is: <https://api.github.com/orgs/dotnet/repos>. You want to retrieve all the
information about these projects, so you'll use an HTTP GET request.
Your browser also uses HTTP GET requests, so you can paste that URL into
your browser to see what information you'll be receiving and processing.

You use the <xref:System.Net.Http.HttpClient> class to make web requests. Like all modern .NET
APIs, <xref:System.Net.Http.HttpClient> supports only async methods for its long-running APIs.
Start by making an async method. You'll fill in the implementation as you
build the functionality of the application. Start by opening the `program.cs` file in your project directory and adding the following method to the `Program` class:

```csharp
private static async Task ProcessRepositories()
{
}
```

You'll need to add a `using` directive at the top of your `Main` method so
that the C# compiler recognizes the <xref:System.Threading.Tasks.Task> type:

```csharp
using System.Threading.Tasks;
```

If you build your project at this point, you'll get a warning generated
for this method, because it does not contain any `await` operators and
will run synchronously. Ignore that for now; you'll add `await` operators
as you fill in the method.

Next, update the `Main` method to call the `ProcessRepositories` method. The
`ProcessRepositories` method returns a task, and you shouldn't exit the
program before that task finishes. Therefore, you must change the signature of `Main`. Add the `async` modifier, and change the return type to `Task`. Then, in the body of the method, add a call to `ProcessRepositories`. Add the `await` keyword to that method call:

```csharp
static async Task Main(string[] args)
{
    await ProcessRepositories();
}
```

Now, you have a program that does nothing, but does it asynchronously. Let's improve it.

First you need an object that is capable to retrieve data from the web; you can use
 a <xref:System.Net.Http.HttpClient> to do that. This object handles the request and the responses. Instantiate a single instance of that type in the `Program` class inside the *Program.cs* file.

```csharp
namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            //...
        }
    }
}
```

Let's go back to the `ProcessRepositories` method and fill in a first version of it:

```csharp
private static async Task ProcessRepositories()
{
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

    var stringTask = client.GetStringAsync("https://api.github.com/orgs/dotnet/repos");

    var msg = await stringTask;
    Console.Write(msg);
}
```

You'll need to also add two new `using` directives at the top of the file for this to compile:

```csharp
using System.Net.Http;
using System.Net.Http.Headers;
```

This first version makes a web request to read the list of all repositories under the dotnet
foundation organization. (The gitHub ID for the .NET Foundation is 'dotnet'). The first few lines set up
the <xref:System.Net.Http.HttpClient> for this request. First, it is configured to accept the GitHub JSON responses.
This format is simply JSON. The next line adds a User Agent header to all requests from this
object. These two headers are checked by the GitHub server code, and are necessary to retrieve
information from GitHub.

After you've configured the <xref:System.Net.Http.HttpClient>, you make a web request and retrieve the response. In
this first version, you use the <xref:System.Net.Http.HttpClient.GetStringAsync(System.String)?displayProperty=nameWithType> convenience method. This convenience method
starts a task that makes the web request, and then when the request returns, it reads the
response stream and extracts the content from the stream. The body of the response is returned
as a <xref:System.String>. The string is available when the task completes.

The final two lines of this method await that task, and then print the response to the console.
Build the app, and run it. The build warning is gone now, because the `ProcessRepositories` now
does contain an `await` operator. You'll see a long display of JSON formatted text.

## Processing the JSON Result

At this point, you've written the code to retrieve a response from a web server, and display
the text that is contained in that response. Next, let's convert that JSON response into C#
objects.

The <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> class serializes objects to JSON and deserializes JSON into objects. Start by defining a class to represent the `repo` JSON object returned from the GitHub API:

```csharp
using System;

namespace WebAPIClient
{
    public class Repository
    {
        public string name { get; set; }
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

Now that you've created the type, let's deserialize it.

Next, you'll use the serializer to convert JSON into C# objects. Replace the call to
<xref:System.Net.Http.HttpClient.GetStringAsync(System.String)> in your `ProcessRepositories` method with the following lines:

```csharp
var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
```

You're using new namespaces, so you'll need to add it at the top of the file as well:

```csharp
using System.Collections.Generic;
using System.Text.Json;
```

Notice that you're now using <xref:System.Net.Http.HttpClient.GetStreamAsync(System.String)> instead of <xref:System.Net.Http.HttpClient.GetStringAsync(System.String)>. The serializer
uses a stream instead of a string as its source. Let's explain a couple features of the C#
language that are being used in the second line of the preceding code snippet. The first argument to <xref:System.Text.Json.JsonSerializer.DeserializeAsync%60%601(System.IO.Stream,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=nameWithType> is an
`await` expression. (The other two parameters are optional and are omitted in the code snippet.) Await expressions can appear almost anywhere in your code, even though
up to now, you've only seen them as part of an assignment statement. The `Deserialize` method is *generic*, which means you must supply type arguments for what kind of objects should be created from the JSON text. In this example, you're deserializing to a `List<Repository>`, which is another generic object, the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. The `List<>` class stores a collection of objects. The type argument declares the type of objects stored in the `List<>`. The JSON text represents a collection of repo objects, so the type argument is `Repository`.

You're almost done with this section. Now that you've converted the JSON to C# objects, let's display
the name of each repository. Replace the lines that read:

```csharp
var msg = await stringTask;   //**Deleted this
Console.Write(msg);
```

with the following:

```csharp
foreach (var repo in repositories)
    Console.WriteLine(repo.name);
```

Compile and run the application. It will print out the names of the repositories that are part of the
.NET Foundation.

## Controlling Serialization

Before you add more features, let's address the `name` property by using the `[JsonPropertyName]` attribute. Make
the following changes to the declaration of the `name` field in repo.cs:

```csharp
[JsonPropertyName("name")]
public string Name { get; set; }
```

To use `[JsonPropertyName]` attribute, you will need to add the <xref:System.Text.Json.Serialization> namespace to the `using` directives:

```csharp
using System.Text.Json.Serialization;
```

This change means you need to change the code that writes the name of each repository in program.cs:

```csharp
Console.WriteLine(repo.Name);
```

Execute `dotnet run` to make sure you've got the mappings correct. You should
see the same output as before.

Let's make one more change before adding new features. The `ProcessRepositories` method can do the async
work and return a collection of the repositories. Let's return the `List<Repository>` from that method,
and move the code that writes the information into the `Main` method.

Change the signature of `ProcessRepositories` to return a task whose result is a list of `Repository`
objects:

```csharp
private static async Task<List<Repository>> ProcessRepositories()
```

Then, just return the repositories after processing the JSON response:

```csharp
var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
return repositories;
```

The compiler generates the `Task<T>` object for the return because you've marked this method as `async`.
Then, let's modify the `Main` method so that it captures those results and writes each repository name
to the console. Your `Main` method now looks like this:

```csharp
public static async Task Main(string[] args)
{
    var repositories = await ProcessRepositories();

    foreach (var repo in repositories)
        Console.WriteLine(repo.Name);
}
```

## Reading More Information

Let's finish this by processing a few more of the properties in the JSON packet that gets sent from the
GitHub API. You won't want to grab everything, but adding a few properties will demonstrate a few more
features of the C# language.

Let's start by adding a few more simple types to the `Repository` class definition. Add these properties
to that class:

```csharp
[JsonPropertyName("description")]
public string Description { get; set; }

[JsonPropertyName("html_url")]
public Uri GitHubHomeUrl { get; set; }

[JsonPropertyName("homepage")]
public Uri Homepage { get; set; }

[JsonPropertyName("watchers")]
public int Watchers { get; set; }
```

These properties have built-in conversions from the string type (which is what the JSON packets contain) to
the target type. The <xref:System.Uri> type may be new to you. It represents a URI, or in this case, a URL. In the case
of the `Uri` and `int` types, if the JSON packet contains data that does not convert to the target type,
the serialization action will throw an exception.

Once you've added these, update the `Main` method to display those elements:

```csharp
foreach (var repo in repositories)
{
    Console.WriteLine(repo.Name);
    Console.WriteLine(repo.Description);
    Console.WriteLine(repo.GitHubHomeUrl);
    Console.WriteLine(repo.Homepage);
    Console.WriteLine(repo.Watchers);
    Console.WriteLine();
}
```

As a final step, let's add the information for the last push operation. This information is formatted in
this fashion in the JSON response:

```json
2016-02-08T21:27:00Z
```

That format is in Coordinated Universal Time (UTC) so you'll get a <xref:System.DateTime> value whose <xref:System.DateTime.Kind%2A> property is <xref:System.DateTimeKind.Utc>. If you prefer a date represented in your time zone, you'll need to write
a custom conversion method. First, define a `public` property that will hold the
UTC representation of the date and time in your `Repository` class and a `LastPush` `readonly` property that returns the date converted to local time:

```csharp
[JsonPropertyName("pushed_at")]
public DateTime LastPushUtc { get; set; }

public DateTime LastPush => LastPushUtc.ToLocalTime();
```

Let's go over the new constructs we just defined. The `LastPush` property is defined using an *expression-bodied member* for the `get` accessor. There is no `set` accessor. Omitting the `set` accessor is how you define a *read-only* property in C#. (Yes,
you can create *write-only* properties in C#, but their value is limited.)

Finally, add one more output statement in the console, and you're ready to build and run this app
again:

```csharp
Console.WriteLine(repo.LastPush);
```

Your version should now match the [finished sample](https://github.com/dotnet/samples/tree/master/csharp/getting-started/console-webapiclient).

## Conclusion

This tutorial showed you how to make web requests, parse the result, and display properties of
those results. You've also added new packages as dependencies in your project. You've seen some of
the features of the C# language that support object-oriented techniques.

<a name="dotnet-restore-note"></a>

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]
