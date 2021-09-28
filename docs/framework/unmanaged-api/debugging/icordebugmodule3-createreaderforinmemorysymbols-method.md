---
description: "Learn more about: ICorDebugModule3::CreateReaderForInMemorySymbols Method"
title: "ICorDebugModule3::CreateReaderForInMemorySymbols Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugModule3.CreateReaderForInMemorySymbols"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugModule3::CreateReaderForInMemorySymbols"
helpviewer_keywords: 
  - "CreateReaderForInMemorySymbols method, ICorDebugModule3 interface [.NET Framework debugging]"
  - "ICorDebugModule3::CreateReaderForInMemorySymbols method [.NET Framework debugging]"
ms.assetid: af317171-d66d-4114-89eb-063554c74940
topic_type: 
  - "apiref"
---
# ICorDebugModule3::CreateReaderForInMemorySymbols Method

Creates a debug symbol reader for a dynamic module.  
  
## Syntax  
  
```cpp  
HRESULT CreateReaderForInMemorySymbols (  
      [in] REFIID riid,  
      [out][iid_is(riid)] void **    ppObj  
```  
  
## Parameters  

 riid  
 [in] The IID of the COM interface to return. Typically, this is an [ISymUnmanagedReader Interface](../diagnostics/isymunmanagedreader-interface.md).  
  
 ppObj  
 [out] Pointer to a pointer to the returned interface.  
  
## Return Value  

 S_OK  
 Successfully created the reader.  
  
 CORDBG_E_MODULE_LOADED_FROM_DISK  
 The module is not an in-memory or dynamic module.  
  
 CORDBG_E_SYMBOLS_NOT_AVAILABLE  
 Symbols have not been supplied by the application or are not yet available.  
  
 E_FAIL (or other E_ return codes)  
 Unable to create the reader.  
  
## Remarks  

 This method can also be used to create a symbol reader object for in-memory (non-dynamic) modules, but only after the symbols are first available (indicated by the [UpdateModuleSymbols Method](icordebugmanagedcallback-updatemodulesymbols-method.md) callback).  
  
 This method returns a new reader instance every time it is called (like [CComPtrBase::CoCreateInstance](/cpp/atl/reference/ccomptrbase-class#cocreateinstance)). Therefore, the debugger should cache the result and request a new instance only when the underlying data may have changed (that is, when a [LoadClass Method](icordebugmanagedcallback-loadclass-method.md) callback is received).  
  
 Dynamic modules do not have any symbols available until the first type has been loaded (as indicated by the [LoadClass Method](icordebugmanagedcallback-loadclass-method.md) callback).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 4.5, 4, 3.5 SP1  
  
## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

- [Debugging Interfaces](debugging-interfaces.md)
