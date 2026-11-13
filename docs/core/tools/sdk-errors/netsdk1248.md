---
title: "NETSDK1248: Failed to sign an OpenHarmony output file"
description: Learn about NETSDK1248, which reports that the OpenHarmony code-signing task could not sign an ELF output file.
ms.topic: error-reference
ms.date: 10/22/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1248
---
# NETSDK1248: Failed to sign an OpenHarmony output file

When you build or publish for an `openharmony-*` runtime identifier, the SDK signs the ELF binaries in the output directory so that OpenHarmony can execute them. This error means the signing task failed for one file. The full error message is similar to the following example:

> NETSDK1248: Failed to sign '{0}': {1}

The `{0}` placeholder is the file that failed to sign, and `{1}` contains the underlying error.

## Resolve the error

- Inspect the error text in `{1}`. Typical causes are a file that isn't a valid ELF64 executable, a read-only or locked file, a full disk, or a file system that doesn't support in-place writes.
- Delete the stale output (for example, the `bin` and `obj` folders) and rebuild.
- Make sure the file is writable and isn't held open by another process.
- Make sure the output is an ELF64 binary for the target architecture. Files with a known non-executable extension (such as `.dll`, `.pdb`, `.json`, `.hap`) are skipped by the signer; other formats should not be part of the executable output.
- If the output directory contains a file that must not be signed, move it out of the output tree before signing.

## See also

- [.NET SDK error and warning reference](index.md)
