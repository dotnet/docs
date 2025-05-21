---
title: System.Object.Equals method
description: Learn about the System.Object.Equals method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Object.Equals method

[!INCLUDE [context](includes/context.md)]

This article pertains to the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method.

The type of comparison between the current instance and the `obj` parameter depends on whether the current instance is a reference type or a value type.

- If the current instance is a reference type, the <xref:System.Object.Equals(System.Object)> method tests for reference equality, and a call to the <xref:System.Object.Equals(System.Object)> method is equivalent to a call to the <xref:System.Object.ReferenceEquals%2A> method. Reference equality means that the object variables that are compared refer to the same object. The following example illustrates the result of such a comparison. It defines a `Person` class, which is a reference type, and calls the `Person` class constructor to instantiate two new `Person` objects, `person1a` and `person2`, which have the same value. It also assigns `person1a` to another object variable, `person1b`. As the output from the example shows, `person1a` and `person1b` are equal because they reference the same object. However, `person1a` and `person2` are not equal, although they have the same value.

  :::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals_ref.cs" interactive="try-dotnet" id="Snippet2":::
  :::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals_ref.fs" id="Snippet2":::
  :::code language="vb" source="./snippets/System/Object/Equals/vb/equals_ref.vb" id="Snippet2":::

- If the current instance is a value type, the <xref:System.Object.Equals(System.Object)> method tests for value equality. Value equality means the following:

  - The two objects are of the same type. As the following example shows, a <xref:System.Byte> object that has a value of 12 does not equal an <xref:System.Int32> object that has a value of 12, because the two objects have different run-time types.

    :::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals_val1.cs" interactive="try-dotnet-method" id="Snippet3":::
    :::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals_val1.fs" id="Snippet3":::
    :::code language="vb" source="./snippets/System/Object/Equals/vb/equals_val1.vb" id="Snippet3":::

  - The values of the public and private fields of the two objects are equal. The following example tests for value equality. It defines a `Person` structure, which is a value type, and calls the `Person` class constructor to instantiate two new `Person` objects, `person1` and `person2`, which have the same value. As the output from the example shows, although the two object variables refer to different objects, `person1` and `person2` are equal because they have the same value for the private `personName` field.

    :::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals_val2.cs" id="Snippet4":::
    :::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals_val2.fs" id="Snippet4":::
    :::code language="vb" source="./snippets/System/Object/Equals/vb/equals_val2.vb" id="Snippet4":::

Because the <xref:System.Object> class is the base class for all types in .NET, the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method provides the default equality comparison for all other types. However, types often override the <xref:System.Object.Equals%2A> method to implement value equality. For more information, see the Notes for Callers and Notes for Inheritors sections.

## Notes for the Windows Runtime

When you call the <xref:System.Object.Equals(System.Object)> method overload on a class in the Windows Runtime, it provides the default behavior for classes that don't override <xref:System.Object.Equals(System.Object)>. This is part of the support that .NET provides for the Windows Runtime (see [.NET Support for Windows Store Apps and Windows Runtime](/dotnet/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime)). Classes in the Windows Runtime don't inherit <xref:System.Object>, and currently don't implement an <xref:System.Object.Equals(System.Object)> method. However, they appear to have <xref:System.Object.ToString%2A>, <xref:System.Object.Equals(System.Object)>, and <xref:System.Object.GetHashCode%2A> methods when you use them in your C# or Visual Basic code, and .NET provides the default behavior for these methods.

> [!NOTE]
> Windows Runtime classes that are written in C# or Visual Basic can override the <xref:System.Object.Equals(System.Object)> method overload.

## Notes for callers

Derived classes frequently override the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method to implement value equality. In addition, types also frequently provide an additional strongly typed overload to the `Equals` method, typically by implementing the <xref:System.IEquatable%601> interface. When you call the `Equals` method to test for equality, you should know whether the current instance overrides <xref:System.Object.Equals%2A?displayProperty=nameWithType> and understand how a particular call to an `Equals` method is resolved. Otherwise, you may be performing a test for equality that is different from what you intended, and the method may return an unexpected value.

The following example provides an illustration. It instantiates three <xref:System.Text.StringBuilder> objects with identical strings, and then makes four calls to `Equals` methods. The first method call returns `true`, and the remaining three return `false`.

:::code language="csharp" source="./snippets/System/Object/Equals/csharp/equalssb1.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equalssb1.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/Object/Equals/vb/equalssb1.vb" id="Snippet5":::

