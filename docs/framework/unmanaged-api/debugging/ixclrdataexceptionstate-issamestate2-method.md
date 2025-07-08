---
description: "Learn more about: IXCLRDataExceptionState::IsSameState2 Method"
title: "IXCLRDataExceptionState::IsSameState2 Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState::IsSameState2 Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState::IsSameState2 Method"
helpviewer.keywords:
  - "IXCLRDataExceptionState::IsSameState2 Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState::IsSameState2 Method

Determines whether the exception state matches the given exception information.

NOTE: This method requires revision 2 as reported by the `Request` method in order to call.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT IsSameState2(
    [in] ULONG32 flags,
    [in] EXCEPTION_RECORD64 *exRecord,
    [in] ULONG32 contextSize,
    [in, size_is(contextSize)] BYTE cxRecord[]
);
```

## Parameters

`flags`\
[in] Flags indicating how to match the exception state.  This is one of the values defined by the `CLRDataExceptionSameFlag` enumeration.

`exRecord`\
[in] The system exception record for which to check a match against.

`contextSize`\
[in] The size of the context record in the `cxRecord` buffer.

`cxRecord`\
[in] The context record associated with the exception.

## Return Value

If the exception state matches the given information, S_OK will be returned.  If it does not, S_FALSE will be returned.

## Remarks

The provided method is part of the `IXCLRDataExceptionState` interface and corresponds to the 12th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
- [IXCLRDataExceptionState::Request Method](ixclrdataexceptionstate-request-method.md)
- [CLRDataExceptionSameFlag Enumeration](clrdataexceptionsameflag-enumeration.md)
