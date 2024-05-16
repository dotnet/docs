### Accessibility improvements in Windows Workflow Foundation (WF) workflow designer

#### Details

The Windows Workflow Foundation (WF) workflow designer is improving how it works with accessibility technologies. These improvements include the following changes:

- The tab order is changed to left to right and top to bottom in some controls:
- The initialize correlation window for setting correlation data for the <xref:System.ServiceModel.Activities.InitializeCorrelation> activity
- The content definition window for the <xref:System.ServiceModel.Activities.Receive>, <xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.SendReply>, and <xref:System.ServiceModel.Activities.ReceiveReply> activities
- More functions are available via the keyboard:
- When editing the properties of an activity, property groups can be collapsed by keyboard the first time they are focused.
- Warning icons are now accessible by keyboard.
- The More Properties button in the Properties window is now accessible by keyboard.
- Keyboard users now can access the header items in the Arguments and Variables panes of the Workflow Designer.
- Improved visibility of items with focus, such as when:
- Adding rows to data grids used by the Workflow Designer and activity designers.
- Tabbing through fields in the <xref:System.ServiceModel.Activities.ReceiveReply> and <xref:System.ServiceModel.Activities.SendReply> activities.
- Setting default values for variables or arguments
- Screen readers can now correctly recognize:
- Breakpoints set in the workflow designer.
- The <xref:System.Activities.Statements.FlowSwitch%601>, <xref:System.Activities.Statements.FlowDecision>, and <xref:System.ServiceModel.Activities.CorrelationScope> activities.
- The contents of the <xref:System.ServiceModel.Activities.Receive> activity.
- The Target Type for the <xref:System.Activities.Statements.InvokeMethod> activity.
- The Exception combobox and the Finally section in the <xref:System.Activities.Statements.TryCatch> activity.
- The Message Type combobox, the splitter in the Add Correlation Initializers window, the Content Definition window, and the CorrelatesOn Defintion window in the messaging activities (<xref:System.ServiceModel.Activities.Receive>, <xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.SendReply>, and <xref:System.ServiceModel.Activities.ReceiveReply>).
- State machine transitions and transitions destinations.
- Annotations and connectors on <xref:System.Activities.Statements.FlowDecision> activities.
- The context (right-click) menus for activities.
- The property value editors, the Clear Search button, the By Category and Alphabetical sort buttons, and the Expression Editor dialog in the properties grid.
- The zoom percentage in the Workflow Designer.
- The separator in <xref:System.Activities.Statements.Parallel> and <xref:System.Activities.Statements.Pick> activities.
- The <xref:System.Activities.Statements.InvokeDelegate> activity.
- The Select Types window for dictionary activities (`Microsoft.Activities.AddToDictionary<TKey,TValue>`, `Microsoft.Activities.RemoveFromDictionary<TKey,TValue>`, etc.).
- The Browse and Select .NET Type window.
- Breadcrumbs in the Workflow Designer.
- Users who choose High Contrast themes will see many improvements in the visibility of the Workflow Designer and its controls like better contrast ratios between elements and more noticeable selection boxes used for focus elements.

#### Suggestion

If you have an application with a re-hosted workflow designer, your application can benefit from these changes by performing either of these actions:

- Recompile your application to target the .NET Framework 4.7.1. These accessibility changes are enabled by default.
- If your application targets the .NET Framework 4.7 or earlier but is running on the .NET Framework 4.7.1, you can opt out of these legacy accessibility behaviors by adding the following [AppContext switch](~/docs/framework/configure-apps/file-schema/runtime/appcontextswitchoverrides-element.md) to the `<runtime>` section of the app.config file and set it to `false`, as the following example shows.

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7"/>
  </startup>
  <runtime>
    <!-- AppContextSwitchOverrides value attribute is in the form of 'key1=true/false;key2=true/false  -->
    <AppContextSwitchOverrides value="Switch.UseLegacyAccessibilityFeatures=false" />
  </runtime>
</configuration>
```

Applications that target the .NET Framework 4.7.1 or later and want to preserve the legacy accessibility behavior can opt in to the use of legacy accessibility features by explicitly setting this AppContext switch to `true`.

| Name    | Value       |
|:--------|:------------|
| Scope   | Minor       |
| Version | 4.7.1       |
| Type    | Retargeting |
