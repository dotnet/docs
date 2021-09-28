---
description: "Learn more about: CoreClrDebugProcInfo Structure"
title: "CoreClrDebugProcInfo Structure"
ms.date: "03/30/2017"
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
---
# CoreClrDebugProcInfo Structure

Represents a process that is running on a remote machine.  
  
## Syntax  
  
```cpp  
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
