---
title: "<synchronousReceive> element"
ms.date: "03/30/2017"
ms.assetid: cc070387-3d11-4b02-a952-bc08ad2df05a
---
# \<synchronousReceive> element
This configuration element is used to specify run-time behavior for receiving messages in either a service or client application. It does not have any attributes or child elements.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<synchronousReceive>  
  
## Syntax  
  
```xml  
<synchronousReceive />
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  
 Use this behavior to instruct the channel listener to use a synchronous receive rather than the default, asynchronous. Windows Communication Foundation (WCF) issues a new thread to pump for each accepted channel. If there are a lot of channels, there is the possibility of running out of threads.  
  
## See also
- <xref:System.ServiceModel.Configuration.SynchronousReceiveElement>
- <xref:System.ServiceModel.Description.SynchronousReceiveBehavior>
