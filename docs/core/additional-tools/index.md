---
title: .NET Core additional tools
description: An overview of the additional tools that support and extend .NET Core functionality.
author: mlacouture
manager: wpickett
ms.author: johalex
ms.date: 01/19/2018
ms.topic: article
ms.prod: .net-core
ms.custom: mvc
---
# .NET Core additional tools
This section compiles a list of tools that support and extend the .NET Core functionality, in addition to the [.NET Core command-line interface (CLI)](..\tools\index.md) tools.

### [WCF Web Service Reference Tool](wcf-web-service-reference-guide.md)
The WCF Web Service Reference is a Visual Studio connected service provider that made its debut in [Visual Studio 2017 version 15.5](https://www.visualstudio.com/news/releasenotes/vs2017-relnotes#WCFTools). The WCF Web Service Reference Tool generates a web service reference containing proxy code for a client to easily consume the web service's functionality, similar to the Add Service Reference tool for .NET Framework Visual Studio projects.

### [XML Serializer Generator](xmlserializergenerator-instructions.md)
Like the [Xml Serializer Generator (sgen.exe)](../../standard/serialization/xml-serializer-generator-tool-sgen-exe.md) for the .NET Framework, the [Microsoft.XmlSerializer.Generator NuGet package](https://www.nuget.org/packages/Microsoft.XmlSerializer.Generator) is the solution for .NET Core and .NET Standard libraries. It creates an XML serialization assembly for types contained in an assembly to improve the startup performance of XML serialization when serializing or de-serializing objects of those types using <xref:System.Xml.Serialization.XmlSerializer>.
