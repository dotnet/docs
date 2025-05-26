---
title: System.CommandLine overview
description: "Learn how to develop and use command-line apps that are based on the System.CommandLine library"
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: overview
---

# System.CommandLine overview

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

The `System.CommandLine` library provides functionality that is commonly needed by command-line apps, such as parsing the command-line input and displaying help text.

Apps that use `System.CommandLine` include the [.NET CLI](../../core/tools/index.md), [additional tools](../../core/additional-tools/index.md), and many [global and local tools](../../core/tools/global-tools.md).

For app developers, the library:

* Lets you focus on writing your app code, since you don't have to write code to parse command-line input or produce a help page.
* Lets you test app code independently of input parsing code.
* Is [trim-friendly](../../core/deploying/trimming/trim-self-contained.md), making it a good choice for developing a fast, lightweight, AOT-capable CLI app.

Use of the library also benefits app users:

* It ensures that command-line input is parsed consistently according to [POSIX](https://en.wikipedia.org/wiki/POSIX) or Windows conventions.
* It automatically supports [tab completion](tab-completion.md) and [response files](syntax.md#response-files).

## NuGet package

The library is available in a NuGet package:

* [System.CommandLine](https://www.nuget.org/packages/System.CommandLine)

## Next steps

To get started with System.CommandLine, see the following resources:

* [Tutorial: Get started with System.CommandLine](get-started-tutorial.md)
* [Syntax overview: How to define commands, options, and arguments](syntax.md)

To learn more, see the following resources:

* [How to bind arguments to handlers](model-binding.md)
* [How to configure dependency injection](dependency-injection.md)
* [How to enable and customize tab completion](tab-completion.md)
* [Help](Help.md)
* [How to handle termination](handle-termination.md)
* [System.CommandLine API reference](xref:System.CommandLine)
