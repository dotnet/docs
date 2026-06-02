---
title: Customize GitHub Copilot modernization
description: "Learn how to customize GitHub Copilot modernization with custom skills, custom scenarios, scenario artifact edits, and chat instructions to encode your team's upgrade patterns."
ms.topic: concept-article
ms.date: 04/06/2026
ai-usage: ai-assisted

#customer intent: As a developer, I want to customize GitHub Copilot modernization so that I can encode my team's upgrade patterns, enforce coding standards during upgrades, and define custom upgrade workflows.

---

# Customize GitHub Copilot modernization

GitHub Copilot modernization is extensible. The agent provides multiple customization points to encode your team's upgrade patterns, enforce coding standards during upgrades, and define new upgrade workflows.

## Customization points overview

| Customization point | Scope | Persistence | Effort |
|---|---|---|---|
| **Chat instructions** | Per session or upgrade | Session or saved to `scenario-instructions.md` | Minimal |
| **Scenario artifacts** | Per upgrade | Duration of upgrade | Low |
| **Custom skills** | Team or personal | Permanent (checked into repo or user profile) | Medium |
| **Custom scenarios** | Team or personal | Permanent | High |

> [!TIP]
> Start with chat instructions and scenario artifact edits. Move to custom skills when you find yourself repeating the same instructions across upgrades.

## Customize through chat

Customize the agent's behavior in real time through natural conversation. The agent either applies your instruction immediately or persists it to `scenario-instructions.md` for future reference.

| You say | What happens |
|---|---|
| _"From now on, always commit after each task"_ | Saved to `scenario-instructions.md` as an execution preference |
| _"Skip test validation for this task"_ | Applied immediately to the current task only |
| _"Use the bottom-up strategy for this upgrade"_ | Affects the planning phase strategy |
| _"Don't touch the Logging project"_ | Added to preferences; agent excludes that project |
| _"Always use file-scoped namespaces"_ | Saved as a coding standard preference |
| _"Pause after each task for my review"_ | Saved as an execution style preference |

> [!TIP]
> To make an instruction persist across the entire upgrade, phrase it as a permanent preference: _"From now on, always..."_ or _"For all tasks in this upgrade..."_. The agent writes the instruction to `scenario-instructions.md`.

## Edit scenario artifacts

When the agent runs an upgrade, it creates a workspace in `.github/upgrades/{scenarioId}/`. The upgrade folder contains editable artifacts that directly control the agent's behavior.

### scenario-instructions.md

The `scenario-instructions.md` file is the agent's persistent memory for the upgrade. The agent always loads this file into context, so anything you write here directly influences every decision the agent makes.

Add sections like these to guide the agent:

```markdown
## User Preferences

### Technical Preferences
- Always prefer explicit type declarations over `var`
- Use `ILogger<T>` instead of `ILoggerFactory` for dependency injection
- Target .NET 10 for all projects
- Keep Newtonsoft.Json in the shared library (don't migrate to System.Text.Json)

### Execution Style
- **Pace**: Methodical
- **Pause Points**: After assessment, after each task group

### Custom Instructions

#### 02-common-lib
- Skip the database migration for now — it has external dependencies
- Use the connection string from `appsettings.Production.json` for testing

#### 03-data-layer
- Keep existing repository interfaces during migration
- Preserve all Entity Framework conventions

## Key Decisions Log
- 2025-01-15: Keep Newtonsoft.Json in SharedLib — third-party SDK requires it
- 2025-01-16: Skip database project — DBA team will handle separately
```

### plan.md

The `plan.md` file defines the tasks and their scope. Edit `plan.md` to:

- Reorder tasks to change the execution sequence.
- Add tasks the agent didn't plan for.
- Remove tasks that don't apply.
- Add notes to provide context for specific tasks.

### Individual task files

Each task in `tasks/{taskId}/task.md` contains the task specification and working notes. Edit these files to:

- Refine a task's scope.
- Add domain-specific context the agent missed.
- Provide code examples for the desired outcome.

> [!IMPORTANT]
> The agent's tools manage `tasks.md` as a read-only dashboard. Don't edit `tasks.md` directly. The agent overwrites any manual changes. Edit `scenario-instructions.md` or individual `task.md` files instead.

## Create custom skills

