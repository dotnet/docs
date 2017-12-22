---
title: "Message Filters"
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
  - "routing [WCF], message filters"
ms.assetid: cb33ba49-8b1f-4099-8acb-240404a46d9a
caps.latest.revision: 8
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Message Filters
To implement content-based routing, the Routing Service uses <xref:System.ServiceModel.Dispatcher.MessageFilter> implementations that inspect specific sections of a message, such as the address, endpoint name, or a specific XPath statement. If none of the message filters provided with [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] meet your needs, you can create a custom filter by creating a new implementation of the base <xref:System.ServiceModel.Dispatcher.MessageFilter> class.  
  
 When configuring the Routing Service, you must define filter elements (<xref:System.ServiceModel.Routing.Configuration.FilterElement> objects) that describe the type of **MessageFilter** and any supporting data required to create the filter, such as specific string values to search for within the message. Note that creating the filter elements only defines the individual message filters; to use the filters to evaluate and route messages you must also define a filter table (<xref:System.ServiceModel.Routing.Configuration.FilterTableEntryCollection>).  
  
 Each entry in the filter table references a filter element and specifies the client endpoint that a message will be routed to if the message matches the filter. The filter table entries also allow you to specify a collection of backup endpoints (<xref:System.ServiceModel.Routing.Configuration.BackupEndpointCollection>), which defines a list of endpoints that the message will be transmitted to in the event of a transmission failure when sending to the primary endpoint. These endpoints will be tried in the order specified until one succeeds.  
  
## Message Filters  
 The message filters used by the Routing Service provide common message selection functionality, such as evaluating the name of the endpoint that a message was sent to, the SOAP action, or the address or address prefix that the message was sent to. Filters can also be joined with an `AND` condition, so that messages will only be routed to an endpoint if the message matches both filters. You can also create custom filters by creating your own implementation of <xref:System.ServiceModel.Dispatcher.MessageFilter>.  
  
 The following table lists the <xref:System.ServiceModel.Routing.Configuration.FilterType> used by the Routing Service, the class that implements the specific message filter, and the required <xref:System.ServiceModel.Routing.Configuration.FilterElement.FilterData%2A> parameters.  
  
|Filter  Type|Description|Filter Data Meaning|Example Filter|  
|------------------|-----------------|-------------------------|--------------------|  
|Action|Uses the <xref:System.ServiceModel.Dispatcher.ActionMessageFilter> class to match messages containing a specific action.|The action to filter upon.|\<filter name="action1" filterType="Action" filterData="http://namespace/contract/operation" />|  
|EndpointAddress|Uses the <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter> class, with <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter.IncludeHostNameInComparison%2A> == `true` to match messages containing a specific address.|The address to filter upon (in the To header).|\<filter name="address1" filterType="EndpointAddress" filterData="http://host/vdir/s.svc/b"  />|  
|EndpointAddressPrefix|Uses the <xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter> class, with <xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter.IncludeHostNameInComparison%2A> == `true` to match messages containing a specific address prefix.|The address to filter upon using longest prefix matching.|\<filter name="prefix1" filterType="EndpointAddressPrefix" filterData="http://host/" />|  
|And|Uses the <xref:System.ServiceModel.Dispatcher.StrictAndMessageFilter> class that always evaluates both conditions before returning.|filterData is not used; instead filter1 and filter2 have the names of the corresponding message filters (also in the table), which should be **AND**ed together.|\<filter name="and1" filterType="And" filter1="address1" filter2="action1" />|  
|Custom|A user-defined type that extends the <xref:System.ServiceModel.Dispatcher.MessageFilter> class and has a constructor taking a string.|The customType attribute is the fully qualified type name of the class to create; filterData is the string to pass to the constructor when creating the filter.|\<filter name="custom1" filterType="Custom" customType="CustomAssembly.CustomMsgFilter, CustomAssembly" filterData="Custom Data" />|  
|EndpointName|Uses the <xref:System.ServiceModel.Dispatcher.EndpointNameMessageFilter> class to match messages based on the name of the service endpoint they arrived on.|The name of the service endpoint, for example: "serviceEndpoint1".  This should be one of the endpoints exposed on the Routing Service.|\<filter name="stock1" filterType="Endpoint" filterData="SvcEndpoint" />|  
|MatchAll|Uses the <xref:System.ServiceModel.Dispatcher.MatchAllMessageFilter> class. This filter matches all arriving messages.|filterData is not used. This filter will always match all messages.|\<filter name="matchAll1" filterType="MatchAll" />|  
|XPath|Uses the <xref:System.ServiceModel.Dispatcher.XPathMessageFilter> class to match specific XPath queries within the message.|The XPath query to use when matching messages.|\<filter name="XPath1" filterType="XPath" filterData="//ns:element" />|  
  
 The following example defines filter entries that use the XPath, EndpointName, and PrefixEndpointAddress message filters. This example also demonstrates using a custom filter for the RoundRobinFilter1 and RoundRobinFilter2 entries.  
  
