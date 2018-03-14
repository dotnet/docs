---
title: "using Directive (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "using directive [C#]"
ms.assetid: b42b8e61-5e7e-439c-bb71-370094b44ae8
caps.latest.revision: 31
author: "BillWagner"
ms.author: "wiwagn"
---
# using Directive (C# Reference)
The `using` directive has three uses:  
  
-   To allow the use of types in a namespace so that you do not have to qualify the use of a type in that namespace:  
  
    ```csharp  
    using System.Text;  
    ```  
  
-   To allow you to access static members of a type without having to qualify the access with the type name. 
  
    ```csharp  
    using static System.Math;  
    ```  
     
    For more information, see the [using static directive](using-static.md).

-   To create an alias for a namespace or a type. This is called a *using alias directive*.  
  
    ```csharp  
    using Project = PC.MyCompany.Project;  
    ```  
  
 The `using` keyword is also used to create *using statements*, which help ensure that <xref:System.IDisposable> objects such as files and fonts are handled correctly. See [using Statement](../../../csharp/language-reference/keywords/using-statement.md) for more information.  
  
## Using Static Type  
 You can access static members of a type without having to qualify the access with the type name:  
  
```csharp  
using static System.Console;   
using static System.Math;  
class Program   
{   
    static void Main()   
    {   
        WriteLine(Sqrt(3*3 + 4*4));   
    }   
}  
```  
  
## Remarks  
 The scope of a `using` directive is limited to the file in which it appears.  
  
 Create a `using` alias to make it easier to qualify an identifier to a namespace or type. The right side of a using alias directive must always be a fully-qualified type regardless of the using directives that come before it.  
  
 Create a `using` directive to use the types in a namespace without having to specify the namespace. A `using` directive does not give you access to any namespaces that are nested in the namespace you specify.  
  
 Namespaces come in two categories: user-defined and system-defined. User-defined namespaces are namespaces defined in your code. For a list of the system-defined namespaces, see [.NET Framework Class Library Overview](../../../standard/class-library-overview.md).  
  
 For examples on referencing methods in other assemblies, see [Create and Use Assemblies Using the Command Line](../../programming-guide/concepts/assemblies-gac/how-to-create-and-use-assemblies-using-the-command-line.md).  
  
## Example 1  
  
 The following example shows how to define and use a `using` alias for a namespace:  
  
 [!code-csharp[csrefKeywordsNamespace#8](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-directive_1.cs)]  
  
 A using alias directive cannot have an open generic type on the right hand side. For example, you cannot create a using alias for a List\<T>, but you can create one for a List\<int>.  
  
## Example 2  
  
 The following example shows how to define a `using` directive and a `using` alias for a class:  
  
 [!code-csharp[csrefKeywordsNamespace#9](../../../csharp/language-reference/keywords/codesnippet/CSharp/using-directive_2.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Using Namespaces](../../../csharp/programming-guide/namespaces/using-namespaces.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [Namespace Keywords](../../../csharp/language-reference/keywords/namespace-keywords.md)  
 [Namespaces](../../../csharp/programming-guide/namespaces/index.md)  
 [using Statement](../../../csharp/language-reference/keywords/using-statement.md)
