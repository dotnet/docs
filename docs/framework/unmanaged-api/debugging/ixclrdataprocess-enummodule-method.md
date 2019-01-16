---
title: "IXCLRDataProcess::EnumModule Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::EnumModule"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumModule Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumModule Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EnumModule Method
Enumerate modules of this process.

## Syntax
```
HRESULT EnumModule(
    [in, out] CLRDATA_ENUM  *handle,
    [out] IXCLRDataModule  **mod
);
```

### Parameters
`handle`
[in, out] A handle for enumerating the modules.

`mod`
[out] The enumerated module.
