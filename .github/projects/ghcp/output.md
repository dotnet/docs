# Fact-Check and Decision Log — GitHub Copilot Modernization Documentation Update

This document maps every change and new article back to its source material in `.github/projects/ghcp/` for verification. Each section identifies the claim made in the published documentation, the source file that supports it, and the relevant excerpt or detail from the source.

---

## Table of Contents

- [Updated articles](#updated-articles)
  - [overview.md changes](#overviewmd-changes)
  - [install.md changes](#installmd-changes)
  - [faq.yml changes](#faqyml-changes)
  - [how-to-upgrade-with-github-copilot.md changes](#how-to-upgrade-with-github-copilotmd-changes)
  - [toc.yml and index.yml changes](#tocyml-and-indexyml-changes)
- [New articles](#new-articles)
  - [concepts.md](#conceptsmd)
  - [scenarios-and-skills.md](#scenarios-and-skillsmd)
  - [best-practices.md](#best-practicesmd)
  - [troubleshooting.md](#troubleshootingmd)

---

## Updated articles

### overview.md changes

#### 1. New "Scenarios" section with 8 scenarios table

**Published claim:** The agent provides 8 scenarios: .NET version upgrade, Aspire integration, Aspire version upgrade, SDK-style conversion, Newtonsoft.Json migration, SqlClient migration, Azure Functions upgrade, Semantic Kernel to Agents.

**Source file:** `starting-info.md` and `scenarios-and-skills.md`

**Source evidence (starting-info.md):**
> - .NET Framework/Core versions (.NET 1.x-7) → .NET 8, 9, 10+ upgrades
> - SDK-Style Conversion (legacy → modern project format)
> - Newtonsoft.Json → System.Text.Json migration
> - SqlClient migration (System.Data → Microsoft.Data)
> - Azure Functions in-process → isolated worker model
> - Semantic Kernel → Agents Framework migration

**Source evidence (scenarios-and-skills.md):**
> | **.NET Version Upgrade** | Upgrades projects from any older .NET version to .NET 8, 9, 10, or later | *"Upgrade my solution to .NET 10"* |
> | **Aspire Integration** | Adds .NET Aspire orchestration for inner-loop dev and optional Azure deployment | *"Add Aspire to my solution"* |
> | **Aspire Version Upgrade** | Upgrades existing Aspire projects to a newer Aspire version with code transforms and TFM updates | *"Upgrade my Aspire project to latest"* |
> | **SDK-Style Conversion** | Converts legacy project files to modern SDK-style format | *"Convert my projects to SDK-style"* |
> | **Newtonsoft.Json Migration** | Replaces Newtonsoft.Json with System.Text.Json across a solution | *"Migrate from Newtonsoft.Json"* |
> | **SqlClient Migration** | Migrates System.Data.SqlClient to Microsoft.Data.SqlClient | *"Update SqlClient to the modern package"* |
> | **Azure Functions Upgrade** | Migrates Azure Functions from in-process to isolated worker model | *"Upgrade my Azure Functions"* |
> | **Semantic Kernel to Agents Framework** | Migrates from SK Agents to Microsoft Agents AI Framework | *"Migrate my SK agents"* |

**Example prompts** in the table are taken directly from `scenarios-and-skills.md`.

---

#### 2. C# and Visual Basic support

**Published claim:** "The modernization agent supports upgrading C# and Visual Basic projects"

**Source file:** `starting-info.md`

**Source evidence:**
> Supports C# and Visual Basic, all project types

**Source file:** `core-concepts.md`

**Source evidence:**
> The agent understands project files, NuGet dependencies, breaking changes, and migration patterns across dozens of .NET technologies — for both C# and Visual Basic projects.

---

#### 3. New project types: WinUI, .NET MAUI, Xamarin, xUnit

**Published claim:** Added WinUI, .NET MAUI and Xamarin, and xUnit to the project types list.

**Source file:** `getting-started.md`

**Source evidence (Supported Project Types):**
> - Console apps, class libraries, WPF, WinForms, WinUI
> - ASP.NET (MVC, Blazor, Razor Pages, Web API)
> - Azure Functions, Xamarin, .NET MAUI
> - Test projects (MSTest, xUnit, NUnit)

---

#### 4. Supported upgrade paths table

**Published claim:** Version matrix table showing .NET Framework → .NET 8/9/10+, .NET Core 1.x–3.x → .NET 8/9/10+, etc.

**Source file:** `scenario-walkthrough.md`

**Source evidence:**
> | .NET Framework (any version) | .NET 8, .NET 9, .NET 10 or later |
> | .NET Core 1.x | .NET 8, .NET 9, .NET 10 or later |
> | .NET Core 2.x | .NET 8, .NET 9, .NET 10 or later |
> | .NET Core 3.x | .NET 8, .NET 9, .NET 10 or later |
> | .NET 5, 6, 7, 8, 9 | .NET 10 or later |

**Source file:** `troubleshooting.md`

**Source evidence:**
> | .NET Framework (any version, with SDK-style conversion) | .NET 8, .NET 9, .NET 10 or later |
> | .NET 8 | .NET 9, .NET 10 or later |
> | .NET 9 | .NET 10 or later |

---

#### 5. Four-phase workflow (was "three-stage")

**Published claim:** The workflow now has four phases: Assessment, Upgrade options, Planning, Execution.

**Source file:** `core-concepts.md`

**Source evidence:**
> Every scenario follows the same four-stage lifecycle.
> ### Stage 1: Pre-initialization
> ### Stage 2: Assessment
> ### Stage 3: Planning (includes Upgrade Options Confirmation + Plan Generation)
> ### Stage 4: Execution

**Decision note:** The source describes pre-initialization as "Stage 1" and assessment/planning/execution as stages 2-4. The source also embeds "Upgrade Options Confirmation" as a sub-phase within Stage 3 (Planning). I chose to surface upgrade options as its own named phase in the docs because the source gives it significant weight—a dedicated file (`upgrade-options.md`), detailed strategy decisions, and a review step. The existing docs already called it "three-stage," so updating to "four-phase" with a separate "Upgrade options" phase makes the workflow clearer for users. The phases as documented are:
1. Assessment → generates `assessment.md`
2. Upgrade options → generates `upgrade-options.md`
3. Planning → generates `plan.md`, `scenario-instructions.md`, `tasks.md`
4. Execution → updates `tasks.md`

---

#### 6. Upgrade strategies table (bottom-up, top-down, all-at-once)

**Published claim:** Three strategies with descriptions and "best for" guidance.

**Source file:** `core-concepts.md`

**Source evidence:**
> | Strategy | Best For | How |
> | **Bottom-up** | Large solutions with deep dependency graphs | Start with leaf projects (no dependencies), work upward |
> | **Top-down** | Quick feedback on main app | Start with the application project, fix dependencies as needed |
> | **All-at-once** | Small, simple solutions | Upgrade everything in one pass |

---

#### 7. Flow modes (Automatic and Guided)

**Published claim:** Two flow modes with switching via "pause"/"continue" commands.

**Source file:** `core-concepts.md`

**Source evidence:**
> | Mode | When Pauses | Best For |
> | **Automatic** | Only at genuine blockers | Experienced users, straightforward upgrades, small solutions |
> | **Guided** | At each stage boundary | First-time users, complex solutions, when learning process |
> Switchable mid-session with *"pause"* → guided, *"continue"* → automatic

---

#### 8. State management table (8 files)

**Published claim:** Table listing `assessment.md`, `upgrade-options.md`, `plan.md`, `tasks.md`, `scenario-instructions.md`, `execution-log.md`, `tasks/{taskId}/task.md`, `tasks/{taskId}/progress-details.md`.

**Source file:** `core-concepts.md`

**Source evidence:**
> Files in `.github/upgrades/{scenarioId}/`:
> - `scenario-instructions.md` — Agent's persistent memory
> - `upgrade-options.md` — Confirmed upgrade decisions
> - `plan.md` — Upgrade plan and strategy
> - `tasks.md` — Visual progress dashboard
> - `execution-log.md` — Detailed change log
> - `tasks/{taskId}/task.md` — Per-task scope and context
> - `tasks/{taskId}/progress-details.md` — Per-task execution notes and results

**Source file:** `getting-started.md`

**Source evidence (folder structure):**
> ```
> .github/upgrades/<scenario>/<operation>/
> ├── scenario-instructions.md
> ├── assessment.md
> ├── plan.md
> ├── tasks.md
> ├── execution-log.md
> └── tasks/
>     ├── 01-common-lib/
>     │   ├── task.md
>     │   └── progress-details.md
>     └── 02-web-api/
>         ├── task.md
>         └── progress-details.md
> ```

---

#### 9. Cross-IDE continuity claim

**Published claim:** "you can close your IDE, switch between sessions, or even switch between development environments (for example, start in VS Code and continue in Visual Studio)"

**Source file:** `core-concepts.md`

**Source evidence:**
> Cross-IDE continuity (VS Code → Visual Studio mid-upgrade)

**Source file:** `working-with-the-agent.md`

**Source evidence:**
> **Cross-IDE support:** Start VS Code, continue Visual Studio (shared state folder)

---

### install.md changes

#### 1. VS Code extension name fix

**Published claim:** Changed from linking to `vscjava.migrate-java-to-azure` marketplace extension to step-by-step instructions searching for "GitHub Copilot modernization for .NET".

**Source file:** `getting-started.md`

**Source evidence:**
> **VS Code:**
> 1. Extensions view (`Ctrl+Shift+X`)
> 2. Search "GitHub Copilot modernization for .NET"
> 3. Install
> 4. Auto-acquires .NET SDK if missing
> 5. Registers tools
> 6. Adds to Copilot Chat as `modernize-dotnet`

The extension ID `ms-dotnettools.vscode-dotnet-modernize` appears in `getting-started.md` as the VS Code extension identifier.

**Decision note:** The old extension link `vscjava.migrate-java-to-azure` was clearly wrong (it references Java, not .NET). The source confirms the correct behavior but I chose to use step-by-step instructions rather than a marketplace link because the source provides those steps explicitly and the correct marketplace URL/extension ID may need verification.

---

#### 2. Visual Basic support in prerequisites

**Published claim:** Changed "Code written in C#" to "Code written in C# or Visual Basic"

**Source file:** `starting-info.md`

**Source evidence:**
> Supports C# and Visual Basic

**Source file:** `core-concepts.md`

**Source evidence:**
> for both C# and Visual Basic projects

---

### faq.yml changes

#### 1. Updated "Can I customize or guide the agent?" answer

**Published claim:** Added "30+ built-in migration skills", "custom skills and scenarios", and `scenario-instructions.md` persistence.

**Source file:** `scenarios-and-skills.md`

**Source evidence:**
> The agent ships with 30+ built-in skills.

**Source file:** `core-concepts.md`

**Source evidence:**
> When you say "always use explicit types instead of `var`" or "skip test validation for now," the agent writes that to `scenario-instructions.md` and remembers it across sessions.

---

#### 2. Expanded "What can the agent upgrade?" with new scenarios and project types

**Published claim:** Added Aspire integration, SDK-style conversion, Newtonsoft.Json migration, SqlClient migration, Azure Functions upgrade, Semantic Kernel to Agents. Added WinUI, .NET MAUI, Xamarin, xUnit. Added Visual Basic support.

**Source files:** Same evidence as overview.md changes #1, #2, #3 above.

---

#### 3. New Q&A: "What .NET versions can I upgrade to?"

**Published claim:** Version matrix table.

**Source files:** Same evidence as overview.md change #4.

---

#### 4. New Q&A: "Can I use the agent offline?"

**Published claim:** "No. The agent requires an internet connection and the GitHub Copilot cloud infrastructure."

**Source file:** `troubleshooting.md`

**Source evidence:**
> **Can I use the agent offline?**
> **No.** The agent requires GitHub Copilot, which needs an active internet connection. All AI processing happens through GitHub Copilot's cloud infrastructure.

---

#### 5. New Q&A: "Does the agent modify files outside the solution?"

**Published claim:** "No. The agent only modifies files within your workspace and the `.github/upgrades/` folder."

**Source file:** `troubleshooting.md`

**Source evidence:**
> **Does the agent modify files outside my solution?**
> **No.** The agent only modifies files within your workspace. The only addition outside your solution's source files is the `.github/upgrades/` folder.

---

#### 6. New Q&A: "Can I partially accept the agent's changes?"

**Published claim:** "Yes. Because each task is committed separately, you can cherry-pick specific commits."

**Source file:** `troubleshooting.md`

**Source evidence:**
> **Can I partially accept the agent's changes?**
> **Yes.** Because each task is committed separately, you can cherry-pick individual commits or revert specific ones.

---

### how-to-upgrade-with-github-copilot.md changes

#### 1. Updated from "three-stage" to "four-phase"

**Published claim:** Changed description, frontmatter, and workflow list from three stages to four phases.

**Source file:** Same evidence as overview.md change #5.

---

#### 2. New "Review upgrade options" section

**Published claim:** Added a section describing upgrade options between assessment and planning, covering upgrade strategy, project migration approach, technology modernization, package management, and compatibility handling.

**Source file:** `core-concepts.md`

**Source evidence:**
> #### Upgrade Options Confirmation
> The agent evaluates your solution and identifies which upgrade decisions are relevant...
> - **Upgrade strategy** — Bottom-up, top-down, or all-at-once
> - **Project migration approach** — In-place rewrite vs side-by-side for web applications; in-place vs multi-targeting for libraries
> - **Technology modernization** — Choices for Entity Framework migration, dependency injection, logging, configuration
> - **Package management** — Whether and when to adopt Central Package Management
> - **Compatibility handling** — How to address unsupported APIs, unsupported packages, and Windows-specific APIs

**Source file:** `scenario-walkthrough.md`

**Source evidence:**
> **Phase 3: Upgrade Options**
> Agent evaluates relevant decisions:
> - **Bottom-up:** Leaf projects first, work upward
> - **Top-down:** Application first, fix dependencies
> - **All-at-once:** All projects in one pass

---

#### 3. Added `scenario-instructions.md` mention in planning section

**Published claim:** "The agent also creates a `scenario-instructions.md` file that stores preferences, decisions, and custom instructions."

**Source file:** `core-concepts.md`

**Source evidence:**
> Planning produces three key artifacts:
> - **`plan.md`** — The upgrade plan
> - **`scenario-instructions.md`** — Your preferences, decisions, and the agent's memory
> - **`tasks.md`** — Visual progress dashboard

---

### toc.yml and index.yml changes

**Published claim:** Added 4 new entries: Core concepts, Scenarios and skills reference, Best practices, Troubleshooting.

**Decision note:** These entries correspond to the 4 new articles created. The placement in the TOC follows the existing pattern: conceptual/reference articles at the top level (Core concepts, Scenarios and skills), and operational articles under "Upgrade .NET apps" (Best practices, Troubleshooting).

---

## New articles

### concepts.md

#### Source mapping

| Section | Primary source file(s) | Content type |
|---|---|---|
| The agent as a teammate | `core-concepts.md` § "The Agent as a Teammate" | Adapted |
| Scenarios | `core-concepts.md` § "Scenarios" | Adapted |
| The workflow lifecycle (4 phases) | `core-concepts.md` § "The Workflow Lifecycle" | Adapted |
| Upgrade strategies | `core-concepts.md` § "Upgrade Options" | Adapted |
| Skills | `core-concepts.md` § "Skills" | Adapted |
| Tasks | `core-concepts.md` § "Tasks" | Adapted |
| State management | `core-concepts.md` § "State Management" | Adapted |
| Resumability | `core-concepts.md` § "Resumability" | Adapted |
| Cross-IDE continuity | `core-concepts.md` § "Cross-IDE Continuity" (under State Management) | Adapted |
| Flow modes | `core-concepts.md` § "Flow Modes" | Adapted |

**Key claims to verify:**

1. **"30+ built-in skills"** — Source: `scenarios-and-skills.md` lists 10 Common + 5 Data Access + 7 ASP.NET Framework + 17 MVC + 1 WCF + 7 Cloud + 12 Libraries = 59 skills. The "30+" claim comes from `starting-info.md` ("Includes 30+ specialized skills") and `core-concepts.md`. The full list in `scenarios-and-skills.md` actually exceeds 30.

2. **"scenario-instructions.md is the agent's persistent memory"** — Source: `core-concepts.md` states: "`scenario-instructions.md` — Agent's persistent memory (preferences, decisions, instructions)"

3. **"Switch modes with 'pause' or 'continue'"** — Source: `core-concepts.md` states: "Switchable mid-session with *'pause'* → guided, *'continue'* → automatic"

4. **Mermaid diagrams** — NOT included in the published article. The source `core-concepts.md` contains Mermaid flowcharts, but I omitted them from the published docs because Microsoft Learn doesn't universally support Mermaid rendering in all contexts. The workflow is described in prose instead.

---

### scenarios-and-skills.md

#### Source mapping

| Section | Primary source file | Content type |
|---|---|---|
| Scenarios table (8 entries) | `scenarios-and-skills.md` § "Scenarios" | Direct adaptation |
| .NET Version Upgrade | `scenarios-and-skills.md` § ".NET Version Upgrade" | Adapted |
| Aspire Integration | `scenarios-and-skills.md` § "Aspire Integration" | Adapted |
| Aspire Version Upgrade | `scenarios-and-skills.md` § "Aspire Version Upgrade" | Adapted |
| SDK-Style Conversion | `scenarios-and-skills.md` § "SDK-Style Conversion" | Adapted |
| Newtonsoft.Json Migration | `scenarios-and-skills.md` § "Newtonsoft.Json Migration" | Adapted |
| SqlClient Migration | `scenarios-and-skills.md` § "SqlClient Migration" | Adapted |
| Azure Functions Upgrade | `scenarios-and-skills.md` § "Azure Functions Upgrade" | Adapted |
| Semantic Kernel to Agents | `scenarios-and-skills.md` § "Semantic Kernel to Agents Framework" | Adapted |
| Migration skills—common (10) | `scenarios-and-skills.md` § "Migration Skills — Common" | Direct adaptation |
| Migration skills—data access (5) | `scenarios-and-skills.md` § "Migration Skills — Data Access" | Direct adaptation |
| Migration skills—web and ASP.NET (25) | `scenarios-and-skills.md` § "Migration Skills — Web / ASP.NET" | Direct adaptation |
| Migration skills—cloud and Azure (7) | `scenarios-and-skills.md` § "Migration Skills — Cloud / Azure" | Direct adaptation |
| Migration skills—libraries (12) | `scenarios-and-skills.md` § "Migration Skills — Libraries" | Direct adaptation |
| When skills activate | `scenarios-and-skills.md` § "When Skills Activate" | Direct adaptation |
| Create your own skills | `scenarios-and-skills.md` § "Creating Your Own Skills" | Adapted |

**Key claims to verify:**

1. **Aspire Integration details** — Source: `scenarios-and-skills.md` includes 6 numbered steps starting with "Scans your solution for compatible projects...". Published article preserves all 6 steps.

2. **Aspire Version Upgrade details** — Source: `scenarios-and-skills.md` includes 7 numbered steps. Published article preserves all 7, including the package rename example (`Aspire.Hosting.NodeJs` → `Aspire.Hosting.JavaScript`).

3. **All skill names and descriptions** — Every skill name and "What It Does" column is adapted directly from the corresponding table in the source. No skills were invented.

4. **Skill placement locations** — Source: `scenarios-and-skills.md` states `.github/skills/` (repository) and `%UserProfile%/.copilot/skills/` (user profile). Published article matches.

---

### best-practices.md

#### Source mapping

| Section | Primary source file | Content type |
|---|---|---|
| Before you start | `best-practices.md` § "Before You Start" | Adapted |
| Verify that your solution builds | `best-practices.md` § "Ensure your solution builds and tests pass" | Adapted |
| Commit or stash | `best-practices.md` § "Commit or stash uncommitted work" | Adapted |
| Back up non-Git repos | `best-practices.md` § "Non-Git repositories" | Adapted |
| Review test coverage | `best-practices.md` § "Review your test coverage" | Adapted |
| Start small | `best-practices.md` § "Start small" | Adapted |
| During the upgrade | `best-practices.md` § "During the Upgrade" | Adapted |
| Use guided mode | `best-practices.md` § "Use guided mode for your first upgrade" | Adapted |
| Review assessment carefully | `best-practices.md` § "Review the assessment carefully" | Adapted |
| Take time with planning | `best-practices.md` § "Don't rush the planning phase" | Adapted |
| Give feedback immediately | `best-practices.md` § "Give feedback when something looks wrong" | Adapted |
| Common pitfalls | `best-practices.md` § "Gotchas & Common Pitfalls" | Adapted |
| Large solutions 50+ | `best-practices.md` § "Large solutions (50+ projects)" | Adapted |
| Private NuGet feeds | `best-practices.md` § "Private NuGet feeds" | Adapted |
| Custom MSBuild targets | `best-practices.md` § "Custom MSBuild targets and imports" | Adapted |
| Session timeouts | `best-practices.md` § "Session timeouts" | Adapted |
| Collaborate effectively | `best-practices.md` § "Tips for Effective Collaboration" | Adapted |
| Be specific about scope | `best-practices.md` § "Be specific about scope" (with table) | Direct adaptation |
| Share constraints | `best-practices.md` § "Share your constraints" | Adapted |
| Explain architecture | `best-practices.md` § "Explain your architecture" | Adapted |
| Ask why | `best-practices.md` § "Ask why" | Adapted |
| Save preferences early | `best-practices.md` § "Save preferences early" | Adapted |
| Recover from problems | `best-practices.md` § "When Things Go Wrong" | Adapted |
| Build failures after task | `best-practices.md` § "Build failures after a task" | Adapted |
| Wrong strategy | `best-practices.md` § "Wrong strategy chosen" | Adapted |
| Agent stuck in loop | `best-practices.md` § "Agent stuck in a loop" | Adapted |
| Undo all changes | `best-practices.md` § "Need to undo everything" | Adapted |
| Security and privacy | `best-practices.md` § "Security & Privacy" | Adapted |
| Performance tips | `best-practices.md` § "Performance Tips" | Adapted |

**Key claims to verify:**

1. **"50+ projects" threshold** — Source: `best-practices.md` states "Large solutions (50+ projects): Monitor progress, consider batching"

2. **Git undo commands** — Source: `best-practices.md` provides `git checkout your-original-branch` and `git branch -D upgrade-branch`. Published article matches.

3. **Privacy claim about code not being retained** — Source: `best-practices.md` states "Code snippets sent to Copilot follow GitHub's privacy policy; not retained beyond session." Published article links to GitHub's Copilot privacy policy.

4. **Build caching tip** — Source: `best-practices.md` states "Build caching helps (avoid clean between tasks)". Published article matches.

**Content omitted from source:**
- "Review scenario-instructions.md periodically" — This guidance from the source was not included as a separate section but is referenced in the "Save preferences early" section context.

---

### troubleshooting.md

#### Source mapping

| Section | Primary source file | Content type |
|---|---|---|
| Agent says "no scenarios found" | `troubleshooting.md` § 1 | Adapted |
| Agent can't resume | `troubleshooting.md` § 1 | Adapted |
| Tasks stuck in progress | `troubleshooting.md` § 1 "Tasks stuck in 🔄" | Adapted |
| Agent suggests wrong scenario | `troubleshooting.md` § 1 | Adapted |
| Build fails after changes | `troubleshooting.md` § 2 | Adapted |
| NuGet restore fails | `troubleshooting.md` § 2 | Adapted |
| Agent generates bad code | `troubleshooting.md` § 2 | Adapted |
| Agent can't create branch | `troubleshooting.md` § 3 | Adapted |
| Undo all changes | `troubleshooting.md` § 3 | Adapted |
| Agent is slow | `troubleshooting.md` § 4 | Adapted |
| Assessment takes long | `troubleshooting.md` § 4 | Adapted |
| Custom skill not picked up | `troubleshooting.md` § 5 | Adapted |
| scenario-instructions.md not working | `troubleshooting.md` § 5 | Adapted |
| Get help | `troubleshooting.md` § 6 | Adapted |

**Key claims to verify:**

1. **Skill file locations** — Source: `troubleshooting.md` lists `.github/skills/`, `.github/upgrades/skills/`, `%UserProfile%/.copilot/skills/`. Published article matches. Note: the source `customization-guide.md` also lists `.claude/skills/` and `%UserProfile%/.claude/skills/` as alternative locations, but I omitted these from the troubleshooting article because they appear to be legacy/alternative paths and including them might confuse users.

2. **scenario-instructions.md sections** — Source: `troubleshooting.md` lists "User Preferences", "Key Decisions", "Custom Instructions" as the correct sections. Published article matches.

3. **"re-assess and re-plan" recovery** — Source: `troubleshooting.md` states "ask the agent to 're-assess and re-plan' to regenerate them." Published article matches.

**Content omitted from source:**
- The "Frequently Asked Questions" section from the source troubleshooting.md was not duplicated in the published troubleshooting article because those Q&As were incorporated into `faq.yml` instead (offline use, file scope, version matrix, partial acceptance).
- The `.claude/skills/` alternative skill locations from `customization-guide.md` were omitted.
- The Git Note about non-Git folders was preserved from the source as a `[!NOTE]` alert.

---

### customization.md

#### Source mapping

| Section | Primary source file | Content type |
|---|---|---|
| Customization points overview | `customization-guide.md` § "Overview of Customization Points" | Direct adaptation |
| Customize through chat | `customization-guide.md` § "Customizing Through Chat" | Direct adaptation |
| Edit scenario artifacts | `customization-guide.md` § "Editing Scenario Artifacts" | Adapted |
| scenario-instructions.md | `customization-guide.md` § "scenario-instructions.md" | Direct adaptation (includes code example) |
| plan.md editing | `customization-guide.md` § "plan.md" | Adapted |
| Individual task files | `customization-guide.md` § "Individual Task Files" | Adapted |
| Create custom skills | `customization-guide.md` § "Creating Custom Skills" | Adapted |
| Skill file locations table | `customization-guide.md` § "Where to Put Custom Skills" | Adapted (omitted `.claude/` alternatives) |
| Skill file structure | `customization-guide.md` § "Skill File Structure" | Direct adaptation (full code example) |
| Metadata fields table | `customization-guide.md` § "Metadata Fields" | Direct adaptation |
| Skill authoring best practices | `customization-guide.md` § "Best Practices for Skill Authoring" | Adapted |
| Create custom scenarios | `customization-guide.md` § "Creating Custom Scenarios" | Adapted (SOAP-to-REST example) |
| Source control and branching | `customization-guide.md` § "Source Control & Branching" | Adapted |
| Skill loading priority | `customization-guide.md` § "Skill Loading Priority" | Adapted (table instead of ASCII art) |

**Key claims to verify:**

1. **Skill file locations** — Source lists 5 locations including `.claude/` alternatives. Published article lists 3 (`.github/skills/`, `.github/upgrades/skills/`, `%UserProfile%/.copilot/skills/`). The `.claude/` paths were omitted as legacy alternatives.

2. **Skill loading priority (5 levels)** — Source shows: Custom API (5) > User profile (4) > Repo upgrade skills (3) > Repo skills (2) > Embedded (1). Published article matches with a table format.

3. **scenarioTraitsSet field** — Source: `customization-guide.md` states the field is used to match scenarios against solution characteristics. Published article matches.

4. **tasks.md is read-only** — Source: `customization-guide.md` states "The `tasks.md` file is a **read-only dashboard** managed by the agent's tools. Don't edit it directly." Published article uses an `[!IMPORTANT]` alert for this.

**Content omitted:**
- Contoso.Http example (Example 1) — Redundant with the FooBar example already in the skill structure section.
- Anthropic prompt engineering reference link — Omitted as external/non-Microsoft reference.
- `.claude/skills/` alternative locations — Omitted as legacy paths.

---

### working-with-agent.md

#### Source mapping

| Section | Primary source file | Content type |
|---|---|---|
| Introduction (agent as teammate) | `working-with-the-agent.md` § "Think of the Agent as a Teammate" | Adapted |
| Start a conversation | `working-with-the-agent.md` § "Starting a Conversation" | Adapted |
| What to say table | `working-with-the-agent.md` § "What to Say" | Direct adaptation |
| What happens next | `working-with-the-agent.md` § "What Happens Next" | Adapted |
| Choose a flow mode | `working-with-the-agent.md` § "Flow Modes" | Adapted |
| Switch modes mid-session | `working-with-the-agent.md` § "Switching Mid-Session" | Direct adaptation |
| Teach the agent | `working-with-the-agent.md` § "Teaching the Agent" | Adapted |
| Correct/preferences/task-specific | `working-with-the-agent.md` § "Correct Mistakes", "Set Preferences", "Custom Instructions per Task" | Direct adaptation (conversation examples) |
| What the agent saves table | `working-with-the-agent.md` § "What the Agent Saves" | Direct adaptation |
| Mid-session corrections | `working-with-the-agent.md` § "Mid-Session Corrections" | Adapted |
| Pause/redirect/undo/ask | `working-with-the-agent.md` § multiple sub-sections | Direct adaptation (conversation examples) |
| Review the agent's work | `working-with-the-agent.md` § "Reviewing the Agent's Work" | Adapted |
| Workflow files table | `working-with-the-agent.md` § "Workflow Files" | Direct adaptation |
| Resume interrupted work | `working-with-the-agent.md` § "Resuming Interrupted Work" | Adapted |
| Multi-session workflows | `working-with-the-agent.md` § "Multi-Session Workflows" | Adapted |
| Ask for help table | `working-with-the-agent.md` § "Asking for Help" | Direct adaptation |
| Effective communication | `working-with-the-agent.md` § "Effective Communication Patterns" | Adapted |
| Quick reference table | `working-with-the-agent.md` § "Quick Reference" | Direct adaptation |

**Key claims to verify:**

1. **Agent checks for existing work on conversation start** — Source confirms. Published article matches.

2. **scenario-instructions.md 4-section structure** — Source lists: User Preferences—Technical, User Preferences—Execution Style, Key Decisions Log, Custom Instructions per Task. Published article matches.

3. **Cross-IDE support** — Source: "Start in VS Code, continue in Visual Studio or Copilot CLI." Published article matches.

4. **Stale task detection** — Source describes agent recognizing tasks stuck in 🔄 from previous session. Published article matches.

**Content omitted:**
- Detailed automatic/guided mode conversation transcript examples (condensed for readability).
- The day-by-day multi-session walkthrough (Monday morning/afternoon, Tuesday) was summarized rather than reproduced verbatim.

---

## Content not yet documented

The following content from the source material was **not** included in this update:

### From `scenario-walkthrough.md`
- Detailed five-phase walkthrough with concrete example (MvcMovieNet6)
- Example conversation between user and agent
- Multi-project solution dependency tiering example
- Decision drivers analysis
- "Applying to Other Scenarios" comparison

**Decision:** The existing `how-to-upgrade-with-github-copilot.md` already has concrete examples of the workflow. A detailed walkthrough article could complement it but was deferred.

---

## Style decisions

1. **"Phase" vs "Stage"** — The source material uses "stage" throughout. The published docs now consistently use "phase" to avoid confusion with the original "three-stage" terminology. Both terms appear in the source; "phase" was chosen because the original published docs also mixed terminology.

2. **Heading level for scenario details in scenarios-and-skills.md** — Used H3 (`###`) for individual scenario descriptions within the H2 "Scenarios" section, matching the source's structure.

3. **Mermaid diagrams omitted** — `core-concepts.md` source contains Mermaid flowcharts. These were not included in the published `concepts.md` because Microsoft Learn's Mermaid support varies. The workflow is described in prose.

4. **.NET 11 preview mention** — Source mentions ".NET 11 preview is also available as a target" in `scenario-walkthrough.md` and ".NET 11 preview planned" in `troubleshooting.md`. This was not prominently featured in the published docs because it's a preview feature and the version matrix already says "or later" which covers future versions.
