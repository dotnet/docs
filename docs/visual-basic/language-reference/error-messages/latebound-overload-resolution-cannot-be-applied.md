---
title: "Latebound overload resolution cannot be applied to &#39;&lt;procedurename&gt;&#39; because the accessing instance is an interface type"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30933"
  - "bc30933"
helpviewer_keywords: 
  - "overload resolution [Visual Basic], with late-bound argument"
  - "BC30933"
ms.assetid: 8182eea0-dd34-4d6e-9ca0-41d8713e9dc4
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Latebound overload resolution cannot be applied to &#39;&lt;procedurename&gt;&#39; because the accessing instance is an interface type
The compiler is attempting to resolve a reference to an overloaded property or procedure, but the reference fails because an argument is of type `Object` and the referring object has the data type of an interface. The `Object` argument forces the compiler to resolve the reference as late-bound.  
  
 In these circumstances, the compiler resolves the overload through the implementing class instead of through the underlying interface. If the class renames one of the overloaded versions, the compiler does not consider that version to be an overload because its name is different. This in turn causes the compiler to ignore the renamed version when it might have been the correct choice to resolve the reference.  
  
 **Error ID:** BC30933  
  
## To correct this error  
  
-   Use `CType` to cast the argument from `Object` to the type specified by the signature of the overload you want to call.  
  
     Note that it does not help to cast the referring object to the underlying interface. You must cast the argument to avoid this error.  
  
## Example  
 The following example shows a call to an overloaded `Sub` procedure that causes this error at compile time.  
  
```  
Module m1  
    Interface i1  
        Sub s1(ByVal p1 As Integer)  
        Sub s1(ByVal p1 As Double)  
    End Interface  
    Class c1  
        Implements i1  
        Public Overloads Sub s1(ByVal p1 As Integer) Implements i1.s1  
        End Sub  
        Public Overloads Sub s2(ByVal p1 As Double) Implements i1.s1  
        End Sub  
    End Class  
    Sub Main()  
        Dim refer As i1 = New c1  
        Dim o1 As Object = 3.1415  
        ' The following reference is INVALID and causes a compiler error.  
        refer.s1(o1)   
    End Sub  
End Module  
```  
  
 In the preceding example, if the compiler allowed the call to `s1` as written, the resolution would take place through the class `c1` instead of the interface `i1`. This would mean that the compiler would not consider `s2` because its name is different in `c1`, even though it is the correct choice as defined by `i1`.  
  
 You can correct the error by changing the call to either of the following lines of code:  
  
```  
refer.s1(CType(o1, Integer))  
refer.s1(CType(o1, Double))  
```  
  
 Each of the preceding lines of code explicitly casts the `Object` variable `o1` to one of the parameter types defined for the overloads.  
  
## See Also  
 [Procedure Overloading](../../../visual-basic/programming-guide/language-features/procedures/procedure-overloading.md)  
 [Overload Resolution](../../../visual-basic/programming-guide/language-features/procedures/overload-resolution.md)  
 [CType Function](../../../visual-basic/language-reference/functions/ctype-function.md)
