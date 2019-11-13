---

---
# Run-time configuration options for compilation

## Tiered compilation

- Configures whether the JIT compiler uses [tiered compilation](../whats-new/dotnet-core-3-0.md#tiered-compilation).
- In .NET Core 3.0 and later, tiered compilation is enabled by default.
- In .NET Core 2.1 and 2.2, tiered compilation is disabled by default.

| runtimeconfig.json | Values | Environment variable | Values |
| - | - | - | - |
| "System.Runtime.TieredCompilation" | `true` - enabled<br/><br/>`false` - disabled | `COMPlus_TieredCompilation` | 1 - enabled<br/><br/>0 - disabled |
