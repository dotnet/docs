---
model: GPT-4.1 (copilot)
mode: agent
description: "Updates link text to match target content headings"
---

# Refresh Links Prompt

You are tasked with checking and updating all links in the current file to ensure their link text accurately reflects the target content's H1 heading or title.

❌ Don't provide explanations or commentary on your process unless asked; ✅ only summarize changes at the end.

## ⚠️ CRITICAL CONSTRAINT ⚠️

**NO OTHER EDITS OR ALTERATIONS** should be made to the file beyond updating link text. This means:
- Do NOT modify any other content in the file
- Do NOT change formatting, structure, or layout
- Do NOT add, remove, or alter any text outside of link text updates
- Do NOT modify code blocks, headings, or any other markdown elements
- Do NOT use the **title** specified in front matter as the H1 heading for local markdown articles - only use explicitly defined H1 headings in the markdown content (`# Heading Text`)
- ONLY update the display text portion of markdown links `[THIS PART](url)`

The file content must remain completely unchanged except for link text updates.

## Link Types and Processing Rules

### 1. Relative Links (e.g., `./folder/file.md`, `../folder/file.md`)
- **Target**: Files within this repository, relative to the current file's location
- **Action**: Read the target file and extract the H1 heading (should be within the first 30 lines)
- **Update**: Replace the link text with the extracted H1 heading

### 2. Root-Relative Links (e.g., `/dotnet/core/introduction`)
- **Target**: Published pages on https://learn.microsoft.com/
- **Action**: Fetch the page from `https://learn.microsoft.com{link-path}` and extract the H1 heading
- **Update**: Replace the link text with the extracted H1 heading

### 3. Repository Root Links (e.g., `~/docs/csharp/fundamentals/index.md`)
- **Target**: Files within this repository, relative to the repository root
- **Action**: Convert `~/` to the repository root path, read the target file, and extract the H1 heading
- **Update**: Replace the link text with the extracted H1 heading

### 4. Full URLs (e.g., `https://example.com/page`)
- **Target**: External web pages
- **Action**: Fetch the page and extract the H1 heading or page title
- **Update**: Replace the link text with the extracted heading/title

### 5. XREF links (e.g., `[link text](xref:api-doc-id)`)
- **Target**: API documentation links
- **Action**: Do not change the link text, ignore this type of item.

## Processing Instructions

1. **Scan the file**: Identify all markdown links in the format `[link text](url)`

2. **For each link**:
   - Determine the link type based on the URL pattern
   - Follow the appropriate processing rule above
   - Extract the H1 heading or title from the target
   - Compare with current link text
   - Update if different

3. **Check for bookmark**:
   - If the link contains a bookmark (e.g., `file.md#section`), use the markdown heading instead of H1 as the link text

4. **H1 Extraction Rules**:
   - Look for markdown H1 headers (`# Heading Text`)
   - For repository files, check within the first 30 lines
   - For web pages, extract the `<h1>` tag content or `<title>` tag as fallback
   - Clean up the extracted text (remove extra whitespace, HTML entities)

5. **Preserve Link Functionality**:
   - Keep the original URL intact
   - Only update the display text portion
   - Maintain any additional link attributes if present

6. **Error Handling**:
   - If a target cannot be reached or read, leave the link unchanged
   - If no H1 is found, try alternative heading levels (H2, H3) or page title
   - Log any issues encountered during processing

## Example Transformations

```markdown
Before: [Old Link Text](../core/install/windows.md)
After:  [Install .NET on Windows](../core/install/windows.md)

Before: [Old Link Text](../core/install/linux.md#system-requirements)
After:  [System requirements](../core/install/linux.md#system-requirements)

Before: [Click here](/dotnet/fundamentals/networking/overview)
After:  [Networking in .NET](/dotnet/fundamentals/networking/overview)

Before: [Link](~/docs/csharp/fundamentals/types/index.md)
After:  [C# Type System](~/docs/csharp/fundamentals/types/index.md)

Before: [External](https://example.com/some-page)
After:  [Example Page](https://example.com/some-page)
```

## Output

Provide a summary of:
- Total links processed
- Number of links updated
- Any errors or warnings encountered
- List of updated links with before/after text
