---
title: "IXCLRDataProcess::StartEnumMethodInstancesByAddress Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::StartEnumMethodInstancesByAddress"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::StartEnumMethodInstancesByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::StartEnumMethodInstancesByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::StartEnumMethodInstancesByAddress Method
Start enumerate method instances of this process by an address.

## Syntax
```
HRESULT StartEnumMethodInstancesByAddress(
    [in] CLRDATA_ADDRESS     address,
    [in] IXCLRDataAppDomain *appDomain,
    [out] CLRDATA_ENUM      *handle
);
```

### Parameters
`address`
[in] The address of the method instance.

`appDomain`
[in] The AppDomain of the method instance.

`handle`
[out] A handle for enumerating the method instance.
