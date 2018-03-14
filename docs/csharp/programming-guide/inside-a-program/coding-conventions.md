---
title: "C# Coding Conventions (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "coding conventions, C#"
  - "Visual C#, coding conventions"
  - "C# language, coding conventions"
ms.assetid: f4f60de9-d49b-4fb6-bab1-20e19ea24710
caps.latest.revision: 32
author: "BillWagner"
ms.author: "wiwagn"
---
# C# Coding Conventions (C# Programming Guide)
 Coding conventions serve the following purposes:  
  
-   They create a consistent look to the code, so that readers can focus on content, not layout.  
  
-   They enable readers to understand the code more quickly by making assumptions based on previous experience.  
  
-   They facilitate copying, changing, and maintaining the code.  
  
-   They demonstrate C# best practices.  

 The guidelines in this topic are used by Microsoft to develop samples and documentation.  
  
## Naming Conventions  
  
-   In short examples that do not include [using directives](../../../csharp/language-reference/keywords/using-directive.md), use namespace qualifications. If you know that a namespace is imported by default in a project, you do not have to fully qualify the names from that namespace. Qualified names can be broken after a dot (.) if they are too long for a single line, as shown in the following example.  
  
     [!code-csharp[csProgGuideCodingConventions#1](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#1)]  
  
-   You do not have to change the names of objects that were created by using the Visual Studio designer tools to make them fit other guidelines.  
  
## Layout Conventions  
 Good layout uses formatting to emphasize the structure of your code and to make the code easier to read. Microsoft examples and samples conform to the following conventions:  
  
-   Use the default Code Editor settings (smart indenting, four-character indents, tabs saved as spaces). For more information, see [Options, Text Editor, C#, Formatting](/visualstudio/ide/reference/options-text-editor-csharp-formatting).  
  
-   Write only one statement per line.  
  
-   Write only one declaration per line.  
  
-   If continuation lines are not indented automatically, indent them one tab stop (four spaces).  
  
-   Add at least one blank line between method definitions and property definitions.  
  
-   Use parentheses to make clauses in an expression apparent, as shown in the following code.  
  
     [!code-csharp[csProgGuideCodingConventions#2](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#2)]  
  
## Commenting Conventions  
  
-   Place the comment on a separate line, not at the end of a line of code.  
  
-   Begin comment text with an uppercase letter.  
  
-   End comment text with a period.  
  
-   Insert one space between the comment delimiter (//) and the comment text, as shown in the following example.  
  
     [!code-csharp[csProgGuideCodingConventions#3](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#3)]  
  
-   Do not create formatted blocks of asterisks around comments.  
  
## Language Guidelines  
 The following sections describe practices that the C# team follows to prepare code examples and samples.  
  
### String Data Type  
  
-   Use the `+` operator to concatenate short strings, as shown in the following code.  
  
     [!code-csharp[csProgGuideCodingConventions#6](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#6)]  
  
-   To append strings in loops, especially when you are working with large amounts of text, use a <xref:System.Text.StringBuilder> object.  
  
     [!code-csharp[csProgGuideCodingConventions#7](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#7)]  
  
### Implicitly Typed Local Variables  
  
-   Use [implicit typing](../../../csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md) for local variables when the type of the variable is obvious from the right side of the assignment, or when the precise type is not important.  
  
     [!code-csharp[csProgGuideCodingConventions#8](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#8)]  
  
-   Do not use [var](../../../csharp/language-reference/keywords/var.md) when the type is not apparent from the right side of the assignment.  
  
     [!code-csharp[csProgGuideCodingConventions#9](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#9)]  
  
-   Do not rely on the variable name to specify the type of the variable. It might not be correct.  
  
     [!code-csharp[csProgGuideCodingConventions#10](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#10)]  
  
-   Avoid the use of `var` in place of [dynamic](../../../csharp/language-reference/keywords/dynamic.md).  
  
-   Use implicit typing to determine the type of the loop variable in [for](../../../csharp/language-reference/keywords/for.md) and [foreach](../../../csharp/language-reference/keywords/foreach-in.md) loops.  
  
     The following example uses implicit typing in a `for` statement.  
  
     [!code-csharp[csProgGuideCodingConventions#11](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#11)]  
  
     The following example uses implicit typing in a `foreach` statement.  
  
     [!code-csharp[csProgGuideCodingConventions#12](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#12)]  
  
### Unsigned Data Type  
  
-   In general, use `int` rather than unsigned types. The use of `int` is common throughout C#, and it is easier to interact with other libraries when you use `int`.  
  
### Arrays  
  
-   Use the concise syntax when you initialize arrays on the declaration line.  
  
     [!code-csharp[csProgGuideCodingConventions#13](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#13)]  
  
### Delegates  
  
-   Use the concise syntax to create instances of a delegate type.  
  
     [!code-csharp[csProgGuideCodingConventions#14](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#14)]  
  
     [!code-csharp[csProgGuideCodingConventions#15](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#15)]  
  
### try-catch and using Statements in Exception Handling  
  
-   Use a [try-catch](../../../csharp/language-reference/keywords/try-catch.md) statement for most exception handling.  
  
     [!code-csharp[csProgGuideCodingConventions#16](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#16)]  
  
-   Simplify your code by using the C# [using statement](../../../csharp/language-reference/keywords/using-statement.md). If you have a [try-finally](../../../csharp/language-reference/keywords/try-finally.md) statement in which the only code in the `finally` block is a call to the <xref:System.IDisposable.Dispose%2A> method, use a `using` statement instead.  
  
     [!code-csharp[csProgGuideCodingConventions#17](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#17)]  
  
### && and &#124;&#124; Operators  
  
-   To avoid exceptions and increase performance by skipping unnecessary comparisons, use [&&](../../../csharp/language-reference/operators/conditional-and-operator.md) instead of [&](../../../csharp/language-reference/operators/and-operator.md) and [&#124;&#124;](../../../csharp/language-reference/operators/conditional-or-operator.md) instead of [&#124;](../../../csharp/language-reference/operators/or-operator.md) when you perform comparisons, as shown in the following example.  
  
     [!code-csharp[csProgGuideCodingConventions#18](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#18)]  
  
### New Operator  
  
-   Use the concise form of object instantiation, with implicit typing, as shown in the following declaration.  
  
     [!code-csharp[csProgGuideCodingConventions#19](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#19)]  
  
     The previous line is equivalent to the following declaration.  
  
     [!code-csharp[csProgGuideCodingConventions#20](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#20)]  
  
-   Use object initializers to simplify object creation.  
  
     [!code-csharp[csProgGuideCodingConventions#21](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#21)]  
  
### Event Handling  
  
-   If you are defining an event handler that you do not need to remove later, use a lambda expression.  
  
     [!code-csharp[csProgGuideCodingConventions#22](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#22)]  
  
     [!code-csharp[csProgGuideCodingConventions#23](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#23)]  
  
### Static Members  
  
-   Call [static](../../../csharp/language-reference/keywords/static.md) members by using the class name: *ClassName.StaticMember*. This practice makes code more readable by making static access clear.  Do not qualify a static member defined in a base class with the name of a derived class.  While that code compiles, the code readability is misleading, and the code may break in the future if you add a static member with the same name to the derived class.  
  
### LINQ Queries  
  
-   Use meaningful names for query variables. The following example uses `seattleCustomers` for customers who are located in Seattle.  
  
     [!code-csharp[csProgGuideCodingConventions#25](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#25)]  
  
-   Use aliases to make sure that property names of anonymous types are correctly capitalized, using Pascal casing.  
  
     [!code-csharp[csProgGuideCodingConventions#26](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#26)]  
  
-   Rename properties when the property names in the result would be ambiguous. For example, if your query returns a customer name and a distributor ID, instead of leaving them as `Name` and `ID` in the result, rename them to clarify that `Name` is the name of a customer, and `ID` is the ID of a distributor.  
  
     [!code-csharp[csProgGuideCodingConventions#27](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#27)]  
  
-   Use implicit typing in the declaration of query variables and range variables.  
  
     [!code-csharp[csProgGuideCodingConventions#25](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#25)]  
  
-   Align query clauses under the [from](../../../csharp/language-reference/keywords/from-clause.md) clause, as shown in the previous examples.  
  
-   Use [where](../../../csharp/language-reference/keywords/where-clause.md) clauses before other query clauses to ensure that later query clauses operate on the reduced, filtered set of data.  
  
     [!code-csharp[csProgGuideCodingConventions#29](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#29)]  
  
-   Use multiple `from` clauses instead of a [join](../../../csharp/language-reference/keywords/join-clause.md) clause to access inner collections. For example, a collection of `Student` objects might each contain a collection of test scores. When the following query is executed, it returns each score that is over 90, along with the last name of the student who received the score.  
  
     [!code-csharp[csProgGuideCodingConventions#30](../../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csprogguidecodingconventions/cs/program.cs#30)]  
  
## Security  
 Follow the guidelines in [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md).  
  
## See Also  
 [Visual Basic Coding Conventions](../../../visual-basic/programming-guide/program-structure/coding-conventions.md)  
 [Secure Coding Guidelines](../../../standard/security/secure-coding-guidelines.md)
