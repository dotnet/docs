# .NET Version Upgrade Plan

## Overview

**Target**: .NET 11 (`net11.0`) and the installed Visual Studio 2026 release.
**Scope**: Three SDK-style C# projects and the solution file; the solution contains no C++ projects, so no C++ language standard or MSVC toolset can be retargeted.

### Selected Strategy
**All-at-Once** — All projects upgraded simultaneously in a single operation.
**Rationale**: Three projects have a shallow dependency graph, and the assessment found no package or API compatibility blockers.

## Upgrade Options

| Option | Selected | Why |
|--------|----------|-----|
| Upgrade Strategy | All-at-Once | The assessment found three SDK-style projects, no package or API compatibility blockers, and a shallow dependency graph. |

## Tasks

### 01-prerequisites: Verify .NET 11 and Visual Studio prerequisites

Confirm the installed .NET 11 SDK, Visual Studio 2026 version, and any applicable SDK selection file before changing the solution. The SDK and Visual Studio 2026 are present in the environment; verify that no `global.json` pin prevents this solution from using them.

**Done when**: The solution can resolve the installed .NET 11 SDK, and applicable SDK configuration does not block the target framework.

### 02-net11-projects: Retarget the plugin-support solution

Update `AppWithPlugin.csproj`, `HelloPlugin.csproj`, and `PluginBase.csproj` together to target `net11.0`, preserving the existing project references and dynamic-loading configuration. Update the solution's Visual Studio version metadata to the installed Visual Studio 2026 release. The C# projects will use the language version supplied by the .NET 11 SDK; no C++ project or C++ language/toolset setting exists in this solution.

**Done when**: All three projects target `net11.0`, the solution metadata identifies Visual Studio 2026, and the existing plugin project references and dynamic-loading settings remain intact.

### 03-solution-validation: Validate the upgraded solution

Restore and build the complete solution, then run any tests discovered for its projects. Check the sample's plugin-host behavior where the project structure supports a direct run, and report any validation step that the solution does not provide.

**Done when**: The full solution builds without warnings or errors, all discovered tests pass (or no test projects are present), and the plugin sample's supported runtime check succeeds.
