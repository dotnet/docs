---
title: "How to: Create, Initialize and Configure Trace Switches"
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
  - "trace switches, configuring"
  - "tracing [.NET Framework], trace switches"
  - "switches, trace"
  - "tracing [.NET Framework], enabling or disabling"
  - "Web.config configuration file, trace switches"
ms.assetid: 5a0e41bf-f99c-4692-8799-f89617f5bcf9
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Create, Initialize and Configure Trace Switches
Trace switches enable you to enable, disable, and filter tracing output.  
  
<a name="create"></a>   
## Creating and initializing a trace switch  
 In order to use trace switches, you must first create them and place them in your code. There are two predefined classes from which you can create switch objects: the <xref:System.Diagnostics.BooleanSwitch?displayProperty=nameWithType> class and the <xref:System.Diagnostics.TraceSwitch?displayProperty=nameWithType> class. You would use <xref:System.Diagnostics.BooleanSwitch> if you care only about whether or not a tracing message appears; you would use <xref:System.Diagnostics.TraceSwitch> if you want to discriminate between levels of tracing. If you use a <xref:System.Diagnostics.TraceSwitch>, you can define your own debugging messages and associate them with different trace levels. You can use both types of switches with either tracing or debugging. By default, a <xref:System.Diagnostics.BooleanSwitch> is disabled and a <xref:System.Diagnostics.TraceSwitch> is set to level <xref:System.Diagnostics.TraceLevel.Off?displayProperty=nameWithType>. Trace switches can be created and placed in any part of your code that might use them.  
  
 Although you can set trace levels and other configuration options in code, we recommend that you use the configuration file to manage the state of your switches. This is because managing the configuration of your switches in the configuration system gives you greater flexibility — you can turn on and off various switches and change levels without recompiling your application.  
  
#### To create and initialize a trace switch  
  
1.  Define a switch as either type <xref:System.Diagnostics.BooleanSwitch?displayProperty=nameWithType> or type <xref:System.Diagnostics.TraceSwitch?displayProperty=nameWithType> and set the name and description of the switch.  
  
