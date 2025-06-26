---
description: "Learn more about: ICLRStrongName::StrongNameKeyInstall Method"
title: "ICLRStrongName::StrongNameKeyInstall Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRStrongName.StrongNameKeyInstall"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRStrongName::StrongNameKeyInstall"
helpviewer_keywords:
  - "ICLRStrongName::StrongNameKeyInstall method [.NET Framework hosting]"
  - "StrongNameKeyInstall method, ICLRStrongName interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRStrongName::StrongNameKeyInstall Method

Imports a public/private key pair into a container.

## Syntax

```cpp
HRESULT StrongNameKeyInstall (
    [in]  LPCWSTR   wszKeyContainer,
    [in]  BYTE      *pbKeyBlob,
    [in]  ULONG     cbKeyBlob
);
```

## Parameters

 `wszKeyContainer`
 [in] The name of the key container. `wszKeyContainer` must be a non-empty string.

 `pbKeyBlob`
 [in] The binary key pair.

 `cbKeyBlob`
 [in] The size, in bytes, of `pbKeyBlob`.

## Return Value

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).

## Remarks

 Use the [ICLRStrongName::StrongNameKeyDelete](iclrstrongname-strongnamekeydelete-method.md) method to delete the key container.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [StrongNameKeyDelete Method](iclrstrongname-strongnamekeydelete-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
