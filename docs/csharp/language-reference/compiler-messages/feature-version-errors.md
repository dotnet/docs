---
title: Resolve errors related to language version and features
description: Several compiler errors indicate that your configured language version doesn't support a feature you're using. This article shows how to fix those errors and warnings.
f1_keywords:
  - "CS8904" # ERR_UnexpectedVarianceStaticMember  Invalid variance: The type parameter '{1}' must be {3} valid on '{0}' unless language version '{4}' or greater is used. '{1}' is {2}.
  - "CS1738" # ERR_NamedArgumentSpecificationBeforeFixedArgument  Named argument specifications must appear after all fixed arguments have been specified. Please use language version {0} or greater to allow non-trailing named arguments
  - "CS8022" # ERR_FeatureNotAvailableInVersion1  Feature is not available in C# 1. Please use language version.
  - "CS8023" # ERR_FeatureNotAvailableInVersion2  Feature is not available in C# 2. Please use language version.
  - "CS8024" # ERR_FeatureNotAvailableInVersion3  Feature is not available in C# 3. Please use language version.
  - "CS8025" # ERR_FeatureNotAvailableInVersion4  Feature is not available in C# 4. Please use language version.
  - "CS8026" # ERR_FeatureNotAvailableInVersion5  Feature is not available in C# 5. Please use language version.
  - "CS8059" # ERR_FeatureNotAvailableInVersion6  Feature is not available in C# 6. Please use language version.
  - "CS8107" # ERR_FeatureNotAvailableInVersion7  Feature is not available in C# 7. Please use language version.
  - "CS8302" # ERR_FeatureNotAvailableInVersion7_1  Feature is not available in C# 7.1. Please use language version.
  - "CS8320" # ERR_FeatureNotAvailableInVersion7_2  Feature is not available in C# 7.2. Please use language version.
  - "CS8370" # ERR_FeatureNotAvailableInVersion7_3  Feature is not available in C# 7.3. Please use language version.
  - "CS8400" # ERR_FeatureNotAvailableInVersion8  Feature is not available in C# 8. Please use language version.
  - "CS8773" # ERR_FeatureNotAvailableInVersion9  Feature is not available in C# 9. Please use language version.
  - "CS8936" # ERR_FeatureNotAvailableInVersion10  Feature is not available in C# 10. Please use language version.
  - "CS9058" # ERR_FeatureNotAvailableInVersion11  Feature is not available in C# 11. Please use language version.
  - "CS8303" # ERR_LanguageVersionCannotHaveLeadingZeroes  Specified language version cannot have leading zeroes
  - "CS8304" # ERR_CompilerAndLanguageVersion  Compiler version is lower than Language version
  - "CS8306" # ERR_TupleInferredNamesNotAvailable Tuple element name '{0}' is inferred. Please use language version {1} or greater to access an element by its inferred name.
  - "CS8371" # WRN_AttributesOnBackingFieldsNotAvailable  Field-targeted attributes on auto-properties are not supported in language version
  - "CS8401" # ERR_AltInterpolatedVerbatimStringsNotAvailable  To use '@$' instead of '$@' for an interpolated verbatim string, please use language version '{0}' or greater.
  - "CS8511" # ERR_ConstantPatternVsOpenType  An expression of type '{0}' cannot be handled by a pattern of type '{1}'
  - "CS8192" # ERR_BadLanguageVersion   Provided language version is unsupported or invalid
  - "CS8627" # ERR_NullableUnconstrainedTypeParameter  A nullable type parameter must be known to be a value type or non-nullable reference type
  - "CS8630" # ERR_NullableOptionNotAvailable  Invalid '{0}' value: '{1}' for C# {2}. Please use language version '{3}' or greater
  - "CS8314" # ERR_PatternWrongGenericTypeInVersion  An expression of type '{0}' cannot be handled by a pattern of type
  - "CS8652" # ERR_FeatureInPreview  The feature '{0}' is currently in Preview and *unsupported*. To use Preview features, use the 'preview' language version
  - "CS8703" # ERR_InvalidModifierForLanguageVersion  The modifier '{0}' is not valid for this item in C# {1}. Please use language version '{2}' or greater.
  - "CS8704" # ERR_ImplicitImplementationOfNonPublicInterfaceMember  Type does not implement interface member. Type cannot implicitly implement a non-public member in selected version.
  - "CS8706" # ERR_LanguageVersionDoesNotSupportInterfaceImplementationForMember  Type cannot implement interface member '{1}' in type '{2}' because feature '{3}' is not available in 
  - "CS8957" # ERR_NoImplicitConvTargetTypedConditional  Conditional expression is not valid in language version {0} because a common type was not found between '{1}' and '{2}'
  - "CS8912" # ERR_InheritingFromRecordWithSealedToString  Inheriting from a record with a sealed 'Object.ToString' is not supported
  - "CS9014" # ERR_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9015" # ERR_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS9016" # WRN_UseDefViolationPropertyUnsupportedVersion  Use of possibly unassigned property
  - "CS9017" # WRN_UseDefViolationFieldUnsupportedVersion  Use of possibly unassigned field
  - "CS8967" # ERR_NewlinesAreNotAllowedInsideANonVerbatimInterpolatedString  Newlines inside a non-verbatim interpolated string are not supported in C#
