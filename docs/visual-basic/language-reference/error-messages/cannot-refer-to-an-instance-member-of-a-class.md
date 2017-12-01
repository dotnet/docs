---
title: "Cannot refer to an instance member of a class from within a shared method or shared member initializer without an explicit instance of the class"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30369"
  - "bc30369"
helpviewer_keywords: 
  - "Shared"
  - "BC30369"
ms.assetid: 39d9466b-c1f3-4406-91a5-3d6c52d23a3d
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Cannot refer to an instance member of a class from within a shared method or shared member initializer without an explicit instance of the class
You have tried to refer to a non-shared member of a class from within a shared procedure. The following example demonstrates such a situation.  
  
```  
Class sample  
    Public x as Integer  
    Public Shared Sub setX()  
        x = 10  
    End Sub  
End Class  
```  
  
 In the preceding example, the assignment statement `x = 10` generates this error message. This is because a shared procedure is attempting to access an instance variable.  
  
 The variable `x` is an instance member because it is not declared as [Shared](../../../visual-basic/language-reference/modifiers/shared.md). Each instance of class `sample` contains its own individual variable `x`. When one instance sets or changes the value of `x`, it does not affect the value of `x` in any other instance.  
  
 However, the procedure `setX` is `Shared` among all instances of class `sample`. This means it is not associated with any one instance of the class, but rather operates independently of individual instances. Because it has no connection with a particular instance, `setX` cannot access an instance variable. It must operate only on `Shared` variables. When `setX` sets or changes the value of a shared variable, that new value is available to all instances of the class.  
  
 **Error ID:** BC30369  
  
## To correct this error  
  
1.  Decide whether you want the member to be shared among all instances of the class, or kept individual for each instance.  
  
2.  If you want a single copy of the member to be shared among all instances, add the `Shared` keyword to the member declaration. Retain the `Shared` keyword in the procedure declaration.  
  
3.  If you want each instance to have its own individual copy of the member, do not specify `Shared` for the member declaration. Remove the `Shared` keyword from the procedure declaration.  
  
## See Also  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)
