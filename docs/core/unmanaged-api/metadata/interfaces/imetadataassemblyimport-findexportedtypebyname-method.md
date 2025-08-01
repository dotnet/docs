---
description: "Learn more about: IMetaDataAssemblyImport::FindExportedTypeByName Method"
title: "IMetaDataAssemblyImport::FindExportedTypeByName Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.FindExportedTypeByName"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::FindExportedTypeByName"
  - "IMetaDataAssemblyImport::FindExportedTypeByName method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::FindExportedTypeByName Method

Gets a pointer to an exported type, given its name and enclosing type.

## Syntax

```cpp
HRESULT FindExportedTypeByName (
    [in]  LPCWSTR           szName,
    [in]  mdToken           mdtExportedType,
    [out] mdExportedType    *ptkExportedType
);
```

## Parameters

 `szName`\
 [in] The name of the exported type.

 `mdtExportedType`\
 [in] The metadata token for the enclosing class of the exported type. This value is `mdExportedTypeNil` if the requested exported type is not a nested type.

 `ptkExportedType`\
 [out] A pointer to the `mdExportedType` token that represents the exported type.

## Remarks

 The `FindExportedTypeByName` method uses the standard rules employed by the common language runtime for resolving references.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
- [How the Runtime Locates Assemblies](../../../../framework/deployment/how-the-runtime-locates-assemblies.md)
