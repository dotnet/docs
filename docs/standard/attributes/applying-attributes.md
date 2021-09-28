---
description: "Learn more about: Apply attributes"
title: "Applying Attributes"
ms.date: "03/30/2017"
dev_langs:
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords:
  - "assemblies [.NET], attributes"
  - "attributes [.NET], applying"
ms.topic: how-to
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

## Apply an attribute to a method

 The following code example shows how to use **System.ObsoleteAttribute**, which marks code as obsolete. The string `"Will be removed in next version"` is passed to the attribute. This attribute causes a compiler warning that displays the passed string when code that the attribute describes is called.

 [!code-cpp[Conceptual.Attributes.Usage#3](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source1.cpp#3)]
 [!code-csharp[Conceptual.Attributes.Usage#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source1.cs#3)]
 [!code-vb[Conceptual.Attributes.Usage#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source1.vb#3)]

## Apply attributes at the assembly level

 If you want to apply an attribute at the assembly level, use the `assembly` (`Assembly` in Visual Basic) keyword. The following code shows the **AssemblyTitleAttribute** applied at the assembly level.

 [!code-cpp[Conceptual.Attributes.Usage#2](../../../samples/snippets/cpp/VS_Snippets_CLR/conceptual.attributes.usage/cpp/source1.cpp#2)]
 [!code-csharp[Conceptual.Attributes.Usage#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.attributes.usage/cs/source1.cs#2)]
 [!code-vb[Conceptual.Attributes.Usage#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.attributes.usage/vb/source1.vb#2)]

 When this attribute is applied, the string `"My Assembly"` is placed in the assembly manifest in the metadata portion of the file. You can view the attribute either by using the [MSIL Disassembler (Ildasm.exe)](../../framework/tools/ildasm-exe-il-disassembler.md) or by creating a custom program to retrieve the attribute.

## See also

- [Attributes](index.md)
- [Retrieving Information Stored in Attributes](retrieving-information-stored-in-attributes.md)
- [Concepts](/cpp/windows/attributed-programming-concepts)
- [Attributes (C#)](../../csharp/programming-guide/concepts/attributes/index.md)
- [Attributes overview (Visual Basic)](../../visual-basic/programming-guide/concepts/attributes/index.md)
