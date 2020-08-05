### Improved accessibility for some .NET SDK tools

#### Details

In the .NET Framework SDK 4.7.1, the SvcConfigEditor.exe and SvcTraceViewer.exe tools have been improved by fixing varied accessibility issues. Most of these were small issues like a name not being defined or certain UI automation patterns not being implemented correctly. While many users wouldn't be aware of these incorrect values, customers who use assistive technologies like screen readers will find these SDK tools more accessible. Certainly, these fixes change some previous behaviors, like keyboard focus order.In order to get all the accessibility fixes in these tools, you can the following to your app.config file:

```xml
<runtime>
  <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=false"/>
</runtime>
```

| Name    | Value       |
|:--------|:------------|
| Scope   | Edge        |
| Version | 4.7.1       |
| Type    | Retargeting |