In the first case, the strongly typed <xref:System.Text.StringBuilder.Equals(System.Text.StringBuilder)?displayProperty=nameWithType> method overload, which tests for value equality, is called. Because the strings assigned to the two <xref:System.Text.StringBuilder> objects are equal, the method returns `true`. However, <xref:System.Text.StringBuilder> does not override <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>. Because of this, when the <xref:System.Text.StringBuilder> object is cast to an <xref:System.Object>, when a <xref:System.Text.StringBuilder> instance is assigned to a variable of type <xref:System.Object>, and when the <xref:System.Object.Equals(System.Object,System.Object)?displayProperty=nameWithType> method is passed two <xref:System.Text.StringBuilder> objects, the default <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method is called. Because <xref:System.Text.StringBuilder> is a reference type, this is equivalent to passing the two <xref:System.Text.StringBuilder> objects to the <xref:System.Object.ReferenceEquals%2A> method. Although all three <xref:System.Text.StringBuilder> objects contain identical strings, they refer to three distinct objects. As a result, these three method calls return `false`.

You can compare the current object to another object for reference equality by calling the <xref:System.Object.ReferenceEquals%2A> method. In Visual Basic, you can also use the `is` keyword (for example, `If Me Is otherObject Then ...`).

## Notes for inheritors

When you define your own type, that type inherits the functionality defined by the `Equals` method of its base type. The following table lists the default implementation of the `Equals` method for the major categories of types in .NET.

|Type category|Equality defined by|Comments|
|-------------------|-------------------------|--------------|
|Class derived directly from <xref:System.Object>|<xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>|Reference equality; equivalent to calling <xref:System.Object.ReferenceEquals%2A?displayProperty=nameWithType>.|
|Structure|<xref:System.ValueType.Equals%2A?displayProperty=nameWithType>|Value equality; either direct byte-by-byte comparison or field-by-field comparison using reflection.|
|Enumeration|<xref:System.Enum.Equals%2A?displayProperty=nameWithType>|Values must have the same enumeration type and the same underlying value.|
|Delegate|<xref:System.MulticastDelegate.Equals%2A?displayProperty=nameWithType>|Delegates must have the same type with identical invocation lists.|
|Interface|<xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>|Reference equality.|

For a value type, you should always override <xref:System.Object.Equals%2A>, because tests for equality that rely on reflection offer poor performance. You can also override the default implementation of <xref:System.Object.Equals%2A> for reference types to test for value equality instead of reference equality and to define the precise meaning of value equality. Such implementations of <xref:System.Object.Equals%2A> return `true` if the two objects have the same value, even if they are not the same instance. The type's implementer decides what constitutes an object's value, but it is typically some or all the data stored in the instance variables of the object. For example, the value of a <xref:System.String> object is based on the characters of the string; the <xref:System.String.Equals(System.Object)?displayProperty=nameWithType> method overrides the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method to return `true` for any two string instances that contain the same characters in the same order.

The following example shows how to override the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method to test for value equality. It overrides the <xref:System.Object.Equals%2A> method for the `Person` class. If `Person` accepted its base class implementation of equality, two `Person` objects would be equal only if they referenced a single object. However, in this case, two `Person` objects are equal if they have the same value for the `Person.Id` property.

:::code language="csharp" source="./snippets/System/Object/Equals/csharp/equalsoverride.cs" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equalsoverride.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Object/Equals/vb/equalsoverride.vb" id="Snippet6":::

In addition to overriding <xref:System.Object.Equals%2A>, you can implement the <xref:System.IEquatable%601> interface to provide a strongly typed test for equality.

The following statements must be true for all implementations of the <xref:System.Object.Equals(System.Object)> method. In the list, `x`, `y`, and `z` represent object references that are not **null**.

- `x.Equals(x)` returns `true`.

- `x.Equals(y)` returns the same value as `y.Equals(x)`.

- `x.Equals(y)` returns `true` if both `x` and `y` are `NaN`.

- If `(x.Equals(y) && y.Equals(z))` returns `true`, then `x.Equals(z)` returns `true`.

- Successive calls to `x.Equals(y)` return the same value as long as the objects referenced by `x` and `y` are not modified.

- `x.Equals(null)` returns `false`.

Implementations of <xref:System.Object.Equals%2A> must not throw exceptions; they should always return a value. For example, if `obj` is `null`, the <xref:System.Object.Equals%2A> method should return `false` instead of throwing an <xref:System.ArgumentNullException>.

Follow these guidelines when overriding <xref:System.Object.Equals(System.Object)>:

- Types that implement <xref:System.IComparable> must override <xref:System.Object.Equals(System.Object)>.

- Types that override <xref:System.Object.Equals(System.Object)> must also override <xref:System.Object.GetHashCode%2A>; otherwise, hash tables  might not work correctly.

- You should consider implementing the <xref:System.IEquatable%601> interface to support strongly typed tests for equality. Your <xref:System.IEquatable%601.Equals%2A?displayProperty=nameWithType> implementation should return results that are consistent with <xref:System.Object.Equals%2A>.

