# Guide to User-Defined Functions (UDFs)

This is a guide to show how to use UDFs in .NET for Apache Spark.

## What are UDFs

[User-Defined Functions (UDFs)](https://spark.apache.org/docs/latest/api/java/org/apache/spark/sql/expressions/UserDefinedFunction.html) are a feature of Spark that allow developers to use custom functions to extend the system's built-in functionality. They transform values from a single row within a table to produce a single corresponding output value per row based on the logic defined in the UDF.

Let's take the following as an example for a UDF definition:

```csharp
string s1 = "hello";
Func<Column, Column> udf = Udf<string, string>(
    str => $"{s1} {str}");

```
The above defined UDF takes a `string` as an input (in the form of a [Column](https://github.com/dotnet/spark/blob/master/src/csharp/Microsoft.Spark/Sql/Column.cs#L14) of a [Dataframe](https://github.com/dotnet/spark/blob/master/src/csharp/Microsoft.Spark/Sql/DataFrame.cs#L24)), and returns a `string` with `hello` appended in front of the input.

For a sample Dataframe, let's take the following Dataframe `df`:

```text
+-------+
|   name|
+-------+
|Michael|
|   Andy|
| Justin|
+-------+
```

Now let's apply the above defined `udf` to the dataframe `df`:

```csharp
DataFrame udfResult = df.Select(udf(df["name"]));
```

This would return the below as the Dataframe `udfResult`:

```text
+-------------+
|         name|
+-------------+
|hello Michael|
|   hello Andy|
| hello Justin|
+-------------+
```
To get a better understanding of how to implement UDFs, please take a look at the [UDF helper functions](https://github.com/dotnet/spark/blob/master/src/csharp/Microsoft.Spark/Sql/Functions.cs#L3616) and some [test examples](https://github.com/dotnet/spark/blob/master/src/csharp/Microsoft.Spark.E2ETest/UdfTests/UdfSimpleTypesTests.cs#L49).

## UDF serialization

Since UDFs are functions that need to be executed on the workers, they have to be serialized and sent to the workers as part of the payload from the driver. This involves serializing the [delegate](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/delegates/) which is a reference to the method, along with its [target](https://docs.microsoft.com/en-us/dotnet/api/system.delegate.target?view=netframework-4.8) which is the class instance on which the current delegate invokes the instance method. Please take a look at this [code](https://github.com/dotnet/spark/blob/master/src/csharp/Microsoft.Spark/Utils/CommandSerDe.cs#L149) to get a better understanding of how UDF serialization is being done.

## Good to know while implementing UDFs

One behavior to be aware of while implementing UDFs in .NET for Apache Spark is how the target of the UDF gets serialized. .NET for Apache Spark uses .NET Core, which does not support serializing delegates, so it is instead done by using reflection to serialize the target where the delegate is defined. When multiple delegates are defined in a common scope, they have a shared closure that becomes the target of reflection for serialization. Let's take an example to illustrate what that means.

The following code snippet defines two string variables that are being referenced in two function delegates that return the respective strings as result:

```csharp
using System;

public class C {
    public void M() {
        string s1 = "s1";
        string s2 = "s2";
        Func<string, string> a = str => s1;
        Func<string, string> b = str => s2;
    }
}
```

The above C# code generates the following C# disassembly (credit source: [sharplab.io](https://sharplab.io)) code from the compiler:

```csharp
public class C
{
    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        public string s1;

        public string s2;

        internal string <M>b__0(string str)
        {
            return s1;
        }

        internal string <M>b__1(string str)
        {
            return s2;
        }
    }

    public void M()
    {
        <>c__DisplayClass0_0 <>c__DisplayClass0_ = new <>c__DisplayClass0_0();
        <>c__DisplayClass0_.s1 = "s1";
        <>c__DisplayClass0_.s2 = "s2";
        Func<string, string> func = new Func<string, string>(<>c__DisplayClass0_.<M>b__0);
        Func<string, string> func2 = new Func<string, string>(<>c__DisplayClass0_.<M>b__1);
    }
}
```
As can be seen in the above decompiled code, both `func` and `func2` share the same closure `<>c__DisplayClass0_0`, which is the target that is serialized when serializing the delegates `func` and `func2`. Hence, even though `Func<string, string> a` is only referencing `s1`, `s2` also gets serialized when sending over the bytes to the workers.

This can lead to some unexpected behaviors at runtime (like in the case of using [broadcast variables](broadcast-guide.md)), which is why we recommend restricting the visibility of the variables used in a function to that function's scope.

Going back to the above example, the following is the recommended way to implement the desired behavior of previous code snippet:

```csharp
using System;

public class C {
    public void M() {
        {
            string s1 = "s1";
            Func<string, string> a = str => s1;
        }
        {
            string s2 = "s2";
            Func<string, string> b = str => s2;
        }
    }
}
```

The above C# code generates the following C# disassembly (credit source: [sharplab.io](https://sharplab.io)) code from the compiler:

```csharp
public class C
{
    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_0
    {
        public string s1;

        internal string <M>b__0(string str)
        {
            return s1;
        }
    }

    [CompilerGenerated]
    private sealed class <>c__DisplayClass0_1
    {
        public string s2;

        internal string <M>b__1(string str)
        {
            return s2;
        }
    }

    public void M()
    {
        <>c__DisplayClass0_0 <>c__DisplayClass0_ = new <>c__DisplayClass0_0();
        <>c__DisplayClass0_.s1 = "s1";
        Func<string, string> func = new Func<string, string>(<>c__DisplayClass0_.<M>b__0);
        <>c__DisplayClass0_1 <>c__DisplayClass0_2 = new <>c__DisplayClass0_1();
        <>c__DisplayClass0_2.s2 = "s2";
        Func<string, string> func2 = new Func<string, string>(<>c__DisplayClass0_2.<M>b__1);
    }
}
```

Here we see that `func` and `func2` no longer share a closure and have their own separate closures `<>c__DisplayClass0_0` and `<>c__DisplayClass0_1` respectively. When used as the target for serialization, nothing other than the referenced variables will get serialized for the delegate.

This behavior is important to keep in mind while implementing multiple UDFs in a common scope. 
To learn more about UDFs in general, please review the following articles that explain UDFs and how to use them: [UDFs in databricks(scala)](https://docs.databricks.com/spark/latest/spark-sql/udf-scala.html), [Spark UDFs and some gotchas](https://medium.com/@achilleus/spark-udfs-we-can-use-them-but-should-we-use-them-2c5a561fde6d).