---
ms.topic: include
---

### dotnet_style_prefer_collection_expression

| Property                 | Value                                     | Description                           |
|--------------------------|-------------------------------------------|---------------------------------------|
| **Option name**          | dotnet_style_prefer_collection_expression |                                       |
| **Option values**        | `true` &#124; `when_types_exactly_match`  | Prefer to use collection expressions only when types match exactly, for example, `ImmutableArray<int> i = ImmutableArray.Create(1, 2, 3);`. |
|                          | `when_types_loosely_match`\*              | Prefer to use collection expressions even when types match loosely, for example, `IEnumerable<int> i = ImmutableArray.Create(1, 2, 3);`. The targeted type must match the type on the right-hand side or be one of the following types: <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.Generic.ICollection%601>, <xref:System.Collections.Generic.IList%601>, <xref:System.Collections.Generic.IReadOnlyCollection%601>, <xref:System.Collections.Generic.IReadOnlyList%601>. |
|                          | `false` &#124; `never`                    | Disables the rule.                    |
| **Default option value** | `when_types_loosely_match`\*              |                                       |

\*When this option is used, the code fix might change the semantics of your code.
