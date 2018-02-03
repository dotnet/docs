---
title: "How to: Safely Cast from bool? to bool (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "casting [C#], nullable types"
  - "nullable types [C#], casting bool? to bool"
ms.assetid: e06e4274-a443-422d-8ef1-9dbf9df55237
caps.latest.revision: 9
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Safely Cast from bool? to bool (C# Programming Guide)
The `bool?` nullable type can contain three different values: `true`, `false`, and `null`. Therefore, the `bool?` type cannot be used in conditionals such as with `if`, `for`, or `while`. For example, the following code causes a compiler error.  
  
```  
bool? b = null;  
if (b) // Error CS0266.  
{  
}  
```  
  
 This is not allowed because it is unclear what `null` means in the context of a conditional. To use a `bool?` in a conditional statement, first check its <xref:System.Nullable%601.HasValue%2A> property to ensure that its value is not `null`, and then cast it to `bool`. For more information, see [bool](../../../csharp/language-reference/keywords/bool.md). If you perform the cast on a `bool?` with a value of `null`, a <xref:System.InvalidOperationException> will be thrown in the conditional test. The following example shows one way to safely cast from `bool?` to `bool`:  
  
## Example  
  
```csharp  
bool? test = null;  
// Other code that may or may not  
// give a value to test.  
if(!test.HasValue) //check for a value  
{  
    // Assume that IsInitialized  
    // returns either true or false.  
    test = IsInitialized();  
}  
if((bool)test) //now this cast is safe  
{  
   // Do something.  
}  
```  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Literal Keywords](../../../csharp/language-reference/keywords/literal-keywords.md)  
 [Nullable Types](../../../csharp/programming-guide/nullable-types/index.md)  
 [?? Operator](../../../csharp/language-reference/operators/null-conditional-operator.md)
