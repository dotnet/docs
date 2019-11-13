---
title: Process streaming data with .NET for Apache Spark
description: Learn how to use .NET for Apache Spark for Spark Structured Streaming.
ms.date: 11/14/2019
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Process streaming data with .NET for Apache Spark

This article teaches you how to invoke Spark Structured Streaming using .NET for Apache Spark. Spark Structured Streaming is Apache Spark's support for processing real-time data streams. Stream processing means analyzing live date as it's being produced.

There are four full stream processing examples on GitHub:

* [StructuredNetworkWordCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCount.cs): word count on data streamed from any source
* [StructuredNetworkWordCountWindowed.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCountWindowed.cs): word count on data with windowing logic
* [StructuredKafkaWordCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs): word count on data streamed from Kafka
* [StructuredNetworkCharacterCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkCharacterCount.cs): uses user-defined functions and stream processing to count the number of characters in each string read from a stream

While the following steps apply to most stream processing apps, there are some specific references to the [StructuredNetworkCharacterCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkCharacterCount.cs) example.

## Create a Spark session

In any Spark application, you must establish a new `SparkSession`, which is the entry point to programming Spark with the Dataset and DataFrame API.

```CSharp
SparkSession spark = SparkSession
    .Builder()
    .AppName("Streaming example with a UDF")
    .GetOrCreate();
```

Calling the *spark* object created above allows you to access Spark and DataFrame functionality throughout your program.

## Establish and connect to a data stream

Depending upon which sample you choose to run, you need to set up a connection to a data stream. One popular way to test out stream processing is through **netcat.**

#### Establish a stream with netcat

netcat (also known as *nc*) allows you to read from and write to network connections. You establish a network connection with netcat through a terminal window.

[Download netcat](https://sourceforge.net/projects/nc110/files/), extract the file from the zip download, and append the directory you extracted to your "PATH" environment variable.

To start a new connection, open a command prompt. If you are using Linux, run ```nc -lk 9999``` to connect to localhost on port 9999.

If you are using Windows, run ```nc -vvv -l -p 9999``` to connect to localhost port 9999.

Your Spark program listens for the input you type into this command prompt.

### Connect to a stream with ReadStream()

The `ReadStream()` method returns a `DataStreamReader` that can be used to read streaming data in as a `DataFrame`. Include the host and port information to tell your Spark app where to expect its streaming data.

```CSharp
DataFrame lines = spark
    .ReadStream()
    .Format("socket")
    .Option("host", hostname)
    .Option("port", port)
    .Load();
```

## Register a user-defined function

A UDF is a *user-defined function.* You can use UDFs in Spark applications to perform calculations and analysis on your data.

```CSharp
Func<Column, Column> udfArray =
    Udf<string, string[]>((str) => new string[] { str, $"{str} {str.Length}");
```

In the above code snippet from [StructuredNetworkCharacterCount.cs](StructuredNetworkCharacterCount.cs), you register a UDF called `udfArray`. This UDF processes each string it receives from the netcat terminal to produce an array that includes: the original string (contained in *str*), the original string concatenated with the length of that original string. 

For example, entering *Hello world* in the terminal would produce an array where:

* array[0] = Hello world
* array[1] = Hello world 11

## Use SparkSQL

Use SparkSQL to perform various functions on the data stored in your DataFrame. It's common to combine UDFs and SparkSQL to apply a UDF to each row of your DataFrame.

```CSharp
DataFrame arrayDF = lines.Select(Explode(udfArray(lines["value"])));
```

In the above code snippet from [StructuredNetworkCharacterCount.cs](StructuredNetworkCharacterCount.cs), *udfArray* is applied to each value in your DataFrame (which represents each string read in from our netcat terminal). Apply the SparkSQL method `Explode` to put each entry of your array in its own row. Finally, use `Select` to place the columns you've produced in the new DataFrame *arrayDF.*

## Display your stream

Use `DataFrame.WriteStream()` to establish characteristics of your output, such as printing results to the console, displaying only the most recent output.

```CSharp
StreamingQuery query = arrayDf
    .WriteStream()
    .Format("console")
    .Start();
```

## Run your code

Structured streaming in Spark processes data through a series of small **batches.** 
When you run your program, the command prompt where you establish the netcat allows you to start typing.

When you hit *enter* after entering data in the command prompt, Spark considers that a batch and runs the UDF. 

### Run on Windows

After starting a new netcat session, open a new terminal and run your `spark-submit` command, similar to the following command:

```powershell
spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local /path/to/microsoft-spark-<version>.jar Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredNetworkCharacterCount localhost 9999
```

> [!NOTE]
> Be sure to update the above command with the actual path to your Microsoft Spark jar file. The above command also assumes your netcat server is running on localhost port 9999.

## Next steps

* [What is Apache Spark?](../what-is-spark.md)
* [What is .NET for Apache Spark?](../what-is-apache-spark-dotnet.md)
* [Get started with .NET for Apache Spark](../tutorials/get-started.md)