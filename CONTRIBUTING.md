Contributing
======

The documentation is built using [Sphinx](http://sphinx-doc.org) and
[reStructuredText](http://sphinx-doc.org/rest.html), and then hosted by
[ReadTheDocs](http://dotnet.readthedocs.org).

## Building the Docs

To build the docs, you will need to install
[python](https://www.python.org/downloads/) (version 2). If you are
running Windows, you will want to add the Python install folder and the
\Scripts\ folder to your `PATH` environment variable.

To install Sphinx, open a command prompt and run:

	pip install sphinx

This may take a few minutes.

This project is also using a custom theme from ReadTheDocs, which you can
install with:

	pip install sphinx_rtd_theme

Note that later if you wish to update your current, installed version of this
theme, you should run:

	pip install -U sphinx_rtd_theme

You should now be able to navigate to the `docs` folder and run

	make html

which should generate the documentation in the _build folder. Open the
_build/html/index.html file to view the generated documentation.

If contributing new documentation content, please review:

- the [Sphinx Style Guide](http://documentation-style-guide-sphinx.readthedocs.org/en/latest/style-guide.html)

## Adding Content ##

Before adding content, submit an issue with a suggestion for your proposed
article. Provide detail on what the article would discuss, and how it would
relate to existing documentation.

Articles should be organized into logical groups or sections. Each section
should be given a named folder (e.g. /yourfirst). That section contains the
rst files for all articles in the section. For images and other static
resources, create a subfolder that matches the name of the article. Within this
subfolder, create a ``sample`` folder for code samples and a  ``_static`` folder
 for images and other static content.

### Example Structure ###

	docs
		/concepts
    /getting-started
    /porting
      /_static
        portability_report.png
					...
**Note:** Sphinx will automatically fix duplicate image names. There is no need
to try to ensure uniqueness of static files beyond an individual article.

Author information is kept in _authors.txt_ file in the docs folder. The authors
 should be specified by a name and a link to the author's GitHub profile.

## Process for Contributing ##

**Step 1:** Open an Issue describing the article you wish to write and how it
relates to existing content. Get approval to write your article.

**Step 2:** Fork the `/dotnet/core-docs` repo.

**Step 3:** Create a `branch` for your article.

**Step 4:** Write your article, placing the article in its own folder and any
needed images in a _static folder located in the same folder as the article.
Be sure to follow the proper reStructuredText syntax. If you have code samples,
place them in a folder within the `/samples/` folder.

**Step 5:** Submit a Pull Request from your branch to `dotnet/core-docs/master`.

**Step 6:** Discuss the Pull Request with the .NET team; make any requested
updates to your branch. When they are ready to accept the PR, they will add a
"LGTM" (Looks Good To Me) comment and any other steps that are (maybe) needed.

## Guidance Checklist ##

Below is a short list of guiding rules that you should keep in mind when you are
contributing to .NET Core documentation.

- Don't forget to submit an issue before starting work on an article
- Don't forget to create a separate branch before working on your article
- Don't update or `merge` your branch after you submit your pull request
- If updating code samples in `/samples/`, be sure any line number references
	in your article remain correct

## Contributing to Samples

Samples should be:

1. Individual, buildable, and runnable Console apps
2. Fully cross-platform and not dependent on Windows or Visual Studio
3. Tested using Xunit with the Xunit commandline test runner

People should be able to download, build, run, and test the samples on Mac, Linux, or Windows.

To learn about how to build and test new sample projects, see the .NET Class Library Manual (LINK NEEDED).

Sample projects are also broken up by language.  Here is an example general structure:

```
/samples
   /concept-to-sample
      /csharp
         global.json
         /src
            File1.cs
            project.json
         /test
            Test1.cs
            project.json
      /vb
      /fsharp
```

When readying a sample project, please verify that it is runnable and testable.  To do this, target `dnxcore50` in your `project.json` file for both your project and test project.  The sample should be run with the `dnx run` command and tested with the `dnx test` command.
