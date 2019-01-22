---
title: "BinaryMessageEncodingBindingElement"
ms.date: "03/30/2017"
ms.assetid: e2bb3cdd-3bbd-4bb5-85fe-570457500a66
---
# BinaryMessageEncodingBindingElement
BinaryMessageEncodingBindingElement  
  
## Syntax  
  
```csharp  
class BinaryMessageEncodingBindingElement : MessageEncodingBindingElement  
{  
  sint32 MaxReadPoolSize;  
  sint32 MaxSessionSize;  
  sint32 MaxWritePoolSize;  
  XmlDictionaryReaderQuotas ReaderQuotas;  
};  
```  
  
## Methods  
 The BinaryMessageEncodingBindingElement class does not define any methods.  
  
## Properties  
 The BinaryMessageEncodingBindingElement class has the following properties.  
  
## MaxReadPoolSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 An integer that defines how many messages can be read simultaneously without allocating new readers.  
  
## MaxSessionSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 A value that specifies the size, in bytes, of the buffer used for encoding.  
  
## MaxWritePoolSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 An integer that defines how many messages can be sent simultaneously without allocating new writers.  
  
## ReaderQuotas  
 Data type: XmlDictionaryReaderQuotas  
  
 Access type: Read-only  
  
 The quotas of the readers.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also
- <xref:System.ServiceModel.Channels.BinaryMessageEncodingBindingElement>
