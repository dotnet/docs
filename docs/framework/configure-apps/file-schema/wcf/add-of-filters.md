---
title: "&lt;add&gt; of &lt;filters&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e3bf437c-dd99-49f3-9792-9a8721e6eaad
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;filters&gt;
A XPath filter that specifies the kind of message to be logged.  
  
 \<system.ServiceModel>  
\<diagnostic>  
\<messageLogging>  
\<filters>  
\<add>  
  
## Syntax  
  
```xml  
<filters>  
   <add filter="String"/>  
</filters>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|filter|A string that specifies a query on an XML document defined by an XPath 1.0 expression. For more information, see <xref:System.ServiceModel.Dispatcher.XPathMessageFilter>.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<filters>](../../../../../docs/framework/configure-apps/file-schema/wcf/filters.md)|Contains a collection of XPath filters used to control what kind of message is logged.|  
  
## Remarks  
 Filters are applied only at the transport layer, specified by `logMessagesAtTransportLevel` is `true`. Service level and malformed message logging are not affected by filters.  
  
 To add a filter to the collection, use the `add` keyword. When one or more filters are defined, only messages that match at least one of the filters are logged. If no filter is defined, all messages pass through.  
  
 Filters support the full XPath syntax, and are applied in the order they appear in the configuration file. A syntactically incorrect filter results in a configuration exception.  
  
 The following is an example of how to configure a filter that records only messages that have a SOAP Header section.  
  
## Example  
 The following is an example of how to configure a filter that records only messages that have a SOAP Header section.  
  
```xml  
<messageLogging logEntireMessage="true"  
     logMalformedMessages="true" logMessagesAtServiceLevel="true"  
     logMessagesAtTransportLevel="true" maxMessagesToLog="420">  
     <filters>  
        <add xmlns:soap="http://www.w3.org/2003/05/soap-envelope">  
                        /soap:Envelope/soap:Headers  
        </add>  
     </filters>  
</messageLogging>  
```  
  
## See Also  
 <xref:System.ServiceModel.Configuration.DiagnosticSection>  
 <xref:System.ServiceModel.Diagnostics>  
 <xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A>  
 <xref:System.ServiceModel.Configuration.MessageLoggingElement>  
 <xref:System.ServiceModel.Configuration.MessageLoggingElement.Filters%2A>  
 <xref:System.ServiceModel.Configuration.XPathMessageFilterElement>  
 <xref:System.ServiceModel.Dispatcher.XPathMessageFilter>  
 [Configuring Message Logging](../../../../../docs/framework/wcf/diagnostics/configuring-message-logging.md)  
 [Configuring Message Logging](../../../../../docs/framework/wcf/diagnostics/configuring-message-logging.md)  
 [\<messageLogging>](../../../../../docs/framework/configure-apps/file-schema/wcf/messagelogging.md)
