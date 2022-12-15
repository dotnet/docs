---
title: Connect .NET for Apache Spark to MongoDB
description: Learn how to connect to your MongoDB instance from your .NET for Apache Spark application.
ms.author: nidutta
author: Niharikadutta
ms.date: 12/16/2022
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Connect .NET for Apache Spark to MongoDB

In this article, you learn how to connect to a MongoDB instance from your .NET for Apache Spark application.

[!INCLUDE [.NET Core 3.1 Warning](../../includes/net-core-31-spark.md)]

## Prerequisites

- Have a MongoDB server up and running with a [database and some collection](https://docs.mongodb.com/manual/core/databases-and-collections/) added to it (Download [this community server](https://www.mongodb.com/try/download/community) for a local server or you can try [MongoDB Atlas](https://www.mongodb.com/cloud/atlas) for a cloud MongoDB service.)

## Set up your MongoDB instance

In order to get .NET for Apache Spark to talk to your MongoDB instance you need to make sure it is set up correctly by doing the following:

1. Create a username and password for your application to connect through, and give the user the necessary permissions/roles using the following command through mongo shell:

    ```bash
    use database
    db.createUser(
      {
        user: "mySparkUser",
        pwd: "<password>",
        roles: [ { role: "userAdminAnyDatabase", db: "admin" }, "readWriteAnyDatabase" ]
      }
    )
    ```

2. Make sure the IP address of the machine your .NET for Apache Spark application is running on is allowlisted for the MongoDB server to be able to connect to. You can refer to [this guide](https://docs.atlas.mongodb.com/security/add-ip-address-to-list/) to learn how to do that.

## Configure your .NET for Apache Spark application

1. Have the following variables set to configure your application to talk to the MongoDB instance and read from a collection.
    1. **authURI**: "Connection string authorizing your application to connect to the required MongoDB instance". The format for that is as follows:

        ```
        "mongodb+srv://<username>:<password>@<cluster_address>/<database>.<collection>"
        ```

    2. **username**: Username of the account you created in Step 1 of the previous section
    3. **password**: Password of the user account created
    4. **cluster_address**: hostname/address of your MongoDB cluster
    5. **database**: The MongoDB database you want to connect to
    6. **collection**: The MongoDB collection you want to read. (For this example we use the standard [`people.json`](https://github.com/apache/spark/blob/master/examples/src/main/resources/people.json) example file provided with every Apache Spark installation.)

2. Use the `com.mongodb.spark.sql.DefaultSource` format is `spark.Read()` as shown below in a simple code snippet:

    ```csharp
    class Program
    {
        static void Main()
        {
            var authURI = "mongodb+srv://<username>:<password>@<cluster_address>/<database>.<collection>?retryWrites=true&w=majority";
            SparkSession spark = SparkSession
                .Builder()
                .AppName("Connect to Mongo DB example")
                .Config("spark.mongodb.input.uri", authURI)
                .GetOrCreate();

            DataFrame df = spark.Read().Format("com.mongodb.spark.sql.DefaultSource").Load();
            df.PrintSchema();
            df.Show();
            spark.Stop();
        }
    }
    ```

## Run your application

In order to run your .NET for Apache Spark application, you should define the `mongo-spark-connector` module as part of the build definition in your Spark project, using `libraryDependency` in `build.sbt` for sbt projects. For Spark environments such as `spark-submit` (or `spark-shell`), use the `--packages` command-line option like so:

```bash
spark-submit --master local --packages org.mongodb.spark:mongo-spark-connector_2.12:3.0.0 --class org.apache.spark.deploy.dotnet.DotnetRunner microsoft-spark-<spark_majorversion-spark_minorversion>_<scala_majorversion.scala_minorversion>-<spark_dotnet_version>.jar yourApp.exe
```

> [!NOTE]
> Make sure to include the package version in accordance with the version of Spark being run.

The result as displayed is the DataFrame (`df`) shown here:

```text
+--------------------+----+-------+
|                 _id| age|   name|
+--------------------+----+-------+
|[5f7c28438029a134...|null|Michael|
|[5f7c287f8029a134...|  30|   Andy|
|[5f7c289a8029a134...|  19| Justin|
+--------------------+----+-------+
```
