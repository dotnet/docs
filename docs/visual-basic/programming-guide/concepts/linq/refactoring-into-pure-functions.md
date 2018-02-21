---
title: "Refactoring Into Pure Functions (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 99e7d27b-a3ff-4577-bdb2-5a8278d6d7af
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent

---
# Refactoring Into Pure Functions (Visual Basic)
An important aspect of pure functional transformations is learning how to refactor code using pure functions.  
  
 As noted previously in this section, a pure function has two useful characteristics:  
  
-   It has no side effects. The function does not change any variables or the data of any type outside of the function.  
  
-   It is consistent. Given the same set of input data, it will always return the same output value.  
  
 One way of transitioning to functional programming is to refactor existing code to eliminate unnecessary side effects and external dependencies. In this way, you can create pure function versions of existing code.  
  
 This topic discusses what a pure function is and what it is not. The [Tutorial: Manipulating Content in a WordprocessingML Document (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md) tutorial shows how to manipulate a WordprocessingML document, and includes two examples of how to refactor using a pure function.  
  
## Eliminating Side Effects and External Dependencies  
 The following examples contrast two non-pure functions and a pure function.  
  
### Non-Pure Function that Changes a Class Member  
 In the following code, the `HypenatedConcat` function is not a pure function, because it modifies the `aMember` data member in the class:  
  
```vb  
Module Module1  
    Dim aMember As String = "StringOne"  
  
    Public Sub HypenatedConcat(ByVal appendStr As String)  
        aMember = aMember & "-" & appendStr  
    End Sub  
  
    Sub Main()  
        HypenatedConcat("StringTwo")  
        Console.WriteLine(aMember)  
    End Sub  
End Module  
```  
  
 This code produces the following output:  
  
```  
StringOne-StringTwo  
```  
  
 Note that it is irrelevant whether the data being modified has `public` or `private` access, or is a  `shared` member or an instance member. A pure function does not change any data outside of the function.  
  
### Non-Pure Function that Changes an Argument  
 Furthermore, the following version of this same function is not pure because it modifies the contents of its parameter, `sb`.  
  
```vb  
Module Module1  
    Public Sub HypenatedConcat(ByVal sb As StringBuilder, ByVal appendStr As String)  
        sb.Append("-" & appendStr)  
    End Sub  
  
    Sub Main()  
        Dim sb1 As StringBuilder = New StringBuilder("StringOne")  
        HypenatedConcat(sb1, "StringTwo")  
        Console.WriteLine(sb1)  
    End Sub  
End Module  
```  
  
 This version of the program produces the same output as the first version, because the `HypenatedConcat` function has changed the value (state) of its first parameter by invoking the <xref:System.Text.StringBuilder.Append%2A> member function. Note that this alteration occurs despite that fact that `HypenatedConcat` uses call-by-value parameter passing.  
  
> [!IMPORTANT]
>  For reference types, if you pass a parameter by value, it results in a copy of the reference to an object being passed. This copy is still associated with the same instance data as the original reference (until the reference variable is assigned to a new object). Call-by-reference is not necessarily required for a function to modify a parameter.  
  
### Pure Function  
 This next version of the program hows how to implement the `HypenatedConcat` function as a pure function.  
  
```vb  
Module Module1  
    Public Function HyphenatedConcat(ByVal s As String, ByVal appendStr As String) As String  
        Return (s & "-" & appendStr)  
    End Function  
  
    Sub Main()  
        Dim s1 As String = "StringOne"  
        Dim s2 As String = HyphenatedConcat(s1, "StringTwo")  
        Console.WriteLine(s2)  
    End Sub  
End Module  
```  
  
 Again, this version produces the same line of output: `StringOne-StringTwo`. Note that to retain the concatenated value, it is stored in the intermediate variable `s2`.  
  
 One approach that can be very useful is to write functions that are locally impure (that is, they declare and modify local variables) but are globally pure. Such functions have many of the desirable composability characteristics, but avoid some of the more convoluted functional programming idioms, such as having to use recursion when a simple loop would accomplish the same thing.  
  
## Standard Query Operators  
 An important characteristic of the standard query operators is that they are implemented as pure functions.  
  
 For more information, see [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md).  
  
## See Also  
 [Introduction to Pure Functional Transformations (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/introduction-to-pure-functional-transformations.md)  
 [Functional Programming vs. Imperative Programming (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/functional-programming-vs-imperative-programming.md)
