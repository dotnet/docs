---
title: Resolve errors related to dynamic binding and the dynamic type
description: These errors indicate an incorrect use of the `dynamic` type or an expression with runtime (or dynamic) binding. Learn about the errors and how to fix them.
f1_keywords:
  - "CS1962"
  - "CS1964"
  - "CS1965"
  - "CS1966"
  - "CS1967"
  - "CS1968"
  - "CS1969"
  - "CS1970"
  - "CS1971"
  - "CS1972"
  - "CS1973"
  - "CS1974"
  - "CS1975"
  - "CS1976"
  - "CS1977"
  - "CS1978"
  - "CS1979"
  - "CS1980"
  - "CS1981"
  - "CS7083"
  - "CS8133"
  - "CS8364"
  - "CS8416"
  - "CS9230"
helpviewer_keywords:
  - "CS1962"
  - "CS1964"
  - "CS1965"
  - "CS1966"
  - "CS1967"
  - "CS1968"
  - "CS1969"
  - "CS1970"
  - "CS1971"
  - "CS1972"
  - "CS1973"
  - "CS1974"
  - "CS1975"
  - "CS1976"
  - "CS1977"
  - "CS1978"
  - "CS1979"
  - "CS1980"
  - "CS1981"
  - "CS7083"
  - "CS8133"
  - "CS8364"
  - "CS8416"
  - "CS9230"
