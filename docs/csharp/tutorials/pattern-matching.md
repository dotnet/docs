title: Use pattern matching features to extend data types
description: This advanced tutorial demonstrates how to use pattern matching techniques to extend data types that .
ms.date: 02/19/2019
ms.custom: mvc
---
# Tutorial: Using pattern matching features to extend data types

C# 7 introduced basic pattern matching features. Those are extended in C# 8 with new expressions and patterns you can use to write functionality that behaves as though you extended types that may be in other libraries. Another use for patterns is to create functionality that your application requires but isn't a fundamental feature of the type being extended.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
> * Do awesome pattern things
> * understand pattern things
> * be awesome

## Prerequisites

You'll need to set up your machine to run .NET Core, including the C# 8.0 preview compiler. The C# 8 preview compiler is available with [Visual Studio 2019 preview 4](https://visualstudio.microsoft.com/vs/preview/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019+preview), or [.NET Core 3.0 preview 3](https://dotnet.microsoft.com/download/dotnet-core/3.0).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET Core CLI.

## Scenarios for pattern matching

Modern development often includes pulling data from multiple sources and presenting information and insights from that data in a cohesive application. You and your team won't have control or access for all the types that represent the incoming data.

The classic object oriented design would call for creating types in your application that represent each data type from those multiple data sources. Then, your application would work with those new types, building inheritance hierarchies, creating virtual methods, and implementing abstractions. Those techniques work, and sometimes they are the best tools. Other times you can write less code, and write more clear code using other techniques.

In this tutorial, you'll create and explore an application that takes incoming data from several external sources for a single scenario. You'll see how **pattern matching** provides an efficient way to consume and process that data in ways that weren't part of the original system.

Consider a major metro area that is using tolls and peak time pricing to manage traffic. You'll write an application that calculates tolls for a vehicle based on its type. Later enhancements will add pricing based on the time and the day of the week. Further enhancements will incorporate pricing based on the number of occupants in the vehicle.

From that brief description, you may have quickly sketched out  an object hierarchy to model this system. If you were building the entire system, and these were the only requirements, that would be a good solution. However, that's not the situation. This metro area had already been using software to manage vehicle registrations for years. In addition, this metro area bought different systems from different suppliers for personal cars, taxis, buses, and delivery trucks. These different systems all provide classes to represent the data they export. But these different systems don't provide a single object model for you to use.

## Pattern matching designs

The scenario used in this tutorial highlights the kinds of problems that are well suited to use pattern matching to solve: 

- The objects you need to work with aren't in an object hierarchy that matches your goals. You may be working with classes that are part of unrelated systems.
- The functionality you're adding isn't part of the core abstraction for these classes. The toll paid by a vehicle *changes* for different types of vehicles, but the toll is not a core function of the vehicle.

The pattern matching features in C# make it easier to build software when the *shape* of the data and the *operations* on that data are not described together.

## Implement the basic toll calculations

The most basic toll calculation relies only on the vehicle type.  THe base rate for a `Car` is `$2.00`, `$3.50` for a `Taxi`, `$5.00` for a `Bus`, and `$10.00` for a `DeliveryTruck`.  You can implement that using this version of a `TollCalculator` class:

```csharp
    public class TollCalculator
    {
        public decimal CalculateToll(object vehicle) =>
            vehicle switch
        {
            Car c => 2.00m,
            Taxi t => 3.50m,
            Bus b => 5.00m,
            DeliveryTruck t => 10.00m,
            { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
            null => throw new ArgumentNullException(nameof(vehicle))
        };
    }
```

The preceding code uses a **switch expression** that tests the **type pattern**. A **switch expression** begins with the variable, `vehicle` in the preceding code, followed by the `switch` keyword. Next comes all the cases inside curly braces. The `switch` expression makes other refinements to the ceremony that surrounded the `switch` statement. The `case` keyword is omitted, and the result of each case is an expression. The last two cases are also new. The `{ }` case matches any non-null object that didn't match an earlier case. This can catch any incorrect types passed to this method. Finally, the `null` pattern catches when `null` is passed to this method. The `null` pattern can be last because the other type patterns match only a non-null object of the correct type.

## Add occupancy pricing

Next, you can inspect the properties of the vehicles to add occupancy based pricing. The metro area adopted the following policies:

- Cars and taxis with no passengers pay an extra $0.50.
- Cars and taxis with 2 passengers get a 0.50 discount.
- Cars and taxis with 3 or more passengers get a $1.00 discount.
- Buses that are less than 50% full pay an extra $2.00.
- Buses that are more than 90% full get a $1.00 discount.

