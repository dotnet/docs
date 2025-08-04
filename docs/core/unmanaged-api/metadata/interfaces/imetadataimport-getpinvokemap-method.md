---
description: "Learn more about: IMetaDataImport::GetPinvokeMap Method"
title: "IMetaDataImport::GetPinvokeMap Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetPinvokeMap"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetPinvokeMap"
  - "GetPinvokeMap method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetPinvokeMap Method

Gets a ModuleRef token to represent the target assembly of a PInvoke call.

## Syntax

```cpp
HRESULT GetPinvokeMap (
   [in]  mdToken       tk,
   [out] DWORD         *pdwMappingFlags,
   [out] LPWSTR        szImportName,
   [in]  ULONG         cchImportName,
   [out] ULONG         *pchImportName,
   [out] mdModuleRef   *pmrImportDLL
);
```

## Parameters

 `tk`
 [in] A FieldDef or MethodDef token to get the PInvoke mapping metadata for.

 `pdwMappingFlags`
 [out] A pointer to flags used for mapping. This value is a bitmask from the [CorPinvokeMap](../enumerations/corpinvokemap-enumeration.md) enumeration.

 `szImportName`
 [out] The name of the unmanaged target DLL.

 `cchImportName`
 [in] The size in wide characters of `szImportName`.

 `pchImportName`
 [out] The number of wide characters returned in `szImportName`.

 `pmrImportDLL`
 [out] A pointer to a ModuleRef token that represents the unmanaged target object library.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
