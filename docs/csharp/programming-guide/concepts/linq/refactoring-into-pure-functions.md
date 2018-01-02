---
title: "Refactoring Into Pure Functions (C#)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 2944a0d4-fd33-4e2e-badd-abb0f9be2fcc
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# Refactoring Into Pure Functions (C#)

An important aspect of pure functional transformations is learning how to refactor code using pure functions.  
  
> [!NOTE]
>  The common nomenclature in functional programming is that you refactor programs using pure functions. In Visual Basic and C++, this aligns with the use of functions in the respective languages. However, in C#, functions are called methods. For the purposes of this discussion, a pure function is implemented as a method in C#.  
  
 As noted previously in this section, a pure function has two useful characteristics:  
  
-   It has no side effects. The function does not change any variables or the data of any type outside of the function.  
  
-   It is consistent. Given the same set of input data, it will always return the same output value.  
  
 One way of transitioning to functional programming is to refactor existing code to eliminate unnecessary side effects and external dependencies. In this way, you can create pure function versions of existing code.  
  
 This topic discusses what a pure function is and what it is not. The [Tutorial: Manipulating Content in a WordprocessingML Document (C#)](../../../../csharp/programming-guide/concepts/linq/tutorial-manipulating-content-in-a-wordprocessingml-document.md) tutorial shows how to manipulate a WordprocessingML document, and includes two examples of how to refactor using a pure function.  
  
## Eliminating Side Effects and External Dependencies  
 The following examples contrast two non-pure functions and a pure function.  
  
### Non-Pure Function that Changes a Class Member  
 In the following code, the `HyphenatedConcat` function is not a pure function, because it modifies the `aMember` data member in the class:  
  
```csharp  
public class Program  
{  
    private static string aMember = "StringOne";  
  
    public static void HyphenatedConcat(string appendStr)  
    {  
        aMember += '-' + appendStr;  
    }  
  
    public static void Main()  
    {  
        HyphenatedConcat("StringTwo");  
        Console.WriteLine(aMember);  
    }  
}  
```  
  
 This code produces the following output:  
  
```  
StringOne-StringTwo  
```  
  
 Note that it is irrelevant whether the data being modified has `public` or `private` access, or is a `static` member or an instance member. A pure function does not change any data outside of the function.  
  
### Non-Pure Function that Changes an Argument  
 Furthermore, the following version of this same function is not pure because it modifies the contents of its parameter, `sb`.  
  
```csharp  
public class Program  
{  
    public static void HyphenatedConcat(StringBuilder sb, String appendStr)  
    {  
        sb.Append('-' + appendStr);  
    }  
  
    public static void Main()  
    {  
        StringBuilder sb1 = new StringBuilder("StringOne");  
        HyphenatedConcat(sb1, "StringTwo");  
        Console.WriteLine(sb1);  
    }  
}  
```  
  
 This version of the program produces the same output as the first version, because the `HyphenatedConcat` function has changed the value (state) of its first parameter by invoking the <xref:System.Text.StringBuilder.Append%2A> member function. Note that this alteration occurs despite that fact that `HyphenatedConcat` uses call-by-value parameter passing.  
  
> [!IMPORTANT]
>  For reference types, if you pass a parameter by value, it results in a copy of the reference to an object being passed. This copy is still associated with the same instance data as the original reference (until the reference variable is assigned to a new object). Call-by-reference is not necessarily required for a function to modify a parameter.  
  
### Pure Function  
This next version of the program shows how to implement the `HyphenatedConcat` function as a pure function.  
  
```csharp  
class Program  
{  
    public static string HyphenatedConcat(string s, string appendStr)  
    {  
        return (s + '-' + appendStr);  
    }  
  
    public static void Main(string[] args)  
    {  
        string s1 = "StringOne";  
        string s2 = HyphenatedConcat(s1, "StringTwo");  
        Console.WriteLine(s2);  
    }  
}  
```  
  
 Again, this version produces the same line of output: `StringOne-StringTwo`. Note that to retain the concatenated value, it is stored in the intermediate variable `s2`.  
  
 One approach that can be very useful is to write functions that are locally impure (that is, they declare and modify local variables) but are globally pure. Such functions have many of the desirable composability characteristics, but avoid some of the more convoluted functional programming idioms, such as having to use recursion when a simple loop would accomplish the same thing.  
  
## Standard Query Operators  
 An important characteristic of the standard query operators is that they are implemented as pure functions.  
  
 For more information, see [Standard Query Operators Overview (C#)](../../../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md).  
  
## See Also  
 [Introduction to Pure Functional Transformations (C#)](../../../../csharp/programming-guide/concepts/linq/introduction-to-pure-functional-transformations.md)  
 [Functional Programming vs. Imperative Programming (C#)](../../../../csharp/programming-guide/concepts/linq/functional-programming-vs-imperative-programming.md)
