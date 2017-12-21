---
title: "WSAT_TraceRecord"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 99bc7f66-1335-40d8-aa68-e754d569dc0d
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WSAT_TraceRecord
WSAT_TraceRecord  
  
## Syntax  
  
```  
class WSAT_TraceRecord : WSAT_TraceEvent  
{  
  object ActivityID;  
  sint32 EventID;  
  string TraceRecord;  
};  
```  
  
## Methods  
 The WSAT_TraceRecord class does not define any methods.  
  
## Properties  
 The WSAT_TraceRecord class has the following properties:  
  
### ActivityID  
 Data type: object  
Access type: Read-only  
  
 The activity ID of the trace record.  
  
### EventID  
 Data type: sint32  
Access type: Read-only  
  
 The event ID of the trace record.  
  
### TraceRecord  
 Data type: string  
Access type: Read-only  
  
 Trace Record  
  
## Requirements  
  
|MOF|Declared in Servicemodel.mof.|  
|---------|-----------------------------------|  
|Namespace|Defined in root\ServiceModel|
