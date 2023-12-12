---
title: MSTest runner exit codes
description: Learn about the various MSTest runner exit codes and their meaning.
author: nohwnd
ms.author: jajares
ms.date: 11/28/2023
ms.topic: reference
---

# MSTest runner exit codes

The MSTest runner uses known exit codes to communicate test failure or app errors. Exit codes start at `0` and are non-negative. Consider the following table that details the various exit codes and their corresponding reasons:

| Exit code | Reason |
|:-----|----------|
| [0](#0) | Success |
| [1](#1) | Generic failure. |
| [2](#2) | At least one test failed. |
| [3](#3) | Test session aborted. |
| [4](#4) | Invalid platform setup. |
| [5](#5) | Invalid command line. |
| [6](#6) | Feature not implemented. |
| [7](#7) | Test host process did not exit gracefully. |
| [8](#8) | Zero tests ran. |
| [9](#9) | Minimum expected tests policy violation. |
| [10](#10) | Test adapter test session failure. |

To enable verbose logging in order to troubleshoot issues, see [troubleshooting](./unit-testing-mstest-runner-intro.md#troubleshooting).
<!-- Setting special name so we can simply link to the number from here, and from error message that is built into TA source code. -->

## <a name="0"></a>
Success — 0

The `0` exit code indicates success. All tests that were chosen to run have run to completion and there were no errors.

## <a name="1"></a>
Generic failure — `1`

The `1` exit code indicates unknown errors and acts as a _catch all_. To find additional error information and details look in the output.

## <a name="2"></a>
At least one test failed — `2`

An exit code of `2` is used to indicate that there was at least one test failure.

## <a name="3"></a>
Test session aborted — `3`

The exit code `3` indicates that the test session was aborted. A session can be aborted using <kbd>Ctrl</kbd>+<kbd>C</kbd>, as an example.

## <a name="4"></a>
Invalid platform setup — `4`

The exit code `4` indicates that the setup of used extensions is invalid and the tests session cannot run.

## <a name="5"></a>
Invalid command line — `5`

The exit code `5` indicates that the command line arguments passed to the test app are invalid.

## <a name="6"></a>
Feature not implemented — `6`

The exit code `6` indicates that the test session is using a non-implemented feature.

## <a name="7"></a>
Test host process didn't exit gracefully — `7`

The exit code `7` indicates that a test session was unable to complete successfully, and likely crashed. It's possible that this was caused by a test session that was ran via a test controller's extension point.

## <a name="8"></a>
Zero tests ran — `8`

The exit code `8` indicates that the test session ran zero tests.

## <a name="9"></a>
Minimum expected tests policy violation — `9`

The exit code `9` indicates that the minimum execution policy for the executed tests was violated.

## <a name="10"></a>
Test adapter test session failure — `10`

The exit code `10` indicates that the test adapter, Testing.Platform Test Framework, MSTest, NUnit, or xUnit, failed to run tests for an infrastructure reason unrelated to the test's self. An example is failing to create a fixture needed by tests.
