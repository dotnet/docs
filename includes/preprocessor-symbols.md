---
ms.custom: "updateeachrelease"
---
| Target Frameworks | Symbols | Additional symbols<br/>(available in .NET 5+ SDKs) | Platform symbols (available only<br/>when you specify an OS-specific TFM) |
| ------------------| ------- | ------------------------------------------------ | -------------------------------------------------------------------- |
| .NET Framework    | `NETFRAMEWORK`, `NET481`, `NET48`, `NET472`, `NET471`, `NET47`, `NET462`, `NET461`, `NET46`, `NET452`, `NET451`, `NET45`, `NET40`, `NET35`, `NET20` | `NET48_OR_GREATER`, `NET472_OR_GREATER`, `NET471_OR_GREATER`, `NET47_OR_GREATER`, `NET462_OR_GREATER`, `NET461_OR_GREATER`, `NET46_OR_GREATER`, `NET452_OR_GREATER`, `NET451_OR_GREATER`, `NET45_OR_GREATER`, `NET40_OR_GREATER`, `NET35_OR_GREATER`, `NET20_OR_GREATER` | |
| .NET Standard     | `NETSTANDARD`, `NETSTANDARD2_1`, `NETSTANDARD2_0`, `NETSTANDARD1_6`, `NETSTANDARD1_5`, `NETSTANDARD1_4`, `NETSTANDARD1_3`, `NETSTANDARD1_2`, `NETSTANDARD1_1`, `NETSTANDARD1_0` | `NETSTANDARD2_1_OR_GREATER`, `NETSTANDARD2_0_OR_GREATER`, `NETSTANDARD1_6_OR_GREATER`, `NETSTANDARD1_5_OR_GREATER`, `NETSTANDARD1_4_OR_GREATER`, `NETSTANDARD1_3_OR_GREATER`, `NETSTANDARD1_2_OR_GREATER`, `NETSTANDARD1_1_OR_GREATER`, `NETSTANDARD1_0_OR_GREATER` | |
| .NET 5+ (and .NET Core) | `NET`, `NET9_0`, `NET8_0`, `NET7_0`, `NET6_0`, `NET5_0`, `NETCOREAPP`, `NETCOREAPP3_1`, `NETCOREAPP3_0`, `NETCOREAPP2_2`, `NETCOREAPP2_1`, `NETCOREAPP2_0`, `NETCOREAPP1_1`, `NETCOREAPP1_0` | `NET9_0_OR_GREATER`, `NET8_0_OR_GREATER`, `NET7_0_OR_GREATER`, `NET6_0_OR_GREATER`, `NET5_0_OR_GREATER`, `NETCOREAPP3_1_OR_GREATER`, `NETCOREAPP3_0_OR_GREATER`, `NETCOREAPP2_2_OR_GREATER`, `NETCOREAPP2_1_OR_GREATER`, `NETCOREAPP2_0_OR_GREATER`, `NETCOREAPP1_1_OR_GREATER`, `NETCOREAPP1_0_OR_GREATER` | `ANDROID`, `BROWSER`, `IOS`, `MACCATALYST`, `MACOS`, `TVOS`, `WINDOWS`,<br/>`[OS][version]` (for example `IOS15_1`),<br/>`[OS][version]_OR_GREATER` (for example `IOS15_1_OR_GREATER`) |

> [!NOTE]
>
> * Versionless symbols are defined regardless of the version you're targeting.
> * Version-specific symbols are only defined for the version you're targeting.
> * The `<framework>_OR_GREATER` symbols are defined for the version you're targeting and all earlier versions. For example, if you're targeting .NET Framework 2.0, the following symbols are defined: `NET20`, `NET20_OR_GREATER`, `NET11_OR_GREATER`, and `NET10_OR_GREATER`.
> * The `NETSTANDARD<x>_<y>_OR_GREATER` symbols are only defined for .NET Standard targets, and not for targets that implement .NET Standard, such as .NET Core and .NET Framework.
> * These are different from the target framework monikers (TFMs) used by [the MSBuild `TargetFramework` property](../docs/standard/frameworks.md#supported-target-frameworks) and [NuGet](/nuget/reference/target-frameworks).
