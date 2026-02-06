---
title: Test organization and metadata in MSTest
description: Learn how to organize and categorize tests in MSTest using categories, properties, priorities, owners, and work item references.
author: Evangelink
ms.author: amauryleve
ms.date: 07/15/2025
---

# Test organization and metadata in MSTest

MSTest provides attributes for organizing tests, adding metadata, and linking tests to work tracking systems. These attributes help you filter, sort, and manage tests effectively in large test suites.

## Overview

Metadata attributes appear in the Visual Studio **Properties** window for test methods. They help you:

- **Organize tests**: Group tests by category, priority, or owner
- **Filter test runs**: Run specific subsets of tests based on metadata
- **Track test coverage**: Link tests to work items and requirements
- **Generate reports**: Include metadata in test reports and dashboards

## Test categorization

### `TestCategoryAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute> groups tests into categories for filtering and organization. You can apply this attribute at the method, class, or assembly level, and categories are combined when applied at multiple levels.

#### Method-level categories

Apply categories directly to test methods for fine-grained control:

```csharp
[TestClass]
public class OrderTests
{
    [TestMethod]
    [TestCategory("Integration")]
    public void CreateOrder_SavesOrderToDatabase()
    {
        // Integration test
    }

    [TestMethod]
    [TestCategory("Unit")]
    public void CalculateTotal_ReturnsSumOfItems()
    {
        // Unit test
    }

    [TestMethod]
    [TestCategory("Integration")]
    [TestCategory("Slow")]
    public void ProcessLargeOrder_CompletesSuccessfully()
    {
        // Multiple categories allowed
    }
}
```

#### Class-level categories

Apply a category to a test class to assign that category to all test methods within the class:

```csharp
[TestClass]
[TestCategory("Payments")]
public class PaymentServiceTests
{
    [TestMethod]
    public void ProcessPayment_ValidCard_Succeeds()
    {
        // Inherits "Payments" category from class
    }

    [TestMethod]
    [TestCategory("Slow")]
    public void ProcessBatchPayments_LargeVolume_CompletesSuccessfully()
    {
        // Has both "Payments" (from class) and "Slow" (from method) categories
    }
}
```

#### Assembly-level categories

Apply a category at the assembly level to categorize all tests in the entire test assembly. This approach is useful for distinguishing test types across projects:

```csharp
// In AssemblyInfo.cs or any file in your test project
using Microsoft.VisualStudio.TestTools.UnitTesting;

[assembly: TestCategory("E2E")]
```

Use assembly-level categories to organize your test projects by test type:

| Project | Assembly category | Purpose |
|---------|-------------------|---------|
| `MyApp.UnitTests` | `Unit` | Fast, isolated unit tests |
| `MyApp.IntegrationTests` | `Integration` | Tests with external dependencies |
| `MyApp.E2ETests` | `E2E` | End-to-end scenario tests |

#### Filter tests by category

Run tests by category using the `dotnet test` command:

```bash
# Run only integration tests
dotnet test --filter TestCategory=Integration

# Run tests in multiple categories
dotnet test --filter "TestCategory=Integration|TestCategory=Unit"

# Exclude slow tests
dotnet test --filter TestCategory!=Slow
```

In Visual Studio Test Explorer, use the search box with `Trait:` prefix:

- `Trait:"TestCategory=Integration"` - shows integration tests
- `-Trait:"TestCategory=Slow"` - excludes slow tests

### `TestPropertyAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute> adds custom key-value metadata to tests. Use this attribute when built-in attributes don't meet your needs.

```csharp
[TestClass]
public class CustomMetadataTests
{
    [TestMethod]
    [TestProperty("Feature", "Authentication")]
    [TestProperty("Sprint", "23")]
    [TestProperty("RiskLevel", "High")]
    public void Login_WithValidCredentials_Succeeds()
    {
        // Test with custom properties
    }

    [TestMethod]
    [TestProperty("Feature", "Authorization")]
    [TestProperty("RequirementId", "REQ-AUTH-001")]
    public void AccessAdminPage_RequiresAdminRole()
    {
        // Link to requirements
    }
}
```

Properties appear in the Visual Studio **Properties** window under **Test specific**.

#### Filter by custom properties

```bash
# Filter by custom property
dotnet test --filter "Feature=Authentication"
```

## Test ownership and priority

### `OwnerAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.OwnerAttribute> identifies who's responsible for a test.

```csharp
[TestClass]
public class PaymentTests
{
    [TestMethod]
    [Owner("jsmith")]
    public void ProcessPayment_ChargesCorrectAmount()
    {
        // John Smith owns this test
    }

    [TestMethod]
    [Owner("team-payments")]
    public void RefundPayment_CreditsCustomerAccount()
    {
        // Team responsibility
    }
}
```

Filter tests by owner:

```bash
dotnet test --filter Owner=jsmith
```

### `PriorityAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.PriorityAttribute> indicates relative test importance. Lower values indicate higher priority.

```csharp
[TestClass]
public class CriticalPathTests
{
    [TestMethod]
    [Priority(0)]
    public void Login_IsAlwaysAvailable()
    {
        // Highest priority - core functionality
    }

    [TestMethod]
    [Priority(1)]
    public void CreateAccount_WorksCorrectly()
    {
        // High priority
    }

    [TestMethod]
    [Priority(2)]
    public void CustomizeProfile_SavesPreferences()
    {
        // Medium priority
    }
}
```

