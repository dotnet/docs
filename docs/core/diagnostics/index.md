---
title: .NET Core Diagnostics
description: An overview of the tools and APIs available to diagnose .NET Core applications.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/05/2019
ms.topic: overview
---
# .NET Core Diagnostics

Software doesn't always behave as you would expect, but .NET Core has tools and APIs that will help you diagnose these issues quickly and effectively.

This article helps you find the various tools you need.

## [Managed Debuggers](managed-debuggers.md)
Managed debuggers allow you to interact with your program. Pausing, incrementally executing, examining,  and resuming gives you insight into the behavior of your code. A debugger is the first choice for diagnosing functional problems that can be easily reproduced.

## [Logging and Tracing](logging-tracing.md)
Logging and tracing are related techniques. They allow instrumenting code to create log files recording what the program does. The log files that can be used to diagnose the most complex problems. When combined with time stamps, these techniques are also valuable in performance investigations.

## [Unit Testing](../testing/index.md)
Unit testing is a key component of continuous integration and deployment of high-quality software. Unit tests are designed to give you an early warning when you break something.
