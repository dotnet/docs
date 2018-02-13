---
title: "LocalServiceSecuritySettings"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 490aa0e5-5242-4f8d-b505-5ec6287633b4
caps.latest.revision: 8
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# LocalServiceSecuritySettings
LocalServiceSecuritySettings  
  
## Syntax  
  
```  
class LocalServiceSecuritySettings  
{  
  boolean DetectReplays;  
  datetime InactivityTimeout;  
  datetime IssuedCookieLifetime;  
  sint32 MaxCachedCookies;  
  datetime MaxClockSkew;  
  sint32 MaxPendingSessions;  
  sint32 MaxStatefulNegotiations;  
  datetime NegotiationTimeout;  
  boolean ReconnectTransportOnFailure;  
  sint32 ReplayCacheSize;  
  datetime ReplayWindow;  
  datetime SessionKeyRenewalInterval;  
  datetime SessionKeyRolloverInterval;  
  datetime TimestampValidityDuration;  
};  
```  
  
## Methods  
 The LocalServiceSecuritySettings class does not define any methods.  
  
## Properties  
 The LocalServiceSecuritySettings class has the following properties:  
  
### DetectReplays  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether replay attacks against the channel are detected and dealt with automatically.  
  
### InactivityTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 The maximum number of pending security sessions that the service supports.  
  
### IssuedCookieLifetime  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the lifetime issued to all new security cookies.  
  
### MaxCachedCookies  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of cookies that can be cached.  
  
### MaxClockSkew  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the maximum time difference between the system clocks of the two communicating parties.  
  
### MaxPendingSessions  
 Data type: sint32  
  
 Access type: Read-only  
  
 The maximum number of pending connections on the service.  
  
### MaxStatefulNegotiations  
 Data type: sint32  
  
 Access type: Read-only  
  
 The number of security negotiations that can be active concurrently.  
  
### NegotiationTimeout  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the maximum duration for the security negotiation phase between server and client.  
  
### ReconnectTransportOnFailure  
 Data type: boolean  
  
 Access type: Read-only  
  
 A Boolean value that specifies whether connections using WS-Reliable messaging attempt to reconnect after transport failures.  
  
### ReplayCacheSize  
 Data type: sint32  
  
 Access type: Read-only  
  
 The number of cached nonces used for replay detection.  
  
### ReplayWindow  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the duration in which individual message nonces are valid.  
  
### SessionKeyRenewalInterval  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the duration after which the initiator renews the key for the security session.  
  
### SessionKeyRolloverInterval  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the time interval a previous session key is valid on incoming messages during a key renewal.  
  
### TimestampValidityDuration  
 Data type: datetime  
  
 Access type: Read-only  
  
 A TimeSpan that specifies the duration in which a time stamp is valid.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|  
  
## See Also  
 <xref:System.ServiceModel.Channels.LocalServiceSecuritySettings>
