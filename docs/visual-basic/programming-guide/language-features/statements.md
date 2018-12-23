---
title: "Statements in Visual Basic"
ms.date: 07/20/2015
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
---
# Statements in Visual Basic

A statement in Visual Basic is a complete instruction. It can contain keywords, operators, variables, constants, and expressions. Each statement belongs to one of the following categories:

- **Declaration Statements**, which name a variable, constant, or procedure, and can also specify a data type.

- **Executable Statements**, which initiate actions. These statements can call a method or function, and they can loop or branch through blocks of code. Executable statements include **Assignment Statements**, which assign a value or expression to a variable or constant.

This topic describes each category. Also, this topic describes how to combine multiple statements on a single line and how to continue a statement over multiple lines.

## Declaration statements

You use declaration statements to name and define procedures, variables, properties, arrays, and constants. When you declare a programming element, you can also define its data type, access level, and scope. For more information, see [Declared Element Characteristics](./declared-elements/declared-element-characteristics.md).

The following example contains three declarations.

[!code-vb[VbVbalrStatements#80](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#80)]

The first declaration is the `Sub` statement. Together with its matching `End Sub` statement, it declares a procedure named `applyFormat`. It also specifies that `applyFormat` is `Public`, which means that any code that can refer to it can call it.

The second declaration is the `Const` statement, which declares the constant `limit`, specifying the `Integer` data type and a value of 33.

The third declaration is the `Dim` statement, which declares the variable `thisWidget`. The data type is a specific object, namely an object created from the `Widget` class. You can declare a variable to be of any elementary data type or of any object type that is exposed in the application you are using.

### Initial Values

When the code containing a declaration statement runs, Visual Basic reserves the memory required for the declared element. If the element holds a value, Visual Basic initializes it to the default value for its data type. For more information, see "Behavior" in [Dim Statement](../../language-reference/statements/dim-statement.md).

You can assign an initial value to a variable as part of its declaration, as the following example illustrates.

[!code-vb[VbVbalrStatements#81](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#81)]

If a variable is an object variable, you can explicitly create an instance of its class when you declare it by using the [New Operator](../../../visual-basic/language-reference/operators/new-operator.md) keyword, as the following example illustrates.

[!code-vb[VbVbalrStatements#82](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#82)]

Note that the initial value you specify in a declaration statement is not assigned to a variable until execution reaches its declaration statement. Until that time, the variable contains the default value for its data type.

## Executable statements

An executable statement performs an action. It can call a procedure, branch to another place in the code, loop through several statements, or evaluate an expression. An assignment statement is a special case of an executable statement.

The following example uses an `If...Then...Else` control structure to run different blocks of code based on the value of a variable. Within each block of code, a `For...Next` loop runs a specified number of times.

[!code-vb[VbVbalrStatements#83](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#83)]

The `If` statement in the preceding example checks the value of the parameter `clockwise`. If the value is `True`, it calls the `spinClockwise` method of `aWidget`. If the value is `False`, it calls the `spinCounterClockwise` method of `aWidget`. The `If...Then...Else` control structure ends with `End If`.

The `For...Next` loop within each block calls the appropriate method a number of times equal to the value of the `revolutions` parameter.

## Assignment statements

Assignment statements carry out assignment operations, which consist of taking the value on the right side of the assignment operator (`=`) and storing it in the element on the left, as in the following example.

[!code-vb[VbVbalrStatements#73](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#73)]

In the preceding example, the assignment statement stores the literal value 42 in the variable `v`.

### Eligible programming elements

The programming element on the left side of the assignment operator must be able to accept and store a value. This means it must be a variable or property that is not [ReadOnly](../../../visual-basic/language-reference/modifiers/readonly.md), or it must be an array element. In the context of an assignment statement, such an element is sometimes called an *lvalue*, for "left value."

The value on the right side of the assignment operator is generated by an expression, which can consist of any combination of literals, constants, variables, properties, array elements, other expressions, or function calls. The following example illustrates this.

[!code-vb[VbVbalrStatements#74](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#74)]

The preceding example adds the value held in variable `y` to the value held in variable `z`, and then adds the value returned by the call to function `findResult`. The total value of this expression is then stored in variable `x`.

### Data types in assignment statements

In addition to numeric values, the assignment operator can also assign `String` values, as the following example illustrates.

[!code-vb[VbVbalrStatements#75](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#75)]

You can also assign `Boolean` values, using either a `Boolean` literal or a `Boolean` expression, as the following example illustrates.

[!code-vb[VbVbalrStatements#76](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#76)]

Similarly, you can assign appropriate values to programming elements of the `Char`, `Date`, or `Object` data type. You can also assign an object instance to an element declared to be of the class from which that instance is created.

### Compound assignment statements

*Compound assignment statements* first perform an operation on an expression before assigning it to a programming element. The following example illustrates one of these operators, `+=`, which increments the value of the variable on the left side of the operator by the value of the expression on the right.

[!code-vb[VbVbalrStatements#77](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#77)]

The preceding example adds 1 to the value of `n`, and then stores that new value in `n`. It is a shorthand equivalent of the following statement:

[!code-vb[VbVbalrStatements#78](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#78)]

A variety of compound assignment operations can be performed using operators of this type. For a list of these operators and more information about them, see [Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md).

The concatenation assignment operator (`&=`) is useful for adding a string to the end of already existing strings, as the following example illustrates.

[!code-vb[VbVbalrStatements#79](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#79)]

### Type Conversions in Assignment Statements

The value you assign to a variable, property, or array element must be of a data type appropriate to that destination element. In general, you should try to generate a value of the same data type as that of the destination element. However, some types can be converted to other types during assignment.

For information on converting between data types, see [Type Conversions in Visual Basic](./data-types/type-conversions.md). In brief, Visual Basic automatically converts a value of a given type to any other type to which it widens. A *widening conversion* is one in that always succeeds at run time and does not lose any data. For example, Visual Basic converts an `Integer` value to `Double` when appropriate, because `Integer` widens to `Double`. For more information, see [Widening and Narrowing Conversions](./data-types/widening-and-narrowing-conversions.md).

*Narrowing conversions* (those that are not widening) carry a risk of failure at run time, or of data loss. You can perform a narrowing conversion explicitly by using a type conversion function, or you can direct the compiler to perform all conversions implicitly by setting `Option Strict Off`. For more information, see [Implicit and Explicit Conversions](./data-types/implicit-and-explicit-conversions.md).

## Putting multiple statements on one line

You can have multiple statements on a single line separated by the colon (`:`) character. The following example illustrates this.

[!code-vb[VbVbalrStatements#70](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#70)]

Though occasionally convenient, this form of syntax makes your code hard to read and maintain. Thus, it is recommended that you keep one statement to a line.

## Continuing a statement over multiple lines

A statement usually fits on one line, but when it is too long, you can continue it onto the next line using a line-continuation sequence, which consists of a space followed by an underscore character (`_`) followed by a carriage return. In the following example, the `MsgBox` executable statement is continued over two lines.

[!code-vb[VbVbalrStatements#71](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#71)]

### Implicit line continuation

In many cases, you can continue a statement on the next consecutive line without using the underscore character (`_`). The following syntax elements implicitly continue the statement on the next line of code.

- After a comma (`,`). For example:

   [!code-vb[VbVbalrLineContinuation#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#1)]

- After an open parenthesis (`(`) or before a closing parenthesis (`)`). For example:

   [!code-vb[VbVbalrLineContinuation#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#2)]

- After an open curly brace (`{`) or before a closing curly brace (`}`). For example:

    [!code-vb[VbVbalrLineContinuation#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#3)]

    For more information, see [Object Initializers: Named and Anonymous Types](./objects-and-classes/object-initializers-named-and-anonymous-types.md) or [Collection Initializers](./collection-initializers/index.md).

- After an open embedded expression (`<%=`) or before the close of an embedded expression (`%>`) within an XML literal. For example:

   [!code-vb[VbVbalrLineContinuation#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#4)]

   For more information, see [Embedded Expressions in XML](./xml/embedded-expressions-in-xml.md).

- After the concatenation operator (`&`). For example:

   [!code-vb[VbVbcnConventions#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnConventions/vb/Class1.vb#9)]

   For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).

- After assignment operators (`=`, `&=`, `:=`, `+=`, `-=`, `*=`, `/=`, `\=`, `^=`, `<<=`, `>>=`). For example:

   [!code-vb[VbVbalrLineContinuation#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#5)]

   For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).

- After binary operators (`+`, `-`, `/`, `*`, `Mod`, `<>`, `<`, `>`, `<=`, `>=`, `^`, `>>`, `<<`, `And`, `AndAlso`, `Or`, `OrElse`, `Like`, `Xor`) within an expression. For example:

   [!code-vb[VbVbalrLineContinuation#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#7)]

   For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).

- After the `Is` and `IsNot` operators. For example:

   [!code-vb[VbVbalrLineContinuation#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#8)]

   For more information, see [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md).

- After a member qualifier character (`.`) and before the member name. For example:

   [!code-vb[VbVbalrLineContinuation#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#5)]

   However, you must include a line-continuation character (`_`) following a member qualifier character when you are using the `With` statement or supplying values in the initialization list for a type. Consider breaking the line after the assignment operator (for example, `=`) when you are using `With` statements or object initialization lists. For example:

   [!code-vb[VbVbalrLineContinuation#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#14)]

   For more information, see [With...End With Statement](../../../visual-basic/language-reference/statements/with-end-with-statement.md) or [Object Initializers: Named and Anonymous Types](./objects-and-classes/object-initializers-named-and-anonymous-types.md).

- After an XML axis property qualifier (`.` or `.@` or `...`). However, you must include a line-continuation character (`_`) when you specify a member qualifier when you are using the `With` keyword. For example:

   [!code-vb[VbVbalrLineContinuation#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#9)]

   For more information, see [XML Axis Properties](../../../visual-basic/language-reference/xml-axis/index.md).

- After a less-than sign (<) or before a greater-than sign (`>`) when you specify an attribute. Also after a greater-than sign (`>`) when you specify an attribute. However, you must include a line-continuation character (`_`) when you specify assembly-level or module-level attributes. For example:

   [!code-vb[VbVbalrLineContinuation#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#10)]

   For more information, see [Attributes overview](../../../visual-basic/programming-guide/concepts/attributes/index.md).

- Before and after query operators (`Aggregate`, `Distinct`, `From`, `Group By`, `Group Join`, `Join`, `Let`, `Order By`, `Select`, `Skip`, `Skip While`, `Take`, `Take While`, `Where`, `In`, `Into`, `On`, `Ascending`, and `Descending`). You cannot break a line between the keywords of query operators that are made up of multiple keywords (`Order By`, `Group Join`, `Take While`, and `Skip While`). For example:

   [!code-vb[VbVbalrLineContinuation#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#11)]

   For more information, see [Queries](../../../visual-basic/language-reference/queries/index.md).

- After the `In` keyword in a `For Each` statement. For example:

   [!code-vb[VbVbalrLineContinuation#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#12)]

   For more information, see [For Each...Next Statement](../../../visual-basic/language-reference/statements/for-each-next-statement.md).

- After the `From` keyword in a collection initializer. For example:

   [!code-vb[VbVbalrLineContinuation#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/vbvbalrlinecontinuation/vb/module1.vb#13)]

   For more information, see [Collection Initializers](../../../visual-basic/programming-guide/language-features/collection-initializers/index.md).

## Adding comments

Source code is not always self-explanatory, even to the programmer who wrote it. To help document their code, therefore, most programmers make liberal use of embedded comments. Comments in code can explain a procedure or a particular instruction to anyone reading or working with it later. Visual Basic ignores comments during compilation, and they do not affect the compiled code.

Comment lines begin with an apostrophe (`'`) or `REM` followed by a space. They can be added anywhere in code, except within a string. To append a comment to a statement, insert an apostrophe or `REM` after the statement, followed by the comment. Comments can also go on their own separate line. The following example demonstrates these possibilities.

[!code-vb[VbVbalrStatements#72](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#72)]

## Checking compilation errors

If, after you type a line of code, the line is displayed with a wavy blue underline (an error message may appear as well), there is a syntax error in the statement. You must find out what is wrong with the statement (by looking in the task list, or hovering over the error with the mouse pointer and reading the error message) and correct it. Until you have fixed all syntax errors in your code, your program will fail to compile correctly.

## Related sections

|Term|Definition|
|---|---|
|[Assignment Operators](../../../visual-basic/language-reference/operators/assignment-operators.md)|Provides links to language reference pages covering assignment operators such as `=`, `*=`, and `&=`.|
|[Operators and Expressions](./operators-and-expressions/index.md)|Shows how to combine elements with operators to yield new values.|
|[How to: Break and Combine Statements in Code](../../../visual-basic/programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md)|Shows how to break a single statement into multiple lines and how to place multiple statements on the same line.|
|[How to: Label Statements](../../../visual-basic/programming-guide/program-structure/how-to-label-statements.md)|Shows how to label a line of code.|
