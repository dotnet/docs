---
title: Microsoft.Testing.Platform capabilities system
description: Learn how the capabilities system enables feature negotiation and version-independent compatibility in Microsoft.Testing.Platform.
author: MarcoRossignoli
ms.author: mrossignoli
ms.date: 11/27/2025
ai-usage: ai-assisted
---

# Microsoft.Testing.Platform capabilities system

The capabilities system is a core mechanism in Microsoft.Testing.Platform that enables components to discover and negotiate features at runtime. A *capability* represents the *ability to perform a specific action or provide specific information*.

## Why capabilities matter

The capabilities system solves several key challenges in building extensible testing platforms:

- **Feature discovery**: Extensions can query what features a test framework supports before using them
- **Graceful degradation**: Extensions continue working even when optional features aren't available
- **Version compatibility**: Different versions of components work together based on mutual understanding
- **No breaking changes**: New features can be added without breaking existing code

## How capabilities work

Components declare capabilities they support, and other components query for those capabilities before using features:

```csharp
// Extension queries test framework capabilities
var capabilities = serviceProvider.GetRequiredService<ITestFrameworkCapabilities>();
var parallelism = capabilities.GetCapability<IDisableParallelismCapability>();

if (parallelism?.CanDisableParallelism == true)
{
    // Feature is supported, use it
    parallelism.Enable();
}
else
{
    // Feature not available, fallback or disable extension
    return false;
}
```

## Capability interfaces

The capability system is built on simple marker interfaces:

```csharp
// Base capability marker
public interface ICapability
{
}

// Container for capabilities
public interface ICapabilities<TCapability>
    where TCapability : ICapability
{
    IReadOnlyCollection<TCapability> Capabilities { get; }
}
```

### Test framework capabilities

Test frameworks declare their capabilities using specialized interfaces:

```csharp
// Base for all test framework capabilities
public interface ITestFrameworkCapability : ICapability
{
}

// Container for test framework capabilities
public interface ITestFrameworkCapabilities : ICapabilities<ITestFrameworkCapability>
{
}
```

