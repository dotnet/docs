---
model: Claude Opus 4.6 (copilot)
agent: agent
description: Reorganizes individual error H2s into thematic sections with resolution focus
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'todo']
---

# Consolidate error sections and rewrite for resolution

You are reorganizing a consolidated error article so individual per-error H2s become thematic H2 sections focused on resolution. The user will provide:

- **Destination filename** — the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`

## Key file locations

- **Destination file**: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- **Reference examples**: Other `*-errors.md` files in the same folder (study these for structural patterns)

## Phase A: Propose themes

1. Read the destination file and identify all error codes and their current H2 sections.
2. Read 2-3 other consolidated error files in `docs/csharp/language-reference/compiler-messages/` to understand the expected structure and tone.
3. Group the error codes into themes based on their error messages, underlying language rules, and resolution strategies. Each theme should represent a coherent set of related diagnostics.
4. Propose the list of themes with:
   - A theme title (which becomes the H2 heading and anchor)
   - The included error codes
   - A one-sentence rationale for the grouping

**Present the theme list to the user and stop.** Format as:

```
### Proposed themes

1. **Operator signature requirements** (`#operator-signature-requirements`)
   - CS0448, CS0559, CS0562, CS0563, CS0564, CS0567, CS0590
   - These errors all relate to invalid parameter or return types in operator declarations.

2. **Overflow and underflow errors** (`#overflow-and-underflow-errors`)
   - CS0031, CS0220, CS0221, CS0463, CS0543, CS0594, CS0652, CS1021, CS8778, CS8973
   - These errors all involve constant values or operations that exceed type boundaries.
```

Tell the user: *Review and approve each theme. Let me know which to proceed with and any adjustments.*

**Wait for user approval before proceeding to Phase B.**

## Phase B: Build thematic sections

For each approved theme:

### 1. Update the master error list at the top of the file

Each error code in the master list should link to its theme's anchor. Keep the list in **numerical order** by error code. Format:

```markdown
- [**CS{NNNN}**](#{theme-anchor}): *{verbatim compiler error message}*
```

### 2. Create the thematic H2 section

Replace all the individual-error H2s that belong to this theme with a single thematic H2:

```markdown
## {Theme title}

- **CS{NNNN}**: *{verbatim error message}*
- **CS{NNNN}**: *{verbatim error message}*
...

{Resolution-focused content}
```

The error list within the section repeats the codes and messages but **without anchor links** (they're already in the section).

### 3. Write resolution-focused content

The content in each thematic section should focus on **how to correct each error**, not on explaining the language feature. Follow these rules:

- **Link to language reference:** Provide links to language reference articles and C# specification sections that explain the rules these diagnostics enforce. For example, link to `https://github.com/dotnet/docs/blob/main/docs/csharp/language-reference/operators/operator-overloading.md` or the relevant spec section.
- **Write detailed corrections:** For each correction, use a full sentence explaining what to do and why. Put the affected error codes in parentheses, in **bold** style. Example:
  > Change the return type of `++` or `--` operators to the containing type or a type derived from it (**CS0448**). The language requires that increment and decrement operators return a value compatible with the containing type so the result can be assigned back to the same variable.
- **No extensive examples:** Remove lengthy code examples. Brief inline code references are acceptable.
- **No H3 headings:** Keep the section flat under the H2.
- **Note obsolete errors:** If any error codes are no longer produced in the latest version of C#, explicitly note that.
- **Incorporate source material:** Where applicable, reuse text or brief examples from the individual H2s you're replacing.

### 4. Remove the old individual H2s

After creating the thematic section, delete all individual-error H2s (`## CS{NNNN}`) that were absorbed into it.

## Final check

After all themes are built:

1. Verify the master error list at the top is still in numerical order.
2. Verify every error code in the front matter has a corresponding entry in the master list.
3. Verify every error code in the master list links to a valid anchor in the article.
4. Verify there are no orphaned H2 sections (individual error H2s that weren't grouped into a theme).
