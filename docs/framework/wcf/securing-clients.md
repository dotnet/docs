---
title: "Securing Clients"
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
  - "clients [WCF], security considerations"
ms.assetid: 44c8578c-9a5b-4acd-8168-1c30a027c4c5
caps.latest.revision: 22
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Securing Clients
In [!INCLUDE[indigo1](../../../includes/indigo1-md.md)], the service dictates the security requirements for clients. That is, the service specifies what security mode to use, and whether or not the client must provide a credential. The process of securing a client, therefore, is simple: use the metadata obtained from the service (if it is published) and build a client. The metadata specifies how to configure the client. If the service requires that the client supply a credential, then you must obtain a credential that fits the requirement. This topic discusses the process in further detail. [!INCLUDE[crabout](../../../includes/crabout-md.md)] creating a secure service, see [Securing Services](../../../docs/framework/wcf/securing-services.md).  
  
## The Service Specifies Security  
 By default, [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] bindings have security features enabled. (The exception is the <xref:System.ServiceModel.BasicHttpBinding>.) Therefore, if the service was created using [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], there is a greater chance that it will implement security to ensure authentication, confidentiality, and integrity. In that case, the metadata the service provides will indicate what it requires to establish a secure communication channel. If the service metadata does not include any security requirements, there is no way to impose a security scheme, such as Secure Sockets Layer (SSL) over HTTP, on a service. If, however, the service requires the client to supply a credential, then the client developer, deployer, or administrator must supply the actual credential that the client will use to authenticate itself to the service.  
  
## Obtaining Metadata  
 When creating a client, the first step is to obtain the metadata for the service that the client will communicate with. This can be done in two ways. First, if the service publishes a metadata exchange (MEX) endpoint or makes its metadata available over HTTP or HTTPS, you can download the metadata using the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md), which generates both code files for a client as well as a configuration file. ([!INCLUDE[crabout](../../../includes/crabout-md.md)] using the tool, see [Accessing Services Using a WCF Client](../../../docs/framework/wcf/accessing-services-using-a-wcf-client.md).) If the service does not publish a MEX endpoint and also does not make its metadata available over HTTP or HTTPS, you must contact the service creator for documentation that describes the security requirements and the metadata.  
  
> [!IMPORTANT]
>  It is recommended that the metadata come from a trusted source and that it not be tampered with. Metadata retrieved using the HTTP protocol is sent in clear text and can be tampered with. If the service uses the <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A> and <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetUrl%2A> properties, use the URL the service creator supplied to download the data using the HTTPS protocol.  
  
## Validating Security  
 Metadata sources can be divided into two broad categories: trust sources and untrusted sources. If you trust a source and have downloaded the client code and other metadata from that source's secure MEX endpoint, then you can build the client, supply it with the right credentials, and run it with no other concerns.  
  
 However, if you elect to download a client and metadata from a source that you know little about, be sure to validate the security measures the code uses. For example, you must not simply create a client that sends your personal or financial information to a service unless the service demands confidentiality and integrity (at the very least). You should trust the owner of the service to the extent that you are willing to disclose such information because such information will be visible to him or her.  
  
 As a rule, therefore, when using code and metadata from an untrusted source, check the code and metadata to ensure that it meets the security level that you require.  
  
## Setting a Client Credential  
 Setting a client credential on a client consists of two steps:  
  
1.  Determine the *client credential type* the service requires. This is accomplished by one of two methods. First, if you have documentation from the service creator, it should specify the client credential type (if any) the service requires. Second, if you have only a configuration file generated by the Svcutil.exe tool, you can examine the individual bindings to determine what credential type is required.  
  
2.  Specify an actual client credential. The actual client credential is called a *client credential value* to distinguish it from the type. For example, if the client credential type specifies a certificate, you must supply an X.509 certificate that is issued by a certification authority the service trusts.  
  
