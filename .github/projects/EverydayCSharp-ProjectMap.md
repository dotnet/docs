# C# Fundamentals Section: Restructuring Plan

This document captures the decisions, rationale, and proposed outline for restructuring the C# Fundamentals section. It's the result of planning discussions informed by the [GitHub project board](https://github.com/orgs/dotnet/projects/225/views/1), the [C# standard](https://github.com/dotnet/csharpstandard), and
the [feature inclusion notes](#feature-coverage-decisions).

## Goals

1. **Make Fundamentals complete.** A developer learning C# should be able to read the Fundamentals section and understand "Everyday C#" — the features and patterns used in the vast majority of production code.
1. **Pull content toward the goal.** Rather than focusing on migrating content *out* of legacy sections (Tutorials, C# concepts, How-to, Programming guide), we focus on building a great Fundamentals section and pull content in as it fits.
1. **Teach through examples.** Most engineers learn software languages by reading and writing example code, not by reading *about* the language. Every article in the Fundamentals section should be example-heavy: short prose introduces a concept, then one or more code samples demonstrate it in context. Favor showing over telling.
1. **Follow the C# standard's organization.** The section ordering mirrors the [C# standard](https://github.com/dotnet/csharpstandard/blob/main/standard/README.md) (§7 Basic concepts → §8 Types → §11 Patterns → §12 Expressions → §15 Classes → §22 Exceptions → §23 Attributes). Content not in the standard appears after standard-aligned sections.
1. **Emphasize everday C#.** Everyday C# features get fuller explanations. Older features that readers (including AI agents and Copilots) already have extensive information about receive lighter treatment. All sample code uses the latest released syntax and idioms.
1. **Target audience.** Developers who know at least one other programming language and are learning C#, or C# developers updating their knowledge of the latest features and idioms. Not absolute beginners in programming.
1. **Samples showcase Everday C# feature sets.** All sample code across the Fundamentals section should incorporate the language features listed in [Include and explain](#include-and-explain), [Use in sample code without detailed explanation](#use-in-sample-code-without-detailed-explanation), and the relevant subsets from [Include a subset](#include-a-subset). This means even an article about, for example, exception handling should use collection expressions, file-scoped namespaces, nullable reference types, raw string literals, and other everyday C# features in its samples — not just the feature under discussion. Readers absorb these idioms organically by seeing them used consistently.

## Include major topic types

The following table lists each topic type. Every section should include an *Overview*, any number of *Concepts* articles, pertinent *Tutorials*. Where necessary, *troubleshooting* and *how to* articles can be added. All *Reference* articles are in the *language reference section*.

**All content types should be example-heavy.** Short prose introduces or connects concepts; code samples do the teaching. Samples in every article should restrict features to the set of C# features in Goals 6 and 7, and [Decision 10](#decision-10-example-heavy-articles-with-everyday-c-feature-saturation)).

| Content type | What is it |
| --- | --- |
| Overview | An article explaining the feature from a technical point of view. And/or an article comparing features across related features. Leads with a motivating example before diving into details. |
| Tutorials | Scenario-based procedures for top tasks using the feature. The focus is on showing the customer how to do the task, not on helping them set up their own environment. Code-first from the opening paragraph. |
| Concepts | In-depth explanation of functionality related to the feature that are fundamental to understanding and use. Each concept is illustrated with at least one focused code sample. |
| How-to guides | Procedural articles that show the reader how to complete a task. Each step includes the code to accomplish it. |
| Troubleshooting articles | Articles that help users solve a common issue. Include before-and-after code showing the problem and the fix. |
| Reference | Documentation for language-based syntax and semantics. |

## Key Decisions

### Decision 1: Null safety is its own section

**Choice:** Null safety gets a standalone sub-section within Fundamentals, covering both nullable value types and nullable reference types with a comparison between the two.

**Rationale:** Null safety is cross-cutting. It touches the type system, expressions, patterns, and API design. Nullable reference types are the single most impactful feature for code quality in C#, and "all new code should use this." Giving it its own section signals that  importance and provides a single place to learn the complete null safety story.

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

- *Structure each article as concept → example → concept → example*, not as a wall of prose with a code block at the end.
- *Prefer small, focused examples* that each illustrate one point, over large monolithic samples.
- *Review every sample's using directives, type declarations, and local variables* to confirm they use the latest syntax (e.g., `global using`, file-scoped namespace, `var`, collection expressions, primary constructors) even when those features aren't the article's topic.
- *Treat the three feature tables as a checklist* when writing or reviewing samples. If a feature from "Use in sample code without detailed explanation" appears naturally, use it without commentary. If a feature from "Include a subset" is relevant to the scenario, include it with a brief link to its full article.

## Feature Coverage Decisions

The following categorization is based on the [Roslyn Feature Status](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) and the
[C# version history](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-version-history). Features are ordered newest-first to emphasize that newer features need the most original content (older features have extensive existing coverage elsewhere).

### Include and explain

These features are "Everyday C#" and receive full treatment in Fundamentals with explanations, examples, and guidance.

| Feature | Version | Proposed Location |
|---|---|---|
| `field` keyword (field-backed properties) | C# 14 | OOP > Properties |
| Extensions (new syntax) | C# 14 | OOP > Extensions |
| Dictionary expressions | C# 14 | Type system > Generics |
| `params` collections | C# 13 | OOP > Methods |
| Collection expressions | C# 12 | Type system > Generics |
| Primary constructors | C# 12 | OOP > Constructors |
| Raw string literals | C# 11 | Strings > Raw string literals |
| List patterns | C# 11 | Pattern matching |
| File-local types | C# 11 | Program structure (in context of top-level statements) |
| Required members | C# 11 | OOP > Properties or Fields |
| Auto-default structs | C# 11 | Type system > Structs |
| Record structs | C# 10 | Type system > Records |
| Global using directives | C# 10 | Program structure > Namespaces |
| File-scoped namespaces | C# 10 | Program structure > Namespaces |
| Parameterless struct constructors | C# 10 | Type system > Structs |
| Records and `with` expressions | C# 9 | Type system > Records |
| Init-only setters | C# 9 | OOP > Properties |
| Top-level statements | C# 9 | Program structure |
| Pattern matching (relational, combinator, parenthesized, type) | C# 9 | Pattern matching |
| Native sized integers (`nint`) | C# 9 | Type system > Built-in types (mention) |
| Target-typed `new` expressions | C# 9 | Type system > Built-in types |
| Static anonymous functions | C# 9 | Functional techniques > Lambdas |
| Covariant return types | C# 9 | OOP > Inheritance |
| Nullable reference types | C# 8 | Null safety |
| Recursive patterns (positional, property, switch expressions) | C# 8 | Pattern matching |
| Ranges and indexes | C# 8 | OOP > Indexers |
| Static local functions | C# 8 | Functional techniques > Local functions |
| Readonly members | C# 8 | Type system > Structs |
| Tuple comparison `==` and `!=` | C# 7.3 | Type system > Tuples |
| Attributes on backing fields | C# 7.3 | OOP > Fields and constants |
| Non-trailing named arguments | C# 7.2 | OOP > Methods |
| `private protected` accessibility | C# 7.2 | OOP > Access modifiers |
| Digit separator after base specifier | C# 7.2 | Type system > Built-in types |
| Async Main | C# 7.1 | Program structure > Main |
| `default` expressions | C# 7.1 | Type system > Built-in types |
| Inferred tuple element names | C# 7.1 | Type system > Tuples |
| Pattern matching with generics | C# 7.1 | Pattern matching |
| Pattern matching | C# 7 | Pattern matching |
| Tuples | C# 7 | Type system > Tuples |
| Deconstruction | C# 7 | Pattern matching > Deconstruction |
| Discards | C# 7 | Pattern matching > Discards |
| Local functions | C# 7 | Functional techniques > Local functions |
| Expression-bodied members (more) | C# 7 | OOP > Methods |
| Auto-property initializers | C# 6 | OOP > Properties |
| Getter-only property defaults | C# 6 | OOP > Properties |
| Expression-bodied members | C# 6 | OOP > Methods |
| Null propagator `?.` and `?[` | C# 6 | Null safety > Null operators |
| String interpolation | C# 6 | Strings > Interpolation |
| `nameof` operator | C# 6 | Strings > nameof |
| Dictionary initializer | C# 6 | Type system > Generics |
| Exception filters | C# 6 | Exceptions |
| Dynamic binding | C# 4 | Type system > Built-in types |
| Named and optional arguments | C# 4 | OOP > Methods |
| Co-/contra-variance for generic delegates and interfaces | C# 4 | Type system > Generics |
| Implicitly typed local variables (`var`) | C# 3 | Type system > Built-in types |
| Object and collection initializers | C# 3 | Type system > Classes |
| Auto-implemented properties | C# 3 | OOP > Properties |
| Lambda expressions | C# 3 | Type system > Delegates/lambdas |
| LINQ query expressions | C# 3 | Statements > LINQ |
| Generics | C# 2 | Type system > Generics |
| Iterators (`yield`) | C# 2 | Functional techniques > Iterators |
| Nullable value types | C# 2 | Null safety > Nullable value types |
| Getter/setter separate accessibility | C# 2 | OOP > Properties |
| Static classes | C# 2 | Type system > Classes |
| Covariance and contravariance | C# 2 | Type system > Generics |
| Classes, Structs, Enums, Interfaces | C# 1 | Type system |
| Events | C# 1 | OOP > Events |
| Properties, Indexers | C# 1 | OOP > Properties, Indexers |
| Reference parameters (`ref`/`out`) | C# 1 | OOP > Methods |
| `params` arrays | C# 1 | OOP > Methods |
| Expressions | C# 1 | Throughout |
| Selection statements (`if`/`else`, `switch`) | C# 1 | Statements |
| Iteration statements (`for`, `foreach`, `while`, `do`-`while`) | C# 1 | Statements |
| `using` statement | C# 1 | OOP > Object lifetime |
| `goto` in `switch` | C# 1 | Mentioned in pattern matching context only |
| Preprocessor directives | C# 1 | Program structure > Preprocessor directives |
| Attributes | C# 1 | Attributes |
| Literals | C# 1 | Type system > Built-in types |
| Verbatim identifier | C# 1 | Type system > Built-in types |
| Unsigned integer types | C# 1 | Type system > Built-in types |
| Boxing and unboxing | C# 1 | Type system > Conversions |

### Use in sample code without detailed explanation

These features appear naturally in code samples. They're intuitive enough that readers understand them from context, or they extend concepts explained elsewhere.

| Feature | Version | Notes |
|---|---|---|
| Unbound generic types in `nameof` | C# 14 | Only interesting if you know the limitation |
| Simple lambda parameters with modifiers | C# 14 | Only interesting if you know the limitation |
| Null-conditional assignment | C# 14 | Once `?.` is understood, `?.` as assignment target is obvious |
| ESC escape sequence | C# 13 | Not a significant regular use case |
| Implicit indexer access in object initializers | C# 13 | "It just works" |
| `nameof` accessing instance members | C# 12 | No need to mention this was added later |
| Lambda optional parameters | C# 12 | Consistent with "lambdas are like methods" |
| UTF-8 string literals | C# 11 | Mostly needed for web scenarios |
| Pattern match `Span<char>` on string | C# 11 | Obvious from examples |
| Newlines in interpolations | C# 11 | Mention in passing on string interpolation |
| Unsigned right-shift operator | C# 11 | Mention in passing if shift operators covered |
| Extended `nameof` scope in attributes | C# 11 | Just another place to use `nameof` |
| `with` expression on structs and anonymous types | C# 10 | Cover as part of `with` in general |
| Improved definite assignment | C# 10 | Use but don't explain |
| Constant interpolated strings | C# 10 | Use but don't explain |
| Extended property patterns | C# 10 | Use in pattern matching examples |
| Mixed deconstructions | C# 10 | Use but don't explain |
| Lambda improvements (attributes, return types, natural type) | C# 10 | Use but don't explain |
| Target-typed conditional expressions | C# 9 | Extends familiar concepts |
| Lambda discard parameters | C# 9 | Ensure discards show an example |
| Attributes on local functions | C# 9 | Mention briefly |
| Enhanced `using` (statement form, dispose ref structs) | C# 8 | Use the statement form in examples |
| Null-coalescing assignment `??=` | C# 8 | Cover in passing with null operators |
| `t is null` on unconstrained type parameter | C# 8 | Use in examples |
| `System.Enum`, `System.Delegate`, `unmanaged` constraints | C# 7.3 | Mention in generics briefly |
| Expression variables in initializers and queries | C# 7.3 | Not called out |
| Out variables | C# 7 | Worth mentioning but not in detail |
| Binary literals | C# 7 | Brief mention |
| Digit separators | C# 7 | Brief mention |
| Throw expressions | C# 7 | Note that `throw` can be an expression |
| `static using` | C# 6 | Brief use |
| `await` in catch/finally | C# 5 | Not a detailed explanation |
| Extension methods (legacy `this` syntax) | C# 3 | Subsumed by new extensions syntax |
| Dispose in `foreach` | C# 1.2 | Implied |
| `foreach` over string specialization | C# 1.2 | Show in iteration samples |

### Include a subset

These features appear in Fundamentals but with limited coverage, linking to deeper treatment in Focus or Advanced sections.

| Feature | Version | Subset Scope |
|---|---|---|
| Partial events and constructors | C# 14 | Brief in context of source generators |
| Partial properties | C# 13 | Only to the extent partial types are covered |
| Using aliases for any type | C# 12 | Subset of use cases |
| Partial methods with returned values | C# 9 | Context for source generators |
| Async streams | C# 8 | Brief mention with `await foreach` |
| Asynchronous methods (`async`/`await`) | C# 5 | Core consuming scenarios only |
| LINQ | C# 3 | Subset — LINQ has its own Focus section |
| Expression trees | C# 3 | Mention in LINQ context for EF providers only |
| Partial methods | C# 3 | Subset for tooling context |
| Partial types | C# 2 | Subset — mainly for source generators and templates |
| Type and namespace aliases | C# 2 | Subset of common scenarios |

### Exclude from Fundamentals

These features are advanced, niche, or targeted at library authors. They belong in Focus sections, Advanced topics, or Language Reference.

| Feature | Version | Reason |
|---|---|---|
| First-class span types | C# 14 | Library author scenario |
| String literals in data section (UTF8) | C# 14 | Advanced, preview |
| Ignored directives | C# 14 | Special purpose |
| User-defined compound assignment operators | C# 14 | Special purpose |
| Method group natural type improvements | C# 13 | "Just works" |
| `ref`/`unsafe` in iterators/async | C# 13 | Advanced |
| `ref struct` interfaces | C# 13 | Advanced |
| Overload resolution priority | C# 13 | Library authors |
| Better conversion from collection expression element | C# 13 | "Just works" |
| Inline arrays | C# 12 | Advanced performance |
| `ref readonly` parameters | C# 12 | Advanced |
| Ref fields | C# 11 | Advanced |
| Static abstract members in interfaces | C# 11 | Advanced |
| `checked` user-defined operators | C# 11 | Advanced |
| Relaxing shift operator requirements | C# 11 | Advanced |
| Numeric `IntPtr` (`nint`/`nuint`) | C# 11 | Advanced high-performance |
| Incremental source generators | C# 10 | Advanced |
| Method-level `AsyncMethodBuilder` | C# 10 | Advanced |
| `#line` span directive | C# 10 | Advanced |
| Interpolated string handlers | C# 10 | Advanced |
| Function pointers | C# 9 | Advanced |
| Suppress `localsinit` flag | C# 9 | Advanced |
| Module initializers | C# 9 | Advanced |
| Extension `GetEnumerator` | C# 9 | Library authors |
| Source generators | C# 9 | Advanced |
| Default interface members | C# 8 | Advanced |
| Unmanaged generic structs | C# 8 | Advanced |
| `stackalloc` in nested contexts | C# 8 | Near bug-fix |
| Alternative interpolated verbatim strings | C# 8 | Near bug-fix |
| `[Obsolete]` on property accessors | C# 8 | Niche |
| `ref` local re-assignment | C# 7.3 | Advanced |
| `stackalloc` initializers | C# 7.3 | Advanced |
| Indexing movable fixed buffers | C# 7.3 | Advanced |
| Custom `fixed` statement | C# 7.3 | Advanced |
| Improved overload candidates | C# 7.3 | Niche |
| Span and ref-like types | C# 7.2 | Advanced |
| `in` parameters and readonly references | C# 7.2 | Advanced |
| Ref conditional | C# 7.2 | Advanced (mention that both args must be variables) |
| Reference assemblies | C# 7.1 | Tooling detail |
| Ref returns and locals | C# 7 | Advanced |
| Generalized async return types | C# 7 | Advanced |
| Caller info attributes | C# 5 | Not necessary |
| `foreach` loop variable per iteration | C# 5 | Historical detail |
| Embedded interop types (NoPIA) | C# 4 | Niche |
| Anonymous types | C# 3 | Prefer tuples |
| Anonymous methods | C# 2 | Subsumed by lambdas |
| Method group conversions (delegates) | C# 2 | Subsumed by lambdas |
| Delegate inference | C# 2 | Covered under lambdas |
| Operator overloading | C# 1 | Advanced |
| User-defined conversion operators | C# 1 | Advanced |
| Delegates (explicit declaration) | C# 1 | Prefer lambdas with `Func<>`/`Action<>` |
| Unsafe code and pointers | C# 1 | Advanced |

## Proposed Fundamentals TOC

The following outline shows every article in the proposed Fundamentals section, its status (existing, needs revision, new, or pulled from another location), and key content notes.

### Program structure (§7)

| # | Article | Status | Notes |
|---|---|---|---|
| 1 | Overview | 🟡 Revise | Add file-scoped namespaces, global usings as default style |
| 2 | Main method and entry points | ✅ Exists | Include async Main (C# 7.1) |
| 3 | Top-level statements | ✅ Exists | Mention file-local types (C# 11) as helpers |
| 4 | Namespaces and using directives | 📝 New | File-scoped namespaces (C# 10), global usings (C# 10), static using (C# 6), type/namespace aliases (subset) |
| 5 | Preprocessor directives | 📝 New | `#if`, `#region`, `#nullable`, `#pragma warning` only |
| 67 | Tutorial: Build file-based apps | ✅ Exists | |
| 68 | Tutorial: Display command-line arguments | ✅ Exists | |
| 77 | Tutorial: Console application | 📥 Pull from Tutorials | |

### Type system (§8)

| # | Article | Status | Notes |
|---|---|---|---|
| 6 | Overview | 🟡 Revise | Value vs. reference, unified type system, built-in types overview |
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

### Null safety

| # | Article | Status | Notes |
|---|---|---|---|
| 17 | Overview | 📝 New | Unified null safety story, NVT vs. NRT comparison |
| 18 | Nullable value types | 📝 New/Pull | `T?` for value types (C# 2), `HasValue`, `GetValueOrDefault` |
| 19 | Nullable reference types | 📥 Consolidate | Pull from tutorials + concepts: enable NRT, annotating, `?`, `!`, flow analysis |
| 20 | Null operators | 📝 New | `?.`, `?[]`, `??`, `??=` (C# 8), `is null`/`is not null` |
| 21 | Resolve nullable warnings | 📥 Pull | Existing nullable warnings content |
| 22 | Nullable migration strategies | 📥 Pull | Existing migration content |
| 74 | Tutorial: Explore nullable reference types | 📥 Pull from Tutorials | |

### Strings

| # | Article | Status | Notes |
|---|---|---|---|
| 23 | Overview | 📝 New | Basics, immutability, `string` vs. `String`, verbatim strings, escape sequences, `\e` (C# 13) |
| 24 | String interpolation | 📥 Pull/Revise | `$""` (C# 6), newlines (C# 11), constant interpolated strings (C# 10) |
| 25 | Raw string literals | 📝 New | `"""` syntax (C# 11), raw interpolated strings |
| 26 | `nameof` operator | 📝 New | `nameof` (C# 6) |
| 27 | Search strings | 📥 Pull | From how-to |
| 28 | Split strings into substrings | 📥 Pull | From how-to |
| 29 | Concatenate strings | 📥 Pull | From how-to |
| 30 | Modify string contents | 📥 Pull | From how-to |
| 31 | Compare strings | 📥 Pull | From how-to |
| 76 | Tutorial: Explore string interpolation | 📥 Pull from Tutorials | |

### Statements and expressions (§12–§13)

| # | Article | Status | Notes |
|---|---|---|---|
| 83 | Selection statements | 📝 New | `if`/`else` branching, `switch` statement, ternary conditional operator; links to pattern matching for `switch` expressions |
| 84 | Iteration statements | 📝 New | `for`, `foreach`, `while`, `do`-`while`; iterating collections; `break` and `continue` in loops |
| 85 | Working with collections | 📝 New | Arrays, `List<T>`, `Dictionary<K,V>`; adding, removing, and searching elements; collection expressions (C# 12); ranges and indexes (C# 8) applied to collections |
| 86 | LINQ and query expressions | 📝 New | Query syntax, fluent (method) syntax, common operators (`Where`, `Select`, `OrderBy`, `GroupBy`); lambda expressions in LINQ context; link to LINQ Focus section for advanced scenarios |

### Pattern matching (§11)

| # | Article | Status | Notes |
|---|---|---|---|
| 32 | Overview | 🟡 Major revise | Comprehensive: type, constant, var, property, extended property (C# 10), positional (C# 8), relational/combinator/parenthesized (C# 9), list (C# 11), switch expressions (C# 8), generics (C# 7.1). May need 2 articles. |
| 33 | Discards | ✅ Exists | Keep or merge into pattern matching |
| 34 | Deconstruction | 🟡 Revise | Records, tuples, custom `Deconstruct` |
| 73 | Tutorial: Explore pattern matching | 📥 Pull from Tutorials | |
| 78 | Tutorial: Build data-driven algorithms with pattern matching | ✅ Exists | |

### Functional techniques (§12)

| # | Article | Status | Notes |
|---|---|---|---|
| 35 | Overview | 🟡 Revise | C# as a multi-paradigm language, functional style |
| 36 | Lambda expressions in depth | 📝 New | Closures, captures, expression vs. statement lambdas, method group conversions |
| 37 | Local functions | 📥 Pull | From concepts/programming guide: local functions (C# 7), static (C# 8), attributes (C# 9) |
| 38 | Iterators | 📥 Pull | `yield return`/`yield break` (C# 2), iterator pattern, foreach over strings |

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
| 80 | Tutorial: Generate API documentation | ✅ Exists | |

### Coding style (post-standard)

| # | Article | Status | Notes |
|---|---|---|---|
| 63 | C# identifier names | ✅ Exists | |
| 64 | C# coding conventions | ✅ Exists | |
| 65 | C# documentation comments | ✅ Exists | |
| 66 | Self-documenting code | ✅ Exists | |

## Article Status Summary

| Status | Count | Description |
|---|---|---|
| ✅ Exists, no change needed | 20 | Exceptions, Coding style, some Tutorials, some Program structure |
| 🟡 Revise existing article | 9 | Structure overview, Records, Pattern matching, Deconstruction, Functional overview, OOP overview, Inheritance merge |
| 📝 New article to write | 27 | Built-in types, Structs, Enums, Generics, Delegates intro, Null safety, Strings, Extensions, Async basics, Attributes, Selection statements, Iteration statements, Working with collections, LINQ, Encapsulation and composition, and others |
| 📥 Pull and revise from other section | 21 | From Programming Guide, Concepts, How-to, Tutorials |
| **Total** | **~77** | Not including potential article splits |

## Content Sources for Pull Articles

| Target Article | Source Location | Action |
|---|---|---|
| Namespaces and using | *No single source* | New, informed by programming guide |
| Nullable value types | `language-reference/builtin-types/nullable-value-types.md` | Adapt for Fundamentals voice |
| Nullable reference types | `tutorials/nullable-reference-types.md` + `nullable-references.md` | Consolidate |
| Resolve nullable warnings | Existing nullable warnings articles | Pull |
| Nullable migration | Existing migration articles | Pull |
| String interpolation | `tutorials/string-interpolation.md` | Pull + modernize |
| String how-tos (5 articles) | `how-to/` string articles | Pull |
| Access modifiers | `programming-guide/classes-and-structs/access-modifiers.md` | Pull + revise |
| Fields and constants | `programming-guide/classes-and-structs/fields.md` + `constants.md` | Merge + revise |
| Properties | `programming-guide/classes-and-structs/properties.md` + related | Pull + major revise for everday C# features |
| Constructors | `programming-guide/classes-and-structs/constructors.md` + related | Pull + add primary constructors |
| Methods | `programming-guide/classes-and-structs/methods.md` + `concepts/methods.md` | Merge + revise |
| Polymorphism | `programming-guide/classes-and-structs/polymorphism.md` | Merge into Inheritance |
| Interfaces (OOP) | `programming-guide/interfaces/` | Pull + revise |
| Indexers | `programming-guide/indexers/` | Pull + add ranges/indexes |
| Events | `concepts/` events articles (subset) | Pull basic subset |
| Local functions | `concepts/` + `programming-guide/` | Merge + revise |
| Iterators | `concepts/iterators.md` + `programming-guide/` | Merge + revise |
| Type conversions | `programming-guide/types/` casting/conversion articles | Pull + revise |
| Tutorials (6 articles) | `tutorials/` section | Move into Fundamentals tutorials |

## Sections That Will Shrink

As content moves into Fundamentals, these existing top-level sections will lose articles. They aren't eliminated as part of this plan, but tracking what moves helps plan redirects.

| Section | Articles Moving Out | Remaining After |
|---|---|---|
| **Tutorials** | 6 (records, patterns, NRT, ranges, interpolation, console app) | REST client, LINQ tutorial (→ LINQ section) |
| **C# concepts** | Methods, iterators, delegates/events subset | Delegates/events (advanced), versioning |
| **How-to C# articles** | 5 string articles | Catch non-CLS exception |
| **C# programming guide** | ~15 articles from Classes/Structs, Interfaces, Indexers, Types | Covariance, generics (advanced), strings (advanced) |

## Open Items for Future Discussion

1. **Pattern matching depth**: The comprehensive pattern matching article may need to be split into two: one covering the core concepts and most common patterns, and one covering advanced patterns (list patterns, nested positional patterns, complex combinators).
1. **Generics article scope**: The single Generics article covers consuming, basic constraints, covariance/contravariance, *and* collection expressions. This may be too much for one article.
1. **Tutorial curation**: As Fundamentals grows, some existing tutorials may become redundant with the main content. Should any tutorials be retired rather than moved?
1. **Cross-references with Language Reference**: Many Fundamentals articles will need "See also" links to the corresponding Language Reference pages for complete syntax details.
1. **Redirect strategy**: Every moved article needs a redirect from its old URL. The redirect mapping should be produced as part of each phase's execution plan.

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
      # NEW: file-scoped namespaces, global usings, static using, type aliases (subset)
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
      # PULL from existing nullable warnings content
      href: fundamentals/null-safety/resolve-warnings.md
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
      # PULL from how-to
      href: fundamentals/strings/search.md
    - name: Split strings into substrings
      # PULL from how-to
      href: fundamentals/strings/split.md
    - name: Concatenate strings
      # PULL from how-to
      href: fundamentals/strings/concatenate.md
    - name: Modify string contents
      # PULL from how-to
      href: fundamentals/strings/modify.md
    - name: Compare strings
      # PULL from how-to
      href: fundamentals/strings/compare.md
    - name: "Tutorial: Explore string interpolation"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/string-interpolation.md

  # ─── §12–§13 Statements and expressions ───
  - name: Statements and expressions
    items:
    - name: Selection statements
      # NEW: if/else branching, switch statement, ternary conditional;
      # links to pattern matching for switch expressions
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

  # ─── §11 Patterns and pattern matching ───
  - name: Pattern matching
    items:
    - name: Overview
      # REVISE: comprehensive pattern matching covering all pattern types:
      # type (C# 7), constant, var, property (C# 8), extended property (C# 10),
      # positional (C# 8), relational/combinator/parenthesized (C# 9),
      # list patterns (C# 11), pattern matching with generics (C# 7.1)
      # switch expressions (C# 8). May need 2 articles.
      href: fundamentals/functional/pattern-matching.md
    - name: Discards
      # EXISTS: keep or merge into pattern matching
      href: fundamentals/functional/discards.md
    - name: Deconstruction
      # REVISE: records, tuples, custom Deconstruct;
      # mixed deconstructions (C# 10—use without explanation)
      href: fundamentals/functional/deconstruct.md
    - name: "Tutorial: Explore pattern matching"
      # PULL from current Tutorials section
      href: fundamentals/tutorials/pattern-matching.md
    - name: "Tutorial: Build data-driven algorithms with pattern matching"
      href: fundamentals/tutorials/pattern-matching-advanced.md

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
    - name: Self-documenting code
      href: fundamentals/coding-style/self-documenting-code.md
```
