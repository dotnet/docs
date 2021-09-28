---
title: "<system.serviceModel>"
description: Learn about the WCF ServiceModel configuration elements, which enable you to configure WCF service and client applications.
ms.date: "03/30/2017"
f1_keywords: 
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#system.ServiceModel"
  - "http://schemas.microsoft.com/.NetConfiguration/v2.0#configuration/system.ServiceModel"
helpviewer_keywords: 
  - "<system.serviceModel> element"
  - "system.serviceModel element"
ms.assetid: 78519531-ad7a-40d3-b3e7-42f1103d8854
---
# \<system.serviceModel>

This configuration section contains all the Windows Communication Foundation (WCF) ServiceModel configuration elements.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;**\<system.serviceModel>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <behaviors>
  </behaviors>
  <bindings>
  </bindings>
  <client>
  </client>
  <comContracts>
  </comContracts>
  <commonBehaviors>
  </commonBehaviors>
  <diagnostics>
  </diagnostics>
  <extensions>
  </extensions>
  <protocolMapping>
  </protocolMapping>
  <routing>
  </routing>
  <serviceHostingEnvironment>
  </serviceHostingEnvironment>
  <services>
  </services>
  <standardEndpoints>
  </standardEndpoints>
  <tracking>
  </tracking>
</system.serviceModel>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behaviors>](behaviors.md)|This section defines two child collections named `endpointBehaviors` and `serviceBehaviors`.  Each collection defines behavior elements consumed by endpoints and services respectively. Each behavior element is identified by its unique `name` attribute.|  
|[\<bindings>](bindings.md)|This section holds a collection of standard and custom bindings. Each entry is identified by its unique `name`. Services use bindings by linking them using the `name`.|  
|[\<client>](client.md)|This section contains a list of endpoints a client uses to connect to a service.|  
|[\<comContracts>](comcontracts.md)|This section defines COM contracts enabled for WCF and COM interop.|  
|[\<commonBehaviors>](commonbehaviors.md)|This section can only be defined in the machine.config file. It defines two child collections named `endpointBehaviors` and `serviceBehaviors`.  Each collection defines behavior elements consumed by all WCF endpoints and services on the machine respectively.  If a behavior is defined in both `<commonBehaviors>` and `<behaviors>` sections, the behavior in the \<behaviors> section is given preference.|  
|[\<diagnostics>](diagnostics.md)|This section contains settings for the diagnostics features of WCF. The user can enable/disable tracing, performance counters, and the WMI provider, and can add custom message filters.|  
|[\<extensions>](extensions-section.md)|This section contains a collection of extensions, which enable the user to create user-defined bindings, behaviors, and other aspects of extensions.|  
|[\<protocolMapping>](protocolmapping.md)|This section defines a set of default protocol mapping between transport protocol schemes (e.g., http, net.tcp, net.pipe, etc.) and WCF bindings.|  
|[\<routing>](routing.md)|This section defines a set of routing filters, which determine the type of Windows Communication Foundation (WCF)<xref:System.ServiceModel.Dispatcher.MessageFilter> to be used when evaluating incoming messages, as well as routing tables that define the target endpoints to send messages to when a filter matches.|  
|[\<serviceHostingEnvironment>](servicehostingenvironment.md)|This section defines what type the service hosting environment instantiates for a particular transport. If this section is empty, the default type is used.|  
|[\<services>](services.md)|The section contains a collection of services. For each service defined in the assembly, this element contains a `service` element specifying settings for the service.|  
|[\<standardEndpoints>](standardendpoints.md)|This section defines a collection of standard endpoints, which are reusable preconfigured endpoints. A standard endpoint will have one or more of the address, binding and contract attributes set to a fixed value. For example, in the discovery endpoint the contract is fixed. You can also use standard endpoints to extend service endpoint with new properties similar to defining custom bindings.|
|[\<tracking>](tracking-of-wcf.md)|This section defines tracking settings for a workflow service.|

### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|\<configuration>|The root element for all configuration elements in a .NET configuration file.|  
  
## Remarks  

 WCF does not add elements to the configuration sections of other products.  
  
 WCF services are defined in the `services` section of the configuration file. An assembly can contain any number of services. Each service has its own `service` configuration section. The section and its content define the service contract, behavior, and endpoints of the particular service.  
  
 Only a service's `name` attribute is required.  By default, a service's name describes the underlying CLR type used to implement a service; however, you may change the ConfigurationName property on a <xref:System.ServiceModel.ServiceContractAttribute> to override the CLR type requirement.  
  
 The `behaviorConfiguration` attribute is optional. It identifies the service behavior used by a service. The behavior specified by this attribute must link to a service behavior defined in the scope of the same configuration file (i.e. the same file or a parent file).  
  
 Each service exposes one or more endpoints defined in an `endpoint` element. Each endpoint has its own address and binding. All bindings used within the configuration file must be defined in the scope of the file.  
  
 Bindings are linked to endpoints through the combination of the attributes `name` and `bindingConfiguration`. The `binding` attribute defines in which section the binding is defined. The `bindingConfiguration` attribute defines which configured binding within the binding section is used. A binding section can define several configured bindings.  
  
## Example  

 This is an example of a WCF configuration file.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <system.serviceModel>
    <behaviors>
      <!-- List of Behaviors -->
    </behaviors>
    <client>
      <!-- List of Endpoints -->
    </client>
    <diagnostics wmiProviderEnabled="false"
                 performanceCountersEnabled="false"
                 tracingEnabled="false">
    </diagnostics>
    <serviceHostingEnvironment>
      <!-- List of entries -->
    </serviceHostingEnvironment>
    <comContracts>
      <!-- List of COM+ Contracts -->
    </comContracts>
    <services>
      <!-- List of Services -->
    </services>
    <bindings>
      <!-- List of Bindings -->
    </bindings>
  </system.serviceModel>
</configuration>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceModelSectionGroup>
