> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

## Proposed Fundamentals TOC

The following outline shows every article in the proposed Fundamentals section, its status (existing, needs revision, new, or pulled from another location), and key content notes.

### Program structure (§7)

| # | Article | Status | Notes |
|---|---|---|---|
| 1 | Overview | 🟡 Revise | Add file-scoped namespaces, global usings as default style. Distinguish the uses of file-based apps, top-level statements / project-based apps, and `Main`-style project-based apps. |
| 2 | Main method and entry points | ✅ Exists | Include async Main (C# 7.1). Include file-based apps |
| 3 | Top-level statements | ✅ Exists | Mention file-local types (C# 11) as helpers |
| 4 | Namespaces and using directives | 📝 New | *Slimmed to a brief intro + cross-reference* per [Decision 12b](decisions.md#decision-12-expressions-and-operators-section): the canonical §14 treatment lives in the standalone [Namespaces (§14)](#namespaces-14) section (article #100). This article keeps a short intro to file-scoped namespaces and using directives in the context of program structure and links to #100. Needs a redirect + repo-wide inbound-link fix (shipped article). |
| 5 | Preprocessor directives | 📝 New | `#if`, `#region`, `#nullable`, `#pragma warning` only |
| 67 | Tutorial: Build file-based apps | ✅ Exists | |
| 68 | Tutorial: Display command-line arguments | ✅ Exists | Consider a top-level statements pivot, and a file-based apps pivot. File-based apps pivot should be the default. |
| 77 | Tutorial: Console application | 📥 Pull from Tutorials | |
| 90 | Tutorial: Build a command-line app with System.CommandLine | 📝 New | Demonstrate `System.CommandLine` for commands, subcommands, arguments, and options |
| 98 | Organizing programs | 📝 New | Assemblies, namespaces, and types as organizational tools. Addresses [#34836](https://github.com/dotnet/docs/issues/34836). |

### Type system (§8)

| # | Article | Status | Notes |
|---|---|---|---|
| 6 | Overview | 🟡 Revise | Value vs. reference, unified type system, built-in types overview. Discuss use cases for tuples vs. records vs. structs vs. classes vs. interfaces. |
| 7 | Built-in types and literals | 📝 New | Numeric (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literal syntax (binary, digit separators, raw string literals), `default` expressions, `var`, target-typed `new` (C# 9), `dynamic` (C# 4) |
| 8 | Classes | 📝 New | What a class is, static classes (C# 2), object initializers (C# 3), collection initializers (C# 3) |
| 9 | Structs | 📝 New | Struct design, auto-default (C# 11), parameterless constructors (C# 10), readonly members (C# 8), record structs (C# 10) |
| 10 | Records | 🟡 Revise | Ensure record structs and `with` expressions are fully covered |
| 11 | Interfaces | 📝 New | Declaring and implementing; exclude default interface members and static abstract members |
| 12 | Enumerations | 📝 New | Core enum usage and patterns |
| 13 | Tuples and deconstruction | 🟡 Revise | Merge existing articles; inferred names (C# 7.1), comparison (C# 7.3), `with` on tuples |
| 14 | Generics | 📝 New | Consuming generic types/methods, type inference, basic constraints (`class`, `struct`, `new()`, base type), brief mention of `Enum`/`Delegate`/`unmanaged` constraints, co-/contra-variance (C# 4), collection expressions (C# 12), dictionary expressions (C# 14), spread `..` |
| 15 | Type conversions, casting, and boxing | 📥 Pull | From programming guide: casting, conversions, boxing/unboxing, `is`/`as` |
| 16 | Delegates, lambdas, and events | 📝 New | Introduction: `Func<>`, `Action<>`, lambda basics (C# 3), static lambdas (C# 9), discard parameters (C# 9), brief events intro (subscribe/unsubscribe). Deeper coverage in OOP and Functional techniques |
| 69 | Tutorial: Introduction to classes | ✅ Exists | |
| 72 | Tutorial: Explore record types | 📥 Pull from Tutorials | |
| 79 | Tutorial: Converting types | ✅ Exists | |
| 91 | Tutorial: Choosing between tuples, records, structs, and classes | 📝 New | Teach readers to decide between using tuples, defining records, defining structs or classes, and defining interfaces |

### Null safety

| # | Article | Status | Notes |
|---|---|---|---|
| 17 | Overview | 📝 New | Unified null safety story, NVT vs. NRT comparison |
| 18 | Nullable value types | 📝 New/Pull | `T?` for value types (C# 2), `HasValue`, `GetValueOrDefault` |
| 19 | Nullable reference types | 📥 Consolidate | Pull from tutorials + concepts: enable NRT, annotating, `?`, `!`, flow analysis |
| 20 | Null operators | 📝 New | `?.`, `?[]`, `??`, `??=` (C# 8), `is null`/`is not null`. Include how pattern matching (`is null`, `is not null`) helps with null checks. |
| 21 | Resolve nullable warnings | 📥 Pull | Existing nullable warnings content. Lives under `null-safety/common-tasks/` per [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 22 | Nullable migration strategies | 📥 Pull | Existing migration content |
| 74 | Tutorial: Explore nullable reference types | 📥 Pull from Tutorials | |

> This section's unified Null safety design (NVT overview + NRT overview + shared operators article) addresses [#36934](https://github.com/dotnet/docs/issues/36934) by consolidating nullable documentation for both value and reference types under one section.

### Strings

| # | Article | Status | Notes |
|---|---|---|---|
| 23 | Overview | 📝 New | Basics, immutability, `string` vs. `String`, verbatim strings, escape sequences, `\e` (C# 13). Include discussion of UTF-8 string literals (`u8` suffix) in the context of HTTP usage. |
| 24 | String interpolation | 📥 Pull/Revise | `$""` (C# 6), newlines (C# 11), constant interpolated strings (C# 10) |
| 25 | Raw string literals | 📝 New | `"""` syntax (C# 11), raw interpolated strings |
| 26 | `nameof` operator | 📝 New | `nameof` (C# 6) |
| 27 | Search strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/` per [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 28 | Split strings into substrings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 29 | Concatenate strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 30 | Modify string contents | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 31 | Compare strings | 📥 Pull | From how-to. Lives under `strings/common-tasks/`. |
| 76 | Tutorial: Explore string interpolation | 📥 Pull from Tutorials | |

### Pattern matching (§11)

Sequenced before Expressions (§12) and Statements (§13) to mirror the C# standard's clause order
(§11 → §12 → §13). Pattern-matching articles live under `fundamentals/patterns/` (their own §11
section), not under `fundamentals/functional/`.

| # | Article | Status | Notes |
|---|---|---|---|
| 32 | Overview | 🟡 Major revise | High-level introduction to pattern matching and switch expressions (C# 8). Motivate when and why to use patterns vs. imperative branching. |
| 92 | Declaration, constant, and var patterns | 📝 New | Declaration patterns, constant patterns, var patterns. Combined into one article because each is brief on its own. |
| 93 | Type patterns | 📝 New | Type-testing patterns, pattern matching with generics (C# 7.1) |
| 94 | Property and positional patterns | 📝 New | Property patterns (C# 8), extended property patterns (C# 10), positional patterns (C# 8) |
| 95 | Relational and logical patterns | 📝 New | Relational patterns, combinator/logical patterns (`and`, `or`, `not`), parenthesized patterns (C# 9) |
| 96 | List patterns | 📝 New | List patterns (C# 11), slice patterns |
| 33 | Discards | ✅ Exists | Keep or merge into pattern matching |
| 34 | Deconstruction | 🟡 Revise | Records, tuples, custom `Deconstruct` |
| 73 | Tutorial: Explore pattern matching | 📥 Pull from Tutorials | |
| 78 | Tutorial: Build data-driven algorithms with pattern matching | ✅ Exists | |

### Expressions and operators (§12)

Fills the §12 operator gap (see [Decision 12](decisions.md#decision-12-expressions-and-operators-section)).
Sequenced before Statements (§13) per the standard. Articles live under `fundamentals/expressions/`.

| # | Article | Status | Notes |
|---|---|---|---|
| 102 | Overview and operator precedence | 📝 New | What an expression is; expression vs. statement; expression classifications (value vs. variable); operands and operators; the operator precedence and associativity table; evaluation order and side effects. Cross-links to switch expression (Pattern matching) and LINQ (Statements). |
| 103 | Arithmetic, comparison, logical, and assignment operators | 📝 New | Arithmetic (`+ - * / %`), unary (`+ - !`), increment/decrement (`++ --`), relational (`< > <= >=`), equality operators (`== !=`, survey; cross-link to Reference vs. value equality for semantics), conditional-logical (`&& ||` with short-circuiting), the conditional operator (`?:`, §12.20), simple and compound assignment (`= += -= *= /= %=`) |

> *Excluded from Fundamentals (stay in Language Reference, cross-linked out):* shift operators
> (`<< >> >>>`, §12.13), integer/bitwise logical operators (`& | ^ ~`, §12.15/§12.9.5), and
> `checked`/`unchecked` (§12.8.20). They fail Filter A universality for everyday code.

### Statements (§13)

| # | Article | Status | Notes |
|---|---|---|---|
| 83 | Selection statements | 📝 New | `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions |
| 84 | Iteration statements | 📝 New | `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops |
| 85 | Working with collections | 📝 New | Arrays, `List<T>`, `Dictionary<TKey,TValue>`; adding, removing, and searching elements; collection expressions (C# 12) including spread elements (`..`) to compose sequences; ranges and indexes (C# 8) applied to collections. Lead indexes/ranges with what they're for; show indexing from the start and from the end; distinguish range `..` from spread `..`; use *index* rather than *position*; and emphasize that a range end is ***exclusive***. |
| 86 | LINQ and query expressions | 📝 New | Query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios. Introduce query syntax, method syntax, providers, and deferred vs. eager execution near the top; use identical output for equivalent query/method examples; and annotate where deferred execution happens in code. |
| 99 | Equality comparisons | ✅ Shipped ([#54849](https://github.com/dotnet/docs/pull/54849)) | Value equality vs. reference equality; the five members `==`, `!=`, `Equals`, `GetHashCode`, `ReferenceEquals`; struct vs. class defaults; record equality semantics (records-first framing; `IEquatable<T>` deemphasized to an optional optimization). **Shipped at `fundamentals/expressions/equality.md`** (relocated from the planned Type system location into the new `fundamentals/expressions/` folder), titled "C# Equality comparisons", rendering as the first child of the combined "Expressions and statements" TOC node. Cross-linked from the Expressions equality-operator survey (deferred to PR 16). |

> *Note:* the conditional `?:` operator is taught in the Expressions and operators section (§12.20).
> Trimming the `ternary conditional operator` mention in Selection statements to a cross-reference is
> a **deferred later-cleanup item**, not part of this reorder batch.

### Functional techniques (§12)

| # | Article | Status | Notes |
|---|---|---|---|
| 35 | Overview | 🟡 Revise | C# as a multi-paradigm language, functional style. Emphasize pattern matching expressions as a key functional technique. Emphasize lambda expressions as a form of "code as data". |
| 36 | Lambda expressions in depth | 📝 New | Closures, captures, expression vs. statement lambdas, method group conversions |
| 37 | Local functions | 📥 Pull | From concepts/programming guide: local functions (C# 7), static (C# 8), attributes (C# 9) |
| 38 | Iterators | 📥 Pull | `yield return`/`yield break` (C# 2), iterator pattern, foreach over strings |
| 97 | Tutorial: Functional techniques in C# | 📝 New | Breadth-focused tutorial demonstrating functional techniques (lambdas, local functions, pattern matching expressions, iterators, LINQ) in combination rather than depth in any single area |

### Namespaces (§14)

| # | Article | Status | Notes |
|---|---|---|---|
| 100 | Namespaces | 📝 New | **Canonical §14 article** (Decision 12b). Motivation for using namespaces to organize programs and libraries; declaring namespaces; file-scoped namespaces (C# 10); importing with `using`; namespace aliases; `extern alias` mention; nested namespaces. The Program-structure "Namespaces and using directives" article (#4) is slimmed to a brief intro + link here. |

### Object-oriented programming (§15)

| # | Article | Status | Notes |
|---|---|---|---|
| 39 | Overview | 🟡 Revise | The OOP model in C# |
| 40 | Objects | ✅ Exists | |
| 41 | Access modifiers | 📥 Pull | From programming guide; all modifiers incl. `private protected` (C# 7.2) |
| 42 | Fields and constants | 📥 Pull | From programming guide; attributes on backing fields (C# 7.3) |
| 43 | Properties | 📥 Pull | Auto-properties (C# 3), initializers (C# 6), getter-only (C# 6), init-only (C# 9), required (C# 11), `field` keyword (C# 14), expression-bodied, separate accessibility (C# 2) |
| 44 | Constructors | 📥 Pull | Instance, static, primary (C# 12) |
| 45 | Methods | 📥 Pull | Named/optional args (C# 4), non-trailing named (C# 7.2), expression-bodied (C# 6+), `ref`/`out`, `params` → `params` collections (C# 13), out variables (C# 7) |
| 46 | Lambdas in OOP | 📝 New | `Func<>`/`Action<>` as parameters/return types, callback patterns, event handlers as lambdas, method groups |
| 47 | Inheritance and polymorphism | 🟡 Merge | Merge existing Inheritance + pull polymorphism; `virtual`/`override`/`new`, `sealed`, covariant returns (C# 9), `abstract`/`base` |
| 48 | Interfaces in practice | 📝 New/Pull | Implementing interfaces, explicit implementation, interfaces vs. abstract classes |
| 49 | Indexers | 📥 Pull | From programming guide; ranges and indexes (C# 8) |
| 50 | Extensions | 📝 New | C# 14 syntax, extension properties; note legacy `this` syntax |
| 51 | Events | 📥 Pull subset | Subscribe/unsubscribe, standard event pattern |
| 52 | Partial types and members | 📝 New | Brief: partial classes/structs, partial methods (C# 9), partial properties (C# 13), partial events/constructors (C# 14); source generator context |
| 53 | Object lifetime and `IDisposable` | 📝 New | `using` statement (C# 1), `using` declaration (C# 8), dispose pattern; exclude finalizers |
| 87 | Encapsulation and composition | 📝 New | Encapsulation as information hiding; composition over inheritance; combining objects to build complex behavior; comparison with inheritance-based designs |
| 70 | Tutorial: Object-oriented C# | ✅ Exists | |
| 71 | Tutorial: Inheritance in C# and .NET | ✅ Exists | |
| 75 | Tutorial: Explore indexes and ranges | 📥 Pull from Tutorials | |

### Asynchronous programming basics

| # | Article | Status | Notes |
|---|---|---|---|
| 88 | Async programming overview | 📥 Pull | Move from `asynchronous-programming/index.md`; redirect old URL |
| 54 | Consuming async methods | 📝 New | `async`/`await` (C# 5), task-based pattern, declaring async methods, async Main (C# 7.1), brief `await foreach` (C# 8), link to Async Focus |

### Exceptions and errors (§22)

| # | Article | Status | Notes |
|---|---|---|---|
| 55 | Overview | ✅ Exists | |
| 56 | Using exceptions | ✅ Exists | |
| 57 | Exception handling | ✅ Exists | Ensure exception filters (C# 6), throw expressions (C# 7), await in catch/finally (C# 5) are covered |
| 58 | Creating and throwing exceptions | ✅ Exists | |
| 59 | Compiler-generated exceptions | ✅ Exists | |
| 81 | Tutorial: Handle exceptions with try-catch | ✅ Exists | |
| 82 | Tutorial: Execute cleanup code with finally | ✅ Exists | |

### Attributes (§23)

| # | Article | Status | Notes |
|---|---|---|---|
| 60 | Using attributes | 📝 New | Common attributes, syntax, targets; defer custom attribute creation |

### XML documentation comments

| # | Article | Status | Notes |
|---|---|---|---|
| 62 | XML documentation | 📝 New or Pull | `///` comments, common tags |
| 89 | Documentation generation tools | 📝 New | Generating XML output with `dotnet build`; DocFX; Sandcastle; other current tools. Lives under `xml-comments/common-tasks/` per [Decision 11](decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials). |
| 80 | Tutorial: Generate API documentation | ✅ Exists | |

### Coding style (post-standard)

| # | Article | Status | Notes |
|---|---|---|---|
| 63 | C# identifier names | ✅ Exists | |
| 64 | C# coding conventions | ✅ Exists | |
| 65 | C# documentation comments | ✅ Exists | |
| 66 | Design alternatives | 📝 New | When to use patterns vs. branching statements; classes vs. structs; when to add `record` modifier; when to use tuples; interfaces vs. abstract base classes; `enum` vs. sealed hierarchy (discriminated union pattern); `string` interpolation vs. `StringBuilder` vs. `string.Concat`; delegates (`Func<>`/`Action<>`) vs. single-method interfaces; `IEnumerable<T>` vs. `IReadOnlyList<T>` vs. arrays as return types; extension methods vs. wrapper/decorator; `async Task` vs. sync methods; exceptions vs. result types (Try pattern); immutability patterns: `readonly struct` with fields vs. `init` properties vs. constructor-only properties |
| 101 | Using .NET analyzers | 📝 New | Roslyn analyzers, .NET SDK analyzers, StyleCop, enabling/configuring via `.editorconfig` and `AnalysisLevel`; finding and fixing code issues |

## Article Status Summary

| Status | Count | Description |
|---|---|---|
| ✅ Exists, no change needed | 19 | Exceptions, Coding style, some Tutorials, some Program structure |
| 🟡 Revise existing article | 9 | Structure overview, Records, Pattern matching overview, Deconstruction, Functional overview, OOP overview, Inheritance merge |
| 📝 New article to write | ~43 | Built-in types, Structs, Enums, Generics, Delegates intro, Null safety, Strings, Extensions, Async basics, Attributes, **Expressions overview + operator precedence, Arithmetic/comparison/logical/assignment operators**, Selection statements, Iteration statements, Working with collections, LINQ, Encapsulation and composition, Documentation generation tools, Design alternatives, Using .NET analyzers, System.CommandLine tutorial, Choosing-types tutorial, Declaration/constant/var patterns, Type patterns, Property/positional patterns, Relational/logical patterns, List patterns, Functional techniques tutorial, Organizing programs, Namespaces, and others |
| 📥 Pull and revise from other section | 22 | From Programming Guide, Concepts, How-to, Tutorials, Async section |
| **Total** | **~93** | Not including potential article splits |


## Complete proposed Fundamentals TOC

The following is the complete proposed TOC:

```yml
# This is the proposed structure for the Fundamentals section.
# It follows the C# standard ordering (§7→§23) and incorporates
# all decisions from the planning discussion.

- name: Fundamentals
  items:

  # ─── §7 Basic concepts: Program structure ───
  - name: Program structure
    items:
    - name: Overview
      href: fundamentals/program-structure/index.md
    - name: Main method and entry points
      href: fundamentals/program-structure/main-command-line.md
    - name: Top-level statements
      href: fundamentals/program-structure/top-level-statements.md
    - name: Namespaces and using directives
      # SLIMMED (Decision 12b): brief intro + cross-reference to the canonical
      # §14 Namespaces article (fundamentals/namespaces/overview.md).
      # Redirect + repo-wide inbound-link fix required (shipped article).
      href: fundamentals/program-structure/namespaces.md
    - name: Preprocessor directives
      # NEW: #if, #region, #nullable, #pragma warning only
      href: fundamentals/program-structure/preprocessor-directives.md
    - name: "Tutorial: Build file-based apps"
      href: fundamentals/tutorials/file-based-programs.md
    - name: "Tutorial: How to display command-line arguments"
      href: fundamentals/tutorials/how-to-display-command-line-arguments.md
    - name: "Tutorial: Console application"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/console-app.md
    - name: "Tutorial: Build a command-line app with System.CommandLine"
      # NEW: System.CommandLine for commands, subcommands, arguments, options
      href: fundamentals/tutorials/system-commandline.md
    - name: Organizing programs
      # NEW: assemblies, namespaces, types as organizational tools (#34836)
      href: fundamentals/program-structure/organizing-programs.md

  # ─── §8 Types ───
  - name: Type system
    items:
    - name: Overview
      # REVISE: value vs reference, unified type system, built-in types
      href: fundamentals/types/index.md
    - name: Built-in types and literals
      # NEW: numeric types (incl unsigned, nint), bool, char, string intro,
      # literal syntax (binary, digit separators, raw string literals),
      # default expressions, implicitly typed variables (var),
      # target-typed new, dynamic binding
      href: fundamentals/types/built-in-types.md
    - name: Classes
      # NEW (brief): what a class is, static classes, object/collection initializers
      href: fundamentals/types/classes.md
    - name: Structs
      # NEW: struct design, auto-default (C# 11), parameterless constructors (C# 10),
      # readonly members (C# 8), record structs (C# 10)
      href: fundamentals/types/structs.md
    - name: Records
      # EXISTS: ensure record structs and with expressions covered
      href: fundamentals/types/records.md
    - name: Interfaces
      # NEW (brief): declaring and implementing; exclude default interface members,
      # static abstract members
      href: fundamentals/types/interfaces.md
    - name: Enumerations
      # NEW: core enum usage
      href: fundamentals/types/enums.md
    - name: Tuples and deconstruction
      # REVISE: merge existing tuples + deconstruct articles; add inferred names (C# 7.1),
      # tuple comparison (C# 7.3), with on tuples
      href: fundamentals/types/tuples.md
    - name: Generics
      # NEW: consuming generic types/methods, type inference, basic constraints
      # (class, struct, new(), base type), brief mention of Enum/Delegate/unmanaged
      # constraints, covariance/contravariance on interfaces and delegates (C# 4),
      # collection expressions (C# 12), dictionary expressions (C# 14), spread operator
      href: fundamentals/types/generics.md
    - name: Type conversions, casting, and boxing
      # PULL from programming guide: casting, conversions, boxing/unboxing, is/as
      href: fundamentals/types/conversions.md
    - name: Delegates, lambdas, and events
      # NEW (introduction): what delegates are, Func<>/Action<>, lambda expression
      # basics (C# 3), static lambdas (C# 9), discard parameters (C# 9),
      # brief intro to events (subscribe/unsubscribe)
      # Deeper treatment in OOP and Functional techniques
      href: fundamentals/types/delegates-lambdas.md
    - name: "Tutorial: Introduction to classes"
      href: fundamentals/tutorials/classes.md
    - name: "Tutorial: Explore record types"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/records.md
    - name: "Tutorial: Converting types"
      displayName: cast, is, as
      href: fundamentals/tutorials/safely-cast-using-pattern-matching-is-and-as-operators.md
    - name: "Tutorial: Choosing between tuples, records, structs, and classes"
      # NEW: teach readers to decide between tuple/record/struct/class/interface
      href: fundamentals/tutorials/choosing-types.md

  # ─── Null safety (§8 nullability, cross-cutting) ───
  - name: Null safety
    items:
    - name: Overview
      # NEW: unified null safety story, comparison of nullable value types
      # vs nullable reference types
      href: fundamentals/null-safety/index.md
    - name: Nullable value types
      # NEW/PULL: T? for value types (C# 2), HasValue, GetValueOrDefault
      href: fundamentals/null-safety/nullable-value-types.md
    - name: Nullable reference types
      # PULL from tutorials + concepts: enable NRT, annotating code, ?, !,
      # flow analysis, all new code should use this
      href: fundamentals/null-safety/nullable-reference-types.md
    - name: Null operators
      # NEW: ?., ?[], ??, ??=, null-conditional assignment (C# 14—use without
      # detailed explanation), is null / is not null
      href: fundamentals/null-safety/null-operators.md
    - name: Resolve nullable warnings
      # PULL from existing nullable warnings content.
      # Task-style article: lives under common-tasks/ per Decision 11.
      href: fundamentals/null-safety/common-tasks/resolve-warnings.md
    - name: Nullable migration strategies
      # PULL from existing migration content
      href: fundamentals/null-safety/migration-strategies.md
    - name: "Tutorial: Explore nullable reference types"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/nullable-reference-types.md

  # ─── Strings (§8.2.5 in standard, standalone per decision) ───
  - name: Strings
    items:
    - name: Overview
      # NEW: string basics, immutability, string vs String, verbatim strings,
      # escape sequences, \e (C# 13)
      href: fundamentals/strings/index.md
    - name: String interpolation
      # PULL/REVISE from tutorials: $"" (C# 6), newlines in interpolations (C# 11),
      # constant interpolated strings (C# 10—use without explanation)
      href: fundamentals/strings/interpolation.md
    - name: Raw string literals
      # NEW: """ syntax (C# 11), raw interpolated strings
      href: fundamentals/strings/raw-string-literals.md
    - name: nameof operator
      # NEW: nameof (C# 6), extended nameof scope (C# 11—use without explanation),
      # unbound generic types in nameof (C# 14—use without explanation)
      href: fundamentals/strings/nameof.md
    - name: Search strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/search.md
    - name: Split strings into substrings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/split.md
    - name: Concatenate strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/concatenate.md
    - name: Modify string contents
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/modify.md
    - name: Compare strings
      # PULL from how-to. Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/strings/common-tasks/compare.md
    - name: "Tutorial: Explore string interpolation"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/string-interpolation.md

  # ─── §11 Patterns and pattern matching ───
  # Sequenced before §12/§13 per the standard. Articles live under fundamentals/patterns/.
  - name: Pattern matching
    items:
    - name: Overview
      # REVISE: high-level intro to pattern matching and switch expressions (C# 8).
      # Motivate when/why to use patterns vs. imperative branching.
      href: fundamentals/patterns/pattern-matching.md
    - name: Declaration, constant, and var patterns
      # NEW: declaration patterns, constant patterns, var patterns
      href: fundamentals/patterns/declaration-constant-var-patterns.md
    - name: Type patterns
      # NEW: type-testing patterns, pattern matching with generics (C# 7.1)
      href: fundamentals/patterns/type-patterns.md
    - name: Property and positional patterns
      # NEW: property patterns (C# 8), extended property (C# 10),
      # positional patterns (C# 8)
      href: fundamentals/patterns/property-positional-patterns.md
    - name: Relational and logical patterns
      # NEW: relational patterns, and/or/not combinators,
      # parenthesized patterns (C# 9)
      href: fundamentals/patterns/relational-logical-patterns.md
    - name: List patterns
      # NEW: list patterns (C# 11), slice patterns
      href: fundamentals/patterns/list-patterns.md
    - name: Discards
      # EXISTS: keep or merge into pattern matching
      href: fundamentals/patterns/discards.md
    - name: Deconstruction
      # REVISE: records, tuples, custom Deconstruct;
      # mixed deconstructions (C# 10—use without explanation)
      href: fundamentals/patterns/deconstruct.md
    - name: "Tutorial: Explore pattern matching"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/pattern-matching.md
    - name: "Tutorial: Build data-driven algorithms with pattern matching"
      href: fundamentals/tutorials/pattern-matching-advanced.md

  # ─── §12 Expressions and operators ───
  # NEW section (Decision 12). Fills the §12 operator gap; before §13 Statements.
  - name: Expressions and operators
    items:
    - name: Overview and operator precedence
      # NEW: expression vs. statement, expression classifications,
      # operator precedence and associativity, evaluation order.
      # Cross-links to switch expression (Pattern matching) and LINQ (Statements).
      href: fundamentals/expressions/index.md
    - name: Arithmetic, comparison, logical, and assignment operators
      # NEW: arithmetic (+ - * / %), unary (+ - !), increment/decrement (++ --),
      # relational (< > <= >=), equality operators (== !=; cross-link to
      # Reference vs. value equality), conditional-logical (&& || short-circuit),
      # conditional operator (?:), simple + compound assignment (= += -= ...).
      # EXCLUDED (stay in Language Reference, cross-linked): shift (<< >> >>>),
      # bitwise (& | ^ ~), checked/unchecked.
      href: fundamentals/expressions/operators.md

  # ─── §13 Statements ───
  - name: Statements
    items:
    - name: Selection statements
      # NEW: if/else branching, switch statement, ternary conditional;
      # links to pattern matching for switch expressions.
      # (Deferred cleanup: trim the ?: mention to a cross-reference to
      # Expressions and operators §12.20 — not part of this batch.)
      href: fundamentals/statements/selection-statements.md
    - name: Iteration statements
      # NEW: for, foreach, while, do-while; iterating collections;
      # break and continue in loops
      href: fundamentals/statements/iteration-statements.md
    - name: Working with collections
      # NEW: Arrays, List<T>, Dictionary<K,V>; adding, removing, searching;
      # collection expressions (C# 12); ranges and indexes (C# 8)
      href: fundamentals/statements/collections.md
    - name: LINQ and query expressions
      # NEW (subset): query syntax, fluent syntax, common operators
      # (Where, Select, OrderBy, GroupBy); lambda expressions in LINQ;
      # link to LINQ Focus section for advanced scenarios
      href: fundamentals/statements/linq.md
    - name: Equality comparisons
      # SHIPPED (PR #54849) as "C# Equality comparisons": value vs reference
      # equality, ==, !=, Equals, GetHashCode, ReferenceEquals; struct vs class
      # defaults; record equality (records-first; IEquatable<T> deemphasized).
      # Relocated from Type system into the new fundamentals/expressions/ folder;
      # renders as the first child of the combined "Expressions and statements" node.
      href: fundamentals/expressions/equality.md

  # ─── §12 Expressions / Functional techniques ───
  - name: Functional techniques
    items:
    - name: Overview
      # REVISE: C# supports multiple paradigms; functional style in C#
      href: fundamentals/functional/index.md
    - name: Lambda expressions in depth
      # NEW: deeper lambda treatment—closures, captures, expression lambdas
      # vs statement lambdas, lambda optional parameters (C# 12—use without
      # explanation), attributes and return types on lambdas (C# 10—use without
      # explanation), method group conversions
      href: fundamentals/functional/lambdas.md
    - name: Local functions
      # PULL from concepts/programming guide: local functions (C# 7),
      # static local functions (C# 8), attributes on local functions (C# 9)
      href: fundamentals/functional/local-functions.md
    - name: Iterators
      # PULL: yield return/yield break (C# 2), iterator pattern,
      # foreach over strings, dispose in foreach
      href: fundamentals/functional/iterators.md
    - name: "Tutorial: Functional techniques in C#"
      # NEW: breadth-focused tutorial demonstrating functional techniques
      # (lambdas, local functions, pattern matching, iterators, LINQ)
      href: fundamentals/tutorials/functional-techniques.md

  # ─── §14 Namespaces ───
  - name: Namespaces
    items:
    - name: Organizing code with namespaces
      # CANONICAL §14 article (Decision 12b): motivation for namespaces, declaring,
      # file-scoped (C# 10), using directives, aliases, extern alias, nested namespaces.
      # The program-structure namespaces article is slimmed to a brief intro + link here.
      href: fundamentals/namespaces/overview.md

  # ─── §15 Classes / OOP ───
  - name: Object-oriented programming
    items:
    - name: Overview
      # REVISE: the OOP model in C#
      href: fundamentals/object-oriented/index.md
    - name: Objects
      # EXISTS
      href: fundamentals/object-oriented/objects.md
    - name: Access modifiers
      # PULL from programming guide: all modifiers incl private protected (C# 7.2)
      href: fundamentals/object-oriented/access-modifiers.md
    - name: Fields and constants
      # PULL from programming guide: fields, constants, readonly,
      # attributes on backing fields (C# 7.3)
      href: fundamentals/object-oriented/fields-constants.md
    - name: Properties
      # PULL from programming guide: auto-properties (C# 3),
      # auto-property initializers (C# 6), getter-only defaults (C# 6),
      # init-only setters (C# 9), required members (C# 11),
      # field keyword (C# 14), expression-bodied accessors,
      # separate getter/setter accessibility (C# 2)
      href: fundamentals/object-oriented/properties.md
    - name: Constructors
      # PULL from programming guide: instance, static, primary (C# 12)
      href: fundamentals/object-oriented/constructors.md
    - name: Methods
      # PULL from programming guide + concepts: named/optional arguments (C# 4),
      # non-trailing named args (C# 7.2), expression-bodied members (C# 6+),
      # ref/out basics, params arrays → params collections (C# 13),
      # out variables (C# 7)
      href: fundamentals/object-oriented/methods.md
    - name: Lambdas in OOP contexts
      # NEW: using Func<>/Action<> as parameters and return types,
      # callback patterns, event handlers as lambdas,
      # method groups as delegates in OOP design
      href: fundamentals/object-oriented/lambdas-in-oop.md
    - name: Inheritance and polymorphism
      # MERGE existing Inheritance + pull polymorphism from programming guide:
      # virtual/override/new, sealed, covariant return types (C# 9),
      # abstract/base
      href: fundamentals/object-oriented/inheritance.md
    - name: Interfaces
      # NEW/PULL: implementing interfaces, explicit implementation,
      # interfaces vs abstract classes; exclude default interface members
      # and static abstract members
      href: fundamentals/object-oriented/interfaces.md
    - name: Indexers
      # PULL from programming guide: indexer syntax,
      # ranges and indexes (C# 8)
      href: fundamentals/object-oriented/indexers.md
    - name: Extensions
      # NEW: C# 14 extension syntax, replaces this extension methods,
      # extension properties; note on legacy this syntax
      href: fundamentals/object-oriented/extensions.md
    - name: Events
      # PULL subset from concepts: subscribe/unsubscribe,
      # standard event pattern; defer custom accessors/advanced multicast
      href: fundamentals/object-oriented/events.md
    - name: Partial types and members
      # NEW (brief subset): partial classes/structs, partial methods (C# 9),
      # partial properties (C# 13), partial events/constructors (C# 14);
      # context is source generators and templates
      href: fundamentals/object-oriented/partial-types.md
    - name: Object lifetime and IDisposable
      # NEW: using statement (C# 1), using declaration (C# 8),
      # dispose pattern; exclude finalizers
      href: fundamentals/object-oriented/object-lifetime.md
    - name: Encapsulation and composition
      # NEW: encapsulation as information hiding; composition over
      # inheritance; combining objects to build complex behavior
      href: fundamentals/object-oriented/encapsulation-composition.md
    - name: "Tutorial: Object-oriented C#"
      href: fundamentals/tutorials/oop.md
    - name: "Tutorial: Inheritance in C# and .NET"
      href: fundamentals/tutorials/inheritance.md
    - name: "Tutorial: Explore indexes and ranges"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/ranges.md

  # ─── Async basics (after OOP, per decision) ───
  - name: Asynchronous programming basics
    items:
    - name: Overview
      # PULL from asynchronous-programming/index.md; redirect old URL
      href: fundamentals/async/index.md
    - name: Consuming async methods
      # NEW (subset): async/await (C# 5), Task-based pattern,
      # declaring async methods that call other async methods,
      # async Main (C# 7.1). Brief mention of async streams
      # (await foreach C# 8). Link to Async focus section for
      # cancellation, ConfigureAwait, parallel patterns, etc.
      href: fundamentals/async/consuming-async.md

  # ─── §22 Exceptions ───
  - name: Exceptions and errors
    items:
    - name: Overview
      href: fundamentals/exceptions/index.md
    - name: Using exceptions
      href: fundamentals/exceptions/using-exceptions.md
    - name: Exception handling
      # Ensure exception filters (C# 6) covered,
      # throw expressions (C# 7), await in catch/finally (C# 5)
      href: fundamentals/exceptions/exception-handling.md
    - name: Creating and throwing exceptions
      href: fundamentals/exceptions/creating-and-throwing-exceptions.md
    - name: Compiler-generated exceptions
      href: fundamentals/exceptions/compiler-generated-exceptions.md
    - name: "Tutorial: How to handle an exception using try-catch"
      href: fundamentals/exceptions/how-to-handle-an-exception-using-try-catch.md
    - name: "Tutorial: How to execute cleanup code using finally"
      href: fundamentals/exceptions/how-to-execute-cleanup-code-using-finally.md

  # ─── §23 Attributes ───
  - name: Attributes
    # NEW (brief): using common attributes, attribute syntax,
    # attribute targets; defer creating custom attributes to Advanced
    href: fundamentals/attributes.md

  # ─── §D Documentation comments ───
  - name: XML documentation comments
    items:
    - name: Overview
      # NEW (brief) or PULL: documenting code with ///, common tags
      href: fundamentals/xml-comments.md
    - name: Documentation generation tools
      # NEW: dotnet build XML output, DocFX, Sandcastle, other current tools.
      # Task-style: under common-tasks/ per Decision 11.
      href: fundamentals/xml-comments/common-tasks/documentation-tools.md
    - name: "Tutorial: Generate API documentation with XML comments"
      href: fundamentals/tutorials/xml-documentation.md

  # ─── Coding style (post-standard, conventions) ───
  - name: Coding style
    items:
    - name: C# identifier names
      href: fundamentals/coding-style/identifier-names.md
    - name: C# coding conventions
      href: fundamentals/coding-style/coding-conventions.md
    - name: C# documentation comments
      href: fundamentals/coding-style/documenting-code.md
    - name: Design alternatives
      # NEW: when to use patterns vs. branching, classes vs. structs,
      # record modifier, tuples, interfaces vs. abstract base classes,
      # immutability patterns, and other common design decisions
      href: fundamentals/coding-style/design-alternatives.md
    - name: Using .NET analyzers
      # NEW: Roslyn analyzers, .NET SDK analyzers, StyleCop,
      # .editorconfig and AnalysisLevel configuration
      href: fundamentals/coding-style/analyzers.md
```
