---
title: .NET formatting options
description: Learn about the code-style options for formatting .NET code.
ms.date: 06/13/2022
ms.topic: reference
dev_langs:
- CSharp
- VB
---
# .NET formatting options

The formatting options in this article apply to both C# and Visual Basic. These are options for code-style rule [IDE0055](ide0055.md).

## Using directive options

Use these options to customize how you want using directives to be sorted and grouped:

- [dotnet\_sort\_system\_directives_first](#dotnet_sort_system_directives_first)
- [dotnet\_separate\_import\_directive\_groups](#dotnet_separate_import_directive_groups)

Example *.editorconfig* file:

```ini
# .NET formatting rules
[*.{cs,vb}]
dotnet_sort_system_directives_first = true
dotnet_separate_import_directive_groups = true
```

> [!TIP]
> If your code is C#, additional [C#-specific `using` directive options](csharp-formatting-options.md#using-directive-options) are available.

### dotnet\_sort\_system\_directives_first

| Property                 | Value                               | Description                                                                                      |
|--------------------------|-------------------------------------|--------------------------------------------------------------------------------------------------|
| **Option name**          | dotnet_sort_system_directives_first |                                                                                                  |
| **Applicable languages** | C# and Visual Basic                 |                                                                                                  |
| **Introduced version**   | Visual Studio 2017 version 15.3     |                                                                                                  |
| **Option values**        | `true`                              | Sort `System.*` `using` directives alphabetically, and place them before other using directives. |
|                          | `false`                             | Do not place `System.*` `using` directives before other `using` directives.                      |

Code examples:

```csharp
// dotnet_sort_system_directives_first = true
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;

// dotnet_sort_system_directives_first = false
using System.Collections.Generic;
using Octokit;
using System.Threading.Tasks;
```

### dotnet\_separate\_import\_directive\_groups

| Property                 | Value                                   | Description                                                 |
|--------------------------|-----------------------------------------|-------------------------------------------------------------|
| **Option name**          | dotnet_separate_import_directive_groups |                                                             |
| **Applicable languages** | C# and Visual Basic                     |                                                             |
| **Introduced version**   | Visual Studio 2017 version 15.5         |                                                             |
| **Option values**        | `true`                                  | Place a blank line between `using` directive groups.        |
|                          | `false`                                 | Do not place a blank line between `using` directive groups. |

Code examples:

```csharp
// dotnet_separate_import_directive_groups = true
using System.Collections.Generic;
using System.Threading.Tasks;

using Octokit;

// dotnet_separate_import_directive_groups = false
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
```

## Dotnet namespace options

This category contains one formatting option that concerns how namespaces are named in both C# and Visual Basic.

- [dotnet\_style\_namespace\_match\_folder](#dotnet_style_namespace_match_folder)

Example *.editorconfig* file:

```ini
# .NET namespace rules
[*.{cs,vb}]
dotnet_style_namespace_match_folder = true
```

### dotnet\_style\_namespace\_match\_folder

| Property                 | Value                               | Description                                                    |
|--------------------------|-------------------------------------|----------------------------------------------------------------|
| **Option name**          | dotnet_style_namespace_match_folder |                                                                |
| **Applicable languages** | C# and Visual Basic                 |                                                                |
| **Introduced version**   | Visual Studio 2019 version 16.10    |                                                                |
| **Option values**        | `true`                              | Match namespaces to folder structure                           |
|                          | `false`                             | Do not report on namespaces that do not match folder structure |

Code examples:

```csharp
// dotnet_style_namespace_match_folder = true
// file path: Example/Convention/C.cs
using System;

namespace Example.Convention
{
    class C
    {
    }
}

// dotnet_style_namespace_match_folder = false
// file path: Example/Convention/C.cs
using System;

namespace Example
{
    class C
    {
    }
}
```

> [!NOTE]
> `dotnet_style_namespace_match_folder` requires the analyzer to have access to project properties to function correctly. For projects that target .NET Core 3.1 or an earlier version, you must manually add the following items to your project file. (They're added automatically for .NET 5 and later.)
>
> ```xml
> <ItemGroup>
>   <CompilerVisibleProperty Include="RootNamespace" />
>   <CompilerVisibleProperty Include="ProjectDir" />
> </ItemGroup>
> ```

## See also

- [Formatting rule (IDE0055)](ide0055.md)
