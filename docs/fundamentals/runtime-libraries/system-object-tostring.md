---
title: System.Object.ToString method
description: Learn about the System.Object.ToString method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
---
# System.Object.ToString method

[!INCLUDE [context](includes/context.md)]

<xref:System.Object.ToString%2A?displayProperty=nameWithType> is a common formatting method in .NET. It converts an object to its string representation so that it is suitable for display. (For information about formatting support in .NET, see [Formatting Types](../../standard/base-types/formatting-types.md).) Default implementations of the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method return the fully qualified name of the object's type.

> [!IMPORTANT]
> You may have reached this page by following the link from the member list of another type. That is because that type does not override <xref:System.Object.ToString%2A?displayProperty=nameWithType>. Instead, it inherits the functionality of the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method.

Types frequently override the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to provide a more suitable string representation of a particular type. Types also frequently overload the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to provide support for format strings or culture-sensitive formatting.

## The default Object.ToString() method

The default implementation of the <xref:System.Object.ToString%2A> method returns the fully qualified name of the type of the <xref:System.Object>, as the following example shows.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/tostring1.cs" interactive="try-dotnet-method" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/tostring1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/tostring1.vb" id="Snippet1":::

Because <xref:System.Object> is the base class of all reference types in .NET, this behavior is inherited by reference types that do not override the <xref:System.Object.ToString%2A> method. The following example illustrates this. It defines a class named `Object1` that accepts the default implementation of all <xref:System.Object> members. Its <xref:System.Object.ToString%2A> method returns the object's fully qualified type name.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/tostring2.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/tostring2.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/tostring2.vb" id="Snippet2":::

## Override the Object.ToString() method

Types commonly override the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to return a string that represents the object instance. For example, the base types such as <xref:System.Char>, <xref:System.Int32>, and <xref:System.String> provide <xref:System.Object.ToString%2A> implementations that return the string form of the value that the object represents. The following example defines a class, `Object2`, that overrides the <xref:System.Object.ToString%2A> method to return the type name along with its value.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/tostring3.cs" interactive="try-dotnet" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/tostring3.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/tostring3.vb" id="Snippet3":::

The following table lists the type categories in .NET and indicates whether or not they override the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method.

| Type category | Overrides Object.ToString() | Behavior |
|---------------|-----------------------------|----------|
| Class         | n/a                         | n/a      |
| Structure     | Yes (<xref:System.ValueType.ToString%2A?displayProperty=nameWithType>) | Same as `Object.ToString()` |
| Enumeration   | Yes (<xref:System.Enum.ToString?displayProperty=nameWithType>) | The member name |
| Interface     | No| n/a |
| Delegate      | No| n/a |

See the Notes to Inheritors section for additional information on overriding <xref:System.Object.ToString%2A>.

## Overload the ToString method

In addition to overriding the parameterless <xref:System.Object.ToString?displayProperty=nameWithType> method, many types overload the `ToString` method to provide versions of the method that accept parameters. Most commonly, this is done to provide support for variable formatting and culture-sensitive formatting.

The following example overloads the `ToString` method to return a result string that includes the value of various fields of an `Automobile` class. It defines four format strings: G, which returns the model name and year; D, which returns the model name, year, and number of doors; C, which returns the model name, year, and number of cylinders; and A, which returns a string with all four field values.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/tostringoverload1.cs" interactive="try-dotnet" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/tostringoverload1.fs" id="Snippet4":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/tostringoverload1.vb" id="Snippet4":::

The following example calls the overloaded <xref:System.Decimal.ToString(System.String,System.IFormatProvider)?displayProperty=nameWithType> method to display culture-sensitive formatting of a currency value.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/tostringoverload2.cs" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/tostringoverload2.fs" id="Snippet5":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/tostringoverload2.vb" id="Snippet5":::

For more information on format strings and culture-sensitive formatting, see [Formatting Types](../../standard/base-types/formatting-types.md). For the format strings supported by numeric values, see [Standard Numeric Format Strings](../../standard/base-types/standard-numeric-format-strings.md) and [Custom Numeric Format Strings](../../standard/base-types/custom-numeric-format-strings.md). For the format strings supported by date and time values, see [Standard Date and Time Format Strings](../../standard/base-types/standard-date-and-time-format-strings.md) and [Custom Date and Time Format Strings](../../standard/base-types/custom-date-and-time-format-strings.md).

## Extend the Object.ToString method

Because a type inherits the default <xref:System.Object.ToString%2A?displayProperty=nameWithType> method, you may find its behavior undesirable and want to change it. This is particularly true of arrays and collection classes. While you may expect the `ToString` method of an array or collection class to display the values of its members, it instead displays the type fully qualified type name, as the following example shows.

:::code language="csharp" source="./snippets/System/Object/ToString/csharp/array1.cs" interactive="try-dotnet-method" id="Snippet6":::
:::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/array1.fs" id="Snippet6":::
:::code language="vb" source="./snippets/System/Object/ToString/vb/array1.vb" id="Snippet6":::

You have several options to produce the result string that you'd like.

- If the type is an array, a collection object, or an object that implements the <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601> interfaces, you can enumerate its elements by using the `foreach` statement in C# or the `For Each...Next` construct in Visual Basic.

