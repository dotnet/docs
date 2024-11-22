---
description: "Learn more about: CLRDATA_METHDEF_EXTENT Structure"
title: "CLRDATA_METHDEF_EXTENT Structure"
ms.date: "07/02/2024"
api_name:
  - "CLRDATA_METHDEF_EXTENT"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDATA_METHDEF_EXTENT"
helpviewer_keywords:
  - "CLRDATA_METHDEF_EXTENT structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDATA_METHDEF_EXTENT Structure

Describes an IL code region associated with a method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct CLRDATA_METHDEF_EXTENT
{
    CLRDATA_ADDRESS startAddress;
    CLRDATA_ADDRESS endAddress;
    ULONG32 enCVersion
    CLRDataMethodDefinitionExtentType type;
};
```

## Members

|Member|Description|
|------------|-----------------|
|`startAddress`|The start address of an IL code region associated with a method.|
|`endAddress`|The end address of an IL code region associated with a method.|
|`enCVersion`|The EnC version of the code in this extent.|
|`type`|The type of extent associated with the method.  The CLRDataMethodDefinitionExtentType enumeration presently has one value: CLRDATA_METHDEF_IL (0)|

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above, where `CLRDATA_ADDRESS` is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
- [IXCLRDataMethodDefinition::StartEnumExtents Method](ixclrdatamethoddefinition-startenumextents.md)
- [IXCLRDataMethodDefinition::EnumExtent Method](ixclrdatamethoddefinition-enumextent-method.md)
- [IXCLRDataMethodDefinition::EndEnumExtents Method](ixclrdatamethoddefinition-endenumextents-method.md)
