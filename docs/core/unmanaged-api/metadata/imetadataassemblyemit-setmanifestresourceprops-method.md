---
description: "Learn more about: IMetaDataAssemblyEmit::SetManifestResourceProps Method"
title: "IMetaDataAssemblyEmit::SetManifestResourceProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyEmit.SetManifestResourceProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyEmit::SetManifestResourceProps"
helpviewer_keywords:
  - "SetManifestResourceProps method [.NET Framework metadata]"
  - "IMetaDataAssemblyEmit::SetManifestResourceProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyEmit::SetManifestResourceProps Method

Modifies the specified `ManifestResource` metadata structure.

## Syntax

```cpp
HRESULT SetManifestResourceProps (
    [in] mdManifestResource  mr,
    [in] mdToken             tkImplementation,
    [in] DWORD               dwOffset,
    [in] DWORD               dwResourceFlags
);
```

## Parameters

 `mr`
 [in] The token that specifies the `ManifestResource` metadata structure to be modified.

 `tkImplementation`
 [in] The token, of type `File` or `AssemblyRef`, that maps to the resource provider.

 `dwOffset`
 [in] The offset to the beginning of the resource within the file.

 `dwResourceFlags`
 [in] A bitwise combination of flag values that specify the attributes of the resource.

## Remarks

 To create a `ManifestResource` metadata structure, use the [IMetaDataAssemblyEmit::DefineManifestResource](imetadataassemblyemit-definemanifestresource-method.md) method.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
