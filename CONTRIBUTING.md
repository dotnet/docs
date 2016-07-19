Contributing
============

Thank you for your interest in contributing to the .NET documentation!

In this topic, you'll see the basic process for adding or updating content in the [.NET documentation site](https://docs.microsoft.com/dotnet). For the detailed step-by-step process and instructions, please see the [official guide](https://github.com/Microsoft/Docs/blob/master/readme.md) in the [Microsoft/Docs](https://github.com/Microsoft/Docs) repo.

In this topic, we'll cover: 

* [Process for contributing](#process-for-contributing) 
* [Guidance checklist](#guidance-checklist)
* [Building the docs](#building-the-docs)
* [Contributing to samples](#contributing-to-samples)
* [Contributor License Agreement](#contributor-license-agreement)

## Process for contributing

**Step 1:** Open an issue describing the article you wish to write and how it relates to existing content.
The content inside the **docs** folder is organized into sections that are reflected in the Table of Contents (TOC). Define where the topic will be located in the TOC. Get feedback on your proposal. 

You can skip this step for small changes.

**Step 2:** Fork the `/dotnet/core-docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article. 

If it's a new topic, you can use this [template file](./styleguide/template.md) as your starting point. It contains the writing guidelines and also explains the metadata required for each article, such as author information.

Navigate to the folder that corresponds to the TOC location determined for your article in step 1.
That folder contains the Markdown files for all articles in that section.
If necessary, create a new folder to place the files for your content. The main article for that section will be the index.md. 
For images and other static resources, create a subfolder called **media** inside the folder that contains your article, if it doesn't already exist. Inside the **media** folder, create a subfolder with the article name (except for the index file).
Larger samples should be included in the `samples` folder under the root of the repo.

Be sure to follow the proper Markdown syntax. See the [style guide](./styleguide/template.md) for more information.

Also, remove the "wrench" icon (🔧) from the TOC and the file heading, if applicable. 

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

**Step 5:** Submit a Pull Request (PR) from your branch to `dotnet/core-docs/master`.

If your PR is addressing an existing issue, add the `Fixes #Issue_Number` keyword to the commit message or PR description, so the issue can be automatically closed when the PR is merged. For more information, see [Closing issues via commit messages](https://help.github.com/articles/closing-issues-via-commit-messages/).

The .NET team will review your PR and let you know if the change looks good or if there are any other updates/changes necessary in order to approve it.

**Step 6:** Make any necessary updates to your branch as discussed with the team. 

The maintainers will merge your PR into the master branch once feedback has been applied and your change looks good. 

On a certain cadence, we push all commits from master branch into the live branch and then you'll be able to see your contribution live at https://docs.microsoft.com/dotnet/. 

## DOs and DON'Ts

Below is a short list of guiding rules that you should keep in mind when you are contributing to the .NET documentation.

- **DON'T** surprise us with big pull requests. Instead, file an issue and start a discussion so we can agree on a direction before you invest a large amount of time.
- **DO** read the [style guide](./styleguide/template.md) and [voice and tone](./styleguide/voice-tone.md) guidelines.
- **DO** use the [template](./styleguide/template.md) file as the starting point of your work.
- **DO** create a separate branch on your fork before working on the articles.
- **DO** follow the [GitHub Flow workflow](https://guides.github.com/introduction/flow/). 
- **DO** blog and tweet (or whatever) about your contributions, frequently!

> Note: you might notice that some of the topics are not currently following all the guidelines specified here and on the [style guide](./styleguide/template.md) as well. We're working towards achieving consistency throughout the site. Check the list of [open issues](https://github.com/dotnet/core-docs/issues?q=is%3Aissue+is%3Aopen+label%3Aguidelines-adherence) we're currently tracking for that specific goal. 

## Building the docs

The documentation is written in [GitHub Flavored Markdown](https://help.github.com/categories/writing-on-github/) and built using [DocFX](http://dotnet.github.io/docfx/) and other internal publishing/building tools. It is hosted at [docs.microsoft.com](https://docs.microsoft.com/dotnet). 

To build the docs locally, you need to install [DocFX](https://dotnet.github.io/docfx/); latest versions are the best.

There are several ways to use DocFX, and most of them are covered in the [DocFX getting started guide](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html). 
The following instructions use the [command-line based](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool) version of the tool. 
If you are comfortable with other ways listed on the link above, feel free to use those. 

**Note:** please note that as of now, DocFX requires the .NET Framework on Windows or Mono for Linux or macOS. We'll be working towards porting it to .NET Core in the future. 

You can build and preview the resulting site locally using a built-in web server. Navigate to the core-docs folder on your machine and type the following command:

```
docfx .\docfx.json --serve
```
	
This starts the local preview on [localhost:8080](http://localhost:8080). You can then view the changes by going to `http://localhost:8080/docs/[path]`, such as http://localhost:8080/docs/articles/.

**Note:** the local preview currently doesn't contain any themes at the moment so the look and feel won't be the same as in the documentation site. We're working towards fixing that experience.

## Contributing to samples

See the [Samples Readme](https://github.com/dotnet/core-docs/blob/master/samples/README.md).

## Contributor License Agreement

You must sign the [.NET Foundation Contribution License Agreement (CLA)](http://cla2.dotnetfoundation.org) before your PR is merged. This is a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

The agreement: [net-foundation-contribution-license-agreement.pdf](https://cla2.dotnetfoundation.org/cladoc/net-foundation-contribution-license-agreement.pdf)

You don't have to do this up-front. You can simply clone, fork, and submit your PR as usual. When your PR is created, it is classified by a CLA bot. If the change is trivial (for example, you just fixed a typo), then the PR is labeled with `cla-not-required`. Otherwise, it's classified as `cla-required`. Once you signed the CLA, the current and all future pull requests will be labeled as `cla-signed`.