---
title: "Recommended Settings for Tracing and Message Logging"
description: Learn about recommended tracing and message logging settings for different operating environments in WCF.
ms.date: "03/30/2017"
ms.assetid: c6aca6e8-704e-4779-a9ef-50c46850249e
---
# Recommended Settings for Tracing and Message Logging

This topic describes recommended tracing and message logging settings for different operating environments.  
  
## Recommended Settings for a Production Environment  

 For a production environment, if you are using WCF trace sources, set the `switchValue` to Warning. If you are using the WCF `System.ServiceModel` trace source, set the `switchValue` attribute to `Warning` and the `propagateActivity` attribute to `true`. If you are using a user-defined trace source, set the `switchValue` attribute to `Warning, ActivityTracing`. This can be done manually using the [Configuration Editor Tool (SvcConfigEditor.exe)](../../configuration-editor-tool-svcconfigeditor-exe.md). If you do not anticipate a hit in performance, you can set the `switchValue` attribute to `Information` in all the previously mentioned cases, which generates a fairly large amount of trace data. The following example demonstrates these recommended settings.  
  
```xml  
<configuration>  
 <system.diagnostics>  
  <sources>  
    <source name="System.ServiceModel"  
            switchValue="Warning"  
            propagateActivity="true" >  
      <listeners>  
        <add name="xml"/>  
      </listeners>  
    </source>  
    <source name="myUserTraceSource"  
            switchValue="Warning, ActivityTracing">  
      <listeners>  
        <add name="xml"/>  
      </listeners>  
    </source>  
  </sources>  
  <sharedListeners>  
    <add name="xml"  
         type="System.Diagnostics.XmlWriterTraceListener"  
               initializeData="C:\logs\Traces.svclog" />  
  </sharedListeners>  
 </system.diagnostics>  
  
<system.serviceModel>  
  <diagnostics wmiProviderEnabled="true">  
  </diagnostics>  
 </system.serviceModel>  
</configuration>  
```  
  
## Recommended Settings for Deployment or Debugging  

 For deployment or debugging environment, choose `Information` or `Verbose`, along with `ActivityTracing` for either a user-defined or `System.ServiceModel` trace source. To enhance debugging, you should also add an additional trace source (`System.ServiceModel.MessageLogging`) to the configuration to enable message logging. Notice that the `switchValue` attribute has no impact on this trace source.  
  
 The following example demonstrates the recommended settings, using a shared listener that utilizes the `XmlWriterTraceListener`.  
  
```xml  
<configuration>  
 <system.diagnostics>  
  <sources>  
    <source name="System.ServiceModel"  
            switchValue="Information, ActivityTracing"  
            propagateActivity="true" >  
      <listeners>  
        <add name="xml"/>  
      </listeners>  
    </source>  
    <source name="System.ServiceModel.MessageLogging">  
      <listeners>  
        <add name="xml"/>  
      </listeners>  
    </source>  
    <source name="myUserTraceSource"  
            switchValue="Information, ActivityTracing">  
      <listeners>  
        <add name="xml"/>  
      </listeners>  
    </source>  
  </sources>  
  <sharedListeners>  
    <add name="xml"  
         type="System.Diagnostics.XmlWriterTraceListener"  
               initializeData="C:\logs\Traces.svclog" />  
  </sharedListeners>  
 </system.diagnostics>  
  
 <system.serviceModel>  
  <diagnostics wmiProviderEnabled="true">  
      <messageLogging
           logEntireMessage="true"
           logMalformedMessages="true"  
           logMessagesAtServiceLevel="true"
           logMessagesAtTransportLevel="true"  
           maxMessagesToLog="3000"
       />  
  </diagnostics>  
 </system.serviceModel>  
</configuration>  
```  
  
## Using WMI to Modify Settings  

 You can use WMI to change configuration settings at run time (by enabling the `wmiProviderEnabled` attribute in the configuration, as demonstrated in the previously configuration example). For example, you can use WMI within the CIM Studio to change the trace source levels from Warning to Information at run time. You should be aware that the performance cost of live debugging in this way can be very high. For more information about using WMI, see the [Using Windows Management Instrumentation for Diagnostics](../wmi/index.md) topic.  
  
## Enable Correlated Events in ASP.NET Tracing  

 ASP.NET events do not set the correlation ID (ActivityID) unless ASP.NET event tracing is turned on. To see correlated events properly, you have to turn on ASP.NET events tracing using the following command in the command console, which can be invoked by going to **Start**, **Run** and type **cmd**,  
  
```console  
logman start mytrace -pf logman.providers -o test.etl –ets  
```  
  
 To turn off tracing of ASP.NET events, use the following command,  
  
```console
logman stop mytrace -ets  
```  
  
## See also

- [Using Windows Management Instrumentation for Diagnostics](../wmi/index.md)
