---
title: "Tracing and Instrumenting Applications"
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
  - "tracing [.NET Framework]"
  - "debugging [.NET Framework], instrumentation"
  - "performance monitoring, instrumentation"
  - "instrumentation, about instrumentation"
  - "tracing [.NET Framework], about tracing"
  - "performance monitoring, tracing code"
  - "Trace class, instrumentation for .NET applications"
ms.assetid: 773b6fc4-9013-4322-b728-5dec7a72e743
caps.latest.revision: 21
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tracing and Instrumenting Applications
Tracing is a way for you to monitor the execution of your application while it is running. You can add tracing and debugging instrumentation to your .NET Framework application when you develop it, and you can use that instrumentation both while you are developing the application and after you have deployed it. You can use the <xref:System.Diagnostics.Trace?displayProperty=nameWithType>, <xref:System.Diagnostics.Debug?displayProperty=nameWithType>, and <xref:System.Diagnostics.TraceSource?displayProperty=nameWithType> classes to record information about errors and application execution in logs, text files, or other devices for later analysis.  
  
 The term *instrumentation* refers to an ability to monitor or measure the level of a product's performance and to diagnose errors. In programming, this means the ability of an application to incorporate:  
  
-   **Code tracing** - Receiving informative messages about the execution of an application at run time.  
  
-   **Debugging** - Tracking down and fixing programming errors in an application under development. For more information, see [Debugging](/visualstudio/debugger/debugging-in-visual-studio).  
  
-   **Performance counters** - Components that allow you to track the performance of your application. For more information, see [Performance Counters](../../../docs/framework/debug-trace-profile/performance-counters.md).  
  
-   **Event logs** - Components that allow you receive and track major events in the execution of your application. For more information, see the <xref:System.Diagnostics.EventLog> class.  
  
 Instrumenting your application by placing trace statements at strategic locations in your code is especially useful for distributed applications. By using trace statements you can instrument an application not only to display information when things go wrong, but also to monitor how well the application is performing.  
  
 The <xref:System.Diagnostics.TraceSource> class provides enhanced tracing features and can be used in place of the static methods of the older <xref:System.Diagnostics.Trace> and <xref:System.Diagnostics.Debug> tracing classes. The familiar <xref:System.Diagnostics.Trace> and <xref:System.Diagnostics.Debug> classes are still widely used, but the <xref:System.Diagnostics.TraceSource> class is recommended for new tracing commands, such as <xref:System.Diagnostics.TraceSource.TraceEvent%2A> and <xref:System.Diagnostics.TraceSource.TraceData%2A>.  
  
 The <xref:System.Diagnostics.Trace> and <xref:System.Diagnostics.Debug> classes are identical, except that procedures and functions of the <xref:System.Diagnostics.Trace> class are compiled by default into release builds, but those of the <xref:System.Diagnostics.Debug> class are not.  
  
 The <xref:System.Diagnostics.Trace> and <xref:System.Diagnostics.Debug> classes provide the means to monitor and examine application performance either during development or after deployment. For example, you can use the <xref:System.Diagnostics.Trace> class to track particular types of actions in a deployed application as they occur (for example, creation of new database connections), and can therefore monitor the application's efficiency.  
  
## Code Tracing and Debugging  
 During development, you can use the output methods of the <xref:System.Diagnostics.Debug> class to display messages in the Output window of the Visual Studio integrated development environment (IDE). For example:  
  
```vb  
Trace.WriteLine("Hello World!")  
Debug.WriteLine("Hello World!")  
```  
  
```csharp  
System.Diagnostics.Trace.WriteLine("Hello World!");  
System.Diagnostics.Debug.WriteLine("Hello World!");  
```  
  
 Each of these examples will display "Hello World!" in the Output window when the application is run in the debugger.  
  
 This enables you to debug your applications and optimize their performance based on their behavior in your test environment. You can debug your application in your debug build with the <xref:System.Diagnostics.Debug> conditional attribute turned on so that you receive all debugging output. When your application is ready for release, you can compile your release build without turning on the <xref:System.Diagnostics.Debug> conditional attribute, so that the compiler will not include your debugging code in the final executable. For more information, see [How to: Compile Conditionally with Trace and Debug](../../../docs/framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md). For more information on different build configurations for your application, see [Compiling and Building](/visualstudio/ide/compiling-and-building-in-visual-studio).  
  
 You can also trace code execution in an installed application, using methods of the <xref:System.Diagnostics.Trace> class. By placing [Trace Switches](../../../docs/framework/debug-trace-profile/trace-switches.md) in your code, you can control whether tracing occurs and how extensive it is. This lets you monitor the status of your application in a production environment. This is especially important in a business application that uses multiple components running on multiple computers. You can control how the switches are used after deployment through the configuration file. For more information, see [How to: Create, Initialize and Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md).  
  
 When you are developing an application for which you intend to use tracing, you usually include both tracing and debugging messages in the application code. When you are ready to deploy the application, you can compile your release build without turning on the **Debug** conditional attribute. However, you can turn on the **Trace** conditional attribute so that the compiler includes your trace code in the executable. For more information, see [How to: Compile Conditionally with Trace and Debug](../../../docs/framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md).  
  
