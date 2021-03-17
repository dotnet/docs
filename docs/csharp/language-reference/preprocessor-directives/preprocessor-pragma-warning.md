---
description: "#pragma warning - C# Reference"
title: "#pragma warning - C# Reference"
ms.date: 07/20/2015
f1_keywords:
  - "#pragma warning"
helpviewer_keywords:
  - "#pragma warning [C#]"
ms.assetid: 723493d5-9753-4cec-babb-54e2b8eb36b6
---
# #pragma warning (C# Reference)

`#pragma warning` can enable or disable certain warnings.

## Syntax

```csharp
#pragma warning disable warning-list
#pragma warning restore warning-list
```

## Parameters

 `warning-list`
 A comma-separated list of warning numbers. The "CS" prefix is optional.

 When no warning numbers are specified, `disable` disables all warnings and `restore` enables all warnings.

> [!NOTE]
> To find warning numbers in Visual Studio, build your project and then look for the warning numbers in the **Output** window.

The `disable` takes affect beginning on the next line of the source file. The warning is restored on the line following the `restore`. If there is no `restore` in the file, the warnings are restored to their default state at the first line of any later files in the same compilation.

## Example

```csharp
// pragma_warning.cs
using System;

#pragma warning disable 414, CS3021
[CLSCompliant(false)]
public class C
{
    int i = 1;
    static void Main()
    {
    }
}
#pragma warning restore CS3021
[CLSCompliant(false)]  // CS3021
public class D
{
    int i = 1;
    public static void F()
    {
    }
}
```

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Preprocessor Directives](./index.md)
- [C# Compiler Errors](../compiler-messages/index.md)
- [How to suppress code analysis warnings](../../../fundamentals/code-analysis/suppress-warnings.md)