### Determining the Client Credential Type  
 If you have the configuration file the Svcutil.exe tool generated, examine the [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md) section to determine what client credential type is required. Within the section are binding elements that specify the security requirements. Specifically, examine the \<security> Element of each binding. That element includes the `mode` attribute, which you can set to one of three possible values (`Message`, `Transport`, or `TransportWithMessageCredential`). The value of the attribute determines the mode, and the mode determines which of the child elements is significant.  
  
 The `<security>` element can contain either a `<transport>` or `<message>` element, or both. The significant element is the one that matches the security mode. For example, the following code specifies that the security mode is `"Message"`, and the client credential type for the `<message>` element is `"Certificate"`. In this case, the `<transport>` element can be ignored. However, the `<message>` element specifies that an X.509 certificate must be supplied.  
  
```xml  
<wsHttpBinding>  
    <binding name="WSHttpBinding_ICalculator">  
       <security mode="Message">  
           <transport clientCredentialType="Windows"   
                      realm="" />  
           <message clientCredentialType="Certificate"   
                    negotiateServiceCredential="true"  
                    algorithmSuite="Default"   
                    establishSecurityContext="true" />  
       </security>  
    </binding>  
</wsHttpBinding>  
```  
  
 Note that if the `clientCredentialType` attribute is set to `"Windows"`, as shown in the following example, you do not need to supply an actual credential value. This is because the Windows integrated security provides the actual credential (a Kerberos token) of the person who is running the client.  
  
```xml  
<security mode="Message">  
    <transport clientCredentialType="Windows "   
        realm="" />  
</security>  
```  
  
### Setting the Client Credential Value  
 If it is determined that the client must supply a credential, use the appropriate method to configure the client. For example, to set a client certificate, use the <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential.SetCertificate%2A> method.  
  
 A common form of credential is the X.509 certificate. You can supply the credential in two ways:  
  
-   By programming it in your client code (using the `SetCertificate` method).  
  
 By adding a [\<behaviors>](../../../docs/framework/configure-apps/file-schema/wcf/behaviors.md) section of the configuration file for the client and using the `clientCredentials` element (shown below).  
  
#### Setting a \<clientCredentials> Value in Code  
 To set a [\<clientCredentials>](../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md) value in code, you must access the <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A> property of the <xref:System.ServiceModel.ClientBase%601> class. The property returns a <xref:System.ServiceModel.Description.ClientCredentials> object that allows access to various credential types, as shown in the following table.  
  
|ClientCredential Property|Description|Notes|  
|-------------------------------|-----------------|-----------|  
|<xref:System.ServiceModel.Description.ClientCredentials.ClientCertificate%2A>|Returns an <xref:System.ServiceModel.Security.X509CertificateInitiatorClientCredential>|Represents an X.509 certificate provided by the client to authenticate itself to the service.|  
|<xref:System.ServiceModel.Description.ClientCredentials.HttpDigest%2A>|Returns an <xref:System.ServiceModel.Security.HttpDigestClientCredential>|Represents an HTTP digest credential. The credential is a hash of the user name and password.|  
|<xref:System.ServiceModel.Description.ClientCredentials.IssuedToken%2A>|Returns an <xref:System.ServiceModel.Security.IssuedTokenClientCredential>|Represents a custom security token issued by a Security Token Service, commonly used in federation scenarios.|  
|<xref:System.ServiceModel.Description.ClientCredentials.Peer%2A>|Returns a <xref:System.ServiceModel.Security.PeerCredential>|Represents a Peer credential for participation in a Peer mesh on a Windows domain.|  
|<xref:System.ServiceModel.Description.ClientCredentials.ServiceCertificate%2A>|Returns an <xref:System.ServiceModel.Security.X509CertificateRecipientClientCredential>|Represents an X.509 certificate provided by the service in an out-of-band negotiation.|  
|<xref:System.ServiceModel.Description.ClientCredentials.UserName%2A>|Returns a <xref:System.ServiceModel.Security.UserNamePasswordClientCredential>|Represents a user name and password pair.|  
|<xref:System.ServiceModel.Description.ClientCredentials.Windows%2A>|Returns a <xref:System.ServiceModel.Security.WindowsClientCredential>|Represents a Windows client credential (a Kerberos credential). The properties of the class are read-only.|  
  
