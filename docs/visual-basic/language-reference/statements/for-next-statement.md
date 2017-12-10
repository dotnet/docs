---
title: "For...Next Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Step"
  - "vb.Next"
  - "vb.To"
  - "vb.for"
helpviewer_keywords: 
  - "infinite loops"
  - "Next keyword [Visual Basic], For...Next statements"
  - "For keyword [Visual Basic], For...Next statements"
  - "Step keyword [Visual Basic], For...Next statements"
  - "operator overloading, For...Next statement"
  - "To keyword [Visual Basic], For...Next statements"
  - "endless loops"
  - "loops, endless"
  - "instructions, repeating"
  - "Next statement [Visual Basic], For...Next"
  - "For...Next statements"
  - "loop structures [Visual Basic], For...Next"
  - "loops, infinite"
  - "Exit statement [Visual Basic], For...Next statements"
  - "For statement [Visual Basic]"
ms.assetid: f5fc0d51-67ce-4c36-9f09-31c9a91c94e9
caps.latest.revision: 64
author: dotnet-bot
ms.author: dotnetcontent
---
# For...Next Statement (Visual Basic)
Repeats a group of statements a specified number of times.  
  
## Syntax  
  
```  
For counter [ As datatype ] = start To end [ Step step ]  
    [ statements ]  
    [ Continue For ]  
    [ statements ]  
    [ Exit For ]  
    [ statements ]  
Next [ counter ]  
```  
  
## Parts  
  
