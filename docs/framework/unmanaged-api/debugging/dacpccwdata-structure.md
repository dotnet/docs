---
title: "DacpCcwData Structure"
ms.date: "06/02/2020"
api.name:
  - "DacpCcwData Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpCcwData Structure"
helpviewer.keywords:
  - "DacpCcwData Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "chuckries"
ms.author: "chuckr"
---
# DacpCcwData Structure

Defines data related to an instance of a [Com Callable Wrapper](../../../standard/native-interop/com-callable-wrapper.md).

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct DacpCcwData
{
    CLRDATA_ADDRESS reserved0;
    CLRDATA_ADDRESS managedObject;
    CLRDATA_ADDRESS reserved2;
    CLRDATA_ADDRESS reserved3;
    LONG            reserved4;
    LONG            reserved5;
    BOOL            isNeutered;
    LONG            reserved7;
    BOOL            reserved8;
    BOOL            reserved9;
    BOOL            reserved10;
    BOOL            reserved11;
    BOOL            reserved12;
};
```

## Members

| Member                       | Description                                                                                                  |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------ |
| `reserved0`                  | This field is reserved for internal use.                                                                     |
| `managedObject`              | The address of the managed object that this CCW represents. This value may change due to garbage collection. |
| `reserved2`                  | This field is reserved for internal use.                                                                     |
| `reserved3`                  | This field is reserved for internal use.                                                                     |
| `reserved4`                  | This field is reserved for internal use.                                                                     |
| `isNeutered`                 | Set to true if this CCW has been disconnected from its managed object.                                       |
| `reserved6`                  | This field is reserved for internal use.                                                                     |
| `reserved7`                  | This field is reserved for internal use.                                                                     |
| `reserved8`                  | This field is reserved for internal use.                                                                     |
| `reserved9`                  | This field is reserved for internal use.                                                                     |
| `reserved10`                 | This field is reserved for internal use.                                                                     |
| `reserved11`                 | This field is reserved for internal use.                                                                     |
| `reserved12`                 | This field is reserved for internal use.                                                                     |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above.

## Requirements
**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
- [Common Data Types](../common-data-types-unmanaged-api-reference.md)
- [Com Callable Wrapper](../../../standard/native-interop/com-callable-wrapper.md)
