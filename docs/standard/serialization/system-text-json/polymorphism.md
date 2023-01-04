---
title: How to serialize properties of derived classes with System.Text.Json
description: "Learn how to serialize polymorphic objects while serializing to and deserializing from JSON in .NET."
ms.date: 09/30/2022
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to serialize properties of derived classes with System.Text.Json

In this article, you will learn how to serialize properties of derived classes with the `System.Text.Json` namespace.

## Serialize properties of derived classes

:::zone pivot="dotnet-core-3-1,dotnet-5-0,dotnet-6-0"

In versions prior to .NET 7, `System.Text.Json` _doesn't support_ the serialization of polymorphic type hierarchies. For example, if a property's type is an interface or an abstract class, only the properties defined on the interface or abstract class are serialized, even if the runtime type has additional properties. The exceptions to this behavior are explained in this section. For information about support in .NET 7, see [Polymorphic serialization in .NET 7](polymorphism.md?pivots=dotnet-7-0).

For example, suppose you have a `WeatherForecast` class and a derived class `WeatherForecastDerived`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WF":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFDerived":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFDerived":::

And suppose the type argument of the `Serialize` method at compile time is `WeatherForecast`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeDefault":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeDefault":::

In this scenario, the `WindSpeed` property is not serialized even if the `weatherForecast` object is a `WeatherForecastDerived` object. Only the base class properties are serialized:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot"
}
```

This behavior is intended to help prevent accidental exposure of data in a derived runtime-created type.

To serialize the properties of the derived type in the preceding example, use one of the following approaches:

* Call an overload of <xref:System.Text.Json.JsonSerializer.Serialize%2A> that lets you specify the type at run time:

  :::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeGetType":::
  :::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeGetType":::

* Declare the object to be serialized as `object`.

  :::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeObject":::
  :::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeObject":::

In the preceding example scenario, both approaches cause the `WindSpeed` property to be included in the JSON output:

```json
{
  "WindSpeed": 35,
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot"
}
```

> [!IMPORTANT]
> These approaches provide polymorphic serialization only for the root object to be serialized, not for properties of that root object.

You can get polymorphic serialization for lower-level objects if you define them as type `object`. For example, suppose your `WeatherForecast` class has a property named `PreviousForecast` that can be defined as type `WeatherForecast` or `object`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithPrevious":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPrevious":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithPreviousAsObject":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPreviousAsObject":::

If the `PreviousForecast` property contains an instance of `WeatherForecastDerived`:

* The JSON output from serializing `WeatherForecastWithPrevious` **doesn't include** `WindSpeed`.
* The JSON output from serializing `WeatherForecastWithPreviousAsObject` **includes** `WindSpeed`.

To serialize `WeatherForecastWithPreviousAsObject`, it isn't necessary to call `Serialize<object>` or `GetType` because the root object isn't the one that may be of a derived type. The following code example doesn't call `Serialize<object>` or `GetType`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeSecondLevel":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeSecondLevel":::

The preceding code correctly serializes `WeatherForecastWithPreviousAsObject`:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "PreviousForecast": {
    "WindSpeed": 35,
    "Date": "2019-08-01T00:00:00-07:00",
    "TemperatureCelsius": 25,
    "Summary": "Hot"
  }
}
```

The same approach of defining properties as `object` works with interfaces. Suppose you have the following interface and implementation, and you want to serialize a class with properties that contain implementation instances:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/IForecast.cs":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/IForecast.vb":::

When you serialize an instance of `Forecasts`, only `Tuesday` shows the `WindSpeed` property, because `Tuesday` is defined as `object`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeInterface":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeInterface":::

The following example shows the JSON that results from the preceding code:

```json
{
  "Monday": {
    "Date": "2020-01-06T00:00:00-08:00",
    "TemperatureCelsius": 10,
    "Summary": "Cool"
  },
  "Tuesday": {
    "Date": "2020-01-07T00:00:00-08:00",
    "TemperatureCelsius": 11,
    "Summary": "Rainy",
    "WindSpeed": 10
  }
}
```

