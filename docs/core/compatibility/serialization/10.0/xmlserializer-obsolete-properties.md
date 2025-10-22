---
title: "Breaking change: XmlSerializer no longer ignores properties marked with ObsoleteAttribute"
description: "Learn about the breaking change in .NET 10 where properties marked with ObsoleteAttribute are now serialized by XmlSerializer instead of being ignored."
ms.date: 10/21/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/49054
---
# XmlSerializer no longer ignores properties marked with ObsoleteAttribute

Starting in .NET 10, the behavior of <xref:System.Xml.Serialization.XmlSerializer> has changed with respect to how it handles properties marked with the <xref:System.ObsoleteAttribute> attribute. Previously, properties marked with `[Obsolete]` were treated as if they were also marked with `[XmlIgnore]`, causing them to be excluded from XML serialization. This behavior was unintended and has been corrected.

With this change, properties marked with `[Obsolete]` are now serialized by default unless the <xref:System.ObsoleteAttribute.IsError> property is set to `true`. If `IsError` is `true`, the serializer throws an <xref:System.InvalidOperationException> during creation. Additionally, an AppContext switch, `Switch.System.Xml.IgnoreObsoleteMembers`, has been introduced to allow developers to revert to the previous behavior, if necessary.

## Version introduced

.NET 10 Preview 1

## Previous behavior

In previous versions of .NET, properties marked with the `[Obsolete]` attribute were excluded from XML serialization, similar to properties marked with `[XmlIgnore]`. This behavior was unexpected and not aligned with the intended purpose of the `[Obsolete]` attribute, which is to provide compile-time warnings about deprecated APIs.

```csharp
public class Example
{
    public string NormalProperty { get; set; } = "normal";
    
    [Obsolete("This property is deprecated")]
    public string ObsoleteProperty { get; set; } = "obsolete";
    
    [XmlIgnore]
    public string IgnoredProperty { get; set; } = "ignored";
}

var obj = new Example();
var serializer = new XmlSerializer(typeof(Example));
using var writer = new StringWriter();
serializer.Serialize(writer, obj);
Console.WriteLine(writer.ToString());
```

**Output before the change:**

```xml
<Example>
  <NormalProperty>normal</NormalProperty>
</Example>
```

## New behavior

Starting in .NET 10, properties marked with `[Obsolete]` are no longer excluded from XML serialization by default. Instead:

- If the `[Obsolete]` attribute is applied with `IsError = false` (default), the property is serialized normally.
- If the `[Obsolete]` attribute is applied with `IsError = true`, the <xref:System.Xml.Serialization.XmlSerializer> throws an <xref:System.InvalidOperationException> during serializer creation.

Using the same code as shown in the previous behavior section, the output after the change is:

```xml
<Example>
  <NormalProperty>normal</NormalProperty>
  <ObsoleteProperty>obsolete</ObsoleteProperty>
</Example>
```

If the AppContext switch `Switch.System.Xml.IgnoreObsoleteMembers` is enabled, the previous behavior is restored:

```csharp
AppContext.SetSwitch("Switch.System.Xml.IgnoreObsoleteMembers", true);

var obj = new Example();
var serializer = new XmlSerializer(typeof(Example));
using var writer = new StringWriter();
serializer.Serialize(writer, obj);
Console.WriteLine(writer.ToString());
```

**Output with AppContext switch enabled:**

```xml
<Example>
  <NormalProperty>normal</NormalProperty>
</Example>
```

If `[Obsolete(IsError = true)]` is applied to a property, the following exception is thrown during serializer creation:

```
System.InvalidOperationException: Cannot serialize member 'ObsoleteProperty' because it is marked with ObsoleteAttribute and IsError is set to true.
```

> [!NOTE]
> Properties that are marked as `[Obsolete]` have always successfully deserialized when data is present in the XML. While this change allows `[Obsolete]` properties to "round trip" from object to XML and back to object, the new behavior affects only the serialization half (object to XML) of the "round trip."

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior of treating `[Obsolete]` as equivalent to `[XmlIgnore]` was unintended and inconsistent with the purpose of the `[Obsolete]` attribute. This change ensures that `[Obsolete]` is used solely for its intended purpose of providing compile-time warnings and doesn't affect runtime serialization behavior. The introduction of the AppContext switch allows developers to opt in to the legacy behavior if necessary.

## Recommended action

Review your codebase for any reliance on the previous behavior where `[Obsolete]` properties were excluded from XML serialization. If this behavior is still desired, enable the AppContext switch `Switch.System.Xml.IgnoreObsoleteMembers` as follows:

```csharp
AppContext.SetSwitch("Switch.System.Xml.IgnoreObsoleteMembers", true);
```

If any properties are marked with `[Obsolete(IsError = true)]` and are being serialized, update the code to either remove the `[Obsolete]` attribute or set `IsError = false` to avoid runtime exceptions.

## Affected APIs

- <xref:System.Xml.Serialization.XmlSerializer?displayProperty=fullName>
