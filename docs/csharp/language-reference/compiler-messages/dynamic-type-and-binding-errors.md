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
ai-usage: ai-assisted
---
# Resolve warnings related to the dynamic type and dynamic binding

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's be design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
  - [**CS1962**](#using-dynamic-in-type-declarations-and-constraints): *The `typeof` operator cannot be used on the `dynamic` type.*
  - [**CS1964**](#dynamic-operation-restrictions): *Cannot apply dynamic conversion to an expression.*
  - [**CS1965**](#using-dynamic-in-type-declarations-and-constraints): *Cannot derive from the `dynamic` type.*
  - [**CS1966**](#using-dynamic-in-type-declarations-and-constraints): *Cannot derive from a constructed dynamic type.*
  - [**CS1967**](#using-dynamic-in-type-declarations-and-constraints): *Cannot use the `dynamic` type as a type constraint.*
  - [**CS1968**](#using-dynamic-in-type-declarations-and-constraints): *Cannot use a constructed dynamic type as a type constraint.*
  - [**CS1969**](#missing-runtime-support-for-dynamic): *One or more types required to compile a dynamic expression cannot be found.*
  - [**CS1970**](#using-dynamic-in-type-declarations-and-constraints): *Do not use '`System.Runtime.CompilerServices.DynamicAttribute`'. Use the '`dynamic`' keyword instead.*
  - [**CS1971**](#dynamic-operation-restrictions): *The call to member needs to be dynamically dispatched, but cannot be because it is part of a base access expression. Consider casting the dynamic arguments or eliminating the base access.*
  - [**CS1972**](#dynamic-operation-restrictions): *The indexer access needs to be dynamically dispatched, but cannot be because it is part of a base access expression. Consider casting the dynamic arguments or eliminating the base access.*
  - [**CS1973**](#dynamic-operation-restrictions): *The dynamic argument type does not match the target parameter type for extension method.*
  - [**CS1974**](#dynamic-dispatch-warnings): *Dynamic dispatch to a conditional method will fail at runtime.*
  - [**CS1975**](#dynamic-operation-restrictions): *The constructor call needs to be dynamically dispatched, but cannot be because it is part of a constructor initializer. Consider casting the dynamic arguments.*
  - [**CS1976**](#dynamic-operation-restrictions): *Cannot use a method group as an argument to a dynamically dispatched operation.*
  - [**CS1977**](#dynamic-operation-restrictions): *Cannot use a lambda expression as an argument to a dynamically dispatched operation.*
  - [**CS1978**](#dynamic-operation-restrictions): *Cannot use an expression as an argument to a dynamically dispatched operation.*
  - [**CS1979**](#dynamic-operation-restrictions): *Query expressions with a source or join sequence of type dynamic are not allowed.*
  - [**CS1980**](#missing-runtime-support-for-dynamic): *Cannot define a class or member that uses 'dynamic' because the compiler required type is missing.*
  - [**CS1981**](#dynamic-dispatch-warnings): *The '`is dynamic`' pattern is misleading. Use '`is object`' instead.*
  - [**CS7083**](#missing-runtime-support-for-dynamic): *Expression must be implicitly convertible to '`System.Object`', or the type '`dynamic`' is not available.*
  - [**CS8133**](#dynamic-operation-restrictions): *Cannot deconstruct dynamic objects.*
  - [**CS8364**](#dynamic-operation-restrictions): *An argument to '`nameof`' cannot use any dynamic operation.*
  - [**CS8416**](#dynamic-operation-restrictions): *The async modifier cannot be used in the expression of a dynamic attribute.*
  - [**CS9230**](#dynamic-operation-restrictions): *Cannot perform a dynamic invocation on an expression with type.*

## Using `dynamic` in type declarations and constraints

- **CS1962**: *The typeof operator cannot be used on the `dynamic` type.*
- **CS1965**: *Cannot derive from the `dynamic` type.*
- **CS1966**: *Cannot derive from a constructed dynamic type.*
- **CS1967**: *Cannot use the `dynamic` type as a type constraint.*
- **CS1968**: *Cannot use a constructed dynamic type as a type constraint.*
- **CS1970**: *Do not use '`System.Runtime.CompilerServices.DynamicAttribute`'. Use the '`dynamic`' keyword instead.*

The [`dynamic` type](../builtin-types/reference-types.md#the-dynamic-type) provides late binding for operations at runtime. Use concrete types in contexts where the compiler needs type information at compile time, such as type declarations, constraints, inheritance, or reflection operations:

- Use concrete types for reflection operations.  Use specific types instead of `dynamic` with the `typeof` operator (CS1962)
- Use concrete types for inheritance. Specify a concrete base class instead of `dynamic` (CS1965, CS1966):
- Use concrete type constraints. Specify concrete type constraints on generic parameters instead of `dynamic` (CS1967, CS1968):
- Use the `dynamic` keyword for variables. Always use the `dynamic` keyword to declare dynamic variables. Don't apply the `DynamicAttribute` directly (CS1970):

For more information about the `dynamic` type and its proper usage, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Dynamic operation restrictions

- **CS1964**: *Cannot apply dynamic conversion to an expression.*
- **CS1971**: *The call to member needs to be dynamically dispatched, but cannot be because it is part of a base access expression. Consider casting the dynamic arguments or eliminating the base access.*
- **CS1972**: *The indexer access needs to be dynamically dispatched, but cannot be because it is part of a base access expression. Consider casting the dynamic arguments or eliminating the base access.*
- **CS1973**: *The dynamic argument type does not match the target parameter type for extension method.*
- **CS1975**: *The constructor call needs to be dynamically dispatched, but cannot be because it is part of a constructor initializer. Consider casting the dynamic arguments.*
- **CS1976**: *Cannot use a method group as an argument to a dynamically dispatched operation.*
- **CS1977**: *Cannot use a lambda expression as an argument to a dynamically dispatched operation.*
- **CS1978**: *Cannot use an expression as an argument to a dynamically dispatched operation.*
- **CS1979**: *Query expressions with a source or join sequence of type dynamic are not allowed.*
- **CS8133**: *Cannot deconstruct dynamic objects.*
- **CS8364**: *An argument to '`nameof`' cannot use any dynamic operation.*
- **CS8416**: *The async modifier cannot be used in the expression of a dynamic attribute.*
- **CS9230**: *Cannot perform a dynamic invocation on an expression with type.*

While [dynamic binding](../operators/member-access-operators.md#member-access-expression-) provides flexibility at runtime, cast dynamic values to specific types when you need compile-time type information for certain operations.

- **Cast dynamic arguments before calling base members:** Cast dynamic arguments to their specific types before calling base members, indexers, or constructors (CS1971, CS1972, CS1975):

  ```csharp
  class Base
  {
      public virtual void Method(object obj) { }
      public virtual int this[int index] => 0;
      public Base(int value) { }
  }

  class Derived : Base
  {
      public Derived(dynamic value) : base((int)value) { }  // Cast before calling base constructor
      
      public override void Method(object obj)
      {
          dynamic d = obj;
          base.Method((object)d);  // Cast before calling base method
      }
      
      public override int this[int index]
      {
          get
          {
              dynamic d = index;
              return base[(int)d];  // Cast before accessing base indexer
          }
      }
  }
  ```

- **Cast to specific types before passing delegates or lambdas:** Cast the dynamic object to its concrete type before passing method groups, lambda expressions, or delegates (CS1976, CS1977, CS1978):

  ```csharp
  dynamic d = GetDynamicObject();

  // Avoid:
  d.ProcessData(Console.WriteLine);  // CS1976
  d.ProcessData(x => x * 2);         // CS1977

  // Recommended:
  ((IProcessor)d).ProcessData(Console.WriteLine);  // Cast first
  ((IProcessor)d).ProcessData(x => x * 2);         // Cast first
  ```

- **Use concrete types for LINQ queries:** Use a concrete type instead of `dynamic` for LINQ query sources and join sequences (CS1979):

  ```csharp
  dynamic data = GetData();

  // Avoid:
  var query = from item in data  // CS1979
              select item;

  // Recommended:
  IEnumerable<MyType> typedData = data;
  var query = from item in typedData
              select item;
  ```

- **Access tuple elements individually:** Access tuple elements individually instead of using deconstruction with dynamic tuples (CS8133):

  ```csharp
  dynamic tuple = (1, 2);

  // Avoid:
  var (a, b) = tuple;  // CS8133

  // Recommended:
  var a = tuple.Item1;
  var b = tuple.Item2;
  ```

- **Use compile-time expressions for operations requiring type information:** Use concrete types for operations that need compile-time type information (CS1964, CS1973, CS8364, CS8416, CS9230):

  ```csharp
  dynamic value = GetValue();

  // Avoid:
  var name = nameof(value.Property);  // CS8364

  // Recommended:
  MyType typedValue = value;
  var name = nameof(typedValue.Property);  // Use concrete type
  ```

For more information about dynamic binding and its limitations, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Missing runtime support for dynamic

- **CS1969**: *One or more types required to compile a dynamic expression cannot be found. Are you missing a reference to 'Microsoft.CSharp.dll'?*
- **CS1980**: *Cannot define a class or member that uses 'dynamic' because the compiler required type cannot be found. Are you missing a reference?*
- **CS7083**: *Expression must be implicitly convertible to '`System.Object`', or the type '`dynamic`' is not available.*

The compiler needs types from the `System.Runtime` namespace and the Dynamic Language Runtime (DLR) to generate code for dynamic operations (CS1969, CS1980, CS7083). Ensure your project includes the necessary references. The required types are included in all modern .NET (.NET 5 and later) projects. For .NET Framework projects, add a reference to `Microsoft.CSharp.dll` in your project file.

For more information about dynamic type requirements, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).

## Dynamic dispatch warnings

- **CS1974**: *The dynamically dispatched call to method can fail at run-time because one or more applicable overloads are conditional methods.*
- **CS1981**: *The '`is dynamic`' pattern is misleading. The runtime type of the subexpression is never '`dynamic`'. Consider using '`object`' instead.*

When you call methods that have the `[Conditional]` attribute, avoid using dynamic dispatch. The compiler can't verify conditional method attributes with dynamic binding, which can cause runtime failures (CS1974). Cast the dynamic expression to its actual type first:

```csharp
dynamic d = GetObject();

// Avoid:
d.ConditionalMethod(); // CS1974 - can fail at runtime

// Recommended:
MyClass obj = (MyClass)d;
obj.ConditionalMethod(); // Compile-time checks ensure correctness
```

When you check whether a value is non-null, use `is object` instead of `is dynamic`. The `dynamic` keyword is a compile-time construct, and no object's runtime type is ever `dynamic` (CS1981):

```csharp
// Avoid:
if (someValue is dynamic) // CS1981 - always evaluates to false
{
    // This code never executes
}

// Recommended:
if (someValue is object) // Correctly checks if non-null
{
    // This code executes for non-null values
}
```

For more information about dynamic dispatch and runtime behavior, see [Using type dynamic](../../../advanced-topics/interop/using-type-dynamic.md).
