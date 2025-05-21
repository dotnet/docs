---
title: System.NotImplementedException class
description: Learn about the System.NotImplementedException class.
ms.date: 12/31/2023
ms.topic: article
---
# System.NotImplementedException class

[!INCLUDE [context](includes/context.md)]

The <xref:System.NotImplementedException> exception is thrown when a particular method, get accessor, or set accessor is present as a member of a type but is not implemented.

<xref:System.NotImplementedException> uses the default <xref:System.Object.Equals%2A?displayProperty=nameWithType> implementation, which supports reference equality. For a list of initial values for an instance of <xref:System.NotImplementedException>, see the <xref:System.NotImplementedException.%23ctor%2A> constructors.

## Throw the exception

You might choose to throw a  <xref:System.NotImplementedException> exception in properties or methods in your own types when the that member is still in development and will only later be implemented in production code. In other words,  a <xref:System.NotImplementedException> exception should be synonymous with "still in development."

## Handle the exception

The <xref:System.NotImplementedException> exception indicates that the method or property that you are attempting to invoke has no implementation and therefore provides no functionality. As a result, you should not handle this error in a `try/catch` block. Instead, you should remove the member invocation from your code. You can include a call to the member when it is implemented in the production version of a library.

In some cases, a <xref:System.NotImplementedException> exception may not be used to indicate functionality that is still in development in a pre-production library. However, this still indicates that the functionality is unavailable, and you should remove the member invocation from your code.

## NotImplementedException and other exception types

.NET also includes two other exception types, <xref:System.NotSupportedException> and <xref:System.PlatformNotSupportedException>, that indicate that no implementation exists for a particular member of a type. You should throw one of these instead of a <xref:System.NotImplementedException> exception under the following conditions:

- Throw a <xref:System.PlatformNotSupportedException> exception on platforms on which the functionality is not supported if you've designed a type with one or more members that are available on some platforms or versions but not others.
- Throw a <xref:System.NotSupportedException> exception if the implementation of an interface member or an override to an abstract base class method is not possible.

  For example, the <xref:System.Convert.ToInt32%28System.DateTime%29?displayProperty=nameWithType> method throws a <xref:System.NotSupportedException> exception because no meaningful conversion between a date and time and a 32-bit signed integer exists. The method must be present in this case because the <xref:System.Convert> class implements the <xref:System.IConvertible> interface.

You should also throw a <xref:System.NotSupportedException> exception if you've implemented an abstract base class and add a new member to it that must be overridden by derived classes. In that case, making the member abstract causes existing subclasses to fail to load.
