---
description: "Learn more about: IXCLRDataExceptionState::IsSameState Method"
title: "IXCLRDataExceptionState::IsSameState Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState::IsSameState Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState::IsSameState Method"
helpviewer.keywords:
  - "IXCLRDataExceptionState::IsSameState Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState::IsSameState Method

Determines whether the exception state matches the given exception information.

NOTE: This method is obsolete; `IsSameState2` should be used instead.  This method requires revision 1 as reported by the `Request` method in order to call.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT IsSameState(
    [in] EXCEPTION_RECORD64 *exRecord,
    [in] ULONG32 contextSize,
    [in, size_is(contextSize)] BYTE cxRecord[]
);
```

## Parameters

`exRecord`\
[in] The system exception record for which to check a match against.

`contextSize`\
[in] The size of the context record in the `cxRecord` buffer.

`cxRecord`\
[in] The context record associated with the exception.

## Return Value

If the exception state matches the given information, S_OK will be returned.  If it does not, S_FALSE will be returned.

## Remarks

The provided method is part of the `IXCLRDataExceptionState` interface and corresponds to the 11th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataExceptionState Interface](ixclrdataexceptionstate-interface.md)
- [IXCLRDataExceptionState::IsSameState2 Method](ixclrdataexceptionstate-issamestate2-method.md)
- [IXCLRDataExceptionState::Request Method](ixclrdataexceptionstate-request-method.md)
