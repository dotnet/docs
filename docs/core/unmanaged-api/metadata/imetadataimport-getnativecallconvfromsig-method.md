---
description: "Learn more about: IMetaDataImport::GetNativeCallConvFromSig Method"
title: "IMetaDataImport::GetNativeCallConvFromSig Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetNativeCallConvFromSig"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetNativeCallConvFromSig"
helpviewer_keywords:
  - "GetNativeCallConvFromSig method [.NET Framework metadata]"
  - "IMetaDataImport::GetNativeCallConvFromSig method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetNativeCallConvFromSig Method

Gets the native calling convention for the method that is represented by the specified signature pointer.

## Syntax

```cpp
HRESULT GetNativeCallConvFromSig (
   [in]  void const  *pvSig,
   [in]  ULONG       cbSig,
   [out] ULONG       *pCallConv
);
```

## Parameters

 `pvSig`
 [in] A pointer to the metadata signature of the method to return the calling convention for.

 `cbSig`
 [in] The size in bytes of `pvSig`.

 `pCallConv`
 [out] A pointer to the native calling convention.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- <xref:System.Runtime.InteropServices.CallingConvention>
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
