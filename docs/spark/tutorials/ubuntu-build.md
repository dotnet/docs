---
title: Build .NET for Apache Spark sample applications on Ubuntu
description: Discover how to build .NET for Apache Spark applications on Ubuntu.
ms.date: 05/06/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a .NET developer, I want to use Apache Spark on Ubuntu.
---

# Tutorial: Build .NET for Apache Spark sample applications on Ubuntu

This tutorial teaches you how to build .NET for Apache Spark applications on Ubuntu. Once you have prepared your environment, you will run several sample applications.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Prepare your Ubuntu environment for .NET for Spark
> * Build and run .NET sample applications

## Prepare your environment

Before you begin, make sure you can run `dotnet`, `java`, `mvn`, `spark-shell` from your command-line. If your environment is already prepared, you can skip to the next section. If you cannot run any or all of the commands, follow the steps below.

1.  Download and install the [.NET Core 2.1x SDK](https://dotnet.microsoft.com/download/dotnet-core/2.1). Installing the SDK adds the `dotnet` toolchain to your PATH. Use the PowerShell command `dotnet --version` to verify the installation.

2. Install [OpenJDK 8](https://openjdk.java.net/install/).
   * You can use the following command:
    ```bash
    sudo apt install openjdk-8-jdk
    ```
   * Verify you are able to run `java` from your command-line.

   If you already have multiple OpenJDK versions installed and want to select OpenJDK 8, use the following command:

    ```bash
    sudo update-alternatives --config java
    ```

3. Install [Apache Maven 3.6.0+](https://maven.apache.org/download.cgi).

   * Run the following command:
    ```bash
    mkdir -p ~/bin/maven
    cd ~/bin/maven
    wget https://www-us.apache.org/dist/maven/maven-3/.6.0/binaries/apache-maven-3.6.0-bin.tar.gz
    tar -xvzf apache-maven-3.6.0-bin.tar.gz
    ln -s apache-maven-3.6.0 current
    export M2_HOME=~/bin/maven/current
    export PATH=${M2_HOME}/bin:${PATH}
    source ~/.bashrc
    ```
       
    Note that these environment variables will be lost when you close your terminal. If you want the changes to be permanent, add the `export` lines to your `~/.bashrc` file.

   * Verify you are able to run `mvn` from your command-line.
 
4. Install [Apache Spark 2.3+](https://spark.apache.org/downloads.html).

   * Download [Apache Spark 2.3+](https://spark.apache.org/downloads.html) and extract it into a local folder. For example, `~/bin/spark-2.3.2-bin-hadoop2.7`.

   * Add the necessary [environment variables](https://www.java.com/en/download/help/path.xml). For example, add the variable `SPARK_HOME` with the value `~/bin/spark-2.3.2-bin-hadoop2.7/`.

   ```bash
   export SPARK_HOME=~/bin/spark-2.3.2-hadoop2.7
   export PATH="$SPARK_HOME/bin:$PATH"
   source ~/.bashrc
   ```
       
   Note that these environment variables will be lost when you close your terminal. If you want the changes to be permanent, add the `export` lines to your `~/.bashrc` file.

   * Verify you are able to run `spark-shell` from your command-line
       
Please make sure you are able to run `dotnet`, `java`, `mvn`, `spark-shell` from your command-line before you move to the next section.

## Clone .NET for Apache Spark repo

Use the following [GitBash](https://gitforwindows.org/) command to clone the .NET for Apache Spark repo to your machine. 

```bash
git clone https://github.com/dotnet/spark.git ~/dotnet.spark
```

## Building .NET for Spark Scala extensions layer

When you submit a .NET application, .NET for Spark has the necessary logic written in Scala to tell Apache Spark how to handle your requests. For example, if you request to create a new Spark Session, or request to transfer data from .NET to JVM. This logic can be found in the [Spark .NET Scala Source Code](https://github.com/dotnet/spark/tree/master/src/scala).

Regardless of whether you are using .NET Framework or .NET Core, you need to build the Spark .NET Scala extension layer. This is done by running the following command from the .NET for Apache Spark repo directory:

```bash
cd src/scala
mvn clean package 
```

You should see JARs created for the supported Spark versions:
* `microsoft-spark-2.3.x\target\microsoft-spark-2.3.x-<version>.jar`
* `microsoft-spark-2.4.x\target\microsoft-spark-2.4.x-<version>.jar`

## Build .NET sample applications using .NET Core CLI

1. Use the following command to build the Worker.

```bash
cd ~/dotnet.spark/src/csharp/icrosoft.Spark.Worker/
dotnet publish -f netcoreapp2.1 -r buntu.18.04-x64
```
      
2. Build the samples.
  
   **.NET Core 2.1.x**

   For .NET Core 2.1.x, you have to modify the `.csproj`    file using the following command:
         
   ```bash
   cd ~/dotnet.spark/examples/   Microsoft.Spark.CSharp.Examples/
   cat Microsoft.Spark.CSharp.Examples.csproj | grep -v    "Microsoft.Spark.Worker.csproj" >    Microsoft.Spark.CSharp.Examples.Patched.csproj
   dotnet publish -f netcoreapp2.1 -r ubuntu.18.04-x64    Microsoft.Spark.CSharp.Examples.Patched.csproj
   ```
         
   **.NET Core 3.x**
   
   If you are using .NET Core 3.x, you can avoid creating a    new patched `.csproj` file and instead compile the    project directly:
   
   ```bash
   cd ~/dotnet.spark/examples/   Microsoft.Spark.CSharp.Examples/
         
   dotnet publish -f netcoreapp2.1 -r ubuntu.18.04-x64    Microsoft.Spark.CSharp.Examples.csproj
   ```

3. Manually copy the Worker binaries into the Samples output location. 
     
```bash
cp ~/dotnet.spark/src/csharp/Microsoft.Spark.Worker/bin/Debug/netcoreapp2.1/ubuntu.18.04-x64/publish/* ~/dotnet.spark/examples/Microsoft.Spark.CSharp.Examples/bin/Debug/netcoreapp2.1/ubuntu.18.04-x64/publish/
```

# Run the samples

Once you build the samples, you can use `spark-submit` to submit your .NET Core apps.

1. Open a terminal and go to the directory where your app binary has been generated. For example, `~/dotnet.spark/examples/Microsoft.Spark.CSharp.Examples/bin/Debug/netcoreapp2.1/ubuntu.18.04-x64/publish`.

2. The command to run your app follows the basic structure below:

   ```bash
   spark-submit \
     [--jars <any-jars-your-app-is-dependent-on>] \
     --class org.apache.spark.deploy.DotnetRunner \
     --master local \
     <path-to-microsoft-spark-jar> \
     <path-to-your-app-binary> <argument(s)-to-your-app>
   ```

   Run the following examples:

   * [Microsoft.Spark.Examples.Sql.Basic](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Basic.cs)

   ```bash
   spark-submit \
   --class org.apache.spark.deploy.DotnetRunner \
   --master local \
   ~/dotnet.spark/src/scala/microsoft-spark-2.3.x/target/microsoft-spark-2.3.x-1.0.0-alpha.jar \
   Microsoft.Spark.CSharp.Examples Sql.Basic $SPARK_HOME/examples/src/main/resources/people.json
   ```
   * [Microsoft.Spark.Examples.Sql.Streaming.StructuredNetworkWordCount](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredNetworkWordCount.cs)

   ```bash
   spark-submit \
   --class org.apache.spark.deploy.DotnetRunner \
   --master local \
   ~/dotnet.spark/src/scala/microsoft-spark-2.3.x/target/microsoft-spark-2.3.x-1.0.0-alpha.jar \
   Microsoft.Spark.CSharp.Examples Sql.Streaming.StructuredNetworkWordCount localhost 9999
   ```

   * [Microsoft.Spark.Examples.Sql.Streaming.StructuredKafkaWordCount (maven accessible)](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs)**
         
   ```bash
   spark-submit \
   --packages org.apache.spark:spark-sql-kafka-0-10_2.11:2.3.2 \
   --class org.apache.spark.deploy.DotnetRunner \
   --master local \
   ~/dotnet.spark/src/scala/microsoft-spark-2.3.x/target/microsoft-spark-2.3.x-1.0.0-alpha.jar \
   Microsoft.Spark.CSharp.Examples Sql.Streaming.StructuredKafkaWordCount localhost:9092 subscribe test
   ```

   * [Microsoft.Spark.Examples.Sql.Streaming.StructuredKafkaWordCount (jars provided)](../../examples/Microsoft.Spark.CSharp.Examples/Sql/Streaming/StructuredKafkaWordCount.cs)

   ```bash
   spark-submit \
   --jars path/to/net.jpountz.lz4/lz4-1.3.0.jar,path/to/org.apache.kafka/kafka-clients-0.10.0.1.jar,path/to/org.apache.spark/   park-sql-kafka-0-10_2.11-2.3.2.jar,`path/to/org.slf4j/slf4j-api-1.7.6.jar,path/to/org.spark-project.spark/   nused-1.0.0.jar,path/to/org.xerial.snappy/snappy-java-1.1.2.6.jar \
   --class org.apache.spark.deploy.DotnetRunner \
   --master local \
   ~/dotnet.spark/src/scala/microsoft-spark-2.3.x/target/microsoft-spark-2.3.x-1.0.0-alpha.jar \
   Microsoft.Spark.CSharp.Examples Sql.Streaming.StructuredKafkaWordCount localhost:9092 subscribe test
   ```


Congratulations! You've now successfully built and executed several .NET for Apache Spark applications.

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Prepare your Ubuntu environment for .NET for Spark
> * Build and run .NET sample applications

