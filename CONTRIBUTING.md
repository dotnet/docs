# Contributing

Thank you for your interest in contributing to the .NET documentation!

The document covers the process for contributing to the articles and code samples that are hosted on the [.NET documentation site](https://docs.microsoft.com/dotnet). Contributions may be as simple as typo corrections or as complex as new articles.

* [Process for contributing](#process-for-contributing) 
* [DOs and DON'Ts](#dos-and-donts)
* [Building the docs](#building-the-docs)
* [Contributor License Agreement](#contributor-license-agreement)

## Process for contributing

You'll need a basic understanding of [Git and GitHub.com](https://guides.github.com/activities/hello-world/).

**Step 1:** Skip this step for small changes. Open an [issue](https://github.com/dotnet/docs/issues) describing what you want to do, such as change an existing article or create a new one.
The content inside the **docs** folder is organized into sections that are reflected in the Table of Contents (TOC). Define where the topic will be located in the TOC. Get feedback on your proposal.

You can also look at our [open issues](https://github.com/dotnet/docs/issues) list and volunteer to work on the ones you're interested in. We use the [up-for-grabs](https://github.com/dotnet/docs/labels/up-for-grabs) label to tag issues open for contribution.

**Step 2:** Fork the `/dotnet/docs` repo and create a branch for your changes.

For small changes, you can use GitHub's web interface and simply click the **Edit the file in your fork of this project** on the file you'd like to change and 
GitHub will create the new branch for you when you submit the changes.

**Step 3:** Make the changes on this new branch.

If it's a new topic, you can use this [template file](./styleguide/template.md) as your starting point. It contains the writing guidelines and also explains the metadata required for each article, such as author information.

Navigate to the folder that corresponds to the TOC location determined for your article in step 1.
That folder contains the Markdown files for all articles in that section.
If necessary, create a new folder to place the files for your content. The main article for that section will be called *index.md*.
For images and other static resources, create a subfolder called **media** inside the folder that contains your article, if it doesn't already exist. Inside the **media** folder, create a subfolder with the article name (except for the index file).
Larger samples should be included in the *samples* folder under the root of the repo.

Be sure to follow the proper Markdown syntax. See the [style guide](./styleguide/template.md) for more information.

Remove the "wrench" icon (🔧) from the TOC and the file heading, if applicable.

### Example structure

    docs
      /about
      /core
        /porting
          porting-overview.md
          /media
            /porting-overview
                portability_report.png
      ...
    samples
      /core
        /porting
          porting_sample.cs

**Step 4:** Submit a Pull Request (PR) from your branch to `dotnet/docs/master`.

If your PR is addressing an existing issue, add the `Fixes #Issue_Number` keyword to the commit message or PR description, so the issue can be automatically closed when the PR is merged. For more information, see [Closing issues via commit messages](https://help.github.com/articles/closing-issues-via-commit-messages/).

The .NET team will review your PR and let you know if there are any other updates/changes necessary in order to approve it.

**Step 5:** Make any necessary updates to your branch as discussed with the team.

The maintainers will merge your PR into the master branch once feedback has been applied and your change is approved.

On a certain cadence, we push all commits from master branch into the live branch and then you'll be able to see your contribution live at https://docs.microsoft.com/dotnet/.

### Contributing to samples

We make the following distinction for code that exists in our repository:

- samples: readers can download and run the samples. All samples should be complete applications or libraries. Where the sample creates a library,
it should include unit tests or an application that lets readers run the code.

- snippets: illustrate a smaller concept or task. They compile but they are not intended to be complete applications.

Code all lives in the *samples* directories and is organized as follows:

- *core* contains .NET Core samples.

   * The *core* directory contains samples that highlight .NET Core. The purpose of your sample should be to teach developers something about .NET Core. This includes the framework packaging, the new tooling, or the cross-platform experience. Our CI build server builds these samples on multiple supported platforms. Therefore, every sample must be configured to build on Linux, Mac, and Windows.

- *csharp* contains C# language samples.

   * The *csharp* directory contains samples where the purpose is to explain the C# language. While these samples will use frameworks and libraries, their focus is on the C# language. Our CI build server builds these samples on multiple supported platforms. Therefore, every sample must be configured to build on Linux, Mac, and Windows.

- *framework* contains .NET Framework samples. These are referenced by topics under many different locations in the documentation. These samples build only on Windows.

   * The *framework* directory contains samples that highlight .NET with platform dependencies. These may include migration samples, platform specific samples, or other samples that require the framework or the Windows-based tools. Our CI build server builds these samples on Windows only. Do not place any samples here that should be checked for cross-platform builds.

- *snippets* contains the code snippets used throughout the documentation. Inside the *snippets* folder, you'll see folder names that identify the language of the code snippet.

We will expand these directories as the docs repository adds new content. For example, we will add Xamarin directories, like `xamarin-ios` and `xamarin-android` directories. 

Sample code may fit more than one of these areas. In those cases, place the sample so it matches
the topics you are covering in your documents. Ask yourself what readers will learn from reading
your topic. What will they learn from building and running your sample?

Each complete sample that you create should contain a *readme.md* file. This file should
contain a short description of the sample (one or two paragraphs). Your *readme.md*
should tell readers what they will learn by exploring this sample. The *readme.md* file should also contain
a link to the live document on the [.NET documentation site](http://docs.microsoft.com/dotnet/welcome).
To determine where a given file in the repository maps to that site, replace `/docs` in the repository path
with `http://docs.microsoft.com/dotnet/articles`.

Your topic will also contain links to the sample. Link directly to the sample's folder on GitHub.

For more information, see the [Samples Readme](https://github.com/dotnet/docs/blob/master/samples/README.md).

## DOs and DON'Ts

Below is a short list of guiding rules that you should keep in mind when you are contributing to the .NET documentation.

- **DON'T** surprise us with big pull requests. Instead, file an issue and start a discussion so we can agree on a direction before you invest a large amount of time.
- **DO** read the [style guide](./styleguide/template.md) and [voice and tone](./styleguide/voice-tone.md) guidelines.
- **DO** use the [template](./styleguide/template.md) file as the starting point of your work.
- **DO** create a separate branch on your fork before working on the articles.
- **DO** follow the [GitHub Flow workflow](https://guides.github.com/introduction/flow/).
- **DO** blog and tweet (or whatever) about your contributions, frequently!

> Note: you might notice that some of the topics are not currently following all the guidelines specified here and on the [style guide](./styleguide/template.md) as well. We're working towards achieving consistency throughout the site. Check the list of [open issues](https://github.com/dotnet/docs/issues?q=is%3Aissue+is%3Aopen+label%3Aguidelines-adherence) we're currently tracking for that specific goal.

## Building the docs

Test your changes with the [DocFX command-line tool](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool), which creates a locally hosted version of the site. DocFX doesn't render style and site extensions created for docs.microsoft.com.

To build the docs locally, you need to install [DocFX](https://dotnet.github.io/docfx/). DocFX requires the .NET Framework on Windows, or Mono for Linux or macOS.

### Windows instructions

* Download the [latest version of DocFX](https://github.com/dotnet/docfx/releases) and unzip *docfx.zip*.
* Add DocFX to your PATH.
* In a command prompt, navigate to the *docs* directory and run the following command:

```
docfx -t default --serve
```

* In a browser, navigate to `http://localhost:8080`.

### Mono instructions

* Install Mono via Homebrew - `brew install mono`.
* Download the [latest version of DocFX](https://github.com/dotnet/docfx/releases).
* Extract to `\bin\docfx`.
* Create an alias for **docfx**:

```
function docfx {
  mono $HOME/bin/docfx/docfx.exe
}

function docfx-serve {
  mono $HOME/bin/docfx/docfx.exe serve _site
}
```

* Run **docfx** in the *docs* directory to build the site, and **docfx-serve** to view the site at `http://localhost:8080`.

## Contributor License Agreement

You must sign the [.NET Foundation Contribution License Agreement (CLA)](http://cla2.dotnetfoundation.org) before your PR is merged. This is a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

The agreement: [net-foundation-contribution-license-agreement.pdf](https://cla2.dotnetfoundation.org/cladoc/net-foundation-contribution-license-agreement.pdf)

You don't have to do this up-front. You can simply clone, fork, and submit your PR as usual. When your PR is created, it is classified by a CLA bot. If the change is trivial (for example, you just fixed a typo), then the PR is labeled with `cla-not-required`. Otherwise, it's classified as `cla-required`. Once you signed the CLA, the current and all future pull requests will be labeled as `cla-signed`.
