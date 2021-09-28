---
description: "Learn more about: StrongNameKeyInstall Function"
title: "StrongNameKeyInstall Function"
ms.date: "03/30/2017"
api_name:
  - "StrongNameKeyInstall"
api_location:
  - "mscoree.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "StrongNameKeyInstall"
helpviewer_keywords:
  - "StrongNameKeyInstall function [.NET Framework strong naming]"
ms.assetid: e32fd546-7757-4681-be3d-658e93281e50
topic_type:
  - "apiref"
---

# StrongNameKeyInstall Function

Imports a public/private key pair into a container.

This function has been deprecated. Use the [ICLRStrongName::StrongNameKeyInstall](../hosting/iclrstrongname-strongnamekeyinstall-method.md) method instead.

## Syntax

```cpp
BOOLEAN StrongNameKeyInstall (
    [in]  LPCWSTR   wszKeyContainer,
    [in]  BYTE      *pbKeyBlob,
    [in]  ULONG     cbKeyBlob
);
```

## Parameters

`wszKeyContainer`\
[in] The name of the key container. `wszKeyContainer` must be a non-empty string.

`pbKeyBlob`\
[in] The binary key pair.

`cbKeyBlob`\
[in] The size, in bytes, of `pbKeyBlob`.

## Return Value

`true` on successful completion; otherwise, `false`.

## Remarks

Use the [StrongNameKeyDelete](strongnamekeydelete-function.md) function to delete the key container.

If the `StrongNameKeyInstall` function does not complete successfully, call the [StrongNameErrorInfo](strongnameerrorinfo-function.md) function to retrieve the last generated error.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** StrongName.h

**Library:** Included as a resource in MsCorEE.dll

**.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [StrongNameKeyInstall Method](../hosting/iclrstrongname-strongnamekeyinstall-method.md)
- [StrongNameKeyDelete Method](../hosting/iclrstrongname-strongnamekeydelete-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
