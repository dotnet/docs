---
title: Installing .NET for Apache Spark on Azure HDInsight's Jupyter Notebooks
description: Learn how to install .NET for Apache Spark on Azure HDInsight's Jupyter Notebooks
ms.date: 02/20/2020
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Installing .NET for Apache Spark on Azure HDInsight's Jupyter Notebooks

This how-to provides the steps to install .NET for Apache Spark on Azure HDInsight's Jupyter Notebooks.

## Background

While we can deploy .NET for Apache Spark on HDI clusters through the command line/Azure portal (you can check out [how to deploy a .NET for Apache Spark application to Azure HDInsight](../tutorials/hdinsight-deployment.md) and [how to submit a .NET for Apache Spark job to Azure HDInsight](hdinsight-deploy-methods.md)), notebooks provide a more interactive and iterative experience.

Azure HDI clusters come with Jupyter notebook, so let's look how to configure those Jupyter notebooks to run .NET for Apache Spark. In order to use .NET for Apache Spark within your Jupyter Notebooks, a C# REPL is needed to execute your C# code line-by-line and to preserve execution state when necessary. We have integrated [Try .NET](https://github.com/dotnet/try) as our official dotnet REPL.

To provide the end-to-end notebook integration, we added a .NET for Apache Spark kernel to Jupyter kernel along with necessary modifications to [Apache Livy](https://github.com/apache/incubator-livy) and [sparkmagic](https://github.com/jupyter-incubator/sparkmagic) to HDI notebooks. Since these code changes have not yet been merged into the respective open source projects, you'll need to modify some components in your HDInsight Spark cluster to utilize .NET for Apache Spark in Jupyter notebooks.

To enable .NET for Apache Spark through the Jupyter Notebooks experience, you'll need to follow a few manual steps through [Ambari](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-manage-ambari) and submitting [script actions](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-customize-cluster-linux) on the HDInsight Spark cluster.

>**Disclaimer:** Please note that this is *experimental* and not supported by the HDInsight Spark team. We are working hard to get these changes into the respective projects so that in the future you will not have to perform these manual steps.

## Pre-requisites:
Create an [Azure HDInsight Spark](https://docs.microsoft.com/en-us/azure/hdinsight/spark/apache-spark-jupyter-spark-sql-use-portal#create-an-hdinsight-spark-cluster) cluster by visiting the **[Azure Portal](https;//portal.azure.com)**, selecting **+ Create a Resource**, and creating a new Azure HDInsight cluster resource. Ensure you select **Spark 2.4** and **HDI 4.0** during cluster creation.

## Installation Procedure
In the Azure Portal, select the **HDInsight Spark cluster** you created in the previous step.
### Step 1. Stop Livy Server
1.1 From the portal, select **Overview**, and then select **Ambari home**. If prompted, enter the cluster login credentials for the cluster.

<img src="../media/hdi-spark-notebooks/select-ambari.png" alt="StopLivyServerImage" width="800"/>

1.2 Select **Spark2**, and then select **LIVY FOR SPARK2 SERVER**.

<img src="../media/hdi-spark-notebooks/select-livyserver.png" alt="StopLivyServerImage" width="800"/>

1.3 Select **hn0... host**, stop **Livy for Spark2 Server** if started. When prompted, click **OK** to proceed.

- Select hn0 as shown below.
<img src="../media/hdi-spark-notebooks/select-host.png" alt="StopLivyServerImage" width="800"/>

- Stop Livy for Spark2 Server.
<img src="../media/hdi-spark-notebooks/stop-server.png" alt="StopLivyServerImage" width="800"/>

1.4 Please follow the same step for hn1... host.

### Step 2. Submit HDInsight Script Action

2.1 Create and upload `install-interactive-notebook.sh`.

The `install-interactive-notebook.sh` is a script that installs .NET for Apache Spark and makes changes to Apache Livy and sparkmagic. Before submitting Script Action to HDI, you'll need to create and upload `install-interactive-notebook.sh`.

* You can create a new file named **install-interactive-notebook.sh** in your local computer, and paste the contents of [install-interactive-notebook.sh contents](https://raw.githubusercontent.com/dotnet/spark/master/deployment/HDI-Spark/Notebooks/install-interactive-notebook.sh). 
* Then, upload the script to a [URI](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-customize-cluster-linux#understand-script-actions) that's accessible from the HDInsight cluster. (e.g. `https://<my storage account>.blob.core.windows.net/<my container>/<some dir>/install-interactive-notebook.sh`)

2.2 Run `install-interactive-notebook.sh` on the cluster using [HDInsight Script Actions](https://docs.microsoft.com/en-us/azure/hdinsight/hdinsight-hadoop-customize-cluster-linux).

Return to your HDI cluster in the Azure Portal, and select **Script actions** from the options on the left. You'll submit one script action to deploy the .NET for Apache Spark REPL on your HDInsight Spark cluster. Please see the following settings.

* Script type: Custom
* Name: Install .NET for Apache Spark Interactive Notebook Experience (or anything that is descriptive)
* Bash script URI: The URI to which you uploaded `install-interactive-notebook.sh`. 
* Node type(s): Head and Worker
* Parameters: .NET for Apache Spark version. You can check [.NET for Apache Spark release](https://github.com/dotnet/spark/releases). For example, if you want to install Sparkdotnet version 0.6.0 then it would be `0.6.0`.

<img src="../media/hdi-spark-notebooks/install-notebook-scriptaction.png" alt="the settings for the HDInsight Script Action"/>

Move to the next step when green checkmarks appear next to the status of the script action.

### Step 3. Start Livy Server
Please follow the above [Step 1](#step-1-stop-livy-server) to now **Start** (rather than **Stop**) the Livy for Spark2 Server for hosts hn0 and hn1.

### Step 4. Set up Spark Default Configs
4.1 From the portal, select **Overview**, and then select **Ambari home**. If prompted, enter the cluster login credentials for the cluster.

4.2 Select **Spark2**, and then **CONFIGS**. Then select **Custom spark2-defaults**.

<img src="../media/hdi-spark-notebooks/spark-configs.png" alt="SetConfigsImage" width="800"/>

4.3 Click on **Add Property...** to add Spark default settings.
You will add a total of 3 individual properties. Add them 1 one at a time, all using **TEXT** Property Type in Single property add mode. Make sure you don’t have any extra spaces before or after any of the keys/values.
- Property 1:
    - Key:&ensp;&ensp;`spark.dotnet.shell.command`
    - Value: `/usr/share/dotnet-tools/dotnet-try,kernel-server,--default-kernel,csharp`
- Property 2:
    - Key:&ensp;&ensp;`spark.dotnet.packages`
    - Value: `["nuget: Microsoft.Spark, 0.6.0", "nuget: Microsoft.Spark.Extensions.Delta, 0.6.0"]`
    
    Please use the version of .NET for Apache Spark which you had included in the previous script action.
- Property 3:
    - Key:&ensp;&ensp;`spark.dotnet.interpreter`
    - Value: `try`

For example, the following captures the setting for adding property 1:

<img src="../media/hdi-spark-notebooks/add-sparkconfig.png" alt="SetConfigsImage" width="800"/>

After adding those 3 properties, select **SAVE**. If you see a warning screen of config recommendations, select **PROCEED ANYWAY**.

4.4 Restart affected components.

After adding the new properties, you need to restart components that were affected by the changes. At the top, select **RESTART**, and then **Restart All Affected** from the drop-down.

<img src="../media/hdi-spark-notebooks/restart-affected.png" alt="SetConfigsImage" width="800"/>

When prompted, select **CONFIRM RESTART ALL** to continue, then click **OK** to finish.

## Submit Jobs through Jupyter Notebook
After finishing previous steps, now you can submit your jobs through Jupyter Notebook!
1. Create a new .NET for Apache Spark notebook

[Launch Jupyter notebook](https://docs.microsoft.com/en-us/azure/hdinsight/spark/apache-spark-jupyter-spark-sql-use-portal#create-a-jupyter-notebook) from your HDI cluster in the Azure Portal, then select **New** > **.NET Spark (C#)** to create a notebook.

<img src="../media/hdi-spark-notebooks/create-sparkdotnet-notebook.png" alt="JupyterNotebookImage" width="800"/>

### Step 2. Submit Jobs using .NET for Apache Spark

> **Note:** After the kernel is ready, then you can start submitting jobs. The following shows a sample to submit jobs through notebook.
- Start a spark session
<img src="../media/hdi-spark-notebooks/start-sparksession.png" alt="SubmitSparkJobImage" width="800"/>

- Create a Dataframe
<img src="../media/hdi-spark-notebooks/create-df.png" alt="SubmitSparkJobImage" width="800"/>

- Register Udf and use Udf via data frames
<img src="../media/hdi-spark-notebooks/run-udf.png" alt="SubmitSparkJobImage" width="800"/>

## Next steps

* [Deploy a .NET for Apache Spark application to Azure HDInsight](../tutorials/hdinsight-deployment.md)
* [HDInsight Documentation](https://docs.microsoft.com/azure/hdinsight/)
