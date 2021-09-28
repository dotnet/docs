---
description: "Learn more about: TcpTransportBindingElement"
title: "TcpTransportBindingElement"
ms.date: "03/30/2017"
ms.assetid: 33bbc1e5-44e4-4ee3-b7b5-801dc78956e4
---
# TcpTransportBindingElement

TcpTransportBindingElement  
  
## Syntax  
  
```csharp
class TcpTransportBindingElement : ConnectionOrientedTransportBindingElement  
{  
  TcpConnectionPoolSettings ConnectionPoolSettings;  
  sint32 ListenBacklog;  
  boolean PortSharingEnabled;  
  boolean TeredoEnabled;  
};  
```  
  
## Methods  

 The TcpTransportBindingElement class does not define any methods.  
  
## Properties  

 The TcpTransportBindingElement class has the following properties:  
  
### ConnectionPoolSettings  

 Data type: TcpConnectionPoolSettings  
  
 Access type: Read-only  
  
 The connection pool settings.  
  
### ListenBacklog  

 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of queued connection requests that can be pending.  
  
### PortSharingEnabled  

 Data type: boolean  
  
 Access type: Read-only  
  
 A boolean value that specifies whether TCP port sharing is enabled for this connection.  
  
### TeredoEnabled  

 Data type: boolean  
  
 Access type: Read-only  
  
 A boolean value that specifies whether Teredo (a technology for addressing clients that are behind firewalls) is enabled.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.TcpTransportBindingElement>
