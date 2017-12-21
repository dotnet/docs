---
title: "Choosing a Filter"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 67ab5af9-b9d9-4300-b3b1-41abb5a1fd10
caps.latest.revision: 8
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Choosing a Filter
When configuring the Routing Service, it is important to select correct message filters and configure them to allow you to make exact matches against the messages you receive. If the filters you select are overly broad in their matches or are incorrectly configured, messages are routed incorrectly. If the filters are too restrictive, you may not have any valid routes available for some of your messages.  
  
## Filter Types  
 When selecting the filters that are used by the Routing Service, it is important that you understand how each filter works as well as what information is available as part of the incoming messages. For instance, if all messages are received over the same endpoint, the Address and EndpointName filters are not useful because all messages match these filters.  
  
### Action  
 The Action filter inspects the <xref:System.ServiceModel.Channels.MessageHeaders.Action%2A> property. If the contents of the Action header in the message match the filter data value specified in the filter configuration, then this filter returns `true`. The following example defines a `FilterElement` that uses the Action filter to match messages with an action header that contains a value of "http://namespace/contract/operation/".  
  
```xml  
<filter name="action1" filterType="Action" filterData="http://namespace/contract/operation/" />  
```  
  
```csharp  
ActionMessageFilter action1 = new ActionMessageFilter(new string[] { "http://namespace/contract/operation" });  
```  
  
 This filter should be used when routing messages that contain a unique Action header.  
  
### EndpointAddress  
 The EndpointAddress filter inspects the EndpointAddress that the message was received on. If the address that the message arrives at exactly matches the filter address specified in the filter configuration, then this filter returns `true`. The following example defines a `FilterElement` that uses the Address filter to match any messages addressed to "http://\<hostname>/vdir/s.svc/b".  
  
```xml  
<filter name="address1" filterType="EndpointAddress" filterData="http://host/vdir/s.svc/b" />  
```  
  
```csharp  
EndpointAddressMessageFilter address1 = new EndpointAddressMessageFilter(new EndpointAddress("http://host/vdir/s.svc/b"), false);  
```  
  
> [!NOTE]
>  It is important to note that the host name portion of an address can differ based on whether the client uses the fully qualified domain name, NetBIOS name, IP address, or other name. Because differing values can refer to the same host, the default behavior for this comparison is to not use the host name portion of the address when performing matches.  
>   
>  This behavior can be modified to allow the comparison to evaluate the host name when configuring the Routing Service programmatically.  
  
 This filter should be used when the incoming messages are addressed to a unique address.  
  
### EndpointAddressPrefix  
 The EndpointAddressPrefix filter is similar to the EndpointAddress filter. The EndpointAddressPrefix filter inspects the EndpointAddress that the message was received on. However the EndpointAddressPrefix filter acts as a wildcard by matching addresses that begin with the value specified in the filter configuration. The following example defines a `FilterElement` that uses the EndpointAddressPrefix filter to match any messages addressed to "http://\<hostname>/vdir*".  
  
```xml  
<filter name="prefix1" filterType="EndpointAddressPrefix" filterData="http://host/vdir" />  
```  
  
```csharp  
PrefixEndpointAddressMessageFilter prefix1 = new PrefixEndpointAddressMessageFilter(new EndpointAddress("http://host/vdir/s.svc/b"), false);  
```  
  
> [!NOTE]
>  It is important to note that the host name portion of an address can differ based on whether the client uses the fully qualified domain name, NetBIOS name, IP address, or other name. Because differing values can refer to the same host, the default behavior for this comparison is to not use the host name portion of the address when performing matches.  
  
 This filter should be used when routing incoming messages that share a common address prefix.  
  
### AND  
 The AND filter does not directly filter on a value within a message, but allows you to combine two other filters to create an `AND` condition where both filters must match the message before the AND filter evaluates to `true`. This allows you to create complex filters that only match if all the sub-filters match. The following example defines an address filter and an action filter, and then defines an AND filter that evaluates a message against both the address and action filters. If both the address and the action filters match, then the AND filter returns `true`.  
  
```xml  
<filter name="address1" filterType="AddressPrefix" filterData="http://host/vdir"/>  
<filter name="action1" filterType="Action" filterData="http://namespace/contract/operation/"/>  
<filter name="and1" filterType="And" filter1="address1" filter2="action1" />  
```  
  
