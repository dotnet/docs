---
title: "Sub Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Sub"
helpviewer_keywords: 
  - "Public keyword [Visual Basic], Sub statements"
  - "procedures [Visual Basic], creating"
  - "declaring procedures [Visual Basic], Sub statement"
  - "arguments [Visual Basic], Sub procedures"
  - "As keyword [Visual Basic], Sub statements"
  - "Optional keyword [Visual Basic], Sub statements"
  - "declarations [Visual Basic], procedures"
  - "Sub keyword [Visual Basic]"
  - "Handles keyword [Visual Basic], Sub statements"
  - "Protected Friend keyword [Visual Basic]"
  - "ParamArray keyword [Visual Basic], Sub statements"
  - "Implements keyword [Visual Basic], Sub statements"
  - "Sub statement [Visual Basic]"
  - "subroutines"
  - "ByRef keyword [Visual Basic], Sub statements"
  - "Sub procedures [Visual Basic], Sub statement"
  - "recursive procedures"
  - "Private keyword [Visual Basic], Sub statements"
  - "Friend keyword [Visual Basic], Sub statements"
  - "Exit statement [Visual Basic], Sub statements"
  - "procedures [Visual Basic], Sub"
  - "End keyword [Visual Basic], Sub statements"
  - "ByVal keyword [Visual Basic], Sub statements"
  - "Visual Basic code, Sub procedures"
ms.assetid: e347d700-d06c-405b-b302-e9b1edb57dfc
caps.latest.revision: 52
author: dotnet-bot
ms.author: dotnetcontent
---
# Sub Statement (Visual Basic)
Declares the name, parameters, and code that define a `Sub` procedure.  
  
## Syntax  
  
```  
[ <attributelist> ] [ Partial ] [ accessmodifier ] [ proceduremodifiers ] [ Shared ] [ Shadows ] [ Async ]  
Sub name [ (Of typeparamlist) ] [ (parameterlist) ] [ Implements implementslist | Handles eventlist ]  
    [ statements ]  
    [ Exit Sub ]  
    [ statements ]  
End Sub  
```  
  
## Parts  
  
-   `attributelist`  
  
     Optional. See [Attribute List](attribute-list.md).  
  
-   `Partial`  
  
     Optional. Indicates definition of a partial method. See [Partial Methods](../../../visual-basic/programming-guide/language-features/procedures/partial-methods.md).  
  
-   `accessmodifier`  
  
     Optional. Can be one of the following:  
  
    -   [Public](../modifiers/public.md)  
  
    -   [Protected](../modifiers/protected.md)  
  
    -   [Friend](../modifiers/friend.md)  
  
    -   [Private](../modifiers/private.md)  
  
    -   `Protected Friend`  
  
     See [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
-   `proceduremodifiers`  
  
     Optional. Can be one of the following:  
  
    -   [Overloads](../modifiers/overloads.md)  
  
    -   [Overrides](../modifiers/overrides.md)  
  
    -   [Overridable](../modifiers/overridable.md)  
  
    -   [NotOverridable](../modifiers/notoverridable.md)  
  
    -   [MustOverride](../modifiers/mustoverride.md)  
  
    -   `MustOverride Overrides`  
  
    -   `NotOverridable Overrides`  
  
-   `Shared`  
  
     Optional. See [Shared](../modifiers/shared.md).  
  
-   `Shadows`  
  
     Optional. See [Shadows](../modifiers/shadows.md).  
  
-   `Async`  
  
     Optional. See [Async](../modifiers/async.md).  
  
-   `name`  
  
     Required. Name of the procedure. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md). To create a constructor procedure for a class, set the name of a `Sub` procedure to the `New` keyword. For more information, see [Object Lifetime: How Objects Are Created and Destroyed](../../../visual-basic/programming-guide/language-features/objects-and-classes/object-lifetime-how-objects-are-created-and-destroyed.md).  
  
-   `typeparamlist`  
  
     Optional. List of type parameters for a generic procedure. See [Type List](type-list.md).  
  
-   `parameterlist`  
  
     Optional. List of local variable names representing the parameters of this procedure. See [Parameter List](parameter-list.md).  
  
-   `Implements`  
  
     Optional. Indicates that this procedure implements one or more `Sub` procedures, each one defined in an interface implemented by this procedure's containing class or structure. See [Implements Statement](implements-statement.md).  
  
-   `implementslist`  
  
     Required if `Implements` is supplied. List of `Sub` procedures being implemented.  
  
     `implementedprocedure [ , implementedprocedure ... ]`  
  
     Each `implementedprocedure` has the following syntax and parts:  
  
     `interface.definedname`  
  
    |Part|Description|  
    |---|---|  
    |`interface`|Required. Name of an interface implemented by this procedure's containing class or structure.|  
    |`definedname`|Required. Name by which the procedure is defined in `interface`.|  
  
-   `Handles`  
  
     Optional. Indicates that this procedure can handle one or more specific events. See [Handles](handles-clause.md).  
  
-   `eventlist`  
  
     Required if `Handles` is supplied. List of events this procedure handles.  
  
     `eventspecifier [ , eventspecifier ... ]`  
  
     Each `eventspecifier` has the following syntax and parts:  
  
     `eventvariable.event`  
  
    |Part|Description|  
    |---|---|  
    |`eventvariable`|Required. Object variable declared with the data type of the class or structure that raises the event.|  
    |`event`|Required. Name of the event this procedure handles.|  
  
-   `statements`  
  
     Optional. Block of statements to run within this procedure.  
  
-   `End Sub`  
  
     Terminates the definition of this procedure.  
  
## Remarks  
 All executable code must be inside a procedure. Use a `Sub` procedure when you don't want to return a value to the calling code. Use a `Function` procedure when you want to return a value.  
  
