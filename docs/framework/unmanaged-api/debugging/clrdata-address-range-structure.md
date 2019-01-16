---
title: "CLRDATA_ADDRESS_RANGE Structure"
ms.date: "01/15/2019"
api.name:
  - "CLRDATA_ADDRESS_RANGE"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "CLRDATA_ADDRESS_RANGE"
helpviewer.keywords:
  - "CLRDATA_ADDRESS_RANGE Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# CLRDATA_ADDRESS_RANGE Structure
Define an address range.

## Syntax
```
typedef struct
{
    CLRDATA_ADDRESS startAddress;
    CLRDATA_ADDRESS endAddress;
} CLRDATA_ADDRESS_RANGE;
```

## Members
|Member      |Description                     |
|------------|--------------------------------|
|startAddress|The start address of the range. |
|endAddress  |The end address of the range.   |
