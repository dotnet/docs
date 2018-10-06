---
title: Install F#
description: Learn how to install F# based on your environment.
ms.date: 08/28/2018
---

# Install F# #

You can install F# in multiple ways, depending on your environment.

## Install F# with Visual Studio

If you're downloading [Visual Studio](https://visualstudio.microsoft.com/) for the first time, it will first install the Visual Studio installer. Install the appropriate SKU of Visual Studio from the installer. If you already have it installed, click **Modify**.

You'll next see a list of Workloads. Select **ASP.NET and web development** which will install F# support and .NET Core support for ASP.NET Core projects.

Next, click **Modify** in the lower right-hand side.  This will install everything you have selected. You can then open Visual Studio 2017 with F# language support by clicking **Launch**.

## Install F# with Visual Studio for Mac

F# is installed by default in [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/), no matter which configuration you choose.

After the install completes, choose "Start Visual Studio". You can also launch it through Finder on macOS.

## Install F# with Visual Studio Code

You must have [git installed](https://git-scm.com/download) and available on your PATH to make use of project templates. You can verify that it is installed correctly by typing `git --version` at a command prompt and pressing **Enter**.

### [macOS](#tab/macos)

[Mono](http://www.mono-project.com) is used for [F# Interactive](../tutorials/fsharp-interactive/index.md) support. The easiest way to install Mono on macOS is via Homebrew. Simply type the following into your terminal:

```console
brew install mono
```

Also install the [.NET Core SDK](https://www.microsoft.com/net/download).

### [Linux](#tab/linux)

[Mono](https://www.mono-project.com) is used for [F# Interactive](../tutorials/fsharp-interactive/index.md) support. If you're on Debian or Ubuntu, you can use the following:

```console
sudo apt-get update
sudo apt-get install mono-complete fsharp
```

Also install the [.NET Core SDK](https://www.microsoft.com/net/download).

### [Windows](#tab/windows)

Install [Visual Studio with F# support](#install-f-with-visual-studio). This installs all the necessary components to write, compile, and execute F# code.

Also install the [.NET Core SDK](https://www.microsoft.com/net/download/).

---

You will then need [Visual Studio Code](https://code.visualstudio.com) installed.

Next, click the Extensions icon and search for "Ionide":

The only plugin required for F# support in Visual Studio Code is [Ionide-fsharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp). However, you can also install [Ionide-FAKE](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-FAKE) to get [FAKE](https://fsharp.github.io/FAKE/) support and [Ionide-Paket](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-Paket) to get [Paket](https://fsprojects.github.io/Paket/) support. FAKE and Paket are additional F# community tools for building projects and managing dependencies, respectively.
