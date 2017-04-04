---
title: "ICorProfilerInfo::GetFunctionFromIP Method | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework-4.6"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
apiname: 
  - "ICorProfilerInfo.GetFunctionFromIP"
apilocation: 
  - "mscorwks.dll"
apitype: "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetFunctionFromIP"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "GetFunctionFromIP method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetFunctionFromIP method [.NET Framework profiling]"
ms.assetid: f069802a-198f-46dd-9f09-4f77adffc9ba
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# ICorProfilerInfo::GetFunctionFromIP Method
Maps a managed code instruction pointer to a `FunctionID`.  
  
## Syntax  
  
```  
HRESULT GetFunctionFromIP(  
    [in]  LPCBYTE    ip,  
    [out] FunctionID *pFunctionId);  
```  
  
#### Parameters  
 `ip`  
 [in] The instruction pointer in managed code.  
  
 `pFunctionId`  
 [out] The returned function ID.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)