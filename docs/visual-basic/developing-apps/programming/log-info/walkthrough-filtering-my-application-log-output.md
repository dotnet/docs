---
title: "Filtering My.Application.Log Output (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "My.Log object, filtering output"
  - "My.Application.Log object, filtering output"
  - "application event logs, output filtering"
ms.assetid: 2c0a457a-38a4-49e1-934d-a51320b7b4ca
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Filtering My.Application.Log Output (Visual Basic)
This walkthrough demonstrates how to change the default log filtering for the `My.Application.Log` object, to control what information is passed from the `Log` object to the listeners and what information is written by the listeners. You can change the logging behavior even after building the application, because the configuration information is stored in the application's configuration file.  
  
## Getting Started  
 Each message that `My.Application.Log` writes has an associated severity level, which filtering mechanisms use to control the log output. This sample application uses `My.Application.Log` methods to write several log messages with different severity levels.  
  
#### To build the sample application  
  
1.  Open a new [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] Windows Application project.  
  
2.  Add a button named Button1 to Form1.  
  
3.  In the <xref:System.Windows.Forms.Control.Click> event handler for Button1, add the following code:  
  
     [!code-vb[VbVbcnMyApplicationLogFiltering#1](../../../../visual-basic/developing-apps/programming/log-info/codesnippet/VisualBasic/walkthrough-filtering-my-application-log-output_1.vb)]  
  
4.  Run the application in the debugger.  
  
5.  Press **Button1**.  
  
     The application writes the following information to the application's debug output and log file.  
  
     `DefaultSource Information: 0 : In Button1_Click`  
  
     `DefaultSource Error: 2 : Error in the application.`  
  
6.  Close the application.  
  
     For information on how to view the application's debug output window, see [Output Window](/visualstudio/ide/reference/output-window). For information on the location of the application's log file, see [Walkthrough: Determining Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-determining-where-my-application-log-writes-information.md).  
  
    > [!NOTE]
    >  By default, the application flushes the log-file output when the application closes.  
  
     In the example above, the second call to the <xref:Microsoft.VisualBasic.Logging.Log.WriteEntry%2A> method and the call to the <xref:Microsoft.VisualBasic.Logging.Log.WriteException%2A> method produces log output, while the first and last calls to the `WriteEntry` method do not. This is because the severity levels of `WriteEntry` and `WriteException` are "Information" and "Error", both of which are allowed by the `My.Application.Log` object's default log filtering. However, events with "Start" and "Stop" severity levels are prevented from producing log output.  
  
## Filtering for All My.Application.Log Listeners  
 The `My.Application.Log` object uses a <xref:System.Diagnostics.SourceSwitch> named `DefaultSwitch` to control which messages it passes from the `WriteEntry` and `WriteException` methods to the log listeners. You can configure `DefaultSwitch` in the application's configuration file by setting its value to one of the <xref:System.Diagnostics.SourceLevels> enumeration values. By default, its value is "Information".  
  
 This table shows the severity level required for Log to write a message to the listeners, given a particular `DefaultSwitch` setting.  
  
|DefaultSwitch Value|Message severity required for output|  
|---|---| 
|`Critical`|`Critical`|  
|`Error`|`Critical` or `Error`|  
|`Warning`|`Critical`, `Error`, or `Warning`|  
|`Information`|`Critical`, `Error`, `Warning`, or `Information`|  
|`Verbose`|`Critical`, `Error`, `Warning`, `Information`, or `Verbose`|  
|`ActivityTracing`|`Start`, `Stop`, `Suspend`, `Resume`, or `Transfer`|  
|`All`|All messages are allowed.|  
|`Off`|All messages are blocked.|  
  
> [!NOTE]
>  The `WriteEntry` and `WriteException` methods each have an overload that does not specify a severity level. The implicit severity level for the `WriteEntry` overload is "Information", and the implicit severity level for the `WriteException` overload is "Error".  
  
 This table explains the log output shown in the previous example: with the default `DefaultSwitch` setting of "Information", only the second call to the `WriteEntry` method and the call to the `WriteException` method produce log output.  
  
#### To log only activity tracing events  
  
1.  Right-click app.config in the **Solution Explorer** and select **Open**.  
  
     -or-  
  
     If there is no app.config file:  
  
    1.  On the **Project** menu, choose **Add New Item**.  
  
    2.  From the **Add New Item** dialog box, choose **Application Configuration File**.  
  
    3.  Click **Add**.  
  
2.  Locate the `<switches>` section, which is in the `<system.diagnostics>` section, which is in the top-level `<configuration>` section.  
  
3.  Find the element that adds `DefaultSwitch` to the collection of switches. It should look similar to this element:  
  
     `<add name="DefaultSwitch" value="Information" />`  
  
4.  Change the value of the `value` attribute to "ActivityTracing".  
  
5.  The content of the app.config file should be similar to the following XML:  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
      <system.diagnostics>  
        <sources>  
          <!-- This section configures My.Application.Log -->  
          <source name="DefaultSource" switchName="DefaultSwitch">  
            <listeners>  
              <add name="FileLog"/>  
            </listeners>  
          </source>  
        </sources>  
        <switches>  
          <add name="DefaultSwitch" value="ActivityTracing" />  
        </switches>  
        <sharedListeners>  
          <add name="FileLog"  
               type="Microsoft.VisualBasic.Logging.FileLogTraceListener,   
                     Microsoft.VisualBasic, Version=8.0.0.0,   
                     Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a,   
                     processorArchitecture=MSIL"   
               initializeData="FileLogWriter"/>  
        </sharedListeners>  
      </system.diagnostics>  
    </configuration>  
    ```  
  
6.  Run the application in the debugger.  
  
7.  Press **Button1**.  
  
     The application writes the following information to the application's debug output and log file:  
  
     `DefaultSource Start: 4 : Entering Button1_Click`  
  
     `DefaultSource Stop: 5 : Leaving Button1_Click`  
  
8.  Close the application.  
  
9. Change the value of the `value` attribute back to "Information".  
  
    > [!NOTE]
    >  The `DefaultSwitch` switch setting controls only `My.Application.Log`. It does not change how the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] <xref:System.Diagnostics.Trace?displayProperty=nameWithType> and <xref:System.Diagnostics.Debug?displayProperty=nameWithType> classes behave.  
  
## Individual Filtering For My.Application.Log Listeners  
 The previous example shows how to change the filtering for all `My.Application.Log` output. This example demonstrates how to filter an individual log listener. By default, an application has two listeners that write to the application's debug output and the log file.  
  
 The configuration file controls the behavior of the log listeners by allowing each one to have a filter, which is similar to a switch for `My.Application.Log`. A log listener will output a message only if the message's severity is allowed by both the log's `DefaultSwitch` and the log listener's filter.  
  
 This example demonstrates how to configure filtering for a new debug listener and add it to the `Log` object. The default debug listener should be removed from the `Log` object, so it is clear that the debug messages come from the new debug listener.  
  
#### To log only activity-tracing events  
  
1.  Right-click app.config in the **Solution Explorer** and choose **Open**.  
  
     -or-  
  
     If there is no app.config file:  
  
    1.  On the **Project** menu, choose **Add New Item**.  
  
    2.  From the **Add New Item** dialog box, choose **Application Configuration File**.  
  
    3.  Click **Add**.  
  
2.  Right-click app.config in **Solution Explorer**. Choose **Open**.  
  
3.  Locate the `<listeners>` section, in the `<source>` section with the `name` attribute "DefaultSource", which is under the `<sources>` section. The `<sources>` section is under the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
4.  Add this element to the `<listeners>` section:  
  
    ```xml  
    <!-- Remove the default debug listener. -->  
    <remove name="Default"/>  
    <!-- Add a filterable debug listener. -->  
    <add name="NewDefault"/>  
    ```  
  
5.  Locate the `<sharedListeners>` section, in the `<system.diagnostics>` section, in the top-level `<configuration>` section.  
  
6.  Add this element to that `<sharedListeners>` section:  
  
    ```xml  
    <add name="NewDefault"   
         type="System.Diagnostics.DefaultTraceListener,   
               System, Version=2.0.0.0, Culture=neutral,   
               PublicKeyToken=b77a5c561934e089,   
               processorArchitecture=MSIL">  
        <filter type="System.Diagnostics.EventTypeFilter"   
                initializeData="Error" />  
    </add>  
    ```  
  
     The <xref:System.Diagnostics.EventTypeFilter> filter takes one of the <xref:System.Diagnostics.SourceLevels> enumeration values as its `initializeData` attribute.  
  
7.  The content of the app.config file should be similar to the following XML:  
  
    ```xml  
    <?xml version="1.0" encoding="utf-8" ?>  
    <configuration>  
      <system.diagnostics>  
        <sources>  
          <!-- This section configures My.Application.Log -->  
          <source name="DefaultSource" switchName="DefaultSwitch">  
            <listeners>  
              <add name="FileLog"/>  
              <!-- Remove the default debug listener. -->  
              <remove name="Default"/>  
              <!-- Add a filterable debug listener. -->  
              <add name="NewDefault"/>  
            </listeners>  
          </source>  
        </sources>  
        <switches>  
          <add name="DefaultSwitch" value="Information" />  
        </switches>  
        <sharedListeners>  
          <add name="FileLog"  
               type="Microsoft.VisualBasic.Logging.FileLogTraceListener,   
                     Microsoft.VisualBasic, Version=8.0.0.0,   
                     Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a,   
                     processorArchitecture=MSIL"   
               initializeData="FileLogWriter"/>  
          <add name="NewDefault"   
               type="System.Diagnostics.DefaultTraceListener,   
                     System, Version=2.0.0.0, Culture=neutral,   
                     PublicKeyToken=b77a5c561934e089,   
                     processorArchitecture=MSIL">  
            <filter type="System.Diagnostics.EventTypeFilter"   
                    initializeData="Error" />  
          </add>  
        </sharedListeners>  
      </system.diagnostics>  
    </configuration>  
    ```  
  
8.  Run the application in the debugger.  
  
9. Press **Button1**.  
  
     The application writes the following information to the application's log file:  
  
     `Default Information: 0 : In Button1_Click`  
  
     `Default Error: 2 : Error in the application.`  
  
     The application writes less information to the application's debug output because of the more restrictive filtering.  
  
     `Default Error   2   Error`  
  
10. Close the application.  
  
 For more information about changing log settings after deployment, see [Working with Application Logs](../../../../visual-basic/developing-apps/programming/log-info/working-with-application-logs.md).  
  
## See Also  
 [Walkthrough: Determining Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-determining-where-my-application-log-writes-information.md)  
 [Walkthrough: Changing Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-changing-where-my-application-log-writes-information.md)  
 [Walkthrough: Creating Custom Log Listeners](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-creating-custom-log-listeners.md)  
 [How to: Write Log Messages](../../../../visual-basic/developing-apps/programming/log-info/how-to-write-log-messages.md)  
 [Trace Switches](../../../../framework/debug-trace-profile/trace-switches.md)  
 [Logging Information from the Application](../../../../visual-basic/developing-apps/programming/log-info/logging-information-from-the-application.md)
