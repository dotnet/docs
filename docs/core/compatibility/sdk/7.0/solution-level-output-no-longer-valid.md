---
title: "Solution-level `--output` option no longer valid for build-related commands"
description: Learn about a breaking change in the .NET 7.0.200 SDK where using the `--output` option is no longer valid when using a solution file
ms.date: 02/15/2023
---
# Solution-level `--output` option no longer valid for build-related commands

In the 7.0.200 SDK, there was [a change](https://github.com/dotnet/sdk/pull/29065) to no longer accept the `--output`/`-o` option when using a solution file with the following commands:

* `build`
* `clean`
* `pack`
* `publish`
* `store`
* `test`
* `vstest`

This is because the semantics of the `OutputPath` property, which is controlled by the `--output`/`-o` option, aren't well defined for solutions. Projects built in this way will have their output placed in the same directory, which is inconsistent and has led to a number of user-reported issues.

This change was reduced to a warning level of severity in the 7.0.201 SDK, and `pack` was removed from the list of commands that are affected.

## Version introduced

.NET 7.0.200 SDK, reduced to a warning only in the 7.0.201 SDK.

## Previous behavior

Previously, if you specified `--output`/`-o` when using a solution file, the output for all built projects would be placed in the specified directory in an undefined and inconsistent order.

## New behavior

The `dotnet` CLI will error if the `--output`/`-o` option is used with a solution file. Starting in the 7.0.201 SDK, a warning will be emitted instead, and in the case of `dotnet pack` no warning or error will be generated.

## Type of breaking change

This breaking change may require modifications to build scripts and continuous integration pipelines. As a result it affects both binary and source compatibility.

## Reason for change

This change was made because the semantics of the `OutputPath` property, which is controlled by the `--output`/`-o` option, aren't well defined for solutions. Projects built in this way will have their output placed in the same directory, which is inconsistent and has led to a number of user-reported issues.

When a solution is built with the `--output` option, the `OutputPath` property is set to the same value for all projects, which means that all projects will have their output placed in the same directory. Depending on the complexity of the projects in the solution, different and inconsistent results may occur. Let's take a look at some examples of different solution shapes and how they are affected by a shared `OutputPath`.

### Single project, single TargetFramework

Imagine a solution that contains a single project targeting a single `TargetFramework`, `net7.0`. In this case, providing the `--output` option is equivalent to setting the `OutputPath` property in the project file. During a build (or other commands, but let's scope the discussion to build for now), all of the outputs for the project will be placed in the specified directory.

### Single project, multiple TargetFrameworks

Now imagine a solution that contains a single project with multiple `TargetFrameworks`, `net6.0` and `net7.0`. Because of multi-targeting, the project will be build twice, once for each `TargetFramework`. For each of these 'inner' builds the `OutputPath` will be set to the same value, and so the outputs for each of the inner builds will be placed in the same directory. This means that whichever build completes last will overwrite the outputs of the other build, and in a parallel-build system like MSBuild operates in by default, 'last' is indeterminate.

### Library => Console => Test, single TargetFramework

Now imagine a solution that contains a library project, a console project that references the library project, and a test project that references the console project. All of these projects target a single `TargetFramework`, `net7.0`. In this case, the library project will be built first, and then the console project will be built. The test project will be built last, and will reference the console project. For each built project, the outputs of each build will be copied into the directory specified by the `OutputPath`, and so the final directory will contain assets from all three projects. This works for testing, but for publishing may result in test assets being sent to production.

### Library => Console => Test, multiple TargetFrameworks

Now take the same chain of projects and add a `net6.0` `TargetFramework` build to them in addition to the `net7.0` build. The same problem as the single-project, multi-targeted build occurs - inconsistent copying of TFM-specific assets to the specified directory.

### Multiple apps

So far we have been looking at scenarios with a linear dependency graph - but many solutions may contain multiple related applications.  This means that multiple apps may be built concurrently to the same output folder.  If the apps include a dependency file with the same name, then the build may intermittently fail when multiple projects try to write to that file in the output path concurrently.

If multiple apps depend on different versions of a file, then even if the build succeeds, which version of the file is copied to the output path may be non-deterministic.  This can happen when the projects depend (possibly transitively) on different versions of a NuGet package.  Within a single project, NuGet helps ensure that its dependencies (including any transitive dependencies through NuGet packages and/or project references) are unified to the same version.  Because the unification is done within the context of a single project and its dependent projects, this means it is possible to resolve different versions of a package when two separate top-level projects are built.  If the project that depends on the higher version copies the dependency last, then often the apps will run successfully.  However, if the lower version is copied last, then the app that was compiled against the higher version will fail to load the assembly at runtime.  Because the version that is copied can be non-deterministic, this can lead to sporadic, unreliable builds where it is very difficult to diagnose the issue.

## Other examples

For more examples of how this underlying error presents in practice, see the discussion on [dotnet/sdk#15607](https://github.com/dotnet/sdk/issues/15607).

## Recommended action

The general recommendation is to perform the action that you previously took _without_ the `--output`/`-o` option, and then move the output to the desired location after the command has completed. It's also possible to perform the action at a specific project and still apply the `--output`/`-o` option, as that has more well-defined semantics.

If you want to maintain the existing behavior exactly, then you can use the `--property` flag to set a MSBuild property to the desired directory. The property to use varies based on the command:

| Command | Property | Example |
| -- | -- | -- |
| `build` | `OutputPath` | `dotnet build --property:OutputPath=DESIRED_PATH` |
| `clean` | `OutputPath` | `dotnet clean --property:OutputPath=DESIRED_PATH` |
| `pack` | `PackageOutputPath` | `dotnet pack --property:PackageOutputPath=DESIRED_PATH` |
| `publish` | `PublishDir` | `dotnet publish --property:PublishDir=DESIRED_PATH` |
| `store` | `OutputPath` | `dotnet store --property:OutputPath=DESIRED_PATH` |
| `test` | `TestResultsDirectory` | `dotnet test --property:OutputPath=DESIRED_PATH` |

**NOTE**
For best results, the DESIRED_PATH should be an absolute path. Relative paths will be 'anchored' (i.e. made absolute) in ways that you may not expect, and may not work the same with all commands.
