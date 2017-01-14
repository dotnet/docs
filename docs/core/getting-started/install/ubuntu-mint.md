---
title: Install for Ubuntu 14.04, 16.04, 16.10 & Linux Mint 17 | Microsoft Docs
description: Install for Ubuntu 14.04, 16.04, 16.10 & Linux Mint 17
keywords: .NET, .NET Core, C#, Getting Started, Acquisition, Cross Platform, Linux, Ubuntu 14.04, Ubuntu 16.04, Ubuntu 16.10, Linux Mint 17
author: kendrahavens
ms.author: kehavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: ef06e00c-53b4-40f3-9792-4ebc1634cbb7
---
# Install for Ubuntu 14.04, 16.04, 16.10 & Linux Mint 17
## 1. Add the dotnet apt-get feed
- In order to install .NET Core on Ubuntu or Linux Mint, you need to first set up the apt-get feed that hosts the package you need.

Ubuntu 14.04 / Linux Mint 17
```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ trusty main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update
```
Ubuntu 16.04
```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ xenial main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update
```
Ubuntu 16.10
```
sudo sh -c 'echo "deb [arch=amd64] https://apt-mo.trafficmanager.net/repos/dotnet-release/ yakkety main" > /etc/apt/sources.list.d/dotnetdev.list'
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 417A0893
sudo apt-get update
```
[!TIP] [Video: Installing .NET Core and Visual Studio Code on Ubuntu](https://sec.ch9.ms/ch9/d1a6/8d5a574e-c8b1-47ef-96b1-aab0b8bbd1a6/VSCodeLinuxTutorial_high.mp4)

## 2. Install .NET Core SDK
- Before you start, please remove any previous versions of .NET Core from your system by using [this script](https://github.com/dotnet/cli/blob/rel/1.0.0/scripts/obtain/uninstall/dotnet-uninstall-debian-packages.sh).
- To install .NET Core 1.1 on Ubuntu or Linux Mint, simply use apt-get.
- .NET Core 1.1 is the latest version. For long term support versions and additional downloads check the [all Linux downloads](https://www.microsoft.com/net/download/linux) section.
```
sudo apt-get install dotnet-dev-1.0.0-preview2.1-003177
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
