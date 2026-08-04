> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase D: Strings — 3 PRs

### PR 10 — Strings: overview, raw strings, nameof

[#53676](https://github.com/dotnet/docs/pull/53676) *Merged*

> ~10 files

1. Create `fundamentals/strings/` directory
2. New `fundamentals/strings/index.md` — basics, immutability, `string` vs `String`, verbatim strings, escape sequences, `\e` (C# 13)
3. New `fundamentals/strings/raw-string-literals.md` — `"""` syntax (C# 11), raw interpolated strings
4. New `fundamentals/strings/nameof.md` — `nameof` (C# 6)
5. Snippet files + toc.yml

> *Watch for redistribution:* the existing string content (verbatim, escape, raw-literal corners) often includes deep-cut detail (UTF-8 literals, custom interpolated string handlers, `Span<char>` manipulation, allocation comparisons) that fails universality. Cut those sub-sections to a Strings deep dive (or leave them in their current homes) and keep the Fundamentals overview, raw-literal, and `nameof` articles focused on everyday usage.

### PR 11 — Strings: interpolation + search + split

[#53991](https://github.com/dotnet/docs/pull/53991) *Merged*

> ~10 files

1. Pull+revise `fundamentals/strings/interpolation.md` — from `tutorials/string-interpolation.md`; add newlines (C# 11), constant interpolated (C# 10)
2. Pull `fundamentals/strings/common-tasks/search.md` — from `how-to/search-strings.md`
3. Pull `fundamentals/strings/common-tasks/split.md` — from `how-to/parse-strings-using-split.md`
4. toc.yml + redirects

> *Folder layout decision:* this PR introduces the `common-tasks/` subfolder convention for Fundamentals sections (now codified as [Decision 11](../decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials) in the Project Map). `interpolation.md` is a concept article and stays at the section root; `search.md` and `split.md` answer "how do I do X?" and go under `strings/common-tasks/` with snippets in `strings/common-tasks/snippets/`. The `toc.yml` renders **Common tasks** as a nested group beneath the concept articles in **Strings**.

> *Watch for redistribution:* the existing how-to articles for search and split include performance comparisons, regex-vs-method discussions, and `Span<char>`-based variants that fail universality. Cut those sub-sections to a Strings deep dive (or leave them in the existing how-to articles if those originals stay live), and pull only the everyday-usage core into Fundamentals.

### PR 12 — Strings: concatenate, modify, compare, interpolation tutorial

[#54475](https://github.com/dotnet/docs/pull/54475) *Merged*

> ~10 files

1. Pull `fundamentals/strings/common-tasks/concatenate.md` — from `how-to/concatenate-multiple-strings.md`
2. Pull `fundamentals/strings/common-tasks/modify.md` — from `how-to/modify-string-contents.md`
3. Pull `fundamentals/strings/common-tasks/compare.md` — from `how-to/compare-strings.md`
4. Pull `tutorials/string-interpolation.md` → `fundamentals/tutorials/string-interpolation.md`
5. toc.yml + redirects

> *Watch for redistribution:* the existing concatenate, modify, and compare how-tos include `StringBuilder` vs. concatenation benchmarks, culture-sensitive comparison deep-dives, and `string.Create`-style allocation guidance. Those sections fail universality — cut them to a Strings deep dive (or globalization content for culture-sensitive comparison) rather than carrying them into Fundamentals.