- If your programming language supports operator overloading and you overload the equality operator for a given type, you must also override the <xref:System.Object.Equals(System.Object)> method to return the same result as the equality operator. This  helps ensure that class library code that uses <xref:System.Object.Equals%2A> (such as <xref:System.Collections.ArrayList> and <xref:System.Collections.Hashtable>) behaves in a manner that is consistent with the way the equality operator is used by application code.

### Guidelines for reference types

The following guidelines apply to overriding <xref:System.Object.Equals(System.Object)> for a reference type:

- Consider overriding <xref:System.Object.Equals%2A> if the semantics of the type are based on the fact that the type represents some value(s).

- Most reference types must not overload the equality operator, even if they override <xref:System.Object.Equals%2A>. However, if you are implementing a reference type that is intended to have value semantics, such as a complex number type, you must override the equality operator.

- You should not override <xref:System.Object.Equals%2A> on a mutable reference type. This is because overriding <xref:System.Object.Equals%2A> requires that you also override the <xref:System.Object.GetHashCode%2A> method, as discussed in the previous section. This means that the hash code of an instance of a mutable reference type can change during its lifetime, which can cause the object to be lost in a hash table.

### Guidelines for value types

The following guidelines apply to overriding <xref:System.Object.Equals(System.Object)> for a value type:

- If you are defining a value type that includes one or more fields whose values are reference types, you should override <xref:System.Object.Equals(System.Object)>. The <xref:System.Object.Equals(System.Object)> implementation provided by <xref:System.ValueType> performs a byte-by-byte comparison for value types whose fields are all value types, but it uses reflection to perform a field-by-field comparison of value types whose fields include reference types.

- If you override <xref:System.Object.Equals%2A> and your development language supports operator overloading, you must overload the equality operator.

- You should implement the <xref:System.IEquatable%601> interface. Calling the strongly typed <xref:System.IEquatable%601.Equals%2A?displayProperty=nameWithType> method avoids boxing the `obj` argument.

## Examples

The following example shows a `Point` class that overrides the <xref:System.Object.Equals%2A> method to provide value equality, and a `Point3D` class that is derived from `Point`. Because `Point` overrides <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> to test for value equality, the <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> method is not called. However, `Point3D.Equals` calls `Point.Equals` because `Point` implements <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> in a manner that provides value equality.

:::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals2.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals2.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Object/Equals/vb/equals2.vb" id="Snippet1":::

The `Point.Equals` method checks to make sure that the `obj` argument is not **null** and that it references an instance of the same type as this object. If either check fails, the method returns `false`.

The `Point.Equals` method calls the <xref:System.Object.GetType%2A> method to determine whether the run-time types of the two objects are identical. If the method used a check of the form `obj is Point` in C# or `TryCast(obj, Point)` in Visual Basic, the check would return `true` in cases where `obj` is an instance of a derived class of `Point`, even though `obj` and the current instance are not of the same run-time type. Having verified that both objects are of the same type, the method casts `obj` to type `Point` and returns the result of comparing the instance fields of the two objects.

In `Point3D.Equals`, the inherited `Point.Equals` method, which overrides <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>, is invoked before anything else is done. Because `Point3D` is a sealed class (`NotInheritable` in Visual Basic), a check in the form `obj is Point` in C# or `TryCast(obj, Point)` in Visual Basic is adequate to ensure that `obj` is a `Point3D` object. If it is a `Point3D` object, it is cast to a `Point` object and passed to the base class implementation of <xref:System.Object.Equals%2A>. Only when the inherited `Point.Equals` method returns `true` does the method compare the `z` instance fields introduced in the derived class.

The following example defines a `Rectangle` class that internally implements a rectangle as two `Point` objects. The `Rectangle` class also overrides <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> to provide for value equality.

:::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals3.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals3.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Object/Equals/vb/equals3.vb" id="Snippet1":::

Some languages such as C# and Visual Basic support operator overloading. When a type overloads the equality operator, it must also override the <xref:System.Object.Equals(System.Object)> method to provide the same functionality. This is typically accomplished by writing the <xref:System.Object.Equals(System.Object)> method in terms of the overloaded equality operator, as in the following example.

:::code language="csharp" source="./snippets/System/Object/Equals/csharp/equals4.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Object/Equals/fsharp/equals4.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Object/Equals/vb/equals4.vb" id="Snippet1":::

Because `Complex` is a value type, it cannot be derived from. Therefore, the override to <xref:System.Object.Equals(System.Object)> method need not call <xref:System.Object.GetType%2A> to determine the precise run-time type of each object, but can instead use the `is` operator in C# or the `TypeOf` operator in Visual Basic to check the type of the `obj` parameter.
