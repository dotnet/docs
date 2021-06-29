---
title: Create a .NET test GitHub Action
description: In this quickstart, you will learn how to create a GitHub Action to test your .NET source code.
author: IEvangelist
ms.author: dapine
ms.date: 06/29/2021
ms.topic: quickstart
recommendations: false
---

# Quickstart: Create a .NET test GitHub Action

In this quickstart, you will learn how to create a GitHub Action to test your .NET source code. Automatically testing your .NET code within GitHub is referred to as continuous integration (CI), where pull requests or changes to the source trigger workflows to exercise. Along with [building the source code](dotnet-build-github-action.md), testing ensures that the compiled source code functions as the author intended. More often than not, unit tests serve as immediate feedback-loop to help ensure the validity of changes to source code.

[!INCLUDE [prerequisites](includes/github-dotnet-ide-prerequisites.md)]

[!INCLUDE [add-github-workflow](includes/add-github-workflow.md)]

<!-- TODO: -->

[!INCLUDE [add-status-badge](includes/add-status-badge.md)]

## See also

- [dotnet test](../core/tools/dotnet-test.md)
- [Unit test .NET apps](../core/testing/unit-testing-with-dotnet-test.md)

## Next steps

> [!div class="nextstepaction"]
> [Quickstart: Create a GitHub Action to publish your .NET app](dotnet-publish-github-action.md)
