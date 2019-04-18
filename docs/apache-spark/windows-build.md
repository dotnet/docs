---
title: Build .NET for Apache Spark on Windows
description: Discover how to build .NET for Apache Spark on Windows.
ms.date: 05/01/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a .NET developer, I want to use Apache Spark.
---
# Tutorial: Build .NET for Apache Spark on Windows

This tutorial teaches you how to build .NET for Apache Spark on Windows. Once you have built .NET for Spark, you will run several sample applications.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Prepare your environment for .NET for Spark
> * Build the .NET for Spark Scala Extensions Layer
> * Build and run .NET sample applications


## Prepare your environment

1.  Download and install the [.NET Core 2.1x SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1). Installing the SDK adds the `dotnet` toolchain to your path. Use the PowerShell command `dotnet --version` to verify the installation.

2. Install [Visual Studio 2017](https://www.visualstudio.com/downloads/) or [Visual Studio 2019](https://visualstudio.microsoft.com/vs/preview/) with the latest updates. You can use Community, Professional, or Enterprise. The Community version is free. 

   Choose the following minimum requirements during installation:
       * .NET desktop development
           * All required components
           * .NET Framework 4.6.1 Development Tools
       * .NET Core cross-platform development
           * All required components

3. Install [Java 1.8](https://www.oracle.com/technetwork/java/javase/downloads/jdk8-downloads-2133151.html).
    * Select the appropriate version for your operating system. For example, select **jdk-8u201-windows-x64.exe** for a Windows x64 machine.
    * Use the PowerShell command `java -version` to verify the installation.

4. Install [Apache Maven 3.6.0+](https://maven.apache.org/download.cgi).
    * Download [Apache Maven 3.6.0](http://mirror.metrocast.net/apache/maven/maven-3/3.6.0/binaries/apache-maven-3.6.0-bin.zip).
    * Extract to a local directory. For example, `c:\bin\apache-maven-3.6.0\`.
    * Add Apache Maven to your [PATH environment variable](https://www.java.com/en/download/help/path.xml). If you extracted to `c:\bin\apache-maven-3.6.0\`, you would add `c:\bin\apache-maven-3.6.0\bin` to your PATH.
    * Use the PowerShell command `mvn -version` to verify the installation.

5. Install [Apache Spark 2.3+](https://spark.apache.org/downloads.html). Apache Spark 2.4+ is not supported.
    * Download [Apache Spark 2.3+](https://spark.apache.org/downloads.html) and extract it into a local folder using [7-zip](https://www.7-zip.org/). For example, you might extract it to `c:\bin\spark-2.3.2-bin-hadoop2.7\`.
    * Add Apache Spark to your [PATH environment variable](https://www.java.com/en/download/help/path.xml). If you extracted to `c:\bin\spark-2.3.2-bin-hadoop2.7\`, you would add `c:\bin\spark-2.3.2-bin-hadoop2.7\bin` to your PATH.
    * Add a [new environment variable](https://www.java.com/en/download/help/path.xml) called `SPARK_HOME`. If you extracted to `C:\bin\spark-2.3.2-bin-hadoop2.7\`, use  `C:\bin\spark-2.3.2-bin-hadoop2.7\` for the **Variable value**.
    * Verify you are able to run `spark-shell` from your command-line.

* Set up [WinUtils](https://github.com/steveloughran/winutils).
    * Download the **winutils.exe** binary from [WinUtils repository](https://github.com/steveloughran/winutils). You should select the version of Hadoop the Spark distribution was compiled with. For example, you use **hadoop-2.7.1** for **Spark 2.3.2**. The Hadoop version is annotated at the end of 
    * Save winutils.exe binary to a directory of your choice, e.g. c:\hadoop\bin.
    * Set `HADOOP_HOME` to reflect the directory with winutils.exe (without bin). For instance, using command-line:
    ```cmd
    set HADOOP_HOME=c:\hadoop
    ```
    * Set PATH environment variable to include `%HADOOP_HOME%\bin`. For instance, using command-line:
    ```cmd
    set PATH=%HADOOP_HOME%\bin;%PATH%
    ```

You may recieve the following error:
 
> ERROR Shell:397 - Failed to locate the winutils binary in the hadoop binary path
> java.io.IOException: Could not locate executable null\bin\winutils.exe in the Hadoop binaries.
        
You can ignore this if you are planning on running Spark in [Standalone mode](https://spark.apache.org/docs/latest/spark-standalone.html). If not, you would have to setup [WinUtils](https://github.com/steveloughran/winutils).
        
   * Download **winutils.exe** binary from [WinUtils repository](https://github.com/steveloughran/winutils). You should select the version of Hadoop the Spark distribution was compiled with, e.g. use hadoop-2.7.1 for Spark 2.3.2.
   * Save **winutils.exe** binary to a directory of your choice, e.g. c:\hadoop\bin.
   * Set `HADOOP_HOME` to reflect the directory with **winutils.exe** (without bin). For instance, using command-line:
    ```cmd
    set HADOOP_HOME=c:\hadoop
    ```
           
   * Set PATH environment variable to include `%HADOOP_HOME%\bin`. For instance, using command-line:
    ```
    set PATH=%HADOOP_HOME%\bin;%PATH%
    ```

Please make sure you are able to run `dotnet`, `java`, `mvn`, `spark-shell` from your command-line before you move to the next section.

## Clone .NET for Apache Spark repo

Use the following [GitBash](https://gitforwindows.org/) command to clone the .NET for Apache Spark repo to your machine. 

```bash
git clone https://github.com/dotnet/spark.git
```

## Building .NET for Spark Scala extensions layer

When you submit a .NET application, .NET for Spark has the necessary logic written in Scala to tell Apache Spark how to handle your requests. For example, if you request to create a new Spark Session, or request to transfer data from .NET to JVM. This logic can be found in the [Spark .NET Scala Source Code](https://github.com/dotnet/spark/tree/master/src/scala).

Regardless of whether you are using .NET Framework or .NET Core, you need to build the Spark .NET Scala extension layer. This is done by running the following command from the .NET for Apache Spark repo directory:

```
cd src\scala
mvn clean package 
```

You should see JARs created for the supported Spark versions:
* `microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-<version>.jar`
* `microsoft-spark-2.4.x\target\microsoft-spark-2.4.x-<version>.jar`

## Build the .NET samples application

1. Open `src\csharp\Microsoft.Spark.sln` in Visual Studio and build the `Microsoft.Spark.CSharp.Examples` project under the `examples` folder. This build will also build the .NET bindings project. If you want, you can write your own code in the `Microsoft.Spark.Examples` project:
  
      ```csharp
        // Instantiate a session
        var spark = SparkSession
            .Builder()
            .AppName("Hello Spark!")
            .GetOrCreate();

        var df = spark.Read().Json(args[0]);

        // Print schema
        df.PrintSchema();

        // Apply a filter and show results
        df.Filter(df["age"] > 21).Show();
      ```
     Once the build is successfuly, you will see the appropriate binaries produced in the output directory.
     <details>
     <summary>&#x1F4D9; Click to see sample console output</summary>
     
      ```
            Directory: C:\github\spark-dot-net\examples\Microsoft.Spark.CSharp.Examples\bin\Debug\net461


        Mode                LastWriteTime         Length Name
        ----                -------------         ------ ----
        -a----         3/6/2019  12:18 AM         125440 Apache.Arrow.dll
        -a----        3/16/2019  12:00 AM          13824 Microsoft.Spark.CSharp.Examples.exe
        -a----        3/16/2019  12:00 AM          19423 Microsoft.Spark.CSharp.Examples.exe.config
        -a----        3/16/2019  12:00 AM           2720 Microsoft.Spark.CSharp.Examples.pdb
        -a----        3/16/2019  12:00 AM         143360 Microsoft.Spark.dll
        -a----        3/16/2019  12:00 AM          63388 Microsoft.Spark.pdb
        -a----        3/16/2019  12:00 AM          34304 Microsoft.Spark.Worker.exe
        -a----        3/16/2019  12:00 AM          19423 Microsoft.Spark.Worker.exe.config
        -a----        3/16/2019  12:00 AM          11900 Microsoft.Spark.Worker.pdb
        -a----        3/16/2019  12:00 AM          23552 Microsoft.Spark.Worker.xml
        -a----        3/16/2019  12:00 AM         332363 Microsoft.Spark.xml
        ------------------------------------------- More framework files -------------------------------------
      ```

      </details>



# Run Samples

Once you build the samples, running them will be through `spark-submit` regardless of whether you are targeting .NET Framework or .NET Core apps. Make sure you have followed the [pre-requisites](#pre-requisites) section and installed Apache Spark.

  1. Open Powershell and go to the directory where your app binary has been generated (e.g., `c:\github\dotnet\spark\examples\Microsoft.Spark.CSharp.Examples\bin\Debug\net461` for .NET Framework, `c:\github\spark-dot-net\examples\Microsoft.Spark.CSharp.Examples\bin\Debug\netcoreapp2.1\win10-x64\publish` for .NET Core)
  2. Running your app follows the basic structure:
     ```powershell
     spark-submit.cmd `
       [--jars <any-jars-your-app-is-dependent-on>] `
       --class org.apache.spark.deploy.DotnetRunner `
       --master local `
       <path-to-microsoft-spark-jar> `
       <path-to-your-app-exe> <argument(s)-to-your-app>
     ```

     Here are some examples you can run:
     - **[Microsoft.Spark.Examples.Sql.Basic](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Basic.cs)**
         ```powershell
         spark-submit.cmd `
         --class org.apache.spark.deploy.DotnetRunner `
         --master local `
         C:\github\spark-dot-net\src\scala\microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-1.0.0-alpha.jar `
         Microsoft.Spark.CSharp.Examples.exe Sql.Basic %SPARK_HOME%\examples\src\main\resources\people.json
         ```
     - **[Microsoft.Spark.Examples.Sql.Streaming.StructuredNetworkWordCount](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCount.cs)**
         ```powershell
         spark-submit.cmd `
         --class org.apache.spark.deploy.DotnetRunner `
         --master local `
         C:\github\spark-dot-net\src\scala\microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-1.0.0-alpha.jar `
         Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredNetworkWordCount localhost 9999
         ```
     - **[Microsoft.Spark.Examples.Sql.Streaming.StructuredKafkaWordCount (maven accessible)](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs)**
         ```powershell
         spark-submit.cmd `
         --packages org.apache.spark:spark-sql-kafka-0-10_2.11:2.3.2 `
         --class org.apache.spark.deploy.DotnetRunner `
         --master local `
         C:\github\spark-dot-net\src\scala\microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-1.0.0-alpha.jar `
         Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredKafkaWordCount localhost:9092 subscribe test
         ```
     - **[Microsoft.Spark.Examples.Sql.Streaming.StructuredKafkaWordCount (jars provided)](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs)**
         ```powershell
         spark-submit.cmd 
         --jars path\to\net.jpountz.lz4\lz4-1.3.0.jar,path\to\org.apache.kafka\kafka-clients-0.10.0.1.jar,path\to\org.apache.spark\spark-sql-kafka-0-10_2.11-2.3.2.jar,`path\to\org.slf4j\slf4j-api-1.7.6.jar,path\to\org.spark-project.spark\unused-1.0.0.jar,path\to\org.xerial.snappy\snappy-java-1.1.2.6.jar `
         --class org.apache.spark.deploy.DotnetRunner `
         --master local `
         C:\github\spark-dot-net\src\scala\microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-1.0.0-alpha.jar `
         Microsoft.Spark.CSharp.Examples.exe Sql.Streaming.StructuredKafkaWordCount localhost:9092 subscribe test
          ```

Feel this experience is complicated? Help us by taking up [Simplify User Experience for Running an App](https://github.com/dotnet/spark/issues/6)

Congratulations! You've now successfully built a machine learning model for image classification by reusing a pre-trained `TensorFlow` model in ML.NET.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TransferLearningTF) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse and tune the pre-trained model
> * Classify images with a loaded model

Check out the Machine Learning samples GitHub repository to explore an expanded image classification sample.
> [!div class="nextstepaction"]
> [dotnet/machinelearning-samples GitHub repository](https://github.com/dotnet/machinelearning-samples/)
