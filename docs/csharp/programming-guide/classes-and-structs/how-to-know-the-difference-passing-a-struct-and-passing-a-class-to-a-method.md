---
title: "How to: Know the Difference Between Passing a Struct and Passing a Class Reference to a Method (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "structs [C#], passing as method parameter"
  - "passing parameters [C#], structs vs. classes"
  - "methods [C#], passing classes vs. structs"
ms.assetid: 9c1313a6-32a8-4ea7-a59f-450f66af628b
caps.latest.revision: 25
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Know the Difference Between Passing a Struct and Passing a Class Reference to a Method (C# Programming Guide)
The following example demonstrates how passing a [struct](../../../csharp/language-reference/keywords/struct.md) to a method differs from passing a [class](../../../csharp/language-reference/keywords/class.md) instance to a method. In the example, both of the arguments (struct and class instance) are passed by value, and both methods change the value of one field of the argument. However, the results of the two methods are not the same because what is passed when you pass a struct differs from what is passed when you pass an instance of a class.  
  
 Because a struct is a [value type](../../../csharp/language-reference/keywords/value-types.md), when you [pass a struct by value](../../../csharp/programming-guide/classes-and-structs/passing-value-type-parameters.md) to a method, the method receives and operates on a copy of the struct argument. The method has no access to the original struct in the calling method and therefore can't change it in any way. The method can change only the copy.  
  
 A class instance is a [reference type](../../../csharp/language-reference/keywords/reference-types.md), not a value type. When [a reference type is passed by value](../../../csharp/programming-guide/classes-and-structs/passing-reference-type-parameters.md) to a method, the method receives a copy of the reference to the class instance. That is, the method receives a copy of the address of the instance, not a copy of the instance itself. The class instance in the calling method has an address, the parameter in the called method has a copy of the address, and both addresses refer to the same object. Because the parameter contains only a copy of the address, the called method cannot change the address of the class instance in the calling method. However, the called method can use the address to access the class members that both the original address and the copy reference. If the called method changes a class member, the original class instance in the calling method also changes.  
  
 The output of the following example illustrates the difference. The value of the `willIChange` field of the class instance is changed by the call to method `ClassTaker` because the method uses the address in the parameter to find the specified field of the class instance. The `willIChange` field of the struct in the calling method is not changed by the call to method `StructTaker` because the value of the argument is a copy of the struct itself, not a copy of its address. `StructTaker` changes the copy, and the copy is lost when the call to `StructTaker` is completed.  
  
## Example  
 [!code-csharp[csProgGuideObjects#32](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-know-the-difference-passing-a-struct-and-passing-a-class-to-a-method_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Classes](../../../csharp/programming-guide/classes-and-structs/classes.md)  
 [Structs](../../../csharp/programming-guide/classes-and-structs/structs.md)  
 [Passing Parameters](../../../csharp/programming-guide/classes-and-structs/passing-parameters.md)
