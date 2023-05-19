### Ignore InternalsVisibleTo attribute

By default, this rule is disabled if the assembly being analyzed uses <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute> to expose its internal symbols. To specify that the rule should run even if the assembly is marked with <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>, add the following key-value pair to an *.editorconfig* file in your project:

```ini
dotnet_code_quality.CAXXXX.ignore_internalsvisibleto = false
```
