---
ms.topic: include
ai-usage: ai-assisted
---

### SubsystemVersion defaults to 6.00 for .NET Framework 4.5 Windows Forms apps

#### Details

When you build with MSBuild, the default `SubsystemVersion` changes from `4.00` to `6.00` for Windows Forms apps that you retarget to .NET Framework 4.5. Windows uses the subsystem version when it reports some window metrics. As a result, code that calculates window or form sizes from <xref:System.Windows.Forms.SystemInformation?displayProperty=nameWithType> values, such as <xref:System.Windows.Forms.SystemInformation.FixedFrameBorderSize?displayProperty=nameWithType>, might produce different layout results than it did on .NET Framework 4.

#### Suggestion

If you must preserve the .NET Framework 4 sizing behavior, set `SubsystemVersion` to `4.00` in your project file:

```xml
<PropertyGroup>
  <SubsystemVersion>4.00</SubsystemVersion>
</PropertyGroup>
```

You can also use the [**SubsystemVersion** compiler option for C#](/dotnet/csharp/language-reference/compiler-options/advanced#subsystemversion) or the [**-subsystemversion** compiler option for Visual Basic](/dotnet/visual-basic/reference/command-line-compiler/subsystemversion).

Review code that sizes or positions Windows Forms UI with <xref:System.Windows.Forms.SystemInformation?displayProperty=nameWithType> values or other `GetSystemMetrics`-based values.

| Name    | Value       |
| ------- | ----------- |
| Scope   | Edge        |
| Version | 4.5         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Windows.Forms.SystemInformation?displayProperty=nameWithType>
- <xref:System.Windows.Forms.SystemInformation.FixedFrameBorderSize?displayProperty=nameWithType>
