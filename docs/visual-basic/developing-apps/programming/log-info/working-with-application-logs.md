---
title: "Working with Application Logs in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "logs, application"
  - "application event logs, Visual Basic"
  - "application event logs"
ms.assetid: 2581afd1-5791-4bc4-86b2-46244e9fe468
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Working with Application Logs in Visual Basic
The `My.Applicaton.Log` and `My.Log` objects make it easy to write logging and tracing information to logs.  
  
## How Messages are Logged  
 First, the severity of the message is checked with the <xref:System.Diagnostics.TraceSource.Switch%2A> property of the log's <xref:Microsoft.VisualBasic.Logging.Log.TraceSource%2A> property. By default, only messages of severity "Information" and higher are passed on to the trace listeners, specified in the log's `TraceListener` collection. Then, each listener compares the severity of the message to the listener's <xref:System.Diagnostics.TraceSource.Switch%2A> property. If the message's severity is high enough, the listener writes out the message.  
  
 The following diagram shows how a message written to the `WriteEntry` method gets passed to the `WriteLine` methods of the log's trace listeners:  
  
 ![My Log Call](../../../../visual-basic/developing-apps/programming/log-info/media/mylogcall.png "MyLogCall")  
  
 You can change the behavior of the log and the trace listeners by changing the application's configuration file. The following diagram shows the correspondence between the parts of the log and the configuration file.  
  
 ![My Log Configuration](../../../../visual-basic/developing-apps/programming/log-info/media/mylogconfig.png "MyLogConfig")  
  
## Where Messages are Logged  
 If the assembly has no configuration file, the `My.Application.Log` and `My.Log` objects write to the application's debug output (through the <xref:System.Diagnostics.DefaultTraceListener> class). In addition, the `My.Application.Log` object writes to the assembly's log file (through the <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener> class), while the `My.Log` object writes to the ASP.NET Web page's output (through the <xref:System.Web.WebPageTraceListener> class).  
  
 The debug output can be viewed in the [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] **Output** window when running your application in debug mode. To open the **Output** window, click the **Debug** menu item, point to **Windows**, and then click **Output**. In the **Output** window, select **Debug** from the **Show output from** box.  
  
 By default, `My.Application.Log` writes the log file in the path for the user's application data. You can get the path from the <xref:Microsoft.VisualBasic.Logging.FileLogTraceListener.FullLogFileName%2A> property of the <xref:Microsoft.VisualBasic.Logging.Log.DefaultFileLogWriter%2A> object. The format of that path is as follows:  
  
 `BasePath`\\`CompanyName`\\`ProductName`\\`ProductVersion`  
  
 A typical value for `BasePath` is as follows.  
  
 C:\Documents and Settings\\`username`\Application Data  
  
 The values of `CompanyName`, `ProductName`, and `ProductVersion` come from the application's assembly information. The form of the log file name is *AssemblyName*.log, where *AssemblyName* is the file name of the assembly without the extension. If more than one log file is needed, such as when the original log is unavailable when the application attempts to write to the log, the form for the log file name is *AssemblyName*-*iteration*.log, where `iteration` is a positive `Integer`.  
  
 You can override the default behavior by adding or changing the computer's and the application's configuration files. For more information, see [Walkthrough: Changing Where My.Application.Log Writes Information](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-changing-where-my-application-log-writes-information.md).  
  
## Configuring Log Settings  
 The `Log` object has a default implementation that works without an application configuration file, app.config. To change the defaults, you must add a configuration file with the new settings. For more information, see [Walkthrough: Filtering My.Application.Log Output](../../../../visual-basic/developing-apps/programming/log-info/walkthrough-filtering-my-application-log-output.md).  
  
 The log configuration sections are located in the `<system.diagnostics>` node in the main `<configuration>` node of the app.config file. Log information is defined in several nodes:  
  
-   The listeners for the `Log` object are defined in the `<sources>` node named DefaultSource.  
  
-   The severity filter for the `Log` object is defined in the `<switches>` node named DefaultSwitch.  
  
-   The log listeners are defined in the `<sharedListeners>` node.  
  
 Examples of `<sources>`, `<switches>`, and `<sharedListeners>` nodes are shown in the following code:  
  
```xml  
<configuration>  
  <system.diagnostics>  
    <sources>  
      <source name="DefaultSource" switchName="DefaultSwitch">  
        <listeners>  
          <add name="FileLog"/>  
        </listeners>  
      </source>  
    </sources>  
    <switches>  
      <add name="DefaultSwitch" value="Information" />  
    </switches>  
    <sharedListeners>  
      <add name="FileLog"  
        type="Microsoft.VisualBasic.Logging.FileLogTraceListener,  
          Microsoft.VisualBasic, Version=8.0.0.0, Culture=neutral,   
          PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL"  
        initializeData="FileLogWriter"  
      />  
    </sharedListeners>  
  </system.diagnostics>  
</configuration>  
```  
  
## Changing Log Settings after Deployment  
 When you develop an application, its configuration settings are stored in the app.config file, as shown in the examples above. After you deploy your application, you can still configure the log by editing the configuration file. In a Windows-based application, this file's name is *applicationName*.exe.config, and it must reside in the same folder as the executable file. For a Web application, this is the Web.config file associated with the project.  
  
 When your application executes the code that creates an instance of a class for the first time, it checks the configuration file for information about the object. For the `Log` object, this happens the first time the `Log` object is accessed. The system examines the configuration file only once for any particular object—the first time your application creates the object. Therefore, you may need to restart the application for the changes to take effect.  
  
 In a deployed application, you enable trace code by reconfiguring switch objects before your application starts. Typically, this involves turning the switch objects on and off or by changing the tracing levels, and then restarting your application.  
  
## Security Considerations  
 Consider the following when writing data to the log:  
  
-   **Avoid leaking user information.** Ensure that your application writes only approved information to the log. For example, it may be acceptable for the application log to contain user names, but not user passwords.  
  
-   **Make log locations secure.** Any log that contains potentially sensitive information should be stored in a secure location.  
  
-   **Avoid misleading information.** In general, your application should validate all data entered by a user before using that data. This includes writing data to the application log.  
  
-   **Avoid denial of service.** If your application writes too much information to the log, it could fill the log or make finding important information difficult.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Logging.Log?displayProperty=nameWithType>  
 [Logging Information from the Application](../../../../visual-basic/developing-apps/programming/log-info/logging-information-from-the-application.md)
