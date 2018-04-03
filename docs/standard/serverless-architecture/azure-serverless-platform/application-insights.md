---
title: Application Insights | Serverless apps. Architecture, patterns, and Azure implementation.
description: Application Insights is a serverless diagnostics platform that enables developers to detect, triage, and diagnose issues in web apps, mobile apps, desktop apps and microservices.
author: JEREMYLIKNESS
ms.author: jeliknes
ms.date: 4/2/2018
ms.prod: .net
ms.technology: dotnet
ms.topic: article
---
# Telemetry with Application Insights

[Application Insights](/azure/application-insights) is a serverless diagnostics platform that enables developers to detect, triage, and diagnose issues in web apps, mobile apps, desktop apps and microservices. You can turn on Application Insights for function apps simply by flipping a switch in the portal or adding an `INSTRUMENTATION_KEY` to your application's settings. With Application Insights you can:

* Create custom charts and alerts based on metrics such as number of function invocations, the time it takes to run a function, and exceptions
* Analyze failures and server exceptions
* Drill into performance by operation and measure the time it takes to call third party dependencies
* Monitor CPU usage, memory, and rates across all servers that host your function apps
* View a live stream of metrics including request count and latency for your function apps
* Use [Analytics](/azure/application-insights/app-insights-analytics) to search, query, and create custom charts over your function data

>[!div class="step-by-step"]
[Previous] (./azure-functions.md)
[Next] (./logic-apps.md)