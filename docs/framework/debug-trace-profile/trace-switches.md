---
title: "Trace Switches"
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
  - "tracing [.NET Framework], trace switches"
  - "trace switches, about trace switches"
  - "tracing [.NET Framework], level of detail"
  - "switches, trace"
  - "trace switches"
  - "trace switches, creating custom"
ms.assetid: 8ab913aa-f400-4406-9436-f45bc6e54fbe
caps.latest.revision: 16
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Trace Switches
Trace switches enable you to enable, disable, and filter tracing output. They are objects that exist in your code and can be configured externally through the .config file. There are three types of trace switches provided in the .NET Framework: the <xref:System.Diagnostics.BooleanSwitch> class, the <xref:System.Diagnostics.TraceSwitch> class, and the <xref:System.Diagnostics.SourceSwitch> class. The <xref:System.Diagnostics.BooleanSwitch> class acts as a toggle switch, either enabling or disabling a variety of trace statements. The <xref:System.Diagnostics.TraceSwitch> and <xref:System.Diagnostics.SourceSwitch> classes allow you to enable a trace switch for a particular tracing level so that the <xref:System.Diagnostics.Trace> or <xref:System.Diagnostics.TraceSource> messages specified for that level and all levels below it appear. If you disable the switch, the trace messages will not appear. All these classes derive from the abstract (**MustInherit**) class **Switch**, as should any user-developed switches.  
  
 Trace switches can be useful for filtering information. For example, you might want to see every tracing message in a data access module, but only error messages in the rest of the application. In that case, you would use one trace switch for the data access module and one switch for the rest of the application. By using the .config file to configure the switches to the appropriate settings, you could control what types of trace message you received. For more information, see [How to: Create, Initialize and Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md).  
  
 Typically, a deployed application is executed with its switches disabled, so that users need not observe a lot of irrelevant trace messages appearing on a screen or filling up a log file as the application runs. If a problem arises during application execution, you can stop the application, enable the switches, and restart the application. Then the tracing messages will be displayed.  
  
 To use a switch you must first create a switch object from a **BooleanSwitch** class, a **TraceSwitch** class, or a developer-defined switch class. For more information about creating developer-defined switches, see the <xref:System.Diagnostics.Switch> class in the .NET Framework reference. Then you set a configuration value that specifies when the switch object is to be used. You then test the setting of the switch object in various **Trace** (or **Debug**) tracing methods.  
  
## Trace Levels  
 When you use **TraceSwitch**, there are additional considerations. A **TraceSwitch** object has four properties that return **Boolean** values indicating whether the switch is set to at least a particular level:  
  
-   <xref:System.Diagnostics.TraceSwitch.TraceError%2A?displayProperty=nameWithType>  
  
-   <xref:System.Diagnostics.TraceSwitch.TraceWarning%2A?displayProperty=nameWithType>  
  
-   <xref:System.Diagnostics.TraceSwitch.TraceInfo%2A?displayProperty=nameWithType>  
  
-   <xref:System.Diagnostics.TraceSwitch.TraceVerbose%2A?displayProperty=nameWithType>  
  
 Levels allow you to limit the amount of tracing information you receive to only that information needed to solve a problem. You specify the level of detail you want in your tracing output by setting and configuring trace switches to the appropriate trace level. You can receive error messages, warning messages, informational messages, verbose tracing messages, or no message at all.  
  
 It is entirely up to you to decide what kind of message to associate with each level. Typically, the content of tracing messages depends on what you associate with each level, but you determine the differences between levels. You might want to provide detailed descriptions of a problem at level 3 (**Info**), for example, but provide only an error reference number at level 1 (**Error**). It is entirely up to you to decide what scheme works best in your application.  
  
 These properties correspond to the values 1 through 4 of the **TraceLevel** enumeration. The following table lists the levels of the **TraceLevel** enumeration and their values.  
  
|Enumerated value|Integer value|Type of message displayed (or written to a specified output target)|  
|----------------------|-------------------|---------------------------------------------------------------------------|  
|Off|0|None|  
|Error|1|Only error messages|  
|Warning|2|Warning messages and error messages|  
|Info|3|Informational messages, warning messages, and error messages|  
|Verbose|4|Verbose messages, informational messages, warning messages, and error messages|  
  
 The **TraceSwitch** properties indicate the maximum trace level for the switch. That is, tracing information is written for the level specified as well as for all lower levels. For example, if **TraceInfo** is **true**, then **TraceError** and **TraceWarning** are also **true** but **TraceVerbose** might well be **false**.  
  
 These properties are read-only. The **TraceSwitch** object automatically sets them when the **TraceLevel** property is set. For example:  
  
```vb  
Dim myTraceSwitch As New TraceSwitch("SwitchOne", "The first switch")  
myTraceSwitch.Level = TraceLevel.Info  
' This message box displays true, because setting the level to  
' TraceLevel.Info sets all lower levels to true as well.  
MessageBox.Show(myTraceSwitch.TraceWarning.ToString())  
' This messagebox displays false.  
MessageBox.Show(myTraceSwitch.TraceVerbose.ToString())  
```  
  
```csharp  
System.Diagnostics.TraceSwitch myTraceSwitch =   
   new System.Diagnostics.TraceSwitch("SwitchOne", "The first switch");  
myTraceSwitch.Level = System.Diagnostics.TraceLevel.Info;  
// This message box displays true, because setting the level to   
// TraceLevel.Info sets all lower levels to true as well.  
MessageBox.Show(myTraceSwitch.TraceWarning.ToString());  
// This message box displays false.  
MessageBox.Show(myTraceSwitch.TraceVerbose.ToString());  
```  
  
## Developer-Defined Switches  
 In addition to providing **BooleanSwitch** and **TraceSwitch**, you can define your own switches by inheriting from the **Switch** class and overriding the base class methods with customized methods. For more information about creating developer-defined switches, see the <xref:System.Diagnostics.Switch> class in the .NET Framework reference.  
  
## See Also  
 [Trace Listeners](../../../docs/framework/debug-trace-profile/trace-listeners.md)  
 [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md)  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)
