---
title: Validate a JavaScript or TypeScript application
description: Use GitHub Copilot upgrade to compile, build, test, run, and inspect a JavaScript or TypeScript application.
ms.topic: how-to
ms.date: 09/21/2026
ai-usage: ai-generated

#customer intent: As a JavaScript or TypeScript developer, I want to validate my application so that I can detect regressions before and after an upgrade.
---

# Validate a JavaScript or TypeScript application

Use GitHub Copilot upgrade to create and run a repeatable validation plan for a JavaScript or TypeScript project. You can run validation as part of a dependency or compiler upgrade, or request a standalone application health check.

## Start validation

1. Install GitHub Copilot upgrade. For instructions, see [Install GitHub Copilot upgrade](install.md).
1. Open the repository in a supported GitHub Copilot environment.
1. Ask the agent to validate the application. For example, enter _"Validate this application before I upgrade its dependencies."_
1. Review the checks that the agent selects for the project.
1. Let the agent run the validation plan and review the results.

## Validation checks

The validation plan reflects how the project actually runs. Based on the available scripts and application type, the plan can:

- Install project dependencies with the configured package manager.
- Compile TypeScript or type-check JavaScript.
- Run the project's build and test scripts.
- Start a command-line application, server, or web application.
- Probe application endpoints.
- Exercise browser workflows and verify expected results.

The agent keeps the plan deterministic so it can safely repeat the same checks. The plan distinguishes application failures from invalid checks and reports environment or credential blockers instead of weakening assertions.

## Validation during an upgrade

For dependency and compiler upgrades, the agent captures a baseline before it changes the project. After the upgrade, it repeats the plan and compares the results. The comparison helps the agent focus repairs on regressions introduced by the upgrade.

Standalone validation checks the current project health without creating or changing an upgrade baseline.

## Related content

- [Upgrade JavaScript and TypeScript projects](javascript-typescript-overview.md)
- [Upgrade JavaScript and TypeScript dependencies](javascript-typescript-upgrade-dependencies.md)
- [Upgrade the TypeScript compiler](javascript-typescript-upgrade-typescript.md)
- [JavaScript and TypeScript capabilities](javascript-typescript-capabilities.md)
