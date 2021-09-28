---
description: "Learn more about: _AxlRSAKeyValueToPublicKeyToken function"
title: "_AxlRSAKeyValueToPublicKeyToken function"
ms.date: "03/30/2017"
api_name:
  - "_AxlRSAKeyValueToPublicKeyToken"
api_location:
  - "clr.dll"
api_type:
  - "DLLExport"
ms.assetid: d60f19fe-7bec-47ba-b60e-ba9ce66abf8c
topic_type: 
  - "apiref"
---
# \_AxlRSAKeyValueToPublicKeyToken function

Converts a Modulus and Exponent to a strong name public key token.

## Syntax

```cpp
HRESULT _AxlRSAKeyValueToPublicKeyToken (
    [in]  PCRYPT_DATA_BLOB pModulusBlob,
    [in]  PCRYPT_DATA_BLOB pExponentBlob,
    [out] LPWSTR           *ppwszPublicKeyToken
);
```

## Parameters

 `pModulusBlob`\
 [in] The base64-encoded Modulus blob (from the \<Modulus> element).  See the [CRYPTOAPI_BLOB](/windows/win32/api/dpapi/ns-dpapi-crypt_integer_blob) structure.

 `pExponentBlob`\
 [in] The base64-encoded Exponent blob (from the \<Exponent> element). See the [CRYPTOAPI_BLOB](/windows/win32/api/dpapi/ns-dpapi-crypt_integer_blob) structure.

 `ppwszPublicKeyToken`\
 [out] A pointer to WCHAR * to receive the hex-encoded public key token.

## Return Value

 `S_OK` if the function succeeds. Otherwise, returns an error code.

## Requirements

**Assembly**: clr.dll

## See also

- [Authenticode](index.md)
