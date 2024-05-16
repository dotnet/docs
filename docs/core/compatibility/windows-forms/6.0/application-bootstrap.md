---
title: "Breaking change: C# templates use application bootstrap"
description: Learn about the breaking change in .NET 6 where C# templates for Windows Forms apps include application bootstrap code.
ms.date: 10/27/2021
---
# C# templates use application bootstrap

In line with [related changes in .NET workloads](../../sdk/6.0/csharp-template-code.md), Windows Forms templates for C# have been updated to support `global using` directives, file-scoped namespaces, and nullable reference types. Because a typical Windows Forms app consist of multiple types split across multiple files, for example, Form1.cs and Form1.Designer.cs, top-level statements are notably absent from the Windows Forms templates. However, the updated templates do include application bootstrap code. This can cause incompatibility if you target an earlier version of .NET.

## Version introduced

.NET 6 RC 1

## Old behavior

A Windows Forms application entry point looked like this:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
```

## New behavior

The new application entry point for a .NET 6+ application looks like this:

```csharp
namespace MyApp;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
```

`ApplicationConfiguration.Initialize()` is an ephemeral API produced by the Roslyn compiler (via source generators). This method emits the same calls that the original templates had. You can configure the behavior of this API by setting the following MSBuild properties:

- [ApplicationDefaultFont](../../../project-sdk/msbuild-props-desktop.md#applicationdefaultfont)
- [ApplicationHighDpiMode](../../../project-sdk/msbuild-props-desktop.md#applicationhighdpimode)
- [ApplicationUseCompatibleTextRendering](../../../project-sdk/msbuild-props-desktop.md#applicationusecompatibletextrendering)
- [ApplicationVisualStyles](../../../project-sdk/msbuild-props-desktop.md#applicationvisualstyles)

If you don't explicitly configure any properties, the following code is executed at run time:

```csharp
static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // ApplicationConfiguration.Initialize() will emit the following calls:
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.SystemAware);

        Application.Run(new Form1());
    }
}
```

## Change category

This change affects [*source compatibility*](../../categories.md#source-compatibility).

## Reason for change

The application bootstrap feature:

- Allows the Windows Forms designer to render the design surface in the preferred font.
- Reduces boilerplate code in the templates.

## Recommended action

If the same source is used to build an application that targets multiple TFMs, you can do one of the following:

- Replace the `ApplicationConfiguration.Initialize();` call with the original code (and lose the designer support for `Application.SetDefaultFont` API).
- Use `#if...#endif` directives, for example:

  ```csharp
  #if NET6_0_OR_GREATER
          ApplicationConfiguration.Initialize();
  #else
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.SetHighDpiMode(HighDpiMode.SystemAware);
  #endif
  ```

## Affected APIs

N/A
