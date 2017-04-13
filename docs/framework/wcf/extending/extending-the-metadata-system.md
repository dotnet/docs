---
title: "Extending the Metadata System | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "extending metadata [WCF]"
ms.assetid: 8c6b3b00-61b8-4589-8fa5-546cc33719bf
caps.latest.revision: 8
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# Extending the Metadata System
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] metadata system is a group of classes and interfaces that represent metadata required to implement service-based applications. Modify or extend the classes or implement and configure the interfaces to export and import custom metadata such as Web Services Description Language (WSDL) extensions or custom WS-PolicyAttachments assertions.  
  
## In This Section  
 [Exporting Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/exporting-custom-metadata-for-a-wcf-extension.md)  
 Describes how to implement and use the <xref:System.ServiceModel.Description.IPolicyExportExtension?displayProperty=fullName> interface to embed custom policy assertions in WSDL documents.  
  
 [Importing Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/importing-custom-metadata-for-a-wcf-extension.md)  
 Describes how to implement and use the <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=fullName> interface to read and respond to custom policy assertions in WSDL documents.  
  
 [Publishing and Retrieving Metadata Over a Custom Binding](../../../../docs/framework/wcf/extending/publishing-and-retrieving-metadata-over-a-custom-binding.md)  
 Describes how to exchange metadata over custom bindings.