ms.date: 10/23/2025
---
# Resolve warnings related to the dynamic type and dynamic binding

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
  - [**CS1962**](#using-dynamic-in-type-declarations-and-constraints): *The typeof operator cannot be used on the dynamic type.*
  - [**CS1964**](#dynamic-operation-restrictions): *Cannot apply dynamic conversion to an expression.*
  - [**CS1965**](#using-dynamic-in-type-declarations-and-constraints): *Cannot derive from the dynamic type.*
  - [**CS1966**](#using-dynamic-in-type-declarations-and-constraints): *Cannot derive from a constructed dynamic type.*
  - [**CS1967**](#using-dynamic-in-type-declarations-and-constraints): *Cannot use the dynamic type as a type constraint.*
  - [**CS1968**](#using-dynamic-in-type-declarations-and-constraints): *Cannot use a constructed dynamic type as a type constraint.*
  - [**CS1969**](#missing-runtime-support-for-dynamic): *One or more types required to compile a dynamic expression cannot be found.*
  - [**CS1970**](#using-dynamic-in-type-declarations-and-constraints): *Do not use 'System.Runtime.CompilerServices.DynamicAttribute'. Use the 'dynamic' keyword instead.*
  - [**CS1971**](#using-dynamic-in-type-declarations-and-constraints): *Base clause cannot specify a dynamic type.*
  - [**CS1972**](#using-dynamic-in-type-declarations-and-constraints): *Cannot specify base type when indexer has no this accessor.*
  - [**CS1973**](#dynamic-operation-restrictions): *The dynamic argument type does not match the target parameter type for extension method.*
  - [**CS1974**](#dynamic-dispatch-warnings): *Dynamic dispatch to a conditional method will fail at runtime.*
  - [**CS1975**](#using-dynamic-in-type-declarations-and-constraints): *Cannot specify base type when constructor has no this or base initializer.*
  - [**CS1976**](#dynamic-operation-restrictions): *Cannot use a method group as an argument to a dynamically dispatched operation.*
  - [**CS1977**](#dynamic-operation-restrictions): *Cannot use a lambda expression as an argument to a dynamically dispatched operation.*
  - [**CS1978**](#dynamic-operation-restrictions): *Cannot use an expression as an argument to a dynamically dispatched operation.*
  - [**CS1979**](#dynamic-operation-restrictions): *Query expressions with a source or join sequence of type dynamic are not allowed.*
  - [**CS1980**](#missing-runtime-support-for-dynamic): *Cannot define a class or member that uses 'dynamic' because the compiler required type is missing.*
  - [**CS1981**](#dynamic-dispatch-warnings): *The 'is dynamic' pattern is misleading. Use 'is object' instead.*
  - [**CS7083**](#missing-runtime-support-for-dynamic): *Expression must be implicitly convertible to 'System.Object', or the type 'dynamic' is not available.*
  - [**CS8133**](#dynamic-operation-restrictions): *Cannot deconstruct dynamic objects.*
  - [**CS8364**](#dynamic-operation-restrictions): *An argument to 'nameof' cannot use any dynamic operation.*
  - [**CS8416**](#dynamic-operation-restrictions): *The async modifier cannot be used in the expression of a dynamic attribute.*
  - [**CS9230**](#dynamic-operation-restrictions): *Cannot perform a dynamic invocation on an expression with type.*

## Using `dynamic` in type declarations and constraints

- **CS1962**: *The typeof operator cannot be used on the dynamic type.*
- **CS1965**: *Cannot derive from the dynamic type.*
- **CS1966**: *Cannot derive from a constructed dynamic type.*
- **CS1967**: *Cannot use the dynamic type as a type constraint.*
- **CS1968**: *Cannot use a constructed dynamic type as a type constraint.*
- **CS1970**: *Do not use 'System.Runtime.CompilerServices.DynamicAttribute'. Use the 'dynamic' keyword instead.*
- **CS1971**: *Base clause cannot specify a dynamic type.*
- **CS1972**: *Cannot specify base type when indexer has no this accessor.*
- **CS1975**: *Cannot specify base type when constructor has no this or base initializer.*

The [`dynamic` type](../builtin-types/reference-types.md#the-dynamic-type) provides late binding for operations at runtime. However, you can't use `dynamic` in contexts where the compiler needs concrete type information at compile time. These errors occur when you try to use `dynamic` in type declarations, constraints, inheritance, or reflection operations.

**Restrictions on using `dynamic`:**

You can't use `dynamic` with the `typeof` operator because the compiler needs to resolve types at compile time for reflection (CS1962):

```csharp
Type t = typeof(dynamic);  // CS1962
```

You can't use `dynamic` in base class declarations (CS1965, CS1966, CS1971):

```csharp
class MyClass : dynamic { }  // CS1965
```

You can't use `dynamic` as a type constraint on generic parameters (CS1967, CS1968):

```csharp
class MyClass<T> where T : dynamic { }  // CS1967
```

**Use the `dynamic` keyword:**

Always use the `dynamic` keyword to declare dynamic types. Don't use the `DynamicAttribute` directly (CS1970):

```csharp
// Correct:
dynamic value = GetValue();

// Incorrect:
[Dynamic] object value = GetValue();  // CS1970
```

**Base type specifications in special members:**

You can't specify base types in certain contexts like indexers without `this` accessors (CS1972) or constructors without `this` or `base` initializers (CS1975). These restrictions apply to all types, including `dynamic`.

For more information about the `dynamic` type and its proper usage, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Dynamic operation restrictions

- **CS1964**: *Cannot apply dynamic conversion to an expression.*
- **CS1973**: *The dynamic argument type does not match the target parameter type for extension method.*
- **CS1976**: *Cannot use a method group as an argument to a dynamically dispatched operation.*
- **CS1977**: *Cannot use a lambda expression as an argument to a dynamically dispatched operation.*
- **CS1978**: *Cannot use an expression as an argument to a dynamically dispatched operation.*
- **CS1979**: *Query expressions with a source or join sequence of type dynamic are not allowed.*
- **CS8133**: *Cannot deconstruct dynamic objects.*
- **CS8364**: *An argument to 'nameof' cannot use any dynamic operation.*
- **CS8416**: *The async modifier cannot be used in the expression of a dynamic attribute.*
- **CS9230**: *Cannot perform a dynamic invocation on an expression with type.*

While [dynamic binding](../operators/member-access-operators.md#member-access-expression-) provides flexibility at runtime, certain operations can't be resolved dynamically. These restrictions exist because the compiler needs to generate specific code at compile time or because the operation fundamentally requires compile-time type information.

**Method groups, lambda expressions, and anonymous methods:**

You can't pass method groups (CS1976), lambda expressions (CS1977), or other expressions that require compile-time resolution (CS1978) as arguments to dynamically dispatched operations:

```csharp
dynamic d = GetDynamicObject();

// CS1976 - method group requires compile-time resolution
d.ProcessData(Console.WriteLine);

// CS1977 - lambda expression requires compile-time resolution  
d.ProcessData(x => x * 2);
```

**LINQ query expressions:**

You can't use `dynamic` as the source or join sequence in LINQ query expressions (CS1979):

```csharp
dynamic data = GetData();
var query = from item in data  // CS1979
            select item;
```

**Deconstruction:**

You can't deconstruct dynamic objects (CS8133):

```csharp
dynamic tuple = (1, 2);
var (a, b) = tuple;  // CS8133
```

**Compile-time operations:**

Some operations require compile-time information and can't work with dynamic operations:

- The `nameof` operator requires compile-time symbol resolution (CS8364)
- Attributes with `async` modifiers can't use dynamic expressions (CS8416)
- Certain type conversions can't be applied dynamically (CS1964)
- Extension methods require compile-time type checking for the first parameter (CS1973)
- Some invocations can't be resolved dynamically depending on the expression type (CS9230)

**Workarounds:**

When you encounter these restrictions, cast the dynamic value to a specific type before performing the operation:

```csharp
dynamic d = GetDynamicObject();

// Instead of: d.ProcessData(x => x * 2);  // CS1977
// Use:
((IProcessor)d).ProcessData(x => x * 2);

// Instead of: var (a, b) = tuple;  // CS8133  
// Use:
var a = tuple.Item1;
var b = tuple.Item2;
```

For more information about dynamic binding and its limitations, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Missing runtime support for dynamic

- **CS1969**: *One or more types required to compile a dynamic expression cannot be found. Are you missing a reference to 'Microsoft.CSharp.dll'?*
- **CS1980**: *Cannot define a class or member that uses 'dynamic' because the compiler required type '*type*' cannot be found. Are you missing a reference?*
- **CS7083**: *Expression must be implicitly convertible to 'System.Object', or the type 'dynamic' is not available.*

These errors occur when the compiler can't find the types it needs to support dynamic binding at runtime.

**CS1969** and **CS1980** indicate that types from `Microsoft.CSharp.dll` or other required assemblies are missing. The compiler needs types from the `System.Runtime` namespace and the Dynamic Language Runtime (DLR) to generate code for dynamic operations. Ensure your project references the correct assemblies:

```csharp
// Triggers CS1969:
dynamic d = GetValue();
d.Method(); // Can't compile without runtime support

// Fix: Add reference to Microsoft.CSharp.dll
// Or for .NET Core/.NET 5+, ensure the project targets the correct framework
```

**CS7083** occurs when the compiler can't locate the `System.Object` type or can't resolve the `dynamic` type because required assemblies are missing. This error typically appears when core libraries aren't properly referenced:

```csharp
// Triggers CS7083:
var result = someValue as dynamic; // Missing core type support

// Fix: Ensure project references include System.Runtime and Microsoft.CSharp
```

For modern .NET projects (.NET Core, .NET 5 or later), add the `Microsoft.CSharp` package reference:

```xml
<PackageReference Include="Microsoft.CSharp" Version="4.7.0" />
```

For .NET Framework projects, add a reference to `Microsoft.CSharp.dll` in your project file.

For more information about dynamic type requirements, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Dynamic dispatch warnings

- **CS1974**: *The dynamically dispatched call to method '*method*' can fail at run-time because one or more applicable overloads are conditional methods.*
- **CS1981**: *The 'is dynamic' pattern is misleading. The runtime type of the subexpression is never 'dynamic'. Consider using 'object' instead.*

These warnings alert you to potential issues when dispatching calls dynamically at runtime.

**CS1974** warns that calling a conditional method through a dynamic expression can fail at runtime. The compiler can't check conditional method attributes at compile time when you use dynamic dispatch. Consider casting the dynamic expression to its actual type before calling the method:

```csharp
// Triggers CS1974:
dynamic d = GetObject();
d.ConditionalMethod(); // Warning: can fail at runtime

// Use:
MyClass obj = (MyClass)d;
obj.ConditionalMethod(); // Compile-time checks apply
```

**CS1981** warns that the `is dynamic` pattern check is misleading because no object's runtime type is ever `dynamic`. The `dynamic` keyword is a compile-time construct that determines how expressions are bound. At runtime, all dynamic objects have concrete types. Use `is object` instead:

```csharp
// Triggers CS1981:
if (someValue is dynamic) // Misleading - always false
{
    // This code never executes
}

// Use:
if (someValue is object) // Checks if non-null
{
    // This code executes for non-null values
}
```

For more information about dynamic dispatch and runtime behavior, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

