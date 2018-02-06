---
title: "Object variable or With block variable not set"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID91"
ms.assetid: 2f03e611-f0ed-465c-99a2-a816e034faa3
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Object variable or With block variable not set
An invalid object variable is being referenced.   This error can occur for several reasons:  
  
-   A variable was declared without specifying a type. If a variable is declared without specifying a type, it defaults to type `Object`.  
  
     For example, a variable declared with `Dim x` would be of type `Object;` a variable declared with `Dim x As String` would be of type `String`.  
  
    > [!TIP]
    >  The `Option Strict` statement disallows implicit typing that results in an `Object` type. If you omit the type, a compile-time error will occur. See [Option Strict Statement](../../../visual-basic/language-reference/statements/option-strict-statement.md).  
  
-   You are attempting to reference an object that has been set to `Nothing`  
  
     .  
  
-   You are attempting to access an element of an array variable that wasn't properly declared.  
  
     For example, an array declared as `products() As String` will trigger the error if you try to reference an element of the array `products(3) = "Widget"`. The array has no elements and is treated as an object.  
  
-   You are attempting to access code within a `With...End With` block before the block has been initialized.   A `With...End With` block must be initialized by executing the `With` statement entry point.  
  
> [!NOTE]
>  In earlier versions of Visual Basic or VBA this error was also triggered by assigning a value to a variable without using the `Set` keyword (`x = "name"` instead of `Set x = "name"`). The `Set` keyword is no longer valid in Visual Basic .Net.  
  
## To correct this error  
  
1.  Set `Option Strict` to `On` by adding the following code to the beginning of the file:  
  
```vb  
Option Strict On  
```  

     When you run the project, a compiler error will appear in the **Error List** for any variable that was specified without a type.  
  
2.  If you don't want to enable `Option Strict`, search your code for any variables that were specified without a type (`Dim x` instead of `Dim x As String`) and add the intended type to the declaration.  
  
3.  Make sure you aren't referring to  an object variable that has been set to `Nothing`.  Search your code for the keyword `Nothing`, and revise your code so that the object isn't set to `Nothing` until after you have referenced it.  
  
4.  Make sure that any array  variables are dimensioned before you access them. You can either assign a dimension when you first create the array (`Dim x(5) As String` instead of `Dim x() As String`), or use the `ReDim` keyword to set the dimensions of the array before you first access it.  
  
5.  Make sure your `With` block is initialized by executing the `With` statement entry point.  
  
## See Also  
 [Object Variable Declaration](../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)  
 [ReDim Statement](../../../visual-basic/language-reference/statements/redim-statement.md)  
 [With...End With Statement](../../../visual-basic/language-reference/statements/with-end-with-statement.md)
