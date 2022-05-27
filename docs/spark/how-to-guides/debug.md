---
title: Debug a .NET for Apache Spark application on Windows
description: Learn how to debug your .NET for Apache Spark application on Windows.
ms.date: 10/09/2020
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Debug a .NET for Apache Spark application

This how-to provides the steps to debug your .NET for Apache Spark application on Windows.

## Debug your application

Open a new command prompt window and run the following command:

```shell
spark-submit \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  <path-to-microsoft-spark-jar> \
  debug
```

When you run the command, you see the following output:

```console
***********************************************************************
* .NET Backend running debug mode. Press enter to exit *
***********************************************************************
```

In debug mode, DotnetRunner does not launch the .NET application, but instead waits for you to start the .NET app. Leave this command prompt window open and start your .NET application through C# debugger to debug your application. Start your .NET application with a C# debugger ([Visual Studio Debugger for Windows/macOS](https://visualstudio.microsoft.com/vs/) or [C# Debugger Extension in Visual Studio Code](https://code.visualstudio.com/Docs/editor/debugging)) to debug your application.

## Debug a user-defined function (UDF)

> [!NOTE]
> User-defined functions are supported only on Windows with Visual Studio Debugger.

Before running `spark-submit`, set the following environment variable:

```bat
set DOTNET_WORKER_DEBUG=1
```

When you run your Spark application, a `Choose Just-In-Time Debugger` window will pop up. Choose a Visual Studio debugger.

The debugger will break at the following location in [TaskRunner.cs](https://github.com/dotnet/spark/blob/5e9c08b430b4bc56b5f42252c4b73437377afaed/src/csharp/Microsoft.Spark.Worker/TaskRunner.cs#L52):

```csharp
if (EnvironmentUtils.GetEnvironmentVariableAsBool("DOTNET_WORKER_DEBUG"))
{
    Debugger.Launch(); // <-- The debugger will break here.
}
```

Navigate to the *.cs* file that contains the UDF that you plan to debug, and [set a breakpoint](/visualstudio/debugger/using-breakpoints). The breakpoint will say `The breakpoint will not currently be hit` because the worker hasn't loaded the assembly that contains UDF yet.

Hit `F5` to continue your application and the breakpoint will eventually be hit.

> [!NOTE]
> The Choose Just-In-Time Debugger window pops up for each task. To avoid excessive pop-ups, set the number of executors to a low number. For example, you can use the **--master local[1]** option for spark-submit to set the number of tasks to 1, which launches a single debugger instance.

## Debug Scala code

If you need to debug the Scala-side code (`DotnetRunner`, `DotnetBackendHandler`, etc.), you can use the following command and attach a debugger to the running process using [IntelliJ](https://www.jetbrains.com/help/idea/attaching-to-local-process.html):

```shell
spark-submit \
  --driver-java-options -agentlib:jdwp=transport=dt_socket,server=y,suspend=n,address=5005 \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  <path-to-microsoft-spark-jar> \
  <path-to-your-app-exe> <argument(s)-to-your-app>
```

After you run the command, attach a debugger to the running process using [Intellij](https://www.jetbrains.com/help/idea/attaching-to-local-process.html).

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [Deploy a .NET for Apache Spark application to Azure HDInsight](../tutorials/hdinsight-deployment.md)
* [Deploy a .NET for Apache Spark application to Databricks](../tutorials/databricks-deployment.md)
* [Deploy a .NET for Apache Spark application to Amazon EMR Spark](../tutorials/amazon-emr-spark-deployment.md)
