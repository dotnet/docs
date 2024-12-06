---
title: MSTest TestContext
description: Learn about the TestContext class of MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 11/12/2024
---

# The `TestContext` class

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class gives useful information and tools to help manage test execution. It lets you access details about the test run and adjust the test environment. This class is part of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace.

## Accessing the `TestContext` object

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> object is available in the following contexts:

- As a parameter to `[AssemblyInitialize]` and `[ClassInitialize]` methods. In this context, the properties related to the test run are not available.
- As a property of a test class. In this context, the properties related to the test run are available.
- As a constructor parameter of a test class (starting with v3.6). This way is recommended over using the property, because it gives access to the object in the constructor. While the property is only available after the constructor has run. This way also helps to ensure immutability of the object and allows the compiler to enforce that the object is not null.

:::code language="csharp" source="snippets/testcontext/csharp/TestContext.cs":::

Or with MSTest 3.6+:

:::code language="csharp" source="snippets/testcontext/csharp/TestContextCtor.cs":::

## The `TestContext` members

The `TestContext` class provides properties about the test run along with methods to manipulate the test environment. This section covers the most commonly used properties and methods.

### Test run information

The `TestContext` provides information about the test run, such as:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestName> – the name of the currently executing test.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.CurrentTestOutcome> - the result of the current test.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.FullyQualifiedTestClassName> - the full name of the test class.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestRunDirectory> - the directory where the test run is executed.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DeploymentDirectory> - the directory where the deployment items are located.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.ResultsDirectory> - the directory where the test results are stored.  Typically a subdirectory of the `TestRunDirectory`.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestRunResultsDirectory> - the directory where the test results are stored. Typically a subdirectory of the `ResultsDirectory`.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestResultsDirectory> - the directory where the test results are stored. Typically a subdirectory of the `ResultsDirectory`.

In MSTest 3.7 and later, the `TestContext` class also provides new properties helpful for `TestInitialize` and `TestCleanup` methods:

- `TestContext.TestData` - the data that will be provided to the parameterized test method or `null` if the test is not parameterized.
- `TestContext.TestDisplayName` - the display name of the test method.
- `TestContext.TestException` - the exception thrown by either the test method or test initialize, or `null` if the test method did not throw an exception.

### Data-driven tests

In MSTest 3.7 and later, the property `TestData` can be used to access the data for the current test during `TestInitialize` and `TestCleanup` methods.

When targeting .NET framework, the `TestContext` enables you to retrieve and set data for each iteration in a data-driven test, using properties like `DataRow` and `DataConnection` (for [DataSource](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute)-based tests).

Consider the following CSV file `TestData.csv`:

```csv
Number,Name
1,TestValue1
2,TestValue2
3,TestValue3
```

You can use the `DataSource` attribute to read the data from the CSV file:

:::code language="csharp" source="snippets/testcontext/csharp/CsvDataSource.cs":::

### Store and retrieve runtime data

You can use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.Properties?displayProperty=nameWithType> to store custom key-value pairs that can be accessed across different methods in the same test session.

```csharp
TestContext.Properties["MyKey"] = "MyValue";
string value = TestContext.Properties["MyKey"]?.ToString();
```

### Associate data to a test

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.AddResultFile(System.String)?displayProperty=nameWithType> method allows you to add a file to the test results, making it available for review in the test output. This can be useful if you generate files during your test (for example, log files, screenshots, or data files) that you want to attach to the test results.

:::code language="csharp" source="snippets/testcontext/csharp/AddResultFile.cs":::

You can also use `TestContext.Write` or `TestContext.WriteLine` methods to write custom messages directly to the test output. This is especially useful for debugging purposes, as it provides real-time logging information within your test execution context.
