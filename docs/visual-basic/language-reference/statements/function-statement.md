---
title: "Function Statement (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vb.Function"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "procedures, creating"
  - "Function procedures, Function statement syntax"
  - "functions [Visual Basic], function procedures"
  - "ParamArray keyword, Function statements"
  - "Private keyword, Function statements"
  - "declarations, procedures"
  - "procedures, declaration"
  - "Public keyword, in Function statement"
  - "ByVal keyword, Function statements"
  - "procedures, recursive"
  - "Implements keyword, Function statements"
  - "procedures, returning values"
  - "Exit statement, in Function procedures"
  - "recursive procedures"
  - "As keyword, in Function statement"
  - "Optional keyword, Function statements"
  - "Function statement"
  - "Visual Basic code, Function procedures"
  - "procedures, function"
  - "ByRef keyword, Function statements"
  - "Friend keyword, Function statements"
  - "End keyword, Function statements"
  - "Handles keyword, Function statements"
ms.assetid: a4497077-0f46-4ede-a27f-9e8670df52b9
caps.latest.revision: 62
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Function Statement (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Declares the name, parameters, and code that define a `Function` procedure.  
  
## Syntax  
  
```  
[ <attributelist> ] [ accessmodifier ] [ proceduremodifiers ] [ Shared ] [ Shadows ] [ Async | Iterator ]  
Function name [ (Of typeparamlist) ] [ (parameterlist) ] [ As returntype ] [ Implements implementslist | Handles eventlist ]  
    [ statements ]  
    [ Exit Function ]  
    [ statements ]  
End Function  
```  
  
## Parts  
  
-   `attributelist`  
  
     Optional. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).  
  
