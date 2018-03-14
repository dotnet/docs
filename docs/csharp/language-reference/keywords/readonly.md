---
title: "readonly (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "readonly_CSharpKeyword"
  - "readonly"
helpviewer_keywords: 
  - "readonly keyword [C#]"
ms.assetid: 2f8081f6-0de2-4903-898d-99696c48d2f4
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
---
# readonly (C# Reference)
The `readonly` keyword is a modifier that you can use on fields. When a field declaration includes a `readonly` modifier, assignments to the fields introduced by the declaration can only occur as part of the declaration or in a constructor in the same class.  
  
## Readonly field example  
 In this example, the value of the field `year` cannot be changed in the method `ChangeYear`, even though it is assigned a value in the class constructor:  
  
 [!code-csharp[csrefKeywordsModifiers#14](../../../csharp/language-reference/keywords/codesnippet/CSharp/readonly_1.cs)]  
  
 You can assign a value to a `readonly` field only in the following contexts:  
  
-   When the variable is initialized in the declaration, for example:  
  
    ```  
    public readonly int y = 5;  
    ```  
  
-   For an instance field, in the instance constructors of the class that contains the field declaration, or for a static field, in the static constructor of the class that contains the field declaration. These are also the only contexts in which it is valid to pass a `readonly` field as an [out](../../../csharp/language-reference/keywords/out-parameter-modifier.md) or [ref](../../../csharp/language-reference/keywords/ref.md) parameter.  
  
> [!NOTE]
>  The `readonly` keyword is different from the [const](../../../csharp/language-reference/keywords/const.md) keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be initialized either at the declaration or in a constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, while a `const` field is a compile-time constant, the `readonly` field can be used for runtime constants as in the following example:  
  
```  
public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;  
```  
  
## Comparing readonly and non-readonly instance fields  
 [!code-csharp[csrefKeywordsModifiers#15](../../../csharp/language-reference/keywords/codesnippet/CSharp/readonly_2.cs)]  
  
 In the preceding example, if you use a statement like this:  
  
 `p2.y = 66;        // Error`  
  
 you will get the compiler error message:  
  
 `The left-hand side of an assignment must be an l-value`  
  
 which is the same error you get when you attempt to assign a value to a constant.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [const](../../../csharp/language-reference/keywords/const.md)  
 [Fields](../../../csharp/programming-guide/classes-and-structs/fields.md)
