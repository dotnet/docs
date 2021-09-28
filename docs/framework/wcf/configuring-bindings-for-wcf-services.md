---
title: "Configuring Bindings for Windows Communication Foundation Services"
description: Learn about configuring bindings at deployment time for a WCF application by editing items under the system.ServiceModel element.
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "binding configuration [WCF]"
ms.assetid: 99a85fd8-f7eb-4a84-a93e-7721b37d415c
---
# Configuring Bindings for Windows Communication Foundation Services

When creating an application, you often want to defer decisions to the administrator after the deployment of the application. For example, there is often no way of knowing in advance what a service address, or Uniform Resource Identifier (URI), will be. Instead of hard-coding an address, it is preferable to allow an administrator to do so after creating a service. This flexibility is accomplished through configuration.  
  
> [!NOTE]
> Use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) with the `/config` switch to quickly create configuration files.  
  
## Major Sections  

 The Windows Communication Foundation (WCF) configuration scheme includes the following three major sections (`serviceModel`, `bindings`, and `services`):  
  
```xml  
<configuration>  
    <system.serviceModel>  
        <bindings>  
        </bindings>  
        <services>  
        </services>  
        <behaviors>  
        </behaviors>  
    </system.serviceModel>  
</configuration>  
```  
  
### ServiceModel Elements  

 You can use the section bounded by the `system.ServiceModel` element to configure a service type with one or more endpoints, as well as settings for a service. Each endpoint can then be configured with an address, a contract, and a binding. For more information about endpoints, see [Endpoint Creation Overview](endpoint-creation-overview.md). If no endpoints are specified, the runtime adds default endpoints. For more information about default endpoints, bindings, and behaviors, see [Simplified Configuration](simplified-configuration.md) and [Simplified Configuration for WCF Services](./samples/simplified-configuration-for-wcf-services.md).  
  
 A binding specifies transports (HTTP, TCP, pipes, Message Queuing) and protocols (Security, Reliability, Transaction flows) and consists of binding elements, each of which specifies an aspect of how an endpoint communicates with the world.  
  
 For example, specifying the [\<basicHttpBinding>](../configure-apps/file-schema/wcf/basichttpbinding.md) element indicates to use HTTP as the transport for an endpoint. This is used to wire up the endpoint at run time when the service using this endpoint is opened.  
  
 There are two kinds of bindings: predefined and custom. Predefined bindings contain useful combinations of elements that are used in common scenarios. For a list of predefined binding types that WCF provides, see [System-Provided Bindings](system-provided-bindings.md). If no predefined binding collection has the correct combination of features that a service application needs, you can construct custom bindings to meet the application's requirements. For more information about custom bindings, see [\<customBinding>](../configure-apps/file-schema/wcf/custombinding.md).  
  
 The following four examples illustrate the most common binding configurations used for setting up a WCF service.  
  
#### Specifying an Endpoint to Use a Binding Type  

 The first example illustrates how to specify an endpoint configured with an address, a contract, and a binding.  
  
```xml  
<service name="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null">  
  <!-- This section is optional with the default configuration introduced  
       in .NET Framework 4. -->  
  <endpoint
      address="/HelloWorld2/"  
      contract="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"  
      binding="basicHttpBinding" />
</service>  
```  
  
 In this example, the `name` attribute indicates which service type the configuration is for. When you create a service in your code with the `HelloWorld` contract, it is initialized with all of the endpoints defined in the example configuration. If the assembly implements only one service contract, the `name` attribute can be omitted because the service uses the only available type. The attribute takes a string, which must be in the format `Namespace.Class, AssemblyName, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null`  
  
 The `address` attribute specifies the URI that other endpoints use to communicate to the service. The URI can be either an absolute or relative path. If a relative address is provided, the host is expected to provide a base address that is appropriate for the transport scheme used in the binding. If an address is not configured, the base address is assumed to be the address for that endpoint.  
  
 The `contract` attribute specifies the contract this endpoint is exposing. The service implementation type must implement the contract type. If a service implementation implements a single contract type, then this property can be omitted.  
  
 The `binding` attribute selects a predefined or custom binding to use for this specific endpoint. An endpoint that does not explicitly select a binding uses the default binding selection, which is `BasicHttpBinding`.  
  
