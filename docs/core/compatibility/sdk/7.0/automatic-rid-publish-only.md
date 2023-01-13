---
title: "Breaking change: "
description: Learn about a breaking change in the .NET 7 SDK where a RuntimeIdentifier is automatically added to projects only for the dotnet publish command.
ms.date: 01/12/2023
---
# Automatic RuntimeIdentifier for publish only

In the 7.0.100 SDK, there was [a change](automatic-runtimeidentifier.md) to automatically add `<RuntimeIdentifier>` to projects with properties that require a runtime identifier (RID). Those properties are as follows:

- `SelfContained`
- `PublishAot`
- `PublishReadyToRun`
- `PublishSingleFile`
- `PublishSelfContained`

However, all of these properties except for `SelfContained` are only used for publishing. Yet the implicit `<RuntimeIdentifier>` was added for any [`dotnet` operation](../../../tools/dotnet.md) if these properties were in the project file or specified as part of the `dotnet` command.

Now, the automatic RID for these properties is limited to only be added during publish. In addition, the automatic RID is only added when using the `dotnet publish` CLI command. It's not added when you publish from Visual Studio or `msbuild`, as those are separate mechanisms, and Visual Studio should provide its own RID.

## Version introduced

.NET 7.0.200 SDK

## Previous behavior

Previously, if you specified any of the mentioned properties, the RID was automatically added to the project.

## New behavior

The RID is only automatically added for the `dotnet publish` command.

If you performed a restore without an RID in .NET 7 and use it to restore for a `publish --no-restore` command on a project with one of the mentioned properties, you'll need to specify an RID using `restore -r <RID>`.

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility) and [source compatibility](../../categories.md#source-compatibility).

## Reason for change

The RID change was a breaking change, and there was no need for a publish property change to break `dotnet build` and other non-publish-related commands.

## Recommended action

For an action like `restore` followed by `publish --no-restore`, you must add the RID by using `dotnet restore -r RID`. In this case, it's also better to be explicit when you publish so the publish has the same RID (using `dotnet publish -r RID`). Alternatively, you can remove `--no-restore` from the publish command.

For everything else, no action is needed. However, if you want to keep the RID, add it to the project file as follows: `<RuntimeIdentifier>win-x64</RuntimeIdentifier>`.

## See also

- [Automatic RuntimeIdentifier for certain projects](automatic-runtimeidentifier.md)
