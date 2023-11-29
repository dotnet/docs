---
title: MSTest Test Runner Exit Codes
description: Learn about MSTest Test Runner exit codes.
author: nohwnd
ms.author: jajares
ms.date: 11/28/2023
ms.custom: 
---

# Exit codes

MSTest Runner uses known exit codes to communicate test failure or application error. Exit codes start at 0 and are non-negative:

| Exit&nbsp;Code | Reason |
|:-----|----------|
| [0](#0) | Success |
| [1](#1) | Generic failure. |
| [2](#2) | At least 1 test failed. |
| [3](#3) | Test session aborted. |
| [4](#4) | Invalid platform setup. |
| [5](#5) | Invalid command line. |
| [6](#6) | Feature not implemented. |
| [7](#7) | Test host process did not exit gracefully. |
| [8](#8) | Zero tests ran. |
| [9](#9) | Minimum expected tests policy violation. |
| [10](#10) | Test adapter test session failure. |

To enable verbose logging in order to troubleshoot issue(s), see [troubleshooting](./unit-testing-mstest-runner-intro.md#troubleshooting).
<!-- Setting special name so we can simply link to the number from here, and from error message that is built into TA source code. -->

## <a name="0"></a>0 - Success

This exit code means success. All tests that were chosen for run has run, and there were no additional errors.

## <a name="1"></a>1 - Generic failure

This is a catch all for all unknown errors. Look for error in the output or log to get more information.

## <a name="2"></a>2 - At least 1 test failed

There was at least 1 failed test.

## <a name="3"></a>3 - Test session aborted

When the test session is aborted, for instance through CTRL+C.

## <a name="4"></a>4 - Invalid platform setup

The setup of used extensions are invalid and the tests session cannot run.

## <a name="5"></a>5 - Invalid command line

Command line arguments passed to the test application are invalid.

## <a name="6"></a>6 - Feature not implemented

Test session is using a not implemented feature.

## <a name="7"></a>7 - Test host process did not exit gracefully

When test session run under test controllers extension point it's possible that the test host won't close gracefully for instance due to a crash.

## <a name="8"></a>8 - Zero tests ran

Test session ran zero tests.

## <a name="9"></a>9 - Minimum expected tests policy violation

Policy for the minimum expected executed tests violated.

## <a name="10"></a>10 - Test adapter test session failure

The test adapter (i.e. Testing.Platform Test Framework, MSTest, NUnit, xUnit) failed to run tests for an infrastructure reason unrelated to the tests self (for instance failing to create a fixture needed by tests).
