---
title: "Filtering"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4002946c-e34a-4356-8cfb-e25912a4be63
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Filtering
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] filtering system can use declarative filters to match messages and make operational decisions. You can use filters to determine what to do with a message by examining part of the message. A queuing process, for example, can use an XPath 1.0 query to check the priority element of a known header to determine whether to move a message to the front of the queue.  
  
 The filtering system is composed of a set of classes that can efficiently determine which of a set of filters are `true` for a particular [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] message.  
  
 The filtering system is a core component of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] messaging; it is designed to be extremely fast. Each filter implementation has been optimized for a particular kind of matching against [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] messages.  
  
 The filtering system is not thread safe. The application must handle any locking semantics. It does, however, support a multi-reader, single writer.  
  
## Where Filtering Fits  
 Filtering is performed after a message is received and is part of the process of dispatching the message to the proper application component. The design of the filtering system addresses the requirements of several [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] subsystems, including messaging, routing, security, event handling, and system management.  
  
## Filters  
 The filter engine has two primary components, filters and filter tables. A filter makes Boolean decisions about a message based on user-specified logical conditions. Filters implement the <xref:System.ServiceModel.Dispatcher.MessageFilter> class.  
  
 The <xref:System.ServiceModel.Dispatcher.MessageFilter.Match%2A> methods are used to determine if a message satisfies a filter. One of the methods tests the message's header, but cannot inspect the message body. The other method takes a *message buffer* as an input parameter and can inspect the message body.  
  
 Filters are not usually tested individually, but as part of a filter table, which is a generic class that the <xref:System.ServiceModel.Dispatcher.MessageFilterTable%601.CreateFilterTable%2A> method creates.  
  
 The several kinds of filters each specialize in matching on a particular kind of Boolean condition. Once you construct a filter, you cannot change the criteria that a filter uses; to modify a filter's criteria, construct a new one and delete the existing filter.  
  
### Action Filters  
 The <xref:System.ServiceModel.Dispatcher.ActionMessageFilter> contains a list of action strings. If any of the actions in the filter’s list matches the Action header in the message or message buffer, the `Match` method returns `true`. If the list is empty, the filter is considered a match-all filter and any message or message buffer matches and `Match` returns `true`. If none of the actions in the filter’s list matches the Action header in the message or message buffer, `Match` returns `false`. If there is no action in the message and the filter’s list is non-empty, then `Match` returns `false`.  
  
### Endpoint Address Filters  
 The <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter> filters messages and message buffers based on an endpoint address, as represented in their header collection. For a message to pass such a filter, the following conditions must be met:  
  
-   The filter’s address Uniform Resource Identifier (URI) must be the same as the one in the message To header.  
  
-   Each endpoint parameter in the address of the filter (`address.Headers` collection) must find a header in the message to map on. Extra headers in the message or message buffer are acceptable for the match to remain `true`.  
  
### Prefix Endpoint Address Filters  
  
1.  The <xref:System.ServiceModel.Dispatcher.PrefixEndpointAddressMessageFilter> functions just like the <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter> filter, except that the match can be on a prefix of the message URI. For example, a filter specifying the address http://www.adatum.com matches messages addressed to http://www.adatum.com/userA.  
  
