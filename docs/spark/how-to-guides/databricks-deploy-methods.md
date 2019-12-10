---
title: Submit a .NET for Apache Spark job to Databricks
description: Learn how to submit a .NET for Apache Spark job to Databricks using spark-submit and Set Jar.
ms.date: 12/05/2019
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Submit a .NET for Apache Spark job to Databricks

There are two ways to deploy your .NET for Apache Spark job to Databricks: `spark-submit` and Set Jar. 

## Deploy using spark-submit

You can use the [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html) command to submit .NET for Apache Spark jobs to Databricks. `spark-submit` allows submission only to a cluster that gets created on-demand.

1. Navigate to your Databricks Workspace and create a job. Choose a title for your job, and then select **Configure spark-submit**. Paste the following parameters in the job configuration, then select **Confirm**.

    ```
    ["--files","/dbfs/<path-to>/<app assembly/file to deploy to worker>","--class","org.apache.spark.deploy.dotnet.DotnetRunner","/dbfs/<path-to>/microsoft-spark-<spark_majorversion.spark_minorversion.x>-<spark_dotnet_version>.jar","/dbfs/<path-to>/<app name>.zip","<app bin name>","app arg1","app arg2"]
    ```

    > [!NOTE]
    > Update the contents of the above parameter based on your specific files and configuration. For instance, reference the version of the Microsoft.Spark jar file that you uploaded to DBFS, and use the appropriate name of your app and published app zip file.

2. Navigate to your job and select **Edit** to configure your job's cluster. Set the Databricks Runtime Version based on the version of Apache Spark you wish to use in your deployment. Then select **Advanced Options > Init Scripts**, and set Init Script Path as `dbfs:/spark-dotnet/db-init.sh`. Select **Confirm** to confirm your cluster settings.

3. Navigate to your job and select **Run Now** to run your job on your newly configured Spark cluster. It takes a few minutes for the job's cluster to be created. Once it is created, your job will be submitted. You can view the output by selecting **Clusters** from the left menu of your Databricks workspace, then select **Driver Logs**.

## Deploy using Set Jar

Alternatively, you can use [Set Jar](https://docs.microsoft.com/azure/databricks/jobs#--create-a-job) in your Databricks workspace to submit .NET for Apache Spark jobs to Databricks. *Set Jar* allows job submission to an existing active cluster.

### One-time setup

1. Navigate to your Databricks cluster and select **Jobs** from the left-side menu, followed by **Set JAR**.

2. Upload the appropriate `microsoft-spark-<spark-version>-<spark-dotnet-version>.jar`.

3. Modify the following parameters to include the correct name for the executable that you published in place of `<your-app-name>`:

    ```
    Main Class: org.apache.spark.deploy.dotnet.DotnetRunner
    Arguments /dbfs/apps/<your-app-name>.zip <your-app-name>
    ```

4. Configure the cluster to point to an existing cluster for which you have already set the init script.

### Publish and run your app

1. Ensure you have published your app, and that your application code does not use `SparkSession.Stop()`.

2. Use [Databricks CLI](https://docs.microsoft.com/azure/databricks/dev-tools/databricks-cli) to upload your application to your Databricks cluster. For example, use the following command to upload your published app to your cluster:

    ```console
    cd <path-to-your-app-publish-directory>
    databricks fs cp <your-app-name>.zip dbfs:/apps/<your-app-name>.zip
    ```

3. If you have any user-defined functions in your app, the app assemblies, such as DLLs that contain user-defined functions along with their dependencies, need to be placed in the working directory of each *Microsoft.Spark.Worker*.

    Upload your application assemblies to your Databricks cluster:

    ```console
    cd <path-to-your-app-publish-directory>
    databricks fs cp <assembly>.dll dbfs:/apps/dependencies
    ```

    Uncomment and modify the app dependencies section in [db-init.sh](https://github.com/dotnet/spark/blob/master/deployment/db-init.sh) to point to your app dependencies path. Then, upload the updated *db-init.sh* to your cluster:

    ```console
    cd <path-to-db-init-and-install-worker>
    databricks fs cp db-init.sh dbfs:/spark-dotnet/db-init.sh
    ```

4. Navigate to **Databricks cluster > Jobs > [Job-name] > Run Now** to run your job.

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [Deploy a .NET for Apache Spark application to Databricks](../tutorials/databricks-deployment.md)
* [Azure Databricks Documentation](https://docs.microsoft.com/azure/azure-databricks/)
