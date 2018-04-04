---
title: Get started with F# in Visual Studio for Mac
description: Learn how to use F# with Visual Studio for Mac.
author: cartermp
ms.author: phcart
ms.date: 02/13/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
---
# Get started with F# in Visual Studio for Mac

F# and the Visual F# tooling are supported in the Visual Studio for Mac IDE.  To begin, you should [download Visual Studio for Mac](https://aka.ms/vsdownload?utm_source=mscom&utm_campaign=msdocs), if you haven't already.  This article uses the Visual Studio Community 2017 for Mac, but you can use F# with the version of your choice.

## Installing F# #

After downloading Visual Studio for Mac, it will prompt you to choose what you want to install.  For the purposes of this article we will be leaving the defaults.  In contrast to Visual Studio for Windows, you do not need to specifically install F# support.  Press "Install" to proceed.

After the install completes, choose "Start Visual Studio".  You can also launch it through Finder on macOS.

## Creating a console application

One of the most basic projects in Visual Studio for Mac is the Console Application.  Here's how to do it.  Once Visual Studio for Mac is open:

1. On the **File** menu, point to **New Solution**.

2.  In the New Project dialog, there are 2 different templates for Console Application.  There is one under Other -> .NET which targets the .NET Framework.  The other template is under .NET Core -> App which targets .NET Core.  Either template should work for the purpose of this article.

3. Under console app, change C# to F# if needed.  Choose the **Next** button to move forward!  

4. Give your project a name, and choose the options you want for the app.  Notice, the preview pane to the side of the screen that will show the directory structure that will be created based on the options selected.  

5. Click **Create**.  You should now see an F# project in the Solution Explorer.

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

You can run the code and see results by clicking on **Run** from the top level menu and then **Start Without Debugging**.  This will run the program without debugging and allows you to see the results.

You should now see the following printed to the console window that Visual Studio for Mac popped up:

```
12 squared is 144!
```

Congratulations!  You've created your first F# project in Visual Studio for Mac, written an F# function printed the results of calling that function, and run the project to see some results.

## Using F# Interactive

One of the best features of the Visual F# tooling in Visual Studio for Mac is the F# Interactive Window.  It allows you to send code over to a process where you can call that code and see the result interactively.

To begin using it, highlight the `square` function defined in your code.  Next, click on **Edit** from the top level menu.  Next select **Send selection to F# Interactive**.  This executes the code in the F# Interactive Window.  Alternatively, you can right click on the selection and choose **Send selection to F# Interactive**.  You should see the F# Interactive Window appear with the following in it:

```
>

val square : x:int -> int

>
```

This shows the same function signature for the `square` function, which you saw earlier when you hovered over the function.  Because `square` is now defined in the F# Interactive process, you can call it with different values:

```
> square 12;;
val it : int = 144
>square 13;;
val it : int = 169
```

This executes the function, binds the result to a new name `it`, and displays the type and value of `it`.  Note that you must terminate each line with `;;`.  This is how F# Interactive knows when your function call is finished.  You can also define new functions in F# Interactive:

```
> let isOdd x = x % 2 <> 0;;

val isOdd : x:int -> bool

> isOdd 12;;
val it : bool = false
```

The above defines a new function, `isOdd`, which takes an `int` and checks to see if it's odd!  You can call this function to see what it returns with different inputs.  You can call functions within function calls:

```
> isOdd (square 15);;
val it : bool = true
```

You can also use the [pipe-forward operator](../language-reference/symbol-and-operator-reference/index.md) to pipeline the value into the two functions:

```
> 15 |> square |> isOdd;;
val it : bool = true
```

The pipe-forward operator, and more, are covered in later tutorials.

This is only a glimpse into what you can do with F# Interactive.  To learn more, check out [Interactive Programming with F#](../tutorials/fsharp-interactive/index.md).

## Next steps

If you haven't already, check out the [Tour of F#](../tour.md), which covers some of the core features of the F# language.  It will give you an overview of some of the capabilities of F#, and provide ample code samples that you can copy into Visual Studio for Mac and run.  There are also some great external resources you can use, showcased in the [F# Guide](../index.md).

## See also
 [Visual F#](../index.md)  
 [Tour of F#](../tour.md)  
 [F# language reference](../language-reference/index.md)  
 [Type inference](../language-reference/type-inference.md)  
 [Symbol and operator reference](../language-reference/symbol-and-operator-reference/index.md)  
