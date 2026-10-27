---
title: "Breaking change: Full build skipped for Native AOT publish"
description: "Learn about the breaking change in .NET 11 where the .NET SDK only compiles intermediate assemblies for Native AOT publish and skips the full Build target."
ms.date: 10/27/2026
ai-usage: ai-assisted
---

# Full build skipped for Native AOT publish

Starting in .NET 11, the .NET SDK no longer executes the full `Build` target when publishing with Native AOT (`PublishAot=true`). Instead, the SDK executes only the minimum targets needed to compile the intermediate assembly and produce the AOT-compiled output.

## Version introduced

.NET 11 RC 2

## Previous behavior

When publishing with `PublishAot=true`, the full MSBuild `Build` target executed as part of the publish pipeline, producing a complete self-contained managed deployment (apphost, DLLs, `deps.json`, `runtimeconfig.json`, and runtime pack files) in the output (`bin\`) directory. These artifacts were unused by the AOT pipeline, which reads from `@(IntermediateAssembly)` in `obj\`, not from `bin\`.

## New behavior

The .NET SDK runs only the targets needed to compile the intermediate assembly and produce the Native AOT publish output. It no longer runs the full `Build` target or produces the unused managed deployment in `bin\`.

Consequently, build extensibility points that aren't part of compilation don't run during Native AOT publish. These include `BeforeBuild`, `AfterBuild`, `PreBuildEvent`, `PostBuildEvent`, `BeforeTargets="Build"`, `AfterTargets="Build"`, and targets added to `BuildDependsOn`.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change reduces customer confusion about which binaries to deploy and improves Native AOT publish performance. Deployable binaries are produced only in the publish directory.

## Recommended action

Update custom MSBuild targets to attach to the specific phase whose outputs they affect:

- For generated source or other compiler inputs, use `BeforeTargets="CoreCompile"`.
- For logic that consumes the compiled assembly, use `AfterTargets="Compile"` and consume `@(IntermediateAssembly)` rather than `$(TargetPath)`.
- For additional files that should be copied to the publish directory, declare them as `Content` items with `CopyToPublishDirectory`, or add them to `@(ResolvedFileToPublish)` before `ComputeResolvedFilesToPublishList`.
- For logic that processes the completed publish output, use `AfterTargets="Publish"`.

For example:

```xml
<Target Name="GenerateSources" BeforeTargets="CoreCompile">
  <!-- Generate source and add it to @(Compile). -->
</Target>

<Target Name="ProcessCompiledAssembly" AfterTargets="Compile">
  <!-- Consume @(IntermediateAssembly), which is produced in obj\. -->
</Target>
```

Targets that require the managed deployment previously produced in `bin\` can't use optimized publish. To restore the previous behavior, set `UseOptimizedPublish` to `false` in the project file:

```xml
<PropertyGroup>
  <UseOptimizedPublish>false</UseOptimizedPublish>
</PropertyGroup>
```

Alternatively, pass it on the command line:

```dotnetcli
dotnet publish /p:UseOptimizedPublish=false
```

## Affected APIs

None.
