---
description: "Learn more about: ICorDebugModule4::IsMappedLayout Method"
title: "ICorDebugModule4::IsMappedLayout Method"
ms.date: "06/06/2022"
api_name:
  - "ICorDebugModule4.IsMappedLayout"
api_location:
  - "CorDebug.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule4::IsMappedLayout"
helpviewer_keywords:
  - "IsMappedLayout method, ICorDebugModule4 interface [.NET Framework debugging]"
  - "ICorDebugModule4::IsMappedLayout method [.NET Framework debugging]"
ms.assetid:
topic_type:
  - "apiref"
---
# ICorDebugModule4::IsMappedLayout Method

Determines whether a module is loaded into memory in mapped/hydrated format.

## Syntax

```cpp
HRESULT IsMappedLayout(
      [out] BOOL *pIsMapped
      );
```

## Parameters

`pIsMapped`\
[out] Pointer to a BOOL to store mapping information. TRUE represents mapped format while FALSE represents flat format.

## Return Value

`S_OK`\
 Successfully created the reader.

`S_FALSE`\
 The layout couldn't be determined.

## Remarks

The `pIsMapped` value should only be interpreted as valid when this function returns `S_OK`. All other return values (including
`S_FALSE`) indicate that the layout couldn't be determined and `pIsMapped` should be ignored.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** 4.5, 4, 3.5 SP1

## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
