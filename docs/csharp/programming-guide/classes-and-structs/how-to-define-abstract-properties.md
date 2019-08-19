---
title: "How to: Define Abstract Properties - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "properties [C#], abstract"
  - "abstract properties [C#]"
ms.assetid: 672a90eb-47b9-4ae0-9914-af53852fddcb
---
# How to: Define Abstract Properties (C# Programming Guide)
The following example shows how to define [abstract](../../language-reference/keywords/abstract.md) properties. An abstract property declaration does not provide an implementation of the property accessors -- it declares that the class supports properties, but leaves the accessor implementation to derived classes. The following example demonstrates how to implement the abstract properties inherited from a base class.  
  
 This sample consists of three files, each of which is compiled individually and its resulting assembly is referenced by the next compilation:  
  
- abstractshape.cs: the `Shape` class that contains an abstract `Area` property.  
  
- shapes.cs: The subclasses of the `Shape` class.  
  
- shapetest.cs: A test program to display the areas of some `Shape`-derived objects.  
  
 To compile the example, use the following command:  
  
 `csc abstractshape.cs shapes.cs shapetest.cs`  
  
 This will create the executable file shapetest.exe.  
  
## Example  
 This file declares the `Shape` class that contains the `Area` property of the type `double`.  
  
 [!code-csharp[csProgGuideInheritance#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#1)]  
  
- Modifiers on the property are placed on the property declaration itself. For example:  
  
    ```csharp  
    public abstract double Area  
    ```  
  
- When declaring an abstract property (such as `Area` in this example), you simply indicate what property accessors are available, but do not implement them. In this example, only a [get](../../language-reference/keywords/get.md) accessor is available, so the property is read-only.  
  
## Example  
 The following code shows three subclasses of `Shape` and how they override the `Area` property to provide their own implementation.  
  
 [!code-csharp[csProgGuideInheritance#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#2)]  
  
## Example  
 The following code shows a test program that creates a number of `Shape`-derived objects and prints out their areas.  
  
 [!code-csharp[csProgGuideInheritance#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#3)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Classes and Structs](./index.md)
- [Abstract and Sealed Classes and Class Members](./abstract-and-sealed-classes-and-class-members.md)
- [Properties](./properties.md)
- [How to: Create and Use Assemblies Using the Command Line](../../../standard/assembly/create-use-command-line.md)
