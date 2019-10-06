---
title: "<transport> of <netNamedPipeBinding>"
ms.date: "03/30/2017"
ms.assetid: d9eff52d-4bde-4586-b56a-b0ec24611f8d
---
# \<transport> of \<netNamedPipeBinding>
Defines the transport security settings for a named pipe.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<netNamedPipeBinding>**](netnamedpipebinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<security>**](security-of-netnamedpipebinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<transport>**  
  
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
|protectionLevel|Defines protection level of the named pipe. Signing messages mitigates the risk of a third party tampering with the message while it is being transferred. Encryption provides data-level privacy during transport. Valid values include the following:<br /><br /> -   None: No protection.<br />-   Sign: Messages are signed.<br />-   EncryptAndSign: Messages are encrypted and signed.<br /><br /> The default value is EncryptAndSign.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<security>](security-of-netnamedpipebinding.md)|Defines the security settings for a binding.|  
  
## See also

- <xref:System.ServiceModel.NamedPipeTransportSecurity>
- <xref:System.ServiceModel.Configuration.NetNamedPipeSecurityElement.Transport%2A>
- <xref:System.ServiceModel.NetNamedPipeSecurity.Transport%2A>
- <xref:System.ServiceModel.Configuration.NamedPipeTransportSecurityElement>
- [Securing Services and Clients](../../../wcf/feature-details/securing-services-and-clients.md)
- [Bindings](../../../wcf/bindings.md)
- [Configuring System-Provided Bindings](../../../wcf/feature-details/configuring-system-provided-bindings.md)
- [Using Bindings to Configure Services and Clients](../../../wcf/using-bindings-to-configure-services-and-clients.md)
- [\<binding>](../../../misc/binding.md)
