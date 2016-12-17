---
title: Install for Fedora
description: Install for Fedora
keywords: .NET, .NET Core, C#, Getting Started, Acquisition,  Cross Platform, Fedora, Linux
author: kendrahavens
ms.author: kendrahavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 
---

# Install for Fedora
## 1. Download .NET Core SDK
- Before you start, please remove any previous versions of .NET Core from your system.
- In order to install .NET Core 1.1 on Fedora, first you need to get the prerequisites and then you download the .NET Core SDK binaries, extract them onto your system and put dotnet onto your PATH.
- .NET Core 1.1 is the latest version. For long term support versions and additional downloads check the [all Linux downloads](https://www.microsoft.com/net/download/linux) section.

Fedora 23
```
sudo dnf install libunwind libicu
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?LinkID=835023
```
Fedora 24
```
sudo dnf install libunwind libicu
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?LinkID=835025
```
## 2. Install the SDK and put it on the $PATH
```
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
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

