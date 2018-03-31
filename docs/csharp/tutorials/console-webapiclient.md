---
title: Create a REST client using .NET Core
description: This tutorial teaches you a number of features in .NET Core and the C# language. 
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 51033ce2-7a53-4cdd-966d-9da15c8204d2
---

# REST client

## Introduction
This tutorial teaches you a number of features in .NET Core and the C# language. You’ll learn:
*	The basics of the .NET Core Command Line Interface (CLI).
*   An overview of C# Language features.
*	Managing dependencies with NuGet
*   HTTP Communications
*   Processing JSON information
*   Managing configuration with Attributes. 

You’ll build an application that issues HTTP Requests to a REST
service on GitHub. You'll read information in JSON format, and convert
that JSON packet into C# objects. Finally, you'll see how to work with
C# objects.

There are a lot of features in this tutorial. Let’s build them one by one.

If you prefer to follow along with the [final sample](https://github.com/dotnet/samples/tree/master/csharp/getting-started/console-webapiclient) for this topic, you can download it. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Prerequisites
You’ll need to set up your machine to run .NET core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page. You can run this
application on Windows, Linux, macOS or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/), which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.
## Create the Application
The first step is to create a new application. Open a command prompt and
create a new directory for your application. Make that the current
directory. Type the command `dotnet new console` at the command prompt. This
creates the starter files for a basic "Hello World" application.

