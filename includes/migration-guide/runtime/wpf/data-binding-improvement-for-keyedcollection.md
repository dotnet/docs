### Data Binding improvement for KeyedCollection

#### Details

Fixed <xref:System.Windows.Data.Binding> incorrect use of IList indexer when the source object declares a custom indexer with the same signature (for example, `KeyedCollection<int,TItem>`).

#### Suggestion

In order for an application that targets an older version to benefit from this change, it must run on the .NET Framework 4.8 or later, and it must opt in to the change by adding the following [AppContext switch](../../../../docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) to the `<runtime>` section of the app config file and setting it to `false`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
<startup>
<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7"/>
</startup>
<runtime>
<!-- AppContextSwitchOverrides value attribute is in the form of key1=true/false;key2=true/false  -->
<AppContextSwitchOverrides value="Switch.System.Windows.Data.Binding.IListIndexerHidesCustomIndexer=false" />
</runtime>
</configuration>
```

| Name    | Value   |
| :------ | :------ |
| Scope   | Major   |
| Version | 4.8     |
| Type    | Runtime |

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
