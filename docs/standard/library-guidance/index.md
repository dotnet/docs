---
title: Open-source library guidance
description: Best practice recommendations for developers to create high quality .NET libraries.
author: jamesnk
ms.author: mairaw
ms.date: 10/17/2018
---
# Open-source library guidance

This guidance provides recommendations for developers to create high-quality .NET libraries. This documentation focuses on the *what* and the *why* when building a .NET library, not the *how*.

Aspects of high-quality open-source .NET libraries:

> [!div class="checklist"]
> * **Inclusive** - Good .NET libraries strive to support many platforms, programming languages, and applications.
> * **Stable** - Good .NET libraries coexist in the .NET ecosystem, running in applications built with many libraries.
> * **Designed to evolve** - .NET libraries should improve and evolve over time, while supporting existing users.
> * **Debuggable** - .NET libraries should use the latest tools to create a great debugging experience for users.
> * **Trusted** - .NET libraries have developers' trust by publishing to NuGet using security best practices.

> [!div class="nextstepaction"]
> [Get Started](./get-started.md)

## Types of recommendations

Each article presents four types of recommendations: **Do**, **Consider**, **Avoid**, and **Do not**. The type of recommendation indicates how strongly it should be followed.

You should almost always follow a **Do** recommendation. For example:

**✔️ DO** distribute your library using a NuGet package.

On the other hand, **Consider** recommendations should generally be followed, but there are legitimate exceptions to the rule and you shouldn't feel bad about not following the guidance:

**✔️ CONSIDER** using [SemVer 2.0.0](https://semver.org/) to version your NuGet package.

**Avoid** recommendations mention things that are generally not a good idea, but breaking the rule sometimes makes sense:

**❌ AVOID** NuGet package references that demand an exact version.

And finally, **Do not** recommendations indicate something you should almost never do:

**❌ DO NOT** publish strong-named and non-strong-named versions of your library. For example, `Contoso.Api` and `Contoso.Api.StrongNamed`.

>[!div class="step-by-step"]
[Next](./get-started.md)
