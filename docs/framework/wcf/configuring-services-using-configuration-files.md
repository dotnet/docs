---
title: "Configuring Services Using Configuration Files"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "configuring services [WCF]"
ms.assetid: c9c8cd32-2c9d-4541-ad0d-16dff6bd2a00
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring Services Using Configuration Files
Configuring a [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] service with a configuration file gives you the flexibility of providing endpoint and service behavior data at the point of deployment instead of at design time. This topic outlines the primary techniques available.  
  
 A [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service is configurable using the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] configuration technology. Most commonly, XML elements are added to the Web.config file for an Internet Information Services (IIS) site that hosts a [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] service. The elements allow you to change details such as the endpoint addresses (the actual addresses used to communicate with the service) on a machine-by-machine basis. In addition, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] includes several system-provided elements that allow you to quickly select the most basic features for a service. Starting with [!INCLUDE[netfx40_long](../../../includes/netfx40-long-md.md)], [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] comes with a new default configuration model that simplifies [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration requirements. If you do not provide any [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] configuration for a particular service, the runtime automatically configures your service with some standard endpoints and default binding/behavior. In practice, writing configuration is a major part of programming [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] applications.  
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Configuring Bindings for Services](../../../docs/framework/wcf/configuring-bindings-for-wcf-services.md). [!INCLUDE[crlist](../../../includes/crlist-md.md)] of the most commonly used elements, see [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] default endpoints, bindings, and behaviors, see [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
> [!IMPORTANT]
>  When deploying side by side scenarios where two different versions of a service are deployed, it is necessary to specify partial names of assemblies referenced in configuration files. This is because the configuration file is shared across all versions of a service and they could be running under different versions of the .NET Framework.  
  
## System.Configuration: Web.config and App.config  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] uses the System.Configuration configuration system of the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)].  
  
 When configuring a service in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], use either a Web.config file or an App.config file to specify the settings. The choice of the configuration file name is determined by the hosting environment you choose for the service. If you are using IIS to host your service, use a Web.config file. If you are using any other hosting environment, use an App.config file.  
  
 In [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)], the file named App.config is used to create the final configuration file. The final name actually used for the configuration depends on the assembly name. For example, an assembly named "Cohowinery.exe" has a final configuration file name of "Cohowinery.exe.config". However, you only need to modify the App.config file. Changes made to that file are automatically made to the final application configuration file at compile time.  
  
 In using an App.config, file the configuration system merges the App.config file with content of the Machine.config file when the application starts and the configuration is applied. This mechanism allows machine-wide settings to be defined in the Machine.config file. The App.config file can be used to override the settings of the Machine.config file; you can also lock in the settings in Machine.config file so that they get used. In the Web.config case, the configuration system merges the Web.config files in all directories leading up to the application directory into the configuration that gets applied. [!INCLUDE[crabout](../../../includes/crabout-md.md)] configuration and the setting priorities, see topics in the <xref:System.Configuration> namespace.  
  
## Major Sections of the Configuration File  
 The main sections in the configuration file include the following elements.  
  
```xml  
<system.ServiceModel>  
  
   <services>  
   <!—- Define the service endpoints. This section is optional in the new  
    default configuration model in .NET Framework 4. -->  
      <service>  
         <endpoint/>  
      </service>  
   </services>  
  
   <bindings>  
   <!-- Specify one or more of the system-provided binding elements,  
    for example, <basicHttpBinding> -->   
   <!-- Alternatively, <customBinding> elements. -->  
      <binding>  
      <!-- For example, a <BasicHttpBinding> element. -->  
      </binding>  
   </bindings>  
  
   <behaviors>  
   <!-- One or more of the system-provided or custom behavior elements. -->  
      <behavior>  
      <!-- For example, a <throttling> element. -->  
      </behavior>  
   </behaviors>  
  
</system.ServiceModel>  
```  
  
> [!NOTE]
>  The bindings and behaviors sections are optional and are only included if required.  
  
### The \<services> Element  
 The `services` element contains the specifications for all services the application hosts. Starting with the simplified configuration model in [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)], this section is optional.  
  
 [\<services>](../../../docs/framework/configure-apps/file-schema/wcf/services.md)  
  
