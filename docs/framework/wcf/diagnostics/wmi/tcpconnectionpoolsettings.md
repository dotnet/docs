---
title: "TcpConnectionPoolSettings"
ms.date: "03/30/2017"
ms.assetid: 19acfba3-c057-4dbc-bac7-8674d7844d83
---
# TcpConnectionPoolSettings
TcpConnectionPoolSettings  
  
## Syntax  
  
```csharp
class TcpConnectionPoolSettings  
{  
  string GroupName;  
  datetime IdleTimeout;  
  datetime LeaseTimeout;  
  sint32 MaxOutboundConnectionsPerEndpoint;  
};  
```  
  
## Methods  
 The TcpConnectionPoolSettings class does not define any methods.  
  
## Properties  
 The TcpConnectionPoolSettings class has the following properties:  
  
### GroupName  
 Data type: string  
  
 Access type: Read-only  
  
 The group name of the connection pool used by the binding element.  
  
### IdleTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum time the connection can be idle before being disconnected.  
  
### LeaseTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum time for the lease operation to complete before timing out.  
  
### MaxOutboundConnectionsPerEndpoint  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum outbound connections for each endpoint.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See also

- <xref:System.ServiceModel.Channels.TcpConnectionPoolSettings>
