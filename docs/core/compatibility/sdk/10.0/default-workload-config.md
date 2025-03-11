---
title: "Breaking change - Change default workload configuration from 'loose manifests' to 'workload sets' mode"
description: "Learn about the breaking change in .NET 10 Preview 2 where the default workload update mode changed."
ms.date: 3/11/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/45000
---

# Change default workload configuration from 'loose manifests' to 'workload sets' mode

In .NET 10 Preview 2, the default workload update mode changed from "manifests" to "workload-set". This change ensures users use a single, coherent set of workload versions that do not individually float, making it easier to maintain consistency and manage workloads.

## Version introduced

.NET 10 Preview 2

## Previous behavior

Previously, workloads operated in 'loose manifest' mode by default. Errant `dotnet workload update` commands could install new versions that might not work well together, making it difficult for users to keep a consistent set of workload versions aligned.

## New behavior

Workloads will never float unless the user:

* Updates their SDK
* Performs an explicit update command

When a user performs an update, all workloads will use known-matching versions from the workload set that is used.

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Users requested more control and predictability in workload management. This new system allows for pinning and coherent updates, ensuring a consistent set of workload versions.

## Recommended action

No corrective action is necessary. If users experience issues, they can revert to loose manifest mode by running the following command:

```dotnetcli
dotnet workload config --update-mode manifests
```

## Affected APIs

None.
