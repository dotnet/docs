---
title: Running MSTest tests
description: Learn about how to run MSTest tests.
author: Evangelink
ms.author: amauryleve
ms.date: 07/24/2024
---

# Running tests

There are several ways to run MSTest tests depending on your needs. You can run tests from an IDE (e.g. Visual Studio, Visual Studio Code, Rider...), from the command line, or from a CI service (e.g. Azure DevOps).

Historically, MSTest relies on [VSTest](https://github.com/microsoft/vstest) for running tests in all contexts but starting with version 3.2.0, MSTest has its own [test runner](./unit-testing-mstest-runner-intro.md). This new runner is more lightweight and faster than VSTest, and it is the recommended way to run MSTest tests.
