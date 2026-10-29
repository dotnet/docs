> Part of the [Everyday C# plan](README.md). Future backlog, not an October commitment.

## Phase P: Documentation comments (Annex D)

Documentation comments are explicitly included. Unsafe code and all other appendixes remain outside this Fundamentals expansion.

### PR 36 — Document code and produce XML documentation

Sources:

- `docs/csharp/language-reference/xmldoc/{index,recommended-tags,examples}.md`.
- `docs/csharp/fundamentals/tutorials/xml-documentation.md`.
- `docs/csharp/fundamentals/coding-style/coding-conventions.md` for relevant comment conventions only.

Proposed teaching destinations: `fundamentals/xml-comments.md` and `fundamentals/xml-comments/common-tasks/documentation-tools.md`. Retain and reconcile the existing tutorial. Don't create another coding-style comments article that teaches the same basics.

1. Teach `///`, `<summary>`, `<param>`, `<returns>`, `<exception>`, and `<see cref>` with short documented declarations. Distinguish a useful contract explanation from a restatement of an identifier.
2. Demonstrate compiler-generated XML with `GenerateDocumentationFile` and `dotnet build`; confirm actual output and the warnings the chosen settings enable.
3. Separate writing comments, generating XML, and publishing an API website. Link to current tool documentation rather than promise DocFX/Sandcastle walkthroughs before their suitability is checked.
4. Address [dotnet/docs#34830](https://github.com/dotnet/docs/issues/34830) through a deliberate teaching/reference split: extract introductory workflow into Fundamentals, retain the complete tag/`cref` rules as reference unless a separately reviewed move preserves that function.
5. The coding-style/design-alternatives and console-tutorial pieces formerly bundled in PR 36 are routed to [PR 45](phase-q-supporting-work.md#pr-45--coding-style-and-console-tutorial-reconciliation) and [Building software](phase-r-building-software.md), not dropped.

### Review units and closeout

| Unit | Reuse / reader outcome | Completion evidence |
|---|---|---|
| Comment concept | Reconcile the existing XML tutorial's contract/IntelliSense motivation with `xmldoc/index.md` and `recommended-tags.md`; the planned `xml-comments.md` teaches writing useful API contracts, not the complete tag catalog. | A short documented method has meaningful summary/parameter/return/failure text and a resolving `cref`; comments describe obligations rather than repeat names. |
| XML generation procedure | Check the tutorial's existing `GenerateDocumentationFile`/build steps before creating `common-tasks/documentation-tools.md`; if they already own the complete bounded procedure, retain them and omit the duplicate how-to. | Build an existing project, inspect its generated XML/member identifiers and actual warnings, and name the output path. No website generator is required. |
| Existing tutorial and reference | Keep `fundamentals/tutorials/xml-documentation.md`'s outcome of documenting the preceding OOP sample; review its dependence on `fundamentals/tutorials/oop.md` if that sample changes. Keep full tags/`cref` lookup in Language Reference. | Live links connect concept → tutorial → full reference; any extracted reference introduction points to Fundamentals without destroying reference completeness. |

**Dependencies and sequence:** Enter after O, using H/K's member/interface contract vocabulary.
No source generator or documentation-server dependency is needed to prove XML generation.
PR 36 closes the G-P foundation wave; R follows only after its content/navigation checks pass.
Q's optional style/analyzer/console work isn't an extra foundation gate.

**Done when:** the tutorial and concept/how-to pages have distinct outcomes, code and `cref` targets compile, generated XML is verified, reference tags keep a canonical lookup home, and any approved retirements/moves include redirects and navigation/link repairs.
