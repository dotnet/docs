---
description: "Learn more about: ICorDebugModule3 Interface"
title: "ICorDebugModule3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule3"
api_location:
  - "CorDebug.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule3"
helpviewer_keywords:
  - "ICorDebugModule3 interface [.NET Framework debugging]"
ms.assetid: 0b69f945-263a-4e11-8512-89d27f6ea296
topic_type:
  - "apiref"
---
# ICorDebugModule3 Interface

Creates a symbol reader for a dynamic module.

## Syntax

```cpp
interface ICorDebugModule3 : IUnknown
{
    HRESULT CreateReaderForInMemorySymbols
      (
      [in] REFIID riid,
      [out][iid_is(riid)] void **  ppObj
      );
};
```

## Methods

|Method|Description|
|------------|-----------------|
|[ICorDebugModule3::CreateReaderForInMemorySymbols Method](icordebugmodule3-createreaderforinmemorysymbols-method.md)|Creates a symbol reader (typically [ISymUnmanagedReader Interface](../diagnostics/isymunmanagedreader-interface.md)) for a dynamic module.|

## Remarks

 This interface logically extends the "ICorDebugModule" and "ICorDebugModule2" interfaces.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** 4.5, 4, 3.5 SP1

## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

- [Debugging Interfaces](debugging-interfaces.md)
