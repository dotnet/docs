---
title: Apply custom upgrade instructions for .NET upgrades
description: "Create and apply custom upgrade instructions with GitHub Copilot to automate .NET upgrades. Learn to write, test, and integrate instructions for consistent transformations."
author: kschlobohm
ms.topic: how-to
ms.date: 12/12/2025
ai-usage: ai-assisted

#customer intent: As a developer, I want to apply custom upgrade instructions during a .NET upgrade so that I can automate specific changes consistently.

---

# Apply custom upgrade instructions for .NET upgrades

Custom upgrade instructions are markdown files that guide GitHub Copilot app modernization to apply specific transformations during an upgrade. Create these files to automate repetitive changes, such as replacing one library with another or guiding how to apply a specific upgrade of an API.

This article explains how to create a custom upgrade instruction file, test it in isolation, and use it during the assessment stage of an upgrade. You learn how to structure the instruction file, verify it works correctly, and integrate it into the upgrade workflow.

## Prerequisites

Before you begin, ensure you have these requirements:

[!INCLUDE [github-copilot-app-modernization-prereqs](../../../includes/github-copilot-app-modernization-prereqs.md)]

## Understand custom upgrade instructions

GitHub Copilot app modernization retrieves custom upgrade instructions as markdown files on demand during the assessment and planning stages of an upgrade. They differ from `copilot-instructions.md` because they're:

- Targeted to automating code and dependency changes.
- Retrieved only when relevant to the current upgrade assessment or plan.
- Reusable across solutions when copied into each repository.

Structure your instruction files with:

- A short title describing the action. For example, "replace Newtonsoft.Json with System.Text.Json."
- A concise problem statement or prerequisite section.
- Explicit step logic ("If X is found, do Y")—avoid vague language.
- (Recommended) One or more diff examples captured from actual local edits to guide transformations.

## Create a custom upgrade instruction

Follow these steps to generate and refine a new instruction file. These sections focus on replacing `Newtonsoft.Json` with `System.Text.Json` to explain this feature with an example.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In the chat, type: `I want to generate a custom upgrade instruction`.
1. When asked, provide a scenario like `I want to replace Newtonsoft with System.Text.Json` to have Copilot create the file.
1. When Copilot creates the new file, such as `replace_newtonsoft_with_system_text_json.md`, review the content and refine it in chat. For example, ask Copilot to "clarify detection criteria" or "add a prerequisite section."

   > [!TIP]
   > Add the file to the solution for visibility if it isn't already included.

1. Strengthen the instruction with real diff examples.

   1. Make the desired code changes manually in one project. For example, "remove the `Newtonsoft.Json` package, update using directives, and replace `JsonConvert` code with `JsonSerializer`."
   1. In chat, with the instruction file open, type: `Check my git changes and add diffs as examples to my instruction file`.
   1. Confirm Copilot used a git diff and appended a fenced diff block or structured example to the markdown file.

### Authoring tips

Follow these guidelines to write clear, effective custom upgrade instructions that Copilot can interpret reliably:

- Use clear conditional phrasing: `If code references X, then do Y.`
- Keep one transformation per file; use prerequisites when multiple files must run in sequence.
- Improve transformation accuracy by providing at least one concrete example, such as a diff or before/after snippet.
- Avoid ambiguous verbs like "improve" or "fix"; use explicit actions like "replace," "remove," and "update."

## Test a custom upgrade instruction (one-time run)

Before running the instruction during an upgrade, validate it in isolation. This fast inner loop helps you refine detection and validate the code changes.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In chat, invoke the instruction by using wording similar to the file name. For example, `replace Newtonsoft with System.Text.Json`.
1. Confirm in the chat window that Copilot retrieved the instruction file:

   ```text
   > Getting instructions for 'replace Newtonsoft with System.Text.Json'.
   
   Perfect! I've retrieved the scenario instructions for migrating from Newtonsoft.Json to System.Text.Json. Now I'll begin the analysis following the scenario-specific instructions.
   ```

   If you don't see an indication that the instructions were found, retry using key words from the file's name, such as the same verb and noun combinations.

1. Review the proposed changes (solution diffs, pending commits, or previewed modifications) to validate the custom upgrade instruction behaves as planned.

### Validation tips

If the test run doesn't produce the expected results, use these troubleshooting tips to refine your instruction file:

- If Copilot only updates package versions instead of performing a replacement, ensure the instruction explicitly says to remove or replace the old package.
- Use consistent naming so natural language activation matches. For example, the file name starts with `replace_` and your chat request begins with "Replace ...".
- Add missing code patterns you discover during testing as more examples to improve coverage.

## Apply custom instructions during an upgrade

Use these steps to incorporate an existing custom upgrade instruction into the assessment stage of an upgrade.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In the chat, choose `Upgrade to a newer version of .NET`. Answer Copilot's questions until it begins the assessment.
1. Monitor the chat to see if Copilot automatically retrieves your custom instruction file during the assessment. You should see a message indicating it opened the markdown instruction file.

   If the custom instructions aren't automatically applied, explicitly request them. Use wording similar to the file name. For example, `use the custom instructions to replace Newtonsoft with System.Text.Json during the assessment`.

1. Wait for Copilot to confirm it retrieved the file. If you don't see a reference to the instruction file, restate the request using the file's key verbs (replace, update, remove) and package names.
1. Review the generated `assessment.md` file in the `.github/upgrades` folder. Confirm the assessment includes issues and changes identified by your custom instruction.

   For example, when replacing Newtonsoft, the assessment identifies:
   - Projects using `Newtonsoft.Json` packages.
   - Code patterns that need refactoring to use `System.Text.Json`.
   - Dependencies that need to be removed or replaced.

1. If needed, edit the `assessment.md` file to add context or adjust the identified issues before proceeding.
1. Tell Copilot to continue to the planning stage once the assessment reflects your custom instruction.
1. Review the `plan.md` file that Copilot generates. It should include strategies for addressing the issues identified during assessment.
1. Continue through the execution stage by telling Copilot to proceed. Monitor the `tasks.md` file as Copilot applies the transformations.

### Tips for better activation

How you name and invoke custom upgrade instructions affects whether Copilot retrieves them automatically. Follow these guidelines to improve activation reliability:

- Match the file's verb. If the file name uses `replace`, use that phrasing (not `upgrade` or `fix`).
- Keep one transformation per file for clarity and reuse. Sequence multiple files by listing prerequisites in each file.
- Request custom instructions during the assessment stage for best results, rather than waiting until planning or execution.
- Avoid ambiguous requests like "improve the assessment." Be explicit: "apply the replace_newtonsoft_with_system_text_json instructions during assessment."

## Validate the applied changes

After the upgrade completes:

1. Review the `tasks.md` file in `.github/upgrades` to see the status of tasks related to your custom instruction.
1. Check the Git commits created during the execution stage for changes related to the custom instruction.
1. Run your tests to ensure functional behavior remains correct.
1. **Optional**: Capture a diff example from the successful change and add it to the instruction file to strengthen future automation.

## Clean up resources

If you create temporary instruction files for experimentation, remove or consolidate them to avoid overlapping transformations in future upgrades.

## Related content

- [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md)
- [GitHub Copilot app modernization FAQ](faq.yml)
- [What is GitHub Copilot app modernization](overview.md)
