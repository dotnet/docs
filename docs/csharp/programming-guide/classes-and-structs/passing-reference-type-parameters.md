---
title: "Passing Reference-Type Parameters (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "method parameters [C#], reference types"
  - "parameters [C#], reference"
ms.assetid: 9e6eb65c-942e-48ab-920a-b7ba9df4ea20
caps.latest.revision: 14
author: "BillWagner"
ms.author: "wiwagn"
---
# Passing Reference-Type Parameters (C# Programming Guide)
A variable of a [reference type](../../../csharp/language-reference/keywords/reference-types.md) does not contain its data directly; it contains a reference to its data. When you pass a reference-type parameter by value, it is possible to change the data belonging to the referenced object, such as the value of a class member. However, you cannot change the value of the reference itself; for example, you cannot use the same reference to allocate memory for a new class and have it persist outside the method. To do that, pass the parameter using the [ref](../../../csharp/language-reference/keywords/ref.md) or [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) keyword. For simplicity, the following examples use `ref`.  
  
## Passing Reference Types by Value  
 The following example demonstrates passing a reference-type parameter, `arr`, by value, to a method, `Change`. Because the parameter is a reference to `arr`, it is possible to change the values of the array elements. However, the attempt to reassign the parameter to a different memory location only works inside the method and does not affect the original variable, `arr`.  
  
 [!code-csharp[csProgGuideParameters#7](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/passing-reference-type-parameters_1.cs)]  
  
 In the preceding example, the array, `arr`, which is a reference type, is passed to the method without the `ref` parameter. In such a case, a copy of the reference, which points to `arr`, is passed to the method. The output shows that it is possible for the method to change the contents of an array element, in this case from `1` to `888`. However, allocating a new portion of memory by using the [new](../../../csharp/language-reference/keywords/new.md) operator inside the `Change` method makes the variable `pArray` reference a new array. Thus, any changes after that will not affect the original array, `arr`, which is created inside `Main`. In fact, two arrays are created in this example, one inside `Main` and one inside the `Change` method.  
  
## Passing Reference Types by Reference  
 The following example is the same as the previous example, except that the `ref` keyword is added to the method header and call. Any changes that take place in the method affect the original variable in the calling program.  
  
 [!code-csharp[csProgGuideParameters#8](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/passing-reference-type-parameters_2.cs)]  
  
 All of the changes that take place inside the method affect the original array in `Main`. In fact, the original array is reallocated using the `new` operator. Thus, after calling the `Change` method, any reference to `arr` points to the five-element array, which is created in the `Change` method.  
  
## Swapping Two Strings  
 Swapping strings is a good example of passing reference-type parameters by reference. In the example, two strings, `str1` and `str2`, are initialized in `Main` and passed to the `SwapStrings` method as parameters modified by the `ref` keyword. The two strings are swapped inside the method and inside `Main` as well.  
  
 [!code-csharp[csProgGuideParameters#9](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/passing-reference-type-parameters_3.cs)]  
  
 In this example, the parameters need to be passed by reference to affect the variables in the calling program. If you remove the `ref` keyword from both the method header and the method call, no changes will take place in the calling program.  
  
 For more information about strings, see [string](../../../csharp/language-reference/keywords/string.md).  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Passing Parameters](../../../csharp/programming-guide/classes-and-structs/passing-parameters.md)  
 [Passing Arrays Using ref and out](../../../csharp/programming-guide/arrays/passing-arrays-using-ref-and-out.md)  
 [ref](../../../csharp/language-reference/keywords/ref.md)  
 [in](../../../csharp/language-reference/keywords/in-parameter-modifier.md)  
 [out](../../../csharp/language-reference/keywords/out.md)  
 [Reference Types](../../../csharp/language-reference/keywords/reference-types.md)
