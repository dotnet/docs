---
title: "ref (C# Reference)"
ms.date: "2017-05-30"
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "ref_CSharpKeyword"
  - "ref"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "parameters [C#], ref"
  - "ref keyword [C#]"
ms.assetid: b8a5e59c-907d-4065-b41d-95bf4273c0bd
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# ref (C# Reference)

The `ref` keyword indicates a value that is passed by reference. It is used in three different contexts: 

- In a method signature and in a method call, to pass an argument to a method by reference. See [Passing an argument by reference](#passing-an-argument-by-reference) for more information.

- In a method signature, to return a value to the caller by reference. See [Reference return values](#reference-return-values) for more information.

- In a member body, to indicate that a reference return value is stored locally as a reference that the caller intends to modify. See [Ref locals](#ref-locals) for more information.

## Passing an argument by reference

When used in a method's parameter list, the `ref` keyword indicates that an argument is passed by reference, not by value. The effect of passing by reference is that any change to the argument in the called method is reflected in the calling method. For example, if the caller passes a local variable expression or an array element access expression, and the called method replaces the object to which the ref parameter refers, then the caller’s local variable or the array element now refers to the new object when the method returns.

> [!NOTE]
>  Do not confuse the concept of passing by reference with the concept of reference types. The two concepts are not the same. A method parameter can be modified by `ref` regardless of whether it is a value type or a reference type. There is no boxing of a value type when it is passed by reference.  

To use a `ref` parameter, both the method definition and the calling method must explicitly use the `ref` keyword, as shown in the following example.  

[!code-cs[csrefKeywordsMethodParams#6](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-1.cs)]

An argument that is passed to a `ref` parameter must be initialized before it is passed. This differs from [out](out.md) parameters, whose arguments do not have to be explicitly initialized before they are passed.

Members of a class can't have signatures that differ only by `ref` and `out`. A compiler error occurs if the only difference between two members of a type is that one of them has a `ref` parameter and the other has an `out` parameter. The following code, for example, doesn't compile.  
  
 [!code-cs[csrefKeywordsMethodParams#2](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-2.cs)]
  
 However, methods can be overloaded when one method has a `ref` or `out` parameter and the other has a value parameter, as shown in the following example.
  
 [!code-cs[ref-and-overloads](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-3.cs)]
  
 In other situations that require signature matching, such as hiding or overriding, `ref` and `out` are part of the signature and don't match each other.  
  
 Properties are not variables. They are methods, and cannot be passed to `ref` parameters.  
  
 For information about how to pass arrays, see [Passing Arrays Using ref and out](../../../csharp/programming-guide/arrays/passing-arrays-using-ref-and-out.md).  
  
 You can't use the `ref` and `out` keywords for the following kinds of methods:  
  
-   Async methods, which you define by using the [async](../../../csharp/language-reference/keywords/async.md) modifier.  
  
-   Iterator methods, which include a [yield return](../../../csharp/language-reference/keywords/yield.md) or `yield break` statement.  
  
## Passing an argument by reference: An example

The previous examples pass value types by reference. You can also use the `ref` keyword to pass reference types by reference. Passing a reference type by reference enables the called method to replace the object to which the reference parameter refers in the caller. The storage location of the object is passed to the method as the value of the reference parameter. If you change the value in the storage location of the parameter (to point to a new object), you also change the storage location to which the caller refers. The following example passes an instance of a reference type as a `ref` parameter.   
  
 [!code-cs[ReferencesByRef](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-4.cs)]  

For more information about how to pass reference types by value and by reference, see [Passing Reference-Type Parameters](../../../csharp/programming-guide/classes-and-structs/passing-reference-type-parameters.md).
  
## Reference return values

Reference return values (or ref returns) are values that a method returns by reference to the caller. That is, the caller can modify the value returned by a method, and that change is reflected in the state of the object that contains the method. 

A reference return value is defined by using the `ref` keyword:

- In the method signature. For example, the following method signature inidicates that the `GetCurrentPrice` method returns a <xref:System.Decimal> value by reference.

   ```csharp
   public ref decimal GetCurrentValue()
   ``` 
- Before each `return` statement in the method. For example:
 
   ```csharp
   ref return Decimal.Zero;
   ``` 

In order for the caller to modify the an object's state, the reference return value must be stored to a variable that is explicitly defined as a [ref local](#ref-locals). 

For an example, see [A ref returns and ref locals example](#a-ref-returns-and-ref-locals-example)

## Ref locals

A ref local variable is used to refer to values returned using `ref return`.  A ref local variable must be initialized and assigned to a ref return value. Any modifications to the value of the ref local are reflected in the state of the object whose method returned the value by reference.

You define a ref local by using the `ref` keyword before the variable declaration, as well as immediately before the call to the method that returns the value by reference. 

For example, the following statement defines a ref local value that is returned by a method named `GetEstimatedValue`:

```csharp
ref decimal estValue = ref Building.GetEstimatedValue();
```

Note that the `ref` keyword must be used in both places, or the compiler generates error CS8172, "Cannot initialize a by-reference variable with a value." 
 
## A ref returns and ref locals example

The following example defines a `Book` class that has two <xref:System.String> fields, `Title` and `Author`. It also defines a `BookCollection` class that includes a private array of `Book` objects. Individual book objects are returned by reference by calling its `GetBookByTitle` method.

[!code-cs[csrefreturns](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-5.cs#1)]  

When the caller stores the value returned by the `GetBookByTitle` method as a ref local, changes that the caller makes to the return value are reflected in the `BookCollection` object, as the following example shows.

[!code-cs[csrefreturns](../../../../samples/snippets/csharp/language-reference/keywords/ref/ref-5.cs#2)]  

## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Passing Parameters](../../../csharp/programming-guide/classes-and-structs/passing-parameters.md)   
 [Method Parameters](../../../csharp/language-reference/keywords/method-parameters.md)   
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)
