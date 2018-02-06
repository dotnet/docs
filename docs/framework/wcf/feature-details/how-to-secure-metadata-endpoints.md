---
title: "How to: Secure Metadata Endpoints"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 9f71b6ae-737c-4382-8d89-0a7b1c7e182b
caps.latest.revision: 13
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# How to: Secure Metadata Endpoints
Metadata for a service can contain sensitive information about your application that a malicious user can leverage. Consumers of your service may also require a secure mechanism for obtaining metadata about your service. Therefore, it is sometimes necessary to publish your metadata using a secure endpoint.  
  
 Metadata endpoints are generally secured using the standard security mechanisms defined in [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] for securing application endpoints. ([!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Security Overview](../../../../docs/framework/wcf/feature-details/security-overview.md).)  
  
 This topic walks through the steps to create an endpoint secured by a Secure Sockets Layer (SSL) certificate or, in other words, an HTTPS endpoint.  
  
### To create a secure HTTPS GET metadata endpoint in code  
  
1.  Configure a port with an appropriate X.509 certificate. The certificate must come from a trusted authority, and it must have an intended use of "Service Authorization." You must use the HttpCfg.exe tool to attach the certificate to the port. See [How to: Configure a Port with an SSL Certificate](../../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md).  
  
    > [!IMPORTANT]
    >  The subject of the certificate or its Domain Name System (DNS) must match the name of the computer. This is essential because one of the first steps the HTTPS mechanism performs is to check that the certificate is issued to the same Uniform Resource Identifier (URI) as the address upon which it is invoked.  
  
2.  Create a new instance of the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> class.  
  
3.  Set the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A> property of the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> class to `true`.  
  
4.  Set the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetUrl%2A> property to an appropriate URL. Note that if you specify an absolute address, the URL must begin with the scheme "https://". If you specify a relative address, you must supply an HTTPS base address for your service host. If this property is not set, the default address is "", or directly at the HTTPS base address for the service.  
  
5.  Add the instance to the behaviors collection that the <xref:System.ServiceModel.Description.ServiceDescription.Behaviors%2A> property of the <xref:System.ServiceModel.Description.ServiceDescription> class returns, as shown in the following code.  
  
     [!code-csharp[c_HowToSecureEndpoint#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howtosecureendpoint/cs/source.cs#1)]
     [!code-vb[c_HowToSecureEndpoint#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howtosecureendpoint/vb/source.vb#1)]  
  
### To create a secure HTTPS GET metadata endpoint in configuration  
  
1.  Add a [\<behaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md) element to the [\<system.serviceModel>](../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md) element of the configuration file for your service.  
  
2.  Add a [\<serviceBehaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/servicebehaviors.md) element to the [\<behaviors>](../../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md) element.  
  
3.  Add a [\<behavior>](../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-servicebehaviors.md) element to the `<serviceBehaviors>` element.  
  
4.  Set the `name` attribute of the `<behavior>` element to an appropriate value. The `name` attribute is required. The example below uses the value `mySvcBehavior`.  
  
5.  Add a [\<serviceMetadata>](../../../../docs/framework/configure-apps/file-schema/wcf/servicemetadata.md) to the `<behavior>` element.  
  
6.  Set the `httpsGetEnabled` attribute of the `<serviceMetadata>` element to `true`.  
  
7.  Set the `httpsGetUrl` attribute of the `<serviceMetadata>` element to an appropriate value. Note that if you specify an absolute address, the URL must begin with the scheme "https://". If you specify a relative address, you must supply an HTTPS base address for your service host. If this property is not set, the default address is "", or directly at the HTTPS base address for the service.  
  
8.  To use the behavior with a service, set the `behaviorConfiguration` attribute of the [\<service>](../../../../docs/framework/configure-apps/file-schema/wcf/service.md) element to the value of the name attribute of the behavior element. The following configuration code shows a complete example.  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
     <system.serviceModel>  
      <behaviors>  
       <serviceBehaviors>  
        <behavior name="mySvcBehavior">  
         <serviceMetadata httpsGetEnabled="true"   
              httpsGetUrl="https://localhost:8036/calcMetadata" />  
        </behavior>  
       </serviceBehaviors>  
      </behaviors>  
     <services>  
      <service behaviorConfiguration="mySvcBehavior"   
            name="Microsoft.Security.Samples.Calculator">  
       <endpoint address="http://localhost:8037/ServiceModelSamples/calculator"  
       binding="wsHttpBinding" bindingConfiguration=""     
       contract="Microsoft.Security.Samples.ICalculator" />  
      </service>  
     </services>  
    </system.serviceModel>  
    </configuration>  
    ```  
  
## Example  
 The following example creates an instance of a <xref:System.ServiceModel.ServiceHost> class and adds an endpoint. The code then creates an instance of the <xref:System.ServiceModel.Description.ServiceMetadataBehavior> class and sets the properties to create a secure metadata exchange point.  
  
 [!code-csharp[c_HowToSecureEndpoint#0](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_howtosecureendpoint/cs/source.cs#0)]
 [!code-vb[c_HowToSecureEndpoint#0](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_howtosecureendpoint/vb/source.vb#0)]  
  
## Compiling the Code  
 The code example uses the following namespaces:  
  
-   <xref:System.ServiceModel?displayProperty=nameWithType>  
  
-   <xref:System.ServiceModel.Description?displayProperty=nameWithType>  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A>  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior>  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetUrl%2A>  
 [How to: Configure a Port with an SSL Certificate](../../../../docs/framework/wcf/feature-details/how-to-configure-a-port-with-an-ssl-certificate.md)  
 [Working with Certificates](../../../../docs/framework/wcf/feature-details/working-with-certificates.md)  
 [Security Considerations with Metadata](../../../../docs/framework/wcf/feature-details/security-considerations-with-metadata.md)  
 [Securing Services and Clients](../../../../docs/framework/wcf/feature-details/securing-services-and-clients.md)
