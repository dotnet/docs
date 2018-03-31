---
title: Microservices hosted in Docker - C#
description: Learn to create asp.net core services that run in Docker containers
keywords: .NET, .NET Core, Docker, C#, ASP.NET, Microservice
author: BillWagner
ms.author: wiwagn
ms.date: 02/03/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-docker
ms.devlang: csharp
ms.assetid: 87e93838-a363-4813-b859-7356023d98ed
---

# Microservices hosted in Docker

This tutorial details the tasks necessary to build and deploy
an ASP.NET Core microservice in a Docker container. During the course
of this tutorial, you'll learn:

* How to generate an ASP.NET Core application using Yeoman
* How to create a development Docker environment
* How to build a Docker image based on an existing image.
* How to deploy your service into a Docker container.

Along the way, you'll also see some C# language features:

* How to convert C# objects into JSON payloads.
* How to build immutable Data Transfer Objects
* How to process incoming HTTP Requests and generate the HTTP Response
* How to work with nullable value types

You can [view or download the sample app](https://github.com/dotnet/samples/tree/master/csharp/getting-started/WeatherMicroservice) for this topic. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

### Why Docker?

Docker makes it easy to create standard machine images to
host your services in a data center, or the public cloud. Docker
enables you to configure the image, and replicate it as needed to
scale the installation of your application.

All the code in this tutorial will work in any .NET Core environment.
The additional tasks for a Docker installation will work for an ASP.NET
Core application. 

## Prerequisites
You’ll need to setup your machine to run .NET core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page.
You can run this application on Windows, Ubuntu Linux, macOS or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

You'll also need to install the Docker engine. See the 
[Docker Installation page](http://www.docker.com/products/docker) 
for instructions for your platform.
Docker can be installed in many Linux distributions, macOS, or Windows. The page
referenced above contains sections to each of the available installations.

Most components to be installed are done by a package manager. If you have node.js's package manager `npm` installed you can skip this step. 
Otherwise install the latest NodeJs from [nodejs.org](https://nodejs.org) which will install the npm package manager. 

At this point you will need to install a number of command line tools that support
ASP.NET core development. The command line templates use Yeoman, Bower,
Grunt, and Gulp. If you have them installed that is good, otherwise type the following into your favorite shell:

`npm install -g yo bower grunt-cli gulp`

The `-g` option indicates that it is a global install, and those tools are
available system wide. (A local install scopes the package to a single
project). Once you've installed those core tools, you need to install
the yeoman ASP.NET template generators:

`npm install -g generator-aspnet`

## Create the Application

Now that you've installed all the tools, create a new ASP.NET Core
application. To use the command line generator, execute the following
yeoman command in your favorite shell:

`yo aspnet`

This command prompts you to select what Type of application you want to
create. For this microservice, you want the simplest, most lightweight
web application possible, so select 'Empty Web Application'. The template
will prompt you for a name. Select 'WeatherMicroservice'. 

The template creates eight files for you:

* A .gitignore, customized for ASP.NET Core applications.
* A Startup.cs file. This contains the basis of the application.
* A Program.cs file. This contains the entry point of the application.
* A WeatherMicroservice.csproj file. This is the build file for the application.
* A Dockerfile. This script creates a Docker image for the application.
* A README.md. This contains links to other ASP.NET Core resources.
* A web.config file. This contains basic configuration information.
* A runtimeconfig.template.json file. This contains debugging settings used by IDEs.

Now you can run the template generated application. That's done using a series
of tools from the command line. The `dotnet` command runs the tools necessary
for .NET development. Each verb executes a different command

The first step is to restore all the dependencies:

```console
dotnet restore
```

Dotnet restore uses the NuGet package manager to install all the necessary packages
into the application directory. It also generates a project.json.lock file. This
file contains information about each package that is referenced. After restoring
all the dependencies, you build the application:

```console
dotnet build
```
[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

And once you build the application, you run it from the command line:

```console
dotnet run
```

The default configuration listens to `http://localhost:5000`. You can open a
browser and navigate to that page and see a "Hello World!" message.

### Anatomy of an ASP.NET Core application

Now that you've built the application, let's look at how this functionality
is implemented. There are two of the generated files that are particularly
interesting at this point: project.json and Startup.cs. 

Project.json contains information about the project. The two nodes you'll
often work with are 'dependencies' and 'frameworks'. The
dependencies node lists all the packages that are needed for this application.
At the moment, this is a small node, needing only the packages that run the
web server.

The 'frameworks' node specifies the versions and configurations of the .NET
framework that will run this application.

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

### Parsing the Query String.

You'll begin by parsing the query string. The service will accept 
'lat' and 'long' arguments on the query string in this form:

`http://localhost:5000/?lat=-35.55&long=-12.35`  

All the changes you need to make are in the lambda expression
defined as the argument to `app.Run` in your startup class.

The argument on the lambda expression is the `HttpContext` for the
request. One of its properties is the `Request` object. The `Request`
object has a `Query` property that contains a dictionary of all the
values on the query string for the request. The first addition is to
find the latitude and longitude values:

[!code-csharp[ReadQueryString](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#ReadQueryString "read variables from the query string")]

The Query dictionary values are `StringValue` type. That type can
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

The `default(double?)` expression returns the default value for the
`double?` type. That default value is the null (or missing) value.

You can use this extension method to convert the query string arguments
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
    private static readonly string[] PossibleConditions = new string[]
    {
        "Sunny",
        "Mostly Sunny",
        "Partly Sunny",
        "Partly Cloudy",
        "Mostly Cloudy",
        "Rain"
    };

    public int HiTemperature { get; }
    public int LoTemperature { get; }
    public int AverageWindSpeed { get; }
    public string Conditions { get; }
}
```

Next, build a constructor that randomly sets those values. This constructor uses
the values for the latitude and longitude to seed the Random number generator. That
means the forecast for the same location is the same. If you change the arguments for
the latitude and longitude, you'll get a different forecast (because you start with a 
different seed.)

[!code-csharp[WeatherReportConstructor](../../../samples/csharp/getting-started/WeatherMicroservice/WeatherReport.cs#WeatherReportConstructor "Weather Report Constructor")]

You can now generate the 5-day forecast in your response method:

[!code-csharp[GenerateRandomReport](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#GenerateRandomReport "Generate a random weather report")]

### Build the JSON response.

The final code task on the server is to convert the WeatherReport array
into a JSON packet, and send that back to the client. Let's start by creating
the JSON packet. You'll add the NewtonSoft JSON Serializer to the
list of dependencies. You can do that using the `dotnet` CLI:

```
dotnet add package Newtonsoft.Json
```

Then, you can use the `JsonConvert` class to write the object to a string:

[!code-csharp[ConvertToJson](../../../samples/csharp/getting-started/WeatherMicroservice/Startup.cs#ConvertToJSON "Convert objects to JSON")]

The code above converts the forecast object (a list of `WeatherForecast`
objects) into a JSON packet. After you've constructed the response packet,
you set the content type to `application/json`, and write the string.

The application now runs and returns random forecasts.

## Build a Docker image

Our final task is to run the application in Docker. We'll create a
Docker container that runs a Docker image that represents our application.

A ***Docker Image*** is a file that defines the environment for running the application.

A ***Docker Container*** represents a running instance of a Docker image.

By analogy, you can think of the *Docker Image* as a *class*, and the
*Docker Container* as an object, or an instance of that class.  

The Dockerfile created by the ASP.NET template will serve
for our purposes. Let's go over its contents.

The first line specifies the source image:

```
FROM microsoft/dotnet:1.1-sdk-msbuild
```

Docker allows you to configure a machine image based on a
source template. That means you don't have to supply all
the machine parameters when you start, you only need to
supply any changes. The changes here will be to include
our application.

In this first sample, we'll use the `1.1-sdk-msbuild` version of
the dotnet image. This is the easiest way to create a working Docker
environment. This image include the dotnet core runtime, and the dotnet SDK. 
That makes it easier to get started and build, but does create a larger image.

The next five lines setup and build your application:

```
WORKDIR /app

# copy csproj and restore as distinct layers

COPY WeatherMicroservice.csproj .
RUN dotnet restore 

# copy and build everything else

COPY . .

# RUN dotnet restore
RUN dotnet publish -c Release -o out
```

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

This will copy the project file from the  current directory to the Docker VM, and restore
all the packages. Using the dotnet CLI means that the Docker image must include the
.NET Core SDK. After that, the rest of your application gets copied, and the dotnet
publish command builds and packages your application.

The final line of the file runs the application:

```
ENTRYPOINT ["dotnet", "out/WeatherMicroservice.dll", "--server.urls", "http://0.0.0.0:5000"]
```

This configured port is referenced in the `--server.urls`
argument to `dotnet` on the last  line of the Dockerfile. The `ENTRYPOINT` command
informs Docker what command and command-line options start the service. 

## Building and running the image in a container.

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
docker run -d -p 80:5000 --name hello-docker weather-microservice
```

The `-d` option means to run the container detached from the current terminal. That means you
won't see the command output in your terminal. The `-p` option indicates the port mapping between
the service and the host. Here it says that any incoming request on port 80 should be forwarded
to port 5000 on the container. Using 5000 matches the port your service is listening on from
the command line arguments specified in the Dockerfile above. The `--name` argument
names your running container. It's a convenient name you can use to work with that
container. 

You can see if the image is running by checking the command:

```console
docker ps
```

If your container is running, you'll see a line that lists
it in the running processes. (It may be the only one).

You can test your service by opening a browser and navigating to localhost, and
specifying a latitude and longitude:

```
http://localhost/?lat=35.5&long=40.75
```

## Attaching to a running container

When you ran your sevice in a command window, you could see diagnostic information printed
for each request. You don't see that information when your container is running in detached
mode. The Docker attach command enables you to attach to a running container so that you
can see the log information.  Run this command from a command window:

```console
docker attach --sig-proxy=false hello-docker
```

The `--sig-proxy=false` argument means that `Ctrl-C` commands do not get sent to the
container process, but rather stop the `docker attach` command. The final argument
is the name given to the container in the `docker run` command. 

> [!NOTE]
> You can also use the Docker assigned container ID to refer to any container. If you
> didn't specify a name for your container in `docker run` you must use the container id.

Open a browser and navigate to your service. You'll see the diagnostic messages in
the command windows from the attached running container.

Press `Ctrl-C` to stop the attach process.

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
