---
title: "<useManagedPresentation>"
ms.date: "03/30/2017"
ms.assetid: 17a0dd77-af54-41db-a9d0-4b17ff42878f
---
# \<useManagedPresentation>
A binding element used to communicate with a CardSpace Security Token Service that supports the CardSpace profile of WS-Trust. This element has no attribute and is present as an empty switch.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<bindings>**](bindings.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<customBinding>**](custombinding.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<binding>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<useManagedPresentation>**  
  
## Syntax  
  
```xml  
<useManagedPresentation />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<binding>](../../../misc/binding.md)|Defines all binding capabilities of the custom binding.|  
  
## Remarks  
 This element is used by an identity provider to express in its policy the fact that it supports the CardSpace profile of WS-Trust. Identity providers that publish such a policy assertion should be able to issue tokens based on that CardSpace profile.  
  
## See also

- <xref:System.ServiceModel.Configuration.UseManagedPresentationElement>
- <xref:System.ServiceModel.Channels.UseManagedPresentationBindingElement>
- <xref:System.ServiceModel.Channels.CustomBinding>
- [Bindings](../../../wcf/bindings.md)
- [Extending Bindings](../../../wcf/extending/extending-bindings.md)
- [Custom Bindings](../../../wcf/extending/custom-bindings.md)
- [\<customBinding>](custombinding.md)
