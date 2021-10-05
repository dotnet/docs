---
title: Continuous integration and deployment with GitHub Actions overview
description: Learn how to create a continuous deployment pipeline with GitHub Actions and .NET DevOps
author: colindembovsky
ms.date: 03/30/2021
uid: azure/devops/github-actions
---
# Continuous integration and deployment with GitHub Actions

GitHub has long been the home for millions of open-source developers around the globe. Most developers associate source control with GitHub. However, GitHub is an evolving platform that can be used for more than just synchronizing Git repositories.

## GitHub Actions

GitHub Actions is a workflow engine that can automate workflows for nearly all events that occur on GitHub. Actions is a great solution for Continuous Integration/Continuous Deployment (CI/CD) pipelines.

In this section of articles, you'll learn how to create an Actions workflow. The workflow will build, test, and deploy a .NET web app to Azure Web Apps.

> [!NOTE]
> Before you begin, complete the **Publish the app's code to GitHub** and **Disconnect local Git deployment** sections of the [Continuous integration and deployment with Azure DevOps](cicd.md) section to publish your code to GitHub. Then proceed to the [Build](actions-build.md) article.

In the [Build](actions-build.md) article, you'll create the initial workflow to build and test the .NET app. You'll:

> [!div class="checklist"]
>
> * Learn the basic structure of a GitHub Action workflow YAML file.
> * Use a template to create a basic build workflow that builds a .NET app and executes unit tests.
> * Publish the compiled app so that it's ready for deployment.

In the [Deploy](actions-deploy.md) article, you'll:

> [!div class="checklist"]
>
> * Learn about environments in GitHub Actions.
> * Create two environments and specify environment protection rules.
> * Create environment secrets for managing environment-specific configuration.
> * Extend the workflow YAML file to add deployment steps.
> * Add a manual dispatch trigger.

## Secure code with CodeQL

In addition to building and deploying code, [GitHub Advanced Security](https://docs.github.com/github/getting-started-with-github/about-github-advanced-security) offers tools for "shifting left" with security. That is, integrating security early on in the software delivery lifecycle. [CodeQL](https://codeql.github.com/docs/codeql-overview/about-codeql/) is a code scanning language that runs queries to find potential vulnerabilities or quality issues in your code. CodeQL is run using an Actions workflow.

In the [CodeQL](actions-codeql.md) article, you'll:

> [!div class="checklist"]
>
> * Create a Code Scanning Action.
> * Edit the workflow file to include custom scan settings.
> * See scanning results.

## Compare and contrast GitHub Actions and Azure Pipelines

GitHub Actions and Azure Pipelines have a common lineage and are similar in many respects. However, you should understand the differences before selecting a platform for building, testing, and deploying apps. In the [Comparison](actions-vs-pipelines.md) article, you'll deep dive into these platforms and compare and contrast them. You'll also learn how to select the correct platform for your CI/CD needs.

>[!div class="step-by-step"]
>[Previous](cicd.md)
>[Next](actions-vs-pipelines.md)
