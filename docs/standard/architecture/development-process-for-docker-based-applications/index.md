---
title: Development Process for Docker Based Applications | Microsoft Docs 
description: .NET Microservices Architecture for Containerized .NET Applications | Development Process for Docker Based Applications
keywords: Docker, Microservices, ASP.NET, Container
author: CESARDELATORRE
ms.author: wiwagn
ms.date: 05/19/2017
---
-   [Vision](#vision)
-   [Development environment for Docker apps](#development-environment-for-docker-apps)
    -   [Development tool choices: IDE or editor](#development-tool-choices-ide-or-editor)
        -   [Additional resources](#additional-resources)
    -   [.NET languages and frameworks for Docker containers](#net-languages-and-frameworks-for-docker-containers)
-   [Development workflow for Docker apps](#development-workflow-for-docker-apps)
    -   [Workflow for developing Docker container-based applications](#workflow-for-developing-docker-container-based-applications)
        -   [Set up your local environment with Visual Studio](#set-up-your-local-environment-with-visual-studio)
        -   [Additional resources](#additional-resources-1)
        -   [Option A: Creating a project using an existing official .NET Docker image](#option-a-creating-a-project-using-an-existing-official-.net-docker-image)
        -   [Additional resources](#additional-resources-2)
            -   [Using multi-platform image repositories](#using-multi-platform-image-repositories)
        -   [Option B: Creating your base image from scratch](#option-b-creating-your-base-image-from-scratch)
        -   [Additional resources](#additional-resources-3)
        -   [Creating Docker images with Visual Studio](#creating-docker-images-with-visual-studio)
        -   [Working with docker-compose.yml in Visual Studio 2017](#working-with-docker-compose.yml-in-visual-studio-2017)
        -   [Option A: Running a single-container with Docker CLI](#option-a-running-a-single-container-with-docker-cli)
        -   [Option B: Running a multi-container application](#option-b-running-a-multi-container-application)
            -   [Running a multi-container application with the Docker CLI](#running-a-multi-container-application-with-the-docker-cli)
            -   [Running and debugging a multi-container application with Visual Studio ](#running-and-debugging-a-multi-container-application-with-visual-studio)
        -   [Additional resources](#additional-resources-4)
            -   [A note about testing and deploying with orchestrators](#a-note-about-testing-and-deploying-with-orchestrators)
        -   [Testing and debugging containers with Visual Studio 2017](#testing-and-debugging-containers-with-visual-studio-2017)
        -   [Testing and debugging without Visual Studio](#testing-and-debugging-without-visual-studio)
        -   [Additional resources](#additional-resources-5)
    -   [Simplified workflow when developing containers with Visual Studio](#simplified-workflow-when-developing-containers-with-visual-studio)
        -   [Additional resources](#additional-resources-6)
    -   [Using PowerShell commands in a Dockerfile to set up Windows Containers ](#using-powershell-commands-in-a-dockerfile-to-set-up-windows-containers)
        -   [Additional resources](#additional-resources-7)



>[!div class="step-by-step"]
[Previous] (../architecting-container-and-microservice-based-applications/orchestrating-microservices-and-multi-container-applications-for-high-scalability-and-availability.md)
[Next] (vision.md)
