---
description: "Learn more about: Claim Creation and Resource Values"
title: "Claim Creation and Resource Values"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "claims [WCF], creation and resource values"
ms.assetid: 30431f76-cbe7-4bad-bad7-8e43e23a82d4
---
# Claim Creation and Resource Values

The <xref:System.IdentityModel.Claims.Claim> class provides several methods for creating instances of built-in claims types. Of these methods, the following perform no semantic or format checking on the supplied resource:

- <xref:System.IdentityModel.Claims.Claim.CreateDnsClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateHashClaim*> (does not check the length or content of the byte array)

- <xref:System.IdentityModel.Claims.Claim.CreateNameClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateSpnClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateThumbprintClaim*> (does not check the length or content of the byte array)

- <xref:System.IdentityModel.Claims.Claim.CreateUpnClaim*>

 Care should be taken when calling the above methods to ensure that the resource values passed in are of the correct format or contain the correct kind of information (or both).

 The following methods take specific types:

- <xref:System.IdentityModel.Claims.Claim.CreateDenyOnlyWindowsSidClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateMailAddressClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateRsaClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateUriClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateWindowsSidClaim*>

- <xref:System.IdentityModel.Claims.Claim.CreateX500DistinguishedNameClaim*>

## See also

- <xref:System.IdentityModel.Claims.Claim>
- <xref:System.IdentityModel.Claims.ClaimSet>
- [Managing Claims and Authorization with the Identity Model](managing-claims-and-authorization-with-the-identity-model.md)
