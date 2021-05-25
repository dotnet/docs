---
title: Structured Streaming with .NET for Apache Spark tutorial
description: In this tutorial, you learn how to use .NET for Apache Spark for Spark Structured Streaming.
author: mamccrea
ms.author: mamccrea
ms.date: 10/09/2020
ms.topic: tutorial
recommendations: false
---

# Tutorial: Structured Streaming with .NET for Apache Spark

This tutorial teaches you how to invoke Spark Structured Streaming using .NET for Apache Spark. Spark Structured Streaming is Apache Spark's support for processing real-time data streams. Stream processing means analyzing live data as it's being produced.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Create and run a .NET for Apache Spark application
> * Use netcat to create a data stream
> * Use user-defined functions and SparkSQL to analyze streaming data

## Prerequisites

If this is your first .NET for Apache Spark application, start with the [Getting Started tutorial](get-started.md) to become familiar with the basics.

## Create a console application

1. In your command prompt, run the following commands to create a new console application:

   ```dotnetcli
   dotnet new console -o mySparkStreamingApp
   cd mySparkStreamingApp
   ```

   The `dotnet` command creates a `new` application of type `console` for you. The `-o` parameter creates a directory named *mySparkStreamingApp* where your app is stored and populates it with the required files. The `cd mySparkStreamingApp` command changes the directory to the app directory you just created.

1. To use .NET for Apache Spark in an app, install the Microsoft.Spark package. In your console, run the following command:

   ```dotnetcli
   dotnet add package Microsoft.Spark
   ```

## Establish and connect to a data stream

One popular way to test stream processing is through **netcat**. netcat (also known as *nc*) allows you to read from and write to network connections. You establish a network connection with netcat through a terminal window.

### Create a data stream with netcat

1. [Download netcat](https://sourceforge.net/projects/nc110/files/). Then, extract the file from the zip download and append the directory you extracted to your "PATH" environment variable.

2. To start a new connection, open a new console and run the following command which connects to localhost on port 9999.

   On Windows:

   ```console
   nc -vvv -l -p 9999
   ```

   On Linux:

   ```console
   nc -lk 9999
   ```

   Your Spark program listens for the input you type into this command prompt.

### Create a SparkSession

1. Add the following additional `using` statements to the top of the *Program.cs* file in *mySparkStreamingApp*:

   ```csharp
   using System;
   using Microsoft.Spark.Sql;
   using Microsoft.Spark.Sql.Streaming;
   using static Microsoft.Spark.Sql.Functions;
   ```

1. Add the following code to your `Main` method to create a new `SparkSession`. The Spark Session is the entry point to programming Spark with the Dataset and DataFrame API.

   ```csharp
   SparkSession spark = SparkSession
        .Builder()
        .AppName("Streaming example with a UDF")
        .GetOrCreate();
   ```

   Calling the *spark* object created above allows you to access Spark and DataFrame functionality throughout your program.

### Connect to a stream with ReadStream()

The `ReadStream()` method returns a `DataStreamReader` that can be used to read streaming data in as a `DataFrame`. Include the host and port information to tell your Spark app where to expect its streaming data.

```csharp
DataFrame lines = spark
    .ReadStream()
    .Format("socket")
    .Option("host", hostname)
    .Option("port", port)
    .Load();
```

## Register a user-defined function

You can use UDFs, *user-defined functions*, in Spark applications to perform calculations and analysis on your data.

Add the following code to your `Main` method to register a UDF called `udfArray`.

```csharp
Func<Column, Column> udfArray =
    Udf<string, string[]>((str) => new string[] { str, $"{str} {str.Length}" });
```

This UDF processes each string it receives from the netcat terminal to produce an array that includes the original string (contained in *str*), followed by the original string concatenated with the length of the original string.

For example, entering *Hello world* in the netcat terminal produces an array where:

* array\[0] = Hello world
* array\[1] = Hello world 11

## Use SparkSQL

Use SparkSQL to perform various functions on the data stored in your DataFrame. It's common to combine UDFs and SparkSQL to apply a UDF to each row of a DataFrame.

```csharp
DataFrame arrayDF = lines.Select(Explode(udfArray(lines["value"])));
```

This code snippet applies *udfArray* to each value in your DataFrame, which represents each string read from your netcat terminal. Apply the SparkSQL method <xref:Microsoft.Spark.Sql.Functions.Explode%2A> to put each entry of your array in its own row. Finally, use <xref:Microsoft.Spark.Sql.DataFrame.Select%2A> to place the columns you've produced in the new DataFrame *arrayDF.*

## Display your stream

Use <xref:Microsoft.Spark.Sql.DataFrame.WriteStream> to establish characteristics of your output, such as printing results to the console and displaying only the most recent output.

```csharp
StreamingQuery query = arrayDf
    .WriteStream()
    .Format("console")
    .Start();
```

## Run your code

Structured streaming in Spark processes data through a series of small **batches**.  When you run your program, the command prompt where you establish the netcat connection allows you to start typing. Each time you press the Enter key after typing data in that command prompt, Spark considers your entry a batch and runs the UDF.

### Use spark-submit to run your app

After starting a new netcat session, open a new terminal and run your `spark-submit` command, similar to the following command:

```powershell
spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local /path/to/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredNetworkCharacterCount localhost 9999
```

> [!NOTE]
> Be sure to update the above command with the actual path to your Microsoft Spark jar file. The above command also assumes your netcat server is running on localhost port 9999.

## Get the code

This tutorial uses the [StructuredNetworkCharacterCount.cs](https://github.com/dotnet/spark/blob/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkCharacterCount.cs) example, but there are three other full stream processing examples on GitHub:

* [StructuredNetworkWordCount.cs](https://github.com/dotnet/spark/blob/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCount.cs): word count on data streamed from any source
* [StructuredNetworkWordCountWindowed.cs](https://github.com/dotnet/spark/blob/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCountWindowed.cs): word count on data with windowing logic
* [StructuredKafkaWordCount.cs](https://github.com/dotnet/spark/blob/main/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs): word count on data streamed from Kafka

## Next steps

Advance to the next article to learn how to deploy your .NET for Apache Spark application to Databricks.
> [!div class="nextstepaction"]
> [Tutorial: Deploy a .NET for Apache Spark application to Databricks](databricks-deployment.md)
