---
title: Reference Cells (F#)
description: Reference Cells (F#)
keywords: visual f#, f#, functional programming
author: dend
manager: danielfe
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: visual-studio-dev14
ms.technology: devlang-fsharp
ms.assetid: 09a0b221-ea21-45c4-bae8-5e4a339750c4
redirect_url: https://docs.microsoft.com/dotnet/articles/fsharp/language-reference/reference-cells
---

# Reference Cells (F#)

*Reference cells* are storage locations that enable you to create mutable values with reference semantics.


## Syntax

```fsharp
ref expression
```

## Remarks
You use the `ref` operator before a value to create a new reference cell that encapsulates the value. You can then change the underlying value because it is mutable.

A reference cell holds an actual value; it is not just an address. When you create a reference cell by using the `ref` operator, you create a copy of the underlying value as an encapsulated mutable value.

You can dereference a reference cell by using the `!` (bang) operator.

The following code example illustrates the declaration and use of reference cells.

[!code-fsharp[Main](snippets/fslangref1/snippet2201.fs)]

The output is **50**.

Reference cells are instances of the `Ref` generic record type, which is declared as follows.

```fsharp
type Ref<'a> =
{ mutable contents: 'a }
```

The type `'a ref` is a synonym for `Ref<'a>`. The compiler and IntelliSense in the IDE display the former for this type, but the underlying definition is the latter.

The `ref` operator creates a new reference cell. The following code is the declaration of the `ref` operator.

```fsharp
let ref x = { contents = x }
```

The following table shows the features that are available on the reference cell.



|Operator, member, or field|Description|Type|Definition|
|--------------------------|-----------|----|----------|
|**!** (dereference operator)|Returns the underlying value.|**'a ref -&gt; 'a**|**let (!) r = r.contents**|
|**:=** (assignment operator)|Changes the underlying value.|**'a ref -&gt; 'a -&gt; unit**|**let (:=) r x = r.contents &lt;- x**|
|**ref** (operator)|Encapsulates a value into a new reference cell.|**'a -&gt; 'a ref**|**let ref x = { contents = x }**|
|**Value** (property)|Gets or sets the underlying value.|**unit -&gt; 'a**|**member x.Value = x.contents**|
|**contents** (record field)|Gets or sets the underlying value.|**'a**|**let ref x = { contents = x }**|
There are several ways to access the underlying value. The value returned by the dereference operator (**!**) is not an assignable value. Therefore, if you are modifying the underlying value, you must use the assignment operator (**:=**) instead.

Both the `Value` property and the `contents` field are assignable values. Therefore, you can use these to either access or change the underlying value, as shown in the following code.

[!code-fsharp[Main](snippets/fslangref1/snippet2203.fs)]

The output is as follows.

```
10
10
11
12
```

The field `contents` is provided for compatibility with other versions of ML and will produce a warning during compilation. To disable the warning, use the `--mlcompatibility` compiler option. For more information, see [Compiler Options &#40;F&#35;&#41;](Compiler-Options-%5BFSharp%5D.md).

The following code illustrates the use of reference cells in parameter passing. The Incrementor type has a method Increment that takes a parameter that includes byref in the parameter type. The byref in the parameter type indicates that callers must pass a reference cell or the address of a typical variable of the specified type, in this case int. The remaining code illustrates how to call Increment with both of these types of arguments, and shows the use of the ref operator on a variable to create a reference cell (ref myDelta1). It then shows the use of the address-of operator (&amp;) to generate an appropriate argument. Finally, the Increment method is called again by using a reference cell that is declared by using a let binding. The final line of code demonstrates the use of the ! operator to dereference the reference cell for printing.

[!code-fsharp[Main](snippets/fslangref1/snippet2204.fs)]

For more information about how to pass by reference, see [Parameters and Arguments &#40;F&#35;&#41;](Parameters-and-Arguments-%5BFSharp%5D.md).

>[!NOTE] {C# programmers should know that ref works differently in F# than it does in C#. For example, the use of ref when you pass an argument does not have the same effect in F# as it does in C#.

## Reference Cells vs. Mutable Variables
Reference cells and mutable variables can often be used in the same situations. However, there are some situations in which mutable variables cannot be used, and you must use a reference cell instead. In general, you should prefer mutable variables where they are accepted by the compiler. However, in expressions that generate closures, the compiler will report that you cannot use mutable variables. *Closures* are local functions that are generated by certain F# expressions, such as lambda expressions, sequence expressions, computation expressions, and curried functions that use partially applied arguments. The closures generated by these expressions are stored for later evaluation. This process is not compatible with mutable variables. Therefore, if you need mutable state in such an expression, you have to use reference cells. For more information about closures, see Closures (F#).

The following code example demonstrates the scenario in which you must use a reference cell.

[!code-fsharp[Main](snippets/fslangref1/snippet2205.fs)]

In the previous code, the reference cell `finished` is included in local state, that is, variables that are in the closure are created and used entirely within the expression, in this case a sequence expression. Consider what occurs when the variables are non-local. Closures can also access non-local state, but when this occurs, the variables are copied and stored by value. This process is known as *value semantics*. This means that the values at the time of the copy are stored, and any subsequent changes to the variables are not reflected. If you want to track the changes of non-local variables, or, in other words, if you need a closure that interacts with non-local state by using *reference semantics*, you must use a reference cell.

The following code examples demonstrate the use of reference cells in closures. In this case, the closure results from the partial application of function arguments.

[!code-fsharp[Main](snippets/fslangref1/snippet2207.fs)]

## See Also
[F&#35; Language Reference](FSharp-Language-Reference.md)

[Parameters and Arguments &#40;F&#35;&#41;](Parameters-and-Arguments-%5BFSharp%5D.md)

[Symbol and Operator Reference &#40;F&#35;&#41;](Symbol-and-Operator-Reference-%5BFSharp%5D.md)
