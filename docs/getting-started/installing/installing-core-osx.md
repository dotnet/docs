# Installing .NET Core on OS X

By [Zlatko Knezevic](https://github.com/blackdwarf)

This document will lead you through acquiring the .NET Core and its associated CLI toolchainand running a “Hello World” demo on OS X. The packages are set to work on OS X version 10.10. 

## Installing .NET Core 

The easiest way to get the tools and .NET Core on your OS X machine is to use the official [PKG installer](https://dotnetcli.blob.core.windows.net/dotnet/dev/Installers/Latest/dotnet-osx-x64.latest.pkg). When you install .NET Core, it will put all of the needed tools in your $PATH so you can use it immidiatelly.  

## Write your App

This being an introduction-level document, it seems fitting to start with a “Hello World” app. Here’s a very simple one you can copy and paste into a CS file in a directory.

```cs
using System;

public class Program
{
    public static void Main (string[] args)
    {
        Console.WriteLine("Hello, OS X");
        Console.WriteLine("Love from .NET Core.");
    }
}

```

The next thing you will need is a `project.json` file that will outline the dependencies of an app, so you can **actually** run it. Use the contents below, it will work for both examples above. Save this file in a directory next to the CS file that contains your code.

```json
 {
    "version": "1.0.0-*",
    "compilationOptions": {
        "emitEntryPoint": true
    },

    "dependencies": {
        "System.Console": "4.0.0-beta-23428",
        "System.Runtime": "4.0.21-beta-23428",
        "Microsoft.NETCore.Runtime": "1.0.1-beta-23428",
        "Microsoft.NETCore.ConsoleHost": "1.0.0-beta-23419",
        "Microsoft.NETCore.TestHost": "1.0.0-beta-23419"
    },

    "frameworks": {
        "dnxcore50": { }
    }
}

```


## Run your App

You need to restore packages for your app, based on your project.json, with `dotnet restore`.

```console
dotnet restore
dotnet run

Hello, OS X
Love from .NET Core.

```

## Compile your application

Running from source is great for rapid prototyping and trying out things. However, in due time you will want to actually compile your application to get increase in speed and similar benefits. In order to do that, we will use `dotnet compile` command that will produce a runnable executable for our Hello World app.

While you're still in the application's directory, type

    dotnet compile
    
This will produce a `bin` directory in your directory. The structure of the drop path is `./bin/[configuration]/[framework]/`. Configuration refers to either *Release* or *Debug*, while framework is essentially a framework ID (i.e. dnxcore50). Inside this directory there will be several files, the most important of which is the binary that will have the same name as your application. Running this will give us the message we saw in the previous example. 

**Note**: this binary requires a shared runtime to be installed on the machine. If you wish to create a self-contained application that includes the runtime and that you can just copy over to another machine, you will need to use `dotnet publish` command or compile your application 

## Building .NET Core runtime from source

.NET Core is an open source project that is hosted on GitHub. This means that you can, at any given time, clone the repository and build .NET Core from source. This is a more advanced scenario that is usually used when you want to add features to the .NET runtime or the BCL or if you are a contributor to these projects. The detailed instruction on how to build .NET Core windows can be found in the [Build .NET Core on Linux](https://github.com/dotnet/coreclr/blob/master/Documentation/building/osx-instructions.md) on GitHub.

## Building the .NET Command Line Interace from source

The toolchain we used in this short tutorial is also open source. It is hosted on [GitHub](https://github.com/dotnet/cli/). You can always clone the repo and build from source. The instructions can be found on the [README.md](https://github.com/dotnet/cli/blob/master/documentation/README.md) in the repo. 