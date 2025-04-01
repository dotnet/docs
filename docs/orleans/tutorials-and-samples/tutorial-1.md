---
title: Minimal Orleans app sample project
description: Explore the minimal Orleans app sample project.
ms.date: 07/03/2024
---

# Tutorial: Create a minimal Orleans application

In this tutorial, you follow step-by-step instructions to create foundational moving parts common to most Orleans applications. It's designed to be self-contained and minimalistic.

This tutorial lacks appropriate error handling and other essential code that would be useful for a production environment. However, it should help you get a hands-on understanding of the common app structure for Orleans and allow you to focus your continued learning on the parts most relevant to you.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads)
- [.NET 7.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/7.0)

## Project setup

For this tutorial you're going to create four projects as part of the same solution:

- Library to contain the grain interfaces.
- Library to contain the grain classes.
- Console app to host the Silo.
- Console app to host the Client.

### Create the structure in Visual Studio

Replace the default code with the code given for each project.

1. Start by creating a Console App project in a new solution. Call the project part silo and name the solution `OrleansHelloWorld`. For more information on creating a console app, see [Tutorial: Create a .NET console application using Visual Studio](../../core/tutorials/with-visual-studio.md).
1. Add another Console App project and name it `Client`.
1. Add a Class Library and name it `GrainInterfaces`. For information on creating a class library, see [Tutorial: Create a .NET class library using Visual Studio](../../core/tutorials/library-with-visual-studio.md).
1. Add another Class Library and name it `Grains`.

#### Delete default source files

1. Delete _Class1.cs_ from **Grains**.
1. Delete _Class1.cs_ from **GrainInterfaces**.

### Add references

1. **Grains** references **GrainInterfaces**.
1. **Silo** references **Grains**.
1. **Client** references **GrainInterfaces**.

## Add Orleans NuGet packages

| Project | NuGet package |
|---|---|
| Silo | `Microsoft.Orleans.Server`<br>`Microsoft.Extensions.Logging.Console`<br>`Microsoft.Extensions.Hosting` |
| Client | `Microsoft.Orleans.Client`<br>`Microsoft.Extensions.Logging.Console`<br>`Microsoft.Extensions.Hosting` |
| Grain Interfaces | `Microsoft.Orleans.Sdk` |
| Grains | `Microsoft.Orleans.Sdk`<br>`Microsoft.Extensions.Logging.Abstractions` |

`Microsoft.Orleans.Server`, `Microsoft.Orleans.Client` and `Microsoft.Orleans.Sdk` are metapackages that bring dependencies that you'll most likely need on the Silo and client. For more information on adding package references, see [dotnet add package](../../core/tools/dotnet-add-package.md) or [Install and manage packages in Visual Studio using the NuGet Package Manager](/nuget/consume-packages/install-use-packages-visual-studio).

## Define a grain interface

In the **GrainInterfaces** project, add an _IHello.cs_ code file and define the following `IHello` interface in it:

:::code source="snippets/minimal/GrainInterfaces/IHello.cs":::

## Define a grain class

In the **Grains** project, add a _HelloGrain.cs_ code file and define the following class in it:

:::code source="snippets/minimal/Grains/HelloGrain.cs":::

### Create the Silo

To create the Silo project, add code to initialize a server that hosts and runs the grains&mdash;a silo. You use the localhost clustering provider, which allows you to run everything locally, without a dependency on external storage systems. For more information, see [Local Development Configuration](../host/configuration-guide/local-development-configuration.md). In this example, you run a cluster with a single silo in it.

Add the following code to _Program.cs_ of the **Silo** project:

:::code source="snippets/minimal/Silo/Program.cs":::

The preceding code:

- Configures the <xref:Microsoft.Extensions.Hosting.IHost> to use Orleans with the <xref:Microsoft.Extensions.Hosting.GenericHostExtensions.UseOrleans%2A> method.
- Specifies that the localhost clustering provider should be used with the <xref:Orleans.Hosting.CoreHostingExtensions.UseLocalhostClustering(Orleans.Hosting.ISiloBuilder,System.Int32,System.Int32,System.Net.IPEndPoint,System.String,System.String)> method.
- Runs the `host` and waits for the process to terminate, by listening for <kbd>Ctrl</kbd>+<kbd>C</kbd> or `SIGTERM`.

### Create the client

Finally, you need to configure a client for communicating with the grains, connect it to the cluster (with a single silo in it), and invoke the grain. The clustering configuration must match the one you used for the silo. For more information, see [Clusters and Clients](../host/client.md)

:::code source="snippets/minimal/Client/Program.cs":::

## Run the application

Build the solution and run the **Silo**. After you get the confirmation message that the **Silo** is running, run the **Client**.

To start the Silo from the command line, run the following command from the directory containing the Silo's project file:

```dotnetcli
dotnet run
```

You'll see numerous outputs as part of the startup of the Silo. After seeing the following message you're ready to run the client:

```Output
Application started. Press Ctrl+C to shut down.
```

From the client project directory, run the same .NET CLI command in a separate terminal window to start the client:

```dotnetcli
dotnet run
```

For more information on running .NET apps, see [dotnet run](../../core/tools/dotnet-run.md). If you're using Visual Studio, you can [configure multiple startup projects](/visualstudio/ide/how-to-set-multiple-startup-projects).

## See also

- [List of Orleans packages](../resources/nuget-packages.md)
- [Orleans configuration guide](../host/configuration-guide/index.md)
- [Orleans best practices](https://www.microsoft.com/research/publication/orleans-best-practices)
