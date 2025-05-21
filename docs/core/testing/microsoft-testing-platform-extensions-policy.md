---
title: Microsoft.Testing.Platform policy extensions
description: Learn about the various Microsoft.Testing.Platform policy extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
ms.topic: article
---

# Policy extensions

This article lists and explains all Microsoft.Testing.Platform extensions related to the policy capability.

## Retry

A .NET test resilience and transient-fault-handling extension.

This extension is intended for integration tests where the test depends heavily on the state of the environment and could experience transient faults.

This extension is shipped as part of [Microsoft.Testing.Extensions.Retry](https://nuget.org/packages/Microsoft.Testing.Extensions.Retry) package.

> [!NOTE]
> The package is shipped with the restrictive Microsoft.Testing.Platform Tools license.
> The full license is available at <https://www.nuget.org/packages/Microsoft.Testing.Extensions.Retry/1.0.0/License>.

The available options are as follows:

| Option                                | Description                                                                                      |
|---------------------------------------|--------------------------------------------------------------------------------------------------|
| `--retry-failed-tests`                | Reruns any failed tests until they pass or until the maximum number of attempts is reached.      |
| `--retry-failed-tests-max-percentage` | Avoids rerunning tests when the percentage of failed test cases crosses the specified threshold. |
| `--retry-failed-tests-max-tests`      | Avoids rerunning tests when the number of failed test cases crosses the specified limit.         |