#### Modifying a Predefined Binding  

 In the following example, a predefined binding is modified. It can then be used to configure any endpoint in the service. The binding is modified by setting the <xref:System.ServiceModel.Configuration.IBindingConfigurationElement.ReceiveTimeout%2A> value to 1 second. Note that the property returns a <xref:System.TimeSpan> object.  
  
 That altered binding is found in the bindings section. This altered binding can now be used when creating any endpoint by setting the `binding` attribute in the `endpoint` element.  
  
> [!NOTE]
> If you give a particular name to the binding, the `bindingConfiguration` specified in the service endpoint must match with it.  
  
```xml  
<service name="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null">  
  <endpoint
      address="/HelloWorld2/"  
      contract="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"  
      binding="basicHttpBinding" />
</service>  
<bindings>  
    <basicHttpBinding
        receiveTimeout="00:00:01"  
    />  
</bindings>  
```  
  
## Configuring a Behavior to Apply to a Service  

 In the following example, a specific behavior is configured for the service type. The `ServiceMetadataBehavior` element is used to enable the [ServiceModel Metadata Utility Tool (Svcutil.exe)](servicemodel-metadata-utility-tool-svcutil-exe.md) to query the service and generate Web Services Description Language (WSDL) documents from the metadata.  
  
> [!NOTE]
> If you give a particular name to the behavior, the `behaviorConfiguration` specified in the service or endpoint section must match it.  
  
```xml  
<behaviors>  
    <behavior>  
        <ServiceMetadata httpGetEnabled="true" />
    </behavior>  
</behaviors>  
<services>  
    <service
       name="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null">
       <endpoint
          address="http://computer:8080/Hello"  
          contract="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"  
          binding="basicHttpBinding" />
    </service>  
</services>  
```  
  
 The preceding configuration enables a client to call and get the metadata of the "HelloWorld" typed service.  
  
 `svcutil /config:Client.exe.config http://computer:8080/Hello?wsdl`  
  
## Specifying a Service with Two Endpoints Using Different Binding Values  

 In this last example, two endpoints are configured for the `HelloWorld` service type. Each endpoint uses a different customized  `bindingConfiguration` attribute of the same binding type (each modifies the `basicHttpBinding`).  
  
```xml  
<service name="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null">  
    <endpoint  
        address="http://computer:8080/Hello1"  
        contract="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"  
        binding="basicHttpBinding"  
        bindingConfiguration="shortTimeout" />
    <endpoint  
        address="http://computer:8080/Hello2"  
        contract="HelloWorld, IndigoConfig, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null"  
        binding="basicHttpBinding"  
        bindingConfiguration="Secure" />
</service>  
<bindings>  
    <basicHttpBinding
        name="shortTimeout"  
        timeout="00:00:00:01"
     />  
     <basicHttpBinding
        name="Secure">  
        <Security mode="Transport" />  
     </basicHttpBinding>
</bindings>  
```  
  
 You can get the same behavior using the default configuration by adding a `protocolMapping` section and configuring the bindings as demonstrated in the following example.  
  
```xml  
<protocolMapping>  
    <add scheme="http" binding="basicHttpBinding" bindingConfiguration="shortTimeout" />  
    <add scheme="https" binding="basicHttpBinding" bindingConfiguration="Secure" />  
</protocolMapping>  
<bindings>  
    <basicHttpBinding
        name="shortTimeout"  
        timeout="00:00:00:01"
     />  
     <basicHttpBinding
        name="Secure" />  
        <Security mode="Transport" />  
</bindings>  
```  
  
## See also

- [Simplified Configuration](simplified-configuration.md)
- [System-Provided Bindings](system-provided-bindings.md)
- [Endpoint Creation Overview](endpoint-creation-overview.md)
- [Using Bindings to Configure Services and Clients](using-bindings-to-configure-services-and-clients.md)
