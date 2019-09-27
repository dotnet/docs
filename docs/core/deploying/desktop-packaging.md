---
title: Packaging your Desktop Application
description: Packaging your Desktop Application
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# Packaging your Desktop Application

There are a couple of options when it comes to packaging up your desktop application to make it ready for deployment the users' computer.

## Windows Application Packaging Project (package your app as an MSIX)

The [MSIX application package](https://docs.microsoft.com/windows/msix/overview) format provides a modern packaging experience to all Windows apps. It enables initial deployment of the app as well as automatic detection and deployment of updates. 

You can use the [Windows Application Packaging Project](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-packaging-dot-net) in Visual Studio to generate an MSIX package for your .NET Core 3.0 or later app. You can then [sideload](https://docs.microsoft.com/windows/msix/package/packaging-uwp-apps#sideload-your-app-package) this app on to a computer.

Note: Currently MSIX packaging is only supported for self-contained deployment, it is not available for framework-dependent deployments.

For more information about packaging your app as an MSIX package using Windows Application Packaging Project, see [Package a desktop app from source code using Visual Studio](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-packaging-dot-net).



## Visual Studio Installer Project (package your app as an MSI)

The [Windows Installer](https://docs.microsoft.com/windows/win32/msi/windows-installer-portal) allows you to create installer packages in an MSI format. The end user that needs to install the app package runs the setup installer and steps through a wizard to install the application. 

You can use the [VS Installer Projects Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=visualstudioclient.MicrosoftVisualStudio2017InstallerProjects) to generate an MSI package for your .NET Core app.

For more information about packaging your app as an MSI using Visual Studio Installer Projects, see [Visual Studio Installer Deployment](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2010/2kt85ked(v=vs.100)).


## Third party installers

In addition to using Visual Studio to create an MSIX or MSI package, there are other third-party products and installers that can be used to package a desktop application. 

For more information about these third party installers, see [Package a desktop app using third-party installers](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-third-party-installer)
