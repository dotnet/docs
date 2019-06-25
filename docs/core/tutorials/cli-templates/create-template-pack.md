---
title: Create a template pack for dotnet new
description: Learn how to create a csproj file that will build a template pack for the dotnet new command.
author: thraka
ms.date: 06/25/2019
ms.topic: tutorial
---

# Tutorial: Create a template pack

With .NET Core, you can create and deploy templates that generate projects, files, even resources. This tutorial is part three of a series that teaches you how to create, install, and uninstall, templates for use with the `dotnet new` command.

In this part of the series you'll learn how to:

> [!div class="checklist"]
> * Create a _.csproj* project to build a template pack
> * Configure the project file for packing
> * Install a template from a NuGet package
> * Uninstall a template by package ID

## Prerequisites

If you have already completed [part 2](create-item-template.md) of this tutorial series, you can skip this section. Just remember to open a terminal and navigate to the _working\\_ folder.

* Install the [.NET Core 2.2 SDK](https://www.microsoft.com/net/core) or later.

* Create the "working folder" structure used by this tutorial.

  Create a new working folder to contain your work during this tutorial. This tutorial will refer to that folder as the _working_ folder. This folder should have a single subfolder named _templates_.

  ```console
  working
  └───templates
  ```

* Additionally, create a temporary folder where you can test your templates. This tutorial will refer to that folder as the _test_ folder. This folder **shouldn't** be under the _working_ folder. As an example, you can create the _test_ folder as a sibling of the _working_ folder.

  ```console
  parent_folder
  ├───test
  └───working
      └───templates
  ```

* Read the reference article [Custom templates for dotnet new](../tools/custom-templates.md).

  The reference article explains the basics about templates and how they're put together. Some of this information will be reiterated here.

* Open a terminal and navigate to the _working\templates_ folder.
