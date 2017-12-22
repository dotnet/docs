---
title: "AppDomainInfo"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6610b7d8-81eb-4bec-a543-9b72ad7b6f73
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AppDomainInfo
Application domain information  
  
## Syntax  
  
```  
class AppDomainInfo  
{  
  sint32 AppDomainId;  
  boolean IsDefault;  
  boolean LogMalformedMessages;  
  boolean LogMessagesAtServiceLevel;  
  boolean LogMessagesAtTransportLevel;  
  TraceListener MessageLoggingTraceListeners[];  
  string Name;  
  string PerformanceCounters;  
  sint32 ProcessId;  
  string ServiceConfigPath;  
  string TraceLevel;  
  TraceListener wmiTraceListeners[];  
};  
```  
  
## Methods  
 The AppDomainInfo class does not define any methods.  
  
## Properties  
 The AppDomainInfo class has the following properties:  
  
### AppDomainId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The Id of the appdomain.  
  
### IsDefault  
 Data type: boolean  
  
 Access type: Read-only  
  
 Indicates whether the appdomain is the default appdomain.  
  
### LogMalformedMessages  
 Data type: boolean  
  
 Access type: Read/Write  
  
 A value that specifies whether malformed messages are logged.  
  
### LogMessagesAtServiceLevel  
 Data type: boolean  
  
 Access type: Read/Write  
  
 A value that specifies whether messages are traced at the service level (before encryption and transport-related transforms).  
  
### LogMessagesAtTransportLevel  
 Data type: boolean  
  
 Access type: Read/Write  
  
 A value that specifies whether messages are traced at the transport level.  
  
### MessageLoggingTraceListeners  
 Data type: TraceListener array  
  
 Access type: Read-only  
  
 The collection trace listeners that listen to the System.Wmi.MessageLogging trace source.  
  
### Name  
 Data type: string  
  
 Access type: Read-only  
  
 The name of the appdomain.  
  
### PerformanceCounters  
 Data type: string  
  
 Access type: Read-only  
  
 The scope of active performance counters in the appdomain.  
  
### ProcessId  
 Data type: sint32  
  
 Access type: Read-only  
  
 The process Id.  
  
### ServiceConfigPath  
 Data type: string  
  
 Access type: Read-only  
  
 The path to the configuration of the service.  
  
### TraceLevel  
 Data type: string  
  
 Access type: Read/Write  
  
 The trace level of the System.Wmi trace source.  
  
### ServiceModelTraceListeners  
 Data type: TraceListener array  
  
 Access type: Read-only  
  
 A collection of listeners from the System.ServiceModel trace source.  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
