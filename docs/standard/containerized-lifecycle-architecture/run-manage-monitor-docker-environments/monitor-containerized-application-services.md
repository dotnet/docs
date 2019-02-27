---
title: Monitor containerized application services
description: Learn some key aspects of monitoring container architectures
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 02/15/2019
---
# Monitor containerized application services

It's critical for applications split into multiple containers and microservices to have a way to monitor and analyze the behavior of the whole application.

## Microsoft Application Insights

[Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview) is an extensible analytics service that monitors your live application. It helps you to detect and diagnose performance issues and to understand what users actually do with your app. It's designed for developers, with the intent of helping you to continuously improve the performance and usability of your services or applications. Application Insights works with both web/services and standalone apps on a wide variety of platforms like .NET, Java, Node.js and many other platforms, hosted on-premises or in the cloud.

### Analyzing Docker apps in QA environments using Application Insights

As it pertains to Docker, you can chart life-cycle events and performance counters from Docker containers on Application Insights. You just need to run the [Application Insights Docker image](https://hub.docker.com/r/microsoft/applicationinsights/) as a container in your host, and it will display performance counters for the host as well as for the other Docker images. This Application Insights Docker image (Figure 6-1) helps you to monitor your containerized applications by collecting telemetry about the performance and activity of your Docker host (that is, your Linux VMs), Docker containers and the applications running within them.

![example](./media/image1.png)

**Figure 6-1**. Application Insights monitoring Docker hosts and containers

When you run the [Application Insights Docker image](https://hub.docker.com/r/microsoft/applicationinsights/) on your Docker host, you benefit from the following:

- Life-cycle telemetry about all the containers running on the host—start, stop, and so on.

- Performance counters for all the containers: CPU, memory, network usage, and more.

- If you also installed [Application Insights SDK](https://docs.microsoft.com/azure/application-insights/app-insights-asp-net) in the apps running in the containers, all the telemetry of those apps will have additional properties identifying the container and host machine. So, for example, if you have instances of an app running in more than one host, you'll easily be able to filter your app telemetry by host.

### Setting up Application Insights to monitor Docker applications and Docker hosts

To create an Application Insights resource, follow the instructions in the articles presented in the list that follows. Azure portal will create the necessary script for you.

- **Monitor Docker applications in Application Insights:** \
  <https://docs.microsoft.com/azure/application-insights/app-insights-docker>

- **Application Insights Docker image at Docker Hub and GitHub:** \
  <https://hub.docker.com/r/microsoft/applicationinsights/> and \
  <https://github.com/Microsoft/ApplicationInsights-Docker>

- **Set up Application Insights for ASP.NET web apps and ASP.NET Core:** \
  <https://docs.microsoft.com/azure/application-insights/app-insights-asp-net>

- **Application Insights for web pages:**  
  <https://docs.microsoft.com/azure/application-insights/app-insights-javascript>

## Security, backup, and monitoring services

There are many support chores with lots of details that you have to handle to ensure your applications and infrastructure are in top notch condition to support business needs, and the situation becomes more complicated in the microservices realm, so you need a way to have both high-level and detailed views when you need to take action.

Azure has the tools to manage and provide a unified view of four critical aspects of both your cloud and on-premises resources:

- **Security**. With [Azure Security Center](https://azure.microsoft.com/services/security-center/).
  - Get full visibility and control over the security of your virtual machines, apps, and workloads.
  - Centralize the management of your security policies and integrate existing processes and tools.
  - Detect real threats with advanced analytics.

- **Backup**. With [Azure Backup](https://azure.microsoft.com/services/backup/).
  - Avoid costly business disruptions, meet compliance goals, and protect your data against ransomware and human errors.
  - Keep your backup data encrypted in transit and at rest.
  - Ensure access based on multifactor authentication to prevent unauthorized use.

- **Monitoring**. With [Azure monitoring](https://azure.microsoft.com/solutions/monitoring/), [Log Analytics](https://azure.microsoft.com/services/log-analytics/), and [Application Insights](https://azure.microsoft.com/services/application-insights/).
  - Get full visibility into the health and performance of your Azure workloads, apps, and infrastructure.
  - Collect data from any source and get rich insights into your virtual machines, containers, and applications.
  - Find the information you need using interactive queries and full-text search. 
  - Perform root-cause analysis with advanced analytics, including machine learning algorithms.

- **On-premises resources**. With [a truly consistent hybrid cloud](https://azure.microsoft.com/resources/truly-consistent-hybrid-cloud-with-microsoft-azure/).

>[!div class="step-by-step"]
>[Previous](manage-production-docker-environments.md)
>[Next](../key-takeaways/index.md)