> [!NOTE]
> This article is about serialization, not deserialization. Polymorphic deserialization is not supported in versions prior to .NET 7, but as a workaround you can write a custom converter, such as the example in [Support polymorphic deserialization](converters-how-to.md#support-polymorphic-deserialization). For more information about how .NET 7 supports polymorphic serialization and deserialization, see [How to serialize properties of derived classes with System.Text.Json in .NET 7](polymorphism.md?pivots=dotnet-7-0).

:::zone-end
:::zone pivot="dotnet-7-0"

Beginning with .NET 7, `System.Text.Json` supports polymorphic type hierarchy serialization and deserialization with attribute annotations.

| Attribute | Description |
|--|--|
| <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute> | When placed on a type declaration, indicates that the specified subtype should be opted into polymorphic serialization. It also exposes the ability to specify a type discriminator. |
| <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute> | When placed on a type declaration, indicates that the type should be serialized polymorphically. It also exposes various options to configure polymorphic serialization and deserialization for that type. |

For example, suppose you have a `WeatherForecastBase` class and a derived class `WeatherForecastWithCity`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFB":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFB":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWC":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWC":::

And suppose the type argument of the `Serialize<TValue>` method at compile time is `WeatherForecastBase`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializePolymorphic.cs" id="SerializeWithAttributeAnnotations":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializePolymorphic.vb" id="SerializeWithAttributeAnnotations":::

In this scenario, the `City` property is serialized because the `weatherForecastBase` object is actually a `WeatherForecastWithCity` object. This configuration enables polymorphic serialization for `WeatherForecastBase`, specifically when the runtime type is `WeatherForecastWithCity`:

```json
{
  "City": "Milwaukee",
  "Date": "2022-09-26T00:00:00-05:00",
  "TemperatureCelsius": 15,
  "Summary": "Cool"
}
```

While round-tripping of the payload as `WeatherForecastBase` is supported, it won't materialize as a run-time type of `WeatherForecastWithCity`. Instead, it will materialize as a run-time type of `WeatherForecastBase`:

```csharp
WeatherForecastBase value = JsonSerializer.Deserialize<WeatherForecastBase>("""
    {
      "City": "Milwaukee",
      "Date": "2022-09-26T00:00:00-05:00",
      "TemperatureCelsius": 15,
      "Summary": "Cool"
    }
    """);

Console.WriteLine(value is WeatherForecastWithCity); // False
```

```vb
Dim value As WeatherForecastBase = JsonSerializer.Deserialize(@"
    {
      "City": "Milwaukee",
      "Date": "2022-09-26T00:00:00-05:00",
      "TemperatureCelsius": 15,
      "Summary": "Cool"
    }")

Console.WriteLine(value is WeatherForecastWithCity) // False
```

The following section describes how to add metadata to enable round-tripping of the derived type.

## Polymorphic type discriminators

To enable polymorphic deserialization, you must specify a type discriminator for the derived class:

```csharp
[JsonDerivedType(typeof(WeatherForecastBase), typeDiscriminator: "base")]
[JsonDerivedType(typeof(WeatherForecastWithCity), typeDiscriminator: "withCity")]
public class WeatherForecastBase
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string? Summary { get; set; }
}

public class WeatherForecastWithCity : WeatherForecastBase
{
    public string? City { get; set; }
}
```

```vb
<JsonDerivedType(GetType(WeatherForecastBase), "base")>
<JsonDerivedType(GetType(WeatherForecastWithCity), "withCity")>
Public Class WeatherForecastBase
    Public Property [Date] As DateTimeOffset
    Public Property TemperatureCelsius As Integer
    Public Property Summary As String
End Class

Public Class WeatherForecastWithCity
    Inherits WeatherForecastBase
    Public Property City As String
End Class
```

With the added metadata, specifically, the type discriminator, the serializer can serialize and deserialize the payload as the `WeatherForecastWithCity` type from its base type `WeatherForecastBase`. Serialization will emit JSON along with the type discriminator metadata:

```csharp
WeatherForecastBase weather = new WeatherForecastWithCity
{
    City = "Milwaukee",
    Date = new DateTimeOffset(2022, 9, 26, 0, 0, 0, TimeSpan.FromHours(-5)),
    TemperatureCelsius = 15,
    Summary = "Cool"
}
var json = JsonSerializer.Serialize<WeatherForecastBase>(weather, options);
Console.WriteLine(json);
// Sample output:
//   {
//     "$type" : "withCity",
//     "City": "Milwaukee",
//     "Date": "2022-09-26T00:00:00-05:00",
//     "TemperatureCelsius": 15,
//     "Summary": "Cool"
//   }
```

```vb
Dim weather As WeatherForecastBase = New WeatherForecastWithCity With
{
    .City = "Milwaukee",
    .[Date] = New DateTimeOffset(2022, 9, 26, 0, 0, 0, TimeSpan.FromHours(-5)),
    .TemperatureCelsius = 15,
    .Summary = "Cool"
}
Dim json As String = JsonSerializer.Serialize(weather, options)
Console.WriteLine(json)
' Sample output:
'   {
'     "$type" : "withCity",
'     "City": "Milwaukee",
'     "Date": "2022-09-26T00:00:00-05:00",
'     "TemperatureCelsius": 15,
'     "Summary": "Cool"
'   }
```

With the type discriminator, the serializer can deserialize the payload polymorphically as `WeatherForecastWithCity`:

```csharp
WeatherForecastBase value = JsonSerializer.Deserialize<WeatherForecastBase>(json);
Console.WriteLine(value is WeatherForecastWithCity); // True
```

> [!NOTE]
> The type discriminator must be placed at the start of the JSON object, grouped together with other metadata properties like `$id` and `$ref`.

```vb
Dim value As WeatherForecastBase = JsonSerializer.Deserialize(json)
Console.WriteLine(value is WeatherForecastWithCity) // True
```

### Mix and match type discriminator formats

Type discriminator identifiers are valid in either `string` or `int` forms, so the following is valid:

```csharp
[JsonDerivedType(typeof(WeatherForecastWithCity), 0)]
[JsonDerivedType(typeof(WeatherForecastWithTimeSeries), 1)]
[JsonDerivedType(typeof(WeatherForecastWithLocalNews), 2)]
public class WeatherForecastBase { }

var json = JsonSerializer.Serialize(new WeatherForecastWithTimeSeries());
Console.WriteLine(json);
// Sample output:
//   {
//    "$type" : 1,
//    Omitted for brevity...
//   }
```

```vb
<JsonDerivedType(GetType(WeatherForecastWithCity), 0)>
<JsonDerivedType(GetType(WeatherForecastWithTimeSeries), 1)>
<JsonDerivedType(GetType(WeatherForecastWithLocalNews), 2)>
Public Class WeatherForecastBase
End Class

Dim json As String = JsonSerializer.Serialize(New WeatherForecastWithTimeSeries())
Console.WriteLine(json)
' Sample output:
'  {
'    "$type" : 1,
'    Omitted for brevity...
'  }
```

While the API supports mixing and matching type discriminator configurations, it's not recommended. The general recommendation is to use either all `string` type discriminators, all `int` type discriminators, or no discriminators at all. The following example shows how to mix and match type discriminator configurations:

```csharp
[JsonDerivedType(typeof(ThreeDimensionalPoint), typeDiscriminator: 3)]
[JsonDerivedType(typeof(FourDimensionalPoint), typeDiscriminator: "4d")]
public class BasePoint
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class ThreeDimensionalPoint : BasePoint
{
    public int Z { get; set; }
}

public sealed class FourDimensionalPoint : ThreeDimensionalPoint
{
    public int W { get; set; }
}
```

```vb
<JsonDerivedType(GetType(ThreeDimensionalPoint), 3)>
<JsonDerivedType(GetType(FourDimensionalPoint), "4d")>
Public Class BasePoint
    Public Property X As Integer
    Public Property Y As Integer
End Class

Public Class ThreeDimensionalPoint
    Inherits BasePoint
    Public Property Z As Integer
End Class

Public NotInheritable Class FourDimensionalPoint
    Inherits ThreeDimensionalPoint
    Public Property W As Integer
End Class
```

In the preceding example, the `BasePoint` type doesn't have a type discriminator, while the `ThreeDimensionalPoint` type has an `int` type discriminator, and the `FourDimensionalPoint` has a `string` type discriminator.

> [!IMPORTANT]
> For polymorphic serialization to work, the type of the serialized value should be that of the polymorphic base type. This includes using the base type as the generic type parameter when serializing root-level values, as the declared type of serialized properties, or as the collection element in serialized collections.

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;

PerformRoundTrip<BasePoint>();
PerformRoundTrip<ThreeDimensionalPoint>();
PerformRoundTrip<FourDimensionalPoint>();

static void PerformRoundTrip<T>() where T : BasePoint, new()
{
    var json = JsonSerializer.Serialize<BasePoint>(new T());
    Console.WriteLine(json);

    BasePoint? result = JsonSerializer.Deserialize<BasePoint>(json);
    Console.WriteLine($"result is {typeof(T)}; // {result is T}");
    Console.WriteLine();
}
// Sample output:
//   { "X": 541, "Y": 503 }
//   result is BasePoint; // True
//
//   { "$type": 3, "Z": 399, "X": 835, "Y": 78 }
//   result is ThreeDimensionalPoint; // True
//
//   { "$type": "4d", "W": 993, "Z": 427, "X": 508, "Y": 741 }
//   result is FourDimensionalPoint; // True
```

```vb
Imports System.Text.Json
Imports System.Text.Json.Serialization

Module Program
    Sub Main()
        PerformRoundTrip(Of BasePoint)()
        PerformRoundTrip(Of ThreeDimensionalPoint)()
        PerformRoundTrip(Of FourDimensionalPoint)()
    End Sub

    Private Sub PerformRoundTrip(Of T As {BasePoint, New})()
        Dim json = JsonSerializer.Serialize(Of BasePoint)(New T())
        Console.WriteLine(json)

        Dim result As BasePoint = JsonSerializer.Deserialize(Of BasePoint)(json)
        Console.WriteLine($"result is {GetType(T)}; // {TypeOf result Is T}")
        Console.WriteLine()
    End Sub
End Module
' Sample output:
'   { "X": 649, "Y": 754 }
'   result is BasePoint; // True
'
'   { "$type": 3, "Z": 247, "X": 814, "Y": 56 }
'   result is ThreeDimensionalPoint; // True
'
'   { "$type": "4d", "W": 427, "Z": 193, "X": 112, "Y": 935 }
'   result is FourDimensionalPoint; // True
```

### Customize the type discriminator name

The default property name for the type discriminator is `$type`. To customize the property name, use the <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute> as shown in the following example:

```csharp
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$discriminator")]
[JsonDerivedType(typeof(ThreeDimensionalPoint), typeDiscriminator: "3d")]
public class BasePoint
{
    public int X { get; set; }
    public int Y { get; set; }
}

public sealed class ThreeDimensionalPoint : BasePoint
{
    public int Z { get; set; }
}
```

```vb
<JsonPolymorphic(TypeDiscriminatorPropertyName:="$discriminator")>
<JsonDerivedType(GetType(ThreeDimensionalPoint), "3d")>
Public Class BasePoint
    Public Property X As Integer
    Public Property Y As Integer
End Class

Public Class ThreeDimensionalPoint
    Inherits BasePoint
    Public Property Z As Integer
End Class
```

In the preceding code, the `JsonPolymorphic` attribute configures the `TypeDiscriminatorPropertyName` to the `"$discriminator"` value. With the type discriminator name configured, the following example shows the `ThreeDimensionalPoint` type serialized as JSON:

```csharp
BasePoint point = new ThreeDimensionalPoint { X = 1, Y = 2, Z = 3 };
var json = JsonSerializer.Serialize<BasePoint>(point);
Console.WriteLine(json);
// Sample output:
//  { "$discriminator": "3d", "X": 1, "Y": 2, "Z": 3 }
```

```vb
Dim point As BasePoint = New ThreeDimensionalPoint With { .X = 1, .Y = 2, .Z = 3 }
Dim json As String = JsonSerializer.Serialize(Of BasePoint)(point)
Console.WriteLine(json)
' Sample output:
'  { "$discriminator": "3d", "X": 1, "Y": 2, "Z": 3 }
```

> [!TIP]
> Avoid using a <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute.TypeDiscriminatorPropertyName?displayProperty=nameWithType> that conflicts with a property in your type hierarchy.

### Handle unknown derived types

To handle unknown derived types, you must opt into such support using an annotation on the base type. Consider the following type hierarchy:

```csharp
[JsonDerivedType(typeof(ThreeDimensionalPoint))]
public class BasePoint
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class ThreeDimensionalPoint : BasePoint
{
    public int Z { get; set; }
}

public class FourDimensionalPoint : ThreeDimensionalPoint
{
    public int W { get; set; }
}
```

```vb
<JsonDerivedType(GetType(ThreeDimensionalPoint))>
Public Class BasePoint
    Public Property X As Integer
    Public Property Y As Integer
End Class

Public Class ThreeDimensionalPoint
    Inherits BasePoint
    Public Property Z As Integer
End Class

Public NotInheritable Class FourDimensionalPoint
    Inherits ThreeDimensionalPoint
    Public Property W As Integer
End Class
```

Since the configuration does not explicitly opt-in support for `FourDimensionalPoint`, attempting to serialize instances of `FourDimensionalPoint` as `BasePoint` will result in a run-time exception:

```csharp
JsonSerializer.Serialize<BasePoint>(new FourDimensionalPoint()); // throws NotSupportedException
```

```vb
JsonSerializer.Serialize(Of BasePoint)(New FourDimensionalPoint()) ' throws NotSupportedException
```

You can change the default behavior by using the <xref:System.Text.Json.Serialization.JsonUnknownDerivedTypeHandling> enum, which can be specified as follows:

```csharp
[JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
[JsonDerivedType(typeof(ThreeDimensionalPoint))]
public class BasePoint
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class ThreeDimensionalPoint : BasePoint
{
    public int Z { get; set; }
}

public class FourDimensionalPoint : ThreeDimensionalPoint
{
    public int W { get; set; }
}
```

```vb
<JsonPolymorphic(
    UnknownDerivedTypeHandling:=JsonUnknownDerivedTypeHandling.FallBackToBaseType)>
<JsonDerivedType(GetType(ThreeDimensionalPoint))>
Public Class BasePoint
    Public Property X As Integer
    Public Property Y As Integer
End Class

Public Class ThreeDimensionalPoint
    Inherits BasePoint
    Public Property Z As Integer
End Class

Public NotInheritable Class FourDimensionalPoint
    Inherits ThreeDimensionalPoint
    Public Property W As Integer
End Class
```

Instead of falling back to the base type, you can use the `FallBackToNearestAncestor` setting to fall back to the contract of the nearest declared derived type:

```csharp
[JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(BasePoint)]
public interface IPoint { }

public class BasePoint : IPoint { }

public class ThreeDimensionalPoint : BasePoint { }
```

```vb
<JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)>
<JsonDerivedType(GetType(BasePoint)>
Public Interface IPoint
End Interface

Public Class BasePoint
    Inherits IPoint
End Class

Public Class ThreeDimensionalPoint
    Inherits BasePoint
End Class
```

With a configuration like the preceding example, the `ThreeDimensionalPoint` type will be serialized as `BasePoint`:

```csharp
// Serializes using the contract for BasePoint
JsonSerializer.Serialize<IPoint>(new ThreeDimensionalPoint());
```

```vb
' Serializes using the contract for BasePoint
JsonSerializer.Serialize(Of IPoint)(New ThreeDimensionalPoint())
```

However, falling back to the nearest ancestor admits the possibility of "diamond" ambiguity. Consider the following type hierarchy as an example:

```csharp
[JsonPolymorphic(
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)]
[JsonDerivedType(typeof(BasePoint))]
[JsonDerivedType(typeof(IPointWithTimeSeries))]
public interface IPoint { }

public interface IPointWithTimeSeries : IPoint { }

public class BasePoint : IPoint { }

public class BasePointWithTimeSeries : BasePoint, IPointWithTimeSeries { }
```

```vb
<JsonPolymorphic(
    UnknownDerivedTypeHandling:=JsonUnknownDerivedTypeHandling.FallBackToNearestAncestor)>
<JsonDerivedType(GetType(BasePoint))>
<JsonDerivedType(GetType(IPointWithTimeSeries))>
Public Interface IPoint
End Interface

Public Interface IPointWithTimeSeries
    Inherits IPoint
End Interface

Public Class BasePoint
    Implements IPoint
End Class

Public Class BasePointWithTimeSeries
    Inherits BasePoint
    Implements IPointWithTimeSeries
End Class
```

In this case, the `BasePointWithTimeSeries` type could be serialized as either `BasePoint` or `IPointWithTimeSeries` since they are both direct ancestors. This ambiguity will cause the <xref:System.NotSupportedException> to be thrown when attempting to serialize an instance of `BasePointWithTimeSeries` as `IPoint`.

```csharp
// throws NotSupportedException
JsonSerializer.Serialize<IPoint>(new BasePointWithTimeSeries());
```

```vb
' throws NotSupportedException
JsonSerializer.Serialize(Of IPoint)(New BasePointWithTimeSeries())
```

## Configure polymorphism with the contract model

For use cases where attribute annotations are impractical or impossible (such as large domain models, cross-assembly hierarchies, or hierarchies in third-party dependencies), to configure polymorphism use the [contract model](custom-contracts.md). The contract model is a set of APIs that can be used to configure polymorphism in a type hierarchy by creating a custom <xref:System.Text.Json.Serialization.Metadata.DefaultJsonTypeInfoResolver> subclass that dynamically provides polymorphic configuration per type, as shown in the following example:

```csharp
public class PolymorphicTypeResolver : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

        Type basePointType = typeof(BasePoint);
        if (jsonTypeInfo.Type == basePointType)
        {
            jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                TypeDiscriminatorPropertyName = "$point-type",
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
                DerivedTypes =
                {
                    new JsonDerivedType(typeof(ThreeDimensionalPoint), "3d"),
                    new JsonDerivedType(typeof(FourDimensionalPoint), "4d")
                }
            };
        }

        return jsonTypeInfo;
    }
}
```

```vb
Public Class PolymorphicTypeResolver
    Inherits DefaultJsonTypeInfoResolver

    Public Overrides Function GetTypeInfo(
        ByVal type As Type,
        ByVal options As JsonSerializerOptions) As JsonTypeInfo

        Dim jsonTypeInfo As JsonTypeInfo = MyBase.GetTypeInfo(type, options)
        Dim basePointType As Type = GetType(BasePoint)

        If jsonTypeInfo.Type = basePointType Then
            jsonTypeInfo.PolymorphismOptions = New JsonPolymorphismOptions With {
                .TypeDiscriminatorPropertyName = "$point-type",
                .IgnoreUnrecognizedTypeDiscriminators = True,
                .UnknownDerivedTypeHandling =
                    JsonUnknownDerivedTypeHandling.FailSerialization
            }
            jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(
                New JsonDerivedType(GetType(ThreeDimensionalPoint), "3d"))
            jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(
                New JsonDerivedType(GetType(FourDimensionalPoint), "4d"))
        End If

        Return jsonTypeInfo
    End Function
