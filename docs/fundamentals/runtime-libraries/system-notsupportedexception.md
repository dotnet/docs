---
title: System.NotSupportedException class
description: Learn about the System.NotSupportedException class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
  - FSharp
---
# System.NotSupportedException class

[!INCLUDE [context](includes/context.md)]

<xref:System.NotSupportedException> indicates that no implementation exists for an invoked method or property.

<xref:System.NotSupportedException> uses the HRESULT `COR_E_NOTSUPPORTED`, which has the value 0x80131515.

For a list of initial property values for an instance of <xref:System.NotSupportedException>, see the <xref:System.NotSupportedException.%23ctor%2A> constructors.

## Throw a NotSupportedException exception

You might consider throwing a <xref:System.NotSupportedException> exception in the following cases:

- You're implementing a general-purpose interface, and number of the methods have no meaningful implementation. For example, if you are creating a date and time type that implements the <xref:System.IConvertible> interface, you would throw a <xref:System.NotSupportedException> exception for most of the conversions.

- You've inherited from an abstract class that requires that you override a number of methods. However, you're only prepared to provide an implementation for a subset of these. For the methods that you decide not to implement, you can choose to throw a <xref:System.NotSupportedException>.

- You're defining a general-purpose type with a state that enables operations conditionally. For example, your type can be either read-only or read-write. In that case:

  - If the object is read-only, attempting to assign values to the properties of an instance or call methods that modify instance state should throw a <xref:System.NotSupportedException> exception.

  - You should implement a property that returns a <xref:System.Boolean> value that indicates whether particular functionality is available. For example, for a type that can be either read-only or read-write, you could implement a `IsReadOnly` property that indicates whether the set of read-write methods are available or unavailable.

## Handle a NotSupportedException exception

The <xref:System.NotSupportedException> exception indicates that a method has no implementation and that you should not call it. You should not handle the exception. Instead, what you should do depends on the cause of the exception: whether an implementation is completely absent, or the member invocation is inconsistent with the purpose of an object (such as a call to the <xref:System.IO.FileStream.Write%2A?displayProperty=nameWithType> method on a read-only <xref:System.IO.FileStream> object).

**An implementation has not been provided because the operation cannot be performed in a meaningful way.**
This is a common exception when you are calling methods on an object that provides implementations for the methods of an abstract base class, or that implements a general-purpose interface, and the method has no meaningful implementation.

For example, the <xref:System.Convert> class implements the <xref:System.IConvertible> interface, which means that it must include a method to convert every primitive type to every other primitive type. Many of those conversions, however, are not possible. As a result, a call to the <xref:System.Convert.ToBoolean%28System.DateTime%29?displayProperty=nameWithType> method, for instance, throws a <xref:System.NotSupportedException> exception because there is no possible conversion between a <xref:System.DateTime> and a <xref:System.Boolean> value

To eliminate the exception, you should eliminate the method call.

**The method call is not supported given the state of the object.**
You're attempting to invoke a member whose functionality is unavailable because of the object's state. You can eliminate the exception in one of three ways:

- You know the state of the object in advance, but you've invoked an unsupported method or property. In this case, the member invocation is an error, and you can eliminate it.

- You know the state of the object in advance (usually because your code has instantiated it), but the object is mis-configured. The following example illustrates this issue. It creates a read-only <xref:System.IO.FileStream> object and then attempts to write to it.

  :::code language="csharp" source="./snippets/System/NotSupportedException/Overview/csharp/BadState1.cs" id="Snippet1":::
  :::code language="fsharp" source="./snippets/System/NotSupportedException/Overview/fsharp/BadState1.fs" id="Snippet1":::
  :::code language="vb" source="./snippets/System/NotSupportedException/Overview/vb/BadState1.vb" id="Snippet1":::

  Ycan eliminate the exception by ensuring that the instantiated object supports the functionality you intend. The following example addresses the problem of the read-only <xref:System.IO.FileStream> object by providing the correct arguments to the <xref:System.IO.FileStream.%23ctor%28System.String%2CSystem.IO.FileMode%2CSystem.IO.FileAccess%29?displayProperty=nameWithType> constructor.

- You don't know the state of the object in advance, and the object doesn't support a particular operation. In most cases, the object should include a property or method that indicates whether it supports a particular set of operations. You can eliminate the exception by checking the value of the object and invoking the member only if appropriate.

  The following example defines a `DetectEncoding` method that throws a <xref:System.NotSupportedException> exception when it attempts to read from the beginning of a stream that does not support read access.

  :::code language="csharp" source="./snippets/System/NotSupportedException/Overview/csharp/TestProp1.cs" id="Snippet3":::
  :::code language="fsharp" source="./snippets/System/NotSupportedException/Overview/fsharp/TestProp1.fs" id="Snippet3":::
  :::code language="vb" source="./snippets/System/NotSupportedException/Overview/vb/TestProp1.vb" id="Snippet3":::

  You can eliminate the exception by examining the value of the <xref:System.IO.FileStream.CanRead?displayProperty=nameWithType> property and exiting the method if the stream is read-only.

  :::code language="csharp" source="./snippets/System/NotSupportedException/Overview/csharp/TestProp2.cs" id="Snippet4":::
  :::code language="fsharp" source="./snippets/System/NotSupportedException/Overview/fsharp/TestProp2.fs" id="Snippet4":::
  :::code language="vb" source="./snippets/System/NotSupportedException/Overview/vb/TestProp2.vb" id="Snippet4":::

## Related exception types

The <xref:System.NotSupportedException> exception is closely related to two other exception types;

- <xref:System.NotImplementedException>

  This exception is thrown when a method could be implemented but is not, either because the member will be implemented in a later version, the member is not available on a particular platform, or the member belongs to an abstract class and a derived class must provide an implementation.

- <xref:System.InvalidOperationException>

  This exception is thrown in scenarios in which it is generally sometimes possible for the object to perform the requested operation, and the object state determines whether the operation can be performed.

## .NET Compact Framework notes

When working with the .NET Compact Framework and using P/Invoke on a native function, this exception may be thrown if:

- The declaration in managed code is incorrect.
- The .NET Compact Framework does not support what you are trying to do.
- The DLL names are mangled on export.

If a <xref:System.NotSupportedException.%23ctor%2A> exception is thrown, check:

- For any violations of the .NET Compact Framework P/Invoke restrictions.
- For any arguments that require pre-allocated memory. If these exist, you should pass a reference to an existing variable.
- That the names of the exported functions are correct. This can be verified with [DumpBin.exe](/cpp/build/reference/dumpbin-reference).
- That you are not attempting to pass too many arguments.
