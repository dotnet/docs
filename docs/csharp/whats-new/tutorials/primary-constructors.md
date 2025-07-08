---
title: Declare C# primary constructors – classes, structs
description: Learn how and when to declare primary constructors in your class and struct types. Primary constructors provide concise syntax to declare constructor parameters available anywhere in the body of your type.
ms.date: 03/18/2025
ms.topic: how-to
#customer intent: As a .NET developer, I want to declare and use C# primary constructors in classes and structs, so I can provide syntax to declare constructor parameters available anywhere in the type body.
---
# Declare primary constructors for classes and structs

C# 12 introduces [primary constructors](../../programming-guide/classes-and-structs/instance-constructors.md#primary-constructors), which provide a concise syntax to declare constructors whose parameters are available anywhere in the body of the type.

This article describes how to declare a primary constructor on your type and recognize where to store primary constructor parameters. You can call primary constructors from other constructors and use primary constructor parameters in members of the type.

## Prerequisites

[!INCLUDE [Prerequisites](../../../../includes/prerequisites-basic.md)]

## Understand rules for primary constructors

You can add parameters to a `struct` or `class` declaration to create a *primary constructor*. Primary constructor parameters are in scope throughout the class definition. It's important to view primary constructor parameters as *parameters* even though they are in scope throughout the class definition.

Several rules clarify that these constructors are parameters:

- Primary constructor parameters might not be stored if they aren't needed.
- Primary constructor parameters aren't members of the class. For example, a primary constructor parameter named `param` can't be accessed as `this.param`.
- Primary constructor parameters can be assigned to.
- Primary constructor parameters don't become properties, except in [record](../../language-reference/builtin-types/record.md) types.

These rules are the same rules already defined for parameters to any method, including other constructor declarations.

Here are the most common uses for a primary constructor parameter:

- Pass as an argument to a `base()` constructor invocation
- Initialize a member field or property
- Reference the constructor parameter in an instance member

Every other constructor for a class **must** call the primary constructor, directly or indirectly, through a `this()` constructor invocation. This rule ensures that primary constructor parameters are assigned everywhere in the body of the type.

## Initialize immutable properties or fields

The following code initializes two readonly (immutable) properties that are computed from primary constructor parameters:

:::code source="./snippets/primary-constructors/Distance.cs" id="ReadonlyStruct":::

This example uses a primary constructor to initialize calculated readonly properties. The field initializers for the `Magnitude` and `Direction` properties use the primary constructor parameters. The primary constructor parameters aren't used anywhere else in the struct. The code creates a struct as if it were written in the following manner:

:::code source="./snippets/primary-constructors/Distance.cs" id="StructOneLowered":::

This feature makes it easier to use field initializers when you need arguments to initialize a field or property.

## Create mutable state

The previous examples use primary constructor parameters to initialize readonly properties. You can also use primary constructors for properties that aren't readonly.

Consider the following code:

:::code source="./snippets/primary-constructors/Distance.cs" id="MutableStruct":::

In this example, the `Translate` method changes the `dx` and `dy` components, which requires the `Magnitude` and `Direction` properties be computed when accessed. The greater than or equal to (`=>`) operator designates an expression-bodied `get` accessor, whereas the equal to (`=`) operator designates an initializer.

This version of the code adds a parameterless constructor to the struct. The parameterless constructor must invoke the primary constructor, which ensures all primary constructor parameters are initialized. The primary constructor properties are accessed in a method, and the compiler creates hidden fields to represent each parameter.

The following code demonstrates an approximation of what the compiler generates. The actual field names are valid Common Intermediate Language (CIL) identifiers, but not valid C# identifiers.

:::code source="./snippets/primary-constructors/Distance.cs" id="StructTwoLowered":::

### Compiler-created storage

For the first example in this section, the compiler didn't need to create a field to store the value of the primary constructor parameters. However, in  the second example, the primary constructor parameter is used inside a method, so the compiler must create storage for the parameters.

The compiler creates storage for any primary constructors only when the parameter is accessed in the body of a member of your type. Otherwise, the primary constructor parameters aren't stored in the object.

## Use dependency injection

Another common use for primary constructors is to specify parameters for dependency injection. The following code creates a simple controller that requires a service interface for its use:

:::code source="./snippets/primary-constructors/ExampleController.cs" id="DependencyInjection":::

The primary constructor clearly indicates the parameters needed in the class. You use the primary constructor parameters as you would any other variable in the class.

## Initialize base class

You can invoke the primary constructor for a base class from the primary constructor of derived class. This approach is the easiest way to write a derived class that must invoke a primary constructor in the base class. Consider a hierarchy of classes that represent different account types as a bank. The following code shows what the base class might look like:

:::code source="./snippets/primary-constructors/BankAccount.cs" id="BaseClass":::

All bank accounts, regardless of the type, have properties for the account number and owner. In the completed application, you can add other common functionality to the base class.

Many types require more specific validation on constructor parameters. For example, the `BankAccount` class has specific requirements for the `owner` and `accountID` parameters. The `owner` parameter must not be `null` or whitespace, and the `accountID` parameter must be a string containing 10 digits. You can add this validation when you assign the corresponding properties:

:::code source="./snippets/primary-constructors/BankAccountValidation.cs" id="BaseClassValidation":::

This example shows how to validate the constructor parameters before you assign them to the properties. You can use built-in methods like <xref:System.String.IsNullOrWhiteSpace(System.String)?displayProperty=nameWithType> or your own validation method, such as `ValidAccountNumber`. In the example, any exceptions are thrown from the constructor, when it invokes the initializers. If a constructor parameter isn't used to assign a field, any exceptions are thrown when the constructor parameter is first accessed.

One derived class might represent a checking account:

:::code source="./snippets/primary-constructors/BankAccount.cs" id="DerivedClass":::

The derived `CheckingAccount` class has a primary constructor that takes all the parameters needed in the base class, and another parameter with a default value. The primary constructor calls the base constructor with the `: BankAccount(accountID, owner)` syntax. This expression specifies both the type for the base class and the arguments for the primary constructor.

Your derived class isn't required to use a primary constructor. You can create a constructor in the derived class that invokes the primary constructor for the base class, as shown in the following example:

:::code source="./snippets/primary-constructors/BankAccount.cs" id="NoPrimaryConstructor":::

There's one potential concern with class hierarchies and primary constructors. It's possible to create multiple copies of a primary constructor parameter because the parameter is used in both derived and base classes. The following code creates two copies each of the `owner` and `accountID` parameters:

:::code source="./snippets/primary-constructors/BankAccount.cs" id="DuplicatedPrimaryConstructorStorage" highlight="33":::

The highlighted line in this example shows that the `ToString` method uses the *primary constructor parameters* (`owner` and `accountID`) rather than the *base class properties* (`Owner` and `AccountID`). The result is that the derived class, `SavingsAccount`, creates storage for the parameter copies. The copy in the derived class is different than the property in the base class. If the base class property can be modified, the instance of the derived class doesn't see the modification. The compiler issues a warning for primary constructor parameters that are used in a derived class and passed to a base class constructor. In this instance, the fix is to use the properties of the base class.

## Related content

- [Parameterless constructors (C# programming guide)](../../programming-guide/classes-and-structs/instance-constructors.md#parameterless-constructors)
- [Primary constructors (Feature specification proposal)](~/_csharplang/proposals/csharp-12.0/primary-constructors.md)
