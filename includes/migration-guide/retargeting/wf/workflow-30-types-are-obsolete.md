### WorkFlow 3.0 types are obsolete

|   |   |
|---|---|
|Details|Windows Workflow Foundation (WWF) 3.0 APIs (those from the System.Workflow namespace) are now obsolete.|
|Suggestion|New WWF 4.0 APIs (in System.Activities) should be used instead. An example of using the new APIs can be found <a href="../../../../framework/windows-workflow-foundation/how-to-update-the-definition-of-a-running-workflow-instance.md">here</a> and further guidance is available <a href="http://blogs.msdn.com/b/workflowteam/archive/2012/02/08/deprecatingwf3.aspx">here</a>. Alternatively, since the WWF 3.0 APIs are still supported, they may be used and the build-time warning avoided either by suppressing it or by using an older compiler.|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
|Analyzers|<ul><li>CD0021</li></ul>|

