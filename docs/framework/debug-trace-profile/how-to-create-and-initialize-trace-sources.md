---
title: "How to: Create and Initialize Trace Sources"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "trace sources"
  - "initializing trace sources"
  - "configuration files [.NET Framework], trace sources"
ms.assetid: f88dda6f-5fda-45be-9b3c-745a9b708c4d
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create and Initialize Trace Sources
The <xref:System.Diagnostics.TraceSource> class is used by applications to produce traces that can be associated with the application. <xref:System.Diagnostics.TraceSource> provides tracing methods that allow you to easily trace events, trace data, and issue informational traces. Trace output from <xref:System.Diagnostics.TraceSource> can be created and initialized with or without the use of configuration files. This topic provides instructions for both options. However, we recommend that you use configuration files to facilitate the reconfiguration of the traces produced by trace sources at run time.  
  
### To create and initialize a trace source using a configuration file  
  
1.  Create a Visual Studio console application project and replace the supplied code with the following code. This code logs errors and warnings and outputs some of them to the console, and some of them to the myListener file that is created by the entries in the configuration file.  
  
     [!code-csharp[TraceSourceExample1#1](../../../samples/snippets/csharp/VS_Snippets_CLR/tracesourceexample1/cs/program.cs#1)]
     [!code-vb[TraceSourceExample1#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/tracesourceexample1/vb/program.vb#1)]  
  
2.  Add an application configuration file, if one is not present, to the project to initialize the trace source named `TraceSourceApp` in the code example in step 1.  
  
3.  Replace the default configuration file content with the following settings to initialize a console trace listener and a text writer trace listener for the trace source that was created in step 1.  
  
    ```xml  
    <configuration>  
      <system.diagnostics>  
        <sources>  
          <source name="TraceSourceApp"   
            switchName="sourceSwitch"   
            switchType="System.Diagnostics.SourceSwitch">  
            <listeners>  
              <add name="console"   
                type="System.Diagnostics.ConsoleTraceListener">  
                <filter type="System.Diagnostics.EventTypeFilter"   
                  initializeData="Error"/>  
              </add>  
              <add name="myListener"/>  
              <remove name="Default"/>  
            </listeners>  
          </source>  
        </sources>  
        <switches>  
          <add name="sourceSwitch" value="Error"/>  
        </switches>  
        <sharedListeners>  
          <add name="myListener"   
            type="System.Diagnostics.TextWriterTraceListener"   
            initializeData="myListener.log">  
            <filter type="System.Diagnostics.EventTypeFilter"   
              initializeData="Error"/>  
          </add>  
        </sharedListeners>  
      </system.diagnostics>  
    </configuration>  
    ```  
  
     In addition to configuring the trace listeners, the configuration file creates filters for both listeners and creates a source switch for the trace source. Two techniques are shown for adding trace listeners: adding the listener directly to the trace source and adding a listener to the shared listeners collection and then adding it by name to the trace source. The filters identified for the two listeners are initialized with different source levels. This results in some messages being written by only one of the two listeners.  
  
     The configuration file initializes the settings for the trace source at the time the application is initialized. The application can dynamically change the properties set by the configuration file to override any settings specified by the user. For example, you might want to ensure that critical messages are always sent to a text file, regardless of the current configuration settings. The example code demonstrates how to override configuration file settings to ensure that critical messages are output to the trace listeners.  
  
     Changing the configuration file settings while the application is executing does not change the initial settings. To change the settings, you must either restart the application or programmatically refresh the application by using the <xref:System.Diagnostics.Trace.Refresh%2A?displayProperty=nameWithType> method.  
  
### To initialize trace sources, listeners, and filters without a configuration file  
  
-   Use the following example code to enable tracing through a trace source without using a configuration file. This is not a recommended practice, but there may be circumstances in which you do not want to depend on configuration files to ensure tracing.  
  
     [!code-csharp[TraceSourceExample2#1](../../../samples/snippets/csharp/VS_Snippets_CLR/tracesourceexample2/cs/program.cs#1)]
     [!code-vb[TraceSourceExample2#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/tracesourceexample2/vb/program.vb#1)]  
  
## See Also  
 <xref:System.Diagnostics.TraceSource>  
 <xref:System.Diagnostics.TextWriterTraceListener>  
 <xref:System.Diagnostics.ConsoleTraceListener>  
 <xref:System.Diagnostics.EventTypeFilter>  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)
