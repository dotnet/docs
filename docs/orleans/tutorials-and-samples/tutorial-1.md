---
title: Minimal Orleans app sample project
description: Explore the minimal Orleans app sample project.
ms.date: 12/06/2022
---

# Tutorial: Create a minimal Orleans application

This tutorial provides step-by-step instructions for creating a basic functioning Orleans application. It is designed to be self-contained and minimalistic, with the following traits:

- It relies only on NuGet packages.
- It has been tested in Visual Studio 2022 using Orleans 7.0.
- It has no reliance on external storage.

Keep in mind this is a tutorial and lacks appropriate error handling and other essential code that would be useful for a production environment. However, it should help readers get a hands-on understanding of the common app structure for Orleans and allow them to focus their continued learning on the parts most relevant to them.

## Project setup

For this tutorial we're going to create four projects:

- Library to contain the grain interfaces.
- Library to contain the grain classes.
- Console app to host the Silo.
- Console app to host the Client.

### Create the structure in Visual Studio

You will replace the default code with the code given for each project, below. You will also probably need to add `using` statements.

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

`Microsoft.Orleans.Server`, `Microsoft.Orleans.Client` and `Microsoft.Orleans.Sdk` are meta-packages that bring dependency that you will most likely need on the Silo and client-side. For more information on adding package references, see [dotnet add package](../../core/tools/dotnet-add-package.md) or [Install and manage packages in Visual Studio using the NuGet Package Manage](/nuget/consume-packages/install-use-packages-visual-studio).

## Define a Grain Interface

In the **GrainInterfaces** project, add an _IHello.cs_ code file and define the following `IHello` interface in it:

:::code source="snippets/minimal/GrainInterfaces/IHello.cs":::

## Define a grain class

In the **Grains** project, add a _HelloGrain.cs_ code file and define the following class in it:

:::code source="snippets/minimal/Grains/HelloGrain.cs":::

### Create the Silo

At this step, we add code to initialize a server that will host and run our grains&mdash;a silo. We will use the development clustering provider here, so that we can run everything locally, without a dependency on external storage systems. For more information, see [Local Development Configuration](../host/configuration-guide/local-development-configuration.md). In this example, you'll run a cluster with a single Silo in it.

Add the following code to _Program.cs_ of the **Silo** project:

:::code source="snippets/minimal/Silo/Program.cs":::

### Create the client

Finally, we need to configure a client for communicating with our grains, connect it to the cluster (with a single silo in it), and invoke the grain. Note that the clustering configuration must match the one we used for the silo. For more information, see [Clusters and Clients](../host/client.md)

:::code source="snippets/minimal/Client/Program.cs":::

## Run the application

Build the solution and run the **Silo**. After you get the confirmation message that the **Silo** is running ("Press enter to terminate..."), run the **Client**. For more information, see [How to: Set multiple startup projects](/visualstudio/ide/how-to-set-multiple-startup-projects).

## See also

- [List of Orleans Packages](../resources/nuget-packages.md)
- [Orleans Configuration Guide](../host/configuration-guide/index.md)
- [Orleans Best Practices](https://www.microsoft.com/research/publication/orleans-best-practices)
