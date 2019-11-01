---
title: Get started with .NET for Apache Spark
description: Discover how to run a .NET for Apache Spark app using .NET Core on Windows.
ms.date: 06/27/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to write a simple custom application using .NET for Apache Spark.
---

# Tutorial: Get started with .NET for Apache Spark

This tutorial teaches you how to run a .NET for Apache Spark app using .NET Core on Windows.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Prepare your Windows environment for .NET for Apache Spark
> * Download the **Microsoft.Spark.Worker**
> * Build and run a simple .NET for Apache Spark application

## Prepare your environment

Before you begin, make sure you can run `dotnet`, `java`, `mvn`, `spark-shell` from your command line. If your environment is already prepared, you can skip to the next section. If you cannot run any or all of the commands, follow the steps below.

1. Download and install the [.NET Core 2.1x SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1). Installing the SDK adds the `dotnet` toolchain to your PATH. Use the PowerShell command `dotnet --version` to verify the installation.

2. Install [Visual Studio 2017](https://www.visualstudio.com/downloads/) or [Visual Studio 2019](https://visualstudio.microsoft.com/vs/preview/) with the latest updates. You can use Community, Professional, or Enterprise. The Community version is free.

   Choose the following workloads during installation:
      * .NET desktop development
          * All required components
          * .NET Framework 4.6.1 Development Tools
      * .NET Core cross-platform development
          * All required components

3. Install [Java 1.8](https://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html).

    * Select the appropriate version for your operating system. For example, select **jdk-8u201-windows-x64.exe** for a Windows x64 machine.
    * Use the PowerShell command `java -version` to verify the installation.

4. Install [Apache Maven 3.6.0+](https://maven.apache.org/download.cgi).
    * Download [Apache Maven 3.6.2](http://mirror.metrocast.net/apache/maven/maven-3/3.6.2/binaries/apache-maven-3.6.2-bin.zip).
    * Extract to a local directory. For example, `c:\bin\apache-maven-3.6.2\`.
    * Add Apache Maven to your [PATH environment variable](https://www.java.com/en/download/help/path.xml). If you extracted to `c:\bin\apache-maven-3.6.2\`, you would add `c:\bin\apache-maven-3.6.2\bin` to your PATH.
    * Use the PowerShell command `mvn -version` to verify the installation.

5. Install [Apache Spark 2.3+](https://spark.apache.org/downloads.html). Apache Spark 2.4+ isn't supported.
    * Download [Apache Spark 2.3+](https://spark.apache.org/downloads.html) and extract it into a local folder using a tool like [7-zip](https://www.7-zip.org/) or [WinZip](https://www.winzip.com/). For example, you might extract it to `c:\bin\spark-2.3.2-bin-hadoop2.7\`.
    * Add Apache Spark to your [PATH environment variable](https://www.java.com/en/download/help/path.xml). If you extracted to `c:\bin\spark-2.3.2-bin-hadoop2.7\`, you would add `c:\bin\spark-2.3.2-bin-hadoop2.7\bin` to your PATH.
    * Add a [new environment variable](https://www.java.com/en/download/help/path.xml) called `SPARK_HOME`. If you extracted to `C:\bin\spark-2.3.2-bin-hadoop2.7\`, use  `C:\bin\spark-2.3.2-bin-hadoop2.7\` for the **Variable value**.
    * Verify you are able to run `spark-shell` from your command line.

6. Set up [WinUtils](https://github.com/steveloughran/winutils).
    * Download the **winutils.exe** binary from [WinUtils repository](https://github.com/steveloughran/winutils). Select the version of Hadoop the Spark distribution was compiled with. For example, you use **hadoop-2.7.1** for **Spark 2.3.2**. The Hadoop version is annotated at the end of your Spark install folder name.
    * Save the **winutils.exe** binary to a directory of your choice. For example, `c:\hadoop\bin`.
    * Set `HADOOP_HOME` to reflect the directory with **winutils.exe** without `bin`. For example, `c:\hadoop`.
    * Set the PATH environment variable to include `%HADOOP_HOME%\bin`.

Double check that you can run `dotnet`, `java`, `mvn`, `spark-shell` from your command line before you move to the next section.

## Download the Microsoft.Spark.Worker release

1. Download the [Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases) release from the .NET for Apache Spark GitHub Releases page to your local machine. For example, you might download it to the path, `c:\bin\Microsoft.Spark.Worker\`.

2. Create a [new environment variable](https://www.java.com/en/download/help/path.xml) called `DOTNET_WORKER_DIR` and set it to the directory where you downloaded and extracted the **Microsoft.Spark.Worker**. For example, `c:\bin\Microsoft.Spark.Worker`.

## Clone the .NET for Apache Spark GitHub repo

Use the following [GitBash](https://gitforwindows.org/) command to clone the .NET for Apache Spark repo to your machine.

```bash
git clone https://github.com/dotnet/spark.git c:\github\dotnet-spark
```

## Write a .NET for Apache Spark app

1. Open **Visual Studio** and navigate to **File > Create New Project > Console App (.NET Core)**. Name the application **HelloSpark**.

2. Install the [Microsoft.Spark NuGet package](https://www.nuget.org/profiles/spark). For more information on installing NuGet packages, see [Different ways to install a NuGet Package](https://docs.microsoft.com/nuget/consume-packages/ways-to-install-a-package).

3. In **Solution Explorer**, open **Program.cs** and write the following C# code:

   ```csharp
     var spark = SparkSession.Builder().GetOrCreate();
     var df = spark.Read().Json("people.json");
     df.Show();
   ```

4. Build the solution.

## Run your .NET for Apache Spark app

1. Open **PowerShell** and change the directory to the folder where your app is stored.

   ```powershell
   cd <your-app-output-directory>
   ```

2. Create a file called **people.json** with the following content:

   ```json
   {"name":"Michael"}
   {"name":"Andy", "age":30}
   {"name":"Justin", "age":19}
   ```

3. Use the following PowerShell command to run your app:

   ```powershell
    spark-submit `
    --class org.apache.spark.deploy.dotnet.DotnetRunner `
    --master local `
    microsoft-spark-2.4.x-<version>.jar `
    dotnet HelloSpark.dll
    ```

Congratulations! You successfully authored and ran a .NET for Apache Spark app.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> * Prepare your Windows environment for .NET for Apache Spark
> * Download the **Microsoft.Spark.Worker**
> * Build and run a simple .NET for Apache Spark application

Check out the resources page to learn more.
> [!div class="nextstepaction"]
> [.NET for Apache Spark Resources](../resources/index.md)
