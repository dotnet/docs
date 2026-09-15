---
name: error-consolidation-verify
description: Verifies a consolidated C# diagnostic article against Roslyn and checks See also links. Use as the final validation and correction phase.
---

# Verify Consolidated Error Messages

Verify every compiler message in a consolidated diagnostic article against Roslyn source, fix all mismatches, and report the results.

## Required Input

Collect the **destination filename** for the consolidated `.md` file in `docs/csharp/language-reference/compiler-messages/`.

## Key Paths

- Destination: `docs/csharp/language-reference/compiler-messages/{destination-filename}`
- Roslyn error codes: `../roslyn/src/Compilers/CSharp/Portable/Errors/ErrorCode.cs`
- Roslyn resources: `../roslyn/src/Compilers/CSharp/Portable/CSharpResources.resx`

## Step 1: Extract All Error Codes

Read the destination and collect every code referenced in:

- The master error list after the H1.
- Error lists within thematic H2 sections.

## Step 2: Look Up Roslyn Messages

For each code:

1. Extract the numeric portion, such as `CS0220` to `220`.
2. Find the constant assigned that number in `ErrorCode.cs`, for example:

   ```csharp
   ERR_CheckedOverflow = 220,
   ```

3. Find the `<data>` element in `CSharpResources.resx` whose `name` exactly matches the constant:

   ```xml
   <data name="ERR_CheckedOverflow" xml:space="preserve">
     <value>The operation overflows at compile time in checked mode</value>
   </data>
   ```

4. Extract the `<value>` text as the verbatim compiler message.

Messages can contain placeholders such as `'{0}'`, `'{1}'`, `{0}`, or `{1}`. Documentation normally replaces them with descriptive terms. Treat those substitutions as matches and compare the static text.

## Step 3: Compare Every Instance

Compare the Roslyn message with every documented instance for that code, including the master list and all thematic section lists.

Report mismatches in this form:

```markdown
| Error Code | Location | Current Text | Roslyn Source Text |
|------------|----------|--------------|--------------------|
| CS0220 | Master list | The operation overflows at compile time | The operation overflows at compile time in checked mode |
| CS0220 | Overflow section | The operation overflows at compile time | The operation overflows at compile time in checked mode |
```

If none differ, report: `All error messages match the Roslyn source.`

## Step 4: Fix All Mismatches

For every mismatch:

1. Update the destination to match Roslyn's static message text.
2. Apply the correction everywhere the message appears, including the master list, thematic lists, and inline body references.
3. Preserve the destination's current descriptive placeholder substitutions; change only mismatched static text.

## Step 5: Verify See Also Links

If the article has a `See also` section, verify that every relative link resolves to an existing, reachable target in the current repository branch. Report and fix broken relative links.

## Step 6: Present Results

Present:

1. The total number of codes verified.
2. The number of mismatches found and fixed.
3. Every correction, with before and after text.
4. The result of the `See also` relative-link check.
