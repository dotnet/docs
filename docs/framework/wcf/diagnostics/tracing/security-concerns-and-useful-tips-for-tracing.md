---
title: "Security Concerns and Useful Tips for Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 88bc2880-ecb9-47cd-9816-39016a07076f
caps.latest.revision: 11
author: "BrucePerlerMS"
ms.author: "bruceper"
manager: "mbaldwin"
ms.workload: 
  - "dotnet"
---
# Security Concerns and Useful Tips for Tracing
This topic describes how you can protect sensitive information from being exposed, as well as useful tips when using WebHost.  
  
## Using a Custom Trace Listener with WebHost  
 If you are writing your own trace listener, you should be aware of the possibility that traces might be lost in the case of a Web-hosted service. When WebHost recycles, it shuts down the live process while a duplicate takes over. However, the two processes must still have access to the same resource for some time, which is dependent on the listener type. In this case, , `XmlWriterTraceListener` creates a new trace file for the second process; while Windows event tracing manages multiple processes within the same session and gives access to the same file. If your own listener does not provide similar functionalities, traces can be lost when the file is locked up by the two processes.  
  
 You should also be aware that a custom trace listener can send traces and messages on the wire, for example, to a remote database. As an application deployer, you should configure custom listeners with appropriate access control. You should also apply security control on any personal information that can be exposed at the remote location.  
  
## Logging Sensitive Information  
 Traces contain message headers when a message is in scope. When tracing is enabled, personal information in application-specific headers, such as, a query string; and body information, such as, a credit card number, can become visible in the logs. The application deployer is responsible for enforcing access control on the configuration and trace files. If you do not want this kind of information to be visible, you should disable tracing, or filter out part of the data if you want to share the trace logs.  
  
 The following tips can help you to prevent the content of a trace file from being exposed unintentionally:  
  
-   Ensure that the log files are protected by Access Control Lists (ACL) both in WebHost and self-host scenarios.  
  
-   Choose a file extension that cannot be easily served using a Web request. For example, the .xml file extension is not a safe choice. You can check the IIS administration guide to see a list of extensions that can be served.  
  
-   Specify an absolute path for the log file location, which should be outside of the WebHost vroot public directory to prevent it from being accessed by an external party using a Web browser.  
  
 By default, keys and personally identifiable information (PII) such as username and password are not logged in traces and logged messages. A machine administrator, however, can use the `enableLoggingKnownPII` attribute in the `machineSettings` element of the Machine.config file to permit applications running on the machine to log known personally identifiable information (PII) as follows:  
  
```xml  
<configuration>  
   <system.ServiceModel>  
      <machineSettings enableLoggingKnownPii="Boolean"/>  
   </system.ServiceModel>  
</configuration>   
```  
  
 An application deployer can then use the `logKnownPii` attribute in either the App.config or Web.config file to enable PII logging as follows:  
  
```xml  
<system.diagnostics>  
  <sources>  
      <source name="System.ServiceModel.MessageLogging"  
        logKnownPii="true">  
        <listeners>  
                 <add name="messages"  
                 type="System.Diagnostics.XmlWriterTraceListener"  
                 initializeData="c:\logs\messages.svclog" />  
          </listeners>  
      </source>  
  </sources>  
</system.diagnostics>  
```  
  
 Only when both settings are `true` is PII logging enabled. The combination of two switches allows the flexibility to log known PII for each application.  
  
 You should be aware that if you specify two or more custom sources in a configuration file, only the attributes of the first source are read. The others are ignored. This means that, for the following App.config, file, PII is not logged for both sources even though PII logging is explicitly enabled for the second source.  
  
```xml  
<system.diagnostics>  
  <sources>  
      <source name="System.ServiceModel.MessageLogging"  
        logKnownPii="false">  
        <listeners>  
           <add name="messages"  
                type="System.Diagnostics.XmlWriterTraceListener"  
                initializeData="c:\logs\messages.svclog" />  
          </listeners>  
      </source>  
      <source name="System.ServiceModel"   
         logKnownPii="true">  
         <listeners>  
            <add name="xml" />  
         </listeners>  
      </source>  
  </sources>  
</system.diagnostics>  
```  
  
 If the `<machineSettings enableLoggingKnownPii="Boolean"/>` element exists outside the Machine.config file, the system throws a <xref:System.Configuration.ConfigurationErrorsException>.  
  
 The changes are effective only when the application starts or restarts. An event is logged at startup when both attributes are set to `true`. An event is also logged if `logKnownPii` is set to `true` but `enableLoggingKnownPii` is `false`.  
  
 For more information on PII logging, see [PII Security Lockdown](../../../../../docs/framework/wcf/samples/pii-security-lockdown.md) sample.  
  
 The machine administrator and application deployer should exercise extreme caution when using these two switches. If PII logging is enabled, security keys and PII are logged. If it is disabled, sensitive and application-specific data is still logged in message headers and bodies. For a more thorough discussion on privacy and protecting PII from being exposed, see [User Privacy](http://go.microsoft.com/fwlink/?LinkID=94647).  
  
 In addition, the IP address of the message sender is logged once per connection for connection-oriented transports, and once per message sent otherwise. This is done without the consent of the sender. However, this logging only occurs at the Information or Verbose tracing levels, which are not the default or recommended tracing levels in production, except for live debugging.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)
