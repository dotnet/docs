---
title: Run tests with MSTest
description: Learn about how to run MSTest tests.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Run tests with MSTest

There are several ways to run MSTest tests depending on your needs. You can run tests from an IDE (for example, Visual Studio, Visual Studio Code, or JetBrains Rider), or from the command line, or from a CI service (such as GitHub Actions or Azure DevOps).

Historically, MSTest relied on [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts but starting with version 3.2.0, MSTest has its own [test runner](./unit-testing-mtp-intro.md). This new runner is more lightweight and faster than VSTest, and it's the recommended way to run MSTest tests.