-   `accessmodifier`  
  
     Optional. Can be one of the following:  
  
    -   [Public](../../../visual-basic/language-reference/modifiers/public.md)  
  
    -   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
  
    -   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
  
    -   [Private](../../../visual-basic/language-reference/modifiers/private.md)  
  
    -   `Protected Friend`  
  
     See [Access Levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
-   `proceduremodifiers`  
  
     Optional. Can be one of the following:  
  
    -   [Overloads](../../../visual-basic/language-reference/modifiers/overloads.md)  
  
    -   [Overrides](../../../visual-basic/language-reference/modifiers/overrides.md)  
  
    -   [Overridable](../../../visual-basic/language-reference/modifiers/overridable.md)  
  
    -   [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md)  
  
    -   [MustOverride](../../../visual-basic/language-reference/modifiers/mustoverride.md)  
  
    -   `MustOverride Overrides`  
  
    -   `NotOverridable Overrides`  
  
-   `Shared`  
  
     Optional. See [Shared](../../../visual-basic/language-reference/modifiers/shared.md).  
  
-   `Shadows`  
  
     Optional. See [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md).  
  
-   `Async`  
  
     Optional. See [Async](../../../visual-basic/language-reference/modifiers/async.md).  
  
-   `Iterator`  
  
     Optional. See [Iterator](../../../visual-basic/language-reference/modifiers/iterator.md).  
  
-   `name`  
  
     Required. Name of the procedure. See [Declared Element Names](../../../visual-basic/programming-guide/language-features/declared-elements/declared-element-names.md).  
  
-   `typeparamlist`  
  
     Optional. List of type parameters for a generic procedure. See [Type List](../../../visual-basic/language-reference/statements/type-list.md).  
  
-   `parameterlist`  
  
     Optional. List of local variable names representing the parameters of this procedure. See [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md).  
  
-   `returntype`  
  
     Required if `Option Strict` is `On`. Data type of the value returned by this procedure.  
  
-   `Implements`  
  
     Optional. Indicates that this procedure implements one or more `Function` procedures, each one defined in an interface implemented by this procedure's containing class or structure. See [Implements Statement](../../../visual-basic/language-reference/statements/implements-statement.md).  
  
-   `implementslist`  
  
     Required if `Implements` is supplied. List of `Function` procedures being implemented.  
  
     `implementedprocedure [ , implementedprocedure ... ]`  
  
     Each `implementedprocedure` has the following syntax and parts:  
  
     `interface.definedname`  
  
    |||  
    |-|-|  
    |Part|Description|  
    |`interface`|Required. Name of an interface implemented by this procedure's containing class or structure.|  
    |`definedname`|Required. Name by which the procedure is defined in `interface`.|  
  
-   `Handles`  
  
     Optional. Indicates that this procedure can handle one or more specific events. See [Handles](../../../visual-basic/language-reference/statements/handles-clause.md).  
  
-   `eventlist`  
  
     Required if `Handles` is supplied. List of events this procedure handles.  
  
     `eventspecifier [ , eventspecifier ... ]`  
  
     Each `eventspecifier` has the following syntax and parts:  
  
     `eventvariable.event`  
  
    |||  
    |-|-|  
    |Part|Description|  
    |`eventvariable`|Required. Object variable declared with the data type of the class or structure that raises the event.|  
    |`event`|Required. Name of the event this procedure handles.|  
  
-   `statements`  
  
     Optional. Block of statements to be executed within this procedure.  
  
-   `End Function`  
  
     Terminates the definition of this procedure.  
  
## Remarks  
 All executable code must be inside a procedure. Each procedure, in turn, is declared within a class, a structure, or a module that is referred to as the containing class, structure, or module.  
  
 To return a value to the calling code, use a `Function` procedure; otherwise, use a `Sub` procedure.  
  
## Defining a Function  
 You can define a `Function` procedure only at the module level. Therefore, the declaration context for a function must be a class, a structure, a module, or an interface and can't be a source file, a namespace, a procedure, or a block. For more information, see [Declaration Contexts and Default Access Levels](../../../visual-basic/language-reference/statements/declaration-contexts-and-default-access-levels.md).  
  
 `Function` procedures default to public access. You can adjust their access levels with the access modifiers.  
  
 A `Function` procedure can declare the data type of the value that the procedure returns. You can specify any data type or the name of an enumeration, a structure, a class, or an interface. If you don't specify the `returntype` parameter, the procedure returns `Object`.  
  
 If this procedure uses the `Implements` keyword, the containing class or structure must also have an `Implements` statement that immediately follows its `Class` or `Structure` statement. The `Implements` statement must include each interface that's specified in `implementslist`. However, the name by which an interface defines the `Function` (in `definedname`) doesn't need to match the name of this procedure (in `name`).  
  
> [!NOTE]
>  You can use lambda expressions to define function expressions inline. For more information, see [Function Expression](../../../visual-basic/language-reference/operators/function-expression.md) and [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md).  
  
## Returning from a Function  
 When the `Function` procedure returns to the calling code, execution continues with the statement that follows the statement that called the procedure.  
  
 To return a value from a function, you can either assign the value to the function name or include it in a `Return` statement.  
  
 The `Return` statement simultaneously assigns the return value and exits the function, as the following example shows.  
  
 [!code-vb[VbVbalrStatements#24](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#24)]  
  
 The following example assigns the return value to the function name `myFunction` and then uses the `Exit Function` statement to return.  
  
 [!code-vb[VbVbalrStatements#23](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#23)]  
  
 The `Exit Function` and `Return` statements cause an immediate exit from a `Function` procedure. Any number of `Exit Function` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Function` and `Return` statements.  
  
 If you use `Exit Function` without assigning a value to `name`, the procedure returns the default value for the data type that's specified in `returntype`. If `returntype` isn't specified, the procedure returns `Nothing`, which is the default value for `Object`.  
  
## Calling a Function  
 You call a `Function` procedure by using the procedure name, followed by the argument list in parentheses, in an expression. You can omit the parentheses only if you aren't supplying any arguments. However, your code is more readable if you always include the parentheses.  
  
 You call a `Function` procedure the same way that you call any library function such as `Sqrt`, `Cos`, or `ChrW`.  
  
 You can also call a function by using the `Call` keyword. In that case, the return value is ignored. Use of the `Call` keyword isn't recommended in most cases. For more information, see [Call Statement](../../../visual-basic/language-reference/statements/call-statement.md).  
  
 Visual Basic sometimes rearranges arithmetic expressions to increase internal efficiency. For that reason, you shouldn't use a `Function` procedure in an arithmetic expression when the function changes the value of variables in the same expression.  
  
## Async Functions  
 The *Async* feature allows you to invoke asynchronous functions without using explicit callbacks or manually splitting your code across multiple functions or lambda expressions.  
  
 If you mark a function with the [Async](../../../visual-basic/language-reference/modifiers/async.md) modifier, you can use the [Await](../../../visual-basic/language-reference/operators/await-operator.md) operator in the function. When control reaches an `Await` expression in the `Async` function, control returns to the caller, and progress in the function is suspended until the awaited task completes. When the task is complete, execution can resume in the function.  
  
> [!NOTE]
>  An `Async` procedure returns to the caller when either it encounters the first awaited object that’s not yet complete, or it gets to the end of the `Async` procedure, whichever occurs first.  
  
 An `Async` function can have a return type of <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.Task>. An example of an `Async` function that has a return type of <xref:System.Threading.Tasks.Task%601> is provided below.  
  
 An `Async` function cannot declare any [ByRef](../../../visual-basic/language-reference/modifiers/byref.md) parameters.  
  
 A [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md) can also be marked with the `Async` modifier. This is primarily used for event handlers, where a value cannot be returned. An `Async``Sub` procedure can't be awaited, and the caller of an `Async``Sub` procedure can't catch exceptions that are thrown by the `Sub` procedure.  
  
 For more information about `Async` functions, see [Asynchronous Programming with Async and Await](../Topic/Asynchronous%20Programming%20with%20Async%20and%20Await%20\(C%23%20and%20Visual%20Basic\).md), [Control Flow in Async Programs](../Topic/Control%20Flow%20in%20Async%20Programs%20\(C%23%20and%20Visual%20Basic\).md), and [Async Return Types](../Topic/Async%20Return%20Types%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Iterator Functions  
 An *iterator* function performs a custom iteration over a collection, such as a list or array. An iterator function uses the [Yield](../../../visual-basic/language-reference/statements/yield-statement.md) statement to return each element one at a time. When a [Yield](../../../visual-basic/language-reference/statements/yield-statement.md) statement is reached, the current location in code is remembered. Execution is restarted from that location the next time the iterator function is called.  
  
 You call an iterator from client code by using a [For Each…Next](../../../visual-basic/language-reference/statements/for-each-next-statement.md) statement.  
  
 The return type of an iterator function can be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.  
  
 For more information, see [Iterators](../Topic/Iterators%20\(C%23%20and%20Visual%20Basic\).md).  
  
## Example  
 The following example uses the `Function` statement to declare the name, parameters, and code that form the body of a `Function` procedure. The `ParamArray` modifier enables the function to accept a variable number of arguments.  
  
 [!code-vb[VbVbalrStatements#25](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#25)]  
  
## Example  
 The following example invokes the function declared in the preceding example.  
  
 [!code-vb[VbVbalrStatements#26](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#26)]  
  
## Example  
 In the following example, `DelayAsync` is an `Async``Function` that has a return type of <xref:System.Threading.Tasks.Task%601>. `DelayAsync` has a `Return` statement that returns an integer. Therefore the function declaration of `DelayAsync` needs to have a return type of `Task(Of Integer)`. Because the return type is `Task(Of Integer)`, the evaluation of the `Await` expression in `DoSomethingAsync` produces an integer. This is demonstrated in this statement: `Dim result As Integer = Await delayTask`.  
  
 The `startButton_Click` procedure is an example of an `Async Sub` procedure. Because `DoSomethingAsync` is an `Async` function, the task for the call to `DoSomethingAsync` must be awaited, as the following statement demonstrates: `Await DoSomethingAsync()`. The `startButton_Click``Sub` procedure must be defined with the `Async` modifier because it has an `Await` expression.  
  
 [!code-vb[csAsyncMethod#1](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/csasyncmethod/vb/mainwindow.xaml.vb#1)]  
  
## See Also  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)   
 [Function Procedures](../../../visual-basic/programming-guide/language-features/procedures/function-procedures.md)   
 [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md)   
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)   
 [Call Statement](../../../visual-basic/language-reference/statements/call-statement.md)   
 [Of](../../../visual-basic/language-reference/statements/of-clause.md)   
 [Parameter Arrays](../../../visual-basic/programming-guide/language-features/procedures/parameter-arrays.md)   
 [How to: Use a Generic Class](../../../visual-basic/programming-guide/language-features/data-types/how-to-use-a-generic-class.md)   
 [Troubleshooting Procedures](../../../visual-basic/programming-guide/language-features/procedures/troubleshooting-procedures.md)   
 [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)   
 [Function Expression](../../../visual-basic/language-reference/operators/function-expression.md)