---
title: Packaging your Application
description: Packaging your Application
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# Packaging your Application

There are a couple of options when it comes to packaging up your desktop application to make it ready for deployment the users' computer.

## Windows Application Packaging Project (package your app as an MSIX)

The [MSIX application package](https://docs.microsoft.com/windows/msix/overview) format provides a modern packaging experience to all Windows apps. It enables both initial deployment of the app, automatic detection, and deployment of updates. 

You can use the Windows Application Packaging Project in Visual Studio to generate an MSIX package for your .NET Core 3.0 or later app. You can then sideload this app on to a computer.

Note: Currently MSIX packaging is only supported for self-contained deployment, it is not available for framework-dependent deployments.

More information about packaging your app as an MSIX package, see [Package a desktop app from source code using Visual Studio](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-packaging-dot-net).



## Visual Studio Installer Project (package your app as an MSI)

[Windows Installer](https://docs.microsoft.com/windows/win32/msi/windows-installer-portal) deployment allows you to create installer packages in an MSI format, the user runs the setup installer and steps through a wizard to install the application. 

You can use the [VS Installer Projects Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=visualstudioclient.MicrosoftVisualStudio2017InstallerProjects) to generate an MSI package for your .NET Core app.

For more information about packaging your app as an MSI using Visual Studio Installer Projects, see [Visual Studio Installer Deployment](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/2kt85ked(v=vs.100)).


## Third party installers

In addition to using Visual Studio to create an MSIX or MSI package, there are other third-party products and installers that can be used to package a desktop application. 

More information about these installers can be found in the document [Package a desktop app using third-party installers](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-third-party-installer)