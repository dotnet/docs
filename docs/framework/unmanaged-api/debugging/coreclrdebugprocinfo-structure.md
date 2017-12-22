---
title: "CoreClrDebugProcInfo Structure"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CoreClrDebugProcInfo"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CoreClrDebugProcInfo"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "CoreClrDebugProcInfo structure"
  - "Silverlight, remote debugging"
ms.assetid: 4ddc37da-5c94-4beb-b61c-b54071c0e749
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CoreClrDebugProcInfo Structure
Represents a process that is running on a remote machine.  
  
## Syntax  
  
```  
struct  CoreClrDebugProcInfo {  
    DWORD m_dwPID;  
    DWORD m_dwInternalID;  
    WCHAR m_wszName[256];  
};  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`m_dwPID`|OS-assigned process identifier.|  
|`m_dwInternalID`|Process identifier that is assigned by the remote debugging proxy running on the target machine. This identifier recycles less often than the OS identifier.|  
|`m_wszName`|Command-line of the process. This member may be truncated.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
