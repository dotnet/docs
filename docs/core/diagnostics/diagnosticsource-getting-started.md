---
title: Getting Started with DiagnosticSource
description: A tutorial to create a basic DiagnosticSource and understand key concepts
ms.date: 05/02/2022
---
# Getting Started with DiagnosticSource

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.5 and later versions

This walkthrough shows <xref:System.Diagnostics.DiagnosticSource?displayProperty=nameWithType> 

## Log an event

The `DiagnosticSource` type is an abstract base class that defines the methods needed to log events. The class that holds the implementation is `DiagnosticListener`.
The first step in instrumenting code with `DiagnosticSource` is to create a
`DiagnosticListener`. For example:

```C#
    private static DiagnosticSource httpLogger = new DiagnosticListener("System.Net.Http");
```
Notice that httpLogger is typed as a `DiagnosticSource`. 
This is because this code
only cares about writing events and thus only cares about the  `DiagnosticSource` methods that
the `DiagnosticListener` implements. `DiagnosticListeners` are given names when they are created
and this name should be the name of logical grouping of related events (typically the component).
Later this name is used to find the Listener and subscribe to any of its events. `DiagnosticListeners` have a name, which is used to represent the component associated with the event.
Thus the event names only need to be unique within a component.
