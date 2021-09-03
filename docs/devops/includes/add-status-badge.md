---
author: IEvangelist
ms.author: dapine
ms.date: 07/01/2021
ms.topic: include
recommendations: false
---

## Create a workflow status badge

It's common nomenclature for GitHub repositories to have a *README.md* file at the root of the repository directory. Likewise, it's nice to report the latest status for various workflows. All workflows can generate a status badge, which are visually appealing within the *README.md* file. To add the workflow status badge:

1. From the GitHub repository select the **Actions** navigation option.
1. All repository workflows are displayed on the left-side, select the desired workflow and the ellipsis (**...**) button.

    - The ellipsis (**...**) button expands the menu options for the selected workflow.

1. Select the **Create status badge** menu option.

    :::image type="content" source="../media/create-status-badge.png" lightbox="../media/create-status-badge.png" alt-text="GitHub: Create status badge":::

1. Select the **Copy status badge Markdown** button.

    :::image type="content" source="../media/copy-status-badge.png" lightbox="../media/copy-status-badge.png" alt-text="GitHub: Copy status badge Markdown":::

1. Paste the Markdown into the *README.md* file, save the file, commit and push the changes.

For more, see [Adding a workflow status badge](https://docs.github.com/actions/managing-workflow-runs/adding-a-workflow-status-badge).