These rules can be implemented using the **property pattern** in the same switch expression. The property pattern examines properties of the object once the type has been determined.  The single case for a `Car` expands to four different cases:

```csharp
Car { Passengers: 0} => 2.00m + 0.50m,
Car { Passengers: 1 } => 2.0m,
Car { Passengers: 2} => 2.0m - 0.50m,
Car c when c.Passengers > 2 => 2.00m - 1.0m,
```

The first three cases test the type as a `Car`, then check the value of the `Passengers` property. If the type and the value of the property match, that expression is evaluated and returned. The final clause shows the `when` clause for a property pattern. You use the `when` clause to test conditions other than equality on a property. In the preceding example, the `when` clause tests to see that there are more than 2 passengers in the car. Strictly speaking, it's not necessary in this example.

You would also expand the cases for taxis in a similar manner:

```csharp
Taxi { Fares: 0} => 3.50m + 1.00m,
Taxi { Fares: 1 } => 3.50m,
Taxi { Fares: 2} => 3.50m - 0.50m,
Taxi t => 3.50m - 1.00m,
```

In the preceding example, the `when` clause was omitted on the final case.

You can finish implementing the occupancy rules by expanding the cases for buses, as shown in the following complete exmaple:

```csharp
public decimal CalculateToll(object vehicle) =>
    vehicle switch
{
    Car { Passengers: 0} => 2.00m + 0.50m,
    Car { Passengers: 1 } => 2.0m,
    Car { Passengers: 2} => 2.0m - 0.50m,
    Car c when c.Passengers > 2 => 2.00m - 1.0m,

    Taxi { Fares: 0} => 3.50m + 1.00m,
    Taxi { Fares: 1 } => 3.50m,
    Taxi { Fares: 2} => 3.50m - 0.50m,
    Taxi t => 3.50m - 1.00m,

    Bus b when ((double)b.Riders / (double)b.Capacity) < 0.50 => 5.00m + 2.00m,
    Bus b when ((double)b.Riders / (double)b.Capacity) > 0.90 => 5.00m - 1.00m, 
    Bus b => 5.00m,

    DeliveryTruck t => 10.00m,
    { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: nameof(vehicle)),
    null => throw new ArgumentNullException(nameof(vehicle))
};
```

## Add peak pricing

For the final feature, the toll authority wants to add time sensitive peak pricing. During the morning and evening rush hours, the tolls are doubled. That rule only affects traffic in one direction: inbound to the city in the morning, and outbound in the evening rush hour. During other times during the workday, tolls increase by 50%. Late night and early morning, tolls are reduced by 25%. During the weekend, it's the normal rate.

You will use pattern matching for this feature, but you'll integrate it with other techniques. You could build a single pattern match expression that would account all the combinations of direction, day of the week, and time. The result would be a very complicated expression. It would be hard to read and difficult to understand. As a result, it would be hard to ensure it was correct.

Instead, you can simplify the combinations by creating two different variables.  The following function uses as pattern matching switch expression to express whether a `DateTime` represents a weekend or a weekday:

```csharp
private static bool isWeekDay(DateTime timeOfToll) =>
    timeOfToll.DayOfWeek switch
{
    DayOfWeek.Saturday => false,
    DayOfWeek.Sunday => false,
    _ => true
};
```

Next, add a similar function to categorize the time into one of several blocks:

```csharp
private static TimeBand TimeBlock(DateTime timeOfToll)
{
    int hour = timeOfToll.Hour;
    if (hour < 6) return TimeBand.Overnight;
    else if (hour < 10) return TimeBand.MorningRush;
    else if (hour < 4) return TimeBand.Daytime;
    else if (hour < 8) return TimeBand.EveningRush;
    else return TimeBand.Overnight;
}
```

The previous method doesn't use pattern matching. It's more clear using a familiar cascade of `if` statements.

You can combine those methods to build a tuple of values that concisely describes all those states and uses pattern matching to calculate a multiplier for the toll.

.. Describe combinations
.. Add table of results
.. combine to shorter code.
.. tuple pattern. Cool!

```csharp
```

This example highlights one of the advantages of pattern matching. The pattern branches are evaluated in order. If you rearrange them so that an earlier branch handles one of your later cases, the compiler warns you. The language rules help you combine separate cases. <expand with example>,

You can combine this code with the previous pattern matching expression to build the following method that computes the tolls:

```csharp
```

## Next staps

You can run the code <here> in our GitHub repo. Explore patterns on your own and add this tecnique into your regular coding activities.
