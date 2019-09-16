---
title: "CertTimestampAuthenticodeLicense Function"
ms.date: "03/30/2017"
api_name: 
  - "CertTimestampAuthenticodeLicense"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: d468325a-21c5-43ce-8567-84e342b22308
author: "rpetrusha"
ms.author: "ronpet"
---
# CertTimestampAuthenticodeLicense Function
Time-stamps an Authenticode XrML license.  
  
## Syntax  
  
```cpp  
HRESULT CertTimestampAuthenticodeLicense (  
    [in]  PCRYPT_DATA_BLOB   pSignedLicenseBlob,  
    [in]  LPCWSTR            pwszTimestampURI,  
    [out] PCRYPT_DATA_BLOB   pTimestampSignatureBlob  
);  
```  
  
## Parameters  
 `pSignedLicenseBlob`  
 [in] The signed Authenticode XrML license to be time-stamped. See the [CRYPTOAPI_BLOB](/windows/win32/api/dpapi/ns-dpapi-crypt_integer_blob) structure.  
  
 `pwszTimestampURI`  
 [in] The time-stamp server's URI.  
  
 `pTimestampSignatureBlob`  
 [out] A pointer to CRYPT_DATA_BLOB to receive the base64-encoded time-stamp signature. It is the caller's responsibility to free `pTimestampSignatureBlob`->`pbData` with `HepFree()` after use. See the [CRYPTOAPI_BLOB](/windows/win32/api/dpapi/ns-dpapi-crypt_integer_blob) structure.  
  
## Remarks  
 The time-stamp signature is actually a PKCS #7 SignedData message whose content is the binary form of the SignatureValue from the license's signature. Basically, this acts as a counter-signature of the license.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See also

- [Authenticode](index.md)
