---
title: "&lt;dispatcherSynchronization&gt;"
ms.date: "03/30/2017"
ms.assetid: cc030f9c-4e38-4b14-94dc-9a0e41ec8e2d
---
  
# &lt;dispatcherSynchronization&gt;
  
Specifies an endpoint behavior that enables a service to send replies asynchronously.  
  
\<system.serviceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
  
## Syntax  
  
```xml  
<dispatcherSynchronizationBehavior asynchronousSendEnabled="Boolean"
                                   maxPendingReceives="Integer" />
```  
  
## Type  
  
`Type`  
  
## Attributes and elements  
  
The following sections describe attributes, child elements, and parent elements.  
  
### Attributes

| Attribute               | Description       |
| ----------------------- | ----------------- |
| asynchronousSendEnabled | A Boolean that specifies whether asynchronous send behavior is enabled. |
| `maxPendingReceives`    | An integer that specifies the number of concurrent receives that can be issued on the channel.<br /><br /> This value should be configured only after you have properly configured service throttling behavior. |

### Child elements

None.

### Parent elements

| Element | Description |  
| ------- | ----------- |  
| [\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior. |

## See also

 <xref:System.ServiceModel.Configuration.DispatcherSynchronizationElement>
 <xref:System.ServiceModel.Description.DispatcherSynchronizationBehavior>