Before you start making modifications, let’s go through the steps to run
the simple Hello World application. After creating the application, type
`dotnet restore` ([see note](#dotnet-restore-note)) at the command prompt. This command runs the NuGet
package restore process. NuGet is a .NET package manager. This command
downloads any of the missing dependencies for your project. As this is a
new project, none of the dependencies are in place, so the first run will
download the .NET Core framework. After this initial step, you will only
need to run `dotnet restore` ([see note](#dotnet-restore-note)) when you add new dependent packages, or update
the versions of any of your dependencies.  

After restoring packages, you run `dotnet build`. This executes the build
engine and creates your application. Finally, you execute `dotnet run` to
run your application.

## Adding New Dependencies
One of the key design goals for .NET Core is to minimize the size of
the .NET framework installation. The .NET Core Application framework contains
only the most common elements of the .NET full framework. If an application
needs additional libraries for some of its features, you add those
dependencies into your C# project (\*.csproj) file. For our example, you'll need to add the `System.Runtime.Serialization.Json` package
so your application can process JSON responses.

Open your `csproj` project file. The first line of the file should appear as:

```xml
<Project Sdk="Microsoft.NET.Sdk">
```

Add the following immediately after this line: 

```xml
   <ItemGroup>
      <PackageReference Include="System.Runtime.Serialization.Json" Version="4.3.0" />
   </ItemGroup> 
```
Most code editors will provide completion for different versions of these
libraries. You'll usually want to use the latest version of any package
that you add. However, it is important to make sure that the versions
of all packages match, and that they also match the version of the .NET
Core Application framework.

After you've made these changes, you should run `dotnet restore` ([see note](#dotnet-restore-note)) again so
that the package is installed on your system.

## Making Web Requests
Now you're ready to start retrieving data from the web. In this
application, you'll read information from the 
[GitHub API](https://developer.github.com/v3/). Let's read information
about the projects under the
[.NET Foundation](http://www.dotnetfoundation.org/) umbrella. You'll
start by making the request to the GitHub API to retrieve information
on the projects. The endpoint you'll use is: [https://api.github.com/orgs/dotnet/repos](https://api.github.com/orgs/dotnet/repos). You want to retrieve all the
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

You'll need to add a `using` statement at the top of your `Main` method so
that the C# compiler recognizes the <xref:System.Threading.Tasks.Task> type:

```csharp
using System.Threading.Tasks;
```

If you build your project at this point, you'll get a warning generated
for this method, because it does not contain any `await` operators and
will run synchronously. Ignore that for now; you'll add `await` operators
as you fill in the method.

Next, rename the namespace defined in the `namespace` statement from its default of `ConsoleApp` to `WebAPIClient`. We'll later define a `repo` class in this namespace.

Next, update the `Main` method to call this method. The
`ProcessRepositories` method returns a Task, and you shouldn't exit the
program before that task finishes. Therefore, you must use the `Wait`
method to block and wait for the task to finish:

```csharp
static void Main(string[] args)
{
    ProcessRepositories().Wait();
}
```

Now, you have a program that does nothing, but does it asynchronously. Let's improve it.

First you need an object that is capable to retrieve data from the web; you can use
 a <xref:System.Net.Http.HttpClient> to do that. This object handles the request and the responses. Instantiate a single instance of that type in the `Program` class inside the Program.cs file.

```csharp
namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
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

You'll need to also add two new using statements at the top of the file for this to compile:

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

The JSON Serializer converts JSON data into C# Objects. Your first task is to define a C# class
type to contain the information you use from this response. Let's build this slowly, so start with
a simple C# type that contains the name of the repository:

```csharp
using System;

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
<xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> object. This object must know the CLR type expected for the
JSON packet it retrieves. The packet from GitHub contains a sequence of repositories, so a
`List<repo>` is the correct type. Add the following line to your `ProcessRepositories` method:

```csharp
var serializer = new DataContractJsonSerializer(typeof(List<repo>));
```

You're using two new namespaces, so you'll need to add those as well:

```csharp
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
```

Next, you'll use the serializer to convert JSON into C# objects. Replace the call to
<xref:System.Net.Http.HttpClient.GetStringAsync(System.String)> in your `ProcessRepositories` method with the following two lines:

```csharp
var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
var repositories = serializer.ReadObject(await streamTask) as List<repo>;
```

Notice that you're now using <xref:System.Net.Http.HttpClient.GetStreamAsync(System.String)> instead of <xref:System.Net.Http.HttpClient.GetStringAsync(System.String)>. The serializer
uses a stream instead of a string as its source. Let's explain a couple features of the C#
language that are being used in the second line above. The argument to <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.ReadObject(System.IO.Stream)> is an
`await` expression. Await expressions can appear almost anywhere in your code, even though
up to now, you've only seen them as part of an assignment statement.

Secondly, the `as` operator converts from the compile time type of `object` to `List<repo>`. 
The declaration of <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.ReadObject(System.IO.Stream)> declares that it returns an object of type <xref:System.Object?displayProperty=nameWithType>. <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer.ReadObject(System.IO.Stream)> will return the type you specified when you constructed it (`List<repo>` in
this tutorial). If the conversion does not succeed, the `as` operator evaluates to `null`,
instead of throwing an exception.

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

Before you add more features, let's address the `repo` type and make it follow more standard
C# conventions. You'll do this by annotating the `repo` type with *attributes* that control how
the JSON Serializer works. In your case, you'll use these attributes to define a mapping between
the JSON key names and the C# class and member names. The two attributes used are the `DataContract`
attribute and the `DataMember` attribute. By convention, all Attribute classes end in the suffix
`Attribute`. However, you do not need to use that suffix when you apply an attribute. 

The `DataContract` and `DataMember` attributes are in a different library, so you'll need to add
that library to your C# project file as a dependency. Add the following line to the `<ItemGroup>` section of your project file:

```xml
<PackageReference Include="System.Runtime.Serialization.Primitives" Version="4.3.0" />
```

After you save the file, run `dotnet restore` ([see note](#dotnet-restore-note)) to retrieve this package.

Next, open the `repo.cs` file. Let's change the name to use Pascal Case, and fully spell out the name
`Repository`. We still want to map JSON 'repo' nodes to this type, so you'll need to add the 
`DataContract` attribute to the class declaration. You'll set the `Name` property of the attribute
to the name of the JSON nodes that map to this type:

```csharp
[DataContract(Name="repo")]
public class Repository
```

The <xref:System.Runtime.Serialization.DataContractAttribute> is a member of the <xref:System.Runtime.Serialization> namespace, so you'll
need to add the appropriate `using` statement at the top of the file:

```csharp
using System.Runtime.Serialization;
```

You changed the name of the `repo` class to `Repository`, so you'll need to make the same name change
in Program.cs (some editors may support a rename refactoring that will make this change automatically:)

```csharp
var serializer = new DataContractJsonSerializer(typeof(List<Repository>));

// ...

var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
```

Next, let's make the same change with the `name` field by using the <xref:System.Runtime.Serialization.DataMemberAttribute> class. Make
the following changes to the declaration of the `name` field in repo.cs:

```csharp
[DataMember(Name="name")]
public string Name;
```

This change means you need to change the code that writes the name of each repository in program.cs:

```csharp
Console.WriteLine(repo.Name);
```

Do a `dotnet build` followed by a `dotnet run` to make sure you've got the mappings correct. You should
see the same output as before. Before we process more properties from the web server, let's make one
more change to the `Repository` class. The `Name` member is a publicly accessible field. That's not
a good object-oriented practice, so let's change it to a property. For our purposes, we don't need
any specific code to run when getting or setting the property, but changing to a property makes it
easier to add those changes later without breaking any code that uses the `Repository` class.

Remove the field definition, and replace it with an [auto-implemented property](../programming-guide/classes-and-structs/auto-implemented-properties.md):

```csharp
public string Name { get; set; }
```

The compiler generates the body of the `get` and `set` accessors, as well as a private field to
store the name. It would be similar to the following code that you could type by hand:

```csharp
public string Name 
{ 
    get { return this._name; }
    set { this._name = value; }
}
private string _name;
```

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
var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
return repositories;
```

The compiler generates the `Task<T>` object for the return because you've marked this method as `async`.
Then, let's modify the `Main` method so that it captures those results and writes each repository name
to the console. Your `Main` method now looks like this:

```csharp
public static void Main(string[] args)
{
    var repositories = ProcessRepositories().Result;

    foreach (var repo in repositories)
        Console.WriteLine(repo.Name);
}
```

Accessing the `Result` property of a Task blocks until the task has completed. Normally, you would prefer
to `await` the completion of the task, as in the `ProcessRepositories` method, but that isn't allowed in the
`Main` method.

## Reading More Information

Let's finish this by processing a few more of the properties in the JSON packet that gets sent from the
GitHub API. You won't want to grab everything, but adding a few properties will demonstrate a few more
features of the C# language.

Let's start by adding a few more simple types to the `Repository` class definition. Add these properties
to that class:

```csharp
[DataMember(Name="description")]
public string Description { get; set; }

[DataMember(Name="html_url")]
public Uri GitHubHomeUrl { get; set; }

[DataMember(Name="homepage")]
public Uri Homepage { get; set; }

[DataMember(Name="watchers")]
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

That format does not follow any of the standard .NET <xref:System.DateTime> formats. Because of that, you'll need to write
a custom conversion method. You also probably don't want the raw string exposed to users of the `Repository`
class. Attributes can help control that as well. First, define a `private` property that will hold the
string representation of the date time in your `Repository` class:

```csharp
[DataMember(Name="pushed_at")]
private string JsonDate { get; set; }
```

The `DataMember` attribute informs the serializer that this should be processed, even though it is not
a public member. Next, you need to write a public read-only property that converts the string to a
valid <xref:System.DateTime> object, and returns that <xref:System.DateTime>:

```csharp
[IgnoreDataMember]
public DateTime LastPush
{
    get
    {
        return DateTime.ParseExact(JsonDate, "yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
    }
}
```

Let's go over the new constructs above. The `IgnoreDataMember` attribute instructs the serializer
that this type should not be read to or written from any JSON object. This property contains only a
`get` accessor. There is no `set` accessor. That's how you define a *read-only* property in C#. (Yes,
you can create *write-only* properties in C#, but their value is limited.) The <xref:System.DateTime.ParseExact(System.String,System.String,System.IFormatProvider)>
method parses a string and creates a <xref:System.DateTime> object using a provided date format, and adds additional 
metadata to the `DateTime` using a `CultureInfo` object. If the parse operation fails, the
property accessor throws an exception.

To use <xref:System.Globalization.CultureInfo.InvariantCulture>, you will need to add the <xref:System.Globalization> namespace to the `using` statements 
in `repo.cs`:

```csharp
using System.Globalization;
```

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