helpviewer_keywords:
  - "CS8904"
  - "CS1738"
  - "CS8022"
  - "CS8023"
  - "CS8024"
  - "CS8025"
  - "CS8026"
  - "CS8059"
  - "CS8107"
  - "CS8302"
  - "CS8320"
  - "CS8370"
  - "CS8400"
  - "CS8773"
  - "CS8936"
  - "CS9058"
  - "CS8303"
  - "CS8304"
  - "CS8306"
  - "CS8371"
  - "CS8401"
  - "CS8511"
  - "CS8192"
  - "CS8627"
  - "CS8630"
  - "CS8314"
  - "CS8652"
  - "CS8703"
  - "CS8704"
  - "CS8706"
  - "CS8957"
  - "CS8912"
  - "CS9014"
  - "CS9015"
  - "CS9016"
  - "CS9017"
  - "CS8967"
ms.date: 11/22/2022
---
# Resolve warnings related to language features and versions

Draft 2:
- CS0171 (changed behavior), now its CS8881
- CS0188 (changed behavior), now 8885
- CS0843 -> now 8880

This article covers the following compiler warnings:

- [**CS8904**](#update-your-version) - *Invalid variance: The type parameter must be valid.*
- [**CS1738**](#update-your-version) - *Named argument specifications must appear after all fixed arguments have been specified.*
- [**CS8022**](#update-your-version) - *Feature is not available in C# 1. Please use language version.*
- [**CS8023**](#update-your-version) - *Feature is not available in C# 2. Please use language version.*
- [**CS8024**](#update-your-version) - *Feature is not available in C# 3. Please use language version.*
- [**CS8025**](#update-your-version) - *Feature is not available in C# 4. Please use language version.*
- [**CS8026**](#update-your-version) - *Feature is not available in C# 5. Please use language version.*
- [**CS8059**](#update-your-version) - *Feature is not available in C# 6. Please use language version.*
- [**CS8107**](#update-your-version) - *Feature is not available in C# 7. Please use language version.*
- [**CS8302**](#update-your-version) - *Feature is not available in C# 7.1. Please use language version.*
- [**CS8320**](#update-your-version) - *Feature is not available in C# 7.2. Please use language version.*
- [**CS8370**](#update-your-version) - *Feature is not available in C# 7.3. Please use language version.*
- [**CS8400**](#update-your-version) - *Feature is not available in C# 8. Please use language version.*
- [**CS8773**](#update-your-version) - *Feature is not available in C# 9. Please use language version.*
- [**CS8936**](#update-your-version) - *Feature is not available in C# 10. Please use language version.*
- [**CS9058**](#update-your-version) - *Feature is not available in C# 11. Please use language version.*
- [**CS8303**](#update-your-version) - *Specified language version cannot have leading zeroes*
- [**CS8304**](#update-your-version) - *Compiler version is less than language version*
- [**CS8306**](#update-your-version) - *Tuple element name '{0}' is inferred. Please use language version {1} or greater to access an element by its inferred name.*
- [**CS8371**](#update-your-version) - *Field-targeted attributes on auto-properties are not supported in language version*
- [**CS8401**](#update-your-version) - *To use `@$` instead of `$@` for an interpolated verbatim string, please use language version '{0}' or greater.*
- [**CS8511**](#update-your-version) - *An expression of type cannot be handled by a pattern of type.*
- [**CS8192**](#update-your-version) - *Provided language version is unsupported or invalid*
- [**CS8627**](#update-your-version) - *A nullable type parameter must be known to be a value type or non-nullable reference type*
- [**CS8630**](#update-your-version) - *Invalid '{0}' value: '{1}' for C# {2}. Please use language version '{3}' or greater*
- [**CS8314**](#update-your-version) - *An expression of type '{0}' cannot be handled by a pattern of type*
- [**CS8652**](#update-your-version) - *The modifier is not valid for this item.*
- [**CS8704**](#update-your-version) - *Type does not implement interface member. It cannot implicitly implement a non-public member.*
- [**CS8706**](#update-your-version) - *Type cannot implement interface member because a feature is not available in this version.*
- [**CS8957**](#update-your-version) - *Conditional expression is not valid in language version because a common type was not found between types.*
- [**CS8912**](#update-your-version) - *Inheriting from a record with a sealed 'Object.ToString' is not supported.*
- [**CS9014**](#update-your-version) - *Error: Use of possibly unassigned property. Upgrade to auto-default the property.*
- [**CS9015**](#update-your-version) - *Error: Use of possibly unassigned field. Upgrade to auto-default the field.*
- [**CS9016**](#update-your-version) - *Warning: Use of possibly unassigned property. Upgrade to auto-default the property.*
- [**CS9017**](#update-your-version) - *Warning: Use of possibly unassigned field. Upgrade to auto-default the field.*
- [**CS8967**](#update-your-version) - *Newlines inside a non-verbatim interpolated string are not supported in C#*

The purpose of nullable warnings is to minimize the chance that your application throws a <xref:System.NullReferenceException?displayProperty=nameWithType> when run. To achieve this goal, the compiler uses static analysis and issues warnings when your code has constructs that may lead to null reference exceptions. You provide the compiler with information for its static analysis by applying type annotations and attributes. These annotations and attributes describe the nullability of arguments, parameters, and members of your types. In this article, you'll learn different techniques to address the nullable warnings the compiler generates from its static analysis. The techniques described here are for general C# code. Learn to work with nullable reference types and Entity Framework core in [Working with nullable reference types](/ef/core/miscellaneous/nullable-reference-types).

You'll address almost all warnings using one of four techniques:

- Adding necessary null checks.
- Adding `?` or `!` nullable annotations.
- Adding attributes that describe null semantics.
- Initializing variables correctly.

## Possible dereference of null

This set of warnings alerts you that you're dereferencing a variable whose *null-state* is *maybe-null*. These warnings are:

- **CS8602** - *Dereference of a possibly null reference.*
- **CS8670** - *Object or collection initializer implicitly dereferences possibly null member.*

The following code demonstrates one example of each of the preceding warnings:

:::code language="csharp" source="snippets/null-warnings/NullWarnings.cs" id="PossibleNullDereference":::

In the example above, the warning is because the `Container`, `c`, may have a null value for the `States` property. Assigning new states to a collection that might be null causes the warning.

To remove these warnings, you need to add code to change that variable's *null-state* to *not-null* before dereferencing it. The collection initializer warning may be harder to spot. The compiler detects that the collection *maybe-null* when the initializer adds elements to it.

In many instances, you can fix these warnings by checking that a variable isn't null before dereferencing it. For example, the above example could be rewritten as:

:::code language="csharp" source="snippets/null-warnings/Program.cs" id="ProvideNullCheck":::

Other instances when you get these warnings may be false positive. You may have a private utility method that tests for null. The compiler doesn't know that the method provides a null check. Consider the following example that uses a private utility method, `IsNotNull`:

:::code language="csharp" source="./snippets/null-warnings/NullTests.cs" id="PrivateNullTest":::

The compiler warns that you may be dereferencing null when you write the property `message.Length` because its static analysis determines that `message` may be `null`. You may know that `IsNotNull` provides a null check, and when it returns `true`, the *null-state* of `message` should be *not-null*. You must tell the compiler those facts. One way is to use the null forgiving operator, `!`. You can change the `WriteLine` statement to match the following code:

```csharp
Console.WriteLine(message!.Length);
```

The null forgiving operator makes the expression *not-null* even if it was *maybe-null* without the `!` applied. In this example, a better solution is to add an attribute to the signature of `IsNotNull`:

:::code language="csharp" source="./snippets/null-warnings/NullTests.cs" id="AnnotatedNullCheck":::

The <xref:System.Diagnostics.CodeAnalysis.NotNullWhenAttribute?displayProperty=nameWithType> informs the compiler that the argument used for the `obj` parameter is *not-null* when the method returns `true`. When the method returns `false`, the argument has the same *null-state* it had before the method was called.

> [!TIP]
> There's a rich set of attributes you can use to describe how your methods and properties affect *null-state*. You can learn about them in the language reference article on [Nullable static analysis attributes](../attributes/nullable-analysis.md).

Fixing a warning for dereferencing a *maybe-null* variable involves one of three techniques:

- Add a missing null check.
- Add null analysis attributes on APIs to affect the compiler's *null-state* static analysis. These attributes inform the compiler when a return value or argument should be *maybe-null* or *not-null* after calling the method.
- Apply the null forgiving operator `!` to the expression to force the state to *not-null*.

## Possible null assigned to a nonnullable reference

This set of warnings alerts you that you're assigning a variable whose type is nonnullable to an expression whose *null-state* is *maybe-null*. These warnings are:

- **CS8601** - *Possible null reference assignment.*
- **CS8605** - *Unboxing a possibly null value.*
- **CS8603** - *Possible null reference return.*
- **CS8604** - *Possible null reference argument for parameter.*
- **CS8600** - *Converting null literal or possible null value to non-nullable type.*
- **CS8597** - *Thrown value may be null.*
- **CS8625** - *Cannot convert null literal to non-nullable reference type.*
- **CS8629** - *Nullable value type may be null.*

The compiler emits these warnings when you attempt to assign an expression that is *maybe-null* to a variable that is nonnullable. For example:

:::code language="csharp" source="./snippets/null-warnings/Program.cs" id="PossibleNullAssignment":::

The different warnings indicate provide details about the code, such as assignment, unboxing assignment, return statements, arguments to methods, and throw expressions.

You can take one of three actions to address these warnings. One is to add the `?` annotation to make the variable a nullable reference type. That change may cause other warnings. Changing a variable from a non-nullable reference to a nullable reference changes its default *null-state* from *not-null* to *maybe-null*. The compiler's static analysis may find instances where you dereference a variable that is *maybe-null*.

The other actions instruct the compiler that the right-hand-side of the assignment is *not-null*. The expression on the right-hand-side could be null-checked before assignment, as shown in the following example:

:::code language="csharp" source="./snippets/null-warnings/Program.cs" id="NullGuard":::

The previous examples demonstrate assignment of the return value of a method. You may annotate the method (or property) to indicate when a method returns a not-null value. The <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute?displayProperty=nameWithType> often specifies that a return value is *not-null* when an input argument is *not-null*. Another alternative is to add the null forgiving operator, `!` to the right-hand side:

```csharp
string msg = TryGetMessage(42)!;
```

Fixing a warning for assigning a *maybe-null* expression to a *not-null* variable involves one of four techniques:

- Change the left side of the assignment to a nullable type. This action may introduce new warnings when you dereference that variable.
- Provide a null-check before the assignment.
- Annotate the API that produces the right-hand side of the assignment.
- Add the null forgiving operator to the right-hand side of the assignment.

## Nonnullable reference not initialized

This set of warnings alerts you that you're assigning a variable whose type is non-nullable to an expression whose *null-state* is *maybe-null*. These warnings are:

- **CS8618** - *Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable.*
- **CS8762** - *Parameter  must have a non-null value when exiting.*

Consider the following class as an example:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="PersonExample":::

Neither `FirstName` nor `LastName` are guaranteed initialized. If this code is new, consider changing the public interface. The above example could be updated as follows:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="WithConstructor":::

If you require creating a `Person` object before setting the name, you can initialize the properties using a default non-null value:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="Initializer":::

Another alternative may be to change those members to nullable reference types. The `Person` class could be defined as follows if `null` should be allowed for the name:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="NullableMember":::

Existing code may require other changes to inform the compiler about the null semantics for those members. You may have created multiple constructors, and your class may have a private helper method that initializes one or more members. You can move the initialization code into a single constructor and ensure all constructors call the one with the common initialization code. Or, you can use the <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute?displayProperty=nameWithType> and <xref:System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute?displayProperty=nameWithType> attributes. These attributes inform the compiler that a member is *not-null* after the method has been called. The following code shows an example of each. The `Person` class uses a common constructor called by all other constructors. The `Student` class has a helper method annotated with the <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute?displayProperty=nameWithType> attribute:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="ConstructorChainingAndMemberNotNull":::

Finally, you can use the null forgiving operator to indicate that a member is initialized in other code. For another example, consider the following classes representing an Entity Framework Core model:

:::code language="csharp" source="./snippets/null-warnings/Context.cs" id="ExampleModel":::

The `DbSet` property is initialized to `null!`. That tells the compiler that the property is set to a *not-null* value. In fact, the base `DbContext` performs the initialization of the set. The compiler's static analysis doesn't pick that up. For more information on working with nullable reference types and Entity Framework Core, see the article on [Working with Nullable Reference Types in EF Core](/ef/core/miscellaneous/nullable-reference-types).

Fixing a warning for not initializing a nonnullable member involves one of four techniques:

- Change the constructors or field initializers to ensure all nonnullable members are initialized.
- Change one or more members to be nullable types.
- Annotate any helper methods to indicate which members are assigned.
- Add an initializer to `null!` to indicate that the member is initialized in other code.

## Mismatch in nullability declaration

Many warnings indicate nullability mismatches between signatures for methods, delegates, or type parameters.

- **CS8619** - *Nullability of reference types in value doesn't match target type.*
- **CS8621** - *Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).*
- **CS8622** - *Nullability of reference types in type of parameter doesn't match the target delegate (possibly because of nullability attributes).*
- **CS8631** - *The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match constraint type.*
- **CS8634** - *The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'class' constraint.*
- **CS8714** - *The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.*
- **CS8608** - *Nullability of reference types in type doesn't match overridden member.*
- **CS8609** - *Nullability of reference types in return type doesn't match overridden member.*
- **CS8819** - *Nullability of reference types in return type doesn't match partial method declaration.*
- **CS8610** - *Nullability of reference types in type parameter doesn't match overridden member.*
- **CS8611** - *Nullability of reference types in type parameter doesn't match partial method declaration.*
- **CS8612** - *Nullability of reference types in type doesn't match implicitly implemented member.*
- **CS8613** - *Nullability of reference types in return type doesn't match implicitly implemented member.*
- **CS8614** - *Nullability of reference types in type of parameter doesn't match implicitly implemented member.*
- **CS8615** - *Nullability of reference types in type doesn't match implemented member.*
- **CS8616** - *Nullability of reference types in return type doesn't match implemented member.*
- **CS8617** - *Nullability of reference types in type of parameter doesn't match implemented member.*
- **CS8633** - *Nullability in constraints for type parameter of method doesn't match the constraints for type parameter of interface method. Consider using an explicit interface implementation instead.*
- **CS8643** - *Nullability of reference types in explicit interface specifier doesn't match interface implemented by the type.*
- **CS8644** - *Type does not implement interface member. Nullability of reference types in interface implemented by the base type doesn't match.*
- **CS8620** - *Argument cannot be used for parameter due to differences in the nullability of reference types.*
- **CS8624** - *Argument cannot be used as an output due to differences in the nullability of reference types.*
- **CS8645** - *Member is already listed in the interface list on type with different nullability of reference types.*
- **CS8667** - *Partial method declarations have inconsistent nullability in constraints for type parameter.*
- **CS8764** - *Nullability of return type doesn't match overridden member (possibly because of nullability attributes).*
- **CS8765** - *Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes).*
- **CS8768** - *Nullability of reference types in return type doesn't match implemented member (possibly because of nullability attributes).*
- **CS8767** - *Nullability of reference types in type of parameter of doesn't match implicitly implemented member (possibly because of nullability attributes).*
- **CS8766** - *Nullability of reference types in return type of doesn't match implicitly implemented member (possibly because of nullability attributes).*
- **CS8769** - *Nullability of reference types in type of parameter doesn't match implemented member (possibly because of nullability attributes).*

The following code demonstrates *CS8764*:

:::code language="csharp" source="snippets/null-warnings/Hierarchy.cs" id="Hierarchy":::

The preceding example shows a `virtual` method in a base class and an `override` with different nullability. The base class returns a non-nullable string, but the derived class returns a nullable string. If the `string` and `string?` are reversed, it would be allowed because the derived class is more restrictive. Similarly, parameter declarations should match. Parameters in the override method can allow null even when the base class doesn't.

Other situations can generate these warnings. You may have a mismatch in an interface method declaration and the implementation of that method. Or a delegate type and the expression for that delegate may differ. A type parameter and the type argument may differ in nullability.

To fix these warnings, update the appropriate declaration.

## Code doesn't match attribute declaration

The preceding sections have discussed how you can use [Attributes for nullable static analysis](../attributes/nullable-analysis.md) to inform the compiler about the null semantics of your code. The compiler warns you if the code doesn't adhere to the promises of that attribute:

- **CS8607** - *A possible null value may not be used for a type marked with `[NotNull]` or `[DisallowNull]`*
- **CS8763** - *A method marked `[DoesNotReturn]` should not return.*
- **CS8770** - *Method lacks `[DoesNotReturn]` annotation to match implemented or overridden member.*
- **CS8774** - *Member must have a non-null value when exiting.*
- **CS8776** - *Member cannot be used in this attribute.*
- **CS8775** - *Member must have a non-null value when exiting.*
- **CS8777** - *Parameter must have a non-null value when exiting.*
- **CS8824** - *Parameter must have a non-null value when exiting because parameter is non-null.*
- **CS8825** - *Return value must be non-null because parameter is non-null.*

Consider the following method:

:::code language="csharp" source="snippets/null-warnings/NullTests.cs" id="ViolateAttribute":::

The compiler produces a warning because the `message` parameter is assigned `null` *and* the method returns `true`. The `NotNullWhen` attribute indicates that shouldn't happen.

To address these warnings, update your code so it matches the expectations of the attributes you've applied. You may change the attributes, or the algorithm.

## Exhaustive switch expression

Switch expressions must be *exhaustive*, meaning that all input values must be handled. Even for non-nullable reference types, the `null` value must be accounted for. The compiler issues warnings when the null value isn't handled:

- **CS8655** - *The switch expression does not handle some null inputs (it is not exhaustive).*
- **CS8847** - *The switch expression does not handle some null inputs (it is not exhaustive). However, a pattern with a 'when' clause might successfully match this value.*

The following example code demonstrates this condition:

:::code language="csharp" source="snippets/null-warnings/NullWarnings.cs" id="NullExhaustiveSwitch":::

The input expression is a `string`, not a `string?`. The compiler still generates this warning. The `{ }` pattern handles all non-null values, but doesn't match `null`. To address these errors, you can either add an explicit `null` case, or replace the `{ }` with the `_` (discard) pattern. The discard pattern matches null as well as any other value.
