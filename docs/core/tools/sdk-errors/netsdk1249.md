---
title: "NETSDK1249: An OpenHarmony output already carries a signature from another signer"
description: Learn about NETSDK1249, which reports that the OpenHarmony code-signing task retained an existing .codesign section created by another signer.
ms.topic: error-reference
ms.date: 10/22/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1249
---
# NETSDK1249: An OpenHarmony output already carries a signature from another signer

When you build or publish for an `openharmony-*` runtime identifier, the SDK signs the ELF binaries in the output directory. If a binary already contains a `.codesign` section that the SDK signer didn't create, the signer leaves the file untouched instead of replacing the signature silently. This is a warning. The full message is similar to the following example:

> NETSDK1249: '{0}' carries a .codesign section that this signer did not create; it was left untouched. Run 'dotnet selfsign --force' to replace it with a self-signature.

## Resolve the warning

Choose one of the following options:

- Keep the existing signature if it is valid for the target device. This is the default behavior.
- Replace the existing section with the SDK's self-signature by re-signing the file with the force option:

  ```dotnetcli
  dotnet selfsign --force <file>
  ```

  Replacing a signature changes the signed content, so do this only when the existing signature isn't the one the device must verify.

## See also

- [.NET SDK error and warning reference](index.md)
