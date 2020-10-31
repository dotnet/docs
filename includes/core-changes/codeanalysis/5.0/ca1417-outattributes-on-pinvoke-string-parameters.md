### CA1417: OutAttribute on string parameter for P/Invoke

.NET code analyzer rule [CA1417](/visualstudio/code-quality/ca1417) is enabled, by default, starting in .NET 5.0. It produces a build warning for any [Platform Invoke (P/Invoke)](../../../../docs/standard/native-interop/pinvoke.md) method definitions where a <xref:System.String> parameter is passed by value and marked with <xref:System.Runtime.InteropServices.OutAttribute>.

#### Change description

Starting in .NET 5.0, the .NET SDK includes [.NET source code analyzers](../../../../docs/fundamentals/productivity/code-analysis.md). Several of these rules are enabled, by default, including [CA1417](/visualstudio/code-quality/ca1417). If your project contains code that violates this rule and is configured to treat warnings as errors, this change could break your build.

Rule CA1417 flags [P/Invoke](../../../../docs/standard/native-interop/pinvoke.md) method definitions where a <xref:System.String> parameter is marked with the <xref:System.Runtime.InteropServices.OutAttribute> attribute and is passed by value. For example:

```csharp
[DllImport("MyLibrary")]
private static extern void PIMethod([Out] string s);
```

The .NET runtime maintains a table, called the intern pool, that contains a single reference to each unique literal string in a program. If an interned string marked with <xref:System.Runtime.InteropServices.OutAttribute> is passed by value to a P/Invoke method, the runtime can be destabilized. For more information about string interning, see the remarks for <xref:System.String.Intern(System.String)?displayProperty=nameWithType>.

#### Version introduced

5.0 Preview 8

#### Recommended action

- If you need to marshal modified string data back to the caller, pass the string by reference instead.

  ```csharp
  [DllImport("MyLibrary")]
  private static extern void PIMethod(out string s);
  ```

- If you don't need to marshal modified string data back to the caller, simply remove the <xref:System.Runtime.InteropServices.OutAttribute>.

  ```csharp
  [DllImport("MyLibrary")]
  private static extern void PIMethod(string s);
  ```

  For more information, see [CA1417](/visualstudio/code-quality/ca1417).

- To disable code analysis completely, set `EnableNETAnalyzers` to `false` in your project file. For more information, see [EnableNETAnalyzers](../../../../docs/core/project-sdk/msbuild-props.md#enablenetanalyzers).

#### Category

Code analysis

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
