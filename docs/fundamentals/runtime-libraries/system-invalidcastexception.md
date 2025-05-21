---
title: System.InvalidCastException class
description: Learn about the System.InvalidCastException class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
  - FSharp
ms.topic: article
---
# System.InvalidCastException class

[!INCLUDE [context](includes/context.md)]

.NET supports automatic conversion from derived types to their base types and back to the derived type, as well as from types that present interfaces to interface objects and back. It also includes a variety of mechanisms that support custom conversions. For more information, see [Type Conversion in .NET](../../standard/base-types/type-conversion.md).

An <xref:System.InvalidCastException> exception is thrown when the conversion of an instance of one type to another type is not supported. For example, attempting to convert a <xref:System.Char> value to a <xref:System.DateTime> value throws an <xref:System.InvalidCastException> exception. It differs from an <xref:System.OverflowException> exception, which is thrown when a conversion of one type to another is supported, but the value of the source type is outside the range of the target type. An <xref:System.InvalidCastException> exception is caused by developer error and should not be handled in a `try/catch` block. Instead, the cause of the exception should be eliminated.

For information about conversions supported by the system, see the <xref:System.Convert> class. For errors that occur when the destination type can store source type values but is not large enough to store a specific source value, see the <xref:System.OverflowException> exception.

> [!NOTE]
> In many cases, your language compiler detects that no conversion exists between the source type and the target type and issues a compiler error.

Some of the conditions under which an attempted conversion throws an <xref:System.InvalidCastException> exception are discussed in the following sections.

For an explicit reference conversion to be successful, the source value must be `null`, or the object type referenced by the source argument must be convertible to the destination type by an implicit reference conversion.

The following intermediate language (IL) instructions throw an <xref:System.InvalidCastException> exception:

- `castclass`
- `refanyval`
- `unbox`

<xref:System.InvalidCastException> uses the HRESULT `COR_E_INVALIDCAST`, which has the value 0x80004002.

For a list of initial property values for an instance of <xref:System.InvalidCastException>, see the <xref:System.InvalidCastException.%23ctor%2A> constructors.

## Primitive types and IConvertible

You directly or indirectly call a primitive type's <xref:System.IConvertible> implementation that does not support a particular conversion. For example, trying to convert a <xref:System.Boolean> value to a <xref:System.Char> or a <xref:System.DateTime> value to an <xref:System.Int32> throws an <xref:System.InvalidCastException> exception. The following example calls both the <xref:System.Boolean.System%23IConvertible%23ToChar%2A?displayProperty=nameWithType> and <xref:System.Convert.ToChar%28System.Boolean%29?displayProperty=nameWithType> methods to convert a <xref:System.Boolean> value to a <xref:System.Char>. In both cases, the method call throws an <xref:System.InvalidCastException> exception.

:::code language="csharp" source="./snippets/System/InvalidCastException/Overview/csharp/iconvertible1.cs" interactive="try-dotnet" id="Snippet2":::
:::code language="fsharp" source="./snippets/System/InvalidCastException/Overview/fsharp/iconvertible1.fs" id="Snippet2":::
:::code language="vb" source="./snippets/System/InvalidCastException/Overview/vb/iconvertible1.vb" id="Snippet2":::

Because the conversion is not supported, there is no workaround.

## The Convert.ChangeType method

You've called the <xref:System.Convert.ChangeType%2A?displayProperty=nameWithType> method to convert an object from one type to another, but one or both types don't implement the <xref:System.IConvertible> interface.

In most cases, because the conversion is not supported, there is no workaround. In some cases, a possible workaround is to manually assign property values from the source type to similar properties of a the target type.

## Narrowing conversions and IConvertible implementations

Narrowing operators define the explicit conversions supported by a type. A casting operator in C# or the `CType` conversion method in Visual Basic (if `Option Strict` is on)  is required to perform the conversion.

