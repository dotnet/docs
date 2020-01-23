---
title: Get started with .NET for Apache Spark on macOS
description: Discover how to run a .NET for Apache Spark app using .NET Core on MacOSX.
ms.date: 01/22/2019
ms.topic: tutorial
ms.custom: mvc
# Customer intent: As a developer, I want to write a simple custom application using .NET for Apache Spark on MacOSX.
---

# Tutorial: Get started with .NET for Apache Spark on macOS

This tutorial shows you how to run a .NET for Apache Spark app using .NET Core on macOS.

> [!div class="checklist"]
>
> * Prerequisites to run a .NET for Apache Spark application
> * Write a simple .NET for Apache Spark application
> * Build and run a .NET for Apache Spark application

## Prerequisites

- Download and install **[.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)** 
- Install **[Java 8](https://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html)** 
  - Select the appropriate version for your operating system, for example, `jdk-8u231-macosx-x64.dmg`.
  - Install using the installer and verify you are able to run `java` from the command line
- Download and install **[Apache Spark 2.4.4](https://archive.apache.org/dist/spark/spark-2.4.4/spark-2.4.4-bin-hadoop2.7.tgz)**:
  - Add the necessary environment variable SPARK_HOME with a value of, for example, *~/bin/spark-2.4.4-bin-hadoop2.7/*
  
    ```bash
    export SPARK_HOME=~/bin/spark-2.4.4-bin-hadoop2.7/
    export PATH="$SPARK_HOME/bin:$PATH"
    source ~/.bashrc
    ```
    
- Download and install **[Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases)** release:
  - Select a **[Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases)** release from .NET for Apache Spark GitHub Releases page and download into your local machine (for example, *~/bin/Microsoft.Spark.Worker/*).
  - **IMPORTANT** Create a new environment variable using ```export DOTNET_WORKER_DIR <your_path>``` and set it to the directory where you downloaded and extracted the Microsoft.Spark.Worker (for example, *~/bin/Microsoft.Spark.Worker/*).

## Author a .NET for Apache Spark app

1. Use the .NET Core CLI to create a console application.

    ```dotnetcli
    dotnet new console -o HelloSpark
    ```
    
1. Install the `Microsoft.Spark` NuGet package into the project from the [spark nuget.org feed](https://www.nuget.org/profiles/spark). For more information, see [Ways to install Nuget Package](https://docs.microsoft.com/nuget/consume-packages/ways-to-install-a-package).
    
    ```dotnetcli
    cd HelloSpark
    dotnet add package Microsoft.Spark
    ```
    
1. Replace the contents of the *Program.cs* file with the following code:
    
    ```csharp
    using Microsoft.Spark.Sql;

    namespace HelloSpark
    {
        class Program
        {
            static void Main(string[] args)
            {
                var spark = SparkSession.Builder().GetOrCreate();
                DataFrame df = spark.Read().Json("people.json");
                df.Show();
            }
        }
    }
    ```
    
1. Use the .NET Core CLI to build the application:
    
    ```dotnetcli
    dotnet build
    ```

## Run your .NET for Apache Spark app

1. Open your terminal and navigate into your app folder:
    
    ```bash
    cd <your-app-output-directory>
    ```
    
1. Create *people.json* with the following content:
    
    ```json
    { "name" : "Michael" }
    { "name" : "Andy", "age" : 30 }
    { "name" : "Justin", "age" : 19 }
    ```
    
1. Run the app.
    
    ```bash
    spark-submit \
    --class org.apache.spark.deploy.dotnet.DotnetRunner \
    --master local \
    microsoft-spark-2.4.x-<version>.jar \
    dotnet HelloSpark.dll 
    ```
    
    > [!NOTE]
    > This command assumes you have downloaded Apache Spark and added it to your PATH environment variable to be able to use `spark-submit`. Otherwise, you would have to use the full path (for example, `~/spark/bin/spark-submit`).
    
1. The output of the application should look similar to the following output:
    
    ```text
    +----+-------+
    | age|   name|
    +----+-------+
    |null|Michael|
    |  30|   Andy|
    |  19| Justin|
    +----+-------+
    ```
   
## Next steps

In this tutorial, you learned how to run your .NET for Apache Spark on macOS. Continue to learn more about how to run your .NET for Apache Spark on Windows and Ubuntu.
> [!div class="nextstepaction"]

> [!div class="nextstepaction"]
> [Tutorial: Get Started with .NET for Apache Spark on Windows](get-started-windows-instructions.md)

> [Tutorial: Get Started with .NET for Apache Spark on Ubuntu](get-started-ubuntu-instructions.md)
