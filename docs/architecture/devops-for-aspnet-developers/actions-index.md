---
title: CI/CD with .NET and GitHub Actions Overview
description: See how GitHub Actions is a great platform for .NET DevOps
author: colindembovsky
ms.date: 03/04/2021
---
# .NET CI/CD with GitHub Actions

GitHub has long been the home for millions of open-source developers around the globe. Most developers associate source control with GitHub. However, GitHub is an evolving platform that can be used for more than just synchronizing Git repositories.

## GitHub Actions

GitHub Actions is a workflow engine that can be used to automate workflows for nearly all events that occur on the GitHub platform. Actions is a greate solution for Continuous Integration/Continuous Deployment (CI/CD) pipelines.

In this section of articles, you'll learn how to create an Actions workflow to build, test and deploy a .NET web app to Azure Web Apps.

In the [Build](actions-build.md) article, you'll create the initial workflow to build and test the .NET app. You'll:

> [!div class="checklist"]
> * Learn the basic structure of a GitHub Action workflow YAML file.
> * Use a template to create a basic build workflow that builds a .NET app and executes unit tests.
> * Publish the compiled app so that it's ready for deployment.

In the [Deploy](actions-build.md) article, you'll:

> [!div class="checklist"]
> * Learn about Environments in GitHub Actions.
> * Create two environments and specify environment protection rules.
> * Create environment secrets for managing environment-specific configuration.
> * Extend the workflow YAML file to add deployment steps.
> * Add a manual dispatch trigger.

## Securing Code with CodeQL

In addition to building and deploying code, [GitHub Advanced Security](https://docs.github.com/github/getting-started-with-github/about-github-advanced-security) offers a suite of tools for "shifting left" with security (that is, integrating security early on in the software delivery lifecycle). [CodeQL](https://codeql.github.com/docs/codeql-overview/about-codeql/) is a code scanning language that can be used to run a suite of queries that find potential vulnerabilities or quality issues in your code. CodeQL is run using an Actions workflow.

In the [CodeQL](actions-codeql.md) article you'll:

> [!div class="checklist"]
> * Create a Code Scanning Action.
> * Edit the workflow file to include custom scan settings.
> * See scanning results.

## Comparing and Contrasting GitHub Actions and Azure Pipelines

GitHub Actions and Azure Pipelines have a common lineage and are similar in many respects. However, there are some crucial differences between Actions and Pipelines that you need to know about if you're deciding which platform to use for building, testing and deploying apps. In the [Comparison](actions-vs-pipelines.md) article, you'll deep-dive into these platforms, compare and contrast them, and learn how to select the correct platform for your CI/CD needs.
