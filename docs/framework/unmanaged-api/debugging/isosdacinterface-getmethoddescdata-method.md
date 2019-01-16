---
title: "ISOSDacInterface::GetMethodDescData Method"
ms.date: "01/15/2019"
api.name:
  - "ISOSDacInterface::GetMethodDescData"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetMethodDescData Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetMethodDescData Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# ISOSDacInterface::GetMethodDescData Method
Get the data associated with the MethodDesc.

## Syntax
```
HRESULT GetMethodDescData(
    CLRDATA_ADDRESS            methodDesc,
    CLRDATA_ADDRESS            ip,
    struct DacpMethodDescData *data,
    ULONG                      cRevertedRejitVersions,
    struct DacpReJitData      *rgRevertedRejitData,
    ULONG                     *pcNeededRevertedRejitData
);
```

### Parameters
`methodDesc`
[in] The address of the MethodDesc.

`ip`
[in] The IP address of the method.

`data`
[out] The data associated with the MethodDesc.

`cRevertedRejitVersions`
[out] The number of reverted rejit versions.

`rgRevertedRejitData`
[out] The data associated with the reverted rejit versions.

`pcNeededRevertedRejitData`
[out] The number of bytes required to store the data associated with the reverted rejit versions.
