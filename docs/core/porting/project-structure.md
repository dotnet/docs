# Organizing Your Project to Support .NET Framework and .NET Core

This article is to help project owners who want to compile their solution against .NET Framework and .NET Code side-by-side.  It provides several options to organize projects to help developers achieve this goal.

## General Guidance

1.  Create an xproj that targets multiple frameworks.
    * Scenario is described [here](#replace-existing-projects-with-a-multi-targeted-net-core-project-xproj)
2.  For projects that use complex logic in their build process, create a Portable Class Library (PCL) that targets .NET Core.
    * Scenario is described [here](#create-a-portable-class-library-pcl-to-target-net-core)

These are general rules for organizing your project. The scenarios below outline a few variations that can be made based on what fits your repository best.

## Example

Consider the repository below:

![][example-initial-project]

[**Source Code**][example-initial-project-code]

There are several different ways to add support for .NET Core for this repository depending on the constraints and complexity of existing projects which are described below.

### Replace Existing Projects with a Multi-targeted .NET Core Project (xproj)

The repository can be re-organized so that any existing *.csproj are removed and a single *.xproj is created that targets multiple frameworks.  This is a great option because a single project is able to compile for different frameworks.  It also has the power to handle different compilation options, dependencies, etc. per targeted framework.

![][example-xproj]

[**Source Code**][example-xproj-code]

Changes to note are:
* Addition of `global.json`
* Replacement of `packages.config` and `*.csproj` with `project.json` and `*.xproj`
* Changes in the [Car's project.json][example-xproj-projectjson] and its [test project][example-xproj-projectjson-test] to support building for the existing .NET Framework as well as others

### Create a Portable Class Library (PCL) to target .NET Core

If existing projects contain complex build operations or properties in their *.csproj, it may be easier to create a PCL.

![][example-pcl]

[**Source Code**][example-pcl-code]

Changes to note are:
*  Renaming `project.json` to `{project-name}.project.json`
    * This prevents potential conflict in Visual Studio when trying to restore packages for the libraries in the same directory
    * [Documentation is here](https://docs.nuget.org/consume/nuget-faq) under "_I have multiple projects in the same folder, how can I use separate packages.config or project.json files for each project?_"
    *  __Alternative__: Create the PCL in another folder and reference the original source code to avoid this issue
*  To target .NET Standard after creating the PCL, open the __Project's Properties__. Under the __Targets__ section, click on the link __"Target .NET Platform Standard"__.  This change can be reversed by repeating the same steps.

### Keep Existing Projects and Create a .NET Core Project

If there are existing projects that target older frameworks, developers may want to leave these projects untouched and use a .NET Core project to target future frameworks.

![][example-xproj-different-folder]

[**Source Code**][example-xproj-different-code]

Changes to note are:
* The .NET Core and existing projects are kept in separate folders.
    * This avoids the package restore issue that was mentioned above due to multiple project.json/package.config files being in the same folder.
    * Keeping projects in separate folders avoids forcing users to have Visual Studio 2015 (due to project.json).  Users can create a separate solution that only opens the old projects.

[sln-only-netcore-projects]: https://docs.microsoft.com/en-us/dotnet/articles/core/tutorials/using-on-windows#a-solution-using-only-net-core-projects

[example-initial-project]: _static/project.png "Existing project"
[example-initial-project-code]: ../../../samples/core-projects/libraries/migrate-library/

[example-xproj]: _static/project.xproj.png "Create an xproj that targets multiple frameworks"
[example-xproj-code]: ../../../samples/core-projects/libraries/migrate-library-xproj/
[example-xproj-projectjson]: ../../../samples/core-projects/libraries/migrate-library-xproj/src/Car/project.json
[example-xproj-projectjson-test]: ../../../samples/core-projects/libraries/migrate-library-xproj/tests/Car.Tests/project.json

[example-xproj-different-folder]: _static/project.xproj.different.png ".NET Core project with existing PCL in different folder"
[example-xproj-different-code]: ../../../samples/core-projects/libraries/migrate-library-xproj-keep-csproj/

[example-pcl]: _static/project.pcl.png "PCL Targeting .NET Core"
[example-pcl-code]: ../../../samples/core-projects/libraries/migrate-library-pcl