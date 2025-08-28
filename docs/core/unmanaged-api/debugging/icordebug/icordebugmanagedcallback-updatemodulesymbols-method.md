---
description: "Learn more about: ICorDebugManagedCallback::UpdateModuleSymbols Method"
title: "ICorDebugManagedCallback::UpdateModuleSymbols Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugManagedCallback.UpdateModuleSymbols"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugManagedCallback::UpdateModuleSymbols"
helpviewer_keywords:
  - "UpdateModuleSymbols method [.NET debugging]"
  - "ICorDebugManagedCallback::UpdateModuleSymbols method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugManagedCallback::UpdateModuleSymbols Method

Notifies the debugger that the symbols for a common language runtime module have changed.

## Syntax

```cpp
HRESULT UpdateModuleSymbols (
    [in] ICorDebugAppDomain *pAppDomain,
    [in] ICorDebugModule    *pModule,
    [in] IStream            *pSymbolStream
);
```

## Parameters

 `pAppDomain`
 [in] A pointer to an ICorDebugAppDomain object that represents the application domain containing the module in which the symbols have changed.

 `pModule`
 [in] A pointer to an ICorDebugModule object that represents the module in which the symbols have changed.

 `pSymbolStream`
 [in] A pointer to a Win32 COM `IStream` object that contains the modified symbols.

## Remarks

 This method provides an opportunity to update the debugger's view of a module's symbols by calling [ISymUnmanagedReader::UpdateSymbolStore](../../../../framework/unmanaged-api/diagnostics/isymunmanagedreader-updatesymbolstore-method.md) or [ISymUnmanagedReader::ReplaceSymbolStore](../../../../framework/unmanaged-api/diagnostics/isymunmanagedreader-replacesymbolstore-method.md).

 This callback can occur multiple times for the same module.

 A debugger should try to bind unbound source-level breakpoints.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [ICorDebugManagedCallback Interface](icordebugmanagedcallback-interface.md)
