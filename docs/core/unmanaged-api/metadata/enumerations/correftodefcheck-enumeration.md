---
description: "Learn more about: CorRefToDefCheck Enumeration"
title: "CorRefToDefCheck Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorRefToDefCheck"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorRefToDefCheck"
topic_type:
  - "apiref"
---
# CorRefToDefCheck Enumeration

Specifies flags to control which referenced items are converted to their definitions in order to optimize the code.

## Syntax

```cpp
typedef enum CorRefToDefCheck {
    MDRefToDefDefault           = 0x00000003,
    MDRefToDefAll               = 0xffffffff,
    MDRefToDefNone              = 0x00000000,
    MDTypeRefToDef              = 0x00000001,
    MDMemberRefToDef            = 0x00000002
} CorRefToDefCheck;
```

## Members

| Member | Description |
|------------|-----------------|
| `MDRefToDefDefault` |Specifies that type references and member references should be converted to definitions. This is the default value (`MDTypeRefToDef` &#124; `MDMemberRefToDef`).|
| `MDRefToDefAll` | Specifies that all referenced items should be converted to definitions. |
| `MDRefToDefNone` | Specifies that no referenced items should be converted to definitions. |
| `MDTypeRefToDef` | Specifies that only type references should be converted to type definitions. |
| `MDMemberRefToDef` | Specifies that only member references should be converted to definitions. That is, member references should be converted to either method definitions or field definitions. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorHdr.h
