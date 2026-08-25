---
description: "Learn more about: Apply attributes"
title: "Applying Attributes"
ms.date: "03/02/2026"
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "assemblies [.NET], attributes"
  - "attributes [.NET], applying"
ms.topic: how-to
ai-usage: ai-assisted
---
# Apply attributes

Use the following process to apply an attribute to an element of your code.

1. Define a new attribute or use an existing .NET attribute.

2. Apply the attribute to the code element by placing it immediately before the element.

     Each language has its own attribute syntax. In C++ and C#, the attribute is surrounded by square brackets and separated from the element by white space, which can include a line break. In Visual Basic, the attribute is surrounded by angle brackets and must be on the same logical line; the line continuation character can be used if a line break is desired.

3. Specify positional parameters and named parameters for the attribute.

     *Positional* parameters are required and must come before any named parameters; they correspond to the parameters of one of the attribute's constructors. *Named* parameters are optional and correspond to read/write properties of the attribute. In C++, and C#, specify `name=value` for each optional parameter, where `name` is the name of the property. In Visual Basic, specify `name:=value`.

 The attribute is emitted into metadata when you compile your code and is available to the common language runtime and any custom tool or application through the runtime reflection services.

 By convention, all attribute names end with "Attribute". However, several languages that target the runtime, such as Visual Basic and C#, do not require you to specify the full name of an attribute. For example, if you want to initialize <xref:System.ObsoleteAttribute?displayProperty=nameWithType>, you only need to reference it as **Obsolete**.

## Valid attribute arguments

When you pass arguments to an attribute, use one of the following kinds of expressions:

- Constant expressions (literals, `const`/`Const` values, and enum values).
- Type expressions (`typeof` in C#, `GetType` in Visual Basic).
- Name expressions (`nameof` in C#, `NameOf` in Visual Basic), which produce string constants at compile time.
- Array creation expressions of an attribute parameter type that use only the preceding expressions as element values.

The following types are valid as attribute parameter types:

- Simple types (C# keyword / Visual Basic keyword / .NET runtime type):

  | C# | Visual Basic | .NET runtime type |
  |----|-------------|-------------------|
  | `bool` | `Boolean` | <xref:System.Boolean> |
  | `byte` | `Byte` | <xref:System.Byte> |
  | `char` | `Char` | <xref:System.Char> |
  | `double` | `Double` | <xref:System.Double> |
  | `float` | `Single` | <xref:System.Single> |
  | `int` | `Integer` | <xref:System.Int32> |
  | `long` | `Long` | <xref:System.Int64> |
  | `short` | `Short` | <xref:System.Int16> |
  | `string` | `String` | <xref:System.String> |

- `object` (in C#, when the value is one of the valid attribute argument types or a single-dimensional array of them).
- <xref:System.Type>.
- Enum types that are accessible at the usage site.
- Single-dimensional arrays of any of the preceding types.

> [!NOTE]
> The types `sbyte`, `ushort`, `uint`, `ulong`, `decimal`, `nint`, and `nuint` aren't valid attribute parameter types, even though they support literal constants.

The following examples show valid attribute arguments:

```csharp
[MyAttr(true)]                            // bool literal
[MyAttr(42)]                              // int literal
[MyAttr("hello")]                         // string literal
[MyAttr(MyEnum.Value)]                    // enum value
[MyAttr(typeof(string))]                  // typeof expression
[MyAttr(nameof(MyClass))]                 // nameof expression (string constant)
[MyAttr(new int[] { 1, 2, 3 })]          // array of constants
[MyAttr(new string[] { "a", "b" })]      // array of strings
```

```vb
<MyAttr(True)>                            ' Boolean literal
<MyAttr(42)>                              ' Integer literal
<MyAttr("hello")>                         ' String literal
<MyAttr(MyEnum.Value)>                    ' Enum value
<MyAttr(GetType(String))>                 ' GetType expression
<MyAttr(NameOf(MyClass))>                 ' NameOf expression (string constant)
<MyAttr(New Integer() {1, 2, 3})>         ' Array of constants
```

The following examples show arguments that cause a compiler error:

```csharp
string value = "test";
[MyAttr(value)]        // Error CS0182: not a constant expression
[MyAttr(GetValue())]   // Error CS0182: method calls aren't allowed
```

## Apply an attribute to a method

 The following code example shows how to use <xref:System.ObsoleteAttribute?displayProperty=fullName>, which marks code as obsolete. The string `"Will be removed in next version"` is passed to the attribute. This attribute causes a compiler warning that displays the passed string when code that the attribute describes is called.

 [!code-csharp[Conceptual.Attributes.Usage#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source1.cs#3)]
 [!code-vb[Conceptual.Attributes.Usage#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source1.vb#3)]

## Apply attributes at the assembly level

 If you want to apply an attribute at the assembly level, use the `assembly` (`Assembly` in Visual Basic) keyword. The following code shows the <xref:System.Reflection.AssemblyTitleAttribute> applied at the assembly level.

 [!code-csharp[Conceptual.Attributes.Usage#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source1.cs#2)]
 [!code-vb[Conceptual.Attributes.Usage#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source1.vb#2)]

 When this attribute is applied, the string `"My Assembly"` is placed in the assembly manifest in the metadata portion of the file. You can view the attribute either by using the [IL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) or by creating a custom program to retrieve the attribute.

## See also

- [Attributes](index.md)
- [Retrieving Information Stored in Attributes](retrieving-information-stored-in-attributes.md)
- [Concepts](/cpp/windows/attributed-programming-concepts)
- [Attributes (C#)](/dotnet/csharp/advanced-topics/reflection-and-attributes)
- [Attributes overview (Visual Basic)](../../visual-basic/programming-guide/concepts/attributes/index.md)
