---
description: "Learn more about: IMetaDataImport::GetFieldProps Method"
title: "IMetaDataImport::GetFieldProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetFieldProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetFieldProps"
helpviewer_keywords:
  - "IMetaDataImport::GetFieldProps method [.NET Framework metadata]"
  - "GetFieldProps method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetFieldProps Method

Gets metadata associated with the field referenced by the specified FieldDef token.

## Syntax

```cpp
HRESULT GetFieldProps (
   [in]  mdFieldDef        mb,
   [out] mdTypeDef         *pClass,
   [out] LPWSTR            szField,
   [in]  ULONG             cchField,
   [out] ULONG             *pchField,
   [out] DWORD             *pdwAttr,
   [out] PCCOR_SIGNATURE   *ppvSigBlob,
   [out] ULONG             *pcbSigBlob,
   [out] DWORD             *pdwCPlusTypeFlag,
   [out] UVCP_CONSTANT     *ppValue,
   [out] ULONG             *pcchValue
);
```

## Parameters

 `mb`
 [in] A FieldDef token that represents the field to get associated metadata for.

 `pClass`
 [out] A pointer to a TypeDef token that represents the type of the class that the field belongs to.

 `szField`
 [out] The name of the field.

 `cchField`
 [in] The size in wide characters of the buffer for *szField*.

 `pchField`
 [out] The actual size of the returned buffer.

 `pdwAttr`
 [out] Flags associated with the field's metadata.

 `ppvSigBlob`
 [out] A pointer to the binary metadata value that describes the field.

 `pcbSigBlob`
 [out] The size in bytes of `ppvSigBlob`.

 `pdwCPlusTypeFlag`
 [out] A flag that specifies the value type of the field.

 `ppValue`
 [out] A constant value for the field.

 `pcchValue`
 [out] The size in chars of `ppValue`, or zero if no string exists.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
