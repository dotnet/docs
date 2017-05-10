---
title: "C# Coding Conventions (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "coding conventions, C#"
  - "Visual C#, coding conventions"
  - "C# language, coding conventions"
ms.assetid: f4f60de9-d49b-4fb6-bab1-20e19ea24710
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# C# Coding Conventions (C# Programming Guide)
The [C# Language Specification](http://go.microsoft.com/fwlink/?LinkId=199552) does not define a coding standard. However, the guidelines in this topic are used by Microsoft to develop samples and documentation.  
  
 Coding conventions serve the following purposes:  
  
-   They create a consistent look to the code, so that readers can focus on content, not layout.  
  
-   They enable readers to understand the code more quickly by making assumptions based on previous experience.  
  
-   They facilitate copying, changing, and maintaining the code.  
  
-   They demonstrate C# best practices.  
  
## Naming Conventions  
  
-   In short examples that do not include [using directives](../../../csharp/language-reference/keywords/using-directive.md), use namespace qualifications. If you know that a namespace is imported by default in a project, you do not have to fully qualify the names from that namespace. Qualified names can be broken after a dot (.) if they are too long for a single line, as shown in the following example.  
  
     [!code-cs[csProgGuideCodingConventions#1](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_1.cs)]  
  
-   You do not have to change the names of objects that were created by using the Visual Studio designer tools to make them fit other guidelines.  
  
## Layout Conventions  
 Good layout uses formatting to emphasize the structure of your code and to make the code easier to read. Microsoft examples and samples conform to the following conventions:  
  
-   Use the default Code Editor settings (smart indenting, four-character indents, tabs saved as spaces). For more information, see [Options, Text Editor, C#, Formatting](https://docs.microsoft.com/visualstudio/ide/reference/options-text-editor-csharp-formatting).  
  
-   Write only one statement per line.  
  
-   Write only one declaration per line.  
  
-   If continuation lines are not indented automatically, indent them one tab stop (four spaces).  
  
-   Add at least one blank line between method definitions and property definitions.  
  
-   Use parentheses to make clauses in an expression apparent, as shown in the following code.  
  
     [!code-cs[csProgGuideCodingConventions#2](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_2.cs)]  
  
## Commenting Conventions  
  
-   Place the comment on a separate line, not at the end of a line of code.  
  
-   Begin comment text with an uppercase letter.  
  
-   End comment text with a period.  
  
-   Insert one space between the comment delimiter (//) and the comment text, as shown in the following example.  
  
     [!code-cs[csProgGuideCodingConventions#3](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_3.cs)]  
  
-   Do not create formatted blocks of asterisks around comments.  
  
## Language Guidelines  
 The following sections describe practices that the C# team follows to prepare code examples and samples.  
  
### String Data Type  
  
-   Use the `+` operator to concatenate short strings, as shown in the following code.  
  
     [!code-cs[csProgGuideCodingConventions#6](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_4.cs)]  
  
-   To append strings in loops, especially when you are working with large amounts of text, use a <xref:System.Text.StringBuilder> object.  
  
     [!code-cs[csProgGuideCodingConventions#7](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_5.cs)]  
  
### Implicitly Typed Local Variables  
  
-   Use [implicit typing](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) for local variables when the type of the variable is obvious from the right side of the assignment, or when the precise type is not important.  
  
     [!code-cs[csProgGuideCodingConventions#8](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_6.cs)]  
  
-   Do not use [var](../../../csharp/language-reference/keywords/var.md) when the type is not apparent from the right side of the assignment.  
  
     [!code-cs[csProgGuideCodingConventions#9](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_7.cs)]  
  
-   Do not rely on the variable name to specify the type of the variable. It might not be correct.  
  
     [!code-cs[csProgGuideCodingConventions#10](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_8.cs)]  
  
-   Avoid the use of `var` in place of [dynamic](../../../csharp/language-reference/keywords/dynamic.md).  
  
-   Use implicit typing to determine the type of the loop variable in [for](../../../csharp/language-reference/keywords/for.md) and [foreach](../../../csharp/language-reference/keywords/foreach-in.md) loops.  
  
     The following example uses implicit typing in a `for` statement.  
  
     [!code-cs[csProgGuideCodingConventions#11](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_9.cs)]  
  
     The following example uses implicit typing in a `foreach` statement.  
  
     [!code-cs[csProgGuideCodingConventions#12](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_10.cs)]  
  
### Unsigned Data Type  
  
-   In general, use `int` rather than unsigned types. The use of `int` is common throughout C#, and it is easier to interact with other libraries when you use `int`.  
  
### Arrays  
  
-   Use the concise syntax when you initialize arrays on the declaration line.  
  
     [!code-cs[csProgGuideCodingConventions#13](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_11.cs)]  
  
### Delegates  
  
-   Use the concise syntax to create instances of a delegate type.  
  
     [!code-cs[csProgGuideCodingConventions#14](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_12.cs)]  
  
     [!code-cs[csProgGuideCodingConventions#15](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_13.cs)]  
  
### try-catch and using Statements in Exception Handling  
  
-   Use a [try-catch](../../../csharp/language-reference/keywords/try-catch.md) statement for most exception handling.  
  
     [!code-cs[csProgGuideCodingConventions#16](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_14.cs)]  
  
-   Simplify your code by using the C# [using statement](../../../csharp/language-reference/keywords/using-statement.md). If you have a [try-finally](../../../csharp/language-reference/keywords/try-finally.md) statement in which the only code in the `finally` block is a call to the <xref:System.IDisposable.Dispose%2A> method, use a `using` statement instead.  
  
     [!code-cs[csProgGuideCodingConventions#17](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_15.cs)]  
  
### && and &#124;&#124; Operators  
  
-   To avoid exceptions and increase performance by skipping unnecessary comparisons, use [&&](../../../csharp/language-reference/operators/conditional-and-operator.md) instead of [&](../../../csharp/language-reference/operators/and-operator.md) and [&#124;&#124;](../../../csharp/language-reference/operators/conditional-or-operator.md) instead of [&#124;](../../../csharp/language-reference/operators/or-operator.md) when you perform comparisons, as shown in the following example.  
  
     [!code-cs[csProgGuideCodingConventions#18](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_16.cs)]  
  
### New Operator  
  
-   Use the concise form of object instantiation, with implicit typing, as shown in the following declaration.  
  
     [!code-cs[csProgGuideCodingConventions#19](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_17.cs)]  
  
     The previous line is equivalent to the following declaration.  
  
     [!code-cs[csProgGuideCodingConventions#20](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_18.cs)]  
  
-   Use object initializers to simplify object creation.  
  
     [!code-cs[csProgGuideCodingConventions#21](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_19.cs)]  
  
### Event Handling  
  
-   If you are defining an event handler that you do not need to remove later, use a lambda expression.  
  
     [!code-cs[csProgGuideCodingConventions#22](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_20.cs)]  
  
     [!code-cs[csProgGuideCodingConventions#23](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_21.cs)]  
  
### Static Members  
  
-   Call [static](../../../csharp/language-reference/keywords/static.md) members by using the class name: *ClassName.StaticMember*. This practice makes code more readable by making static access clear.  Do not qualify a static member defined in a base class with the name of a derived class.  While that code compiles, the code readability is misleading, and the code may break in the future if you add a static member with the same name to the derived class.  
  
### LINQ Queries  
  
-   Use meaningful names for query variables. The following example uses `seattleCustomers` for customers who are located in Seattle.  
  
     [!code-cs[csProgGuideCodingConventions#25](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_22.cs)]  
  
-   Use aliases to make sure that property names of anonymous types are correctly capitalized, using Pascal casing.  
  
     [!code-cs[csProgGuideCodingConventions#26](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_23.cs)]  
  
-   Rename properties when the property names in the result would be ambiguous. For example, if your query returns a customer name and a distributor ID, instead of leaving them as `Name` and `ID` in the result, rename them to clarify that `Name` is the name of a customer, and `ID` is the ID of a distributor.  
  
     [!code-cs[csProgGuideCodingConventions#27](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_24.cs)]  
  
-   Use implicit typing in the declaration of query variables and range variables.  
  
     [!code-cs[csProgGuideCodingConventions#25](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_22.cs)]  
  
-   Align query clauses under the [from](../../../csharp/language-reference/keywords/from-clause.md) clause, as shown in the previous examples.  
  
-   Use [where](../../../csharp/language-reference/keywords/where-clause.md) clauses before other query clauses to ensure that later query clauses operate on the reduced, filtered set of data.  
  
     [!code-cs[csProgGuideCodingConventions#29](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_25.cs)]  
  
-   Use multiple `from` clauses instead of a [join](../../../csharp/language-reference/keywords/join-clause.md) clause to access inner collections. For example, a collection of `Student` objects might each contain a collection of test scores. When the following query is executed, it returns each score that is over 90, along with the last name of the student who received the score.  
  
     [!code-cs[csProgGuideCodingConventions#30](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/coding-conventions_26.cs)]  
  
## Security  
 Follow the guidelines in [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md).  
  
## See Also  
 [Visual Basic Coding Conventions](../../../visual-basic/programming-guide/program-structure/coding-conventions.md)   
 [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md)