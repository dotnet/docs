---
title: Resolve nullable warnings
description: Several compiler warnings indicate code that isn't null-safe. Learn how to address those warnings by making your code more resilient.
f1_keywords:
  - "CS8597" # WRN_ThrowPossibleNull: Thrown value may be null.
  - "CS8600" # WRN_ConvertingNullableToNonNullable: Converting null literal or possible null value to non-nullable type.
  - "CS8601" # WRN_NullReferenceAssignment: Possible null reference assignment.
  - "CS8602" # WRN_NullReferenceReceiver: Dereference of a possibly null reference.
  - "CS8603" # WRN_NullReferenceReturn: Possible null reference return.
  - "CS8604" # WRN_NullReferenceArgument: Possible null reference argument for parameter '{0}' in '{1}'
  - "CS8605" # WRN_UnboxPossibleNull: Unboxing a possibly null value.
  - "CS8607" # WRN_DisallowNullAttributeForbidsMaybeNullAssignment: A possible null value may not be used for a type marked with [NotNull] or [DisallowNull]
  - "CS8608" # WRN_NullabilityMismatchInTypeOnOverride: Nullability of reference types in type doesn't match overridden member.
  - "CS8609" # WRN_NullabilityMismatchInReturnTypeOnOverride: Nullability of reference types in return type doesn't match overridden member.
  - "CS8819" # WRN_NullabilityMismatchInReturnTypeOnPartial: Nullability of reference types in return type doesn't match partial method declaration.
  - "CS8610" # WRN_NullabilityMismatchInParameterTypeOnOverride: Nullability of reference types in type of parameter '{0}' doesn't match overridden member.
  - "CS8611" # WRN_NullabilityMismatchInParameterTypeOnPartial: Nullability of reference types in type of parameter '{0}' doesn't match partial method declaration.
  - "CS8612" # WRN_NullabilityMismatchInTypeOnImplicitImplementation: Nullability of reference types in type of '{0}' doesn't match implicitly implemented member '{1}'.
  - "CS8613" # WRN_NullabilityMismatchInReturnTypeOnImplicitImplementation: Nullability of reference types in return type of '{0}' doesn't match implicitly implemented member '{1}'.
  - "CS8614" # WRN_NullabilityMismatchInParameterTypeOnImplicitImplementation: Nullability of reference types in type of parameter '{0}' of '{1}' doesn't match implicitly implemented member '{2}'.
  - "CS8615" # WRN_NullabilityMismatchInTypeOnExplicitImplementation: Nullability of reference types in type doesn't match implemented member '{0}'.
  - "CS8616" # WRN_NullabilityMismatchInReturnTypeOnExplicitImplementation: Nullability of reference types in return type doesn't match implemented member '{0}'.
  - "CS8617" # WRN_NullabilityMismatchInParameterTypeOnExplicitImplementation: Nullability of reference types in type of parameter '{0}' doesn't match implemented member '{1}'.
  - "CS8618" # WRN_UninitializedNonNullableField: Non-nullable {0} '{1}' must contain a non-null value when exiting constructor. Consider declaring the {0} as nullable.
  - "CS8619" # WRN_NullabilityMismatchInAssignment: Nullability of reference types in value of type '{0}' doesn't match target type '{1}'.
  - "CS8620" # WRN_NullabilityMismatchInArgument: Argument of type '{0}' cannot be used for parameter '{2}' of type '{1}' in '{3}' due to differences in the nullability of reference types.
  - "CS8621" # WRN_NullabilityMismatchInReturnTypeOfTargetDelegate: Nullability of reference types in return type of '{0}' doesn't match the target delegate '{1}' (possibly because of nullability attributes).
  - "CS8622" # WRN_NullabilityMismatchInParameterTypeOfTargetDelegate: Nullability of reference types in type of parameter '{0}' of '{1}' doesn't match the target delegate '{2}' (possibly because of nullability attributes).
  - "CS8624" # WRN_NullabilityMismatchInArgumentForOutput: Argument of type '{0}' cannot be used as an output of type '{1}' for parameter '{2}' in '{3}' due to differences in the nullability of reference types.
  - "CS8625" # WRN_NullAsNonNullable: Cannot convert null literal to non-nullable reference type.
  - "CS8629" # WRN_NullableValueTypeMayBeNull: Nullable value type may be null.
  - "CS8631" # WRN_NullabilityMismatchInTypeParameterConstraint: The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. Nullability of type argument '{3}' doesn't match constraint type '{1}'.
  - "CS8633" # WRN_NullabilityMismatchInConstraintsOnImplicitImplementation: Nullability in constraints for type parameter '{0}' of method '{1}' doesn't match the constraints for type parameter '{2}' of interface method '{3}'. Consider using an explicit interface implementation instead.
  - "CS8634" # WRN_NullabilityMismatchInTypeParameterReferenceTypeConstraint: The type '{2}' cannot be used as type parameter '{1}' in the generic type or method '{0}'. Nullability of type argument '{2}' doesn't match 'class' constraint.
  - "CS8643" # WRN_NullabilityMismatchInExplicitlyImplementedInterface: Nullability of reference types in explicit interface specifier doesn't match interface implemented by the type.
  - "CS8644" # WRN_NullabilityMismatchInInterfaceImplementedByBase:  '{0}' does not implement interface member '{1}'. Nullability of reference types in interface implemented by the base type doesn't match.
  - "CS8645" # WRN_DuplicateInterfaceWithNullabilityMismatchInBaseList: '{0}' is already listed in the interface list on type '{1}' with different nullability of reference types.
  - "CS8655" # WRN_SwitchExpressionNotExhaustiveForNull: The switch expression does not handle some null inputs (it is not exhaustive). For example, the pattern '{0}' is not covered.
  - "CS8667" # WRN_NullabilityMismatchInConstraintsOnPartialImplementation: Partial method declarations of '{0}' have inconsistent nullability in constraints for type parameter '{1}'
  - "CS8670" # WRN_NullReferenceInitializer: Object or collection initializer implicitly dereferences possibly null member '{0}'.
  - "CS8714" # WRN_NullabilityMismatchInTypeParameterNotNullConstraint: The type '{2}' cannot be used as type parameter '{1}' in the generic type or method '{0}'. Nullability of type argument '{2}' doesn't match 'notnull' constraint.
  - "CS8762" # WRN_ParameterConditionallyDisallowsNull: Parameter '{0}' must have a non-null value when exiting with '{1}'.
  - "CS8763" # WRN_ShouldNotReturn: A method marked [DoesNotReturn] should not return.
  - "CS8764" # WRN_TopLevelNullabilityMismatchInReturnTypeOnOverride:  Nullability of return type doesn't match overridden member (possibly because of nullability attributes).
  - "CS8765" # WRN_TopLevelNullabilityMismatchInParameterTypeOnOverride: Nullability of type of parameter '{0}' doesn't match overridden member (possibly because of nullability attributes).
  - "CS8766" # WRN_TopLevelNullabilityMismatchInReturnTypeOnImplicitImplementation: Nullability of reference types in return type of '{0}' doesn't match implicitly implemented member '{1}' (possibly because of nullability attributes).
  - "CS8767" # WRN_TopLevelNullabilityMismatchInParameterTypeOnImplicitImplementation: Nullability of reference types in type of parameter '{0}' of '{1}' doesn't match implicitly implemented member '{2}' (possibly because of nullability attributes).
  - "CS8768" # WRN_TopLevelNullabilityMismatchInReturnTypeOnExplicitImplementation: Nullability of reference types in return type doesn't match implemented member '{0}' (possibly because of nullability attributes).
  - "CS8769" # WRN_TopLevelNullabilityMismatchInParameterTypeOnExplicitImplementation: Nullability of reference types in type of parameter '{0}' doesn't match implemented member '{1}' (possibly because of nullability attributes).
  - "CS8770" # WRN_DoesNotReturnMismatch: Method '{0}' lacks `[DoesNotReturn]` annotation to match implemented or overridden member.
  - "CS8774" # WRN_MemberNotNull: Member '{0}' must have a non-null value when exiting.
  - "CS8776" # WRN_MemberNotNullBadMember:  Member '{0}' cannot be used in this attribute.
  - "CS8775" # WRN_MemberNotNullWhen: Member '{0}' must have a non-null value when exiting with '{1}'.
  - "CS8777" # WRN_ParameterDisallowsNull: Parameter '{0}' must have a non-null value when exiting.
  - "CS8824" # WRN_ParameterNotNullIfNotNull: Parameter '{0}' must have a non-null value when exiting because parameter '{1}' is non-null.
  - "CS8825" # WRN_ReturnNotNullIfNotNull: Return value must be non-null because parameter '{0}' is non-null.
  - "CS8847" # WRN_SwitchExpressionNotExhaustiveForNullWithWhen: The switch expression does not handle some null inputs (it is not exhaustive). For example, the pattern '{0}' is not covered. However, a pattern with a 'when' clause might successfully match this value.
