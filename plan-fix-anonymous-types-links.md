# Plan: Restore anonymous types article and fix mislinked references

Commit 6e4216e bulk-replaced `anonymous-types.md` → `tuples.md` links. Most of those links explicitly discuss C# anonymous types as a language feature and need to point to a new dedicated article instead.

---

## Phase 1: Create the anonymous types article

**Step 1.1 — Remove redirect** in `.openpublishing.redirection.csharp.json` for `programming-guide/classes-and-structs/anonymous-types.md` → tuples. Keep the *other* redirect (`fundamentals/types/anonymous-types.md` → tuples).

**Step 1.2 — Author new article** at `docs/csharp/programming-guide/classes-and-structs/anonymous-types.md` covering:

- What anonymous types are (compiler-generated `internal class`, read-only properties)
- Syntax: `new { Prop = value }` with object initializer
- Requirement to use `var`
- Inferred property names, equality semantics
- Use in LINQ query expressions
- Limitations (can't be return types, parameters, or fields; scoped to method)
- Brief comparison linking to `tuples.md#tuples-vs-anonymous-types`
- Code snippets in `snippets/anonymous-types/csharp/`

**Step 1.3 — Add to TOC** in `docs/csharp/toc.yml`, after "Tuples and deconstruction":

```yaml
    - name: Anonymous types
      href: programming-guide/classes-and-structs/anonymous-types.md
```

---

## Phase 2: Fix 21 incorrect links across 19 files

Update links where anchor text says "Anonymous types" but target is `tuples.md` → new `anonymous-types.md`:

| # | File | Line | New relative target |
|---|------|------|-------------------|
| 1 | `docs/csharp/whats-new/csharp-version-history.md` | 380 | `../programming-guide/classes-and-structs/anonymous-types.md` |
| 2 | `docs/csharp/linq/standard-query-operators/join-operations.md` | 176 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 3 | `docs/csharp/linq/standard-query-operators/index.md` | 110 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 4 | `docs/csharp/linq/get-started/features-that-support-linq.md` | 67 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 5 | `docs/csharp/language-reference/statements/declarations.md` | 61 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 6 | `docs/csharp/language-reference/operators/new-operator.md` | 50 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 7 | `docs/csharp/language-reference/operators/with-expression.md` | 12 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 8 | `docs/csharp/language-reference/keywords/select-clause.md` | 37 | `../../programming-guide/classes-and-structs/anonymous-types.md` |
| 9 | `docs/csharp/programming-guide/classes-and-structs/object-and-collection-initializers.md` | 57 | `anonymous-types.md` |
| 10 | `docs/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md` | 46 | `anonymous-types.md` |
| 11 | `docs/csharp/programming-guide/classes-and-structs/implicitly-typed-local-variables.md` | 97 | `anonymous-types.md` |
| 12 | `docs/csharp/programming-guide/classes-and-structs/how-to-use-implicitly-typed-local-variables-and-arrays-in-a-query-expression.md` | 17 | `anonymous-types.md` |
| 13 | `docs/csharp/programming-guide/classes-and-structs/how-to-return-subsets-of-element-properties-in-a-query.md` | 48 | `anonymous-types.md` |
| 14 | `docs/csharp/programming-guide/classes-and-structs/access-modifiers.md` | 96 | `anonymous-types.md` |
| 15 | `docs/csharp/misc/cs0746.md` | 46 | `../programming-guide/classes-and-structs/anonymous-types.md` |
| 16 | `docs/csharp/misc/cs0833.md` | 41 | `../programming-guide/classes-and-structs/anonymous-types.md` |
| 17 | `docs/core/diagnostics/diagnosticsource-diagnosticlistener.md` | 69 | `../../csharp/programming-guide/classes-and-structs/anonymous-types.md` |
| 18 | `docs/fundamentals/code-analysis/style-rules/ide0050.md` | 30 | `../../../csharp/programming-guide/classes-and-structs/anonymous-types.md` |
| 19 | `docs/fundamentals/code-analysis/style-rules/ide0050.md` | 83 | `../../../csharp/programming-guide/classes-and-structs/anonymous-types.md` |
| 20 | `docs/fundamentals/code-analysis/style-rules/ide0037.md` | 32 | `../../../csharp/programming-guide/classes-and-structs/anonymous-types.md` |
| 21 | `docs/fsharp/language-reference/anonymous-records.md` | 215 | `../../csharp/programming-guide/classes-and-structs/anonymous-types.md` |

### Links kept pointing to `tuples.md` (correct — these discuss the concept/comparison, not the feature)

- `docs/standard/base-types/choosing-between-anonymous-and-tuple.md` L49, L115
- `docs/standard/linq/concepts-terminology-functional-transformation.md` L60
- `docs/standard/linq/project-anonymous-type.md` L28, L75

---

## Verification

1. Grep for remaining `anonymous.type` text linking to `tuples.md` — ensure none missed
2. Check all 21 relative paths resolve correctly
3. Validate redirect removal doesn't break external URLs (the `fundamentals/types/anonymous-types.md` redirect still covers that old path)
4. Run code snippets to confirm they compile
5. Build check for broken links

## Decisions

- Only the `programming-guide/classes-and-structs/anonymous-types.md` redirect is removed; the `fundamentals/types/anonymous-types.md` redirect stays
- 4 links in `docs/standard/` stay on `tuples.md` (comparison/conceptual context)
- New article placed in `programming-guide/classes-and-structs/` reusing the old path
- TOC entry placed in "Type system" section alongside tuples, records, etc.
