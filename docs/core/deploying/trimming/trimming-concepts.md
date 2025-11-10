---
title: Understanding trim analysis
description: Learn the fundamental concepts of how trim analysis works, why certain patterns produce warnings, and how to make code trim-compatible from first principles.
author: agocke
ms.author: angocke
ms.date: 11/04/2025
ai-usage: ai-assisted
---
# Understanding trim analysis

This article explains the fundamental concepts behind trim analysis to help you understand why certain code patterns produce warnings and how to make your code trim-compatible. Understanding these concepts will help you make informed decisions when addressing trim warnings rather than simply "spreading attributes around to silence the tooling."

## How the trimmer analyzes code

The trimmer performs **static analysis** at publish time to determine which code is used by your application. It starts from known entry points (like your `Main` method) and follows the code paths through your application.

### What the trimmer can understand

The trimmer excels at analyzing direct, compile-time-visible code patterns:

```csharp
// The trimmer CAN understand these patterns:
var date = new DateTime();
date.AddDays(1);  // Direct method call - trimmer knows AddDays is used

var list = new List<string>();
list.Add("hello");  // Generic method call - trimmer knows List<string>.Add is used

string result = MyUtility.Process("data");  // Direct static method call
```

In these examples, the trimmer can follow the code path and mark `DateTime.AddDays`, `List<string>.Add`, and `MyUtility.Process` as used code that should be kept in the final application.

### What the trimmer cannot understand

The trimmer struggles with dynamic operations where the target of an operation isn't known until runtime:

```csharp
// The trimmer CANNOT fully understand these patterns:
Type type = Type.GetType(Console.ReadLine());  // Type name from user input
type.GetMethod("SomeMethod");  // Which method? On which type?

object obj = GetSomeObject();
obj.GetType().GetProperties();  // What type will obj be at runtime?

Assembly asm = Assembly.LoadFrom(pluginPath);  // What's in this assembly?
```

In these examples, the trimmer has no way to know:
- Which type the user will enter
- What type `GetSomeObject()` returns
- What code exists in the dynamically loaded assembly

This is the fundamental problem that trim warnings address.

## The reflection problem

Reflection allows code to inspect and invoke types and members dynamically at runtime. This is powerful but creates a challenge for static analysis.

### Why reflection breaks trimming

Consider this example:

```csharp
void PrintMethodNames(Type type)
{
    foreach (var method in type.GetMethods())
    {
        Console.WriteLine(method.Name);
    }
}

// Called somewhere in the app
PrintMethodNames(typeof(DateTime));
```

From the trimmer's perspective:
1. It sees `type.GetMethods()` is called
2. It doesn't know what `type` will be (it's a parameter)
3. It can't determine which types' methods need to be preserved
4. Without guidance, it might remove methods from `DateTime`, breaking the code

This is why the trimmer produces a warning on this code.

## Understanding DynamicallyAccessedMembers

<xref:System.Diagnostics.CodeAnalysis.DynamicallyAccessedMembersAttribute> solves the reflection problem by creating an explicit contract between the caller and the called method.

### The fundamental purpose

`DynamicallyAccessedMembers` tells the trimmer: "This parameter (or field, or return value) will hold a `Type` that needs specific members preserved because reflection will be used to access them."

### A concrete example

Let's fix the previous example:

```csharp
void PrintMethodNames(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    foreach (var method in type.GetMethods())
    {
        Console.WriteLine(method.Name);
    }
}

// When this is called...
PrintMethodNames(typeof(DateTime));
```

Now the trimmer understands:
1. `PrintMethodNames` requires its parameter to have `PublicMethods` preserved
2. The call site passes `typeof(DateTime)`
3. Therefore, `DateTime`'s public methods must be kept

The attribute creates a **requirement** that flows backward from the reflection usage to the source of the `Type` value.

### It's a contract, not a hint

This is crucial to understand: `DynamicallyAccessedMembers` isn't just documentation. The trimmer enforces this contract:

```csharp
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
Type GetTypeForProcessing() 
{
    return typeof(DateTime);  // OK - trimmer will preserve DateTime's public methods
}

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
Type GetTypeFromInput()
{
    // WARNING: The trimmer can't verify that the type from GetType()
    // will have its public methods preserved
    return Type.GetType(Console.ReadLine());
}
```

If you can't fulfill the contract (like in the second example), you'll get a warning.

## Understanding RequiresUnreferencedCode

Some code patterns simply cannot be made statically analyzable. For these cases, use <xref:System.Diagnostics.CodeAnalysis.RequiresUnreferencedCodeAttribute>.

### When to use RequiresUnreferencedCode

Use this attribute when:

1. **The reflection pattern is fundamentally dynamic**: Loading assemblies or types by string names from external sources
2. **The complexity is too high to annotate**: Code that uses reflection in complex, data-driven ways
3. **You're using runtime code generation**: Technologies like <xref:System.Reflection.Emit> or the `dynamic` keyword

Example:

```csharp
[RequiresUnreferencedCode("Plugin loading is not compatible with trimming")]
void LoadPlugin(string pluginPath)
{
    Assembly pluginAssembly = Assembly.LoadFrom(pluginPath);
    // Plugin assemblies aren't known at publish time
    // This fundamentally cannot be made trim-compatible
}
```

### The purpose of the attribute

`RequiresUnreferencedCode` serves two purposes:

1. **Suppresses warnings inside the method**: The trimmer won't analyze or warn about the reflection usage
2. **Creates warnings at call sites**: Any code calling this method gets a warning

This "bubbles up" the warning to give developers visibility into trim-incompatible code paths.

### Writing good messages

