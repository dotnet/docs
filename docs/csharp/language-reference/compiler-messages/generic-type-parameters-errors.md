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
  - "CS1960"
  - "CS1961"
  - "CS3024"
  - "CS7002"
  - "CS8322"
  - "CS8375"
  - "CS8377"
  - "CS8379"
  - "CS8380"
  - "CS8387"
  - "CS8389"
  - "CS8427"
  - "CS8665"
  - "CS8666"
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
  - "CS1960"
  - "CS1961"
  - "CS3024"
  - "CS7002"
  - "CS8322"
  - "CS8375"
  - "CS8377"
  - "CS8379"
  - "CS8380"
  - "CS8387"
  - "CS8389"
  - "CS8427"
  - "CS8665"
  - "CS8666"
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
- [**CS0081**](#type-parameter-declaration-and-naming): *Type parameter declaration must be an identifier not a type.*
- [**CS0224**](#type-argument-count-and-usage): *A method with vararg cannot be generic, be in a generic type, or have a params parameter.*
- [**CS0304**](#constructor-constraints): *Cannot create an instance of the variable type because it does not have the `new()` constraint.*
- [**CS0305**](#type-argument-count-and-usage): *Using the generic type requires N type arguments.*
- [**CS0306**](#type-argument-count-and-usage): *The type may not be used as a type argument.*
- [**CS0307**](#type-argument-count-and-usage): *The 'identifier' cannot be used with type arguments.*
- [**CS0308**](#type-argument-count-and-usage): *The non-generic type-or-method cannot be used with type arguments.*
- [**CS0310**](#constructor-constraints): *The type must be a non-abstract type with a public parameterless constructor in order to use it as parameter in the generic type or method.*
- [**CS0311**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter `T` in the generic type or method. There is no implicit reference conversion from 'type1' to 'type2'.*
- [**CS0312**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter in the generic type or method. The nullable type 'type1' does not satisfy the constraint of 'constraint'.*
- [**CS0313**](#constraint-satisfaction-and-conversions): *The type 'type1' cannot be used as type parameter in the generic type or method. The nullable type 'type1' does not satisfy the constraint of 'constraint'. Nullable types can not satisfy any interface constraints.*
- [**CS0314**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter in the generic type or method. There is no boxing conversion or type parameter conversion from 'type' to 'constraint'.*
- [**CS0315**](#constraint-satisfaction-and-conversions): *The type cannot be used as type parameter `T` in the generic type or method. There is no boxing conversion from 'type' to 'constraint'.*
- [**CS0401**](#constraint-declaration-and-ordering): *The `new()` constraint must be the last restrictive constraint specified.*
- [**CS0403**](#generic-type-usage-restrictions): *Cannot convert null to type parameter because it could be a non-nullable value type. Consider using `default(T)` instead.*
- [**CS0405**](#valid-constraint-types): *Duplicate constraint for type parameter.*
- [**CS0406**](#constraint-declaration-and-ordering): *The class type constraint 'constraint' must come before any other constraints.*
- [**CS0409**](#constraint-declaration-and-ordering): *A constraint clause has already been specified for type parameter 'type parameter'. All of the constraints for a type parameter must be specified in a single where clause.*
- [**CS0411**](#type-argument-inference): *The type arguments for method 'method' cannot be inferred from the usage. Try specifying the type arguments explicitly.*
- [**CS0412**](#type-parameter-declaration-and-naming): *Parameter: a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- [**CS0413**](#generic-type-usage-restrictions): *The type parameter cannot be used with the `as` operator because it does not have a class type constraint nor a `class` constraint.*
- [**CS0417**](#constructor-constraints): *Identifier: cannot provide arguments when creating an instance of a variable type.*
- [**CS0449**](#constraint-declaration-and-ordering): *The `class`, `struct`, `unmanaged`, `notnull`, and `default` constraints cannot be combined or duplicated, and must be specified first in the constraints list.*
- [**CS0450**](#constraint-declaration-and-ordering): *Type Parameter: cannot specify both a constraint class and the `class` or `struct` constraint.*
- [**CS0451**](#constraint-declaration-and-ordering): *The `new()` constraint cannot be used with the `struct` constraint.*
- [**CS0452**](#constraint-satisfaction-and-conversions): *The type 'type name' must be a reference type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- [**CS0453**](#constraint-satisfaction-and-conversions): *The type 'type name' must be a non-nullable value type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- [**CS0454**](#constraint-conflicts-and-circular-dependencies): *Circular constraint dependency involving Type Parameter 1 and Type Parameter 2.*
- [**CS0455**](#constraint-conflicts-and-circular-dependencies): *Type parameter inherits conflicting constraints 'constraint1' and 'constraint2'.*
- [**CS0456**](#constraint-conflicts-and-circular-dependencies): *Type parameter 'type parameter 1' has the 'struct' constraint so 'type parameter 1' cannot be used as a constraint for 'type parameter 2'.*
- [**CS0693**](#type-parameter-declaration-and-naming): *Type parameter 'type parameter' has the same name as the type parameter from outer type 'type'.*
- [**CS0694**](#type-parameter-declaration-and-naming): *Type parameter has the same name as the containing type, or method.*
- [**CS0695**](#generic-type-usage-restrictions): *'type' cannot implement both 'interface1' and 'interface2' because they may unify for some type parameter substitutions.*
- [**CS0698**](#generic-type-usage-restrictions): *A generic type cannot derive from type because it is an attribute class.*
- [**CS0699**](#type-parameter-declaration-and-naming): *'generic' does not define type parameter 'identifier'.*
- [**CS0701**](#valid-constraint-types): *'identifier' is not a valid constraint. A type used as a constraint must be an interface, a non-sealed class or a type parameter.*
- [**CS0702**](#valid-constraint-types): *Constraint cannot be special class.*
- [**CS0703**](#valid-constraint-types): *Inconsistent accessibility: constraint type is less accessible than declaration.*
- [**CS0704**](#generic-type-usage-restrictions): *Cannot do non-virtual member lookup in 'type' because it is a type parameter.*
- [**CS0706**](#valid-constraint-types): *Invalid constraint type. A type used as a constraint must be an interface, a non-sealed class or a type parameter.*
- [**CS0717**](#valid-constraint-types): *Static class: static classes cannot be used as constraints.*
- [**CS0718**](#generic-type-usage-restrictions): *'type': static types cannot be used as type arguments.*
- [**CS1720**](#generic-type-usage-restrictions): *Expression will always cause a System.NullReferenceException because the default value of 'generic type' is null.*
- [**CS1763**](#generic-type-usage-restrictions): *'parameter' is of type 'type'. A default parameter value of a reference type other than string can only be initialized with null.*
- [**CS1948**](#type-parameter-declaration-and-naming): *The range variable 'name' cannot have the same name as a method type parameter.*
- [**CS1960**](#type-parameter-variance): *Invalid variance modifier. Only interface and delegate type parameters can be specified as variant.*
- [**CS1961**](#type-parameter-variance): *Invalid variance: The type parameter must be covariantly valid on 'type'. 'type parameter' is contravariant.*
- [**CS3024**](#valid-constraint-types): *Constraint type 'type' is not CLS-compliant.*
- [**CS7002**](#type-argument-count-and-usage): *Unexpected use of a generic name.*
- [**CS8322**](#generic-type-usage-restrictions): *Cannot pass argument with dynamic type to generic local function with inferred type arguments.*
- [**CS8375**](#constraint-declaration-and-ordering): *The 'new()' constraint cannot be used with the 'unmanaged' constraint.*
- [**CS8377**](#constraint-satisfaction-and-conversions): *The type 'type' must be a non-nullable value type, along with all fields at any level of nesting, in order to use it as parameter 'parameter' in the generic type or method 'generic'.*
- [**CS8379**](#constraint-conflicts-and-circular-dependencies): *Type parameter 'type parameter 1' has the 'unmanaged' constraint so 'type parameter 1' cannot be used as a constraint for 'type parameter 2'.*
- [**CS8380**](#constraint-declaration-and-ordering): *'type': cannot specify both a constraint class and the 'unmanaged' constraint.*
- [**CS8387**](#type-parameter-declaration-and-naming): *Type parameter 'type parameter' has the same name as the type parameter from outer method 'method'.*
- [**CS8389**](#type-argument-count-and-usage): *Omitting the type argument is not allowed in the current context.*
- [**CS8427**](#type-parameter-variance): *Enums, classes, and structures cannot be declared in an interface that has an 'in' or 'out' type parameter.*
- [**CS8665**](#override-and-implementation-constraint-rules): *Method 'method' specifies a 'class' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is not a reference type.*
- [**CS8666**](#override-and-implementation-constraint-rules): *Method 'method' specifies a 'struct' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is not a non-nullable value type.*
- [**CS8822**](#override-and-implementation-constraint-rules): *Method 'method' specifies a 'default' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is constrained to a reference type or a value type.*
- [**CS8823**](#override-and-implementation-constraint-rules): *The 'default' constraint is valid on override and explicit interface implementation methods only.*
- [**CS8893**](#unmanagedcallersonly-restrictions): *'type' is not a valid calling convention type for 'UnmanagedCallersOnly'.*
- [**CS8894**](#unmanagedcallersonly-restrictions): *Cannot use 'type' as a parameter or return type on a method attributed with 'UnmanagedCallersOnly'.*
- [**CS8895**](#unmanagedcallersonly-restrictions): *Methods attributed with 'UnmanagedCallersOnly' cannot have generic type parameters and cannot be declared in a generic type.*
- [**CS8896**](#unmanagedcallersonly-restrictions): *'UnmanagedCallersOnly' can only be applied to ordinary static non-abstract, non-virtual methods or static local functions.*
- [**CS9011**](#constraint-declaration-and-ordering): *Keyword `delegate` cannot be used as a constraint. Did you mean `System.Delegate`?*
- [**CS9012**](#type-parameter-declaration-and-naming): *Unexpected keyword `record`. Did you mean `record struct` or `record class`?*
- [**CS9338**](#generic-type-usage-restrictions): *Inconsistent accessibility: type is less accessible than class.*

## Type parameter declaration and naming

- **CS0080**: *Constraints are not allowed on non-generic declarations.*
- **CS0081**: *Type parameter declaration must be an identifier not a type.*
- **CS0412**: *Parameter: a parameter, local variable, or local function cannot have the same name as a method type parameter.*
- **CS0693**: *Type parameter 'type parameter' has the same name as the type parameter from outer type 'type'.*
- **CS0694**: *Type parameter has the same name as the containing type, or method.*
- **CS0699**: *'generic' does not define type parameter 'identifier'.*
- **CS1948**: *The range variable 'name' cannot have the same name as a method type parameter.*
- **CS8387**: *Type parameter 'type parameter' has the same name as the type parameter from outer method 'method'.*
- **CS9012**: *Unexpected keyword `record`. Did you mean `record struct` or `record class`?*

These errors relate to how you declare and name type parameters in generic types and methods. Type parameter names must be valid identifiers, must not conflict with other identifiers in scope, and must appear in the declaration's type parameter list.

- Remove the constraint clause from non-generic declarations (**CS0080**). The `where` clause can only be used on generic types and methods that declare type parameters. If you need to apply constraints, first add type parameters to your type or method declaration.
- Replace actual type names with identifiers in type parameter declarations (**CS0081**). You must declare type parameters using identifiers (like `T`, `TKey`, or `TValue`) rather than concrete types (like `int` or `string`). The purpose of a type parameter is to serve as a placeholder that the compiler substitutes with actual types when the generic type or method is used.
- Rename type parameters, local variables, parameters, or range variables to avoid naming conflicts (**CS0412**, **CS0694**, **CS1948**). Type parameter names can't shadow identifiers in the same scope, and they can't match the name of the containing type or method. LINQ range variables also can't reuse a method's type parameter name. Such conflicts create ambiguity about which identifier is being referenced.
- Use a different name for inner type parameters that shadow outer ones (**CS0693**, **CS8387**). When a generic member (such as a method or nested type) is inside a generic class or method, the inner type parameter isn't necessarily the same as the outer one. Giving them the same name creates confusion about which type parameter is being referenced. Use a distinct name for the inner type parameter.
- Ensure all type parameters in constraint clauses are declared in the type parameter list (**CS0699**). A `where` clause can only reference type parameters that appear in the generic declaration. If the name in the `where` clause doesn't match any declared type parameter, check for typos or misspellings.
- Use the correct record declaration syntax (**CS9012**). When declaring a record type, you must use either `record class` or `record struct` (or just `record` for a reference type). The `record` keyword alone can't appear in positions where the compiler expects a different declaration syntax.

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Constraint declaration and ordering

- **CS0401**: *The `new()` constraint must be the last restrictive constraint specified.*
- **CS0406**: *The class type constraint 'constraint' must come before any other constraints.*
- **CS0409**: *A constraint clause has already been specified for type parameter 'type parameter'. All of the constraints for a type parameter must be specified in a single where clause.*
- **CS0449**: *The `class`, `struct`, `unmanaged`, `notnull`, and `default` constraints cannot be combined or duplicated, and must be specified first in the constraints list.*
- **CS0450**: *Type Parameter: cannot specify both a constraint class and the `class` or `struct` constraint.*
- **CS0451**: *The `new()` constraint cannot be used with the `struct` constraint.*
- **CS8375**: *The 'new()' constraint cannot be used with the 'unmanaged' constraint.*
- **CS8380**: *'type': cannot specify both a constraint class and the 'unmanaged' constraint.*
- **CS9011**: *Keyword `delegate` cannot be used as a constraint. Did you mean `System.Delegate`?*

Constraints on type parameters must follow a specific order: primary constraints (`class`, `struct`, `unmanaged`, `notnull`, or `default`) come first, then a class type constraint, followed by interface constraints, and finally the `new()` constructor constraint. Some constraints are mutually exclusive and can't be combined. All constraints for a single type parameter must appear in a single `where` clause.

- Place the `new()` constraint at the end of the constraint list (**CS0401**). The `new()` constraint must appear after all other constraints. For example, change `where T : new(), IDisposable` to `where T : IDisposable, new()`.
- Place the class type constraint before interface constraints (**CS0406**). When you constrain a type parameter to a specific base class along with interfaces, the class must appear first. For example, change `where T : IDisposable, MyBaseClass` to `where T : MyBaseClass, IDisposable`.
- Combine all constraints for a type parameter into a single `where` clause (**CS0409**). You can't use multiple `where` clauses for the same type parameter. Merge them into one clause: change `where T : I where T : new()` to `where T : I, new()`. Multiple `where` clauses are only valid when they target different type parameters.
- Place primary constraints first and don't combine mutually exclusive constraints (**CS0449**). You can specify at most one of `class`, `struct`, `unmanaged`, `notnull`, or `default`, and it must appear first in the constraint list. The `class` and `struct` constraints are mutually exclusive, as are `class` and `unmanaged`.
- Don't combine a specific class constraint with `class`, `struct`, or `unmanaged` (**CS0450**, **CS8380**). If a type parameter is constrained to a specific class type, it's implicitly a reference type, which contradicts the `struct` or `unmanaged` constraint. Remove either the class constraint or the primary constraint.
- Don't combine `new()` with `struct` or `unmanaged` (**CS0451**, **CS8375**). All value types implicitly have a public parameterless constructor, so the `new()` constraint is redundant when combined with `struct`. The same applies to `unmanaged`, which implies `struct`. Remove the `new()` constraint.
- Replace `delegate` with `System.Delegate` in constraint clauses (**CS9011**). The `delegate` keyword is used for declaring delegate types, not as a constraint. To constrain a type parameter to delegate types, use `System.Delegate` as the constraint type.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Valid constraint types

- **CS0405**: *Duplicate constraint for type parameter.*
- **CS0701**: *'identifier' is not a valid constraint. A type used as a constraint must be an interface, a non-sealed class or a type parameter.*
- **CS0702**: *Constraint cannot be special class.*
- **CS0703**: *Inconsistent accessibility: constraint type is less accessible than declaration.*
- **CS0706**: *Invalid constraint type. A type used as a constraint must be an interface, a non-sealed class or a type parameter.*
- **CS0717**: *Static class: static classes cannot be used as constraints.*
- **CS3024**: *Constraint type 'type' is not CLS-compliant.*

A constraint must be an interface, a non-sealed class, or a type parameter. Certain types are invalid as constraints due to their special meaning in the .NET type system or because they can't be inherited.

- Remove duplicate constraints (**CS0405**). Each constraint can only appear once in a constraint clause. If you have `where T : I, I`, remove the duplicate.
- Use only non-sealed types as constraints (**CS0701**). Sealed classes, structs, and enums can't be inherited, so they serve no purpose as constraints. Use an interface that the desired types implement, or use a non-sealed base class.
- Don't use special classes as constraints (**CS0702**). The types <xref:System.Object>, <xref:System.Array>, and <xref:System.ValueType> can't be used as constraints. Every type already derives from `Object`, so constraining to it provides no value. `Array` and `ValueType` are abstract base types that can't be directly inherited. If you need array-like behavior, use `IList<T>` or `IEnumerable<T>` instead.
- Ensure constraint types are at least as accessible as the generic type (**CS0703**). A public generic type can't have constraints using internal types, because external code wouldn't be able to provide valid type arguments. Either make the constraint type public, or reduce the accessibility of the generic type.
- Use only interfaces, non-sealed classes, or type parameters as constraints (**CS0706**). You can't use arrays, sealed classes, structs, enums, or other invalid types as constraints. Consider using an interface that the desired types implement.
- Don't use static classes as constraints (**CS0717**). Static classes can't be extended because they only contain static members. No type can derive from a static class, making it useless as a constraint.
- Use a CLS-compliant type for the type constraint (**CS3024**). When an assembly is marked with `[assembly: CLSCompliant(true)]`, using a non-CLS-compliant type as a generic type constraint could make it impossible for code written in some languages to consume your generic class.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Constraint satisfaction and conversions

- **CS0311**: *The type cannot be used as type parameter `T` in the generic type or method. There is no implicit reference conversion from 'type1' to 'type2'.*
- **CS0312**: *The type cannot be used as type parameter in the generic type or method. The nullable type does not satisfy the constraint of 'constraint'.*
- **CS0313**: *The type cannot be used as type parameter in the generic type or method. The nullable type does not satisfy the constraint of 'constraint'. Nullable types can not satisfy any interface constraints.*
- **CS0314**: *The type cannot be used as type parameter in the generic type or method. There is no boxing conversion or type parameter conversion from 'type' to 'constraint'.*
- **CS0315**: *The type cannot be used as type parameter `T` in the generic type or method. There is no boxing conversion from 'type' to 'constraint'.*
- **CS0452**: *The type 'type name' must be a reference type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- **CS0453**: *The type 'type name' must be a non-nullable value type in order to use it as parameter 'parameter name' in the generic type or method 'generic'.*
- **CS8377**: *The type 'type' must be a non-nullable value type, along with all fields at any level of nesting, in order to use it as parameter 'parameter' in the generic type or method 'generic'.*

These errors occur when a type argument doesn't satisfy the constraints declared on a generic type parameter. The type argument must have the correct conversions, inheritance relationships, and structural properties to match all constraints.

- Change the type argument to one that has an implicit reference conversion to the constraint type (**CS0311**). When a type parameter has a constraint like `where T : BaseType`, any type argument must be convertible to `BaseType` through an implicit reference conversion or identity conversion. Implicit numeric conversions (such as from `short` to `int`) don't satisfy generic type parameter constraints.
- Use non-nullable value types or change the constraint type (**CS0312**, **CS0313**). Nullable value types (such as `int?`) are distinct from their underlying value types and don't satisfy the same constraints. Nullable value types can't satisfy interface constraints because the nullable wrapper itself doesn't implement the interface. Use the non-nullable form of the value type as the type argument.
- Repeat the base class's type parameter constraints in any derived class declaration (**CS0314**). When a derived generic class inherits from a constrained base generic class, the derived class must declare the same constraints on its corresponding type parameters.
- Ensure type arguments satisfy reference type or class constraints (**CS0315**). When a type parameter is constrained to a class type, you can't use a value type (struct) as the type argument because there's no boxing conversion that satisfies the constraint relationship. Use a reference type that inherits from or implements the constraint.
- Use a reference type as the type argument when the `class` constraint is specified (**CS0452**). Value types such as `struct` or `int` can't satisfy a `class` constraint. Either change the type argument to a reference type, or remove the `class` constraint if the generic type can work with value types.
- Use a non-nullable value type as the type argument when the `struct` constraint is specified (**CS0453**). Reference types, nullable value types (`int?`), and other non-value types can't satisfy a `struct` constraint. Use a concrete, non-nullable value type such as `int`, `double`, or a user-defined `struct`.
- Use a type whose fields are all unmanaged types when the `unmanaged` constraint is specified (**CS8377**). The `unmanaged` constraint requires a non-nullable value type where every field, at every level of nesting, is also an unmanaged type. Types containing reference-type fields or generic type parameters that aren't known to be unmanaged don't satisfy this constraint.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Constraint conflicts and circular dependencies

- **CS0454**: *Circular constraint dependency involving Type Parameter 1 and Type Parameter 2.*
- **CS0455**: *Type parameter inherits conflicting constraints 'constraint1' and 'constraint2'.*
- **CS0456**: *Type parameter 'type parameter 1' has the 'struct' constraint so 'type parameter 1' cannot be used as a constraint for 'type parameter 2'.*
- **CS8379**: *Type parameter 'type parameter 1' has the 'unmanaged' constraint so 'type parameter 1' cannot be used as a constraint for 'type parameter 2'.*

Constraints can't create circular dependencies, and type parameters can't inherit conflicting constraints that are impossible to satisfy simultaneously. Value type constraints (`struct` and `unmanaged`) are implicitly sealed, so they can't be used as constraints on other type parameters.

- Remove circular constraint dependencies (**CS0454**). A type parameter can't directly or indirectly depend on itself through its constraints. For example, `where T : U where U : T` creates a circular dependency. Break the cycle by removing one of the constraints.
- Remove conflicting inherited constraints (**CS0455**). A type parameter can't be constrained to multiple unrelated classes, because C# doesn't support multiple class inheritance. Similarly, it can't be constrained to both `struct` and a class type. Restructure your type hierarchy or remove one of the conflicting constraints.
- Don't use a `struct`-constrained or `unmanaged`-constrained type parameter as a constraint for another type parameter (**CS0456**, **CS8379**). Value type constraints are implicitly sealed, so no other type can derive from them. To resolve this error, put the value type or unmanaged constraint directly on the second type parameter instead of constraining it indirectly through the first type parameter.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## Override and implementation constraint rules

- **CS8665**: *Method 'method' specifies a 'class' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is not a reference type.*
- **CS8666**: *Method 'method' specifies a 'struct' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is not a non-nullable value type.*
- **CS8822**: *Method 'method' specifies a 'default' constraint for type parameter 'type parameter', but corresponding type parameter 'type parameter' of overridden or explicitly implemented method 'method' is constrained to a reference type or a value type.*
- **CS8823**: *The 'default' constraint is valid on override and explicit interface implementation methods only.*

When you override a virtual method or explicitly implement an interface method, the constraints on the overriding method's type parameters must be compatible with the base method's constraints. The `default` constraint is a special modifier used only in override and explicit interface implementation scenarios to indicate that a type parameter has neither a `class` nor `struct` constraint.

- Ensure the overriding method's constraints match the base method's constraints (**CS8665**, **CS8666**). An override can't add a `class` constraint if the base method's corresponding type parameter isn't constrained to a reference type. Similarly, it can't add a `struct` constraint if the base method's type parameter isn't constrained to a value type. The override must be compatible with the base declaration.
- Use the `default` constraint only when the base method's type parameter is unconstrained (**CS8822**). The `default` constraint indicates that the type parameter has no `class` or `struct` constraint. You can't apply `default` if the corresponding type parameter of the overridden method already has a `class` or `struct` constraint.
- Use the `default` constraint only on override or explicit interface implementation methods (**CS8823**). The `default` constraint isn't valid on regular method declarations. It exists specifically to disambiguate when overriding a method where the base had an unconstrained type parameter, and you need to indicate that the override also leaves it unconstrained.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and the [`default` constraint](../keywords/where-generic-type-constraint.md).

## Constructor constraints

- **CS0304**: *Cannot create an instance of the variable type because it does not have the `new()` constraint.*
- **CS0310**: *The type must be a non-abstract type with a public parameterless constructor in order to use it as parameter in the generic type or method.*
- **CS0417**: *Identifier: cannot provide arguments when creating an instance of a variable type.*

These errors relate to the `new()` constraint and instantiating type parameters with the `new` operator.

- Add the `new()` constraint to type parameters that you need to instantiate (**CS0304**). When you use `new T()` inside a generic type or method, the compiler must guarantee that any type argument has a parameterless constructor. The `new()` constraint provides this guarantee.
- Ensure type arguments have public parameterless constructors (**CS0310**). When a type parameter has the `new()` constraint, any concrete type used as a type argument must be non-abstract and must provide a public parameterless constructor. Types with only private, protected, or parameterized constructors can't satisfy the `new()` constraint.
- Remove constructor arguments when instantiating type parameters (**CS0417**). The `new()` constraint only guarantees a parameterless constructor. You can't pass arguments to `new T(arguments)`. If you need to construct instances with specific arguments, consider using a factory pattern or an interface constraint that defines the construction behavior.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and the [`new()` constraint](../keywords/new-constraint.md).

## Type argument count and usage

- **CS0224**: *A method with vararg cannot be generic, be in a generic type, or have a params parameter.*
- **CS0305**: *Using the generic type requires N type arguments.*
- **CS0306**: *The type may not be used as a type argument.*
- **CS0307**: *The 'identifier' cannot be used with type arguments.*
- **CS0308**: *The non-generic type-or-method cannot be used with type arguments.*
- **CS7002**: *Unexpected use of a generic name.*
- **CS8389**: *Omitting the type argument is not allowed in the current context.*

These errors relate to providing the correct number and type of arguments to generic types and methods.

- Remove generic type parameters or containing generic type declarations from methods that use `__arglist` (**CS0224**). The `__arglist` keyword is incompatible with generics because the runtime mechanisms for handling variable argument lists conflict with the type substitution required for generic type parameters.
- Supply the exact number of type arguments specified in the generic declaration (**CS0305**). Each generic type parameter in the definition must have a corresponding type argument when the generic type is instantiated.
- Use only valid types as type arguments (**CS0306**). Pointer types (such as `int*` or `char*`) can't be used as type arguments because generic types require managed types that the garbage collector can track.
- Remove type argument syntax from non-generic constructs (**CS0307**, **CS0308**). Type arguments enclosed in angle brackets can only be applied to generic types and methods that declare type parameters. Ensure you imported the namespace that contains the generic version of the type.
- Remove type parameters from declarations that don't support generics (**CS7002**). Some constructs, such as enums, can't be generic. If you need a generic container for enum values, consider using a generic class or struct instead.
- Provide all required type arguments explicitly (**CS8389**). In some contexts, such as using the `typeof` operator or creating delegates, you must provide all type arguments and can't omit them. For example, use `typeof(List<int>)` rather than attempting to omit the type argument.

For more information, see [Generic Type Parameters](../../programming-guide/generics/generic-type-parameters.md) and [Generics](../../fundamentals/types/generics.md).

## Type argument inference

- **CS0411**: *The type arguments for method 'method' cannot be inferred from the usage. Try specifying the type arguments explicitly.*

This error occurs when you call a generic method without explicitly providing the type arguments and the compiler can't infer which type arguments you intend. The compiler infers type arguments from the types of the method arguments you pass at the call site.

- Specify the type arguments explicitly in angle brackets (**CS0411**). If the compiler can't determine the type arguments from the method arguments, provide them directly. For example, change `G()` to `G<int>()`. This error commonly occurs when a generic method has no parameters from which to infer the type, or when a `null` argument is passed and the compiler can't determine the intended type.

For more information, see [Generic Methods](../../programming-guide/generics/generic-methods.md).

## Type parameter variance

- **CS1960**: *Invalid variance modifier. Only interface and delegate type parameters can be specified as variant.*
- **CS1961**: *Invalid variance: The type parameter must be covariantly valid on 'type'. 'type parameter' is contravariant.*
- **CS8427**: *Enums, classes, and structures cannot be declared in an interface that has an 'in' or 'out' type parameter.*

Variance modifiers (`in` for contravariance, `out` for covariance) control how you can use type parameters in interface and delegate declarations. Only interfaces and delegates support variance. A covariant (`out`) type parameter can only appear in output positions (return types), while a contravariant (`in`) type parameter can only appear in input positions (parameter types).

- Use variance modifiers only on interface and delegate type parameters (**CS1960**). Classes, structs, and other type declarations don't support variance modifiers. Only `interface` and `delegate` declarations can use `in` or `out` on their type parameters.
- Use `out` (covariant) for type parameters that only appear in return types, and `in` (contravariant) for type parameters that only appear in parameter types (**CS1961**). If the type parameter must appear in both input and output positions, remove the variance modifier.
- Don't declare enums, classes, or structures inside a variant interface (**CS8427**). Nested type declarations inside an interface that has `in` or `out` type parameters aren't allowed because they could violate the variance safety rules. Move the nested type outside the interface declaration.

For more information, see [Covariance and Contravariance in Generics](../../../standard/generics/covariance-and-contravariance.md).

## Generic type usage restrictions

- **CS0403**: *Cannot convert null to type parameter because it could be a non-nullable value type. Consider using `default(T)` instead.*
- **CS0413**: *The type parameter cannot be used with the `as` operator because it does not have a class type constraint nor a `class` constraint.*
- **CS0695**: *'type' cannot implement both 'interface1' and 'interface2' because they may unify for some type parameter substitutions.*
- **CS0698**: *A generic type cannot derive from type because it is an attribute class.*
- **CS0704**: *Cannot do non-virtual member lookup in 'type' because it is a type parameter.*
- **CS0718**: *'type': static types cannot be used as type arguments.*
- **CS1720**: *Expression will always cause a System.NullReferenceException because the default value of 'generic type' is null.*
- **CS1763**: *'parameter' is of type 'type'. A default parameter value of a reference type other than string can only be initialized with null.*
- **CS8322**: *Cannot pass argument with dynamic type to generic local function with inferred type arguments.*
- **CS9338**: *Inconsistent accessibility: type is less accessible than class.*

These errors relate to restrictions on how generic types and type parameters can be used in expressions, inheritance, and member access.

- Replace `null` assignments with `default(T)` or add a `class` constraint (**CS0403**). When you assign `null` to an unconstrained type parameter, the compiler can't guarantee the type argument is a reference type. Use `default(T)`, which provides the appropriate default value for any type, or add a `class` constraint if you specifically need reference type semantics.
- Add a `class` or specific type constraint when using the `as` operator (**CS0413**). The `as` operator returns `null` if the conversion fails, but value types can't be `null`. Add a `class` constraint to ensure the type parameter is always a reference type.
- Avoid implementing the same generic interface multiple times with type parameters that could unify (**CS0695**). When a class implements a generic interface multiple times with different type parameters (such as `class G<T1, T2> : I<T1>, I<T2>`), instantiating with the same type for both parameters would create a conflict. Implement the interface only once, or restructure to prevent unification.
- Remove generic type parameters from attribute classes (**CS0698**). This error is no longer produced in current versions of C#, as generic attributes are now supported.
- Use the concrete constraint type instead of the type parameter for nested member access (**CS0704**). You can't access nested types or non-virtual members through a type parameter. Instead of `T.InnerType`, use the known constraint type directly, such as `BaseClass.InnerType`.
- Don't use static types as type arguments (**CS0718**). Static types can't be instantiated and can't be used as generic arguments. Remove the static type from the generic argument.
- Avoid calling instance members on `default(T)` when `T` is constrained to a reference type (**CS1720**). When `T` has a `class` constraint, `default(T)` is `null`, so calling instance members on it always throws a <xref:System.NullReferenceException>. Add a null check before calling members, or restructure the code to avoid using `default(T)` directly.
- Use `null` as the default parameter value for optional parameters whose type is a reference type (**CS1763**). If a generic method has a parameter of type `T` and `T` is a reference type, replace `default(U)` with `null` because optional parameter defaults must be compile-time constants, and `default(T)` doesn't fix that requirement.
- Explicitly specify type arguments when passing dynamic values to generic local functions (**CS8322**). When you pass a `dynamic` argument to a generic local function, the compiler can't infer type arguments. Explicitly specify the type argument or cast the dynamic value.
- Ensure type arguments used in public or protected signatures are at least as accessible as the member (**CS9338**). A public generic member must use type arguments that are publicly accessible. Either make the type argument public, or reduce the accessibility of the member.

For more information, see [Constraints on type parameters](../../programming-guide/generics/constraints-on-type-parameters.md) and [default value expressions](../operators/default.md).

## `UnmanagedCallersOnly` restrictions

- **CS8893**: *'type' is not a valid calling convention type for 'UnmanagedCallersOnly'.*
- **CS8894**: *Cannot use 'type' as a parameter or return type on a method attributed with 'UnmanagedCallersOnly'.*
- **CS8895**: *Methods attributed with 'UnmanagedCallersOnly' cannot have generic type parameters and cannot be declared in a generic type.*
- **CS8896**: *'UnmanagedCallersOnly' can only be applied to ordinary static non-abstract, non-virtual methods or static local functions.*

The <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute> attribute marks methods that unmanaged code can call. These methods have strict requirements because the runtime must handle the transition between managed and unmanaged calling conventions.

- Use only valid calling convention types in the `UnmanagedCallersOnly` attribute (**CS8893**). The `CallConvs` property of the attribute accepts only recognized calling convention types from the `System.Runtime.CompilerServices` namespace.
- Use only [blittable types](/dotnet/standard/native-interop/blittable-and-non-blittable-types) as parameter and return types (**CS8894**). Methods marked with `UnmanagedCallersOnly` can't use managed types (such as `string` or `object`) as parameter or return types because unmanaged callers can't manage the garbage-collected references.
- Remove generic type parameters from `UnmanagedCallersOnly` methods and don't declare them in generic types (**CS8895**). Unmanaged calling conventions don't support generics because the runtime can't determine the correct calling convention for generic type substitutions.
- Apply `UnmanagedCallersOnly` only to ordinary static, non-abstract, non-virtual methods or static local functions (**CS8896**). Instance methods, abstract methods, and virtual methods can't be marked with `UnmanagedCallersOnly` because unmanaged callers can't perform the dispatch mechanisms these methods require.

For more information, see <xref:System.Runtime.InteropServices.UnmanagedCallersOnlyAttribute>.
