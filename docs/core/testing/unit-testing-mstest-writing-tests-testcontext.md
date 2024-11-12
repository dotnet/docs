---
title: MSTest TestContext
description: Learn about the TestContext class of MSTest.
author: Evangelink
ms.author: amauryleve
ms.date: 11/12/2024
---

# The `TestContext` class

The `TestContext` class provides contextual information and support for test execution, making it easier to retrieve information about the test run and manipulate aspects of the environment. It's defined in the `Microsoft.VisualStudio.TestTools.UnitTesting` namespace and is available when using the MSTest Framework.

## Accessing the `TestContext` object

The `TestContext` object is available in the following contexts:

- As a parameter to `[AssemblyInitialize]` and `[ClassInitialize]` methods. In this context, the properties related to the test run are not available.
- As a property of a test class. In this context, the properties related to the test run are available.
- As a constructor parameter of a test class (starting with v3.6) as an alternative to the property. This construct is recommended over the property because it gives access to the object in the constructor (while the property is only available after the constructor has run). It's also helping to ensure immutability of the object and finally it helps the compiler to enforce that the object is not null.

```csharp
[TestClass]
public class MyTestClass
{
    public TestContext TestContext { get; set; }

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [TestMethod]
    public void MyTestMethod()
    {
        // Access TestContext properties and methods here
    }
}
```

or with MSTest 3.6+

```csharp
[TestClass]
public class MyTestClass
{
    private readonly TestContext _testContext;

    public MyTestClass(TestContext testContext)
    {
        _testContext = testContext;
    }

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
        // Access TestContext properties and methods here. The properties related to the test run are not available.
    }

    [TestMethod]
    public void MyTestMethod()
    {
        // Access TestContext properties and methods here
    }
}
```

## The `TestContext` members

The `TestContext` class provides properties about the test run along with methods to manipulate the test environment. In this section, we will cover the most commonly used properties and methods.

### Test run information

The `TestContext` provides information about the test run, such as:

- `TestName` – the name of the currently executing test.
- `CurrentTestOutcome` – the result status of the current test.
- `FullyQualifiedTestClassName` – the full name of the test class.
- `TestRunDirectory` – the directory where the test run is executed.
- `DeploymentDirectory` – the directory where the deployment items are located.
- `ResultsDirectory` – the directory where the test results are stored.  Typically a subdirectory of the `TestRunDirectory`.
- `TestRunResultsDirectory` – the directory where the test results are stored. Typically a subdirectory of the `ResultsDirectory`.
- `TestResultsDirectory` – the directory where the test results are stored. Typically a subdirectory of the `ResultsDirectory`.

In MSTest 3.7 and later, the `TestContext` class also provides new properties helpful for `TestInitialize` and `TestCleanup` methods:

- `TestData` – the data that will be provided to the parameterized test method or `null` if the test is not parameterized.
- `TestDisplayName` - the display name of the test method.
- `TestException` - the exception thrown by either the test method or test initialize or `null` if the test method did not throw an exception.

### Data-driven tests

`TestContext` is essential for data-driven testing in MSTest. It enables you to retrieve and set data for each iteration in a data-driven test, using properties like `DataRow` and `DataConnection` (for datasource based tests).

Assuming the following CSV file `TestData.csv`:

```csv
Number,Name
1,TestValue1
2,TestValue2
3,TestValue3
```

You can use the `DataSource` attribute to read the data from the CSV file:

```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace YourNamespace
{
    [TestClass]
    public class CsvDataDrivenTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.CSV", 
            "|DataDirectory|\\TestData.csv", 
            "TestData#csv", 
            DataAccessMethod.Sequential)]
        public void TestWithCsvDataSource()
        {
            // Access data from the current row
            int number = Convert.ToInt32(TestContext.DataRow["Number"]);
            string name = TestContext.DataRow["Name"].ToString();

            Console.WriteLine($"Number: {number}, Name: {name}");

            // Example assertions or logic
            Assert.IsTrue(number > 0);
            Assert.IsFalse(string.IsNullOrEmpty(name));
        }
    }
}
```

In MSTest 3.7 and later, the property `TestData` can be used to access the data for the current test during `TestInitialize` and `TestCleanup` methods.

### Storing and Retrieving Runtime Data

You can use `TestContext.Properties` to store custom key-value pairs that can be accessed across different methods in the same test session.

```csharp
TestContext.Properties["MyKey"] = "MyValue";
string value = TestContext.Properties["MyKey"]?.ToString();
```

### Associating data to a test

The `TestContext.AddResultFile` method allows you to add a file to the test results, making it available for review in the test output. This can be useful if you generate files during your test (e.g., log files, screenshots, or data files) that you want to attach to the test results.

```csharp
[TestMethod]
public void TestMethodWithResultFile()
{
    // Simulate creating a log file for this test
    string logFilePath = Path.Combine(TestContext.TestRunDirectory, "TestLog.txt");
    File.WriteAllText(logFilePath, "This is a sample log entry for the test.");

    // Add the log file to the test result
    TestContext.AddResultFile(logFilePath);

    // Perform some assertions (example only)
    Assert.IsTrue(File.Exists(logFilePath), "The log file was not created.");
    Assert.IsTrue(new FileInfo(logFilePath).Length > 0, "The log file is empty.");
}
```

You can also use `TestContext.Write` or `TestContext.WriteLine` methods to write custom messages directly to the test output. This is especially useful for debugging purposes, as it provides real-time logging information within your test execution context.
