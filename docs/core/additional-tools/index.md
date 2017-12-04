---
title: .NET Core Additional Tools
description: An overview of the additional tools that support and extend .Net Core functionality.
author: miguell
ms.author: miguell
ms.date: 12/04/2017
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core tools.
---
# .NET Core additional tools
This section compiles a list of tools that support and extend the .Net Core functionality, in addition to the [.NET Core command-line interface (CLI)](..\tools\index.md) tools.


### [WCF Web Service Reference](WCF-Web-Service-Reference-guide.md)
The WCF Web Service Reference is a Visual Studio connected service provider which made its debut in [Visual Studio 2017 version 15.5](https://www.visualstudio.com/en-us/news/releasenotes/vs2017-relnotes#WCFTools). Similarly to the Add Service Reference tool for classic .Net Framework VS projects, it allows for generating a web service reference containing proxy code that makes it easier for a client to consume the web service's functionality.

### [XML Serializer Generator](xmlserializergenerator-instructions.md)
Like the Xml Serializer Generator (sgen.exe) on desktop, Microsoft.XmlSerializer.Generator NuGet package is the solution for .NET Core and .NET Standard Libraries. It creates an Xml serialization assembly for types contained in an assembly to improve the startup performance of Xml serialization when serializing or de-serializing objects of those types using XmlSerializer. 