```xml  
<filters>  
     <filter name="XPathFilter" filterType="XPath"   
             filterData="/s12:Envelope/s12:Header/custom:RoundingCalculator = 1"/>  
     <filter name="EndpointNameFilter" filterType="EndpointName"   
             filterData="calculatorEndpoint"/>  
     <filter name="PrefixAddressFilter" filterType="PrefixEndpointAddress"   
             filterData="http://localhost/routingservice/router/rounding/"/>  
     <filter name="RoundRobinFilter1" filterType="Custom"   
             customType="RoutingServiceFilters.RoundRobinMessageFilter,   
             RoutingService" filterData="group1"/>  
     <filter name="RoundRobinFilter2" filterType="Custom"   
             customType="RoutingServiceFilters.RoundRobinMessageFilter,   
             RoutingService" filterData="group1"/>  
</filters>  
```  
  
> [!NOTE]
>  Simply defining a filter does not cause messages to be evaluated against the filter. The filter must be added to a filter table, which is then associated with the service endpoint exposed by the Routing Service.  
  
### Namespace Table  
 When using an XPath filter, the filter data that contains the XPath query can become extremely large due to the use of namespaces. To alleviate this problem the Routing Service provides the ability to define your own namespace prefixes by using the namespace table.  
  
 The namespace table is a collection of <xref:System.ServiceModel.Routing.Configuration.NamespaceElement> objects that defines the namespace prefixes for common namespaces that can be used in an XPath. The following are the default namespaces and namespace prefixes that are contained in the namespace table.  
  
|Prefix|Namespace|  
|------------|---------------|  
|s11|http://schemas.xmlsoap.org/soap/envelope|  
|s12|http://www.w3.org/2003/05/soap-envelope|  
|wsaAugust2004|http://schemas.xmlsoap.org/ws/2004/08/addressing|  
|wsa10|http://www.w3.org/2005/08/addressing|  
|sm|http://schemas.microsoft.com/serviceModel/2004/05/xpathfunctions|  
|tempuri|http://tempuri.org|  
|ser|http://schemas.microsoft.com/2003/10/Serialization|  
  
 When you know that you will be using a specific namespace in your XPath queries, you can add it to the namespace table along with a unique namespace prefix and use the prefix in any XPath query instead of the full namespace. The following example defines a prefix of "custom" for the namespace "http://my.custom.namespace", which is then used in the XPath query contained in filterData.  
  
```xml  
<namespaceTable>  
     <add prefix="custom" namespace="http://my.custom.namespace/"/>  
</namespaceTable>  
<filters>  
     <filter name="XPathFilter" filterType="XPath" filterData="/s12:Envelope/s12:Header/custom:RoundingCalculator = 1"/>  
</filters>  
```  
  
## Filter Tables  
 While each filter element defines a logical comparison that can be applied to a message, the filter table provides the association between the filter element and the destination client endpoint. A filter table is a named collection of <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement> objects that define the association between a filter, a primary destination endpoint, and a list of alternative backup endpoints. The filter table entries also allow you to specify an optional priority for each filter condition. The following example defines two filters and then defines a filter table that associates each filter with a destination endpoint.  
  
