---
title: "IXCLRDataProcess::EnumMethodInstanceByAddress Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumMethodInstanceByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EnumMethodInstanceByAddress Method
Enumerate method instances of this process by an address.

## Syntax
```
HRESULT EnumMethodInstanceByAddress(
    [in] CLRDATA_ENUM              *handle,
    [out] IXCLRDataMethodInstance **method
);
```

### Parameters
`handle`
[in] A handle for enumerating the method instances.

`mod`
[out] The enumerated method instance.
