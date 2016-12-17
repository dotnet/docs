---
title: Install for CentOS 7.1 & Oracle Linux 7.1
description: Install for CentOS 7.1 & Oracle Linux 7.1
keywords: .NET, .NET Core, C#, Getting Started, Acquisition, Cross Platform, CentOS 7.1, Oracle Linux 7.1
author: kendrahavens
ms.author: kendrahavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 
---
# Install for CentOS 7.1 & Oracle Linux 7.1

## 1. Install .NET Core SDK
- Before you start, please remove any previous versions of .NET Core from your system.
- In order to install .NET Core 1.1 on CentOS or Oracle Linux, first you need to get the prerequisites and then you download the .NET Core SDK binaries, extract them onto your system and put dotnet onto your PATH.
- For other releases you can check the [Linux downloads](https://www.microsoft.com/net/download/linux) section.
```
sudo yum install libunwind libicu
curl -sSL -o dotnet.tar.gz https://go.microsoft.com/fwlink/?LinkID=835019
sudo mkdir -p /opt/dotnet && sudo tar zxf dotnet.tar.gz -C /opt/dotnet
sudo ln -s /opt/dotnet/dotnet /usr/local/bin
```

## 2. Initialize some code
- Let's initialize a sample Hello World application!
```
mkdir hwapp
cd hwapp
dotnet new
```
## 3. Run the app
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