2.  Configure your trace switch. For more information, see [Configuring trace switches](#configure).  
  
     The following code creates two switches, one of each type:  
  
    ```vb  
    Dim dataSwitch As New BooleanSwitch("Data", "DataAccess module")  
    Dim generalSwitch As New TraceSwitch("General", "Entire application")  
    ```  
  
    ```csharp  
    System.Diagnostics.BooleanSwitch dataSwitch =   
       new System.Diagnostics.BooleanSwitch("Data", "DataAccess module");  
    System.Diagnostics.TraceSwitch generalSwitch =   
       new System.Diagnostics.TraceSwitch("General",   
       "Entire application");  
    ```  
  
<a name="configure"></a>   
## Configuring trace switches  
 After your application has been distributed, you can still enable or disable trace output by configuring the trace switches in your application. Configuring a switch means changing its value from an external source after it has been initialized. You can change the values of the switch objects using the configuration file. You configure a trace switch to turn it on and off, or to set its level, determining the amount and type of messages it passes along to listeners.  
  
 Your switches are configured using the .config file. For a Web application, this is the Web.config file associated with the project. In a Windows application, this file is named (application name).exe.config. In a deployed application, this file must reside in the same folder as the executable.  
  
 When your application executes the code that creates an instance of a switch for the first time, it checks the configuration file for trace-level information about the named switch. The tracing system examines the configuration file only once for any particular switch — the first time your application creates the switch.  
  
 In a deployed application, you enable trace code by reconfiguring switch objects when your application is not running. Typically this involves turning the switch objects on and off or by changing the tracing levels, and then restarting your application.  
  
 When you create an instance of a switch, you also initialize it by specifying two arguments: a *displayName* argument and a *description* argument. The *displayName* argument of the constructor sets the <xref:System.Diagnostics.Switch.DisplayName%2A?displayProperty=nameWithType> property of the <xref:System.Diagnostics.Switch> class instance. The *displayName* is the name that is used to configure the switch in the .config file, and the *description* argument should return a brief description of the switch and what messages it controls.  
  
 In addition to specifying the name of a switch to configure, you must also specify a value for the switch. This value is an Integer. For <xref:System.Diagnostics.BooleanSwitch>, a value of 0 corresponds to **Off**, and any nonzero value corresponds to **On**. For <xref:System.Diagnostics.TraceSwitch>, 0,1,2,3, and 4 correspond **Off**, **Error**, **Warning**, **Info**, and **Verbose**, respectively. Any number greater than 4 is treated as **Verbose**, and any number less than zero is treated as **Off**.  
  
> [!NOTE]
>  In the .NET Framework version 2.0, you can use text to specify the value for a switch. For example, `true` for a <xref:System.Diagnostics.BooleanSwitch> or the text representing an enumeration value such as `Error` for a <xref:System.Diagnostics.TraceSwitch>. The line `<add name="myTraceSwitch" value="Error" />` is equivalent to `<add name="myTraceSwitch" value="1" />`.  
  
 In order for end users to be able to configure an application's trace switches, you must provide detailed documentation on the switches in your application. You should detail which switches control what and how to turn them on and off. You should also provide your end user with a .config file that has appropriate Help in the comments.  
  
#### To configure trace switches  
  
1.  In order to use trace switches, you must first create them and place them in your code as described in the section [Creating and initializing a trace switch](#create).  
  
2.  If your project does not contain a configuration file (app.config or Web.config), then from the **Project** menu, select **Add New Item**.  
  
    -   **Visual Basic:** In the **Add New Item** dialog box, choose **Application Configuration File**.  
  
         The application configuration file is created and opened. This is an XML document whose root element is `<configuration>.`  
  
    -   **Visual C#:** In the **Add New Item** dialog box, choose **XML File**. Name this file **app.config**. In the XML editor, after the XML declaration, add the following XML:  
  
        ```xml  
        <configuration>  
        </configuration>  
        ```  
  
         When your project is compiled, the app.config file is copied to the project output folder and is renamed *applicationname*.exe.config.  
  
3.  After the `<configuration>` tag but before the `</configuration>` tag, add the appropriate XML to configure your switches. The following examples demonstrate a **BooleanSwitch** with a **DisplayName** property of `DataMessageSwitch` and a **TraceSwitch** with a **DisplayName** property of `TraceLevelSwitch`.  
  
    ```xml  
    <system.diagnostics>  
       <switches>  
          <add name="DataMessagesSwitch" value="0" />  
          <add name="TraceLevelSwitch" value="0" />  
       </switches>  
    </system.diagnostics>  
    ```  
  
     In this configuration, both switches are off.  
  
4.  If you need to turn on a **BooleanSwitch**, such as `DataMessagesSwitch` shown in the previous example, change the **Value** to any integer other than 0.  
  
5.  If you need to turn on a **TraceSwitch**, such as `TraceLevelSwitch` shown in the previous example, change the **Value** to the appropriate level setting (1 to 4).  
  
6.  Add comments to the .config file so the end user has a clear understanding of what values to change to configure the switches appropriately.  
  
     The following example shows how the final code, including comments, might look:  
  
    ```xml  
    <system.diagnostics>  
       <switches>  
          <!-- This switch controls data messages. In order to receive data   
             trace messages, change value="0" to value="1" -->  
          <add name="DataMessagesSwitch" value="0" />  
          <!-- This switch controls general messages. In order to   
             receive general trace messages change the value to the   
             appropriate level. "1" gives error messages, "2" gives errors   
             and warnings, "3" gives more detailed error information, and   
             "4" gives verbose trace information -->  
          <add name="TraceLevelSwitch" value="0" />  
       </switches>  
    </system.diagnostics>  
    ```  
  
## See Also  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)  
 [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md)  
 [Trace Switches](../../../docs/framework/debug-trace-profile/trace-switches.md)  
 [Trace and Debug Settings Schema](../../../docs/framework/configure-apps/file-schema/trace-debug/index.md)
