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


## For Developers: Building and Deploying your .NET Core app

As a developer, you will want to think about the following questions when building and deploying your .NET Core app:

1.	Determine whether you will use an IDE like Visual Studio or the Command Line Interface (CLI) to build your app.

2.	Determine whether you will build a Framework Dependent Deployment (FDD) or Self-Contained Deployment (SCD)

3.	Determine whether you will publish the app as a set of assemblies or whether you will publish a single file executable

4.	Determine how your app will be packaged and deployed to the target computer


## For DevOps Engineers/IT Admins: Deploying .NET Apps and the .NET Core runtime

As a dev-ops engineer managing a CI/CD environment or an IT admin responsible for deploying software in an organization, you will want to think about the following questions:
1.	Determine how you will acquire and deploy the .NET Core runtime necessary for the app to run 
2.	Determine how you will deploy the app



## See also

- [Deploying .NET Core Apps with CLI Tools](deploy-with-cli.md)
- [Deploying .NET Core Apps with Visual Studio](deploy-with-vs.md)
- [Packages, Metapackages and Frameworks](../packages.md)
- [.NET Core Runtime IDentifier (RID) catalog](../rid-catalog.md)
