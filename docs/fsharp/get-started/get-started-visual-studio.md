---
title: Get started with F# in Visual Studio
description: Learn how to use F# with Visual Studio.
ms.date: 12/20/2019
---
# Get started with F# in Visual Studio

F# and the Visual F# tooling are supported in the Visual Studio integrated development environment (IDE).

To begin, ensure that you have [Visual Studio installed with F# support](install-fsharp.md#install-f-with-visual-studio).

## Create a console application

One of the most basic projects in Visual Studio is the console app. Here's how to create one:

1. Open Visual Studio 2019.

2. On the start window, choose **Create a new project**.

3. On the **Create a new project** page, choose **F#** from the Language list.

4. Choose the **Console App (.NET Core)** template, and then choose **Next**.

5. On the **Configure your new project** page, enter a name in the **Project name** box. Then, choose **Create**.

   Visual Studio creates the new F# project. You can see it in the Solution Explorer window.

## Write the code

Let's get started by writing some code. Make sure that the `Program.fs` file is open, and then replace its contents with the following:

[!code-fsharp[HelloSquare](~/samples/snippets/fsharp/getting-started/hello-square.fs)]

The previous code sample defines a function called `square` that takes an input named `x` and multiplies it by itself. Because F# uses [Type inference](../language-reference/type-inference.md), the type of `x` doesn't need to be specified. The F# compiler understands the types where multiplication is valid and assigns a type to `x` based on how `square` is called. If you hover over `square`, you should see the following:

```fsharp
val square: x:int -> int
```

This is what is known as the function's type signature. It can be read like this: "Square is a function that takes an integer named x and produces an integer". The compiler gave `square` the `int` type for now; this is because multiplication is not generic across *all* types but rather a closed set of types. The F# compiler will adjust the type signature if you call `square` with a different input type, such as a `float`.

Another function, `main`, is defined, which is decorated with the `EntryPoint` attribute. This attribute tells the F# compiler that program execution should start there. It follows the same convention as other [C-style programming languages](https://en.wikipedia.org/wiki/Entry_point#C_and_C.2B.2B), where command-line arguments can be passed to this function, and an integer code is returned (typically `0`).

It is in the entry point function, `main`, that you call the `square` function with an argument of `12`. The F# compiler then assigns the type of `square` to be `int -> int` (that is, a function that takes an `int` and produces an `int`). The call to `printfn` is a formatted printing function that uses a format string and prints the result (and a new line). The format string, similar to C-style programming languages, has parameters (`%d`) that correspond to the arguments that are passed to it, in this case, `12` and `(square 12)`.

## Run the code

You can run the code and see the results by pressing **Ctrl**+**F5**. Alternatively, you can choose the **Debug** > **Start Without Debugging** from the top-level menu bar. This runs the program without debugging.

The following output prints to the console window that Visual Studio opened:

```console
12 squared is: 144!
```

Congratulations! You've created your first F# project in Visual Studio, written an F# function that calculates and prints a value, and run the project to see the results.

## Next steps

If you haven't already, check out the [Tour of F#](../tour.md), which covers some of the core features of the F# language. It provides an overview of some of the capabilities of F# and ample code samples that you can copy into Visual Studio and run.

> [!div class="nextstepaction"]
> [Tour of F#](../tour.md)

## See also

- [F# language reference](../language-reference/index.md)
- [Type inference](../language-reference/type-inference.md)
- [Symbol and operator reference](../language-reference/symbol-and-operator-reference/index.md)
