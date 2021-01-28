## Suppress a warning

To suppress a rule violation, set the severity option for the specific rule ID to `none` in an EditorConfig file. For example:

```ini
[*.{cs,vb}]
dotnet_diagnostic.CA1822.severity = none
```

Be sure to change `CA1822` in the example to the specific rule ID you want to suppress.

Visual Studio provides additional ways to suppress warnings from code analysis rules. For more information, see [Suppress violations](/visualstudio/code-quality/use-roslyn-analyzers#suppress-violations).

For more information about rule severities, see [Configure rule severity](~/docs/fundamentals/code-analysis/configuration-options.md#severity-level).
