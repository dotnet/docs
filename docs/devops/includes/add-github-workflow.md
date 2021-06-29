---
author: IEvangelist
ms.author: dapine
ms.date: 06/29/2021
ms.topic: include
recommendations: false
---

## Create a workflow file

In the GitHub repository, add a new YAML file to the *.github/workflows* directory. Choose a meaningful file name, something that will clearly indicate what the workflow is intended to do. Here are several good examples of workflow file names:

| Workflow file name | Description |
|--|--|
| *build-validation.yml* | Compiles (or builds) the source code. If the source code doesn't compile, this will fail. |
| *run-tests.yml* | Exercises the unit tests within the repository. Failing unit tests will cause workflow failure. |
| *publish-app.yml* (or *deploy-app.yml*) | Packages, and publishes the source code to a destination. |
| *codeql-analysis.yml* | Analyses your code for security vulnerabilities and coding errors. |
