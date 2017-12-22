---
title: "ICorDebugMemoryBuffer Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 85dc2d65-3657-4b93-9f23-9feaa95d37ff
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMemoryBuffer Interface
Represents an in-memory buffer.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetSize Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmemorybuffer-getsize-method.md)|Gets the size of the memory buffer in bytes.|  
|[GetStartAddress Method](../../../../docs/framework/unmanaged-api/debugging/icordebugmemorybuffer-getstartaddress-method.md)|Gets the starting address of the memory buffer.|  
  
## Remarks  
  
> [!NOTE]
>  This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
