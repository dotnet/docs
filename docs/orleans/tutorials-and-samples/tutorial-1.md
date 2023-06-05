---
title: Minimal Orleans app sample project
description: Explore the minimal Orleans app sample project.
ms.date: 06/05/2023
---

# Tutorial: Create a minimal Orleans application

In this tutorial, you follow step-by-step instructions to create a basic functioning Orleans application. It's designed to be self-contained and minimalistic.

Keep in mind this is a tutorial and lacks appropriate error handling and other essential code that would be useful for a production environment. However, it should help readers get a hands-on understanding of the common app structure for Orleans and allow them to focus their continued learning on the parts most relevant to them.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/download) with the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) installed.
- [.NET 7.0 SDK or later](https://dotnet.microsoft.com/download/dotnet/7.0)

## Project setup

For this tutorial you're going to create four projects in the same solution:

- Library to contain the grain interfaces.
- Library to contain the grain classes.
- Console app to host the Silo.
- Console app to host the Client.

### Create the structure in Visual Studio

You replace the default code with the code given for each project, below. You'll also probably need to add `using` statements.

1. Start by creating a Console App project in a new solution. Call the project part `Silo` and name the solution `OrleansHelloWorld`.
2. Add another Console App project and name it `Client`.
3. Add a Class Library and name it `GrainInterfaces`.
4. Add another Class Library and name it `Grains`.

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

`Microsoft.Orleans.Server`, `Microsoft.Orleans.Client` and `Microsoft.Orleans.Sdk` are meta-packages that bring dependency that you'll most likely need on the Silo and client-side. For more information on adding package references, see [dotnet add package](../../core/tools/dotnet-add-package.md) or [Install and manage packages in Visual Studio using the NuGet Package Manage](/nuget/consume-packages/install-use-packages-visual-studio).

## Define a Grain Interface

In the **GrainInterfaces** project, add an _IHello.cs_ code file and define the following `IHello` interface in it:

:::code source="snippets/minimal/GrainInterfaces/IHello.cs":::

## Define a grain class

In the **Grains** project, add a _HelloGrain.cs_ code file and define the following class in it:

:::code source="snippets/minimal/Grains/HelloGrain.cs":::

### Create the Silo

At this step, you add code to initialize a server that will host and run our grains&mdash;a silo. You use the development clustering provider here, so that you can run everything locally, without a dependency on external storage systems. For more information, see [Local Development Configuration](../host/configuration-guide/local-development-configuration.md). In this example, you run a cluster with a single Silo in it.

Add the following code to _Program.cs_ of the **Silo** project:

:::code source="snippets/minimal/Silo/Program.cs":::

### Create the client

Finally, you need to configure a client for communicating with our grains, connect it to the cluster (with a single silo in it), and invoke the grain. The clustering configuration must match the one you used for the silo. For more information, see [Clusters and Clients](../host/client.md)

:::code source="snippets/minimal/Client/Program.cs":::

## Run the application

Build the solution and run the **Silo**. After you get the confirmation message that the **Silo** is running ("Press enter to terminate..."), run the **Client**. For more information, see [How to: Set multiple startup projects](/visualstudio/ide/how-to-set-multiple-startup-projects).

## See also

- [List of Orleans Packages](../resources/nuget-packages.md)
- [Orleans Configuration Guide](../host/configuration-guide/index.md)
- [Orleans Best Practices](https://www.microsoft.com/research/publication/orleans-best-practices)
