### Resizing a Grid can cause the application to become unresponsive

#### Details

An infinite loop can occur during layout of a `T:System.Windows.Controls.Grid` under the following circumstances:

- Row definitions contain two \*-rows, both declaring a MinHeight and a MaxHeight.
- Content of the \*-rows doesn't exceed the corresponding MaxHeight.
- The Grid's available height is exceeded by the first MinHeight (plus any other fixed or Auto rows).
- The app targets .NET Framework 4.7, or opts in to the 4.7 allocation algorithm by setting `Switch.System.Windows.Controls.Grid.StarDefinitionsCanExceedAvailableSpace=false`.

The loop would also happen with more than two rows, or in the analogous case for columns. The issue is fixed in .NET Framework 4.7.1.

#### Suggestion

Upgrade to .NET Framework 4.7.1. Alternatively, if you don't need the 4.7 allocation algorithm you can use the following configuration setting:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.System.Windows.Controls.Grid.StarDefinitionsCanExceedAvailableSpace=true" />
</runtime>
```

| Name    | Value   |
| :------ | :------ |
| Scope   | Edge    |
| Version | 4.7     |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