Skills are the primary extension point for the agent. A skill is a Markdown file with a metadata header that teaches the agent how to handle a specific upgrade, pattern, or task.

### Where to place custom skills

| Location | Scope | Use when |
|---|---|---|
| `.github/skills/my-skill.md` | Repository (shared with team) | Team-wide upgrade patterns |
| `.github/upgrades/skills/my-skill.md` | Repository (upgrade-specific) | Skills specific to upgrade scenarios |
| `%UserProfile%/.copilot/skills/my-skill.md` | User profile (personal, all repos) | Personal preferences and patterns |

> [!TIP]
> Repository-level skills (`.github/skills/`) are the most common choice. They travel with the code, and the entire team can use them.

### Skill file structure

Every skill file has two parts: a metadata header (which the agent uses to understand when the skill applies) and a Markdown body (instructions the agent follows).

```yaml
---
name: migrating-foobar-v2-to-v3
description: >
  Migrate our internal FooBar library from v2 to v3. Activates when
  FooBar.v2 NuGet package is detected, or when asked to "upgrade FooBar",
  "migrate FooBar", or "update FooBar library".
metadata:
  discovery: lazy
  traits: .NET | CSharp
---

# Migrating FooBar Library v2 to v3

## Overview

FooBar v3 introduces a new async-first API surface. This skill guides the
agent through replacing synchronous FooBar.v2 calls with their v3 async
equivalents, updating configuration, and verifying behavior.

## Workflow

1. **Identify FooBar.v2 references**
   - Search for `PackageReference` elements referencing `FooBar.v2`
   - Locate all `using FooBar.V2;` directives

2. **Update package references**
   - Replace `FooBar.v2` with `FooBar.v3` in all `.csproj` files
   - Run `dotnet restore` to verify resolution

3. **Migrate API calls**
   - Replace `FooBarClient.Send(...)` with `await FooBarClient.SendAsync(...)`
   - Replace `FooBarConfig.LoadFromFile(...)` with `FooBarConfig.LoadFromJsonAsync(...)`
   - Update method signatures to `async Task` where needed

4. **Update configuration**
   - Rename `foobar.config` to `foobar.json`
   - Migrate XML config entries to JSON format

5. **Verify**
   - Build the project: `dotnet build`
   - Run existing tests: `dotnet test`
   - Verify no remaining references to `FooBar.V2` namespace

## Success Criteria

- [ ] No references to `FooBar.v2` NuGet package remain
- [ ] All `FooBar.V2` namespace usages replaced with `FooBar.V3`
- [ ] Project builds without errors
- [ ] All existing tests pass

## Error Handling

- If `FooBar.v3` is not available in the configured NuGet feeds, instruct
  the user to add the internal feed
- If async migration causes deadlocks in legacy synchronous code paths,
  wrap calls with `.GetAwaiter().GetResult()` and add a TODO comment
```

### Metadata fields

| Field | Required | Description |
|---|---|---|
| `name` | Yes | Unique identifier in kebab-case. Start with a gerund verb (for example, `upgrading-`, `converting-`). Maximum 64 characters. |
| `description` | Yes | Determines when the agent loads the skill. Include trigger phrases, such as words and patterns that should activate the skill. |
| `metadata.discovery` | No | Controls when the skill loads: `preload` (always available), `lazy` (on-demand when description matches, default and recommended), or `scenario` (defines a workflow orchestrator). |
| `metadata.traits` | No | Keywords describing the technologies in your project, such as `.NET`, `CSharp`, `VisualBasic`, or `DotNetCore`. |

### Skill authoring best practices

- **Be specific in the description:** Include exact package names, library names, and natural-language trigger phrases users might type.
- **Include clear, step-by-step workflows:** Number the steps. Be explicit about what files to change and what commands to run.
- **Include success criteria:** Without success criteria, the agent doesn't know when to stop. Use checkboxes or a clear list of verifiable conditions.
- **Include error handling:** Anticipate common failure modes, such as missing packages, build failures, or broken tests.
- **Keep skills focused:** One skill per upgrade or task type. A skill for "upgrading FooBar v2 to v3" is better than "upgrading all internal libraries."
- **Name with a gerund verb:** Use `upgrading-foobar-v2-to-v3`, not `foobar-upgrade` or `foobar-v3`.
- **Use `lazy` discovery:** Use `lazy` discovery for most custom skills to avoid bloating the agent's context window.

