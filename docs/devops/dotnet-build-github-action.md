---
title: Create a build validation GitHub Action
description: In this quickstart, you will learn how to create a GitHub Action to validate .NET app compilation.
author: IEvangelist
ms.author: dapine
ms.date: 06/29/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a build validation GitHub Action

In this quickstart, you will learn how to create a GitHub Action to validate the compilation of your .NET source code in GitHub. Compiling your .NET code is one of the most basic validation steps that you can take to help ensure the quality of updates to your code. If code doesn't compile (or build), it's an easy deterrent and should be a clear sign that the code needs to be fixed.

[!INCLUDE [prerequisites](includes/github-dotnet-ide-prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

<!-- TODO: -->

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

## See also

- [dotnet build](../core/tools/dotnet-build.md)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a .NET test GitHub Action](dotnet-test-github-action.md)
