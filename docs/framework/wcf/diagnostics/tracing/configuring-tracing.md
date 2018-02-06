---
title: "Configuring Tracing"
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
  - "tracing [WCF]"
ms.assetid: 82922010-e8b3-40eb-98c4-10fc05c6d65d
caps.latest.revision: 53
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Configuring Tracing
This topic describes how you can enable tracing, configure trace sources to emit traces and set trace levels, set activity tracing and propagation to support end-to-end trace correlation, and set trace listeners to access traces.  
  
 For tracing settings recommendations in production or debugging environment, refer to [Recommended Settings for Tracing and Message Logging](../../../../../docs/framework/wcf/diagnostics/tracing/recommended-settings-for-tracing-and-message-logging.md).  
  
> [!IMPORTANT]
>  On Windows 8 you must run your application elevated (Run as Administrator) in order for your application to generate trace logs.  
  
## Enabling Tracing  
 [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] outputs the following data for diagnostic tracing:  
  
-   Traces for process milestones across all components of the applications, such as operation calls, code exceptions, warnings and other significant processing events.  
  
-   Windows error events when the tracing feature malfunctions. See [Event Logging](../../../../../docs/framework/wcf/diagnostics/event-logging/index.md).  
  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] tracing is built on top of <xref:System.Diagnostics>. To use tracing, you should define trace sources in the configuration file or in code. [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] defines a trace source for each [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] assembly. The `System.ServiceModel` trace source is the most general [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] trace source, and records processing milestones across the [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] communication stack, from entering/leaving transport to entering/leaving user code. The `System.ServiceModel.MessageLogging` trace source records all messages that flow through the system.  
  
 Tracing is not enabled by default. To activate tracing, you must create a trace listener and set a trace level other than "Off" for the selected trace source in configuration; otherwise, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] does not generate any traces. If you do not specify a listener, tracing is automatically disabled. If a listener is defined, but no level is specified, the level is set to "Off" by default, which means that no trace is emitted.  
  
 If you use [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] extensibility points such as custom operation invokers, you should emit your own traces. This is because if you implement an extensibility point, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] can no longer emit the standard traces in the default path. If you do not implement manual tracing support by emitting traces, you may not see the traces you expect.  
  
 You can configure tracing by editing the application’s configuration file—either Web.config for Web-hosted applications, or Appname.exe.config for self-hosted applications. The following is an example of such edit. For more information on these settings, see the "Configuring Trace Listeners to Consume Traces" section.  
  
```xml  
<configuration>  
   <system.diagnostics>  
      <sources>  
            <source name="System.ServiceModel"   
                    switchValue="Information, ActivityTracing"  
                    propagateActivity="true">  
            <listeners>  
               <add name="traceListener"   
                   type="System.Diagnostics.XmlWriterTraceListener"   
                   initializeData= "c:\log\Traces.svclog" />  
            </listeners>  
         </source>  
      </sources>  
   </system.diagnostics>  
</configuration>  
```  
  
> [!NOTE]
>  To edit the configuration file of a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service project in [!INCLUDE[vs_current_short](../../../../../includes/vs-current-short-md.md)], right click the application’s configuration file—either Web.config for Web-hosted applications, or Appname.exe.config for self-hosted application in **Solution Explorer**. Then choose the **Edit WCF Configuration** context menu item. This launches the [Configuration Editor Tool (SvcConfigEditor.exe)](../../../../../docs/framework/wcf/configuration-editor-tool-svcconfigeditor-exe.md), which enables you to modify configuration settings for [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] services using a graphical user interface.  
  
## Configuring Trace Sources to Emit Traces  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] defines a trace source for each assembly. Traces generated within an assembly are accessed by the listeners defined for that source. The following trace sources are defined:  
  
-   System.ServiceModel: Logs all stages of [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] processing, whenever configuration is read, a message is processed in transport, security processing, a message is dispatched in user code, and so on.  
  
-   System.ServiceModel.MessageLogging: Logs all messages that flow through the system.  
  
-   System.IdentityModel.  
  
-   System.ServiceModel.Activation.  
  
-   System.IO.Log: Logging for the .NET Framework interface to the Common Log File System (CLFS).  
  
-   System.Runtime.Serialization: Logs when objects are read or written.  
  
