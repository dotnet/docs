---
title: Tools for Azure .NET and .NET Core developers
description: Get the tools to start using the Azure .NET libraries from a Windows, Linux, and Mac environment.
ms.date: 10/01/2018
ms.custom: azure-dotnet-devcenter, azure-dotnet-devcenter-authored, azure-dotnet-devcenter-conceptual, vs-azure
---

# Tools for .NET and .NET Core Azure developers

## SDK downloads

Azure libraries for .NET are implemented as [NuGet packages](https://www.nuget.org/packages?q=windowsazureofficial). See the [API Reference](/dotnet/api/overview/azure/?view=azure-dotnet) for installation instructions organized by Azure service.

## Development tools

Visual Studio has tooling for many Azure services built-in. Some Azure services have additional tools or emulators available, such as [Azure Storage Explorer](https://azure.microsoft.com/features/storage-explorer/). See the documentation for your Azure service for any additional tools, if necessary.

These instructions install the recommended starting development environment for your operating system. 

## [Windows](#tab/windows)

<table>
  <tr>
    <td width="50">
        <img src="https://docs.microsoft.com/media/logos/logo_vs-ide.svg" width="50" height="50"></img>
    </td>
    <td>
        Visual Studio versions 2017 and later have built-in support for Azure development. The below steps describe enabling Azure development support in Visual Studio.<br />
        <br />
        For Visual Studio 2015 and earlier, <a href="dotnet-sdk-vs2015-install.md">follow these instructions</a>.
    </td>
  </tr>
</table>

### Step 1: Download Visual Studio 2019

You can skip this step if you already have Visual Studio 2019 installed.

> [!div class="nextstepaction"]
> [Download Visual Studio 2019](https://www.visualstudio.com/downloads/)

### Step 2: Install the two Azure workloads

In the Visual Studio installer, install Visual Studio (or modify an existing installation). Make sure the *Azure development* and *ASP.NET and web development* workloads are selected.

### Step 3: Develop with .NET on Azure

Get started by [deploying your first ASP.NET Core web app on Azure App Service](https://docs.microsoft.com/azure/app-service-web/app-service-web-get-started-dotnet).

## [macOS](#tab/macos)
<table>
  <tr>
    <td width="50">
        <img src="https://docs.microsoft.com/media/logos/logo_vs-mac.svg" width="50" height="50"></img>
    </td>
    <td>
        Visual Studio for Mac has everything you need for Azure development.
    </td>
  </tr>
</table>

### Step 1: Download Visual Studio for Mac

> [!div class="nextstepaction"]
> [Download Visual Studio for Mac](https://www.visualstudio.com/vs/visual-studio-mac/)

During installation, Azure tools are selected by default.

## [Linux](#tab/linux)

<table>
  <tr>
    <td width="50">
        <img src="https://docs.microsoft.com/media/logos/logo_vs-code.svg" width="50" height="50"></img>
    </td>
    <td>
        Visual Studio Code has everything you need for Azure development on Linux.
    </td>
  </tr>
</table>

### Step 1: Download the .NET Core SDK

The SDK and command-line tools for .NET Core apps.

> [!div class="nextstepaction"]
> [Download .NET Core SDK](https://dotnet.microsoft.com/download)

### Step 2: Visual Studio Code

Edit and debug .NET Core apps on any operating system: Windows, Mac, and Linux.

> [!div class="nextstepaction"]
> [Download Visual Studio Code](https://code.visualstudio.com)
