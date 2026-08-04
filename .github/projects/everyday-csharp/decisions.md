> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Key Decisions

### Decision 1: Null safety is its own section

**Choice:** Null safety gets a standalone sub-section within Fundamentals, covering both nullable value types and nullable reference types with a comparison between the two.

**Rationale:** Null safety is cross-cutting. It touches the type system, expressions, patterns, and API design. Nullable reference types are the single most impactful feature for code quality in C#, and "all new code should use this." Giving it its own section signals that  importance and provides a single place to learn the complete null safety story.

**Terminology:** Use only the official null-state vocabulary, and define each term before the rule that uses it. A variable's *null state* is either *not-null* or *maybe-null*; the null state *changes* on a line (it doesn't "move"). A nullable *annotation* (`?`) states the design intent for a reference type — whether a variable is *meant* to hold null — and is distinct from null state; don't describe an annotation as a "hint." Define "null state" at first use before stating the analysis rules.

**Migration content lives in Advanced.** Strategies for adding nullable annotations to an existing pre-C# 8 codebase fail Filter A (universality) and stay at `advanced-topics/update-applications/nullable-migration-strategies.md`; the Fundamentals null-safety articles link out rather than inlining migration guidance.

### Decision 2: Strings is its own section

**Choice:** Strings get a standalone sub-section within Fundamentals.

**Rationale:** Strings are one of the most-used types in C#, and the existing how-to articles (search, split, concatenate, modify, compare) are among the highest-traffic pages in the C# docs. C# has significantly improved string handling with interpolation (C# 6), raw string literals (C# 11), and interpolated raw strings. The string type also has a rich API surface already documented in the API reference — the Fundamentals content focuses on *using* strings idiomatically, not exhaustively documenting every method.

**Scope boundary:** Custom interpolated string handlers, allocation avoidance techniques, and `Span<char>` manipulation are deferred to Focus
or Advanced sections.

### Decision 3: Remove anonymous types from Fundamentals

**Choice:** Anonymous types are removed from the Fundamentals section
entirely.

