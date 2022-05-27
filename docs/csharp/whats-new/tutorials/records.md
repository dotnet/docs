---
title: Use record types - C# tutorial
description: Learn about how to use record types, build hierarchies of records, and when to choose records over classes.
ms.date: 09/30/2021
---
# Create record types

C# 9 introduces [*records*](../../language-reference/builtin-types/record.md), a new reference type that you can create instead of classes or structs. C# 10 adds *record structs* so that you can define records as value types. Records are distinct from classes in that record types use *value-based equality*. Two variables of a record type are equal if the record type definitions are identical, and if for every field, the values in both records are equal. Two variables of a class type are equal if the objects referred to are the same class type and the variables refer to the same object. Value-based equality implies other capabilities you'll probably want in record types. The compiler generates many of those members when you declare a `record` instead of a `class`. The compiler generates those same methods for `record struct` types.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Decide if you should declare a `class` or a `record`.
> - Declare record types and positional record types.
> - Substitute your methods for compiler generated methods in records.

## Prerequisites

You'll need to set up your machine to run .NET 6 or later, including the C# 10 or later compiler. The C# 10 compiler is available starting with [Visual Studio 2022](https://visualstudio.microsoft.com/vs) or the [.NET 6 SDK](https://dotnet.microsoft.com/download).

## Characteristics of records

You define a *record* by declaring a type with the `record` keyword, instead of the `class` or `struct` keyword. Optionally, you can declare a `record class` to clarify that it's a reference type. A record is a reference type and follows value-based equality semantics. You can define a `record struct` to create a record that is a value type. To enforce value semantics, the compiler generates several methods for your record type (both for `record class` types and `record struct` types):

- An override of <xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>.
- A virtual `Equals` method whose parameter is the record type.
- An override of <xref:System.Object.GetHashCode?displayProperty=nameWithType>.
- Methods for `operator ==` and `operator !=`.
- Record types implement <xref:System.IEquatable%601?displayProperty=nameWithType>.

Records also provide an override of <xref:System.Object.ToString?displayProperty=nameWithType>. The compiler synthesizes methods for displaying records using <xref:System.Object.ToString?displayProperty=nameWithType>. You'll explore those members as you write the code for this tutorial. Records support `with` expressions to enable non-destructive mutation of records.

You can also declare *positional records* using a more concise syntax. The compiler synthesizes more methods for you when you declare positional records:

- A primary constructor whose parameters match the positional parameters on the record declaration.
- Public properties for each parameter of a primary constructor. These properties are *init-only* for `record class` types and `readonly record struct` types. For `record struct` types, they're *read-write*.
- A `Deconstruct` method to extract properties from the record.

## Build temperature data

Data and statistics are among the scenarios where you'll want to use records. For this tutorial, you'll build an application that computes *degree days* for different uses. *Degree days* are a measure of heat (or lack of heat) over a period of days, weeks, or months. Degree days track and predict energy usage. More hotter days means more air conditioning, and more colder days means more furnace usage. Degree days help manage plant populations and correlate to plant growth as the seasons change. Degree days help track animal migrations for species that travel to match climate.

The formula is based on the mean temperature on a given day and a baseline temperature. To compute degree days over time, you'll need the high and low temperature each day for a period of time. Let's start by creating a new application. Make a new console application. Create a new record type in a new file named "DailyTemperature.cs":

:::code language="csharp" source="snippets/record-types/InterimSteps.cs" ID="DailyRecord":::

The preceding code defines a *positional record*. The `DailyTemperature` record is a `readonly record struct`, because you don't intend to inherit from it, and it should be immutable. The `HighTemp` and `LowTemp` properties are *init only properties*, meaning they can be set in the constructor or using a property initializer. If you wanted the positional parameters to be read-write, you declare a `record struct` instead of a `readonly record struct`. The `DailyTemperature` type also has a *primary constructor* that has two parameters that match the two properties. You use the primary constructor to initialize a `DailyTemperature` record. The following code creates and initializes several `DailyTemperature` records. The first uses named parameters to clarify the `HighTemp` and `LowTemp`. The remaining initializers use positional parameters to initialize the `HighTemp` and `LowTemp`:

:::code language="csharp" source="snippets/record-types/Program.cs" ID="DeclareData":::

