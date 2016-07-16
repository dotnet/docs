Contributing
============

Thank you for your interest in contributing to the .NET documentation!

In this topic, you'll see the basic process for adding or updating content in our [documentation site](https://docs.microsoft.com/dotnet). For the detailed step-by-step process and instructions, please see the [official guide](https://github.com/Microsoft/Docs/blob/master/readme.md) in the [Microsoft/Docs](https://github.com/Microsoft/Docs) repo.

In this topic, we'll cover: 

* [Adding content](#adding-content)
* [Process for contributing](#process-for-contributing) 
* [Guidance checklist](#guidance-checklist)
* [Building the docs](#building-the-docs)
* [Contributing to samples](#contributing-to-samples)
* [Contributor License Agreement](#contributor-license-agreement)

## Adding content

Before adding content, please submit an issue describing your content proposal. For smaller changes or additions, feel free to make a Pull Request (PR) without opening an issue.

The content inside the **docs** folder is organized into sections that are reflected in our Table of Contents (TOC). 
See where your article fits in the TOC and navigate to the folder associated to that section.
That folder contains the Markdown files for all articles in the section.
If necessary, create a new folder to place the files for your content. The main article for that section will be the index.md. 
For images and other static resources, create a subfolder called **media** inside the folder that contains your article, if it doesn't already exist. Inside the **media** folder, create a subfolder with the article name (except for the index file).

Larger samples should be included in the samples folder under the root of the repo. 

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

## Process for contributing

**Step 1:** Open an issue describing the article you wish to write and how it
relates to existing content. Define where the topic will be located in the TOC - this will determine in which folder to place your article. Get approval to write it. 

You can skip this step for small changes.

**Step 2:** Fork the `/dotnet/core-docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article. 

If it's a new topic, you can use [our template file](template.md) as your starting point. It contains our writing guidelines and also explains the metadata required for each article, such as author information.

Place the article in the appropriate folder and any needed images in a media folder located in the same folder as the article.

Be sure to follow the proper Markdown syntax.
 
If you have code samples, place them in a folder within the `/samples/` folder. 
Also do not forget to remove the "wrench" icon (🔧) from the TOC and the file heading, if applicable. 

**Step 5:** Submit a PR from your branch to `dotnet/core-docs/master`.

If your PR is addressing an existing issue, add the `Fixes #Issue_Number` keyword to the commit message or PR description, so the issue can be automatically closed when the PR is merged. For more information, see [Closing issues via commit messages](https://help.github.com/articles/closing-issues-via-commit-messages/).

The .NET team will review your PR and let you know if the change looks good or if there are any other updates/changes necessary in order to approve it.

**Step 6:** Make any necessary updates to your branch as discussed with the team. 

When we are ready to accept the PR, we will let you know that the change looks good and merge it into the master branch. The master branch is our staging environment. 

On a certain cadence, we push all commits from master branch into the live branch (our production environment) and then you'll be able to see your contribution live at https://docs.microsoft.com/dotnet/. 

## DOs and DON'Ts

Below is a short list of guiding rules that you should keep in mind when you are contributing to .NET documentation.

- **DON'T** surprise us with big pull requests. Instead, file an issue and start a discussion so we can agree on a direction before you invest a large amount of time.
- **DO** read our [style guide](template.md) and [voice and tone](voice-tone.md) guidelines.
- **DO** use our [template](template.md) file as the starting point of your work.
- **DO** create a separate branch on your fork before working on the articles.
- **DO** follow the [GitHub Flow workflow](https://guides.github.com/introduction/flow/). 
- **DO** blog and tweet (or whatever) about your contributions, frequently!

> Note: you might notice that some of our topics are not currently following all the guidelines specified here and on our [style guide](template.md) as well. We're working towards achieving consistency throughout our site. Check the list of [open issues](https://github.com/dotnet/core-docs/issues?q=is%3Aissue+is%3Aopen+label%3Aguidelines-adherence) we're currently tracking for that specific goal. 

## Building the docs

The documentation is built using [DocFX](http://dotnet.github.io/docfx/), 
[Markdown](https://daringfireball.net/projects/markdown/syntax) and other internal publishing/building tools. It is hosted at [docs.microsoft.com/dotnet](https://docs.microsoft.com/dotnet). 

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

**Note:** the local preview currently doesn't contain any themes at the moment so the look and feel won't be the same as in our site. We're working towards fixing that experience.

## Contributing to samples

See the [Samples Readme](https://github.com/dotnet/core-docs/blob/master/samples/README.md).

## Contributor License Agreement

You must sign a [.NET Foundation Contribution License Agreement (CLA)](http://cla2.dotnetfoundation.org) before your PR will be merged. This is a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

Signing the CLA is super simple and can be done in less than a minute.

You don't have to do this up-front. You can simply clone, fork, and submit your PR as usual. When your PR is created, it is classified by a CLA bot. If the change is trivial (for example, you just fixed a typo), then the PR is labeled with `cla-not-required`; otherwise, it's classified as `cla-required`. Once you signed a CLA, the current and all future pull-requests will be labeled as `cla-signed`.