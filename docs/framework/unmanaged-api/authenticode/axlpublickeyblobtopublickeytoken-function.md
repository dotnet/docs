---
description: "Learn more about: _AxlPublicKeyBlobToPublicKeyToken Function"
title: "_AxlPublicKeyBlobToPublicKeyToken Function"
ms.date: "03/30/2017"
api_name:
  - "_AxlPublicKeyBlobToPublicKeyToken"
api_location:
  - "clr.dll"
api_type:
  - "DLLExport"
ms.assetid: 2d92a746-d68c-4f53-a16e-727f071a2d80
topic_type: 
  - "apiref"
---
# \_AxlPublicKeyBlobToPublicKeyToken Function

Computes the strong name public key token from a CSP PUBLICKEYBLOB format.

## Syntax

```cpp
HRESULT _AxlPublicKeyBlobToPublicKeyToken (
    [in]  PCCERT_CHAIN_CONTEXT   pCspPublicKeyBlob,
    [out] LPWSTR                 *ppwszPublicKeyToken
);
```

## Parameters

 `pCspPublicKeyBlob`\
 [in] The CSP public key blob.

 `ppwszPublicKeyHash`\
 [out] A pointer to WCHAR * to receive the hex-encoded public key hash.

## Return Value

 `S_OK` if the function succeeds; otherwise `S_FALSE`.

## Requirements

**Assembly**: clr.dll

## See also

- [Authenticode](index.md)
