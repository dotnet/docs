---
title: Visual Basic language strategy
description: Learn about the .NET team's strategy for development and maintenance of the Visual Basic programming language.
ms.date: 02/06/2023
---
# Annotated Visual Basic language strategy

The following statements define the .NET team's strategy in making decisions about the evolution of Visual Basic.

[!INCLUDE [visual-basic](../../../includes/vb-strategy.md)]

## How strategy guides Visual Basic evolution

These annotations provide insight into how the .NET team thinks about key statements.

> "Visual Basic remains a straightforward and approachable language"

Visual Basic's natural language syntax enables programmers and non-programmers to read code and engage in meaningful discussions. Many people embrace the design of Visual Basic, and that design won't change.

> "language with a stable design"

The design of Visual Basic allows programmers to build solid applications today and to understand code written across a long period of time without stylistic changes.

> "Visual Basic will generally adopt a consumption-only approach and avoid new syntax"

New features in the .NET runtime and C# sometimes require language changes to implement. The .NET team will maximize interop by supporting many of these features and maximize stability with a consumption-only approach. A consumption-only approach means Visual Basic code can access .NET APIs and types built on new .NET runtime features, but the language won't add syntax to define types that use those features. This approach allows new features to benefit Visual Basic users with little or no syntax changes.

> "We will continue to invest in the experience in Visual Studio"

The .NET team will continue to improve the Visual Studio experience for Visual Basic developers, such as providing analyzers, code fixers, and IDE productivity features.

> "in core Visual Basic scenarios"

The .NET team will focus on existing scenarios supported by Visual Basic. It's unlikely that support for new workloads, such as web front ends or cross-platform UI frameworks, will be added.
