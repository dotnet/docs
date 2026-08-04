> 📋 Part of the [Everyday C# Fundamentals restructuring plan](README.md). See also the [Project Map](../project-map.md).

## Phase C: Null Safety — 2 PRs

### PR 8 — Null safety: overview, nullable value types, null operators

[#53509](https://github.com/dotnet/docs/pull/53509) *Merged*

> ~10 files

1. Create `fundamentals/null-safety/` directory
2. New `fundamentals/null-safety/index.md` — unified null safety story, NVT vs. NRT comparison
3. New `fundamentals/null-safety/nullable-value-types.md` — `T?` for value types, `HasValue`, `GetValueOrDefault`
4. New `fundamentals/null-safety/null-operators.md` — `?.`, `?[]`, `??`, `??=`, null-conditional assignment, `is null`/`is not null`
5. Snippet files + toc.yml

### PR 9 — Null safety: NRT, warnings, migration, tutorial

[#53542](https://github.com/dotnet/docs/pull/53542) *Merged*

> ~10 files

1. Consolidate `fundamentals/null-safety/nullable-reference-types.md` — pull from `nullable-references.md` + `tutorials/nullable-reference-types.md`
2. Pull `fundamentals/null-safety/common-tasks/resolve-warnings.md` — from existing nullable warnings content
3. *Migration article stays in place* — the `nullable-migration-strategies.md` content remains at `advanced-topics/update-applications/nullable-migration-strategies.md` (the "Update existing apps" area); the Fundamentals NRT article links out to it rather than inlining migration strategy, because the migration guidance targets large pre-C# 8 codebases and fails Filter A universality (Goal 11 / Decision 1). No Fundamentals migration article is created.
4. Pull `tutorials/nullable-reference-types.md` → `fundamentals/tutorials/nullable-reference-types.md` (flat under tutorials, not nested under null-safety)
5. toc.yml + redirects (for the consolidated NRT article, `resolve-warnings.md`, and the NRT tutorial)

> *Folder layout note:* `resolve-warnings.md` is the only task-style article in this section, so it goes under `null-safety/common-tasks/`. The other articles in this PR are concept content at the section root, and the NRT tutorial lives flat under `fundamentals/tutorials/` per the [folder layout convention](../decisions.md#decision-11-fundamentals-folder-layout--concepts-common-tasks-tutorials).

