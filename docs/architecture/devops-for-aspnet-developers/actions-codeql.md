---
title: DevOps with .NET and GitHub Actions - Securing Code with CodeQL
description: Add security scanning to your .NET code with GitHub Actions and CodeQL
author: colindembovsky
ms.date: 03/04/2021
---

# Securing .NET Code with CodeQL and GitHub Actions

[CodeQL](https://codeql.github.com/docs/codeql-overview/about-codeql/) is a static code analysis engine that can automate security and quality checks. With CodeQL, you can perform _variant analysis_, which uses known vulnerabilities as seeds to find similar issues. CodeQL is part of [GitHub Advanced Security](https://docs.github.com/github/getting-started-with-github/about-github-advanced-security) which includes:

> [!div class="checklist"]
> * Code scanning - find potential security vulnerabilities in your code.
> * Secret scanning - detect secrets and tokens that are committed.
> * Dependency scanning - detect vulnerabilities in packages that you consume.

CodeQL [supports some of the most popular programming languages and compilers](https://codeql.github.com/docs/codeql-overview/supported-languages-and-frameworks/):
- C/C++
- Java
- C#
- Python
- Go
- JavaScript
- TypeScript

CodeQL is a very powerful language and security professionals can create custom queries using CodeQL. However, teams can benefit immensely from the large open source collection of queries that the security community has created without having to write any custom CodeQL.

In this article, you will set up a GitHub Workflow that will scan code in your repository using CodeQL. You will:

> [!div class="checklist"]
> * Create a Code Scanning Action.
> * Edit the workflow file.
> * See scanning results.

> [!NOTE]
> In order to see Security Alerts for your repository, you must be a repository owner.

## Create the Code Scanning Workflow

You can use a starter workflow for code scanning by navigating to the Security tab of your repository.

1. Navigate to your GitHub repository and select the **Security** tab. Select `Code Scanning Alerts`. The top recommended workflow should be CodeQL Analysis. Select `Set up this workflow`.

    - ![Create a new code scanning workflow](images/codeql/setup-workflow.jpg)
    **Figure 1:** Create a new code scanning workflow.

1. This creates a new workflow file in your `.github/workflows` folder.
1. Select `Start Commit` on the upper right to save the default workflow. You can commit to the `main` branch.
    
    - ![Commit the file](images/codeql/start-commit.jpg)
    **Figure 2:** Commit the file.

1. Select the **Actions** tab. In the left hand tree, you will now see a CodeQL node. Click on this node to filter for CodeQL workflow runs.
    - ![View the CodeQL Workflow runs](images/codeql/codeql-run.jpg)

Let's examine the workflow file while it runs. If we remove the comments from the file, we have the following yml:
```yml
name: "CodeQL"

on:
  push:
    branches: [ master ]
  pull_request:
    branches: [ master ]
  schedule:
    - cron: '40 14 * * 6'

jobs:
  analyze:
    name: Analyze
    runs-on: ubuntu-latest

    strategy:
      fail-fast: false
      matrix:
        language: [ 'csharp' ]

    steps:
    - name: Checkout repository
      uses: actions/checkout@v2

    - name: Initialize CodeQL
      uses: github/codeql-action/init@v1
      with:
        languages: ${{ matrix.language }}

    - name: Autobuild
      uses: github/codeql-action/autobuild@v1

    - name: Perform CodeQL Analysis
      uses: github/codeql-action/analyze@v1

```

We can see the following:
- The `name` of this workflow is `CodeQL`
- This workflow triggers on `push` and `pull_request` events to the `master` branch. There is also a `cron` trigger. The `cron` trigger lets you define a schedule for triggering this workflow and is randomly generated for you. In this case, this workflow will run at 14:40 UTC every Saturday.
> **Tip**: If you edit the workflow file and mouse-over the cron expression, a tooltip will show you the English text for the cron expression.
- There is a single job called `analyze` that runs on the `ubuntu-latest` hosted agent.
- This workflow defines a `strategy` with a `matrix` on the array of `language`. In this case, there is only `csharp` but if the repository contained other languages, you could just add them into this array. This causes the job to "fan out" and create an instance per value of the matrix.
- There are four steps, starting with `checkout`
- The next step initializes the CodeQL scanner for the `language` this job is going to scan. CodeQL intercepts calls to the compiler in order to build a database of the code while the code is being built.
- The `Autobuild` step will attempt to automatically build the source code. If this fails, you can inject your own custom build steps here.
- After building, the CodeQL analysis is performed, where suites of queries are run against the code database.
- The run should complete successfully: however, there appear to be no issues!
    - ![No results to the intial scan](images/codeql/no-results.jpg)

## Customize CodeQL Settings
The CodeQL scan is not reporting any security issues. However, CodeQL can also scan for quality issues. The current workflow is using the default `security-extended` suite. You can add quality scanning in by adding a configuration file to customize the scanning suites. In this step you will configure CodeQL to use the `security-and-quality` suites.

> For other CodeQL config options, see [this article](https://docs.github.com/en/github/finding-security-vulnerabilities-and-errors-in-your-code/configuring-codeql-code-scanning-in-your-ci-system)

- Navigate to the `.github` folder in the Code tab and add click Add File
    - ![Creating a new file](images/codeql/create-new-file.jpg)
- Enter `codeql/codeql-config.yml` as the name (this creates the file in a folder) and paste in the following code:
```yml
name: "Security and Quality"

queries:
  - uses: security-and-quality
```
    - ![Creating the CodeQL config file](images/codeql/codeql-config.jpg)
- Click `Commit to master` at bottom of the editor to commit the file.
- You must now edit the CodeQL workflow to use the new configuration file. Navigate to `.github/workflows/codeql-analysis.yml` and click the pencil icon. Add a new property to the `with` section as shown below:
```yml
- name: Initialize CodeQL
  uses: github/codeql-action/init@v1
  with:
    languages: ${{ matrix.language }}
    config-file: ./.github/codeql/codeql-config.yml  # <-- add this line
```
- Click `Start Commit` and commit to the master branch.

## Reviewing Security Alerts
> **Note**: This demo repository is small and as such does not contain any major security or quality issues. However, "real world" repos will more than likely have some issues!

When the last CodeQL workflow run completes, you should see 2 issues in the Security tab:
    - ![Viewing security alerts](images/codeql/security-alerts.jpg)
- Click on the first one to open the issue.
- In this case, the issue is in a generated file that is not commited to the repository, so the preview is unavailable.
- Note the tags that are applied - these can be used for filtering issues.
- Clicking `Show More` under the rule info will expand to provide additional help and recommendations.
    - ![Opening an alert](images/codeql/alert.jpg)
- Clicking `Dismiss` will open options for dismissing this issue:
    - ![Dismissing an alert](images/codeql/dismiss.jpg)