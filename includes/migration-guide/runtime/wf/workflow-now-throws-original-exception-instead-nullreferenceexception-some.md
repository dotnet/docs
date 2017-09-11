### Workflow now throws original exception instead of NullReferenceException in some cases

|   |   |
|---|---|
|Details|In the .NET Framework 4.6.2 and earlier versions, when the Execute method of a workflow activity throws an exception with a <code>null</code> value for the <xref:System.Exception.Message> property, the System.Activities Workflow runtime throws a <xref:System.NullReferenceException?displayProperty=name>, masking the original exception.In the .NET Framework 4.7, the previously masked exception is thrown.|
|Suggestion|If your code relies on handling the <xref:System.NullReferenceException?displayProperty=name>, change it to catch the exceptions that could be thrown from your custom activities.|
|Scope|Minor|
|Version|4.7|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Activities.CodeActivity.Execute(System.Activities.CodeActivityContext)?displayProperty=fullName></li><li><xref:System.Activities.AsyncCodeActivity.BeginExecute(System.Activities.AsyncCodeActivityContext%2CSystem.AsyncCallback%2CSystem.Object)?displayProperty=fullName></li><li><xref:System.Activities.AsyncCodeActivity%601.BeginExecute(System.Activities.AsyncCodeActivityContext%2CSystem.AsyncCallback%2CSystem.Object)?displayProperty=fullName></li><li><xref:System.Activities.WorkflowInvoker.Invoke?displayProperty=fullName></li></ul>|

