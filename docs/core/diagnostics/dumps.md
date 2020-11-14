---
title: Dumps - .NET Core
description: An introduction to .NET Core logging and tracing.
ms.date: 10/12/2020
---

# Dumps

A dump is a file that contains snapshot of the process at the time they were created and can be useful for examining the state of your application for debugging. This is useful when 

## Collect dumps

Dumps can be collected in a variety of ways depending on which platform you are running your app on.

[!NOTE]
> Collecting a dump inside a container requires PTRACE capability which can be added via `--cap-add=SYS_PTRACE` or `--privileged`

### 