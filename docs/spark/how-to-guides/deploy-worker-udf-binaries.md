---
title: Deploy .NET for Apache Spark worker and user-defined function binaries
description: Learn how to deploy .NET for Apache Spark worker and user-defined function binaries.
ms.date: 10/09/2020
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Deploy .NET for Apache Spark worker and user-defined function binaries

This how-to provides general instructions on how to deploy .NET for Apache Spark worker and user-defined function binaries. You learn which Environment Variables to set up, as well as some commonly used parameters for launching applications with `spark-submit`.

## Configurations

Configurations show the general environment variables and parameters settings in order to deploy .NET for Apache Spark worker and user-defined function binaries.

### Environment variables

When deploying workers and writing UDFs, there are a few commonly used environment variables that you may need to set:

| Environment Variable         | Description
| :--------------------------- | :----------
| DOTNET_WORKER_DIR            | Path where the <code>Microsoft.Spark.Worker</code> binary has been generated.</br>It's used by the Spark driver and will be passed to Spark executors. If this variable is not set up, the Spark executors will search the path specified in the <code>PATH</code> environment variable.</br>_e.g. "C:\bin\Microsoft.Spark.Worker"_
| DOTNET_ASSEMBLY_SEARCH_PATHS | Comma-separated paths where <code>Microsoft.Spark.Worker</code> will load assemblies.</br>Note that if a path starts with ".", the working directory will be prepended. If in **yarn mode**, "." would represent the container's working directory.</br>_e.g. "C:\Users\\&lt;user name&gt;\\&lt;mysparkapp&gt;\bin\Debug\\&lt;dotnet version&gt;"_
| DOTNET_WORKER_DEBUG          | If you want to <a href="https://github.com/dotnet/spark/blob/main/docs/developer-guide.md#debugging-user-defined-function-udf">debug a UDF</a>, then set this environment variable to <code>1</code> before running <code>spark-submit</code>.

### Parameter options

Once the Spark application is [bundled](https://spark.apache.org/docs/latest/submitting-applications.html#bundling-your-applications-dependencies), you can launch it using `spark-submit`. The following table shows some of the commonly used options:

| Parameter Name        | Description
| :---------------------| :----------
| --class               | The entry point for your application.</br>_e.g. org.apache.spark.deploy.dotnet.DotnetRunner_
| --master              | The <a href="https://spark.apache.org/docs/latest/submitting-applications.html#master-urls">master URL</a> for the cluster.</br>_e.g. yarn_
| --deploy-mode         | Whether to deploy your driver on the worker nodes (<code>cluster</code>) or locally as an external client (<code>client</code>).</br>Default: <code>client</code>
| --conf                | Arbitrary Spark configuration property in <code>key=value</code> format.</br>_e.g. spark.yarn.appMasterEnv.DOTNET_WORKER_DIR=.\worker\Microsoft.Spark.Worker_
| --files               | Comma-separated list of files to be placed in the working directory of each executor.<br/><ul><li>Please note that this option is only applicable for yarn mode.</li><li>It supports specifying file names with # similar to Hadoop.</br></ul>_e.g. <code>myLocalSparkApp.dll#appSeen.dll</code>. Your application should use the name as <code>appSeen.dll</code> to reference <code>myLocalSparkApp.dll</code> when running on YARN._</li>
| --archives          | Comma-separated list of archives to be extracted into the working directory of each executor.</br><ul><li>Please note that this option is only applicable for yarn mode.</li><li>It supports specifying file names with # similar to Hadoop.</br></ul>_e.g. <code>hdfs://&lt;path to your worker file&gt;/Microsoft.Spark.Worker.zip#worker</code>. This will copy and extract the zip file to <code>worker</code> folder._</li>
| application-jar       | Path to a bundled jar including your application and all dependencies.</br>_e.g. hdfs://&lt;path to your jar&gt;/microsoft-spark-&lt;version&gt;.jar_
| application-arguments | Arguments passed to the main method of your main class, if any.</br>_e.g. hdfs://&lt;path to your app&gt;/&lt;your app&gt;.zip &lt;your app name&gt; &lt;app args&gt;_

> [!NOTE]
> Specify all the `--options` before `application-jar` when launching applications with `spark-submit`, otherwise they will be ignored. For more information, see [`spark-submit` options](https://spark.apache.org/docs/latest/submitting-applications.html) and [running spark on YARN details](https://spark.apache.org/docs/latest/running-on-yarn.html).

## Frequently asked questions

### When I run a spark app with UDFs, I get a `FileNotFoundException` error. What should I do?

> **Error:** [Error] [TaskRunner] [0] ProcessStream() failed with exception: System.IO.FileNotFoundException: Assembly 'mySparkApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null' file not found: 'mySparkApp.dll'

**Answer:** Check that the `DOTNET_ASSEMBLY_SEARCH_PATHS` environment variable is set correctly. It should be the path that contains your `mySparkApp.dll`.

### After I upgraded my .NET for Apache Spark version and reset the `DOTNET_WORKER_DIR` environment variable, why do I still get the following `IOException` error?

> **Error:** Lost task 0.0 in stage 11.0 (TID 24, localhost, executor driver): java.io.IOException: Cannot run program "Microsoft.Spark.Worker.exe": CreateProcess error=2, The system cannot find the file specified.

**Answer:** Try restarting your PowerShell window (or other command windows) first so that it can take the latest environment variable values. Then start your program.

### After submitting my Spark application, I get the error `System.TypeLoadException: Could not load type 'System.Runtime.Remoting.Contexts.Context'`.

> **Error:** [Error] [TaskRunner] [0] ProcessStream() failed with exception: System.TypeLoadException: Could not load type 'System.Runtime.Remoting.Contexts.Context' from assembly 'mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=...'.

**Answer:** Check the `Microsoft.Spark.Worker` version you are using. There are two versions: **.NET Framework 4.6.1** and **.NET Core 3.1.x**. In this case, `Microsoft.Spark.Worker.net461.win-x64-<version>` (which you can [download](https://github.com/dotnet/spark/releases)) should be used since `System.Runtime.Remoting.Contexts.Context` is only for .NET Framework.

### How do I run my spark application with UDFs on YARN? Which environment variables and parameters should I use?

**Answer:** To launch the spark application on YARN, the environment variables should be specified as `spark.yarn.appMasterEnv.[EnvironmentVariableName]`. Please see below as an example using `spark-submit`:

```powershell
spark-submit \
--class org.apache.spark.deploy.dotnet.DotnetRunner \
--master yarn \
--deploy-mode cluster \
--conf spark.yarn.appMasterEnv.DOTNET_WORKER_DIR=./worker/Microsoft.Spark.Worker-<version> \
--conf spark.yarn.appMasterEnv.DOTNET_ASSEMBLY_SEARCH_PATHS=./udfs \
--archives hdfs://<path to your files>/Microsoft.Spark.Worker.net461.win-x64-<version>.zip#worker,hdfs://<path to your files>/mySparkApp.zip#udfs \
hdfs://<path to jar file>/microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar \
hdfs://<path to your files>/mySparkApp.zip mySparkApp
```

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [Debug a .NET for Apache Spark application on Windows](debug.md)
