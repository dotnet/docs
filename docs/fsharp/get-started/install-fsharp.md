---
title: Install F#
description: Learn how to install F# in various different ways.
ms.date: 12/20/2019
---
# Install F\#

You can install F# in multiple ways, depending on your environment.

## Install F# with Visual Studio

1. If you're downloading [Visual Studio](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) for the first time, it will first install Visual Studio Installer. Install the appropriate edition of Visual Studio from the installer.

   If you already have Visual Studio installed, choose **Modify** next to the edition you want to add F# to.

2. On the Workloads page, select the **ASP.NET and web development** workload, which includes F# and .NET Core support for ASP.NET Core projects.

3. Choose **Modify** in the lower right-hand corner to install everything you've selected.

   You can then open Visual Studio with F# by choosing **Launch** in Visual Studio Installer.

## Install F# with Visual Studio Code

1. Ensure you have [git](https://git-scm.com/download) installed and available on your PATH. You can verify that it's installed correctly by entering `git --version` at a command prompt and pressing **Enter**.

2. Install the [.NET Core SDK](https://dotnet.microsoft.com/download) and [Visual Studio Code](https://code.visualstudio.com).

3. Select the Extensions icon and search for "Ionide":

   The only plugin required for F# support in Visual Studio Code is [Ionide-fsharp](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp). However, you can also install [Ionide-FAKE](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-FAKE) to get [FAKE](https://fake.build/) support and [Ionide-Paket](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-Paket) to get [Paket](https://fsprojects.github.io/Paket/) support. FAKE and Paket are additional F# community tools for building projects and managing dependencies, respectively.

## Install F# with Visual Studio for Mac

F# is installed by default in [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link), no matter which configuration you choose.

After the install completes, choose **Start Visual Studio**. You can also open Visual Studio through Finder on macOS.

## Install F# on a build server

If you're using .NET Core or .NET Framework via the .NET SDK, you simply need to install the .NET SDK on your build server. It has everything you need.

If you're using .NET Framework and you are **not** using the .NET SDK, then you'll need to install the [Visual Studio Build Tools SKU](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=BuildTools&rel=16) onto your Windows Server. In the installer, select **.NET desktop build tools**, and then select the **F# compiler** component on the right-hand side of the installer menu.