```csharp  
EndpointAddressMessageFilter address1 = new EndpointAddressMessageFilter(new EndpointAddress("http://host/vdir/s.svc/b"), false);  
ActionMessageFilter action1 = new ActionMessageFilter(new string[] { "http://namespace/contract/operation" });  
StrictAndMessageFilter and1=new StrictAndMessageFilter(address1, action1);  
```  
  
 This filter should be used when you must combine the logic from multiple filters to determine when a match should be made. For example, if you have multiple destinations that must receive only certain combinations of actions and messages to particular addresses, you can use an AND filter to combine the necessary Action and Address filters.  
  
### Custom  
 When selecting the Custom filter type, you must provide a customType value that contains the type of the assembly that contains the **MessageFilter** implementation to be used for this filter. Additionally, filterData must contain any values that the custom filter may require in its evaluation of messages. The following example defines a `FilterElement` that uses the `CustomAssembly.MyCustomMsgFilter` MessageFilter implementation.  
  
```xml  
<filter name="custom1" filterType="Custom" customType="CustomAssembly.MyCustomMsgFilter, CustomAssembly" filterData="Custom Data" />  
```  
  
```csharp  
MyCustomMsgFilter custom1=new MyCustomMsgFilter("Custom Data");  
```  
  
 If you need to perform custom matching logic against a message that is not covered by the filters provided with [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)], you must create a custom filter that is an implementation of the **MessageFilter** class. For example, you might create a custom filter that compares a field in the incoming message against a list of known values given to the filter as configuration, or that hashes a particular message element and then examines that value to determine whether the filter should return `true` or `false`.  
  
### EndpointName  
 The EndpointName filter inspects the name of the endpoint that received the message. The following example defines a `FilterElement` that uses the EndpointName filter to route messages received on the "SvcEndpoint".  
  
```xml  
<filter name="name1" filterType="Endpoint" filterData="SvcEndpoint" />  
```  
  
```csharp  
EndpointNameMessageFilter name1 = new EndpointNameMessageFilter("SvcEndpoint");  
```  
  
 This filter is useful when the Routing Service exposes more than one named service endpoint. For example, you might expose two endpoints that the Routing Service uses to receive messages; one is used by priority customers who require real-time processing of their messages, while the other endpoint receives messages that are not time sensitive.  
  
 While you can often use full address matching to determine which endpoint a message was received on, using the defined endpoint name instead is a convenient shortcut that is often less error prone, especially when configuring a Routing Service using a configuration file (where endpoint names are a required attribute).  
  
### MatchAll  
 The MatchAll filter matches any received message. It is useful if you must always route all received messages to a specific endpoint, such as a logging service that stores a copy of all received messages. The following example defines a `FilterElement` that uses the MatchAll filter.  
  
```xml  
<filter name="matchAll1" filterType="MatchAll" />  
```  
  
```csharp  
MatchAllMessageFilter matchAll1 = new MatchAllMessageFilter();  
```  
  
### XPath  
 The XPath filter allows you to specify an XPath query that is used to inspect a specific element within the message. XPath filtering is a powerful filtering option that allows you to directly inspect any XML addressable entry within the message; however it requires that you have specific knowledge of the structure of the messages that you are receiving. The following example defines a `FilterElement` that uses the XPath filter to inspect the message for an element named "element" within the namespace referenced by the "ns" namespace prefix.  
  
```xml  
<filter name="xpath1" filterType="XPath" filterData="//ns:element" />  
```  
  
```csharp  
XPathMessageFilter xpath1=new XPathMessageFilter("//ns:element");  
```  
  
 This filter is useful if you know that the messages you are receiving contain a specific value. For example, if you are hosting two versions of the same service and you know that messages addressed to the newer version of the service contain a unique value in a custom header, you can create a filter that uses XPath to navigate to this header and compares the value present in the header to another given in the filter configuration to determine if the filter matches.  
  
 Because XPath queries often contain unique namespaces, which are often lengthy or complex string values, the XPath filter allows you to use the namespace table to define unique prefixes for your namespaces. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the namespace table, see [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md).  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] designing XPath queries, see [XPath Syntax](http://go.microsoft.com/fwlink/?LinkId=164592).  
  
## See Also  
 [Message Filters](../../../../docs/framework/wcf/feature-details/message-filters.md)  
 [How To: Use Filters](../../../../docs/framework/wcf/feature-details/how-to-use-filters.md)
