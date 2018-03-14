---
title: "Debugging Structures"
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
  - "unmanaged structures [.NET Framework], debugging"
  - "debugging structures [.NET Framework]"
  - "structures [.NET Framework debugging]"
ms.assetid: 173ba2c2-ab34-49ae-b6a8-e5c49882bf05
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Debugging Structures
This section describes the unmanaged structures that the debugging API uses.  
  
## In This Section  
 [CLR_DEBUGGING_VERSION Structure](../../../../docs/framework/unmanaged-api/debugging/clr-debugging-version-structure.md)  
 Defines the product version of the common language runtime (CLR) for debugging purposes.  
  
 [CodeChunkInfo Structure1](../../../../docs/framework/unmanaged-api/debugging/codechunkinfo-structure.md)  
 Represents a single chunk of code in memory.  
  
 [CorDebugBlockingObject Structure](../../../../docs/framework/unmanaged-api/debugging/cordebugblockingobject-structure.md)  
 Defines an object that is blocking a thread and the reason why the thread is blocked.  
  
 [CorDebugEHClause Structure](../../../../docs/framework/unmanaged-api/debugging/cordebugehclause-structure.md)  
 Represents an exception handling (EH) clause for a given piece of intermediate language (IL).  
  
 [CorDebugExceptionObjectStackFrame Structure](../../../../docs/framework/unmanaged-api/debugging/cordebugexceptionobjectstackframe-structure.md)  
 Represents stack frame information from an exception object.  
  
 [CorDebugExceptionObjectStackFrame Structure](../../../../docs/framework/unmanaged-api/debugging/cordebugexceptionobjectstackframe-structure.md)  
 Maps a [!INCLUDE[wrt](../../../../includes/wrt-md.md)] GUID to its corresponding [ICorDebugType](../../../../docs/framework/unmanaged-api/debugging/icordebugtype-interface.md) object.  
  
 COR_ACTIVE_FUNCTION  
 Contains information about the functions that are currently active in a thread's frames.  
  
 [COR_ARRAY_LAYOUT Structure](../../../../docs/framework/unmanaged-api/debugging/cor-array-layout-structure.md)  
 Provides information about the layout of an array object in memory.  
  
 COR_DEBUG_IL_TO_NATIVE_MAP  
 Contains the offsets that are used to map Microsoft intermediate language (MSIL) code to native code.  
  
 COR_DEBUG_STEP_RANGE  
 Contains the offset information for a range of code.  
  
 [COR_FIELD Structure](../../../../docs/framework/unmanaged-api/debugging/cor-field-structure.md)  
 Provides information about a field in an object.  
  
 [COR_GC_REFERENCE Structure](../../../../docs/framework/unmanaged-api/debugging/cor-gc-reference-structure.md)  
 Contains information about an object that is to be garbage-collected.  
  
 [COR_HEAPINFO Structure](../../../../docs/framework/unmanaged-api/debugging/cor-heapinfo-structure.md)  
 Provides general information about the garbage collection heap, including whether it is enumerable.  
  
 [COR_HEAPOBJECT Structure](../../../../docs/framework/unmanaged-api/debugging/cor-heapobject-structure.md)  
 Provides information about an object on the managed heap.  
  
 COR_IL_MAP  
 Specifies changes in the relative offset of a function.  
  
 [COR_SEGMENT Structure](../../../../docs/framework/unmanaged-api/debugging/cor-segment-structure.md)  
 Contains information about a region of memory in the managed heap.  
  
 [COR_TYPEID Structure](../../../../docs/framework/unmanaged-api/debugging/cor-typeid-structure.md)  
 Contains a type identifier.  
  
 [COR_TYPE_LAYOUT Structure](../../../../docs/framework/unmanaged-api/debugging/cor-type-layout-structure.md)  
 Provides information about the layout of an object in memory.  
  
 COR_VERSION  
 Stores the standard four-part version number of the common language runtime.  
  
 [StackTrace_SimpleContext Structure](../../../../docs/framework/unmanaged-api/debugging/stacktrace-simplecontext-structure.md)  
 Provides a simple context that can be used in place of a full `CONTEXT` structure.  
  
## Related Sections  
 [Debugging Coclasses](../../../../docs/framework/unmanaged-api/debugging/debugging-coclasses.md)  
  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)  
  
 [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)  
  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
