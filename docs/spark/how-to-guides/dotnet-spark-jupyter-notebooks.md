---
title: Run Jupyter Notebooks locally
titleSuffix: .NET for Apache Spark
description: Run .NET for Apache Spark in Jupyter Notebooks and Visual Studio Code
ms.author: luquinta
author: luisquintanilla
ms.date: 10/08/2020
ms.topic: conceptual
ms.custom: mvc, how-to
---

# Run .NET for Apache Spark in Jupyter Notebooks locally

In this article, you learn how to run .NET for Apache Spark jobs in Jupyter Notebooks on your local computing environment.

## About Jupyter

[Jupyter](https://jupyter.org/) is an open-source, cross-platform computing environment that provides a way for users to prototype and develop applications interactively. You can interact with Jupyter through a wide variety of interfaces such as Jupyter Notebooks, Jupyter Lab, and Visual Studio Code.

In the context of .NET, [.NET Interactive](https://github.com/dotnet/interactive), a .NET Core global tool, provides a kernel for writing .NET code (C#/F#) in interactive computing environments such as Jupyter Notebooks.

## Prerequisites

- [.NET Core 3.1 SDK](https://docs.microsoft.com/dotnet/core/install/)
- Apache Spark
- Apache Spark .NET Worker

See the [getting started tutorial](../tutorials/get-started.md) for more information on setting up your .NET for Apache Spark environment.

## Prepare .NET Interactive environment

To work with Jupyter Notebooks, you'll need two things.

1. Install [.NET Interactive global .NET tool](https://github.com/dotnet/interactive/blob/main/docs/NotebooksLocalExperience.md)
1. Download `Microsoft.Spark` NuGet package.
    1. Navigate to the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) NuGet package page.

        > [!IMPORTANT]
        > By default, the latest version of the package is downloaded. **Make sure that the version you download is the same as your Apache Spark .NET Worker.**

    1. In the **Info** pane, select **Download package**. Doing so downloads the latest version of the package to a file with a name similar to  *microsoft.spark.[PACKAGE-VERSION].nupkg*.
    1. Unzip the recently downloaded package. The unzipped directory should contain a subdirectory called *jars*. Take note of the path since it's used at a later time.

## Start .NET for Apache Spark in debug mode

Start .NET for Apache Spark in debug mode. This will will set up a process that will wait for connections from a [SparkSession](xref:Microsoft.Spark.Sql.SparkSession). Make sure to provide the path to the jar for the respective version of Apache Spark you're using.

```bash
spark-submit \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  <path-to-microsoft-spark-jar> \
  debug
```

## Start Jupyter

You can use different interfaces to interact with Jupyter. For a browser-based interface, use Jupyter Notebooks or Jupyter Lab. For a local editor experience, use Visual Studio Code.

### Jupyter Notebooks & Jupyter lab

1. In another command prompt, start Jupyter Notebook or Jupyter Lab use one of the commands below:

    **Jupyter Notebook**

    ```bash
    jupyter notebook
    ```

    **Jupyter Lab**

    ```bash
    jupyter lab
    ```

1. Create a new .NET Interactive notebook.
1. When the notebook opens, write and execute your code in the notebook cells.

### Visual Studio Code (preview)

> [!IMPORTANT]
> To use Jupyter Notebooks in Visual Studio Code, you have to install:
>    - [Visual Studio Code Insiders](https://code.visualstudio.com/insiders/) 
>    - [.NET Interactive Notebooks extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)

1. Open Visual Studio Code
1. Open the command palette **View > Command Palette**

    The command palette appears. Enter the following command to create a new .NET Interactive notebook:

    ```text
    .NET Interactive: Create new blank notebook
    ```

    Alternatively, if you want to open an existing .NET Interactive notebook with the *.ipynb* extension, use the following command:

    ```text
    .NET Interactive: Open notebook
    ```

1. When the notebook opens, write and execute your code in the notebook cells.

## Next Steps

- [Get started with .NET for Apache Spark](../tutorials/get-started.md)
- [Predict sentiment using .NET for Apache Spark and ML.NET](../tutorials/ml-sentiment-analysis.md)
- For more information on .NET Interactive, see the [.NET Interactive documentation](https://github.com/dotnet/interactive/blob/main/docs/README.md).