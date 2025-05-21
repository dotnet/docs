---
title: Microsoft.Testing.Platform test reports extensions
description: Learn about the various Microsoft.Testing.Platform test reports extensions and how to use them.
author: evangelink
ms.author: amauryleve
ms.date: 04/10/2024
ms.topic: article
---

# Test reports extensions

This article lists and explains all Microsoft.Testing.Platform extensions related to the test report capability.

A test report is a file that contains information about the execution and outcome of the tests.

## Visual Studio test reports

The Visual Studio test result file (or TRX) is the default format for publishing test results. This extension is shipped as part of [Microsoft.Testing.Extensions.TrxReport](https://nuget.org/packages/Microsoft.Testing.Extensions.TrxReport) package.

> [!IMPORTANT]
> The package is shipped with Microsoft .NET library closed-source free to use licensing model.

The available options as follows:

| Option | Description |
|--|--|
| `--report-trx` | Generates the TRX report. |
| `--report-trx-filename` | The name of the generated TRX report. The default name matches the following format `<UserName>_<MachineName>_<yyyy-MM-dd HH:mm:ss>.trx`. |

The report is saved inside the default _TestResults_ folder that can be specified through the `--results-directory` command line argument.
