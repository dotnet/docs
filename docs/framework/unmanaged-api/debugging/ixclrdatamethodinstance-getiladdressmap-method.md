---
title: "IXCLRDataMethodInstance::GetILAddressMap Method"
ms.date: "01/15/2019"
api.name:
  - "IXCLRDataMethodInstance::GetILAddressMap"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodInstance::GetILAddressMap Method"
helpviewer.keywords:
  - "IXCLRDataMethodInstance::GetILAddressMap Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataMethodInstance::GetILAddressMap Method
Get the IL to address mapping information.

## Syntax
```
HRESULT GetILAddressMap(
    [in] ULONG32                                   mapLen,
    [out] ULONG32                                 *mapNeeded,
    [out, size_is(mapLen)] CLRDATA_IL_ADDRESS_MAP  maps[]
);
```

### Parameters
`mapLen`
[in] The length of the provided maps array.

`mapNeeded`
[out] The number of map entries that the method needs.

`maps`
[out, size_is(mapLen)] The array for storing the map entries.
