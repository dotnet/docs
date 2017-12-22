---
title: "Authenticode (Unmanaged API Reference)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 7e8cc303-6e77-4116-aa8b-7ea297a3a467
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Authenticode (Unmanaged API Reference)
Supports the Authenticode XrML license creation and verification module.  
  
## In This Section  
 [_AxlGetIssuerPublicKeyHash Function](../../../../docs/framework/unmanaged-api/authenticode/axlgetissuerpublickeyhash-function.md)  
 Retrieves the SHA-1 hash of the public key associated with the private key that is used to sign the specified certificate.  
  
 [_AxlPublicKeyBlobToPublicKeyToken Function](../../../../docs/framework/unmanaged-api/authenticode/axlpublickeyblobtopublickeytoken-function.md)  
 Computes the strong name public key token from a CSP PUBLICKEYBLOB format.  
  
 [_AxlRSAKeyValueToPublicKeyToken Function](../../../../docs/framework/unmanaged-api/authenticode/axlrsakeyvaluetopublickeytoken-function.md)  
 Converts a Modulus and Exponent to a strong name public key token.  
  
 [CertFreeAuthenticodeSignerInfo Function](../../../../docs/framework/unmanaged-api/authenticode/certfreeauthenticodesignerinfo-function.md)  
 Frees resources allocated for the AXL_AUTHENTICODE_SIGNER_INFO structure.  
  
 [CertFreeAuthenticodeTimestamperInfo Function](../../../../docs/framework/unmanaged-api/authenticode/certfreeauthenticodetimestamperinfo-function.md)  
 Frees resources allocated for the AXL_AUTHENTICODE_TIMESTAMPER_INFO structure.  
  
 [CertTimestampAuthenticodeLicense Function](../../../../docs/framework/unmanaged-api/authenticode/certtimestampauthenticodelicense-function.md)  
 Time stamps an Authenticode XrML license created by CertCreateAuthenticodeLicense.  
  
 [CertVerifyAuthenticodeLicense Function](../../../../docs/framework/unmanaged-api/authenticode/certverifyauthenticodelicense-function.md)  
 Verifies the validity of an Authenticode XrML license.  
  
 [AXL_AUTHENTICODE_SIGNER_INFO Structure](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-signer-info-structure.md)  
 Defines the Authenticode signer information.  
  
 [AXL_AUTHENTICODE_TIMESTAMPER_INFO Structure](../../../../docs/framework/unmanaged-api/authenticode/axl-authenticode-timestamper-info-structure.md)  
 Defines the Authenticode time stamper information.  
  
## See Also  
 [Unmanaged API Reference](../../../../docs/framework/unmanaged-api/index.md)
