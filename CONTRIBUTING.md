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

## Adding content ##

Before adding content, please submit an issue describing your content proposal. For smaller changes or additions, feel free to make a Pull Request (PR) without opening an issue.

The content inside the **docs** folder is organized into sections that are reflected in our Table of Contents (TOC). 
See where your article fits in the TOC and navigate to the folder associated to that section.
That folder contains the Markdown files for all articles in the section.
If necessary, create a new folder to place the files for your content.
For images and other static resources, create a subfolder called **media** inside the folder that contains your article, if it doesn't already exist.
Larger samples should be included in the samples folder under the root of the repo. 

### Example structure ###

    docs
      /about
      /core
        /porting
          /media
            portability_report.png
      ...
    samples
      /core
        /porting
          porting_sample.cs

## Process for contributing ##

**Step 1:** Open an issue describing the article you wish to write and how it
relates to existing content. Get approval to write your article.

**Step 2:** Fork the `/dotnet/core-docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article. You can use [our template file](template.md) as your starting point. It contains our writing guidelines and also explains about the metadata required for each article, such as author information.
Also read our [voice and tone article](voice-tone.md).
Place the article in the appropriate folder and any needed images in a media folder located in the same folder as the article.
Be sure to follow the proper Markdown syntax. 
If you have code samples, place them in a folder within the `/samples/` folder. 
 Also do not forget to remove the "wrench" icon (🔧) from the TOC and the file heading, if applicable. 

**Step 5:** Submit a PR from your branch to `dotnet/core-docs/master`.

**Step 6:** Discuss the PR with the .NET team; make any requested updates to your branch. 
When we are ready to accept the PR, we will add a "LGTM" (Looks Good To Me) comment and any other steps that are perhaps necessary.

## DOs and DON'Ts ##

Below is a short list of guiding rules that you should keep in mind when you are contributing to .NET documentation.

- **DON'T** surprise us with big pull requests. Instead, file an issue and start a discussion so we can agree on a direction before you invest a large amount of time.
- **DO** read our [voice and tone](voice-tone.md) guidelines.
- **DO** use our [template](template.md) file as the starting point of your work. 
- **DO** create a separate branch before working on your article. 
- **DO** blog and tweet (or whatever) about your contributions, frequently!
- **DON'T** update or `merge` your branch after you submit your PR.

## Building the docs ##

The documentation is built using Open Publishing, [DocFX](http://dotnet.github.io/docfx/) and
[Markdown](https://daringfireball.net/projects/markdown/syntax). It is hosted at [https://docs.microsoft.com/dotnet](https://docs.microsoft.com/dotnet). 

To build the docs locally, you will need to install [DocFX](https://dotnet.github.io/docfx/); latest versions are the best.

There are several ways to use DocFX, and most of them are covered in the DocFX [getting started guide](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html). 
This small guide will use the [command-line based](https://dotnet.github.io/docfx/tutorial/docfx_getting_started.html#2-use-docfx-as-a-command-line-tool) version of the tool. 
If you are comfortable with other ways listed on the link above, feel free to use those. 

**Note:** please note that as of now, DocFX requires the .NET Framework on Windows or Mono for Linux or macOS. We will be working towards porting it to .NET Core in the future. 

The conceptual documentation is placed in the docs folder in the root of the repo so most of the work will happen there. 

You can build and preview the resulting site locally using a built-in web server.

	docfx core-docs\docfx.json --serve
	
This will start the local preview on [localhost:8080](http://localhost:8080). You can then view the changes by going to http://localhost:8080/docs/[path] (for example, http://localhost:8080/docs/about/).

**Note:** the local preview currently doesn't contain any themes at the moment so the look and feel won't be the same as in our site. We're working towards fixing that experience.

## Contributing to samples

See the [Samples Readme](https://github.com/dotnet/core-docs/blob/master/samples/README.md).

##Contributor License Agreement

You must sign a [.NET Foundation Contribution License Agreement (CLA)](http://cla2.dotnetfoundation.org) before your PR will be merged. This a one-time requirement for projects in the .NET Foundation. You can read more about [Contribution License Agreements (CLA)](http://en.wikipedia.org/wiki/Contributor_License_Agreement) on Wikipedia.

Signing the CLA is super simple and can be done in less than a minute.

You don't have to do this up-front. You can simply clone, fork, and submit your PR as usual. When your PR is created, it is classified by a CLA bot. If the change is trivial (for example, you just fixed a typo), then the PR is labeled with `cla-not-required`; otherwise, it's classified as `cla-required`. Once you signed a CLA, the current and all future pull-requests will be labeled as `cla-signed`.