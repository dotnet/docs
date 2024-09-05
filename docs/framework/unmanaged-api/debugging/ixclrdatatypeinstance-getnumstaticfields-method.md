---
description: "Learn more about: IXCLRDataTypeInstance::GetNumStaticFields Method"
title: "IXCLRDataTypeInstance::GetNumStaticFields Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataTypeInstance::GetNumStaticFields Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTypeInstance::GetNumStaticFields Method"
helpviewer.keywords:
  - "IXCLRDataTypeInstance::GetNumStaticFields Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTypeInstance::GetNumStaticFields Method

Gets the number of static fields in the type.

NOTE: This method is obsolete.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetNumStaticFields(
    [out] ULONG32 *numFields
);
```

## Parameters

`numFields`\
[out] The number of static fields in the type.

## Remarks

The provided method is part of the `IXCLRDataTypeInstance` interface and corresponds to the 10th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
- [IXCLRDataTypeInstance::GetStaticFieldByIndex Method](ixclrdatatypeinstance-getstaticfieldbyindex-method.md)
