---
title: "IXCLRDataMethodDefinition::EnumInstance Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataMethodDefinition::EnumInstance"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::EnumInstance Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::EnumInstance Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodDefinition::EnumInstance Method
Enumerate instances of this definition.

## Syntax
```
HRESULT EnumInstance(
    [in, out] CLRDATA_ENUM         *handle,
    [out] IXCLRDataMethodInstance **instance
);
```

### Parameters
`handle`
[in, out] A handle for enumerating the instances.

`instance`
[out] The enumerated instance.
