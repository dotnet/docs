---
description: "Learn more about: IMetaDataDispenser::OpenScope Method"
title: "IMetaDataDispenser::OpenScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataDispenser.OpenScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataDispenser::OpenScope"
  - "OpenScope method, IMetaDataDispenser interface [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataDispenser::OpenScope Method

Opens an existing, on-disk file and maps its metadata into memory.

## Syntax

```cpp
HRESULT OpenScope (
    [in]  LPCWSTR     szScope,
    [in]  DWORD       dwOpenFlags,
    [in]  REFIID      riid,
    [out] IUnknown    **ppIUnk
);
```

## Parameters

 `szScope`
 [in] The name of the file to be opened. The file must contain common language runtime (CLR) metadata.

 `dwOpenFlags`
 [in] A value of the [CorOpenFlags](../enumerations/coropenflags-enumeration.md) enumeration to specify the mode (read, write, and so on) for opening.

 `riid`
 [in] The IID of the desired metadata interface to be returned; the caller will use the interface to import (read) or emit (write) metadata.

 The value of `riid` must specify one of the "import" or "emit" interfaces. Valid values are IID_IMetaDataEmit, IID_IMetaDataImport, IID_IMetaDataAssemblyEmit, IID_IMetaDataAssemblyImport, IID_IMetaDataEmit2, or IID_IMetaDataImport2.

 `ppIUnk`
 [out] The pointer to the returned interface.

## Remarks

The in-memory copy of the metadata can be queried using methods from one of the "import" interfaces, or added to using methods from the one of the "emit" interfaces.

If the target file does not contain CLR metadata, the `OpenScope` method will fail.

Scopes opened with `dwOpenFlags` set to `ofRead` aren't shared. Use the `ofReadOnly` value to allow the scope to be shared. When a scope is shared, queries that use "read/write" metadata interfaces will fail.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataDispenser Interface](imetadatadispenser-interface.md)
- [IMetaDataDispenserEx Interface](imetadatadispenserex-interface.md)
- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
