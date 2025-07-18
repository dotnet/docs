---
description: "Learn more about: IMetaDataImport::GetSigFromToken Method"
title: "IMetaDataImport::GetSigFromToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetSigFromToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetSigFromToken"
helpviewer_keywords:
  - "IMetaDataImport::GetSigFromToken method [.NET Framework metadata]"
  - "GetSigFromToken method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetSigFromToken Method

Gets the binary metadata signature associated with the specified token.

## Syntax

```cpp
HRESULT GetSigFromToken (
   [in]   mdSignature        mdSig,
   [out]  PCCOR_SIGNATURE    *ppvSig,
   [out]  ULONG              *pcbSig
);
```

## Parameters

 `mdSig`
 [in] The token to return the binary metadata signature for.

 `ppvSig`
 [out] A pointer to the returned metadata signature.

 `pcbSig`
 [out] The size in bytes of the binary metadata signature.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
