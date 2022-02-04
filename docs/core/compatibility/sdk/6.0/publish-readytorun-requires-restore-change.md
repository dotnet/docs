---
title: "Breaking change: Publish ReadyToRun with --no-restore requires changes"
description: Learn about the breaking change in .NET 6 where publishing a project with ReadyToRun requires changes to the way the project is restored.
ms.date: 02/01/2022
---
# Publishing a ReadyToRun project with --no-restore requires changes to the restore

If you publish a project with `-p:ReadyToRun=true` in addition to `--no-restore`, the project will only build with packages that were restored in a prior `dotnet restore` operation. In .NET 5, this process worked and resulted in a crossgen'd binary. In .NET 6, this same process will fail with the NETSDK1095 error.

## Version introduced

.NET 6

## Previous behavior

In previous versions, the crossgen application was packaged with the runtime. As a result, the crossgen process was able to run on your application regardless of if the project had been restored or not. It was a common practice to separate `dotnet restore` from `dotnet publish`, adding `--no-restore` to the publish command to ensure that no additional network accesses occurred.

## New behavior

In .NET 6, `dotnet restore` followed by `dotnet publish -p:ReadyToRun=true --no-restore` will fail with the NETSDK1095 error. This is because the crossgen binary is now shipped as a separate NuGet package, and so needs to be part of the restore operation for publishing to succeed.

## Reason for change

The crossgen binary is not required for many workloads, so it was split out from the main SDK.  It it typically acquired on-demand, and the publishing MSBuild targets now handle this acquisition by adding the package to the list of packages to be restored.

## Recommended action

- If you want to maintain an isolated publish experience, tell the restore step that you'll be publishing ReadyToRun. Add `-p:ReadyToRun=true` to your restore command line as well.
- Or, remove `--no-restore` from your publish command line to allow the publish command to restore crossgen as well.
