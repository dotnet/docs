---
title: "ICorProfilerInfo6::EnumNgenModuleMethodsInliningThisMethod Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b933dfe6-7833-40cb-aad8-40842dc3034f
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorProfilerInfo6::EnumNgenModuleMethodsInliningThisMethod Method
[Supported in the .NET Framework 4.6 and later versions]  
  
 Returns an enumerator to all the methods that          are defined in  a given NGen module and          inline a given method.  
  
## Syntax  
  
```  
HRESULT EnumNgenModuleMethodsInliningThisMethod(  
        [in] ModuleID inlinersModuleId,  
        [in] ModuleID inlineeModuleId,  
        [in] mdMethodDef inlineeMethodId,  
        [out] BOOL *incompleteData,  
        [out] ICorProfilerMethodEnum** ppEnum  
);  
```  
  
#### Parameters  
 `inlinersModuleId`  
 [in] The identifier of an NGen module.  
  
 `inlineeModuleId`  
 [in] The identifier of a module that defines `inlineeMethodId`. See the Remarks section for more information.  
  
 `inlineeMethodId`  
 [in] The identifier of an inlined method. See the Remarks section for more information.  
  
 `incompleteData`  
 [out] A flag that indicates whether `ppEnum` contains all methods inlining a given method.  See the Remarks section for more information.  
  
 `ppEnum`  
 [out] A pointer to the address of an enumerator  
  
## Remarks  
 `inlineeModuleId` and `inlineeMethodId` together form the full identifier for the method that might be inlined. For example, assume module `A` defines a method `Simple.Add`:  
  
```csharp  
Simple.Add(int a, int b)   
{ return a + b; }  
```  
  
 and module Bdefines `Fancy.AddTwice`:  
  
```csharp  
Fancy.AddTwice(int a, int b)   
{ return Simple.Add(a,b) + Simple.Add(a,b); }  
```  
  
 Lets also assume that `Fancy.AddTwice` inlines the call to `SimpleAdd`. A profiler could use this enumerator to find all methods defined in module B which inline `Simple.Add`, and the result would enumerate `AddTwice`.  `inlineeModuleId` is the identifier of module `A`,   and `inlineeeMethodId` is the identifier of `Simple.Add(int a, int b)`.  
  
 If `incompleteData` is true after the function returns, the enumerator does not contain all methods inlining a given method. This can happen when one or more direct or indirect dependencies of inliners module haven't been loaded yet. If a profiler needs accurate data, it should retry later when more modules are loaded, preferably on each module load.  
  
 The `EnumNgenModuleMethodsInliningThisMethod` method can be used to work around limitations on inlining for ReJIT. ReJIT lets a profiler change the implementation of a method and then create new code for it on the fly. For example, we could change `Simple.Add` as follows:  
  
```csharp  
Simple.Add(int a, int b)   
{ return 42; }  
```  
  
 However because `Fancy.AddTwice` has already inlined `Simple.Add`, it continues to have the same behavior as before. To work around that limitation, the caller has to search for all methods in all modules that inline `Simple.Add` and use `ICorProfilerInfo5::RequestRejit` on each of those methods. When the methods are re-compiled, they will have the new behavior of `Simple.Add` instead of the old behavior.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See Also  
 [ICorProfilerInfo6 Interface](../../../../docs/framework/unmanaged-api/profiling/icorprofilerinfo6-interface.md)
