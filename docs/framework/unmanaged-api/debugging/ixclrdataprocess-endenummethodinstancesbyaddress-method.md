---
title: "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EndEnumMethodInstancesByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EndEnumMethodInstancesByAddress Method
End enumerate method instances of this process by an address.

## Syntax
```
HRESULT EndEnumMethodInstancesByAddress(
    [in] CLRDATA_ENUM handle
);
```

### Parameters
`handle`
[out] A handle for enumerating the method instances.
