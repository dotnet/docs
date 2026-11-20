---
title: Upgrade the TypeScript compiler
description: Use GitHub Copilot upgrade to update the TypeScript compiler through supported major versions and resolve compatibility problems.
ms.topic: how-to
ms.date: 09/21/2026
ai-usage: ai-generated

#customer intent: As a TypeScript developer, I want to upgrade the TypeScript compiler and resolve errors introduced by each major version.
---

# Upgrade the TypeScript compiler

Use GitHub Copilot upgrade to move a project to a newer TypeScript compiler version. The agent upgrades the compiler incrementally across major versions, resolves new compiler errors at each step, and validates application behavior after the upgrade.

Use the dependency upgrade workflow instead when you want to update packages other than `typescript`. For more information, see [Upgrade JavaScript and TypeScript dependencies](javascript-typescript-upgrade-dependencies.md).

## Start the compiler upgrade

1. Install GitHub Copilot upgrade. For instructions, see [Install GitHub Copilot upgrade](install.md).
1. Open the repository that contains the TypeScript project in a supported GitHub Copilot environment.
1. Ask the agent to upgrade TypeScript. Name the target version when you need a specific release. For example:

   - _"Upgrade this project to the latest TypeScript version."_
   - _"Upgrade TypeScript to version 7."_

1. Review the detected current and target compiler versions.
1. Let the agent capture the compile and runtime baseline.
1. Review the changes and validation results for each major-version step.

## How compiler upgrades work

The agent moves through major TypeScript versions one at a time. At each step, it updates the compiler, compiles the project, and resolves errors caused by that compiler version. This approach keeps failures tied to a specific version transition and avoids combining unrelated breaking changes.

The agent preserves strictness settings and fixes affected code instead of suppressing new errors. It might also update related `@types` packages when their versions must remain compatible with the underlying libraries and compiler.

## Validate the result

After the final compiler update, the agent compiles the project again and repeats the runtime validation plan. Review the summary for:

- Starting and ending TypeScript versions.
- Successful and unsuccessful version transitions.
- Source and configuration changes.
- Compile and runtime validation results.
- Preexisting code defects exposed by the newer compiler.

For details about runtime checks, see [Validate a JavaScript or TypeScript application](javascript-typescript-validate-application.md).

## Related content

- [Upgrade JavaScript and TypeScript projects](javascript-typescript-overview.md)
- [Upgrade JavaScript and TypeScript dependencies](javascript-typescript-upgrade-dependencies.md)
- [JavaScript and TypeScript capabilities](javascript-typescript-capabilities.md)
