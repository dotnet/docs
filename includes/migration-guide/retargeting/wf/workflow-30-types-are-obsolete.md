### WorkFlow 3.0 types are obsolete

#### Details

Windows Workflow Foundation (WWF) 3.0 APIs (those from the System.Workflow namespace) are now obsolete.

#### Suggestion

New WWF 4.0 APIs (in System.Activities) should be used instead. For an example of using the new APIs, see [How to: Update the definition of a running workflow instance](~/docs/framework/windows-workflow-foundation/how-to-update-the-definition-of-a-running-workflow-instance.md). Further guidance is available at [WF3 Types Marked Obsolete in .NET 4.5](/archive/blogs/workflowteam/wf3-types-marked-obsolete-in-net-4-5). Alternatively, since the WWF 3.0 APIs are still supported, they can be used, and you can avoid the build-time warning by suppressing it or by using an older compiler.

| Name    | Value       |
|:--------|:------------|
| Scope   | Major       |
| Version | 4.5         |
| Type    | Retargeting |
