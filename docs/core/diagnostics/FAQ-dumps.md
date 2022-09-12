---
title: Dumps - .NET FAQ
description: Frequently Asked Questions about dumps .NET
ms.date: 09/12/22
---

# Dumps

## Dumps with MacOS and Linux

Collecting a dump requires that the process have access to ptrace targeting parent processes. This means /proc/sys/kernel should have ptrace_scope set to 1 or 0. If running under any type of Open Container Initiatory technology, the seccomp profile must allow for calls to ptrace. For example, moby+containerd specifies a [seccomp profile](https://github.com/moby/moby/blob/master/profiles/seccomp/default.json) that allows parent ptrace if the container host has a kernel version higher than 4.8. 

## See also

Learn more about how you can leverage dumps to help diagnosing problems in your .NET application.

* [Debug Linux dumps](debug-linux-dumps.md) tutorial walks you through how to debug a dump that was collected in Linux.

* [Debug deadlock](debug-deadlock.md) tutorial walks you through how to debug a deadlock in your .NET application using dumps.
