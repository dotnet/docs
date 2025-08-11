---
author: BillWagner
ms.author: wiwagn
ms.topic: include
ms.date: 10/30/2024
---

> [!IMPORTANT]
>
> You should be careful using the `field` keyword feature in a class that has a field named `field`. The new `field` keyword shadows a field named `field` in the scope of a property accessor. You can either change the name of the `field` variable, or use the `@` token to reference the `field` identifier as `@field`. You can learn more by reading the feature specification for [the `field` keyword](~/_csharplang/proposals/csharp-14.0/field-keyword.md).
