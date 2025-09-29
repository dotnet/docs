# Copilot-Optimized Instructions: Breaking Change Documentation

## When to use this prompt

- If assigned an issue labeled `breaking-change`  
- If given a link to an issue referencing this prompt and asked to create a breaking change document

## General rules

- **Format:** Use Markdown
- **Scope:**  
  - Ignore docs under [`docs/framework/migration-guide`](https://github.com/dotnet/docs/tree/main/docs/framework/migration-guide) (for legacy .NET Framework)  
  - Document ONLY modern .NET breaking changes
- **Writing style:**  
  - Make content clear and concise  
  - Previous behavior: **past tense**  
  - New behavior: **present tense**

## Document structure

Start with this header (replace placeholders):

```
---
title: "Breaking change - <Concise descriptive title>"
description: "Learn about the breaking change in <product/version without preview> where <brief description>."
ms.date: <Today's date in MM/DD/YYYY format>
ai-usage: ai-assisted
ms.custom: <URL of the issue>
---
```
> **Note:** Use today's date in the format MM/DD/YYYY. This date cannot be earlier than 9/29/2025.

Then include these sections in this order:

### 1. H1 Title

- Use the header title, **removing "Breaking change - "**.

**Intro paragraph:**  
Summarize the breaking change. Include the major version (omit preview number).

### 2. Version introduced

- Version where change was introduced (include preview number if applicable).

### 3. Previous behavior

- Briefly describe past behavior.
- Include example code snippets if relevant.

### 4. New behavior

- Briefly describe new behavior.
- Include example code snippets if relevant.

### 5. Type of breaking change

- If **behavioral change**:  
  `This is a [behavioral change](../../categories.md#behavioral-change).`
- If **source or binary incompatible**:  
  `This change can affect [source compatibility](../../categories.md#source-incompatible) and/or [binary compatibility](../../categories.md#binary-incompatible).`
- If multiple types:  
  Link to each type in a single sentence.
- If none specified:  
  State "No specific type listed."

### 6. Reason for change

- Explain why the change was made.
- Include relevant links.

### 7. Recommended action

- Describe what users should do to adapt.
- Include code examples if helpful.

### 8. Affected APIs

- Bullet list of affected APIs.
- Use **xref-style links** as described in `copilot-instructions.md`.
- If none: Write "None."

## Final steps

- **Add the new doc to the [TOC file](https://github.com/dotnet/docs/blob/main/docs/core/compatibility/toc.yml).**
- **Add an entry to the index file under the appropriate area H2 heading.**
- **Create a pull request.**
  - In the description, include: `Fixes #<issue-number>` (replace with the correct number).
  - Request review on the pull request from the person who opened the issue.

---

**Copilot optimization notes:**  
- All steps and formatting are condensed and clarified for rapid, accurate document drafting.
- Section ordering and linking instructions are explicit for automation.
- Xref/linking and PR closing instructions are surfaced for easy action.
