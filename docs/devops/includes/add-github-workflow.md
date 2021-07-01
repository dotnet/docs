---
author: IEvangelist
ms.author: dapine
ms.date: 07/01/2021
ms.topic: include
recommendations: false
---

## Create a workflow file

In the GitHub repository, add a new YAML file to the *.github/workflows* directory. Choose a meaningful file name, something that will clearly indicate what the workflow is intended to do. Here are several good examples of workflow file names:

:::row:::
    :::column span="1":::
        **Workflow file name**
    :::column-end:::
    :::column span="3":::
        **Description**
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        *build-validation.yml*
    :::column-end:::
    :::column span="3":::
        Compiles (or builds) the source code. If the source code doesn't compile, this will fail.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        *build-and-test.yml*
    :::column-end:::
    :::column span="3":::
        Exercises the unit tests within the repository. In order to run tests, the source code must first be compiled &mdash; this is really both a build and test workflow (it would supersede the *build-validation.yml* workflow). Failing unit tests will cause workflow failure.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        *publish-app.yml* (or *deploy-app.yml*)
    :::column-end:::
    :::column span="3":::
        Packages, and publishes the source code to a destination.
    :::column-end:::
:::row-end:::
:::row:::
    :::column span="1":::
        *codeql-analysis.yml*
    :::column-end:::
    :::column span="3":::
        Analyzes your code for security vulnerabilities and coding errors. Any discovered vulnerabilities could cause fail.
    :::column-end:::
:::row-end:::

> [!IMPORTANT]
> GitHub requires that workflow composition files to be placed within the *.github/workflows* directory.

Workflow files typically define a composition of one or more GitHub Action via the `jobs.<job_id>/steps[*]`. For more information, see, [Workflow syntax for GitHub Actions](https://docs.github.com/actions/reference/workflow-syntax-for-github-actions).
