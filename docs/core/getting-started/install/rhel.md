---
title: Install for Red Hat Enterprise Linux 7 Server | Microsoft Docs
description: Install for Red Hat Enterprise Linux 7 Server
keywords: .NET, .NET Core, C#, Getting Started, Acquisition, Cross Platform, Linux, RHEL, Red Hat enterprise Linux
author: kendrahavens
ms.author: kehavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8430211d-9a3b-4834-98bd-c28b7529f1a9
---
# Install for Red Hat Enterprise Linux 7 Server

## 1. Enable the .NET Core channel for Red Hat Enterprise Linux 7 Server
- In order to install .NET Core from Red Hat on RHEL Server, you first need to enable the .NET Core channel which is available under your RHEL 7 Server subscription. You also need to ensure that your system supports enabling software collections via the scl tool.
```
subscription-manager repos --enable=rhel-7-server-dotnet-rpms
yum install scl-utils
```
- For help on registering your machine to get access to the channel see the [Chapter 1](https://access.redhat.com/documentation/en/net-core/1.0/getting-started-guide/chapter-1-install-net-core-100-on-red-hat-enterprise-linux) of the .NET Core Getting Started Guide at Red Hat.

## 2. Install and enable the .NET Core SDK
- Now you can install .NET Core 1.0 and then enable the .NET Core software collection.
- .NET Core 1.0.1 is the latest version. For long term support versions and additional downloads check the [all Linux downloads](https://www.microsoft.com/net/download/linux) section.
- For additional help and guidance on installing and enabling .NET Core on RHEL Server, see the [.NET Core Getting Started Guide at Red Hat](https://access.redhat.com/documentation/en/net-core/1.0/getting-started-guide/getting-started-guide).
```
yum install rh-dotnetcore10
scl enable rh-dotnetcore10 bash
```
## 3. Initialize some code
- Let's initialize a sample Hello World application!
```
mkdir hwapp
cd hwapp
dotnet new
```
## 4. Run the app
- The first command will restore the packages specified in the project.json file, and the second command will run the actual sample:
```
dotnet restore
dotnet run
```
## And you're ready!
- You now have .NET core running on your machine!

## Want some tools?
- Visual Studio Code runs on Linux and has full support for .NET Core.
  ## [Download Visual Studio Code](https://code.visualstudio.com/)