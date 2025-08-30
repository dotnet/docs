---
description: "Learn more about: COR_DEBUG_IL_TO_NATIVE_MAP Structure"
title: "COR_DEBUG_IL_TO_NATIVE_MAP Structure"
ms.date: "03/30/2017"
api_name:
  - "COR_DEBUG_IL_TO_NATIVE_MAP"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "COR_DEBUG_IL_TO_NATIVE_MAP"
helpviewer_keywords:
  - "COR_DEBUG_IL_TO_NATIVE_MAP structure [.NET debugging]"
topic_type:
  - "apiref"
---
# COR_DEBUG_IL_TO_NATIVE_MAP Structure

Contains the offsets that are used to map common intermediate language (CIL) code to native code.

## Syntax

```cpp
typedef struct COR_DEBUG_IL_TO_NATIVE_MAP {
    ULONG32  ilOffset;
    ULONG32  nativeStartOffset;
    ULONG32  nativeEndOffset;
} COR_DEBUG_IL_TO_NATIVE_MAP;
```

## Members

| Member              | Description                                 |
|---------------------|---------------------------------------------|
| `ilOffset`          | The offset of the CIL code.                 |
| `nativeStartOffset` | The offset of the start of the native code. |
| `nativeEndOffset`   | The offset of the end of the native code.   |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorProf.idl, CorDebug.idl

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [GetILToNativeMapping Method](icordebugcode-getiltonativemapping-method.md)
