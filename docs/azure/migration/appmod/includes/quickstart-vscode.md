---
ms.topic: include
ms.date: 01/22/2026
---

## Prerequisites

- A GitHub account with an active [GitHub Copilot](https://github.com/features/copilot) subscription under any plan.
- The latest version of [Visual Studio Code](https://code.visualstudio.com/). Must be version 1.101 or later.
    - [GitHub Copilot in Visual Studio Code](https://code.visualstudio.com/docs/copilot/overview). For setup instructions, see [Set up GitHub Copilot in Visual Studio Code](https://code.visualstudio.com/docs/copilot/setup). Be sure to sign in to your GitHub account within Visual Studio Code.
    - [GitHub Copilot app modernization](https://marketplace.visualstudio.com/items?itemName=vscjava.migrate-java-to-azure). Restart Visual Studio Code after installation.
- .NET development environment to build and test the project.

## Assess app readiness


## App migrations

GitHub Copilot app modernization for .NET includes [predefined tasks](../predefined-tasks.md) for common migration scenarios and follows Microsoft's best practices.

### Start a migration task

Start a migration task in one of the following ways:

**Option 1. Run from the Assessment Report**

Select the **Run Task** button in the Assessment Report from the previous step to start a migration task.

**Option 2. Apply a predefined tasks**

Run the specific task in the **TASKS - dotnet** section.

:::image type="content" source="media/vscode/run-task.png" alt-text="Screenshot of run a task in tasks section to start a migration task.":::

### Plan and progress tracker generation

- When you start the migration, GitHub Copilot starts a session in agent mode.
- The tool creates two files in the `.github/appmod/code-migration/<target-branch-name>` folder:
  - `plan.md` - the overall migration plan
  - `progress.md` - a progress tracker; GitHub Copilot marks items as it completes tasks
- Edit these files to customize your migration before you continue.

:::image type="content" source="media/vscode/start-migration.png" alt-text="Screenshot of plan generation during a migration task.":::

### Start code remediation

- If you're satisfied with the plan and progress tracker, manually input **continue** to start the migration

- GitHub Copilot starts the migration process and might ask for your approval to use knowledge base tools in the Model Context Protocol (MCP) server. Grant permission when prompted.
- Copilot follows the plan and progress tracker to:
  - Manage dependencies
  - Apply configuration changes
  - Make code changes
  - Build the project, fix all compilation and configuration errors, and ensure a successful build
  - Fix security vulnerabilities
- You need to repeatedly select or input **Continue** to confirm the use of tools or commands and wait for the code changes to finish.

### Validation iteration

After the code changes finish, migration proceeds with the validation and fix iteration loop. This loop includes the following five parts:

- Detect Common Vulnerabilities and Exposures (CVEs) in current dependencies and fixes them.
- Build the project and resolve any build errors.
- Analyze the codes for functional consistency.
- Analyze the project for unit test failures and automatically generates a plan to fix them until the tests pass.
- Analyze the codes if migration items missed in initial code migration and fixes them.

After all processes complete, generate the migration summary as the final step. Review the code changes and confirm them by selecting **Keep**.
