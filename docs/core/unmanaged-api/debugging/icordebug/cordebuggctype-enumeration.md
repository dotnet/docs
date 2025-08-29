---
description: "Learn more about: CorDebugGCType Enumeration"
title: "CorDebugGCType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorDebugGCType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorDebugGCType"
helpviewer_keywords:
  - "CorDebugGCType enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# CorDebugGCType Enumeration

Indicates whether the garbage collector is running on a workstation or a server.

## Syntax

```cpp
typedef enum CorDebugGCType {
    CorDebugWorkstationGC  = 0,
    CorDebugServerGC       = ( CorDebugWorkstationGC + 1 )
} CorDebugGCType;
```

## Parameters

## Members

|Member name|Description|
|-----------------|-----------------|
|`CorDebugWorkstationGC`|The garbage collector is running on a workstation.|
|`CorDebugServerGC`|The garbage collector is running on a server.|

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5
