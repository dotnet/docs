---
title: "COR_GC_REFERENCE Structure"
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
  - "COR_GC_REFERENCE"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_GC_REFERENCE"
helpviewer_keywords: 
  - "COR_GC_REFERENCE structure [.NET Framework debugging]"
ms.assetid: 162e8179-0cd4-4110-8f06-5f387698bd62
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# COR_GC_REFERENCE Structure
Contains information about an object that is to be garbage-collected.  
  
## Syntax  
  
```  
typedef struct _COR_GC_REFERENCE {  
    ICorDebugAppDomain *domain;   
    ICorDebugValue *location;  
    CorGCReferenceType type;  
    UINT64 extraData;  
} COR_GC_REFERENCE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`domain`|A pointer to the application domain to which the handle or object belongs. Its value may be `null`.|  
|`location`|Either an ICorDebugValue or an ICorDebugReferenceValue interface that corresponds to the object to be garbage-collected.|  
|`type`|A [CorGCReferenceType](../../../../docs/framework/unmanaged-api/debugging/corgcreferencetype-enumeration.md) enumeration value that indicates where the root came from. For more information, see the Remarks section.|  
|`extraData`|Additional data about the object to be garbage-collected. This information depends on the source of the object, as indicated by the `type` field. For more information, see the Remarks section.|  
  
## Remarks  
 The `type` field is a [CorGCReferenceType](../../../../docs/framework/unmanaged-api/debugging/corgcreferencetype-enumeration.md) enumeration value that indicates where the reference came from. A particular `COR_GC_REFERENCE` value can reflect any of the following kinds of managed objects:  
  
-   Objects from all managed stacks (`CorGCReferenceType.CorReferenceStack`). This includes live references in managed code, as well as objects created by the common language runtime.  
  
-   Objects from the handle table (`CorGCReferenceType.CorHandle*`). This includes strong references (`HNDTYPE_STRONG` and `HNDTYPE_REFCOUNT`) and static variables in a module.  
  
-   Objects from the finalizer queue (`CorGCReferenceType.CorReferenceFinalizer`). The finalizer queue roots objects until the finalizer has run.  
  
 The `extraData` field contains extra data depending on the source (or type) of the reference. Possible values are:  
  
-   `DependentSource`. If the `type` is `CorGCREferenceType.CorHandleStrongDependent`, this field is the object that, if alive, roots the object to be garbage-collected at `COR_GC_REFERENCE.Location`.  
  
-   `RefCount`. If the `type` is `CorGCREferenceType.CorHandleStrongRefCount`, this field is the reference count of the handle.  
  
-   `Size`. If the `type` is `CorGCREferenceType.CorHandleStrongSizedByref`, this field is the last size of the object tree for which the garbage collector calculated the object roots. Note that this calculation is not necessarily up to date.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
