---
title: Upgrade JavaScript and TypeScript dependencies
description: Use GitHub Copilot upgrade to update npm dependencies and repair compatibility problems in JavaScript and TypeScript projects.
ms.topic: how-to
ms.date: 09/21/2026
ai-usage: ai-generated

#customer intent: As a JavaScript or TypeScript developer, I want to update project dependencies and resolve breaking changes with GitHub Copilot.
---

# Upgrade JavaScript and TypeScript dependencies

Use GitHub Copilot upgrade to update selected npm packages or all dependencies in a JavaScript or TypeScript project. The agent scans the dependency graph, groups related packages, applies framework-specific guidance, and repairs compatibility problems introduced by the updates.

## Start the upgrade

1. Install GitHub Copilot upgrade. For instructions, see [Install GitHub Copilot upgrade](install.md).
1. Open the repository in a supported GitHub Copilot environment.
1. Ask the agent to update all dependencies or name the packages that you want to update. For example:

   - _"Upgrade all dependencies in this project."_
   - _"Upgrade React and its peer dependencies."_
   - _"Upgrade axios to the latest version."_

1. Review the proposed scope. For a package-specific upgrade, confirm whether the agent should include related peer dependencies.
1. Let the agent establish the compile, build, test, and runtime baseline before it updates packages.
1. Review the compatibility repairs and final validation summary.

## How package upgrades work

The agent preserves the scope you request. For a package-specific request, it doesn't update unrelated dependencies. If the selected package requires compatible peer dependencies, the agent identifies those dependencies and asks you to confirm the expanded scope.

For supported frameworks, the agent applies framework-specific migration guidance and required package groupings. It upgrades one dependency group at a time and validates each group before it continues. If an updated package requires a newer TypeScript version, the agent applies the smallest compatible compiler change or starts the structured compiler upgrade when the required version crosses multiple major releases.

## Validate the result

After the dependency updates, the agent repeats the project checks it captured before the upgrade. For details about the available checks, see [Validate a JavaScript or TypeScript application](javascript-typescript-validate-application.md).

Review the final summary for:

- Packages that the agent updated successfully.
- Packages that the agent couldn't update.
- Source or configuration changes that resolve breaking changes.
- Compile, build, test, and runtime validation results.
- Environment, authentication, or toolchain blockers.

## Related content

- [Upgrade JavaScript and TypeScript projects](javascript-typescript-overview.md)
- [Upgrade the TypeScript compiler](javascript-typescript-upgrade-typescript.md)
- [JavaScript and TypeScript capabilities](javascript-typescript-capabilities.md)
