---
title: "GetTypeLibInfo Function"
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
  - "GetTypeLibInfo"
api_location: 
  - "TlbRef.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetTypeLibInfo"
helpviewer_keywords: 
  - "GetTypeLibInfo function [.NET Framework]"
ms.assetid: a1c4d165-9bdc-4ca8-940e-292d4ffcc338
topic_type: 
  - "apiref"
caps.latest.revision: 16
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetTypeLibInfo Function
Returns information about the specified type library by examining its [TLIBATTR](https://msdn.microsoft.com/library/ms221376\(v=vs.85\).aspx) structure.  
  
## Syntax  
  
```  
HRESULT GetTypeLibInfo(  
    [in]   LPWSTR     szFile,  
    [out]  GUID      *pTypeLibID,  
    [out]  LCID      *pTypeLibLCID,  
    [out]  SYSKIND   *pTypeLibPlatform,  
    [out]  USHORT    *pTypeLibMajorVer,  
    [out]  USHORT    *pTypeLibMinorVer  
);  
```  
  
#### Parameters  
 `szFile`  
 [in] The file name of the type library.  
  
 `pTypeLibID`  
 [out] The GUID of the type library.  
  
 `pTypeLibLCID`  
 [out] The localization ID of the type library.  
  
 `pTypeLibPlatform`  
 [out] A [SYSKIND](https://msdn.microsoft.com/library/ms221272\(v=vs.85\).aspx) flag that identifies the target operating system for the type library. Common values are SYS_WIN32 and SYS_WIN64.  
  
 `pTypeLibMajorVer`  
 [out] The major version number of the type library. For example, for version *x.y*, the major version number is *x*.  
  
 `pTypeLibMinorVer`  
 [out] The minor version number of the type library. For example, for version *x.y*, the minor version number is *y*.  
  
## Remarks  
 The `GetTypeLibInfo` function is called by the [Tlbexp.exe (Type Library Exporter)](../../../../docs/framework/tools/tlbexp-exe-type-library-exporter.md). This tool generates a type library that describes the types in a common language runtime (CLR) assembly.  
  
 If any parameter is null, the function returns an `HRESULT` of `E_POINTER`. Otherwise, it returns `S_OK`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** TlbRef.h  
  
 **Library:** TlbRef.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Tlbexp Helper Functions](../../../../docs/framework/unmanaged-api/tlbexp/index.md)  
 [LoadTypeLibEx Function](https://msdn.microsoft.com/library/ms221249\(v=vs.85\).aspx)
