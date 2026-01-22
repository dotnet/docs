---
ms.topic: include
ms.date: 01/22/2026
---

## Prerequisites

- A GitHub account with an active [GitHub Copilot](https://github.com/features/copilot) subscription under any plan.
- The latest version of [Visual Studio Code](https://code.visualstudio.com/). Must be version 1.101 or later.
    - [GitHub Copilot in Visual Studio Code](https://code.visualstudio.com/docs/copilot/overview). For setup instructions, see [Set up GitHub Copilot in Visual Studio Code](https://code.visualstudio.com/docs/copilot/setup). Be sure to sign in to your GitHub account within Visual Studio Code.
    - [GitHub Copilot app modernization](https://marketplace.visualstudio.com/items?itemName=vscjava.migrate-java-to-azure). Restart Visual Studio Code after installation.
- A .NET development environment to build and test the project.

## Assess app readiness

GitHub Copilot app modernization for .NET assessment helps you find app readiness challenges, learn their impact, and see recommended migration tasks. Each migration task includes references to set up Azure resources, add configurations, and make code changes. Follow these steps to start your migration:

1. Clone the [.NET migration copilot samples](https://github.com/Azure-Samples/dotnet-migration-copilot-samples) repository to your computer.

2. In Visual Studio Code, open the **Contoso University** solution from the samples repository.

3. Open the **GitHub Copilot app modernization** extension.

4. In the **QUICKSTART** section, select **Start Assessment**. The **Assessment reports** page opens.

5. Select **Run Assessment** in the upper-right corner of the page.

:::image type="content" source="../media/vscode/start-assessment.png" alt-text="Screenshot of run a task in tasks section to start a migration task.":::

6. The assessment starts automatically and analyzes your project for migration readiness.

:::image type="content" source="../media/vscode/assessment-in-process.png" alt-text="Screenshot of run a task in tasks section to start a migration task.":::

7. When the assessment finishes, you see a comprehensive assessment report UI page and a list of migration tasks in the chat window.

:::image type="content" source="../media/vscode/assessment-report.png" alt-text="Screenshot of run a task in tasks section to start a migration task.":::

## App migrations

GitHub Copilot app modernization for .NET includes [predefined tasks](../predefined-tasks.md) for common migration scenarios and follows Microsoft's best practices.

### Start a migration task

Start a migration task in one of the following ways:

**Option 1. Run from the Assessment Report**

Select the **Run Task** button in the Assessment Report from the previous step to start a migration task.

**Option 2. Apply a predefined task**

Run the specific task in the **TASKS - .NET** section. For example, the **Migrate Database to Azure Database for PostgreSQL** task under **Database Tasks** updates your database connection, configurations, dependencies, and data access code to use Azure Database for PostgreSQL.

:::image type="content" source="../media/vscode/run-task.png" alt-text="Screenshot of run a task in tasks section to start a migration task.":::

### Plan and progress tracker generation

- When you start the migration, GitHub Copilot starts a session in agent mode.

- The tool creates two files in the `.github/appmod/code-migration/<target-branch-name>` folder:
  - `plan.md`: The overall migration plan.
  - `progress.md`: A progress tracker that GitHub Copilot updates as it completes tasks.

- Edit these files to customize your migration before you continue.

:::image type="content" source="../media/vscode/start-migration.png" alt-text="Screenshot of plan generation during a migration task.":::

### Start code remediation

- When you're satisfied with the plan and progress tracker, enter **continue** to start the migration.

- GitHub Copilot starts the migration process and might ask for your approval to use knowledge base tools in the Model Context Protocol (MCP) server. Grant permission when prompted.

- Copilot follows the plan and progress tracker to:
  - Manage dependencies.
  - Apply configuration changes.
  - Make code changes.
  - Build the project, fix all compilation and configuration errors, and ensure a successful build.
  - Fix security vulnerabilities.

- Repeatedly select or enter **Continue** to confirm the use of tools or commands and wait for the code changes to finish.

> [!NOTE]
> In Visual Studio Code, app modernization uses the `AppModernization-DotNet` custom agent with Claude Sonnet 4.5 by default for best results when updating .NET code to migrate to Azure. It falls back to the 'auto' model if Sonnet 4.5 is not available to you. You can configure the custom agent to [modify the 'model' setting](https://code.visualstudio.com/docs/copilot/customization/custom-agents#_custom-agent-file-structure) by selecting **Configure Custom Agents** from the **Agent** menu. Alternatively, you can use the language model picker in the chat window to switch models for the current chat session.


### Validation iteration

After the code changes finish, the migration proceeds with a validation and fix iteration loop. This loop includes the following five parts:

1. Detect Common Vulnerabilities and Exposures (CVEs) in current dependencies and fix them.
1. Build the project and resolve any build errors.
1. Analyze the code for functional consistency.
1. Analyze the project for unit test failures and automatically generate a plan to fix them until the tests pass.
1. Analyze the code for migration items missed in the initial code migration and fix them.

After all processes complete, the migration generates a summary as the final step. Review the code changes and confirm them by selecting **Keep**.
