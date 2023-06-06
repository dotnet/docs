---
title: "Breaking change: Runtime-specific apps no longer self-contained"
description: Learn about a breaking change in the .NET 8 SDK where apps that specify a runtime identifier are no longer self-contained by default.
ms.date: 06/05/2023
---
# Runtime-specific apps no longer self-contained

Runtime-specific apps, or .NET apps with a `RuntimeIdentifier`, are no longer [self-contained](../../../deploying/index.md#publish-self-contained) by default. Instead, they are [framework-dependent](../../../deploying/index.md#publish-framework-dependent) by default.

This is a breaking change in the following situations:

- If you deployed, distributed, or published your app and didn't explicitly add the `SelfContained` property, but also didn't require that the .NET runtime be installed on the machine for it to work. In this case, you may have relied on the previous behavior to produce a self-contained app by default.

- If you rely on the IL Link tool. In this case, you'll have to take the steps described under [Recommended action](#recommended-action) to use IL Link again.

Blazor WebAssembly apps relied on the previous behavior. However, the Blazor SDK now adds `SelfContained` automatically for all apps, so Blazor customers shouldn't be affected.

## Previous behavior

Previously, if a runtime identifier (RID) was specified (via [RuntimeIdentifier](../../../project-sdk/msbuild-props.md#runtimeidentifier)), the app was published as self-contained, even if `SelfContained` wasn't explicitly specified.

In addition:

- If `PublishSelfContained` wasn't explicitly set to `false`, the publish properties `PublishSingleFile` and `PublishAot` implied `PublishSelfContained` and therefore `SelfContained` during operations including `dotnet build`, `dotnet restore`, and `dotnet publish`.
- The `PublishTrimmed` property did not imply `SelfContained`.
- The `PublishReadyToRun` property implied `SelfContained` if `SelfContained` wasn't specified.

## New behavior

Starting in .NET 8, for apps that target .NET 8 or a later version, `RuntimeIdentifier` no longer implies `SelfContained` by default. Instead, apps that specify a runtime identifier will be dependent on the .NET runtime by default (framework-dependent). Apps that target .NET 7 or earlier versions aren't affected.

In addition:

- If `PublishSelfContained` isn't explicitly set to `false`, the publish properties `PublishSingleFile` and `PublishAot` now imply `SelfContained` during `dotnet publish` only (that is, not for `dotnet build` or `dotnet restore`).
- The `PublishTrimmed` property also now implies `SelfContained` during `dotnet publish`.
- The `PublishReadyToRun` property no longer implies `SelfContained` if the project targets .NET 8 or later.

> [!NOTE]
> If you publish using `msbuild t:/Publish`, the publish properties don't imply `SelfContained`.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

- The new .NET SDK behavior aligns with Visual Studio behavior.
- Framework-dependent apps are smaller by default, since there aren't copies of .NET stored in each app.
- When .NET is managed outside of the app (that is, for framework-dependent deployments), .NET stays more secure and up-to-date. Apps that have their own copy of the runtime don't get security updates. This change makes more apps framework-dependent by default.
- Ideally, command-line options are orthogonal. In this case, the tooling supports both RID-specific self-contained deployment (SCD) and RID-specific framework-dependent deployment (FDD). So it didn't make sense that no RID defaulted to FDD and RID defaulted to SCD. This behavior was often confusing for users.

.NET 6 alerted users to this breaking change with the following warning:

**warning NETSDK1179: One of '--self-contained' or '--no-self-contained' options are required when '--runtime' is used.**

Now that customers have had time to add `SelfContained` explicitly, it's okay to introduce the break.

## Recommended action

If you're using .NET 7 or an earlier version and relied on the previous behavior where `SelfContained` was inferred, you'll see this warning:

**For projects with TargetFrameworks >= 8.0, RuntimeIdentifier no longer automatically gives a SelfContained app. To continue creating a .NET framework independent app after upgrading to 8.0, consider setting SelfContained explicitly.**

Follow the guidance of the warning if you want to continue to produce self-contained apps. If you want to move to the new default, set `SelfContained` to `false` in the project file (`<SelfContained>false</SelfContained>`) or as a command-line argument, for example, `dotnet publish --no-self-contained`.

If you're using .NET 8, you don't need to do anything unless you want to keep the previous behavior. In that case, set `SelfContained` to `true`.

## See also

- [.NET application publishing overview](../../../deploying/index.md)
