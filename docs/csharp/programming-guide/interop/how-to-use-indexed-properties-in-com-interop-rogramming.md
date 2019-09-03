---
title: "How to: Use Indexed Properties in COM Interop Programming - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "indexed properties [C#]"
  - "Office programming [C#], indexed properties"
  - "properties [C#], indexed"
ms.assetid: 756bfc1e-7c28-4d4d-b114-ac9288c73882
---
# How to: Use Indexed Properties in COM Interop Programming (C# Programming Guide)
*Indexed properties* improve the way in which COM properties that have parameters are consumed in C# programming. Indexed properties work together with other features in Visual C#, such as [named and optional arguments](../classes-and-structs/named-and-optional-arguments.md), a new type ([dynamic](../../language-reference/keywords/dynamic.md)), and [embedded type information](../concepts/assemblies-gac/walkthrough-embedding-types-from-managed-assemblies-in-visual-studio.md), to enhance Microsoft Office programming.  
  
 In earlier versions of C#, methods are accessible as properties only if the `get` method has no parameters and the `set` method has one and only one value parameter. However, not all COM properties meet those restrictions. For example, the Excel <xref:Microsoft.Office.Interop.Excel.Range.Range%2A> property has a `get` accessor that requires a parameter for the name of the range. In the past, because you could not access the `Range` property directly, you had to use the `get_Range` method instead, as shown in the following example.  
  
 [!code-csharp[csProgGuideIndexedProperties#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#1)]  
  
 Indexed properties enable you to write the following instead:  
  
 [!code-csharp[csProgGuideIndexedProperties#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#2)]  
  
> [!NOTE]
> The previous example also uses the [optional arguments](../classes-and-structs/named-and-optional-arguments.md) feature, which enables you to omit `Type.Missing`.  
  
 Similarly to set the value of the `Value` property of a <xref:Microsoft.Office.Interop.Excel.Range> object in C# 3.0 and earlier, two arguments are required. One supplies an argument for an optional parameter that specifies the type of the range value. The other supplies the value for the `Value` property. The following examples illustrate these techniques. Both set the value of the A1 cell to `Name`.
  
 [!code-csharp[csProgGuideIndexedProperties#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#3)]  
  
 Indexed properties enable you to write the following code instead.  
  
 [!code-csharp[csProgGuideIndexedProperties#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#4)]  
  
 You cannot create indexed properties of your own. The feature only supports consumption of existing indexed properties.  
  
## Example  
 The following code shows a complete example. For more information about how to set up a project that accesses the Office API, see [How to: Access Office Interop Objects by Using Visual C# Features](./how-to-access-office-onterop-objects.md).  
  
 [!code-csharp[csProgGuideIndexedProperties#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguideindexedproperties/cs/program.cs#5)]  
  
## See also

- [Named and Optional Arguments](../classes-and-structs/named-and-optional-arguments.md)
- [dynamic](../../language-reference/keywords/dynamic.md)
- [Using Type dynamic](../types/using-type-dynamic.md)
- [How to: Use Named and Optional Arguments in Office Programming](../classes-and-structs/how-to-use-named-and-optional-arguments-in-office-programming.md)
- [How to: Access Office Interop Objects by Using Visual C# Features](./how-to-access-office-onterop-objects.md)
- [Walkthrough: Office Programming](./walkthrough-office-programming.md)
