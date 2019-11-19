---
title: How to do batch processing with .NET for Apache Spark
description: Learn how to do batch processing using .NET for Apache Spark.
ms.date: 11/14/2019
ms.topic: conceptual
ms.custom: mvc,how-to
---

# How to do batch processing with .NET for Apache Spark

This how-to shows you how to do batch processing using .NET for Apache Spark. If this is your first time using .NET for Apache Spark, check out the [Get started with .NET for Apache Spark](../tutorials/get-started.md) tutorial to learn how to prepare your environment and run your first .NET for Apache Spark application.

## What is batch processing?

Batch processing is the transformation of data at rest, meaning that the source data has already been loaded into data storage. Batch processing is generally performed over large, flat datasets that need to be prepared for further analysis. Log processing and data warehousing are common batch processing scenarios. 

## GitHub projects data example

The following steps demonstrate batch processing of GitHub projects data. 

[GHTorrent](http://ghtorrent.org/) monitors all public GitHub events, such as info about projects, commits, and watchers, and stores the events and their structure in databases. Data collected over different time periods is available as downloadable archives. Because the dump files are very large, this guide uses a [truncated version of the dump file](https://github.com/dotnet/spark/tree/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Batch/projects_smaller.csv) that can be downloaded from GitHub.

### Problem

The goal is to analyze information about GitHub projects. First, the data is prepped by removing null data and unnecessary columns. Then, further analysis is performed to discover the number of times different projects have been forked and how recently projects have been updated.

### Solution

The following steps walk you through how to process the GitHub projects data. You can see the [full solution](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Batch/GitHubProjects.cs) on GitHub.

1. Create a new .NET console app and add the `Microsft.Spark` NuGet package. Then, add the following using statements to your code.

   ```csharp
   using System;
   using Microsoft.Spark.Sql;
   using static Microsoft.Spark.Sql.Functions;
   ```

1. Add the following code to create a `s_referenceDate` variable and a `Run` function. The `Run` function takes the CSV file path as an argument.

   ```csharp
   // For later use when filtering based on date
   static readonly DateTime s_referenceDate = new DateTime(2015 10, 20);

   public void Run(string[] args)
   {
       if (args.Length != 1)
       {
            Console.Error.WriteLine("Usage: GitHubProjects <path to projects.csv>");
            Environment.Exit(1);
        }
    }
   ```

1. Inside the `Run` function, add the following code to establish a new SparkSession. The SparkSession is the entry point to programming Spark with the Dataset and DataFrame API. By calling the `spark` object, you can access Spark and DataFrame functionality throughout your program.

   ```csharp
   SparkSession spark = SparkSession
        .Builder()
        .AppName("GitHub and Spark Batch")
        .GetOrCreate();
   ```

1. Read the input file into a DataFrame, which is a distributed collection of data organized into named columns. You can set the columns for your data through `.Schema()`. Use `.Show()` to display the data in your DataFrame.

   ```csharp
   DataFrame projectsDf = spark
       .Read()
       .Schema("id INT, url STRING, owner_id INT, " +
       "name STRING, descriptor STRING, language STRING, " +
       "created_at STRING, forked_from INT, deleted STRING" +
       "updated_at STRING")
       .Csv(args[0]);

   projectsDf.Show();
   ```

1. Use `DataFrame.Na()` to drop rows with NA (null) values, and the `DataFrameNaFunctions.Drop()` method to remove certain columns from your data. This helps prevent errors if you try to analyze null data or columns that are not relevant to your final analysis.

   ```csharp
   // Drop any rows with NA values
   DataFrameNaFunctions dropEmptyProjects = projectsDf.Na();
   DataFrame cleanedProjects = dropEmptyProjects.Drop("any");

   // Remove unnecessary columns
   cleanedProjects = cleanedProjects.Drop("id", "url", "owner_id");
   cleanedProjects.Show();
   ```

1. Spark SQL allows you to make SQL calls on your data. It's common to combine user-defined functions and Spark SQL to apply a user-defined function to all rows of your DataFrame.

   You can specifically call `spark.Sql` to mimic standard SQL calls seen in other types of apps. You can also call methods like `GroupBy` and `Agg` to specifically combine, filter, and perform calculations on your data.

   ```csharp
   // Average number of times each language has been forked
   DataFrame groupedDF = cleanedProjects
       .GroupBy("language")
       .Agg(Avg(cleanedProjects["forked_from"]) 

   // Sort by most forked languages first
   groupedDF.OrderBy(Desc("avg(forked_from)")).Show(); 

   spark.Udf().Register<string, bool>(
       "MyUDF",
       (date) => DateTime.TryParse(date, out DateTime   convertedDate) &&
           (convertedDate > s_referenceDate);   
   cleanedProjects.CreateOrReplaceTempView("dateView"); 

   DataFrame dateDf = spark.Sql(
       "SELECT *, MyUDF(dateView.updated_at) AS datebefore FROM dateView");
   dateDf.Show();
   ```

1. Call `spark.Stop()` to end the SparkSession.

1. Use `spark-submit` to run your app. Be sure to update the following command with the actual paths to your Microsoft Spark jar file and **projects_smaller.csv**.


   ```console
   spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local /<path>/to/microsoft-spark-<version>.jar Microsoft.Spark.CSharp.Examples.exe Sql.Batch.GitHubProjects /<path>/projects_smaller.csv
   ```

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [.NET for Apache Spark 101 video series](https://channel9.msdn.com/Series/NET-for-Apache-Spark-101)
* [Deploy a .NET for Apache Spark application to Azure HDInsight](../tutorials/hdinsight-deployment.md)
* [Deploy a .NET for Apache Spark application to Databricks](../tutorials/databricks-deployment.md)
* [Deploy a .NET for Apache Spark application to Amazon EMR Spark](../tutorials/amazon-emr-spark-deployment.md)
