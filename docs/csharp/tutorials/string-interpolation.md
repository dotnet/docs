---
title: String Interpolation - C#
description: Learn how string interpolation works in C# 6
keywords: .NET, .NET Core, C#, string
author: mgroves
ms.author: wiwagn
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: f8806f6b-3ac7-4ee6-9b3e-c524d5301ae9
---

# String Interpolation in C# #

String Interpolation is the way that placeholders in a string are replaced by the value of a string variable. Before C# 6, the way to do this is with <xref:System.String.Format%2A?displayProperty=nameWithType>. This works okay, but since it uses numbered placeholders, it can be harder to read and more verbose.

Other programming languages have had string interpolation built into the language for a while. For instance, in PHP:

```php
$name = "Jonas";
echo "My name is $name.";
// This will output "My name is Jonas."
```

In C# 6, we finally have that style of string interpolation. You can use a `$` before a string to indicate that it should substitute variables/expressions for their values.

## Prerequisites
You’ll need to set up your machine to run .NET core. You can find the
installation instructions on the [.NET Core](https://www.microsoft.com/net/core)
page.
You can run this application on Windows, Ubuntu Linux, macOS or in a Docker container. 
You’ll need to install your favorite code editor. The descriptions below
use [Visual Studio Code](https://code.visualstudio.com/) which is an open
source, cross platform editor. However, you can use whatever tools you are
comfortable with.

## Create the Application

Now that you've installed all the tools, create a new .NET Core
application. To use the command line generator, create a directory for your project, such as `interpolated`, and execute the following command in your favorite shell:

```
dotnet new console
```

This command creates a barebones .NET Core project with a project file, *interpolated.csproj*, and a source code file, *Program.cs*. You will need to execute `dotnet restore` to restore the dependencies needed to compile this project.

[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

To execute the program, use `dotnet run`. You should see "Hello, World" output to the console.



## Intro to String Interpolation

With <xref:System.String.Format%2A?displayProperty=nameWithType>, you specify "placeholders" in a string that are replaced by the arguments following the string. For instance:

[!code-csharp[String.Format example](../../../samples/snippets/csharp/new-in-6/string-interpolation.cs#StringFormatExample)]  

That will output "My name is Matt Groves".

In C# 6, instead of using `String.Format`, you define an interpolated string by prepending it with the `$` symbol, and then using the variables directly in the string. For instance:

[!code-csharp[Interpolation example](../../../samples/snippets/csharp/new-in-6/string-interpolation.cs#InterpolationExample)]  

You don't have to use just variables. You can use any expression within the brackets. For instance:

[!code-csharp[Interpolation expression example](../../../samples/snippets/csharp/new-in-6/string-interpolation.cs#InterpolationExpressionExample)]  

Which would output:

```
This is line number 1
This is line number 2
This is line number 3
This is line number 4
This is line number 5
```

## How string interpolation works

Behind the scenes, this string interpolation syntax is translated into `String.Format` by the compiler. So, you can do the [same type of stuff you've done before with `String.Format`](../../standard/base-types/formatting-types.md).

For instance, you can add padding and numeric formatting:

[!code-csharp[Interpolation formatting example](../../../samples/snippets/csharp/new-in-6/string-interpolation.cs#InterpolationFormattingExample)]  

The above would output something like:

```
998        5,177.67
999        6,719.30
1000       9,910.61
1001       529.34
1002       1,349.86
1003       2,660.82
1004       6,227.77
```

If a variable name is not found, then a compile-time error is generated.

For instance:

```csharp
var animal = "fox";
var localizeMe = $"The {adj} brown {animal} jumped over the lazy {otheranimal}";
var adj = "quick";
Console.WriteLine(localizeMe);
```

If you compile this, you get errors:
 
* `Cannot use local variable 'adj' before it is declared` - the `adj` variable wasn't declared until *after* the interpolated string.
* `The name 'otheranimal' does not exist in the current context` - a variable called `otheranimal` was never even declared

## Localization and Internationalization

An interpolated string supports <xref:System.IFormattable?displayProperty=nameWithType> and <xref:System.FormattableString?displayProperty=nameWithType>, which can be useful for internationalization.

By default, an interpolated string uses the current culture. To use a different culture, cast an interpolated string as `IFormattable`. For instance:

[!code-csharp[Interpolation internationalization example](../../../samples/snippets/csharp/new-in-6/string-interpolation.cs#InterpolationInternationalizationExample)]  

## Conclusion 

In this tutorial, you learned how to use string interpolation features of C# 6. It's basically a more concise way of writing simple `String.Format` statements, with some caveats for more advanced uses. For more information, see the [String interpolation](../../csharp//language-reference/tokens/interpolated.md) topic.
