> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase B: Type System (§8) — 5 PRs

### PR 3 — Type system: overview, built-in types, enums

[#52608](https://github.com/dotnet/docs/pull/52608) *Merged*

> ~10 files

1. Revise `fundamentals/types/index.md` — value vs. reference, unified type system
2. New `fundamentals/types/built-in-types.md` — numeric types (incl. unsigned, `nint`), `bool`, `char`, `string` intro, literals, `default`, `var`, target-typed `new`, `dynamic`
3. New `fundamentals/types/enums.md` — core enum usage and patterns
4. Snippet files + toc.yml

### PR 4 — Type system: classes, structs, records

[#52685](https://github.com/dotnet/docs/pull/52685) *Merged*

1. Revise `fundamentals/types/classes.md` — static classes (C# 2), object/collection initializers (C# 3)
2. New `fundamentals/types/structs.md` — struct design, auto-default (C# 11), parameterless constructors (C# 10), readonly members (C# 8), record structs (C# 10)
3. Revise `fundamentals/types/records.md` — ensure record structs and `with` expressions covered
4. Snippet files + toc.yml

### PR 5 — Type system: tuples, interfaces, generics

[#52891](https://github.com/dotnet/docs/pull/52891) *Merged*

> ~10 files

1. Replace `fundamentals/types/anonymous-types.md` → `fundamentals/types/tuples.md` — merge existing tuples + deconstruct content; add inferred names (C# 7.1), tuple comparison (C# 7.3), `with` on tuples. Redirect old URL
2. Revise `fundamentals/types/interfaces.md` — declaring and implementing (exclude default interface members, static abstract members)
3. Revise `fundamentals/types/generics.md` — add collection expressions (C# 12), dictionary expressions (C# 14), spread `..`, co-/contra-variance
4. Snippet files + toc.yml + redirect

### PR 6 — Type system: conversions, delegates/lambdas, records tutorial

[#52973](https://github.com/dotnet/docs/pull/52973) *Merged*

> ~10 files

1. New `fundamentals/types/conversions.md` — pull+revise from `programming-guide/types/casting-and-type-conversions.md` and `programming-guide/types/boxing-and-unboxing.md`. Add redirects
2. New `fundamentals/types/delegates-lambdas.md` — `Func<>`/`Action<>`, lambda basics, static lambdas, discard params, brief events intro
3. Pull `tutorials/records.md` → `fundamentals/tutorials/records.md` + redirect
4. Snippet files + toc.yml + redirects

### PR 7 — Tutorial: Choosing between tuples, records, structs, and classes

[#53160](https://github.com/dotnet/docs/pull/53160) *Merged*

> ~4 files

1. New `fundamentals/tutorials/choosing-types.md` — teach readers to decide between using tuples, defining records, defining structs or classes, and defining interfaces
2. Snippet files + toc.yml

