---
title: "CLRDATA_IL_ADDRESS_MAP Structure"
ms.date: "01/15/2019"
api.name:
  - "CLRDATA_IL_ADDRESS_MAP"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "CLRDATA_IL_ADDRESS_MAP Structure"
helpviewer.keywords:
  - "CLRDATA_IL_ADDRESS_MAP Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# CLRDATA_IL_ADDRESS_MAP Structure
Define an IL to address mapping

## Syntax
```
typedef struct
{
    ULONG32 ilOffset;
    CLRDATA_ADDRESS startAddress;
    CLRDATA_ADDRESS endAddress;
    CLRDataSourceType type;
} CLRDATA_IL_ADDRESS_MAP;
```

## Members
|Member      |Description                                           |
|------------|------------------------------------------------------|
|ilOffset    |The start address of the range.                       |
|startAddress|The start address of the range.                       |
|endAddress  |The end address of the range.                         |
|type        |The type of the data. The value is currently not used |
