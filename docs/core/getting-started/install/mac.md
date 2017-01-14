---
title: Install for macOS 10.11 or higher | Microsoft Docs
description: Install for macOS 10.11 or higher
keywords: .NET, .NET Core, C#, Getting Started, Acquisition, Cross Platform, macOS
author: kendrahavens
ms.author: kehavens
ms.date: 12/19/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: fe033d8e-4c1a-40d4-b0bb-c4aee3a364d6
---

# Install for macOS 10.11 or higher

## 1. Install pre-requisites
- In order to use .NET Core, you first need to install the latest version of OpenSSL. The easiest way to get this is from [Homebrew](http://brew.sh/).
- After installing brew, do the following:
```
brew update
brew install openssl
mkdir -p /usr/local/lib
ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
```
[!TIP] [Video: Install .NET Core and Visual Studio Code on a Mac](https://sec.ch9.ms/ch9/91a8/38eb734a-ea5a-4e3d-92ee-15de701391a8/VSCodeMac_high.mp4)

## 2. Install .NET Core SDK
- The best way to install .NET Core 1.1 on macOS is to download the official installer.

## [Download .NET Core SDK](https://go.microsoft.com/fwlink/?LinkID=835011)
- This installer will install the tools and put them on your PATH so you can run dotnet from the Console.
- .NET Core 1.1 is the latest version. For long term support versions and additional downloads check the [all downloads](https://www.microsoft.com/net/download/core) section.

[!NOTE] if you have any problems with installation on macOS, please consult our [known issues page](https://github.com/dotnet/core/blob/master/cli/known-issues.md).

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
- [Visual Studio Code](https://code.visualstudio.com/) runs on macOS and has full support for .NET Core. Install the [C# extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp) to get the best experience.
- [Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/) provides a full IDE to create mobile applications and also supports .NET Core backend development.


