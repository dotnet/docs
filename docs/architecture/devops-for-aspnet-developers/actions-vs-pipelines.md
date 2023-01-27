---
title: DevOps with .NET and GitHub Actions - Compare GitHub Actions with Azure Pipelines
description: GitHub Actions and Azure Pipelines compared and contrasted for decision makers
author: colindembovsky
ms.date: 02/17/2021
---

# Compare and contrast GitHub Actions and Azure Pipelines

[!INCLUDE [download-alert](includes/download-alert.md)]

[GitHub Actions](https://docs.github.com/actions) and [Azure Pipelines](/azure/devops/pipelines/get-started/what-is-azure-pipelines) have a common history. In fact, the Actions agent is a fork of the Pipelines agent. There are many similarities between GitHub Actions and Azure Pipelines and it's worth comparing and contrasting them.

## Pipelines as code

Before you compare GitHub Actions and Azure Pipelines, you should consider the benefits of *pipelines as code*. Pipelines as code:

> [!div class="checklist"]
>
> * Benefit from standard source control practices (such as code reviews via pull request and versioning).
> * Can be audited for changes just like any other files in the repository.
> * Don’t require accessing a separate system or UI to edit.
> * Can fully codify the build, test, and deploy process for code.
> * Can usually be templatized to empower teams to create standard processes across multiple repositories.

> [!NOTE]
> The term "pipelines" can also be referred to by several different interchangeable words: *pipeline*, *workflow*, and *build* are common terms. In this article, references to *Azure Pipelines* are referring to [YAML Pipelines](/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops&preserve-view=true#define-pipelines-using-yaml-syntax), and not the older UI-based [Classic Pipelines](/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops&preserve-view=true#define-pipelines-using-the-classic-interface).

## Agents and runners

Before you examine pipelines themselves, you should consider how these pipelines *execute*. Both GitHub Actions and Azure Pipelines are really *orchestration engines*. When a pipeline is triggered, the system finds an "agent" and tells the agent to execute the jobs defined in the pipeline file.

Azure Pipelines run on *agents*. The agent is written in .NET, so it will run wherever .NET can run: Windows, macOS, and Linux. Agents can even run in containers. Agents are registered to a [pool](/azure/devops/pipelines/agents/pools-queues) in Azure Pipelines or to a repository or organization in GitHub. Agents can be *hosted* or *private*.

GitHub Workflows execute on *runners*. The runner code is essentially a fork of the Azure Pipelines code, so it's very similar. It's also cross-platform and you can also use *hosted* or *self-hosted* runners.

### Hosted agents and runners

Hosted agents (Azure Pipelines) and hosted runners (GitHub) are agents that are spun up and managed by Azure DevOps or GitHub respectively. You don't need to maintain any build infrastructure. When a pipeline triggers that targets a hosted agent, an instance of the specified agent image is created. The job is run by the agent on the instance, and once the job completes, the instance is destroyed. The same applies for hosted runners running GitHub workflows.

> [!NOTE]
> The list of software installed on Azure Pipelines images is listed in [this repository](https://github.com/actions/virtual-environments/tree/main/images). You can select the platform folder and examine the *README.md* files. You can find information on [GitHub hosted runners](https://docs.github.com/actions/reference/specifications-for-github-hosted-runners).

### Private agents and self-hosted runners

There are times when you can't use hosted images. For example, when you:

- Require SDKs or other software that isn't installed on the images.
- Need to access resources that aren't public (such as an internal SonarQube server or an internal Artifactory instance).
- Need to deploy to private networks.
- Need to install licenses for third-party software required for building your code.
- Need more storage or memory than is provided to the hosted agent images.
- Need more time than the maximum build time limit for hosted agents.

> [!IMPORTANT]
> It's possible to install tools and SDKs when running pipelines on hosted agents. If the install steps don't take long, this is viable. However, if the tools/software take a long time to install, then you may be better off with a private agent or self-hosted runner, since the install steps will need to execute for every run of the workflow.

### Azure DevOps agents

Every Azure DevOps account has a hosted pool with a single agent that can run one job at a time. Also included is a set number of free build minutes. You may purchase additional "hosted pipelines" in Azure DevOps. When you purchase an additional hosted pipeline, you're really removing the build minutes limit and adding *concurrency*. One pipeline can run one job at a time. Two pipelines can run two jobs simultaneously, and so on.

### Comparison of agents

|Feature|GitHub|Azure Pipelines|Links|
|-------|------|---------------|-----|
|Hosted agents for public repos/projects|Free|Up to 10 free Microsoft-hosted parallel jobs that can run for up to 360 minutes (6 hours) each time with no overall time limit per month. You aren't given this free grant by default, you have to [submit a request](https://aka.ms/azpipelines-parallelism-request)|[Azure Pipelines](/azure/devops/pipelines/agents/hosted?view=azure-devops&tabs=yaml&preserve-view=true#capabilities-and-limitations) [GitHub](https://github.com/features/actions)|
|Hosted agents for private repos/projects|2,000 minutes free per month, 3,000 minutes for Pro and Team licenses, 50,000 minutes for Enterprise license. Additional minutes may be purchased.|One free parallel job that can run for up to 60 minutes each time, until you've used 1,800 minutes (30 hours) per month. You can pay for additional capacity per parallel job. Paid parallel jobs remove the monthly time limit and allow you to run each job for up to 360 minutes (6 hours).||
|Cross-platform|Yes|Yes||
|Scale set agents|No|Yes| [Azure virtual machine scale set agents](/azure/devops/pipelines/agents/scale-set-agents?view=azure-devops&preserve-view=true)|

## Comparison of GitHub Actions and Azure Pipelines

Azure Pipelines (YAML pipelines) provide a mature set of features. Some of the features include:

* Approvals
* Artifact storage
* Deployment jobs
* Environments
* Gates
* Stages
* Templates
* Triggers
* Variable groups

For a full list of Azure Pipelines features, refer to the [Feature availability](/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops&preserve-view=true#feature-availability) table.

GitHub Actions are evolving rapidly and provide features such as triggers for almost all GitHub events, artifact storage, environments and environment rules, starter templates, and matrices. Read more about the entire feature set refer [GitHub Actions](https://docs.github.com/actions).

### Feature comparison

The following table is current as of January 2023 and is not an exhaustive list of features.

|Feature|Description|GitHub Actions|Azure Pipelines|
|-------|-----------|--------------|---------------|
|Approvals|Define approval conditions before moving further in the pipeline|Yes|Yes|
|Artifacts|Upload, store, and download artifacts from jobs|Yes|Yes|
|Caching|Cache folders or files for subsequent runs|Yes|Yes|
|Conditions|Specify conditions for steps or jobs|Yes|Yes|
|Container Jobs|Run jobs inside a container|Yes|Yes|
|Demands|Specify demands that must be met to match jobs to agents|Yes|Yes|
|Dependencies|Specify dependencies between jobs or stages|Yes|Yes|
|Deployment Groups|A logical set of target machines for deployments|No|Yes|
|Deployment Jobs|Job that targets a deployment group|No|Yes|
|Environments|A collection of resources to target or a logical environment|Yes|Yes|
|Gates/Checks|Automatic collection and evaluation of signals to control continuation|Yes|Yes|
|Jobs|Sequence of steps that are executed on an agent|Yes|Yes|
|Service Containers|Manage the lifecycle of a containerized service instance available during a job|Yes|Yes|
|Service Connections|Abstract credentials to external systems|No|Yes|
|Passwordless connections to cloud providers|Provide technologies and support use cases that reduce and potentially eliminate the use of passwords|Yes|No|
|Stages|Group jobs in a pipeline|No|Yes|
|Templates|Define reusable, parameterized building blocks for steps, jobs, or variables|Yes|Yes|
|Starter Templates|Defines a starter workflow based on the type of code detected in a repository|Yes|No|
|Triggers|Set of events that cause the pipeline to trigger|Yes|Yes|
|Variables|Variables that can be passed in, statically or dynamically defined|Yes|Yes|
|Variable Groups|Store values for use across multiple pipelines|No|Yes|

> [!IMPORTANT]
> GitHub Actions is rapidly evolving. Be sure to check documentation carefully before deciding which platform is right for you.

>[!div class="step-by-step"]
>[Previous](actions-index.md)
>[Next](actions-build.md)
