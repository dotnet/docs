---
title: "&lt;serviceMetadata&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2b4c3b4c-31d4-4908-a9b7-5bb411c221f2
caps.latest.revision: 28
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;serviceMetadata&gt;
Specifies the publication of service metadata and associated information.  
  
\<system.serviceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceMetadata>  
  
## Syntax  
  
```xml
<serviceMetadata externalMetadataLocation="String"  
                 httpGetBinding="String" 
                 httpGetBindingConfiguration="String"  
                 httpGetEnabled="Boolean" 
                 httpGetUrl="String" 
                 httpsGetBinding="String" 
                 httpsGetBindingConfiguration="String"  
                 httpsGetEnabled="Boolean"   
                 httpsGetUrl="String"  
                 policyVersion="Policy12/Policy15" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|externalMetadataLocation|A Uri that contains the location of a WSDL file, which is returned to the user in response to WSDL and MEX requests instead of the auto-generated WSDL. When this attribute is not set, the default WSDL is returned. The default is an empty string.|  
|httpGetBinding|A string that specifies the type of the binding that will be used for metadata retrieval via HTTP GET. This setting is optional. If it is not specified, the default bindings will be used.<br /><br /> Only bindings with inner binding elements that support <xref:System.ServiceModel.Channels.IReplyChannel> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None%2A>.|  
|httpGetBindingConfiguration|A string that sets the name of the binding that is specified in the `httpGetBinding` attribute, which references to the additional configuration information of this binding. The same name must be defined in the `<bindings>` section.|  
|httpGetEnabled|A Boolean value that specifies whether to publish service metadata for retrieval using an HTTP/Get request. The default is `false`.<br /><br /> If the httpGetUrl attribute is not specified, the address at which the metadata is published is the service address plus a "?wsdl". For example, if the service address is "http://localhost:8080/CalculatorService", the HTTP/Get metadata address is "http://localhost:8080/CalculatorService?wsdl".<br /><br /> If this property is `false`, or the address of the service is not based on HTTP or HTTPS, "?wsdl" is ignored.|  
|httpGetUrl|A Uri that specifies the address at which the metadata is published for retrieval using an HTTP/Get request. If a relative Uri is specified it will be treated as relative to the service’s base address.|  
|httpsGetBinding|A string that specifies the type of the binding that will be used for metadata retrieval via HTTPS GET. This setting is optional. If it is not specified, the default bindings will be used.<br /><br /> Only bindings with inner binding elements that support <xref:System.ServiceModel.Channels.IReplyChannel> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None%2A>.|  
|httpsGetBindingConfiguration|A string that sets the name of the binding that is specified in the `httpsGetBinding` attribute, which references to the additional configuration information of this binding. The same name must be defined in the `<bindings>` section.|  
|httpsGetEnabled|A Boolean value that specifies whether to publish service metadata for retrieval using an HTTPS/Get request. The default is `false`.<br /><br /> If the httpsGetUrl attribute is not specified, the address at which the metadata is published is the service address plus a "?wsdl". For example, if the service address is "https://localhost:8080/CalculatorService", the HTTP/Get metadata address is "https://localhost:8080/CalculatorService?wsdl".<br /><br /> If this property is `false`, or the address of the service is not based on HTTP or HTTPS, "?wsdl" is ignored.|  
|httpsGetUrl|A Uri that specifies the address at which the metadata is published for retrieval using an HTTPS/Get request.|  
|policyVersion|A string that specifies the version of the WS-Policy specification being used. This attribute is of type <xref:System.ServiceModel.Description.PolicyVersion>.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 This configuration element allows you to control the metadata publishing features of a service. To prevent unintentional disclosure of potentially sensitive service metadata, the default configuration for [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] services disables metadata publishing. This behavior is secure by default, but also means that you cannot use a metadata import tool (such as Svcutil.exe) to generate the client code required to call the service unless the service’s metadata publishing behavior is explicitly enabled in configuration. Using this configuration element, you can enable this publishing behavior for your service.  
  
 For a detailed example of configuring this behavior, see [Metadata Publishing Behavior](../../../../../docs/framework/wcf/samples/metadata-publishing-behavior.md).  
  
 The optional `httpGetBinding` and `httpsGetBinding` attributes allow you to configure the bindings used for metadata retrieval via HTTP GET (or HTTPS GET). If they are not specified, the default bindings (`HttpTransportBindingElement`, in the case of HTTP and `HttpsTransportBindingElement`, in the case of HTTPS) are used for metadata retrieval as appropriate. Notice that you cannot use these attributes with the built-in WCF bindings. Only bindings with inner binding elements that support <xref:System.ServiceModel.Channels.IReplyChannel> will be supported. Additionally, the <xref:System.ServiceModel.Channels.MessageVersion> property of the binding must be <xref:System.ServiceModel.Channels.MessageVersion.None%2A>.  
  
 To reduce the exposure of a service to malicious users, it is possible to secure the transfer using the SSL over HTTP (HTTPS) mechanism. To do so, you must first bind a suitable X.509 certificate to a specific port on the computer that is hosting the service. ([!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [Working with Certificates](../../../../../docs/framework/wcf/feature-details/working-with-certificates.md).) Second, add this element to the service configuration and set the `httpsGetEnabled` attribute to `true`. Finally, set the `httpsGetUrl` attribute to the URL of the service metadata endpoint, as shown in the following example.  
  
```xml
<behaviors>  
  <serviceBehaviors>  
    <behavior name="NewBehavior">  
      <serviceMetadata httpsGetEnabled="true"   
                       httpsGetUrl="https://myComputerName/myEndpoint" />  
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
## Example  
 The following example configure a service to expose metadata by using the \<serviceMetadata> element. It also configures an endpoint to expose the `IMetadataExchange` contract as an implementation of a WS-MetadataExchange (MEX) protocol. The example uses the `mexHttpBinding`, which is a convenience standard binding that is equivalent to the `wsHttpBinding` with the security mode set to `None`. A relative address of "mex" is used in the endpoint, which when resolved against the services base address results in an endpoint address of http://localhost/servicemodelsamples/service.svc/mex.  
  
