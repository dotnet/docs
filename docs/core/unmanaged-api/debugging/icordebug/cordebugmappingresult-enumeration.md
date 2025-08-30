---
description: "Learn more about: CorDebugMappingResult Enumeration"
title: "CorDebugMappingResult Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugMappingResult"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugMappingResult"
helpviewer_keywords:
  - "CorDebugMappingResult enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugMappingResult Enumeration

Provides the details of how the value of the instruction pointer (IP) was obtained.

## Syntax

```cpp
typedef enum CorDebugMappingResult {
    MAPPING_PROLOG              = 0x1,
    MAPPING_EPILOG              = 0x2,
    MAPPING_NO_INFO             = 0x4,
    MAPPING_UNMAPPED_ADDRESS    = 0x8,
    MAPPING_EXACT               = 0x10,
    MAPPING_APPROXIMATE         = 0x20,
} CorDebugMappingResult;
```

## Members

|Member|Description|
|------------|-----------------|
|`MAPPING_PROLOG`|The native code is in the prolog, so the value of the IP is 0.|
|`MAPPING_EPILOG`|The native code is in an epilog, so the value of the IP is the address of the last instruction of the method.|
|`MAPPING_NO_INFO`|No mapping information is available for the method, so the value of the IP is 0.|
|`MAPPING_UNMAPPED_ADDRESS`|Although there is mapping information for the method, the current address cannot be mapped to common intermediate language (CIL) code. The value of the IP is 0.|
|`MAPPING_EXACT`|Either the method maps exactly to CIL code or the frame has been interpreted, so the value of the IP is accurate.|
|`MAPPING_APPROXIMATE`|The method was successfully mapped, but the value of the IP may be approximate.|

## Remarks

 You can use the [ICorDebugILFrame::GetIP](icordebugilframe-getip-method.md) method to obtain the value of the instruction pointer.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