### Phases of Code Tracing  
 There are three phases of code tracing:  
  
1.  **Instrumentation** — you add trace code to your application.  
  
2.  **Tracing** — the tracing code writes information to the specified target.  
  
3.  **Analysis** — you evaluate the tracing information to identify and understand problems in the application.  
  
 During development, all debug and trace output methods write information to the Output window in Visual Studio by default. In a deployed application, the methods write tracing information to the targets you specify. For more information on specifying an output target for tracing or debugging, see [Trace Listeners](../../../docs/framework/debug-trace-profile/trace-listeners.md).  
  
 The following is an overall view of the major steps typically involved in using tracing to analyze and correct potential problems in deployed applications. For more information on how to perform these steps, see the appropriate link.  
  
##### To use tracing in an application  
  
1.  Consider which tracing output you will want to receive onsite after you have deployed the application.  
  
2.  Create a set of switches. For more information, see [How to: Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md).  
  
3.  Add the trace statements to the application code.  
  
4.  Determine where you want the tracing output to appear and add the appropriate listeners. For more information, see [Creating and Initializing Trace Listeners](../../../docs/framework/debug-trace-profile/how-to-create-and-initialize-trace-listeners.md).  
  
5.  Test and debug your application and the tracing code it contains.  
  
6.  Compile the application into executable code using one of the following procedures:  
  
    -   Use the **Build** menu along with the **Debug** page of the **Property Pages** dialog box in **Solution Explorer**. Use this when compiling in Visual Studio.  
  
         \- or -  
  
    -   Use the **Trace** and **Debug** compiler directives for the command-line method of compiling. For more information, see [Compiling Conditionally with Trace and Debug](../../../docs/framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md). Use this when compiling from the command line.  
  
7.  If a problem occurs during run time, turn on the appropriate trace switch. For more information, see [Configuring Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md).  
  
     The tracing code writes tracing messages to a specified target, for example, a screen, a text file, or an event log. The type of listener you included in the **Trace.Listeners** collection determines the target.  
  
8.  Analyze the tracing messages to identify and understand the problem in the application.  
  
## Trace Instrumentation and Distributed Applications  
 When you create a distributed application, you might find it difficult to test the application in the manner in which it will be used. Few development teams have the capability to test all possible combinations of operating systems or Web browsers (including all the localized language options), or to simulate the high number of users that will access the application at the same time. Under these circumstances, you cannot test how a distributed application will respond to high volumes, different setups, and unique end-user behaviors. Also, many parts of a distributed application have no user interface with which you can interact directly or view the activity of those parts.  
  
 However, you can compensate for this by enabling distributed applications to describe certain events of interest to system administrators, especially things that go wrong, by *instrumenting* the application — that is, by placing trace statements at strategic locations in your code. Then if something unexpected occurs at run time (for example, excessively slow response time), you can determine the likely cause.  
  
 With trace statements you can avoid the difficult task of examining the original source code, modifying it, recompiling, and attempting to produce the run-time error within the debugging environment. Remember that you can instrument an application not only to display errors, but also to monitor performance.  
  
## Strategic Placement of Trace Statements  
 You must exercise special care when placing your trace statements for use during run time. You must consider what tracing information is likely to be needed in a deployed application, so that all likely tracing scenarios are adequately covered. Because applications that use tracing vary widely, however, there are no general guidelines for strategic placement of tracing. For more information on placing trace statements, see [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md).  
  
