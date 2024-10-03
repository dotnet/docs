---
description: "Learn more about: IXCLRDataTypeInstance::GetStaticFieldByIndex Method"
title: "IXCLRDataTypeInstance::GetStaticFieldByIndex Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeInstance::GetStaticFieldByIndex Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeInstance::GetStaticFieldByIndex Method"
helpviewer.keywords:
  - "IXCLRDataTypeInstance::GetStaticFieldByIndex Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeInstance::GetStaticFieldByIndex Method

Gets one static field of the type.  Because static field ordering is not fixed, this can also return name information and/or the metadata token if the caller passes in appropriate values.

NOTE: This method is obsolete.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetStaticFieldByIndex(
    [in] ULONG32 index,
    [in] IXCLRDataTask *tlsTask,
    [out] IXCLRDataValue **field,
    [in] ULONG32 bufLen,
    [out] ULONG32 *nameLen,
    [out, size_is(bufLen)] WCHAR nameBuf[],
    [out] mdFieldDef *token
);
```

## Parameters

`index`\
[in] The 0-based index of the static field to retrieve.

`tlsTask`\
[in] The managed task for which to retrieve any static field that is thread local

`field`\
[out] The static field.

`bufLen`\
[in] The size in characters of the buffer `nameBuf`.

`nameLen`\
[out] The number of characters in the static field name which were written to the `nameBuf` buffer.

`nameBuf`\
[out] The name of the static field.

`token`\
[out] The metadata token of the static field.

`method`\
[out] The method instance corresponding to the stack frame.

## Remarks

The provided method is part of the `IXCLRDataTypeInstance` interface and corresponds to the 11th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
- [IXCLRDataTypeInstance::GetNumStaticFields Method](ixclrdatatypeinstance-getnumstaticfields-method.md)
