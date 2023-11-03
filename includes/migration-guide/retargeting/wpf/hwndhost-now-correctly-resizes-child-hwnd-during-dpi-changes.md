### HwndHost now correctly resizes child-HWND during DPI changes

#### Details

In .NET Framework 4.7.2 and earlier versions, when WPF was run in Per-Monitor Aware mode, controls hosted within <xref:System.Windows.Interop.HwndHost> were not sized correctly after DPI changes, such as when moving applications from one monitor to another. This fix ensures that hosted controls are sized appropriately.

#### Suggestion

In order for the application to benefit from these changes, it must run on the .NET Framework 4.7.2 or later, and it must opt-in to this behavior by setting the following [AppContext Switch](../../../../docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) in the `<runtime>` section of the app config file to `false`, as the following example shows.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
<startup>
<supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7"/>
</startup>
<runtime>
<!-- AppContextSwitchOverrides value attribute is in the form of &#39;key1=true/false;key2=true/false  -->
<AppContextSwitchOverrides value="Switch.System.Windows.DoNotUsePresentationDpiCapabilityTier2OrGreater=false" />
</runtime>
</configuration>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Major       |
| Version | 4.8         |
| Type    | Retargeting |
