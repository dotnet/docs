---
title: "Tutorial: Make HTTP requests from a .NET console application using C#"
description: Learn how to make HTTP requests from a .NET console application to a REST web service using C#.
ms.date: 04/21/2021
---

# Tutorial: Make HTTP requests from a .NET console application using C\#

In this tutorial you learn how to:

> [!div class="checklist"]
>
> * Do HTTP Communications.
> * Process JSON information.
> * Manage configuration with Attributes.

You'll build an application that issues HTTP requests to a REST
service on GitHub. You'll read information in JSON format and convert
the JSON into C# objects.

If you prefer to follow along with the [final sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-webapiclient) for this article, you can download it. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

## Prerequisites

* [.NET SDK 5.0 or later](https://dotnet.microsoft.com/download/dotnet/5.0)
* A code editor. The tutorial instructions refer to [Visual Studio Code](https://code.visualstudio.com/), which is an open
source, cross platform editor. You can run this application on Windows, Linux, or macOS, or in a Docker container.

## Create the client application

1. Open a command prompt and create a new directory for your application. Make that the current
directory. Enter the following command in a console window:

   ```dotnetcli
   dotnet new console --name WebAPIClient
   ```

   This creates the starter files for a basic "Hello World" application. The project name is "WebAPIClient". As this is a new project, none of the dependencies are in place.

1. Navigate into the "WebAPIClient" directory and type `dotnet run` at the command prompt to run the application.

   ```dotnetcli
   cd WebAPIClient
   dotnet run
   ```

   [`dotnet run`](../../core/tools/dotnet-run.md) automatically runs [`dotnet restore`](../../core/tools/dotnet-restore.md) and runs [`dotnet build`](../../core/tools/dotnet-build.md) if needed.

## Make HTTP requests

This application will call the [GitHub API](https://developer.github.com/v3/) to get information about the projects under the
[.NET Foundation](https://www.dotnetfoundation.org/) umbrella. The endpoint is: <https://api.github.com/orgs/dotnet/repos>. To retrieve information, it makes an HTTP GET request. Browsers also make HTTP GET requests, so you can paste that URL into your browser address bar to see what information you'll be receiving and processing.

You'll use the <xref:System.Net.Http.HttpClient> class to make HTTP requests. <xref:System.Net.Http.HttpClient> supports only async methods for its long-running APIs.

1. Open the `Program.cs` file in your project directory and add the following async method to the `Program` class:

   ```csharp
   private static async Task ProcessRepositories()
   {
   }
   ```

1. Add a `using` directive at the top of the program.cs file so
that the C# compiler recognizes the <xref:System.Threading.Tasks.Task> type:

   ```csharp
   using System.Threading.Tasks;
   ```

If you build the project at this point, you get a warning generated for this method, because it doesn't contain any `await` operators and
runs synchronously. Ignore that for now; you'll add `await` operators as you fill in the method.

1. Replace the `Main` method with the following code:

   ```csharp
   static async Task Main(string[] args)
   {
       await ProcessRepositories();
   }
   ```

   These changes:

   * Change the signature of `Main` by adding the `async` modifier and changing the return type to `Task`.
   * Replace the `Console.WriteLine` statement with a call to `ProcessRepositories` that uses the `await` keyword.

1. In the Program class, create a static instance of <xref:System.Net.Http.HttpClient> to handle requests and responses.

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

1. Add code to the `ProcessRepositories` method to call the GitHub endpoint and display the result.

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

1. Add two `using` directives at the top of the file:

   ```csharp
   using System.Net.Http;
   using System.Net.Http.Headers;
   ```

The code in `ProcessRepositories` makes a web request to read the list of all repositories under the .NET foundation organization. (The GitHub ID for the .NET Foundation is `dotnet`.)

The first few lines set up HTTP headers that will be included in all requests:
  
* An `Accept` header to accept the GitHub JSON responses.
* A `User-Agent` header.

These two headers are checked by the GitHub server code, and are necessary to retrieve information from GitHub.

After the headers are configured, <xref:System.Net.Http.HttpClient.GetStringAsync(System.String)?displayProperty=nameWithType> is called to make a web request and retrieve the response. This method starts a task that makes the web request, and then when the request returns, it reads the response stream and extracts the content from the stream. The body of the response is returned as a <xref:System.String>. The string is available when the task completes.

The final two lines of this method await that task and then print the response to the console.

1. Build the app and run it.

   ```dotnetcli
   dotnet run
   ```

   The build warning is gone, because the `ProcessRepositories` now does contain an `await` operator. The output is a long display of JSON formatted text.

## Processing the JSON Result

At this point, the code retrieves a response from a web server and displays the text that is contained in that response. In the following steps, you convert that JSON response into C# objects. You'll use the <xref:System.Text.Json.JsonSerializer?displayProperty=nameWithType> class to serializes objects to JSON and deserializes JSON into objects.

1. Create a file named "repo.cs" and put the following code in it. This code defines a class to represent the `repo` JSON object returned from the GitHub API:

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

   You'll use this class to display a list of repository names. When you deserialize a repository object from the JSON, only the name proprey will be deserialized. The serializer automatically ignores JSON properties for which there is no match in the class that is the target of deserialization. This feature makes it easier to create types that work with only a subset of the fields in the JSON packet.

    The name property is in lowercase letters because that matches exactly what's in the JSON. Later you'll see how to follow the C# convention of capitalizing the first letter of property names.

1. Use the serializer to convert JSON into C# objects. Replace the call to
<xref:System.Net.Http.HttpClient.GetStringAsync(System.String)> in the `ProcessRepositories` method with the following lines:

   ```csharp
   var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
   var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
   ```

1. Add the following `using` directives at the top of the file:

   ```csharp
   using System.Collections.Generic;
   using System.Text.Json;
   ```

   Notice that you're now using <xref:System.Net.Http.HttpClient.GetStreamAsync(System.String)> instead of <xref:System.Net.Http.HttpClient.GetStringAsync(System.String)>. The serializer uses a stream instead of a string as its source.

   The first argument to <xref:System.Text.Json.JsonSerializer.DeserializeAsync%60%601(System.IO.Stream,System.Text.Json.JsonSerializerOptions,System.Threading.CancellationToken)?displayProperty=nameWithType> is an `await` expression. (The other two parameters are optional and are omitted in the code snippet.) `await` expressions can appear almost anywhere in your code, even though up to now, you've only seen them as part of an assignment statement.

   The `Deserialize` method is *generic*, which means you must supply type arguments for what kind of objects should be created from the JSON text. In this example, you're deserializing to a `List<Repository>`, which is another generic object, the <xref:System.Collections.Generic.List%601?displayProperty=nameWithType>. The `List<T>` class stores a collection of objects. The type argument declares the type of objects stored in the `List<T>`. The JSON text represents a collection of repository objects, so the type argument is `Repository`.

1. Add code to display the name of each repository. Replace the lines that read:

   ```csharp
   var msg = await stringTask;   //**Deleted this
   Console.Write(msg);
   ```

   with the following:

   ```csharp
   foreach (var repo in repositories)
       Console.WriteLine(repo.name);
   ```

1. Compile and run the application.

   ```dotnetcli
   dotnet run
   ```

   The output is a list of the names of the repositories that are part of the .NET Foundation.

## Controll serialization

1. In *repo.cs*, change the `name` property to `Name` and add a `[JsonPropertyName]` attribute to specify how this property appears in the JSON.

   ```csharp
   [JsonPropertyName("name")]
   public string Name { get; set; }
   ```

1. Add the <xref:System.Text.Json.Serialization> namespace to the `using` directives:

   ```csharp
   using System.Text.Json.Serialization;
   ```

1. In *Program.cs*, update the code to use the new capitalization of the `Name` property:

   ```csharp
   Console.WriteLine(repo.Name);
   ```

1. Compile and run the application.

   ```dotnetcli
   dotnet run
   ```

## Simplify some code

The `ProcessRepositories` method can do the async work and return a collection of the repositories. Change that method to return `List<Repository>`, and move the code that writes the information into the `Main` method.

1. Change the signature of `ProcessRepositories` to return a task whose result is a list of `Repository` objects:

   ```csharp
   private static async Task<List<Repository>> ProcessRepositories()
   ```

1. Return the repositories after processing the JSON response:

   ```csharp
   var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
   var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await streamTask);
   return repositories;
   ```

   The compiler generates the `Task<T>` object for the return because you've marked this method as `async`.

1. Modify the `Main` method so that it captures those results and writes each repository name to the console. Your `Main` method now looks like this:

   ```csharp
   public static async Task Main(string[] args)
   {
       var repositories = await ProcessRepositories();
   
       foreach (var repo in repositories)
           Console.WriteLine(repo.Name);
   }
   ```

## Read more information

Process  a few more of the properties in the JSON packet that gets sent from the
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

Your version should now match the [finished sample](https://github.com/dotnet/samples/tree/main/csharp/getting-started/console-webapiclient).

## Conclusion

This tutorial showed you how to make web requests, parse the result, and display properties of
those results. You've also added new packages as dependencies in your project. You've seen some of
the features of the C# language that support object-oriented techniques.
