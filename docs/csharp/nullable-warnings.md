---
title: Resolve nullable warnings
description: Enabling nullable reference types causes the compiler to issue warnings related to null safety. Learn techniques to address them.
ms.technology: csharp-null-safety
ms.date: 09/17/2021
---
# Learn techniques to resolve nullable warnings

The purpose of nullable reference types is to minimize the chance that your application throws a <xref:System.NullReferenceException?displayProperty=nameWithType> when run. To achieve this goal, the compiler uses static analysis and issues warnings when your code has constructs that may lead to null reference exceptions. You provide the compiler with information for its static analysis by applying type annotations and attributes. These annotations and attributes describe the nullability of arguments, parameters, and members of your types. In this article, you'll learn different techniques to address the nullable warnings the compiler generates from its static analysis. The techniques described here are for general C# code. Learn to work with nullable reference types and Entity Framework core in [Working with nullable reference types](/ef/core/miscellaneous/nullable-reference-types.md).

You'll address almost all warnings using one of four techniques:

- Adding necessary null checks.
- Adding `?` or `!` nullable annotations.
- Adding attributes that describe null semantics.
- Initializing variables correctly.

## Possible dereference of null

One set of warnings alert you that you're dereferencing a variable whose *null-state* is *maybe-null*. One example might be:

```csharp
string message = null;
Console.WriteLine(message.Length);
```

To remove these warnings, you need to add code to change that variable's *null-state* to *not-null* before dereferencing it.

In many instances, you can fix these warnings by checking that a variable isn't null before dereferencing it. For example, the above example could be rewritten as:

:::code language="csharp" source="snippets/null-warnings/Program.cs" id="ProvideNullCheck":::

When your code generates a warning that it may be dereferencing a *maybe-null* reference, make sure you've done a null check. If you haven't, add one. The compiler warning helped you address a possible bug.

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
> There's a rich set of attributes you can use to describe how your methods and properties affect *null-state*. You can learn about them in the language reference article on [Nullable static analysis attributes](language-reference/attributes/nullable-analysis.md).

Fixing a warning for dereferencing a *maybe-null* variable involves one of three techniques:

- Add a missing null check.
- Add null analysis attributes on APIs to affect the compiler's *null-state* static analysis. These attributes inform the compiler when a return value or argument should be *maybe-null* or *not-null* after calling the method.
- Apply the null forgiving operator `!` to the expression to force the state to *not-null*.

## Possible null assigned to a nonnullable reference

The compiler emits these warnings when you attempt to assign an expression that is *maybe-null* to a variable that is nonnullable. For example:

:::code language="csharp" source="./snippets/null-warnings/Program.cs" id="PossibleNullAssignment":::

You can take one of three actions to address these warnings. One is to add the `?` annotation to make the variable a nullable reference type. That change may cause other warnings. Changing a variable from a non-nullable reference to a nullable reference changes its default *null-state* from *not-null* to *maybe-null*. The compiler's static analysis may find instances where you dereference a variable that is *maybe-null*.

The other actions instruct the compiler that the right-hand-side of the assignment is *not-null*. The expression on the right-hand-side could be null checked before assignment, as shown in the following example:

:::code language="csharp" source="./snippets/null-warnings/Program.cs" id="NullGuard":::

The previous examples demonstrate assignment to the return value of a method. You may annotate the method (or property) to indicate when a method returns a not-null value. The <xref:System.Diagnostics.CodeAnalysis.NotNullIfNotNullAttribute?displayProperty=nameWithType> often specifies that a return value is *not-null* when an input argument is *not-null*. Another alternative is to add the null forgiving operator, `!` to the right-hand side:

```csharp
string msg = TryGetMessage(42)!;
```

Fixing a warning for assigning a *maybe-null* expression to a *not-null* variable involves one of four techniques:

- Change the left side of the assignment to a nullable type. This action may introduce new warnings when you dereference that variable.
- Provide a null-check before the assignment.
- Annotate the API that produces the right-hand side of the assignment.
- Add the null forgiving operator to the right-hand side of the assignment.

## Nonnullable reference not initialized

Other warnings are generated when a nonnullable reference variable isn't initialized when declared, or in a constructor. Consider the following class as an example:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="PersonExample":::

Neither `FirstName` nor `LastName` are guaranteed initialized. If this code is new, consider changing the public interface. The above example could be updated as follows:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="WithConstructor":::

If you require creating a `Person` object before setting the name, you can initialize the properties using a default non-null value:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="Initializer":::

Another alternative may be to change those members to nullable reference types. The `Person` class could be defined as follows if `null` should be allowed for the name:

:::code language="csharp" source="./snippets/null-warnings/PersonExamples.cs" id="NullableMember":::

Existing code may require other changes to inform the compiler about the null semantics for those members. You may have created multiple constructors, and your class may have a private helper method that initializes one or more members. The <xref:System.Diagnostics.CodeAnalysis.MemberNotNullAttribute?displayProperty=nameWithType> and <xref:System.Diagnostics.CodeAnalysis.MemberNotNullWhenAttribute?displayProperty=nameWithType> attributes inform the compiler that a member is *not-null* after the method has been called.

Finally, you can use the null forgiving operator to indicate that a member is initialized in other code. For another example, consider the following classes representing an Entity Framework Core model:

:::code language="csharp" source="./snippets/null-warnings/Context.cs" id="ExampleModel":::

The `DbSet` property is initialized to `null!`. That tells the compiler that the property is set to a *not-null* value. In fact, the base `DbContext` performs the initialization of the set. The compiler's static analysis doesn't pick that up. For more information on working with nullable reference types and Entity Framework Core, see the article on [Working with Nullable Reference Types in EF Core](/ef/core/miscellaneous/nullable-reference-types).

Fixing a warning for not initializing a nonnullable member involves one of four techniques:

- Change the constructors or field initializers to ensure all nonnullable members are initialized.
- Change one or more members to be nullable types.
- Annotate any helper methods to indicate which members are assigned.
- Add an initializer to `null!` to indicate that the member is initialized in other code.

## Mismatch in nullability declaration

Other warnings indicate nullability mismatches between signatures for methods, delegates, or type parameters. For example:

:::code language="csharp" source="snippets/null-warnings/Hierarchy.cs" id="Hierarchy":::

The preceding example shows a `virtual` method in a base class and an `override` with different nullability. The base class returns a non-nullable string, but the derived class returns a nullable string. If the `string` and `string?` are reversed, it would be allowed because the derived class is more restrictive. Similarly, parameter declarations should match. Parameters in the override method can allow null even when the base class doesn't.

Other situations can generate these warnings. You may have a mismatch in an interface method declaration and the implementation of that method. Or a delegate type and the expression for that delegate may differ. A type parameter and the type argument may differ in nullability.

To fix these warnings, update the appropriate declaration.

## Code doesn't match attribute declaration

The preceding sections have discussed how you can use [Attributes for nullable static analysis](language-reference/attributes/nullable-analysis.md) to inform the compiler about the null semantics of your code. The compiler warns you if the code doesn't adhere to the promises of that attribute. Consider the following method:

:::code language="csharp" source="snippets/null-warnings/NullTests.cs" id="ViolateAttribute":::

The compiler produces a warning because the `message` parameter is assigned `null` *and* the method returns `true`. The `NotNullWhen` attribute indicates that shouldn't happen.

To address these warnings, update your code so it matches the expectations of the attributes you've applied. You may change the attributes, or the algorithm.
