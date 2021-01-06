---
title: Getting started with Dapr
description: This chapter will guide you through preparing your local development environment and building your first .NET applications with Dapr.
author: amolenk 
ms.date: 01/06/2021
---

# Getting started with Dapr

Now that you've learned the basic concepts of Dapr, it's time to get some hands-on experience. This chapter will guide you through preparing your local development environment and building two .NET applications with Dapr.

## Installing Dapr into your local environment

In this section we'll explain how to install Dapr into your local development environment. With Dapr installed locally, you can run your application with Dapr in self-hosted mode.

Follow these steps to install Dapr locally:

1. [Install the Dapr CLI](https://docs.dapr.io/getting-started/install-dapr-cli/). The Dapr CLI allows you to setup Dapr on your local environment or on a Kubernetes cluster. It also provides debugging support, and launches and manages Dapr instances.

1. Install [Docker Desktop](https://docs.docker.com/get-docker/). If you're running on Windows, make sure that **Docker Desktop for Windows** is configured to use Linux containers.

  > By default, Dapr uses Docker containers to give you the best out-of-the-box experience. If you want to install Dapr locally without requiring Docker, you can skip these steps and [execute a *slim* initialization](https://docs.dapr.io/operations/hosting/self-hosted/self-hosted-no-docker/) instead. Note that the walkthroughs in this chapter require that you use Docker containers.

1. [Initialize Dapr using the CLI](https://docs.dapr.io/getting-started/install-dapr/).

Now that Dapr is installed in your local environment, let's build your first Dapr application!

## Building your first Dapr application

In this walkthrough, we'll show you how to build a basic .NET Console application that uses the Dapr State Management building block.

To complete this walkthrough, you'll also need to install the [.NET Core 3 Development Tools](https://dotnet.microsoft.com/download/dotnet-core/3.1) for development with .NET Core 3.1.

### Create the application

1. In your terminal, enter the following command to create a new .NET Console application:

   ```terminal
   dotnet new console -o DaprCounter
   ```

1. Then, navigate to the new directory created by the previous command:

   ```terminal
   cd DaprCounter
   ```

1. The template creates a simple "Hello World" application. The application displays "Hello World!" when you run it:

   ```terminal
   dotnet run
   ```

### Add Dapr State Management

In this part of the walkthrough, you'll use the Dapr State Management building block to implement a stateful counter in the program.

While you can use both HTTP and gRPC to call the Dapr APIs, it's much nicer to use the Dapr .NET SDK. Using the Dapr .NET SDK feels more natural for a .NET developer because it provides a strongly typed client to call the Dapr APIs. It also provides integration with ASP.NET Core, making it even easier to use Dapr features such as pub/sub messaging and state management from ASP.NET Core applications.

1. Add the `Dapr.Client` NuGet package to your application:

   ```
   dotnet add package Dapr.Client
   ```

1. Open the `Program.cs` file in your favorite editor and change its contents to:

   ```c#
   using System;
   using System.Threading.Tasks;
   using Dapr;
   using Dapr.Client;
   
   namespace DaprCounter
   {
       class Program
       {
           static async Task Main(string[] args)
           {
               DaprClient daprClient = new DaprClientBuilder().Build();
   
               int counter = await daprClient.GetStateAsync<int>("statestore", "counter");
   
               while (true)
               {
                   Console.WriteLine($"Counter = {counter++}");
   
                   await daprClient.SaveStateAsync("statestore", "counter", counter);
   
                   await Task.Delay(1000);
               }
           }
       }
   }
   ```

   The updated code performs the following steps:

   - First we create a new `DaprClient` instance. The .NET `DaprClient` class can be used for most interactions with the Dapr sidecar.
   - Then we use that `DaprClient` instance to load the state with key `counter` from the state store. If there isn't any state stored yet for that key, we'll get back the default `int` value which is `0`.
   - Finally, we enter a loop that continuously writes the current `counter` value to the console, increments the value, and saves it back to the state store.

1. Now when you want to run the application, you must use the Dapr CLI `run` command to run both the application and Dapr's sidecar side by side. You also need to name your application by specifing an application id. If you don't specify an application id, Dapr will generate a unique value for you. This will cause problems with the State Management building block because it uses the application id as a prefix for the state keys. This means that if your application id changes, you will no longer be able to access any previously stored state.

   Now run the application:

   ```
   dapr run --app-id DaprCounter dotnet run
   ```

   Try stopping and starting the application a couple of times. You'll see that the counter will not reset, but start from the previously saved state, making this a truly stateful application.

At this point, you might wonder where the state is actually stored. For that we'll have to look at component configuration files, which we will address in the next section.

## Component configuration files

In the previous section, you've created a stateful application which uses the default state store component installed by Dapr. When you initialize Dapr using the `dapr init` command, the Dapr CLI automatically provisions a Redis container. It also creates a `statestore.yaml` component configuration file that contains the required settings for using the Redis container as a state store. The file is stored in the `$HOME/.dapr/components` folder on Linux/macOS, and in the `%USERPROFILE%\.dapr\components` folder on Windows. Here's a look at the contents:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
spec:
  type: state.redis
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: ""
  - name: actorStateStore
    value: "true"
```

Each component has a name. In the sample above, the component is named `statestore`. Note that we used that name in our walkthrough code to tell the Dapr sidecar which component to use. Each component configuration file has a `spec` section which contains a `type` field to specify the type of component and a `metadata` field. This holds metadata that the component requires, such as connection details and other settings. The exact metadata values you need to specify vary per component.

By default, any Dapr sidecar can use a component that you've configured. In some scenarios however, you may want to limit this access. For example, let's say that the Redis component shown above should only be accessible to sidecars running in a production environment. The first step to achieve this is to define a *namespace* for the production environment, let's call it `production`. In self-hosted mode, you must specify the namespace of a Dapr sidecar by setting the `NAMESPACE` environment variable. If the `NAMESPACE` environment variable is set, the Dapr sidecar will only load the components that match the namespace. For Kubernetes deployments, the Kubernetes namespace determines which components are loaded. The following sample shows the Redis component placed in a `production` namespace:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
  namespace: production
spec:
  type: state.redis
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: ""
  - name: actorStateStore
    value: "true"
```

We can take this one step further. Within the `production` namespace, you may want to limit access to the Redis cache to only the `DaprCounter` application. You can do so by specifying *scopes* in the component configuration. The following example shows how to further restrict access to the Redis `statestore` component to application `DaprCounter` in the `production` namespace:

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
  namespace: production
spec:
  type: state.redis
  metadata:
  - name: redisHost
    value: localhost:6379
  - name: redisPassword
    value: ""
  - name: actorStateStore
    value: "true"
  scopes:
  - DaprCounter
```

## Building a multi-container Dapr application

In the first walkthrough, we explained how you can create a simple application consisting of a single executable running side by side with a Dapr sidecar. Distributed applications such as eShopOnDapr consist of many more parts. eShopOnDapr has a number of .NET Core services running in containers along with containers for infrastructure such as Redis, SQL Server, Seq, and Zipkin. Managing multiple containers requires container orchestration and requires an orchestrator such as Docker Compose or Kubernetes. To make debugging and testing locally very easy, we use Docker Compose in eShopOnDapr.

In the following walkthrough, you'll create a multi-container application from scratch and use Dapr Service Invocation to communicate between the services. The solution will consist of a front-end web application that retrieves weather forecasts from a back-end web API. The front-end and back-end will each run in a Docker container. To complete this walkthrough, you'll need to have installed Dapr into your local environment (for example, using Docker Desktop) along with the following prerequisites:

- [Visual Studio 2019](https://visualstudio.microsoft.com/downloads) with the **.NET Core cross-platform development** workload installed
- [.NET Core 3 Development Tools](https://dotnet.microsoft.com/download/dotnet-core/3.1) for development with .NET Core 3.

### Create the application

1. In Visual Studio, create an **ASP.NET Core Web Application** project:

   ![Screenshot of creating a new project](./media/ch4-getting-started/walkthrough-multicontainer-createproject.png)

1. Name your project `DaprFrontEnd` and your solution `DaprMultiContainer`:

   ![Screenshot of configuring your new project](./media/ch4-getting-started/walkthrough-multicontainer-configureproject.png)

1. Select **Web Application** to create a web application with Razor pages. Do not select **Enable Docker Support**. You'll add Docker support later.

   ![Screenshot of creating a new ASP.NET Core web application](./media/ch4-getting-started/walkthrough-multicontainer-createwebapp.png)

1. Add a second ASP.NET Core Web Application project to the same solution and call it *DaprBackEnd*. Select **API** as the project type, and clear the checkbox for **Configure for HTTPS**. It's recommended to deploy Dapr sidecars in the same network namespace as the application. Therefore, the Dapr sidecar is designed to use unencrypted HTTP to communicate with the application. Note that we still use HTTPS for the front-end and that Dapr provides support for mTLS to encrypt calls between services.

   ![Screenshot of creating the back-end web API](./media/ch4-getting-started/walkthrough-multicontainer-createwebapi.png)

### Add Dapr Service Invocation

In this part of the walkthrough, you'll use the Dapr Service Invocation building block to make the front-end retrieve weather forecasts from the back-end web API. The Service Invocation building block provides benefits such as service discovery, automatic retries, message encryption using mTLS, and improved observability. See [chapter 6](./ch6-service-invocation.md) for more information. You'll use the Dapr .NET SDK to invoke the service invocation API on the Dapr sidecar.

1. In Visual Studio, open the Package Manager Console (**Tools > NuGet Package Manager > Package Manager Console**) and make sure that `DaprFrontEnd` is the default project. From the console, add the `Dapr.AspNetCore` NuGet package to the project:

   ```
   Install-Package Dapr.AspNetCore -Prerelease
   ```

   > You need to specify the `-Prerelease` flag while the `Dapr.AspNetCore` package is still in prerelease.

1. In the `DaprFrontEnd` project, open the *Startup.cs* file, and replace the `ConfigureServices` method with the following code:

   ```c#
   // This method gets called by the runtime. Use this method to add services to the container.
   public void ConfigureServices(IServiceCollection services)
   {
     services.AddControllers().AddDapr();
     services.AddRazorPages();
   }
   ```

   The call to `AddDapr` registers the `DaprClient` class with the ASP.NET Core dependency injection system. You'll use the `DaprClient` class later on to communicate with the Dapr sidecar.

2. Add a new C# class file named *WeatherForecast* to the `DaprFrontEnd` project. Replace the content of the file with the following code:

   ```c#
   using System;
      
      namespace DaprFrontEnd
      {
          public class WeatherForecast
          {
              public DateTime Date { get; set; }
      
              public int TemperatureC { get; set; }
      
              public int TemperatureF { get; set; }
      
              public string Summary { get; set; }
          }
      }
   ```

3. Open the *Index.cshtml.cs* file in the *Pages* folder, and replace its contents with the following code:

   ```c#
   using System.Collections.Generic;
   using System.Net.Http;
   using System.Threading.Tasks;
   using Dapr.Client;
   using Microsoft.AspNetCore.Mvc.RazorPages;
   
   namespace DaprFrontEnd.Pages
   {
       public class IndexModel : PageModel
       {
           private readonly DaprClient _client;
   
           public IndexModel(DaprClient client)
           {
               _client = client;
           }
   
           public async Task OnGet()
           {
               var forecasts = await _client.InvokeMethodAsync<IEnumerable<WeatherForecast>>(
                   "daprbackend",
                   "weatherforecast",
                   new HttpInvocationOptions
                   {
                       Method = HttpMethod.Get
                   });
   
               ViewData["WeatherForecastData"] = forecasts;
           }
       }
   }
   ```

   Note that the `DaprClient` is injected into the `IndexModel` constructor. The `OnGet` method gets called when the user visits the home page. Here we use the injected `DaprClient` instance to invoke the `weatherforecast` method of the `daprbackend` service. You'll configure the back-end web API to use `daprbackend` as its application id later on when configuring it to run with Dapr. Finally, the service response is saved in view data.

4. Replace the contents of the *Index.cshtml* file in the *Pages* folder, with the following code. It displays the weather forecasts stored in the view data to the user:

   ```html
   @page
   @model IndexModel
   @{
       ViewData["Title"] = "Home page";
   }
   
   <div class="text-center">
       <h1 class="display-4">Welcome</h1>
       <p>Learn about <a href="https://docs.microsoft.com/aspnet/core">building Web apps with ASP.NET Core</a>.</p>
       @foreach (var forecast in (IEnumerable<WeatherForecast>)ViewData["WeatherForecastData"])
       {
           <p>The forecast for @forecast.Date is @forecast.Summary!</p>
       }
   </div>
   ```

### Add container support

In the final part of this walkthrough, you'll add container support and run the solution using Docker Compose.

1. Right-click the `DaprFrontEnd` project, and choose **Add > Container Orchestrator Support**. The **Add Container Orchestrator Support** dialog appears:

   ![Screenshot of adding container orchestrator support](./media/ch4-getting-started/walkthrough-multicontainer-addorchestrator.png)

   Choose **Docker Compose**.

1. In the next dialog, select **Linux** as the Target OS:

   ![Screenshot of selecting Docker target OS](./media/ch4-getting-started/walkthrough-multicontainer-targetos.png)

   Visual Studio creates a *docker-compose.yml* file and a *.dockerignore* file in the **docker-compose** folder in the solution:

   ![Screenshot of the docker-compose project](./media/ch4-getting-started/walkthrough-multicontainer-dockersolution.png)

   The *docker-compose.yml* file contains the front-end service:

   ```yaml
   version: '3.4'
   
   services:
     daprfrontend:
       image: ${DOCKER_REGISTRY-}daprfrontend
       build:
         context: .
         dockerfile: DaprFrontEnd/Dockerfile
   
   ```

   The *.dockerignore* file contains file types and extensions that you don't want Docker to include in the container. These files are generally associated with the development environment and source control, not part of the app or service you're developing.

2. In the `DaprBackEnd` web API project, right-click on the project node, and choose **Add** > **Container Orchestrator Support**. Choose **Docker Compose**, and then select **Linux** again as the target OS.

   Open the *docker-compose.yml* file and examine its contents. Visual Studio has made some changes to your Compose file. Now both services are included.

   ```yaml
   version: '3.4'
   
   services:
     daprfrontend:
       image: ${DOCKER_REGISTRY-}daprfrontend
       build:
         context: .
         dockerfile: DaprFrontEnd/Dockerfile
   
     daprbackend:
       image: ${DOCKER_REGISTRY-}daprbackend
       build:
         context: .
         dockerfile: DaprBackEnd/Dockerfile
   ```

3. To use the Dapr building blocks from your application, you'll need to add the Dapr sidecars to your Compose file. Replace the content of the *docker-compose.yml* file with the following:

   ```yaml
   version: '3.4'
   
   services:
     daprfrontend:
       image: ${DOCKER_REGISTRY-}daprfrontend
       build:
         context: .
         dockerfile: DaprFrontEnd/Dockerfile
       ports:
         - "51000:50001" 
   
     daprfrontend-dapr:
       image: "daprio/daprd:latest"
       command: [ "./daprd", "-app-id", "daprfrontend", "-app-port", "80" ]
       depends_on:
         - daprfrontend
       network_mode: "service:daprfrontend"
   
     daprbackend:
       image: ${DOCKER_REGISTRY-}daprbackend
       build:
         context: .
         dockerfile: DaprBackEnd/Dockerfile
       ports:
         - "52000:50001"
   
     daprbackend-dapr:
       image: "daprio/daprd:latest"
       command: [ "./daprd", "-app-id", "daprbackend", "-app-port", "80" ]
       depends_on:
         - daprfrontend
       network_mode: "service:daprbackend" 
   ```

   In the updated file, we've added `daprfrontend-dapr` and `daprbackend-dapr` sidecars for the `daprfrontend` and `daprbackend` services respectively. Note the following about the changes:

   - The sidecars use the `daprio/daprd:latest` container image. The use of the `latest` tag is not recommended for production scenarios. For production, it's better to use a specific version number.
   - Each service defined in the Compose file has its own network namespace for network isolation purposes. The sidecars use `network_mode: "service:..."` to ensure they run in the same network namespace as the application. This allows the sidecar and the application to communicate using `localhost`.
   - The ports that the Dapr sidecars are listening on for gRPC communication (by default 50001), must be exposed to allow the sidecars to communicate with each other.

4. Run the solution (**F5** or **Ctrl+F5**) to verify that it works as expected. If everything is configured correctly, you should see the weather forecast data:

   ![Screenshot of the final solution showing the weather forecast data](./media/ch4-getting-started/walkthrough-multicontainer-result.png)

   Note that when debugging, you can set breakpoints in both the front- and back-end. This makes it very easy to debug calls across services. For production scenarios, it's recommended to host your application on Kubernetes. The [eShopOnDapr sample application](...) contains scripts to deploy to Kubernetes.

   To learn more about the Dapr Service Invocation building block used in this walkthrough, refer to [chapter 6](./ch6-service-invocation.md).

## Summary

In this chapter we've guided you through two walkthroughs to build your own .NET applications with Dapr. The first walkthrough explained how to create a simple, stateful, .NET Console application that leverages the Dapr State Management building block.

The second walkthrough showed how you can use Visual Studio and Docker Compose to get a very nice F5 debugging experience for multi-container solutions. In both walkthroughs, we've used the Dapr .NET SDK which gives an intuitive and language-specific way to interact with Dapr.

We've also looked more closely at the component configuration files. Use configuration files to configure the actual infrastructure implementation used by the Dapr building blocks. You can use namespaces and scopes to limit component access to particular Dapr sidecars.

In the next couple of chapters, we'll dive deeper into the building blocks offered by Dapr. We'll also show you how we've used them in eShopOnDapr.

### References

- [Dapr Documentation - Getting started](https://docs.dapr.io/getting-started/)

- [eShopOnDapr](https://github.com/dotnet-architecture/eShopOnDapr)

<!-- >[!div class="step-by-step"]
>[Previous](index.md)
>[Next](index.md) -->
