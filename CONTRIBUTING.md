Contributing
============

In this document: 

* [Adding content](#adding-content)
* [Process for contributing](#process-for-contributing) 
* [Guidance checklist](#guidance-checklist)
* [Building the docs](#building-the-docs)
* [Contributing to samples](#contributing-to-samples)

## Adding content ##

Before adding content, please submit an issue describing your content proposal. For smaller changes or additions, feel free to make a pull request.

Articles should be organized into logical groups or sections. Each section
should be given a named folder (e.g. /yourfirst). That section contains the
Markdown files for all articles in the section. For images and other static
resources, create a subfolder that matches the name of the article. Within this
subfolder, create a ``sample`` folder for code samples and a  ``_static`` folder
 for images and other static content.

### Example structure ###

    docs
      /concepts
      /getting-started
      /porting
        /_static
          portability_report.png
	  ...

Author information is kept in the Markdown file itself. Each author should have a link to an online presence for himself/herself. 

## Process for contributing ##

**Step 1:** Open an Issue describing the article you wish to write and how it
relates to existing content. Get approval to write your article.

**Step 2:** Fork the `/dotnet/core-docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article, placing the article in its own folder and any
needed images in a _static folder located in the same folder as the article.
Be sure to follow the proper Markdown syntax. If you have code samples,
place them in a folder within the `/samples/` folder.  For writing guidelines, see
[our style guide](/styleguide.md). Also do not forget to remove the "wrench" icon 
(🔧) from the TOC and the file heading, if applicable. 

**Step 5:** Submit a Pull Request from your branch to `dotnet/core-docs/master`.

**Step 6:** Discuss the Pull Request with the .NET team; make any requested
updates to your branch. When they are ready to accept the PR, they will add a
"LGTM" (Looks Good To Me) comment and any other steps that are (maybe) needed.

## Guidance checklist ##

Below is a short list of guiding rules that you should keep in mind when you are
contributing to .NET Core documentation.

- Don't forget to submit an issue before starting work on an article
- Don't forget to create a separate branch before working on your article
- Don't update or `merge` your branch after you submit your pull request
- If updating code samples in `/samples/`, be sure any line number references
	in your article remain correct

## Building the docs ##

The documentation is built using [docfx](http://dotnet.github.io/docfx/) and
[Markdown](https://daringfireball.net/projects/markdown/syntax). It is hosted on the [.NET Core](http://dotnet.github.io/) website. 

To build the docs, you will need to install
[docfx](http://dotnet.github.io/docfx/); latest versions are the best. 

There are several ways to use docfx, and most of them are covered in the docfx [getting started guide](http://aspnet.github.io/docfx/tutorial/docfx_getting_started.html). This small guide will use the [DNX-based](http://aspnet.github.io/docfx/tutorial/docfx_getting_started.html#use-docfx-under-dnx) version of the tool to be able to invoke it from the command line; if you are comfortable with other ways listed on the link above, feel free to use those. 

**Note:** please note that as of now, docfx requires the full .NET Framework (Windows) or Mono (Linux/OSX). We will be working towards porting it to .NET Core in the future. 

The conceptual documentation is placed in the docs folder in the root of the repo so most of the work will happen there. 

Using the DNX-based docfx tool, you build the resulting 

	docfx build
	
After build completes, you can preview the resulting site locally using built-in web server.

	docfx serve _site
	
This will start the local preview on localhost:8080. You can then view the changes by going to http://localhost:8080/docs/[path] (e.g. http://localhost:8080/docs/getting-started/).   

## Contributing to samples

See the [Samples Readme](https://github.com/dotnet/core-docs/blob/master/samples/README.md).
