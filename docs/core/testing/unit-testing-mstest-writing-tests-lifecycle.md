---
title: MSTest Test Lifecycle
description: Learn about the creation and lifecycle of test classes and test methods in MSTest.
author: marcelwgn
ms.author: marcelwagner
ms.date: 07/24/2024
---

# MSTest lifecycle

MSTest provides a well-defined lifecycle for test classes and test methods, allowing for setup and teardown operations to be performed at various stages of the test execution process. The lifecycle can be grouped into the following three stages:

- Assembly-level lifecycle
- Class-level lifecycle
- Test-level lifecycle

The execution of the lifecycle events occurs from the highest level (assembly) to the lowest level (test method). The order of execution is as follows:

1. Assembly Initialization
1. Class Initialization (for every test class)
1. Test initialization (for every test method)
1. Test Execution
1. Test Cleanup (for every test method)
1. Class Cleanup (for every test class)
1. Assembly Cleanup

## Assembly-level Lifecycle

The assembly lifecycle describes the lifecycle of the entire assembly, which includes all test classes and methods.
To manage the assembly lifecycle, MSTest provides the `AssemblyInitialize` and `AssemblyCleanup` attributes.
To learn more about these attributes, refer to the [AssemblyInitialize and AssemblyCleanup](./unit-testing-mstest-writing-tests-attributes.md#assembly-level) documentation.

## Class-level Lifecycle

The test class lifecycle refers to the lifecycle of individual test classes within the assembly and can be implemented using the [ClassInitialize] and [ClassCleanup] attributes.
These attributes allow you to define setup and teardown methods that are executed before and after all tests in a class, respectively.
For more information on these attributes, refer to the [ClassInitialize and ClassCleanup](./unit-testing-mstest-writing-tests-attributes.md#class-level) documentation.
The class level lifecycle is only run once per class, regardless of the number of tests in a class.

## Test-level Lifecycle

The test level lifecycle is executed for every test method. For parameterized tests, each set of parameters is treated as a separate test method, and the lifecycle is executed for each set of parameters.
Test level lifecycle can be grouped into setup, execution and cleanup with setup and cleanup supporting multiple ways to be implemented.

#### Setup

The setup phase of the test level lifecycle is responsible for preparing the test environment before the execution of each test method. This can be achieved using the `TestInitialize` attribute or by implementing a constructor in the test class. In the case of inheritance, execution of `TestInitialize` methods follows the order from the base class to the derived class. If a test class implements a constructor, it is executed before the `TestInitialize` method.

> [!NOTE]
> Unlike the class constructor, `TestInitialize` methods can be async and also support attribute usage such as the `TimeoutAttribute`.

#### Execution

The execution phase is the phase where the actual test method is executed. If a test method returns a Task or ValueTask, the test method will be awaited.

> [!NOTE]
> In the case of asynchronous test methods, no SynchronizationContext is provided. This means any async code is being run on a ThreadPool thread, and not on the main thread.

#### Cleanup

The cleanup phase of the test level lifecycle is responsible for cleaning up the test environment after the execution of each test method. This can be achieved using the `TestCleanup` attribute or by implementing the `IDisposable`/`IAsyncDisposable` interface in the test class. If a test class implements `IDisposable` or `IAsyncDisposable`, its `Dispose`/`DisposeAsync` method is executed after the `TestCleanup` method. In case of inheritance, execution of `TestCleanup` methods follows the order from the derived class to the base class.

#### Order

The complete order of the test level lifecycle is as follows:

1. Create instance of test class
1. Set TestContext if present
1. Run TestInitialize (if implemented)
1. Test method execution
1. Update TestContext with test results
1. Run TestCleanup if implemented
1. Run DisposeAsync if implemented
1. Run Dispose if implemented
