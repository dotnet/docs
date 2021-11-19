---
title: "Breaking change: Error generated when executable references executable"
description: Learn about the breaking change in .NET 5 where compile-time errors are generated when an executable references an executable whose SelfContained value is different.
ms.date: 05/26/2021
---
# Error generated when executable project references mismatched executable

Generally, an executable project references library projects, not other executable projects. An executable project can also reference another executable project to use APIs that are defined in it. Some developers want to reference an executable project from another executable project so that both apps are placed in and are runnable from the same output folder. However, this scenario does not work if a self-contained executable references a non-self-contained executable, or vice versa. Because of how the application host works, neither app can be launched. To prevent situations where apps aren't runnable, .NET SDK 5+ produces compile-time errors NETSDK1150 and NETSDK1151 when it detects mismatched executable references.

## Change description

In previous .NET SDK versions, you could reference a self-contained executable project from a non-self-contained executable project without a build error. However, both apps would not be runnable. Starting in .NET SDK 5, an error is generated if an executable project references another executable project and the `SelfContained` values don't match.

## Version introduced

.NET SDK 5.0.300

## Reason for change

The errors were introduced to prevent situations where you expect to be able to launch both applications but cannot.

## Recommended action

If the referenced project doesn't need to be runnable from the output folder, you can set a property to avoid this error check:

```xml
<ValidateExecutableReferencesMatchSelfContained>false</ValidateExecutableReferencesMatchSelfContained>
```

For more information, see [ValidateExecutableReferencesMatchSelfContained](../../../project-sdk/msbuild-props.md#validateexecutablereferencesmatchselfcontained).

## Affected APIs

None.

<!--

### Affected APIs

Not detectable via API analysis.

### Category

- SDK

-->
