---
description: "Learn more about: CoreClrDebugRuntimeInfo Structure"
title: "CoreClrDebugRuntimeInfo Structure"
ms.date: "03/30/2017"
api_name: 
  - "CoreClrDebugRuntimeInfo"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CoreClrDebugRuntimeInfo"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "CoreDebugRuntimeInfo structure"
  - "Silverlight, remote debugging"
ms.assetid: bd01c30f-b7a8-4179-9497-622b6599b1a6
topic_type: 
  - "apiref"
---
# CoreClrDebugRuntimeInfo Structure

Represents a common language runtime (CLR) instance that is loaded in a process on a remote machine.  
  
## Syntax  
  
```cpp  
struct  CoreClrDebugRuntimeInfo {  
    DWORD m_dwInternalID;  
};  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`m_dwInternalID`|Runtime identifier that is assigned by the remote debugging proxy running on the target machine.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
