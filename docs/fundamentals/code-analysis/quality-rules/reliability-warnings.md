---
title: Reliability rules (code analysis)
description: "Learn about code analysis reliability rules."
ms.date: 11/04/2016
ms.topic: reference
f1_keywords:
- vs.codeanalysis.reliabilityrules
helpviewer_keywords:
- rules, reliability
- reliability rules
- managed code analysis rules, reliability rules
author: gewarren
ms.author: gewarren
---
# Reliability rules

Reliability rules support library and application reliability, such as correct memory and thread usage. The reliability rules include:

|Rule|Description|
|----------|-----------------|
|[CA2000: Dispose objects before losing scope](ca2000.md)|Because an exceptional event might occur that will prevent the finalizer of an object from running, the object should be explicitly disposed before all references to it are out of scope.|
|[CA2002: Do not lock on objects with weak identity](ca2002.md)|An object is said to have a weak identity when it can be directly accessed across application domain boundaries. A thread that tries to acquire a lock on an object that has a weak identity can be blocked by a second thread in a different application domain that has a lock on the same object.|
|[CA2007: Do not directly await a Task](ca2007.md)|An asynchronous method [awaits](../../../csharp/language-reference/operators/await.md) a <xref:System.Threading.Tasks.Task> directly.|
|[CA2008: Do not create tasks without passing a TaskScheduler](ca2008.md)|A task creation or continuation operation uses a method overload that does not specify a <xref:System.Threading.Tasks.TaskScheduler> parameter.|
|[CA2009: Do not call ToImmutableCollection on an ImmutableCollection value](ca2009.md)|`ToImmutable` method was unnecessarily called on an immutable collection from <xref:System.Collections.Immutable> namespace.|
|[CA2011: Do not assign property within its setter](ca2011.md) | A property was accidentally assigned a value within its own [set accessor](../../../csharp/programming-guide/classes-and-structs/using-properties.md#the-set-accessor). |
|[CA2012: Use ValueTasks correctly](ca2012.md) | ValueTasks returned from member invocations are intended to be directly awaited.  Attempts to consume a ValueTask multiple times or to directly access one's result before it's known to be completed may result in an exception or corruption.  Ignoring such a ValueTask is likely an indication of a functional bug and may degrade performance. |
|[CA2013: Do not use ReferenceEquals with value types](ca2013.md) | When comparing values using <xref:System.Object.ReferenceEquals%2A?displayProperty=fullName>, if objA and objB are value types, they are boxed before they are passed to the <xref:System.Object.ReferenceEquals%2A> method. This means that even if both objA and objB represent the same instance of a value type, the <xref:System.Object.ReferenceEquals%2A> method nevertheless returns false. |
|[CA2014: Do not use stackalloc in loops.](ca2014.md) | Stack space allocated by a stackalloc is only released at the end of the current method's invocation.  Using it in a loop can result in unbounded stack growth and eventual stack overflow conditions. |
|[CA2015: Do not define finalizers for types derived from MemoryManager&lt;T&gt;](ca2015.md) | Adding a finalizer to a type derived from <xref:System.Buffers.MemoryManager%601> may permit memory to be freed while it is still in use by a <xref:System.Span%601>. |
|[CA2016: Forward the CancellationToken parameter to methods that take one](ca2016.md) | Forward the `CancellationToken` parameter to methods that take one to ensure the operation cancellation notifications gets properly propagated, or pass in `CancellationToken.None` explicitly to indicate intentionally not propagating the token. |
|[CA2018: The `count` argument to `Buffer.BlockCopy` should specify the number of bytes to copy](ca2018.md) | When using `Buffer.BlockCopy`, the `count` argument specifies the number of bytes to copy. You should only use `Array.Length` for the `count` argument on arrays whose elements are exactly one byte in size. `byte`, `sbyte`, and `bool` arrays have elements that are one byte in size. |
