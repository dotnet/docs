---
title: "&lt;add&gt; of &lt;serviceActivations&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e5b01fc8-ee84-48b7-95fd-95ab54fa871f
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;serviceActivations&gt;
A configuration element that allows you to define virtual service activation settings that map to your [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service types. This makes it possible to activate services hosted in WAS/IIS without an .svc file.  
  
 \<system.ServiceModel>  
\<ServiceHostingEnvironment>  
  
## Syntax  
  
```xml  
<serviceHostingEnvironment>   
   <serviceActivations>  
      <add factory="String"  
           service="String"/>  
   </serviceActivations>  
</serviceHostingEnvironment>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|factory|A string that specifies the CLR type name of the factory that generates a service activation element.|  
|service|The ServiceType that implements the service (either the full qualified Typename or the short Typename (when it is placed in the App_Code folder).|  
|relativeAddress|The relative address within the current IIS application - for example "Service.svc". In WCF 4.0 this relative address has to contain one of the known file extensions (.svc, .xamlx, ...). No physical file has to exist for the relativeUrl|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceHostingEnvironment>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md)|A configuration section that describes activation settings.|  
  
## Remarks  
 The following example shows how to configure activation settings within your web.config file.  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <serviceHostingEnvironment>  
      <serviceActivations>  
        <add service="GreetingService"/>  
      </serviceActivations>  
    </serviceHostingEnvironment>  
  </system.serviceModel>  
</configuration>  
```  
  
 Using this configuration, you can activate the GreetingService without using an .svc file.  
  
 Note that `<serviceHostingEnvironment>` is an application level configuration. You have to place the `web.config` containing the configuration under the root of the virtual Application. In addition, `serviceHostingEnvironment` is a machinetoApplication inheritable section. If you register a single service in the root of the machine, every service in the application will inherit this service.  
  
 Configuration-based activation supports activation over both http and non-http protocol. It requires extensions in the relatativeAddress, i.e. .svc, .xoml or .xamlx. You can map your own extensions to the know buildProviders, which will then enable you to activate service over any extension. Upon conflict, the `<serviceActivations>` section overrides .svc registrations.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceActivationElement>  
 <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection>  
 <xref:System.ServiceModel.ServiceHostingEnvironment>
