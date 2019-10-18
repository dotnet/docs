---
title: "InitDbgTransportManager Function"
ms.date: "03/30/2017"
api_name: 
  - "InitDbgTransportManager"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "InitDbgTransportManager"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "InitDbgTransportManager function"
  - "Silverlight, remote debugging"
ms.assetid: a30102ff-c52e-48c9-b3a9-aa14286a42b2
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# InitDbgTransportManager Function
Initializes the transport manager to connect to a remote target for process and runtime enumeration.  
  
## Syntax  
  
```cpp  
HRESULT InitDbgTransportManager ();  
```  
  
## Return Value  
 S_OK  
 Success.  
  
 E_OUTOFMEMORY  
 The function was unable to allocate memory for a transport manager.  
  
 E_FAIL (or other E_ return codes)  
 Other failures.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
