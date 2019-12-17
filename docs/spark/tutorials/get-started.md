---
title: Get started with .NET for Apache Spark
description: Discover how to run a .NET for Apache Spark app using .NET Core on Windows.
ms.date: 11/04/2019
ms.topic: tutorial
ms.custom: mvc
# Customer intent: As a developer, I want to write a simple custom application using .NET for Apache Spark.
---

# Tutorial: Get started with .NET for Apache Spark

This tutorial teaches you how to run a .NET for Apache Spark app using .NET Core on Windows.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Prepare your Windows environment for .NET for Apache Spark
> * Write your first .NET for Apache Spark application
> * Build and run your simple .NET for Apache Spark application

## Prepare your environment

Before you begin writing your app, you need to set up some prerequisite dependencies. If you can run `dotnet`, `java`, `mvn`, `spark-shell` from your command line environment, then your environment is already prepared and you can skip to the next section. If you cannot run any or all of the commands, do the following steps.

### 1. Install .NET

To start building .NET apps, you need to download and install the .NET SDK (Software Development Kit).

Download and install the [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/3.0). Installing the SDK adds the `dotnet` toolchain to your PATH.

Once you've installed the .NET Core SDK, open a new command prompt and run `dotnet`.

If the command runs and prints out information about how to use dotnet, can move to the next step. If you receive a `'dotnet' is not recognized as an internal or external command` error, make sure you opened a **new** command prompt before running the command.

### 2. Install Java

