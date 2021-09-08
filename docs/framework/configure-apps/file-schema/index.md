---
description: "Learn more about: Configuration file schema for the .NET Framework"
title: "Configuration file schema for the .NET Framework"
ms.date: "05/01/2017"
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
---
# Configuration file schema for the .NET Framework

Configuration files are standard XML files that you can use to change settings and set policies for your apps. The .NET Framework configuration schema consists of elements that you can use in configuration files to control the behavior of your apps. The table of contents for this section reflects the schema hierarchy for startup, runtime, network, and other types of configuration settings.

For information about the types, format, and location of configuration files, see [Configure apps](../index.md). Familiarize yourself with XML if you want to edit the configuration files directly.

> [!IMPORTANT]
> XML tags and attributes in configuration files are case-sensitive.

## In this section

[**\<configuration>** Element](configuration-element.md)\
The top-level element for all configuration files.

[**\<assemblyBinding>** Element](assemblybinding-element-for-configuration.md)\
Specifies assembly binding policy at the configuration level.

[**\<linkedConfiguration>** Element](linkedconfiguration-element.md)\
Specifies a configuration file to include.

[Startup Settings Schema](./startup/index.md)\
Elements that specify which version of the common language runtime to use.

[Runtime Settings Schema](./runtime/index.md)\
Elements that configure assembly binding and runtime behavior.

[Network Settings Schema](./network/index.md)\
Elements that specify how the .NET Framework connects to the internet.

[Cryptography Settings Schema](./cryptography/index.md)\
Elements that map friendly algorithm names to classes that implement cryptography algorithms.

[Configuration Sections Schema](configuration-sections-schema.md)\
Elements used to create and use configuration sections for custom settings.

[Trace and Debug Settings Schema](./trace-debug/index.md)\
Elements that specify trace switches and listeners.

[Compiler and Language Provider Settings Schema](./compiler/index.md)\
Elements that specify compiler configuration for available language providers.

[Application Settings Schema](application-settings-schema.md)\
Elements that enable a Windows Forms or ASP.NET application to store and retrieve application-scoped and user-scoped settings.

[App Settings Schema](./appsettings/index.md)\
Contains custom application settings, such as file paths, XML Web service URLs, or any other custom configuration information for an application.

[Web Settings Schema](./web/index.md)\
Elements for configuring how ASP.NET works with a host application such as IIS. Used in *Aspnet.config* files.

[Windows Forms Configuration Schema](winforms/index.md)\
All elements in the Windows Forms application configuration section, which includes customizations such as multi-monitor and high-DPI support.

[WCF Configuration Schema](./wcf/index.md)\
All elements that enable you to configure WCF service and client applications.

[WCF Directive Syntax](./wcf-directive/index.md)\
Describes the `@ServiceHost` directive, which defines page-specific attributes used by the .svc compiler.

## Related sections

[Remoting Settings Schema](/previous-versions/dotnet/netframework-4.0/z415cf9a(v=vs.100))\
Describes the elements that configure client and server applications that implement remoting.

[ASP.NET Settings Schema](/previous-versions/dotnet/netframework-4.0/b5ysx397(v=vs.100))\
Describes the elements that control the behavior of ASP.NET Web applications.

[Web Services Settings Schema](/previous-versions/dotnet/netframework-4.0/cctwteet(v=vs.100))\
Describes the elements that control the behavior of ASP.NET Web services and their clients.

[Configuring .NET Framework Apps](/previous-versions/dotnet/netframework-4.0/kza1yk3a(v=vs.100))\
Describes how to configure security, assembly binding, and remoting in the .NET Framework.