## Defining a Sub Procedure  
 You can define a `Sub` procedure only at the module level. The declaration context for a sub procedure must, therefore, be a class, a structure, a module, or an interface and can't be a source file, a namespace, a procedure, or a block. For more information, see [Declaration Contexts and Default Access Levels](declaration-contexts-and-default-access-levels.md).  
  
 `Sub` procedures default to public access. You can adjust their access levels by using the access modifiers.  
  
 If the procedure uses the `Implements` keyword, the containing class or structure must have an `Implements` statement that immediately follows its `Class` or `Structure` statement. The `Implements` statement must include each interface that's specified in `implementslist`. However, the name by which an interface defines the `Sub` (in `definedname`) doesn't have to match the name of this procedure (in `name`).  
  
## Returning from a Sub Procedure  
 When a `Sub` procedure returns to the calling code, execution continues with the statement after the statement that called it.  
  
 The following example shows a return from a `Sub` procedure.  
  
```vb  
Sub mySub(ByVal q As String)  
    Return  
End Sub   
```  
  
 The `Exit Sub` and `Return` statements cause an immediate exit from a `Sub` procedure. Any number of `Exit Sub` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Sub` and `Return` statements.  
  
## Calling a Sub Procedure  
 You call a `Sub` procedure by using the procedure name in a statement and then following that name with its argument list in parentheses. You can omit the parentheses only if you don't supply any arguments. However, your code is more readable if you always include the parentheses.  
  
 A `Sub` procedure and a `Function` procedure  can have parameters and perform a series of statements. However, a `Function` procedure returns a value, and a `Sub` procedure doesn't. Therefore, you can't use a `Sub` procedure in an expression.  
  
 You can use the `Call` keyword when you call a `Sub` procedure, but that keyword isn't recommended for most uses. For more information, see [Call Statement](call-statement.md).  
  
 Visual Basic sometimes rearranges arithmetic expressions to increase internal efficiency. For that reason, if your argument list includes expressions that call other procedures, you shouldn't assume that those expressions will be called in a particular order.  
  
## Async Sub Procedures  
 By using the Async feature, you can invoke asynchronous functions without using explicit callbacks or manually splitting your code across multiple functions or lambda expressions.  
  
 If you mark a procedure with the [Async](../modifiers/async.md) modifier, you can use the [Await](../../../visual-basic/language-reference/operators/await-operator.md) operator in the procedure. When control reaches an `Await` expression in the `Async` procedure, control returns to the caller, and progress in the procedure is suspended until the awaited task completes. When the task is complete, execution can resume in the procedure.  
  
> [!NOTE]
>  An `Async` procedure returns to the caller when either the first awaited object that’s not yet complete is encountered or the end of the `Async` procedure is reached, whichever occurs first.  
  
 You can also mark a [Function Statement](function-statement.md) with the `Async` modifier. An `Async` function can have a return type of <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.Task>. An example later in this topic shows an `Async` function that has a return type of <xref:System.Threading.Tasks.Task%601>.  
  
 `Async` `Sub` procedures are primarily used for event handlers, where a value can't be returned. An `Async``Sub` procedure can't be awaited, and the caller of an `Async``Sub` procedure can't catch exceptions that the `Sub` procedure throws.  
  
 An `Async` procedure can't declare any [ByRef](../modifiers/byref.md) parameters.  
  
 For more information about `Async` procedures, see [Asynchronous Programming with Async and Await](../../../visual-basic/programming-guide/concepts/async/index.md), [Control Flow in Async Programs](../../../visual-basic/programming-guide/concepts/async/control-flow-in-async-programs.md), and [Async Return Types](../../../visual-basic/programming-guide/concepts/async/async-return-types.md).  
  
## Example  
 The following example uses the `Sub` statement to define the name, parameters, and code that form the body of a `Sub` procedure.  
  
 [!code-vb[VbVbalrStatements#58](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/sub-statement_1.vb)]  
  
## Example  
 In the following example, `DelayAsync` is an `Async``Function` that has a return type of <xref:System.Threading.Tasks.Task%601>. `DelayAsync` has a `Return` statement that returns an integer. Therefore, the function declaration of `DelayAsync` must have a return type of `Task(Of Integer)`. Because the return type is `Task(Of Integer)`, the evaluation of the `Await` expression in `DoSomethingAsync` produces an integer, as the following statement shows: `Dim result As Integer = Await delayTask`.  
  
 The `startButton_Click` procedure is an example of an `Async Sub` procedure. Because `DoSomethingAsync` is an `Async` function, the task for the call to `DoSomethingAsync` must be awaited, as the following statement shows: `Await DoSomethingAsync()`. The `startButton_Click``Sub` procedure must be defined with the `Async` modifier because it has an `Await` expression.  
  
 [!code-vb[csAsyncMethod#1](../../../csharp/programming-guide/classes-and-structs/codesnippet/VisualBasic/sub-statement_2.vb)]  
  
## See Also  
 [Implements Statement](implements-statement.md)  
 [Function Statement](function-statement.md)  
 [Parameter List](parameter-list.md)  
 [Dim Statement](dim-statement.md)  
 [Call Statement](call-statement.md)  
 [Of](of-clause.md)  
 [Parameter Arrays](../../../visual-basic/programming-guide/language-features/procedures/parameter-arrays.md)  
 [How to: Use a Generic Class](../../../visual-basic/programming-guide/language-features/data-types/how-to-use-a-generic-class.md)  
 [Troubleshooting Procedures](../../../visual-basic/programming-guide/language-features/procedures/troubleshooting-procedures.md)  
 [Partial Methods](../../../visual-basic/programming-guide/language-features/procedures/partial-methods.md)
