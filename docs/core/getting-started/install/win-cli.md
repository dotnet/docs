---
title: Install for Windows - Command Line
description: Install for Windows - Command Line
keywords: .NET, .NET Core, Visual Studio Code, VS Code, C#, Getting Started, Acquisition, Cross Platform
author: kendrahavens
ms.author: kendrahavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 
---
# Install for Windows - Command Line

## 1. Install .NET Core SDK
- To start creating .NET Core apps you just need to download the .NET Core SDK for Windows.
  ## [Download .NET Core 1.1 SDK](https://go.microsoft.com/fwlink/?LinkID=835014)
- .NET Core 1.1 is the latest version. For long term support versions and additional downloads check the all downloads section.

[!TIP] [Video: Installing .NET Core and Visual Studio Code in Windows](https://sec.ch9.ms/ch9/51a9/95a7aa04-05c5-4c93-836d-cc54481651a9/VSCodeTutorialWindows_high.mp4)

## 2. Initialize some code
- Let's initialize a sample Hello World application!
```
mkdir hwapp
cd hwapp
dotnet new
```
3. Run the app
- The first command will restore the packages specified in the project.json file, and the second command will run the actual sample:
```
dotnet restore
dotnet run
```
## And you're ready!
You now have .NET core running on your machine!

## Want some tools?
[Visual Studio Code](https://code.visualstudio.com/) complements your command line experience with a lightweight code editor that runs on Windows, Mac and Linux.

## [Download Visual Studio Code](https://code.visualstudio.com/)