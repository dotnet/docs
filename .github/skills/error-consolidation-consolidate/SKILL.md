---
name: error-consolidation-consolidate
description: Reorganizes a consolidated C# diagnostic article into approved resolution themes. Use after the article's diagnostic set is complete.
---

# Consolidate Error Sections by Resolution Theme

Replace individual diagnostic H2 sections with thematic H2 sections organized around shared resolution strategies.

## Required Input

Collect the **destination filename** for the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`.

## Key Paths

- Destination: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- Reference examples: Other `*-errors.md` files in `docs/csharp/language-reference/compiler-messages/`

## Phase A: Propose Themes

1. Read the destination and identify every error code and current H2 section.
2. Read two or three other consolidated `*-errors.md` files to learn the expected structure and tone.
3. Group codes by their messages, underlying language rules, and shared resolution strategies. Each theme must represent a coherent set of related diagnostics.
4. For each proposed theme, provide:
   - The title that would become its H2 heading and anchor.
   - The included error codes.
   - A one-sentence rationale.

Present the proposal and stop:

```markdown
### Proposed themes

1. **Operator signature requirements** (`#operator-signature-requirements`)
   - CS0448, CS0559, CS0562, CS0563, CS0564, CS0567, CS0590
   - These errors all relate to invalid parameter or return types in operator declarations.

2. **Overflow and underflow errors** (`#overflow-and-underflow-errors`)
   - CS0031, CS0220, CS0221, CS0463, CS0543, CS0594, CS0652, CS1021, CS8778, CS8973
   - These errors all involve constant values or operations that exceed type boundaries.
```

Tell the user:

> Review and approve each theme. Let me know which to proceed with and any adjustments.

Wait for user approval before proceeding to Phase B.

## Phase B: Build Approved Thematic Sections

For each approved theme, complete the following steps.

### 1. Update the Master Error List

Link each code to its theme anchor and keep the complete list in numeric order:

```markdown
- [**CS{NNNN}**](#{theme-anchor}): *{verbatim compiler error message}*
```

### 2. Create the Thematic H2

Replace the theme's individual diagnostic H2 sections with one section:

```markdown
## {Theme title}

- **CS{NNNN}**: *{verbatim error message}*
- **CS{NNNN}**: *{verbatim error message}*

{Resolution-focused content}
```

Repeat codes and messages without anchor links inside the thematic section.

### 3. Write Resolution-Focused Content

- Focus on correcting each diagnostic rather than teaching the full language feature.
- Link to the language reference and relevant C# specification sections that explain the enforced rules. Use repository-consistent links.
- State what to change and why in complete, direct, action-oriented sentences. Identify affected codes in bold parentheses. Keep the guidance concise while retaining the source requirement to explain the correction fully. For example:

  > Change the return type of `++` or `--` operators to the containing type or a type derived from it (**CS0448**). The language requires that increment and decrement operators return a value compatible with the containing type so the result can be assigned back to the same variable.

- Remove lengthy examples. Brief inline code is acceptable.
- Do not add H3 headings; keep each thematic section flat under its H2.
- Explicitly identify diagnostics that the latest C# compiler no longer produces.
- Reuse source text or a brief source example when it supports the resolution.

### 4. Remove Absorbed H2 Sections

Delete every individual `## CS{NNNN}` section absorbed into the theme.

## Final Checks

After building all approved themes:

1. Verify the master list is in numeric order.
2. Verify every front matter code appears in the master list.
3. Verify every master-list code links to an existing thematic anchor.
4. Verify no individual diagnostic H2 section remains orphaned.
