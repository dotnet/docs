# 02-net11-projects: Retarget the plugin-support solution

Update `AppWithPlugin.csproj`, `HelloPlugin.csproj`, and `PluginBase.csproj` together to target `net11.0`, preserving the existing project references and dynamic-loading configuration. Update the solution's Visual Studio version metadata to the installed Visual Studio 2026 release. The C# projects will use the language version supplied by the .NET 11 SDK; no C++ project or C++ language/toolset setting exists in this solution.

## Scope Inventory

- **Projects affected**: `AppWithPlugin` (executable, references `PluginBase`), `HelloPlugin` (dynamically loaded plugin, references `PluginBase`), and `PluginBase` (shared library).
- **Distinct concerns**: Replace each project's existing single `TargetFramework` value with `net11.0`; update the solution metadata from Visual Studio 15 to the installed Visual Studio 2026 version.
- **Assessment signals**: Each project is SDK-style and has one mandatory `Project.0002` target-framework issue. All 158 analyzed APIs are compatible, with no package dependencies or API migration issues. Test coverage is not recommended by the assessment.
- **Property locations**: All three `TargetFramework` elements are directly in their project files. Dependency inspection found no imported local MSBuild targets or centralized target-framework props. The project references and `EnableDynamicLoading` configuration are project-specific and must remain unchanged.
- **Skill matches**: `managing-target-frameworks`, `modifying-project-properties`, and `building-projects`.

**Done when**: All three projects target `net11.0`, the solution metadata identifies Visual Studio 2026, and the existing plugin project references and dynamic-loading settings remain intact.
