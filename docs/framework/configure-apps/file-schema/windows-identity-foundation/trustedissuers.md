---
title: "&lt;trustedIssuers&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d818c917-07b4-40db-9801-8676561859fd
caps.latest.revision: 7
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# &lt;trustedIssuers&gt;
Configures the list of trusted issuer certificates used by the configuration-based issuer name registry (<xref:System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry>).  
  
 \<system.identityModel>  
\<identityConfiguration>  
\<securityTokenHandlers>  
\<securityTokenHandlerConfiguration>  
\<issuerNameRegistry>  
\<trustedIssuers>  
  
## Syntax  
  
```xml  
<system.identityModel>  
  <identityConfiguration>  
    <securityTokenHandlers>  
      <securityTokenHandlerConfiguration>  
        <issuerNameRegistry>  
          <trustedIssuers>  
            <add thumbprint=xs:string name=xs:string>  
            <clear>  
            <remove thumbprint=xs:string>  
          </trustedIssuers>  
        </issuerNameRegistry>  
      </securityTokenHandlerConfiguration>  
    </securityTokenHandlers>  
  </identityConfiguration>  
</system.identityModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|`<add thumbprint=xs:string name=xs:string>`|Adds a certificate to the collection of trusted issuers. The certificate is specified with the `thumbprint` attribute. This attribute is required and should contain the ASN.1 encoded form of the certificate thumbprint. The `name` attribute is optional and can be used to specify a friendly name for the certificate.|  
|`<clear>`|Clears all certificates from the collection of trusted issuers.|  
|`<remove thumbprint=xs:string>`|Removes a certificate from the collection of trusted issuers. The certificate is specified with the `thumbprint` attribute. This attribute is required.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<issuerNameRegistry>](../../../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/issuernameregistry.md)|Configures the issuer name registry. **Important:**  The `type` attribute of the `<issuerNameRegistry>` element must reference the <xref:System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry> class for the `<trustedIssuers>` element to be valid.|  
  
## Remarks  
 Windows Identity Foundation (WIF) provides a single implementation of the <xref:System.IdentityModel.Tokens.IssuerNameRegistry> class out of the box, the <xref:System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry> class. The configuration issuer name registry maintains a list of trusted issuers that is loaded from configuration. The list associates each issuer name with the X.509 certificate that is needed to verify the signature of tokens produced by the issuer. The list of trusted issuer certificates is specified under the `<trustedIssuers>` element. Each element in the list associates a mnemonic issuer name with the X.509 certificate that is needed to verify the signature of tokens produced by that issuer. Trusted certificates are specified using the ASN.1 encoded form of the certificate thumbprint and are added the collection by using `<add>` element. You can clear or remove issuers (certificates) from the list by using the `<clear>` and `<remove>` elements.  
  
 The `type` attribute of the `<issuerNameRegistry>` element must reference the <xref:System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry> class for the `<trustedIssuers>` element to be valid.  
  
## Example  
 The following XML shows how to specify the configuration based issuer name registry.  
  
```xml  
<issuerNameRegistry type="System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089">  
  <trustedIssuers>  
    <add thumbprint="9B74CB2F32 … B1DC01EF40D0" name="LocalSTS" />  
  </trustedIssuers>  
</issuerNameRegistry>  
```  
  
## See Also  
 <xref:System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry>  
 <xref:System.IdentityModel.Tokens.IssuerNameRegistry>