However, if neither the source type nor the target type defines an explicit or narrowing conversion between the two types, and the <xref:System.IConvertible> implementation of one or both types doesn't support a conversion from the source type to the target type, an <xref:System.InvalidCastException> exception is thrown.

In most cases, because the conversion is not supported, there is no workaround.

## Downcasting

You're downcasting, that is, trying to convert an instance of a base type to one of its derived types. In the following example, trying to convert a `Person` object to a `PersonWithID` object fails.

:::code language="csharp" source="./snippets/System/InvalidCastException/Overview/csharp/basetoderived1.cs" interactive="try-dotnet" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/InvalidCastException/Overview/fsharp/basetoderived1.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/InvalidCastException/Overview/vb/basetoderived1.vb" id="Snippet1":::

As the example shows, the downcast succeeds only if the `Person` object was created by an upcast from a `PersonWithId` object to a `Person` object, or if the `Person` object is `null`.

## Conversion from an interface object

You're attempting to convert an interface object to a type that implements that interface, but the target type is not the same type or a base class of the type from which the interface object was originally derived. The following example throws an <xref:System.InvalidCastException> exception when it attempts to convert an <xref:System.IFormatProvider> object to a <xref:System.Globalization.DateTimeFormatInfo> object. The conversion fails because although the <xref:System.Globalization.DateTimeFormatInfo> class implements the <xref:System.IFormatProvider> interface, the <xref:System.Globalization.DateTimeFormatInfo> object is not related to the <xref:System.Globalization.CultureInfo> class from which the interface object was derived.

:::code language="csharp" source="./snippets/System/InvalidCastException/Overview/csharp/Interface1.cs" id="Snippet3":::
:::code language="fsharp" source="./snippets/System/InvalidCastException/Overview/fsharp/Interface1.fs" id="Snippet3":::
:::code language="vb" source="./snippets/System/InvalidCastException/Overview/vb/Interface1.vb" id="Snippet3":::

As the exception message indicates, the conversion would succeed only if the interface object is converted back to an instance of the original type, in this case a  <xref:System.Globalization.CultureInfo>. The conversion would also succeed if the interface object is converted to an instance of a base type of the original type.

## String conversions

You're trying to convert a value or an object to its string representation by using a casting operator in C#. In the following example, both the attempt to cast a <xref:System.Char> value to a string and the attempt to cast an integer to a string throw an <xref:System.InvalidCastException> exception.

:::code language="csharp" source="./snippets/System/InvalidCastException/Overview/csharp/ToString1.cs" id="Snippet4":::
:::code language="fsharp" source="./snippets/System/InvalidCastException/Overview/fsharp/ToString1.fs" id="Snippet4":::

> [!NOTE]
> Using the Visual Basic `CStr` operator to convert a value of a primitive type to a string succeeds. The operation does not throw an <xref:System.InvalidCastException> exception.

To successfully convert an instance of any type to its string representation, call its `ToString` method, as the following example does. The `ToString` method is always present, since the <xref:System.Object.ToString%2A> method is defined by the <xref:System.Object> class and therefore is either inherited or overridden by all managed types.

:::code language="csharp" source="./snippets/System/InvalidCastException/Overview/csharp/ToString2.cs" interactive="try-dotnet" id="Snippet5":::
:::code language="fsharp" source="./snippets/System/InvalidCastException/Overview/fsharp/ToString2.fs" id="Snippet5":::

## Visual Basic 6.0 migration

You're upgrading a Visual Basic 6.0 application with a call to a custom event in a user control to Visual Basic .NET, and an <xref:System.InvalidCastException> exception is thrown with the message, "Specified cast is not valid." To eliminate this exception, change the line of code in your form (such as `Form1`)

```vb
Call UserControl11_MyCustomEvent(UserControl11, New UserControl1.MyCustomEventEventArgs(5))
```

and replace it with the following line of code:

```vb
Call UserControl11_MyCustomEvent(UserControl11(0), New UserControl1.MyCustomEventEventArgs(5))
```
