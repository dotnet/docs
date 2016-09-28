---
title: Using F# on Azure
description: Guide to using Azure services with F#
keywords: Azure, cloud, visual f#, f#, functional programming, .NET, .NET Core
author: dsyme
manager: jbronsk
ms.date: 09/22/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: FAD4D11E-703A-42D4-9F72-893D9E0F569B
---


# Using F# on Azure

F# is a superb language for cloud programming and is frequently used to write web applications, cloud services, cloud-hosted microservices, and for scalable data processing.

In the sections below, you will find resources on how to use a range of Azure services with F#.

> [!NOTE]
> If a particular Azure service isn't in this documentation set, please consult the C# documentation for that service. Some Azure services are entirely language-independent systems services and require no language-specific documentation, and in this case are not listed here.

## Using Azure Virtual Machines with F# #

Azure supports a wide range of virtual machine (VM) configurations, see [Linux and Azure Virtual Machines](https://azure.microsoft.com/en-us/services/virtual-machines/).

To install F# on a virtual machine for execution, compilation and/or scripting see [Using F# on Linux](http://fsharp.org/use/linux) and [Using F# on Windows](http://fsharp.org/use/windows).

## Using Azure Functions with F# #

[Azure Functions](https://azure.microsoft.com/en-us/services/functions/) is a solution for easily running small pieces of code, or "functions," in the cloud. You can write just the code you need for the problem at hand, without worrying about a whole application or the infrastructure to run it. Your functions are connected to events in Azure storage and other cloud-hosted resources. Data flows into your F# functions via function arguments. You can use your development language of choice, trusting Azure to scale as needed.

Azure Functions support F# as a first-class language with efficient, reactive, scalable execution of F# code. See the [Azure Functions F# Developer Reference](https://azure.microsoft.com/en-us/documentation/articles/functions-reference-fsharp/) for reference doccumentation on how to use F# with Azure Functions.

Other resources for using Azure Functions and F#:

* [Scale Up Azure Functions in F# Using Suave](http://blog.tamizhvendan.in/blog/2016/09/19/scale-up-azure-functions-in-f-number-using-suave/)
* [Azure Functions in Practice](https://www.troyhunt.com/azure-functions-in-practice/)

## Using Azure Storage with F# #

Azure Storage is a base layer of storage services for modern applications that rely on durability, availability, and scalability to meet the needs of customers. F# programs can interact directly with Azure storage services, using the techinques described in the articles below.

* [Get started with Azure Blob storage using F#](blob-storage.md)
* [Get started with Azure File storage using F#](file-storage.md)
* [Get started with Azure Queue storage using F#](queue-storage.md)
* [Get started with Azure Table storage using F#](table-storage.md)

Azure Storage can also be used in conjunction with Azure Functions through declarative configuration rather than explicit API calls. See the information above on using Azure Functions with F#.

## Other resources

* [Full documentation on all Azure services](https://azure.microsoft.com/en-us/documentation/)
