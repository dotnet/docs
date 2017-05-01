---
title: "Configuration sections schema | Microsoft Docs"
ms.date: "05/02/2017"
ms.prod: ".net-framework"
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
  - "CSharp"
  - "C++"
  - "jsharp"
helpviewer_keywords: 
  - "configuration settings [.NET Framework], custom"
  - "schema configuration settings"
  - "configuration sections [.NET Framework]"
  - "custom elements"
  - "configuration schema [.NET Framework], custom settings in configuration files"
  - "elements [.NET Framework], custom settings in configuration files"
ms.assetid: 6e4cc793-c526-4007-b4e9-37d56295f2cb
author: "guardrex"
ms.author: "mairaw"
manager: "wpickett"
---

# Configuration sections schema

The configuration sections schema contains elements that define custom settings in configuration files.

[**\<configuration>**](~/docs/framework/configure-apps/file-schema/configuration-element.md)   
&nbsp;&nbsp;[**\<configSections>**](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<clear>**](~/docs/framework/configure-apps/file-schema/clear-element-for-configsections.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<remove>**](~/docs/framework/configure-apps/file-schema/remove-element-for-configsections.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<section>**](~/docs/framework/configure-apps/file-schema/section-element.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<sectionGroup>**](~/docs/framework/configure-apps/file-schema/sectiongroup-element-for-configsections.md)   
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<section>**](~/docs/framework/configure-apps/file-schema/section-element.md)   
&nbsp;&nbsp;[**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/index.md)   
&nbsp;&nbsp;[Custom element for `SingleTagSectionHandler`](~/docs/framework/configure-apps/file-schema/custom-element-1.md)   
&nbsp;&nbsp;[Custom element for `NameValueSectionHandler` and `DictionarySectionHandler`](~/docs/framework/configure-apps/file-schema/custom-element-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<add>**](~/docs/framework/configure-apps/file-schema/add-element-for-custom-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<remove>**](~/docs/framework/configure-apps/file-schema/remove-element-for-custom-2.md)   
&nbsp;&nbsp;&nbsp;&nbsp;[**\<clear>**](~/docs/framework/configure-apps/file-schema/clear-element-for-custom-2.md)

| Element | Description |
| ------- | ----------- |
| [**\<add>**](~/docs/framework/configure-apps/file-schema/add-element-for-custom-2.md) for <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> | Adds custom application settings. |
| [**\<appSettings>**](~/docs/framework/configure-apps/file-schema/appsettings/index.md) | Contains custom application settings. This is a predefined configuration section provided by the .NET Framework. |
| [**\<clear>** for **\<configSections>**](~/docs/framework/configure-apps/file-schema/clear-element-for-configsections.md) | Clears all previously defined sections and section groups. |
| [**\<clear>**](~/docs/framework/configure-apps/file-schema/clear-element-for-custom-2.md) for <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> | Clears all previously defined settings in a section. |
| [**\<configSections>**](~/docs/framework/configure-apps/file-schema/configsections-element-for-configuration.md) | Contains configuration section and namespace declarations. |
| [Custom](~/docs/framework/configure-apps/file-schema/custom-element-2.md) for <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> | Defines settings for custom configuration sections that use the <xref:System.Configuration.NameValueSectionHandler> or <xref:System.Configuration.DictionarySectionHandler> classes. |
| [Custom](~/docs/framework/configure-apps/file-schema/custom-element-1.md) for <xref:System.Configuration.SingleTagSectionHandler> | Defines settings for custom configuration sections that use the <xref:System.Configuration.SingleTagSectionHandler> class. |
| [**\<remove>** for **\<configSections>**](~/docs/framework/configure-apps/file-schema/remove-element-for-configsections.md) | Removes a predefined section or section group. |
| [**\<remove>**](~/docs/framework/configure-apps/file-schema/remove-element-for-custom-2.md) for <xref:System.Configuration.NameValueSectionHandler> and <xref:System.Configuration.DictionarySectionHandler> | Removes a previously defined setting. |
| [**\<section>** for **\<configSections>** and **\<sectionGroup>**](~/docs/framework/configure-apps/file-schema/section-element.md) | Contains a configuration section declaration. |
| [**\<sectionGroup>** for **\<configSections>**](~/docs/framework/configure-apps/file-schema/sectiongroup-element-for-configsections.md) | Defines a namespace for configuration sections. |

## See also

[Configuration file schema for the .NET Framework](~/docs/framework/configure-apps/file-schema/index.md)
