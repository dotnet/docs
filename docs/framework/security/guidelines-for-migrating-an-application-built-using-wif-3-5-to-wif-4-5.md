---
title: "Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7a32fe6e-5f68-4693-9371-19411fa8063c
caps.latest.revision: 12
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Guidelines for Migrating an Application Built Using WIF 3.5 to WIF 4.5
## Applies To  
  
-   Microsoft® Windows® Identity Foundation (WIF) 3.5 and 4.5.  
  
## Overview  
 Windows Identity Foundation (WIF) was originally released in the .NET 3.5 SP1 timeframe. That version of WIF is referred to as WIF 3.5. It was released as a separate runtime and SDK, which meant that every computer on which a WIF-enabled application ran had to have the WIF runtime installed and developers had to download and install the WIF SDK to get the Visual Studio templates and tooling that enabled development of WIF-enabled applications. Beginning with .NET 4.5, WIF has been fully integrated into the .NET Framework. A separate runtime is no longer needed and the WIF tooling can be installed in Visual Studio 2012 by using the Visual Studio Extensions Manager. This version of WIF is referred to as WIF 4.5.  
  
 The integration of WIF into .NET necessitated several changes in the WIF API surface. WIF 4.5 includes new namespaces, some changes to configuration elements, and new tooling for Visual Studio. This topic provides guidance that you can use to help you migrate applications built using WIF 3.5 to WIF 4.5. There may be scenarios in which you need to run legacy applications built using WIF 3.5 on computers that are running Windows 8 or Windows Server 2012. This topic also provides guidance about how to enable WIF 3.5 for these operating systems.  
  
## Changes Required for WIF 4.5  
 This section describes the changes that are required to migrate a WIF 3.5 application to WIF 4.5.  
  
