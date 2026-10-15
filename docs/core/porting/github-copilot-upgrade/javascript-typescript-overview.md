---
title: Upgrade JavaScript and TypeScript projects with GitHub Copilot
description: Learn how GitHub Copilot upgrade updates JavaScript and TypeScript dependencies, upgrades the TypeScript compiler, and validates applications.
ms.topic: overview
ms.date: 09/21/2026
ai-usage: ai-generated

#customer intent: As a JavaScript or TypeScript developer, I want to understand which upgrades GitHub Copilot can perform so that I can choose the right workflow for my project.
---

# Upgrade JavaScript and TypeScript projects with GitHub Copilot

GitHub Copilot upgrade can update npm dependencies, upgrade the TypeScript compiler, repair compatibility problems, and validate JavaScript and TypeScript applications. The agent detects the project structure and applies guidance for supported frameworks and libraries.

JavaScript-only projects don't need a `tsconfig.json`. For these projects, the agent preserves valid JavaScript and uses the project's own build and test scripts as part of validation.

## Choose an upgrade workflow

- To update one package, a group of packages, or all project dependencies, see [Upgrade JavaScript and TypeScript dependencies](javascript-typescript-upgrade-dependencies.md).
- To move a project through TypeScript compiler versions, see [Upgrade the TypeScript compiler](javascript-typescript-upgrade-typescript.md).
- To check an application before or after an upgrade, see [Validate a JavaScript or TypeScript application](javascript-typescript-validate-application.md).
- To compare the available workflows, see [JavaScript and TypeScript capabilities](javascript-typescript-capabilities.md).

## What the agent validates

The agent establishes a baseline before it changes dependencies or the compiler. Based on the project, validation can include compilation, bundler builds, tests, command-line execution, server startup, endpoint checks, and browser flows. After the upgrade, the agent repeats the relevant checks and repairs regressions caused by the upgrade.

## Related content

- [GitHub Copilot upgrade overview](overview.md)
- [Install GitHub Copilot upgrade](install.md)
- [GitHub Copilot upgrade concepts](concepts.md)
- [Troubleshoot GitHub Copilot upgrade](troubleshooting.md)
