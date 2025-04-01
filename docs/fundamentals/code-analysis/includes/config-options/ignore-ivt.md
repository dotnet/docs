### Ignore InternalsVisibleTo attribute

By default, this rule is disabled if the assembly being analyzed uses <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> to expose its internal symbols. You can set the [ignore_internalsvisibleto](../../code-quality-rule-options.md#ignore_internalsvisibleto) option to change the configuration. To specify that the rule should run even if the assembly is marked with <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.ignore_internalsvisibleto = true
```

> [!NOTE]
> Replace the `XXXX` part of `CAXXXX` with the ID of the applicable rule.

This option is available starting in .NET 8.
