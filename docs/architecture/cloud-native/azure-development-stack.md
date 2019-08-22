---
title: The Azure Cloud Native Development Stack
description: Architecting Cloud Native .NET Apps for Azure | The Azure Cloud Native Development Stack
author: ardalis
ms.date: 06/30/2019
---

# The Azure Cloud-Native Development Stack

Microsoft offers organizations seeking to build cloud native systems a compelling value proposition: A tightly integrated, but open, end-to-end stack for constructing and managing cloud native workloads.

Moreover, Microsoft is [making tremendous investments in open source](https://www.zdnet.com/article/why-microsoft-is-turning-into-an-open-source-company/) and cross-platform development tools to reach a wider range of developers - these tools are easy to acquire and free in many cases. It behooves CIOs to think differently about Microsoft development tools and investments in the Azure cloud as both provide comprehensive support for Linux and open-source initiatives.

We'll examine key considerations of the stack.

## Choosing an OS

For years, Microsoft and Linux vendors fought tooth-and-nail for control of the enterprise *server* market. Sides were formed, battle lines drawn. In many ways, it resembled a religious battle. Linux symbolizing freedom and Microsoft with a well understood, comprehensive platform.

### The operating system becomes transparent

Interestingly, with the growth of modern development platforms and container orchestrators, the operating system has become more transparent.

Why is that?

To start, most modern development platforms natively support cross-platform portability. Developers write an application in a preferred language, deploy it to the operating system of choice and the platform runtime engine automatically handles the environment-specific dependencies. Later, that same application package can be redeployed to a different operating system and ran just the same with the appropriate runtime engine and configuration changes.

Even further clouding operating system concerns is the explosive growth of containers. Containers allow applications to run independently of the operating system. "If you take a look at the way that containers have evolved, it's basically an evolution of the OS model we've had to this point," says Microsoft Azure CTO [Mark Russinovich](https://www.google.com/search?q=If+you+take+a+look+at+the+way+that+containers+have+evolved%2C+it%E2%80%99s+basically+an+evolution+of+the+OS+model+we%E2%80%99ve+had+to+this+point&rlz=1C1GCEU_enFR819US820&oq=If+you+take+a+look+at+the+way+that+containers+have+evolved%2C+it%E2%80%99s+basically+an+evolution+of+the+OS+model+we%E2%80%99ve+had+to+this+point&aqs=chrome..69i57.915j0j9&sourceid=chrome&ie=UTF-8). The operating system still exists, but its role has become further abstracted. Instead, the container orchestrator, which will we cover in detail later in the book, has become the *de-facto operating system* of choice. Developers and cloud administrators are less concerned about the operating system on which the container runs provided that the services exposed by container are reliable and can be quickly deployed.

### Azure, LCOW and Windows Server 2019 Platform

Finally, cloud providers like Microsoft openly embrace both Windows and Linux workloads. For Azure, it's Linux, not Windows Server, that has become the most popular operating system. Furthermore, many critical Azure services run on Linux. Consider, for example, Redis Cache, Sql Server on Linux, NoSql, or the variety of Linux VMs supporting at least eight Linux distributions that are available and have full support in Azure.

Even [Windows Server 2019](https://cloudblogs.microsoft.com/windowsserver/2018/03/20/introducing-windows-server-2019-now-available-in-preview/) itself features a subsystem for Linux that enables Windows and Linux environments to run simultaneously. Another new Windows feature, [Linux Containers on Windows](https://blogs.msdn.microsoft.com/premier_developer/2018/04/20/running-docker-windows-and-linux-containers-simultaneously/) ([LCOW](https://blogs.msdn.microsoft.com/premier_developer/2018/04/20/running-docker-windows-and-linux-containers-simultaneously/)) makes it possible to run Linux *and* Windows containers simultaneously - all from a single Docker engine. LCOW not only simplifies day-to-day management, but also consolidates infrastructure costs as there is no longer the need for dedicated hosts for each operating system.

As cloud native architecture and container orchestrators evolve, expect to see less and less importance placed on the choice of the operating system.

## .NET Core Platform

The Microsoft's .NET development platform originated in 2002 and is among the most loved technologies, according to a [Stack Overflow survey](http://dontcodetired.com/blog/post/Stack-Overflow-Developer-Survey-2018-Overview-for-NET-Developers).

Fast-forward to 2019 and the [Microsoft .NET Core platform](https://dotnet.microsoft.com/learn/dotnet/what-is-dotnet), a modernized rewrite of .NET. A free, open source and cross-platform development stack for building applications. It is a feature-rich platform that can be used to build services, devices and IoT applications, among others. It is maintained by Microsoft and the .NET community on GitHub. Cross-platform, applications built with .NET Core can run on Windows, macOS, and several flavors of Linux.

.NET Core supports multiple programming languages, editors, and libraries. It fully supports the C# programming language, which is a widely used and mature language that is frequently updated and continually modernized.

.NET core is highly performant and has scored very well in comparison to Node.js and other completing platforms see the [TechEmpower](https://www.techempower.com/benchmarks/#section=data-r17&hw=ph&test=plaintext) benchmark.

.NET Core plays especially well with microservice-based applications, including built-in features, open-source initiatives that directly support microservice development and direct support for Docker containers. All that said, the .NET Core stack with C\# is an excellent choice for building cloud native applications in the Azure cloud.

## Tooling: IDE vs. Editor

When building cloud native applications with the .NET Core platform, you have several development tools from which to choose.

### Visual Studio

At the top of the list is [Visual Studio](https://visualstudio.microsoft.com/), a full-featured IDE ([Integrated Development Environment](https://learn.g2crowd.com/ide)) for Windows including compilers, debuggers, source control, and profiling tools. It's a complete solution used primarily for .NET development.

It includes built-in support of Docker container-based development and a rich set of web development tooling providing everything you need to develop, manage, and deploy complex microservice applications. In the latest version of Visual Studio, you can develop cross-platform applications without leaving the IDE.

Rated as one of the [world's leading IDEs](https://www.g2crowd.com/categories/integrated-development-environment-ide), Visual Studio is available in a free fully functional [Community Edition](https://visualstudio.microsoft.com/vs/community/), with more feature-rich version available for Corporate use.

### Visual Studio Code

More recently, Microsoft has released [Visual Studio Code](https://code.visualstudio.com/docs/editor/whyvscode), a free, lightweight, cross-platform editor that contains built-in Git integration and can be used to view, edit, run, and debug source code for applications. Being an editor, it is primarily oriented around files, not projects and has limited scaffolding support.

It supports macOS, Linux, and Windows, featuring support for a variety of programming languages through its extensions model.

One of the key attractions of Visual Studio Code is the rich, fast-growing ecosystem of pluggable extensions. Easily installable from the [Extension Marketplace](https://marketplace.visualstudio.com/), these plug-ins let you customize your editing experience and add programming languages, debuggers, and tools to support a wide variety of development workflows.

Both Visual Studio and Visual Studio Code have tight integration with the Azure platform including productivity tooling and libraries that make it easy to discover and interact with cloud services that power your cloud native applications.

### Other Open Source Editors

But it doesn't stop there. Not only does .NET Core embrace cross-platform support, but it can be written across cross-platform. Figure 1-12 presents open-source development tools that can be used to construct .NET Core cloud native applications across multiple environments.

![Cross-platform editors for .NET Core](media/cross-platform-editors-for-dotnet-core.png)
**Figure 1-12**. Cross-platform editors for .NET Core

## Source control in GitHub

*Factor \#1* from the [Twelve-Factor Application](https://12factor.net/) guidelines, detailed above, calls for *storing your code in a repository tracked by revision control*. Such a repository can provide many services. To start, it can track changes to software development projects. With it, developers can simultaneously collaborate on a shared codebase and separate larger tasks into separate branches, merging changes when complete. At any time, developers can view the history of changes and revert to a previous version, if necessary.

Fortunately, development teams have many available options when selecting a repository.

One of them is [GitHub](https://github.com/). Founded in 2009, GitHub is an extremely popular web-based repository for hosting projects, documentation, and code. Apple, Amazon, Google, and many other large tech companies use GitHub. Using the open-source, distributed version control system named [Git](https://en.wikipedia.org/wiki/Git) as its foundation, GitHub adds its own features, including defect tracking, feature and pull requests, tasks management and wikis for each code base.

As of June 2018, GitHub had over 28 million users, making it the largest host of source code in the world. In October of 2018, Microsoft purchased GitHub. Microsoft has pledged that GitHub will remain an [open platform](https://techcrunch.com/2018/06/04/microsoft-promises-to-keep-github-independent-and-open/) that any developer can plug into and extend. It continues to operate as an independent company.

GitHub offers plans for enterprise, team, professional and free accounts and is an excellent location on which to store your source code.

## CI/CD in Azure DevOps

*Factor \#5* from the [Twelve-Factor Application](https://12factor.net/) guidelines calls for *strict separation of the build, release, and run stages*. Modern, automated CI/CD pipelines help fulfill this principle. They help to ensure consistent and quality code that's readily available to users.

[Continuous Integration/Continuous Delivery](https://www.infoworld.com/article/3271126/what-is-cicd-continuous-integration-and-continuous-delivery-explained.html) (CI/CD) is a set of operating principles that enable application development teams to deliver code changes frequently and reliably. Applying these practices, organizations have radically evolved how they ship software. Many have moved scheduled quarterly releases to immediate on-demand updates.

### Continuous Integration

[Continuous Integration (CI)](https://martinfowler.com/articles/continuousIntegration.html) works to establish a consistent, simplified, and automated *pipeline* approach to building, testing, and packaging applications. The process is typically invoked from a commit to your source code repository and composed of a series of steps to verify the commit, as shown in Figure 1-13.

![ Steps in the CI Pipeline](media/steps-in-the-ci-pipeline.png)
**Figure 1-13**. Steps in the CI Pipeline

The beauty of the pipeline approach is that additional steps and checks can be inserted to map the process to the exact deployment requirements for your organization.

The goal is to catch problems early in the development cycle when they're less expensive to fix. The longer the duration between integrations, the more expensive problems become to resolve. The CI process outputs project artifact items that are used by the CD pipeline to drive automatic deployments. With consistency in the integration process, teams can commit code changes more frequently, which leads to better collaboration and software quality.

### Continuous Deployment

[Continuous Delivery(CD)](https://martinfowler.com/bliki/ContinuousDelivery.html), closely related to CI, picks up where CI ends. It automatically picks up the package built by CI process and deploys it to a specified environment, such as QA, Staging, or Production, as shown in Figure 1-14.

It can invoke additional steps such as integration and performance tests.

![Steps in the CD Pipeline](media/steps-in-the-cd-pipeline.png)
**Figure 1-14**. Steps in the CD Pipeline

The goal is an automated, predictable deployment that can be performed on demand.

### Azure Pipelines

The Azure cloud includes a new CI/CD service entitled [Azure Pipelines](https://azure.microsoft.com/services/devops/pipelines/), which is part of the [Azure DevOps](https://azure.microsoft.com/services/devops/) offering, as shown in Figure 1-15.

![Azure Pipelines in DevOps](media/azure-pipelines-in-azure-devops.png)
**Figure 1-15**. Azure Pipelines in DevOps

Azure DevOps works with most Git providers, including GitHub, and can generate deployment pipelines for Linux, macOS, and Windows. It works with just about any language or project type, including .NET Languages, such as C#, F#, Visual Basic, along with Java, JavaScript, Python, .NET, PHP, Go, XCode, and C++.

To use Azure Pipelines, an organization creates an account (called an Organization) in [Azure DevOps](https://azure.microsoft.com/services/devops/pipelines/) service and stores its source code in a version control system. Interestingly, if your project is stored in a public repository, such as GitHub, Azure Pipelines is free to use. For private projects, there is a charge.

Azure Pipelines combines continuous integration (CI) and continuous delivery (CD) to consistently test and build your code and ship it to any target.

## Summary

In this chapter, we flew over cloud native computing at 5,000 feet, providing a definition along with the key characteristics of a cloud native application. We looked at the type of applications that might justify this type of investment and effort. Lastly, we looked cloud native development stack available in the Azure Cloud <https://deloitte.wsj.com/cio/2018/08/27/3-reasons-to-go-cloud-native/> working toward a [cloud-native](https://deloitte.wsj.com/cio/2016/12/12/making-the-leap-to-a-cloud-native-world/) mindset reorganizing people and processes and reworking applications with the cloud in mind organizations can maximize the benefits of their cloud efforts.

### References

- [Lift and Shift with Containers Book](https://aka.ms/liftandshiftwithcontainersebook)

>[!div class="step-by-step"]
>[Previous](candidate-apps.md)
>[Next](scale-applications.md) <!-- Next Chapter -->
