---
title: Leveraging serverless functions
description: Leveraging Serverless and Azure Functions in Cloud-Native Applications
ms.date: 06/30/2019
---
# Leveraging serverless functions

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

In the spectrum of managing full machines and operating systems to leveraging cloud capabilities, serverless lives at the extreme end where the only thing you're responsible for is your code, and you only pay for your code when it runs. Azure Functions provides a way to build serverless capabilities into your applications. 

## What is serverless?

Serverless computing doesn't mean there isn't a server involved in running your application - the code still runs on a server somewhere. The distinction is that the application development team no longer needs to concern themselves with managing server infrastructure. Serverless computing solutions like Azure Functions help teams increase their productivity and allow organizations to optimize their resources and focus on delivering solutions.

Serverless computing uses event-triggered stateless containers to host your application or part of your application. Serverless platforms can scale up and down to meet demand as-needed. Platforms like Azure Functions have easy direct access to other Azure services like queues, events, and storage.

## What challenges are solved by serverless?

Serverless is the ultimate abstraction away from running your own hardware. Developers can focus exclusively on writing code to solve business problems, without concern for any of the following tasks that might have been necessary when hosting your own servers:

- Purchasing machines and software licenses
- Housing, securing, configuring, and maintaining the machines and their networking, power, and A/C requirements
- Patching and upgrading operating systems and software
- Configuring web servers or machine services to host application software
- Configuring application software within its platform

Many companies employ dozens of staff members and allocate large budgets to support these hardware infrastructure concerns. Simply moving to the cloud eliminates some of these concerns; shifting applications all the way to serverless will eliminate the rest.

## What scenarios are appropriate for serverless?

Serverless uses individual short-running functions that are called in response to some trigger. This makes them ideal for processing background tasks.

For example, an application might need to send an email as part of processing a request. Instead of sending the email as part of handling the web request, the details of the email could be placed onto a queue and an Azure Function could be used to pick up the message and send the email. Many different parts of the application, or even many applications, could leverage this same Azure Function, providing improved performance and scalability for the applications and using [queue-based load leveling](https://docs.microsoft.com/azure/architecture/patterns/queue-based-load-leveling) to avoid bottlenecks related to sending the emails.

Although a [Publisher/Subscriber pattern](https://docs.microsoft.com/azure/architecture/patterns/publisher-subscriber) between applications and Azure Functions is the most common pattern, other patterns are possible. Azure Functions can be triggered by other events, such as changes to Azure Blob Storage. An application that supported image uploads could have an Azure Function responsible for creating thumbnail images, or resizing uploaded images to consistent dimensions, or optimizing image size. All of this functionality could be triggered directly by inserts to Azure Blob Storage, keeping the complexity and the workload out of the application itself.

Many applications have long-running processes as part of their workflows. Often these tasks are done as part of the user's interaction with the application, forcing the user to wait and negatively impacting their experience. Serverless computing provides a great way to perform slower tasks outside of the user interaction loop, and these tasks can easily scale with demand without requiring the entire application to scale.

## When should you avoid serverless?

Serverless computing is best-used for tasks that don't block the user interface. This means they're not ideal for hosting web applications or web APIs directly. The main reason for this is that serverless solutions are provisioned and scaled on demand. When a new instance of a function is needed, referred to as a *cold start*, it takes time to provision. This time is typically a few seconds, but can be longer depending on a variety of factors. A single instance can often be maintained indefinitely (for instance, by periodically making a request to it), but the cold start issue remains if the number of instances ever needs to scale up.

![Cold versus warm start](./media/cold-start-warm-start.png)
**Figure 3-10**. Cold start vs. warm start.

If you need to avoid cold starts entirely, you can choose to switch from a [consumption plan to a dedicated plan](https://azure.microsoft.com/blog/understanding-serverless-cold-start/). You can also [configure one or more pre-warmed instances](https://docs.microsoft.com/azure/azure-functions/functions-premium-plan#pre-warmed-instances) with the premium plan so when you need to add another instance, it's already up and ready to go. These options can mitigate one of the key concerns associated with serverless computing.

You should also typically avoid serverless for long-running tasks. They're best for small pieces of work that can be completed quickly. Most serverless platforms require individual functions to complete within a few minutes. Azure Functions defaults to a 5-minute time-out duration (can be configured up to 10 minutes). The Azure Functions premium plan can mitigate this issue as well, defaulting time outs to 30 minutes and allowing an unbounded higher limit to be configured.

Finally, leveraging serverless for certain tasks within your application adds complexity. It's often best to architect your application in a modular, loosely coupled manner first, and then identify if there are benefits serverless would offer that make the additional complexity worthwhile. Many smaller applications will run perfectly well in a single monolithic deployment, without the need for the distributed application architecture serverless computing requires.

## References

- [Understanding serverless cold start](https://azure.microsoft.com/blog/understanding-serverless-cold-start/)
- [Pre-warmed Azure Functions instances](https://docs.microsoft.com/azure/azure-functions/functions-premium-plan#pre-warmed-instances)
- [Create a function on Linux using a custom image](https://docs.microsoft.com/azure/azure-functions/functions-create-function-linux-custom-image)

>[!div class="step-by-step"]
>[Previous](leverage-containers-orchestrators.md)
>[Next](combine-containers-serverless-approaches.md)
