---
title: "How to override the ToString method - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "ToString method, overriding in C#"
  - "inheritance [C#], overriding OnPaint and ToString"
ms.assetid: 8016db69-1f19-420c-8e17-98e8bebb7749
---
# How to override the ToString method (C# Programming Guide)

Every class or struct in C# implicitly inherits the <xref:System.Object> class. Therefore, every object in C# gets the <xref:System.Object.ToString%2A> method, which returns a string representation of that object. For example, all variables of type `int` have a `ToString` method, which enables them to return their contents as a string:  
  
 [!code-csharp[csProgGuideInheritance#37](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#37)]  
  
 When you create a custom class or struct, you should override the <xref:System.Object.ToString%2A> method in order to provide information about your type to client code.  
  
 For information about how to use format strings and other types of custom formatting with the `ToString` method, see [Formatting Types](../../../standard/base-types/formatting-types.md).  
  
> [!IMPORTANT]
> When you decide what information to provide through this method, consider whether your class or struct will ever be used by untrusted code. Be careful to ensure that you do not provide any information that could be exploited by malicious code.  
  
To override the `ToString` method in your class or struct:
  
1. Declare a `ToString` method with the following modifiers and return type:  
  
    ```csharp  
    public override string ToString(){}  
    ```  
  
2. Implement the method so that it returns a string.  
  
     The following example returns the name of the class in addition to the data specific to a particular instance of the class.  
  
     [!code-csharp[csProgGuideInheritance#36](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#36)]  
  
     You can test the `ToString` method as shown in the following code example:  
  
     [!code-csharp[csProgGuideInheritance#38](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideInheritance/CS/Inheritance.cs#38)]  
  
## See also

- <xref:System.IFormattable>
- [C# Programming Guide](../index.md)
- [Classes and Structs](./index.md)
- [Strings](../strings/index.md)
- [string](../../language-reference/builtin-types/reference-types.md)
- [override](../../language-reference/keywords/override.md)
- [virtual](../../language-reference/keywords/virtual.md)
- [Formatting Types](../../../standard/base-types/formatting-types.md)
