---
description: "Learn more about: Logging class"
title: Logging class (System.Net)
ms.date: 06/12/2020
ms.subservice: networking
topic_type:
  - apiref
api_name:
  - System.Net.Logging
  - System.Net.Logging.Associate
  - System.Net.Logging.Enter
  - System.Net.Logging.Exception
  - System.Net.Logging.Exit
  - System.Net.Logging.get_Http
  - System.Net.Logging.get_On
api_location:
  - System.dll
api_type:
  - Assembly
---
# Logging class

Provides trace logging functionality.

```csharp
internal class Logging
```

> [!WARNING]
> This class is internal and is not meant to be used directly in your code.
>
> Microsoft does not support the use of this class in a production application under any circumstance.

## Associate method

Logs information that two objects are associated with each other.

```csharp
internal static void Associate(TraceSource traceSource, object objA, object objB)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `objA` <xref:System.Object>

  The object to associate with `objB`.

- `objB` <xref:System.Object>

  The object to associate with `objA`.

## Enter(TraceSource, object, string, string) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, object obj, string method, string param)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.Object>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being entered.

- `param` <xref:System.String>

  The parameters that were passed to the method.

## Enter(TraceSource, object, string, object) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, object obj, string method, object paramObject)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.Object>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being entered.

- `paramObject` <xref:System.Object>

  The parameters that were passed to the method.

## Enter(TraceSource, string, string, string) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, string obj, string method, string param)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.String>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being entered.

- `param` <xref:System.String>

  The parameters that were passed to the method.

## Enter(TraceSource, string, string, object) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, string obj, string method, object paramObject)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.String>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being entered.

- `paramObject` <xref:System.Object>

  The parameters that were passed to the method.

## Enter(TraceSource, string, string) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, string method, string parameters)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `method` <xref:System.String>

  The method that is being entered.

- `parameters` <xref:System.String>

  The parameters that were passed to the method.

## Enter(TraceSource, string) method

Logs entrance to a method.

```csharp
internal static void Enter(TraceSource traceSource, string msg)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `msg` <xref:System.String>

  The entrance message to log to the trace source.

## Exception method

Logs an exception and restores indentation.

```csharp
internal static void Exception(TraceSource traceSource, object obj, string method, Exception e)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.Object>

  The object that the method that threw an exception was called on.

- `method` <xref:System.String>

  The method that threw the exception.

- `e` <xref:System.Exception>

  The exception that was thrown.

## Exit(TraceSource, object, string, object) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, object obj, string method, object retObject)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.Object>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being exited.

- `retObject` <xref:System.Object>

  The value that's being returned by the method.

## Exit(TraceSource, string, string, object) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, string obj, string method, object retObject)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.String>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being exited.

- `retObject` <xref:System.Object>

  The value that's being returned by the method.

## Exit(TraceSource, object, string, string) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, object obj, string method, string retValue)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.Object>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being exited.

- `retValue` <xref:System.String>

  The value that's being returned by the method.

## Exit(TraceSource, string, string, string) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, string obj, string method, string retValue)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `obj` <xref:System.String>

  The object that the method was called on.

- `method` <xref:System.String>

  The method that is being exited.

- `retValue` <xref:System.String>

  The value that's being returned by the method.

## Exit(TraceSource, string, string) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, string method, string parameters)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `method` <xref:System.String>

  The method that is being exited.

- `parameters` <xref:System.String>

  The parameters that were passed to the method that's being exited.

## Exit(TraceSource, string) method

Logs exit from a function.

```csharp
internal static void Exit(TraceSource traceSource, string msg)
```

### Parameters

- `traceSource` <xref:System.Diagnostics.TraceSource>

  The trace source to log the event to.

- `msg` <xref:System.String>

  The exit message to log to the trace source.

## Http property

Gets the trace source for "System.Net.Http".

```csharp
internal static TraceSource Http { get; }
```

### Property value

<xref:System.Diagnostics.TraceSource>\
The trace source for "System.Net.Http", or `null` if logging is not enabled.

## On property

Gets a value that indicates whether logging is enabled.

```csharp
internal static bool On { get; }
```

### Property value

<xref:System.Boolean>\
`true` if logging is enabled; otherwise, `false`.

## Requirements

**Namespace:** <xref:System.Net>

**Assembly:** System (in System.dll)
