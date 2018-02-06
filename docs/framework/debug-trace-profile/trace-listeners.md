---
title: "Trace Listeners"
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
  - "Listener object types"
  - "listeners"
  - "Trace class, listeners"
  - "trace listeners, about trace listeners"
  - "Listeners collection"
  - "trace listeners"
  - "tracing [.NET Framework], trace listeners"
  - "logs, trace listeners"
ms.assetid: 444b0d33-67ea-4c36-9e94-79c50f839025
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Trace Listeners
When using **Trace**, **Debug** and <xref:System.Diagnostics.TraceSource>, you must have a mechanism for collecting and recording the messages that are sent. Trace messages are received by *listeners*. The purpose of a listener is to collect, store, and route tracing messages. Listeners direct the tracing output to an appropriate target, such as a log, window, or text file.  
  
 Listeners are available to the **Debug**, **Trace**, and <xref:System.Diagnostics.TraceSource> classes, each of which can send its output to a variety of listener objects. The following are the commonly used predefined listeners:  
  
-   A <xref:System.Diagnostics.TextWriterTraceListener> redirects output to an instance of the <xref:System.IO.TextWriter> class or to anything that is a <xref:System.IO.Stream> class. It can also write to the console or to a file, because these are <xref:System.IO.Stream> classes.  
  
-   An <xref:System.Diagnostics.EventLogTraceListener> redirects output to an event log.  
  
-   A <xref:System.Diagnostics.DefaultTraceListener> emits **Write** and **WriteLine** messages to the **OutputDebugString** and to the **Debugger.Log** method. In Visual Studio, this causes the debugging messages to appear in the Output window. **Fail** and failed **Assert** messages also emit to the **OutputDebugString** Windows API and the **Debugger.Log** method, and also cause a message box to be displayed. This behavior is the default behavior for **Debug** and **Trace** messages, because **DefaultTraceListener** is automatically included in every `Listeners` collection and is the only listener automatically included.  
  
-   A <xref:System.Diagnostics.ConsoleTraceListener> directs tracing or debugging output to either the standard output or the standard error stream.  
  
-   A <xref:System.Diagnostics.DelimitedListTraceListener> directs tracing or debugging output to a text writer, such as a stream writer, or to a stream, such as a file stream. The trace output is in a delimited text format that uses the delimiter specified by the <xref:System.Diagnostics.DelimitedListTraceListener.Delimiter%2A> property.  
  
-   An <xref:System.Diagnostics.XmlWriterTraceListener> directs tracing or debugging output as XML-encoded data to a <xref:System.IO.TextWriter> or to a <xref:System.IO.Stream>, such as a <xref:System.IO.FileStream>.  
  
 If you want any listener besides the <xref:System.Diagnostics.DefaultTraceListener> to receive **Debug**, **Trace** and <xref:System.Diagnostics.TraceSource> output, you must add it to the `Listeners` collection. For more information, see [How to: Create and Initialize Trace Listeners](../../../docs/framework/debug-trace-profile/how-to-create-and-initialize-trace-listeners.md) and [How to: Use TraceSource and Filters with Trace Listeners](../../../docs/framework/debug-trace-profile/how-to-use-tracesource-and-filters-with-trace-listeners.md). Any listener in the **Listeners** collection gets the same messages from the trace output methods. For example, suppose you set up two listeners: a **TextWriterTraceListener** and an **EventLogTraceListener**. Each listener receives the same message. The **TextWriterTraceListener** would direct its output to a stream, and the **EventLogTraceListener** would direct its output to an event log.  
  
 The following example shows how to send output to the **Listeners** collection.  
  
```vb  
' Use this example when debugging.  
Debug.WriteLine("Error in Widget 42")  
' Use this example when tracing.  
Trace.WriteLine("Error in Widget 42")  
```  
  
```csharp  
// Use this example when debugging.  
System.Diagnostics.Debug.WriteLine("Error in Widget 42");  
// Use this example when tracing.  
System.Diagnostics.Trace.WriteLine("Error in Widget 42");  
```  
  
 Debug and trace share the same **Listeners** collection, so if you add a listener object to a **Debug.Listeners** collection in your application, it gets added to the **Trace.Listeners** collection as well.  
  
 The following example shows how to use a listener to send tracing information to a console:  
  
```vb  
Trace.Listeners.Clear()  
Trace.Listeners.Add(New TextWriterTraceListener(Console.Out))  
```  
  
```csharp  
System.Diagnostics.Trace.Listeners.Clear();  
System.Diagnostics.Trace.Listeners.Add(  
   new System.Diagnostics.TextWriterTraceListener(Console.Out));  
```  
  
## Developer-Defined Listeners  
 You can define your own listeners by inheriting from the **TraceListener** base class and overriding its methods with your customized methods. For more information on creating developer-defined listeners, see <xref:System.Diagnostics.TraceListener> in the .NET Framework reference.  
  
## See Also  
 <xref:System.Diagnostics.TextWriterTraceListener>  
 <xref:System.Diagnostics.EventLogTraceListener>  
 <xref:System.Diagnostics.DefaultTraceListener>  
 <xref:System.Diagnostics.TraceListener>  
 [Tracing and Instrumenting Applications](../../../docs/framework/debug-trace-profile/tracing-and-instrumenting-applications.md)  
 [Trace Switches](../../../docs/framework/debug-trace-profile/trace-switches.md)
