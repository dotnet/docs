---
description: "Learn more about: MsmqTransportBindingElement"
title: "MsmqTransportBindingElement"
ms.date: "03/30/2017"
ms.assetid: 1c89f073-9ed3-4025-a8c5-13535a0f526b
---
# MsmqTransportBindingElement

MsmqTransportBindingElement  
  
## Syntax  
  
```csharp
class MsmqTransportBindingElement : MsmqBindingElementBase  
{  
  sint32 MaxPoolSize;  
  string QueueTransferProtocol;  
  boolean UseActiveDirectory;  
};  
```  
  
## Methods  

 The MsmqTransportBindingElement class does not define any methods.  
  
## Properties  

 The MsmqTransportBindingElement class has the following properties:  
  
### MaxPoolSize  

 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum size of the pool that contains internal MSMQ message objects.  
  
### QueueTransferProtocol  

 Data type: string  
  
 Access type: Read-only  
  
 An enumeration value that indicates the queued communication channel transport that this binding uses.  
  
### UseActiveDirectory  

 Data type: boolean  
  
 Access type: Read-only  
  
 Returns a Boolean value that indicates whether queue addresses should be converted using Active Directory.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.MsmqTransportBindingElement>
