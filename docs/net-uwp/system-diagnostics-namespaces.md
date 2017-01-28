---
title: "System.Diagnostics namespaces1 | Microsoft Docs"
ms.custom: ""
ms.date: "12/16/2016"
ms.prod: "windows-client-threshold"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - ".net-for-windows-store-apps"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0cabc3de-f5ee-4a32-b36b-bc08347deeba
caps.latest.revision: 10
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
---
# System.Diagnostics namespaces1
`System.Diagnostics` and its child namespaces (`System.Diagnostics.CodeAnalysis`, `System.Diagnostics.Contracts`, and `System.Diagnostics.Tracing`) contain types that enable you to interact with system processes, event logs, and performance counters.  
  
 This topic displays the types in the `System.Diagnostics` namespaces that are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]. Note that the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)] does not include all the members of each type. For information about individual types, see the linked topics. The documentation for a type indicates which members are included in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)].  
  
## System.Diagnostics namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Diagnostics.ConditionalAttribute>|Indicates to compilers that a method call or attribute should be ignored unless a specified conditional compilation symbol is defined.|  
|<xref:System.Diagnostics.Debug>|Provides a set of methods and properties that help debug your code. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggableAttribute>|Modifies code generation for runtime just-in-time (JIT) debugging. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggableAttribute.DebuggingModes>|Specifies the debugging mode for the just-in-time (JIT) compiler.|  
|<xref:System.Diagnostics.Debugger>|Enables communication with a debugger. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggerBrowsableAttribute>|Determines if and how a member is displayed in the debugger variable windows. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggerBrowsableState>|Provides display instructions for the debugger.|  
|<xref:System.Diagnostics.DebuggerDisplayAttribute>|Determines how a class or field is displayed in the debugger variable windows.|  
|<xref:System.Diagnostics.DebuggerHiddenAttribute>|Specifies the DebuggerHiddenAttribute. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggerNonUserCodeAttribute>|Identifies a type or member that is not part of the user code for an application.|  
|<xref:System.Diagnostics.DebuggerStepThroughAttribute>|Instructs the debugger to step through the code instead of stepping into the code. This class cannot be inherited.|  
|<xref:System.Diagnostics.DebuggerTypeProxyAttribute>|Specifies the display proxy for a type.|  
|<xref:System.Diagnostics.Stopwatch>|Provides a set of methods and properties that you can use to accurately measure elapsed time.|  
  
## System.Diagnostics.CodeAnalysis namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Diagnostics.CodeAnalysis.SuppressMessageAttribute>|Suppresses reporting of a specific static analysis tool rule violation, allowing multiple suppressions on a single code artifact.|  
  
## System.Diagnostics.Contracts namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Diagnostics.Contracts.Contract>|Contains static methods for representing program contracts such as preconditions, postconditions, and object invariants.|  
|<xref:System.Diagnostics.Contracts.ContractAbbreviatorAttribute>|Enables defining abbreviations for contracts which can be used in place of the full contract syntax.|  
|<xref:System.Diagnostics.Contracts.ContractArgumentValidatorAttribute>|Enables factoring legacy if-then-throw code into separate methods for reuse and full control over thrown exceptions and arguments.|  
|<xref:System.Diagnostics.Contracts.ContractClassAttribute>|Specifies that a separate type contains the code contracts for this type.|  
|<xref:System.Diagnostics.Contracts.ContractClassForAttribute>|Specifies that a class is a contract for a type.|  
|<xref:System.Diagnostics.Contracts.ContractFailedEventArgs>|Provides methods and data for the ContractFailed event.|  
|<xref:System.Diagnostics.Contracts.ContractFailureKind>|Specifies the type of contract that failed.|  
|<xref:System.Diagnostics.Contracts.ContractInvariantMethodAttribute>|Marks a method as being the invariant method for a class.|  
|<xref:System.Diagnostics.Contracts.ContractOptionAttribute>|Allows setting contract and tool options at assembly, type, or method granularity.|  
|<xref:System.Diagnostics.Contracts.ContractPublicPropertyNameAttribute>|Specifies that a field can be used in method contracts when the field has less visibility than the method.|  
|<xref:System.Diagnostics.Contracts.ContractReferenceAssemblyAttribute>|Specifies that an assembly is a reference assembly that contains contracts.|  
|<xref:System.Diagnostics.Contracts.ContractRuntimeIgnoredAttribute>|Identifies a member that has no run-time behavior.|  
|<xref:System.Diagnostics.Contracts.ContractVerificationAttribute>|Instructs analysis tools to assume the correctness of an assembly, type, or member without performing static verification.|  
|<xref:System.Diagnostics.Contracts.PureAttribute>|Indicates that a type or method is pure, that is, it does not make any visible state changes.|  
  
## System.Diagnostics.Tracing namespace  
  
|Types supported in the [!INCLUDE[net_win8_profile](../net-uwp/includes/net-win8-profile-md.md)]|Description|  
|---------------------------------------------------------------------------------------------|-----------------|  
|<xref:System.Diagnostics.Tracing.EventAttribute>|Enables you to specify additional event schema information for an event.|  
|<xref:System.Diagnostics.Tracing.EventCommand>|Describes the command passed to the OnEventCommand callback.|  
|<xref:System.Diagnostics.Tracing.EventCommandEventArgs>|Provides the arguments for the OnEventCommand callback.|  
|<xref:System.Diagnostics.Tracing.EventKeywords>|Defines the standard keywords that apply to events.|  
|<xref:System.Diagnostics.Tracing.EventLevel>|Identifies the level of an event.|  
|<xref:System.Diagnostics.Tracing.EventListener>|Provides methods for enabling and disabling events from event sources.|  
|<xref:System.Diagnostics.Tracing.EventOpcode>|Defines the standard opcodes that are attached to events by the event source.|  
|<xref:System.Diagnostics.Tracing.EventSource>|Provides the ability to create events for event tracing.|  
|<xref:System.Diagnostics.Tracing.EventSource.EventData>|Provides the event data for creating fast WriteEvent overloads using the WriteEventCore method.|  
|<xref:System.Diagnostics.Tracing.EventSourceAttribute>|Allows the event tracing for Windows (ETW) name to be defined independently of the name of the event source class.|  
|<xref:System.Diagnostics.Tracing.EventSourceException>|The exception that is thrown when an error occurs during event tracing for Windows (ETW).|  
|<xref:System.Diagnostics.Tracing.EventTask>|Defines the tasks that apply to events.|  
|<xref:System.Diagnostics.Tracing.EventWrittenEventArgs>|Provides data for the OnEventWritten callback.|  
|<xref:System.Diagnostics.Tracing.NonEventAttribute>|Identifies a method not generating an event.|  
  
## See Also  
 [.NET for Windows apps](../net-uwp/dotnet-for-windows-apps.md)