## Create custom scenarios

For advanced users who want to define entirely new upgrade workflows, custom scenarios let you orchestrate a full multi-phase upgrade pipeline. A scenario is a skill with `metadata.discovery: scenario` that defines the phases the agent follows.

```yaml
---
name: migrating-soap-to-rest-api
description: >
  Migrate legacy WCF/SOAP services to ASP.NET Core REST APIs. Activates
  when WCF service references, .svc files, or SOAP clients are detected,
  or when asked to "migrate SOAP to REST", "replace WCF", or "convert
  web services to REST".
metadata:
  discovery: scenario
  traits: .NET | CSharp
  scenarioTraitsSet: [wcf, soap, web-services]
---

# SOAP to REST API Migration

## Pre-initialization

Gather from the user:
- Which SOAP services to migrate (all or specific ones)
- Whether to maintain backward compatibility with a SOAP facade
- Authentication mechanism for the new REST APIs
- API versioning strategy (URL path, header, query string)

## Assessment

Analyze the solution for:
- `.svc` files and WCF service contracts
- WSDL files and service references
- `System.ServiceModel` usage and binding configurations
- Data contracts and their serialization requirements
- Client proxies consuming SOAP services

## Planning

Create tasks in this order:
1. Create shared DTOs — Convert `[DataContract]` types to POCOs
2. Create REST controllers — One controller per `[ServiceContract]`
3. Map operations to HTTP methods
4. Migrate service implementations
5. Update clients — Replace `ChannelFactory`/generated proxies with `HttpClient`
6. Remove WCF infrastructure
7. Add API documentation — Swagger/OpenAPI via Swashbuckle

## Execution

For each service contract:
1. Create a corresponding controller
2. Create a service interface and implementation
3. Register the service in DI
4. Map WCF operations to REST endpoints
5. Update any in-solution clients to use the new REST endpoints
6. Build and run existing tests
```

Place scenario files in `.github/skills/` or `.github/upgrades/skills/` for the agent to discover them.

> [!TIP]
> The `scenarioTraitsSet` field defines traits that the agent uses to match your scenario against the solution's characteristics. These traits help the agent suggest your scenario when appropriate.

## Source control and branching

The agent offers to work on a Git branch, but you have full control over the strategy:

- **Branch naming:** Tell the agent what branch name to use, or let the agent suggest one.
- **Per-task branches:** Request a separate branch per task for granular review.
- **Commit timing:** Choose when the agent commits: after every completed task (default), only at the end of the full upgrade, or on demand.
- **No source control:** The agent also works with non-Git folders but recommends backing up your project first.

Example chat instructions:

- _"Use branch name 'upgrade/dotnet10' for this upgrade"_
- _"Create a branch per task so I can review each one separately"_
- _"Don't commit until I explicitly ask you to"_
- _"Commit after every task with a descriptive message"_

> [!TIP]
> For large multi-project upgrades, per-task branches give you flexibility to review and merge each change independently, or roll back a single task without affecting the rest.

## Skill loading priority

When the agent discovers multiple skills, it resolves them using a priority system. Higher-priority sources override or supplement lower-priority ones:

| Priority | Source | Location |
|---|---|---|
| 5 (highest) | Custom skills (user-provided through API) | — |
| 4 | User profile skills | `%UserProfile%/.copilot/skills/` |
| 3 | Repository upgrade skills | `.github/upgrades/skills/` |
| 2 | Repository skills | `.github/skills/` |
| 1 (lowest) | Embedded skills (built into the agent) | — |

The agent collects skills from all sources. When skills have overlapping scope, higher-priority sources take precedence. The `discovery` field controls when the skill loads. `lazy` means on demand when relevant, and `preload` means always available.

> [!TIP]
> You don't need to replace a built-in skill to change behavior. A higher-priority repository skill supplements the built-in skill, adding your team's specific conventions on top of the baseline behavior.

## Related content

- [Core concepts](concepts.md)
- [Scenarios and skills reference](scenarios-and-skills.md)
- [Apply custom upgrade instructions](how-to-custom-upgrade-instructions.md)
- [Best practices](best-practices.md)
