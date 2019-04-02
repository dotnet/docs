---
title: "Nested function does not have a signature that is compatible with delegate '<delegatename>'"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc36532"
  - "bc36532"
helpviewer_keywords: 
  - "BC36532"
ms.assetid: 493f292c-d81e-40ef-8b47-61f020571829
---
# Nested function does not have a signature that is compatible with delegate '\<delegatename>'
A lambda expression has been assigned to a delegate that has an incompatible signature. For example, in the following code, delegate `Del` has two integer parameters.  
  
```vb  
Delegate Function Del(ByVal p As Integer, ByVal q As Integer) As Integer  
```  
  
 The error is raised if a lambda expression with one argument is declared as type `Del`:  
  
```vb  
' Neither of these is valid.   
' Dim lambda1 As Del = Function(n As Integer) n + 1  
' Dim lambda2 As Del = Function(n) n + 1  
```  
  
 **Error ID:** BC36532  
  
## To correct this error  
  
-   Adjust either the delegate definition or the assigned lambda expression so that the signatures are compatible.  
  
## See also

- [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md)
- [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)
