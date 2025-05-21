---
description: "Learn more about: Metadata formats"
title: "Metadata Formats"
ms.date: "03/30/2017"
ms.assetid: baad1e68-28fc-4a6a-8a43-75e47e7fa871
ms.topic: article
---
# Metadata formats

Windows Communication Foundation (WCF) supports the metadata formats in the following table.  
  
## Metadata Specifications and Usage  
  
|Protocol|Specification and usage|  
|--------------|-----------------------------|  
|WSDL 1.1|[Web Services Description Language (WSDL) 1.1](https://www.w3.org/TR/wsdl/)<br /><br /> WCF uses Web Services Description Language (WSDL) to describe services.|  
|XML Schema|[XML Schema Part 2: Datatypes Second Edition](https://www.w3.org/TR/2004/REC-xmlschema-2-20041028/) and [XML Schema Part 1: Structures Second Edition](https://www.w3.org/TR/2004/REC-xmlschema-1-20041028/)<br /><br /> WCF uses the XML Schema to describe data types used in messages.|  
|WS Policy|[Web Services Policy 1.2 - Framework (WS-Policy)](https://www.w3.org/Submission/WS-Policy/)<br /><br /> [Web Services Policy 1.5 - Framework](https://www.w3.org/TR/ws-policy/)<br /><br /> WCF uses the WS-Policy 1.2 or 1.5 specifications with domain-specific assertions to describe service requirements and capabilities.|  
|WS Policy Attachments|[Web Services Policy 1.2 - Attachment (WS-PolicyAttachment)](https://www.w3.org/Submission/WS-PolicyAttachment/)<br /><br /> WCF implements WS-Policy Attachments to attach policy expressions at various scopes in WSDL.|  
|WS Metadata Exchange|[Web Services Metadata Exchange (WS-MetadataExchange) version 1.1](http://specs.xmlsoap.org/ws/2004/09/mex/WS-MetadataExchange.pdf)<br /><br /> WCF implements WS-MetadataExchange to retrieve XML Schema, WSDL, and WS-Policy.|  
|WS Addressing Binding for WSDL|[Web Services Addressing 1.0 - WSDL Binding](https://www.w3.org/TR/ws-addr-wsdl/)<br /><br /> WCF implements WS-Addressing Binding for WSDL to attach addressing information in WSDL.|  
  
## See also

- [Web Services Protocols Supported by System-Provided Interoperability Bindings](web-services-protocols-supported-by-system-provided-interoperability-bindings.md)
- [WSDL and Policy](wsdl-and-policy.md)
