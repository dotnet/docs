---
title: "Breaking change: Duplicate output for -getItem, -getProperty, and -getTargetResult"
description: Learn about a breaking change in the .NET 8 SDK where using property, item, and result-returning MSBuild flags in combination with a framework-specific build causes duplicate output of the requested properties, items, and results.
ms.date: 12/05/2023
ms.topic: how-to
---
# Duplicate output for -getItem, -getProperty, and -getTargetResult

.NET SDK 8.0.200 introduced a regression in the new `-getItem`, `-getProperty`, and `-getTargetResult` MSBuild CLI options. When the SDK is used to perform an MSBuild operation for a specific TargetFramework, the output is duplicated, like so:

```terminal
> dotnet build -r:android-arm64 --getProperty:OutputPath -f:net8.0-android
bin\Debug/net8.0-android/android-arm64/
bin\Debug/net8.0-android/android-arm64/
```

> [!NOTE]
> We intend to fix this behavior in an upcoming release of the .NET 8.0.200 SDK.

## Version introduced

.NET 8.0.200

## Previous behavior

```terminal
> dotnet build -r:android-arm64 --getProperty:OutputPath -f:net8.0-android
bin\Debug/net8.0-android/android-arm64/
```

## New behavior

Building, loading, or running an affected project fails.

## Type of breaking change

This is a behavioral change that can impact user scripts, especially in CI/CD scenarios.

## Reason for change

These options are intended to return values computed from a single user-requested build. However, SDK-initiated MSBuild operations like `build` and `publish` can sometimes trigger a second call to MSBuild&mdash;particularly when the `-f` option is used to specify that a build should occur for a specific TargetFramework. In that scenario, `-getItem`, `-getProperty`, and `-getTargetResult` options were passed to both MSBuild invocations, instead of only the one that a user expected to be triggered.

## Recommended action

Choose one of the following actions:

- Use an older version of the .NET SDK (before the regression was introduced).
- Use a version of the .NET 8 SDK that contains the fix, which should be any version after 8.0.202.
- Remove any usage of `-f` from calls that also use `-getItem`, `-getProperty`, or `-getTargetResults`.
