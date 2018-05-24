---
title: global.json reference
description: See the schema for the global.json file, which permits setting the .NET Core SDK version.
author: mairaw
ms.author: mairaw
ms.date: 05/23/2018
ms.custom: "updateeachrelease"
---
# global.json reference

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

The *global.json* file allows selection of the .NET Core SDK version being used through the `sdk` property.

.NET Core SDK looks for this file in the current working directory (which isn't necessarily the same as the project directory) or one of its parent directories.

## sdk

Type: Object

Specifies information about the .NET Core SDK.

### version

Type: String

The version of the .NET Core SDK to use.

Note that this field:

- Doesn't have globbing support, that is, the full version number has to be specified.
- Doesn't support version ranges.

The following example shows the contents of a *global.json* file:

```json
{
  "sdk": {
    "version": "2.1.300-preview1-008174"
  }
}
```

You can easily create this file by executing the [dotnet new](dotnet-new.md) command as follows:

```console
dotnet new globaljson --sdk-version 2.1.300-preview1-008174
```

## Matching rules

With .NET Core SDK 1.x, if you specified a version and no exact match was found, the latest installed SDK version was used. Latest SDK version can be either release or pre-release - the highest version number wins.

Starting with .NET Core SDK 2.0, the following rules apply when determining which version of the SDK to use:

- If no *global.json* file is found or *global.json* doesn't specify a SDK version, the latest installed SDK version is used. Latest SDK version can be either release or pre-release - the highest version number wins.
- If *global.json* does specify a SDK version:
  - If the specified SDK version is found on the machine, that exact version is used.
  - If the specified SDK version cannot be found on the machine, the latest installed SDK **patch-version** of the specified SDK version is used. Latest installed SDK **patch-version** can be either release or pre-release - the highest version number wins.
  - If the specified SDK version and an appropriate SDK **patch-version** cannot be found, an error is thrown.

The SDK version is now composed of the following parts:
`[major][minor][xyz]-[additional optional information]`

The **patch-version** is defined by the third position (`z`) in the last portion of the number (`xyz`) for SDK versions earlier than 2.1.100 and the last two digits (`yz`) starting with 2.1.100. For example, if you specify `2.1.300` as the SDK version, it can try to find up to `2.1.399` but `2.1.400` is not considered a patch version for `2.1.300`.

## Supported .NET Core SDK versions

The following .NET Core SDK version numbers are the officially supported .NET Core SDK versions:

- 2.1.300-rc1-008673
- 2.1.300-preview2-008533
- 2.1.300-preview1-008174
- 2.1.200
- 2.1.105
- 2.1.104
- 2.1.103
- 2.1.102
- 2.1.101
- 2.1.100
- 2.1.4
- 2.1.2
- 2.0.3
- 2.0.0
- 2.0.0-preview2-006497
- 2.0.0-preview1-005977
- 1.1.9
- 1.1.8
- 1.1.7
- 1.1.5
- 1.1.4
- 1.0.4
- 1.0.1
- 1.0.0-preview2-003156
- 1.0.0-preview2-003148
- 1.0.0-preview2-003131
- 1.0.0-preview2-003121
- 1.0.0-preview2.1-003177

Nightly builds are not included in this list. These versions are updated each release at the [releases.json](https://github.com/dotnet/core/blob/master/release-notes/releases.json) file.

## See also

[How project SDKs are resolved](/visualstudio/msbuild/how-to-use-project-sdk#how-project-sdks-are-resolved)