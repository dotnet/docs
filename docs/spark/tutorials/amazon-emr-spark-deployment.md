---
title: Deploy a .NET for Apache Spark application to Amazon EMR Spark
description: Discover how to deploy a .NET for Apache Spark application to Amazon EMR Spark.
ms.date: 10/09/2020
ms.topic: tutorial
ms.custom: mvc
recommendations: false
#Customer intent: As a developer, I want to deployment .NET for Apache Spark application to Amazon EMR Spark.
---

# Deploy a .NET for Apache Spark application to Amazon EMR Spark

This tutorial teaches how to deploy a .NET for Apache Spark application to Amazon EMR Spark. [Amazon EMR](https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-what-is-emr.html) is a managed cluster platform that simplifies running big data frameworks on AWS.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> * Prepare Microsoft.Spark.Worker
> * Publish your Spark .NET app
> * Deploy your app to Amazon EMR Spark
> * Run your app

> [!Note]
> AWS EMR Spark is Linux-based. Therefore, if you are interested in deploying your app to AWS EMR Spark, make sure your app is .NET Standard compatible and that you use .NET Core compiler to compile your app.

## Prerequisites

Before you start, do the following:

* Download the [AWS CLI](https://aws.amazon.com/cli/).
* Download [install-worker.sh](https://github.com/dotnet/spark/blob/main/deployment/install-worker.sh) to your local machine. This is a helper script that you use later to copy .NET for Apache Spark dependent files into your Spark cluster's worker nodes.

## Prepare worker dependencies

**Microsoft.Spark.Worker** is a backend component that lives on the individual worker nodes of your Spark cluster. When you want to execute a C# UDF (User-Defined Function), Spark needs to understand how to launch the .NET CLR to execute the UDF. **Microsoft.Spark.Worker** provides a collection of classes to Spark that enable this functionality.

1. Select a [Microsoft.Spark.Worker](https://github.com/dotnet/spark/releases) Linux netcoreapp release to be deployed on your cluster.

   For example, if you want `.NET for Apache Spark v1.0.0` using `netcoreapp3.1`, you'd download [Microsoft.Spark.Worker.netcoreapp3.1.linux-x64-1.0.0.tar.gz](https://github.com/dotnet/spark/releases/download/v1.0.0/Microsoft.Spark.Worker.netcoreapp3.1.linux-x64-1.0.0.tar.gz).

2. Upload `Microsoft.Spark.Worker.<release>.tar.gz` and [install-worker.sh](https://github.com/dotnet/spark/blob/main/deployment/install-worker.sh) to a distributed file system (e.g., S3) that your cluster has access to.

## Prepare your .NET for Apache Spark app

1. Follow the [Get Started](get-started.md) tutorial to build your app.

2. Publish your Spark .NET app as self-contained.

   Run the following command on Linux.

   ```dotnetcli
   dotnet publish -c Release -f netcoreapp3.1 -r ubuntu.16.04-x64
   ```

3. Produce `<your app>.zip` for the published files.

   Run the following command on Linux using `zip`.

   ```bash
   zip -r <your app>.zip .
   ```

4. Upload the following items to a distributed file system (e.g., S3) that your cluster has access to:

   * `microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar`: This jar is included as part of the [Microsoft.Spark](https://www.nuget.org/packages/Microsoft.Spark/) NuGet package and is colocated in your app's build output directory.
   * `<your app>.zip`
   * Files (like dependency files or common data accessible to every worker) or assemblies (like DLLs that contain your user-defined functions or libraries that your app depends on) to be placed in the working directory of each executor.

## Deploy to Amazon EMR Spark

[Amazon EMR](https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-what-is-emr.html) is a managed cluster platform that simplifies running big data frameworks on AWS.

> [!NOTE]
> Amazon EMR Spark is Linux-based. Therefore, if you are interested in deploying your app to Amazon EMR Spark, make sure your app is .NET Standard compatible and that you use the [.NET Core compiler](https://dotnet.microsoft.com/download) to compile your app.

### Deploy Microsoft.Spark.Worker

This step is only required at cluster creation.

Run `install-worker.sh` during cluster creation using [Bootstrap Actions](https://docs.aws.amazon.com/emr/latest/ManagementGuide/emr-plan-bootstrap.html).

Run the following command on Linux using AWS CLI.

```bash
aws emr create-cluster \
--name "Test cluster" \
--release-label emr-5.23.0 \
--use-default-roles \
--ec2-attributes KeyName=myKey \
--applications Name=Spark \
--instance-count 3 \
--instance-type m1.medium \
--bootstrap-actions Path=s3://mybucket/<some dir>/install-worker.sh,Name="Install Microsoft.Spark.Worker",Args=["aws","s3://mybucket/<some dir>/Microsoft.Spark.Worker.<release>.tar.gz","/usr/local/bin"]
```

## Run your app

There are two ways to run your app in Amazon EMR Spark: spark-submit and Amazon EMR Steps.

### Use spark-submit

You can use the [spark-submit](https://spark.apache.org/docs/latest/submitting-applications.html) command to submit .NET for Apache Spark jobs to Amazon EMR Spark.

1. `ssh` into one of the nodes in the cluster.

2. Run `spark-submit`.

   ```bash
   spark-submit \
   --master yarn \
   --class org.apache.spark.deploy.dotnet.DotnetRunner \
   --files <comma-separated list of assemblies that contain UDF definitions, if any> \
   s3://mybucket/<some dir>/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar \
   s3://mybucket/<some dir>/<your app>.zip <your app> <app args>
   ```

### Use Amazon EMR Steps

[Amazon EMR Steps](https://docs.aws.amazon.com/emr/latest/ReleaseGuide/emr-spark-submit-step.html) can be used to submit jobs to the Spark framework installed on the EMR cluster.

Run the following command on Linux using AWS CLI.

```bash
aws emr add-steps \
--cluster-id j-xxxxxxxxxxxxx \
--steps Type=spark,Name="Spark Program",Args=[--master,yarn,--files,s3://mybucket/<some dir>/<udf assembly>,--class,org.apache.spark.deploy.dotnet.DotnetRunner,s3://mybucket/<some dir>/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar,s3://mybucket/<some dir>/<your app>.zip,<your app>,<app arg 1>,<app arg 2>,...,<app arg n>],ActionOnFailure=CONTINUE
```

## Next steps

In this tutorial, you deployed your .NET for Apache Spark application to Amazon EMR Spark. For .NET for Apache Spark example projects, continue to GitHub.

> [!div class="nextstepaction"]
> [.NET for Apache Spark samples](https://github.com/dotnet/spark/tree/main/examples)
