---
title: Sentiment analysis with .NET for Apache Spark and ML.NET tutorial
description: In this tutorial, you learn how to use ML.NET with .NET for Apache Spark for sentiment analysis.
author: mamccrea
ms.author: mamccrea
ms.date: 01/31/2019
ms.topic: tutorial
---

# Tutorial: Sentiment analysis with .NET for Apache Spark and ML.NET

This tutorial teaches you how to perform sentiment analysis of online reviews using ML.NET and .NET for Apache Spark. ML.NET is a free, cross-platform, open-source machine learning framework. You can use ML.NET with .NET for Apache Spark to scale the training and prediction of machine learning algorithms.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Write a .NET for Apache Spark app that performs sentiment analysis.
> * Use the ML.NET model builder in Visual Studio.
> * 

## Prerequisites

If this is your first .NET for Apache Spark application, start with the [Getting Started tutorial](get-started.md) to become familiar with the basics.

This tutorial uses the ML.NET Model Builder (preview), a visual interface available in Visual Studio. If you do not already have Visual Studio, you can [download the Community version of Visual Studio](https://visualstudio.microsoft.com/downloads/) for free.

[Download and install](https://marketplace.visualstudio.com/items?itemName=MLNET.07) ML.NET Model Builder (preview).

## Build your machine learning model

1. Open Visual Studio and create a new C# Console App (.NET Core). Name the project *MLSparkModel*.

1. In **Solution Explorer**, right-click the *MLSparkModel* project. Then select **Add > Machine Learning**.

1. From the ML.NET Model Builder, select the **Sentiment Analysis** scenario tile.

1. On the **Add data** page, upload the *Amazon* reviews data set. 

1. Choose *Column2* from the **Columns to Predict** dropdown.

1. On the **Train** page, set the time to train to *60 seconds* and select **Start training**. Notice the status of your training under **Progress**.

## Create a console app

1. Create another C# Console App (.NET Core) called *myMLSparkApp*.

1. Access the NuGet Package Manager from **Tools > NuGet Package Manager > Manage NuGet Packages for Solution**.

1. Search for **Microsoft.ML** and **Microsoft.Spark**, and install the packages.

1. Double-click on your *myMLSparkApp* C# project and add the following code to add a reference to your *MLSparkModel* project.

   ```xml
   <ItemGroup>
       <ProjectReference Include="<path to project>\MLSparkModel\MLSparkModel.Model.csproj" />
   </ItemGroup>
   ```

   If you receive an error that the reference could not be found, open a command prompt and navigate to your *myMLSparkApp*. Then, run the following command to clean up dependencies in your project.

   ```dotnet cli
   dotnet restore
   ```

## heading

1. Add the following `using` statements to the top of the *Program.cs* file in *myMLSparkApp*:

   ```csharp
   using System;
   using System.Collections.Generic;
   using Microsoft.ML;
   using Microsoft.ML.Data;
   using Microsoft.Spark.Sql;
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
spark-submit --class org.apache.spark.deploy.dotnet.DotnetRunner --master local /path/to/microsoft-spark-<version>.jar Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredNetworkCharacterCount localhost 9999
```

> [!NOTE]
> Be sure to update the above command with the actual path to your Microsoft Spark jar file. The above command also assumes your netcat server is running on localhost port 9999.

## Get the code

This tutorial uses the [StructuredNetworkCharacterCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkCharacterCount.cs) example, but there are three other full stream processing examples on GitHub:

* [StructuredNetworkWordCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCount.cs): word count on data streamed from any source
* [StructuredNetworkWordCountWindowed.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCountWindowed.cs): word count on data with windowing logic
* [StructuredKafkaWordCount.cs](https://github.com/dotnet/spark/blob/master/examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs): word count on data streamed from Kafka

## Next steps

Advance to the next article to learn how to deploy your .NET for Apache Spark application to Databricks.
> [!div class="nextstepaction"]
> [Tutorial: Deploy a .NET for Apache Spark application to Databricks](databricks-deployment.md)
