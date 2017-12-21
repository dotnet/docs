---
title: "Trace Type Summary"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e639410b-d1d1-479c-b78e-a4701d4e4085
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Trace Type Summary
[Source Levels](http://go.microsoft.com/fwlink/?LinkID=94943) defines various trace levels: Critical, Error, Warning, Information, and Verbose, as well as provides description of the `ActivityTracing` flag, which toggles the output of trace boundary and activity transfer events.  
  
 You can also review [TraceEventType](http://go.microsoft.com/fwlink/?LinkId=95169) for the types of traces which can be emitted from <xref:System.Diagnostics>.  
  
 The following table lists the most important ones.  
  
|Trace Type|Description|  
|----------------|-----------------|  
|Critical|Fatal error or application crash.|  
|Error|Recoverable error.|  
|Warning|Informational message.|  
|Information|Non-critical problem.|  
|Verbose|Debugging trace.|  
|Start|Starting of a logical unit of processing.|  
|Suspend|Suspension of a logical unit of processing.|  
|Resume|Resumption of a logical unit of processing.|  
|Stop|Stopping of a logical unit of processing.|  
|Transfer|Changing of correlation identity.|  
  
 An activity is defined as a combination of the trace types above.  
  
 The following is a regular expression that defines an ideal activity in a local (trace source) scope,  
  
 `R = Start (Critical | Error | Warning | Information | Verbose | Transfer | (Transfer Suspend Transfer Resume) )* Stop`  
  
 This means that an activity must satisfy the following conditions.  
  
-   It must start and stop respectively by a Start and Stop traces  
  
-   It must have a Transfer trace immediately preceding a Suspend or Resume trace  
  
-   It must not have any traces between the Suspend and Resume traces if such traces exist  
  
-   It can have any and as many of critical/Error/Warning/Information/Verbose/Transfer traces as long as the previous conditions are observed  
  
 The following is a regular expression that defines an ideal activity in the global scope,  
  
```  
R+   
```  
  
 with R being the regular expression for an activity in the local scope. This translates to,  
  
```  
[R+ = Start ( Critical | Error | Warning | Information | Verbose | Transfer | (Transfer Suspend Transfer Resume) )* Stop]+  
```
