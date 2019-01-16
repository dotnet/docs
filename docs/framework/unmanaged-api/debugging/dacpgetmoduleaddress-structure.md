---
title: "DacpGetModuleAddress Structure"
ms.date: "01/15/2019"
api.name:
  - "DacpGetModuleAddress"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "DacpGetModuleAddress Structure"
helpviewer.keywords:
  - "DacpGetModuleAddress Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# DacpGetModuleAddress Structure
Define a get module address request.

## Syntax
```
struct DacpGetModuleAddress
{
    CLRDATA_ADDRESS ModulePtr;
};
```

## Members
|Member      |Description               |
|------------|--------------------------|
|ModulePtr   |The pointer to the module |

## Methods
|Method  |Description          |
|--------|---------------------|
|Request |Perform the request. |
