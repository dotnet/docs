---
title: "out parameter modifier (C# Reference)"
ms.date: 03/06/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "parameters [C#], out"
  - "out parameters [C#]"
author: "BillWagner"
ms.author: "wiwagn"
---
# out parameter modifier (C# Reference)
The `out` keyword causes arguments to be passed by reference. It is like the [ref](ref.md) keyword, except that `ref` requires that the variable be initialized before it is passed. It is also like the [in](in-parameter-modifier.md) keyword, except that `in` does not allow the called method to modify the argument value. To use an `out` parameter, both the method definition and the calling method must explicitly use the `out` keyword. For example:  
  
[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#1)]  

> [!NOTE] 
> The `out` keyword can also be used with a generic type parameter to specify that the type parameter is covariant. For more information on the use of the `out` keyword in this context, see [out (Generic Modifier)](out-generic-modifier.md).
  
Variables passed as `out` arguments do not have to be initialized before being passed in a method call. However, the called method is required to assign a value before the method returns.  
  
Although the `in`, `ref`, and `out` keywords cause different run-time behavior, they are not considered part of the method signature at compile time. Therefore, methods cannot be overloaded if the only difference is that one method takes a `ref` or `in` argument and the other takes an `out` argument. The following code, for example, will not compile:  
  
```csharp
class CS0663_Example
{
    // Compiler error CS0663: "Cannot define overloaded 
    // methods that differ only on ref and out".
    public void SampleMethod(out int i) { }
    public void SampleMethod(ref int i) { }
}
```
  
Overloading is legal, however, if one method takes a `ref`, `in`, or `out` argument and the other has none of those modifiers, like this:  
  
[!code-csharp[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#2)]  

The compiler chooses the best overload by matching the parameter modifiers at the call site to the parameter modifiers used in the method call.
 
Properties are not variables and therefore cannot be passed as `out` parameters.
  
 For information about passing arrays, see [Passing Arrays Using ref and out](../../../csharp/programming-guide/arrays/passing-arrays-using-ref-and-out.md).  
  
 You can't use the `in`, `ref`, and `out` keywords for the following kinds of methods:  
  
-   Async methods, which you define by using the [async](../../../csharp/language-reference/keywords/async.md) modifier.  
  
-   Iterator methods, which include a [yield return](../../../csharp/language-reference/keywords/yield.md) or `yield break` statement.  

## Declaring `out` arguments   

 Declaring a method with `out` arguments is useful when you want a method to return multiple values. The following example uses `out` to return three variables with a single method call. Note that the third argument is assigned to null. This enables methods to return values optionally.  
  
[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#3)]  

 The [Try pattern](/visualstudio/code-quality/ca1021-avoid-out-parameters#try-pattern-methods.md) involves returning a `bool` to indicate whether an operation succeeded and failed, and returning the value produced by the operation in an `out` argument. A number of parsing methods, such as the [DateTime.TryParse](xref:System.DateTime.TryParse(System.String,System.DateTime@)) method, use this pattern.
   
## Calling a method with an `out` argument

In C# 6 and earlier, you must declare a variable in a separate statement before you pass it as an `out` argument. The following example declares a variable named `number` before it is passed to the [Int32.TryParse](xref:System.Int32.TryParse(System.String,System.Int32@)) method, which attempts to convert a string to a number.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#4)]  

Starting with C# 7, you can declare the `out` variable in the argument list of the method call, rather than in a separate variable declaration. This produces more compact, readable code, and also prevents you from inadvertently assigning a value to the variable before the method call. The following example is like the previous example, except that it defines the `number` variable in the call to the [Int32.TryParse](xref:System.Int32.TryParse(System.String,System.Int32@)) method.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#5)]  
   
In the previous example, the `number` variable is strongly typed as an `int`. You can also declare an implicitly typed local variable, as the following example does.

[!code-csharp-interactive[cs-out-keyword](../../../../samples/snippets/csharp/language-reference/keywords/in-ref-out-modifier/OutParameterModifier.cs#6)]  
   
## C# Language Specification  
[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Method Parameters](../../../csharp/language-reference/keywords/method-parameters.md)
