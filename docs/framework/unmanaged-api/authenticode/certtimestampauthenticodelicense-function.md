---
title: "CertTimestampAuthenticodeLicense Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CertTimestampAuthenticodeLicense"
api_location: 
  - "clr.dll"
api_type: 
  - "DLLExport"
ms.assetid: d468325a-21c5-43ce-8567-84e342b22308
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CertTimestampAuthenticodeLicense Function
Time-stamps an Authenticode XrML license.  
  
## Syntax  
  
```  
HRESULT CertTimestampAuthenticodeLicense (  
    [in]  PCRYPT_DATA_BLOB   pSignedLicenseBlob,  
    [in]  LPCWSTR            pwszTimestampURI,  
    [out] PCRYPT_DATA_BLOB   pTimestampSignatureBlob  
);  
```  
  
#### Parameters  
 `pSignedLicenseBlob`  
 [in] The signed Authenticode XrML license to be time-stamped. See the [CRYPTOAPI_BLOB](http://msdn.microsoft.com/library/windows/desktop/aa380238.aspx) structure.  
  
 `pwszTimestampURI`  
 [in] The time-stamp server's URI.  
  
 `pTimestampSignatureBlob`  
 [out] A pointer to CRYPT_DATA_BLOB to receive the base64-encoded time-stamp signature. It is the caller's responsibility to free `pTimestampSignatureBlob`->`pbData` with `HepFree()` after use. See the [CRYPTOAPI_BLOB](http://msdn.microsoft.com/library/windows/desktop/aa380238.aspx) structure.  
  
## Remarks  
 The time-stamp signature is actually a PKCS #7 SignedData message whose content is the binary form of the SignatureValue from the license's signature. Basically, this acts as a counter-signature of the license.  
  
## Return Value  
 `S_OK` if the function succeeds. Otherwise, returns an error code.  
  
## See Also  
 [Authenticode](../../../../docs/framework/unmanaged-api/authenticode/index.md)