helpviewer_keywords:
  - "CS8597"
  - "CS8600"
  - "CS8601"
  - "CS8602"
  - "CS8604"
  - "CS8605"
  - "CS8607"
  - "CS8608"
  - "CS8609"
  - "CS8610"
  - "CS8611"
  - "CS8612"
  - "CS8613"
  - "CS8614"
  - "CS8615"
  - "CS8616"
  - "CS8617"
  - "CS8618"
  - "CS8619"
  - "CS8620"
  - "CS8621"
  - "CS8622"
  - "CS8624"
  - "CS8625"
  - "CS8629"
  - "CS8631"
  - "CS8634"
  - "CS8655"
  - "CS8633"
  - "CS8643"
  - "CS8644"
  - "CS8645"
  - "CS8762"
  - "CS8763"
  - "CS8764"
  - "CS8765"
  - "CS8766"
  - "CS8667"
  - "CS8768"
  - "CS8670"
  - "CS8714"
  - "CS8767"
  - "CS8769"
  - "CS8770"
  - "CS8774"
  - "CS8776"
  - "CS8775"
  - "CS8777"
  - "CS8819"
  - "CS8824"
  - "CS8825"
  - "CS8847"
ms.date: 06/30/2022
---
# Resolve nullable warnings

The purpose of nullable reference types is to minimize the chance that your application throws a <xref:System.NullReferenceException?displayProperty=nameWithType> when run. To achieve this goal, the compiler uses static analysis and issues warnings when your code has constructs that may lead to null reference exceptions. You provide the compiler with information for its static analysis by applying type annotations and attributes. These annotations and attributes describe the nullability of arguments, parameters, and members of your types. In this article, you'll learn different techniques to address the nullable warnings the compiler generates from its static analysis. The techniques described here are for general C# code. Learn to work with nullable reference types and Entity Framework core in [Working with nullable reference types](/ef/core/miscellaneous/nullable-reference-types).

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
