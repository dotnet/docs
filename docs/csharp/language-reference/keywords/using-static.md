---
title: "using static directive - C# Reference"
ms.date: 03/10/2017
helpviewer_keywords: 
  - "using static directive [C#]"
ms.assetid: 8b8f9e34-c75e-469b-ba85-6f2eb4090314
---
# using static directive (C# Reference)

The `using static` directive designates a type whose static members and nested types you can access without specifying a type name. Its syntax is:

```csharp
using static <fully-qualified-type-name>;
```

where *fully-qualified-type-name* is the name of the type whose static members and nested types can be referenced without specifying a type name. If you do not provide a fully qualified type name (the full namespace name along with the type name), C# generates compiler error [CS0246](../compiler-messages/cs0246.md): "The type or namespace name 'type/namespace' could not be found (are you missing a using directive or an assembly reference?)".

The `using static` directive applies to any type that has static members (or nested types), even if it also has instance members. However, instance members can only be invoked through the type instance.

The `using static` directive was introduced in C# 6.

## Remarks

Ordinarily, when you call a static member, you provide the type name along with the member name. Repeatedly entering the same type name to invoke members of the type can result in verbose, obscure code. For example, the following definition of a `Circle` class references a number of members of the <xref:System.Math> class.

[!code-csharp[using-static#1](~/samples/snippets/csharp/language-reference/keywords/using/using-static1.cs#1)]

By eliminating the need to explicitly reference the <xref:System.Math> class each time a member is referenced, the `using static` directive produces much cleaner code:

[!code-csharp[using-static#2](~/samples/snippets/csharp/language-reference/keywords/using/using-static2.cs#1)]

`using static` imports only accessible static members and nested types declared in the specified type.  Inherited members are not imported.  You can import from any named type with a using static directive, including Visual Basic modules.  If F# top-level functions appear in metadata as static members of a named type whose name is a valid C# identifier, then the F# functions can be imported.

 `using static` makes extension methods declared in the specified type available for extension method lookup.  However, the names of the extension methods are not imported into scope for unqualified reference in code.

 Methods with the same name imported from different types by different `using static` directives in the same compilation unit or namespace form a method group.  Overload resolution within these method groups follows normal C# rules.

## Example

The following example uses the `using static` directive to make the static members of the <xref:System.Console>, <xref:System.Math>, and <xref:System.String> classes available without having to specify their type name.

[!code-csharp[using-static#3](~/samples/snippets/csharp/language-reference/keywords/using/using-static3.cs)]

In the example, the `using static` directive could also have been applied to the <xref:System.Double> type. This would have made it possible to call the <xref:System.Double.TryParse(System.String,System.Double@)> method without specifying a type name. However, this creates less readable code, since it becomes necessary to check the `using static` statements to determine which numeric type's `TryParse` method is called.

## See also

- [using directive](using-directive.md)
- [C# Reference](../index.md)
- [C# Keywords](index.md)
- [Using Namespaces](../../programming-guide/namespaces/using-namespaces.md)
- [Namespaces](../../programming-guide/namespaces/index.md)
