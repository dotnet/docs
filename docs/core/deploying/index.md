---
title: .NET Core Acquisition and Deployment Guide
description: Learn about ways to acquire and deploy the .NET Core runtime and tools and .NET Core apps.
author: jamshedd
ms.author: jamshedd
ms.date: 09/06/2019
ms.custom: 
---
# .NET Core acquisition and deployment

## Terminology

First, let's review some basic terminology we will be using throughout this guide -

**_Acquisition_** is about finding and getting what you need for both development (that is toolset/SDK) and for runtime. Acquisition also includes the ability to detect if the packages you have are up-to-date.

**_Deployment_** is about packaging the application and delivering the application and runtime to the target machine.

<br/>

## For Developers: Building and Deploying your .NET Core app

As a developer, your workflow will typically look like this:

Step 1 | | Step 2 | | Step 3 | | Step 4 |
|---|---|---|---|---|---|---|
 [Build your App](#Step-1-Build-your-app) | --> | [Publish your app](#Step-2-publish-your-app) | --> | [Package your app for deployment](#Step-3-Package-your-app-for-deployment) | --> | [Deploy your app](#Step-4-Deploy-your-app) | 


<br/>

### Step 1: Build your app

When it comes to creating and building your app, you have two choices - you can work with either an IDE like Visual Studio or the Command Line Interface (CLI).

[Acquire the .NET Core tools through Visual Studio]()

[Acquire the .NET Core CLI tools]()

_There are several other ways to acquire the .NET Core SDK and Runtime, these options are covered in the [.NET Core Acquisition Experiences](acquisition-experiences.md) guide._


Once you have acquired the tools, you're ready to build your app. Pick the approach that corresponds to whether in the previous step you chose to use an IDE like Visual Studio or Visual Studio for Mac or the CLI.

[Build your first .NET Core app using Visual Studio](https://docs.microsoft.com/dotnet/core/tutorials/with-visual-studio)
 
[Build your first .NET Core app using the Command Line Interface (CLI)](../tutorials/using-with-xplat-cli.md)


Either choice will allow you to create various types of .NET Core applications including ASP.NET Core, WPF, and Windows Forms applications.


<br/>

### Step 2: Publish your app

You can publish your app in one of two configurations - as a [Framework Dependent Deployment (FDD)](publish.md#Framework-Dependent-Deployment-FDD) or as a [Self-Contained Deployment (SCD)](publish.md#Self-contained-deployment-SCD).

For both of the above configurations, you can publish the app either as a set of loose assemblies for either `xcopy` or package up for deployment, or alternatively as a single file executable.

More information about each of these configurations can be found in the document on how to [Publish your app](publish.md).


<br/>

### Step 3: Package your app for deployment

Packaging your app is optional. You can `xcopy` the publish folder of your app to a folder on the target computer. 

If you prefer to package your app with a more professional installer experience instead of an `xcopy` based deployment, you have a couple of options.

You can package your app using one of the deployment technologies built into Visual Studio (MSIX and MSI), or use a third-party installer of your choice.

This document on [.NET Core Packaging](packaging.md) covers packaging your app as either an MSIX or MSI in further detail. You may also want to review the guide on [Packaging a desktop app using third party installers](https://docs.microsoft.com/windows/msix/desktop/desktop-to-uwp-third-party-installer). 


<br/>

### Step 4: Deploy your app


#### **Pre-requisites for deploying your Framework-Dependent Deployment (FDD) app**

If you create a Framework-Dependent Deployment (FDD) for your app during the publish step, then you need to install the .NET Core Runtime on the target computer. There are several options for acquiring the .NET Core runtime, refer to the [.NET Core Acquisition Experiences](acquisition-experiences.md) guide to select the option that works best for you.

If you chose to create a Self-Contained Deployment (CDD) during the publish step the latest .NET Core runtime is already included with your application, so there's nothing else to do.


#### **Deploying your app without Packaging/an Installer**

If you chose to forgo packaging your app in the previous step, then you can `xcopy` over the publish folder to the target computer. 

_Note: If you created a single file executable during publish, then instead of multiple files in the publish older you copy over that single executable to the target computer.__


#### **Deploying your app with Packaging/an Installer**

If you have created an installer, copy it to the target machine and run the installer. 

Note: If your installer was signed using a test certificate or a self-signed certificate, you need to complete these steps before installing the app:

a) [Enable Developer mode](https://docs.microsoft.com/windows/uwp/get-started/enable-your-device-for-development) on the target computer

b) Import the test certificate on the target computer (Trusted Root Certification Authorities) folder


<br/>
<br/>



## For DevOps Engineers and Enterprise IT Administrators

As a DevOps Engineer you may be responsible for deploying the .NET Core tools and runtime to CI/CD machines. Or, as an IT Administrator in an enterprise you may be responsible for deploying the .NET Core runtime to end-user machines or servers where .NET Core apps will run.

| Step 1 | | Step 2 |
|-|-|-|
| [Acquire the .NET Core runtime](#Step-1-acquire-the-core-runtime) | --> | [Deploy the .NET Core runtime](#step-2-deploy-the-core-runtime) | 


<br/>

### Step 1: Acquire the Core Runtime

When it comes to acquiring the .NET Core runtime and tools, you have several options to choose from so you have the flexibility to pick the approach that is right for your needs. 

Various acquisition options for the .NET Core runtime and tools are covered in more detail in the [.NET Core Acquisition Experiences guide](acquisition-experiences.md).


<br/>

### Step 2: Deploy the Core Runtime

When it comes to deploying the .NET Core runtime, you can again choose between various options for both cloud and on-premises deployments. 


#### Deploying to the Cloud

* Various [Azure App Services](acquisition-experiences.md#azure-app-services) support containers. You create a Docker image for your application and deploy it to one of these services.
 
* The Azure DevOps pipeline supports the [.NET Core Installer Task](https://docs.microsoft.com/azure/devops/pipelines/tasks/tool/dotnet-core-tool-installer?view=azure-devops) which can be used to acquire a specific version of .NET Core from the Internet.


#### Deploying to on-premises clients/servers

* Using a software update management tool like [System Center Configuration Manager (SCCM)](https://docs.microsoft.com/sccm/) or another similar tool is a great option to deploy the .NET Core runtime or tools to on-premises clients and servers. 

  Software update management tools like System Center Configuration Manager allow you to define a target group of computers for deploying the .NET Core runtime and also the app itself. You then push the deployment to the target group. 

  System Center Configuration Manager client is supported on Windows Server and Client computers, MacOS, and Linux. 

  For more information about using SCCM to deploy the .NET Core runtime, see [Create and deploy an application with SCCM](https://docs.microsoft.com/sccm/apps/get-started/create-and-deploy-an-application).

* Another option for deploying the .NET Core runtime or tools to on-premises clients/servers is the [Dotnet-install Script](acquisition-experiences.md#Dotnet-install.ps1.sh-Scripts). You can use this script anywhere PowerShell and Bash are supported. 


<br/>

## See also

- [.NET Core Acquisition Experiences](acquisition-experiences.md)
- [.NET Core Deployment Experiences](deployment-experiences.md)
- [Publish your Application](publish.md)
- [Trimming](trimming.md)
- [Packaging your Application](packaging.md)
- [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
- [Packages, Metapackages, and Frameworks](../packages.md)
