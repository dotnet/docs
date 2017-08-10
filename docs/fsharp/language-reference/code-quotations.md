---
title: Code Quotations (F#)
description: Learn about F# code quotations, a language feature that enables you to generate and work with F# code expressions programmatically.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: 4559e659-2b04-48bd-8a0b-8527920eec95 
---

# Code Quotations

> [!NOTE]
The API reference link will take you to MSDN.  The docs.microsoft.com API reference is not complete.

This topic describes *code quotations*, a language feature that enables you to generate and work with F# code expressions programmatically. This feature lets you generate an abstract syntax tree that represents F# code. The abstract syntax tree can then be traversed and processed according to the needs of your application. For example, you can use the tree to generate F# code or generate code in some other language.


## Quoted Expressions
A *quoted expression* is an F# expression in your code that is delimited in such a way that it is not compiled as part of your program, but instead is compiled into an object that represents an F# expression. You can mark a quoted expression in one of two ways: either with type information or without type information. If you want to include type information, you use the symbols `<@` and `@>` to delimit the quoted expression. If you do not need type information, you use the symbols `<@@` and `@@>`. The following code shows typed and untyped quotations.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-3/snippet501.fs)]

Traversing a large expression tree is faster if you do not include type information. The resulting type of an expression quoted with the typed symbols is `Expr<'T>`, where the type parameter has the type of the expression as determined by the F# compiler's type inference algorithm. When you use code quotations without type information, the type of the quoted expression is the non-generic type [Expr](https://msdn.microsoft.com/library/ed6a2caf-69d4-45c2-ab97-e9b3be9bce65). You can call the [Raw](https://msdn.microsoft.com/library/47fb94f1-e77f-4c68-aabc-2b0ba40d59c2) property on the typed `Expr` class to obtain the untyped `Expr` object.

There are a variety of static methods that allow you to generate F# expression objects programmatically in the `Expr` class without using quoted expressions.

Note that a code quotation must include a complete expression. For a `let` binding, for example, you need both the definition of the bound name and an additional expression that uses the binding. In verbose syntax, this is an expression that follows the `in` keyword. At the top-level in a module, this is just the next expression in the module, but in a quotation, it is explicitly required.

Therefore, the following expression is not valid.

```fsharp
// Not valid:
// <@ let f x = x + 1 @>
```

But the following expressions are valid.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-3/snippet502.fs)]

To use code quotations, you must add an import declaration (by using the `open` keyword) that opens the [Microsoft.FSharp.Quotations](https://msdn.microsoft.com/library/e9ce8a3a-e00c-4190-bad5-cce52ee089b2) namespace.

The F# PowerPack provides support for evaluating and executing F# expression objects.


## Expr Type
An instance of the `Expr` type represents an F# expression. Both the generic and the non-generic `Expr` types are documented in the F# library documentation. For more information, see [Microsoft.FSharp.Quotations Namespace](https://msdn.microsoft.com/visualfsharpdocs/conceptual/microsoft.fsharp.quotations-namespace-%5bfsharp%5d) and [Quotations.Expr Class](https://msdn.microsoft.com/visualfsharpdocs/conceptual/quotations.expr-class-%5bfsharp%5d).


## Splicing Operators
Splicing enables you to combine literal code quotations with expressions that you have created programmatically or from another code quotation. The `%` and `%%` operators enable you to add an F# expression object into a code quotation. You use the `%` operator to insert a typed expression object into a typed quotation; you use the `%%` operator to insert an untyped expression object into an untyped quotation. Both operators are unary prefix operators. Thus if `expr` is an untyped expression of type `Expr`, the following code is valid.

```fsharp
<@@ 1 + %%expr @@>
```

And if `expr` is a typed quotation of type `Expr<int>`, the following code is valid.

```fsharp
<@ 1 + %expr @>
```

## Example

### Description
The following example illustrates the use of code quotations to put F# code into an expression object and then print the F# code that represents the expression. A function `println` is defined that contains a recursive function `print` that displays an F# expression object (of type `Expr`) in a friendly format. There are several active patterns in the [Microsoft.FSharp.Quotations.Patterns](https://msdn.microsoft.com/library/093944a9-c752-403a-8983-5fcd5dbf92a4) and [Microsoft.FSharp.Quotations.DerivedPatterns](https://msdn.microsoft.com/library/d2434a6e-ae7b-4f3d-b567-c162938bc9cd) modules that can be used to analyze expression objects. This example does not include all the possible patterns that might appear in an F# expression. Any unrecognized pattern triggers a match to the wildcard pattern (`_`) and is rendered by using the `ToString` method, which, on the `Expr` type, lets you know the active pattern to add to your match expression.


### Code
[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-3/snippet601.fs)]
    
### Output

```fsharp
fun (x:System.Int32) -> x + 1
a + 1
let f = fun (x:System.Int32) -> x + 10 in f 10
```

## Example

### Description
You can also use the three active patterns in the [ExprShape module](https://msdn.microsoft.com/library/7685150e-2432-4d39-9338-57292eff18de) to traverse expression trees with fewer active patterns. These active patterns can be useful when you want to traverse a tree but you do not need all the information in most of the nodes. When you use these patterns, any F# expression matches one of the following three patterns: `ShapeVar` if the expression is a variable, `ShapeLambda` if the expression is a lambda expression, or `ShapeCombination` if the expression is anything else. If you traverse an expression tree by using the active patterns as in the previous code example, you have to use many more patterns to handle all possible F# expression types, and your code will be more complex. For more information, see [ExprShape.ShapeVar&#124;ShapeLambda&#124;ShapeCombination Active Pattern](https://msdn.microsoft.com/visualfsharpdocs/conceptual/exprshape.shapevarhshapelambdahshapecombination-active-pattern-%5bfsharp%5d).

The following code example can be used as a basis for more complex traversals. In this code, an expression tree is created for an expression that involves a function call, `add`. The [SpecificCall](https://msdn.microsoft.com/library/05a77b21-20fe-4b9a-8e07-aa999538198d) active pattern is used to detect any call to `add` in the expression tree. This active pattern assigns the arguments of the call to the `exprList` value. In this case, there are only two, so these are pulled out and the function is called recursively on the arguments. The results are inserted into a code quotation that represents a call to `mul` by using the splice operator (`%%`). The `println` function from the previous example is used to display the results.

The code in the other active pattern branches just regenerates the same expression tree, so the only change in the resulting expression is the change from `add` to `mul`.


### Code
[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-3/snippet701.fs)]
    
### Output

```fsharp
1 + Module1.add(2,Module1.add(3,4))
1 + Module1.mul(2,Module1.mul(3,4))
```

## See Also
[F# Language Reference](index.md)