**Rationale:** Tuples (C# 7+) are the preferred solution for lightweight unnamed data structures. Anonymous types remain documented in the Language Reference for developers maintaining older code, but they aren't part of "Everyday C#" for new development.

### Decision 4: Async basics subset in Fundamentals

**Choice:** A small async sub-section appears in Fundamentals, after OOP. It covers consuming async methods with `await` and declaring `async` methods that call other async methods. A brief mention of `await foreach` (async streams) links to the Async Focus section.

**Rationale:** Almost all C# applications consume async APIs. Developers need to understand `await` and the `async` method declaration pattern as part of everyday coding. However, the full async model (cancellation, `ConfigureAwait`, parallel patterns, custom awaiters, `TaskCompletionSource`, etc.) belongs in the dedicated Async Focus section.

### Decision 5: New extensions syntax replaces `this` extension methods

**Choice:** The Fundamentals section teaches the new C# 14 extension syntax as the primary way to write extensions. The legacy `this` parameter syntax gets a brief note as the older approach.

**Rationale:** C# 14 extensions are "a major design space" that subsumes and improves upon extension methods. They support extension properties and other member kinds beyond methods. Teaching the new syntax first gives readers the most useful and forward-looking mental model.

**Placement:** Extensions appear in the OOP sub-section, since they extend types with new members.

### Decision 6: Follow the C# standard's ordering

**Choice:** The Fundamentals section ordering follows the C# standard (§7→§23), with non-standard content (coding style, tutorials) appearing after standard-aligned sections.

**Rationale:** The C# standard represents a carefully considered progression through the language. Following it provides a coherent learning path and makes it easy for readers familiar with the standard to find content. It also provides a principled answer to "where does this topic go?" for any future content.

### Decision 7: Delegates scope — `Func<>` and `Action<>` are fundamental

**Choice:** Delegates are covered in Fundamentals when used as `Func<...>` and `Action<...>` types. Lambda expressions are the primary syntax shown. More advanced scenarios (declaring custom delegate types, multicast delegates, advanced event patterns) are deferred.

**Rationale:** Every C# developer uses `Func<>` and `Action<>` through LINQ, async callbacks, and everyday APIs. Lambda expressions are the idiomatic way to create delegates. The full delegate model with custom declarations and multicast invocation lists is a deeper topic that most developers encounter less frequently.

**Structure:** A basic delegates/lambdas article appears in the Type system section (introduction), with deeper lambda coverage in both OOP (callbacks, event handlers, method parameters) and Functional techniques (closures, captures, functional patterns).

### Decision 8: Generics scope — consuming is fundamental, authoring is Focus

**Choice:** The basics of generics (consuming generic types like `List<T>`, calling generic methods, basic type constraints) are fundamental. Authoring generic algorithms is a Focus section topic.

**Rationale:** You can't write real C# without consuming generics. `List<T>`, `Dictionary<TKey, TValue>`, `Task<T>`, `Func<T>`, and `IEnumerable<T>` are everywhere. Understanding type parameters, basic constraints, and covariance/contravariance at the consumption level is essential. Designing generic algorithms with complex constraint combinations is a specialized skill.

### Decision 9: Events — basic subscribe/unsubscribe is fundamental

**Choice:** Basic event usage (subscribing, unsubscribing, the standard event pattern) appears in Fundamentals. Custom event accessors, advanced multicast scenarios, and designing event-based architectures are deferred.

**Rationale:** Events are pervasive in .NET (UI frameworks, ASP.NET middleware, domain events). Developers need to know how to subscribe to and raise events. The internal mechanics of custom event accessors are a niche topic.

### Decision 10: Example-heavy articles with "Everyday C#" feature saturation

**Choice:** Every Fundamentals article leads with code examples and uses everyday C# features throughout its samples — not only the feature the article teaches.

**Rationale:** Most engineers learn a language by reading and writing code, not by reading prose descriptions. Articles should therefore be structured as short explanatory text followed by meaningful, runnable examples. Additionally, samples should incorporate the full "Everyday C#" feature set: features from "Include and explain," features from "Use in sample code without detailed explanation," and the applicable subsets from "Include a subset." For instance, an article on exception handling should still use file-scoped namespaces, collection expressions, nullable reference types, and raw string literals when they fit naturally. This consistent exposure helps readers internalize idioms across the entire Fundamentals section.

**Implications for authors:**

- *Structure each article as concept → example → concept → example*, not as a wall of prose with a code block at the end. Put the concepts readers must not miss near the top; when framing a newer feature, state what the syntax is for and show the newer or less familiar variant first, then the equivalent baseline form. Use headings that name the concept without gerund (`-ing`) forms unless the official term requires one, and use a short intro plus bullets for enumerations of operators, options, or common forms, including items that also have their own subsection.
- *Prefer small, focused examples* that each illustrate one point, over large monolithic samples. Don't repeat code or content already shown earlier in the same article; if the recommended form is clear from code and explaining why would pull in out-of-scope concepts, demonstrate it and move on.
- *Make each sample readable on first pass.* For any construct a sample isn't teaching, pick the most familiar form (`while` or `foreach` before `for`; a regular method before a static factory). Add a brief intent comment on any line whose purpose or syntax isn't obvious, such as the spread element in a collection expression or the line that triggers deferred LINQ execution. When the sample illustrates a decision, show both branches and print the result as a trailing comment (`// => …`). When two syntaxes produce the same result, make the output comments identical so the equivalence is visible.
- *Review every sample's using directives, type declarations, and local variables* to confirm they use the latest syntax (e.g., `global using`, file-scoped namespace, `var`, collection expressions, primary constructors) even when those features aren't the article's topic.
- *Treat the three feature tables as a checklist* when writing or reviewing samples. If a feature from "Use in sample code without detailed explanation" appears naturally, use it without commentary. If a feature from "Include a subset" is relevant to the scenario, include it with a brief link to its full article. Keep link boilerplate small: when a paragraph mostly points elsewhere, choose the single best "For more information" target instead of stacking links.

### Decision 11: Fundamentals folder layout — concepts, common tasks, tutorials

**Choice:** Each Fundamentals section uses a three-bucket folder layout:

- *Concept articles and the section overview* live at the section's top level (for example, `fundamentals/strings/index.md`, `fundamentals/strings/interpolation.md`).
- *Task-style articles* that answer "how do I do X?" live under a `<section>/common-tasks/` subfolder (for example, `fundamentals/strings/common-tasks/search.md`), with their snippet projects under `<section>/common-tasks/snippets/`. The section's `toc.yml` renders a nested **Common tasks** group beneath the concept articles — a collapsible subnode, not a flat heading.
- *Tutorials* live flat under `fundamentals/tutorials/` rather than nested per section.

Sections without task-style articles don't get a `common-tasks/` subfolder.

**Rationale:** Readers scan a section's TOC for either "explain this to me" (concepts) or "show me how to do this specific thing" (tasks). Visually separating the two via folder structure and a nested TOC group reduces cognitive load and signals which articles teach a concept versus demonstrate a task. Flat tutorials keep the tutorial index discoverable as a single learning path rather than scattering tutorials across section folders.

**Origin:** Adopted in [PR 11 (#53991)](https://github.com/dotnet/docs/pull/53991), which moved `search.md` and `split.md` under `fundamentals/strings/common-tasks/`, relocated `resolve-warnings.md` to `fundamentals/null-safety/common-tasks/`, and moved the NRT tutorial to the flat `fundamentals/tutorials/` folder.

### Decision 12: Expressions and operators section

**Choice:** Add a dedicated **Expressions and operators (§12)** section, positioned per the C#
standard **after Pattern matching (§11) and before Statements (§13)**. It has two concept articles:
an overview + operator-precedence article (`fundamentals/expressions/index.md`) and an operators
article (`fundamentals/expressions/operators.md`).

**Rationale:** §12 is the largest clause in the standard, but the earlier plan had no home for the
core operator set — arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`),
relational (`< > <= >=`), equality operators (`== !=`), conditional-logical (`&& ||`), the
conditional operator (`?:`), operator precedence/associativity, and simple + compound assignment.
These pass both fit-test filters (universal and beginner-accessible), so they belong in Fundamentals.
The section is sequenced before Statements because expressions are the building blocks that
statements compose, matching §12 → §13.

**Scope boundary (excluded → Language Reference, cross-linked):** shift operators (`<< >> >>>`,
§12.13), integer/bitwise logical operators (`& | ^ ~`, §12.15/§12.9.5), and `checked`/`unchecked`
(§12.8.20) are too niche for everyday code (fail Filter A). They stay in the Language Reference; the
new articles cross-link out. The equality *operators* get a survey slot here, but equality
*semantics* live in the dedicated equality article. **As shipped (PR [#54849](https://github.com/dotnet/docs/pull/54849)), that article was relocated out of Type system into a new `fundamentals/expressions/` folder — it now lives at `fundamentals/expressions/equality.md`** and renders as the first child of the combined "Expressions and statements" TOC node. It is
cross-linked rather than duplicated. The conditional `?:` operator is taught here; trimming its
mention in the merged Selection-statements article is a **deferred later-cleanup item**.

**Ordering (Option A):** The Fundamentals section order mirrors the standard where content belongs
to a clause: Program structure → Type system → Null safety → Strings → **Pattern matching (§11)** →
**Expressions and operators (§12)** → **Statements (§13)** → Functional techniques → Namespaces →
OOP → Async → Exceptions → Attributes → XML docs → Coding style. Pattern-matching articles move to a
`fundamentals/patterns/` folder (their own §11 section) instead of `fundamentals/functional/`.

**§12 coverage map (for the authors of the two new articles).** §12 is the standard's largest clause
and its subclauses are scattered across already-merged sections; the two new articles own only the
gap. Use this map to avoid duplicating covered material and to wire cross-links to the existing homes.

*Write in the new Expressions articles (the gap — nothing owns these today):* operator precedence &
associativity + evaluation order (§12.4.2); arithmetic `+ - * / %` (§12.12); unary `+ - !`
(§12.9.2–4); increment/decrement `++ --` (§12.8.16, §12.9.7); relational `< > <= >=` (§12.14.1–4);
equality-operator survey `== !=` (§12.14.5–11); conditional-logical `&& ||` with short-circuiting
(§12.16); conditional operator `?:` (§12.20, re-homed from Selection statements); simple + compound
assignment `= += -= *= /= %=` (§12.23.2/.5).

*Already covered elsewhere (cross-link, do not re-teach):* literals/`default`/`new`
(§12.8.2/.17/.21 → Type system > Built-in types); interpolated strings (§12.8.3 → Strings);
`nameof` (§12.8.23 → Strings); tuple literals (§12.8.6 → Type system > Tuples); null-conditional
`?.`/`?[]` and null-coalescing `??`/`??=` (§12.8.8/.11/.13, §12.17 → Null safety > Null operators);
null-forgiving `!` (§12.8.9 → Null safety > NRT); cast/`as` (§12.9.8, §12.14.13 → Type system >
Conversions); index-from-end `^` and range `..` (§12.9.6, §12.10 → Collections / Indexers); `await`
(§12.9.9 → Async); switch expression (§12.11 → Pattern matching, §11); `is` (§12.14.12 → Pattern
matching); throw expression (§12.18 → Exceptions); lambdas (§12.21 → Delegates / Functional); query
expressions/LINQ (§12.22 → Statements > LINQ); deconstructing assignment (§12.23.3 → Patterns >
Deconstruction); event assignment (§12.23.6 → OOP > Events). Equality *semantics* (`Equals`,
`GetHashCode`, record equality) live in the dedicated equality article (`fundamentals/expressions/equality.md`, relocated there from Type system in PR #54849); the new
survey cross-links to it.

*Excluded from Fundamentals (Q6 — stay in Language Reference, cross-link out only):* shift
`<< >> >>>` (§12.13); integer/bitwise logical `& | ^` and complement `~` (§12.15, §12.9.5);
`checked`/`unchecked` (§12.8.20).

### Decision 12b: Consolidate Namespaces (§14) to one canonical article

**Choice:** The standalone **Namespaces (§14)** article (`fundamentals/namespaces/overview.md`,
article #100) is the canonical §14 home. The shipped Program-structure article
`fundamentals/program-structure/namespaces.md` (article #4) is slimmed to a brief intro +
cross-reference to #100.

**Rationale:** §14 Namespaces is its own clause, distinct from §7 program structure, and the two
articles duplicated file-scoped namespaces, global/static `using`, and aliases. Consolidating removes
the overlap and keeps Program structure focused on §7. Because the program-structure article is
already published, the slim requires a redirect (if any URL changes) and a repo-wide inbound-link fix
per the build-clean rule.

