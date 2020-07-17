---
title: "CertVerifyAuthenticodeLicense Function"
ms.date: "03/30/2017"
api_name: 
  - "CertVerifyAuthenticodeLicense"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: 00118de7-33c6-41c4-8e1f-5d5e35e0da83
---
# CertVerifyAuthenticodeLicense Function
Verifies the validity of an Authenticode XrML license.  
  
## Syntax  
  
```cpp  
HRESULT CertVerifyAuthenticodeLicense (  
    [in]   PCRYPT_DATA_BLOB                   pLicenseBlob,  
    [in]   OPTIONAL DWORD                     dwFlags,  
    [out]  PAXL_AUTHENTICODE_SIGNER_INFO      pSignerInfo,  
    [out]  PAXL_AUTHENTICODE_TIMESTAMPER_INFO pTimestamperInfo  
);  
```  
  
## Parameters  
 `pLicenseBlob`  
 [in] The Authenticode XrML license to be verified.  
  
 See the [CRYPTOAPI_BLOB](/windows/win32/api/dpapi/ns-dpapi-crypt_integer_blob) structure.  
  
 `dwFlags`  
 [in] Optional. A combination of following values:  
  
- AXL_REVOCATION_NO_CHECK  
  
- AXL_REVOCATION_CHECK_END_CERT_ONLY  
  
- AXL_REVOCATION_CHECK_ENTIRE_CHAIN  
  
- AXL_URL_CACHE_ONLY_RETRIEVAL  
  
- AXL_LIFETIME_SIGNING  
  
- AXL_TRUST_MICROSOFT_ROOT_ONLY  
  
 `pSignerInfo`  
 [out] To receive the signer's information. If the license wasn't signed, `dwError` is set to TRUST_E_NOSIGNATURE. It is the caller's responsibility to free resources by using the [CertFreeAuthenticodeSignerInfo](certfreeauthenticodesignerinfo-function.md) function after use.  
  
 See [AXL_AUTHENTICODE_SIGNER_INFO Structure](axl-authenticode-signer-info-structure.md).  
  
 `pTimestamperInfo`  
 [out] To receive time stamper's information, if available. If the license was not time-stamped, `dwError` is set to TRUST_E_NOSIGNATURE. It is the caller's responsibility to free resources by using the [CertFreeAuthenticodeTimestamperInfo](certfreeauthenticodetimestamperinfo-function.md) function after use.  
  
 See [AXL_AUTHENTICODE_TIMESTAMPER_INFO Structure](axl-authenticode-timestamper-info-structure.md).  
  
## Return Value  
 Returns `S_OK` if successful. Otherwise, returns an error code.  
  
## See also

- [Authenticode](index.md)
- [GetHashFromHandle Method](../hosting/iclrstrongname-gethashfromhandle-method.md)
- [ICLRStrongName Interface](../hosting/iclrstrongname-interface.md)
