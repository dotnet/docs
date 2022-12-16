---
title: 'Quickstart: Build your first Orleans app with ASP.NET Core'
description: Learn how to use Orleans to build a scalable, distributed ASP.NET Core application
author: alexwolfmsft
ms.author: alexwolf
ms.date: 12/16/2022
ms.topic: quickstart
ms.service: orleans
ms.devlang: csharp
---

In this quickstart, you'll use Orleans and ASP.NET Core 7.0 Minimal APIs to build a URL shortener app. Users can submit a full URL to the app, which will return a shortened version they can share with others, who will then be redirected to the full site. The app will use Orleans grains and silos to manage state in a distributed manner to allow for scalability and resiliency. These features are critical when developing apps for distributed cloud hosting services like Azure Container Apps and platforms like Kubernetes.

At the end of the quickstart, you'll have an app that creates and handles redirects using short, friendly URLs. You'll learn how to:

* Add Orleans to an ASP.NET Core app
* Work with grains and silos
* Configure state management
* Integrate Orleans with API endpoints

## Prerequisites

# [Visual Studio](#tab/visual-studio)

- .NET 7.0 SDK
- Visual Studio 2022 with the ASP.NET and web development workload

# [Visual Studio Code](#tab/visual-studio-code)

- .NET 7.0 SDK
- Visual Studio Code

---

## Create the app

# [Visual Studio](#tab/visual-studio)

1. Start Visual Studio 2022 and select **Create a new project**.

   ![Create a new project from the start window](~/tutorials/razor-pages/razor-pages-start/_static/6/start-window-create-new-project.png)

1. In the **Create a new project** dialog, select **ASP.NET Core Web App**, and then select **Next**.

    ![Create an ASP.NET Core Web App](~/tutorials/razor-pages/razor-pages-start/_static/6/np.png)

1. In the **Configure your new project** dialog, enter `SignalRChat` for **Project name**. It's important to name the project *SignalRChat*, including matching the capitalization, so the namespaces will match when you copy and paste example code.

1. Select **Next**.

1. In the **Additional information** dialog, select **.NET 7.0 (Standard support)** and then select **Create**.

    ![Additional information](~/tutorials/razor-pages/razor-pages-start/_static/6/additional-info.png)

# [Visual Studio Code](#tab/visual-studio-code)

