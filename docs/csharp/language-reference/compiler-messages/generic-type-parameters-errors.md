---
title: Resolve errors and warnings related to generic type parameters and type arguments.
description: These compiler errors and warnings indicate errors in generic type parameters and type arguments.
f1_keywords:
  - "CS0080"
  - "CS0081"
  - "CS0224"
  - "CS0304"
  - "CS0305"
  - "CS0306"
  - "CS0307"
  - "CS0308"
  - "CS0310"
  - "CS0311"
  - "CS0312"
  - "CS0313"
  - "CS0314"
  - "CS0315"
  - "CS0401"
  - "CS0403"
  - "CS0405"
  - "CS0406"
  - "CS0409"
  - "CS0411"
  - "CS0412"
  - "CS0413"
  - "CS0417"
  - "CS0449"
  - "CS0450"
  - "CS0451"
  - "CS0452"
  - "CS0453"
  - "CS0454"
  - "CS0455"
  - "CS0456"
  - "CS0693"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS0699"
  - "CS0701"
  - "CS0702"
  - "CS0703"
  - "CS0704"
  - "CS0706"
  - "CS0717"
  - "CS0718"
  - "CS1720"
  - "CS1763"
  - "CS1948"
  - "CS1961"
  - "CS3024"
  - "CS7002"
  - "CS8322"
  - "CS8822"
  - "CS8823"
  - "CS8893"
  - "CS8894"
  - "CS8895"
  - "CS8896"
  - "CS9011"
  - "CS9012"
  - "CS9338"
helpviewer_keywords:
  - "CS0080"
  - "CS0081"
  - "CS0224"
  - "CS0304"
  - "CS0305"
  - "CS0306"
  - "CS0307"
  - "CS0308"
  - "CS0310"
  - "CS0311"
  - "CS0312"
  - "CS0313"
  - "CS0314"
  - "CS0315"
  - "CS0401"
  - "CS0403"
  - "CS0405"
  - "CS0406"
  - "CS0409"
  - "CS0411"
  - "CS0412"
  - "CS0413"
  - "CS0417"
  - "CS0449"
  - "CS0450"
  - "CS0451"
  - "CS0452"
  - "CS0453"
  - "CS0454"
  - "CS0455"
  - "CS0456"
  - "CS0693"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS0699"
  - "CS0701"
  - "CS0702"
  - "CS0703"
  - "CS0704"
  - "CS0706"
  - "CS0717"
  - "CS0718"
  - "CS1720"
  - "CS1763"
  - "CS1948"
  - "CS1961"
  - "CS3024"
  - "CS7002"
  - "CS8322"
  - "CS8822"
  - "CS8823"
  - "CS8893"
  - "CS8894"
  - "CS8895"
  - "CS8896"
  - "CS9011"
  - "CS9012"
  - "CS9338"
