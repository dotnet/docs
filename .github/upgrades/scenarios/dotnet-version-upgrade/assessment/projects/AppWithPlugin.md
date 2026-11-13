# AppWithPlugin\AppWithPlugin.csproj

[← Back to the assessment index](../../assessment.md)

## Project Info

- **Current Target Framework:** net5
- **Proposed Target Framework:** net11.0
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 2
- **Number of Files with Incidents**: 1
- **Lines of Code**: 148
- **Estimated LOC to modify**: 0+ (at least 0.0% of the project)

## Related Projects

**Depends on (1)** — projects this one references:

- [C:\Users\wiwagn\GitHub\fork\docs\samples\snippets\core\tutorials\creating-app-with-plugin-support\csharp\PluginBase\PluginBase.csproj](../projects/PluginBase.md)

## Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["AppWithPlugin.csproj"]
        MAIN["<b>📦&nbsp;AppWithPlugin.csproj</b><br/><small>net5</small>"]
        click MAIN "../projects/AppWithPlugin.md"
    end
    subgraph downstream["Dependencies (1)"]
        P2["<b>📦&nbsp;PluginBase.csproj</b><br/><small>net5</small>"]
        click P2 "../projects/PluginBase.md"
    end
    MAIN --> P2

```

## API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 145 |  |
| ***Total APIs Analyzed*** | ***145*** |  |

