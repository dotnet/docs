---
title: Implementing Resilient Applications | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Implementing Resilient Applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [Vision](#vision)
-   [Handling partial failure](#handling-partial-failure)
-   [Strategies for handling partial failure](#strategies-for-handling-partial-failure)
    -   [Additional resources](#additional-resources)
    -   [Implementing retries with exponential backoff](#implementing-retries-with-exponential-backoff)
        -   [Implementing resilient Entity Framework Core SQL connections](#implementing-resilient-entity-framework-core-sql-connections)
            -   [Execution strategies and explicit transactions using BeginTransaction and multiple DbContexts](#execution-strategies-and-explicit-transactions-using-begintransaction-and-multiple-dbcontexts)
        -   [Additional resources](#additional-resources-1)
        -   [Implementing custom HTTP call retries with exponential backoff](#implementing-custom-http-call-retries-with-exponential-backoff)
        -   [Implementing HTTP call retries with exponential backoff with Polly](#implementing-http-call-retries-with-exponential-backoff-with-polly)
    -   [Implementing the Circuit Breaker pattern](#implementing-the-circuit-breaker-pattern)
        -   [Implementing a Circuit Breaker pattern with Polly](#implementing-a-circuit-breaker-pattern-with-polly)
    -   [Using the ResilientHttpClient utility class from eShopOnContainers](#using-the-resilienthttpclient-utility-class-from-eshoponcontainers)
    -   [Testing retries in eShopOnContainers](#testing-retries-in-eshoponcontainers)
    -   [Testing the circuit breaker in eShopOnContainers](#testing-the-circuit-breaker-in-eshoponcontainers)
    -   [Adding a jitter strategy to the retry policy](#adding-a-jitter-strategy-to-the-retry-policy)
        -   [Additional resources](#additional-resources-2)
-   [Health monitoring](#health-monitoring)
    -   [Implementing health checks in ASP.NET Core services](#implementing-health-checks-in-asp.net-core-services)
        -   [Using the HealthChecks library in your back end ASP.NET microservices](#using-the-healthchecks-library-in-your-back-end-asp.net-microservices)
        -   [Caching health check responses](#caching-health-check-responses)
        -   [Querying your microservices to report about their health status](#querying-your-microservices-to-report-about-their-health-status)
    -   [Using watchdogs](#using-watchdogs)
    -   [Health checks when using orchestrators](#health-checks-when-using-orchestrators)
    -   [Advanced monitoring: visualization, analysis, and alerts](#advanced-monitoring-visualization-analysis-and-alerts)
        -   [Additional resources](#additional-resources-3)



>[!div class="step-by-step"]
[Previous] (../tackling-business-complexity-in-a-microservice-with-ddd-and-cqrs-patterns/implementing-the-microservice-application-layer-using-the-web-api.md)
[Next] (vision.md)
