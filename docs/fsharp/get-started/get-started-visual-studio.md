---
title: Get started with F# in Visual Studio
description: Learn how to use F# with Visual Studio.
ms.date: 07/03/2018
---
# Get started with F# in Visual Studio

F# and the Visual F# tooling are supported in the Visual Studio IDE.

To begin, ensure that you have [Visual Studio installed with F#](install-fsharp.md#install-f-with-visual-studio).

## Creating a console application

One of the most basic projects in Visual Studio is the Console Application.  Here's how to do it.  Once Visual Studio is open:

1. On the **File** menu, point to **New**, and then choose **Project**.

2.  In the New Project dialog, under **Templates**, you should see **Visual F#**.  Choose this to show the F# templates.

3. Select either **.NET Core Console app** or **Console app**.

3. Choose the **Okay** button to create the F# project!  You should now see an F# project in the Solution Explorer.

## Writing your code

Let's get started by writing some code first.  Make sure that the `Program.fs` file is open, and then replace its contents with the following:

[!code-fsharp[HelloSquare](../../../samples/snippets/fsharp/getting-started/hello-square.fs)]

In the previous code sample, a function `square` has been defined which takes an input named `x` and multiplies it by itself.  Because F# uses [Type Inference](../language-reference/type-inference.md), the type of `x` doesn't need to be specified.  The F# compiler understands the types where multiplication is valid, and will assign a type to `x` based on how `square` is called.  If you hover over `square`, you should see the following:

```
val square: x:int -> int
```

This is what is known as the function's type signature.  It can be read like this: "Square is a function which takes an integer named x and produces an integer".  Note that the compiler gave `square` the `int` type for now - this is because multiplication is not generic across *all* types, but rather is generic across a closed set of types.  The F# compiler picked `int` at this point, but it will adjust the type signature if you call `square` with a different input type, such as a `float`.

Another function, `main`, is defined, which is decorated with the `EntryPoint` attribute to tell the F# compiler that program execution should start there.  It follows the same convention as other [C-style programming languages](https://en.wikipedia.org/wiki/Entry_point#C_and_C.2B.2B), where command-line arguments can be passed to this function, and an integer code is returned (typically `0`).

It is in this function that we call the `square` function with an argument of `12`.  The F# compiler then assigns the type of `square` to be `int -> int` (that is, a function which takes an `int` and produces an `int`).  The call to `printfn` is a formatted printing function which uses a format string, similar to C-style programming languages, parameters which correspond to those specified in the format string, and then prints the result and a new line.

## Running your code

You can run the code and see results by pressing **Ctrl**+**F5**.  This runs the program without debugging and allows you to see the results.  Alternatively, you can choose the **Debug** top-level menu item in Visual Studio and choose **Start Without Debugging**.

You should now see the following printed to the console window that Visual Studio popped up:

```
12 squared is 144!
```

Congratulations!  You've created your first F# project in Visual Studio, written an F# function printed the results of calling that function, and run the project to see some results.

## Next steps

If you haven't already, check out the [Tour of F#](../tour.md), which covers some of the core features of the F# language.  It will give you an overview of some of the capabilities of F#, and provide ample code samples that you can copy into Visual Studio and run.  There are also some great external resources you can use, showcased in the [F# Guide](../index.md).

## See also

- [Tour of F#](../tour.md)
- [F# language reference](../language-reference/index.md)
- [Type inference](../language-reference/type-inference.md)
- [Symbol and operator reference](../language-reference/symbol-and-operator-reference/index.md)
