---
description: "Learn more about: Add a Service Reference in a Workflow Solution"
title: "Adding a Service Reference in a Workflow Solution"
ms.date: "03/30/2017"
ms.assetid: 83574cf3-9803-49bc-837f-432936dc9c76
ms.topic: concept-article
---
# Add a Service Reference in a Workflow Solution

Adding a service reference in a workflow application works a little differently than a regular WCF application. When you select **Add** > **Service Reference** and specify the URL to the service, the metadata is downloaded and custom activities are generated that allow you to call that WCF service or WCF workflow service. After adding a service reference, rebuild the solution so the generated activities are built. They will then appear in the workflow designer toolbox. This will only work if you are adding a service reference within a workflow solution. The following web cast shows how to add a service reference in other types of projects: [Calling a WCF Service from a Workflow in a Web Project](/archive/blogs/endpoint/how-to-consume-a-wcf-service-from-a-wf4-workflow).

Adding two or more service references to services that contain the same operation name will cause a problem. The generated activities will call only the first service operation. To work around this issue, rename the service operations so they are different, or change the endpoint configuration name within each generated activity.

## See also

- [Workflow Services](workflow-services.md)
- [Calling a WCF Service from a Workflow in a Web Project](/archive/blogs/endpoint/how-to-consume-a-wcf-service-from-a-wf4-workflow)
