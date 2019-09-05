---
title: Debug a .NET for Apache Spark application on Windows
description: Learn how to debug your .NET for Apache Spark application on Windows.
ms.date: 08/15/2019
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Debug a .NET for Apache Spark application

This how-to provides the commands you need to run to debug your .NET for Apache Spark application and Scala code on Windows.

## Debug your application

Open a new command prompt window, run the following:

```shell
spark-submit \
  --class org.apache.spark.deploy.dotnet.DotnetRunner \
  --master local \
  <path-to-microsoft-spark-jar> \
  debug
```

When you run the command, you see the following output:

```
***********************************************************************
* .NET Backend running debug mode. Press enter to exit *
***********************************************************************
```

In this debug mode, `DotnetRunner` does not launch the .NET application, but it waits for it to connect. Leave this command prompt window open.

Now you can run your .NET application with any debugger to debug your application.

## Debug Scala code

If you need to debug the Scala side code, such as `DotnetRunner` or `DotnetBackendHandler`, run the following command:

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