ms.date: 05/12/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to generic type parameters and generic type arguments

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0080**](#type-parameter-declaration-and-naming): *Constraints are not allowed on non-generic declarations.*
- [**CS0081**](#type-parameter-declaration-and-naming): *Type parameter declaration must be an identifier, not a type.*
- [**CS0224**](#type-argument-count-and-usage): *A method with vararg cannot be generic, be in a generic type, or have a params parameter.*
- [**CS0304**](#constructor-constraints): *Cannot create an instance of the variable type because it does not have the `new()` constraint.*
- [**CS0305**](#type-argument-count-and-usage): *Using the generic type requires N type arguments.*
- [**CS0306**](#type-argument-count-and-usage): *The type may not be used as a type argument.*
- [**CS0307**](#type-argument-count-and-usage): *The identifier is not a generic method. If you intended an expression list, use parentheses around the expression.*
- [**CS0308**](#type-argument-count-and-usage): *The non-generic type-or-method cannot be used with type arguments.*
- [**CS0310**](#constructor-constraints): *The type must be a non-abstract type with a public parameterless constructor in order to use it as parameter in the generic type or method.*
- [**CS0311**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter `T` in the generic type or method. There is no implicit reference conversion from type1 to type2.*
- [**CS0312**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter in the generic type or method. The nullable type 'type1' does not satisfy the constraint.*
- [**CS0313**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter in the generic type or method. The nullable type 'type1' does not satisfy the constraint. Nullable types can not satisfy any interface constraints.*
- [**CS0314**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter in the generic type or method. There is no boxing conversion or type parameter conversion.*
- [**CS0315**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter `T` in the generic type or method. There is no boxing conversion.*
- [**CS0401**](#constraint-declaration-and-ordering): *The `new()` constraint must be the last constraint specified.*
- [**CS0403**](#generic-type-usage-restrictions): *Cannot convert null to type parameter because it could be a non-nullable value type. Consider using `default(T)` instead.*
- [**CS0405**](#valid-constraint-types): *Duplicate constraint for type parameter.*
- [**CS0406**](#anchor-tbd): *The class type constraint 'constraint' must come before any other constraints.*
- [**CS0409**](#anchor-tbd): *A constraint clause has already been specified for type parameter 'type parameter'. All of the constraints for a type parameter must be specified in a single where clause.*
- [**CS0411**](#anchor-tbd): *The type arguments for method 'method' cannot be inferred from the usage. Try specifying the type arguments explicitly.*
- [**CS0412**](#type-parameter-declaration-and-naming): *Parameter: a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- [**CS0413**](#generic-type-usage-restrictions): *The type parameter cannot be used with the `as` operator because it does not have a class type constraint nor a `class` constraint.*
- [**CS0417**](#constructor-constraints): *Identifier: cannot provide arguments when creating an instance of a variable type.*
- [**CS0449**](#constraint-declaration-and-ordering): *The `class`, `struct`, `unmanaged`, `notnull`, and `default` constraints cannot be combined or duplicated, and must be specified first in the constraints list.*
- [**CS0450**](#constraint-declaration-and-ordering): *Type Parameter: cannot specify both a constraint class and the `class` or `struct` constraint.*
- [**CS0451**](#constraint-declaration-and-ordering): *The `new()` constraint cannot be used with the `struct` constraint.*
- [**CS0452**](#anchor-tbd): *The type 'type name' must be a reference type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- [**CS0453**](#anchor-tbd): *The type 'type name' must be a non-nullable value type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- [**CS0454**](#constraint-conflicts-and-circular-dependencies): *Circular constraint dependency involving Type Parameter 1 and Type Parameter 2.*
- [**CS0455**](#constraint-conflicts-and-circular-dependencies): *Type parameter inherits conflicting constraints.*
- [**CS0456**](#anchor-tbd): *Type parameter 'type parameter 1' has the 'struct' constraint so 'type parameter 1' cannot be used as a constraint for 'type parameter 2'.*
- [**CS0693**](#anchor-tbd): *Type parameter 'type parameter' has the same name as the type parameter from outer type 'type'.*
- [**CS0694**](#type-parameter-declaration-and-naming): *Type parameter has the same name as the containing type or method.*
- [**CS0695**](#generic-type-usage-restrictions): *`T` cannot implement both interfaces because they may unify for some type parameter substitutions.*
- [**CS0698**](#generic-type-usage-restrictions): *A generic type cannot derive from type because it is an attribute class.*
- [**CS0699**](#anchor-tbd): *'generic' does not define type parameter 'identifier'.*
- [**CS0701**](#anchor-tbd): *'identifier' is not a valid constraint. A type used as a constraint must be an interface, a non-sealed class or a type parameter.*
- [**CS0702**](#valid-constraint-types): *Constraint cannot be special class.*
- [**CS0703**](#valid-constraint-types): *Inconsistent accessibility: constraint type is less accessible than declaration.*
- [**CS0704**](#anchor-tbd): *Cannot do non-virtual member lookup in 'type' because it is a type parameter.*
- [**CS0706**](#valid-constraint-types): *Invalid constraint type. A type used as a constraint must be an interface, a non-sealed class, or a type parameter.*
- [**CS0717**](#valid-constraint-types): *Static class: static classes cannot be used as constraints.*
- [**CS0718**](#anchor-tbd): *'type': static types cannot be used as type arguments.*
- [**CS1720**](#anchor-tbd): *Expression will always cause a System.NullReferenceException because the default value of 'generic type' is null.*
- [**CS1763**](#anchor-tbd): *'parameter' is of type 'type'. A default parameter value of a reference type other than string can only be initialized with null.*
- [**CS1948**](#anchor-tbd): *The range variable 'name' cannot have the same name as a method type parameter.*
- [**CS1961**](#type-parameter-variance): *Invalid variance: The type parameter must be validly variant on type.*
- [**CS3024**](#anchor-tbd): *Constraint type 'type' is not CLS-compliant.*
- [**CS7002**](#type-argument-count-and-usage): *Unexpected use of a generic name.*
- [**CS8322**](#generic-type-usage-restrictions): *Cannot pass argument with dynamic type to generic local function with inferred type arguments.*
- [**CS8822**](#anchor-tbd): *Method 'method' specifies a 'default' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is constrained to a reference type or a value type.*
- [**CS8823**](#anchor-tbd): *The 'default' constraint is valid on override and explicit interface implementation methods only.*
- [**CS8893**](#anchor-tbd): *'type' is not a valid calling convention type for 'UnmanagedCallersOnly'.*
- [**CS8894**](#anchor-tbd): *Cannot use 'type' as a parameter or return type on a method attributed with 'UnmanagedCallersOnly'.*
- [**CS8895**](#anchor-tbd): *Methods attributed with 'UnmanagedCallersOnly' cannot have generic type parameters and cannot be declared in a generic type.*
- [**CS8896**](#anchor-tbd): *'UnmanagedCallersOnly' can only be applied to ordinary static non-abstract, non-virtual methods or static local functions.*
- [**CS9011**](#constraint-declaration-and-ordering): *Keyword `delegate` cannot be used as a constraint. Did you mean `System.Delegate`?*
- [**CS9012**](#type-parameter-declaration-and-naming): *Unexpected keyword `record`. Did you mean `record struct` or `record class`?*
- [**CS9338**](#generic-type-usage-restrictions): *Inconsistent accessibility: type is less accessible than class.*

## Type parameter declaration and naming

The following errors relate to how you declare and name type parameters in generic types and methods:

- **CS0080**: *Constraints are not allowed on non-generic declarations.*
- **CS0081**: *Type parameter declaration must be an identifier, not a type.*
- **CS0412**: *Parameter: a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- **CS0694**: *Type parameter has the same name as the containing type or method.*
- **CS9012**: *Unexpected keyword `record`. Did you mean `record struct` or `record class`?*

To correct these errors, ensure that you declare type parameters with valid identifiers, apply constraint clauses only to generic declarations, and avoid naming conflicts with other identifiers in scope:

- Remove the constraint clause from non-generic declarations (**CS0080**). The `where` clause can only be used on generic types and methods that declare type parameters, because constraints define requirements that type arguments must satisfy. If you need to apply constraints, first add type parameters to your type or method declaration. For example, change `public class MyClass where MyClass : System.IDisposable` to `public class MyClass<T> where T : System.IDisposable`.
- Replace actual type names with identifiers in type parameter declarations (**CS0081**). You must declare type parameters using identifiers (like `T`, `TKey`, or `TValue`) rather than concrete types (like `int` or `string`). The purpose of a type parameter is to serve as a placeholder that the compiler substitutes with actual types when the generic type or method is used. For example, change `public void F<int>()` to `public void F<T>()`.
- Rename type parameters, local variables, or parameters to avoid naming conflicts (**CS0412**, **CS0694**). Type parameter names can't shadow identifiers in the same scope. They can't match the name of the containing type or method. Such conflicts create ambiguity about which identifier is being referenced. For example, if you have a method `public void F<T>()`, you can't declare a local variable `double T` inside that method, and you can't name a type parameter the same as its containing type (`class C<C>`).
- Use the correct record declaration syntax (**CS9012**). When declaring a record type, you must use either `record class` or `record struct` (or just `record` for a reference type). The `record` keyword alone can't appear in positions where the compiler expects a type declaration syntax. For example, if you meant to declare a record type, write `record class MyRecord` or `record struct MyRecord` instead of placing `record` where a different keyword is expected.

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Constraint declaration and ordering

The following errors relate to the syntax and ordering of constraints on generic type parameters:

- **CS0401**: *The `new()` constraint must be the last constraint specified.*
- **CS0449**: *The `class`, `struct`, `unmanaged`, `notnull`, and `default` constraints cannot be combined or duplicated, and must be specified first in the constraints list.*
- **CS0450**: *Type Parameter: cannot specify both a constraint class and the `class` or `struct` constraint.*
- **CS0451**: *The `new()` constraint cannot be used with the `struct` constraint.*
- **CS9011**: *Keyword `delegate` cannot be used as a constraint. Did you mean `System.Delegate`?*

Constraints on type parameters must follow a specific order: primary constraints (`class`, `struct`, `unmanaged`, `notnull`, or `default`) come first, followed by interface or class constraints, and finally the `new()` constructor constraint. Some constraints are mutually exclusive and can't be combined.

To correct these errors:

- Place the `new()` constraint at the end of the constraint list (**CS0401**). The `new()` constraint must appear after all other constraints. For example, change `where T : new(), IDisposable` to `where T : IDisposable, new()`.
- Place primary constraints first and don't combine mutually exclusive constraints (**CS0449**). You can specify at most one of `class`, `struct`, `unmanaged`, `notnull`, or `default`, and it must appear first in the constraint list. The `class` and `struct` constraints are mutually exclusive, as are `class` and `unmanaged`. In a nullable context, `class` already implies `notnull`, so they can't be combined.
- Don't combine a specific class constraint with `struct` (**CS0450**). If a type parameter is constrained to a specific class type, it's implicitly a reference type, which contradicts the `struct` constraint. Remove either the class constraint or the `struct` constraint.
- Don't combine `new()` with `struct` (**CS0451**). All value types (structs) implicitly have a public parameterless constructor, so the `new()` constraint is redundant when combined with `struct`. Remove the `new()` constraint when using `struct`.
- Replace `delegate` with `System.Delegate` in constraint clauses (**CS9011**). The `delegate` keyword is used for declaring delegate types, not as a constraint. To constrain a type parameter to delegate types, use `System.Delegate` as the constraint type. For example, change `where T : delegate` to `where T : System.Delegate`.

The following example shows correct constraint ordering:

```csharp
using System;

// Primary constraint first, then interface constraints, then new()
class C<T> where T : class, IDisposable, new() { }

// struct doesn't need new() - it's implicit
class D<T> where T : struct, IComparable { }

// Delegate constraint using System.Delegate
class E<T> where T : System.Delegate { }
```

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Type argument count and usage

The following errors relate to providing the correct number and type of type arguments to generic types and methods:

- **CS0224**: *A method with vararg cannot be generic, be in a generic type, or have a params parameter.*
- **CS0305**: *Using the generic type requires N type arguments.*
- **CS0306**: *The type may not be used as a type argument.*
- **CS0307**: *The identifier is not a generic method. If you intended an expression list, use parentheses around the expression.*
- **CS0308**: *The non-generic type-or-method cannot be used with type arguments.*
- **CS7002**: *Unexpected use of a generic name.*

To correct these errors, ensure that you provide the exact number of type arguments required by the generic declaration. Use only valid types as type arguments. Don't apply type arguments to non-generic constructs:

- Remove generic type parameters or containing generic type declarations from methods that use `__arglist` (**CS0224**). The `__arglist` keyword is incompatible with generics because the runtime mechanisms for handling variable argument lists conflict with the type substitution required for generic type parameters. This restriction also applies to the `params` keyword when used in combination with generic methods or methods within generic types.
- Supply the exact number of type arguments specified in the generic type or method declaration (**CS0305**). Each generic type parameter declared in the definition must have a corresponding type argument when the generic type is instantiated. The compiler needs to know which concrete type to substitute for each type parameter. For example, if a class is declared as `class MyList<T>`, you must provide exactly one type argument when using it, such as `MyList<int>`, not `MyList<int, string>`.
- Use only valid types as type arguments (**CS0306**). Pointer types, such as `int*` or `char*`, can't be used as type arguments because generic types require managed types that the garbage collector can track, and pointer types are unmanaged. If you need to work with pointers in a generic context, consider using `IntPtr` or restructuring your code to avoid mixing generics with unsafe code.
- Remove type argument syntax from non-generic constructs (**CS0307**, **CS0308**). Type arguments enclosed in angle brackets (like `<int>`) can only be applied to generic types and methods that declare type parameters. You must either remove the type arguments entirely or ensure you imported the namespace that contains the generic version of the type. For example, `IEnumerator<T>` requires the `using System.Collections.Generic;` directive, whereas `IEnumerator` is in `System.Collections`.
- Remove type parameters from declarations that don't support generics (**CS7002**). Some constructs, such as enums, can't be generic. If you need a generic container for enum values, consider using a generic class or struct instead.

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Constructor constraints

The following errors relate to the `new()` constraint on generic type parameters:

- **CS0304**: *Cannot create an instance of the variable type because it does not have the `new()` constraint.*
- **CS0310**: *The type must be a non-abstract type with a public parameterless constructor in order to use it as parameter in the generic type or method.*
- **CS0417**: *Identifier: cannot provide arguments when creating an instance of a variable type.*

To correct these errors, add the `new()` constraint to type parameters that need to be instantiated, ensure type arguments have public parameterless constructors, and avoid passing arguments when constructing instances of type parameters:

- Add the `new()` constraint to the type parameter declaration (**CS0304**). When you use the `new` operator to create an instance of a type parameter within a generic type or method, the compiler must be able to guarantee that any type argument supplied at runtime has a parameterless constructor available. The `new()` constraint provides this guarantee at compile time, allowing the compiler to generate the appropriate instantiation code. For example, if you have `class C<T>` with a member `T t = new T();`, you must change the declaration to `class C<T> where T : new()`.
- Ensure that type arguments used with `new()` constrained type parameters have public parameterless constructors (**CS0310**). When a generic type or method declares a `new()` constraint on a type parameter, any concrete type used as a type argument must be non-abstract and must provide a public parameterless constructor. If a type only has non-public constructors (such as `private` or `protected` constructors) or only has constructors with parameters, it can't satisfy the `new()` constraint. To fix this error, either add a public parameterless constructor to the type or use a different type argument that already has one.
- Remove constructor arguments when instantiating type parameters (**CS0417**). The `new()` constraint only guarantees the existence of a parameterless constructor, so you can't pass arguments to `new T(arguments)` because the compiler can't verify that a constructor with those specific parameter types exists on the types that are substituted for `T`. If you need to construct instances with specific arguments, consider using factory methods, abstract factory patterns, or specific base class or interface constraints that define the construction behavior you need.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and the [`new()` constraint](../keywords/new-constraint.md).

## Constraint satisfaction and conversions

The following errors relate to type arguments not satisfying the constraints of generic type parameters:

- **CS0311**: *The type cannot be used as type parameter `T` in the generic type or method. There is no implicit reference conversion.*
- **CS0312**: *The type cannot be used as type parameter in the generic type or method. The nullable type does not satisfy the constraint.*
- **CS0313**: *The type cannot be used as type parameter in the generic type or method. The nullable type does not satisfy the constraint. Nullable types can not satisfy any interface constraints.*
- **CS0314**: *The type cannot be used as the type parameter in the generic type or method. There is no boxing conversion or type parameter conversion.*
- **CS0315**: *The type cannot be used as type parameter `T` in the generic type or method `TypeorMethod<T>`. There is no boxing conversion.*

To correct these errors, use type arguments that satisfy all constraints through appropriate conversions, ensure derived classes repeat base class constraints, and understand that nullable value types have special constraint requirements:

- Change the type argument to one that has an implicit reference conversion to the constraint type (**CS0311**). When a type parameter has a constraint like `where T : BaseType`, any type argument must be convertible to `BaseType` through an implicit reference conversion or identity conversion. The type argument must be `BaseType` itself, derive from `BaseType`, or implement `BaseType` if it's an interface. Implicit numeric conversions (such as from `short` to `int`) don't satisfy generic type parameter constraints because these conversions are value conversions, not reference conversions.
- Repeat the base class's type parameter constraints in any derived class declaration (**CS0314**). When a derived generic class inherits from a base generic class that has constraints on its type parameters, the derived class must declare the same constraints on its corresponding type parameters. You must repeat these constraints because the compiler needs to verify that type arguments supplied to the derived class satisfy the requirements of the base class. For example, if you have `public class A<T> where T : SomeClass`, then any class deriving from it must be declared as `public class B<T> : A<T> where T : SomeClass`.
- Use non-nullable value types or change the constraint type (**CS0312**, **CS0313**). Nullable value types (such as `int?`) are distinct from their underlying value types and don't satisfy the same constraints. There's no implicit conversion between `int?` and `int`, and nullable value types can't satisfy interface constraints because the nullable wrapper itself doesn't implement the interface, even though the underlying value type does. To fix these errors, either use the non-nullable form of the value type as the type argument, or adjust your constraint to accept `object` or a nullable reference type if appropriate.
- Ensure type arguments satisfy reference type or class constraints (**CS0315**). When a type parameter is constrained to a class type (such as `where T : SomeClass`), you can't use a value type (struct) as the type argument because there's no boxing conversion that satisfies the constraint relationship. The constraint requires a reference type that has an inheritance or implementation relationship with the constraint type. To resolve this error, either change the struct to a class if semantically appropriate, or remove the class constraint if the generic type can work with value types.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and [Implicit conversions](../../../standard/base-types/conversion-tables.md).

## Generic type usage restrictions

The following errors relate to restrictions on how generic types can be used:

- **CS0403**: *Cannot convert null to type parameter because it could be a non-nullable value type. Consider using `default(T)` instead.*
- **CS0413**: *The type parameter cannot be used with the `as` operator because it does not have a class type constraint nor a `class` constraint.*
- **CS0695**: *Type cannot implement both interfaces and because they may unify for some type parameter substitutions.*
- **CS0698**: *A generic type cannot derive from type because it is an attribute class.*
- **CS8322**: *Cannot pass argument with dynamic type to generic local function with inferred type arguments.*
- **CS9338**: *Inconsistent accessibility: type is less accessible than class.*

To correct these errors, use `default` instead of `null` for unconstrained type parameters, add class constraints when using the `as` operator, avoid interface unification conflicts, don't create generic attribute classes, and ensure type arguments match the visibility of their containing members:

- Replace `null` assignments with `default(T)` or add a `class` constraint (**CS0403**). When you assign `null` to an unconstrained type parameter, the compiler can't guarantee that the type argument is a reference type that accepts `null` values, because it might be a value type like `int` or `struct`, which can't be `null`. To resolve this error, either use `default(T)`, which provides the appropriate default value for any type (null for reference types, zero or empty for value types), or add a `class` constraint to the type parameter if you specifically need reference type semantics and want to allow `null` assignments.
- Add a `class` or specific type constraint when using the `as` operator (**CS0413**). The `as` operator performs a safe type cast that returns `null` if the conversion fails, but this behavior is incompatible with value types because value types can't be `null`. When you use `as` with an unconstrained type parameter, the compiler can't guarantee the type argument isn't a value type, so it rejects the code. To fix this error, add a `class` constraint or a specific reference type constraint (like `where T : SomeClass`) to ensure the type parameter is always a reference type that can properly handle the `null` result of a failed cast.
- Avoid implementing the same generic interface multiple times with type parameters that could unify (**CS0695**). When a class implements a generic interface multiple times with different type parameters (such as `class G<T1, T2> : I<T1>, I<T2>`), there's a risk that someone could instantiate it with the same type for both parameters (`G<int, int>`), which would create a conflict because the class would effectively be implementing `I<int>` twice. To resolve this error, either implement the interface only once, restructure your type parameters to prevent unification, or use separate non-generic classes for different specializations.
- Remove generic type parameters from attribute classes (**CS0698**).
  > [!NOTE]
  > This error isn't produced in current versions of C#, as generic attributes are now supported.
- Explicitly specify type arguments when passing dynamic values to generic local functions (**CS8322**). When you pass a `dynamic` argument to a generic local function, the compiler can't infer type arguments because the actual type isn't known until runtime. To fix this error, explicitly specify the type argument (for example, `LocalFunc<int>(d)`), cast the dynamic value to the expected type, or use a non-dynamic variable.
- Ensure type arguments used in public or protected signatures are at least as accessible as the member using them (**CS9338**). A public or protected generic member must use type arguments that are publicly accessible. Otherwise external code couldn't properly reference or use the member's signature. For example, if you have `public class Container<T>` where `T` is an internal type, external assemblies can see the `Container` but can't properly work with it because they can't see `T`. To fix this error, either make the type argument public, or reduce the accessibility of the member using it to match the type argument's accessibility.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md), [default value expressions](../operators/default.md), and [Attributes](../attributes/general.md).

## Valid constraint types

The following errors relate to using invalid types as constraints on generic type parameters:

- **CS0405**: *Duplicate constraint for type parameter.*
- **CS0702**: *Constraint cannot be special class.*
- **CS0703**: *Inconsistent accessibility: constraint type is less accessible than declaration.*
- **CS0706**: *Invalid constraint type. A type used as a constraint must be an interface, a non-sealed class, or a type parameter.*
- **CS0717**: *`static class`: static classes cannot be used as constraints.*

A constraint must be an interface, a non-sealed class, or a type parameter. Certain types are invalid as constraints due to their special meaning in the .NET type system or because they can't be inherited.

To correct these errors:

- Remove duplicate constraints (**CS0405**). Each constraint can only appear once in a constraint clause. If you have `where T : I, I`, remove the duplicate.
- Don't use special classes as constraints (**CS0702**). The types <xref:System.Object>, <xref:System.Array>, and <xref:System.ValueType> can't be used as constraints. Every type already derives from `Object`, so constraining to it provides no value. `Array` and `ValueType` are abstract base types that can't be directly inherited. If you need array-like behavior, use `IList<T>` or `IEnumerable<T>` instead.
- Ensure constraint types are at least as accessible as the generic type (**CS0703**). A public generic type can't have constraints using internal types, because external code wouldn't be able to provide valid type arguments. Either make the constraint type public, or reduce the accessibility of the generic type.
- Use only interfaces, non-sealed classes, or type parameters as constraints (**CS0706**). You can't use arrays, sealed classes, structs, enums, or other invalid types as constraints. If you need specific behavior, consider using an interface that the desired types implement.
- Don't use static classes as constraints (**CS0717**). Static classes can't be extended because they only contain static members. No type can exist that derives from a static class, making it useless as a constraint. Use a non-static class or interface instead.

The following example shows valid constraint types:

```csharp
public interface IMyInterface { }
public class MyBaseClass { }

// Valid: interface constraint
class A<T> where T : IMyInterface { }

// Valid: non-sealed class constraint
class B<T> where T : MyBaseClass { }

// Valid: type parameter constraint
class C<T, U> where T : U { }
```

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Constraint conflicts and circular dependencies

The following errors relate to conflicts between constraints or circular dependencies in constraint declarations:

- **CS0454**: *Circular constraint dependency involving Type Parameter 1 and Type Parameter 2.*
- **CS0455**: *Type parameter inherits conflicting constraints.*

Constraints can't create circular dependencies, and type parameters can't inherit conflicting constraints that are impossible to satisfy simultaneously.

To correct these errors:

- Remove circular constraint dependencies (**CS0454**). A type parameter can't directly or indirectly depend on itself through its constraints. For example, `where T : U where U : T` creates a circular dependency because `T` depends on `U` and `U` depends on `T`. Break the cycle by removing one of the constraints.
- Remove conflicting inherited constraints (**CS0455**). A type parameter can't be constrained to multiple unrelated classes, because C# doesn't support multiple class inheritance. Similarly, it can't be constrained to both `struct` and a class type, as these constraints are mutually exclusive. Restructure your type hierarchy or remove one of the conflicting constraints.

The following example shows the problems:

```csharp
// CS0454: Circular dependency - T depends on U and U depends on T
class Circular<T, U> where T : U where U : T { }

// CS0455: Conflicting constraints - U can't derive from both B and B2
public class B { }
public class B2 { }
public class G<T> where T : B
{
    public class N<U> where U : B2, T { }
}
```

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Type parameter variance

The following error relates to variance modifiers on generic type parameters:

- **CS1961**: *Invalid variance: The type parameter must be validly variant on type.*

Variance modifiers (`in` for contravariance, `out` for covariance) control how you use type parameters in interface and delegate declarations. A covariant (`out`) type parameter can only appear in output positions (return types), while a contravariant (`in`) type parameter can only appear in input positions (parameter types).

To correct this error:

- Use `out` (covariant) for type parameters that only appear in return types. Covariance allows a more derived type to be used where a less derived type is expected.
- Use `in` (contravariant) for type parameters that only appear in parameter types. Contravariance allows a less derived type to be used where a more derived type is expected.
- Remove the variance modifier if the type parameter must appear in both input and output positions.

The following example shows correct and incorrect variance usage:

```csharp
// Incorrect: out T can't appear in input position
interface IWrong<out T>
{
    void Method(T arg);  // CS1961
}

// Correct: out T only in output positions
interface ICovariant<out T>
{
    T GetValue();
}

// Correct: in T only in input positions
interface IContravariant<in T>
{
    void Process(T arg);
}

// No modifier needed for both input and output
interface IInvariant<T>
{
    T Transform(T arg);
}
```

For more information, see [Covariance and Contravariance in Generics](../../../standard/generics/covariance-and-contravariance.md).

## CS0406

The class type constraint 'constraint' must come before any other constraints.

When a generic type or method has a class type constraint, that constraint must be listed first. To avoid this error, move the class type constraint to the beginning of the constraint list.

```csharp
// CS0406.cs
// compile with: /target:library
interface I {}
class C {}
class D<T> where T : I, C {}   // CS0406
class D2<T> where T : C, I {}   // OK
```

## CS0409

A constraint clause has already been specified for type parameter 'type parameter'. All of the constraints for a type parameter must be specified in a single where clause.

Multiple constraint clauses (where clauses) were found for a single type parameter. Remove the extraneous where clause, or correct the where clauses so that a unique type parameter in each clause.

```csharp
// CS0409.cs
interface I
{
}

// Compiler error CS0409 is reported on the following line because T is specified in multiple where clauses.
class Example<T> where T : I where T : new()
{
}

// To resolve the error, combine the constraints for the same type parameter into a single clause.
class Example<T> where T : I, new()
{
}

// Using multiple where clauses is only valid when targeting different type parameters.
class Example<T1, T2> where T1 : I where T2 : new()
{
}
```

## CS0411

The type arguments for method 'method' cannot be inferred from the usage. Try specifying the type arguments explicitly.

This error occurs if you call a generic method without explicitly providing the type arguments and the compiler cannot infer which type arguments are intended. To avoid this error, add the intended type arguments in angle brackets.

### Example 1

The following sample generates CS0411:

```csharp
// CS0411.cs
class C
{
    void G<T>()
    {
    }

    public static void Main()
    {
        G();  // CS0411
        // Try this instead:
        // G<int>();
    }
}
```

### Example 2

Other possible error cases include when the parameter is `null`, which has no type information:

```csharp
// CS0411b.cs
class C
{
    public void F<T>(T t) where T : C
    {
    }

    public static void Main()
    {
        C c = new C();
        c.F(null);  // CS0411
    }
}
```

## CS0452

The type 'type name' must be a reference type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.

This error occurs when you pass a value type such as a `struct` or `int` as a parameter to a generic type or method that has a reference type constraint.

```csharp
// CS0452.cs
using System;
public class BaseClass<S> where S : class { }
public class Derived1 : BaseClass<int> { } // CS0452
public class Derived2<S> : BaseClass<S> where S : struct { } // CS0452
```

For more information, see [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## CS0453

The type 'Type Name' must be a non-nullable value type in order to use it as parameter 'Parameter Name' in the generic type or method 'Generic Identifier'.

This error occurs when you use a [non-value type](../builtin-types/value-types.md) argument in instantiating a generic type or method that has the [**value** constraint](../../programming-guide/generics/constraints-on-type-parameters.md) on it. It can also occur when you use a nullable value type argument. See the last two lines of code in the following example.

```csharp
// CS0453.cs
using System;
public class HV<S> where S : struct { }

// CS0453: string is not a value type
public class H1 : HV<string> { }

// CS0453: H1 is a class, not a struct
public class H2 : HV<H1> { }

// CS0453: HV is based on a class, not a struct
public class H3<S> : HV<S> where S : class { }
public class H4<S> : HV<S> where S : struct { } // OK

// CS0453: HV accepts a nullable int type
public class H4 : HV<int?> { }

// CS0453: HV is based on Nullable type of int
public class H5 : HV<Nullable<Nullable<int>>> { }
```

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## CS0456

Type parameter 'Type Parameter Name 1' has the 'struct' constraint so 'Type Parameter Name 1' cannot be used as a constraint for 'Type Parameter Name 2'.

Value type constraints are implicitly sealed so those constraints cannot be used as constraints on a second type parameter. This is because value types cannot be overridden. To resolve this error, put a value type constraint directly on the second type parameter, instead of doing so indirectly by means of the first type parameter.

```csharp
// CS0456.cs
// compile with: /target:library
public class GenericsErrors
{
   public class G5<T> where T : struct
   {
      public class N<U> where U : T {}   // CS0456
      public class N2<U> where U : struct {}   // OK
   }
}
```

## CS0693

Type parameter 'type parameter' has the same name as the type parameter from outer type 'type'.

This error occurs when you have a generic member such as a method inside a generic class. Since the method's type parameter is not necessarily the same as the class's type parameter, you cannot give them both the same name. For more information, see [Generic Methods](../../programming-guide/generics/generic-methods.md).

To avoid this situation, use a different name for one of the type parameters.

```csharp
// CS0693.cs
// compile with: /W:3 /target:library
class Outer<T>
{
   class Inner<T> {}   // CS0693
   // try the following line instead
   // class Inner<U> {}
}
```

## CS0699

'generic' does not define type parameter 'identifier'.

A type parameter was used in a generic definition that was not found in the declaration list of the type parameters for that generic. This can happen if the name used for the type parameter was inconsistent.

The following sample generates CS0699:

```csharp
// CS0699.cs
class C<T> where U : I   // CS0699 – U is not a valid type parameter
{
}
```

## CS0701

'identifier' is not a valid constraint. A type used as a constraint must be an interface, a non-sealed class or a type parameter.

This error occurs if a sealed type is used as a constraint. To resolve this error, use only non-sealed types as constraints.

```csharp
// CS0701.cs
// compile with: /target:library
class C<T> where T : System.String {}   // CS0701
class D<T> where T : System.Attribute {}   // OK
```

## CS0704

Cannot do non-virtual member lookup in 'type' because it is a type parameter.

An inner type cannot be specified through a type parameter. Try using the desired type explicitly.

```csharp
// CS0704.cs
class B
{
    public class I { }
}

class C<T> where T : B
{
    T.I f;  // CS0704 – member lookup on type parameter
    // Try this instead:
    // B.I f;
}

class CMain
{
    public static void Main() {}
}
```

## CS0718

'type': static types cannot be used as type arguments.

Because a static type cannot be instantiated, it cannot be used as a generic argument. To resolve this error, remove the static type from the generic argument.

```csharp
// CS0718.cs
public static class SC
{
    public static void F()
    {
    }
}

public class G<T>
{
}

public class CMain
{
    public static void Main()
    {
        G<SC> gsc = new G<SC>();  // CS0718
    }
}
```

## CS1720

Expression will always cause a System.NullReferenceException because the default value of 'generic type' is null.

If you write an expression involving the default of a generic type variable that is a reference type (for example, a class), this error will occur. Consider the following expression:

```csharp
default(T).ToString()
```

Since `T` is a reference type, its default value is null, and so attempting to apply the <xref:System.Object.ToString*> method to it will throw a <xref:System.NullReferenceException>.

The class reference constraint on type `T` ensures that `T` is a reference type.

The following sample generates CS1720.

```csharp
// CS1720.cs
using System;
public class Tester
{
    public static void GenericClass<T>(T t1) where T : class
    {
        Console.WriteLine(default(T).ToString());  // CS1720
    }
    public static void Main() {}
}
```

## CS1763

'parameter' is of type 'type'. A default parameter value of a reference type other than string can only be initialized with null.

```csharp
// CS1763.cs
class Program
{
    public void Goo<T, U>(T t = default(U)) where U : T
    {
    }
    static void Main(string[] args)
    {

    }
}
```

This example generates CS1763 because the `Goo<T,U>` parameter is declared with a default value of `default(U)` when the type of the parameter is `T`, despite the constraint that `U` derive from base class `T`.

Changing `default(U)` to use the corresponding type argument corrects this error:

```csharp
    public void Goo<T, U>(T t = default(T)) where U : T
    {
    }
```

## CS1948

The range variable 'name' cannot have the same name as a method type parameter.

The same declaration space cannot contain two declarations of the same identifier.

To correct this error, change the name of the range variable or the type parameter.

The following example generates CS1948 because the identifier `T` is used for the range variable and for the type parameter on method `TestMethod`:

```csharp
// cs1948.cs
using System.Linq;
class Test
{
    public void TestMethod<T>(T t)
    {
        var x = from T in Enumerable.Range(1, 100) // CS1948
                select T;
    }
}
```

## CS3024

Constraint type 'type' is not CLS-compliant.

The compiler issues this warning because the use of a non-CLS-compliant type as a generic type constraint could make it impossible for code written in some languages to consume your generic class.

To eliminate this warning, use a CLS-compliant type for the type constraint.

```csharp
// cs3024.cs
// Compile with: /target:library
 [assembly: System.CLSCompliant(true)]

[type: System.CLSCompliant(false)]
public class TestClass // CS3024
{
    public ushort us;
}
[type: System.CLSCompliant(false)]
public interface ITest // CS3024
{}
public interface I<T> where T : TestClass
{}
public class TestClass_2<T> where T : ITest
{}
public class TestClass_3<T> : I<T> where T : TestClass
{}
public class TestClass_4<T> : TestClass_2<T> where T : ITest
{}
public class Test
{
    public static int Main()
    {
        return 0;
    }
}
```

For more information, see [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).
