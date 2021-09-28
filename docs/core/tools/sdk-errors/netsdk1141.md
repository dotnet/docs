---
title: "NETSDK1141: Unable to resolve the .NET SDK version as specified in the global.json"
description: Learn about .NET SDK error NETSDK1141, which occurs when the SDK version could not be resolved in global.json.
ms.topic: error-reference
ms.date: 04/16/2021
f1_keywords:
- NETSDK1141
---
# NETSDK1141: Unable to resolve the .NET SDK version as specified in the global.json

**This article applies to:** ✔️ .NET Core 5.0 SDK and later versions

There was a problem with the version of the SDK specified in the *global.json* file.

**NETSDK1141: Unable to resolve the .NET SDK version as specified in the global.json located at C:\path\global.json.**

## Cause

* The SDK version in the *global.json* file is incorrectly specified.
* The SDK version specified in the *global.json* file was not installed.
* The SDK version specified in *global.json* could not be found, due to an incorrect path.

## How to fix the error

* Install the SDK version requested in *global.json*.
* Specify a different SDK version in *global.json*.
* Check for typos or other problems in *global.json*. See [global.json](../global-json.md) for the correct structure of that file.
* Delete *global.json*. In this case, the latest installed version of the SDK is used.

When you're working on a shared project, developers need to agree on the SDK version that will be used for the project. Without *global.json*, if developers on different dev machines don't have the same SDK versions, the build environment might be inconsistent across the dev team. To solve this, the SDK version can be specified in *global.json* and checked into source control as a common file which would be the same for all developers and ensure that the same SDK version is being used in all development environments. Therefore, to resolve this issue in a shared project, you might need to agree as a team on a particular SDK version and update all the code to use this version.

## See also

[global.json](../global-json.md)
[How to check that the .NET SDK is installed](../../install/how-to-detect-installed-versions.md#check-sdk-versions)
