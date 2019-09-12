### WorkFlow 3.0 types are obsolete

|   |   |
|---|---|
|Details|Windows Workflow Foundation (WWF) 3.0 APIs (those from the System.Workflow namespace) are now obsolete.|
|Suggestion|New WWF 4.0 APIs (in System.Activities) should be used instead. An example of using the new APIs can be found [here](~/docs/framework/windows-workflow-foundation/how-to-update-the-definition-of-a-running-workflow-instance.md) and further guidance is available [here](https://blogs.msdn.microsoft.com/workflowteam/2012/02/08/wf3-types-marked-obsolete-in-net-4-5/). Alternatively, since the WWF 3.0 APIs are still supported, they may be used and the build-time warning avoided either by suppressing it or by using an older compiler.|
|Scope|Major|
|Version|4.5|
|Type|Retargeting|
