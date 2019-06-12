---
title: .NET Core application compatibility
description: Learn about the ways in which .NET Core attempts to maintain compatibility for developers across .NET versions.
author: rpetrusha
ms.author: ronpet
ms.date: 06/10/2019
---
# .NET Core application compatibility

Throughout its history, .NET has attempted to maintain a high level of compatibility from version to version and across flavors of .NET. This continues to be true of .NET Core. Although .NET Core can be considered as a new technology that is independent of the .NET Framework, two major factors limit the ability of .NET Core to diverge from .NET Framework:

- A large number of developers either originally developed or continue to develop .NET Framework applications. They expect consistent behavior across .NET implementations.

- .NET Standard library projects allow developers to create libraries that target common APIs shared by .NET Core and .NET Framework. Developers expect that a library used in a .NET Core application should behave identically to the same library used in a .NET Framework application.

Along with compatibility across .NET implementations, developers expect a high level of compatibility across .NET Core versions. In particular, code written for an earlier version of .NET Core should run seamlessly on a later version of .NET Core. In fact, many developers expect that the new APIs found in newly released versions of .NET Core should also be compatible with the pre-release versions in which those APIs were introduced.

This article outlines the categories of compatibility changes (or breaking changes) and the way in which the .NET team evaluates changes in each of these categories. An understanding of the how the .NET team approaches possible breaking changes is particularly helpful for developers who are opening pull requests in the GitHub [dotnet/corefx](https://github.com/dotnet/corefx) repository that modify the behavior of existing APIs.

> [!NOTE]
> For a discussion of compatibility categories, such as binary compatibility and backward compatibility, see [Breaking change categories](categories.md).

The following sections describes the categories of changes made to .NET Core APIs and their impact on application compatibility. The ✔️ icon indicates that a particular kind of change is allowed, ❌ indicates that it is disallowed, and  ? for a grey area.

## Modifications to the public contract

Changes in this category *modify* the public surface area of a type. Most of the changes in this category are disallowed since they violate *backwards compatibility* (the ability of an application that was developed with a previous version of an API to execute without recompilation on a later version). They include:

- **❌ Renaming or removing a public type, member, or parameter**

   This breaks all code that uses the renamed or removed type, member, or parameter. Note that this applies to changing the names of parameters as well. Because arguments can be specified for a particular parameter either positionally or [by name](../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments#named-arguments.md), changing the name of a parameter is a [source incompatible change](categories#Source-compatibility).

- **❌ Changing the value of a public constant or enumeration member**

- **❌ Sealing a type that was previously unsealed**

- **❌ Making a virtual member abstract**

  A [virtual member](../../csharp/language-reference/keywords/virtual.md) provides a method implementation that *can be* overridden by a derived class. An [abstract member](./../csharp/language-reference/keywords/abstract.md) provides no implementation and *must be* overridden.

- **❌ Adding an interface to the set of base types of an interface**

   If an interface implements an interface that it previously did not implement, all types that implemented the original version of the interface are broken.

- **❌ Removing a type or interface from the set of base types**

- **❌ Reducing the visibility of a type or member**

   However, increasing the visibility of a type or member is allowed.

- **❌ Changing the type of a member**

   The return value of a method or the type of a property or field cannot be modified. For example, the signature of a method that returns an <xref:System.Object> cannot be changed to return a <xref:System.String>, or vice versa.

Some kinds of changes are allowed, however:

- **✔️ Adding a new interface implementation to a type**

- **✔️ Expanding the visibility of a type or member**

## Behavioral changes

### Properties, fields, parameters, and return values

- **✔️ Changing the value of a property, field, return value, or [out](./../csharp/language-reference/keywords/out-parameter-modifier.md) parameter to a more derived type**

  For example, a method that returns an type of <xref:System.Object> can return a <xref:System.String> instance. (However, the method signature cannot change.)

- **✔️ Increasing the range of accepted values for a property or parameter if the member is not [virtual](../../csharp/language-reference/keywords/virtual.md)**

  Note that while the range of values that can be passed to the method or are returned by the member can expand, the parameter or member type cannot. For example, while the values passed to a method can expand from 0-124 to 0-255, the parameter type cannot change from <xref:System.Byte> to <xref:System.Int32>.

- **❌ Increasing the range of accepted values for a property or parameter if the member is [virtual](../../csharp/language-reference/keywords/virtual.md)**

   This change breaks existing overridden members, which will not function correctly for the extended range of values.

- **❌ Decreasing the range of accepted values for a property or parameter**

- **❌ Increasing the range of returned values for a property, field, return value, or [out](./../csharp/language-reference/keywords/out-parameter-modifier.md) parameter**

- **❌ Changing the returned values for a property, field, method return value, or [out](./../csharp/language-reference/keywords/out-parameter-modifier.md) parameter**



- **❌ Changing the default value of a property, field, or parameter** 

- **❌ Changing the precision of a numeric return value**

### Exceptions

- **✔️ Throwing a more derived exception than an existing exception**

  Because the new exception is a subclass of an existing exception, previous exception handling code continues to handle the exception. For example, in .NET Framework 4, culture creation and retrieval methods began to throw an <xref:System.Globalization.CultureNotFoundException> instead of an <xref:System.ArgumentException> if the culture could not be found. Because  <xref:System.Globalization.CultureNotFoundException> derives from <xref:System.ArgumentException>, this is an acceptable change.

- **✔️ Throwing a more specific exception than <xref:System.NotSupportedException>, <xref:System.NotImplementedException>, <xref:System.NullReferenceException>**

- **✔️ Throwing an exception that is considered unrecoverable**

  Unrecoverable exceptions should not be caught, but should be handled by a high-level catch-all handler. Therefore, users are not expected to have code that catches these explicit exceptions. The unrecoverable exceptions are:

  - <xref:System.StackOverflowException>
  - <xref:System.SEHException>
  - <xref:System.ExecutionEngineException>
  - <xref:System.AccessViolationException>

- **✔️ Throwing a new exception in a new code path**

  The exception must apply only to a new code-path which is executed with new parameter values or state, and that can't be executed by existing code that targets the previous version.

- **✔️ Removing an exception to enable more robust behavior or new scenarios**

  For example, a `Divide` method that previously only handled positive values and threw an <xref:System.ArgumentOutOfRangeException> otherwise can be changed to support both negative and positive values without throwing an exception.

- **❌ Throwing an exception in any other case not listed above**

- **❌ Removing an exception in any other case not listed above**

## Platform support

- **✔️ Supporting an operation on a platform that was previously not supported**

- **❌ Not supporting or now requiring a specific service pack for an operation that was previosuly supported on a platform**

## Internal implmentation changes

- **? Changing the surface area of an internal type**

   Such changes are generally allowed, although they break private reflection. In some cases, where popular third-party libraries or a large number of developers depend on the internal APIs, such changes may not be allowed.

- **? Changing the internal implementation of a member**

  These changes are generally allowed, although they break private reflection. In some cases, where customer code frequently depends on private reflection or where the change introduces unintended side effects, these changes may not be allowed.

- **✔️ Improving the performance of an operation**

   The ability to modify the performance of an operation is essential, but such changes can break code that relies upon the current speed of an operation. This is particularly true of code that depends on the timing of asynchronous operations. Note that the performance change should have no affect on other behavior of the API in question; otherwise, the change will be breaking.

- **✔️ Indirectly (and often adversely) changing the performance of an operation**

  Assuming that the change in question is not categorized as breaking for some other reason, this is acceptable. Often, actions need to be taken that may include extra operations or that add new functionality. This will almost always affect performance but may be essential to make the API in question function as expected.
  
???
?

✔️

❌
❌

