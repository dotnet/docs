---
description: "Learn more about: Get WorkflowInstanceId"
title: "Get WorkflowInstanceId sample"
ms.date: "03/30/2017"
ms.assetid: bd7eea3b-1c28-4b84-9a67-003bc553aa81
---
# Get WorkflowInstanceId

The [GetWorkflowInstanceId sample](https://github.com/dotnet/samples/tree/main/framework/windows-workflow-foundation/scenario/ActivityLibrary/GetWorkflowInstanceId/CS) demonstrates how to use the custom activity, `GetWorkflowInstanceId` to return the workflow instance ID.

## Demonstrates

 Custom activity development, how to access the workflow instance.

## Discussion

 Getting the instance ID of a running workflow requires writing code. If you want to write a fully-declarative workflow, then you need an activity that can return the workflow instance ID so that the activity can be referenced in the workflow to provide a fully-declarative workflow authoring experience. Many scenarios require access to the instance ID: a few examples are for logging or auditing purposes or for doing application-level correlation by providing the instance ID back to a client for future association (for example, by using this activity inside a SendReply activity).

 `GetWorkflowInstanceId` is implemented as a <xref:System.Activities.CodeActivity%601> because it must return a value of type <xref:System.Guid>, and it must have access to the <xref:System.Activities.CodeActivityContext> for getting the workflow's instance ID. Its implementation is fairly basic.

```csharp
public sealed class GetWorkflowInstanceId : CodeActivity<Guid>
{
    protected override Guid Execute(CodeActivityContext context)
    {
        return context.WorkflowInstanceId;
    }
}
```