### The \<service> Element  
 Each service has these attributes:  
  
-   `name`. Specifies the type that provides an implementation of a service contract. This is a fully qualified name which consists of the namespace, a period, and then the type name. For example `"MyNameSpace.myServiceType"`.  
  
-   `behaviorConfiguration`. Specifies the name of one of the `behavior` elements found in the `behaviors` element. The specified behavior governs actions such as whether the service allows impersonation. If its value is the empty name or no `behaviorConfiguration` is provided then the default set of service behaviors is added to the service.  
  
-   [\<service>](../../../docs/framework/configure-apps/file-schema/wcf/service.md)  
  
### The \<endpoint> Element  
 Each endpoint requires an address, a binding, and a contract, which are represented by the following attributes:  
  
-   `address`. Specifies the service's Uniform Resource Identifier (URI), which can be an absolute address or one that is given relative to the base address of the service. If set to an empty string, it indicates that the endpoint is available at the base address that is specified when creating the <xref:System.ServiceModel.ServiceHost> for the service.  
  
-   `binding`. Typically specifies a system-provided binding like <xref:System.ServiceModel.WSHttpBinding>, but can also specify a user-defined binding. The binding specified determines the type of transport, security and encoding used, and whether reliable sessions, transactions, or streaming is supported or enabled.  
  
-   `bindingConfiguration`. If the default values of a binding must be modified, this can be done by configuring the appropriate `binding` element in the `bindings` element. This attribute should be given the same value as the `name` attribute of the `binding` element that is used to change the defaults. If no name is given, or no `bindingConfiguration` is specified in the binding, then the default binding of the binding type is used in the endpoint.  
  
-   `contract`. Specifies the interface that defines the contract. This is the interface implemented in the common language runtime (CLR) type specified by the `name` attribute of the `service` element.  
  
-   [\<endpoint> element reference](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017)  
  
### The \<bindings> Element  
 The `bindings` element contains the specifications for all bindings that can be used by any endpoint defined in any service.  
  
 [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)  
  
