# Projects Relationship Graph

[← Back to the assessment index](../assessment.md)

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;AppWithPlugin.csproj</b><br/><small>net5</small>"]
    P2["<b>📦&nbsp;PluginBase.csproj</b><br/><small>net5</small>"]
    P3["<b>📦&nbsp;HelloPlugin.csproj</b><br/><small>net5</small>"]
    P1 --> P2
    P3 --> P2
    click P1 "projects/AppWithPlugin.md"
    click P2 "projects/PluginBase.md"
    click P3 "projects/HelloPlugin.md"

```