-   CardSpace.  
  
 You can configure each trace source to use the same (shared) listener, as indicated in the following configuration example.  
  
```xml  
<configuration>  
    <system.diagnostics>  
        <sources>  
            <source name="System.ServiceModel"   
                    switchValue="Information, ActivityTracing"  
                    propagateActivity="true">  
                <listeners>  
                    <add name="xml" />  
                </listeners>  
            </source>  
            <source name="CardSpace">  
                <listeners>  
                    <add name="xml" />  
                </listeners>  
            </source>  
            <source name="System.IO.Log">  
                <listeners>  
                    <add name="xml" />  
                </listeners>  
            </source>  
            <source name="System.Runtime.Serialization">  
                <listeners>  
                    <add name="xml" />  
                </listeners>  
            </source>  
            <source name="System.IdentityModel">  
                <listeners>  
                    <add name="xml" />  
                </listeners>  
            </source>  
        </sources>  
  
        <sharedListeners>  
            <add name="xml"  
                 type="System.Diagnostics.XmlWriterTraceListener"  
                 initializeData="c:\log\Traces.svclog" />  
        </sharedListeners>  
    </system.diagnostics>  
</configuration>  
```  
  
 In addition, you can add user-defined trace sources, as demonstrated by the following example, to emit user code traces.  
  
```xml  
<system.diagnostics>  
   <sources>  
       <source name="UserTraceSource" switchValue="Warning, ActivityTracing" >  
          <listeners>  
              <add name="xml"  
                 type="System.Diagnostics.XmlWriterTraceListener"  
                 initializeData="C:\logs\UserTraces.svclog" />  
          </listeners>  
       </source>  
   </sources>  
   <trace autoflush="true" />   
</system.diagnostics>  
```  
  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] creating user-defined trace sources, see [Extending Tracing](../../../../../docs/framework/wcf/samples/extending-tracing.md).  
  
