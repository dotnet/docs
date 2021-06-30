---
author: IEvangelist
ms.author: dapine
ms.date: 06/30/2021
ms.topic: include
recommendations: false
---

## Create a workflow file

In the GitHub repository, add a new YAML file to the *.github/workflows* directory. Choose a meaningful file name, something that will clearly indicate what the workflow is intended to do. Here are several good examples of workflow file names:

| Workflow file name | Description |
|--|--|
| *build-validation.yml* | Compiles (or builds) the source code. If the source code doesn't compile, this will fail. |
| *build-and-test.yml* | Exercises the unit tests within the repository. In order to run tests, the source code must first be compiled &mdash; this is really both a build and test workflow (it would supersede the *build-validation.yml* workflow). Failing unit tests will cause workflow failure. |
| *publish-app.yml* (or *deploy-app.yml*) | Packages, and publishes the source code to a destination. |
| *codeql-analysis.yml* | Analyzes your code for security vulnerabilities and coding errors. Any discovered vulnerabilities could cause fail. |

> [!IMPORTANT]
> GitHub requires that workflow composition files to be placed within the *.github/workflows* directory.

Workflow files typically define a composition of one or more GitHub Action via the `jobs.<job_id>/steps[*]`. For more information, see, [Workflow syntax for GitHub Actions](https://docs.github.com/actions/reference/workflow-syntax-for-github-actions).
