---
description: "Learn more about: NamedPipeConnectionPoolSettings"
title: "NamedPipeConnectionPoolSettings"
ms.date: "03/30/2017"
ms.assetid: 079bccb8-54b5-4436-a43d-5567763f72ce
---
# NamedPipeConnectionPoolSettings

NamedPipeConnectionPoolSettings  
  
## Syntax  
  
```csharp
class NamedPipeConnectionPoolSettings  
{  
  string GroupName;  
  datetime IdleTimeout;  
  sint32 MaxOutboundConnectionsPerEndpoint;  
};  
```  
  
## Methods  

 The NamedPipeConnectionPoolSettings class does not define any methods.  
  
## Properties  

 The NamedPipeConnectionPoolSettings class has the following properties:  
  
### GroupName  

 Data type: string  
  
 Access type: Read-only  
  
 The group name of the connection pool used by the binding element.  
  
### IdleTimeout  

 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum time the connection can be idle before being disconnected.  
  
### MaxOutboundConnectionsPerEndpoint  

 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of outbound connections for each endpoint on the client.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.NamedPipeConnectionPoolSettings>
