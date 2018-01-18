---
title: "Simplified Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dcbe1f84-437c-495f-9324-2bc09fd79ea9
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Simplified Configuration
Configuring [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] services can be a complex task. There are many different options and it is not always easy to determine what settings are required. While configuration files increase the flexibility of [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] services, they also are the source for many hard to find problems. [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] addresses these problems and provides a way to reduce the size and complexity of service configuration.  
  
## Simplified Configuration  
 In [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service configuration files, the <`system.serviceModel`> section contains a <`service`> element for each service hosted. The <`service`> element contains a collection of <`endpoint`> elements that specify the endpoints exposed for each service and optionally a set of service behaviors. The <`endpoint`> elements specify the address, binding, and contract exposed by the endpoint, and optionally binding configuration and endpoint behaviors. The <`system.serviceModel`> section also contains a <`behaviors`> element that allows you to specify service or endpoint behaviors. The following example shows the <`system.serviceModel`> section of a configuration file.  
  
```  
<system.serviceModel>  
  <behaviors>  
    <serviceBehaviors>  
      <behavior name="MyServiceBehavior">  
        <serviceMetadata httpGetEnabled="true">  
        <serviceDebug includeExceptionDetailInFaults="false">  
      </behavior>  
    </serviceBehaviors>  
  </behaviors>  
  <bindings>  
   <basicHttpBinding>  
      <binding name=MyBindingConfig"  
               maxBufferSize="100"  
               maxReceiveBufferSize="100" />  
   </basicHttpBinding>  
   </bindings>   <services>  
    <service behaviorConfiguration="MyServiceBehavior"  
             name="MyService">  
      <endpoint address=""  
                binding="basicHttpBinding"  
                contract="ICalculator"  
                bindingConfiguration="MyBindingConfig" />  
      <endpoint address="mex"  
                binding="mexHttpBinding"  
                contract="IMetadataExchange"/>  
    </service>  
  </services>  
</system.serviceModel>  
```  
  
 [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] makes configuring a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service easier by removing the requirement for the <`service`> element. If you do not add a <`service`>  section or add any endpoints in a <`service`> section and your service does not programmatically define any endpoints, then a set of default endpoints are automatically added to your service, one for each service base address and for each contract implemented by your service. In each of these endpoints, the endpoint address corresponds to the base address, the binding is determined by the base address scheme and the contract is the one implemented by your service. If you do not need to specify any endpoints or service behaviors or make any binding setting changes, you do not need to specify a service configuration file at all. If a service implements two contracts and the host enables both HTTP and TCP transports the service host creates four default endpoints, one for each contract using each transport. To create default endpoints the service host must know what bindings to use. These settings are specified in a <`protocolMappings`> section within the <`system.serviceModel`> section. The <`protocolMappings`> section contains a list of transport protocol schemes mapped to binding types. The service host uses the base addresses passed to it to determine which binding to use. The following example uses the <`protocolMappings`> element.  
  
> [!WARNING]
>  Changing default configuration elements, such as bindings or behaviors, might affect services defined in lower levels of the configuration hierarchy, since they might be using these default bindings and behaviors. Thus, whoever changes default bindings and behaviors needs to be aware that these changes might affect other services in the hierarchy.  
  
> [!NOTE]
>  Services hosted under Internet Information Services (IIS) or Windows Process Activation Service (WAS) use the virtual directory as their base address.  
  
```xml  
<protocolMapping>  
  <add scheme="http"     binding="basicHttpBinding" bindingConfiguration="MyBindingConfiguration"/>  
  <add scheme="net.tcp"  binding="netTcpBinding"/>  
  <add scheme="net.pipe" binding="netNamedPipeBinding"/>  
  <add scheme="net.msmq" binding="netMSMQBinding"/>  
</protocolMapping>  
```  
  
 In the previous example, an endpoint with a base address that starts with the "http" scheme uses the <xref:System.ServiceModel.BasicHttpBinding>. An endpoint with a base address that starts with the "net.tcp" scheme uses the <xref:System.ServiceModel.NetTcpBinding>. You can override settings in a local App.config or Web.config file.  
  
 Each element within the <`protocolMappings`> section must specify a scheme and a binding. Optionally it can specify a `bindingConfiguration` attribute that specifies a binding configuration within the <`bindings`> section of the configuration file. If no `bindingConfiguration` is specified, the anonymous binding configuration of the appropriate binding type is used.  
  
 Service behaviors are configured for the default endpoints by using anonymous <`behavior`> sections within <`serviceBehaviors`> sections. Any unnamed <`behavior`> elements within <`serviceBehaviors`> are used to configure service behaviors. For example, the following configuration file enables service metadata publishing for all services within the host.  
  
```xml  
<system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True"/>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>    <!-- No <service> tag is necessary. Default endpoints are added to the service -->  
    <!-- The service behavior with name="" is picked up by the service -->  
 </system.serviceModel>  
```  
  
 Endpoint behaviors are configured by using anonymous <`behavior`> sections within <`serviceBehaviors`> sections.  
  
 The following example is a configuration file equivalent to the one at the beginning of this topic that uses the simplified configuration model.  
  
```xml  
<system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="false"/>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>    <bindings>  
       <basicHttpBinding>  
          <binding maxBufferSize="100"  
                   maxReceiveBufferSize="100" />  
       </basicHttpBinding>  
    </bindings>    <!-- No <service> tag is necessary. Default endpoints will be added to the service -->  
    <!-- The service behavior with name="" will be picked up by the service -->  
    <protocolMapping>  
      <add scheme="http"     binding="basicHttpBinding" / </protocolMapping>  
  </system.serviceModel>  
```  
  
> [!IMPORTANT]
>  This feature relates only to WCF service configuration, not client configuration. Most times, WCF client configuration will be generated by a tool such as svcutil.exe or adding a service reference from Visual Studio. If you are manually configuring a WCF client you will need to add a \<client> element to the configuration and specify any endpoints you wish to call.  
  
## See Also  
 [Configuring Services Using Configuration Files](../../../docs/framework/wcf/configuring-services-using-configuration-files.md)  
 [Configuring Bindings for Services](../../../docs/framework/wcf/configuring-bindings-for-wcf-services.md)  
 [Configuring System-Provided Bindings](../../../docs/framework/wcf/feature-details/configuring-system-provided-bindings.md)  
 [Configuring Services](../../../docs/framework/wcf/configuring-services.md)  
 [Configuring Windows Communication Foundation Applications](http://msdn.microsoft.com/library/13cb368e-88d4-4c61-8eed-2af0361c6d7a)  
 [Configuring WCF Services in Code](../../../docs/framework/wcf/configuring-wcf-services-in-code.md)
