#Introduction

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

## Why Docker?

Docker makes it easy to create standard machine images to
host your services in a data center, or the public cloud. Docker
enables you to configure the image, and replicate it as needed to
scale the installation of your application.

All the code in this tutorial will work in any .NET Core environment.
The additional tasks for a Docker installation will work for an ASP.NET
Core application. 

# Prerequisites
You’ll need to setup your machine to run .NET core. See the 
[.NET Core Getting Started page](http://dotnet.github.io/getting-started/)
for instructions on installing .NET core on your machine.
You can run this application on Windows, Ubuntu Linux, OS X or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

You'll also need to install the Docker engine. See the 
[Docker Installation page](https://docs.docker.com/engine/installation/) 
for instructions.
Docker can be installed in many Linux distributions, Mac OS, or Windows. The page
referenced above contains links to each of the available installations.

You'll also need to install a number of command line tools that support
ASP.NET core development. The command line templates use Yeoman, Bower,
Grunt, and Gulp. You may already have many of these tools, but if not,
run the following command in your favorite shell:

`npm install -g yo bower grunt-cli gulp`

This instructs the node package manager (npm) to install the needed tools.
The '-g' option indicates that it is a global install, and those tools are
available system wide. (A local install scopes the package to a single
project). Once you've installed those core tools, you need to install
the yeoman asp.net template generators:

`npm install -g generator-aspnet`

# Create the Application

Now that you've installed all the tools, create a new asp.net core
application. To use the command line generator, execute the following
yeoman command in your favorite shell:

`yo aspnet`

This command prompts you to select what Type of application you want to
create. For this microservice, you want the simplest, most lightweight
web application possible, so select 'Empty Application'. The template
will prompt you for a name. Select 'WeatherMicroservice'. 

The template creates six files for you:

* A .gitignore, customized for asp.net core applications.
* A Startup.cs file. This contains the basis of the application.
* A project.json file. This is the build file for the application.
* A Dockerfile. This script creates a Docker image for the application.
* A wwwroot/readme.md. This contains links to other asp.net core resources.
* A wwwroot/web.config file. This contains basic configuration information.

Now you can run the template generated application. That's done using a series
of tools from the command line. The `dotnet` command runs the tools necessary
for .NET development. Each verb executes a different command

The first step is to restore all the dependencies:

`dotnet restore`

Dotnet restore uses the NuGet package manager to install all the necessary packages
into the application directory. It also generates a project.json.lock file. This
file contains information about each package that is referenced. After restoring
all the dependencies, you build the application:

`dotnet build`

And once you build the application, you run it from the command line:

`dotnet run`

The default configuration listens to http://localhost:5000. You can open a
browser and navigate to that page and see a "Hello World!" message.

## Anatomy of an ASP.NET Core application

Now that you've built the application, let's look at how this functionality
is implemented. There are two of the generated files that are particularly
interesting at this point: project.json and startup.cs. 

Project.json contains information about the project. The three nodes you'll
often work with are 'dependencies', 'commands' and 'frameworks'. The
dependencies node lists all the packages that are needed for this application.
At the moment, this is a small node, needing only the packages that run the
web server.

The 'commands' node lists the command that runs the web server. As a project
grows, you'll add commands here to run unit tests, or perform other tasks. The
web task starts the webserver.

The 'frameworks' node specifies the versions and configurations of the .NET
framework that will run this application.

The application is implemented in Startup.cs. This file contains the startup
class. Its `Main()` method starts the web server, and instructs the web
server that the web application class is this Startup class:

`public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);`

This method is a simple one-line method, so it utilizes the C# syntax for
*expression bodied members*. The body of the method, instead of being enclosed
in curly braces, is represented by the body of a lambda expression.

The other two methods are called by the asp.net core infrastructure to configure
and run the application. The `ConfigureServices` method describes the services that are
necessary for this application. You're building a lean microservice, so it doesn't
need to configure any dependencies. The `Configure` method configures the handlers
for incoming HTTP Requests. The template generates a simple handler that responds
to any request with the text 'Hello World!'.

# Build a microservice

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

## Parsing the Query String.

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

```cs
var latString = context.Request.Query["lat"].FirstOrDefault();
var longString = context.Request.Query["long"].FirstOrDefault();
```

The Query dictionary values are `StringValue` type. That type can
contain a collection of strings. For your weather service, each
value is a single string. That's why there's the call to `FirstOrDefault()`
in the code above. 

Next, you need to convert the strings to doubles. The method you'll use
to convert the string to a double is `double.TryParse()`:

```cs
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

```cs
public static class Extensions
{
    public static double? TryParse(this string input)
    {
        double result;
        if (double.TryParse(input, out result))
            return result;
        else
            return default(double?);
    }
}
```  

The `default(double?)` expression returns the default value for the
`double?` type. That default value is the null (or missing) value.

You can use this extension method to convert the query string arguments
into the double type:

```cs
var latitude = latString.TryParse();
var longitude = longString.TryParse();
```

To easily test the parsing code, update the response to include the values
of the arguments:

```cs
await context.Response.WriteAsync($"Retrieving Weather for lat: {latitude}, long: {longitude}");
```

At this point, you can run the web application and see if your parsing
code is working. Add values to the web request in a browser, and you should see
the updated results.

## Build a random weather forecast

Your next task is to build a random weather forecast. Let's start with a data
container that holds the values you'd want for a weather forecast:

```cs
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

Next, build a constructor that randomly sets those values:

```cs
public WeatherReport(double latitude, double longitude, int daysInFuture)
{
    var generator = new Random((int)(latitude + longitude) + daysInFuture);

    HiTemperature = generator.Next(40, 100);
    LoTemperature = generator.Next(0, HiTemperature);
    AverageWindSpeed = generator.Next(0, 45);
    Conditions = PossibleConditions[generator.Next(0, PossibleConditions.Length - 1)];
}
```

You can now generate the 5-day forecast in your response method:

```cs
if (latitude.HasValue && longitude.HasValue)
{
    var forecast = new List<WeatherReport>();
    for (var days = 1; days < 6; days++)
    {
        forecast.Add(new WeatherReport(latitude.Value, longitude.Value, days));
    }
}
``` 

## Build the JSON response.

The final code task on the server is to convert the WeatherReport array
into a JSON packet, and send that back to the client. Let's start by creating
the JSON packet. You'll add the NewtonSoft JSON Serializer to the
list of dependencies:

```
  "dependencies": {
    "Microsoft.AspNet.IISPlatformHandler": "1.0.0-rc1-final",
    "Microsoft.AspNet.Server.Kestrel": "1.0.0-rc1-final",
    "Newtonsoft.Json": "8.0.4-beta1"
  },
``` 

Then, you can use the `JsonConvert` class to write the object to a string:

```cs
var json = JsonConvert.SerializeObject(forecast, Formatting.Indented);
context.Response.ContentType = "application/json; charset=utf-8";
await context.Response.WriteAsync(json);
```

The code above converts the forecast object (a list of `WeatherForecast`
objects) into a JSON packet. After you've constructed the response packet,
you set the content type to 'application/json', and write the string.

The application now runs and returns random forecasts.

# Load into Docker

The Dockerfile created by the asp.net template will serve
for our purposes. Let's go over its contents.

The first line specifies the source image:

```
FROM microsoft/dotnet:onbuild
```

Docker allows you to configure a machine image based on a
source template. That means you don't have to supply all
the machine parameters when you start, you only need to
supply any changes. The changes here will be to include
our application.

In this first sample, we'll use the `onbuild` version of
the RC2 image. This is the easiest way to create a working Docker
environment. However, the image it creates is larger than necessary.
This image include the dotnet core runtime, and the dotnet SDK. 

The next two lines load SQLite onto the machine:

```
RUN printf "deb http://ftp.us.debian.org/debian jessie main\n" >> /etc/apt/sources.list
RUN apt-get -qq update && apt-get install -qqy sqlite3 libsqlite3-dev && rm -rf /var/lib/apt/lists/*
```

We're not using SQLite, but leave it in place for reference if you need it later.

The next three lines setup your application:

```
COPY . /app
WORKDIR /app
RUN ["dotnet", "restore"]
```

This will copy the contents of the current directory to the docker VM, and restore
all the packages.

The final lines of the file set the output port (80) and run the application:

```
EXPOSE 80
ENTRYPOINT ["dotnet", "run"]
```

Notice that this Dockerfile uses the dotnet cli to build and run your docker image.
That's why the larger image is needed.

Here are the steps to build the image and deploy it. The information below is 
for the PowerShell CLI. Different shells will have slightly different syntax
that will be highlighted below.

First, you have to create a new docker machine called 'weather-service':

```
docker-machine create --driver virtualbox weather-service
```

This command creates a new virtual machine in your Docker installation. You can see
the machine by typing the following command:

```
docker-machine ls
```

To connect to the machine, you need to retrieve its environment. That's done with
the env command in docker-machine:

```
docker-machine env --shell powershell weather-service
```

Substitute your shell of choice for 'powershell' in the command above. This command
echoes back a command to configure your shell to communicate with the docker container.
In PowerShell it is as follows:

```
 & "C:\Program Files\Docker Toolbox\docker-machine.exe" env --shell powershell weather-service | Invoke-Expression
```

If you are using a different shell, the output from the docker-machine command
above will show you what command to use in its place. Execute the command that was generated
for you. 

> Note: The `docker-machine` command will include the shell's comment character,
> `#` in the case of powershell in the output for the command to run. Make sure
> you remove this character when you execute the command.

Finally, build the docker image from your application:

```
docker build -t weather-service .
```

> Note: You may need to restart the Docker machine for the `docker build` command
> to work. You do that by executing the `docker restart` command:
> 
> `docker restart weather-service`

The build command builds the image using your source, and the configuration
settings in your
Dockerfile.

And finally run the application in the docker container:

```
docker run -t -d -p 80:5000 weather-service
```

You can see if the image is running by checking the command:

```
docker ps
```

If your container is running, you'll see a line that lists
it in the running processes. (It may be the only one).

To navigate to your service, find the IP address for the machine:

```
docker-machine ip weather-service
```

Open a browser on the docker host and navigate to that site, and you should see your 
weather service running. 

# Conclusion 

In this tutorial, you built an asp.net core microservice, and added a few
features.

You built a docker machine, created an image of your new application and
ran that application in the docker vm.
Along the way, you saw several features of the C# language in action.
