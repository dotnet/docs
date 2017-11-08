---
title: "Statements in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "variables [Visual Basic], declaring"
  - "colons (:) [Visual Basic]"
  - "constants [Visual Basic], defining"
  - "underlines"
  - "constants [Visual Basic], statements"
  - "blue underline [Visual Basic]"
  - "procedures [Visual Basic], statements"
  - "variables [Visual Basic], assigning"
  - "line breaks [Visual Basic], in code"
  - "executable statements [Visual Basic]"
  - "variables [Visual Basic], defining"
  - "statements [Visual Basic], about statements"
ms.assetid: fcfdee1a-82b7-4846-98f7-9ca3f5160089
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
---
# Statements in Visual Basic
A statement in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is a complete instruction. It can contain keywords, operators, variables, constants, and expressions. Each statement belongs to one of the following categories:  
  
-   **Declaration Statements**, which name a variable, constant, or procedure, and can also specify a data type.  
  
-   **Executable Statements**, which initiate actions. These statements can call a method or function, and they can loop or branch through blocks of code. Executable statements include **Assignment Statements**, which assign a value or expression to a variable or constant.  
  
 This topic describes each category. Also, this topic describes how to combine multiple statements on a single line and how to continue a statement over multiple lines.  
  
## Declaration Statements  
 You use declaration statements to name and define procedures, variables, properties, arrays, and constants. When you declare a programming element, you can also define its data type, access level, and scope. For more information, see [Declared Element Characteristics](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-characteristics.md).  
  
 The following example contains three declarations.  
  
 [!code-vb[VbVbalrStatements#80](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_1.vb)]  
  
 The first declaration is the `Sub` statement. Together with its matching `End Sub` statement, it declares a procedure named `applyFormat`. It also specifies that `applyFormat` is `Public`, which means that any code that can refer to it can call it.  
  
 The second declaration is the `Const` statement, which declares the constant `limit`, specifying the `Integer` data type and a value of 33.  
  
 The third declaration is the `Dim` statement, which declares the variable `thisWidget`. The data type is a specific object, namely an object created from the `Widget` class. You can declare a variable to be of any elementary data type or of any object type that is exposed in the application you are using.  
  
### Initial Values  
 When the code containing a declaration statement runs, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] reserves the memory required for the declared element. If the element holds a value, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] initializes it to the default value for its data type. For more information, see "Behavior" in [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md).  
  
 You can assign an initial value to a variable as part of its declaration, as the following example illustrates.  
  
 [!code-vb[VbVbalrStatements#81](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_2.vb)]  
  
 If a variable is an object variable, you can explicitly create an instance of its class when you declare it by using the [New Operator](../../../visual-basic/language-reference/operators/new-operator.md) keyword, as the following example illustrates.  
  
 [!code-vb[VbVbalrStatements#82](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_3.vb)]  
  
 Note that the initial value you specify in a declaration statement is not assigned to a variable until execution reaches its declaration statement. Until that time, the variable contains the default value for its data type.  
  
## Executable Statements  
 An executable statement performs an action. It can call a procedure, branch to another place in the code, loop through several statements, or evaluate an expression. An assignment statement is a special case of an executable statement.  
  
 The following example uses an `If...Then...Else` control structure to run different blocks of code based on the value of a variable. Within each block of code, a `For...Next` loop runs a specified number of times.  
  
 [!code-vb[VbVbalrStatements#83](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_4.vb)]  
  
 The `If` statement in the preceding example checks the value of the parameter `clockwise`. If the value is `True`, it calls the `spinClockwise` method of `aWidget`. If the value is `False`, it calls the `spinCounterClockwise` method of `aWidget`. The `If...Then...Else` control structure ends with `End If`.  
  
 The `For...Next` loop within each block calls the appropriate method a number of times equal to the value of the `revolutions` parameter.  
  
## Assignment Statements  
 Assignment statements carry out assignment operations, which consist of taking the value on the right side of the assignment operator (`=`) and storing it in the element on the left, as in the following example.  
  
 [!code-vb[VbVbalrStatements#73](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_5.vb)]  
  
 In the preceding example, the assignment statement stores the literal value 42 in the variable `v`.  
  
### Eligible Programming Elements  
 The programming element on the left side of the assignment operator must be able to accept and store a value. This means it must be a variable or property that is not [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md), or it must be an array element. In the context of an assignment statement, such an element is sometimes called an *lvalue*, for "left value."  
  
 The value on the right side of the assignment operator is generated by an expression, which can consist of any combination of literals, constants, variables, properties, array elements, other expressions, or function calls. The following example illustrates this.  
  
 [!code-vb[VbVbalrStatements#74](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_6.vb)]  
  
 The preceding example adds the value held in variable `y` to the value held in variable `z`, and then adds the value returned by the call to function `findResult`. The total value of this expression is then stored in variable `x`.  
  
### Data Types in Assignment Statements  
 In addition to numeric values, the assignment operator can also assign `String` values, as the following example illustrates.  
  
 [!code-vb[VbVbalrStatements#75](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_7.vb)]  
  
 You can also assign `Boolean` values, using either a `Boolean` literal or a `Boolean` expression, as the following example illustrates.  
  
 [!code-vb[VbVbalrStatements#76](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_8.vb)]  
  
 Similarly, you can assign appropriate values to programming elements of the `Char`, `Date`, or `Object` data type. You can also assign an object instance to an element declared to be of the class from which that instance is created.  
  
### Compound Assignment Statements  
 *Compound assignment statements* first perform an operation on an expression before assigning it to a programming element. The following example illustrates one of these operators, `+=`, which increments the value of the variable on the left side of the operator by the value of the expression on the right.  
  
 [!code-vb[VbVbalrStatements#77](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_9.vb)]  
  
 The preceding example adds 1 to the value of `n`, and then stores that new value in `n`. It is a shorthand equivalent of the following statement:  
  
 [!code-vb[VbVbalrStatements#78](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_10.vb)]  
  
 A variety of compound assignment operations can be performed using operators of this type. For a list of these operators and more information about them, see [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md).  
  
 The concatenation assignment operator (`&=`) is useful for adding a string to the end of already existing strings, as the following example illustrates.  
  
 [!code-vb[VbVbalrStatements#79](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_11.vb)]  
  
### Type Conversions in Assignment Statements  
 The value you assign to a variable, property, or array element must be of a data type appropriate to that destination element. In general, you should try to generate a value of the same data type as that of the destination element. However, some types can be converted to other types during assignment.  
  
 For information on converting between data types, see [Type Conversions in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/type-conversions.md). In brief, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically converts a value of a given type to any other type to which it widens. A *widening conversion* is one in that always succeeds at run time and does not lose any data. For example, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] converts an `Integer` value to `Double` when appropriate, because `Integer` widens to `Double`. For more information, see [Widening and Narrowing Conversions](../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md).  
  
 *Narrowing conversions* (those that are not widening) carry a risk of failure at run time, or of data loss. You can perform a narrowing conversion explicitly by using a type conversion function, or you can direct the compiler to perform all conversions implicitly by setting `Option Strict Off`. For more information, see [Implicit and Explicit Conversions](../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md).  
  
## Putting Multiple Statements on One Line  
 You can have multiple statements on a single line separated by the colon (`:`) character. The following example illustrates this.  
  
 [!code-vb[VbVbalrStatements#70](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_12.vb)]  
  
 Though occasionally convenient, this form of syntax makes your code hard to read and maintain. Thus, it is recommended that you keep one statement to a line.  
  
## Continuing a Statement over Multiple Lines  
 A statement usually fits on one line, but when it is too long, you can continue it onto the next line using a line-continuation sequence, which consists of a space followed by an underscore character (`_`) followed by a carriage return. In the following example, the `MsgBox` executable statement is continued over two lines.  
  
 [!code-vb[VbVbalrStatements#71](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_13.vb)]  
  
### Implicit Line Continuation  
 In many cases, you can continue a statement on the next consecutive line without using the underscore character (_). The following table lists the syntax elements that implicitly continue the statement on the next line of code.  
  
|Syntax element|Example|  
|---|---|  
|After a comma (`,`).|[!code-vb[VbVbalrLineContinuation#1](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_14.vb)]|  
|After an open parenthesis (`(`) or before a closing parenthesis (`)`).|[!code-vb[VbVbalrLineContinuation#2](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_15.vb)]|  
|After an open curly brace (`{`) or before a closing curly brace (`}`).|[!code-vb[VbVbalrLineContinuation#3](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_16.vb)]<br /><br /> For more information, see [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md) or [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md).|  
|After an open embedded expression (`<%=`) or before the close of an embedded expression (`%>`) within an XML literal.|[!code-vb[VbVbalrLineContinuation#4](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_17.vb)]<br /><br /> For more information, see [Embedded Expressions in XML](../../../visual-basic/programming-guide/language-features/xml/embedded-expressions-in-xml.md).|  
|After the concatenation operator (`&`).|[!code-vb[VbVbcnConventions#9](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_18.vb)]<br /><br /> For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).|  
|After assignment operators (`=`, `&=`, `:=`, `+=`, `-=`, `*=`, `/=`, `\=`, `^=`, `<<=`, `>>=`).|[!code-vb[VbVbalrLineContinuation#5](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_19.vb)]<br /><br /> For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).|  
|After binary operators (`+`, `-`, `/`, `*`, `Mod`, `<>`, `<`, `>`, `<=`, `>=`, `^`, `>>`, `<<`, `And`, `AndAlso`, `Or`, `OrElse`, `Like`, `Xor`) within an expression.|[!code-vb[VbVbalrLineContinuation#7](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_20.vb)]<br /><br /> For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).|  
|After the `Is` and `IsNot` operators.|[!code-vb[VbVbalrLineContinuation#8](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_21.vb)]<br /><br /> For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).|  
|After a member qualifier character (`.`) and before the member name. However, you must include a line-continuation character (_) following a member qualifier character when you are using the `With` statement or supplying values in the initialization list for a type. Consider breaking the line after the assignment operator (for example, `=`) when you are using `With` statements or object initialization lists.|[!code-vb[VbVbalrLineContinuation#5](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_19.vb)]<br />[!code-vb[VbVbalrLineContinuation#14](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_22.vb)]<br /><br /> For more information, see [With...End With Statement](../../../visual-basic/language-reference/statements/with-end-with-statement.md) or [Object Initializers: Named and Anonymous Types](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-initializers-named-and-anonymous-types.md).|  
|After an XML axis property qualifier (`.` or `.@` or `...`). However, you must include a line-continuation character (_) when you specify a member qualifier when you are using the `With` keyword.|[!code-vb[VbVbalrLineContinuation#9](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_23.vb)]<br /><br /> For more information, see [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/xml-axis-properties.md).|  
|After a less-than sign (<) or before a greater-than sign (`>`) when you specify an attribute. Also after a greater-than sign (`>`) when you specify an attribute. However, you must include a line-continuation character (_) when you specify assembly-level or module-level attributes.|[!code-vb[VbVbalrLineContinuation#10](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_24.vb)]<br /><br /> For more information, see [Attributes overview](../../../visual-basic/programming-guide/concepts/attributes/index.md).|  
|Before and after query operators (`Aggregate`, `Distinct`, `From`, `Group By`, `Group Join`, `Join`, `Let`, `Order By`, `Select`, `Skip`, `Skip While`, `Take`, `Take While`, `Where`, `In`, `Into`, `On`, `Ascending`, and `Descending`). You cannot break a line between the keywords of query operators that are made up of multiple keywords (`Order By`, `Group Join`, `Take While`, and `Skip While`).|[!code-vb[VbVbalrLineContinuation#11](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_25.vb)]<br /><br /> For more information, see [Queries](../../../visual-basic/language-reference/queries/queries.md).|  
|After the `In` keyword in a `For Each` statement.|[!code-vb[VbVbalrLineContinuation#12](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_26.vb)]<br /><br /> For more information, see [For Each...Next Statement](../../../visual-basic/language-reference/statements/for-each-next-statement.md).|  
|After the `From` keyword in a collection initializer.|[!code-vb[VbVbalrLineContinuation#13](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/statements_27.vb)]<br /><br /> For more information, see [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md).|  
  
## Adding Comments  
 Source code is not always self-explanatory, even to the programmer who wrote it. To help document their code, therefore, most programmers make liberal use of embedded comments. Comments in code can explain a procedure or a particular instruction to anyone reading or working with it later. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] ignores comments during compilation, and they do not affect the compiled code.  
  
 Comment lines begin with an apostrophe (`'`) or `REM` followed by a space. They can be added anywhere in code, except within a string. To append a comment to a statement, insert an apostrophe or `REM` after the statement, followed by the comment. Comments can also go on their own separate line. The following example demonstrates these possibilities.  
  
 [!code-vb[VbVbalrStatements#72](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/statements_28.vb)]  
  
## Checking Compilation Errors  
 If, after you type a line of code, the line is displayed with a wavy blue underline (an error message may appear as well), there is a syntax error in the statement. You must find out what is wrong with the statement (by looking in the task list, or hovering over the error with the mouse pointer and reading the error message) and correct it. Until you have fixed all syntax errors in your code, your program will fail to compile correctly.  
  
## Related Sections  
  
|Term|Definition|  
|---|---|  
|[Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)|Provides links to language reference pages covering assignment operators such as `=`, `*=`, and `&=`.|  
|[Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)|Shows how to combine elements with operators to yield new values.|  
|[How to: Break and Combine Statements in Code](../../../visual-basic/programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md)|Shows how to break a single statement into multiple lines and how to place multiple statements on the same line.|  
|[How to: Label Statements](../../../visual-basic/programming-guide/program-structure/how-to-label-statements.md)|Shows how to label a line of code.|
