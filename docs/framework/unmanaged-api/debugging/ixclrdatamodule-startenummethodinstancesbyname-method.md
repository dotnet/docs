---
description: "Learn more about: IXCLRDataModule::StartEnumMethodInstancesByName Method"
title: "IXCLRDataModule::StartEnumMethodInstancesByName Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataModule::StartEnumMethodInstancesByName Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataModule::StartEnumMethodInstancesByName Method"
helpviewer.keywords:
  - "IXCLRDataModule::StartEnumMethodInstancesByName Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataModule::StartEnumMethodInstancesByName Method

Provides a handle for the enumeration of method instances of a given `name` and `appDomain` associated with the module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumMethodInstancesByName(
    [in] LPCWSTR name,
    [in] ULONG32 flags,
    [in] IXCLRDataAppDomain *appDomain,
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`name`\
[in] A buffer containing the name for which to enumerate method instances within the given `appDomain` associated with the module.

`flags`\
[in] A set of flags governing the enumeration of method instances.

Flags may contain one or more of the following values:

| Flag                              | Value      | Description                                                     |
|-----------------------------------|------------|-----------------------------------------------------------------|
| `CLRDATA_BYNAME_CASE_SENSITIVE`   | 0x00000000 | The enumeration should be case sensitive according to `name`.   |
| `CLRDATA_BYNAME_CASE_INSENSITIVE` | 0x00000001 | The enumeration should be case insensitive according to `name`. |

`appDomain`\
[in] The AppDomain from which to enumerate method instances of the given `name`.

`handle`\
[out] A handle for enumerating method instances of a given `name` and `appDomain` associated with the module.

## Remarks

The provided method is part of the `IXCLRDataModule` interface and corresponds to the 23rd slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataModule::EnumMethodInstanceByName Method](ixclrdatamodule-enummethodinstancebyname-method.md)
- [IXCLRDataModule::EndEnumMethodInstancesByName Method](ixclrdatamodule-endenummethodinstancesbyname-method.md)
