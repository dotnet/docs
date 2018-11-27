---
title: Azure Logic Apps - Serverless apps
description: Azure Logic Apps enable building automated scalable workflows that integrate apps and data across cloud services and on-premises systems.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 06/26/2018
---
# Azure Logic Apps

[Azure Logic Apps](https://docs.microsoft.com/azure/logic-apps) provides a serverless engine to build automated workflows to integrate apps and data between cloud services and on-premises systems. You build workflows using a visual designer. You can trigger workflows based on events or timers and leverage connectors to integration applications and facilitate business-to-business (B2B) communication. Logic Apps integrates seamlessly with Azure Functions.

![Azure Logic Apps logo](./media/logic-apps-logo.png)

Logic Apps can do more than just connect your cloud services (like functions) with cloud resources (like queues and databases). You can also orchestrate on-premises workflows with the on-premises gateway. For example, you can use the Logic App to trigger an on-premises SQL stored procedure in response to a cloud-based event or conditional logic in your workflow. Learn more about [Connecting to on-premises data sources with Azure On-premises Data Gateway](https://docs.microsoft.com/azure/analysis-services/analysis-services-gateway).

![Logic Apps architecture](./media/logic-apps-architecture.png)

Like Azure Functions, you kick off Logic App workflows with a trigger. There are many triggers for you to choose from. The following capture shows just a few of the more popular ones out of hundreds that are available.

![Logic Apps triggers](./media/logic-app-triggers.png)

Once the app is triggered, you can use the visual designer to build out steps, loops, conditions, and actions. Any data ingested in a previous step is available for you to use in subsequent steps. The following workflow loads URLs from a CosmosDB database. It finds the ones with a host of `t.co` then searches for them on Twitter. If it finds corresponding tweets, it updates the documents with the related tweets by calling a function.

![Logic App workflow](./media/logic-app-workflow.png)

The Logic Apps dashboard shows the history of running your workflows and whether each run completed successfully or not. You can navigate into any given run and inspect the data used by each step for troubleshooting. Logic Apps also provides existing templates you can edit and are well suited for complex enterprise workflows.

To learn more, see [Azure Logic Apps](https://docs.microsoft.com/azure/logic-apps).

>[!div class="step-by-step"]
>[Previous](application-insights.md)
>[Next](event-grid.md)