### The \<binding> Element  
 The `binding` elements contained in the `bindings` element can be either one of the system-provided bindings (see [System-Provided Bindings](../../../docs/framework/wcf/system-provided-bindings.md)) or a custom binding (see [Custom Bindings](../../../docs/framework/wcf/extending/custom-bindings.md)). The `binding` element has a `name` attribute that correlates the binding with the endpoint specified in the `bindingConfiguration` attribute of the `endpoint` element. If no name is specified then that binding corresponds to the default of that binding type.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] configuring services and clients, see [Configuring Windows Communication Foundation Applications](http://msdn.microsoft.com/library/13cb368e-88d4-4c61-8eed-2af0361c6d7a).  
  
 [\<binding>](../../../docs/framework/misc/binding.md)  
  
### The \<behaviors> Element  
 This is a container element for the `behavior` elements that define the behaviors for a service.  
  
 [\<behaviors>](../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md)  
  
### The \<behavior> Element  
 Each `behavior` element is identified by a `name` attribute and provides either a system-provided behavior, such as <`throttling`>, or a custom behavior. If no name is given then that behavior element corresponds to the default service or endpoint behavior.  
  
 [\<behavior>](../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-servicebehaviors.md)  
  
## How to Use Binding and Behavior Configurations  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] makes it easy to share configurations between endpoints using a reference system in configuration. Rather than directly assigning configuration values to an endpoint, binding-related configuration values are grouped in `bindingConfiguration` elements in the `<binding>` section. A binding configuration is a named group of settings on a binding. Endpoints can then reference the `bindingConfiguration` by name.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
 <system.serviceModel>  
  <bindings>  
    <basicHttpBinding>  
     <binding name="myBindingConfiguration1" closeTimeout="00:01:00" />  
     <binding name="myBindingConfiguration2" closeTimeout="00:02:00" />  
     <binding closeTimeout="00:03:00" />  <!—- Default binding for basicHttpBinding -->  
    </basicHttpBinding>  
     </bindings>  
     <services>  
      <service name="MyNamespace.myServiceType">  
       <endpoint   
          address="myAddress" binding="basicHttpBinding"   
          bindingConfiguration="myBindingConfiguration1"  
          contract="MyContract"  />  
       <endpoint   
          address="myAddress2" binding="basicHttpBinding"   
          bindingConfiguration="myBindingConfiguration2"  
          contract="MyContract" />  
       <endpoint   
          address="myAddress3" binding="basicHttpBinding"   
          contract="MyContract" />  
       </service>  
      </services>  
    </system.serviceModel>  
</configuration>  
```  
  
 The `name` of the `bindingConfiguration` is set in the `<binding>` element. The `name` must be a unique string within the scope of the binding type—in this case the [<basicHttpBinding\>](../../../docs/framework/configure-apps/file-schema/wcf/basichttpbinding.md), or an empty value to refer to the default binding. The endpoint links to the configuration by setting the `bindingConfiguration` attribute to this string.  
  
 A `behaviorConfiguration` is implemented the same way, as illustrated in the following sample.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <endpointBehaviors>  
        <behavior name="myBehavior">  
           <callbackDebug includeExceptionDetailInFaults="true" />  
         </behavior>  
      </endpointBehaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="true" />  
        </behavior>  
      </serviceBehaviors>  
  
    </behaviors>  
    <services>  
     <service name="NewServiceType">  
       <endpoint   
          address="myAddress3" behaviorConfiguration="myBehavior"  
          binding="basicHttpBinding"  
          contract="MyContract" />  
      </service>  
    </services>  
   </system.serviceModel>  
</configuration>  
```  
  
 Note that the default set of service behaviors are added to the service. This system allows endpoints to share common configurations without redefining the settings. If machine-wide scope is required, create the binding or behavior configuration in Machine.config. The configuration settings are available in all App.config files. The [Configuration Editor Tool (SvcConfigEditor.exe)](../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md) makes it easy to create configurations.  
  
## Behavior Merge  
 The behavior merge feature makes it easier to manage behaviors when you want a set of common behaviors to be used consistently. This feature allows you to specify behaviors at different levels of the configuration hierarchy and have services inherit behaviors from multiple levels of the configuration hierarchy. To illustrate how this works assume you have the following virtual directory layout in IIS:  
  
 ~\Web.config~\Service.svc~\Child\Web.config~\Child\Service.svc  
  
 And your ~\Web.config file has the following contents:  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceDebug includeExceptionDetailInFaults="True" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
 And you have a child Web.config located at ~\Child\Web.config with the following contents:  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <serviceMetadata httpGetEnabled="True" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
 The service located at ~\Child\Service.svc will behave as though it has both the serviceDebug and serviceMetadata behaviors. The service located at ~\Service.svc will only have the serviceDebug behavior. What happens is that the two behavior collections with the same name (in this case the empty string) are merged.  
  
 You can also clear behavior collections by using the \<clear> tag and removed individual behaviors from the collection by using the \<remove> tag. For example, the following two configuration results in the child service having only the serviceMetadata behavior:  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <remove name="serviceDebug"/>  
          <serviceMetadata httpGetEnabled="True" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <serviceBehaviors>  
        <behavior>  
          <clear/>  
          <serviceMetadata httpGetEnabled="True" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
 Behavior merge is done for nameless behavior collections as shown above and named behavior collections as well.  
  
 Behavior merge works in the IIS hosting environment, in which Web.config files merge hierarchically with the root Web.config file and machine.config. But it also works in the application environment, where machine.config can merge with the App.config file.  
  
 Behavior merge applies to both endpoint behaviors and service behaviors in configuration.  
  
 If a child behavior collection contains a behavior that’s already present in the parent behavior collection, the child behavior overrides the parent. So if a parent behavior collection had `<serviceMetadata httpGetEnabled="False" />` and a child behavior collection had `<serviceMetadata httpGetEnabled="True" />`, the child behavior would override the parent behavior in the behavior collection and httpGetEnabled would be "true".  
  
## See Also  
 [Simplified Configuration](../../../docs/framework/wcf/simplified-configuration.md)  
 [Configuring Windows Communication Foundation Applications](http://msdn.microsoft.com/library/13cb368e-88d4-4c61-8eed-2af0361c6d7a)  
 [\<service>](../../../docs/framework/configure-apps/file-schema/wcf/service.md)  
 [\<binding>](../../../docs/framework/misc/binding.md)
