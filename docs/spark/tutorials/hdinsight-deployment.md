---
title: Deploy a .NET for Apache Spark application to HDInsight
description: Discover how to deploy a .NET for Apache Spark application to HDInsight.
ms.date: 05/13/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to deployment .NET for Apache Spark application to HDInsight.
---

# Deploy a .NET for Apache Spark application to the HDInsight

This tutorial teaches how to deploy a .NET for Apache Spark application to Azure HDInsight.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * 

## Prerequisites

Before you start, make sure you have the following:

* Download [Azure Storage Explorer](https://azure.microsoft.com/features/storage-explorer/)
* Download [install-worker.sh](https://github.com/dotnet/spark/blob/master/deployment/install-worker.sh) to your local machine. This is a helper script that you use later to copy .NET for Apache Spark dependent files into your Spark cluster's worker nodes.

## Prepare worker dependencies

**Microsoft.Spark.Worker** is a backend component that lives on the individual worker nodes of your Spark cluster. When you want to execute a C# UDF (user-defined function), Spark needs to understand how to launch the .NET CLR to execute the UDF. **Microsoft.Spark.Worker** provides a collection of classes to Spark that enable this functionality.

1. Select a [Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases) Linux netcoreapp release to be deployed on your cluster.

   For example, if you want `.NET for Apache Spark v0.1.0` using `netcoreapp2.1`, you'd download [Microsoft.Spark.Worker.netcoreapp2.1.linux-x64-0.1.0.tar.gz](https://github.com/dotnet/spark/releases/download/v0.1.0/Microsoft.Spark.Worker.netcoreapp2.1.linux-x64-0.1.0.tar.gz).

2. Upload `Microsoft.Spark.Worker.<release>.tar.gz` and [install-worker.sh](https://github.com/dotnet/spark/blob/master/deployment/install-worker.sh) to a distributed file system (e.g., HDFS, WASB, ADLS) that your cluster has access to.

## Prepare your .NET for Apache Spark app

1. Follow the [Get Started](get-started.md) tutorial to build your app.

2. Publish your Spark .NET `app` as self-contained.

   ```shell
   # For example, you can run the following on Linux.
   foo@bar:~/path/to/app$ dotnet publish -c Release -f netcoreapp2.1 -r ubuntu.16.04-x64
   ```
1. Produce `<your app>.zip` for the published files.
   ```shell
   # For example, you can run the following on Linux using `zip`.
   foo@bar:~/path/to/app/bin/Release/netcoreapp2.1/ubuntu.16.04-x64/publish$ zip -r <your app>.zip .
   ```
1. Upload the following to a distributed file system (e.g., HDFS, WASB, ADLS, S3, DBFS) that your cluster has access to:
   * `microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar` (Included as part of the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) nuget and is colocated in your app's build output directory)
   * `<your app>.zip`
   * Files (e.g., dependency files, common data accessible to every worker) or Assemblies (e.g., DLLs that contain your user-defined functions, libraries that your `app` depends on) to be placed in the working directory of each executor.

# Cloud Deployment
## Azure HDInsight Spark
[Azure HDInsight Spark](https://docs.microsoft.com/en-us/azure/hdinsight/spark/apache-spark-overview) is the Microsoft implementation of Apache Spark in the cloud that allows users to launch and configure Spark clusters in Azure. You can use HDInsight Spark clusters to process your data stored in Azure (e.g., [Azure Storage](https://azure.microsoft.com/en-us/services/storage/) and [Azure Data Lake Storage](https://docs.microsoft.com/en-us/azure/storage/blobs/data-lake-storage-introduction)).

> **Note:** Azure HDInsight Spark is Linux-based. Therefore, if you are interested in deploying your app to Azure HDInsight Spark, make sure your app is .NET Standard compatible and that you use [.NET Core compiler](https://dotnet.microsoft.com/download) to compile your app.

### Deploy Microsoft.Spark.Worker
*Note that this step is required only once*

#### Run HDInsight Script Action
Run `install-worker.sh` on the cluster using [HDInsight Script Actions](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-customize-cluster-linux):

* Script type: Custom
* Name: Install Microsoft.Spark.Worker (or anything that is descriptive)
* Bash script URI: The URI to which you uploaded `install-worker.sh` (e.g. adl://\<cluster name\>.azuredatalakestore.net/\<some dir\>/install-worker.sh)
* Node type(s): Worker
* Parameters: Parameters to `install-worker.sh`. For example, if you uploaded to Azure Data Lake then it would be `azure adl://<cluster name>.azuredatalakestore.net/<some dir>/Microsoft.Spark.Worker.<release>.tar.gz /usr/local/bin`.

The following captures the setting for a HDInsight Script Action:

<img src="../docs/img/deployment-hdi-action-script.png" alt="ScriptActionImage" width="500"/>

### Run your app on the cloud!
#### Using [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html)
1. `ssh` into one of the head nodes in the cluster.
2. Run `spark-submit`:
   ```shell
   foo@bar:~$ $SPARK_HOME/bin/spark-submit \
   --master yarn \
   --class org.apache.spark.deploy.DotnetRunner \
   --files <comma-separated list of assemblies that contain UDF definitions, if any> \
   adl://<cluster name>.azuredatalakestore.net/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar \
   adl://<cluster name>.azuredatalakestore.net/<some dir>/<your app>.zip <your app> <app arg 1> <app arg 2> ... <app arg n>
   ```

#### Using [Apache Livy](https://livy.incubator.apache.org/) 
You can use Apache Livy, the Apache Spark REST API, to submit Spark .NET jobs to an Azure HDInsight Spark cluster as documented in [Remote jobs with Apache Livy](https://docs.microsoft.com/en-us/azure/hdinsight/spark/apache-spark-livy-rest-interface).
```shell
# For example, you can run the following on Linux using `curl`.
foo@bar:~$ curl -k -v -X POST "https://<your spark cluster>.azurehdinsight.net/livy/batches" \
-u "<hdinsight username>:<hdinsight password>" \
-H "Content-Type: application/json" \
-H "X-Requested-By: <hdinsight username>" \
-d @- << EOF
{
    "file":"adl://<cluster name>.azuredatalakestore.net/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar",
    "className":"org.apache.spark.deploy.DotnetRunner",
    "files":["adl://<cluster name>.azuredatalakestore.net/<some dir>/<udf assembly>", "adl://<cluster name>.azuredatalakestore.net/<some dir>/<file>"],
    "args":["adl://<cluster name>.azuredatalakestore.net/<some dir>/<your app>.zip","<your app>","<app arg 1>","<app arg 2>,"...","<app arg n>"]
}
EOF
```

## Amazon EMR Spark
[Amazon EMR](https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-what-is-emr.html) is a managed cluster platform that simplifies running big data frameworks on AWS.

> **Note:** AWS EMR Spark is Linux-based. Therefore, if you are interested in deploying your app to AWS EMR Spark, make sure your app is .NET Standard compatible and that you use [.NET Core compiler](https://dotnet.microsoft.com/download) to compile your app.

### Deploy Microsoft.Spark.Worker
*Note that this step is only required at cluster creation*

#### Create cluster using Amazon EMR Bootstrap Actions
Run `install-worker.sh` during cluster creation using [Bootstrap Actions](https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-plan-bootstrap.html).
```shell
# For example, you can run the following on Linux using `aws` cli.
foo@bar:~$ aws emr create-cluster \
--name "Test cluster" \
--release-label emr-5.23.0 \
--use-default-roles \
--ec2-attributes KeyName=myKey \
--applications Name=Spark \
--instance-count 3 \
--instance-type m1.medium \
--bootstrap-actions Path=s3://mybucket/<some dir>/install-worker.sh,Name="Install Microsoft.Spark.Worker",Args=["aws","s3://mybucket/<some dir>/Microsoft.Spark.Worker.<release>.tar.gz","/usr/local/bin"]
```

### Run your app on the cloud!
#### Using [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html)
1. `ssh` into one of the nodes in the cluster.
2. Run `spark-submit`:
   ```shell
   foo@bar:~$ spark-submit \
   --master yarn \
   --class org.apache.spark.deploy.DotnetRunner \
   --files <comma-separated list of assemblies that contain UDF definitions, if any> \
   s3://mybucket/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar \
   s3://mybucket/<some dir>/<your app>.zip <your app> <app args>
   ```

#### Using [Amazon EMR Steps](https://docs.aws.amazon.com/emr/latest/ReleaseGuide/emr-spark-submit-step.html)
Amazon EMR Steps can be used to submit jobs to the Spark framework installed on the EMR cluster.
```bash
# For example, you can run the following on Linux using `aws` cli.
foo@bar:~$ aws emr add-steps \
--cluster-id j-xxxxxxxxxxxxx \
--steps Type=spark,Name="Spark Program",Args=[--master,yarn,--files,s3://mybucket/<some dir>/<udf assembly>,--class,org.apache.spark.deploy.DotnetRunner,s3://mybucket/<some dir>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar,s3://mybucket/<some dir>/<your app>.zip,<your app>,<app arg 1>,<app arg 2>,...,<app arg n>],ActionOnFailure=CONTINUE
```

## Databricks
[Databricks](http://databricks.com) is a platform that provides cloud-based big data processing using Apache Spark.

> **Note:** [Azure](https://azure.microsoft.com/en-us/services/databricks/) and [AWS](https://databricks.com/aws) Databricks is Linux-based. Therefore, if you are interested in deploying your app to Databricks, make sure your app is .NET Standard compatible and that you use [.NET Core compiler](https://dotnet.microsoft.com/download) to compile your app.

Databricks allows you to submit Spark .NET apps to an existing active cluster or create a new cluster everytime you launch a job. This requires the **Microsoft.Spark.Worker** to be installed **first** before you submit a Spark .NET app.

### Deploy Microsoft.Spark.Worker
*Note that this step is required only once*

   1. Download **[db-init.sh](../deployment/db-init.sh)** and **[install-worker.sh](../deployment/install-worker.sh)** onto your local machine
   2. Modify **db-init.sh** appropriately to point to the Microsoft.Spark.Worker release you want to download and install on your cluster
   3. Download and install [Databricks CLI](https://docs.databricks.com/user-guide/dev-tools/databricks-cli.html)
   4. [Setup authentication](https://docs.databricks.com/user-guide/dev-tools/databricks-cli.html#set-up-authentication) details for the Databricks CLI appropriately
   5. Upload the files you downloaded and modified to your Databricks cluster
      ```shell
      cd <path-to-db-init-and-install-worker>
      databricks fs cp db-init.sh dbfs:/spark-dotnet/db-init.sh
      databricks fs cp install-worker.sh dbfs:/spark-dotnet/install-worker.sh
      ```
   6. Go to to your Databricks cluster homepage -> Clusters (on the left-side menu) -> Create Cluster
   7. After configuring the cluster appropriately, set the init script (see the image below) and create the cluster.

      <img src="../docs/img/deployment-databricks-init-script.PNG" alt="ScriptActionImage" width="600"/>

   > **Note:** If everything went well, your cluster creation should have been successful. You can check this by clicking on the cluster -> Event Logs.

### Run your app on the cloud!

#### Using [Set JAR](https://docs.databricks.com/user-guide/jobs.html#create-a-job)

> **Note:** This approach allows job submission to an existing active cluster.

One-time Setup:
   1. Go to your Databricks cluster -> Jobs (on the left-side menu) -> Set JAR
   2. Upload the appropriate `microsoft-spark-<spark-version>-<spark-dotnet-version>.jar`
   3. Set the params appropriately:
      ```
      Main Class: org.apache.spark.deploy.DotnetRunner
      Arguments /dbfs/apps/<your-app-name>.zip <your-app-main-class>
      ```
   4. Configure the Cluster to point to an existing cluster (that you already set the init script for - see previous section).

Publishing your App & Running:
   1. You should first [publish your app](#preparing-your-spark-net-app). 
      > **Note:** Do not use `SparkSession.Stop()` in your application code when submitting jobs to an existing active cluster.
   2. Use [Databricks CLI](https://docs.databricks.com/user-guide/dev-tools/databricks-cli.html) to upload your application to Databricks cluster. For instance, 
      ```shell
      cd <path-to-your-app-publish-directory>
      databricks fs cp <your-app-name>.zip dbfs:/apps/<your-app-name>.zip
      ```
   3. This step is only required if app assemblies (e.g., DLLs that contain user-defined functions along with their dependencies) need to be placed in the working directory of each Microsoft.Spark.Worker.
      - Upload your application assemblies to your Databricks cluster
         ```shell
         cd <path-to-your-app-publish-directory>
         databricks fs cp <assembly>.dll dbfs:/apps/dependencies
         ```
      - Uncomment and modify the app dependencies section in **[db-init.sh](../deployment/db-init.sh)** to point to your app dependencies path and upload to your Databricks cluster.
         ```shell
         cd <path-to-db-init-and-install-worker>
         databricks fs cp db-init.sh dbfs:/spark-dotnet/db-init.sh
         ```
      - Restart your cluster.
   4. Now, go to your `Databricks cluster -> Jobs -> [Job-name] -> Run Now` to run your job!

#### Using [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html)

> **Note:** This approach allows submission ONLY to cluster that gets created on-demand.

   1. [Create a Job](https://docs.databricks.com/user-guide/jobs.html) and select *Configure spark-submit*.
   2. Configure `spark-submit` with the following parameters:
      ```shell
      ["--files","/dbfs/<path-to>/<app assembly/file to deploy to worker>","--class","org.apache.spark.deploy.DotnetRunner","/dbfs/<path-to>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar","/dbfs/<path-to>/<app name>.zip","<app bin name>","app arg1","app arg2"]
      ```