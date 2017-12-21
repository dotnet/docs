---
title: "ICorDebugManagedCallback::UpdateModuleSymbols Method"
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
  - "ICorDebugManagedCallback.UpdateModuleSymbols"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugManagedCallback::UpdateModuleSymbols"
helpviewer_keywords: 
  - "UpdateModuleSymbols method [.NET Framework debugging]"
  - "ICorDebugManagedCallback::UpdateModuleSymbols method [.NET Framework debugging]"
ms.assetid: 0863f644-58e8-45a0-b0c3-a28e99b20938
topic_type: 
  - "apiref"
caps.latest.revision: 17
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugManagedCallback::UpdateModuleSymbols Method
Notifies the debugger that the symbols for a common language runtime module have changed.  
  
## Syntax  
  
```  
HRESULT UpdateModuleSymbols (  
    [in] ICorDebugAppDomain *pAppDomain,  
    [in] ICorDebugModule    *pModule,  
    [in] IStream            *pSymbolStream  
);  
```  
  
#### Parameters  
 `pAppDomain`  
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the module in which the symbols have changed.  
  
 `pModule`  
 [in] A pointer to an ICorDebugModule object that represents the module in which the symbols have changed.  
  
 `pSymbolStream`  
 [in] A pointer to a Win32 COM `IStream` object that contains the modified symbols.  
  
## Remarks  
 This method provides an opportunity to update the debugger's view of a module's symbols by calling [ISymUnmanagedReader::UpdateSymbolStore](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-updatesymbolstore-method.md) or [ISymUnmanagedReader::ReplaceSymbolStore](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-replacesymbolstore-method.md).  
  
 This callback can occur multiple times for the same module.  
  
 A debugger should try to bind unbound source-level breakpoints.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugManagedCallback Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmanagedcallback-interface.md)