|Part|Description|  
|----------|-----------------|  
|`counter`|Required in the `For` statement. Numeric variable. The control variable for the loop. For more information, see [Counter Argument](#BKMK_Counter) later in this topic.|  
|`datatype`|Optional. Data type of `counter`. For more information, see [Counter Argument](#BKMK_Counter) later in this topic.|  
|`start`|Required. Numeric expression. The initial value of `counter`.|  
|`end`|Required. Numeric expression. The final value of `counter`.|  
|`step`|Optional. Numeric expression. The amount by which `counter` is incremented each time through the loop.|  
|`statements`|Optional. One or more statements between `For` and `Next` that run the specified number of times.|  
|`Continue For`|Optional. Transfers control to the next loop iteration.|  
|`Exit For`|Optional. Transfers control out of the `For` loop.|  
|`Next`|Required. Terminates the definition of the `For` loop.|  
  
> [!NOTE]
>  The `To` keyword is used in this statement to specify the range for the counter. You can also use this keyword in the [Select...Case Statement](../../../visual-basic/language-reference/statements/select-case-statement.md) and in array declarations. For more information about array declarations, see [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md).  
  
## Simple Examples  
 You use a `For`...`Next` structure when you want to repeat a set of statements a set number of times.  
  
 In the following example, the `index` variable starts with a value of 1 and is incremented with each iteration of the loop, ending after the value of `index` reaches 5.  
  
 [!code-vb[VbVbalrStatements#111](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_1.vb)]  
  
 In the following example, the `number` variable starts at 2 and is reduced by 0.25 on each iteration of the loop, ending after the value of `number` reaches 0. The `Step` argument of `-.25` reduces the value by 0.25 on each iteration of the loop.  
  
 [!code-vb[VbVbalrStatements#112](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_2.vb)]  
  
> [!TIP]
>  A [While...End While Statement](../../../visual-basic/language-reference/statements/while-end-while-statement.md) or [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md) works well when you don't know in advance how many times to run the statements in the loop. However, when you expect to run the loop a specific number of times, a `For`...`Next` loop is a better choice. You determine the number of iterations when you first enter the loop.  
  
## Nesting Loops  
 You can nest `For` loops by putting one loop within another. The following example demonstrates nested `For`...`Next` structures that have different step values. The outer loop creates a string for every iteration of the loop. The inner loop decrements a loop counter variable for every iteration of the loop.  
  
 [!code-vb[VbVbalrStatements#113](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_3.vb)]  
  
 When nesting loops, each loop must have a unique `counter` variable.  
  
 You can also nest different kinds control structures within each other. For more information, see [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md).  
  
## Exit For and Continue For  
 The `Exit For` statement immediately exits the `For`…`Next` loop and transfers control to the statement that follows the `Next` statement.  
  
 The `Continue For` statement transfers control immediately to the next iteration of the loop. For more information, see [Continue Statement](../../../visual-basic/language-reference/statements/continue-statement.md).  
  
 The following example illustrates the use of the `Continue For` and `Exit For` statements.  
  
 [!code-vb[VbVbalrStatements#115](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_4.vb)]  
  
 You can put any number of `Exit For` statements in a `For`…`Next` loop. When used within nested `For`…`Next` loops, `Exit For` exits the innermost loop and transfers control to the next higher level of nesting.  
  
 `Exit For` is often used after you evaluate some condition (for example, in an `If`...`Then`...`Else` structure). You might want to use `Exit For` for the following conditions:  
  
-   Continuing to iterate is unnecessary or impossible. An erroneous value or a termination request might create this condition.  
  
-   A `Try`...`Catch`...`Finally` statement catches an exception. You might use `Exit For` at the end of the `Finally` block.  
  
-   You have an endless loop, which is a loop that could run a large or even infinite number of times. If you detect such a condition, you can use `Exit For` to escape the loop. For more information, see [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md).  
  
## Technical Implementation  
 When a `For`...`Next` loop starts, Visual Basic evaluates `start`, `end`, and `step`. Visual Basic evaluates these values only at this time and then assigns `start` to `counter`. Before the statement block runs, Visual Basic compares `counter` to `end`. If `counter` is already larger than the `end` value (or smaller if `step` is negative), the `For` loop ends and control passes to the statement that follows the `Next` statement. Otherwise, the statement block runs.  
  
 Each time Visual Basic encounters the `Next` statement, it increments `counter` by `step` and returns to the `For` statement. Again it compares `counter` to `end`, and again it either runs the block or exits the loop, depending on the result. This process continues until `counter` passes `end` or an `Exit For` statement is encountered.  
  
 The loop doesn't stop until `counter` has passed `end`. If `counter` is equal to `end`, the loop continues. The comparison that determines whether to run the block is `counter` <= `end` if `step` is positive and `counter` >= `end` if `step` is negative.  
  
 If you change the value of `counter` while inside a loop, your code might be more difficult to read and debug. Changing the value of `start`, `end`, or `step` doesn't affect the iteration values that were determined when the loop was first entered.  
  
 If you nest loops, the compiler signals an error if it encounters the `Next` statement of an outer nesting level before the `Next` statement of an inner level. However, the compiler can detect this overlapping error only if you specify `counter` in every `Next` statement.  
  
### Step Argument  
 The value of `step` can be either positive or negative. This parameter determines loop processing according to the following table:  
  
|**Step value**|**Loop executes if**|  
|--------------------|--------------------------|  
|Positive or zero|`counter` <= `end`|  
|Negative|`counter` >= `end`|  
  
 The default value of `step` is 1.  
  
###  <a name="BKMK_Counter"></a> Counter Argument  
 The following table indicates whether `counter` defines a new local variable that’s scoped to the entire `For…Next` loop. This determination depends on whether `datatype` is present and whether `counter` is already defined.  
  
|Is `datatype` present?|Is `counter` already defined?|Result (whether `counter` defines a new local variable that’s scoped to the entire `For...Next` loop)|  
|----------------------------|-----------------------------------|-------------------------------------------------------------------------------------------------------------|  
|No|Yes|No, because `counter` is already defined. If the scope of `counter` isn't local to the procedure, a compile-time warning occurs.|  
|No|No|Yes. The data type is inferred from the `start`, `end`, and `step` expressions. For information about type inference, see [Option Infer Statement](../../../visual-basic/language-reference/statements/option-infer-statement.md) and [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md).|  
|Yes|Yes|Yes, but only if the existing `counter` variable is defined outside the procedure. That variable remains separate. If the scope of the existing `counter` variable is local to the procedure, a compile-time error occurs.|  
|Yes|No|Yes.|  
  
 The data type of `counter` determines the type of the iteration, which must be one of the following types:  
  
-   A `Byte`, `SByte`, `UShort`, `Short`, `UInteger`, `Integer`, `ULong`, `Long`, `Decimal`, `Single`, or `Double`.  
  
-   An enumeration that you declare by using an [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md).  
  
-   An `Object`.  
  
-   A type `T` that has the following operators, where `B` is a type that can be used in a `Boolean` expression.  
  
     `Public Shared Operator >= (op1 As T, op2 As T) As B`  
  
     `Public Shared Operator <= (op1 As T, op2 As T) As B`  
  
     `Public Shared Operator - (op1 As T, op2 As T) As T`  
  
     `Public Shared Operator + (op1 As T, op2 As T) As T`  
  
 You can optionally specify the `counter` variable in the `Next` statement. This syntax improves the readability of your program, especially if you have nested `For` loops. You must specify the variable that appears in the corresponding `For` statement.  
  
 The `start`, `end`, and `step` expressions can evaluate to any data type that widens to the type of `counter`. If you use a user-defined type for `counter`, you might have to define the `CType` conversion operator to convert the types of `start`, `end`, or `step` to the type of `counter`.  
  
## Example  
 The following example removes all elements from a generic list. Instead of a [For Each...Next Statement](../../../visual-basic/language-reference/statements/for-each-next-statement.md), the example shows a `For`...`Next` statement that iterates in descending order. The example uses this technique because the `removeAt` method causes elements after the removed element to have a lower index value.  
  
 [!code-vb[VbVbalrStatements#114](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_5.vb)]  
  
## Example  
 The following example iterates through an enumeration that's declared by using an [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md).  
  
 [!code-vb[VbVbalrStatements#116](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_6.vb)]  
  
## Example  
 In the following example, the statement parameters use a class that has operator overloads for the `+`, `-`, `>=`, and `<=` operators.  
  
 [!code-vb[VbVbalrStatements#117](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/for-next-statement_7.vb)]  
  
## See Also  
 <xref:System.Collections.Generic.List%601>  
 [Loop Structures](../../../visual-basic/programming-guide/language-features/control-flow/loop-structures.md)  
 [While...End While Statement](../../../visual-basic/language-reference/statements/while-end-while-statement.md)  
 [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md)  
 [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)  
 [Collections](../../programming-guide/concepts/collections.md)
