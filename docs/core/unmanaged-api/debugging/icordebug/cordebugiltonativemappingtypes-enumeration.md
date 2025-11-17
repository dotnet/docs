---
description: "Learn more about: CorDebugIlToNativeMappingTypes Enumeration"
title: "CorDebugIlToNativeMappingTypes Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugIlToNativeMappingTypes"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugIlToNativeMappingTypes"
helpviewer_keywords:
  - "CorDebugIIToNativeMappingTypes enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugIlToNativeMappingTypes Enumeration

Indicates whether a particular range of native instructions, represented by an instance of the COR_DEBUG_IL_TO_NATIVE_MAP structure, corresponds to a special code region.

## Syntax

```cpp
typedef enum CorDebugIlToNativeMappingTypes {
    NO_MAPPING = -1,
    PROLOG     = -2,
    EPILOG     = -3
} CorDebugIlToNativeMappingTypes;
```

## Members

|Member|Description|
|------------|-----------------|
|`NO_MAPPING`|The range of native instructions does not correspond to any special code region.|
|`PROLOG`|The range of native instructions corresponds to the prolog.|
|`EPILOG`|The range of native instructions corresponds to the epilog.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [GetILToNativeMapping Method](icordebugcode-getiltonativemapping-method.md)
