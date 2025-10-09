---
title: How to apply custom upgrade instructions during an upgrade
description: "Learn how to apply custom upgrade instructions with GitHub Copilot app modernization so they're executed automatically during a .NET upgrade."
author: kschlobohm
ms.author: adegeo
ms.topic: how-to
ms.date: 10/07/2025
ai-usage: ai-assisted

#customer intent: As a developer, I want to apply custom upgrade instructions during a .NET upgrade so that I can automate specific changes consistently.

---

# Apply custom upgrade instructions during a .NET upgrade

GitHub Copilot app modernization executes reusable, task-focused guidance stored as custom upgrade instruction files. During an upgrade, incorporate these instructions into the generated plan so Copilot applies opinionated replacements, refactorings, or policy-driven changes (for example, replacing `Newtonsoft.Json` with `System.Text.Json`).

This article shows how to create a custom upgrade instruction, test it with a fast inner loop, and apply it automatically during a full upgrade.

## Prerequisites

Before you begin, ensure you have these requirements:

[!INCLUDE[github-copilot-app-mod-prereqs](../../includes/github-copilot-app-mod-prereqs.md)]

## Understand custom upgrade instructions

Custom upgrade instructions are markdown files that Copilot retrieves on demand while planning or executing an upgrade. They differ from `copilot-instructions.md` because they're:

- Targeted to automating code and dependency changes.
- Retrieved only when relevant to the current user request or plan modification.
- Reusable across solutions when copied into each repository.

Structure your instruction files with:

- A short title describing the action (for example, Replace Newtonsoft.Json with System.Text.Json).
- A concise problem statement or prerequisite section.
- Explicit step logic ("If X is found, do Y")—avoid vague language.
- (Recommended) One or more diff examples captured from actual local edits to guide transformations.

## Create a custom upgrade instruction

Follow these steps to generate and refine a new instruction file. These sections focus on replacing `Newtonsoft.Json` with `System.Text.Json` to explain this feature with an example.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In the chat, type: `I want to generate a custom upgrade instruction`.
1. When asked, provide a scenario like `I want to replace Newtonsoft with System.Text.Json` to have Copilot create the file.
1. (Optional) Add the file to the solution for visibility if it isn't already included.
1. When Copilot creates the new file (for example, `replace_newtonsoft_with_system_text_json.md`), review the content and refine it in chat. For example, ask Copilot to clarify detection criteria or add a prerequisite section.
1. (Recommended) Strengthen the instruction with a real diff example:
   1. Make the desired code changes manually in one project (for example, remove the `Newtonsoft.Json` package, update using directives, and replace `JsonConvert` code with `JsonSerializer`).
   1. In chat, with the instruction file open, type: `Check my git changes and add diffs as examples to my instruction file`.
   1. Confirm Copilot used a git diff and appended a fenced diff block or structured example to the markdown file.

### Authoring tips

- Use clear conditional phrasing: "If code references X, then do Y."
- Keep one transformation per file; use prerequisites when multiple files must run in sequence.
- Provide at least one concrete example (diff or before/after snippet) to improve transformation accuracy.
- Avoid ambiguous verbs like "improve" or "fix"—use explicit actions like replace, remove, update.

## Test a custom upgrade instruction (one-time run)

Before running the instruction during an upgrade plan, validate it in isolation. This fast inner loop helps you refine detection and validate the code changes.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In chat, invoke the instruction using wording similar to the file name. For example: `Replace Newtonsoft with System.Text.Json`.
1. Confirm in the chat window that Copilot retrieved the instruction file (it shows the text "Getting more instructions"). If it didn't, retry by using the key words from the file's name such as using the same verb (replace/update/remove) and nouns (Newtonsoft/System.Text.Json).
1. Review the proposed changes (solution diffs, pending commits, or previewed modifications) to validate the custom upgrade instruction behaves as planned.

### Validation tips

- If Copilot only updates package versions instead of performing a replacement, ensure the instruction explicitly says to remove or replace the old package.
- Use consistent naming so natural language activation matches (for example, file name starts with `replace_` and your chat request begins with "Replace ...").
- Add missing code patterns you discover during testing as more examples to improve coverage.

## Apply custom instructions during an upgrade

Use these steps to incorporate an existing custom upgrade instruction into an upgrade plan.

1. In the **Solution Explorer** window, right-click the **solution** > **Modernize**.
1. In the chat, choose `Upgrade to a newer version of .NET`. Answer Copilot's questions until it generates the plan markdown file.
1. Review the generated plan. Confirm whether the intended transformation (for example, replacing Newtonsoft.Json) is already present. If it only lists a version bump, your custom instruction wasn't yet applied.
1. In chat, explicitly reference the instruction using language similar to the file name. For example: `Modify the plan using the custom instructions to replace Newtonsoft with System.Text.Json`.
1. Wait for Copilot to confirm it retrieved the file. In chat, you see that it opened the markdown instruction file. If you don't see a reference, restate the request using the file's key verbs (replace, update, remove) and package names.
1. Review the plan file and verify that it includes the custom instruction's details:
   - Review package actions. When replacing Newtonsoft, the plan switches from a version bump to now describing replacement/removal instead of a version upgrade.
   - Review execution steps. Any new execution steps referencing the transformation appear under the plan's step list.

   :::image type="content" source="./media/github-copilot-app-modernization-how-to-custom-upgrade-instructions/visualstudio-copilot-upgrade5.png" alt-text="The screenshot shows the effect of applying a custom upgrade instruction to the upgrade plan. Instead of upgrading Newtonsoft.Json, the plan now removes it and incorporates System.Text.Json as the replacement, explicitly listing the package removal and corresponding additions/changes that occur during execution.":::

   :::image type="content" source="./media/github-copilot-app-modernization-how-to-custom-upgrade-instructions/visualstudio-copilot-upgrade6.png" alt-text="The screenshot shows the project-level (feature) actions added by the custom upgrade instruction. Projects that previously referenced Newtonsoft.Json are now slated for code refactoring to use System.Text.Json APIs.":::

1. Tell Copilot to proceed with the upgrade once the plan reflects your custom instruction.
1. Monitor the **Upgrade Progress Details**. If Copilot pauses due to conflicts or compilation errors, resolve issues and instruct it to continue.

### Tips for better activation

- Match the file's verb: if the file name uses replace, use that phrasing (not upgrade or fix).
- Keep one transformation per file for clarity and reuse; sequence multiple files by listing prerequisites in each file.
- Ask Copilot to modify the plan rather than manually editing; this reduces the risk of breaking dependency ordering.
- Avoid ambiguous requests like "improve the plan"; be explicit: "apply the replace_newtonsoft_with_system_text_json instructions."

## Validate the applied changes

After the upgrade completes:

1. Review the upgrade report for commits related to the custom instruction.
1. Run your tests to ensure functional behavior remains correct.
1. (Optional) Capture a diff example from the successful change and add it to the instruction file to strengthen future automation.

## Clean up resources

If you created temporary instruction files for experimentation, remove or consolidate them to avoid overlapping transformations in future upgrades.

## Related content

- [How to upgrade a .NET app with GitHub Copilot app modernization](how-to-upgrade-with-github-copilot.md)
- [GitHub Copilot app modernization FAQ](github-copilot-app-modernization-faq.yml)
- [What is GitHub Copilot app modernization](github-copilot-app-modernization-overview.md)