You can add your own properties or methods to records, including positional records. You'll need to compute the mean temperature for each day. You can add that property to the `DailyTemperature` record:

:::code language="csharp" source="snippets/record-types/DailyTemperature.cs" ID="TemperatureRecord":::

Let's make sure you can use this data. Add the following code to your `Main` method:

```csharp
foreach (var item in data)
    Console.WriteLine(item);
```

Run your application, and you'll see output that looks similar to the following display (several rows removed for space):

```dotnetcli
DailyTemperature { HighTemp = 57, LowTemp = 30, Mean = 43.5 }
DailyTemperature { HighTemp = 60, LowTemp = 35, Mean = 47.5 }


DailyTemperature { HighTemp = 80, LowTemp = 60, Mean = 70 }
DailyTemperature { HighTemp = 85, LowTemp = 66, Mean = 75.5 }
```

The preceding code shows the output from the override of `ToString` synthesized by the compiler. If you prefer different text, you can write your own version of `ToString` that prevents the compiler from synthesizing a version for you.

## Compute degree days

To compute degree days, you take the difference from a baseline temperature and the mean temperature on a given day. To measure heat over time, you discard any days where the mean temperature is below the baseline. To measure cold over time, you discard any days where the mean temperature is above the baseline. For example, the U.S. uses 65F as the base for both heating  and cooling degree days. That's the temperature where no heating or cooling is needed. If a day has a mean temperature of 70F, that day is five cooling degree days and zero heating degree days. Conversely, if the mean temperature is 55F, that day is 10 heating degree days and 0 cooling degree days.

You can express these formulas as a small hierarchy of record types: an abstract degree day type and two concrete types for heating degree days and cooling degree days. These types can also be positional records. They take a baseline temperature and a sequence of daily temperature records as arguments to the primary constructor:

:::code language="csharp" source="snippets/record-types/InterimSteps.cs" ID="DegreeDaysRecords":::

The abstract `DegreeDays` record is the shared base class for both the `HeatingDegreeDays` and `CoolingDegreeDays` records. The primary constructor declarations on the derived records show how to manage base record initialization. Your derived record declares parameters for all the parameters in the base record primary constructor. The base record declares and initializes those properties. The derived record doesn't hide them, but only creates and initializes properties for parameters that aren't declared in its base record. In this example, the derived records don't add new primary constructor parameters. Test your code by adding the following code to your `Main` method:

:::code language="csharp" source="snippets/record-types/Program.cs" ID="HeatingAndCooling":::

You'll get output like the following display:

```dotnetcli
HeatingDegreeDays { BaseTemperature = 65, TempRecords = record_types.DailyTemperature[], DegreeDays = 85 }
CoolingDegreeDays { BaseTemperature = 65, TempRecords = record_types.DailyTemperature[], DegreeDays = 71.5 }
```

## Define compiler-synthesized methods

Your code calculates the correct number of heating and cooling degree days over that period of time. But this example shows why you may want to replace some of the synthesized methods for records. You can declare your own version of any of the compiler-synthesized methods in a record type except the clone method. The clone method has a compiler-generated name and you can't provide a different implementation. These synthesized methods include a copy constructor, the members of the <xref:System.IEquatable%601?displayProperty=nameWithType> interface, equality and inequality tests, and <xref:System.Object.GetHashCode>. For this purpose, you'll synthesize `PrintMembers`. You could also declare your own `ToString`, but `PrintMembers` provides a better option for inheritance scenarios. To provide your own version of a synthesized method, the signature must match the synthesized method.

The `TempRecords` element in the console output isn't useful. It displays the type, but nothing else. You can change this behavior by providing your own implementation of the synthesized `PrintMembers` method. The signature depends on modifiers applied to the `record` declaration:

- If a record type is `sealed`, or a `record struct`, the signature is `private bool PrintMembers(StringBuilder builder);`
- If a record type isn't `sealed` and derives from `object` (that is, it doesn't declare a base record), the signature is `protected virtual bool PrintMembers(StringBuilder builder);`
- If a record type isn't `sealed` and derives from another record, the signature is `protected override bool PrintMembers(StringBuilder builder);`

