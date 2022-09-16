---
title: Dumps - .NET FAQ
description: Frequently Asked Questions about dumps .NET
ms.date: 09/19/2022
---

# Frequently Asked Questions Regarding Dumps

## Collecting dumps on macOS and Linux

Collecting a dump requires that the processes in the system have access to call `ptrace` targeting parent processes. The following is a non-exhaustive list of settings that are needed for this to work properly:

- On Linux-based systems, `/proc/sys/kernel` should have `ptrace_scope` set to `1` or `0`. Any value higher than this will require running as root or will block dump collection entirely.
- For applications running under an Open Container Initiative technology, the `seccomp` profile must allow for calls to `ptrace`. For example, moby+containerd specifies a default [seccomp profile](https://github.com/moby/moby/blob/master/profiles/seccomp/default.json) that allows `ptrace` only if the container host has a kernel version higher than 4.8 or if the `CAP_SYS_PTRACE` capability was specified.
- on macOS, the use of `ptrace` requires the host of the target process to be properly entitled. See [Default Entitlements](../install/macos-notarization-issues#default-entitlements) for more information.

## See also

Learn more about how you can leverage dumps to help diagnosing problems in your .NET application.

* [Debug Linux dumps](debug-linux-dumps.md) tutorial walks you through how to debug a dump that was collected in Linux.

* [Debug deadlock](debug-deadlock.md) tutorial walks you through how to debug a deadlock in your .NET application using dumps.
