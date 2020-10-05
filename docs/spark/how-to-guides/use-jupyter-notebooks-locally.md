---
title: Run Jupyter Notebooks locally
desciption: Run .NET for Apache Spark in Jupyter Notebooks
titleSuffix: .NET for Apache Spark
ms.author: luquinta
author: luisquintanilla
ms.date: 10/05/2020
ms.topic: conceptual
ms.custom: mvc, how-to
---

# Run .NET for Apache Spark in Jupyter Notebooks locally

In this article, you learn how to run .NET for Apache Spark jobs in Jupyter Notebooks on your local PC.

## About Jupyter

[Jupyter](https://jupyter.org/) is an open-source, cross-platform computing environment that provides a way for users to prototype and develop applications alongside rich interactive output.

In the context of .NET, .NET Interactive, a .NET global tool, provides a kernel for writing .NET code in interactive computing environments.

## Prerequisites

- [.NET Core 3.1 SDK](https://docs.microsoft.com/dotnet/core/install/)
- Apache Spark
- Apache Spark .NET Worker

See the [getting started tutorial](../tutorials/get-started.md) for more information on setting up .NET for Apache Spark.

## Prepare .NET Interactive local environment

To work with Jupyter notebooks, you'll need two things.

1. Install [.NET Interactive global .NET tool](https://github.com/dotnet/interactive/blob/main/docs/NotebooksLocalExperience.md)
1. Download `Microsoft.Spark` NuGet package.
    1. Navigate to the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) package page on NuGet.

    > [!IMPORTANT]
    > By default, the latest version of the package is downloaded. **Make sure that the version you download is the same as your Apache Spark .NET Worker.**

    1. In the **Info** pane, select **Download package**. Doing so downloads the latest version of the package to a file with a name similar to  *microsoft.spark.<PACKAGE-VERSION>.nupkg*.
    1. Unzip the recently downloaded package. The unzipped directory should contain a subdirectory called *jars*. Take note of the path since it's used at a later time.

## Start .NET for Apache Spark in debug mode

1. Start .NET for Apache Spark in debug mode. Make sure to provide the path to the jar for the respective version of Apache Spark you're using.

```bash
spark-submit \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  <path-to-microsoft-spark-jar> \
  debug
```

## Jupyter Notebooks & Jupyter lab

1. In another command prompt, start Jupyter Notebook or Jupyter Lab.

```bash
jupyter notebook
```

```bash
jupyter lab
```

## Visual Studio Code (preview)

> [!IMPORTANT]
> To use Jupyter Notebooks, you have to install:
>    - [Visual Studio Code Insiders](https://code.visualstudio.com/insiders/) 
>    - [.NET Interactive Notebooks extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)

1. Open Visual Studio Code
1. Open the command palette **View > Command Palette**

    The command palette appears. Enter the following command.

    ```text
    .NET Interactive: Create new blank notebook
    ```

    Alternatively, if you want to open an existing .NET notebook with the *.ipynb* extension, use the following command:

    ```text
    .NET Interactive: Open notebook
    ```

1. Initialize your Spark Session
1. Write your code

## Next steps

- Connect to MongoDB
- Connect to Azure Data Storage
- Connect to SQL Server