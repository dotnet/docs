---
title: "IDebugAutoAttach::AutoAttach Method"
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
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDebugAutoAttach::AutoAttach Method
Performs server-invoked debugger auto attach.  
  
## Syntax  
  
```  
HRESULT AutoAttach  
(  
    [in]  REFGUID   guidPort,  
    [in]  DWORD     dwPid,  
    [in]  AUTOATTACH_PROGRAM_TYPE dwProgramType,  
    [in]  DWORD     dwProgramId,  
    [in]  LPCWSTR   pszSessionId  
);  
```  
  
#### Parameters  
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
  
## See Also  
 [IDebugAutoAttach Interface](../../../../docs/framework/unmanaged-api/diagnostics/idebugautoattach-interface.md)
