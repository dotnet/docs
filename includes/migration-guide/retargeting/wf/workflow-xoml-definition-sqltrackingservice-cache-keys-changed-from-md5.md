### Workflow XOML definition and SqlTrackingService cache keys changed from MD5 to SHA256

#### Details

The Workflow Runtime in keeps a cache of workflow definitions defined in XOML. The SqlTrackingService also keeps a cache that is keyed by strings. These caches are keyed by values that include checksum hash value. In the .NET Framework 4.7.2 and earlier versions, this checksum hashing used the MD5 algorithm, which caused issues on FIPS-enabled systems. Starting with the .NET Framework 4.8, the algorithm used is SHA256.There shouldn't be a compatibility issue with this change because the values are recalculated each time the Workflow Runtime and SqlTrackingService is started. However, we have provided quirks to allow customers to revert back to usage of the legacy hashing algorithm, if necessary.

#### Suggestion

If this change presents a problem when executing workflows, try setting one or both of the `AppContext` switches:

- &quot;Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey&quot; to true.
- &quot;Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKey&quot; to true.
In code:

```csharp
System.AppContext.SetSwitch(=Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey=, true);
System.AppContext.SetSwitch(=Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKey=, true);
```

Or in the configuration file (this needs to be in the config file for the application that is creating the <xref:System.Workflow.Runtime.WorkflowRuntime> object):

```xml
<configuration>
<runtime>
<AppContextSwitchOverrides value==Switch.System.Workflow.Runtime.UseLegacyHashForWorkflowDefinitionDispenserCacheKey=true= />
<AppContextSwitchOverrides value==Switch.System.Workflow.Runtime.UseLegacyHashForSqlTrackingCacheKeytrue= />
</runtime>
</configuration>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.8         |
| Type    | Retargeting |
