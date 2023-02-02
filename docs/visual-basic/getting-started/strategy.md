---
title: Visual Basic language strategy
description: We will ensure Visual Basic remains a straightforward and approachable language with a stable design. The core libraries of .NET (such as the BCL) will support VB and many of the improvements to the .NET Runtime and libraries will automatically benefit VB.
ms.date: 02/06/2023
---
# Annotated Visual Basic language strategy

[!INCLUDE [visual-basic](../../../includes/vb-strategy.md)]

## How strategy guides Visual Basic

The Visual Basic strategy guides our decisions about VB evolution, and these annotations provide insight into how we think about key statements. 

> "Visual Basic remains a straightforward and approachable language"

Visual Basic’s natural language syntax enables programmers and non-programmers to read code and engage in meaningful discussions. Many people embrace the design of Visual Basic, and we do not plan to change that design.

> "language with a stable design"

The Visual Basic design allows programmers to build solid applications today and to understand code written across a long period of time without stylistic changes.

> "VB will generally adopt a consumption-only approach and avoid new syntax"

New features in the .NET runtime and C# sometimes require language changes to implement. We will maximize interop by supporting many of these features and maximize stability with a consumption only approach. A consumption only approach means Visual Basic code can access .NET APIs and types built on new .NET runtime features, but Visual Basic won’t add syntax to define types that use those features. This allows new features to benefit Visual Basic users with little or no syntax changes.

> "We will continue to invest in the experience in Visual Studio"

We will continue to improve the Visual Studio experience for Visual Basic developers, such as providing analyzers, code fixes and IDE productivity features.

> "in core VB scenarios"

We will focus on existing scenarios supported by VB and do not anticipate adding support for new workloads, such as web front ends or cross-platform UI frameworks
