---
title: "readonly (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "readonly_CSharpKeyword"
  - "readonly"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "readonly keyword [C#]"
ms.assetid: 2f8081f6-0de2-4903-898d-99696c48d2f4
caps.latest.revision: 16
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# readonly (C# Reference)
The `readonly` keyword is a modifier that you can use on fields. When a field declaration includes a `readonly` modifier, assignments to the fields introduced by the declaration can only occur as part of the declaration or in a constructor in the same class.  
  
## Example  
 In this example, the value of the field `year` cannot be changed in the method `ChangeYear`, even though it is assigned a value in the class constructor:  
  
 [!code[csrefKeywordsModifiers#14](../keywords/codesnippet/CSharp/readonly--csharp-reference-_1.cs)]  
  
 You can assign a value to a `readonly` field only in the following contexts:  
  
-   When the variable is initialized in the declaration, for example:  
  
    ```  
    public readonly int y = 5;  
    ```  
  
-   For an instance field, in the instance constructors of the class that contains the field declaration, or for a static field, in the static constructor of the class that contains the field declaration. These are also the only contexts in which it is valid to pass a `readonly` field as an [out](../keywords/out--csharp-reference-.md) or [ref](../keywords/ref--csharp-reference-.md) parameter.  
  
> [!NOTE]
>  The `readonly` keyword is different from the [const](../keywords/const--csharp-reference-.md) keyword. A `const` field can only be initialized at the declaration of the field. A `readonly` field can be initialized either at the declaration or in a constructor. Therefore, `readonly` fields can have different values depending on the constructor used. Also, while a `const` field is a compile-time constant, the `readonly` field can be used for runtime constants as in the following example:  
  
```  
public static readonly uint timeStamp = (uint)DateTime.Now.Ticks;  
```  
  
## Example  
 [!code[csrefKeywordsModifiers#15](../keywords/codesnippet/CSharp/readonly--csharp-reference-_2.cs)]  
  
 In the preceding example, if you use a statement like this:  
  
 `p2.y = 66;        // Error`  
  
 you will get the compiler error message:  
  
 `The left-hand side of an assignment must be an l-value`  
  
 which is the same error you get when you attempt to assign a value to a constant.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [const](../keywords/const--csharp-reference-.md)   
 [Fields](../classes-and-structs/fields--csharp-programming-guide-.md)