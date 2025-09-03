---
title: Test file
dev_langs:
- CSharp
- VB
---

# Test file

This article contains C# and VB snippets.

## Modern ::: syntax

With 'snippet' prefix:

:::code language="csharp" source="snippets/program.cs" id="Snippet1":::
:::code language="vbnet" source="snippets/program.vb" id="Snippet1":::

Without 'snippet' prefix:

:::code language="csharp" source="snippets/program.cs" id="1":::
:::code language="vbnet" source="snippets/program.vb" id="1":::

Snippet 2 (has angle brackets):

:::code language="csharp" source="snippets/program.cs" id="Snippet2":::
:::code language="vbnet" source="snippets/program.vb" id="Snippet2":::

Snippet 3 (no angle brackets):

:::code language="csharp" source="snippets/program.cs" id="Snippet3":::
:::code language="vbnet" source="snippets/program.vb" id="Snippet3":::

## Legacy snippet syntax

With prefix:

[!code-csharp[Snippet1](snippets/program.cs#Snippet1)]
[!code-vb[Snippet1](snippets/program.vb#Snippet1)]

Without prefix:

[!code-csharp[Snippet1](snippets/program.cs#1)]
[!code-vb[Snippet1](snippets/program.vb#1)]

Snippet 2 (angle brackets):

[!code-csharp[Snippet2](snippets/program.cs#Snippet2)]
[!code-vb[Snippet2](snippets/program.vb#Snippet2)]

Snippet 3 (no angle brackets):

[!code-csharp[Snippet3](snippets/program.cs#Snippet3)]
[!code-vb[Snippet3](snippets/program.vb#Snippet3)]