## Configuring Trace Listeners to Consume Traces  
 At runtime, [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] feeds trace data to the listeners which process the data. [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] provides several predefined listeners for <xref:System.Diagnostics>, which differ in the format they use for output. You can also add custom listener types.  
  
 You can use `add` to specify the name and type of the trace listener you want to use. In our example configuration, we named the Listener `traceListener` and added the standard .NET Framework trace listener (`System.Diagnostics.XmlWriterTraceListener`) as the type we want to use. You can add any number of trace listeners for each source. If the trace listener emits the trace to a file, you must specify the output file location and name in the configuration file. This is done by setting `initializeData` to the name of the file for that listener. If you do not specify a file name, a random file name is generated based on the listener type used. If <xref:System.Diagnostics.XmlWriterTraceListener> is used, a file name with no extension is generated. If you implement a custom listener, you can also use this attribute to receive initialization data other than a filename. For example, you can specify a database identifier for this attribute.  
  
 You can configure a custom trace listener to send traces on the wire, for example, to a remote database. As an application deployer, you should enforce proper access control on the trace logs in the remote machine.  
  
 You can also configure a trace listener programmatically. [!INCLUDE[crdefault](../../../../../includes/crdefault-md.md)] [How to: Create and Initialize Trace Listeners](http://go.microsoft.com/fwlink/?LinkId=94648) and [Creating a Custom TraceListener](http://go.microsoft.com/fwlink/?LinkId=96239).  
  
> [!CAUTION]
>  Because `System.Diagnostics.XmlWriterTraceListener` is not thread-safe, the trace source may lock resources exclusively when outputting traces. When many threads output traces to a trace source configured to use this listener, resource contention may occur, which results in a significant performance issue. To resolve this problem, you should implement a custom listener that is thread-safe.  
  
## Trace Level  
 The tracing level is controlled by the `switchValue` setting of the trace source. The available tracing levels are described in the following table.  
  
|Trace Level|Nature of the Tracked Events|Content of the Tracked Events|Tracked Events|User Target|  
|-----------------|----------------------------------|-----------------------------------|--------------------|-----------------|  
|Off|N/A|N/A|No traces are emitted.|N/A|  
|Critical|"Negative" events: events that indicate an unexpected processing or an error condition.||Unhandled exceptions including the following are logged:<br /><br /> -   OutOfMemoryException<br />-   ThreadAbortException (the CLR invokes any ThreadAbortExceptionHandler)<br />-   StackOverflowException (cannot be caught)<br />-   ConfigurationErrorsException<br />-   SEHException<br />-   Application start errors<br />-   Failfast events<br />-   System hangs<br />-   Poison messages: message traces that cause the application to fail.|Administrators<br /><br /> Application developers|  
|Error|"Negative" events: events that indicate an unexpected processing or an error condition.|Unexpected processing has happened. The application was not able to perform a task as expected. However, the application is still up and running.|All exceptions are logged.|Administrators<br /><br /> Application developers|  
|Warning|"Negative" events: events that indicate an unexpected processing or an error condition.|A possible problem has occurred or may occur, but the application still functions correctly. However, it may not continue to work properly.|-   The application is receiving more requests than its throttling settings allow.<br />-   The receiving queue is near its maximum configured capacity.<br />-   Timeout has exceeded.<br />-   Credentials are rejected.|Administrators<br /><br /> Application developers|  
|Information|"Positive" events: events that mark successful milestones|Important and successful milestones of application execution, regardless of whether the application is working properly or not.|In general, messages helpful for monitoring and diagnosing system status, measuring performance or profiling are generated. You can use such information for capacity planning and performance management:<br /><br /> -   Channels are created.<br />-   Endpoint listeners are created.<br />-   Message enters/leaves transport.<br />-   Security token is retrieved.<br />-   Configuration setting is read.|Administrators<br /><br /> Application developers<br /><br /> Product developers.|  
|Verbose|"Positive" events: events that mark successful milestones.|Low level events for both user code and servicing are emitted.|In general, you can use this level for debugging or application optimization.<br /><br /> -   Understood message header.|Administrators<br /><br /> Application developers<br /><br /> Product developers.|  
|ActivityTracing||Flow events between processing activities and components.|This level allows administrators and developers to correlate applications in the same application domain:<br /><br /> -   Traces for activity boundaries, such as start/stop.<br />-   Traces for transfers.|All|  
|All||Application may function properly. All events are emitted.|All previous events.|All|  
  
 The levels from Verbose to Critical are stacked on top of each other, that is, each trace level includes all levels above it except the Off level. For example, a listener listening at the Warning level receives Critical, Error, and Warning traces. The All level includes events from Verbose to Critical and Activity tracing events.  
  
> [!CAUTION]
>  The Information, Verbose, and ActivityTracing levels generate a lot of traces, which may negatively impact message throughput if you have used up all available resources on the machine.  
  
## Configuring Activity Tracing and Propagation for Correlation  
 The `activityTracing` value specified for the `switchValue` attribute is used to enable activity tracing, which emits traces for activity boundaries and transfers within endpoints.  
  
> [!NOTE]
>  When you use certain extensibility features in [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)], you might get a <xref:System.NullReferenceException> when activity tracing is enabled. To fix this problem, check your application's configuration file and ensure that the `switchValue` attribute for your trace source is not set to `activityTracing`.  
  
 The `propagateActivity` attribute indicates whether the activity should be propagated to other endpoints that participate in the message exchange. By setting this value to `true`, you can take trace files generated by any two endpoints and observe how a set of traces on one endpoint flowed to a set of traces on another endpoint.  
  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] activity tracing and propagation, see [Propagation](../../../../../docs/framework/wcf/diagnostics/tracing/propagation.md).  
  
 Both `propagateActivity` and `ActivityTracing` Boolean values apply to the System.ServiceModel TraceSource. The `ActivityTracing` value also applies to any trace source, including [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] or user-defined ones.  
  
 You cannot use the `propagateActivity` attribute with user-defined trace sources. For user code activity ID propagation, make sure you do not set ServiceModel `ActivityTracing`, while still having ServiceModel `propagateActivity` attribute set to `true`.  
  
## See Also  
 [Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/index.md)  
 [Administration and Diagnostics](../../../../../docs/framework/wcf/diagnostics/index.md)  
 [How to: Create and Initialize Trace Listeners](http://go.microsoft.com/fwlink/?LinkId=94648)  
 [Creating a Custom TraceListener](http://go.microsoft.com/fwlink/?LinkId=96239)
