---
description: "Learn more about: Authenticode (Unmanaged API Reference)"
title: "Authenticode (Unmanaged API Reference)"
ms.date: "03/30/2017"
ms.assetid: 7e8cc303-6e77-4116-aa8b-7ea297a3a467
---
# Authenticode (Unmanaged API Reference)

Supports the Authenticode XrML license creation and verification module.  
  
## In This Section  

 [_AxlGetIssuerPublicKeyHash Function](axlgetissuerpublickeyhash-function.md)  
 Retrieves the SHA-1 hash of the public key associated with the private key that is used to sign the specified certificate.  
  
 [_AxlPublicKeyBlobToPublicKeyToken Function](axlpublickeyblobtopublickeytoken-function.md)  
 Computes the strong name public key token from a CSP PUBLICKEYBLOB format.  
  
 [_AxlRSAKeyValueToPublicKeyToken Function](axlrsakeyvaluetopublickeytoken-function.md)  
 Converts a Modulus and Exponent to a strong name public key token.  
  
 [CertFreeAuthenticodeSignerInfo Function](certfreeauthenticodesignerinfo-function.md)  
 Frees resources allocated for the AXL_AUTHENTICODE_SIGNER_INFO structure.  
  
 [CertFreeAuthenticodeTimestamperInfo Function](certfreeauthenticodetimestamperinfo-function.md)  
 Frees resources allocated for the AXL_AUTHENTICODE_TIMESTAMPER_INFO structure.  
  
 [CertTimestampAuthenticodeLicense Function](certtimestampauthenticodelicense-function.md)  
 Time stamps an Authenticode XrML license created by CertCreateAuthenticodeLicense.  
  
 [CertVerifyAuthenticodeLicense Function](certverifyauthenticodelicense-function.md)  
 Verifies the validity of an Authenticode XrML license.  
  
 [AXL_AUTHENTICODE_SIGNER_INFO Structure](axl-authenticode-signer-info-structure.md)  
 Defines the Authenticode signer information.  
  
 [AXL_AUTHENTICODE_TIMESTAMPER_INFO Structure](axl-authenticode-timestamper-info-structure.md)  
 Defines the Authenticode time stamper information.  

## Requirements

**Library**: clr.dll
  
## See also

- [Unmanaged API Reference](../index.md)
