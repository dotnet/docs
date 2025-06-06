---
title: System.CommandLine overview
description: "Learn how to develop and use command-line apps that are based on the System.CommandLine library."
ms.date: 04/07/2022
no-loc: [System.CommandLine]
helpviewer_keywords:
  - "command line interface"
  - "command line"
  - "System.CommandLine"
ms.topic: overview
---

# System.CommandLine Overview

[!INCLUDE [scl-preview](../../../includes/scl-preview.md)]

The `System.CommandLine` library provides functionality commonly needed by command-line apps, such as parsing command-line input and displaying help text.

Apps that use `System.CommandLine` include the [.NET CLI](../../core/tools/index.md), [additional tools](../../core/additional-tools/index.md), and many [global and local tools](../../core/tools/global-tools.md).

For app developers, the library:

- Lets you focus on writing your app code, since you don't have to write code to parse command-line input or produce a help page.
- Lets you test app code independently of input parsing code.
- Is [trim-friendly](../../core/deploying/trimming/trim-self-contained.md), making it a good choice for developing fast, lightweight, AOT-capable CLI apps.

Use of the library also benefits app users:

- It ensures that command-line input is parsed consistently according to [POSIX](https://en.wikipedia.org/wiki/POSIX) or Windows conventions.
- It automatically supports [tab completion](tab-completion.md) and [response files](syntax.md#response-files).

## NuGet Package

The library is available as a NuGet package:

- [System.CommandLine](https://www.nuget.org/packages/System.CommandLine)

## Next Steps

To get started with System.CommandLine, see the following resources:

- [Tutorial: Get started with System.CommandLine](get-started-tutorial.md)
- [Syntax overview: commands, options, and arguments](syntax.md)

To learn more, see the following resources:

- [How to parse and invoke the result](parse-and-invoke.md)
- [How to customize parsing and validation](parsing-and-validation.md)
- [How to configure the parser](command-line-configuration.md)
- [How to customize help](help.md)
- [How to enable and customize tab completion](tab-completion.md)
- [Command-line design guidance](design-guidance.md)
- [Breaking changes in beta5](beta5.md)
- [System.CommandLine API reference](xref:System.CommandLine)
