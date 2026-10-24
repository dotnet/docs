---
title: "NETSDK1250: A symbolic link was skipped while signing OpenHarmony outputs"
description: Learn about NETSDK1250, which reports that the OpenHarmony code-signing task skipped a symbolic link in the output directory.
ms.topic: error-reference
ms.date: 10/22/2026
ai-usage: ai-assisted
f1_keywords:
- NETSDK1250
---
# NETSDK1250: A symbolic link was skipped while signing OpenHarmony outputs

When you build or publish for an `openharmony-*` runtime identifier, the SDK signs the ELF binaries in the output directory. The signer never follows symbolic links (file or directory links), because doing so could rewrite a file outside the output tree. This is a warning. The full message is similar to the following example:

> NETSDK1250: Skipping symbolic link '{0}' while signing OpenHarmony outputs: signing never follows symbolic links.

## Resolve the warning

- This warning is expected when the output tree contains links that point outside it. The real file must be signed where it lives, not through the link.
- If a linked file must be signed as part of the output, replace the link with a copy of the file in the output directory, or sign the real target separately.
- If the link is intentional and its target is already signed, no action is required.

## See also

- [.NET SDK error and warning reference](index.md)
