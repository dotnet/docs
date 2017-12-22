---
title: "Namespace Mapping between WIF 3.5 and WIF 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a092d98c-444d-4336-a644-63c2e11e96c8
caps.latest.revision: 4
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Namespace Mapping between WIF 3.5 and WIF 4.5
Beginning with .NET 4.5, Windows Identity Foundation (WIF) has been fully integrated into the .NET Framework. This integration engendered name changes and some consolidation of the WIF namespaces and API surface. This topic provides some guidance and a general mapping between the WIF 3.5 namespaces and the WIF 4.5 namespaces. It is not intended to be exhaustive, but rather provide some general information about where to find familiar WIF 3.5 classes in WIF 4.5. For more detailed information about the differences between WIF 3.5 and WIF 4.5, see [What's New in Windows Identity Foundation 4.5](../../../docs/framework/security/whats-new-in-wif.md). For guidance about how to migrate an applications built using WIF 3.5 to WIF 4.5, see [Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5](../../../docs/framework/security/guidelines-for-migrating-an-application-built-using-wif-3-5-to-wif-4-5.md).  
  
## WIF 3.5 to WIF 4.5 Namespace Map  
 The WIF classes, which were collected under the `Microsoft.IdentityModel` namespaces in WIF 3.5, are now distributed among the following namespaces: `System.Security.Claims`, `System.ServiceModel.Security`, and the `System.IdentityModel` namespaces in WIF 4.5. In addition some WIF 3.5 namespaces were consolidated or dropped entirely in WIF 4.5.  
  
> [!IMPORTANT]
>  The following `System.IdentityModel` namespaces contain classes that implement the WCF claims-based identity model: <xref:System.IdentityModel.Claims?displayProperty=nameWithType>, <xref:System.IdentityModel.Policy?displayProperty=nameWithType>, and <xref:System.IdentityModel.Selectors?displayProperty=nameWithType>. The WCF claims-based identity model is superseded by WIF. You should not use classes in these three namespaces when building solutions based on WIF.  
  
 The following table provides information about where WIF 3.5 classes can be found in WIF 4.5.  
  
|**WIF 3.5 Namespace**|**WIF 4.5 Namespace**|**Comments**|  
|-|-|-|  
|`Microsoft.IdentityModel`|<xref:System.IdentityModel?displayProperty=nameWithType>|-   Most of the classes that represent constants are not implemented.<br />-   The classes that are used to build security token services have been moved from `Microsoft.IdentityModel.SecurityTokenService` to <xref:System.IdentityModel?displayProperty=nameWithType>.<br />-   The classes in `Microsoft.IdentityModel.Threading` have been moved to <xref:System.IdentityModel?displayProperty=nameWithType>.<br />-   The `ExceptionMapper` and `MruSecurityTokenCache` classes are not implemented.|  
|`Microsoft.IdentityModel.Claims`|<xref:System.Security.Claims?displayProperty=nameWithType>|-   The `IClaimsPrincipal` and `IClaimsIdentity` interfaces are not implemented in WIF 4.5. Instead <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType> and <xref:System.Security.Claims.ClaimsIdentity?displayProperty=nameWithType> are now the base classes from which most .NET principal and identity classes derive. This means there is no need for specialized claims principal and identity classes like `Microsoft.IdentityModel.Claims.WindowsClaimsPrincipal` and `Microsoft.IdentityModel.Claims.WindowsClaimsIdentity` in WIF 4.5,  use <xref:System.Security.Principal.WindowsPrincipal?displayProperty=nameWithType> and <xref:System.Security.Principal.WindowsIdentity?displayProperty=nameWithType> instead. The same is true for other for the other specialized claims principal and identity classes that existed in WIF 3.5.<br />-   The `Microsoft.IdentityModel.Claims.ClaimsCollection` class is not implemented in WIF 4.5. Instead, collections of claims are exposed as enumerable collections of type <xref:System.Security.Claims.Claim?displayProperty=nameWithType>.<br />-   <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType> and <xref:System.Security.Claims.ClaimsIdentity?displayProperty=nameWithType> provide methods that  now fully support LINQ.|  
|`Microsoft.IdentityModel.Configuration`|<xref:System.IdentityModel.Configuration?displayProperty=nameWithType>|Some elements and classes have undergone name changes and some have been dropped in WIF 4.5; for example `Microsoft.IdentityModel.Configuraiton.ServiceConfiguration` is now <xref:System.IdentityModel.Configuration.IdentityConfiguration?displayProperty=nameWithType>.|  
|`Microsoft.IdentityModel.Protocols`|<xref:System.IdentityModel.Services?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Protocols.WSFederation`|<xref:System.IdentityModel.Services?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Protocols.WSFederation.Metadata`|<xref:System.IdentityModel.Metadata?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Protocols.WSIdentity`|Not Implemented in WIF 4.5|In WIF 3.5 contained classes to support CardSpace, not implemented in WIF 4.5.|  
|`Microsoft.IdentityModel.Protocols.WSTrust`|Split between the <xref:System.IdentityModel.Protocols.WSTrust?displayProperty=nameWithType> and  <xref:System.ServiceModel.Security?displayProperty=nameWithType> namespaces.|Classes that represents WS-Trust artifacts are in the <xref:System.IdentityModel.Protocols.WSTrust?displayProperty=nameWithType> namespace; for example, the <xref:System.IdentityModel.Protocols.WSTrust.RequestSecurityToken> class. Classes that represent WCF service contracts, service hosts, and channels that enable a WCF service to communicate using the WS-Trust protocol are in the <xref:System.ServiceModel.Security?displayProperty=nameWithType> namespace; for example, the <xref:System.ServiceModel.Security.WSTrustServiceHost> class.|  
|`Microsoft.IdentityModel.Protocols.WSTrust.Bindings`|Not Implemented in WIF 4.5|-|  
|`Microsoft.IdentityModel.Protocols.XmlEncryption`|Not Implemented in WIF 4.5|Contained classes that represent XML Encryption constants in WIF 3.5. These constants are not implemented in WIF 4.5.|  
|`Microsoft.IdentityModel.Protocols.XmlSignature`|<xref:System.IdentityModel?displayProperty=nameWithType>|The `EnvelopingSignature` class and classes that represent constants are not implemented.|  
|`Microsoft.IdentityModel.SecurityTokenService`|Split between the <xref:System.IdentityModel?displayProperty=nameWithType>, <xref:System.IdentityModel.Protocols.WSTrust?displayProperty=nameWithType>, and <xref:System.IdentityModel.Tokens?displayProperty=nameWithType> namespaces.|-|  
|`Microsoft.IdentityModel.Threading`|<xref:System.IdentityModel?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Tokens`|<xref:System.IdentityModel.Tokens?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Tokens.Saml11`|<xref:System.IdentityModel.Tokens?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Tokens.Saml2`|<xref:System.IdentityModel.Tokens?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Web`|<xref:System.IdentityModel.Services?displayProperty=nameWithType>|-|  
|`Microsoft.IdentityModel.Web.Configuration`|<xref:System.IdentityModel.Services.Configuration?displayProperty=nameWithType>|Classes that provide configuration for passive (WS-Federation) scenarios have largely been moved to <xref:System.IdentityModel.Services.Configuration?displayProperty=nameWithType>; however, some of these classes are in <xref:System.IdentityModel.Services?displayProperty=nameWithType>.|  
|`Microsoft.IdentityModel.Web.Controls`|Not Implemented in WIF 4.5|The classes in `Microsoft.IdentityModel.Web.Controls` implemented the Federated Passive Sign-In Control, which does not exist in WIF 4.5.|  
|`Microsoft.IdentityModel.WindowsTokenService`|Not Implemented in WIF 4.5|-|  
  
## See Also  
 [What's New in Windows Identity Foundation 4.5](../../../docs/framework/security/whats-new-in-wif.md)  
 [Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5](../../../docs/framework/security/guidelines-for-migrating-an-application-built-using-wif-3-5-to-wif-4-5.md)
