---
title: Microservices hosted in Docker - C#
description: Learn to create asp.net core services that run in Docker containers
ms.date: 06/08/2017
ms.assetid: 87e93838-a363-4813-b859-7356023d98ed
---

# Microservices hosted in Docker

This tutorial details the tasks necessary to build and deploy
an ASP.NET Core microservice in a Docker container. During the course
of this tutorial, you'll learn:

* How to generate an ASP.NET Core application.
* How to create a development Docker environment.
* How to build a Docker image based on an existing image.
* How to deploy your service into a Docker container.

Along the way, you'll also see some C# language features:

* How to convert C# objects into JSON payloads.
* How to build immutable Data Transfer Objects.
* How to process incoming HTTP Requests and generate the HTTP Response.
* How to work with nullable value types.

You can [view or download the sample app](https://github.com/dotnet/samples/tree/master/csharp/getting-started/WeatherMicroservice) for this topic. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Why Docker?

Docker makes it easy to create standard machine images to
host your services in a data center, or the public cloud. Docker
enables you to configure the image, and replicate it as needed to
scale the installation of your application.

All the code in this tutorial will work in any .NET Core environment.
The additional tasks for a Docker installation will work for an ASP.NET
Core application. 

## Prerequisites

You’ll need to setup your machine to run .NET Core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page.
You can run this application on Windows, Linux, macOS or in a Docker container.
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

You'll also need to install the Docker engine. See the 
[Docker Installation page](https://docs.docker.com/install/overview/) 
for instructions for your platform.
Docker can be installed in many Linux distributions, macOS, or Windows. The page
referenced above contains sections to each of the available installations.

## Create the Application

Now that you've installed all the tools, create a new ASP.NET Core
application in a directory called "WeatherMicroservice" by executing
the following command in your favorite shell:

```console
dotnet new web -o WeatherMicroservice
```

The `dotnet` command runs the tools necessary
for .NET development. Each verb executes a different command.

The `dotnet new` command is used to create .Net Core projects.

The `-o WeatherMicroservice` option after the `dotnet new` command
is used to give the location to create the ASP.NET Core application.

For this microservice, we want the simplest, most lightweight
web application possible, so we used the "ASP.NET Core Empty" template,
by specifying its short name, `web`.

The template creates four files for you:

* A Startup.cs file. This contains the basis of the application.
* A Program.cs file. This contains the entry point of the application.
* A WeatherMicroservice.csproj file. This is the build file for the application.
* A Properties/launchSettings.json file. This contains debugging settings used by IDEs.

Now you can run the template generated application:

```console
dotnet run
```

This command will first restore dependencies required to build the application
and then it will build the application.

The default configuration listens to `http://localhost:5000`. You can open a
browser and navigate to that page and see a "Hello World!" message.

When you're done, you can shut down the application by pressing <kbd>Ctrl</kbd>+<kbd>C</kbd>.

### Anatomy of an ASP.NET Core application

Now that you've built the application, let's look at how this functionality
is implemented. There are two of the generated files that are particularly
interesting at this point: WeatherMicroservice.csproj and Startup.cs. 

The .csproj file contains information about the project.
The two nodes that are most interesting are `<TargetFramework>` and `<PackageReference>`.

The `<TargetFramework>` node specifies the version of .NET that will run this application.

Each `<PackageReference>` node is used to specify a package that is needed for this application.

The application is implemented in Startup.cs. This file contains the startup
class.

The two methods are called by the ASP.NET Core infrastructure to configure
and run the application. The `ConfigureServices` method describes the services that are
necessary for this application. You're building a lean microservice, so it doesn't
need to configure any dependencies. The `Configure` method configures the handlers
for incoming HTTP Requests. The template generates a simple handler that responds
to any request with the text 'Hello World!'.

## Build a microservice

The service you're going to build will deliver weather reports from anywhere
around the globe. In a production application, you'd call some service
to retrieve weather data. For our sample, we'll generate a random weather
forecast. 

There are a number of tasks you'll need to perform in order to implement
our random weather service:

* Parse the incoming request to read the latitude and longitude.
* Generate some random forecast data.
* Convert that random forecast data from C# objects into JSON packets.
* Set the response header to indicate that your service sends back JSON.
* Write the response.

The next sections walk you through each of these steps.

### Parsing the Query String

You'll begin by parsing the query string. The service will accept 
'lat' and 'long' arguments on the query string in this form:

```
http://localhost:5000/?lat=-35.55&long=-12.35
```

All the changes you need to make are in the lambda expression
defined as the argument to `app.Run` in your startup class.

The argument on the lambda expression is the `HttpContext` for the
request. One of its properties is the `Request` object. The `Request`
object has a `Query` property that contains a dictionary of all the
values on the query string for the request. The first addition is to
find the latitude and longitude values:

[!code-csharp[ReadQueryString](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#ReadQueryString "read variables from the query string")]

The `Query` dictionary values are `StringValue` type. That type can
contain a collection of strings. For your weather service, each
value is a single string. That's why there's the call to `FirstOrDefault()`
in the code above. 

Next, you need to convert the strings to doubles. The method you'll use
to convert the string to a double is `double.TryParse()`:

```csharp
bool TryParse(string s, out double result);
```

This method leverages C# out parameters to indicate if the input string
can be converted to a double. If the string does represent a valid
representation for a double, the method returns true, and the `result`
argument contains the value. If the string does not represent a valid
double, the method returns false.

You can adapt that API with the use of an *extension method* that returns
a *nullable double*. A *nullable value type* is a type that represents
some value type, and can also hold a missing, or null value. A nullable
type is represented by appending the `?` character to the type declaration. 

Extension methods are methods that are defined as static methods, but
by adding the `this` modifier on the first parameter, can be called as
though they are members of that class. Extension methods may only be
defined in static classes. Here's the definition of the class containing
the extension method for parse:

[!code-csharp[TryParseExtension](../../../samples/csharp/getting-started/WeatherMicroservice/Extensions.cs#TryParseExtension "try parse to a nullable")]

Before calling the extension method, change the current culture to invariant:

[!code-csharp[SetCulture](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#SetCulture "set current culture to invariant")]

This ensures that your application parses numbers the same on any server, regardless of its default culture.

Now you can use the extension method to convert the query string arguments
into the double type:

[!code-csharp[UseTryParse](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#UseTryParse "Use the try parse extension method")]

To easily test the parsing code, update the response to include the values
of the arguments:

[!code-csharp[WriteResponse](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#WriteResponse "Write the output response")]

At this point, you can run the web application and see if your parsing
code is working. Add values to the web request in a browser, and you should see
the updated results.

### Build a random weather forecast

Your next task is to build a random weather forecast. Let's start with a data
container that holds the values you'd want for a weather forecast:

```csharp
public class WeatherReport
{
    private static readonly string[] PossibleConditions =
    {
        "Sunny",
        "Mostly Sunny",
        "Partly Sunny",
        "Partly Cloudy",
        "Mostly Cloudy",
        "Rain"
    };

    public int HighTemperatureFahrenheit { get; }
    public int LowTemperatureFahrenheit { get; }
    public int AverageWindSpeedMph { get; }
    public string Condition { get; }
}
```

Next, build a constructor that randomly sets those values. This constructor uses
the values for the latitude and longitude to seed the `Random` number generator. That
means the forecast for the same location is the same. If you change the arguments for
the latitude and longitude, you'll get a different forecast (because you start with a 
different seed).

[!code-csharp[WeatherReportConstructor](../../../samples/csharp/getting-started/WeatherMicroservice/WeatherReport.cs#WeatherReportConstructor "Weather Report Constructor")]

You can now generate the 5-day forecast in your response method:

```csharp
if (latitude.HasValue && longitude.HasValue)
{
    var forecast = new List<WeatherReport>();
    for (var days = 1; days <= 5; days++)
    {
        forecast.Add(new WeatherReport(latitude.Value, longitude.Value, days));
    }
}
```

### Build the JSON response

The final code task on the server is to convert the `WeatherReport` list
into JSON document, and send that back to the client. Let's start by creating
the JSON document. You'll add the Newtonsoft JSON serializer to the
list of dependencies. You can do that using the following `dotnet` command:

```console
dotnet add package Newtonsoft.Json
```

Then, you can use the `JsonConvert` class to write the object to a string:

[!code-csharp[ConvertToJson](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#ConvertToJSON "Convert objects to JSON")]

The code above converts the forecast object (a list of `WeatherForecast`
objects) into a JSON document. After you've constructed the response document,
you set the content type to `application/json`, and write the string.

The application now runs and returns random forecasts.

## Build a Docker image

Our final task is to run the application in Docker. We'll create a
Docker container that runs a Docker image that represents our application.

A ***Docker Image*** is a file that defines the environment for running the application.

A ***Docker Container*** represents a running instance of a Docker Image.

By analogy, you can think of the *Docker Image* as a *class*, and the
*Docker Container* as an object, or an instance of that class.  

The following Dockerfile will serve for our purposes:

```
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WeatherMicroservice.dll"]
```

Let's go over its contents.

The first line specifies the source image used for building the application:

```
FROM microsoft/dotnet:2.1-sdk AS build
```

Docker allows you to configure a machine image based on a
source template. That means you don't have to supply all
the machine parameters when you start, you only need to
supply any changes. The changes here will be to include
our application.

In this sample, we'll use the `2.1-sdk` version of
the `dotnet` image. This is the easiest way to create a working Docker
environment. This image includes the .NET Core runtime, and the .NET Core SDK.
That makes it easier to get started and build, but does create a larger image,
so we'll use this image for building the application and a different image to run it.

The next lines setup and build your application:

```
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
```

This will copy the project file from the  current directory to the Docker VM, and restore
all the packages. Using the dotnet CLI means that the Docker image must include the
.NET Core SDK. After that, the rest of your application gets copied, and the `dotnet
publish` command builds and packages your application.

Finally, we create a second Docker image that runs the application:

```
# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "WeatherMicroservice.dll"]
```

This image uses the `2.1-aspnetcore-runtime` version of the `dotnet` image,
which contains everything necessary to run ASP.NET Core applications,
but does not include the .NET Core SDK. This means this image can't be used to build
.NET Core applications, but it also makes the final image smaller.

To make this work, we copy the built application from the first image to the second one.

The `ENTRYPOINT` command informs Docker what command starts the service.

## Building and running the image in a container

Let's build an image and run the service inside a Docker container. You don't want
all the files from your local directory copied into the image. Instead, you'll
build the application in the container. You'll create a `.dockerignore` file
to specify the directories that are not copied into the image. You don't want
any of the build assets copied. Specify the build and publish directories
in the `.dockerignore` file:

```
bin/*
obj/*
out/*
```

You build the image
using the `docker build` command. Run the following command from the directory containing your code.

```console
docker build -t weather-microservice .
```

This command builds the container image based on all the information in your Dockerfile. The `-t`
argument provides a tag, or name, for this container image. In the command line above, the
tag used for the Docker container is `weather-microservice`. When this command completes,
you have a container ready to run your new service. 

Run the following command to start
the container and launch your service:

```console
docker run -d -p 80:80 --name hello-docker weather-microservice
```

The `-d` option means to run the container detached from the current terminal. That means you
won't see the command output in your terminal. The `-p` option indicates the port mapping between
the service and the host. Here it says that any incoming request on port 80 should be forwarded
to port 80 on the container. Using 80 matches the port your service is listening on,
which is the default port for production applications. The `--name` argument
names your running container. It's a convenient name you can use to work with that
container.

You can see if the image is running by checking the command:

```console
docker ps
```

If your container is running, you'll see a line that lists
it in the running processes. (It may be the only one.)

You can test your service by opening a browser and navigating to localhost, and
specifying a latitude and longitude:

```
http://localhost/?lat=35.5&long=40.75
```

## Attaching to a running container

When you ran your service in a command window, you could see diagnostic information printed
for each request. You don't see that information when your container is running in detached
mode. The Docker attach command enables you to attach to a running container so that you
can see the log information.  Run this command from a command window:

```console
docker attach --sig-proxy=false hello-docker
```

The `--sig-proxy=false` argument means that <kbd>Ctrl</kbd>+<kbd>C</kbd> commands do not get sent to the
container process, but rather stop the `docker attach` command. The final argument
is the name given to the container in the `docker run` command. 

> [!NOTE]
> You can also use the Docker assigned container ID to refer to any container. If you
> didn't specify a name for your container in `docker run` you must use the container ID.

Open a browser and navigate to your service. You'll see the diagnostic messages in
the command windows from the attached running container.

Press <kbd>Ctrl</kbd>+<kbd>C</kbd> to stop the attach process.

When you are done working with your container, you can stop it:

```console
docker stop hello-docker
```

The container and image is still available for you to restart.  If you want to remove
the container from your machine, you use this command:

```console
docker rm hello-docker
```

If you want to remove unused images from your machine, you use this command:

```console
docker rmi weather-microservice
```

## Conclusion 

In this tutorial, you built an ASP.NET Core microservice, and added a few
simple features.

You built a Docker container image for that service, and ran that container on
your machine. You attached a terminal window to the service, and saw the
diagnostic messages from your service.

Along the way, you saw several features of the C# language in action.
