---
title: "Configuring Message Logging"
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
  - "message logging [WCF]"
ms.assetid: 0ff4c857-8f09-4b85-9dc0-89084706e4c9
caps.latest.revision: 40
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring Message Logging
This topic describes how you can configure message logging for different scenarios.  
  
## Enabling Message Logging  
 [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] does not log messages by default. To activate message logging, you must add a trace listener to the `System.ServiceModel.MessageLogging` trace source and set attributes for the `<messagelogging>` element in the configuration file.  
  
 The following example shows how to enable logging and specify additional options.  
  
```xml  
<system.diagnostics>  
  <sources>  
      <source name="System.ServiceModel.MessageLogging">  
        <listeners>  
                 <add name="messages"  
                 type="System.Diagnostics.XmlWriterTraceListener"  
                 initializeData="c:\logs\messages.svclog" />  
          </listeners>  
      </source>  
    </sources>  
</system.diagnostics>  
  
<system.serviceModel>  
  <diagnostics>  
    <messageLogging   
         logEntireMessage="true"   
         logMalformedMessages="false"  
         logMessagesAtServiceLevel="true"   
         logMessagesAtTransportLevel="false"  
         maxMessagesToLog="3000"  
         maxSizeOfMessageToLog="2000"/>  
  </diagnostics>  
</system.serviceModel>  
```  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] message logging settings, see [Recommended Settings for Tracing and Message Logging](../../../../docs/framework/wcf/diagnostics/tracing/recommended-settings-for-tracing-and-message-logging.md).  
  
 You can use `add` to specify the name and type of the listener you want to use. In the example configuration, the Listener is named "messages" and adds the standard .NET Framework trace listener (`System.Diagnostics.XmlWriterTraceListener`) as the type to use. If you use `System.Diagnostics.XmlWriterTraceListener`, you must specify the output file location and name in the configuration file. This is done by setting `initializeData` to the name of the log file. Otherwise, the system throws an exception. You can also implement a custom listener that emits logs to a default file.  
  
> [!NOTE]
>  Because message logging accesses disk space, you should limit the number of messages that are written to disk for a particular service. When the message limit is reached, a trace at the Information level is produced and all message logging activities stop.  
  
 The logging level, as well as the additional options, are discussed in the Logging Level and Options section.  
  
 The `switchValue` attribute of a `source` is only valid for tracing. If you specify a `switchValue` attribute for the `System.ServiceModel.MessageLogging` trace source as follows, it has no effect.  
  
```xml  
<source name="System.ServiceModel.MessageLogging" switchValue="Verbose">  
```  
  
 If you want to disable the trace source, you should use the `logMessagesAtServiceLevel`, `logMalformedMessages`, and `logMessagesAtTransportLevel` attributes of the `messageLogging` element instead. You should set all these attributes to `false`. This can be done by using the configuration file in the previous code example, through the Configuration Editor UI interface, or using WMI. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the Configuration Editor tool, see [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] WMI, see [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md).  
  
## Logging Levels and Options  
 For incoming messages, logging happens immediately after the message is formed, immediately before the message gets to user code in the service level, and when malformed messages are detected.  
  
 For outgoing messages, logging happens immediately after the message leaves user code and immediately before the message goes on the wire.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] logs messages at two different levels, service and transport. Malformed messages are also logged. The three categories are independent from each other and can be activated separately in configuration.  
  
 You can control the logging level by setting the `logMessagesAtServiceLevel`, `logMalformedMessages`, and `logMessagesAtTransportLevel` attributes of the `messageLogging` element.  
  
### Service Level  
 Messages logged at this layer are about to enter (on receiving) or leave (on sending) user code. If filters have been defined, only messages that match the filters are logged. Otherwise, all messages at the service level are logged. Infrastructure messages (transactions, peer channel, and security) are also logged at this level, except for Reliable Messaging messages. On streamed messages, only the headers are logged. In addition, secure messages are logged decrypted at this level.  
  
### Transport Level  
 Messages logged at this layer are ready to be encoded or decoded for or after transportation on the wire. If filters have been defined, only messages that match the filters are logged. Otherwise, all messages at the transport layer are logged. All infrastructure messages are logged at this layer, including reliable messaging messages. On streamed messages, only the headers are logged. In addition, secure messages are logged as encrypted at this level, except if a secure transport such as HTTPS is used.  
  
### Malformed Level  
 Malformed messages are messages that are rejected by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] stack at any stage of processing. Malformed messages are logged as-is: encrypted if they are so, with non-proper XML, and so on. `maxSizeOfMessageToLog` defined the size of the message to be logged as CDATA. By default, `maxSizeOfMessageToLog` is equal to 256K. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] this attribute, see the Other Options section.  
  
### Other Options  
 In addition to the logging levels, the user can specify the following options:  
  
-   Log Entire Message (`logEntireMessage` attribute): This value specifies whether the entire message (message header and body) is logged. The default value is `false`, meaning that only the header is logged. This setting affects service and transport message logging levels..  
  
-   Max messages to log (`maxMessagesToLog` attribute): This value specifies the maximum number of messages to log. All messages (service, transport, and malformed messages) are counted towards this quota. When the quota is reached, a trace is emitted and no additional message is logged. The default value is 10000.  
  
