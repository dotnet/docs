---
description: "Learn more about: ICorDebugModule::GetBaseAddress Method"
title: "ICorDebugModule::GetBaseAddress Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetBaseAddress"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetBaseAddress"
helpviewer_keywords:
  - "GetBaseAddress method [.NET debugging]"
  - "ICorDebugModule::GetBaseAddress method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetBaseAddress Method

Gets the base address of the module.

## Syntax

```cpp
HRESULT GetBaseAddress(
    [out] CORDB_ADDRESS *pAddress
);
```

## Parameters

 `pAddress`
 [out] A `CORDB_ADDRESS` that specifies the base address of the module.

## Remarks

If the module is a native image (that is, if the module was produced by the native image generator, NGen.exe), its base address will be zero.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0

## See also
