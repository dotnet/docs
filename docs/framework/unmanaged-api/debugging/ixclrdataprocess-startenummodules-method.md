---
title: "IXCLRDataProcess::StartEnumModules Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::StartEnumModules"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::StartEnumModules Method"
helpviewer.keywords:
  - "IXCLRDataProcess::StartEnumModules Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::StartEnumModules Method
Start enumerate modules of this process.

## Syntax
```
HRESULT StartEnumModules(
    [out] CLRDATA_ENUM *handle
);
```

### Parameters
`handle`
[out] A handle for enumerating the modules.
