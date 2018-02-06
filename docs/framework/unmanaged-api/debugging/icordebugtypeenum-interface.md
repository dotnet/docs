---
title: "ICorDebugTypeEnum Interface1"
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
  - "ICorDebugTypeEnum"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugTypeEnum"
helpviewer_keywords: 
  - "ICorDebugTypeEnum interface [.NET Framework debugging]"
ms.assetid: 159ccfcf-b37c-4ad9-8e0d-a9a443262472
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugTypeEnum Interface1
Implements "ICorDebugEnum" methods and enumerates "ICorDebugType" arrays.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[Next Method](../../../../docs/framework/unmanaged-api/debugging/icordebugtypeenum-next-method.md)|Gets the specified number of `ICorDebugType` instances from the enumeration, starting at the current position.|  
  
## Remarks  
  
> [!NOTE]
>  This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
