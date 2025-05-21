---
title: "Breaking change: Containers default to use the 'latest' tag"
description: Learn about the breaking change in containers where .NET SDK-built containers default to use the 'latest' tag instead of '$(Version)'.
ms.date: 07/27/2023
ms.topic: concept-article
---
# Containers default to use the 'latest' tag

The default image tag used for .NET SDK-built containers changed from the value of the `Version` of the project to the value `latest`.

## Previous behavior

Previously, the image was built with a tag value of `$(Version)`, which enabled changing the tag based on the same value that the rest of the .NET ecosystem uses.

## New behavior

Starting in .NET 8, the generated image has the `latest` tag in all cases.

## Version introduced

.NET 8 Preview 6

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change aligns the default containerization experience with the developer experiences for other container tooling like the Docker CLI. It also makes the development inner-loop of repeated container publishes easier to use with tools like Docker Compose, because the version remains stable.

## Recommended action

Explicitly set the version if you need it. The easiest way is to set the `ContainerImageTag` property on the command line to an explicit version, for example, `/p:ContainerImageTag=1.2.3`. But you can also programmatically set the value as you would any other MSBuild property. In a project file, you can continue to use the `$(Version)` property by adding the `ContainerImageTag` property:

```xml
<PropertyGroup>
  <ContainerImageTag>$(Version)</ContainerImageTag>
</PropertyGroup>
```

## Affected APIs

None.
