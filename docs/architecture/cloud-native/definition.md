---
title: Defining Cloud Native
description: Architecting Cloud-Native .NET Apps for Azure | Defining Cloud Native
author: robvet
ms.date: 08/05/2019
---
# Defining Cloud Native

Stop what you’re doing and ping 10 of your colleagues. Ask them to define the term “Cloud Native.” Good chance you’ll get eight different answers. Interestingly, six months from now, as cloud-native technologies and practices evolve, so will their definition.

Cloud native is all about changing the way we think about constructing critical business systems.

But, what exactly is cloud native?

The Cloud Native Computing Foundation provides an [official definition](https://github.com/cncf/foundation/blob/master/charter.md) of Cloud Native:

*Cloud-native technologies empower organizations to build and run scalable applications in modern, dynamic environments such as public, private, and hybrid clouds. Containers, service meshes, microservices, immutable infrastructure, and declarative APIs exemplify this approach.*

*These techniques enable loosely coupled systems that are resilient, manageable, and observable. Combined with robust automation, they allow engineers to make high-impact changes frequently and predictably with minimal toil.*

Applications have become increasingly complex with users demanding more and more. Users expect rapid responsiveness, innovative features, and zero downtime. Performance problems, recurring errors, and the inability to move fast are no longer acceptable. They'll easily move to your competitor.

Cloud native is much about *speed* and *agility*. Business systems are evolving from enabling business capabilities to weapons of strategic transformation, accelerating business velocity and growth. It’s imperative to get ideas to market immediately. 


The following table highlights companies who have implemented these techniques. Think about the speed, agility, and scalability they've achieved.

|  |  |
| :-------- | :-------- |
| Netflix | Has 600+ services in production. Deploys a hundred times per day. |
| Uber | Has 1,000+ services stored in production. Deploys several thousand service builds each week. |
| WeChat | Has 300+ services in production. Makes almost 1,000 changes per day. |


As you can see, Netflix, Uber, and WeChat expose systems that consist of hundreds of independent microservices. This architectural style enables them to rapidly respond to market conditions. They can instantaneously update small areas of a live, complex application and individually scale those areas as needed.

The speed and agility of cloud native derive from a number of ingredients, including system architecture and infrastructure, coupled with the six capabilities highlighted in blue in Figure 1-2.

![Capabilities of cloud-native apps](media/capabilities-of-cloud-native-apps.png)

**Figure 1-2**. Capabilities of cloud-native apps

Let’s take some time to better understand the importance of each key capability.

## The cloud…

Cloud-native systems take full advantage of the cloud service model.

Designed to thrive in a dynamic, virtualized cloud environment, these systems make extensive use of [Platform as a Service (PaaS)](https://azure.microsoft.com/overview/what-is-paas/) compute infrastructure and managed services. They treat the underlying infrastructure as *disposable* - provisioned in minutes and resized, scaled, moved, or destroyed whenever necessary – all through automation.

Consider the widely-accepted DevOps concept of [Pets vs. Cattle](https://medium.com/@Joachim8675309/devops-concepts-pets-vs-cattle-2380b5aab313). In a traditional data center, servers are treated as *Pets*: a physical machine, given a meaningful name, and cared for. You scale by adding more resources to the same machine (scaling up). If the server becomes sick, you nurse it back to health. Should the server become unavailable, everyone notices.

The *Cattle* service model is different. You provision each instance as a virtual machine or container. They are identical and assigned a system identifier such as Service-01, Service-02, and so on. You scale by creating more of them (scaling out). When one becomes unavailable, nobody notices.

The cattle model embraces *immutable infrastructure*. Servers aren't repaired or modified. If one fails or requires updating, it's destroyed and a new one is provisioned – all done via automation.

Cloud-native systems embrace the Cattle service model. They continue to run as the infrastructure scales in or out with no regard to the machines upon which they're running.

The Azure cloud platform supports this type of highly elastic infrastructure with automatic scaling, self-healing, and monitoring capabilities.

## Modern design...

How would you design a cloud-native app? What would your architecture look like? To what principles, patterns, and best practices would you adhere? What infrastructure and operational concerns would be important?

### The 12-Factor Application

A widely accepted methodology for constructing cloud-native applications is the [Twelve-Factor Application](https://12factor.net/). This manifesto describes guidelines for building cloud-based applications. The factors adhere to a set of principles and best practices that developers follow to construct and evolve applications that are optimized for modern cloud environments. Special attention is paid to portability across environments and declarative automation.

While applicable to any web-based application, many practitioners consider this manifesto a solid foundation for building cloud-native apps.  Systems built upon these principles can deploy and scale rapidly and add features to react quickly to market changes.

The following table highlights the 12-Factor methodology.

|    |  Factor | Explanation  |
| :-------- | :-------- | :-------- |
| 1 | Code Base | Single code base for each microservice, stored in its own repository, tracked with revision control, able to deploy to across environments (Dev, QA, Prod). |
| 2 | Dependencies | Each microservice isolates and packages its own dependencies, embracing changes without impacting the entire system. |
| 3 | Configurations  | Configuration information is moved out of the microservice and externalized through a configuration management tool outside of the code. The same deployment can propagated across environments with the correct configuration applied.  |
| 4 | Backing Services | All required ancillary resources (data stores, caches, message brokers) should be accessed as RESTFul services via an addressable URL decoupling the resource from the microservices and enabling it to be easily interchanged.  |
| 5 | Build, Release, Run | Each release must enforce a strict separation across the build, release and run stages. Each should be tagged with a unique ID and support the ability to roll back. Modern CI/CD systems help fulfill this principle. |
| 6 | Statelessness | Each microservice will be stateless with any necessary state externalized to a backing service (i.e., distributed cache, data store), providing seamless scalability and fault tolerance. |
| 7 | Port Binding | Each microservices is built within a container, typically exposed as HTTP on a web server, with all interfaces and functionality bound through ports, once again, providing isolation from other microservices. |
| 8 | Concurrency | Services scale out across a large number of small identical processes (copies) as opposed to scaling-up a single large instance on the most powerful machine available. |
| 9 | Disposability | Service instances should be disposable, favoring fast startups to increase scalability opportunities and graceful shutdowns to leave the system in a correct state. Docker containers along with an orchestrator inherently satisfy this requirement. |
| 10 | Dev/Prod Parity | Keep environments across the application lifecycle (Dev, QA, Staging and Prod) as similar as possible, avoiding costly shortcuts. Here, the adoption of containers can greatly contribute by promoting the same execution environment. |
| 11 | Logging | Treat logs generated by microservices as event streams, processed by event aggregator infrastructure and propagated to data-mining/log management tools like Azure Monitor or Splunk and eventually long-term archival. |
| 12 | Admin Processes | Run administrative/management tasks as one-off processes. These tasks might include data cleanup or pulling analytics for a report. Tools performing such tasks should be  invoked from the production environment, but separately from the application. |

In his book, [Beyond the Twelve-Factor App](https://content.pivotal.io/blog/beyond-the-twelve-factor-app), Author Kevin Hoffman details each of the original 12 factors (written in 2011) while providing additional factors that reflect today's modern cloud application design.

We'll refer to the 12 factors throughout the book.

### Critical Design Considerations

Beyond the guidance provided from the 12-factor manifesto, there are several critical design decisions you must make when constructing distributed systems.

*Communication*

How will front-end client applications communicate with backed-end core services? Will you allow direct communication? Or, might you abstract the backend services with a gateway façade that provides  flexibility, control, and security?

Then, how will back-end core services communicate with each other? Will you allow direct HTTP calls that lead to coupling and impact performance and agility? Or, might you consider decoupled messaging with queue and topic technologies?

*Resiliency*

A microservices architecture moves your system from in-process to network communication. In a distributed environment, what will you do when Service B isn't responding to a call from Service A? What happens when Service C becomes temporarily unavailable and other services calling it, stack up, and degrade system performance?

*Distributed Data*

By design, each microservice encapsulates its own data, exposing operations via its public interface. If so, how do you query data or implement a transaction across multiple services?

*Identity*

How will your service identify who is accessing it and what permissions they have?

These topics are covered in detail throughout the chapters of this book.

## Microservices…
Cloud-native systems embrace microservices, a popular architectural style for constructing modern applications.

Built as a distributed set of small, independent services that interact through a shared fabric, microservices share the following characteristics:

- Each implements a specific business capability within a larger domain context.

- Each is developed autonomously and can be deployed independently.

- Each is self-contained encapsulating its own data storage technology (SQL, NoSQL) and programming platform.

- Each runs in its own process and communicates with others using standard communication protocols such as HTTP/HTTPS, WebSockets, or [AMQP](https://en.wikipedia.org/wiki/Advanced_Message_Queuing_Protocol).

- They compose together to form an application.


>> Add factor #1 for single code base for each svc???


Figure 1-3 contrasts a monolithic application approach with a microservices approach. Note how the monolith is composed of a layered architecture which executes in a single process. It typically consumes a single centralized relational database. The microservice approach, however, segregates functionality into independent services that include logic and data. Each microservice hots its own data store.

![Monolithic deployment versus microservices](media/monolithic-vs-microservices.png)

**Figure 1-3.** Monolithic deployment versus microservices

### Why microservices?

Microservice provide agility.

Each microservice has an autonomous lifecycle and evolve independently and deploy frequently. You don’t have to wait for a quarterly release to deploy new features or updates. You can update small areas of a complex application with less risk of disrupting the entire system.

Each microservice can scale independently. Instead of scaling the entire application as a single unit, you scale out only those services that require more processing power or network bandwidth. This  fine-grained approach to scaling provides for greater control of your system and helps to reduce overall costs as you scale portions of your system, not everything.

### Developing microservices

>> Microservices can be created in any modern dev platform. Touch on languages and dev tools???

An excellent reference guide for microservices is [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/dotnet/standard/microservices-architecture/).

## Containers…

Nowadays, it natural to hear the term *container* mentioned in any conversation concerning *cloud native*. In her book, [Cloud Native Patterns](https://www.manning.com/books/cloud-native-patterns), author Cornelia Davis observes that, "Containers are a great enabler of cloud-native software." So much so that the Cloud Native Computing Foundation places microservice containerization as the [first step](https://raw.githubusercontent.com/cncf/trailmap/master/CNCF_TrailMap_latest.png) for enterprises starting their cloud native journey.

To containerize a microservice, developers package their code and its required infrastructure (dependencies and runtime) into a binary called a container [image](https://docs.docker.com/glossary/?term=image). Images are stored to a [container registry](https://azure.microsoft.com/services/container-registry/) in a public cloud. When needed, the image is transformed into a container instance. The instance runs on any computer which has the Docker runtime engine installed.


>> Add factor #2 - isolates own dependencies??


Figure 1-4 shows three different microservices, each in its own container, running on a single host.

![Multiple containers running on a container host](media/hosting-mulitple-containers.png)  

**Figure 1-4**. Multiple containers running on a container host

In the previous image, note how each container maintains its own set of dependencies and runtime, which can be different. Here, we see different versions of the Product microservice running on the same host. Each container shares a slice of the underlying host operating system, memory and processor, but is isolated from one another. 

Containers support both Linux and Windows workloads. The Azure cloud openly embraces both, and it's Linux, not Windows Server, that has become the most popular operating system in Azure.

### Why containers?

Containers provide portability and guarantee consistency across environments. By encapsulating everything into a single package, you *isolate* the microservice and its dependencies from the underlying infrastructure. 

>> Add factor #7 - isolation???


You can deploy that same container in any environment that has the Docker runtime engine. Containerized workloads also eliminate the expense of pre-configuring each environment with frameworks, software libraries, and runtime engines.

By sharing the underlying operating system and host resources, containers have a much smaller footprint than a full virtual machine. The smaller size increases the *density*, or number of microservices, that a given host can run at one time.

While tools such as Docker create images and run containers, you also need tools to manage them. Container management is done with a special software program called a container orchestrator. When operating at scale, container orchestration is essential. 

Figure 1-6 shows common management tasks that container orchestrators perform.

![What container orchestrators do](media/what-container-orchestrators-do.png)

**Figure 1-6**. What container orchestrators do

The following table highlights the management tasks that container orchestrators perform.

|  Tasks | Explanation  |
| :-------- | :-------- |
| Scheduling | Automatically provision container instances.|
| Affinity/anti-affinity | Provision containers either nearby each other or far apart from each other, facilitating availability and performance. |
| Health monitoring | Automatically detect and correct failures.|
| Failover | Automatically re-provision failed instance to healthy machines.|
| Scaling | Automatically add or remove container instance to meet demand.|
| Networking | Initiate a networking overlay for container communication.|
| Service Discovery | Enable containers to locate each other.|
| Rolling Upgrades | Coordinate incremental upgrades to avoid downtime and automatically rollback problematic changes.|

While several container orchestrators exist, [Kubernetes](https://kubernetes.io/docs/concepts/overview/what-is-kubernetes/) has become the de facto standard for the cloud-native world. It's a portable, extensible, open-source platform for managing containerized workloads. 

You could host your own instance of Kubernetes, but then you'd be responsible for provisioning and managing its resources - which can be complex. The Azure cloud features Kubernetes as a managed service, [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/). Kubernetes as a managed service allows you fully leverage its features, without having to install and maintain it.

### Developing in containers

Most developers build code on their local computers. They install the required frameworks, libraries, and runtimes and construct their application. When complete, the code is unit tested and checked into a team repository for future use.

Cloud-native systems, however, consist of large numbers of interrelated microservices. Running the entire application on a local computer can be difficult, if not impossible. A common alternative involves maintaining a set of mock dependencies to enable end-to-end testing on the local machine. However, their creation can be time-consuming and lead to subtle bugs if not kept current.

Cloud-native development teams often containerize their development cycle. They write code in Docker containers and run the application in a shared development cluster in the cloud. New tooling innovations in Visual Studio and [Azure Kubernetes Service](https://azure.microsoft.com/services/kubernetes-service/) help facilitate this new approach.

## Backing services...

Cloud-native systems depend upon many different ancillary resources, such as data stores, message brokers, monitoring, and identity services. These services are known as [backing services](https://12factor.net/backing-services).

 Figure 1-5 shows many common backing services that cloud-native systems consume.

![Common backing services](media/common-backing-services.png)

**Figure 1-5**. Common backing services

You could host your own backing services, but then you'd be responsible for licensing, provisioning, and managing those resources.

Cloud providers offer a rich assortment of *managed backing services.* Instead of owning the service, you simply consume it. The provider operates the resource at scale and bears the responsibility for performance, security, and maintenance. You can count on monitoring, redundancy, and availability – all built into the service. Providers fully support their managed services - open a ticket and they fix your issue.

Cloud-native systems more often favor managed backing services from cloud vendors. The savings in time and labor are great. The operational risk of hosting your own and experiencing trouble can get expensive fast.

When constructing cloud-native applications, it is a best practice to treat a backing service as an *attached resource*, bound to your containerized microservice by a URL and credentials stored in an external configuration. This guidance is explicitly spelled out in the [Twelve-Factor Application](https://12factor.net/), discussed earlier in the chapter.

>*Factor \#4* specifies that "backing services should be configurable, accessible from a URL, and easily interchanged."

>*Factor \#3* specifies that "configuration information should be externalized outside of the microservice code."

With this pattern, each backing service is dynamically bound to the containerized microservice and can be attached and detached without code changes. For example, you might promote your microservice from QA to a staging environment. After provisioning the backing services to staging, you would update the microservice binding configuration to point to the new resources and inject them into your container at startup. 

Finally, a microservice should never directly reference an API for a backing service. Cloud vendors provide libraries for you to communicate with their proprietary backing services. Directly communicating with these libraries in your code lock you into that backing service. It is a better practice to introduce an intermediation layer, or intermediate API, which insulates the implementation details of the proprietary API, exposing generic operations to you service code. This loose coupling enables you to swap out one backing service for another or move your code to a different public cloud without having to make changes to the mainline service code.

Throughout this book, we'll explore various types of cloud-managed backing services.

## Automation

As you've seen, cloud-native systems embrace microservices, containers, and modern system design to achieve speed and agility. But, that's only part of the story. How do you provision the cloud environments upon which these systems run? How do you rapidly deploy app features and updates? How can you round out the full picture?

Enter the widely-accepted practice of [Infrastructure as Code](https://docs.microsoft.com/azure/devops/learn/what-is-infrastructure-as-code), or IaC.

With IaC, you automate platform provisioning and application deployment. You essentially apply software engineering practices such as testing, versioning, and xxxxxxx to your DevOps practices. Your infrastructure and deployments are automated, consistent, and repeatable.

### Automating infrastructure

Tools like [Azure Resource Manager](https://azure.microsoft.com/documentation/articles/resource-group-overview/), [Terraform](https://www.terraform.io/) and the [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest), enable you to declaratively script the infrastructure you require. Resource names, locations, capacities, and secrets are parameterized and dynamic. The script is versioned and checked into source control as an artifact of your project. You can then invoke the script on demand to provision a consistent infrastructure across different system environments. 

Under the hood, IaC is idempotent, meaning that you can run the same script over and over without side effects. If the team needs to make a change, they edit the script and rerun it.

In the article, [What is Infrastructure as Code](https://docs.microsoft.com/azure/devops/learn/what-is-infrastructure-as-code), Sam Guckenheimer describes how, "Teams who implement IaC can deliver stable environments rapidly and at scale. Teams avoid manual configuration of environments and enforce consistency by representing the desired state of their environments via code. Infrastructure deployments with IaC are repeatable and prevent runtime issues caused by configuration drift or missing dependencies. DevOps teams can work together with a unified set of practices and tools to deliver applications and their supporting infrastructure rapidly, reliably, and at scale."

### Automating deployments

The [Twelve-Factor Application](https://12factor.net/) details the steps for transforming code into a running application.

> *Factor \#5* specifies that "Each release must enforce a strict separation across the build, release and run stages. Each should be tagged with a unique ID and support the ability to roll back."

In a nutshell, you should be able to test and build the code; then, combine the binaries with specific configuration information to create a specific release; and finally run the release. Each releases should be identifiable. You should be able to say, ‘This deployment is running Release 2.1.1 of the application.

Modern CI/CD systems help fulfill this principle. They provide for separate deployment steps and help ensure consistent and quality code that's readily available to users. Figure 1.x shows the process.

![Continuous Integration (CI)](media/build-release-run-pipeline.png)

**Figure 1-11**. Deployment steps in a CI/CD Pipeline

In the previous figure, the developer constructs a feature in his or her development environment. When complete, the code is pushed into a code repository, such as GitHub, an Azure DevOps repo or BitBucket. That push then triggers the build step which is implemented using a [Continuous Integration (CI)](https://martinfowler.com/articles/continuousIntegration.html) pipeline, which automatically builds, tests, and packages the application as a binary artifact. Next, the [Continuous Delivery(CD)](https://martinfowler.com/bliki/ContinuousDelivery.html) picks up the package built by the CI process, applies external configuration information, and produces an immutable release. Finally, the release is deployed to a specified cloud environment, such as QA or production. 

Applying these practices, organizations have radically evolved how they ship software. Many have moved from quarterly releases to immediate on-demand updates.

The goal of CI/CD is an automated, predictable deployment that can be triggered on demand.

(CI/CD) is a set of operating principles that enable application development teams to deliver code changes frequently and reliably. 

The goal is to catch problems early in the development cycle when they're less expensive to fix. The longer the duration between integrations, the more expensive problems become to resolve. The CI process outputs project artifact items that are used by the CD pipeline to drive automatic deployments. With consistency in the integration process, teams can commit code changes more frequently, leading to better collaboration and software quality.

The Azure cloud includes a new CI/CD service entitled [Azure Pipelines](https://azure.microsoft.com/services/devops/pipelines/), which is part of the [Azure DevOps](https://azure.microsoft.com/services/devops/) offering shown in Figure 1-11.

![Azure Pipelines in DevOps](media/azure-pipelines-in-azure-devops.png)

**Figure 1-11**. Azure Pipelines in DevOps

Azure DevOps supports most Git providers and generates deployment pipelines for Linux, macOS, and Windows. It includes support for Java, .NET, JavaScript, Python, PHP, Go, XCode, and C++.

An organization creates an account (called an Organization) in the [Azure DevOps](https://azure.microsoft.com/services/devops/pipelines/) service and stores its source code in a version control system. If your project is stored in a public repository, such as GitHub, Azure Pipelines is free to use. For private projects, there's a charge.

Azure Pipelines combines CI/CD to consistently test, build, and deploy your code to any target.

We cover automation and DevOps later in the book.

>[!div class="step-by-step"]
>[Previous](introduction.md)
>[Next](candidate-apps.md)
