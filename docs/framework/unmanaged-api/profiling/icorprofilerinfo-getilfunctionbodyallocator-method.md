---
description: "Learn more about: ICorProfilerInfo::GetILFunctionBodyAllocator Method"
title: "ICorProfilerInfo::GetILFunctionBodyAllocator Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo.GetILFunctionBodyAllocator"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorProfilerInfo::GetILFunctionBodyAllocator"
helpviewer_keywords: 
  - "GetILFunctionBodyAllocator method [.NET Framework profiling]"
  - "ICorProfilerInfo::GetILFunctionBodyAllocator method [.NET Framework profiling]"
ms.assetid: 5da1bf3d-dddf-4892-b266-578ee54d570b
topic_type: 
  - "apiref"
---
# ICorProfilerInfo::GetILFunctionBodyAllocator Method

Gets an interface that provides a method to allocate memory to be used for swapping out the body of a method in Microsoft intermediate language (MSIL) code.  
  
## Syntax  
  
```cpp  
HRESULT GetILFunctionBodyAllocator(  
    [in]  ModuleID      moduleId,  
    [out] IMethodMalloc **ppMalloc);  
```  
  
## Parameters  

 `moduleId`  
 [in] The ID of the module in which the method resides.  
  
 `ppMalloc`  
 [out] A pointer to an [IMethodMalloc](imethodmalloc-interface.md) interface that provides a method to allocate the memory.  
  
## Remarks  

 A method body in MSIL code must be located as a relative virtual address (RVA), relative to the loaded module, which means that it follows the module within 4 GB. To make it easier for a tool to swap out the body of a method, the `GetILFunctionBodyAllocator` method ensures that memory is allocated within that range.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorProfilerInfo Interface](icorprofilerinfo-interface.md)
