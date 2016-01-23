# Installing .NET Core on Linux

By [Zlatko Knezevic](https://github.com/blackdwarf)

This document will lead you through acquiring the .NET Core and its associated CLI toolchain and running a “Hello World” demo on Linux.

## Setting up the environment

### Setting up the apt-get feed

We will use apt-get, the native Ubuntu package installer, to install the .NET Core SDK. In order to get the package, however, we will need to add a new package feed. The below commands will do this. 

```console
sudo sh -c 'echo "deb [arch=amd64] http://apt-mo.trafficmanager.net/repos/dotnet/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list' 
sudo apt-key adv --keyserver apt-mo.trafficmanager.net --recv-keys 417A0893
sudo apt-get update
``` 


## Installing the .NET Command Line Interface

Installing the actual CLI toolchain is as simple as running:

```console
sudo apt-get install dotnet
```

This will install the package and all of the dependencies. It will also add the toolchain to your $PATH, so they will be available the next time you drop down into the terminal.  

That’s it! You now have the .NET Core tools installed on your machine and it is time to take it for a spin.

## The proverbial Hello World

This being an introduction-level document, it seems fitting to start with a “Hello World” app. Luckily, the .NET CLI tools have a command that will help us with that. First, let's start with making a directory to contain our application:

```console
mkdir newapp
cd newapp
```

We will then use the `dotnet new` command to drop a sample Hello World application in the directory we just made:

```console
dotnet new
```

This will drop several things, most notably a `Program.cs` and `project.json` that are needed to run the application. 

## Run your App

You need to restore packages for your app, based on your project.json, with `dotnet restore` and then run the application using `dotnet run`. 

```console
dotnet restore
dotnet run

Hello World!
```

## Compile your application

Running from source is great for rapid prototyping and trying out things. However, in due time you will want to actually compile your application to get increase in speed and similar benefits. In order to do that, we will use `dotnet compile` command that will produce a runnable executable for our Hello World app.

While you're still in the application's directory, type

    dotnet build
    
This will produce a `bin` directory in your directory. The structure of the drop path is `./bin/[configuration]/[framework]/`. Configuration refers to either *Release* or *Debug*, while framework is essentially a framework ID (i.e. dnxcore50). Inside this directory there will be several files, the most important of which is the binary that will have the same name as your application. Running this will give us the message we saw in the previous example. 

## Create a single native binary 

Finally, let's exercise a new feature that we've added to our .NET Command Line Interface: producing single native binaries. These binaries do not require a shared runtime to work; you can just copy the single file over to another Ubuntu machine and just run it. 

The process is pretty similar to the above, with the addition of one more switch. 

```console
dotnet restore
dotnet build --native
```

After the compile command finishes, we can just run the resulting binary. By convention, the compile command drops the results in ./bin/[configuration]/[framework]/native/[binary name]. Running this binary will get us our greeting! 

> **Note**
> This capability is still in its infancy. Therefore, only the simplest of programs will be able to be natively compiled. 

