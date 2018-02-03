---
title: "Client Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5da5bd3b-65d9-43b7-91b9-cc9e989b1350
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Client Configuration
You can use the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] client configuration to specify the address, binding, behavior, and contract, the "ABC" properties of the client endpoint, which clients use to connect to service endpoints. The [\<client>](../../../../docs/framework/configure-apps/file-schema/wcf/client.md) element has an [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element whose attributes are used to configure the endpoint ABCs. These attributes are discussed in the "Configuring Endpoints" section of this topic.  
  
 The [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element also contains a [\<metadata>](../../../../docs/framework/configure-apps/file-schema/wcf/metadata.md) element that is used to specify settings for importing and exporting metadata , a [\<headers>](../../../../docs/framework/configure-apps/file-schema/wcf/headers.md) element that contains a collection of custom address headers, and an [\<identity>](../../../../docs/framework/configure-apps/file-schema/wcf/identity.md) element that enables the authentication of an endpoint by other endpoints exchanging messages with it. The [\<headers>](../../../../docs/framework/configure-apps/file-schema/wcf/headers.md) and [\<identity>](../../../../docs/framework/configure-apps/file-schema/wcf/identity.md) elements are part of the <xref:System.ServiceModel.EndpointAddress> and are discussed in the [Addresses](../../../../docs/framework/wcf/feature-details/endpoint-addresses.md) topic. Links to topics that explain the use of metadata extensions are provided in the Configuring Metadata sub-section of this topic.  
  
## Configuring Endpoints  
 The client configuration is designed to allow the client to specify one or more endpoints, each with its own name, address, and contract, with each referencing the [\<bindings>](../../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) and [\<behaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md) elements in the client configuration to be used to configure that endpoint. The client configuration file should be named "App.config" because this is the name that the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] runtime expects. The following example shows a client configuration file.  
  
```xml  
<?xml version="1.0" encoding="utf-8"?>  
<configuration>  
  <system.serviceModel>  
        <client>  
          <endpoint  
            name="endpoint1"  
            address="http://localhost/ServiceModelSamples/service.svc"  
            binding="wsHttpBinding"  
            bindingConfiguration="WSHttpBinding_IHello"  
            behaviorConfiguration="IHello_Behavior"  
            contract="IHello" >  
  
            <metadata>  
              <wsdlImporters>  
                <extension  
                  type="Microsoft.ServiceModel.Samples.WsdlDocumentationImporter, WsdlDocumentation"/>  
              </wsdlImporters>  
            </metadata>  
  
            <identity>  
              <servicePrincipalName value="host/localhost" />  
            </identity>  
          </endpoint>  
// Add another endpoint by adding another <endpoint> element.  
          <endpoint  
            name="endpoint2">  
           //Configure another endpoint here.  
          </endpoint>  
        </client>  
  
//The bindings section references by the bindingConfiguration endpoint attribute.  
    <bindings>  
      <wsHttpBinding>  
        <binding name="WSHttpBinding_IHello"   
                 bypassProxyOnLocal="false"   
                 hostNameComparisonMode="StrongWildcard">  
          <readerQuotas maxDepth="32"/>  
          <reliableSession ordered="true"   
                           enabled="false" />  
          <security mode="Message">  
           //Security settings go here.  
          </security>  
        </binding>  
        <binding name="Another Binding"  
        //Configure this binding here.  
        </binding>  
          </wsHttpBinding>  
        </bindings>  
  
//The behavior section references by the behaviorConfiguration endpoint attribute.  
        <behaviors>  
            <endpointBehaviors>  
                <behavior name=" IHello_Behavior ">  
                    <clientVia />  
                </behavior>  
            </endpointBehaviors>  
        </behaviors>  
  
    </system.serviceModel>  
</configuration>  
```  
  
 The optional `name` attribute uniquely identifies an endpoint for a given contract. It is used by the <xref:System.ServiceModel.ChannelFactory%601.%23ctor%2A> or by the <xref:System.ServiceModel.ClientBase%601.%23ctor%2A> to specify which endpoint in the client configuration is being targeted and must be loaded when a channel is created to service. A wildcard endpoint configuration name "*" is available and indicates to the <xref:System.ServiceModel.ChannelFactory.ApplyConfiguration%2A> method that it should load any endpoint configuration in the file, provided there is precisely one available, and otherwise throws an exception. If this attribute is omitted, the corresponding endpoint is used as the default endpoint associated with the specified contract type. The default value for the `name` attribute is an empty string which is matched like any other name.  
  
 Every endpoint must have an address associated with it to locate and identify the endpoint. The `address` attribute can be used to specify the URL that provides the location of the endpoint. But the address for a service endpoint can also be specified in code by creating a Uniform Resource Identifier (URI) and is added to the <xref:System.ServiceModel.ServiceHost> using one of the <xref:System.ServiceModel.ServiceHost.AddServiceEndpoint%2A> methods. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Addresses](../../../../docs/framework/wcf/feature-details/endpoint-addresses.md). As the introduction indicates, the [\<headers>](../../../../docs/framework/configure-apps/file-schema/wcf/headers.md) and [\<identity>](../../../../docs/framework/configure-apps/file-schema/wcf/identity.md) elements are part of the <xref:System.ServiceModel.EndpointAddress> and are also discussed in the [Addresses](../../../../docs/framework/wcf/feature-details/endpoint-addresses.md) topic.  
  
 The `binding` attribute indicates the type of binding the endpoint expects to use when connecting to a service. The type must have a registered configuration section if it is to be referenced. In the previous example, this is the [\<wsHttpBinding>](../../../../docs/framework/configure-apps/file-schema/wcf/wshttpbinding.md) section, which indicates that the endpoint uses a <xref:System.ServiceModel.WSHttpBinding>. But there may be more than one binding of a given type that the endpoint can use. Each of these has its own [\<binding>](../../../../docs/framework/misc/binding.md) element within the (binding) type element. The `bindingconfiguration` attribute is used to distinguish between bindings of the same type. Its value is matched with the `name` attribute of the [\<binding>](../../../../docs/framework/misc/binding.md) element. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] how to configure a client binding using configuration, see [How to: Specify a Client Binding in Configuration](../../../../docs/framework/wcf/how-to-specify-a-client-binding-in-configuration.md).  
  
 The `behaviorConfiguration` attribute is used to specify which [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) of the [\<endpointBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md) the endpoint should use. Its value is matched with the `name` attribute of the [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md) element. For an example of using configuration to specify client behaviors, see [Configuring Client Behaviors](../../../../docs/framework/wcf/configuring-client-behaviors.md).  
  
 The `contract` attribute specifies which contract the endpoint is exposing. This value maps to the <xref:System.ServiceModel.ServiceContractAttribute.ConfigurationName%2A> of the <xref:System.ServiceModel.ServiceContractAttribute>. The default value is the full type name of the class that implements the service.  
  
### Configuring Metadata  
 The [\<metadata>](../../../../docs/framework/configure-apps/file-schema/wcf/metadata.md) element is used to specify settings used to register metadata import extensions. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] extending the metadata system, see[Extending the Metadata System](../../../../docs/framework/wcf/extending/extending-the-metadata-system.md).  
  
## See Also  
 [Endpoints: Addresses, Bindings, and Contracts](../../../../docs/framework/wcf/feature-details/endpoints-addresses-bindings-and-contracts.md)  
 [Configuring Client Behaviors](../../../../docs/framework/wcf/configuring-client-behaviors.md)
