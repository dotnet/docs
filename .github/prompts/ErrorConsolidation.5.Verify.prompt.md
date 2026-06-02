---
model: Claude Opus 4.6 (copilot)
agent: agent
description: Verifies all error messages in a consolidated article match Roslyn source verbatim
tools: ['vscode', 'execute', 'read', 'agent', 'edit', 'search', 'todo']
---

# Verify error messages against Roslyn source

You are verifying that every error message in a consolidated compiler error article matches the verbatim text from the Roslyn compiler source. The user will provide:

- **Destination filename** — the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`

## Key file locations

- **Destination file**: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- **Roslyn ErrorCodes**: `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCodes.cs`
- **Roslyn Resources**: `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx`

## Verification process

### Step 1: Extract all error codes from the destination file

Read the destination file and collect every error code referenced in:
- The master error list at the top of the article (the bulleted list after the H1)
- Any error lists within thematic H2 sections

### Step 2: Look up each error message in Roslyn source

For each error code:

1. Extract the numeric portion (e.g., `CS0220` → `220`).
2. Find the constant with that number in `ErrorCodes.cs`. It will appear as something like:
   ```csharp
   ERR_CheckedOverflow = 220,
   ```
3. Find the corresponding `<data>` element in `CSharpResources.resx` whose `name` attribute matches the constant name exactly (e.g., `ERR_CheckedOverflow`):
   ```xml
   <data name="ERR_CheckedOverflow" xml:space="preserve">
     <value>The operation overflows at compile time in checked mode</value>
   </data>
   ```
4. Extract the text from the `<value>` element. This is the **verbatim** compiler error message.

**Note on format strings:** Some error messages contain placeholders like `'{0}'`, `'{1}'`, `{0}`, `{1}`, etc. In the documentation, these are typically replaced with descriptive terms like `'value'`, `'type'`, `'operator'`, etc. When comparing, treat placeholder substitutions as matches — only flag differences in the static text portions of the message.

### Step 3: Compare and report

Compare each Roslyn source message against every instance of that error's message in the destination file (both the master list and the thematic section lists).

Build a report of mismatches:

```
| Error Code | Location | Current Text | Roslyn Source Text |
|-----------|----------|-------------|-------------------|
| CS0220 | Master list | The operation overflows at compile time | The operation overflows at compile time in checked mode |
| CS0220 | Overflow section | The operation overflows at compile time | The operation overflows at compile time in checked mode |
```

If there are no mismatches, report: *All error messages match the Roslyn source.*

### Step 4: Fix mismatches

For each mismatch found:

1. Update the error message text in the destination file to match the Roslyn source verbatim.
2. Apply the fix in **all** locations where the message appears (master list, thematic section lists, and any inline references in the body text).
3. When replacing placeholders, use the same descriptive terms that appear in the current text (e.g., keep `'value'` for `'{0}'`) — only fix the static text portions.

### Step 5: Present results

After all fixes are applied, present:

1. The total number of error codes verified.
2. The number of mismatches found and fixed.
3. A list of all corrections made, showing the before and after text.
