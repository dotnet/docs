---
title: "#line (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "#line"
helpviewer_keywords: 
  - "#line directive [C#]"
ms.assetid: 6439e525-5dd5-4acb-b8ea-efabb32ff95b
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
---
# #line (C# Reference)
`#line` lets you modify the compiler's line number and (optionally) the file name output for errors and warnings. This example shows how to report two warnings associated with line numbers. The `#line 200` directive forces the line number to be 200 (although the default is #7) and until the next #line directive, the filename will be reported as "Special". The #line default directive returns the line numbering to its default numbering, which counts the lines that were renumbered by the previous directive.  
  
```csharp
class MainClass  
{  
    static void Main()  
    {  
#line 200 "Special"  
        int i;    // CS0168 on line 200  
        int j;    // CS0168 on line 201  
#line default  
        char c;   // CS0168 on line 9  
        float f;  // CS0168 on line 10  
#line hidden // numbering not affected  
        string s;   
        double d; // CS0168 on line 13  
    }  
}  
```  
  
## Remarks  
 The `#line` directive might be used in an automated, intermediate step in the build process. For example, if lines were removed from the original source code file, but you still wanted the compiler to generate output based on the original line numbering in the file, you could remove lines and then simulate the original line numbering with `#line`.  
  
 The `#line hidden` directive hides the successive lines from the debugger, such that when the developer steps through the code, any lines between a `#line hidden` and the next `#line` directive (assuming that it is not another `#line hidden` directive) will be stepped over. This option can also be used to allow ASP.NET to differentiate between user-defined and machine-generated code. Although ASP.NET is the primary consumer of this feature, it is likely that more source generators will make use of it.  
  
 A `#line hidden` directive does not affect file names or line numbers in error reporting. That is, if an error is encountered in a hidden block, the compiler will report the current file name and line number of the error.  
  
 The `#line filename` directive specifies the file name you want to appear in the compiler output. By default, the actual name of the source code file is used. The file name must be in double quotation marks ("") and must be preceded by a line number.  
  
 A source code file can have any number of `#line` directives.  
  
## Example 1  
 The following example shows how the debugger ignores the hidden lines in the code. When you run the example, it will display three lines of text. However, when you set a break point, as shown in the example, and hit F10 to step through the code, you will notice that the debugger ignores the hidden line. Notice also that even if you set a break point at the hidden line, the debugger will still ignore it.  
  
```csharp
// preprocessor_linehidden.cs  
using System;  
class MainClass   
{  
    static void Main()   
    {  
        Console.WriteLine("Normal line #1."); // Set break point here.  
#line hidden  
        Console.WriteLine("Hidden line.");  
#line default  
        Console.WriteLine("Normal line #2.");  
    }  
}  
```  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Preprocessor Directives](../../../csharp/language-reference/preprocessor-directives/index.md)
