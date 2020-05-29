# Guide to using Broadcast Variables

This is a guide to show how to use broadcast variables in .NET for Apache Spark.

## What are Broadcast Variables

[Broadcast variables in Apache Spark](https://spark.apache.org/docs/2.2.0/rdd-programming-guide.html#broadcast-variables) are a mechanism for sharing variables across executors that are meant to be read-only. They allow the programmer to keep a read-only variable cached on each machine rather than shipping a copy of it with tasks. They can be used, for example, to give every node a copy of a large input dataset in an efficient manner.

### How to use broadcast variables in .NET for Apache Spark

Broadcast variables are created from a variable `v` by calling `SparkContext.Broadcast(v)`. The broadcast variable is a wrapper around `v`, and its value can be accessed by calling the `Value()` method. 

Example:

```csharp
string v = "Variable to be broadcasted";
Broadcast<string> bv = SparkContext.Broadcast(v);

// Using the broadcast variable in a UDF:
Func<Column, Column> udf = Udf<string, string>(
    str => $"{str}: {bv.Value()}");
```

The type parameter for `Broadcast` should be the type of the variable being broadcasted.

### Deleting broadcast variables

The broadcast variable can be deleted from all executors by calling the `Destroy()` method on it.

```csharp
// Destroying the broadcast variable bv:
bv.Destroy();
```

> Note: `Destroy()` deletes all data and metadata related to the broadcast variable. Use this with caution - once a broadcast variable has been destroyed, it cannot be used again.

#### Caveat of using Destroy

One important thing to keep in mind while using broadcast variables in UDFs is to limit the scope of the variable to only the UDF that is referencing it. The [guide to using UDFs](udf-guide.md) describes this phenomenon in detail. This is especially crucial when calling `Destroy` on the broadcast variable. If the broadcast variable that has been destroyed is visible to or accessible from other UDFs, it gets picked up for serialization by all those UDFs, even if it is not being referenced by them. This will throw an error as .NET for Apache Spark is not able to serialize the destroyed broadcast variable.

Example to demonstrate:

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

The recommended way of implementing above desired behavior:

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
 This ensures that destroying `bv` doesn't affect calling `udf2` because of unexpected serialization behavior. 

 Broadcast variables are useful for transmitting read-only data to all executors, as the data is sent only once and this can give performance benefits when compared with using local variables that get shipped to the executors with each task. Please refer to the [official documentation](https://spark.apache.org/docs/2.2.0/rdd-programming-guide.html#broadcast-variables) to get a deeper understanding of broadcast variables and why they are used.