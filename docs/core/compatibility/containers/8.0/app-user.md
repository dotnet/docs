---
title: "Breaking change: New non-root 'app' user in Linux images"
description: Learn about the breaking change in containers where a new non-root 'app' user was added in Linux container images.
ms.date: 07/12/2023
---
# New non-root 'app' user in Linux images

The .NET Linux container images include a new non-root user named `app`. You can opt into this new user to provide security benefits. The name of this user may conflict with an existing user defined by an application's Dockerfile.

## Previous behavior

Prior to .NET 8, the Linux container images did not include any additional users beyond what was included by default in the base Linux container image (for example, Debian, Alpine, and Ubuntu).

## New behavior

Starting in .NET 8, Linux container images define a user named `app` that can be opted-into for additional security benefits. However, the name of this user may conflict with an existing user that was defined by the application's Dockerfile. If the application's Dockerfile attempts to create a user with the same name, an error might occur saying that the user already exists.

## Version introduced

.NET 8 Preview 1

## Type of change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The new user was introduced to improve usability for securing containers.

## Recommended action

If your application's Dockerfile attempts to create a new user with the same name as the existing `app` user, there are two options:

- Update the Dockerfile to change the name of the user so that it no longer conflicts.
- Remove the user creation logic and migrate to use the built-in `app` user instead.

## Affected APIs

None.

## See also

- [Blog post: Rootless Linux containers](https://devblogs.microsoft.com/dotnet/securing-containers-with-rootless/)
