---
title: "&lt;add&gt; of &lt;claimTypeRequirements&gt; element"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3234cd45-1478-468e-8b19-5c50815c4786
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;claimTypeRequirements&gt; element
Specifies the types of required and optional claims expected to appear in the federated credential. For example, services state the requirements on incoming credentials, which must possess a certain set of claim types.  
  
 \<system.ServiceModel>  
\<bindings>  
\<wsFederatedBinding>  
\<binding>  
\<security>  
\<message>  
\<claimTypeRequirements>  
  
## Syntax  
  
```xml  
<claimTypeRequirements>  
      <add claimType="URI"  
        isOptional="Boolean" />  
</claimTypeRequirements>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|claimType|A URI that defines the type of a claim. For example, to purchase a product from a Web site, the user must present a valid credit card with sufficient credit limit. The claim type would be the credit card URI.|  
|isOptional|A Boolean value that specifies if this is for an optional claim. Set this attribute to `false` if this is a required claim.<br /><br /> You can use this attribute when the service asks for some information but does not require it. For example, if you require the user to enter his/her first name, last name and address, but decide that phone number is optional.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<claimTypeRequirements>](../../../../../docs/framework/configure-apps/file-schema/wcf/claimtyperequirements-for-message.md)|Specifies a collection of required claim types. Each element is of type <xref:System.ServiceModel.Configuration.ClaimTypeElement>.<br /><br /> In a federated scenario, services state the requirements on incoming credentials. For example, the incoming credentials must possess a certain set of claim types. Each element in this collection specifies the types of required and optional claims expected to appear in a federated credential.|  
  
## Remarks  
 In a federated scenario, services state the requirements on incoming credentials. For example, the incoming credentials must possess a certain set of claim types. This requirement is manifested in a security policy. When a client requests credentials from a federated service (for example, CardSpace), it puts the requirements into a token request (RequestSecurityToken) so that the federated service can issue the credentials that satisfy the requirements accordingly.  
  
## Example  
 The following configuration adds two claim type requirements to a security binding.  
  
```xml  
<bindings>  
    <wsFederationHttpBinding>  
      <binding name="myFederatedBinding">  
        <security mode="Message">  
          <message issuedTokenType="urn:oasis:names:tc:SAML:1.0:assertion">  
            <claimTypeRequirements>  
              <add claimType=  
"http://schemas.microsoft.com/ws/2005/05/identity/claims/EmailAddress"/>  
              <add claimType=  
"http://schemas.microsoft.com/ws/2005/05/identity/claims/UserName"    
optional="true" />  
            </claims>  
          </message>  
        </security>  
      </binding>  
    </wsFederationHttpBinding>  
</bindings>  
```  
  
## See Also  
 <xref:System.ServiceModel.FederatedMessageSecurityOverHttp.ClaimTypeRequirements%2A>  
 <xref:System.ServiceModel.Security.Tokens.ClaimTypeRequirement>  
 <xref:System.ServiceModel.Configuration.FederatedMessageSecurityOverHttpElement.ClaimTypeRequirements%2A>  
 <xref:System.ServiceModel.Configuration.ClaimTypeElementCollection>  
 <xref:System.ServiceModel.Configuration.ClaimTypeElement>
