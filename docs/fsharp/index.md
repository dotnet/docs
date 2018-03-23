---
title: F# Guide
description: This guide provides an overview of various learning materials for F#, a functional programming language that runs on .NET.
author: jackfoxy
ms.author: phcart
ms.date: 03/19/2018
ms.topic: article
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: ea27fb37-dad1-4bd4-a3cc-4f5c70767ae9
---

# F# Guide

F# is a functional programming language that runs on .NET. It also has full support for objects, letting you blend functional and object programming for pragmatic solutions to any problem.

```fsharp
open System // Get access to functionality in System namespace.

// Function: takes a name and produces a greeting.
let getGreeting name =
    sprintf "Hello, %s! Isn't F# great?" name

// Use the EntryPoint attribute to run the program.
[<EntryPoint>]
let main args =
    // Define a list of names
    let names = [| "Don"; "Julia"; "Xi" |]
    
    // Print a fun greeting for each name!
    names
    |> Array.map getGreeting
    |> Array.iter (fun greeting -> printfn "%s" greeting)

    0
```

F# is about productivity at its heart. The tooling support for F# is ubiquitous and full of advanced features.

## Learning F# #

[Tour of F#](tour.md) gives an overview of major language features with lots of code samples. This is recommended if you are new to F# and want to get a feel for how the language works.

[Get started with F# in Visual Studio](get-started/get-started-visual-studio.md) if you're on Windows and want the full Visual Studio IDE (Integraded Development Environment) experience.

[Get started with F# in Visual Studio for Mac](get-started/get-started-with-visual-studio-for-mac.md) if you're on macOS and want to use a Visual Studio IDE.

[Get Started with F# in Visual Studio Code](get-started/get-started-vscode.md) if you want a lightweight, cross-platform, and feature-packed IDE experience.

[Get started with F# with the .NET Core CLI](get-started/get-started-command-line.md) if you want to use command-line tools.

[Get started with F# and Xamarin](https://docs.microsoft.com/xamarin/cross-platform/platform/fsharp/) for mobile programming with F#.

## References

[F# Language Reference](language-reference/index.md) is the official, comprehensive reference for all F# language features. Each article explains the syntax and shows code samples. You can use the filter bar in the table of contents to find specific articles.

[F# Core Library Reference](https://msdn.microsoft.com/visualfsharpdocs/conceptual/fsharp-core-library-reference) is the API reference for the F# Core Library.


## Additional guides

[F# for Fun and Profit](https://swlaschin.gitbooks.io/fsharpforfunandprofit/content/) is a comprehensive and very detailed book on learning F#. Its contents and author are beloved by the F# community. The target audience is primarily developers with an object oriented programming background.

[F# Programming Wikibook](https://en.wikibooks.org/wiki/F_Sharp_Programming) is a wikibook about learning F#. It is also a product of the F# community. The target audience is people who are new to F#, with a little bit of object oriented programming background.

## Learn F# through videos

[F# tutorial on YouTube](https://www.youtube.com/watch?v=c7eNDJN758U) is a great introduction to F# using Visual Studio, showing lots of great examples over the course of 1.5 hours. The target audience is Visual Studio developers who are new to F#.

[Introduction to Programming with F#](https://www.youtube.com/watch?v=Teak30_pXHk&list=PLEoMzSkcN8oNiJ67Hd7oRGgD1d4YBxYGC) is a great video series that uses Visual Studio Code as the main editor. The video series starts from nothing and ends with building a text-based RPG video game. The target audience is developers who prefer Visual Studio Code (or a lightweight IDE) and are new to F#.

[What's New in Visual Studio 2017 for F# For Developers](https://www.linkedin.com/learning/what-s-new-in-visual-studio-2017-for-f-sharp-for-developers) is a video course that shows some of the newer features for F# in Visual Studio 2017. The target audience is Visual Studio developers who are new to F#.

## Other useful resources

The [F# Snippets Website](http://www.fssnip.net) contains a massive set of code snippets showing how to do just about anything in F#, ranging from absolute beginner to highly advanced snippets.

The [F# Software Foundation Slack](http://fsharp.org/guides/slack/) is a great place for beginners and experts alike, is highly active, and has some of world's best F# programmers available for a chat. We highly recommend joining.

## The F# Software Foundation

Although Microsoft is the primary developer of the F# language and its tools in Visual Studio, F# is also backed by an independent foundation, the F# Software Foundation (FSSF).

The mission of the F# Software Foundation is to promote, protect, and advance the F# programming language, and to support and facilitate the growth of a diverse and international community of F# programmers.

To learn more and get involved, check out [fsharp.org](http://fsharp.org). It's free to join, and the network of F# developers in the foundation is something you don't want to miss out on!
