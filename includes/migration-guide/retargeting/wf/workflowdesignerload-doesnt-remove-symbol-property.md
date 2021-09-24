### WorkflowDesigner.Load doesn't remove symbol property

#### Details

When targeting the .NET Framework 4.5 in the workflow designer, and loading a re-hosted 3.5 workflow with the <xref:System.Activities.Presentation.WorkflowDesigner.Load> method, a <xref:System.Xaml.XamlDuplicateMemberException?displayProperty=fullName> is thrown while saving the workflow.

#### Suggestion

This bug only manifests when targeting .NET Framework 4.5 in the workflow designer, so it can be worked around by setting the `WorkflowDesigner.Context.Services.GetService<DesignerConfigurationService>().TargetFrameworkName` to the 4.0 .NET Framework.

Alternatively, the issue may be avoided by using the <xref:System.Activities.Presentation.WorkflowDesigner.Load(System.String)> method to load the workflow, instead of <xref:System.Activities.Presentation.WorkflowDesigner.Load>.

| Name    | Value       |
|:--------|:------------|
| Scope   | Major       |
| Version | 4.5         |
| Type    | Retargeting |

#### Affected APIs

- <xref:System.Activities.Presentation.WorkflowDesigner.Load?displayProperty=nameWithType>