```xml  
<routing>  
     <filters>  
       <filter name="AddAction" filterType="Action" filterData="Add" />  
       <filter name="SubtractAction" filterType="Action" filterData="Subtract" />  
     </filters>  
     <filterTables>  
       <table name="routingTable1">  
         <filters>  
           <add filterName="AddAction" endpointName="Addition" />  
           <add filterName="SubtractAction" endpointName="Subtraction" />  
         </filters>  
       </table>  
     </filterTables>      
</routing>  
```  
  
### Filter Evaluation Priority  
 By default, all entries in the filter table are evaluated simultaneously, and the message being evaluated is routed to the endpoint(s) associated with each matching filter entry. If multiple filters evaluate to `true`, and the message is one-way or duplex, the message is multicast to the endpoints for all matching filters. Request-reply messages cannot be multicast because only one reply can be returned to the client.  
  
 More complex routing logic can be implemented by specifying priority levels for each filter; the Routing Service evaluates all filters at the highest priority level first. If a message matches a filter of this level, no filters of a lower priority are processed. For example, an incoming one-way message is first evaluated against all filters with a priority of 2. The message does not match any filter at this priority level, so next the message is compared against filters with a priority of 1. Two priority 1 filters match the message, and because it is a one-way message it is routed to both destination endpoints.  Because a match was found among the priority 1 filters, no filters of priority 0 are evaluated.  
  
> [!NOTE]
>  If no priority is specified, the default priority of 0 is used.  
  
 The following example defines a filter table that specifies priorities of 2, 1, and 0 for the filters referenced in the table.  
  
```xml  
<filterTables>  
     <filterTable name="filterTable1">  
          <add filterName="XPathFilter" endpointName="roundingCalcEndpoint"   
               priority="2"/>  
          <add filterName="EndpointNameFilter" endpointName="regularCalcEndpoint"   
               priority="1"/>  
          <add filterName="PrefixAddressFilter" endpointName="roundingCalcEndpoint"   
               priority="1"/>  
          <add filterName="MatchAllMessageFilter" endpointName="defaultCalcEndpoint"   
               priority="0"/>  
     </filterTable>  
</filterTables>  
```  
  
 In the preceding example, if a message matches the XPathFilter, it will be routed to the roundingCalcEndpoint and no further filters in the table will be evaluated because all other filters are of a lower priority. However, if the message does not match the XPathFilter it will then be evaluated against all filters of the next lower priority, EndpointNameFilter and PrefixAddressFilter.  
  
> [!NOTE]
>  When possible, use exclusive filters instead of specifying a priority because priority evaluation can result in performance degradation.  
  
### Backup Lists  
 Each filter in the filter table can optionally specify a backup list, which is a named collection of endpoints (<xref:System.ServiceModel.Routing.Configuration.BackupEndpointCollection>). This collection contains an ordered list of endpoints that the message will be transmitted to in the event of a <xref:System.ServiceModel.CommunicationException> when sending to the primary endpoint specified in <xref:System.ServiceModel.Routing.Configuration.FilterTableEntryElement.EndpointName%2A>. The following example defines a backup list named "backupServiceEndpoints" that contains two endpoints.  
  
```xml  
<filterTables>  
     <filterTable name="filterTable1">  
          <add filterName="MatchAllFilter1" endpointName="Destination" backupList="backupEndpointList"/>  
     </filterTable>  
</filterTables>  
<backupLists>  
     <backupList name="backupEndpointList">  
          <add endpointName="backupServiceQueue" />  
          <add endpointName="alternateServiceQueue" />  
     </backupList>  
</backupLists>  
```  
  
 In the preceding example, if a send to the primary endpoint "Destination" fails, the Routing Service will try sending to each endpoint in the sequence they are listed, first sending to backupServiceQueue and subsequently sending to alternateServiceQueue if the send to backupServiceQueue fails. If all backup endpoints fail, a fault is returned.
