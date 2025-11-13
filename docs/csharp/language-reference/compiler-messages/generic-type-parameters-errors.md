---
title: Resolve errors and warnings related to generic type parameters and type arguments.
description: These compiler errors and warnings indicate errors in generic type parameters and type arguments.
f1_keywords:
  - "CS0080"
  - "CS0081"
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
  - "CS0403"
  - "CS0412"
  - "CS0413"
  - "CS0417"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS9338"
helpviewer_keywords:
  - "CS0080"
  - "CS0081"
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
  - "CS0403"
  - "CS0412"
  - "CS0413"
  - "CS0694"
  - "CS0695"
  - "CS0698"
  - "CS0417"
  - "CS9338"
ms.date: 11/13/2025
ai-usage: ai-assisted
---
# Resolve errors and warnings related to generic type parameters and generic type arguments

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0080**](#type-parameter-declaration-and-naming): *Constraints are not allowed on non-generic declarations.*
- [**CS0081**](#type-parameter-declaration-and-naming): *Type parameter declaration must be an identifier not a type.*
- [**CS0224**](#type-argument-count-and-usage): *A method with vararg cannot be generic, be in a generic type, or have a params parameter.*
- [**CS0304**](#constructor-constraints): *Cannot create an instance of the variable type 'type' because it does not have the new() constraint.*
- [**CS0305**](#type-argument-count-and-usage): *Using the generic type 'generic type' requires 'number' type arguments.*
- [**CS0306**](#type-argument-count-and-usage): *The type 'type' may not be used as a type argument.*
- [**CS0307**](#type-argument-count-and-usage): *The 'construct' 'identifier' is not a generic method. If you intended an expression list, use parentheses around the < expression.*
- [**CS0308**](#type-argument-count-and-usage): *The non-generic type-or-method 'identifier' cannot be used with type arguments.*
- [**CS0310**](#constructor-constraints): *The type 'typename' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'parameter' in the generic type or method 'generic'.*
- [**CS0311**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'T' in the generic type or method '\<name>'. There is no implicit reference conversion from 'type1' to 'type2'.*
- [**CS0312**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. The nullable type 'type1' does not satisfy the constraint of 'type2'.*
- [**CS0313**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'parameter name' in the generic type or method 'type2'. The nullable type 'type1' does not satisfy the constraint of 'type2'. Nullable types can not satisfy any interface constraints.*
- [**CS0314**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. There is no boxing conversion or type parameter conversion from 'type1' to 'type2'.*
- [**CS0315**](#constraint-satisfaction-and-conversions): *The type 'valueType' cannot be used as type parameter 'T' in the generic type or method 'TypeorMethod\<T>'. There is no boxing conversion from 'valueType' to 'referenceType'.*
- [**CS0403**](#generic-type-usage-restrictions): *Cannot convert null to type parameter 'name' because it could be a non-nullable value type. Consider using 'default('T')' instead.*
- [**CS0412**](#type-parameter-declaration-and-naming): *'parameter': a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- [**CS0413**](#generic-type-usage-restrictions): *The type parameter 'type parameter' cannot be used with the 'as' operator because it does not have a class type constraint nor a 'class' constraint.*
- [**CS0417**](#constructor-constraints): *'identifier': cannot provide arguments when creating an instance of a variable type.*
- [**CS0694**](#type-parameter-declaration-and-naming): *Type parameter 'identifier' has the same name as the containing type, or method.*
- [**CS0695**](#generic-type-usage-restrictions): *'type' cannot implement both 'interface1' and 'interface2' because they may unify for some type parameter substitutions.*
- [**CS0698**](#generic-type-usage-restrictions): *A generic type cannot derive from 'type' because it is an attribute class.*
- [**CS9338**](#generic-type-usage-restrictions): *Inconsistent accessibility: type 'type1' is less accessible than class 'type2'.*

## Type parameter declaration and naming

The following errors relate to how type parameters are declared and named in generic types and methods:

- **CS0080**: *Constraints are not allowed on non-generic declarations.*
- **CS0081**: *Type parameter declaration must be an identifier not a type.*
- **CS0412**: *'parameter': a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- **CS0694**: *Type parameter 'identifier' has the same name as the containing type, or method.*

To correct these errors, ensure that type parameters are declared with valid identifiers, constraint clauses are only applied to generic declarations, and type parameter names don't conflict with other identifiers in scope:

- Remove the constraint clause from non-generic declarations (**CS0080**). The `where` clause can only be used on generic types and methods that declare type parameters, because constraints define requirements that type arguments must satisfy. If you need to apply constraints, first add type parameters to your type or method declaration. For example, change `public class MyClass where MyClass : System.IDisposable` to `public class MyClass<T> where T : System.IDisposable`.
- Replace actual type names with identifiers in type parameter declarations (**CS0081**). Type parameters must be declared using identifiers (like `T`, `TKey`, or `TValue`) rather than concrete types (like `int` or `string`), because the purpose of a type parameter is to serve as a placeholder that is substituted with actual types when the generic type or method is used. For example, change `public void F<int>()` to `public void F<T>()`.
- Rename type parameters, local variables, or parameters to avoid naming conflicts (**CS0412**, **CS0694**). Type parameter names can't shadow identifiers in the same scope. They can't match the name of the containing type or method. Such conflicts create ambiguity about which identifier is being referenced. For example, if you have a method `public void F<T>()`, you can't declare a local variable `double T` inside that method, and you can't name a type parameter the same as its containing type (`class C<C>`).

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Type argument count and usage

The following errors relate to providing the correct number and type of type arguments to generic types and methods:

- **CS0224**: *A method with vararg cannot be generic, be in a generic type, or have a params parameter*
- **CS0305**: *Using the generic type 'generic type' requires 'number' type arguments*
- **CS0306**: *The type 'type' may not be used as a type argument*
- **CS0307**: *The 'construct' 'identifier' is not a generic method. If you intended an expression list, use parentheses around the < expression.*
- **CS0308**: *The non-generic type-or-method 'identifier' cannot be used with type arguments.*

To correct these errors, ensure that you provide the exact number of type arguments required by the generic declaration. Use only valid types as type arguments. Don't apply type arguments to non-generic constructs:

- Remove generic type parameters or containing generic type declarations from methods that use `__arglist` (**CS0224**). The `__arglist` keyword is incompatible with generics because the runtime mechanisms for handling variable argument lists conflict with the type substitution required for generic type parameters. This restriction also applies to the `params` keyword when used in combination with generic methods or methods within generic types.
- Supply the exact number of type arguments specified in the generic type or method declaration (**CS0305**). Each generic type parameter declared in the definition must have a corresponding type argument when the generic type is instantiated. The compiler needs to know which concrete type to substitute for each type parameter. For example, if a class is declared as `class MyList<T>`, you must provide exactly one type argument when using it, such as `MyList<int>`, not `MyList<int, string>`.
- Use only valid types as type arguments (**CS0306**). Pointer types, such as `int*` or `char*`, can't be used as type arguments because generic types require managed types that the garbage collector can track, and pointer types are unmanaged. If you need to work with pointers in a generic context, consider using `IntPtr` or restructuring your code to avoid mixing generics with unsafe code.
- Remove type argument syntax from non-generic constructs (**CS0307**, **CS0308**). Type arguments enclosed in angle brackets (like `<int>`) can only be applied to generic types and methods that declare type parameters. You must either remove the type arguments entirely or ensure you imported the namespace that contains the generic version of the type. For example, `IEnumerator<T>` requires the `using System.Collections.Generic;` directive, whereas `IEnumerator` is in `System.Collections`.

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Constructor constraints

The following errors relate to the `new()` constraint on generic type parameters:

- **CS0304**: *Cannot create an instance of the variable type 'type' because it does not have the new() constraint*
- **CS0310**: *The type 'typename' must be a non-abstract type with a public parameterless constructor in order to use it as parameter 'parameter' in the generic type or method 'generic'*
- **CS0417**: *'identifier': cannot provide arguments when creating an instance of a variable type*

To correct these errors, add the `new()` constraint to type parameters that need to be instantiated, ensure type arguments have public parameterless constructors, and avoid passing arguments when constructing instances of type parameters:

- Add the `new()` constraint to the type parameter declaration (**CS0304**). When you use the `new` operator to create an instance of a type parameter within a generic type or method, the compiler must be able to guarantee that any type argument supplied at runtime has a parameterless constructor available. The `new()` constraint provides this guarantee at compile time, allowing the compiler to generate the appropriate instantiation code. For example, if you have `class C<T>` with a member `T t = new T();`, you must change the declaration to `class C<T> where T : new()`.
- Ensure that type arguments used with `new()` constrained type parameters have public parameterless constructors (**CS0310**). When a generic type or method declares a `new()` constraint on a type parameter, any concrete type used as a type argument must be non-abstract and must provide a public parameterless constructor. If a type only has non-public constructors (such as `private` or `protected`) or only has constructors with parameters, it can't satisfy the `new()` constraint. To fix this error, either add a public parameterless constructor to the type, or use a different type argument that already has one.
- Remove constructor arguments when instantiating type parameters (**CS0417**). The `new()` constraint only guarantees the existence of a parameterless constructor, so attempting to pass arguments to `new T(arguments)` isn't allowed because the compiler can't verify that a constructor with those specific parameter types exists on the type that are substituted for `T`. If you need to construct instances with specific arguments, consider using factory methods, abstract factory patterns, or specific base class/interface constraints that define the construction behavior you need.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and the [new() constraint](../keywords/new-constraint.md).

## Constraint satisfaction and conversions

The following errors relate to type arguments not satisfying the constraints of generic type parameters:

- **CS0311**: *The type 'type1' cannot be used as type parameter 'T' in the generic type or method '\<name>'. There is no implicit reference conversion from 'type1' to 'type2'.*
- **CS0312**: *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. The nullable type 'type1' does not satisfy the constraint of 'type2'.*
- **CS0313**: *The type 'type1' cannot be used as type parameter 'parameter name' in the generic type or method 'type2'. The nullable type 'type1' does not satisfy the constraint of 'type2'. Nullable types can not satisfy any interface constraints.*
- **CS0314**: *The type 'type1' cannot be used as type parameter 'name' in the generic type or method 'name'. There is no boxing conversion or type parameter conversion from 'type1' to 'type2'.*
- **CS0315**: *The type 'valueType' cannot be used as type parameter 'T' in the generic type or method 'TypeorMethod\<T>'. There is no boxing conversion from 'valueType' to 'referenceType'.*

To correct these errors, use type arguments that satisfy all constraints through appropriate conversions, ensure derived classes repeat base class constraints, and understand that nullable value types have special constraint requirements:

- Change the type argument to one that has an implicit reference conversion to the constraint type (**CS0311**). When a type parameter has a constraint like `where T : BaseType`, any type argument must be convertible to `BaseType` through an implicit reference conversion or identity conversion. The type argument must either be `BaseType` itself, derive from `BaseType`, or implement `BaseType` if it's an interface. Implicit numeric conversions (such as from `short` to `int`) don't satisfy generic type parameter constraints because these conversions are value conversions, not reference conversions.
- Repeat the base class's type parameter constraints in any derived class declaration (**CS0314**). When a derived generic class inherits from a base generic class that has constraints on its type parameters, the derived class must declare the same constraints on its corresponding type parameters. Repetition is required because the compiler needs to verify that type arguments supplied to the derived class satisfies the requirements of the base class. For example, if you have `public class A<T> where T : SomeClass`, then any class deriving from it must be declared as `public class B<T> : A<T> where T : SomeClass`.
- Use non-nullable value types or change the constraint type (**CS0312**, **CS0313**). Nullable value types (such as `int?`) are distinct from their underlying value types and don't satisfy the same constraints. There's no implicit conversion between `int?` and `int`, and nullable value types can't satisfy interface constraints because the nullable wrapper itself doesn't implement the interface, even though the underlying value type does. To fix these errors, either use the non-nullable form of the value type as the type argument, or adjust your constraint to accept `object` or a nullable reference type if appropriate.
- Ensure type arguments satisfy reference type or class constraints (**CS0315**). When a type parameter is constrained to a class type (such as `where T : SomeClass`), you can't use a value type (struct) as the type argument because there's no boxing conversion that satisfies the constraint relationship. The constraint requires a reference type that has an inheritance or implementation relationship with the constraint type. To resolve this error, either change the struct to a class if semantically appropriate, or remove the class constraint if the generic type can work with value types.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and [Implicit conversions](../../../standard/base-types/conversion-tables.md).

## Generic type usage restrictions

The following errors relate to restrictions on how generic types can be used:

- **CS0403**: *Cannot convert null to type parameter 'name' because it could be a non-nullable value type. Consider using 'default('T')' instead.*
- **CS0413**: *The type parameter 'type parameter' cannot be used with the 'as' operator because it does not have a class type constraint nor a 'class' constraint.*
- **CS0695**: *'type' cannot implement both 'interface1' and 'interface2' because they may unify for some type parameter substitutions.*
- **CS0698**: *A generic type cannot derive from 'type' because it is an attribute class.*
- **CS9338**: *Inconsistent accessibility: type 'type1' is less accessible than class 'type2'.*

To correct these errors, use `default` instead of `null` for unconstrained type parameters, add class constraints when using the `as` operator, avoid interface unification conflicts, don't create generic attribute classes, and ensure type arguments match the visibility of their containing members:

- Replace `null` assignments with `default(T)` or add a class constraint (**CS0403**). When you assign `null` to an unconstrained type parameter, the compiler can't guarantee that the type argument is a reference type that accepts `null` values, because it might be a value type like `int` or `struct`, which can't be `null`. To resolve this error, either use `default(T)`, which provides the appropriate default value for any type (null for reference types, zero or empty for value types), or add a `class` constraint to the type parameter if you specifically need reference type semantics and want to allow `null` assignments.
- Add a `class` or specific type constraint when using the `as` operator (**CS0413**). The `as` operator performs a safe type cast that returns `null` if the conversion fails, but this behavior is incompatible with value types because value types can't be `null`. When you use `as` with an unconstrained type parameter, the compiler can't guarantee the type argument isn't a value type, so it rejects the code. To fix this error, add a `class` constraint or a specific reference type constraint (like `where T : SomeClass`) to ensure the type parameter is always a reference type that can properly handle the `null` result of a failed cast.
- Avoid implementing the same generic interface multiple times with type parameters that could unify (**CS0695**). When a class implements a generic interface multiple times with different type parameters (such as `class G<T1, T2> : I<T1>, I<T2>`), there's a risk that someone could instantiate it with the same type for both parameters (`G<int, int>`), which would create a conflict because the class would effectively be implementing `I<int>` twice. To resolve this error, either implement the interface only once, restructure your type parameters to prevent unification, or use separate non-generic classes for different specializations.
- Remove generic type parameters from attribute classes (**CS0698**).
  > [!NOTE]
  > This error is no longer produced in current versions of C#, as generic attributes are now supported.
- Ensure type arguments used in public or protected signatures are at least as accessible as the member using them (**CS9338**). A public or protected generic member must use type arguments that are be publicly accessible. Otherwise external code couldn't properly reference or use the member's signature. For example, if you have `public class Container<T>` where `T` is an internal type, external assemblies can see the `Container` but can't properly work with it because they can't see `T`. To fix this error, either make the type argument public, or reduce the accessibility of the member using it to match the type argument's accessibility.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md), [default value expressions](../operators/default.md), and [Attributes](../../programming-guide/concepts/attributes/index.md).
