---
description: "Learn more about: ICorDebugILFrame2 Interface"
title: "ICorDebugILFrame2 Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugILFrame2"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame2"
helpviewer_keywords: 
  - "ICorDebugILFrame2 interface [.NET Framework debugging]"
ms.assetid: f94b9d53-d8f8-4424-a95e-53a1bfd26e4a
topic_type: 
  - "apiref"
---
# ICorDebugILFrame2 Interface

A logical extension of the ICorDebugILFrame interface.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateTypeParameters Method](icordebugilframe2-enumeratetypeparameters-method.md)|Gets an ICorDebugTypeEnum object that contains the <xref:System.Type> parameters in this frame.|  
|[RemapFunction Method](icordebugilframe2-remapfunction-method.md)|Remaps an edited function by specifying the new MSIL offset.|  
  
## Remarks  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
