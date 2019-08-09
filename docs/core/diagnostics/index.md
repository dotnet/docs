---
title: Diagnostics tools overview - .NET Core
description: An overview of the tools and techniques available to diagnose .NET Core applications.
author: sdmaclea
ms.author: stmaclea
ms.date: 08/05/2019
ms.topic: overview
#Customer intent: As a .NET Core developer I want to find the best tools to help me diagnose problems so that I can be productive.
---
# What diagnostic tools are available in .NET Core?

Software doesn't always behave as you would expect, but .NET Core has tools and APIs that will help you diagnose these issues quickly and effectively.

This article helps you find the various tools you need.

## [Managed debuggers](managed-debuggers.md)
Managed debuggers allow you to interact with your program. Pausing, incrementally executing, examining,  and resuming gives you insight into the behavior of your code. A debugger is the first choice for diagnosing functional problems that can be easily reproduced.

## [Logging and tracing](logging-tracing.md)
Logging and tracing are related techniques. They refer to instrumenting code to create log files. The files record the details of what a program does. These details can be used to diagnose the most complex problems. When combined with time stamps, these techniques are also valuable in performance investigations.

## [Unit testing](../testing/index.md)
Unit testing is a key component of continuous integration and deployment of high-quality software. Unit tests are designed to give you an early warning when you break something.
