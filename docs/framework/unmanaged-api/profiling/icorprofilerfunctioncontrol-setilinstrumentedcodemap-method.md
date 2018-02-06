---
title: "ICorProfilerFunctionControl::SetILInstrumentedCodeMap Method"
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
  - "ICorProfilerFunctionControl.SetILInstrumentedCodeMap"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerFunctionControl::SetILInstrumentedCodeMap"
helpviewer_keywords: 
  - "ICorProfilerFunctionControl::SetILInstrumentedCodeMap method [.NET Framework profiling]"
  - "SetIILInstrumentedCodeMap method, ICorProfilerFunctionControl interface [.NET Framework profiling]"
ms.assetid: ecf56646-7e5f-46c4-8340-f3a04e88920f
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerFunctionControl::SetILInstrumentedCodeMap Method
Sets a code map for the specified function by using the specified Common Intermediate Language (CIL) map entries.  
  
## Syntax  
  
```  
HRESULT SetILInstrumentedCodeMap(  
    [in]   ULONG      cILMapEntries,  
    [in, size_is(cILMapEntries)] COR_IL_MAP rgILMapEntries[]);  
```  
  
#### Parameters  
 `cILMapEntries`  
 [in] The number of entries in the map.  
  
 `rgILMapEntries`  
 [in] The caller-allocated array of COR_IL_MAP  entries. The interpretation of these entries is the same as for the [ICorProfilerInfo::SetILInstrumentedCodeMap](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-setilinstrumentedcodemap-method.md) method.  
  
## Remarks  
 Setting the mapping by calling this method allows the debugger to retrieve the mapping by calling [ICorDebugILCode2::GetInstrumentedILMap](../../../../docs/framework/unmanaged-api/debugging/icordebugilcode2-getinstrumentedilmap-method.md). It also allows the debugger to use the mapping internally when calculating IL offsets for stack traces and variable lifetimes.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
