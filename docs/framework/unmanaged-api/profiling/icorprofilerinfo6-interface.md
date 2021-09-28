---
description: "Learn more about: ICorProfilerInfo6 Interface"
title: "ICorProfilerInfo6 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorProfilerInfo6"
api_location: 
  - "mscorwks.dll"
api_type: 
  - "COM"
ms.assetid: 6f2bb148-1e2b-4e45-a5a5-0ceddc40064b
---
# ICorProfilerInfo6 Interface

[Supported in the .NET Framework 4.6 and later versions]  
  
 A subclass of [ICorProfilerInfo5](icorprofilerinfo5-interface.md) that provides an enumerator for all methods that are defined in a given NGen module and inline a given method.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICorProfilerInfo6::EnumNgenModuleMethodsInliningThisMethod Method](icorprofilerinfo6-enumngenmodulemethodsinliningthismethod-method.md)|Returns an enumerator for all methods that belong to a given NGen module and that are inlined in the body of a given method.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
