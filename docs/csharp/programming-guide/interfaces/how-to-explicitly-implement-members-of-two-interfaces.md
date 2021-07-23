---
title: "How to explicitly implement members of two interfaces - C# Programming Guide"
description: Learn how to explicitly implement two interfaces that have the same member names and give each interface member a separate implementation in this C# example.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "inheritance [C#], explicitly implementing interface members"
  - "interfaces [C#], explicitly implementing with inheritance"
ms.assetid: 8b402ddc-dff9-4869-89cb-d718c764e68e
---
# How to explicitly implement members of two interfaces (C# Programming Guide)

Explicit [interface](../../language-reference/keywords/interface.md) implementation also allows the programmer to implement two interfaces that have the same member names and give each interface member a separate implementation. This example displays the dimensions of a box in both metric and English units. The Box [class](../../language-reference/keywords/class.md) implements two interfaces IEnglishDimensions and IMetricDimensions, which represent the different measurement systems. Both interfaces have identical member names, Length and Width.  
  
## Example  

 [!code-csharp[csProgGuideInheritance#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#9)]  
  
## Robust Programming  

 If you want to make the default measurements in English units, implement the methods Length and Width normally, and explicitly implement the Length and Width methods from the IMetricDimensions interface:  
  
 [!code-csharp[csProgGuideInheritance#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#10)]  
  
 In this case, you can access the English units from the class instance and access the metric units from the interface instance:  
  
 [!code-csharp[csProgGuideInheritance#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#11)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Classes, structs, and records](/dotnet/csharp/fundamentals/object-oriented)
- [Interfaces](../../fundamentals/types/interfaces.md)
- [How to explicitly implement interface members](./how-to-explicitly-implement-interface-members.md)
