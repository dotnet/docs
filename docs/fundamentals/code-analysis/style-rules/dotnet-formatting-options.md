---
title: .NET formatting options
description: Learn about the code-style options for formatting .NET code.
ms.date: 12/20/2022
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
> A separate C#-specific [`using` directive rule IDE0065](ide0065.md) is also available. That rule concerns whether `using` directives are placed inside or outside namespaces.

### dotnet\_sort\_system\_directives_first

| Property                 | Value                               | Description                                                                                      |
|--------------------------|-------------------------------------|--------------------------------------------------------------------------------------------------|
| **Option name**          | dotnet_sort_system_directives_first |                                                                                                  |
| **Applicable languages** | C# and Visual Basic                 |                                                                                                  |
| **Introduced version**   | Visual Studio 2017 version 15.3     |                                                                                                  |
| **Option values**        | `true`                              | Sort `System.*` `using` directives alphabetically, and place them before other using directives. |
|                          | `false`                             | Do not place `System.*` `using` directives before other `using` directives.                      |
| **Default value**        | `true`                              |                                                                                                  |

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
| **Default value**        | `false`                                 |                                                             |

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

## See also

- [Formatting rule (IDE0055)](ide0055.md)
