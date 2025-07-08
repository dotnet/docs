---
title: BuildCheck rule list
description: A complete list of BCxxxx build check errors.
ms.topic: error-reference
ms.date: 07/10/2024
ms.custom: updateeachrelease
f1_keywords:
- BC0101
- BC0102
---
# BuildCheck rule list

**This article applies to:** ✔️ .NET 9 SDK and later versions

The following list includes all build-check warnings that you might get from the .NET SDK.

| Rule                |  Default Severity | Message                                                                             |
|---------------------|-------------------|-------------------------------------------------------------------------------------|
| [BC0101](bc0101.md) | Warning | Two projects should not share their OutputPath or IntermediateOutputPath locations. |
| [BC0102](bc0102.md) | Warning | Two tasks should not write the same file. |
| [BC0103](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/Codes.md#bc0103---used-environment-variable) | Suggestion | Environment variables should not be used as a value source for the properties. |
| [BC0201](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/Codes.md#bc0201---usage-of-undefined-property) | Warning | A property that is accessed should be declared first. |
| [BC0202](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/Codes.md#bc0202---property-first-declared-after-it-was-used) | Warning | A property should be declared before it is first used. |
| [BC0203](https://github.com/dotnet/msbuild/blob/main/documentation/specs/BuildCheck/Codes.md#bc0203----property-declared-but-never-used) | None | A property that is not used should not be declared. |
