---
title: Use broadcast variables in .NET for Apache Spark
description: Learn how to use broadcast variables in .NET for Apache Spark applications.
ms.author: nidutta
author: Niharikadutta
ms.date: 12/16/2022
ms.topic: conceptual
ms.custom: mvc,how-to
---

# Use broadcast variables in .NET for Apache Spark

In this article, you learn how to use broadcast variables in .NET for Apache Spark. [Broadcast variables in Apache Spark](https://spark.apache.org/docs/2.2.0/rdd-programming-guide.html#broadcast-variables) are mechanisms for sharing variables across executors that are meant to be read-only. Broadcast variables allow you to keep a read-only variable cached on each machine rather than shipping a copy of it with tasks. You can use broadcast variables to give every node a copy of a large input dataset in an efficient manner.

Because the data is sent only once, broadcast variables have performance benefits when compared to local variables that are shipped to the executors with each task. Refer to the [official broadcast variable documentation](https://spark.apache.org/docs/2.2.0/rdd-programming-guide.html#broadcast-variables) to get a deeper understanding of broadcast variables and why they are used.

[!INCLUDE [.NET Core 3.1 Warning](../includes/net-core-31-spark.md)]

## Create broadcast variables

To create a broadcast variable, call `SparkContext.Broadcast(v)` for any variable `v`. The broadcast variable is a wrapper around the variable `v`, and its value can be accessed by calling the `Value()` method.

In the following code snippet, a string variable `v` is created, and a broadcast variable `bv` is created when `SparkContext.Broadcast(v)`is called. Notice the type parameter for `Broadcast`, string, matches the type of the variable being broadcasted. The user-defined function (UDF) returns the value of `bv`.

```csharp
string v = "Variable to be broadcasted";
Broadcast<string> bv = SparkContext.Broadcast(v);

Func<Column, Column> udf = Udf<string, string>(
    str => $"{str}: {bv.Value()}");
```

## Delete broadcast variables

The broadcast variable can be deleted from all executors by calling the `Destroy()` method.

```csharp
bv.Destroy();
```

`Destroy()` deletes all data and metadata related to the broadcast variable and should be used with caution. Once a broadcast variable is destroyed, it can't be used again.

## Limit broadcast variable scope in UDFs

When you use broadcast variables in UDFs, you need to limit the scope of the variable to only the UDF that is referencing the variable. The [guide to using UDFs](udf-guide.md) describes this phenomenon in detail. Scope is especially crucial when you call `Destroy()` on the broadcast variable.

If the broadcast variable that has been destroyed is visible to or accessible from other UDFs, it gets picked up for serialization by all of the UDFs, even if it is not being referenced by them. .NET for Apache Spark is unable to serialize the destroyed broadcast variable, which results in an error. The following code snippet demonstrates this error:

```csharp
string v = "Variable to be broadcasted";
Broadcast<string> bv = SparkContext.Broadcast(v);

// Using the broadcast variable in a UDF:
Func<Column, Column> udf1 = Udf<string, string>(
    str => $"{str}: {bv.Value()}");

// Destroying bv
bv.Destroy();

// Calling udf1 after destroying bv throws the following expected exception:
// org.apache.spark.SparkException: Attempted to use Broadcast(0) after it was destroyed
df.Select(udf1(df["_1"])).Show();

// Different UDF udf2 that is not referencing bv
Func<Column, Column> udf2 = Udf<string, string>(
    str => $"{str}: not referencing broadcast variable");

// Calling udf2 throws the following (unexpected) exception:
// [Error] [JvmBridge] org.apache.spark.SparkException: Task not serializable
df.Select(udf2(df["_1"])).Show();
```

The following code snippet demonstrates how to ensure that destroying `bv` doesn't affect `udf2` because of an unexpected serialization behavior:

```csharp
string v = "Variable to be broadcasted";
// Restricting the visibility of bv to only the UDF referencing it
{
    Broadcast<string> bv = SparkContext.Broadcast(v);

    // Using the broadcast variable in a UDF:
    Func<Column, Column> udf1 = Udf<string, string>(
        str => $"{str}: {bv.Value()}");

    // Destroying bv
    bv.Destroy();
}

// Different UDF udf2 that is not referencing bv
Func<Column, Column> udf2 = Udf<string, string>(
    str => $"{str}: not referencing broadcast variable");

// Calling udf2 works fine as expected
df.Select(udf2(df["_1"])).Show();
```

## FAQs

**Why don't Broadcast Variables work with .NET Interactive?**  
Broadcast variables don't work with interactive scenarios because of .NET interactive's design of appending each object defined in a cell with its cell submission class, which since is not marked serializable, fails with the same exception as shown previously. For more information, please check out [this article](dotnet-interactive-udf-issue.md).

## Next steps

* [Get started with .NET for Apache Spark](../tutorials/get-started.md)
* [Debug a .NET for Apache Spark application on Windows](debug.md)
* [Deploy .NET for Apache Spark worker and user-defined function binaries](deploy-worker-udf-binaries.md)
