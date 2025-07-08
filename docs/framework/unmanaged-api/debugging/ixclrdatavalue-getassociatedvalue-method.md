---
description: "Learn more about: IXCLRDataValue::GetAssociatedValue Method"
title: "IXCLRDataValue::GetAssociatedValue Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataValue::GetAssociatedValue Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataValue::GetAssociatedValue Method"
helpviewer.keywords:
  - "IXCLRDataValue::GetAssociatedValue Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataValue::GetAssociatedValue Method

Gets the value implicitly associated with this value.  For pointers or reference values, this is the value pointed or referred to.  For boxed values, this is the contained value.  For other values, there is no associated value.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetAssociatedValue(
    [out] IXCLRDataValue **assocValue
);
```

## Parameters

`assocValue`\
[out] The value implicitly associated with this value.

## Remarks

The provided method is part of the `IXCLRDataValue` interface and corresponds to the 21st slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataValue Interface](ixclrdatavalue-interface.md)
- [IXCLRDataValue::GetAssociatedType Method](ixclrdatavalue-getassociatedtype-method.md)