Filter tests by priority:

```bash
# Run only highest priority tests
dotnet test --filter Priority=0

# Run high priority or higher
dotnet test --filter "Priority=0|Priority=1"
```

### `DescriptionAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute> provides a human-readable description of what the test verifies.

> [!WARNING]
> Use `Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute`, not `System.ComponentModel.DescriptionAttribute`. The [MSTEST0031](mstest-analyzers/mstest0031.md) analyzer detects incorrect usage.

```csharp
[TestClass]
public class DocumentedTests
{
    [TestMethod]
    [Description("Verifies that orders over $100 receive a 10% discount")]
    public void ApplyDiscount_LargeOrder_Gets10PercentOff()
    {
        // Test implementation
    }

    [TestMethod]
    [Description("Ensures email validation rejects malformed addresses")]
    public void ValidateEmail_InvalidFormat_ReturnsFalse()
    {
        // Test implementation
    }
}
```

## Work item tracking

### `WorkItemAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.WorkItemAttribute> links tests to work items in your tracking system (like Azure DevOps).

```csharp
[TestClass]
public class BugFixTests
{
    [TestMethod]
    [WorkItem(12345)]
    [Description("Regression test for bug #12345")]
    public void DatePicker_LeapYear_HandlesFebruary29()
    {
        // Test that verifies the bug fix
    }

    [TestMethod]
    [WorkItem(67890)]
    [WorkItem(67891)]  // Can link multiple work items
    public void Export_LargeDataset_CompletesWithinTimeout()
    {
        // Test related to multiple work items
    }
}
```

### `GitHubWorkItemAttribute`

The <xref:Microsoft.VisualStudio.TestTools.UnitTesting.GitHubWorkItemAttribute> links tests to GitHub issues.

```csharp
[TestClass]
public class GitHubLinkedTests
{
    [TestMethod]
    [GitHubWorkItem("https://github.com/myorg/myrepo/issues/42")]
    public void FeatureX_WorksAsExpected()
    {
        // Test linked to GitHub issue #42
    }

    [TestMethod]
    [GitHubWorkItem("https://github.com/myorg/myrepo/issues/100")]
    [Ignore("Waiting for upstream fix")]
    public void DependentFeature_RequiresUpdate()
    {
        // Ignored test linked to tracking issue
    }
}
```

Work item attributes are especially valuable when combined with `Ignore`:

```csharp
[TestMethod]
[Ignore("Known issue, tracked in work item")]
[WorkItem(99999)]
public void KnownIssue_AwaitingFix()
{
    // Provides traceability for why the test is ignored
}
```

## Combining attributes

Combine multiple metadata attributes for comprehensive test organization:

```csharp
[TestClass]
public class FullyDocumentedTests
{
    [TestMethod]
    [TestCategory("Integration")]
    [TestCategory("API")]
    [Owner("payment-team")]
    [Priority(1)]
    [Description("Verifies that the payment API returns correct error codes for invalid requests")]
    [WorkItem(54321)]
    [TestProperty("Sprint", "24")]
    [TestProperty("Feature", "ErrorHandling")]
    public void PaymentAPI_InvalidRequest_ReturnsAppropriateErrorCode()
    {
        // Well-documented test with full traceability
    }
}
```

## Best practices

1. **Use consistent categories**: Establish naming conventions for test categories across your project.

1. **Set priorities strategically**: Reserve `Priority(0)` for critical path tests that must pass for a viable build.

1. **Link to work items**: Always link tests to related work items for traceability, especially bug regression tests.

1. **Document test purpose**: Use `Description` for complex tests where the method name doesn't fully explain intent.

1. **Keep metadata current**: Update metadata when test scope or ownership changes.

1. **Use categories for filtering**: Design categories to support your CI/CD pipeline needs (for example, "Smoke", "Nightly", "Integration").

## Filtering tests

### Command-line filtering

```bash
# Filter by category
dotnet test --filter TestCategory=Unit

# Filter by owner
dotnet test --filter Owner=jsmith

# Filter by priority
dotnet test --filter Priority=0

# Combine filters (AND)
dotnet test --filter "TestCategory=Integration&Priority=0"

# Combine filters (OR)
dotnet test --filter "TestCategory=Smoke|TestCategory=Critical"

# Exclude by filter
dotnet test --filter TestCategory!=Slow

# Filter by custom property
dotnet test --filter "Feature=Payments"
```

### Visual Studio Test Explorer

Use the search box in Test Explorer:

- `Trait:"TestCategory=Integration"` - filter by category
- `Trait:"Owner=jsmith"` - filter by owner
- `Trait:"Priority=0"` - filter by priority

For more information on test filtering, see [Run selective unit tests](selective-unit-tests.md).

## See also

- [Run selective unit tests](selective-unit-tests.md)
- [Write tests in MSTest](unit-testing-mstest-writing-tests.md)
- [Test execution and control](unit-testing-mstest-writing-tests-controlling-execution.md)
- [MSTEST0015: Test method should not be ignored](mstest-analyzers/mstest0015.md)
- [MSTEST0031: Do not use System.ComponentModel.DescriptionAttribute](mstest-analyzers/mstest0031.md)
