---
title: "Claims and Tokens"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "claims [WCF], and tokens"
ms.assetid: eff167f3-33f8-483d-a950-aa3e9f97a189
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Claims and Tokens
This topic describes the various claim types that [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] creates from the default tokens that it supports.  
  
 You can examine the claims of a client credential by using the <xref:System.IdentityModel.Claims.ClaimSet> and <xref:System.IdentityModel.Claims.Claim> classes. The `ClaimSet` contains a collection of `Claim` objects. Each `Claim` has the following important members:  
  
-   The <xref:System.IdentityModel.Claims.Claim.ClaimType%2A> property returns a Uniform Resource Identifier (URI) that specifies the type of claim being made. For example, a claim type may be a thumbprint of a certificate, in which case the URI is http:schemas.microsoft.com/ws/20005/05/identity/claims/thumprint.  
  
-   The <xref:System.IdentityModel.Claims.Claim.Right%2A> property returns a URI that specifies the right of the claim. Predefined rights are found in the <xref:System.IdentityModel.Claims.Rights> class (<xref:System.IdentityModel.Claims.Rights.Identity%2A>,  <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A>).  
  
-   The <xref:System.IdentityModel.Claims.Claim.Resource%2A> property returns the resource associated with the claim.  
  
 Each <xref:System.IdentityModel.Claims.ClaimSet> also has an <xref:System.IdentityModel.Claims.ClaimSet.Issuer%2A> property, which represents the <xref:System.IdentityModel.Claims.ClaimSet> of the `Issuer`.  
  
## Windows Accounts  
 Where a client credential maps to a Windows user account, the resulting <xref:System.IdentityModel.Claims.ClaimSet> has the following values:  
  
-   The `Issuer` is the value returned by the static Windows property of the <xref:System.IdentityModel.Claims.ClaimSet> class.  
  
-   The claims in the collection are:  
  
    -   A <xref:System.IdentityModel.Claims.Claim> with a <xref:System.IdentityModel.Claims.Claim.ClaimType%2A> value of security identifier (SID), a <xref:System.IdentityModel.Claims.Claim.Right%2A> property value of `Identity`, and a <xref:System.IdentityModel.Claims.Claim.Resource%2A> that returns the actual SID value. A SID is a unique value the domain controller issues to every user. The SID is used to identify the user in interactions with Windows security.  
  
    -   A <xref:System.IdentityModel.Claims.Claim> with a <xref:System.IdentityModel.Claims.Claim.ClaimType%2A> value of SID, a <xref:System.IdentityModel.Claims.Claim.Right%2A> of `PossessProperty`, and a <xref:System.IdentityModel.Claims.Claim.Resource%2A> of the SID value.  
  
    -   A <xref:System.IdentityModel.Claims.Claim> with a <xref:System.IdentityModel.Claims.Claim.ClaimType%2A> of <xref:System.IdentityModel.Claims.ClaimTypes.Name%2A>, a <xref:System.IdentityModel.Claims.Claim.Right%2A> of `PossessProperty` and a <xref:System.IdentityModel.Claims.Claim.Resource%2A> of string containing the user name (for example, "MYMACHINE\Bob").  
  
    -   Additional SID claims with <xref:System.IdentityModel.Claims.Rights.PossessProperty%2A> for the various groups the user belongs to.  
  
## Certificates  
 Where the client credential is a certificate, the resulting <xref:System.IdentityModel.Claims.ClaimSet> has the following values:  
  
-   For self-issued certificates, the `Issuer` is the <xref:System.IdentityModel.Claims.ClaimSet> itself. The <xref:System.IdentityModel.Claims.ClaimSet> returns a <xref:System.IdentityModel.Claims.Claim.ClaimType%2A> of <xref:System.IdentityModel.Claims.ClaimTypes.Thumbprint%2A>, a <xref:System.IdentityModel.Claims.Claim.Right%2A> of `Identity`, and a <xref:System.IdentityModel.Claims.Claim.Resource%2A> value that is a <xref:System.Byte> array containing the thumbprint of the certificate.  
  
-   For a certificate issued by a certification authority, the issuer is the `ClaimSet` representing the certification authority’s certificate.  
  
-   The `Claims` in the collection include:  
  
    -   A `Claim` with a `ClaimType` of Thumbprint, a `Right` of PossessProperty, and a `Resource` that is a byte array containing the thumbprint of the certificate  
  
    -   Additional PossessProperty claims of various types, including X500DistinguishedName, Dns, Name, Upn, and Rsa, represent various properties of the certificate. The resource for the Rsa claim is the public key associated with the certificate.**Note** Where the client credential type is a certificate that the service maps to a Windows account, two `ClaimSet` objects are generated. The first contains all the claims related to the Windows account and the second contains all the claims related to the certificate.  
  
## User Name/Password  
 Where the client credential is a user name/password (or equivalent) that does not map to a Windows account, the resulting `ClaimSet` is issued by the static <xref:System.IdentityModel.Claims.ClaimSet.System%2A> property of the `ClaimSet` class. The `ClaimSet` contains an `Identity` claim of type <xref:System.IdentityModel.Claims.ClaimTypes.Name%2A> whose resource is the user name the client provides. A corresponding claim has a `Right` of `PossessProperty`.  
  
## RSA Keys  
 Where an RSA key not associated with a certificate is used, the resulting `ClaimSet` is self-issued and contains an `Identity` claim of type <xref:System.IdentityModel.Claims.ClaimTypes.Rsa%2A> whose resource is the RSA key. A corresponding claim has a `Right` of `PossessProperty`.  
  
## SAML  
 Where the client authenticates with a Security Assertions Markup Language (SAML) token, the resulting `ClaimSet` is issued by the entity that signed the SAML token, often the certificate of the security token service (STS) that issued the SAML token. The `ClaimSet` contains various claims as found in the SAML token. If the SAML token contains a `SamlSubject` with a non-`null` name, then an `Identity` claim with a type of <xref:System.IdentityModel.Claims.ClaimTypes.NameIdentifier%2A> and a resource type of <xref:System.IdentityModel.Tokens.SamlNameIdentifierClaimResource> are created.  
  
## Identity Claims and ServiceSecurityContext.IsAnonymous  
 If none of the `ClaimSet` objects resulting from the client credentials contain a claim with a `Right` of `Identity,` then the <xref:System.ServiceModel.ServiceSecurityContext.IsAnonymous%2A> property returns `true`. If one or more such claims are present, the `IsAnonymous` property returns `false`.  
  
## See Also  
 <xref:System.IdentityModel.Claims.ClaimSet>  
 <xref:System.IdentityModel.Claims.Claim>  
 <xref:System.IdentityModel.Claims.Rights>  
 <xref:System.IdentityModel.Claims.ClaimTypes>  
 [Managing Claims and Authorization with the Identity Model](../../../../docs/framework/wcf/feature-details/managing-claims-and-authorization-with-the-identity-model.md)
