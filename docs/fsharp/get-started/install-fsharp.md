---
title: Install F#
description: Learn how to install F# based on your environment.
ms.date: 09/05/2019
---

# Install F\#

You can install F# in multiple ways, depending on your environment.

## Install F# with Visual Studio

If you're downloading [Visual Studio](https://visualstudio.microsoft.com/vs/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link) for the first time, it will first install the Visual Studio installer. Install the appropriate SKU of Visual Studio from the installer. If you already have it installed, click **Modify**.

You'll next see a list of Workloads. Select **ASP.NET and web development** which will install F# support and .NET Core support for ASP.NET Core projects.

Next, click **Modify** in the lower right-hand side.  This will install everything you have selected. You can then open Visual Studio 2017 with F# language support by clicking **Launch**.

## Install F# with Visual Studio Code

First, ensure you have [git installed](https://git-scm.com/download) and available on your PATH. You can verify that it is installed correctly by typing `git --version` at a command prompt and pressing **Enter**.

Next, install the [.NET Core SDK](https://dotnet.microsoft.com/download).

You will then need [Visual Studio Code](https://code.visualstudio.com) installed.

Next, click the Extensions icon and search for "Ionide":

The only plugin required for F# support in Visual Studio Code is [Ionide-fsharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp). However, you can also install [Ionide-FAKE](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-FAKE) to get [FAKE](https://fake.build/) support and [Ionide-Paket](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-Paket) to get [Paket](https://fsprojects.github.io/Paket/) support. FAKE and Paket are additional F# community tools for building projects and managing dependencies, respectively.

## Install F# with Visual Studio for Mac

F# is installed by default in [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link), no matter which configuration you choose.

After the install completes, choose "Start Visual Studio". You can also launch it through Finder on macOS.

## Install F# on a Build Server

If you are using .NET Core or .NET Framework via the .NET SDK, you simply need to install the .NET SDK on your build server. It has everything you need.

If you are using .NET Framework and you are **not** using the .NET SDK, then you will need to install the [Visual Studio Build Tools SKU](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16) onto your Windows Server. In the installer, select **.NET desktop build tools** and then select the **F# compiler** component on the right side of the installer menu.
