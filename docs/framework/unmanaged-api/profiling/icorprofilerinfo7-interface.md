---
description: "Learn more about: ICorProfilerInfo7 Interface"
title: "ICorProfilerInfo7 Interface"
ms.date: "03/30/2017"
ms.assetid: cf37c462-73c5-412a-a7f8-bb26ca746313
---
# ICorProfilerInfo7 Interface

[Supported in the .NET Framework 4.6.1 and later versions]  
  
 A subclass of [ICorProfilerInfo6](icorprofilerinfo6-interface.md) that provides a method to apply newly defined metadata to a module and that provides access to an in-memory symbol stream.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ApplyMetaData Method](icorprofilerinfo7-applymetadata-method.md)|Applies the metadata newly defined by the `IMetadataEmit::Define*` methods to a specified module.|  
|[GetInMemorySymbolsLength Method](icorprofilerinfo7-getinmemorysymbolslength-method.md)|Returns the length of an in-memory symbol stream.|  
|[ReadInMemorySymbols](icorprofilerinfo7-readinmemorysymbols.md)|Reads bytes from an in-memory symbol stream.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorProf.idl, CorProf.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v461plus](../../../../includes/net-current-v461plus-md.md)]  
  
## See also

- [Profiling Interfaces](profiling-interfaces.md)