#### Setting a \<clientCredentials> Value in Configuration  
 Credential values are specified by using an endpoint behavior as child elements of the [\<clientCredentials>](../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md) element. The element used depends on the client credential type. For example, the following example shows the configuration to set an X.509 certificate using the <[\<clientCertificate>](../../../docs/framework/configure-apps/file-schema/wcf/clientcertificate-of-clientcredentials-element.md).  
  
```xml  
<configuration>  
  <system.serviceModel>  
    <behaviors>  
      <endpointBehaviors>  
        <behavior name="myEndpointBehavior">  
          <clientCredentials>  
            <clientCertificate findvalue="myMachineName"   
            storeLocation="Current" X509FindType="FindBySubjectName" />  
          </clientCredentials>  
        </behavior>              
    </behaviors>  
  </system.serviceModel>  
</configuration>  
```  
  
 To set the client credential in configuration, add an [\<endpointBehaviors>](../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md) element to the configuration file. Additionally, the added behavior element must be linked to the service's endpoint using the `behaviorConfiguration` attribute of the [\<endpoint>](http://msdn.microsoft.com/library/13aa23b7-2f08-4add-8dbf-a99f8127c017) element as shown in the following example. The value of the `behaviorConfiguration` attribute must match the value of the behavior `name` attribute.  
  
 `<configuration>`  
  
 `<system.serviceModel>`  
  
 `<client>`  
  
 `<endpoint address="http://localhost/servicemodelsamples/service.svc"`  
  
 `binding="wsHttpBinding"`  
  
 `bindingConfiguration="Binding1"`  
  
 `behaviorConfiguration="myEndpointBehavior"`  
  
 `contract="Microsoft.ServiceModel.Samples.ICalculator" />`  
  
 `</client>`  
  
 `</system.serviceModel>`  
  
 `</configuration>`  
  
> [!NOTE]
>  Some of the client credential values cannot be set using application configuration files, for example, user name and password, or Windows user and password values. Such credential values can be specified only in code.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] setting the client credential, see [How to: Specify Client Credential Values](../../../docs/framework/wcf/how-to-specify-client-credential-values.md).  
  
> [!NOTE]
>  `ClientCredentialType` is ignored when `SecurityMode` is set to `"TransportWithMessageCredential",` as shown in the following sample configuration.  
  
```xml  
<wsHttpBinding>  
    <binding name="PingBinding">  
        <security mode="TransportWithMessageCredential"  >  
           <message  clientCredentialType="UserName"   
               establishSecurityContext="false"    
               negotiateServiceCredential="false" />  
           <transport clientCredentialType="Certificate"  />  
         </security>  
    </binding>  
</wsHttpBinding>  
```  
  
## See Also  
 <xref:System.ServiceModel.ClientBase%601.ClientCredentials%2A>  
 <xref:System.ServiceModel.ClientBase%601>  
 <xref:System.ServiceModel.Description.ClientCredentials>  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetEnabled%2A>  
 <xref:System.ServiceModel.Description.ServiceMetadataBehavior.HttpsGetUrl%2A>  
 [\<bindings>](../../../docs/framework/configure-apps/file-schema/wcf/bindings.md)  
 [Configuration Editor Tool (SvcConfigEditor.exe)](../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md)  
 [Securing Services](../../../docs/framework/wcf/securing-services.md)  
 [Accessing Services Using a WCF Client](../../../docs/framework/wcf/accessing-services-using-a-wcf-client.md)  
 [How to: Specify Client Credential Values](../../../docs/framework/wcf/how-to-specify-client-credential-values.md)  
 [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md)  
 [How to: Specify the Client Credential Type](../../../docs/framework/wcf/how-to-specify-the-client-credential-type.md)
