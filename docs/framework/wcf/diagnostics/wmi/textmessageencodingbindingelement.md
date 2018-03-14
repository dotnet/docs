---
title: "TextMessageEncodingBindingElement"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 885e2d7a-3436-4093-bc5f-0a404c62acdc
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# TextMessageEncodingBindingElement
TextMessageEncodingBindingElement  
  
## Syntax  
  
```  
class TextMessageEncodingBindingElement : MessageEncodingBindingElement  
{  
  string Encoding;  
  sint32 MaxReadPoolSize;  
  sint32 MaxWritePoolSize;  
  XmlDictionaryReaderQuotas ReaderQuotas;  
};  
```  
  
## Methods  
 The TextMessageEncodingBindingElement class does not define any methods.  
  
## Properties  
 The TextMessageEncodingBindingElement class has the following properties:  
  
### Encoding  
 Data type: string  
  
 Access type: Read-only  
  
 The character set encoding to be used for emitting messages on the binding.  
  
### MaxReadPoolSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 An integer that defines how many messages can be read simultaneously without allocating new readers.  
  
### MaxWritePoolSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 An integer that defines how many messages can be sent simultaneously without allocating new writers.  
  
### ReaderQuotas  
 Data type: XmlDictionaryReaderQuotas  
  
 Access type: Read-only  
  
 The quotas of the readers.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.TextMessageEncodingBindingElement>
