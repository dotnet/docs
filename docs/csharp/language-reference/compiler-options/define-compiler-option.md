---
title: "-define (C# Compiler Options)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "/define"
helpviewer_keywords: 
  - "-define compiler option [C#]"
  - "/define compiler option [C#]"
  - "-d compiler option [C#]"
  - "define compiler option [C#]"
  - "/d compiler option [C#]"
  - "d compiler option [C#]"
ms.assetid: f17d7b4d-82d0-4133-8563-68cced1cac6e
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"
---
# -define (C# Compiler Options)
The **-define** option defines `name` as a symbol in all source code files your program.  
  
## Syntax  
  
```console  
-define:name[;name2]  
```  
  
## Arguments  
 `name`, `name2`  
 The name of one or more symbols that you want to define.  
  
## Remarks  
 The **-define** option has the same effect as using a [#define](../../../csharp/language-reference/preprocessor-directives/preprocessor-define.md) preprocessor directive except that the compiler option is in effect for all files in the project. A symbol remains defined in a source file until an [#undef](../../../csharp/language-reference/preprocessor-directives/preprocessor-undef.md) directive in the source file removes the definition. When you use the -define option, an `#undef` directive in one file has no effect on other source code files in the project.  
  
 You can use symbols created by this option with [#if](../../../csharp/language-reference/preprocessor-directives/preprocessor-if.md), [#else](../../../csharp/language-reference/preprocessor-directives/preprocessor-else.md), [#elif](../../../csharp/language-reference/preprocessor-directives/preprocessor-elif.md), and [#endif](../../../csharp/language-reference/preprocessor-directives/preprocessor-endif.md) to compile source files conditionally.  
  
 **-d** is the short form of **-define**.  
  
 You can define multiple symbols with **-define** by using a semicolon or comma to separate symbol names. For example:  
  
```console  
-define:DEBUG;TUESDAY  
```  
  
 The C# compiler itself defines no symbols or macros that you can use in your source code; all symbol definitions must be user-defined.  
  
> [!NOTE]
>  The C# `#define` does not allow a symbol to be given a value, as in languages such as C++. For example, `#define` cannot be used to create a macro or to define a constant. If you need to define a constant, use an `enum` variable. If you want to create a C++ style macro, consider alternatives such as generics. Since macros are notoriously error-prone, C# disallows their use but provides safer alternatives.  
  
### To set this compiler option in the Visual Studio development environment  
  
1.  Open the project's **Properties** page.  
  
2.  On the **Build** tab, type the symbol that is to be defined in the **Conditional compilation symbols** box. For example, if you are using the code example that follows, just type `xx` into the text box.  
  
 For information on how to set this compiler option programmatically, see <xref:VSLangProj80.CSharpProjectConfigurationProperties3.DefineConstants%2A>.  
  
## Example  
  
```csharp  
// preprocessor_define.cs  
// compile with: -define:xx  
// or uncomment the next line  
// #define xx  
using System;  
public class Test   
{  
    public static void Main()   
    {  
        #if (xx)   
            Console.WriteLine("xx defined");  
        #else  
            Console.WriteLine("xx not defined");  
        #endif  
    }  
}  
```  
  
## See Also  
 [C# Compiler Options](../../../csharp/language-reference/compiler-options/index.md)  
 [Managing Project and Solution Properties](/visualstudio/ide/managing-project-and-solution-properties)
