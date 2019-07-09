---
title: "IDebugAutoAttach::AutoAttach Method"
ms.date: "03/30/2017"
api_name: 
  - "IDebugAutoAttach.AutoAttach"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDebugAutoAttach::AutoAttach"
helpviewer_keywords: 
  - "AutoAttach method [.NET Framework debugging]"
  - "IDebugAutoAttach::AutoAttach method [.NET Framework debugging]"
ms.assetid: 3cf3bd9c-7d88-4afa-a476-94cdc7609aa6
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IDebugAutoAttach::AutoAttach Method
Performs server-invoked debugger auto attach.  
  
## Syntax  
  
```cpp  
HRESULT AutoAttach  
(  
    [in]  REFGUID   guidPort,  
    [in]  DWORD     dwPid,  
    [in]  AUTOATTACH_PROGRAM_TYPE dwProgramType,  
    [in]  DWORD     dwProgramId,  
    [in]  LPCWSTR   pszSessionId  
);  
```  
  
## Parameters  
 `guidPort`  
 [in] Always set to `GUID_NULL`.  
  
 `dwPid`  
 [in] Process ID, normally retrieved with the `GetCurrentProcessId` function.  
  
 `dwProgramType`  
 [in] Program type: `AUTOATTACH_PROGRAM_WIN32`, `AUTOATTACH_PROGRAM_COMPLUS`, or `AUTOATTACH_PROGRAM_UNKNOWN`.  
  
 `dwProgramId`  
 [in] Program ID.  
  
 `pszSessionId`  
 [in] String passed by the debug verb.  
  
## Return Value  
 S_OK if the method succeeds.  
  
## Requirements  
 **Header:** DbgAutoAttach.h  
  
## See also

- [IDebugAutoAttach Interface](../../../../docs/framework/unmanaged-api/diagnostics/idebugautoattach-interface.md)
