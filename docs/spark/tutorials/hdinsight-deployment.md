---
title: Deploy a .NET for Apache Spark application to Azure HDInsight
description: Discover how to deploy a .NET for Apache Spark application to HDInsight.
ms.date: 05/17/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to deployment .NET for Apache Spark application to HDInsight.
---

# Deploy a .NET for Apache Spark application to Azure HDInsight

This tutorial teaches how to deploy a .NET for Apache Spark application to Azure HDInsight.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Prepare Microsoft.Spark.Worker
> * Publish your Spark .NET app
> * Deploy your app to Azure HDInsight
> * Run your app

## Prerequisites

Before you start, do the following:

* Download [Azure Storage Explorer](https://azure.microsoft.com/features/storage-explorer/).
* Download [install-worker.sh](https://github.com/dotnet/spark/blob/master/deployment/install-worker.sh) to your local machine. This is a helper script that you use later to copy .NET for Apache Spark dependent files into your Spark cluster's worker nodes.

## Prepare worker dependencies

**Microsoft.Spark.Worker** is a backend component that lives on the individual worker nodes of your Spark cluster. When you want to execute a C# UDF (user-defined function), Spark needs to understand how to launch the .NET CLR to execute the UDF. **Microsoft.Spark.Worker** provides a collection of classes to Spark that enable this functionality.

1. Select a [Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases) Linux netcoreapp release to be deployed on your cluster.

   For example, if you want `.NET for Apache Spark v0.1.0` using `netcoreapp2.1`, you'd download [Microsoft.Spark.Worker.netcoreapp2.1.linux-x64-0.1.0.tar.gz](https://github.com/dotnet/spark/releases/download/v0.1.0/Microsoft.Spark.Worker.netcoreapp2.1.linux-x64-0.1.0.tar.gz).

2. Upload `Microsoft.Spark.Worker.<release>.tar.gz` and [install-worker.sh](https://github.com/dotnet/spark/blob/master/deployment/install-worker.sh) to a distributed file system (e.g., HDFS, WASB, ADLS) that your cluster has access to.

## Prepare your .NET for Apache Spark app

1. Follow the [Get Started](get-started.md) tutorial to build your app.

2. Publish your Spark .NET app as self-contained.

   You can run the following command on Linux.

   ```dotnetcli
   dotnet publish -c Release -f netcoreapp2.1 -r ubuntu.16.04-x64
   ```

3. Produce `<your app>.zip` for the published files.

   You can run the following command on Linux using `zip`.

   ```bash
   zip -r <your app>.zip .
   ```

4. Upload the following to a distributed file system (e.g., HDFS, WASB, ADLS) that your cluster has access to:

   * `microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar`: This jar is included as part of the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) NuGet package and is colocated in your app's build output directory.
   * `<your app>.zip`
   * Files (like dependency files or common data accessible to every worker) or Assemblies (like DLLs that contain your user-defined functions or libraries that your `app` depends on) to be placed in the working directory of each executor.

## Deploy to Azure HDInsight Spark

[Azure HDInsight Spark](https://docs.microsoft.com/azure/hdinsight/spark/apache-spark-overview) is the Microsoft implementation of Apache Spark in the cloud that allows users to launch and configure Spark clusters in Azure. You can use HDInsight Spark clusters to process your data stored in [Azure Storage](https://azure.microsoft.com/services/storage/) or [Azure Data Lake Storage](https://docs.microsoft.com/azure/hdinsight/hdinsight-hadoop-use-data-lake-storage-gen2).

> [!NOTE]
> Azure HDInsight Spark is Linux-based. If you are interested in deploying your app to Azure HDInsight Spark, make sure your app is .NET Standard compatible and that you use the [.NET Core compiler](https://dotnet.microsoft.com/download) to compile your app.

### Deploy Microsoft.Spark.Worker

This step is only required once for your cluster.

Run `install-worker.sh` on the cluster using [HDInsight Script Actions](https://docs.microsoft.com/azure/hdinsight/hdinsight-hadoop-customize-cluster-linux).

|Setting|Value|
|-------|-----|
|Script type|Custom|
|Name|Install Microsoft.Spark.Worker|
|Bash script URI|The URI to which you uploaded `install-worker.sh`. For example, `abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/install-worker.sh`|
|Node type(s)|Worker|
|Parameters|Parameters to `install-worker.sh`. For example, if you uploaded `install-worker.sh` to Azure Data Lake Gen 2 then it would be `azure abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/Microsoft.Spark.Worker.<release>.tar.gz /usr/local/bin`.|

![Script Action Image](./media/hdinsight-deployment/deployment-hdi-action-script.png)

## Run your app

You can submit your job to Azure HDInsight using `spark-submit` or Apache Livy.

### Use spark-submit

You can use the [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html) command to submit .NET for Apache Spark jobs to Azure HDInsight.
 
1. `ssh` into one of the head nodes in your cluster.

1. Run `spark-submit`:

   ```bash
   spark-submit \
   --master yarn \
   --class org.apache.spark.deploy.dotnet.DotnetRunner \
   --files <comma-separated list of assemblies that contain UDF definitions, if any> \
   abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar \
   abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<your app>.zip <your app> <app arg 1> <app arg 2> ... <app arg n>
   ```

### Use Apache Livy

You can use [Apache Livy](https://livy.incubator.apache.org/), the Apache Spark REST API, to submit .NET for Apache Spark jobs to an Azure HDInsight Spark cluster. For more information, see [Remote jobs with Apache Livy](https://docs.microsoft.com/azure/hdinsight/spark/apache-spark-livy-rest-interface).

You can run the following command on Linux using `curl`:

```bash
curl -k -v -X POST "https://<your spark cluster>.azurehdinsight.net/livy/batches" \
-u "<hdinsight username>:<hdinsight password>" \
-H "Content-Type: application/json" \
-H "X-Requested-By: <hdinsight username>" \
-d @- << EOF
{
    "file":"abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar",
    "className":"org.apache.spark.deploy.dotnet.DotnetRunner",
    "files":["abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<udf assembly>", "abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<file>"],
    "args":["abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<your app>.zip","<your app>","<app arg 1>","<app arg 2>,"...","<app arg n>"]
}
EOF
```

## Next steps

In this tutorial, you deployed your .NET for Apache Spark application to Azure HDInsight. To learn more about HDInsight, continue to the Azure HDInsight Documentation.

> [!div class="nextstepaction"]
> [Azure HDInsight Documentation](https://docs.microsoft.com/azure/hdinsight/)
