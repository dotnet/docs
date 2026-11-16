> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase A: Program Structure (§7)

### PR 1 — Program structure: namespaces + preprocessor directives

[#52082](https://github.com/dotnet/docs/pull/52082) *Merged*

> ~10 files

1. Revise `fundamentals/program-structure/index.md` — add file-scoped namespaces, global usings as default style
2. Move+revise `fundamentals/types/namespaces.md` → `fundamentals/program-structure/namespaces.md` — add file-scoped namespaces (C# 10), global usings (C# 10), static using (C# 6), type/namespace aliases (subset)
3. New `fundamentals/program-structure/preprocessor-directives.md` — `#if`, `#region`, `#nullable`, `#pragma warning`
4. New `fundamentals/program-structure/organizing-programs.md` — assemblies, namespaces, and types as organizational tools (addresses [#34836](https://github.com/dotnet/docs/issues/34836))
5. Snippet files for new/revised articles
6. toc.yml + redirect for old namespaces path

**Namespace follow-through as shipped, reconciled 2026-11-16:** [#56771](https://github.com/dotnet/docs/pull/56771)
(Phase G / PR 24, merged 2026-11-12) retains `program-structure/namespaces.md` as a complete
short introduction and consolidates depth into `fundamentals/namespaces/overview.md`,
**Organize types with namespaces**. Both share the existing `snippets/namespaces/` project.
The older `fundamentals/types/namespaces.md` redirect now targets depth, not the introduction;
the introduction itself isn't redirected. This supersedes PR 1's depth ownership, not its
original delivery or the other program-structure tasks.

### PR 2 — Tutorial: System.CommandLine

[#52592](https://github.com/dotnet/docs/pull/52592) *Merged*

> ~4 files

1. New `fundamentals/tutorials/system-commandline.md` — demonstrate `System.CommandLine` for commands, subcommands, arguments, and options
2. Snippet files + toc.yml

