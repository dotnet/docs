---
title: "Extending the Metadata System"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "extending metadata [WCF]"
ms.assetid: 8c6b3b00-61b8-4589-8fa5-546cc33719bf
---
# Extending the Metadata System
The Windows Communication Foundation (WCF) metadata system is a group of classes and interfaces that represent metadata required to implement service-based applications. Modify or extend the classes or implement and configure the interfaces to export and import custom metadata such as Web Services Description Language (WSDL) extensions or custom WS-PolicyAttachments assertions.  
  
## In This Section  
 [Exporting Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/exporting-custom-metadata-for-a-wcf-extension.md)  
 Describes how to implement and use the <xref:System.ServiceModel.Description.IPolicyExportExtension?displayProperty=nameWithType> interface to embed custom policy assertions in WSDL documents.  
  
 [Importing Custom Metadata for a WCF Extension](../../../../docs/framework/wcf/extending/importing-custom-metadata-for-a-wcf-extension.md)  
 Describes how to implement and use the <xref:System.ServiceModel.Description.IPolicyImportExtension?displayProperty=nameWithType> interface to read and respond to custom policy assertions in WSDL documents.  
  
 [Publishing and Retrieving Metadata Over a Custom Binding](../../../../docs/framework/wcf/extending/publishing-and-retrieving-metadata-over-a-custom-binding.md)  
 Describes how to exchange metadata over custom bindings.
