---
description: "Learn more about: CorLocalRefPreservation Enumeration"
title: "CorLocalRefPreservation Enumeration"
ms.date: "03/30/2017"
api_name:
  - "CorLocalRefPreservation"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "CorLocalRefPreservation"
topic_type:
  - "apiref"
---
# CorLocalRefPreservation Enumeration

Contains flag values for the treatment of local references.

## Syntax

```cpp
typedef enum CorLocalRefPreservation
{
    MDPreserveLocalRefsNone     =   0x00000000,
    MDPreserveLocalTypeRef      =   0x00000001,
    MDPreserveLocalMemberRef    =   0x00000002
} CorLocalRefPreservation;
```

## Members

|Member|Description|
|------------|-----------------|
|`MDPreserveLocalRefsNone`|Preserve no local references.|
|`MDPreserveLocalTypeRef`|Preserve local type references.|
|`MDPreserveLocalMemberRef`|Preserve local member references.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorHdr.h

 **.NET versions:** Available since .NET Framework 4.5
