### CA2013: Do not use ReferenceEquals with value types

.NET code analyzer rule [CA2013](/visualstudio/code-quality/ca2013) is enabled, by default, starting in .NET 5.0. It produces a build warning for any code where <xref:System.Object.ReferenceEquals(System.Object,System.Object)> is used to compare one or more value types for equality.

#### Change description

Starting in .NET 5.0, the .NET SDK includes [.NET source code analyzers](../../../../docs/fundamentals/productivity/code-analysis.md). Several of these rules are enabled, by default, including [CA2013](/visualstudio/code-quality/ca2013). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA2013 finds instances where <xref:System.Object.ReferenceEquals(System.Object,System.Object)> is used to compare one or more value types for equality. Comparing value types for equality in this way can lead to incorrect results, because the values are boxed before they're compared. <xref:System.Object.ReferenceEquals(System.Object,System.Object)> will return `false` even if the compared values represent the same instance of a value type.

#### Version introduced

5.0 Preview 8

#### Recommended action

- Change the code to use an appropriate equality operator, such as `==`. You should not suppress this warning.

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../../docs/core/project-sdk/msbuild-props.md#enablenetanalyzers).

#### Category

Code analysis

#### Affected APIs

- <xref:System.Object.ReferenceEquals(System.Object,System.Object)?displayProperty=fullName>

<!--

#### Affected APIs

- `M:System.Object.ReferenceEquals(System.Object,System.Object)`

-->
