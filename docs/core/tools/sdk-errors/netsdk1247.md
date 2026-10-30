---
title: "NETSDK1247: Failed to enumerate a directory while signing OpenHarmony outputs"
description: Learn about NETSDK1247, which reports that the OpenHarmony code-signing task could not enumerate an output directory.
ms.topic: error-reference
ms.date: 10/22/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1247
---
# NETSDK1247: Failed to enumerate a directory while signing OpenHarmony outputs

When you build or publish for an `openharmony-*` runtime identifier, the SDK signs the ELF binaries in the output directory so that OpenHarmony can execute them. This error means the signing task could not enumerate one of those directories. The full error message is similar to the following example:

> NETSDK1247: Failed to enumerate '{0}' while signing OpenHarmony outputs: {1}

The `{1}` placeholder contains the underlying I/O or permission error.

## Resolve the error

- Make sure the output directory exists and is readable by the user that runs the build.
- Check the exception text in `{1}` for the specific cause, such as an access denial, a directory that was deleted during the build, or a network share that became unavailable.
- If another process (an antivirus scanner, an editor, or a file watcher) is locking the output tree, close it and rebuild.
- If the build uses a custom `OutputPath` or `PublishDir`, verify that the path is valid on the build machine.

## See also

- [.NET SDK error and warning reference](index.md)
