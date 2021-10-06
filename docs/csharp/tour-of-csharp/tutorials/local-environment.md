---
title: Introduction to C# - become familiar with the development tools
description: This article provides a basic introduction to the tools you'll use to develop C# and .NET Applications on your machine.
ms.date: 02/02/2021
---
# Set up your local environment

The first step in running a tutorial on your machine is to set up a development environment. Choose one of the following alternatives:

* To use the .NET CLI and your choice of text or code editor, see the .NET tutorial [Hello World in 10 minutes](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro). The tutorial has instructions for setting up a development environment on Windows, Linux, or macOS.
* To use the .NET CLI and Visual Studio Code, install the [.NET SDK](https://dotnet.microsoft.com/download) and
[Visual Studio Code](https://code.visualstudio.com/).
* To use Visual Studio 2019, see [Tutorial: Create a simple C# console app in Visual Studio](/visualstudio/get-started/csharp/tutorial-console).

## Basic application development flow

The instructions in these tutorials assume that you're using the .NET CLI to create, build, and run applications. You'll use the following commands:

* [`dotnet new`](../../../core/tools/dotnet-new.md) creates an application. This command generates the files and assets necessary for your application. The introduction to C# tutorials all use the `console` application type. Once you've got the basics, you can expand to other application types.
* [`dotnet build`](../../../core/tools/dotnet-build.md) builds the executable.
* [`dotnet run`](../../../core/tools/dotnet-run.md) runs the executable.

If you use Visual Studio 2019 for these tutorials, you'll choose a Visual Studio menu selection when a tutorial directs you to run one of these CLI commands:

* **File** > **New** > **Project** creates an application.
  * The `Console Application` project template is recommended.
  * You will be given the option to specify a target framework. The tutorials below work best when targeting .NET 5 or higher.
* **Build** >  **Build Solution** builds the executable.
* **Debug** > **Start Without Debugging** runs the executable.

## Pick your tutorial

You can start with any of the following tutorials:

## Numbers in C\#

In the [Numbers in C#](numbers-in-csharp-local.md) tutorial, you'll learn
how computers store numbers and how to perform calculations with different
numeric types. You'll learn the basics of rounding and how to perform
mathematical calculations using C#.

This tutorial assumes that you have finished the [Hello world](hello-world.yml) lesson.

## Branches and loops

The [Branches and loops](branches-and-loops-local.md) tutorial teaches the basics of selecting
different paths of code execution based on the values stored in variables. You'll learn the
basics of control flow, which is the basis of how programs make decisions and choose
different actions.

This tutorial assumes that you have finished the [Hello world](hello-world.yml) and
[Numbers in C#](numbers-in-csharp-local.md) lessons.

## List collection

The [List collection](arrays-and-collections.md) lesson gives you a tour of the List collection type that stores sequences of data. You'll learn how to add and remove items, search for items, and sort the lists. You'll explore different kinds of lists.

This tutorial assumes that you have finished the lessons listed above.
