---
title: "Windows Workflow Foundation Glossary for .NET Framework 4.5"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Workflow Foundation [WF], glossary"
  - "WF [WF], glossary"
ms.assetid: ab682b2f-3779-45ca-b831-b7c03d7dbb3a
caps.latest.revision: 259
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Workflow Foundation Glossary for .NET Framework 4.5
The following terms are used in the Windows Workflow Foundation documentation.  
  
## Terms  
  
|Term|Definition|  
|----------|----------------|  
|activity|A unit of program behavior in Windows Workflow Foundation. Single activities can be composed together into more complex activities.|  
|activity action|A data structure used to expose callbacks for workflow and activity execution.|  
|argument|Defines the data flow into and out of an activity. Each argument has a specified direction: in, out, or in/out. These represent the input, output, and input/output parameters of the activity.|  
|bookmark|The point at which an activity can pause and wait to be resumed.|  
|compensation|A group of actions designed to undo or mitigate the effect of previously completed work.|  
|correlation|The mechanism for routing messages to a workflow or service instance.|  
|expression|A construct that takes in one or more arguments, performs an operation on the arguments and returns a single value. Expressions can be used anywhere an activity can be used.|  
|flowchart|A well-known modeling paradigm that represents program components as symbols linked together with directional arrows.  In the .NET Framework 4, workflows can be modeled as flowcharts using the Flowchart activity.|  
|long-running process|A unit of program execution that does not return immediately and may span system restarts.|  
|persistence|Saving the state of a workflow or service to a durable medium, so that it can be unloaded from memory or recovered after a system failure.|  
|state machine|A well-known modeling paradigm that represents program components as individual states linked together with event-driven state transitions.  Workflows can be modeled as state machines using the StateMachine activity.|  
|substance|Represents a group of related bookmarks under a common identifier and allows the runtime to make decisions about whether a particular bookmark resumption is valid or may become valid.|  
|type converter|A CLR type can be associated with one or more System.ComponentModel.TypeConverter derived types that enable converting instances of the CLR type to and from instances of other types. A type converterr is associated with a CLR type using the System.ComponentModel.TypeConverterAttribute attribute.  A TypeConverterAttribute can be specified directly on the CLR type or on a property. A type converter specified on a property always takes precedence over a type converter specified on the CLR type of the property.|  
|variable|Represents the storage of some data that must be saved and accessed later.|  
|workflow|A single activity or tree of activities invoked by a host process.|  
|XAML|eXtensible Application Markup Language|
