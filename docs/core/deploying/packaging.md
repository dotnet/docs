---
title: Packaging your Application
description: Packaging your Application
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---

# Packaging your Application

There are a couple of options when it comes to packaging up your application to make it ready for deployment the users’ computer.

## Windows Application Packaging Project (package your app as an MSIX)

The MSIX application package format provides a modern packaging experience to all Windows apps. It enables both initial deployment and automatic detection and deployment of updates for the application similar to the ClickOnce application deployment experience. 

You can use the Windows Application Packaging Project in Visual Studio to generate an [MSIX package](https://docs.microsoft.com/en-us/windows/msix/overview) for your .NET Core 3.0 or later app. You can then sideload this app on to a computer.

Note: MSIX packaging is only supported for self-contained deployments at this time, it is not available for framework dependent deployments.

More information about packaging your app as an MSIX package can be found in the document [Package a desktop app from source code using Visual Studio](https://docs.microsoft.com/en-us/windows/msix/desktop/desktop-to-uwp-packaging-dot-net).



## Visual Studio Installer Project (package your app as an MSI)

Windows Installer deployment enables you to create installer packages to be distributed to users, the user runs the setup and steps through a wizard to install the application. 

You can use the [VS Installer Projects Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=visualstudioclient.MicrosoftVisualStudio2017InstallerProjects) to generate an MSI package for your .NET Core app.

For more information about packaging your app as an MSI using [Visual Studio Installer Projects please refer to the [Visual Studio Installer Deployment](https://docs.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2010/2kt85ked%28v%3dvs.100%29) guide.
