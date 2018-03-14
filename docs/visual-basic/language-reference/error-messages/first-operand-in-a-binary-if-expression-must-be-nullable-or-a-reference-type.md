---
title: "First operand in a binary &#39;If&#39; expression must be nullable or a reference type"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc33107"
  - "vbc33107"
helpviewer_keywords: 
  - "BC33107"
ms.assetid: 493c8899-3f6b-4471-8eb6-9284e8492768
caps.latest.revision: 5
author: dotnet-bot
ms.author: dotnetcontent
---
# First operand in a binary &#39;If&#39; expression must be nullable or a reference type
An `If` expression can take either two or three arguments. When you send only two arguments, the first argument must be a reference type or a nullable type. If the first argument evaluates to anything other than `Nothing`, its value is returned. If the first argument evaluates to `Nothing`, the second argument is evaluated and returned.  
  
 For example, the following code contains two `If` expressions, one with three arguments and one with two arguments. The expressions calculate and return the same value.  
  
```vb  
' firstChoice is a nullable value type.  
Dim firstChoice? As Integer = Nothing  
Dim secondChoice As Integer = 1128  
' If expression with three arguments.  
Console.WriteLine(If(firstChoice IsNot Nothing, firstChoice, secondChoice))  
' If expression with two arguments.  
Console.WriteLine(If(firstChoice, secondChoice))  
```  
  
 The following expressions cause this error:  
  
```vb  
Dim choice1 = 4  
Dim choice2 = 5  
Dim booleanVar = True  
  
' Not valid.  
'Console.WriteLine(If(choice1 < choice2, 1))  
' Not valid.  
'Console.WriteLine(If(booleanVar, "Test returns True."))  
```  
  
 **Error ID:** BC33107  
  
## To correct this error  
  
-   If you cannot change the code so that the first argument is a nullable type or reference type, consider converting to a three-argument `If` expression, or to an `If...Then...Else` statement.  
  
```vb  
Console.WriteLine(If(choice1 < choice2, 1, 2))  
Console.WriteLine(If(booleanVar, "Test returns True.", "Test returns False."))  
```  
  
## See Also  
 [If Operator](../../../visual-basic/language-reference/operators/if-operator.md)  
 [If...Then...Else Statement](../../../visual-basic/language-reference/statements/if-then-else-statement.md)  
 [Nullable Value Types](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)
