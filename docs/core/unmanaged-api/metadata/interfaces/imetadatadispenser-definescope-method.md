---
description: "Learn more about: IMetaDataDispenser::DefineScope Method"
title: "IMetaDataDispenser::DefineScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenser.DefineScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenser::DefineScope"
  - "IMetaDataDispenser::DefineScope method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenser::DefineScope Method

Creates a new area in memory in which you can create new metadata.

## Syntax

```cpp
HRESULT DefineScope (
    [in]  REFCLSID    rclsid,
    [in]  DWORD       dwCreateFlags,
    [in]  REFIID      riid,
    [out] IUnknown    **ppIUnk
);
```

## Parameters

 `rclsid`\
 [in] The CLSID of the version of metadata structures to be created.

 `dwCreateFlags`\
 [in] Flags that specify options.

 `riid`\
 [in] The IID of the desired metadata interface to be returned; the caller will use the interface to create the new metadata.

 The value of `riid` must specify one of the "emit" interfaces. Valid values are `IID_IMetaDataEmit`, `IID_IMetaDataAssemblyEmit`, or `IID_IMetaDataEmit2`.

 `ppIUnk`\
 [out] The pointer to the returned interface.

## Remarks

 `DefineScope` creates a set of in-memory metadata tables, generates a unique GUID (module version identifier, or MVID) for the metadata, and creates an entry in the module table for the compilation unit being emitted.

 You can attach attributes to the metadata scope as a whole by using the [IMetaDataEmit::SetModuleProps](imetadataemit-setmoduleprops-method.md) or [IMetaDataEmit::DefineCustomAttribute](imetadataemit-definecustomattribute-method.md) method, as appropriate.

## Requirements

 **Platform:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