End Class
```

### Additional polymorphic serialization details

* Polymorphic serialization supports derived types that have been explicitly opted in via the <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute>. Undeclared types will result in a run-time exception. The behavior can be changed by configuring the <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute.UnknownDerivedTypeHandling?displayProperty=nameWithType> property.
* Polymorphic configuration specified in derived types is not inherited by polymorphic configuration in base types. The base type must be configured independently.
* Polymorphic hierarchies are supported for both `interface` and `class` types.
* Polymorphism using type discriminators is only supported for type hierarchies that use the default converters for objects, collections, and dictionary types.
* Polymorphism is supported in metadata-based source generation, but not fast-path source generation.

:::zone-end

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
* [Instantiate JsonSerializerOptions instances](configure-options.md)
* [Enable case-insensitive matching](character-casing.md)
* [Customize property names and values](customize-properties.md)
* [Ignore properties](ignore-properties.md)
* [Allow invalid JSON](invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](handle-overflow.md)
* [Preserve references and handle circular references](preserve-references.md)
* [Deserialize to immutable types and non-public accessors](immutability.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](migrate-from-newtonsoft.md)
* [Customize character encoding](character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](converters-how-to.md)
* [DateTime and DateTimeOffset support](../../datetime/system-text-json-support.md)
* [How to use source generation](source-generation.md)
* [Supported collection types](supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
