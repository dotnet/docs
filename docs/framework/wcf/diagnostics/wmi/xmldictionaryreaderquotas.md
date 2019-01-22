---
title: "XmlDictionaryReaderQuotas"
ms.date: "03/30/2017"
ms.assetid: 9b4ca8b4-0a89-4758-97ab-528a8ce18f07
---
# XmlDictionaryReaderQuotas
XmlDictionaryReaderQuotas  
  
## Syntax  
  
```csharp
class XmlDictionaryReaderQuotas  
{  
  sint32 MaxArrayLength;  
  sint32 MaxBytesPerRead;  
  sint32 MaxDepth;  
  sint32 MaxNameTableCharCount;  
  sint32 MaxStringContentLength;  
};  
```  
  
## Methods  
 The XmlDictionaryReaderQuotas class does not define any methods.  
  
## Properties  
 The XmlDictionaryReaderQuotas class has the following properties:  
  
### MaxArrayLength  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum allowed array length.  
  
### MaxBytesPerRead  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum allowed bytes returned for each read.  
  
### MaxDepth  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum nested node depth for each read.  
  
### MaxNameTableCharCount  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum characters allowed in a table name.  
  
### MaxStringContentLength  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum characters allowed in XML element content.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also
 <xref:System.Xml.XmlDictionaryReaderQuotas>  
 <xref:System.ServiceModel.Configuration.XmlDictionaryReaderQuotasElement>
