---
title: "Configuration file schema for the .NET Framework"
ms.custom: ""
ms.date: "05/01/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - ".NET Framework application configuration, configuration schema"
  - "machine configuration files"
  - "application configuration files, schema"
  - "app.config files, schema"
  - "schema configuration settings"
  - "schemas, configuration settings"
  - "enterprisesec.config files"
  - "well-formed XML"
  - "enterprisesec configuration files"
  - "security.config files"
  - "security [.NET Framework], configuration files"
  - "application development [.NET Framework], schema"
  - "XML tags"
  - "container tags"
  - "machine.config files"
  - "configuration schema [.NET Framework]"
  - "configuration settings [.NET Framework], applications"
  - "configuration file reference [.NET Framework]"
ms.assetid: 69003d39-dc8a-460c-a6be-e6d93e690b38
caps.latest.revision: 20
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---

# Configuration file schema for the .NET Framework

Configuration files are standard XML files that you can use to change settings and set policies for your apps. The .NET Framework configuration schema consists of elements that you can use in configuration files to control the behavior of your apps. The table of contents for this section reflects the schema hierarchy for startup, runtime, network, and other types of configuration settings.

For information about the types, format, and location of configuration files, see the article [Configuring Apps](~/docs/framework/configure-apps/index.md). Familiarize yourself with XML if you want to edit the configuration files directly.

> [!IMPORTANT]
> XML tags and attributes in configuration files are case-sensitive.

## In this section

[**\<configuration>** Element](~/docs/framework/configure-apps/file-schema/configuration-element.md)
Describes the `<configuration>` element, which is the top-level element for all configuration files.

[**\<assemblyBinding>** Element](~/docs/framework/configure-apps/file-schema/assemblybinding-element-for-configuration.md)
Specifies assembly binding policy at the configuration level.

[**\<linkedConfiguration>** Element](~/docs/framework/configure-apps/file-schema/linkedconfiguration-element.md)
Specifies a configuration file to include.

[Startup Settings Schema](~/docs/framework/configure-apps/file-schema/startup/index.md)
Describes the elements that specify which version of the common language runtime to use.

[Runtime Settings Schema](~/docs/framework/configure-apps/file-schema/runtime/index.md)
Describes the elements that configure assembly binding and runtime behavior.

[Network Settings Schema](~/docs/framework/configure-apps/file-schema/network/index.md)
Describes the elements that specify how the .NET Framework connects to the Internet.

[Cryptography Settings Schema](~/docs/framework/configure-apps/file-schema/cryptography/index.md)
Describes elements that map friendly algorithm names to classes that implement cryptography algorithms.

[Configuration Sections Schema](~/docs/framework/configure-apps/file-schema/configuration-sections-schema.md)
Describes the elements used to create and use configuration sections for custom settings.

[Trace and Debug Settings Schema](~/docs/framework/configure-apps/file-schema/trace-debug/index.md)
Describes the elements that specify trace switches and listeners.

[Compiler and Language Provider Settings Schema](~/docs/framework/configure-apps/file-schema/compiler/index.md)
Describes the elements that specify compiler configuration for available language providers.

[Application Settings Schema](~/docs/framework/configure-apps/file-schema/application-settings-schema.md)
Describes the elements that enable a Windows Forms or ASP.NET application to store and retrieve application-scoped and user-scoped settings.

[App Settings Schema](~/docs/framework/configure-apps/file-schema/appsettings/index.md)
Contains custom application settings, such as file paths, XML Web service URLs, or any other custom configuration information for an application.

[Web Settings Schema](~/docs/framework/configure-apps/file-schema/web/index.md)
All elements in the Web settings schema, which includes elements for configuring how ASP.NET works with a host application such as IIS. Used in *Aspnet.config* files.

[Windows Forms Configuration Schema](winforms/index.md)
All elements in the Windows Forms application configuration section, which includes customizations such as multi-monitor and high DPI support.

[WCF Configuration Schema](~/docs/framework/configure-apps/file-schema/wcf/index.md)
All elements that enable you to configure WCF service and client applications.

[WCF Directive Syntax](~/docs/framework/configure-apps/file-schema/wcf-directive/index.md)
Describes the `@ServiceHost` directive, which defines page-specific attributes used by the .svc compiler.

[WIF Configuration Schema](windows-identity-foundation/index.md)
All elements of the Windows Identity Foundation (WIF) configuration schema.

## Related sections

[Remoting Settings Schema](http://msdn.microsoft.com/library/dc2d1e62-9af7-4ca1-99fd-98b93bb4db9e)
Describes the elements that configure client and server applications that implement remoting.

[ASP.NET Settings Schema](http://msdn.microsoft.com/library/b5ysx397\(v=vs.100\).aspx)
Describes the elements that control the behavior of ASP.NET Web applications.

[Web Services Settings Schema](http://msdn.microsoft.com/library/f84d6d55-1add-4eb7-ae46-33df5833ea2e)
Describes the elements that control the behavior of ASP.NET Web services and their clients.

[Configuring .NET Framework Apps](http://msdn.microsoft.com/library/d789b592-fcb5-4e3d-8ac9-e0299adaaa42)
Describes how to configure security, assembly binding, and remoting in the .NET Framework.