```xml
<configuration>  
  <system.serviceModel>  
    <services>  
      <service name="Microsoft.ServiceModel.Samples.CalculatorService" 
               behaviorConfiguration="CalculatorServiceBehavior">  
        <!-- This endpoint is exposed at the base address provided by the host: http://localhost/servicemodelsamples/service.svc -->  
        <endpoint address=""  
                  binding="wsHttpBinding"  
                  contract="Microsoft.ServiceModel.Samples.ICalculator" />  
        <!-- The mex endpoint is exposed at http://localhost/servicemodelsamples/service.svc/mex   
             To expose the IMetadataExchange contract, you must enable the serviceMetadata behavior as demonstrated below. -->  
        <endpoint address="mex"  
                  binding="mexHttpBinding"  
                  contract="IMetadataExchange" />  
      </service>  
    </services>  

    <!--For debugging purposes set the includeExceptionDetailInFaults attribute to true-->  
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="CalculatorServiceBehavior">  
          <!-- The serviceMetadata behavior publishes metadata through   
               the IMetadataExchange contract. When this behavior is   
               present, you can expose this contract through an endpoint   
               as shown above. Setting httpGetEnabled to true publishes   
               the service's WSDL at the <baseaddress>?wsdl  
               eg. http://localhost/servicemodelsamples/service.svc?wsdl -->  
          <serviceMetadata httpGetEnabled="True"/>  
          <serviceDebug includeExceptionDetailInFaults="False" />  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ServiceMetadataPublishingElement>  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior>  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)  
 [Metadata Publishing Behavior](../../../../../docs/framework/wcf/samples/metadata-publishing-behavior.md)
