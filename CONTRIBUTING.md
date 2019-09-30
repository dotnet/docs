# Contributing

Thank you for your interest in contributing to the .NET documentation!

> We're in the process of moving our guidelines into a site-wide contribution guide.
> To see the new guidance, visit [Microsoft Docs contributor guide overview](https://docs.microsoft.com/contribute/).

The document covers the process for contributing to the articles and code samples that are hosted on the [.NET documentation site](https://docs.microsoft.com/dotnet). Contributions may be as simple as typo corrections or as complex as new articles.

- [Process for contributing](#process-for-contributing)
- [The C# interactive experience](#the-c-interactive-experience)
- [DOs and DON'Ts](#dos-and-donts)
- [Contributor License Agreement](#contributor-license-agreement)

This repository contains the conceptual documentation for .NET. The .NET documentation site is built from multiple repositories in addition to this one:

- [Code samples and snippets](https://github.com/dotnet/samples)
- [API reference](https://github.com/dotnet/dotnet-api-docs)
- [.NET Compiler Platform SDK reference](https://github.com/dotnet/roslyn-api-docs)

Issues and tasks for roslyn-api-docs repository is tracked here.

## Process for contributing

You need a basic understanding of [Git and GitHub.com](https://guides.github.com/activities/hello-world/).

**Step 1:** Skip this step for small changes (for example, if you're correcting a typo or immediately opening a pull request to address an issue that you find in the docs). If you're interested in writing new content or in thoroughly revising existing content, open an [issue](https://github.com/dotnet/docs/issues) describing what you want to do.
The content inside the *docs* folder is organized into sections that are reflected in the Table of Contents (TOC). Define where the topic will be located in the TOC. Get feedback on your proposal.

-or-

You can also choose from existing issues for which community contributions are welcome. [Projects for .NET Community contributors](https://github.com/dotnet/docs/projects/35) lists many of the work items that are available for community contributors. Depending on your interests and level of commitment, you can choose from issues in the following categories:

- **Maintenance**. This category includes fairly simple contributions, such as fixing broken or incorrect links, adding missing code examples, or addressing limited content issues. In some cases, these issues may concern large numbers of files. In that case, you should let us know what you'd like to work on before you begin.

- **Content updates**. Given the enormity of the doc set, content easily becomes outdated and requires revision. In addition, for a variety of reason, some content has been duplicated or even triplicated. Updating content involves making sure that individual topics are current or revising content in a feature area to eliminate duplication and ensure that all unique content is preserved in the smaller documentation set.

- **New content authoring**. If you're interested in authoring your own topic, these issues list topics that we know we'd like to add to our doc set. Let us know before you begin working on a topic, though. If you're interested in writing a topic that isn't listed here, open an issue.

You can also look at our [open issues](https://github.com/dotnet/docs/issues) list and volunteer to work on the ones you're interested in. We use the [up-for-grabs](https://github.com/dotnet/docs/labels/up-for-grabs) label to tag issues open for contribution. 

**Step 2:** Fork the `dotnet/docs`, `dotnet/samples` or `dotnet/dotnet-api-docs` repos as needed and create a branch for your changes.

For small changes, you can use GitHub's web interface. Simply click the **Edit the file in your fork of this project** on the file you'd like to change. GitHub creates the new branch for you when you submit the changes.

**Step 3:** Make the changes on this new branch.

If it's a new topic, you can use this [template file](./styleguide/template.md) as your starting point. It contains the writing guidelines and also explains the metadata required for each article, such as author information.

Navigate to the folder that corresponds to the TOC location determined for your article in step 1.
That folder contains the Markdown files for all articles in that section.
If necessary, create a new folder to place the files for your content. The main article for that section is called *index.md*.
For images and other static resources, create a subfolder called *media* inside the folder that contains your article, if it doesn't already exist. Inside the *media* folder, create a subfolder with the article name (except for the index file).
Include larger samples in the *samples* folder under the root of the repo.

Be sure to follow the proper Markdown syntax. For more information, see the [style guide](./styleguide/template.md).

### Example structure

```
docs
  /about
  /core
    /porting
      porting-overview.md
      /media
        /porting-overview
            portability_report.png
```

**Step 4:** Submit a Pull Request (PR) from your branch to `dotnet/docs/master`, `dotnet/dotnet-api-docs/master`, or `dotnet/samples/master`.

Your PR should *always* target the master branch. You should *never* open a PR that targets the live branch.

Each PR should usually address one issue at a time. The PR can modify one or multiple files. If you're addressing multiple fixes on different files, separate PRs are preferred.

If your PR is addressing an existing issue, add the `Fixes #Issue_Number` keyword to the commit message or PR description. That way, the issue is automatically closed when the PR is merged. For more information, see [Closing issues via commit messages](https://help.github.com/articles/closing-issues-via-commit-messages/).

The .NET team will review your PR and let you know if there are any other updates/changes necessary in order to approve it.

**Step 5:** Make any necessary updates to your branch as discussed with the team.

The maintainers will merge your PR into the master branch once feedback has been applied and your change is approved.

On a certain cadence, we push all commits from master branch into the live branch and then you'll be able to see your contribution live at https://docs.microsoft.com/dotnet/.

### Contributing to samples

We make the following distinction for code that exists in our repository:

- Samples: readers can download and run the samples. All samples should be complete applications or libraries. Where the sample creates a library, it should include unit tests or an application that lets readers run the code.

- Snippets: illustrate a smaller concept or task. They compile but they are not intended to be complete applications.

Code all lives in the [dotnet/samples](https://github.com/dotnet/samples) repository. We are working toward a model where our samples folder structure matches our docs folder structure. Standards that we follow are:

- The top level *snippets* folder contains snippets for small, focused samples.
- API reference samples have been in a folder following this pattern: *snippets/\<language>/api/\<namespace>/\<apiname>*.
- Other top-level folders match the top level folders in the *docs* repository. For example, the docs repository has a *machine-learning/tutorials* folder, and the samples for machine learning tutorials are in the *samples/machine-learning/tutorials* folder.

In addition, all samples under the *core* and *standard* folders should build and run on all platforms supported by .NET Core. Our CI build system will enforce that. The top level *framework* folder contains samples that are only built and validated on Windows.

We may expand these directories as the docs repository adds new content. For example, we will add Xamarin directories, like `xamarin-ios` and `xamarin-android` directories.

Each complete sample that you create should contain a *readme.md* file. This file should contain a short description of the sample (one or two paragraphs). Your *readme.md* should tell readers what they will learn by exploring this sample. The *readme.md* file should also contain a link to the live document on the [.NET documentation site](https://docs.microsoft.com/dotnet/welcome).
To determine where a given file in the repository maps to that site, replace `/docs` in the repository path
with `https://docs.microsoft.com/dotnet`.

Your topic will also contain links to the sample. Link directly to the sample's folder on GitHub.

For more information, see the [Samples Readme](https://github.com/dotnet/samples/blob/master/README.md).

## The C# interactive experience

Short code samples in C# can use the `csharp-interactive` language tag to 
specify a C# sample that runs in the browser. (Inline code samples use the
`csharp-interactive` tag, for snippets included from source, use the
`code-csharp-interactive` tag.) These code samples
display a code window and an output window in the article. The output window displays any output from
executing the interactive code once the user has run the sample. 

The C# interactive experience changes how we work with samples. Visitors can run the sample
to see the results. A number of factors help determine if the sample
or corresponding text should include information about the output.

### When to display the expected output without running the sample

- Articles intended for beginners should provide output so that readers can compare the output of their work with the expected answer.
- Samples where the output is integral to the topic should display that output. For example, articles on formatted text should show the text format without running the sample.
- When both the sample and the expected output is short, consider showing the output. It saves a bit of time.
- Articles explaining how current culture or invariant culture affect output should explain the expected output. The interactive REPL (Read Evaluate Print Loop) runs on a Linux-based host. The default culture, and the invariant culture produce different output on different operating systems and machines. The article should explain the output in Windows, Linux, and Mac systems.

### When to exclude expected output from the sample 

- Articles where the sample generates a larger output should not include that in comments. It obscures the code once the sample has been run.
- Articles where the sample demonstrates a topic, but the output isn't integral to understanding it. For example, code that runs a LINQ query to explain query syntax and then display every item in the output collection.

## DOs and DON'Ts

The following list shows some guiding rules that you should keep in mind when you're contributing to the .NET documentation:

- **DON'T** surprise us with large pull requests. Instead, file an issue and start a discussion so we can agree on a direction before you invest a large amount of time.
- **DO** read the [style guide](./styleguide/template.md) and [voice and tone](./styleguide/voice-tone.md) guidelines.
- **DO** use the [template](./styleguide/template.md) file as the starting point of your work.
- **DO** create a separate branch on your fork before working on the articles.
- **DO** follow the [GitHub Flow workflow](https://guides.github.com/introduction/flow/).
- **DO** blog and tweet (or whatever) about your contributions, frequently!

> Note: you might notice that some of the topics are not currently following all the guidelines specified here and on the [style guide](./styleguide/template.md) as well. We're working towards achieving consistency throughout the site. Check the list of [open issues](https://github.com/dotnet/docs/issues?q=is%3Aissue+is%3Aopen+label%3Aguidelines-adherence) we're currently tracking for that specific goal.

## Contributor License Agreement

You must sign the [.NET Foundation Contribution License Agreement (CLA)](https://cla.dotnetfoundation.org) before your PR is merged. This is a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](https://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

The agreement: [net-foundation-contribution-license-agreement.pdf](https://github.com/dotnet/home/blob/master/guidance/net-foundation-contribution-license-agreement.pdf)

You don't have to sign the agreement up-front. You can clone, fork, and submit your PR as usual. When your PR is created, it is classified by a CLA bot. If the change is trivial (for example, you fixed a typo), then the PR is labeled with `cla-not-required`. Otherwise, it's classified as `cla-required`. Once you signed the CLA, the current and all future pull requests are labeled as `cla-signed`.
