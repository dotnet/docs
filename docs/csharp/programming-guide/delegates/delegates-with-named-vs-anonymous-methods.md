---
title: "Delegates with Named vs. Anonymous Methods - C# Programming Guide"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "delegates [C#], with named vs. anonymous methods"
  - "methods [C#], in delegates"
ms.assetid: 98fa8c61-66b6-4146-986c-3236c4045733
---
# Delegates with Named vs. Anonymous Methods (C# Programming Guide)
A [delegate](../../language-reference/builtin-types/reference-types.md) can be associated with a named method. When you instantiate a delegate by using a named method, the method is passed as a parameter, for example:  
  
 [!code-csharp[csProgGuideDelegates#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#1)]  
  
 This is called using a named method. Delegates constructed with a named method can encapsulate either a [static](../../language-reference/keywords/static.md) method or an instance method. Named methods are the only way to instantiate a delegate in earlier versions of C#. However, in a situation where creating a new method is unwanted overhead, C# enables you to instantiate a delegate and immediately specify a code block that the delegate will process when it is called. The block can contain either a lambda expression or an anonymous method. For more information, see [Anonymous Functions](../statements-expressions-operators/anonymous-functions.md).  
  
## Remarks  
 The method that you pass as a delegate parameter must have the same signature as the delegate declaration.  
  
 A delegate instance may encapsulate either static or instance method.  
  
 Although the delegate can use an [out](../../language-reference/keywords/out-parameter-modifier.md) parameter, we do not recommend its use with multicast event delegates because you cannot know which delegate will be called.  
  
## Example 1  
 The following is a simple example of declaring and using a delegate. Notice that both the delegate, `Del`, and the associated method, `MultiplyNumbers`, have the same signature  
  
 [!code-csharp[csProgGuideDelegates#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#2)]  
  
## Example 2  
 In the following example, one delegate is mapped to both static and instance methods and returns specific information from each.  
  
 [!code-csharp[csProgGuideDelegates#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDelegates/CS/Delegates.cs#3)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Delegates](./index.md)
- [How to combine delegates (Multicast Delegates)](./how-to-combine-delegates-multicast-delegates.md)
- [Events](../events/index.md)
