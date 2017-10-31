---
title: "How to: Declare A Constant (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.constant"
helpviewer_keywords: 
  - "Integer data type [Visual Basic], declaring constants"
  - "Single data type [Visual Basic], declaring constants"
  - "Const statement [Visual Basic], declaring constants"
  - "procedures [Visual Basic], declaration"
  - "data types [Visual Basic], constants"
  - "Long data type [Visual Basic], declaring constants"
  - "Visual Basic code, declaring variables and constants"
  - "Double data type [Visual Basic], declaring constants"
  - "Boolean data type [Visual Basic], declaring constants"
  - "modules, declaring constants"
  - "Byte data type [Visual Basic], declaring constants"
  - "constants [Visual Basic], declaring"
  - "Date data type [Visual Basic], declaring constants"
  - "String data type [Visual Basic], declaring constants"
  - "declaring constants [Visual Basic], const keyword"
  - "Currency data type [Visual Basic], declaring constants and variants"
  - "module-level constants and variables"
  - "Object data type [Visual Basic], declaring constants"
ms.assetid: f901b4fa-481f-4621-822e-427060577ad1
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare A Constant (Visual Basic)
You use the `Const` statement to declare a constant and set its value. By declaring a constant, you assign a meaningful name to a value. Once a constant is declared, it cannot be modified or assigned a new value.  
  
 You declare a constant within a procedure or in the declarations section of a module, class, or structure. Class or structure-level constants are `Private` by default, but may also be declared as `Public`, `Friend`, `Protected`, or `Protected Friend` for the appropriate level of code access.  
  
 The constant must have a valid symbolic name (the rules are the same as those for creating variable names) and an expression composed of numeric or string constants and operators (but no function calls).  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To declare a constant  
  
-   Write a declaration that includes an access specifier, the `Const` keyword, and an expression, as in the following examples:  
  
     [!code-vb[VbEnumsTask#8](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-declare-a-constant_1.vb)]  
  
     When [Option Infer](../../../../visual-basic/language-reference/statements/option-infer-statement.md) is `Off` and [Option Strict](../../../../visual-basic/language-reference/statements/option-strict-statement.md) is `On`, you must declare a constant explicitly by specifying a data type (`Boolean`, `Byte`, `Char`, `DateTime`, `Decimal`, `Double`, `Integer`, `Long`, `Short`, `Single`, or `String`).  
  
     When `Option Infer` is `On` or `Option Strict` is `Off`, you can declare a constant without specifying a data type with an `As` clause. The compiler determines the type of the constant from the type of the expression. For more information, see [Constant and Literal Data Types](constant-and-literal-data-types.md).  
  
### To declare a constant that has an explicitly stated data type  
  
-   Write a declaration that includes the `As` keyword and an explicit data type, as in the following examples:  
  
     [!code-vb[VbEnumsTask#9](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-declare-a-constant_2.vb)]  
  
     You can declare multiple constants on a single line, although your code is more readable if you declare only a single constant per line. If you declare multiple constants on a single line, they must all have the same access level (`Public`, `Private`, `Friend`, `Protected`, or `Protected Friend`).  
  
### To declare multiple constants on a single line  
  
-   Separate the declarations with a comma and a space, as in the following example:  
  
    ```  
    Public Const Four As Integer = 4, Five As Integer = 5, Six As Integer = 44  
    ```  
  
## See Also  
 [Const Statement](../../../../visual-basic/language-reference/statements/const-statement.md)  
 [Constant and Literal Data Types](constant-and-literal-data-types.md)  
 [Constants Overview](constants-overview.md)
 [How to: Declare A Constant](how-to-declare-a-constant.md)
 [User-Defined Constants](user-defined-constants.md)
 [Constant and Literal Data Types](constant-and-literal-data-types.md)
 [How to: Group Related Constant Values Together](how-to-group-related-constant-values-together.md)
 [Enumerations Overview](enumerations-overview.md)
 [How to: Declare Enumerations](how-to-declare-enumerations.md)
 [How to: Refer to an Enumeration Member](how-to-refer-to-an-enumeration-member.md)
 [Enumerations and Name Qualification](enumerations-and-name-qualification.md)
 [How to: Iterate Through An Enumeration](how-to-iterate-through-an-enumeration.md)
 [How to: Determine the String Associated with an Enumeration Value](how-to-determine-the-string-associated-with-an-enumeration-value.md)
 [When to Use an Enumeration](when-to-use-an-enumeration.md)

 [Enumerations Overview](enumerations-overview.md)  
 [Constants Overview](constants-overview.md)  
 [How to: Declare an Enumeration](how-to-declare-enumerations.md)  
 [Enumerations and Name Qualification](enumerations-and-name-qualification.md)  
 [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)  
 [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)
