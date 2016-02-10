# Installing .NET Core on OS X

By [Zlatko Knezevic](https://github.com/blackdwarf)

This document will lead you through acquiring the .NET Core and its associated CLI toolchainand running a “Hello World” demo on OS X. The packages are set to work on OS X version 10.10. 

## Installing .NET Core 

The easiest way to get the tools and .NET Core on your OS X machine is to use the official [PKG installer](https://dotnetcli.blob.core.windows.net/dotnet/dev/Installers/Latest/dotnet-osx-x64.latest.pkg). When you install .NET Core, it will put all of the needed tools in your $PATH so you can use it immidiatelly.  

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

```console
cd bin/Debug/dnxcore50
./HelloDotNetCli

Hello World!
```

## Create a single native binary 

Finally, let's exercise a new feature that we've added to our .NET Command Line Interface: producing single native binaries. These binaries do not require a shared runtime to work; you can just copy the single file over to another Ubuntu machine and just run it. 

The process is pretty similar to the above, with the addition of one more switch.

```console
dotnet restore
dotnet build --native
```

After the compile command finishes, we can just run the resulting binary. By convention, the compile command drops the results in ./bin/[configuration]/[framework]/native/[binary name].exe. Running this binary will get us our greeting! 

> **Note**
> This capability is still in its infancy. Therefore, only the simplest of programs will be able to be natively compiled. 

