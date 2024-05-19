---
title: "Breaking change: System.Formats.Cbor DateTimeOffset formatting change"
description: Learn about the .NET 8 breaking change in .NET extensions where System.Formats.Cbor always formats and parses DateTimeOffset values using the invariant culture.
ms.date: 11/02/2023
---
# System.Formats.Cbor DateTimeOffset formatting change

Since it was released in .NET 5, the System.Formats.Cbor NuGet package included built-in methods for serializing and deserializing DateTimeOffset values according to RFC 7049. Unfortunately, the implementations didn't use invariant culture when formatting and parsing DateTimeOffset values. This resulted in inconsistent or even incorrect date encodings on machines with cultures that use non-Gregorian calendars.

The behavior has been changed so that invariant culture is always used when parsing and formatting DateTimeOffset values. This change might break your code if you relied on the previous behavior. Also, it might be impossible to read date values that were encoded with earlier versions of the System.Formats.Cbor NuGet package.

## Version introduced

.NET 8

## Previous behavior

Consider this code that parses a DateTimeOffset value from a string and then encodes it using CBOR:

```csharp
// Install a culture with a non-Gregorian calendar
var culture = new CultureInfo("he-IL");
culture.DateTimeFormat.Calendar = new HebrewCalendar();
Thread.CurrentThread.CurrentCulture = culture;

DateTimeOffset value = DateTimeOffset.Parse("2020-04-09T14:31:21.3535941+01:00", CultureInfo.InvariantCulture);

var writer = new CborWriter();
writer.WriteDateTimeOffset(value);
byte[] cborEncoding = writer.Encode();

Console.WriteLine(Convert.ToHexString(cborEncoding));
```

Previously, this code produced the following CBOR encoding:

`C07828D7AAD7A922D7A42DD796272DD79822D7955431343A33313A32312E333533353934312B30313A3030`

This encoding corresponds to `0(תש\"פ-ז'-ט\"וT14:31:21.3535941+01:00)` in CBOR diagnostic notation, which is an invalid date representation per RFC 7049.

## New behavior

Starting in .NET 8, the same code produces the following CBOR encoding:

`C07821323032302D30342D30395431343A33313A32312E333533353934312B30313A3030`

This encoding corresponds to `0("2020-04-09T14:31:21.3535941+01:00")` in CBOR diagnostic notation.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous behavior produced invalid date encodings per RFC 7049.

## Recommended action

You might have to be able to read CBOR date encodings that were persisted using earlier versions of System.Formats.Cbor if you don't upgrade to the latest version of the System.Formats.Cbor NuGet package.

Alternatively, you can change your code to use the following extension method:

```csharp
public static class CborReaderExtensions
{
    private const string Rfc3339FormatString = "yyyy-MM-ddTHH:mm:ss.FFFFFFFK";

    public static DateTimeOffset ReadDateTimeOffsetReplacement(this CborReader reader, CultureInfo? cultureInfo = null)
    {
        CborTag tag = reader.PeekTag();
        if (tag != CborTag.DateTimeString)
        {
            throw new InvalidOperationException($"Expected CborTag {(int)CborTag.DateTimeString}");
        }

        reader.ReadTag();
        string dateString = reader.ReadTextString();
        return DateTimeOffset.ParseExact(dateString, Rfc3339FormatString, cultureInfo, DateTimeStyles.    RoundtripKind);
    }
}
```

Use this extension method to read a CBOR date encoding as follows:

```csharp
var reader = new CborReader(cborEncoding);
DateTimeOffset date = reader.ReadDateTimeOffsetReplacement(culture);
Console.WriteLine(date.ToString(CultureInfo.InvariantCulture));
```

## Affected APIs

- <xref:System.Formats.Cbor.CborWriter.WriteDateTimeOffset(System.DateTimeOffset)?displayProperty=fullName>
- <xref:System.Formats.Cbor.CborReader.ReadDateTimeOffset?displayProperty=fullName>
