---
title: Defining Cloud Native
description: Architecting Cloud-Native .NET Apps for Azure | Defining Cloud Native
author: robvet
ms.date: 07/20/2019
---
# Defining Cloud Native

Stop what you’re doing and ping 10 of your colleagues. Ask them to define the term “Cloud Native.” Good chance you’ll get about eight different answers. Interestingly, six months from now, as cloud-native technologies and practices evolve, so will their definition.

Cloud native is about thinking differently on how we construct and evolve critical business systems.

Consider the [definition](https://github.com/cncf/foundation/blob/master/charter.md) from the Cloud Native Computing Foundation:

- Cloud-native technologies empower organizations to build and run scalable applications in modern, dynamic environments such as public, private, and hybrid clouds. Containers, service meshes, microservices, immutable infrastructure, and declarative APIs exemplify this approach.

- These techniques enable loosely coupled systems that are resilient, manageable, and observable. Combined with robust automation, they allow engineers to make high-impact changes frequently and predictably with minimal toil.

Applications and their underlying systems have become increasingly complex with users demanding more and more. The new expectation is instantaneous responsiveness, up-to-the-minute features, and absolutely no downtime. Performance problems, recurring errors, and the inability to move fast are no longer acceptable to your business and customers.

Among many things, cloud native is about *speed* and *agility*. Business critical systems are evolving from enablers of business capability to weapons of strategic transformation, accelerating business velocity and growth. Now, it’s imperative to get ideas to market immediately. Figure 1-1 presents three pioneers who have implemented these techniques. Think about the speed, agility, and scalability they've achieved.

![Companies using cloud native to embrace agility](media/companies-embracing-cloud-native.png)
**Figure 1-1**. Companies using cloud native to embrace agility

As you can see, eBay, Netflix and Uber expose systems that consist of hundreds of self-contained isolated microservices. This architecture enables rapid responses to market conditions by instantaneously updating specific functionality without fully deploying the entire system.

This agility derives from the architecture and infrastructure upon which the system is built and is composed of six capabilities shown in Figure 1-2.

![Capabilities of cloud-native apps](media/capabilities-of-cloud-native-apps.png)
**Figure 1-2**. Capabilities of cloud-native apps

As these capabilities are key to a cloud-native system, let’s take some time to visit each.

## Thinking in terms of the cloud…

Cloud-native systems are *all about the cloud*: designed, developed, and deployed to thrive in a cloud environment. Development teams design these systems from the ground-up in a highly dynamic, virtualized environment. They're built to exploit the platform and infrastructure capabilities of the cloud delivery model: elasticity, resilience, redundancy, orchestration, and on-demand features. 

The focus moves to *how* your create and deploy an application and less about *where*. Cloud-native apps make extensive use of Platform as a Service (PaaS) infrastructure and managed services. 

Figure 1-3 shows a spectrum of compute services available in Azure. As you move down the hierarchy, you move away from infrastructure plumbing and closer to business functionality. Cloud-native systems typically reside at these lower levels, using containers, PaaS, and serverless environments.

![Azure compute stack](media/azure-compute-stack.png)
**Figure 1-3**. Azure compute stack

Cloud-native systems typically view the underlying infrastructure as *disposable* - provisioned in minutes and resized, scaled, moved, or destroyed whenever necessary – all done through automation.

Consider the argument of [Pets vs. Cattle](https://medium.com/@Joachim8675309/devops-concepts-pets-vs-cattle-2380b5aab313). In a traditional data center, servers are treated as *Pets*. They're typically a physical machine, given a meaningful name, and cared for. You scale by adding more resources to the same machine (scaling up). If one becomes sick, it's nursed back to health. When one becomes unavailable, everyone notices.

The *Cattle* service model is different. You provision each instance as a virtual machine or container. Each virtual instance is identical and assigned an identifier such as Service-01, Service-02, and so on. When scaling, you *scale out* by creating more of them. When one become unavailable, nobody notices.

This cattle model embraces *immutable infrastructure*. Servers are not repaired or modified. If one fails or requires updating, it's destroyed and a new one is provisioned – all done via automation.

Cloud-native systems embrace the Cattle model. They continue to run as the infrastructure moves, resizes, and upgrades. Services can scale up, down, in, or out and move across nodes in the cluster with no regard to the machines upon which they're running.

As stated earlier, many companies view the cloud, and associated cloud-native systems as a competitive advantage – move fast, pivot quickly, and fail fast - while reducing operational and hardware costs.

The Azure cloud platform provides a highly elastic infrastructure with a rich set of services, including automatic scaling, self-healing, and monitoring capabilities.

## Thinking in terms of microservices…

Cloud-native systems embrace microservices, an increasingly popular architectural style for building modern services applications. Constructed as a distributed set of small, independent services that interact through a shared fabric, microservices share the following characteristics: 

- Each microservice runs in its own process and communicates with others using standard communication protocols such as HTTP/HTTPS, WebSockets, or [AMQP](https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol)

- Each microservice implements a specific business capability within a larger domain context boundary

- Each service is developed autonomously and can be deployed independently.

- Each service is self-contained. The domain logic, data, and state are encapsualted, and you select the data storage technology (SQL, NoSQL) and programming platform of choice.

### Why microservices?

Microservices provide agility. You build a system of  related, but independent services, with each having a granular and autonomous lifecycle. Each can evolve independently and deploy frequently. You don’t have to wait for a quarterly release to deploy new features or updates. Pushing out individual services on demand enables agility and rapid iteration. You can update small areas of a large complex application with less risk of disrupting the entire system.

An additional benefit is that each microservice can scale in and out independently. Instead of scaling the entire application as a single unit, you scale out specific microservices that require more processing power or network bandwidth. This kind of fine-grained scalability provides greater control of your system and helps to reduce overall costs as you scale portions of your system, not everything.

Figure 1-4 contrasts a monolithic and microservices approach.

![Monolithic deployment versus microservices](media/monolithic-deployment-vs-microservices.jpg)
**Figure 1-4.** Monolithic deployment versus microservices

While you'll find an abundance of information about microservices, an excellent reference guide is [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/dotnet/standard/microservices-architecture/), free from Microsoft.

Cloud-native systems are built as a set of independent microservices that can significantly increase agility.

## Thinking in terms of containers…

Microservices go hand in hand with software containerization. Developers package the service code, dependencies, configuration, and runtime as a single unit, called an [image](https://docs.docker.com/glossary/?term=image). Images are stored in a [container registry](https://azure.microsoft.com/services/container-registry/). Restores can reside on your laptop, in your data center, or in the public cloud. From a registry, you can *pull* the image and transform it into a running container instance on any computer (development laptop, QA, Staging, Production, etc.) that has the Docker software engine.

### Benefits of containers

Containers provide portability and guarantee consistency across environments. By encapsulating everything into a single package, you *isolate* the application and its dependencies from the underlying environment. If the container runs on a development laptop, it will run in test and in production as well. In this manner, containerized workloads dramatically reduce the expense (and risk) of pre-configuring an environment and troubleshooting environment-specific issues.

Each [container](https://docs.docker.com/glossary/?term=container) runs on a container host, most often  [Docker](https://opensource.com/resources/what-docker)). Containers share the underlying host operating system resulting in a smaller footprint than a full virtual machine (VM) instance. The smaller size increases the number of services that can run on a given VM, helping reduce overall cost.

Each microservice runs in its own container. In Figure 1-5, there are four containerized microservices running on a single virtual machine.

![Multiple containers running on a container host](media/multiple-containers-running-on-a-host.png)  
**Figure 1-5**. Multiple containers running on a container host

While they share the OS from the underlying VM, each container is isolated from one another. Both Linux and Windows containers provide a high-degree of process isolation. However, Windows containers can offer an even higher degree of isolation with its [Hyper-V Container](https://docs.microsoft.com/virtualization/windowscontainers/manage-containers/hyperv-container) option.

Another benefit of containers is scalability. Containers can rapidly scale out to handle spikes in traffic and quickly scale in when no longer needed. When running multiple instances of the same container image, you typically deploy each to a different host VM inside of a cluster. This way, if a VM were to become unavailable, requests can be routed to a container instance on an operational VM. We’ll cover availability later in this book. 

### Developing in containers

Most developers build code on their local computers. When complete, the code is tested and checked into a team repository for future use. 

However, the adoption of microservice architectures with large numbers of indpendent services make it difficult to load an entire application on a local development machine. Some development teams are now containerizing their entire development cycle, writing code locally inside Docker containers. 

 [Azure Dev Spaces](https://docs.microsoft.com/azure/dev-spaces/) enables development teams to iteratively build and test an entire microservices application running in Azure Kubernetes Service (AKS). Azure Dev Spaces is shown in Figure 1-6.

![Azure Dev Spaces](media/azure-dev-spaces-site-example.png)
**Figure 1-6**. Azure Dev Spaces

In the previous figure, Developer Susie Walker and team share a development instance of their entire application in an [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/) cluster (in blue). Using Azure Dev Spaces, Susie creates a personal development space with a local copy of the Hotel Service. She can work locally with the hotel service, but seamlessly run it against the entire system residing on the AKS cluster without having to mock or replicate dependencies. Suzie doesn't need to maintain the full code base on her local computer. Until Susie deploys the Hotel Service to the dev cluster, other team members run against the older version in the cluster. We discuss this upcoming product, Azure Dev Spaces, later in this book.

Containers offer immense benefits for packaging, deploying, and managing cloud-native applications.

## Thinking in terms of cloud-hosted backing services…

Cloud-native systems depend upon many different ancillary resources such as data stores, message brokers, monitoring, and identity services. The ancillary services are known as backing services.  Figure 1-7 shows many common backing services consumed by cloud-native systems.

![Cloud-native backing services](media/cloud-native-backing-services.png)
**Figure 1-7**. Cloud-native backing services

Your operations team could accept the responsibility for owning backing services. It wouldn’t be hard to provision a VM and install an instance of the open-source RabbitMQ message broker. While feasible, does that make sense - from a business perspective?

Chances are you’re not in the message broker business. So, why incur the cost and complexity of owning and managing this service when someone else can do it better and for less? No matter how skilled you may be, it is unlikely that you can match the reliability and performance of the fully managed [Azure Service Bus](https://azure.microsoft.com/services/service-bus/) service in Azure. The people working on the Microsoft team that own Azure Service Bus specialize in message broker technology - that’s their business. While you, instead, sell consumer items, provide medical services, or deliver packages. Do what you're good at and let others help you with the rest. Focus your effort on building outstanding customer functionality, not becoming experts in open-source backing services.

With all that said, cloud-native systems are best built using managed backing services from a cloud provider. The provider manages these resources at scale and bears the responsibility for security, scalability, and maintenance. You can also count on comprehensive monitoring, configurable redundancy, and availability – built into the service. They're battle-tested, performant, and ready to go!

Built on cloud technologies, managed backing services are more agile and flexible than traditional offerings. The inherent benefits of scalability and resiliency make them an attractive proposition for developers. And like most cloud resources, they're constantly tuned and optimized for speed, security, and performance.

Finally, managed backing services are fully supported by the cloud provider. Open a support ticket if you experience an issue and the provider fixes it. It makes little sense to distract your focus scouring the web for a blog post that mentions an error code that you’re experiencing from your open-source backing service.

Figure 1-8 shows managed services available on the Azure platform.

![Managed services in Azure](media/managed-services-in-azure.png)
**Figure 1-8**. Managed services in Azure

Understandably, you may have a concern with vendor lock-in. However, you must weigh this concern against bearing the full responsibility for hosting your own backing services. A smart approach might be to wrap each managed backing service inside of an abstraction shim, using a strategy pattern, and externalized configuration. This way your code is decoupled from the infrastructure. You can dynamically swap-out one backing service for another without a full redeployment of the system.

Throughout this book, we'll explore various types of cloud-managed backing services.

## Thinking in terms of modern system design…

How would you design a cloud-native app? What would your architecture look like? To what principles, patterns, and best practices would you adhere? So far we’ve talked about several key cloud-native patterns, including cloud compute, microservices, containers, and managed backing services. But, what about the application design process itself?

We’ll start with a widely accepted foundation for service design and then highlight some important concerns.

### The 12-Factor Foundation

A widely accepted methodology for constructing cloud-native systems is the [Twelve-Factor Application](https://12factor.net/) Design Principles. It describes rules, guidelines, and best practices for building applications that are decoupled from their underlying platform, embrace continuous deployment, and leverage-managed backing services. Many practitioners consider its principles as a foundation for building modern cloud-native apps.

Figure 1-9 shows the 12-Factor methodology at 5,000 feet – low enough to appreciate the principles, but high enough as to not get caught in the weeds.

![The 12-Factor app](media/the-twelve-factor-app.png)
**Figure 1-9.** The 12-Factor app

### Critical Design Considerations

Beyond the guidance provided in the 12-factor manifesto, there are several critical design principles you must consider.

*Communication*

How will front-end client applications communicate with your backed-end core services? Will you allow direct communication? Or, might you abstract the backend services with a gateway façade that provides  flexibility, control, and security?

Then, how will back-end core services communicate with each other? Will you allow direct HTTP calls that lead to coupling and can impact performance and agility? Or, might you consider decoupled messaging with queue and topic technologies?

*Resiliency*

A microservices architecture moves you from in-process to network communication. In this  distributed environment, what will you do when Service B isn't responding to a call from Service A? Or, what will you do when a service is temporarily unavailable, but a large number of calls from other services, trying to reach it, back up, and degrade overall network performance?

*Distributed Data*

By design, each microservice encapsulates its own data, exposing operations via its public interface. In that model, how do you query data or implement a transaction across multiple services?

*Identity*

How will your service identify who is accessing it and what permissions they have?

These topics are covered in detail throughout the chapters of this book.

## Thinking in terms of automation

*Cloud-native thinking* goes beyond microservices, containers, and modern system design. DevOps engagement is crucial. Large distributed systems require rapid provisioning, decentralized deployment, and close adherence to widely accepted DevOps processes. A mandatory requirement for cloud native is *automation* – automation of the underlying infrastructure, code deployment, and the environment.

### Automating Infrastructure

Cloud-native apps favor [Infrastructure as Code (IaC)](https://docs.microsoft.com/azure/devops/learn/what-is-infrastructure-as-code).

With IaC, you use tooling, such as [Azure Resource Manager](https://azure.microsoft.com/documentation/articles/resource-group-overview/) or [Terraform](https://www.terraform.io/) to declaratively script the infrastructure you desire. Resource names, locations, capacities, and secrets are parameterized and dynamic. The script is versioned and checked into source control as an artifact of your project. When needed, you can invoke the script to provision the desired infrastructure across different system environments (Dev, Test, Staging, Production) providing an identical blueprint of resources.

We cover infrastructure automation in detail in the Cloud-Native DevOps chapter of this book.

### Automating deployment

Cloud-native systems typically consist of many independent microservices that interact with each other when needed. Each of these services is self-contained and has its own life cycle. Trying to  *manually manage* them would be expensive, inefficient, and error prone.

Instead, manage each service with its own continuous integration/continuous delivery (CI/CD) pipeline. Both work in tandem to deploy and manage the cloud-native application.

Hold your thought as we cover DevOps and CI/CD later in this chapter and in the book.

### Orchestration

If you had only a handful of microservices, your DevOps team *might* be able to manually manage the workload. They would need to pay close attention to the performance and traffic patterns, so they could manage and scale the services correctly. However, if you have 10, 100 or even 1,000 microservices, all bets are off.

When you’re operating at scale, [container orchestration](https://blog.newrelic.com/engineering/container-orchestration-explained/) is mandatory. Orchestration includes deployment, management, scaling, networking, and availability of your containers.

Container orchestration is done with a special software program called (you guessed it) a container orchestrator. While several are available, [Kubernetes](https://kubernetes.io/) has become the de facto standard for the cloud-native world. The Azure cloud features Kubernetes as a managed service, [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/). You see Kubernetes as a running service in the Azure portal, Microsoft is responsible for provisioning or managing the Kubernetes infrastructure – a career path in and of itself!

What exactly do containers orchestrators do? Figure 1-10 provides some insight.

![What container orchestrators do](media/what-container-orchestrators-do.png)
**Figure 1-10**. What container orchestrators do

We'll dig deep into containers orchestrators and Azure Kubernetes Services throughout this book.

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](candidate-apps.md)
