---
description: "Learn more about: <service>"
title: "<service>"
ms.date: "03/30/2017"
ms.assetid: 13123dd6-c4a9-4a04-a984-df184b851788
---
# \<service>

The `service` element contains the settings for a Windows Communication Foundation (WCF) service. It also contains endpoints that expose the service.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<services>**](services.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<service>**  
  
## Syntax  
  
```xml  
<service behaviorConfiguration="String"
         name="String">
</service>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|behaviorConfiguration|A string that contains the behavior name of the behavior to be used to instantiate the service. The behavior name must be in scope at the point the service is defined. The default value is an empty string.|  
|name|Required String attribute that specifies the type of the service to be instantiated. This setting must equate to a valid type. The format should be `Namespace.Class.`|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpoint>](endpoint-element.md)|A collection of `endpoint` elements that expose this service.|  
|[\<host>](host.md)|Specifies the host of this service instance. This element is of type <xref:System.ServiceModel.Configuration.HostElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<services>](services.md)|The root element of all WCF configuration elements.|  
  
## Remarks  

 Services are defined in the `services` section of the configuration file. An assembly can contain any number of services. Each service has its own `service` configuration section. This section and its content define the service contract, behavior, and endpoints of the particular service.  
  
 The `behaviorConfiguration` element is also optional. It identifies the behavior the service uses. The behavior specified in this attribute must link to a behavior in scope in the same configuration file.  
  
 Each service exposes one or more endpoints, which has its own address and binding. All bindings used within the configuration file must be defined in the scope of the file. Binding are linked to endpoints through the combination of the attributes `name` and `bindingConfiguration`. The `name` attribute describes the section the binding is defined in. The `bindingConfiguration` attribute defines which configuration within the binding section is used. A binding section can define several configurations.  
  
## Example  

 This is an example of a service configuration.  
  
```xml  
<service behaviorConfiguration="testChannelBehavior"
         name="HelloWorld">
  <endpoint address="/HelloWorld2/"
            name="test"
            bindingNamespace="http://www.cohowinery.com/"
            binding="basicHttpBinding"
            contract="IHelloWorld" />
</service>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.ServiceElement>
- [Configuring Services](../../../wcf/configuring-services.md)
