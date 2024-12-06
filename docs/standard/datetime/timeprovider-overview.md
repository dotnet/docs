---
title: What is the TimeProvider class
description: Learn about the TimeProvider class in .NET and .NET Framework. TimeProvider provides an abstraction over time.
ms.date: 12/03/2024
ms.topic: overview
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "TimeProvider class"
  - "date and time classes [.NET]"
#customer intent: As a developer, I want to understand what TimeProvider is so that I can use it.
---

# What is TimeProvider?

The <xref:System.TimeProvider?displayProperty=fullName> class was introduced in .NET 8 and is also available for .NET Framework 4.7+ and .NET Standard 2.0 as a NuGet package. `TimeProvider` is an abstraction of time that provides a point in time as a <xref:System.DateTimeOffset> type. By using `TimeProvider` to retrieve a `DateTimeOffset`, you ensure that your code is testable and predictable.

The <xref:System.TimeProvider> class defines the following capabilities:

- Provides access to the date and time through <xref:System.TimeProvider.GetUtcNow?displayProperty=nameWithType> and <xref:System.TimeProvider.GetLocalNow?displayProperty=nameWithType>.
- High-frequency timestamps with <xref:System.TimeProvider.GetTimestamp?displayProperty=nameWithType>.
- Measure time between two timestamps with <xref:System.TimeProvider.GetElapsedTime*?displayProperty=nameWithType>.
- High-resolution timers with <xref:System.TimeProvider.CreateTimer(System.Threading.TimerCallback,System.Object,System.TimeSpan,System.TimeSpan)?displayProperty=nameWithType>.
- Get the current timezone with <xref:System.TimeProvider.LocalTimeZone?displayProperty=nameWithType>.

## Default implementation

.NET provides an implementation of <xref:System.TimeProvider> through the <xref:System.TimeProvider.System?displayProperty=nameWithType> property, using the following characteristics:

- Date and time are calculated with <xref:System.DateTimeOffset.UtcNow?displayProperty=nameWithType> and <xref:System.TimeZoneInfo.Local?displayProperty=nameWithType>.
- Timestamps are provided by <xref:System.Diagnostics.Stopwatch?displayProperty=fullName>.
- Timers are implemented through an internal class and exposed as <xref:System.Threading.ITimer?displayProperty=nameWithType>.

The following example demonstrates using <xref:System.TimeProvider> to get the current date and time:

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/Program.cs" id="GetLocal":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/Program.vb" id="GetLocal":::

The following example demonstrates capturing elapsed time with <xref:System.TimeProvider.GetTimestamp?displayProperty=nameWithType>:

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/Program.cs" id="Timestamp":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/Program.vb" id="Timestamp":::

## FakeTimeProvider implementation

The [**Microsoft.Extensions.TimeProvider.Testing** NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.TimeProvider.Testing/) provides a controllable `TimeProvider` implementation that's suitable for unit testing.

The following list describes some of the capabilities of the <xref:Microsoft.Extensions.Time.Testing.FakeTimeProvider> class:

- Set a specific date and time.
- Automatically advance the date and time by a specified amount whenever the date and time is read.
- Manually advance the date and time.

## Custom implementation

While [FakeTimeProvider](#faketimeprovider-implementation) should cover most scenarios requiring control over time, you can still provide your own. Create a new class that derives from <xref:System.TimeProvider> and override members to control how time is provided. For example, the following class only provides a single date, the date of the moon landing:

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/MoonLandingTimeProviderPST.cs" id="CustomProvider":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/MoonLandingTimeProviderPST.vb" id="CustomProvider":::

If code using this class calls `MoonLandingTimeProviderPST.GetUtcNow`, the date of the moon landing in UTC is returned. If `MoonLandingTimeProviderPST.GetLocalNow` is called, the base class applies `MoonLandingTimeProviderPST.LocalTimeZone` to `GetUtcNow` and returns the moon landing date and time in the PST timezone.

To demonstrate the usefulness of controlling time, consider the following example. Let's say that you're writing a calendar app that sends a greeting to the user when the app is first opened each day. The app has many hardcoded greetings for special days, such as the anniversary of the moon landing.

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/CalendarHelper.cs" id="CalendarHelper":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/CalendarHelper.vb" id="CalendarHelper":::

You might be inclined to write the previous code with <xref:System.DateTime> or <xref:System.DateTimeOffset> to get the current time, instead of <xref:System.TimeProvider>. But with unit testing, it's hard to work around <xref:System.DateTime> or <xref:System.DateTimeOffset> directly. You would need to either run the tests on the day and month of the moon landing or further abstract the code into smaller but testable units.

The normal operation of your app uses `TimeProvider.System` to retrieve the current date and time:

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/Program.cs" id="GreetingNormal":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/Program.vb" id="GreetingNormal":::

And unit tests are written to test special use cases:

:::code language="csharp" source="./snippets/timeprovider-overview/csharp/Program.cs" id="GreetingMoon":::
:::code language="vb" source="./snippets/timeprovider-overview/vb/Program.vb" id="GreetingMoon":::

## Use with .NET

Starting with .NET 8, the <xref:System.TimeProvider> class is provided by the runtime library. Older versions of .NET or libraries targeting .NET Standard 2.0 should use the NuGet package as described in the [Use with .NET Framework](#use-with-net-framework) section.

## Use with .NET Framework

<xref:System.TimeProvider> is implemented by the [**Microsoft.Bcl.TimeProvider** NuGet package](https://www.nuget.org/packages/Microsoft.Bcl.TimeProvider/).
