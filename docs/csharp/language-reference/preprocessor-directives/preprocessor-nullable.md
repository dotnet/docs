---
description: "#nullable - C# Reference"
title: "#nullable - C# Reference"
ms.date: 11/18/2020
f1_keywords: 
  - "#nullable"
helpviewer_keywords: 
  - "#nullable directive [C#]"
---
# #nullable (C# Reference)

The `#nullable` preprocessor directive sets the *nullable annotation context* and *nullable warning context*. This directive controls whether nullable annotations have effect, and whether nullability warnings are given. Each context is either *disabled* or *enabled*.

Both contexts can be specified at the project level (outside of C# source code). The `#nullable` directive controls the annotation and warning contexts and takes precedence over the project-level settings. A directive sets the context(s) it controls until another directive overrides it, or until the end of the source file.

The effect of the directives is as follows:

- `#nullable disable`: Sets the nullable annotation and warning contexts to *disabled*.
- `#nullable enable`: Sets the nullable annotation and warning contexts to *enabled*.
- `#nullable restore`: Restores the nullable annotation and warning contexts to project settings.
- `#nullable disable annotations`: Sets the nullable annotation context to *disabled*.
- `#nullable enable annotations`: Sets the nullable annotation context to *enabled*.
- `#nullable restore annotations`: Restores the nullable annotation context to project settings.
- `#nullable disable warnings`: Sets the nullable warning context to *disabled*.
- `#nullable enable warnings`: Sets the nullable warning context to *enabled*.
- `#nullable restore warnings`: Restores the nullable warning context to project settings.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
