---
title: "IDE1007: The name does not exist in the current context"
description: "Learn about code analysis rule IDE1007: The name does not exist in the current context"
ms.date: 07/07/2026
f1_keywords:
- IDE1007
helpviewer_keywords:
- IDE1007
dev_langs:
- CSharp
ai-usage: ai-assisted
---
# The name does not exist in the current context (IDE1007)

| Property                 | Value                                      |
|--------------------------|--------------------------------------------|
| **Rule ID**              | IDE1007                                    |
| **Title**                | The name does not exist in the current context |
| **Category**             | Style                                      |
| **Subcategory**          | Language rules                             |
| **Applicable languages** | C#                                         |
| **Options**              | None                                       |

## Overview

This rule identifies incomplete member declarations where a type name can't be resolved in the current context. It's an internal IDE diagnostic that enables code fixes such as **Add using**, **Fully Qualify**, and **Generate Type**.

> [!NOTE]
> This rule is not configurable and is primarily an internal diagnostic used to drive IDE code-fix features. You might encounter it as part of IDE functionality, but it isn't intended as a user-facing quality or style rule.

A common scenario is when you start typing a member declaration but the type referenced hasn't been imported. For example, if you type `public DateTime` without a variable name and without a `using System;` directive, this rule fires on `DateTime` to enable the **Add using** code fix.

## Example

```csharp
// Code that triggers IDE1007.
// 'DateTime' is unresolved because 'using System;' is missing.

class MyClass
{
    public DateTime // incomplete member — 'DateTime' is unresolved
}
```

Adding the missing `using` directive or fully qualifying the type resolves the issue:

```csharp
using System;

class MyClass
{
    public DateTime MyDate { get; set; }
}
```

## See also

- [Code style language rules](language-rules.md)
- [Code style rules reference](index.md)
