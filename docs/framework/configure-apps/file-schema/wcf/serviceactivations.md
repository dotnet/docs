---
title: "<serviceActivations>"
ms.date: "03/30/2017"
ms.assetid: 97e665b6-1c51-410b-928a-9bb42c954ddb
---
# \<serviceActivations>
A configuration element that allows you to add settings that define virtual service activation settings that map to your Windows Communication Foundation (WCF) service types. This makes it possible to activate services hosted in WAS/IIS without an .svc file.  
  
 \<system.ServiceModel>  
\<serviceHostingEnvironment>  
\<serviceActivations>  
  
## Syntax  
  
```xml  
<serviceHostingEnvironment>
  <serviceActivations>
    <add factory="String"
         service="String" />
  </serviceActivations>
</serviceHostingEnvironment>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-serviceactivations.md)|Adds a configuration element that specifies the activation of a service application.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceHostingEnvironment>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicehostingenvironment.md)|Defines the type the service hosting environment instantiates for a particular transport.|  
  
## Remarks  
 The following example shows how to configure activation settings within your web.config file.  
  
```xml  
<configuration>
  <system.serviceModel>
    <serviceHostingEnvironment>
      <serviceActivations>
        <add service="GreetingService" />
      </serviceActivations>
    </serviceHostingEnvironment>
  </system.serviceModel>
</configuration>
```  
  
 Using this configuration, you can activate the GreetingService without using an .svc file.  
  
 Note that `<serviceHostingEnvironment>` is an application level configuration. You have to place the `web.config` containing the configuration under the root of the virtual Application. In addition, `serviceHostingEnvironment` is a machinetoApplication inheritable section. If you register a single service in the root of the machine, every service in the application will inherit this service.  
  
 Configuration-based activation supports activation over both http and non-http protocol. It requires extensions in the relatativeAddress i.e. .svc, .xoml or .xamlx. You can map your own extensions to the know buildProviders, which will then enable you to activate service over any extension. Upon conflict, the `<serviceActivations>` section overrides .svc registrations.  
  
## See also
- <xref:System.ServiceModel.Configuration.ServiceActivationElementCollection>
- <xref:System.ServiceModel.Configuration.ServiceHostingEnvironmentSection>
- <xref:System.ServiceModel.ServiceHostingEnvironment>
