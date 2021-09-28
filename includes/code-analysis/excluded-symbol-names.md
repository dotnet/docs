### Exclude specific symbols

You can exclude specific symbols, such as types and methods, from analysis. For example, to specify that the rule should not run on any code within types named `MyType`, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.excluded_symbol_names = MyType
```

Allowed symbol name formats in the option value (separated by `|`):

- Symbol name only (includes all symbols with the name, regardless of the containing type or namespace).
- Fully qualified names in the symbol's [documentation ID format](../../docs/csharp/language-reference/xmldoc/index.md#id-strings). Each symbol name requires a symbol-kind prefix, such as `M:` for methods, `T:` for types, and `N:` for namespaces.
- `.ctor` for constructors and `.cctor` for static constructors.

Examples:

| Option Value | Summary |
| --- | --- |
|`dotnet_code_quality.CAXXXX.excluded_symbol_names = MyType` | Matches all symbols named `MyType`. |
|`dotnet_code_quality.CAXXXX.excluded_symbol_names = MyType1|MyType2` | Matches all symbols named either `MyType1` or `MyType2`. |
|`dotnet_code_quality.CAXXXX.excluded_symbol_names = M:NS.MyType.MyMethod(ParamType)` | Matches specific method `MyMethod` with the specified fully qualified signature. |
|`dotnet_code_quality.CAXXXX.excluded_symbol_names = M:NS1.MyType1.MyMethod1(ParamType)|M:NS2.MyType2.MyMethod2(ParamType)` | Matches specific methods `MyMethod1` and `MyMethod2` with the respective fully qualified signatures. |
