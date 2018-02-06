---
title: "ICorProfilerInfo::GetILFunctionBody Method"
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
  - "ICorProfilerInfo.GetILFunctionBody"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetILFunctionBody"
helpviewer_keywords: 
  - "GetILFunctionBody method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetILFunctionBody method [.NET Framework profiling]"
ms.assetid: e29b46bc-5fdc-4894-b0c2-619df4b65ded
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo::GetILFunctionBody Method
Gets a pointer to the body of a method in Microsoft intermediate language (MSIL) code, starting at its header.  
  
## Syntax  
  
```  
HRESULT GetILFunctionBody(  
    [in]  ModuleID    moduleId,  
    [in]  mdMethodDef methodId,  
    [out] LPCBYTE     *ppMethodHeader,  
    [out] ULONG       *pcbMethodSize);  
```  
  
#### Parameters  
 `moduleId`  
 [in] The ID of the module in which the function resides.  
  
 `methodId`  
 [in] The metadata token for the method.  
  
 `ppMethodHeader`  
 [out] A pointer to the method's header.  
  
 `pcbMethodSize`  
 [out] An integer that specifies the size of the method.  
  
## Remarks  
 A method is scoped by the module in which it lives. Because the `GetILFunctionBody` method is designed to give a tool access to the MSIL code before it has been loaded by the common language runtime (CLR), it uses the metadata token of the method to find the desired instance.  
  
 `GetILFunctionBody` can return a CORPROF_E_FUNCTION_NOT_IL HRESULT if the `methodId` points to a method without any MSIL code (such as an abstract method, or a platform invoke (PInvoke) method).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo-interface.md)
