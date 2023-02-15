---
title: "Solution-level `--output` option no longer valid for build-related commands"
description: Learn about a breaking change in the .NET 7.0.200 SDK where using the `--output` option is no longer valid when using a solution file
ms.date: 02/15/2023
---
# Solution-level `--output` option no longer valid for build-related commands

In the 7.0.200 SDK, there was [a change]([automatic-runtimeidentifier.md](https://github.com/dotnet/sdk/pull/29065)) to no longer accept the `--output`/`-o` option when using a solution file with the following commands:

* build
* clean
* pack
* publish
* store
* test
* vstest

This is because the semantics of the `OutputPath` property, which is controlled by the `--output`/`-o` option, are not well-defined for solutions - projects built in this way will have their output placed in the same directory, which is not consistent and has lead to a number of user-reported issues in the past.

## Version introduced

.NET 7.0.200 SDK

## Previous behavior

Previously, if you specified `--output`/`-o` when using a solution file, the output for all built projects would be placed in the specified directory in an undefined and inconsistent order.

## New behavior

The `dotnet` CLI will error if the `--output`/`-o` option is used with a solution file.

## Type of breaking change

This change requires changes to build scripts and Continuous Integration pipelines.

## Reason for change

This change was taken because the semantics of the `OutputPath` property, which is controlled by the `--output`/`-o` option, are not well-defined for solutions - projects built in this way will have their output placed in the same directory, which is not consistent and has lead to a number of user-reported issues in the past.

For examples of how this presents in practice, see the discussion on [dotnet/sdk#15607](https://github.com/dotnet/sdk/issues/15607).

## Recommended action

The general recommendation is to perform the action that you previously took _without_ the `--output`/`-o` option, and then move the output to the desired location after the command has completed. It is also possible to perform the action at a more specific level (i.e. at a specific project) and still apply the `--output`/`-o` option, as that has more well-defined semantics.