-   Max size of message to log (`maxSizeOfMessageToLog` attribute): This value specifies the maximum size of messages to log in bytes. Messages that exceed the size limit are not logged, and no other activity is performed for that message. This setting affects all trace levels. If ServiceModel tracing is on, a Warning level trace is emitted at the first logging point (ServiceModelSend* or TransportReceive) to notify the user. The default value for service level and transport level messages is 256K, while the default value for malformed messages is 4K.  
  
    > [!CAUTION]
    >  The message size that is computed to compare against `maxSizeOfMessageToLog` is the message size in memory before serialization. This size can differ from the actual length of the message string that is being logged, and in many occasions is bigger than the actual size. As a result, messages may not be logged. You can account for this fact by specifying the `maxSizeOfMessageToLog` attribute to be 10% larger than the expected message size. In addition, if malformed messages are logged, the actual disk space utilized by the message logs can be up to 5 times the size of the value specified by `maxSizeOfMessageToLog`.  
  
 If no trace listener is defined in the configuration file, no logging output is generated regardless of the specified logging level.  
  
 Message logging options, such as the attributes described in this section, can be changed at runtime using Windows Management Instrumentation (WMI). This can be done by accessing the [AppDomainInfo](../../../../docs/framework/wcf/diagnostics/wmi/appdomaininfo.md) instance, which exposes these Boolean properties: `LogMessagesAtServiceLevel`, `LogMessagesAtTransportLevel`, and `LogMalformedMessages`. Therefore, if you configure a trace listener for message logging, but set these options to `false` in configuration, you can later change them to `true` when the application is running. This effectively enables message logging at runtime. Similarly, if you enable message logging in your configuration file, you can disable it at runtime using WMI. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Windows Management Instrumentation for Diagnostics](../../../../docs/framework/wcf/diagnostics/wmi/index.md).  
  
 The `source` field in a message log specifies in which context the message is logged: when sending/receiving a request message, for a request-reply or 1-way request, at service model or transport layer, or in the case of a malformed message.  
  
 For malformed messages, `source`  is equal to `Malformed`. Otherwise, source has the following values based on the context.  
  
 For Request/Reply  
  
||Send Request|Receive Request|Send Reply|Receive Reply|  
|-|------------------|---------------------|----------------|-------------------|  
|Service Model layer|Service<br /><br /> Level<br /><br /> Send<br /><br /> Request|Service<br /><br /> Level<br /><br /> Receive<br /><br /> Request|Service<br /><br /> Level<br /><br /> Send<br /><br /> Reply|Service<br /><br /> Level<br /><br /> Receive<br /><br /> Reply|  
|Transport layer|Transport<br /><br /> Send|Transport<br /><br /> Receive|Transport<br /><br /> Send|Transport<br /><br /> Receive|  
  
 For One-way Request  
  
||Send Request|Receive Request|  
|-|------------------|---------------------|  
|Service Model layer|Service<br /><br /> Level<br /><br /> Send<br /><br /> Datagram|Service<br /><br /> Level<br /><br /> Receive<br /><br /> Datagram|  
|Transport layer|Transport<br /><br /> Send|Transport<br /><br /> Receive|  
  
## Message Filters  
 Message filters are defined in the `messageLogging` configuration element of the `diagnostics` configuration section. They are applied at the service and transport level. When one or more filters are defined, only messages that match at least one of the filters are logged. If no filter is defined, all messages pass through.  
  
 Filters support the full XPath syntax and are applied in the order they appear in the configuration file. A syntactically incorrect filter results in a configuration exception.  
  
 Filters also provide a safety feature using the `nodeQuota` attribute, which limits the maximum number of nodes in the XPath DOM that can be examined to match the filter.  
  
 The following example shows how to configure a filter that records only messages that have a SOAP header section.  
  
```xml  
<messageLogging logEntireMessage="true"  
    logMalformedMessages="true"   
    logMessagesAtServiceLevel="true"  
    logMessagesAtTransportLevel="true"  
    maxMessagesToLog="420">  
    <filters>  
        <add nodeQuota="10" xmlns:soap="http://www.w3.org/2003/05/soap-envelope">  
                 /soap:Envelope/soap:Header  
        </add>  
     </filters>  
</messageLogging>  
```  
  
 Filters cannot be applied to the body of a message. Filters that attempt to manipulate the body of a message are removed from the list of filters. An event is also emitted that indicates this. For example, the following filter would be removed from the filter table.  
  
```xml  
<add xmlns:s="http://schemas.xmlsoap.org/soap/envelope/">/s:Envelope/s:Body[contains(text(), "Hello")]</add>  
```  
  
## Configuring a Custom Listener  
 You can also configure a custom listener with additional options. A custom listener can be useful in filtering application-specific PII elements from messages before logging. The following example demonstrates a custom listener configuration.  
  
```xml  
<system.diagnostics>  
   <sources>  
     <source name="System.ServiceModel.MessageLogging">  
           <listeners>  
             <add name="MyListener"   
                    type="YourCustomListener"  
                    initializeData="c:\logs\messages.svclog"  
                    maxDiskSpace="1000"/>  
           </listeners>  
     </source>  
   </sources>  
</system.diagnostics>  
```  
  
 You should be aware that the `type` attribute should be set to a qualified assembly name of the type.  
  
## See Also  
 [\<messageLogging>](../../../../docs/framework/configure-apps/file-schema/wcf/messagelogging.md)  
 [Message Logging](../../../../docs/framework/wcf/diagnostics/message-logging.md)  
 [Recommended Settings for Tracing and Message Logging](../../../../docs/framework/wcf/diagnostics/tracing/recommended-settings-for-tracing-and-message-logging.md)
