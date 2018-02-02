---
title: "&lt;serviceThrottling&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a337d064-1e64-4209-b4a9-db7fdb7e3eaf
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;serviceThrottling&gt;
Specifies the throttling mechanism of a Windows Communication Foundation (WCF) service.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<serviceThrottling>  
  
## Syntax  
  
```xml  
<serviceThrottling maxConcurrentCalls="Integer"  
    maxConcurrentInstances="Integer"  
    maxConcurrentSessions="Integer" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|maxConcurrentCalls|A positive integer that limits the number of messages that currently process across a <xref:System.ServiceModel.ServiceHost>. Calls in excess of the limit are queued. Setting this value to 0 is equivalent to setting it to Int32.MaxValue. The default is 16 * processor count.|  
|maxConcurrentInstances|A positive integer that limits the number of <xref:System.ServiceModel.InstanceContext> objects that execute at one time across a <xref:System.ServiceModel.ServiceHost>. Requests to create additional instances are queued and complete when a slot below the limit becomes available. The default is the sum of maxConcurrentSessions and MaxConcurrentCalls|  
|maxConcurrentSessions|A positive integer that limits the number of sessions a <xref:System.ServiceModel.ServiceHost> object can accept.<br /><br /> The service will accept connections in excess of the limit, but only the channels below the limit are active (messages are read from the channel). Setting this value to 0 is equivalent to setting it to Int32.MaxValue. The default is 100 * processor count.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 Throttling controls place limits on the number of concurrent calls, instances, or sessions to prevent over-consumption of resources.  
  
 A trace is written every time the value of attributes is reached. The first trace is written as a warning.  
  
## Example  
 The following configuration example specifies that the service limits the maximum concurrent calls to 2, and the maximum number of concurrent instances to 10. For a detailed example of running this example, see [Throttling](../../../../../docs/framework/wcf/samples/throttling.md).  
  
```xml  
<behaviors>   
  <serviceBehaviors>   
    <behavior name="CalculatorServiceBehavior">   
      <serviceDebug includeExceptionDetailInFaults="False" />   
      <serviceMetadata httpGetEnabled="True"/>   
      <!-- Specify throttling behavior -->  
      <serviceThrottling maxConcurrentCalls="2"   
           maxConcurrentInstances="10"/>   
    </behavior>  
  </serviceBehaviors>  
</behaviors>  
```  
  
## See Also  
 <xref:System.ServiceModel.Description.ServiceThrottlingBehavior>  
 <xref:System.ServiceModel.Configuration.ServiceThrottlingElement>  
 [Using ServiceThrottlingBehavior to Control WCF Service Performance](../../../../../docs/framework/wcf/feature-details/using-servicethrottlingbehavior-to-control-wcf-service-performance.md)
