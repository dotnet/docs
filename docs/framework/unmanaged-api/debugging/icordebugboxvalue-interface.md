---
title: "ICorDebugBoxValue Interface1 | Microsoft Docs"
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
  - "ICorDebugBoxValue"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugBoxValue"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugBoxValue interface [.NET Framework debugging]"
ms.assetid: 3d3ae7e2-97d4-46de-a2c3-cb78f3490f9d
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugBoxValue Interface1
A subclass of "ICorDebugHeapValue" that represents a boxed value class object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetObject Method](../../../../docs/framework/unmanaged-api/debugging/icordebugboxvalue-getobject-method.md)|Gets an interface pointer to the boxed "ICorDebugObjectValue" instance.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)