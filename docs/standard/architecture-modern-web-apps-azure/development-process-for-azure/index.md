---
title: development process for azure | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | development process for azure
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [Vision](#vision)
-   [Development environment for ASP.NET Core apps](#development-environment-for-asp.net-core-apps)
    -   [Development tools choices: IDE or editor](#development-tools-choices-ide-or-editor)
-   [Development workflow for Azure-hosted ASP.NET Core apps](#development-workflow-for-azure-hosted-asp.net-core-apps)
    -   [Initial Setup](#initial-setup)
    -   [Workflow for developing Azure-hosted ASP.NET Core applications](#workflow-for-developing-azure-hosted-asp.net-core-applications)
        -   [\
            Step 1. Local Dev Environment Inner Loop](#step-1.-local-dev-environment-inner-loop)
        -   [Step 2. Application Code Repository](#step-2.-application-code-repository)
        -   [Step 3. Build Server: Continuous Integration. Build, Test, Package](#step-3.-build-server-continuous-integration.-build-test-package)
        -   [Step 4. Build Server: Continuous Delivery](#step-4.-build-server-continuous-delivery)
        -   [Step 5. Azure App Service. Web App.](#step-5.-azure-app-service.-web-app.)
        -   [Step 6. Production Monitoring and Diagnostics](#step-6.-production-monitoring-and-diagnostics)
    -   [References](#references)


> _"With the cloud, individuals and small businesses can snap their fingers and instantly set up enterprise-class services."_  
> _- Roy Stephan_


>[!div class="step-by-step"]
[Previous] (../testing-asp/functional-testing-asp.net-core-apps.md)
[Next] (vision.md)
