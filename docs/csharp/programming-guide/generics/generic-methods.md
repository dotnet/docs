---
title: "Generic Methods - C# Programming Guide"
description: Learn about methods declared with type parameters, known as generic methods. See code examples and view additional available resources.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "generics [C#], methods"
ms.assetid: 673eeea2-4b48-4faa-9c4e-2e89449221b9
---
# Generic Methods (C# Programming Guide)

A generic method is a method that is declared with type parameters, as follows:  
  
 [!code-csharp[csProgGuideGenerics#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#22)]  
  
 The following code example shows one way to call the method by using `int` for the type argument:  
  
 [!code-csharp[csProgGuideGenerics#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#23)]  
  
 You can also omit the type argument and the compiler will infer it. The following call to `Swap` is equivalent to the previous call:  
  
 [!code-csharp[csProgGuideGenerics#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#24)]  
  
 The same rules for type inference apply to static methods and instance methods. The compiler can infer the type parameters based on the method arguments you pass in; it cannot infer the type parameters only from a constraint or return value. Therefore type inference does not work with methods that have no parameters. Type inference occurs at compile time before the compiler tries to resolve overloaded method signatures. The compiler applies type inference logic to all generic methods that share the same name. In the overload resolution step, the compiler includes only those generic methods on which type inference succeeded.  
  
 Within a generic class, non-generic methods can access the class-level type parameters, as follows:  
  
 [!code-csharp[csProgGuideGenerics#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#25)]  
  
 If you define a generic method that takes the same type parameters as the containing class, the compiler generates warning [CS0693](../../misc/cs0693.md) because within the method scope, the argument supplied for the inner `T` hides the argument supplied for the outer `T`. If you require the flexibility of calling a generic class method with type arguments other than the ones provided when the class was instantiated, consider providing another identifier for the type parameter of the method, as shown in `GenericList2<T>` in the following example.  
  
 [!code-csharp[csProgGuideGenerics#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#26)]  
  
 Use constraints to enable more specialized operations on type parameters in methods. This version of `Swap<T>`, now named `SwapIfGreater<T>`, can only be used with type arguments that implement <xref:System.IComparable%601>.  
  
 [!code-csharp[csProgGuideGenerics#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#27)]  
  
 Generic methods can be overloaded on several type parameters. For example, the following methods can all be located in the same class:  
  
 [!code-csharp[csProgGuideGenerics#28](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideGenerics/CS/Generics.cs#28)]  
  
## C# Language Specification  

 For more information, see the [C# Language Specification](~/_csharplang/spec/classes.md#methods).  
  
## See also

- <xref:System.Collections.Generic>
- [C# Programming Guide](../index.md)
- [Introduction to Generics](../../fundamentals/types/generics.md)
- [Methods](../classes-and-structs/methods.md)
