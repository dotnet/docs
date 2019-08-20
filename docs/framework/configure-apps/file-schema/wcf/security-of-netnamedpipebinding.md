---
title: "<security> of <netNamedPipeBinding>"
ms.date: "03/30/2017"
ms.assetid: bb3cb022-637e-49fd-92e8-6766038affa7
---
# \<security> of \<netNamedPipeBinding>
Defines the security settings for a binding.  
  
 \<system.ServiceModel>  
\<bindings>  
\<netNamedPipeBinding>  
\<binding>  
\<security>  
  
## Syntax  
  
```xml  
<netNamedPipeBinding>
  <binding>
    <security mode="None/Transport">
      <transport protectionLevel="None/Sign/EncryptAndSign" />
    </security>
  </binding>
</netNamedPipeBinding>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|mode|Specifies the type of security that is applied to this binding. Valid values include the following:<br /><br /> -   None: This disables security.<br />-   Transport: Security is provided using underlying transport based security. It is possible to control the protection level with this mode.<br />-   The default value is Transport. This attribute is of type <xref:System.ServiceModel.NetNamedPipeSecurityMode>.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|transport|Defines the security settings for the transport. This element is of type <xref:System.ServiceModel.Configuration.NamedPipeTransportSecurityElement>.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|binding|The binding element of the [\<netNamedPipeBinding>](netnamedpipebinding.md).|  
  
## See also

- <xref:System.ServiceModel.NetNamedPipeSecurity>
- <xref:System.ServiceModel.NetNamedPipeBinding.Security%2A>
- <xref:System.ServiceModel.Configuration.NetNamedPipeBindingElement.Security%2A>
- <xref:System.ServiceModel.Configuration.NetNamedPipeSecurityElement>
- [Securing Services and Clients](../../feature-details/securing-services-and-clients.md)
- [Selecting a Credential Type](../../feature-details/selecting-a-credential-type.md)
- [Bindings](../../bindings.md)
- [Configuring System-Provided Bindings](../../feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
