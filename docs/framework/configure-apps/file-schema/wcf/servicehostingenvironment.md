---
title: "&lt;serviceHostingEnvironment&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4f8a7c4f-e735-4987-979a-b74fcdae2652
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;serviceHostingEnvironment&gt;
This element defines the type the service hosting environment instantiates for a particular transport. If this element is empty, the default type is used. This element can only be used at the application or machine level configuration files.  
  
 \<system.ServiceModel>  
\<ServiceHostingEnvironment>  
  
## Syntax  
  
```xml  
<serviceHostingEnvironment aspNetCompatibilityEnabled="Boolean" 
                           minFreeMemoryPercentageToActivateService="Integer" 
                           multipleSiteBindingsEnabled="Boolean">
  <baseAddressPrefixFilters>
    <add prefix="string" />
  </baseAddressPrefixFilters>
  <serviceActivations>
    <add factory="String" service="String" />
  </serviceActivations>
  <transportConfigurationTypes>
    <add name="String" transportConfigurationType="String" />
  </transportConfigurationTypes>
</serviceHostingEnvironment>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|aspNetCompatibilityEnabled|A Boolean value indicating whether the ASP.NET compatibility mode has been turned on for the current application. The default is `false`.<br /><br /> When this attribute is set to `true`, requests to [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] services flow through the ASP.NET HTTP pipeline, and communication over non-HTTP protocols is prohibited. For more information, see [WCF Services and ASP.NET](../../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md).|  
|minFreeMemoryPercentageToActivateService|An integer that specifies the minimum amount of free memory that should be available to the system, before a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service can be activated. **Caution:**  Specifying this attribute along with partial trust in the web.config file of a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service will result in a <xref:System.Security.SecurityException> when the service is run.|  
|multipleSiteBindingsEnabled|A Boolean value that specifies whether multiple IIS bindings per site is enabled.<br /><br /> IIS consists of web sites, which are containers for virtual applications containing virtual directories. The application in a site can be accessed through one or more IIS binding. An IIS binding provides two pieces of information: a binding protocol and binding information. Binding protocol defines the scheme over which communication occurs, and binding information is the information used to access the site. An example of a binding protocol can be HTTP, whereas binding information can contain an IP address, Port, host header, etc.<br /><br /> IIS supports specifying multiple IIS bindings per site, which results in multiple base addresses per scheme. However, a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service hosted under a site allows binding to only one baseAddress per scheme.<br /><br /> To enable multiple IIS bindings per site for a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service, set this attribute to `true`. Notice that multiple site binding is supported only for the HTTP protocol. The address of endpoints in the configuration file needs to be a complete URI.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<baseAddressPrefixFilters>](../../../../../docs/framework/configure-apps/file-schema/wcf/baseaddressprefixfilters.md)|A collection of configuration elements that specify prefix filters for the base addresses used by the service host.|  
|[\<serviceActivations>](../../../../../docs/framework/configure-apps/file-schema/wcf/serviceactivations.md)|A configuration section that describes activation settings.|  
|[\<transportConfigurationTypes>](../../../../../docs/framework/configure-apps/file-schema/wcf/transportconfigurationtypes.md)|A collection of configuration elements that identify the type of a particular transport.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|serviceModel|The root element of all Windows Communication Foundation (WCF) configuration elements.|  
  
## Remarks  
 By default, WCF services run side-by-side with ASP.NET in hosted Application Domains (AppDomain). Even though WCF and ASP.NET can coexist in the same AppDomain, WCF requests are not processed by the ASP.NET HTTP Pipeline by default. As a result, several elements of the ASP.NET application platform are not available to WCF services. These include  
  
-   ASP.NET File/URL Authorization  
  
-   ASP.NET Impersonation  
  
-   Cookie-based Session State  
  
-   HttpContext.Current  
  
-   Pipeline Extensibility via custom HttpModule  
  
 If your WCF services need to function in the ASP.NET context, and communicate only over HTTP, you can use WCF’s ASP.NET compatibility mode. This mode is turned on when the `aspNetCompatibilityEnabled` attribute is set to `true` at the application level. Service implementations must declare their ability to run in compatibility mode using the <xref:System.ServiceModel.Activation.AspNetCompatibilityRequirementsAttribute> class. When the compatibility mode is enabled,  
  
-   ASP.NET File/URL Authorization is enforced prior to WCF authorization. An authorization decision is based on the transport-level identity of the request. Identities at the message level are ignored.  
  
-   WCF service operations start to execute in the ASP.NET impersonation context. If both ASP.NET impersonation and WCF impersonation are enabled for a specific service, the WCF impersonation context applies.  
  
-   HttpContext.Current can be used from WCF service code, and services are prevented from exposing non-HTTP endpoints.  
  
-   WCF requests are processed by the ASP.NET pipeline. HttpModules that have been configured to act on incoming requests can also process WCF requests. These can include ASP.NET platform components (e.g., <xref:System.Web.SessionState.SessionStateModule>), as well as custom third party modules.  
  
## Example  
 The following code sample shows how to enable ASP Compatibility Mode.  
  
## Code  
  
```xml  
<serviceHostingEnvironment aspNetCompatibilityEnabled="true"/>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection>  
 <xref:System.ServiceModel.ServiceHostingEnvironment>  
 [Hosting](../../../../../docs/framework/wcf/feature-details/hosting.md)  
 [WCF Services and ASP.NET](../../../../../docs/framework/wcf/feature-details/wcf-services-and-aspnet.md)
