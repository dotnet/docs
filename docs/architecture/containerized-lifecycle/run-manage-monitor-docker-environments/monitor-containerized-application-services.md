---
title: Monitor containerized application services
description: Learn some key aspects of monitoring container architectures
ms.date: 08/06/2020
---
# Monitor containerized application services

It's critical for applications split into multiple containers and microservices to have a way to monitor and analyze the behavior of the whole application.

## Azure Monitor

[Azure Monitor](https://azure.microsoft.com/services/monitor/) is an extensible analytics service that monitors your live application. It helps you to detect and diagnose performance issues and to understand what users actually do with your app. It's designed for developers, with the intent of helping you to continuously improve the performance and usability of your services or applications. Azure Monitor works with both web/services and standalone apps on a wide variety of platforms like .NET, Java, Node.js and many other platforms, hosted on-premises or in the cloud.

### Additional resources

- **Overview of Azure Monitor** \
  [https://docs.microsoft.com/azure/azure-monitor/overview](/azure/azure-monitor/overview)

- **What is Application Insights?** \
  [https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview](/azure/azure-monitor/app/app-insights-overview)

- **What is Azure Monitor Metrics?** \
  [https://docs.microsoft.com/azure/azure-monitor/platform/data-platform-metrics](/azure/azure-monitor/platform/data-platform-metrics)

- **Container Monitoring solution in Azure Monitor** \
  [https://docs.microsoft.com/azure/azure-monitor/insights/containers](/azure/azure-monitor/insights/containers)

## Security and backup services

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

- **On-premises resources**. With [hybrid cloud solutions](https://azure.microsoft.com/solutions/hybrid-cloud-app/).

>[!div class="step-by-step"]
>[Previous](manage-production-docker-environments.md)
>[Next](../key-takeaways/index.md)
