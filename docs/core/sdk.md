---
title: .NET Core SDK Overview
description: Find out about the .NET Core SDK, which is a set of libraries and tools used to create .NET Core projects.
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 26bc9822-e42b-48ec-b0d6-499dc604add7
ms.workload: 
  - dotnetcore
---

# .NET Core SDK Overview 

## Introduction
.NET Core Software Development Kit (SDK) is a set of libraries and tools that allow developers to create .NET Core applications
and libraries. This is the package that developers will most likely acquire. 

It contains the following components:

1. The .NET Core Command Line Tools that are used to build applications
2. .NET Core (libraries and runtime) that allow applications to both be built and run
3. The `dotnet` driver for running the [CLI commands](tools/index.md) as well as running applications


## Acquiring the .NET Core SDK
As with any tooling, the first thing is to get the tools to your machine. Depending on your scenario, you can either 
use the native installers to install the SDK or use the installation shell script.

The native installers are primarily meant for developer's machines. The SDK is distributed using each supported platform's 
native install mechanism, for instance DEB packages on Ubuntu or MSI bundles on Windows. These installers will install 
and set up the environment as needed for the user to use the SDK immediately after the install. However, they also 
require administrative privileges on the machine. You can view the installation instructions on the
[.NET Core installation guide](https://aka.ms/dotnetcoregs).

Install scripts, on the other hand, do not require administrative privileges. However, they will also not install any 
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for 
setting up build servers or when you wish to install the tools without admin privileges (do note the prerequisites 
caveat above). You can find more information on the [install script reference topic](tools/dotnet-install-script.md). If you are 
interested in how to set up SDK on your CI build server you can take a look at the [SDK with CI servers](tools/using-ci-with-cli.md) 
document. 

By default, the SDK will install in a "side-by-side" (SxS) manner. This means that multiple versions of the CLI tools 
can coexist at any given time on a single machine. How the correct version gets used is explained in more detail in 
the [driver section](tools/index.md#driver) of .NET Core Command Line Tools topic.
