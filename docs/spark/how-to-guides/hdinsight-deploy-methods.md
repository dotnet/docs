---
title: Submit a .NET for Apache Spark job to Azure HDInsight
description: Learn how to submit a .NET for Apache Spark job to Azure HDInsight using spark-submit and Apache Livy.
ms.date: 12/16/2022
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Submit a .NET for Apache Spark job to Azure HDInsight

There are two ways to deploy your .NET for Apache Spark job to HDInsight: `spark-submit` and Apache Livy.

[!INCLUDE [.NET Core 3.1 Warning](../../includes/net-core-31-spark.md)]

## Deploy using spark-submit

You can use the [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html) command to submit .NET for Apache Spark jobs to Azure HDInsight.

1. Navigate to your HDInsight Spark cluster in Azure portal, and then select **SSH + Cluster login**.

2. Copy the ssh login information and paste the login into a terminal. Sign in to your cluster using the password you set during cluster creation. You should see messages welcoming you to Ubuntu and Spark.

3. Use the **spark-submit** command to run your app on your HDInsight cluster. Remember to replace **mycontainer** and **mystorageaccount** in the example script with the actual names of your blob container and storage account. Also remember to replace the microsoft-spark jar with the version of Spark and .NET for Apache Spark being used.

   ```bash
   $SPARK_HOME/bin/spark-submit \
   --master yarn \
   --class org.apache.spark.deploy.dotnet.DotnetRunner \
   wasbs://mycontainer@mystorageaccount.blob.core.windows.net/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar \
   wasbs://mycontainer@mystorageaccount.blob.core.windows.net/publish.zip mySparkApp
   ```

## Deploy using Apache Livy

You can use [Apache Livy](https://livy.incubator.apache.org/), the Apache Spark REST API, to submit .NET for Apache Spark jobs to an Azure HDInsight Spark cluster. For more information, see [Remote jobs with Apache Livy](/azure/hdinsight/spark/apache-spark-livy-rest-interface).

You can run the following command on Linux using `curl`:

```bash
curl -k -v -X POST "https://<your spark cluster>.azurehdinsight.net/livy/batches" \
-u "<hdinsight username>:<hdinsight password>" \
-H "Content-Type: application/json" \
-H "X-Requested-By: <hdinsight username>" \
-d @- << EOF
{
    "file":"abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar",
    "className":"org.apache.spark.deploy.dotnet.DotnetRunner",
    "files":["abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<udf assembly>", "abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<file>"],
    "args":["abfss://<your-file-system-name>@<your-storage-account-name>.dfs.core.windows.net/<some dir>/<your app>.zip","<your app>","<app arg 1>","<app arg 2>,"...","<app arg n>"]
}
EOF
```

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [Deploy a .NET for Apache Spark application to Azure HDInsight](../tutorials/hdinsight-deployment.md)
* [HDInsight Documentation](/azure/hdinsight/)
