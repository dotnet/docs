---
title: MSTest TestContext
description: Learn about the TestContext class of MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 11/12/2024
ms.topic: article
---

# The `TestContext` class

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class gives useful information and tools to help manage test execution. It lets you access details about the test run and adjust the test environment. This class is part of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting> namespace.

## Accessing the `TestContext` object

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> object is available in the following contexts:

- As a parameter to [AssemblyInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyInitializeAttribute), the [ClassInitialize](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute) methods. In this context, the properties related to the test run are not available.
- Starting with 3.6, optionally, as a parameter to [AssemblyCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.AssemblyCleanupAttribute), the [ClassCleanup](xref:Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute) methods. In this context, the properties related to the test run are not available.
- As a property of a test class. In this context, the properties related to the test run are available.
- As a constructor parameter of a test class (starting with v3.6). This way is recommended over using the property, because it gives access to the object in the constructor. While the property is only available after the constructor has run. This way also helps to ensure immutability of the object and allows the compiler to enforce that the object is not null.

:::code language="csharp" source="snippets/testcontext/csharp/TestContext.cs":::

Or with MSTest 3.6+:

:::code language="csharp" source="snippets/testcontext/csharp/TestContextCtor.cs":::

## The `TestContext` members

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class provides properties about the test run along with methods to manipulate the test environment. This section covers the most commonly used properties and methods.

### Test run information

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> provides information about the test run, such as:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestName?displayProperty=nameWithType> – the name of the currently executing test.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.CurrentTestOutcome?displayProperty=nameWithType> - the result of the current test.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.FullyQualifiedTestClassName?displayProperty=nameWithType> - the full name of the test class.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestRunDirectory?displayProperty=nameWithType> - the directory where the test run is executed.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.DeploymentDirectory?displayProperty=nameWithType> - the directory where the deployment items are located.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.ResultsDirectory?displayProperty=nameWithType> - the directory where the test results are stored.  Typically a subdirectory of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestRunDirectory?displayProperty=nameWithType>.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestRunResultsDirectory?displayProperty=nameWithType> - the directory where the test results are stored. Typically a subdirectory of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.ResultsDirectory?displayProperty=nameWithType>.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestResultsDirectory?displayProperty=nameWithType> - the directory where the test results are stored. Typically a subdirectory of the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.ResultsDirectory?displayProperty=nameWithType>.

In MSTest 3.7 and later, the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> class also provides new properties helpful for `TestInitialize` and `TestCleanup` methods:

- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestData?displayProperty=nameWithType> - the data that will be provided to the parameterized test method, or `null` if the test is not parameterized.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestDisplayName?displayProperty=nameWithType> - the display name of the test method.
- <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestException?displayProperty=nameWithType> - the exception thrown by either the test method or test initialize, or `null` if the test method did not throw an exception.

### Data-driven tests

In MSTest 3.7 and later, the property <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.TestData?displayProperty=nameWithType> can be used to access the data for the current test during `TestInitialize` and `TestCleanup` methods.

When targeting .NET framework, the <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext> enables you to retrieve and set data for each iteration in a data-driven test, using properties like `DataRow` and `DataConnection` (for [DataSource](xref:Microsoft.VisualStudio.TestTools.UnitTesting.DataSourceAttribute)-based tests).

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

You can also use <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.Write*?displayProperty=nameWithType> or <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestContext.WriteLine*?displayProperty=nameWithType> methods to write custom messages directly to the test output. This is especially useful for debugging purposes, as it provides real-time logging information within your test execution context.
