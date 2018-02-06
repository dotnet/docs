---
title: "Profiling Structures"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
helpviewer_keywords: 
  - "profiling structures [.NET Framework]"
  - "unmanaged structures [.NET Framework], profiling"
  - "structures [.NET Framework profiling]"
ms.assetid: 750385f2-f365-41b1-939f-ca2f2ff9b466
caps.latest.revision: 27
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Profiling Structures
This section describes the unmanaged structures that the profiling API uses.  
  
## In This Section  
 [COR_PRF_ASSEMBLY_REFERENCE_INFO Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-assembly-reference-info-structure.md)  
 Provides the common language runtime with information about a reference assembly that it should consider when performing an assembly reference closure walk.  
  
 [COR_PRF_CODE_INFO Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-code-info-structure.md)  
 Represents one contiguous block of native code stored in memory.  
  
 [COR_PRF_EX_CLAUSE_INFO Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-ex-clause-info-structure.md)  
 Stores information about a specific exception clause instance and its associated frame.  
  
 [COR_PRF_FUNCTION Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-structure.md)  
 Provides a unique representation of a function by combining its ID with the ID of its recompiled version.  
  
 [COR_PRF_FUNCTION_ARGUMENT_INFO Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-info-structure.md)  
 Represents a function's arguments, in left-to-right order.  
  
 [COR_PRF_FUNCTION_ARGUMENT_RANGE Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-function-argument-range-structure.md)  
 Represents a block of function arguments stored contiguously in left-to-right order in memory.  
  
 [COR_PRF_GC_GENERATION_RANGE Structure](../../../../docs/framework/unmanaged-api/profiling/cor-prf-gc-generation-range-structure.md)  
 Describes a range (that is, block) of memory that is undergoing garbage collection.  
  
## Related Sections  
 COR_DEBUG_IL_TO_NATIVE_MAP  
  
 COR_IL_MAP  
  
 [Profiling Overview](../../../../docs/framework/unmanaged-api/profiling/profiling-overview.md)  
  
 [Profiling Interfaces](../../../../docs/framework/unmanaged-api/profiling/profiling-interfaces.md)  
  
 [Profiling Global Static Functions](../../../../docs/framework/unmanaged-api/profiling/profiling-global-static-functions.md)  
  
 [Profiling Enumerations](../../../../docs/framework/unmanaged-api/profiling/profiling-enumerations.md)