The message should help developers understand their options:

```csharp
// ❌ Not helpful
[RequiresUnreferencedCode("Uses reflection")]

// ✅ Helpful - explains what's incompatible and suggests alternatives
[RequiresUnreferencedCode("Plugin loading is not compatible with trimming. Consider using a source generator for known plugins instead")]
```

## How requirements flow through code

Understanding how requirements propagate helps you know where to add attributes.

### Requirements flow backward

Requirements flow from where reflection is used back to where the `Type` originates:

```csharp
void CallChain()
{
    // Step 1: Source of the Type value
    ProcessData<DateTime>();  // ← Requirement ends here
}

void ProcessData<T>()
{
    // Step 2: Type flows through generic parameter
    var type = typeof(T);
    DisplayInfo(type);  // ← Requirement flows back through here
}

void DisplayInfo(Type type)
{
    // Step 3: Reflection creates the requirement
    type.GetMethods();  // ← Requirement starts here
}
```

To make this trim-compatible, you need to annotate the chain:

```csharp
void ProcessData<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>()
{
    var type = typeof(T);
    DisplayInfo(type);
}

void DisplayInfo(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] Type type)
{
    type.GetMethods();
}
```

Now the requirement flows: `GetMethods()` requires `PublicMethods` → `type` parameter needs `PublicMethods` → generic `T` needs `PublicMethods` → `DateTime` needs `PublicMethods` preserved.

### Requirements flow through storage

Requirements also flow through fields and properties:

```csharp
class TypeHolder
{
    // This field will hold Types that need PublicMethods preserved
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)]
    private Type _typeToProcess;

    public void SetType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicMethods)] T>()
    {
        _typeToProcess = typeof(T);  // OK - requirement satisfied
    }

    public void Process()
    {
        _typeToProcess.GetMethods();  // OK - field is annotated
    }
}
```

## Choosing the right approach

When you encounter code that needs reflection, follow this decision tree:

### 1. Can you avoid reflection?

The best solution is to avoid reflection when possible:

```csharp
// ❌ Uses reflection
void Process(Type type)
{
    var instance = Activator.CreateInstance(type);
}

// ✅ Uses compile-time generics instead
void Process<T>() where T : new()
{
    var instance = new T();
}
```

### 2. Is the Type known at compile time?

If reflection is necessary but the types are known, use `DynamicallyAccessedMembers`:

```csharp
// ✅ Trim-compatible
void Serialize<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T obj)
{
    foreach (var prop in typeof(T).GetProperties())
    {
        // Serialize property
    }
}
```

### 3. Is the pattern fundamentally dynamic?

If the types truly aren't known until runtime, use `RequiresUnreferencedCode`:

```csharp
// ✅ Documented as trim-incompatible
[RequiresUnreferencedCode("Dynamic type loading is not compatible with trimming")]
void ProcessTypeByName(string typeName)
{
    var type = Type.GetType(typeName);
    // Work with type
}
```

## Common patterns and solutions

### Pattern: Serialization

```csharp
// Problem: Serializer needs to access properties dynamically
void SerializeObject(object obj)
{
    foreach (var prop in obj.GetType().GetProperties())
    {
        // Serialize...
    }
}

// Solution: Use generic parameter with annotation
void SerializeObject<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties)] T>(T obj)
{
    foreach (var prop in typeof(T).GetProperties())
    {
        // Serialize...
    }
}
```

### Pattern: Factory methods

```csharp
// Problem: Creating instances from Type parameter
object CreateInstance(Type type)
{
    return Activator.CreateInstance(type);
}

// Solution: Specify constructor requirements
object CreateInstance(
    [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)] Type type)
{
    return Activator.CreateInstance(type);
}
```

### Pattern: Dependency injection containers

```csharp
// Problem: DI containers resolve types dynamically
class ServiceContainer
{
    public object Resolve(Type serviceType)
    {
        // Complex reflection to instantiate and inject dependencies
    }
}

// Solution: Often too complex - mark as incompatible
class ServiceContainer
{
    [RequiresUnreferencedCode("Service resolution uses reflection and is not trim-compatible. Register services explicitly or use source-generated DI.")]
    public object Resolve(Type serviceType)
    {
        // Complex reflection to instantiate and inject dependencies
    }
}
```

### Pattern: Plugin systems

```csharp
// Problem: Loading unknown assemblies at runtime
[RequiresUnreferencedCode("Plugin loading is not trim-compatible. Plugins must be known at compile time.")]
void LoadPlugins(string pluginDirectory)
{
    foreach (var file in Directory.GetFiles(pluginDirectory, "*.dll"))
    {
        Assembly.LoadFrom(file);
    }
}

// Better solution: Known plugins with source generation
// Use source generators to create plugin registration code at compile time
```

## Key takeaways

1. **The trimmer uses static analysis** - it can only understand code paths visible at compile time
2. **Reflection breaks static analysis** - the trimmer can't see what reflection will access at runtime
3. **DynamicallyAccessedMembers creates contracts** - it tells the trimmer what needs to be preserved
4. **Requirements flow backward** - from reflection usage back to the source of the `Type` value
5. **RequiresUnreferencedCode documents incompatibility** - use it when code can't be made analyzable
6. **Attributes aren't just hints** - the trimmer enforces contracts and produces warnings when they can't be met

## Next steps

- [Fix trim warnings](fixing-warnings.md) - Apply these concepts to resolve warnings in your code
- [Prepare libraries for trimming](prepare-libraries-for-trimming.md) - Make your libraries trim-compatible
- [Trim warning reference](trim-warnings/il2026.md) - Detailed information about specific warnings
