---
title: .NET Core Acquisition and Deployment Guide
description: Learn about the ways to acquire and deploy a .NET Core and .NET Core applications.

author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# .NET Core Acquisition and Deployment Guide

## Terminology

First, let’s review some basic terminology we will be using throughout this guide -

**_Acquisition_** is about finding and getting what you need for both development (i.e. toolset/SDK) and for runtime. Acquisition also includes the ability to detect if the packages you have are up-to-date.

**_Deployment_** is about packaging the application and delivering the application and runtime to the target machine. 

<br/>

## For Developers: Building and Deploying your .NET Core app

As a developer, your workflow will typically look like this:

Step 1 | | Step 2 | | Step 3 | | Step 4 |
|---|---|---|---|---|---|---|
 [Build your App](#Step-1-Build-your-app) | --> | [Publish your app](#Step-2-publish-your-app) | --> | [Package your app for deployment](#Step-3-Package-your-app-for-deployment) | --> | [Deploy your app](#Step-4-Deploy-your-app) | 


<br/>

### Step 1: Build your app

When it comes to creating and building your app you have two choices - you can work with either an IDE like Visual Studio or the Command Line Interface (CLI).

[Acquire the .NET Core tools through Visual Studio]()

[Acquire the .NET Core CLI tools]()

_There are several other ways to acquire the .NET Core SDK and Runtime, these options are covered in the [.NET Core Acquisition Experiences](acquisition-experiences.md) guide._


Once you have acquired the tools, you're ready to build your app. You would use the approach that corresponds to whether in the previous step you chose to use an IDE like Visual Studio or Visual Studio for Mac or the CLI.

[Build your first .NET Core app using Visual Studio](https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio)
 
[Build your first .NET Core app using the Command Line Interface (CLI)](../tutorials/using-with-xplat-cli.md)


Either choice will allow you to create various types of .NET Core applications including ASP.NET Core, WPF and Windows Forms applications.


<br/>

### Step 2: Publish your app

You can publish your app in one of two configurations - as a [Framework Dependent Deployment (FDD)]() or as a [Self-Contained Deployment (SCD)]().

Within each of these configurations, you also have the choice of publishing the app as a set of loose assemblies which you then either xcopy or package up for deployment, or alternatively as a single file executable.

More information about each of these configurations can be found in the document on how to [Publish your app](publish.md).


<br/>

### Step 3: Package your app for deployment

Packaging your app while usually preferred, is optional. You can always choose to xcopy the publish folder of your app to a folder on the target computer where you want to run this. 

If rather than use an xcopy based deployment you would prefer to package your app with a more professional installer experience, you have a couple of options. 

At a high level, you can choose to package your app using one of the deployment technologies built into Visual Studio (MSIX and MSI), or use a third party installer of your choise.

This document on [.NET Core Packaging](packaging.md) covers packaging your app as either an MSIX or MSI in further detail. You may also want to review the guide on [Packaging a desktop app using third party installers](https://docs.microsoft.com/en-us/windows/msix/desktop/desktop-to-uwp-third-party-installer). 


<br/>

### Step 4: Deploy your app


#### **Pre-requisites for deploying your Framework Dependent Deployment (FDD) app**

If you chose to create a Framework Dependent Deployment (FDD) for your app during the publish step then you need to ensure the .NET Core Runtime is installed on the target computer. There are several options for acquiring the .NET Core runtime, please refer to the [.NET Core Acquisition Experiences](acquisition-experiences.md) guide to select the option that works best for you.

If you chose to create a Self-Contained Deployment (CDD) during the publish step then there's nothing else to do since the latest .NET Core runtime is already included with your application.


#### **Deploying your app without Packaging/an Installer**

If you chose to forgo packaging your app in the previous step then you can simply xcopy over the publish folder to the target computer. 

_Note: If you created a single file executable during publish then instead of multiple files in the publish older you will only have that single executable to copy over to the target computer.__


#### **Deploying your app with Packaging/an Installer**

If you have created an installer then you need to copy the installer to the target machine and run the installer. 

Note: If your installer was signed using a test certificate or a self-signed certificate then you would need to do the following before installing the app:

a) [Enable Developer mode](https://docs.microsoft.com/en-us/windows/uwp/get-started/enable-your-device-for-development) on the target computer

b) Import the test certificate on the target computer (Tursted Root Certification Authorities) folder


<br/>
<br/>



## For DevOps Engineers/IT Admins: Deploying .NET Apps and the .NET Core runtime

As a dev-ops engineer managing a CI/CD environment or an IT admin responsible for deploying software in an organization, you will want to think about the following choices:

1.	Pick an option to acquire and deploy the .NET Core runtime necessary for the app to run 
2.	Determine how you will deploy your app



## See also

- [.NET Core Acquisition Experiences](acquisition-experiences.md)
- [.NET Core Deployment Experiences](deployment-experiences.md)
- [Publish your Application](publish.md)
- [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
- [Trimming](trimming.md)
- [Packages, Metapackages and Frameworks](../packages.md)
