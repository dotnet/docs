---
title: "Tuples in Visual Basic"
ms.custom: ""
ms.date: 04/23/2017
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "tuples [Visual Basic]"
ms.assetid: 3e66cd1b-3432-4e1d-8c37-5ebacae8f53f
author: "rpetrusha"
ms.author: "ronpet"
---
# Tuples (Visual Basic)

Starting with Visual Basic 2017, the Visual Basic language offers built-in support for tuples that makes creating tuples and accessing the elements of tuples easier. A tuple is a light-weight data structure that has a specific number and sequence of values. When you instantiate the tuple, you define the number and the data type of each value (or element). For example, a 2-tuple (or pair) has two elements. The first might be a `Boolean` value, while the second is a `String`. Because tuples make it easy to store multiple values in a single object, they are often used as a lightweight way to return multiple values from a method.

> [!IMPORTANT]
> Tuple support requires the <xref:System.ValueTuple> type. If the .NET Framework 4.7 is not installed, you must add the NuGet package `System.ValueTuple`, which is available on the NuGet Gallery. Without this package, you may get a compilation error similar to, "Predefined type 'ValueTuple(Of,,,)' is not defined or imported."

## Instantiating and using a tuple

You instantiate a tuple by enclosing its comma-delimited values im parentheses. Each of those values then becomes a field of the tuple. For example, the following code defines a triple (or 3-tuple) with a `Date` as its first value, a `String` as its second, and a `Boolean` as its third.

