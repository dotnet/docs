---
title: Batch processing with .NET for Apache Spark tutorial
description: Learn how to do batch processing using .NET for Apache Spark.
author: mamccrea
ms.author: mamccrea
ms.date: 10/09/2020
ms.topic: tutorial
recommendations: false
---

# Tutorial: Do batch processing with .NET for Apache Spark

In this tutorial, you learn how to do batch processing using .NET for Apache Spark. Batch processing is the transformation of data at rest, meaning that the source data has already been loaded into data storage.

Batch processing is generally performed over large, flat datasets that need to be prepared for further analysis. Log processing and data warehousing are common batch processing scenarios. In this scenario, you analyze information about GitHub projects, such as the number of time different projects have been forked or how recently projects have been updated.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Create and run a .NET for Apache Spark application
> * Read data into a DataFrame and prepare it for analysis
> * Process the data using Spark SQL

## Prerequisites

If this is your first time using .NET for Apache Spark, check out the [Get started with .NET for Apache Spark](get-started.md) tutorial to learn how to prepare your environment and run your first .NET for Apache Spark application.

## Download the sample data

[GHTorrent](http://ghtorrent.org/) monitors all public GitHub events, such as info about projects, commits, and watchers, and stores the events and their structure in databases. Data collected over different time periods is available as downloadable archives. Because the dump files are very large, this guide uses a [truncated version of the dump file](https://github.com/dotnet/spark/tree/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Batch/projects_smaller.csv) that can be downloaded from GitHub.

> [!NOTE]
> The GHTorrent dataset is distributed under a dual licensing scheme ([Creative Commons +](https://wiki.creativecommons.org/wiki/CCPlus)). For non-commercial uses (including, but not limited to, educational, research or personal uses), the dataset is distributed under the [CC-BY-SA license](https://creativecommons.org/licenses/by-sa/4.0/).

## Create a console application

1. In your command prompt, run the following commands to create a new console application:

   ```dotnetcli
   dotnet new console -o mySparkBatchApp
   cd mySparkBatchApp
   ```

   The `dotnet` command creates a `new` application of type `console` for you. The `-o` parameter creates a directory named *mySparkBatchApp* where your app is stored and populates it with the required files. The `cd mySparkBatchApp` command changes the directory to the app directory you just created.

1. To use .NET for Apache Spark in an app, install the Microsoft.Spark package. In your console, run the following command:

   ```dotnetcli
   dotnet add package Microsoft.Spark
   ```

## Create a SparkSession

1. Add the following additional `using` statements to the top of the *Program.cs* file in *mySparkBatchApp*.

   ```csharp
   using System;
   using Microsoft.Spark.Sql;
   using static Microsoft.Spark.Sql.Functions;
   ```

1. Add the following code to your project namespace. *s_referenceData* is used later in the program to filter based on date.

   ```csharp
   static readonly DateTime s_referenceDate = new DateTime(2015, 10, 20);
   ```

1. Add the following code inside your Main method to establish a new SparkSession. The SparkSession is the entry point to programming Spark with the Dataset and DataFrame API. By calling the `spark` object, you can access Spark and DataFrame functionality throughout your program.

   ```csharp
   SparkSession spark = SparkSession
        .Builder()
        .AppName("GitHub and Spark Batch")
        .GetOrCreate();
   ```

## Prepare the data

1. Read the input file into a `DataFrame`, which is a distributed collection of data organized into named columns. You can set the columns for your data through <xref:Microsoft.Spark.Sql.DataFrame.Schema%2A>. Use the <xref:Microsoft.Spark.Sql.DataFrame.Show%2A> method to display the data in your DataFrame. Be sure to update the CSV file path to the location of the GitHub data you downloaded.

   ```csharp
   DataFrame projectsDf = spark
       .Read()
       .Schema("id INT, url STRING, owner_id INT, " +
       "name STRING, descriptor STRING, language STRING, " +
       "created_at STRING, forked_from INT, deleted STRING," +
       "updated_at STRING")
       .Csv("filepath");

   projectsDf.Show();
   ```

1. Use the <xref:Microsoft.Spark.Sql.DataFrame.Na%2A> method to drop rows with NA (null) values, and the <xref:Microsoft.Spark.Sql.DataFrame.Drop%2A> method to remove certain columns from your data. This helps prevent errors if you try to analyze null data or columns that are not relevant to your final analysis.

   ```csharp
   // Drop any rows with NA values
   DataFrameNaFunctions dropEmptyProjects = projectsDf.Na();
   DataFrame cleanedProjects = dropEmptyProjects.Drop("any");

   // Remove unnecessary columns
   cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");
   cleanedProjects.Show();
   ```

## Analyze the data

Spark SQL allows you to make SQL calls on your data. It's common to combine user-defined functions and Spark SQL to apply a user-defined function to all rows of your DataFrame.

You can specifically call `spark.Sql` to mimic standard SQL calls seen in other types of apps. You can also call methods like <xref:Microsoft.Spark.Sql.DataFrame.GroupBy%2A> and <xref:Microsoft.Spark.Sql.DataFrame.Agg%2A> to specifically combine, filter, and perform calculations on your data.

The goal of this app is to gain some insights about the GitHub projects data. Add the following code snippets to your program to analyze the data.

1. Add the following block of code finds the number of times each language has been forked. First, the data is grouped by language. Then, the average number of forks from each language is taken.

   ```csharp
   // Average number of times each language has been forked
   DataFrame groupedDF = cleanedProjects
       .GroupBy("language")
       .Agg(Avg(cleanedProjects["forked_from"]));
   ```

1. Add the following block of code to order the average number of forks in descending order to see which languages are the most forked. That is, the largest number of forks will appear first.

   ```csharp
   // Sort by most forked languages first
   groupedDF.OrderBy(Desc("avg(forked_from)")).Show();
   ```

1. The next block of code shows you how recently projects have been updated. You register a new user-defined function called *MyUDF* and compare it with a date, *s_referenceDate*, which was declared at the beginning of the tutorial. The date for each project is compared against the reference date. Then, Spark SQL is used to call the UDF on each row of the data to analyze each project in the data set.

   ```csharp
   spark.Udf().Register<string, bool>(
       "MyUDF",
       (date) => DateTime.TryParse(date, out DateTime convertedDate) &&
           (convertedDate > s_referenceDate));
   cleanedProjects.CreateOrReplaceTempView("dateView");

   DataFrame dateDf = spark.Sql(
       "SELECT *, MyUDF(dateView.updated_at) AS datebefore FROM dateView");
   dateDf.Show();
   ```

1. Call `spark.Stop()` to end the SparkSession.

## Use spark-submit to run your app

1. Use the following command to build your .NET app:

   ```dotnetcli
   dotnet build
   ```

1. Run your app with `spark-submit`. Be sure to update the following command with the actual paths to your Microsoft Spark jar file.

   ```console
   spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local /<path>/to/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar dotnet /<path>/to/netcoreapp<version>/mySparkBatchApp.dll
   ```

## Get the code

You can see the [full solution](https://github.com/dotnet/spark/blob/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Batch/GitHubProjects.cs) on GitHub.

## Next steps

Advance to the next article to learn how to process streaming data with .NET for Apache Spark.
> [!div class="nextstepaction"]
> [Tutorial: Structured Streaming with .NET for Apache Spark](streaming.md)