Install [Java 8.1](https://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html).

Select the appropriate version for your operating system. For example, select **jdk-8u201-windows-x64.exe** for a Windows x64 machine. Then, use the command `java` to verify the installation.

![Java Download](https://dotnet.microsoft.com/static/images/java-jdk-downloads-windows.png?v=6BbJHoNyDO-PyYVciImr5wzh2AW_YHNcyb3p093AwPA)

### 3. Install 7-zip

Apache Spark is downloaded as a compressed .tgz file. Use an extraction program, like 7-zip, to extract the file.

* Visit [7-Zip downloads](https://www.7-zip.org/).
* In the first table on the page, select the 32-bit x86 or 64-bit x64 download, depending on your operating system.
* When the download completes, run the installer.

![7Zip Download](https://dotnet.microsoft.com/static/images/7-zip-downloads.png?v=W6qWtFC1tTMKv3YGXz7lBa9F3M22uWyTvkMmunyroNk)

### 4. Install Apache Spark

[Download and install Apache Spark](https://spark.apache.org/downloads.html). You'll need to select from version 2.3.* or 2.4.0, 2.4.1, 2.4.3, or 2.4.4 (.NET for Apache Spark is not compatible with other versions of Apache Spark).

The commands used in the following steps assume you have [downloaded and installed Apache Spark 2.4.1](https://archive.apache.org/dist/spark/spark-2.4.1/spark-2.4.1-bin-hadoop2.7.tgz). If you wish to use a different version, replace **2.4.1** with the appropriate version number. Then, extract the **.tar** file and the Apache Spark files.

To extract the nested **.tar** file:

* Locate the **spark-2.4.1-bin-hadoop2.7.tgz** file that you downloaded.
* Right click on the file and select **7-Zip -> Extract here**.
* **spark-2.4.1-bin-hadoop2.7.tar** is created alongside the **.tgz** file you downloaded.

To extract the Apache Spark files:

* Right click on **spark-2.4.1-bin-hadoop2.7.tar** and select **7-Zip -> Extract files...**
* Enter **C:\bin** in the **Extract to** field.
* Uncheck the checkbox below the **Extract to** field.
* Select **OK**.
* The Apache Spark files are extracted to C:\bin\spark-2.4.1-bin-hadoop2.7\

![Install Spark](https://dotnet.microsoft.com/static/images/spark-extract-with-7-zip.png?v=YvjUv54LIxI9FbALPC3h8zSQdyMtK2-NKbFOliG-f8M)

Run the following commands to set the environment variables used to locate Apache Spark:

```console
setx HADOOP_HOME C:\bin\spark-2.4.1-bin-hadoop2.7\
setx SPARK_HOME C:\bin\spark-2.4.1-bin-hadoop2.7\
```

Once you've installed everything and set your environment variables, open a **new** command prompt and run the following command:

`%SPARK_HOME%\bin\spark-submit --version`

If the command runs and prints version information, you can move to the next step.

If you receive a `'spark-submit' is not recognized as an internal or external command` error, make sure you opened a **new** command prompt.

### 5. Install .NET for Apache Spark

Download the [Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases) release from the .NET for Apache Spark GitHub. For example if you're on a Windows machine and plan to use .NET Core, [download the Windows x64 netcoreapp2.1 release](https://github.com/dotnet/spark/releases/download/v0.5.0/Microsoft.Spark.Worker.netcoreapp2.1.win-x64-0.6.0.zip).

To extract the Microsoft.Spark.Worker:

* Locate the **Microsoft.Spark.Worker.netcoreapp2.1.win-x64-0.6.0.zip** file that you downloaded.
* Right click and select **7-Zip -> Extract files...**.
* Enter **C:\bin** in the **Extract to** field.
* Uncheck the checkbox below the **Extract to** field.
* Select **OK**.

![Install .NET Spark](https://dotnet.microsoft.com/static/images/dotnet-for-spark-extract-with-7-zip.png?v=jwCyum9mL0mGIi4V5zC7yuvLfcj1_nL-QFFD8TClhZk)

### 6. Install WinUtils

.NET for Apache Spark requires WinUtils to be installed alongside Apache Spark. [Download winutils.exe](https://github.com/steveloughran/winutils/blob/master/hadoop-2.7.1/bin/winutils.exe). Then, copy WinUtils into **C:\bin\spark-2.4.1-bin-hadoop2.7\bin**.

> [!NOTE]
> If you are using a different version of Hadoop, which is annotated at the end of your Spark install folder name, [select the version of WinUtils](https://github.com/steveloughran/winutils) that's compatible with your version of Hadoop.

### 7. Set DOTNET_WORKER_DIR and check dependencies

Run the following command to set the `DOTNET_WORKER_DIR` Environment Variable, which is used by .NET apps to locate .NET for Apache Spark:

`setx DOTNET_WORKER_DIR "C:\bin\Microsoft.Spark.Worker-0.6.0"`

Finally, double-check that you can run `dotnet`, `java`, `mvn`, `spark-shell` from your command line before you move to the next section.

## Write a .NET for Apache Spark app

### 1. Create a console app

In your command prompt, run the following commands to create a new console application:

```console
dotnet new console -o mySparkApp
cd mySparkApp
```

The `dotnet` command creates a `new` application of type `console` for you. The `-o` parameter creates a directory named *mySparkApp* where your app is stored and populates it with the required files. The `cd mySparkApp` command changes the directory to the app directory you just created.

### 2. Install NuGet package

To use .NET for Apache Spark in an app, install the Microsoft.Spark package. In your command prompt, run the following command:

`dotnet add package Microsoft.Spark --version 0.6.0`

### 3. Code your app

Open *Program.cs* in Visual Studio Code, or any text editor, and replace all of the code with the following:

```csharp
using Microsoft.Spark.Sql;

namespace MySparkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Spark session.
            var spark = SparkSession
                .Builder()
                .AppName("word_count_sample")
                .GetOrCreate();

            // Create initial DataFrame.
            DataFrame dataFrame = spark.Read().Text("input.txt");

            // Count words.
            var words = dataFrame
                .Select(Functions.Split(Functions.Col("value"), " ").Alias("words"))
                .Select(Functions.Explode(Functions.Col("words"))
                .Alias("word"))
                .GroupBy("word")
                .Count()
                .OrderBy(Functions.Col("count").Desc());

            // Show results.
            words.Show();

            // Stop Spark session.
            spark.Stop();
        }
    }
}
```

### 4. Add data file

Your app processes a file containing lines of text. Create an *input.txt* file in your *mySparkApp* directory, containing the following text:

```text
Hello World
This .NET app uses .NET for Apache Spark
This .NET app counts words with Apache Spark
```

## Run your .NET for Apache Spark app

1. Run the following command to build your application:

   ```dotnetcli
   dotnet build
   ```

2. Run the following command to submit your application to run on Apache Spark:

   ```powershell
   %SPARK_HOME%\bin\spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local bin\Debug\netcoreapp3.0\microsoft-spark-2.4.x-0.6.0.jar dotnet bin\Debug\netcoreapp3.0\mySparkApp.dll
   ```

3. When your app runs, the word count data of the *input.txt* file is written to the console.

Congratulations! You successfully authored and ran a .NET for Apache Spark app.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> * Prepare your Windows environment for .NET for Apache Spark
> * Write your first .NET for Apache Spark application
> * Build and run your simple .NET for Apache Spark application

To see a video explaining the steps above, checkout the [.NET for Apache Spark 101 video series](https://channel9.msdn.com/Series/NET-for-Apache-Spark-101/Run-Your-First-NET-for-Apache-Spark-App).

Check out the resources page to learn more.
> [!div class="nextstepaction"]
> [.NET for Apache Spark Resources](../resources/index.md)
