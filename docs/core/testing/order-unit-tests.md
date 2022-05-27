---
title: Order unit tests
description: Learn how to order unit tests with .NET Core.
author: IEvangelist
ms.author: dapine
ms.date: 05/18/2020
zone_pivot_groups: unit-testing-framework-set-one
recommendations: false
---

# Order unit tests

Occasionally, you may want to have unit tests run in a specific order. Ideally, the order in which unit tests run should _not_ matter, and it is [best practice](unit-testing-best-practices.md) to avoid ordering unit tests. Regardless, there may be a need to do so. In that case, this article demonstrates how to order test runs.

If you prefer to browse the source code, see the [order .NET Core unit tests](/samples/dotnet/samples/order-unit-tests-cs) sample repository.

> [!TIP]
> In addition to the ordering capabilities outlined in this article, consider [creating custom playlists with Visual Studio](/visualstudio/test/run-unit-tests-with-test-explorer#create-custom-playlists) as an alternative.

:::zone pivot="mstest"

## Order alphabetically

With MSTest, tests are automatically ordered by their test name.

> [!NOTE]
> A test named `Test14` will run before `Test2` even though the number  `2` is less than `14`. This is because, test name ordering uses the text name of the test.

:::code language="csharp" source="snippets/order-unit-tests/csharp/MSTest.Project/ByAlphabeticalOrder.cs":::

:::zone-end
:::zone pivot="xunit"

The xUnit test framework allows for more granularity and control of test run order. You implement the `ITestCaseOrderer` and `ITestCollectionOrderer` interfaces to control the order of test cases for a class, or test collections.

## Order by test case alphabetically

To order test cases by their method name, you implement the `ITestCaseOrderer` and provide an ordering mechanism.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/Orderers/AlphabeticalOrderer.cs":::

Then in a test class you set the test case order with the `TestCaseOrdererAttribute`.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/ByAlphabeticalOrder.cs":::

## Order by collection alphabetically

To order test collections by their display name, you implement the `ITestCollectionOrderer` and provide an ordering mechanism.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/Orderers/DisplayNameOrderer.cs":::

Since test collections potentially run in parallel, you must explicitly disable test parallelization of the collections with the `CollectionBehaviorAttribute`. Then specify the implementation to the `TestCollectionOrdererAttribute`.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/ByDisplayName.cs":::

## Order by custom attribute

To order xUnit tests with custom attributes, you first need an attribute to rely on. Define a `TestPriorityAttribute` as follows:

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/Attributes/TestPriorityAttribute.cs":::

Next, consider the following `PriorityOrderer` implementation of the `ITestCaseOrderer` interface.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/Orderers/PriorityOrderer.cs":::

Then in a test class you set the test case order with the `TestCaseOrdererAttribute` to the `PriorityOrderer`.

:::code language="csharp" source="snippets/order-unit-tests/csharp/XUnit.TestProject/ByPriorityOrder.cs":::

:::zone-end
:::zone pivot="nunit"

## Order by priority

To order tests explicitly, NUnit provides an [`OrderAttribute`](https://github.com/nunit/docs/wiki/Order-Attribute). Tests with this attribute are started before tests without. The order value is used to determine the order to run the unit tests.

:::code language="csharp" source="snippets/order-unit-tests/csharp/NUnit.TestProject/ByOrder.cs":::

:::zone-end

## Next Steps

> [!div class="nextstepaction"]
> [Unit test code coverage](unit-testing-code-coverage.md)
