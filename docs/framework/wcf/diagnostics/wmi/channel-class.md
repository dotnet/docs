---
title: "Channel class"
ms.date: "03/30/2017"
ms.assetid: d9fae2ca-209c-4341-a0f5-6b79d1a67776
---
# Channel class
Channel  
  
## Syntax  
  
```csharp
class Channel  
{  
  string LocalAddress;  
  Endpoint ref;  
  string RemoteAddress;  
  string SessionId;  
  string Type;  
};  
```  
  
## Methods  
 The Channel class does not define any methods.  
  
## Properties  
 The Channel class has the following properties.  
  
### LocalAddress  
 Data type: string  
  
 Access type: Read-only  
  
 The local endpoint for the channel.  
  
### ref  
 Data type: Endpoint  
  
 Access type: Read-only  
  
 A reference to the endpoint the channel connects to.  
  
### RemoteAddress  
 Data type: string  
  
 Access type: Read-only  
  
 The remote address associated with the channel.  
  
### SessionId  
 Data type: string  
  
 Access type: Read-only  
  
 The current session Id, if any.  
  
### Type  
 Data type: string  
  
 Access type: Read-only  
  
 The type of the channel.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.ChannelBase>
