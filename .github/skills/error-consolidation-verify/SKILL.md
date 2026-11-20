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

Match the complete constant name, including fatal `FTL_` prefixes. An uncommented `ErrorCode.cs` entry is the inclusion authority even if no emitting reference is found. Don't invent a reproduction or classify such an entry as obsolete solely because it isn't emitted by an observed compiler invocation.

If an existing historical diagnostic has a commented-out enum entry and no current resource, record it as a legacy exception. Preserve its existing historical explanation unless removal is approved, and don't claim its message was verified against a nonexistent current resource. Report missing resources for active entries as unresolved verification failures.

Messages can contain placeholders such as `'{0}'`, `'{1}'`, `{0}`, or `{1}`. Documentation normally replaces them with descriptive terms. Treat those substitutions as matches and compare the static text.

Check that every placeholder is represented, including unquoted placeholders. Normalize XML entities before comparing text. Preserve compiler contractions, punctuation, and quotation marks rather than applying prose style rules to quoted messages.

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

## Step 5: Verify Behavior, Discovery, and Links

- Check remediation against the actual parser, API validation, or emitting source. Run focused compiler probes for new or corrected examples, including the failing input and its correction where an emitter is available. Record the compiler version separately from the Roslyn source revision. Isolate fixtures so wildcard source options don't include unrelated test files.
- Distinguish a retained diagnostic definition from demonstrated emission. For example, a PDB path need not enable PDB generation or reproduce CS2036; verify current behavior instead of inferring it from the historical message.
- Verify equal, duplicate-free code sets in `f1_keywords`, `helpviewer_keywords`, the numeric master list, thematic lists, and TOC `displayName`. Verify unique F1 ownership across C# articles, including the catch-all.
- Verify redirects for retired standalone articles and confirm obsolete redirect-only codes weren't added as new destination coverage.
- Verify every master-list anchor and relative article link. If a `See also` section exists, include all its relative links; otherwise report that the section isn't present.
- Run existing Markdown lint and whitespace checks. Confirm the linter actually processed the changed file: a successful invocation that reports zero files isn't validation. Use explicit file processing or the installed linter API with repository rules if glob matching fails.

## Step 6: Present Results

Present:

1. The total number of codes reviewed, current-resource messages verified, and legacy or unresolved exceptions.
2. The number of mismatches found and fixed.
3. Every correction, with before and after text.
4. The result of the `See also` relative-link check.
5. Behavior probes, ownership, redirects, anchor checks, and actual lint file counts. Leave edits on the prepared branch for human review; don't commit, push, or proceed to merge unless explicitly instructed.