### Assembly and Namespace Changes  
 In WIF 3.5, all of the WIF classes were contained in the `Microsoft.IdentityModel` assembly (microsoft.identitymicrosoft.identitymodel.dll). In WIF 4.5, the WIF classes have been split across the following assemblies: `mscorlib` (mscorlib.dll), `System.IdentityModel` (System.IdentityModel.dll), `System.IdentityModel.Services` (System.IdentityModel.Services.dll), and `System.ServiceModel` (System.ServiceModel.dll).  
  
 The WIF 3.5 classes were all contained in one of the `Microsoft.IdentityModel` namespaces; for example, `Microsoft.IdentityModel`, `Microsoft.IdentityModel.Tokens`, `Microsoft.IdentityModel.Web`, and so on. In WIF 4.5, the WIF classes are now spread across the [System.IdentityModel](http://go.microsoft.com/fwlink/?LinkId=272004) namespaces, the <xref:System.Security.Claims?displayProperty=nameWithType> namespace, and the <xref:System.ServiceModel.Security?displayProperty=nameWithType> namespace. In addition to this reorganization, some WIF 3.5 classes have been dropped in WIF 4.5.  
  
 The following table shows some of the more important WIF 4.5 namespaces and the kind of classes they contain. For more detailed information about how namespaces map between WIF 3.5 and WIF 4.5 and about namespaces and classes that have been dropped in WIF 4.5, see [Namespace Mapping between WIF 3.5 and WIF 4.5](../../../docs/framework/security/namespace-mapping-between-wif-3-5-and-wif-4-5.md).  
  
|WIF 4.5 Namespace|Description|  
|-----------------------|-----------------|  
|<xref:System.IdentityModel?displayProperty=nameWithType>|Contains classes that represent cookie transforms, security token services, and specialized XML dictionary readers. Contains classes from the following WIF 3.5 namespaces: `Microsoft.IdentityModel`, `Microsoft.IdentityModel.SecurityTokenService`, and `Microsoft.IdentityModel.Threading`.|  
|<xref:System.Security.Claims?displayProperty=nameWithType>|Contains classes that represent claims, claims-based identities, claims based principals, and other claims based identity model artifacts. Contains classes from the `Microsoft.IdentityModel.Claims` namespace.|  
|<xref:System.IdentityModel.Tokens?displayProperty=nameWithType>|Contains classes that represent security tokens, security token handlers, and other security token artifacts. Contains classes from the following WIF 3.5 namespaces: `Microsoft.IdentityModel.Tokens`, `Microsoft.IdentityModel.Tokens.Saml11`, and `Microsoft.IdentityModel.Tokens.Saml2`.|  
|<xref:System.IdentityModel.Services?displayProperty=nameWithType>|Contains classes that are used in passive (WS-Federation) scenarios. Contains classes from the `Microsoft.IdentityModel.Web` namespace.|  
|<xref:System.ServiceModel.Security?displayProperty=nameWithType>|Classes that represent WCF contracts, channels, service hosts and other artifacts that are used in active (WS-Trust) scenarios are now in this namespace. In WIF 3.5 , these classes were in the `Microsoft.IdentityModel.Protocols.WSTrust` namespace.|  
  
> [!IMPORTANT]
>  The following `System.IdentityModel` namespaces contain classes that implement the WCF claims-based identity model: <xref:System.IdentityModel.Claims?displayProperty=nameWithType>, <xref:System.IdentityModel.Policy?displayProperty=nameWithType>, and <xref:System.IdentityModel.Selectors?displayProperty=nameWithType>. The WCF claims-based identity model is superseded by WIF. You should not use classes in these three namespaces when building solutions based on WIF.  
  
### Changes Due to .NET Integration  
 WIF is now integrated into the .NET Framework. Most .NET identity and principal classes now derive from <xref:System.Security.Claims.ClaimsIdentity?displayProperty=nameWithType> and <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType>. The results in the following changes in WIF 4.5:  
  
-   WIF classes that represent claims, identities, and principals now exist in the <xref:System.Security.Claims?displayProperty=nameWithType> namespace.  
  
    > [!IMPORTANT]
    >  The <xref:System.IdentityModel.Claims?displayProperty=nameWithType> namespace contains classes that represent artifacts in the WCF claims-based identity model. Many of these classes have names that are the same as WIF classes; for example, `Claims`. Do not use these classes when building solutions based on WIF.  
  
-   .NET identity and principal classes now derive directly from <xref:System.Security.Claims.ClaimsIdentity?displayProperty=nameWithType> and <xref:System.Security.Claims.ClaimsPrincipal?displayProperty=nameWithType>, which represent claims-based identities and principals. For this reason, the WIF 3.5 interfaces `IClaimsIdentity` and `IClaimsPrincipal` are no longer needed and are not available in WIF 4.5.  
  
-   Because.NET identity and principal classes such as <xref:System.Security.Principal.WindowsIdentity?displayProperty=nameWithType> and <xref:System.Security.Principal.WindowsPrincipal?displayProperty=nameWithType> now derive from <xref:System.Security.Claims.ClaimsIdentity> and <xref:System.Security.Claims.ClaimsPrincipal>, they have claims functionality built-in. For this reason, claims-specific identity and principal classes such as `WindowsClaimsIdentity` and `WindowsClaimsPrincipal` that were present in WIF 3.5 are no longer needed and do not exist in WIF 4.5.  
  
### Other Changes to WIF Functionality  
 In addition to the namespace changes and the changes due to integration with .NET, the following general changes to WIF functionality occur in WIF 4.5.  
  
-   The `Microsoft.IdentityModel.ExceptionMapper` class, which provided functionality that enabled you to map exceptions to specific SOAP Faults, is removed.  
  
-   The exception surface has been greatly reduced.  
  
-   Many of the classes that defined protocol or WS-* specific constants have been removed; for example, the `Microsoft.IdentityModel.WSAddressing10Constants` class, which defined constants related to WS-Addressing 1.0.  
  
-   The Claims to Windows Token Service (c2wts) and its associated classes in the `Microsoft.IdentityModel.WindowsTokenService` namespace are removed.  
  
### WIF Configuration Changes  
 Many of the changes in the configuration file have been caused by namespace updates in WIF 4.5. For example, consider the following WIF 3.5 entry in the `<httpModules>` section to add the WS-Federation Authentication Manager to an application:  
  
```xml  
<add name="WSFederationAuthenticationModule" type="Microsoft.IdentityModel.Web.WSFederationAuthenticationModule, Microsoft.IdentityModel, Version=3.5.0.0, Culture=neutral, PublicKeyToken=abcd … 5678" />  
```  
  
 This entry has been updated in WIF 4.5 to include the new namespaces and assembly version:  
  
```xml  
<add name="WSFederationAuthenticationModule" type="System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=abcd … 5678"/>  
```  
  
 The following list enumerates the major changes to the configuration file for WIF 4.5.  
  
-   The `<microsoft.identityModel>` section is now the [\<system.identityModel>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel.md) section.  
  
-   The `<service>` element is now the [\<identityConfiguration>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md) element.  
  
-   A new section, [\<system.identityModel.services>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/system-identitymodel-services.md), has been added to specify settings that control behavior in passive (WS-Federation) scenarios.  
  
-   The [\<federationConfiguration>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/federationconfiguration.md) element and its child elements have been moved from the `<service>` element in WIF 3.5 to the new `<system.identityModel.services>` element .  
  
-   Several elements that could be specified at the service-level directly under the `<service>` element in WIF 3.5 have been restricted to being specified under the [\<securityTokenHandlerConfiguration>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/securitytokenhandlerconfiguration.md) element. (They may still be specified under the [\<identityConfiguration>](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/identityconfiguration.md) element in WIF 4.5 for backward compatibility.)  
  
 For a complete list of the WIF 4.5 configuration elements, see [WIF Configuration Schema](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/index.md).  
  
### Visual Studio Tooling Changes  
 The WIF 3.5 SDK offered a stand-alone federation utility, FedUtil.exe (FedUtil), that you could use to outsource identity management in WIF-enabled applications to a security token service (STS). This tool added WIF settings to the application configuration file to enable the application to get security tokens from one or more STSs, and was surfaced in Visual Studio through the **Add STS Service Reference** button. FedUtil does not ship with WIF 4.5. Instead, WIF 4.5 supports a new Visual Studio extension named the Identity and Access Tool for Visual Studio 2012 that you can use to modify your application’s configuration file with the WIF settings required to outsource identity management to an STS. The Identity and Access Tool also implements an STS called Local STS that you can use to test your WIF-enabled applications. In many cases, this feature obviates the need to build custom STSs that were often necessary in WIF 3.5 to test solutions under development. For this reason, the STS templates are no longer supported in Visual Studio 2012; however, the classes that support the development of STSs are still available in WIF 4.5.  
  
 You can install the Identity and Access Tool from the Extensions and Updates Manager in Visual Studio or you can download it from the following page on Code Gallery: [Identity and Access Tool for Visual Studio 2012 on Code Gallery](http://go.microsoft.com/fwlink/?LinkID=245849). The Visual Studio tooling changes are summarized in the following list:  
  
-   The Add STS Service Reference functionality is removed. The replacement is the Identity and Access Tool.  
  
-   The Visual Studio STS templates are removed. You can use the Local STS that is available through the Identity and Access Tool to test identity solutions that you develop with WIF. The Local STS configuration can be modified to customize the claims that it serves.  
  
-   The stand-alone Federation Utility (FedUtil) is not available in WIF 4.5. You can use the Identity and Access Tool to modify your configuration files to outsource identity management to an STS.  
  
 For more information about the Identity and Access Tool, see [Identity and Access Tool for Visual Studio 2012](../../../docs/framework/security/identity-and-access-tool-for-vs.md)  
  
<a name="BKMK_ToolingChanges"></a>   
### Passive (WS-Federation) Scenarios:  
  
-   Classes that support passive scenarios have been moved to the <xref:System.IdentityModel.Services?displayProperty=nameWithType> namespace. In WIF 3.5 these classes were in the `Microsoft.IdentityModel.Web` namespace.  
  
-   The classes in the `Microsoft.IdentityModel.Web.Configuration` namespace have been moved to <xref:System.IdentityModel.Services.Configuration?displayProperty=nameWithType>. These classes represent objects specific to configuration in passive scenarios.  
  
-   The `FederatedPasssiveSignInControl` is no longer supported; all classes in the `Microsoft.IdentityModel.Web.Controls` namespace have been removed from WIF 4.5.  
  
-   The WS-Federation Authentication Module (<xref:System.IdentityModel.Services.WSFederationAuthenticationModule>) sign-out functionality is different than WIF 3.5. For more details about how sign-out works in WIF 4.5, see the <xref:System.IdentityModel.Services.WSFederationAuthenticationModule> class topic.  
  
### Active (WCF/WS-Trust) Scenarios:  
  
-   The `Microsoft.IdentityModel.Protocols.WSTrust` namespace has been split mainly into two namespaces in WIF 4.5. Classes that represent artifacts that are specific to the WS-Trust protocol are now in <xref:System.IdentityModel.Protocols.WSTrust?displayProperty=nameWithType>. This includes classes like <xref:System.IdentityModel.Protocols.WSTrust.RequestSecurityToken>. Classes that represent service contracts, channels, service hosts and other artifacts that are involved in using WS-Trust in WCF applications have been moved to <xref:System.ServiceModel.Security?displayProperty=nameWithType>; for example, the <xref:System.ServiceModel.Security.IWSTrust13AsyncContract> interface.  
  
-   Configuring a WCF application to use WIF has been greatly simplified. Previously the `Microsoft.IdentityModel.Configuration.ConfigureServiceHostBehaviorExtensionElement` had to be added as a behavior extension and this functionality was then used to wedge WIF into the service behavior by specifying a `<federatedServiceHostConfiguration>` element. WIF 4.5 has been more tightly integrated with WCF. Now you enable WIF on a WCF service by specifying the `useIdentityConfiguration` attribute on the `<system.serviceModel>`/`<behaviors>`/`<serviceBehaviors>`/`<serviceCredentials>` element as in the following XML:  
  
    ```xml  
    <serviceCredentials useIdentityConfiguration="true">  
        <!--Certificate added by Identity And Access VS Package.  Subject='CN=localhost', Issuer='CN=localhost'. Make sure you have this certificate installed. The Identity and Access tool does not install this certificate.-->  
        <serviceCertificate findValue="CN=localhost" storeLocation="LocalMachine" storeName="My" x509FindType="FindBySubjectDistinguishedName" />  
    </serviceCredentials>  
    ```  
  
-   In WIF 4.5 the service certificate used by an active (WCF) service must be specified on the service host. In configuration, you can do this through the `<system.serviceModel>`/`<behaviors>`/`<serviceBehaviors>`/`<serviceCredentials>`/`<serviceCertificate>` element as shown in the preceding example. In WIF 3.5 the service certificate could be specified through the `<serviceCertificate>` child element of the WIF `<service>` element. This functionality does not exist in WIF 4.5; specify the `<serviceCertificate>` element under the `<serviceCredentials>` element instead.  
  
-   The classes used to wedge WIF 3.5 into WCF no longer exist. This includes the following classes in the `Microsoft.IdentityModel.Tokens` namespace: `FederatedSecurityTokenManager`, `FederatedServiceCredentials`, and `IdentityModelServiceAuthorizationManager`, as well as the `Microsoft.IdentityModel.Configuration.ConfigureServiceHostBehaviorExtensionElement` class.  
  
## Enabling WIF 3.5 in Windows 8  
 Because WIF 4.5 is part of .NET 4.5, it is automatically enabled on computers running Windows 8 and Windows Server 2012 and applications that are built using WIF 4.5 will run under Windows 8 or Windows Server 2012 by default. However, you may need to run applications that were built using WIF 3.5 on a computer that is running Windows 8 or Windows Server 2012. In this case, you need to enable WIF 3.5 on the target computer. On a computer running Windows 8, you can do this by using the Deployment Image Servicing and Management (DISM) tool. On a computer running Windows Server 2012, you can use the DISM tool or you can use the Windows PowerShell `Add-WindowsFeature` cmdlet. In both cases, the appropriate commands can be invoked either at the command line or from inside the Windows PowerShell environment.  
  
 The following commands show how to use the DISM tool from either the command line or from inside the Windows PowerShell environment. By default, the DISM PowerShell module is included in Windows 8 and Windows Server 2012 and does not need to be imported. For more information about using DISM with Windows PowerShell, see [How to Use DISM in Windows PowerShell](http://go.microsoft.com/fwlink/?LinkId=254419).  
  
 To enable WIF 3.5 using DISM:  
  
```  
dism /online /enable-feature:windows-identity-foundation  
```  
  
 To disable WIF 3.5 using DISM:  
  
```  
dism /online /disable-feature:windows-identity-foundation  
```  
  
 To check which features are enabled or disabled using DISM:  
  
```  
dism /online /get-features  
```  
  
 Alternatively, on computers running Windows Server 2012, you can enable WIF 3.5 by using the Windows PowerShell `Add-WindowsFeature` cmdlet. To do so from the command line, you can enter the following command:  
  
```  
powershell "add-windowsfeature windows-identity-foundation"  
```  
  
 From inside the Windows PowerShell environment, you can enter the command directly:  
  
```  
add-windowsfeature windows-identity-foundation  
```  
  
> [!NOTE]
>  Because many of the classes in WIF 3.5 and WIF 4.5 share the same names, when you are using both WIF 3.5 and WIF 4.5 together, be sure to either use fully qualified class names or use namespace aliases to distinguish between classes in WIF 3.5 and WIF 4.5.  
  
## See Also  
 [WIF Configuration Schema](../../../docs/framework/configure-apps/file-schema/windows-identity-foundation/index.md)  
 [Namespace Mapping between WIF 3.5 and WIF 4.5](../../../docs/framework/security/namespace-mapping-between-wif-3-5-and-wif-4-5.md)  
 [What's New in Windows Identity Foundation 4.5](../../../docs/framework/security/whats-new-in-wif.md)  
 [Identity and Access Tool for Visual Studio 2012](../../../docs/framework/security/identity-and-access-tool-for-vs.md)
