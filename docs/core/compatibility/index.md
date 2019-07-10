---
title: Evaluate breaking changes - .NET Core
description: Learn about the ways in which .NET Core attempts to maintain compatibility for developers across .NET versions.
author: rpetrusha
ms.author: ronpet
ms.date: 06/10/2019
---
# Evaluate breaking changes in .NET Core

Throughout its history, .NET has attempted to maintain a high level of compatibility from version to version and across flavors of .NET. This continues to be true for .NET Core. Although .NET Core can be considered as a new technology that is independent of the .NET Framework, two major factors limit the ability of .NET Core to diverge from .NET Framework:

- A large number of developers either originally developed or continue to develop .NET Framework applications. They expect consistent behavior across .NET implementations.

- .NET Standard library projects allow developers to create libraries that target common APIs shared by .NET Core and .NET Framework. Developers expect that a library used in a .NET Core application should behave identically to the same library used in a .NET Framework application.

Along with compatibility across .NET implementations, developers expect a high level of compatibility across .NET Core versions. In particular, code written for an earlier version of .NET Core should run seamlessly on a later version of .NET Core. In fact, many developers expect that the new APIs found in newly released versions of .NET Core should also be compatible with the pre-release versions in which those APIs were introduced.

This article outlines the categories of compatibility changes (or breaking changes) and the way in which the .NET team evaluates changes in each of these categories. Understanding how the .NET team approaches possible breaking changes is particularly helpful for developers who are opening pull requests in the [dotnet/corefx](https://github.com/dotnet/corefx) GitHub repository that modify the behavior of existing APIs.

> [!NOTE]
> For a definition of compatibility categories, such as binary compatibility and backward compatibility, see [Breaking change categories](categories.md).

The following sections describes the categories of changes made to .NET Core APIs and their impact on application compatibility. The ✔️ icon indicates that a particular kind of change is allowed, ❌ indicates that it is disallowed, and  ❓ indicates a change that may or may not be allowed. Changes in this last category require judgment and an evaluation of how predictable, obvious, and consistent the previous behavior was.

> [!NOTE]
> In addition to serving as a guide to how changes to .NET Core libraries are evaluated, library developers can also use these criteria to evaluate changes to their libraries that target multiple .NET implementations and versions.

## Modifications to the public contract

Changes in this category *modify* the public surface area of a type. Most of the changes in this category are disallowed since they violate *backwards compatibility* (the ability of an application that was developed with a previous version of an API to execute without recompilation on a later version).

### Types

- **✔️ Removing an interface implementation from a type when the interface is already implemented by a base type**

- **❓ Adding a new interface implementation to a type**

  This is an acceptable change because it does not adversely affect existing clients. Any changes to the type must work within the boundaries of acceptable changes defined here for the new implementation to remain acceptable. Extreme caution is necessary when adding interfaces that directly affect the ability of a designer or serializer to generate code or data that cannot be consumed down-level. An example is the <xref:System.Runtime.Serialization.ISerializable> interface.

- **❓ Introducing a new base class**

  A type can be introduced into an hierarchy between two existing types if it doesn't introduce any new [abstract](../../csharp/language-reference/keywords/abstract.md) members or change the semantics or behavior of existing types. For example, in .NET Framework 2.0, the <xref:System.Data.Common.DbConnection> class became a new base class for <xref:System.Data.SqlClient.SqlConnection>, which had previously derived directly from <xref:System.ComponentModel.Component>.

- **✔️ Moving a type from one assembly to another**

  Note that the *old* assembly must be marked with the <xref:System.Runtime.CompilerServices.TypeForwardedToAttribute> that points to the new assembly.

- **✔️ Changing a [struct](../../csharp/language-reference/keywords/struct.md) type to a `readonly struct` type**

  Note that changing a `readonly struct` type to a `struct` type is not allowed.
  
- **✔️ Adding the [sealed](../../csharp/language-reference/keywords/sealed.md) or [abstract](../../csharp/language-reference/keywords/abstract.md) keyword to a type when there are no *accessible* (public or protected) constructors**

- **✔️ Expanding the visibility of a type**

- **❌ Changing the namespace or name of a type**

- **❌ Renaming or removing a public type**

   This breaks all code that uses the renamed or removed type.

- **❌ Changing the underlying type of an enumeration**

   This is a compile-time and behavioral breaking change as well as a binary breaking change that can make attribute arguments unparsable.

- **❌ Sealing a type that was previously unsealed**

- **❌ Adding an interface to the set of base types of an interface**

   If an interface implements an interface that it previously did not implement, all types that implemented the original version of the interface are broken.

- **❓ Removing a class from the set of base classes or an interface from the set of implemented interfaces**

  There is one exception to the rule for interface removal: you can add the implementation of an interface that derives from the removed interface. For example, you can remove <xref:System.IDisposable> if the type or interface now implements <xref:System.ComponentModel.IComponent>, which implements <xref:System.IDisposable>.

- **❌ Changing a `readonly struct` type to a [struct](../../csharp/language-reference/keywords/struct.md) type**

  Note that the change of a `struct` type to a `readonly struct` type is allowed.

- **❌ Changing a [struct](../../csharp/language-reference/keywords/struct.md) type to a `ref struct` type, and vice versa**

- **❌ Reducing the visibility of a type**

   However, increasing the visibility of a type is allowed.

### Members

- **✔️ Expanding the visibility of a member that is not [virtual](../../csharp/language-reference/keywords/sealed.md)**

- **✔️ Adding an abstract member to a public type that has no *accessible* (public or protected) constructors, or the type is [sealed](../../csharp/language-reference/keywords/sealed.md)**

  However, adding an abstract member to a type that has accessible (public or protected) constructors and is not `sealed` is not allowed.

- **✔️ Restricting the visibility of a [protected](../../csharp/language-reference/keywords/protected.md) member when the type has no accessible (public or protected) constructors, or the type is [sealed](../../csharp/language-reference/keywords/sealed.md)**

- **✔️ Moving a member into a class higher in the hierarchy than the type from which it was removed**

- **✔️ Adding or removing an override**

  Note that introducing an override might cause previous consumers to skip over the override when calling [base](../../csharp/language-reference/keywords/base.md).

- **✔️ Adding a constructor to a class, along with a default (parameterless) constructor if the class previously had no constructors**

   However, adding a constructor to a class that previously had no constructors *without* adding the parameterless constructor is not allowed.

- **✔️ Changing a member from [abstract](../../csharp/language-reference/keywords/abstract.md) to [virtual](../../csharp/language-reference/keywords/virtual.md)**

- **✔️ Changing from a `ref readonly` to a `ref` return value (except for virtual methods or interfaces)**

- **✔️ Removing [readonly](../../csharp/language-reference/keywords/readonly.md) from a field, unless the static type of the field is a mutable value type**

- **✔️ Calling a new event that wasn't previously defined**

- **❓ Adding a new instance field to a type**

   This change impacts serialization.

- **❌ Renaming or removing a public member or parameter**

   This breaks all code that uses the renamed or removed member, or parameter.

   Note that this includes removing or renaming a getter or setter from a property, as well as renaming or removing enumeration members.

- **❌ Adding a member to an interface**

- **❌ Changing the value of a public constant or enumeration member**

- **❌ Changing the type of a property, field, parameter, or return value**

- **❌ Adding, removing, or changing the order of parameters**

- **❌ Adding or removing the [in](../../csharp/language-reference/keywords/in.md), [out](../../csharp/language-reference/keywords/out.md) , or [ref](../../csharp/language-reference/keywords/ref.md) keyword from a parameter**

- **❌ Renaming a parameter (including changing its case)**

  This is considered breaking for two reasons:
  
  - It breaks late-bound scenarios such as the late binding feature in Visual Basic and [dynamic](../../csharp/language-reference/keywords/dynamic.md) in C#.
  
  - It breaks [source compatibility](categories.md#source-compatibility) when developers use [named arguments](../../csharp/programming-guide/classes-and-structs/named-and-optional-arguments.md#named-arguments).

- **❌ Changing from a `ref` return value to a `ref readonly` return value**

- **❌️ Changing from a `ref readonly` to a `ref` return value on a virtual method or interface**

- **❌ Adding or removing [abstract](../../csharp/language-reference/keywords/abstract.md) from a member**

- **❌ Removing the [virtual](../../csharp/language-reference/keywords/virtual.md) keyword from a member**

  While this often is not a breaking change because the C# compiler tends to emit [callvirt](<xref:System.Reflection.Emit.OpCodes.Callvirt>) Intermediate Language (IL) instructions to call non-virtual methods (`callvirt` performs a null check, while a normal call doesn't), this behavior is not invariable for several reasons:
  - C# is not the only language that .NET targets.
  
  - The C# compiler increasingly tries to optimize `callvirt` to a normal call whenever the target method is non-virtual and is probably not null (such as a method accessed through the [?. null propagation operator](../../csharp/language-reference/operators/member-access-operators.md#null-conditional-operators--and-)).
  
  Making a method virtual means that the consumer code would often end up calling it non-virtually.

- **❌ Adding the [virtual](../../csharp/language-reference/keywords/virtual.md) keyword to a member**

- **❌ Making a virtual member abstract**

  A [virtual member](../../csharp/language-reference/keywords/virtual.md) provides a method implementation that *can be* overridden by a derived class. An [abstract member](../../csharp/language-reference/keywords/abstract.md) provides no implementation and *must be* overridden.

- **❌ Adding an abstract member to a public type that has accessible (public or protected) constructors and that is not [sealed](../../csharp/language-reference/keywords/sealed.md)**

- **❌ Adding or removing the [static](../../csharp/language-reference/keywords/static.md) keyword from a member**

- **❌ Adding an overload that precludes an existing overload and defines a different behavior**

  This breaks existing clients that were bound to the previous overload. For example, if a class has a single version of a method that accepts a <xref:System.UInt32>, an existing consumer will successfully bind to that overload when passing a <xref:System.Int32> value. However, if you add an overload that accepts an <xref:System.Int32>, when recompiling or using late-binding, the compiler now binds to the new overload. If different behavior results, this is a breaking change.

- **❌ Adding a constructor to a class that previously had no constructor without adding the parameterless constructor**

- **❌️ Adding [readonly](../../csharp/language-reference/keywords/readonly.md) to a field**

- **❌ Reducing the visibility of a member**

   This includes reducing the visibility of a [protected](../../csharp/language-reference/keywords/protected.md) member when there are *accessible* (public or protected) constructors and the type is *not* [sealed](../../csharp/language-reference/keywords/sealed.md). If this is not the case, reducing the visibility of a protected member is allowed.

   Note that increasing the visibility of a member is allowed.

- **❌ Changing the type of a member**

   The return value of a method or the type of a property or field cannot be modified. For example, the signature of a method that returns an <xref:System.Object> cannot be changed to return a <xref:System.String>, or vice versa.

- **❌ Adding a field to a struct that previously had no state**

  Definite assignment rules allow the use of uninitialized variables so long as the variable type is a stateless struct. If the struct is made stateful, code could end up with uninitialized data. This is both potentially a source breaking and a binary breaking change.

- **❌ Firing an existing event when it was never fired before**

## Behavioral changes

### Assemblies

- **✔️ Making an assembly portable when the same platforms are still supported**

- **❌ Changing the name of an assembly**
- **❌ Changing the public key of an assembly**

### Properties, fields, parameters, and return values

- **✔️ Changing the value of a property, field, return value, or [out](../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter to a more derived type**

  For example, a method that returns a type of <xref:System.Object> can return a <xref:System.String> instance. (However, the method signature cannot change.)

- **✔️ Increasing the range of accepted values for a property or parameter if the member is not [virtual](../../csharp/language-reference/keywords/virtual.md)**

  Note that while the range of values that can be passed to the method or are returned by the member can expand, the parameter or member type cannot. For example, while the values passed to a method can expand from 0-124 to 0-255, the parameter type cannot change from <xref:System.Byte> to <xref:System.Int32>.

- **❌ Increasing the range of accepted values for a property or parameter if the member is [virtual](../../csharp/language-reference/keywords/virtual.md)**

   This change breaks existing overridden members, which will not function correctly for the extended range of values.

- **❌ Decreasing the range of accepted values for a property or parameter**

- **❌ Increasing the range of returned values for a property, field, return value, or [out](../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter**

- **❌ Changing the returned values for a property, field, method return value, or [out](../../csharp/language-reference/keywords/out-parameter-modifier.md) parameter**

- **❌ Changing the default value of a property, field, or parameter**

- **❌ Changing the precision of a numeric return value**

- **❓ A change in the parsing of input and throwing new exceptions (even if parsing behavior is not specified in the documentation**

### Exceptions

- **✔️ Throwing a more derived exception than an existing exception**

  Because the new exception is a subclass of an existing exception, previous exception handling code continues to handle the exception. For example, in .NET Framework 4, culture creation and retrieval methods began to throw a <xref:System.Globalization.CultureNotFoundException> instead of an <xref:System.ArgumentException> if the culture could not be found. Because <xref:System.Globalization.CultureNotFoundException> derives from <xref:System.ArgumentException>, this is an acceptable change.

- **✔️ Throwing a more specific exception than <xref:System.NotSupportedException>, <xref:System.NotImplementedException>, <xref:System.NullReferenceException>**

- **✔️ Throwing an exception that is considered unrecoverable**

  Unrecoverable exceptions should not be caught but instead should be handled by a high-level catch-all handler. Therefore, users are not expected to have code that catches these explicit exceptions. The unrecoverable exceptions are:

  - <xref:System.AccessViolationException>
  - <xref:System.ExecutionEngineException>
  - <xref:System.Runtime.InteropServices.SEHException>
  - <xref:System.StackOverflowException>

- **✔️ Throwing a new exception in a new code path**

  The exception must apply only to a new code-path which is executed with new parameter values or state, and that can't be executed by existing code that targets the previous version.

- **✔️ Removing an exception to enable more robust behavior or new scenarios**

  For example, a `Divide` method that previously only handled positive values and threw an <xref:System.ArgumentOutOfRangeException> otherwise can be changed to support both negative and positive values without throwing an exception.

- **✔️ Changing the text of an error message**

  Developers should not rely on the text of error messages, which also change based on the user's culture.

- **❌ Throwing an exception in any other case not listed above**

- **❌ Removing an exception in any other case not listed above**

### Attributes

- **✔️ Changing the value of an attribute that is *not* observable**

- **❌ Changing the value of an attribute that *is* observable**

- **❓ Removing an attribute**

  In most cases, removing an attribute (such as <xref:System.NonSerializedAttribute>) is a breaking change.

## Platform support

- **✔️ Supporting an operation on a platform that was previously not supported**

- **❌ Not supporting or now requiring a specific service pack for an operation that was previously supported on a platform**

## Internal implementation changes

- **❓ Changing the surface area of an internal type**

   Such changes are generally allowed, although they break private reflection. In some cases, where popular third-party libraries or a large number of developers depend on the internal APIs, such changes may not be allowed.

- **❓ Changing the internal implementation of a member**

  These changes are generally allowed, although they break private reflection. In some cases, where customer code frequently depends on private reflection or where the change introduces unintended side effects, these changes may not be allowed.

- **✔️ Improving the performance of an operation**

   The ability to modify the performance of an operation is essential, but such changes can break code that relies upon the current speed of an operation. This is particularly true of code that depends on the timing of asynchronous operations. Note that the performance change should have no effect on other behavior of the API in question; otherwise, the change will be breaking.

- **✔️ Indirectly (and often adversely) changing the performance of an operation**

  If the change in question is not categorized as breaking for some other reason, this is acceptable. Often, actions need to be taken that may include extra operations or that add new functionality. This will almost always affect performance but may be essential to make the API in question function as expected.

- **❌ Changing a synchronous API to asynchronous (and vice versa)**

## Code changes

- **✔️ Adding [params](../../csharp/language-reference/keywords/params.md) to a parameter**

- **❌ Changing a [struct](../../csharp/language-reference/keywords/struct.md) to a [class](../../csharp/language-reference/keywords/class.md) and vice versa**

- **❌ Adding the [checked](../../csharp/language-reference/keywords/virtual.md) keyword to a code block**

   This change may cause code that previously executed to throw an <xref:System.OverflowException> and is unacceptable.

- **❌ Removing [params](../../csharp/language-reference/keywords/params.md) from a parameter**

- **❌ Changing the order in which events are fired**

  Developers can reasonably expect events to fire in the same order, and developer code frequently depends on the order in which events are fired.

- **❌ Removing the raising of an event on a given action**

- **❌ Changing the number of times given events are called**

- **❌ Adding the <xref:System.FlagsAttribute> to an enumeration type**
