---
title: "TransportBindingElement"
ms.date: "03/30/2017"
ms.assetid: 54ecfbee-53c0-410c-a7fa-a98f2e40c545
---
# TransportBindingElement
TransportBindingElement  
  
## Syntax  
  
```csharp
class TransportBindingElement : BindingElement  
{  
  boolean ManualAddressing;  
  sint64 MaxBufferPoolSize;  
  sint64 MaxReceivedMessageSize;  
  string Scheme;  
};  
```  
  
## Methods  
 The TransportBindingElement class does not define any methods.  
  
## Properties  
 The TransportBindingElement class has the following properties:  
  
### ManualAddressing  
 Data type: boolean  
  
 Access type: Read-only  
  
 A boolean value that specifies whether the user wants to take control of message addressing.  
  
### MaxBufferPoolSize  
 Data type: sint64  
  
 Access type: Read-only  
  
 The maximum buffer pool size for the binding.  
  
### MaxReceivedMessageSize  
 Data type: sint64  
  
 Access type: Read-only  
  
 The maximum size for a message that is processed by this binding.  
  
### Scheme  
 Data type: string  
  
 Access type: Read-only  
  
 The URI scheme for the transport.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.TransportBindingElement>