- If the class is not `sealed` (in C#) or `NotInheritable` (in Visual Basic), you can develop a wrapper class that inherits from the base class whose <xref:System.Object.ToString%2A?displayProperty=nameWithType> method you want to customize. At a minimum, this requires that you do the following:

  1. Implement any necessary constructors. Derived classes do not inherit their base class constructors.
  2. Override the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to return the result string that you'd like.

  The following example defines a wrapper class for the <xref:System.Collections.Generic.List%601> class. It overrides the <xref:System.Object.ToString%2A?displayProperty=nameWithType> method to display the value of each method of the collection rather than the fully qualified type name.

  :::code language="csharp" source="./snippets/System/Object/ToString/csharp/customize1.cs" interactive="try-dotnet" id="Snippet7":::
  :::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/customize1.fs" id="Snippet7":::
  :::code language="vb" source="./snippets/System/Object/ToString/vb/customize1.vb" id="Snippet7":::

- Develop an [extension method](../../standard/design-guidelines/extension-methods.md) that returns the result string that you want. Note that you can't override the default <xref:System.Object.ToString%2A?displayProperty=nameWithType> method in this way&mdash;that is, your extension class (in C#) or module (in Visual Basic) cannot have a parameterless method named `ToString` that's called in place of the original type's `ToString` method. You'll have to provide some other name for your parameterless `ToString` replacement.

  The following example defines two methods that extend the <xref:System.Collections.Generic.List%601> class: a parameterless `ToString2` method, and a `ToString` method with a <xref:System.String> parameter that represents a format string.

  :::code language="csharp" source="./snippets/System/Object/ToString/csharp/customize2.cs" interactive="try-dotnet" id="Snippet8":::
  :::code language="fsharp" source="./snippets/System/Object/ToString/fsharp/customize2.fs" id="Snippet8":::
  :::code language="vb" source="./snippets/System/Object/ToString/vb/customize2.vb" id="Snippet8":::

## Notes for the Windows Runtime

When you call the <xref:System.Object.ToString%2A> method on a class in the Windows Runtime, it provides the default behavior for classes that don't override <xref:System.Object.ToString%2A>. This is part of the support that .NET provides for the Windows Runtime (see [.NET Support for Windows Store Apps and Windows Runtime](/dotnet/standard/cross-platform/support-for-windows-store-apps-and-windows-runtime)). Classes in the Windows Runtime don't inherit <xref:System.Object>, and don't always implement a <xref:System.Object.ToString%2A>. However, they always appear to have <xref:System.Object.ToString%2A>, <xref:System.Object.Equals(System.Object)>, and <xref:System.Object.GetHashCode%2A> methods when you use them in your C# or Visual Basic code, and .NET provides a default behavior for these methods.

The common language runtime uses [IStringable.ToString](xref:Windows.Foundation.IStringable.ToString) on a Windows Runtime object before falling back to the default implementation of <xref:System.Object.ToString%2A?displayProperty=nameWithType>.

> [!NOTE]
> Windows Runtime classes that are written in C# or Visual Basic can override the <xref:System.Object.ToString%2A> method.

### The Windows Runtime and the IStringable Interface

The Windows Runtime includes an [IStringable](xref:Windows.Foundation.IStringable) interface whose single method, [IStringable.ToString](xref:Windows.Foundation.IStringable.ToString), provides basic formatting support comparable to that provided by <xref:System.Object.ToString%2A?displayProperty=nameWithType>. To prevent ambiguity, you should not implement [IStringable](xref:Windows.Foundation.IStringable) on managed types.

When managed objects are called by native code or by code written in languages such as JavaScript or C++/CX, they appear to implement [IStringable](xref:Windows.Foundation.IStringable). The common language runtime automatically routes calls from [IStringable.ToString](xref:Windows.Foundation.IStringable.ToString) to <xref:System.Object.ToString%2A?displayProperty=nameWithType> if [IStringable](xref:Windows.Foundation.IStringable) is not implemented on the managed object.

> [!WARNING]
> Because the common language runtime auto-implements [IStringable](xref:Windows.Foundation.IStringable) for all managed types in Windows Store apps, we recommend that you do not provide your own `IStringable` implementation. Implementing `IStringable` may result in unintended behavior when calling `ToString` from the Windows Runtime, C++/CX, or JavaScript.

If you do choose to implement [IStringable](xref:Windows.Foundation.IStringable) in a public managed type that's exported in a Windows Runtime component, the following restrictions apply:

- You can define the [IStringable](xref:Windows.Foundation.IStringable) interface only in a "class implements" relationship, as follows:

  ```csharp
  public class NewClass : IStringable
  ```

  ```vb
  Public Class NewClass : Implements IStringable
  ```

- You cannot implement [IStringable](xref:Windows.Foundation.IStringable) on an interface.

- You cannot declare a parameter to be of type [IStringable](xref:Windows.Foundation.IStringable).

- [IStringable](xref:Windows.Foundation.IStringable) cannot be the return type of a method, property, or field.

- You cannot hide your [IStringable](xref:Windows.Foundation.IStringable) implementation from base classes by using a method definition such as the following:

  ```csharp
  public class NewClass : IStringable
  {
     public new string ToString()
     {
        return "New ToString in NewClass";
     }
  }
  ```

  Instead, the [IStringable.ToString](xref:Windows.Foundation.IStringable.ToString) implementation must always override the base class implementation. You can hide a `ToString` implementation only by invoking it on a strongly typed class instance.

Under a variety of conditions, calls from native code to a managed type that implements [IStringable](xref:Windows.Foundation.IStringable) or hides its [ToString](xref:Windows.Foundation.IStringable.ToString) implementation can produce unexpected behavior.
