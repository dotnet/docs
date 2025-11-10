---
title: Fixing trim warnings
description: Learn practical workflows for addressing trim warnings in your application, including step-by-step instructions for making code trim-compatible.
author: agocke
ms.author: angocke
ms.date: 11/04/2025
---
# Fixing trim warnings

When you enable trimming in your application, the .NET SDK performs static analysis to detect code patterns that might not be compatible with trimming. Trim warnings indicate potential issues that could cause behavior changes or crashes after trimming.

**An app that uses trimming shouldn't produce any trim warnings.** If there are any trim warnings, thoroughly test the app after trimming to ensure there are no behavior changes.

This article provides practical workflows for addressing trim warnings. For a deeper understanding of why these warnings occur and how trimming works, see [Understanding trim analysis](trimming-concepts.md).

## Understanding warning categories

Trim warnings fall into two main categories:

- **Code incompatible with trimming** - Marked with <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>. The code fundamentally can't be made analyzable (for example, dynamic assembly loading or complex reflection patterns). The method is marked as incompatible, and callers receive warnings.

- **Code with requirements** - Annotated with <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute>. Reflection is used, but types are known at compile time. When requirements are satisfied, the code becomes fully trim-compatible.

## Workflow: Determine the right approach

When you encounter a trim warning, follow these steps in order:

1. **Try to eliminate reflection** - This is always the best option if possible
2. **Use DynamicallyAccessedMembers** - If types are known, make the code trim-compatible
3. **Use RequiresUnreferencedCode** - If truly dynamic, document the incompatibility
4. **Suppress warnings as last resort** - Only if you're certain the code is safe

## Approach 1: Eliminate reflection

The best solution is to avoid reflection entirely when possible. This makes your code faster and fully trim-compatible.

### Use compile-time generics

Replace runtime type operations with compile-time generic parameters:

```csharp
// ❌ Before: Uses reflection
void CreateAndProcess(Type type)
{
    var instance = Activator.CreateInstance(type);
    // Process instance...
}

// ✅ After: Uses generics
void CreateAndProcess<T>() where T : new()
{
    var instance = new T();
    // Process instance...
}
```

### Use source generators

Modern .NET provides source generators for common reflection scenarios:

