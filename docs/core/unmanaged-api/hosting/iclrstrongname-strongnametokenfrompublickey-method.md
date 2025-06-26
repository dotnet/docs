---
description: "Learn more about: ICLRStrongName::StrongNameTokenFromPublicKey Method"
title: "ICLRStrongName::StrongNameTokenFromPublicKey Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRStrongName.StrongNameTokenFromPublicKey"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRStrongName::StrongNameTokenFromPublicKey"
helpviewer_keywords:
  - "ICLRStrongName::StrongNameTokenFromPublicKey method [.NET Framework hosting]"
  - "StrongNameTokenFromPublicKey method, ICLRStrongName interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRStrongName::StrongNameTokenFromPublicKey Method

Gets a token that represents a public key. A strong name token is the shortened form of a public key.

## Syntax

```cpp
HRESULT StrongNameTokenFromPublicKey (
    [in]  BYTE    *pbPublicKeyBlob,
    [in]  ULONG   cbPublicKeyBlob,
    [out] BYTE    **ppbStrongNameToken,
    [out] ULONG   *pcbStrongNameToken
);
```

## Parameters

 `pbPublicKeyBlob`
 [in] A structure of type [PublicKeyBlob]((../../../framework/unmanaged-api/strong-naming/publickeyblob-structure.md) that contains the public portion of the key pair used to generate the strong name signature.

 `cbPublicKeyBlob`
 [in] The size, in bytes, of `pbPublicKeyBlob`.

 `ppbStrongNameToken`
 [out] The strong name token corresponding to the key passed in `pbPublicKeyBlob`. The common language runtime allocates the memory in which to return the token. The caller must free this memory by using the [ICLRStrongName::StrongNameFreeBuffer](iclrstrongname-strongnamefreebuffer-method.md) method.

 `pcbStrongNameToken`
 [out] The size, in bytes, of the returned strong name token.

## Return Value

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).

## Remarks

 A strong name token is the shortened form of a public key that is used to save space when storing key information in metadata. Specifically, strong name tokens are used in assembly references to refer to the dependent assembly.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in mscoree.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [StrongNameGetPublicKey Method](iclrstrongname-strongnamegetpublickey-method.md)
- [PublicKeyBlob Structure]((../../../framework/unmanaged-api/strong-naming/publickeyblob-structure.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