You provide these when [registering your test framework](microsoft-testing-platform-architecture-testframework.md#register-a-test-framework):

```csharp
builder.RegisterTestFramework(
    serviceProvider => new MyTestFrameworkCapabilities(),
    (capabilities, serviceProvider) => new MyTestFramework(capabilities, serviceProvider));
```

## Example: Designing a capability

Let's design a capability for a hypothetical scenario where an extension needs a test framework to:

1. Run tests one at a time (disable parallelism)
2. Provide CPU usage information for each test

### Define the capability interface

```csharp
public interface IDisableParallelismCapability : ITestFrameworkCapability
{
    // Query support
    bool CanDisableParallelism { get; }
    bool CanProvidePerTestCpuConsumption { get; }
    
    // Activate the feature
    void Enable();
}
```

### Implement in the test framework

```csharp
internal class MyTestFrameworkCapabilities : ITestFrameworkCapabilities
{
    public IReadOnlyCollection<ITestFrameworkCapability> Capabilities =>
    [
        new DisableParallelismCapability()
    ];
}

internal class DisableParallelismCapability : IDisableParallelismCapability
{
    private bool _enabled;
    
    public bool CanDisableParallelism => true;
    public bool CanProvidePerTestCpuConsumption => true;
    
    public void Enable()
    {
        _enabled = true;
        // Configure test framework for sequential execution
    }
    
    public bool IsEnabled => _enabled;
}
```

### Query and use in an extension

```csharp
public class CpuMonitorExtension : IDataConsumer
{
    private readonly IDisableParallelismCapability? _parallelismCapability;
    
    public CpuMonitorExtension(IServiceProvider serviceProvider)
    {
        var capabilities = serviceProvider.GetRequiredService<ITestFrameworkCapabilities>();
        
        // Query for the capability
        _parallelismCapability = capabilities.GetCapability<IDisableParallelismCapability>();
    }
    
    public async Task<bool> IsEnabledAsync()
    {
        // Only enable if framework supports our requirements
        if (_parallelismCapability is null)
        {
            Console.WriteLine("Test framework doesn't support CPU monitoring");
            return false;
        }
        
        if (!_parallelismCapability.CanDisableParallelism)
        {
            Console.WriteLine("Cannot disable parallelism - CPU monitoring may be inaccurate");
        }
        
        if (_parallelismCapability.CanProvidePerTestCpuConsumption)
        {
            _parallelismCapability.Enable();
            return true;
        }
        
        return false;
    }
    
    // ... IDataConsumer implementation
}
```

## Built-in platform capabilities

The platform provides several built-in capabilities that test frameworks can implement.

### IBannerMessageOwnerCapability

Allows test frameworks to provide custom banner messages instead of the platform default.

```csharp
public interface IBannerMessageOwnerCapability : ITestFrameworkCapability
{
    Task<string?> GetBannerMessageAsync();
}
```

**When to use**: When your test framework wants to display custom branding or version information at startup.

**Example implementation**:

```csharp
internal class MyBannerCapability : IBannerMessageOwnerCapability
{
    private readonly IPlatformInformation _platformInfo;
    
    public MyBannerCapability(IPlatformInformation platformInfo)
    {
        _platformInfo = platformInfo;
    }
    
    public Task<string?> GetBannerMessageAsync()
    {
        return Task.FromResult<string?>(
            $"MyTestFramework v2.0.0 on {_platformInfo.Name} {_platformInfo.Version}");
    }
}
```

> [!TIP]
> Use the [`IPlatformInformation` service](microsoft-testing-platform-architecture-services.md#the-iplatforminformation-service) to access platform details when building your banner.

## Capability ownership and distribution

When you design a custom capability:

### 1. Define the capability contract

Create a separate "abstractions" package containing only the capability interfaces:

```
MyExtension.Abstractions
└── IMyCustomCapability.cs
```

This allows test frameworks to reference only the contract without pulling in your entire extension.

### 2. Document the capability thoroughly

Your capability documentation should include:

- **Purpose**: What feature does this capability enable?
- **Requirements**: What must the test framework do to support it?
- **Data contracts**: What messages should be published to `IMessageBus`?
- **Activation**: How and when should `Enable()` be called?
- **Examples**: Working code samples

### 3. Version the capability

Follow semantic versioning for capability interfaces:

- **Major version**: Breaking changes to the interface
- **Minor version**: New optional members (with default implementations if possible)
- **Patch version**: Documentation updates

### 4. Example: TRX Report Capability

The TRX report extension demonstrates this pattern:

**Contract package**: `Microsoft.Testing.Extensions.TrxReport.Abstractions`

- Contains capability interfaces
- Referenced by test frameworks

**Implementation package**: `Microsoft.Testing.Extensions.TrxReport`

- Contains the actual extension
- Referenced by test projects

## Querying capabilities

Extensions query capabilities from the service provider:

```csharp
public class MyExtension : IDataConsumer
{
    private readonly ITestFrameworkCapabilities _frameworkCapabilities;
    
    public MyExtension(IServiceProvider serviceProvider)
    {
        // Get test framework capabilities
        _frameworkCapabilities = serviceProvider
            .GetRequiredService<ITestFrameworkCapabilities>();
    }
    
    public async Task<bool> IsEnabledAsync()
    {
        // Query for a specific capability
        var capability = _frameworkCapabilities.GetCapability<IMyCapability>();
        
        if (capability is null)
        {
            // Capability not supported
            Console.WriteLine("MyCapability not supported by test framework");
            return false;
        }
        
        // Check specific features
        if (!capability.SupportsFeatureX)
        {
            Console.WriteLine("Feature X not supported - using fallback");
        }
        
        // Enable the capability
        capability.Enable();
        return true;
    }
}
```

## Best practices

### For capability designers

**DO**:

- Design capabilities as simple, focused interfaces
- Use boolean properties to indicate feature support
- Provide an `Enable()` method for activating features
- Document expected `IMessageBus` message types
- Create separate abstractions packages
- Include working examples in documentation

**DON'T**:

- Include implementation details in capability interfaces
- Create overly complex capability hierarchies
- Make assumptions about how features will be used
- Break capability interfaces in minor versions

### For test framework authors

**DO**:

- Implement capabilities your framework naturally supports
- Return empty collections if no capabilities are supported
- Document which capabilities you implement
- Test capability interactions thoroughly
- Respect capability contracts for message bus data

**DON'T**:

- Implement capabilities you can't fully support
- Break capability contracts
- Assume all extensions query capabilities

### For extension authors

**DO**:

- Always check if capabilities exist before using them
- Provide fallback behavior when capabilities are missing
- Use `IsEnabledAsync()` to disable gracefully when requirements aren't met
- Document which capabilities your extension requires
- Test with test frameworks that don't support your capabilities

**DON'T**:

- Assume capabilities are always present
- Fail hard when capabilities are missing
- Query capabilities in performance-critical paths
- Modify capability objects after `Enable()` is called

## Capability discovery

Users can discover available capabilities using the `--info` command:

```bash
./MyTests.exe --info
```

This displays all registered extensions and their capabilities, helping users understand what features are available.

## Summary

The capabilities system enables:

- **Loose coupling**: Components communicate through well-defined contracts
- **Version independence**: Different versions work together
- **Graceful degradation**: Extensions adapt to available features
- **Extensibility**: New features without breaking changes

Key principles:

1. Capabilities represent potential, not requirements
2. Extensions query before using features
3. Missing capabilities shouldn't break execution
4. Documentation is critical for capability adoption

## See also

- [Architecture overview](microsoft-testing-platform-architecture-overview.md)
- [Build a test framework](microsoft-testing-platform-architecture-testframework.md)
- [Build extensions](microsoft-testing-platform-extensions.md)
- [Platform services](microsoft-testing-platform-architecture-services.md)
