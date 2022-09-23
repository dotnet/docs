---
title: "C# Compiler warning waves"
description: "C# warning waves are optional warnings that can be reported on code where previously a warning wouldn't have been reported. They represent practices that could be harmful, or potentially elements that may be breaking changes in the future."
ms.date: 05/11/2022
f1_keywords:
  - "CS7023"
  - "CS8073"
  - "CS8848"
  - "CS8880"
  - "CS8881"
  - "CS8882"
  - "CS8883"
  - "CS8884"
  - "CS8885"
  - "CS8886"
  - "CS8887"
  - "CS8892"
  - "CS8897"
  - "CS8898"
  - "CS8826"
  - "CS8981"
helpviewer_keywords: 
  - "CS7023"
  - "CS8073"
  - "CS8848"
  - "CS8880"
  - "CS8881"
  - "CS8882"
  - "CS8883"
  - "CS8884"
  - "CS8885"
  - "CS8886"
  - "CS8887"
  - "CS8892"
  - "CS8897"
  - "CS8898"
  - "CS8826"
  - "CS8981"
---
# C# Warning waves

New warnings and errors may be introduced in each release of the C# compiler. When new warnings could be reported on existing code, those warnings are introduced under an opt-in system referred to as a *warning wave*. The opt-in system means that you shouldn't see new warnings on existing code without taking action to enable them. Warning waves are enabled using the [**AnalysisLevel**](../compiler-options/errors-warnings.md#analysis-level) element in your project file. When `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>` is specified, enabled warning wave warnings generate errors. Warning wave 5 diagnostics were added in C# 9. Warning wave 6 diagnostics were added in C# 10. Warning wave 7 diagnostics were added in C# 11.

## CS8981 - The type name only contains lower-cased ascii characters.

*Warning wave 7*

Any new keywords added for C# will be all lower-case ASCII characters. This warning ensures that none of your types conflict with future keywords. The following code produces CS8981:

:::code language="csharp" source="./snippets/WarningWaves/WaveSeven.cs" id="NoLowercaseTypes":::

You can address this warning by renaming the type to include at least one non-lower case ASCII character, such as an upper case character, a digit, or an underscore.

## CS8826 - Partial method declarations have signature differences.

*Warning wave 6*

This warning corrects some inconsistencies in reporting differences between partial method signatures. The compiler always reported an error when the partial method signatures created different CLR signatures. Now, the compiler reports CS8826 when the signatures are syntactically different C#.  Consider the following partial class:

:::code language="csharp" source="./snippets/WarningWaves/WaveSix.cs" id="PartialMethodDeclaration":::

The following partial class implementation generates several examples of CS8626:

:::code language="csharp" source="./snippets/WarningWaves/WaveSix.cs" id="PartialMethodDefinition":::

> [!NOTE]
> If the implementation of a method uses a non-nullable reference type when the other declaration accepts nullable reference types, CS8611 is generated instead of CS8826.

To fix any instance of these warnings, ensure the two signatures match.

## CS7023 - A static type is used in an 'is' or 'as' expression.

*Warning wave 5*

The `is` and `as` expressions always return `false` for a static type because you can't create instances of a static type. The following code produces CS7023:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeAsIs":::

The compiler reports this warning because the type test can never succeed. To correct this warning, remove the test and remove any code executed only if the test succeeded. In the preceding example, the `else` clause is always executed. The method body could be replaced by that single line:

```csharp
Console.WriteLine("o is not an instance of a static class");
```

## CS8073 - The result of the expression is always 'false' (or 'true').

*Warning wave 5*

The `==` and `!=` operators always return `false` (or `true`) when comparing an instance of a `struct` type to `null`. The following code demonstrates this warning. Assume `S` is a `struct` that has defined `operator ==` and `operator !=`:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StructsArentNull":::

To fix this error, remove the null check and code that would execute if the object is `null`.

## CS8848 - Operator 'from' can't be used here due to precedence. Use parentheses to disambiguate.

*Warning wave 5*

The following examples demonstrate this warning. The expression binds incorrectly because of the precedence of the operators.

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="QueryPrecedence":::

To fix this error, put parentheses around the query expression:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="QueryPrecedenceNoWarn":::

## Members must be fully assigned, use of unassigned variable (CS8880, CS8881, CS8882, CS8883, CS8884, CS8885, CS8886, CS8887)

*Warning wave 5*

Several warnings improve the definite assignment analysis for `struct` types declared in imported assemblies. All these new warnings are generated when a struct in an imported assembly includes an inaccessible field (usually a `private` field) of a reference type, as shown in the following example:

:::code language="csharp" source="snippets/ImportedTypes/Types.cs" id="DeclareImportedType":::

The following examples show the warnings generated from the improved definite assignment analysis:

- CS8880:  Auto-implemented property 'Property' must be fully assigned before control is returned to the caller.
- CS8881:  Field 'field' must be fully assigned before control is returned to the caller.
- CS8882: The out parameter 'parameter' must be assigned to before control leaves the current method.
- CS8883: Use of possibly unassigned auto-implemented property 'Property'.
- CS8884: Use of possibly unassigned field 'Field'
- CS8885: The 'this' object can't be used before all its fields have been assigned.
- CS8886: Use of unassigned output parameter 'parameterName'.
- CS8887: Use of unassigned local variable 'variableName'

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="DefiniteAssignmentWarnings":::

You can fix any of these warnings by initializing or assigning the imported struct to its default value:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="DefiniteAssignment":::

## CS8892 - Method will not be used as an entry point because a synchronous entry point 'method' was found.

*Warning wave 5*

This warning is generated on all async entry point candidates when you have multiple valid entry points, including one or more synchronous entry point.

The following example generates CS8892:

:::code language="csharp" source="./snippets/WarningWaves/Program.cs" id="MultipleEntryPoints":::

> [!NOTE]
> The compiler always uses the synchronous entry point. In case there are multiple synchronous entry points, you get a compiler error.

To fix this warning, remove or rename the asynchronous entry point.

## CS8897 - Static types can't be used as parameters

*Warning wave 5*

Members of an interface can't declare parameters whose type is a static class. The following code demonstrates both CS8897 and CS8898:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeInInterface":::

To fix this warning, change the parameter type or remove the method.

## CS8898 - static types can't be used as return types

*Warning wave 5*

Members of an interface can't declare a return type that is a static class. The following code demonstrates both CS8897 and CS8898:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeInInterface":::

To fix this warning, change the return type or remove the method.