These rules are easiest to comprehend through understanding the purpose of `PrintMembers`. `PrintMembers` adds information about each property in a record type to a string. The contract requires base records to add their members to the display and assumes derived members will add their members. Each record type synthesizes a `ToString` override that looks similar to the following example for `HeatingDegreeDays`:

```csharp
public override string ToString()
{
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Append("HeatingDegreeDays");
    stringBuilder.Append(" { ");
    if (PrintMembers(stringBuilder))
    {
        stringBuilder.Append(" ");
    }
    stringBuilder.Append("}");
    return stringBuilder.ToString();
}
```

You declare a `PrintMembers` method in the `DegreeDays` record that doesn't print the type of the collection:

:::code language="csharp" source="snippets/record-types/DegreeDays.cs" ID="AddPrintMembers":::

The signature declares a `virtual protected` method to match the compiler's version. Don't worry if you get the accessors wrong; the language enforces the correct signature. If you forget the correct modifiers for any synthesized method, the compiler issues warnings or errors that help you get the right signature.

In C# 10 and later, you can declare the `ToString` method as `sealed` in a record type. That prevents derived records from providing a new implementation. Derived records will still contain the `PrintMembers` override. You would do seal `ToString` if you didn't want it to display the runtime type of the record. In the preceding example, you'd lose the information on where the record was measuring heating or cooling degree days.

## Non-destructive mutation

The synthesized members in a positional record class don't modify the state of the record. The goal is that you can more easily create immutable records. Remember that you declare a `readonly record struct` to create an immutable record struct. Look again at the preceding declarations for `HeatingDegreeDays` and `CoolingDegreeDays`. The members added perform computations on the values for the record, but don't mutate state. Positional records make it easier for you to create immutable reference types.

Creating immutable reference types means you'll want to use non-destructive mutation. You  create new record instances that are similar to existing record instances using [`with` expressions](../../language-reference/operators/with-expression.md). These expressions are a copy construction with additional assignments that modify the copy. The result is a new record instance where each property has been copied from the existing record and optionally modified. The original record is unchanged.

Let's add a couple features to your program that demonstrate `with` expressions. First, let's create a new record to compute growing degree days using the same data. *Growing degree days* typically uses 41F as the baseline and measures temperatures above the baseline. To use the same data, you can create a new record that is similar to the `coolingDegreeDays`, but with a different base temperature:

:::code language="csharp" source="snippets/record-types/Program.cs" ID="GrowingDegreeDays":::

You can compare the number of degrees computed to the numbers generated with a higher baseline temperature. Remember that records are *reference types* and these copies are shallow copies. The array for the data isn't copied, but both records refer to the same data. That fact is an advantage in one other scenario. For growing degree days, it's useful to keep track of the total for the previous five days. You can create new records with different source data using `with` expressions. The following code builds a collection of these accumulations, then displays the values:

:::code language="csharp" source="snippets/record-types/Program.cs" ID="RunningFiveDayTotal":::

You can also use `with` expressions to create copies of records. Don't specify any properties between the braces for the `with` expression. That means create a copy, and don't change any properties:

```csharp
var growingDegreeDaysCopy = growingDegreeDays with { };
```

Run the finished application to see the results.

## Summary

This tutorial showed several aspects of records. Records provide concise syntax for types where the fundamental use is storing data. For object-oriented classes, the fundamental use is defining responsibilities. This tutorial focused on *positional records*, where you can use a concise syntax to declare the properties for a record. The compiler synthesizes several members of the record for copying and comparing records. You can add any other members you need for your record types. You can create immutable record types knowing that none of the compiler-generated members would mutate state. And `with` expressions make it easy to support non-destructive mutation.

Records add another way to define types. You use `class` definitions to create object-oriented hierarchies that focus on the responsibilities and behavior of objects. You create `struct` types for data structures that store data and are small enough to copy efficiently. You create `record` types when you want value-based equality and comparison, don't want to copy values, and want to use reference variables. You create `record struct` types when you want the features of records for a type that is small enough to copy efficiently.

You can learn more about records in the [C# language reference article for the record type](../../language-reference/builtin-types/record.md) and the [proposed record type specification](~/_csharplang/proposals/csharp-9.0/records.md) and [record struct specification](~/_csharplang/proposals/csharp-10.0/record-structs.md).
