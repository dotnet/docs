---
title: "Breaking change: StripSymbols defaults to true"
description: Learn about the breaking change in deployment where the default value for 'StripSymbols' is now 'true' for 'PublishAOT'.
ms.date: 05/02/2023
---
# StripSymbols defaults to true

When .NET 7 introduced [Native AOT deployment](../../../deploying/native-aot/index.md), it also introduced the `StripSymbols` property that optionally allows debugging symbols to be stripped from the produced executable on Linux into a separate file. The default value of the property was `false`. In .NET 8, the default value has changed to `true`.

## Previous behavior

With `PublishAOT`, debugging symbols on Linux were placed into the produced executable by default, with an opt-in option to place them into a separate *.dbg* file.

## New behavior

With `PublishAOT`, debugging symbols on Linux are placed into a *.dbg* file by default, with an opt-out option to place them into the executable.

## Version introduced

.NET 8 Preview 4

## Reason for change

Based on feedback, we determined that .NET users prefer the .NET-symbols convention instead of the platform-native convention. However, the option to strip the symbols was not discoverable enough.

## Recommended action

- If you rely on debugging symbols to be present in the main executable, add `<StripSymbols>false</StripSymbols>` to your project file to restore the previous behavior.
- If you choose to use the new default, verify that the debugging symbols in *.dbg* files are properly archived if you expect you'll need to debug the generated executables.

## Affected APIs

None.
