---
title: "C# Compiler warning waves"
description: "C# warning waves are optional warnings that can be reported on code where previously a warning would not have been reported. They represent practices that could be harmful, or potentially elements that may be breaking changes in the future."
ms.date: 04/27/2022
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

New warnings and errors may be introduced in each release of the C# compiler. When new warnings could be reported on existing code, those warnings are introduced under an opt-in system referred to as a *warning wave*. The opt-in system means that you should not see new warnings on existing code without taking action to enable them. Warning waves are enabled using a whole number greater than 4 for the [**WarningLevel**](../compiler-options/errors-warnings.md#warninglevel) element in your project file. When `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>` is specified, enabled warning wave warnings generate errors.

The default warning level is `4`. If you want the compiler to produce all applicable warnings, you can specify `<WarningLevel>9999</WarningLevel>`.

## Warning level 7

The compiler shipped with .NET 7 (the C# 11 compiler) contains the following warnings which are reported only under `/warn:7` or higher.

### CS8981

CS8981 - The type name 'name' only contains lower-cased ascii characters. Such names may become reserved for the language.

Any potential new keywords added for C# will be all lower-case ASCII characters. This warning ensures that none of your types conflict with potential future keywords. The following code produces CS8981:

:::code language="csharp" source="./snippets/WarningWaves/WaveSeven.cs" id="NoLowercaseTypes":::

You can address this warning by renaming the type to include at least non-lower case ASCII character, such as an upper case character, a digit, or an underscore.

## Warning level 6

The compiler shipped with .NET 6 (the C# 10 compiler) contains the following warnings which are reported only under `/warn:6` or higher.

### CS8826

CS8826  - Partial method declarations 'name' and 'name' have signature differences.

This warning corrects some inconsistencies in reporting differences between partial method signatures. The compiler always reported an error when the partial method signatures created different CLR signatures. Now, the compiler reports CS8826 when the signatures are syntactically different C#.  Consider the following partial class:

:::code language="csharp" source="./snippets/WarningWaves/WaveSix.cs" id="PartialMethodDeclaration":::

The following partial class implementation generates several examples of CS8626:

:::code language="csharp" source="./snippets/WarningWaves/WaveSix.cs" id="PartialMethodDefinition":::

Note that if the implementation of a method uses a non-nullable reference type when the other declaration accepts nullable reference types, CS8611 is generated instead of CS8826.

To fix any instance of these warnings, ensure the two signatures match.

## Warning level 5

Warning level 5 warnings are available beginning with C# 9, which shipped with .NET 5.

### CS7023

CS7023 - A static type is used in an `is` or `as` expression.

The `is` and `as` expressions always return `false` for a static type because you can't create instances of a static type. The following code produces CS7023:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeAsIs":::

The compiler reports this warning because the type test can never succeed. To correct this warning, remove the test and remove any code executed only if the test succeeded. In the preceding example, the `else` clause is always executed. The method body could be replaced by that single line:

```csharp
Console.WriteLine("o is not an instance of a static class");
```

### CS8073

CS8073 - The result of the expression is always 'false' (or `true`).

The `==` and `!=` operators always return `false` (or `true`) when comparing an instance of a `struct` type to `null`. The following code demonstrates this warning. Assume `S` is a `struct` that has defined `operator ==` and `operator !=`:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StructsArentNull":::

To fix this error, remove the null check, and and code that would execute if the object is `null`.

### CS8848

CS8848: Operator 'from' cannot be used here due to precedence. Use parentheses to disambiguate.

The following examples demonstrate this warning. The expression binds incorrectly because of the precedence of the operators.

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="QueryPrecedence":::

To fix this error, put parentheses around the query expression:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="QueryPrecedenceNoWarn":::

### Definite assignment warnings

Warning wave 5 includes several warnings the improve the definite assignment analysis for `struct` types declared in imported assemblies. All these new warnings are generated when a struct in an imported assembly includes an inaccessible field (usually a `private` field) that isn't initialized by that struct. The following struct definition shows an example of a struct with a private field that isn't initialized by the struct:

:::code language="csharp" source="snippets/ImportedTypes/Types.cs" id="DeclareImportedType":::

#### CS8880

CS8880:  Auto-implemented property 'Property' must be fully assigned before control is returned to the caller.

The compiler generates CS8880 when you declare an auto implemented property whose type is an imported struct type and don't initialize that struct, as shown in the following code:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UninitializedAutoProp":::

To address this warning, explicitly initialize the struct:

```csharp
public Testing(int dummy)
{
    Property = default;
}
```

#### CS8881

CS8881:  Field 'field' must be fully assigned before control is returned to the caller.

The compiler generates CS8881 when you declare a field whose type is an imported struct type and don't initialize that struct, as shown in the following code:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UninitializedField":::

To address this warning, explicitly initialize the struct:

```csharp
public Testing(int dummy)
{
    field = default;
}
```

#### CS8882

CS882: The out parameter 'parameter' must be assigned to before control leaves the current method.

The compiler generates CS8882 when you declare a method with an `out` parameter whose type is an imported struct type and you don't assign that struct in the method. The following code generates CS8881:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UninitializedField":::

To address this warning, explicitly initialize the struct:

```csharp
private Struct field = default;
```

#### CS8883

CS8883: Use of possibly unassigned auto-implemented property 'Property'.

The compiler generates CS8883 when you access an auto-implemented property whose type is an imported struct and you read that property before you definitely assign it. The following code generates CS8883:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UseBeforeAssignment":::

To address this warning, explicitly initialize the struct:

```csharp
public Struct Property { get; } = default;
```

#### CS8884

CS8884: Use of possibly unassigned field 'Field'

The compiler generates CS8884 when you access a field whose type is an imported struct and you read that field before you definitely assign it. The following code generates CS8884:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="AccessFieldBeforeAssignment":::

To address the warning, explicitly initialize the struct:

```csharp
public Struct Field;
```

#### CS8885

CS8885: The 'this' object can't be used before all its fields have been assigned.

The compiler generates CS8885 when you access `this` before you've assigned all the fields (or auto-implemented properties) in the current instance. The following code generates CS8885:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="AccessThisBeforeAssignment":::

To address the warning, explicitly initialize all fields in the struct:

```csharp
public Struct Field = default;
```

#### CS8886

CS8886: Use of unassigned output parameter `parameterName`

The compiler generates CS8886 when you access an out parameter whose type is an imported struct and you read that field out parameter before you definitely assign it. The following code generates CS8886:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UseOutBeforeAssignment":::

To address this warning, definitely assign the parameter before accessing it:

```csharp
s1 = default;
var s2 = s1;
```

#### CS8887

CS8887: Use of unassigned local variable 'variableName'

The compiler generates CS8887 when you access a local variable whose type is an imported struct and you read that local variable before you definitely assign it. The following code generates CS8887:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="UseLocalStruct":::

The address this warning, definitely assign the local variable:

```csharp
Struct r1 = default;
```

### CS8892

CS889s: Method 'method' will not be used as an entry point because a synchronous entry point 'method' was found.

This warning is generated on all async entry point candidates when you have multiple valid entry points, where they contain one or more synchronous entry point and one or more asynchronous entry points. Because async main was only supported starting with C# 7.1, this warning isn't generated for projects targeting a previous version.

The following example generates CS8892:

:::code language="csharp" source="./snippets/WarningWaves/Program.cs" id="MultipleEntryPoints":::

> [!NOTE]
> The compiler always uses the synchronous entry point. In case there are multiple synchronous entry points, you get a compiler error.

To fix this warning, remove or rename the asynchronous entry point.

### CS8897

CS8897: static types cannot be used as parameters

Members of an interface can't declare parameters whose type is a static class. The following code demonstrates both CS8897 and CS8898:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeInInterface":::

To fix this warning, change the parameter type or remove the method.

### CS8898

CS8898: static types cannot be used as return types

Members of an interface can't declare a return type that is a static class. The following code demonstrates both CS8897 and CS8898:

:::code language="csharp" source="./snippets/WarningWaves/WaveFive.cs" id="StaticTypeInInterface":::

To fix this warning, change the return type or remove the method.