[!code-vb[Instantiate](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple1.vb#1)]

By default, the name of each field in a tuple consists of the string `Item` along with the field's one-based position in the tuple. For this 3-tuple, the `Date` field is `Item1`, the `String` field is `Item2`, and the `Boolean` field is `Item3`. The following example displays the values of fields of the tuple instantiated in the previous line of code

[!code-vb[Instantiate](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple1.vb#2)]

The fields of a Visual Basic tuple are read-write; after you've instantiated a tuple, you can modify its values. The following example modifies two of the three fields of the tuple created in the previous example and displays the result.

[!code-vb[Instantiate](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple1.vb#3)]

## Instantiating and using a named tuple

Rather than using default names for a tuple's fields, you can instantiate a *named tuple* by assigning your own names to the tuple's elements. The tuple's fields can then be accessed by their assigned names *or* by their default names. The following example instantiates the same 3-tuple as previously, except that it explicitly names the first field `EventDate`, the second `Name`, and the third `IsHoliday`. It then displays the field values, modifies them, and displays the field values again.

[!code-vb[Instantiate](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple1.vb#4)]

## Inferred tuple element names

Starting with Visual Basic 15.3, Visual Basic can infer the names of tuple elements; you do not have to assign them explicitly. Inferred tuple names are useful when you initialize a tuple from a set of variables, and you want the tuple element name to be the same as the variable name. 

The following example creates a `stateInfo` tuple that contains three explicitly named elements, `state`, `stateName`, and `capital`. Note that, in naming the elements, the tuple initialization statement simply assigns the named elements the values of the identically named variables.

[!code-vb[ExplicitlyNamed](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/named-tuples/program.vb#1)]
 
Because elements and variables have the same name, the Visual Basic compiler can infer the names of the fields, as the following example shows.

[!code-vb[ExplicitlyNamed](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/named-tuples/program.vb#2)]

To enable interred tuple element names, you must define the version of the Visual Basic compiler to use in your Visual Basic project (\*.vbproj) file: 

```xml 
<PropertyGroup> 
  <LangVersion>15.3</LangVersion> 
</PropertyGroup> 
```

The version number can be any version of the Visual Basic compiler starting with 15.3. Rather than hard-coding a specific compiler version, you can also specify "Latest" as the value of `LangVersion` to compile with the most recent version of the Visual Basic compiler installed on your system.

In some cases, the Visual Basic compiler cannot infer the tuple element name from the candidate name, and the tuple field can only be referenced using its default name, such as `Item1`, `Item2`, etc. These include:

- The candidate name is the same as the name of a tuple member, such as `Item3`, `Rest`, or `ToString`.

- The candidate name is duplicated in the tuple.
 
When field name inference fails, Visual Basic does not generate a compiler error, nor is an exception thrown at runtime. Instead, tuple fields must be referenced by their predefined names, such as `Item1` and `Item2`. 
  
## Tuples versus structures

A Visual Basic tuple is a value type that is an instance of one of the a **System.ValueTuple** generic types. For example, the `holiday` tuple defined in the previous example is an instance of the <xref:System.ValueTuple%603> structure. It is designed to be a lightweight container for data. Since the tuple aims to make it easy to create an object with multiple data items, it lacks some of the features that a custom structure might have. These include:

- Custom members. You cannot define your own properties, methods, or events for a tuple.

- Validation. You cannot validate the data assigned to fields.

- Immutability. Visual Basic tuples are mutable. In contrast, a custom structure allows you to control whether an instance is mutable or immutable.

If custom members, property and field validation, or immutability are important, you should use the Visual Basic [Structure](../../../language-reference/statements/structure-statement.md) statement to define a custom value type.

A Visual Basic tuple does inherit the members of its **ValueTuple** type. In addition to its fields, these include the following methods:

| Member | Description |
| ---|---|
| CompareTo | Compares the current tuple to another tuple with the same number of elements. |
| Equals | Determines whether the current tuple is equal to another tuple or object. |
| GetHashCode | Calculates the hash code for the current instance. |
| ToString | Returns the string representation of this tuple, which takes the form `(Item1, Item2...)`, where `Item1` and `Item2` represent the values of the tuple's fields. |

In addition, the **ValueTuple** types implement <xref:System.Collections.IStructuralComparable> and <xref:System.Collections.IStructuralEquatable> interfaces, which allow you to define customer comparers.

## Assignment and tuples

Visual Basic supports assignment between tuple types that have the same number of fields. The field types can be converted if one of the following is true:

- The source and target field are of the same type.

- A widening (or implicit) conversion of the source type to the target type is defined. 

- `Option Strict` is `On`, and a narrowing (or explicit) conversion of the source type to the target type is defined. This conversion can throw an exception if the source value is outside the range of the target type.

Other conversions are not considered for assignments. Let's look at the kinds of assignments that are allowed between tuple types.

Consider these variables used in the following examples:

[!code-vb[Assign](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple3.vb#1)]

The first two variables, `unnamed` and `anonymous`, do not have semantic names provided for the fields. Their field names are the default `Item1` and `Item2`. The last two variables, `named` and `differentName` have semantic field names. Note that these two tuples have different names for the fields.

All four of these tuples have the same number of fields (referred to as 'arity'), and the types of those fields are identical. Therefore, all of these assignments work:

[!code-vb[Assign](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple3.vb#2)]

Notice that the names of the tuples are not assigned. The values of the fields are assigned following the order of the fields in the tuple.

Finally, notice that we can assign the `named` tuple to the `conversion` tuple, even though the first field of `named` is an `Integer`, and the first field of `conversion` is a `Long`. This assignment succeeds because converting an `Integer` to a `Long` is a widening conversion.

[!code-vb[Assign](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple3.vb#3)]

Tuples with different numbers of fields are not assignable:

```vb
' Does not compile.
' VB30311: Value of type '(Integer, Integer, Integer)' cannot be converted
'          to '(Answer As Integer, Message As String)'
var differentShape = (1, 2, 3)
named = differentShape
```

## Tuples as method return values

A method can return only a single value. Frequently, though, you'd like a method call to return multiple values. There are several ways to work around this limitation:

- You can create a custom class or structure whose properties or fields represent values returned by the method. Thus is a heavyweight solution; it requires that you define a custom type whose only purpose is to retrieve values from a method call.

- You can return a single value from the method, and return the remaining values by passing them by reference to the method. This involves the overhead of instantiating a variable and risks inadvertently overwriting the value of the variable that you pass by reference.

- You can use a tuple, which provides a lightweight solution to retrieving multiple return values.

For example, the **TryParse** methods in .NET return a `Boolean` value that indicates whether the parsing operation succeeded. The result of the parsing operation is returned in a variable passed by reference to the method. Normally, a call to the a parsing method such as <xref:System.Int32.TryParse%2A?displayProperty=nameWithType> looks like the following:

[!code-vb[Return](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple-returns.vb#1)]

We can return a tuple from the parsing operation if we wrap the call to the <xref:System.Int32.TryParse%2A?displayProperty=nameWithType> method in our own method. In the following example, `NumericLibrary.ParseInteger` calls the <xref:System.Int32.TryParse%2A?displayProperty=nameWithType> method and returns a named tuple with two elements. 

[!code-vb[Return](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple-returns.vb#2)]

You can then call the method with code like the following:

[!code-vb[Return](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple-returns.vb#3)]

## Visual Basic tuples and tuples in the .NET Framework

A Visual Basic tuple is an instance of one of the **System.ValueTuple** generic types, which were introduced in the .NET Framework 4.7. The .NET Framework also includes a set of generic **System.Tuple** classes. These classes, however, differ from Visual Basic tuples and the **System.ValueTuple** generic types in a number of ways:

- The elements of the **Tuple** classes are properties named `Item1`, `Item2`, and so on. In Visual Basic tuples and the **ValueTuple** types, tuple elements are fields.

- You cannot assign meaningful names to the elements of a **Tuple** instance or of a **ValueTuple** instance. Visual Basic allows you to assign names that communicate the meaning of the fields.

- The properties of a **Tuple** instance are read-only; the tuples are immutable. In Visual Basic tuples and the **ValueTuple** types, tuple fields are read-write; the tuples are mutable.

- The generic **Tuple** types are reference types. Using these **Tuple** types means allocating objects. On hot paths, this can have a measurable impact on your application's performance. Visual Basic tuples and the **ValueTuple** types are value types.

Extension methods in the <xref:System.TupleExtensions> class make it easy to convert between Visual Basic tuples and .NET **Tuple** objects. The **ToTuple** method converts a Visual Basic tuple to a .NET **Tuple** object, and the **ToValueTuple** method converts a .NET **Tuple** object to a Visual Basic tuple.

The following example creates a tuple, converts it to a .NET **Tuple** object, and converts it back to a Visual Basic tuple. The example then compares this tuple with the original one to ensure that they are equal.

[!code-vb[Convert](../../../../../samples/snippets/visualbasic/programming-guide/language-features/data-types/tuple2.vb#1)]

## See also

[Visual Basic Language Reference](index.md)  