- **Serialization**: Use [System.Text.Json source generation](../../../standard/serialization/system-text-json/source-generation.md) instead of reflection-based serializers
- **Configuration**: Use the [configuration binding source generator](../../whats-new/dotnet-8/runtime.md#configuration-binding-source-generator)

For more information, see [Known trimming incompatibilities](incompatibilities.md).

## Approach 2: Make code trim-compatible with DynamicallyAccessedMembers

When reflection is necessary but types are known at compile time, use <xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> to make your code trim-compatible.

### Step-by-step: Annotate reflection usage

Consider this example that produces a warning:

```csharp
void PrintMethodNames(Type type)
{
    // ⚠️ IL2070: 'this' argument does not satisfy 'DynamicallyAccessedMemberTypes.PublicMethods'
    foreach (var method in type.GetMethods())
    {
        Console.WriteLine(method.Name);
    }
}
```

**Step 1: Identify what reflection operation is performed**

The code calls `GetMethods()`, which requires `PublicMethods` to be preserved.

**Step 2: Annotate the parameter**

Add `DynamicallyAccessedMembers` to tell the trimmer what's needed:

```csharp
void PrintMethodNames(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    // ✅ No warning - trimmer knows to preserve public methods
    foreach (var method in type.GetMethods())
    {
        Console.WriteLine(method.Name);
    }
}
```

**Step 3: Ensure callers satisfy the requirement**

When calling this method with a known type (`typeof`), the requirement is automatically satisfied:

```csharp
// ✅ OK - DateTime's public methods will be preserved
PrintMethodNames(typeof(DateTime));
```

### Step-by-step: Propagate requirements through call chains

When types flow through multiple methods, you need to propagate requirements:

```csharp
void Method1()
{
    Method2<DateTime>();  // ⚠️ Warning: Generic parameter needs annotation
}

void Method2<T>()
{
    Type t = typeof(T);
    Method3(t);  // ⚠️ Warning: Argument doesn't satisfy requirements
}

void Method3(Type type)
{
    var methods = type.GetMethods();  // ⚠️ Warning: Reflection usage
}
```

**Step 1: Start at the reflection usage**

Annotate where reflection is actually used:

```csharp
void Method3(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    var methods = type.GetMethods();  // ✅ Fixed
}
```

**Step 2: Propagate up the call chain**

Work backward through the call chain:

```csharp
void Method2<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>()
{
    Type t = typeof(T);
    Method3(t);  // ✅ Fixed - T is annotated
}
```

**Step 3: Verify at the call site**

```csharp
void Method1()
{
    Method2<DateTime>();  // ✅ Fixed - DateTime's public methods preserved
}
```

For more details on how requirements flow through code, see [Understanding trim analysis](trimming-concepts.md).

### Common DynamicallyAccessedMemberTypes values

Choose the minimum access level needed:

| Member Type | When to use |
|-------------|-------------|
| `PublicConstructors` | Using `Activator.CreateInstance()` or `GetConstructor()` |
| `PublicMethods` | Using `GetMethod()` or `GetMethods()` |
| `PublicFields` | Using `GetField()` or `GetFields()` |
| `PublicProperties` | Using `GetProperty()` or `GetProperties()` (serialization) |
| `PublicEvents` | Using `GetEvent()` or `GetEvents()` |

> [!WARNING]
> Using `DynamicallyAccessedMemberTypes.All` preserves all members on the target type and all members on its nested types (but not transitive dependencies like members on a property's return type). This significantly increases app size. More importantly, preserved members become reachable, which means they may contain their own problematic code. For example, if a preserved member calls a method marked with `RequiresUnreferencedCode`, that warning cannot be resolved since the member is being kept through reflection annotation rather than an explicit call. Use the minimum required member types to avoid these cascading issues.

## Approach 3: Mark code as incompatible with RequiresUnreferencedCode

When code fundamentally cannot be made analyzable, use <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute> to document the incompatibility.

### When to use RequiresUnreferencedCode

Use this attribute when:

- **Types are loaded dynamically**: Using <xref:System.Type.GetType> with runtime-determined strings
- **Assemblies are loaded at runtime**: Using <xref:System.Reflection.Assembly.LoadFrom(System.String)>
- **Complex reflection patterns**: Reflection usage too complex to annotate
- **Runtime code generation**: Using <xref:System.Reflection.Emit> or the `dynamic` keyword

### Step-by-step: Mark incompatible methods

**Step 1: Identify truly incompatible code**

Example of code that cannot be made trim-compatible:

```csharp
void LoadPluginByName(string pluginName)
{
    // Type name comes from runtime input - trimmer cannot know what types are needed
    Type pluginType = Type.GetType(pluginName);
    var plugin = Activator.CreateInstance(pluginType);
    // Use plugin...
}
```

**Step 2: Add RequiresUnreferencedCode attribute**

```csharp
[RequiresUnreferencedCode("Plugin loading by name is not compatible with trimming. Consider using compile-time plugin registration instead.")]
void LoadPluginByName(string pluginName)
{
    Type pluginType = Type.GetType(pluginName);
    var plugin = Activator.CreateInstance(pluginType);
    // ✅ No warnings inside this method - it's marked as incompatible
}
```

**Step 3: Callers receive warnings**

```csharp
void InitializePlugins()
{
    // ⚠️ IL2026: Using member 'LoadPluginByName' which has 'RequiresUnreferencedCodeAttribute'
    // can break functionality when trimming application code. Plugin loading by name is not
    // compatible with trimming. Consider using compile-time plugin registration instead.
    LoadPluginByName("MyPlugin");
}
```

### Writing effective warning messages

A good `RequiresUnreferencedCode` message should:

1. **State what functionality is incompatible**: Be specific about what doesn't work with trimming
2. **Suggest alternatives**: Guide developers toward trim-compatible solutions
3. **Be concise**: Keep messages short and actionable

```csharp
// ❌ Not helpful
[RequiresUnreferencedCode("Uses reflection")]

// ✅ Helpful - explains problem and suggests alternative
[RequiresUnreferencedCode("Dynamic type loading is not compatible with trimming. Use generic type parameters or source generators instead.")]
```

For longer guidance, add a `Url` parameter:

```csharp
[RequiresUnreferencedCode(
    "Plugin system is not compatible with trimming. See documentation for alternatives.",
    Url = "https://docs.example.com/plugin-trimming")]
```

### Propagating RequiresUnreferencedCode

When a method calls another method marked with `RequiresUnreferencedCode`, you typically need to propagate the attribute:

```csharp
class PluginSystem
{
    // Use a constant for consistent messaging
    const string PluginMessage = "Plugin system is not compatible with trimming. Use compile-time registration instead.";

    [RequiresUnreferencedCode(PluginMessage)]
    private void LoadPluginImplementation(string name)
    {
        // Low-level plugin loading
    }

    [RequiresUnreferencedCode(PluginMessage)]
    public void LoadPlugin(string name)
    {
        LoadPluginImplementation(name);  // ✅ No warning - method is also marked
    }
}
```

## Common patterns and solutions

### Pattern: Factory methods with Activator.CreateInstance

```csharp
// ❌ Before: Produces warning
object CreateInstance(Type type)
{
    return Activator.CreateInstance(type);
}

// ✅ After: Trim-compatible
object CreateInstance(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type type)
{
    return Activator.CreateInstance(type);
}
```

### Pattern: Plugin systems loading assemblies

```csharp
// This pattern is fundamentally incompatible with trimming
[RequiresUnreferencedCode("Plugin loading is not compatible with trimming. Consider compile-time plugin registration using source generators.")]
void LoadPluginsFromDirectory(string directory)
{
    foreach (var dll in Directory.GetFiles(directory, "*.dll"))
    {
        Assembly.LoadFrom(dll);
    }
}
```

### Pattern: Dependency injection containers

```csharp
// Complex DI containers are often incompatible
class Container
{
    [RequiresUnreferencedCode("Service resolution uses complex reflection. Consider using source-generated DI or registering services explicitly.")]
    public object Resolve(Type serviceType)
    {
        // Complex reflection to resolve dependencies
    }
}
```

## Approach 4: Suppress warnings as last resort

> [!WARNING]
> Only suppress trim warnings if you're absolutely certain the code is safe. Incorrect suppressions can lead to runtime failures after trimming.

Use <xref:System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute> when you've verified that code is trim-safe but the trimmer cannot prove it statically.

### When suppression is appropriate

Suppress warnings only when:

1. You've manually ensured all required code is preserved (via `DynamicDependency` or other mechanisms)
2. The code path is never executed in trimmed scenarios
3. You've thoroughly tested the trimmed application

### How to suppress warnings

```csharp
[RequiresUnreferencedCode("Uses reflection")]
void MethodWithReflection() { /* ... */ }

[UnconditionalSuppressMessage("Trimming", "IL2026:RequiresUnreferencedCode",
    Justification = "All referenced types are manually preserved via DynamicDependency attributes")]
void CallerMethod()
{
    MethodWithReflection();  // Warning suppressed
}
```

> [!IMPORTANT]
> Do not use `SuppressMessage` or `#pragma warning disable` for trim warnings. These only work for the compiler but aren't preserved in the compiled assembly. The trimmer operates on compiled assemblies and won't see these suppressions. Always use `UnconditionalSuppressMessage`.

### Minimize suppression scope

Apply suppressions to the smallest scope possible. Extract the problematic call into a local function:

```csharp
void ProcessData()
{
    InitializeData();

    CallReflectionMethod();  // Only this call is suppressed

    ProcessResults();

    [UnconditionalSuppressMessage("Trimming", "IL2026:RequiresUnreferencedCode",
        Justification = "Types are preserved via DynamicDependency on ProcessData method")]
    void CallReflectionMethod()
    {
        MethodWithReflection();
    }
}
```

This approach:
- Makes it clear which specific call is suppressed
- Prevents accidentally suppressing other warnings if the code changes
- Keeps the justification close to the suppressed call

## Troubleshooting tips

### Warning persists after adding DynamicallyAccessedMembers

Ensure you've annotated the entire call chain from the reflection usage back to the source of the `Type`:

1. Find where reflection is used (like `GetMethods()`)
2. Annotate that method's parameter
3. Follow the `Type` value backward through all method calls
4. Annotate each parameter, field, or generic type parameter in the chain

### Too many warnings to address

1. Start with your own code - fix warnings in code you control first
2. Use `TrimmerSingleWarn` to see individual warnings from packages
3. Consider if trimming is appropriate for your application
4. Check [Known trimming incompatibilities](incompatibilities.md) for framework-level issues

### Unsure which DynamicallyAccessedMemberTypes to use

Look at the reflection API being called:

- `GetMethod()` / `GetMethods()` → `PublicMethods`
- `GetProperty()` / `GetProperties()` → `PublicProperties`
- `GetField()` / `GetFields()` → `PublicFields`
- `GetConstructor()` / `Activator.CreateInstance()` → `PublicParameterlessConstructor` or `PublicConstructors`
- `GetEvent()` / `GetEvents()` → `PublicEvents`

Use the narrowest type possible to minimize app size.

## Next steps

- [Understanding trim analysis](trimming-concepts.md) - Learn the fundamental concepts behind trim warnings
- [Prepare libraries for trimming](prepare-libraries-for-trimming.md) - Make your libraries trim-compatible
- [Trim warning reference](trim-warnings/il2026.md) - Detailed information about specific warning codes
- [Known incompatibilities](incompatibilities.md) - Patterns that cannot be made trim-compatible
