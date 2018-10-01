---
title: Open-source library guidance
description: Best practice recommendations for developers to create high quality .NET libraries.
author: jamesnk
ms.author: James.NewtonKing
ms.date: 09/20/2018
---
# Open-source library guidance

This guidance provides recommendations for developers to create high-quality .NET libraries. This documentation focuses on the *what* and the *why* when building a .NET library, not the *how*.

Aspects of high-quality .NET libraries:

> [!div class="checklist"]
> * **Inclusive** - Good .NET libraries strive to support many platforms and applications.
> * **Stable** - Good .NET libraries should co-exist in the greater .NET ecosystem in applictions with many libraries.
> * **Designed to evolve** - .NET libraries should improve and evolve over time while supporting existing users.
> * **Debuggable** - A high-quality .NET library should use the latest tools to create a great debugging experience for its users.
> * **Trusted** - .NET libraries have developers trust and publish to NuGet following security best practices.

> [!div class="nextstepaction"]
> [Get Started](./get-started.md)

## Recommendations

With each topic there is a list of recommendations for your open-source .NET library using **Do**, **Consider**, **Avoid** and **Do not**. The wording of each recommendation indicates how strongly it should be followed. For example a **Do** recommendation is one that should almost always be followed:

**✔️ DO** distribute your library using a NuGet package.

On the other hand **Consider** recommendations should generally be followed, but there are legitimate exceptions to the rule and you should not feel bad about not following the guidance:

**✔️ CONSIDER** using [SemVer 2.0.0](https://semver.org/) to version your NuGet package.

**Do not** indicates something you should almost never do:

**❌ DO NOT** publish strong-named and non-strong-named versions of your project. For example, `Contoso.Api` and `Contoso.Api.StrongNamed`.

And finally less strong, **avoid** recommendations are something this is not a good idea, but breaking the rule sometimes makes sense:

**❌ AVOID** NuGet package references that demand an exact version.