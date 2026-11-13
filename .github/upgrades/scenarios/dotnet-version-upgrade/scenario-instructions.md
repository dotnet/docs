# .NET Version Upgrade

## Preferences
- **Flow Mode**: Automatic
- **Target Framework**: net11.0
- **Commit Strategy**: Single Commit at End

## Source Control
- **Source Branch**: use-11-everywhere
- **Working Branch**: use-11-everywhere
- **Pending Changes**: Preserve; do not modify or commit the existing HostWithHostFxr.slnx change
- **Commit Strategy**: Single Commit at End
- **Branch Sync**: Disabled

## Build Tool Decisions
- **AppWithPlugin.csproj**: Visual Studio IDE build (SDK-style, no special requirements)
- **HelloPlugin.csproj**: Visual Studio IDE build (SDK-style, no special requirements)
- **PluginBase.csproj**: Visual Studio IDE build (SDK-style, no special requirements)

## Upgrade Options

### Strategy
- Upgrade Strategy: All-at-Once

## Strategy
**Selected**: All-at-Once
**Rationale**: The assessment found three SDK-style projects, no package or API compatibility blockers, and a shallow dependency graph.

### Execution Constraints
- Upgrade all three projects together; do not sequence work by dependency tier.
- Verify the .NET 11 SDK and global.json compatibility before editing project files.
- Update all target frameworks together, restore dependencies, then perform one bounded build-and-fix pass.
- Run tests after the atomic upgrade succeeds, then validate the full solution.
- Preserve the unrelated HostWithHostFxr.slnx change and exclude it from any commit.
