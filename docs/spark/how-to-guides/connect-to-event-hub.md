---
title: Connect .NET for Apache Spark to Azure Event Hubs
description: Learn how to connect to Azure Event Hub from local .NET for Apache Spark instance.
ms.author: nidutta
author: Niharikadutta
ms.date: 12/16/2022
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Connect .NET for Apache Spark to Azure Event Hubs

In this article, you will learn how to connect your [.NET for Apache Spark](https://github.com/dotnet/spark) application with Azure Event Hubs to read and write Apache Kafka streams.

[!INCLUDE [.NET Core 3.1 Warning](./includes/net-core-31-spark.md)]

## Prerequisites

Have an Event Hubs Namespace ready with an event hub. For a step-by-step guide, refer to [Quickstart: Create an event hub using Azure portal](/azure/event-hubs/event-hubs-create). Make sure to select the Standard Pricing tier while creating the Event Hub Namespace.

## What is Azure Event Hubs

[Azure Event Hubs](/azure/event-hubs/event-hubs-about) is a big-data streaming platform and event-ingestion service. It is a fully managed Platform-as-a-Service (PaaS) that can easily integrate with [Apache Kafka](https://kafka.apache.org/) to give you the PaaS Kafka experience without having to manage, configure, or run your own clusters.

## Connect your application to Azure Event Hubs

1. Get the Event Hubs connection string and fully qualified domain name (FQDN) for later use. For instructions, see [Get an Event Hubs connection string](/azure/event-hubs/event-hubs-get-connection-string).
2. Set the following configurations with details from your namespace in your code to start reading from Event Hubs for Kafka:
    1. Update **BOOTSTRAP_SERVERS** and **EH_SASL** in your application like so:

    ```csharp
    string BOOTSTRAP_SERVERS = "hostname:9093"; // 9093 is the port used to communicate with Event Hubs, see [troubleshooting guide](https://learn.microsoft.com/azure/event-hubs/troubleshooting-guide)
    string EH_SASL = "org.apache.kafka.common.security.plain.PlainLoginModule required username=\"$ConnectionString\" password=\"<CONNECTION_STRING>\";"; // Connection string obtained from Step 1
    ```

## Read from Azure Event Hub stream

You can now start streaming with Event Hubs as you would with Kafka. Sample code as shown below:

```csharp
SparkSession spark = SparkSession
    .Builder()
    .AppName("Connect Event Hub")
    .GetOrCreate();

DataFrame df = spark
    .ReadStream()
    .Format("kafka")
    .Option("kafka.bootstrap.servers", BOOTSTRAP_SERVERS)
    .Option("subscribe", "spark-test")
    .Option("kafka.sasl.mechanism", "PLAIN")
    .Option("kafka.security.protocol", "SASL_SSL")
    .Option("kafka.sasl.jaas.config", EH_SASL)
    .Option("kafka.request.timeout.ms", "60000")
    .Option("kafka.session.timeout.ms", "60000")
    .Option("failOnDataLoss", "false")
    .Load();

DataFrame dfWrite = df
    .WriteStream()
    .OutputMode("append")
    .Format("console")
    .Start();
```

## Write to Azure Event Hub stream

You can also write to Event Hubs in the same way, as shown below:

```csharp
// df is the DataFrame to write

df.WriteStream()
    .Format("kafka")
    .Option("topic", topics)
    .Option("kafka.bootstrap.servers", BOOTSTRAP_SERVERS)
    .Option("kafka.sasl.mechanism", "PLAIN")
    .Option("kafka.security.protocol", "SASL_SSL")
    .Option("kafka.sasl.jaas.config", EH_SASL)
    .Option("checkpointLocation", "./checkpoint")
    .Start();
```

## Run your application

In order to run your .NET for Apache Spark application, define the `spark-sql-kafka-0-10` module as part of the build definition in your Spark project, using `libraryDependency` in `build.sbt` for sbt projects. For Spark environments such as `spark-submit` (or `spark-shell`), use the `--packages` command-line option like so:

```bash
spark-shell --packages org.apache.spark:spark-sql-kafka-0-10_2.12:2.4.5
```

> [!NOTE]
> Make sure to include the package version in accordance with the version of Spark being run.