## Output from Tracing  
 Trace output is collected by objects called *listeners*. A listener is an object that receives trace output and writes it to an output device (usually a window, log, or text file). When a trace listener is created, it is typically added to the <xref:System.Diagnostics.Trace.Listeners%2A?displayProperty=nameWithType> collection, allowing the listener to receive all trace output.  
  
 Tracing information is always written at least to the default <xref:System.Diagnostics.Trace> output target, the <xref:System.Diagnostics.DefaultTraceListener>. If for some reason you have deleted the <xref:System.Diagnostics.DefaultTraceListener> without adding any other listeners to the <xref:System.Diagnostics.Trace.Listeners%2A> collection, you will not receive any tracing messages. For more information, see [Trace Listeners](../../../docs/framework/debug-trace-profile/trace-listeners.md).  
  
 The six <xref:System.Diagnostics.Debug> members and <xref:System.Diagnostics.Trace> methods that write tracing information are listed in the following table.  
  
|Method|Output|  
|------------|------------|  
|**Assert**|The specified text; or, if none is specified, the Call Stack. The output is written only if the condition specified as an argument in the **Assert** statement is **false**.|  
|**Fail**|The specified text; or, if none is specified, the Call Stack.|  
|**Write**|The specified text.|  
|**WriteIf**|The specified text, if the condition specified as an argument in the **WriteIf** statement is satisfied.|  
|**WriteLine**|The specified text and a carriage return.|  
|**WriteLineIf**|The specified text and a carriage return, if the condition specified as an argument in the **WriteLineIf** statement is satisfied.|  
  
 All listeners in the <xref:System.Diagnostics.Trace.Listeners%2A> collection receive the messages described in the above table, but the actions taken may vary depending on what kind of listener receives the message. For example, the <xref:System.Diagnostics.DefaultTraceListener> displays an assertion dialog box when it receives a **Fail** or failed **Assert** notification, but a <xref:System.Diagnostics.TextWriterTraceListener> simply writes the output to its stream.  
  
 You can produce custom results by implementing your own listener. A custom trace listener might, for example, display the messages to a message box, or connect to a database to add messages to a table. All custom listeners should support the six methods mentioned above. For more information on creating developer-defined listeners, see <xref:System.Diagnostics.TraceListener> in the .NET Framework reference.  
  
> [!NOTE]
>  In [!INCLUDE[vbprvblong](../../../includes/vbprvblong-md.md)], the **Debug.Write**, **Debug.WriteIf**, **Debug.WriteLine**, and **Debug.WriteLineIf** methods have replaced the **Debug.Print** method that was available in earlier versions of Visual Basic.  
  
 The **Write** and **WriteLine** methods always write the text that you specify. **Assert**, **WriteIf**, and **WriteLineIf** require a Boolean argument that controls whether or not they write the specified text; they write the specified text only if the expression is **true** (for **WriteIf** and **WriteLineIf**), or **false** (for **Assert**). The **Fail** method always writes the specified text. For more information, see [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md) and the .NET Framework reference.  
  
## Security Concerns  
 If you do not disable tracing and debugging before deploying an ASP.NET application, your application may reveal information about itself that could be exploited by a malicious program. For more information, see [How to: Compile Conditionally with Trace and Debug](../../../docs/framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md), [Compiling and Building](/visualstudio/ide/compiling-and-building-in-visual-studio), and [How to: Create, Initialize and Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md). Debugging is also configurable through Internet Information Services (IIS).  
  
## See Also  
 <xref:System.Diagnostics.Trace>  
 <xref:System.Diagnostics.TraceSource>  
 [Code Contracts](../../../docs/framework/debug-trace-profile/code-contracts.md)  
 [C#, F#, and Visual Basic Project Types](/visualstudio/debugger/debugging-preparation-csharp-f-hash-and-visual-basic-project-types)  
 [How to: Add Trace Statements to Application Code](../../../docs/framework/debug-trace-profile/how-to-add-trace-statements-to-application-code.md)  
 [How to: Compile Conditionally with Trace and Debug](../../../docs/framework/debug-trace-profile/how-to-compile-conditionally-with-trace-and-debug.md)  
 [How to: Create, Initialize and Configure Trace Switches](../../../docs/framework/debug-trace-profile/how-to-create-initialize-and-configure-trace-switches.md)  
 [How to: Create and Initialize Trace Sources](../../../docs/framework/debug-trace-profile/how-to-create-and-initialize-trace-sources.md)  
 [How to: Use TraceSource and Filters with Trace Listeners](../../../docs/framework/debug-trace-profile/how-to-use-tracesource-and-filters-with-trace-listeners.md)  
 [Trace Listeners](../../../docs/framework/debug-trace-profile/trace-listeners.md)  
 [Trace Switches](../../../docs/framework/debug-trace-profile/trace-switches.md)