### XPath Message Filters  
 An <xref:System.ServiceModel.Dispatcher.XPathMessageFilter> uses an XPath expression to determine whether an XML document contains specific elements, attributes, text, or other XML syntactic constructs. The filter is optimized to be extremely efficient for a strict subset of XPath. The XML Path Language is described in the [W3C XML Path Language 1.0 specification](http://go.microsoft.com/fwlink/?LinkId=94779).  
  
 Typically, an application uses an <xref:System.ServiceModel.Dispatcher.XPathMessageFilter> at an endpoint to query the contents of a SOAP message and then takes the appropriate action based on the results of that query. A queuing process, for example, may use an XPath query to inspect the priority element of a known header to decide whether to move a message to the front of the queue.  
  
## Filter Tables  
 Filter tables are used to store key-value pairs, where a filter is the key and some associated data is the value. The filter data can be used to indicate what actions to take if a message matches the filter and the type of the filter data is the generic parameter for the filter table class. The filter data can consist of routing rules, session security state, listeners on a channel, and so on. The data can be used where data flow control is necessary.  
  
 Filter tables implement the generic interface <xref:System.ServiceModel.Dispatcher.IMessageFilterTable%601>.  
  
 Filter tables have several methods that match a message against all the filters in the table and return an unordered collection of matching filters or data. Some of the match methods are multiple-match and return all matching items. Others are single-match, returning only one item, and throw a <xref:System.ServiceModel.Dispatcher.MultipleFilterMatchesException> if more than one filter matches.  
  
### Message Filter Table  
 The <xref:System.ServiceModel.Dispatcher.MessageFilterTable%601> is the most general implementation of <xref:System.ServiceModel.Dispatcher.IMessageFilterTable%601>. You can store filters of all types in the table.  
  
 You can assign numeric priorities to filters, where the highest priority is signified by the highest number. Multiple types of filters can have the same priority. A particular type of filter can appear in more than one priority level.  
  
 Matching is done starting with the highest priority, and once matching filters are found with a given priority, no filters with lower priorities are examined. Therefore, if you are using a single-filter match method, and more than one filter matches a message, but each matching filter has a different priority, then no exception is thrown and the filter with the highest priority is returned. Similarly, a multiple-filter match method returns only those matching filters with the highest priority.  
  
### XPath Message Filter Table  
 The <xref:System.ServiceModel.Dispatcher.XPathMessageFilterTable%601> is optimized for declarative XPath filters, so the table key is a <xref:System.ServiceModel.Dispatcher.XPathMessageFilter>.  
  
 The <xref:System.ServiceModel.Dispatcher.XPathMessageFilterTable%601> class optimizes matching for a subset of XPath that covers most of the messaging scenarios and also supports the full XPath 1.0 grammar. It has optimized algorithms for efficient parallel matching.  
  
 This table has several specialized `Match` methods that operate over an <xref:System.Xml.XPath.XPathNavigator> and a <xref:System.ServiceModel.Dispatcher.SeekableXPathNavigator>. A <xref:System.ServiceModel.Dispatcher.SeekableXPathNavigator> extends the <xref:System.Xml.XPath.XPathNavigator> class by adding a <xref:System.ServiceModel.Dispatcher.SeekableXPathNavigator.CurrentPosition%2A> property. This property allows positions within the XML document to be saved and loaded quickly without having to clone the navigator, an expensive memory allocation that the <xref:System.Xml.XPath.XPathNavigator> requires for such an operation. The [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] XPath engine must frequently record the position of the cursor in the course of executing queries on XML documents, so the <xref:System.ServiceModel.Dispatcher.SeekableXPathNavigator> provides an important optimization for message processing.  
  
## Customer Scenarios  
 You can use filtering any time you want to send a message to different processing modules depending on data contained in the message. Two typical scenarios are routing a message based on its action code and de-multiplexing a stream of messages based on the messages' endpoint address.  
  
### Routing  
 The listener of an endpoint listens for messages that have one or more action codes in the message's SOAP header. You implement this by creating an <xref:System.ServiceModel.Dispatcher.ActionMessageFilter> by passing an array that contains the action codes to its constructor. It uses that filter to register with the `ListenerFactory`, so only messages whose action matches one of those in the filter get to that particular endpoint.  
  
### De-multiplexing  
 When multiple endpoints fan out from the same `ServiceListener` off the wire, the only way to de-multiplex messages and know whether they belong to a certain endpoint address, is to use <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter>s, which select messages toward the registered endpoints by performing a lookup on the information stored in the headers. In these filters, only those messages that pass have all necessary headers that correspond to both:  
  
-   The URI in the `EndpointAddress`.  
  
-   The rest of the endpoint parameters in the `EndpointAddress` as specified in the <xref:System.ServiceModel.Dispatcher.EndpointAddressMessageFilter>.  
  
## See Also  
 [Data Transfer and Serialization](../../../../docs/framework/wcf/feature-details/data-transfer-and-serialization.md)
