---
title: Use Jupyter Notebooks
titleSuffix: .NET for Apache Spark
description: Use .NET for Apache Spark in interactive environments like Jupyter Notebook, Jupyter Lab, or Visual Studio Code (VS Code)
ms.author: luquinta
author: luisquintanilla
ms.date: 10/09/2020
ms.topic: conceptual
ms.custom: mvc, how-to
---

# Use .NET for Apache Spark in Jupyter Notebooks

In this article, you learn how to run .NET for Apache Spark jobs interactively in Jupyter Notebook and Visual Studio Code (VS Code) with .NET Interactive.

## About Jupyter

[Jupyter](https://jupyter.org/) is an open-source, cross-platform computing environment that provides a way for users to prototype and develop applications interactively. You can interact with Jupyter through a wide variety of interfaces such as Jupyter Notebook, Jupyter Lab, and VS Code.

In the context of .NET, [.NET Interactive](https://github.com/dotnet/interactive), a .NET Core global tool, provides a kernel for writing .NET code (C#/F#) in interactive computing environments such as Jupyter Notebook.

## Prerequisites

- [.NET Core 3.1 SDK](../../core/install/index.yml)
- [Apache Spark](https://spark.apache.org/downloads.html)
- [Apache Spark .NET Worker](https://github.com/dotnet/spark/releases)

See the [getting started tutorial](../tutorials/get-started.md) for more information on setting up your .NET for Apache Spark environment.

## Prepare environment

To work with Jupyter Notebooks, you'll need two things.

1. Install the [.NET Interactive global .NET tool](https://github.com/dotnet/interactive/blob/main/docs/NotebookswithJupyter.md)
1. Download the `Microsoft.Spark` NuGet package.
    1. Navigate to the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) NuGet package page.

        > [!IMPORTANT]
        > By default, the latest version of the package is downloaded. **Make sure that the version you download is the same as your Apache Spark .NET Worker.**

    1. In the **Info** pane, select **Download package** to download the latest version of the package. The name of the package is similar to  *microsoft.spark.[PACKAGE-VERSION].nupkg*.
    1. Unzip the downloaded package. The unzipped directory should contain a subdirectory called *jars*. Take note of the path since it's used at a later time.

## Start .NET for Apache Spark

Run the following command to start .NET for Apache Spark in debug mode. This `spark-submit` command starts a process and waits for connections from a [SparkSession](xref:Microsoft.Spark.Sql.SparkSession). Make sure to provide the path to the `microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar` for the respective version of .NET for Apache Spark you're using.

**Ubuntu**

```bash
spark-submit \
    --class org.apache.spark.deploy.dotnet.DotnetRunner \
    --master local \
    <path-to-microsoft-spark-jar> \
    debug
```

**Windows**

```cmd
spark-submit ^
    --class org.apache.spark.deploy.dotnet.DotnetRunner ^
    --master local ^
    <path-to-microsoft-spark-jar> ^
    debug
```

## Create a notebook

You can use different interfaces to interact with Jupyter. For a browser-based interface, use Jupyter Notebooks or Jupyter Lab. For a local editor experience, use VS Code.

### Jupyter Notebooks & Jupyter Lab

1. In another command prompt, start Jupyter Notebook or Jupyter Lab using one of the commands below:

    **Jupyter Notebook**

    ```bash
    jupyter notebook
    ```

    **Jupyter Lab**

    ```bash
    jupyter lab
    ```

    These commands launch a browser window with the Jupyter Notebook or Jupyter Lab interface.

1. In the browser, create a new notebook.

    **Jupyter Notebook**

    Select **New > .NET (C#)** or **New > .NET (F#)**

    **Jupyter Lab**

    In the Launcher window, select **.NET (C#)** or **.NET (F#)**

### Visual Studio Code (preview)

> [!IMPORTANT]
> To use Jupyter Notebooks in VS Code, you have to install:
>
>- [VS Code Insiders](https://code.visualstudio.com/insiders/)
>- [.NET Interactive Notebooks extension](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.dotnet-interactive-vscode)

1. Open VS Code.
1. Open the command palette **View > Command Palette**.

    When the command palette appears, enter the following command to create a new .NET Interactive notebook:

    ```text
    >.NET Interactive: Create new blank notebook
    ```

    Alternatively, if you want to open an existing .NET Interactive notebook with the *.ipynb* extension, use the following command:

    ```text
    >.NET Interactive: Open notebook
    ```

## Initialize a Spark Session

1. When the notebook opens, install the `Microsoft.Spark` NuGet package. Make sure the version you install is the same as the .NET Worker.

    ```text
    #r "nuget:Microsoft.Spark, 1.0.0"
    ```

1. Add the following using statement to the notebook.

    ```csharp
    using Microsoft.Spark.Sql;
    ```

1. Initialize your [SparkSession](xref:Microsoft.Spark.Sql.SparkSession).

    ```csharp
    var sparkSession =
    SparkSession
        .Builder()
        .AppName("dotnet-interactive-spark")
        .GetOrCreate();
    ```

The notebook should look similar to the one in the following image. This example uses VS Code, but Jupyter Notebook and Jupyter Lab should look about the same.

> [!div class="mx-imgBorder"]
![.NET for Apache Spark Jupyter Notebook VS Code](media/dotnet-spark-jupyter-notebooks/jupyter-notebooks-dotnet-spark-vscode.png)

## Next Steps

- [Get started with .NET for Apache Spark](../tutorials/get-started.md)
- [Predict sentiment using .NET for Apache Spark and ML.NET](../tutorials/ml-sentiment-analysis.md)
- For more information on .NET Interactive, see the [.NET Interactive documentation](https://github.com/dotnet/interactive/blob/main/docs/README.md).