1. Open the [integrated terminal](https://code.visualstudio.com/docs/editor/integrated-terminal).

1. Change to the directory (`cd`) that will contain the project.
1. Run the following commands:

   ```dotnetcli
   dotnet new webapp -o OrleansURLShortener
   code -r OrleansURLShortener
   ```

   Visual Studio Code displays a dialog box that asks **Do you trust the authors of the files in this folder**.  Select:
    * The checkbox **trust the authors of all files in the parent folder**
    * **Yes, I trust the authors** (because dotnet generated the files).

   The `dotnet new` command creates a new Razor Pages project in the *SignalRChat* folder.

   The `code` command opens the *SignalRChat* folder in the current instance of Visual Studio Code.

---

## Add Orleans to the project

Orleans is available through a collection of NuGet packages, which provide access to various features. For this quickstart, add the Orleans.Server package to the app using the steps below below:

# [Visual Studio](#tab/visual-studio)

- Right click on the **OrleansURLShortener** project node in the solution explorer and select **Manage NuGet Packages**.
- In the package manager window, search for *Orleans*.
- Select the **Orleans.Server** package from the search results and select **Install**.

# [Visual Studio Code](#tab/visual-studio-code)

- In the Visual Studio code terminal, run the following command:

```dotnetcli
dotnet add package Microsoft.Orleans.Server
```

---

Open the *program.cs* file and replace the existing content with the following code:

```csharp
using Microsoft.AspNetCore.Http.Extensions;
using Orleans.Runtime;

var builder = WebApplication.CreateBuilder();

var app = builder.Build();

app.Run();
```

## Configure the silos

[Silos](/dotnet/orleans/overview#what-are-silos) are responsible for storing grains and are another core building block of Orleans. A silo can contain one or more grains; a group of silos is known as a cluster. The cluster coordinates work between silos, allowing communication with grains as though they were all available in a single process. You can organize your data by storing different types of grains in different silos. Your application can retrieve individual grains without having to worry about the details of how they're managed within the cluster.

At the top of the Program class, refactor the builder code to use Orleans. The code uses a `SiloBuilder` class to create a cluster with a silo that can store grains. [In this scenario, you'll use a localhost cluster, but in a production app you can configure more scalable clusters using services like Azure Table Storage. The `SiloBuilder` also uses the `AddMemoryGrainStorage` to configure the Orleans silos to persist grains in memory.

```csharp
var builder = WebApplication.CreateBuilder();

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddMemoryGrainStorage("urls");
});

var app = builder.Build();

app.Run();
```

## Create the URL shortener grain

[Grains](/dotnet/orleans/overview#what-are-grains) are the most essential primitives and building blocks of Orleans applications. A grain is a class that inherits from the Grain base class, which manages various internal behaviors and integration points with the Orleans framework. Grains should also implement one of the interfaces listed below to define the type of grain key identifier. Each of these interfaces defines a similar contract, but marks your class with a different data type for the identifier that Orleans uses to track the grain, such as a string or integer.

- IGrainWithGuidKey
- IGrainWithIntegerKey
- IGrainWithStringKey
- IGrainWithGuidCompoundKey
- IGrainWithIntegerCompoundKey

For this quickstart, you'll use the `IGrainWithStringKey`, since strings are a logical choice for working with URL values and short codes. Orleans grains can also use a custom interface to define their methods and properties. The URL shortener grain interface should define two methods:

- A `SetUrl` method to persist the original and shortened URL.
- A `GetUrl` method to retrieve the original URL using the shortened URL.

1. Inside of the `Program` class, add the following interface definition to the bottom of the file. Grains can implement different interfaces that .

    ```csharp
    public interface IUrlShortenerGrain : IGrainWithStringKey
    {
        Task SetUrl(string shortenedRouteSegment, string fullUrl);
        Task<string> GetUrl();
    }
    ```

1. Create a `UrlShortenerGrain` class using the following code. This class inherits from the `Grain` class provided by Orleans and implements the `IUrlShortenerGrain` interface you created. The class also uses the `IPersistentState` interface of Orleans to manage reading and writing state values for the URLs to the configured silo storage.

    ```csharp
    public class UrlShortenerGrain : Grain, IUrlShortenerGrain
    {
        private IPersistentState<KeyValuePair<string, string>> _cache;
    
        public UrlShortenerGrain(
            [PersistentState(
                stateName: "url",
                storageName: "urls")]
                IPersistentState<KeyValuePair<string, string>> state)
        {
            _cache = state;
        }
    
        public async Task SetUrl(string shortenedRouteSegment, string fullUrl)
        {
            _cache.State = new KeyValuePair<string, string>(shortenedRouteSegment, fullUrl);
            await _cache.WriteStateAsync();
        }
    
        public Task<string> GetUrl()
        {
            return Task.FromResult(_cache.State.Value);
        }
    }
    ```

## Create the endpoints

Next, create two endpoints to utilize the Orleans grain and silo configurations:

- A `/shorten/{*url}` endpoint to handle creating and storing a shortened version of the URL. The original, full URL is provided as a path parameter, and the shortened URL is returned to the user for later use.
- A `/go/{*shortenedUrl}` endpoint to handle redirecting users to the original URL using the shortened URL that is supplied as a parameter.

Append the following code to the end of the `Program.cs` file:

```csharp
app.MapGet("/shorten/{*path}",
    async (IGrainFactory grains, HttpRequest request, string path) =>
    {
        // Create a unique, short ID
        var shortenedRouteSegment = Guid.NewGuid().GetHashCode().ToString("X");

        // Create and persist a grain with the shortened ID and full URL
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        await shortenerGrain.SetUrl(shortenedRouteSegment, path);

        // Return the shortened URL for later use
        var resultBuilder = new UriBuilder(request.GetEncodedUrl())
        {
            Path = $"/go/{shortenedRouteSegment}"
        };
    
        return Results.Ok(resultBuilder.Uri);
    });

app.MapGet("/go/{shortenedRouteSegment}",
    async (IGrainFactory grains, string shortenedRouteSegment) =>
    {
        // Retrieve the grain using the shortened ID and redirect to the original URL        
        var shortenerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);
        var url = await shortenerGrain.GetUrl();
    
        return Results.Redirect(url);
    });
```

## Test the app

The core functionality of the app should now work as expected, so now you can test your code.

1) Inside the Visual Studio Code terminal, run the `dotnet run` command again to launch the app.

    ```dotnetcli
    dotnet run
    ```

    The app should launch in the browser and display the familiar `Hello world!` text.

2) In the browser address bar, test the `shorten` endpoint by entering a URL path such as `{localhost}/shorten/https://microsoft.com`. The page should reload and provide a shortened URL. Copy the shortened URL to your clipboard.

3) Paste the shortened URL into the address bar and press enter. The page should reload and redirect you to [https://microsoft.com](https://microsoft.com).