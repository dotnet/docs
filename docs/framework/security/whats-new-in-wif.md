---
title: "What&#39;s New in Windows Identity Foundation 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3b381f04-593b-471f-bd33-0362be1aade5
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# What&#39;s New in Windows Identity Foundation 4.5
The first version of Windows Identity Foundation (WIF) shipped as a standalone download and is known as WIF 3.5 because it was introduced in the .NET 3.5 SP1 timeframe. Starting with .NET 4.5, WIF is part of the .NET framework. Having the WIF classes directly available in the framework allows for a much deeper integration of claims-based identity in .NET, making it easier to use claims. Applications written for WIF 3.5 will need to be modified in order to take advantage of the new model; for information, see [Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5](../../../docs/framework/security/guidelines-for-migrating-an-application-built-using-wif-3-5-to-wif-4-5.md).  
  
 Below you can find some highlights of the main changes.  
  
## WIF Is Now Part of the .NET Framework  
 WIF classes are now spread across several assemblies, the main ones being `mscorlib`, `System.IdentityModel`, `System.IdentityModel.Services`, and `System.ServiceModel`. Likewise, the WIF classes are spread across several namespaces: <xref:System.Security.Claims?displayProperty=nameWithType>, several [System.IdentityModel](http://go.microsoft.com/fwlink/?LinkId=272004) namespaces, and <xref:System.ServiceModel.Security?displayProperty=nameWithType>. The <xref:System.Security.Claims?displayProperty=nameWithType> namespace contains the new <xref:System.Security.Claims.ClaimsPrincipal> and <xref:System.Security.Claims.ClaimsIdentity> classes (see below). All principals in .NET now derive from <xref:System.Security.Claims.ClaimsPrincipal>. For more detailed information about the WIF namespaces and the kinds of classes that they contain, see [WIF API Reference](../../../docs/framework/security/wif-api-reference.md). For information about how namespaces map between WIF 3.5 and WIF 4.5, see [Namespace Mapping between WIF 3.5 and WIF 4.5](../../../docs/framework/security/namespace-mapping-between-wif-3-5-and-wif-4-5.md).  
  
## New Claims Model and Principal Object  
 Claims are at the very core of the .NET Framework 4.5. The base claim classes (<xref:System.Security.Claims.Claim>, <xref:System.Security.Claims.ClaimsIdentity>, <xref:System.Security.Claims.ClaimsPrincipal>, <xref:System.Security.Claims.ClaimTypes>, and <xref:System.Security.Claims.ClaimValueTypes>) all live directly in `mscorlib` in the <xref:System.Security.Claims?displayProperty=nameWithType> namespace. It is no longer necessary to use interfaces in order to plug claims into the .NET identity system: <xref:System.Security.Principal.WindowsPrincipal>, <xref:System.Security.Principal.GenericPrincipal>, and <xref:System.Web.Security.RolePrincipal> now inherit from <xref:System.Security.Claims.ClaimsPrincipal>; and <xref:System.Security.Principal.WindowsIdentity>, <xref:System.Security.Principal.GenericIdentity>, and <xref:System.Web.Security.FormsIdentity> now inherit from <xref:System.Security.Claims.ClaimsIdentity>. In short, every principal class will now serve claims. The WIF 3.5 integration classes and interfaces (`WindowsClaimsIdentity`, `WindowsClaimsPrincipal`, `IClaimsPrincipal`, `IClaimsIdentity`) have thus been removed. In addition, the <xref:System.Security.Claims.ClaimsIdentity> class now exposes methods which make it easier to query the identity’s claims collection.  
  
## Changes to the WIF 4.5 Visual Studio Experience  
  
-   The **Add STS Reference …** Visual Studio functionality (cmdline utility FedUtil) no longer exists; instead you can use the new Visual Studio extension **Identity and Access Tool for Visual Studio 2012**. This allows you to federate with an existing STS or use LocalSTS to test your solutions. After installing the extension you can right-click on your project and look for **Identity and Access** in the context menu.  
  
-   The ASP.NET and STS templates are no longer provided as claims can be used directly in existing project templates for ASP.Net, web sites, and WCF.  
  
-   The controls in the `Microsoft.IdentityModel.Web.Controls` namespace (`SignInControl`, `FederatedPassiveSignInControl`, and `FederatedPassiveSignInStatus`) are not carried over into WIF 4.5.  
  
## Changes to the WIF 4.5 API  
  
-   In general, claims related classes are in the <xref:System.Security.Claims?displayProperty=nameWithType> namespace; WCF related classes –- service contracts, channels, channel factories, and service hosts that are used for WS-Trust scenarios -- are in <xref:System.ServiceModel.Security?displayProperty=nameWithType>; and all other WIF classes are spread across various [System.IdentityModel](http://go.microsoft.com/fwlink/?LinkId=272004) namespaces – these include, for example, classes that represent WS-* and SAML artifacts, token handlers and related classes, and classes used in WS-Federation scenarios. For more information, see [Namespace Mapping between WIF 3.5 and WIF 4.5](../../../docs/framework/security/namespace-mapping-between-wif-3-5-and-wif-4-5.md) and [WIF API Reference](../../../docs/framework/security/wif-api-reference.md).  
  
-   Machine key has been enabled for use in session cookies for web farm scenarios. For more information, see [WIF and Web Farms](../../../docs/framework/security/wif-and-web-farms.md).  
  
-   You now declaratively configure WIF under the [\<system.identityModel>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md) and [\<system.identityModel.services>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel-services.md) elements. For more information about WIF configuration, see [WIF Configuration Reference](../../../docs/framework/security/wif-configuration-reference.md).  
  
## Other notable .NET changes or features that are caused by the integration of WIF into .NET  
  
-   The potential for performing claims-based authorization (CBAC) is now integral to the .NET framework. You can configure a <xref:System.Security.Claims.ClaimsAuthorizationManager> object and then use the <xref:System.IdentityModel.Services.ClaimsPrincipalPermission> and <xref:System.IdentityModel.Services.ClaimsPrincipalPermissionAttribute> classes to perform imperative and declarative access checks in your code. CBAC provides more flexibility and greater granularity than traditional role-based access checks (RBAC). It also allows greater separation of authorization policy from business logic because the business logic can base the access check on a specific claim or set of claims and the authorization policy for those claims can be configured declaratively under the [\<claimsAuthorizationManager>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/claimsauthorizationmanager.md) element.  
  
## WCF changes as a result of WIF integration:  
  
-   The WCF claims-based identity model is superseded by WIF. This means that classes in the <xref:System.IdentityModel.Claims?displayProperty=nameWithType>, <xref:System.IdentityModel.Policy?displayProperty=nameWithType>, and <xref:System.IdentityModel.Selectors?displayProperty=nameWithType> namespaces should be dropped in favor of using WIF classes.  
  
-   WIF is now enabled on a WCF service by specifying the `useIdentityConfiguration` attribute on the `<system.serviceModel>`/`<behaviors>`/`<serviceBehaviors>`/`<serviceCredentials>` element as in the following XML:  
  
    ```xml  
    <serviceCredentials useIdentityConfiguration="true">  
        <!--Certificate added by Identity And Access VS Package.  Subject='CN=localhost', Issuer='CN=localhost'. Make sure you have this certificate installed. The Identity and Access tool does not install this certificate.-->  
        <serviceCertificate findValue="CN=localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectDistinguishedName" />  
    </serviceCredentials>  
    ```  
  
     When you use the **Identity and Access Tool for Visual Studio 2012** (see **Changes to the Visual Studio Experience** above), the tool adds a `<serviceCredentials>` element with the `useIdentityConfiguration` attribute set to the configuration file for you. It also adds a corresponding [\<system.identityModel>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md) element that contains the WIF configuration settings and adds a binding and other settings necessary to outsource authentication to your chosen STS.  
  
## See Also  
 [Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5](../../../docs/framework/security/guidelines-for-migrating-an-application-built-using-wif-3-5-to-wif-4-5.md)  
 [Namespace Mapping between WIF 3.5 and WIF 4.5](../../../docs/framework/security/namespace-mapping-between-wif-3-5-and-wif-4-5.md)  
 [WIF API Reference](../../../docs/framework/security/wif-api-reference.md)  
 [WIF Configuration Reference](../../../docs/framework/security/wif-configuration-reference.md)
