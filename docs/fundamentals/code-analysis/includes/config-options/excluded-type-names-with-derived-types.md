### Exclude specific types and their derived types

You can exclude specific types and their derived types from analysis by setting the [excluded_type_names_with_derived_types](../../code-quality-rule-options.md#excluded_type_names_with_derived_types) option. For example, to specify that the rule should not run on any methods within types named `MyType` and their derived types, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.excluded_type_names_with_derived_types = MyType
```

> [!NOTE]
> Replace the `XXXX` part of `CAXXXX` with the ID of the applicable rule.

Allowed symbol name formats in the option value (separated by `|`):

- Type name only (includes all types with the name, regardless of the containing type or namespace).
- Fully qualified names in the symbol's [documentation ID format](../../../../csharp/language-reference/xmldoc/index.md#id-strings), with an optional `T:` prefix.

Examples:

<!-- markdownlint-disable MD056 -->
| Option value | Summary |
| --- | --- |
|`dotnet_code_quality.CAXXXX.excluded_type_names_with_derived_types = MyType` | Matches all types named `MyType` and all of their derived types. |
|`dotnet_code_quality.CAXXXX.excluded_type_names_with_derived_types = MyType1|MyType2` | Matches all types named either `MyType1` or `MyType2` and all of their derived types. |
|`dotnet_code_quality.CAXXXX.excluded_type_names_with_derived_types = M:NS.MyType` | Matches specific type `MyType` with given fully qualified name and all of its derived types. |
|`dotnet_code_quality.CAXXXX.excluded_type_names_with_derived_types = M:NS1.MyType1|M:NS2.MyType2` | Matches specific types `MyType1` and `MyType2` with the respective fully qualified names, and all of their derived types. |
<!-- markdownlint-enable MD056 -->
