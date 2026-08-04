> 🗺️ Part of the [Everyday C# Project Map](project-map.md).

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
| Expressions | C# 1 | Expressions and operators |
| Operators (arithmetic, relational, equality, logical, conditional, assignment) | C# 1 | Expressions and operators |
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

