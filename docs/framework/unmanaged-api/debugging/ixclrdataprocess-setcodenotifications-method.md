---
description: "Learn more about: IXCLRDataProcess::SetCodeNotifications Method"
title: "IXCLRDataProcess::SetCodeNotifications Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::SetCodeNotifications Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::SetCodeNotifications Method"
helpviewer.keywords:
  - "IXCLRDataProcess::SetCodeNotifications Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::SetCodeNotifications Method

Requests notifications when code is generated or discarded for a method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT SetCodeNotifications(
    [in] ULONG32 numTokens,
    [in, size_is(numTokens)] IXCLRDataModule* mods[],
    [in] IXCLRDataModule *singleMod,
    [in, size_is(numTokens)] mdMethodDef tokens[],
    [in, size_is(numTokens)] ULONG32 flags[],
    [in] ULONG32 singleFlags
);
```

## Parameters

`numTokens`\
[in] The number of method tokens for which to request code notifications.

`mods`\
[in] The module associated with each method token.  If this is NULL, `singleMod` is used as the module for all tokens in the `tokens` array.

`singleMod`\
[in] The module associated with all method tokens.  This argument is only used if `mods` is NULL.

`tokens`\
[in] The method tokens for which to request code notifications.

`flags`\
[in] The flags associated with each method token.  If this is NULL, `singleFlags` is used as the flags for all tokens in the `tokens` array.  Each entry in the `flags` array is one or more of the flags defined by the `CLRDataMethodCodeNotification` enumeration.

`singleFlags`\
[in] The flags associated with all method tokens.  This argument is only used if `flags` is NULL.  The `singleFlags` argument is one or more of the flags defined by the `CLRDataMethodCodeNotification` enumeration.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 41st slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [CLRDataMethodCodeNotification Enumeration](clrdatamethodcodenotification-enumeration.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
