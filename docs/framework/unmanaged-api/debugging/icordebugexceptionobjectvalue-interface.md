---
title: "ICorDebugExceptionObjectValue Interface | Microsoft Docs"
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
  - "ICorDebugExceptionObjectValue"
apilocation: 
  - "mscordbi.dll"
apitype: "COM"
f1_keywords: 
  - "ICorDebugExceptionObjectValue"
dev_langs: 
  - "C++"
helpviewer_keywords: 
  - "ICorDebugExceptionObjectValue interface [.NET Framework debugging]"
ms.assetid: 43416dd5-8892-4106-9f59-f9143b19ddb4
caps.latest.revision: 5
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
---
# ICorDebugExceptionObjectValue Interface
Extends the "ICorDebugObjectValue" interface to provide stack trace information from a managed exception object.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateExceptionCallStack Method](../../../../docs/framework/unmanaged-api/debugging/icordebugexceptionobjectvalue-enumerateexceptioncallstack-method.md)|Gets an enumerator to the call stack embedded in an exception object.|  
  
## Remarks  
 The call to `QueryInterface` will succeed for managed objects that derive from <xref:System.Exception?displayProperty=fullName>.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See Also  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)   
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)   
 