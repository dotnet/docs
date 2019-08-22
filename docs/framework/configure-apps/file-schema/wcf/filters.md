---
title: "<filters>"
ms.date: "03/30/2017"
ms.assetid: 37a87222-ec78-4728-8105-9ca1bd961f0c
---

# \<filters>

The `filters` element holds a collection of XPath filters used to control what kind of message is logged.

Filters are applied only at the transport layer, specified by `logMessagesAtTransportLevel` is `true`. Service level and malformed message logging are not affected by filters.

To add a filter to the collection, use the `add` keyword. When one or more filters are defined, only messages that match at least one of the filters are logged. If no filter is defined, all messages pass through.

Filters support the full XPath syntax, and are applied in the order they appear in the configuration file. A syntactically incorrect filter results in a configuration exception.

The following is an example of how to configure a filter that records only messages that have a SOAP Header section.
  
```xml  
<messageLogging logEntireMessage="true"
                logMalformedMessages="true"
                logMessagesAtServiceLevel="true"
                logMessagesAtTransportLevel="true"
                maxMessagesToLog="420">
  <filters>
    <add xmlns:soap="http://www.w3.org/2003/05/soap-envelope">
      /soap:Envelope/soap:Headers
    </add>
  </filters>
</messageLogging>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.DiagnosticSection>
- <xref:System.ServiceModel.Diagnostics>
- <xref:System.ServiceModel.Configuration.DiagnosticSection.MessageLogging%2A>
- <xref:System.ServiceModel.Configuration.MessageLoggingElement>
- <xref:System.ServiceModel.Configuration.MessageLoggingElement.Filters%2A>
- <xref:System.ServiceModel.Configuration.XPathMessageFilterElementCollection>
- <xref:System.ServiceModel.Configuration.XPathMessageFilterElement>
- <xref:System.ServiceModel.Dispatcher.XPathMessageFilter>
- [Configuring Message Logging](../../../wcf/diagnostics/configuring-message-logging.md)
- [\<messageLogging>](messagelogging.md)
