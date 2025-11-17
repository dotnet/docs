---
description: "Learn more about: CorDebugUnmappedStop Enumeration"
title: "CorDebugUnmappedStop Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugUnmappedStop"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugUnmappedStop"
helpviewer_keywords:
  - "CorDebugUnmappedStop enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugUnmappedStop Enumeration

Specifies the type of unmapped code that can trigger a halt in code execution by the stepper.

## Syntax

```cpp
typedef enum CorDebugUnmappedStop {
    STOP_NONE               = 0x0,
    STOP_PROLOG             = 0x01,
    STOP_EPILOG             = 0x02,
    STOP_NO_MAPPING_INFO    = 0x04,
    STOP_OTHER_UNMAPPED     = 0x08,
    STOP_UNMANAGED          = 0x10,
    STOP_ALL                = 0xffff,
} CorDebugUnmappedStop;
```

## Members

|Member|Description|
|------------|-----------------|
|`STOP_NONE`|Do not stop in any type of unmapped code.|
|`STOP_PROLOG`|Stop in prolog code.|
|`STOP_EPILOG`|Stop in epilog code.|
|`STOP_NO_MAPPING_INFO`|Stop in code that has no mapping information.|
|`STOP_OTHER_UNMAPPED`|Stop in unmapped code that does not fit into the prolog, epilog, no-mapping-information, or unmanaged category.|
|`STOP_UNMANAGED`|Stop in unmanaged code. This value is valid only with interop debugging.|
|`STOP_ALL`|Stop in all types of unmapped code.|

## Remarks

 Use the [ICorDebugStepper::SetUnmappedStopMask](icordebugstepper-setunmappedstopmask-method.md) method to set the flags that specify the unmapped code in which the stepper will stop.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
