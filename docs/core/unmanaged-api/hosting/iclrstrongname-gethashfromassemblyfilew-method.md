---
description: "Learn more about: ICLRStrongName::GetHashFromAssemblyFileW Method"
title: "ICLRStrongName::GetHashFromAssemblyFileW Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRStrongName.GetHashFromAssemblyFileW"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRStrongName::GetHashFromAssemblyFileW"
helpviewer_keywords:
  - "ICLRStrongName::GetHashFromAssemblyFileW method [.NET Framework hosting]"
  - "GetHashFromAssemblyFileW method, ICLRStrongName interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRStrongName::GetHashFromAssemblyFileW Method

Generates a hash over the contents of the file specified by a Unicode string.

## Syntax

```cpp
HRESULT GetHashFromAssemblyFileW (
    [in]  LPCWSTR   wszFilePath,
    [in, out] unsigned int   *piHashAlg,
    [out] BYTE      *pbHash,
    [in]  DWORD     cchHash,
    [out] DWORD     *pchHash
);
```

## Parameters

 `wszFilePath`
 [in] The path to the file to be hashed. This parameter must be a Unicode string.

 `piHashAlg`
 [in, out] A constant that specifies the hash algorithm. Use zero for the default hash algorithm.

 `pbHash`
 [out] The returned hash buffer.

 `cchHash`
 [in] The requested maximum size of `pbHash`.

 `pchHash`
 [out] The returned size, in bytes, of `pbHash`.

## Return Value

 `S_OK` if the method completed successfully; otherwise, an HRESULT value that indicates failure (see [Common HRESULT Values](/windows/win32/seccrypto/common-hresult-values) for a list).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MetaHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]

## See also

- [GetHashFromAssemblyFile Method](iclrstrongname-gethashfromassemblyfile-method.md)
- [ICLRStrongName Interface](iclrstrongname-interface.md)
