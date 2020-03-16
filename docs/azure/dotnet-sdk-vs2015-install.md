---
title: Azure tools for Visual Studio 2015
description: Get the tools to start using the Azure .NET libraries from Visual Studio 2015.
ms.date: 10/19/2017
---

# Azure tools for Visual Studio 2015

The quickest and easiest way to install the **Azure SDK for Visual Studio 2015** and **Service Fabric SDK and Tools for Visual Studio 2015** is using the [Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx).  The Microsoft Web Platform Installer is a free tool that streamlines downloading, installing, and updating some of the components of the Microsoft Web Platform, including Azure tools for Visual Studio 2015.  These SDKs can also be downloaded and installed as individual components from the [Azure Downloads page](https://azure.microsoft.com/downloads/). 

## Using the Web Platform Installer

1. Download and run this [Web Platform Installer bootstrapper](https://www.microsoft.com/web/handlers/webpi.ashx?command=getinstallerredirect&appid=VWDOrVs2015AzurePack;MicrosoftAzure-ServiceFabric-VS2015).  

2. The bootstrapper will install Web Platform Installer (if needed) and automatically put the latest versions of the  **Azure SDK for Visual Studio 2015** and **Service Fabric SDK and Tools for Visual Studio 2015** items in your *Items to be installed* list.  Click **Install**.

    ![Web Platform Installer](media/dotnet-sdk-vs2015-install/webpi.png)

3. On the next screen, click **I Accept**.  Web PI will begin downloading and installing the components you selected.

4. After the installation is finished, it will display a confirmation screen.  Click **Finish**.  You can now close Web Platform Installer.

## Verifying the installation

1. In Visual Studio 2015, click the **Tools** menu, and then click **Extensions and Updates...**.

2. The displayed list will contain several Azure tools, such as **Microsoft Azure App Service Tools**, **Microsoft Azure Storage Connected Service**, and **Service Fabric Tools**.

    ![Extensions and updates](media/dotnet-sdk-vs2015-install/ext-tools.png)

## Next steps

[Get started with Azure libraries for .NET](dotnet-sdk-azure-get-started.md).
