---
title: Basic concepts for model training in ML.NET
description: This article explains the basic concepts covering *model training* scenarios in ML.NET. Not all concepts are relevant to the more simple scenario of *prediction with existing model*.
ms.date: 11/06/2018
ms.topic: overview
ms.custom: mvc
#Customer intent: As a developer, I want to learn the basic ML.NET concepts related to model training so that I can understand how to leverage machine learning in my applications.
---
# Basic concepts for model training in ML.NET

This article explains the basic concepts covering *model training* scenarios in ML.NET. Not all concepts are relevant to the more simple scenario of *prediction with existing model*.

## Model training concepts

This document covers the following concepts related to model training in ML.NET:

- [*Data*](#data) represented as an `IDataView` interface.
  - In ML.NET, data is similar to a SQL view: It's a lazily evaluated, immutable, cursorable, heterogenous, schematized dataset. 
  - An excellent document about the data interface is [IDataView Design Principles](https://github.com/dotnet/machinelearning/blob/master/docs/code/IDataViewDesignPrinciples.md).
- [*Transformer*](#transformer) represented as `ITransformer` interface.
  - A transformer is a component that takes data, does some work on it, and returns new transformed data.
  - For example, you can think of a machine learning model as a transformer that takes features and returns predictions.
  - Another example, text tokenizer takes a single text column and output a vector column with individual words extracted out of the texts.
- [*Data reader*](#data-reader) represented as an `IDataReader<T>` interface.
  - The data reader is ML.NET component to create data. It takes an instance of `T` and returns data out of it. 
  - For example, a *TextLoader* is an `IDataReader<FileSource>`. It takes the file source and produces data. 
- [*Estimator*](#estimator) represented as an `IEstimator<T>` interface.
  - This is an object that learns from data. The result of the learning is a *transformer*.
  - You can think of a machine learning *algorithm* as an estimator that learns on data and produces a machine learning *model*.
- [*Prediction function*](#prediction-function) represented as a `PredictionFunction<TSrc, TDst>` class.
  - The prediction function can be seen as a machine that applies a transformer to one row, such as at prediction time.

## Data

In ML.NET, data is similar to a SQL view: It's a lazily evaluated, cursorable, heterogenous, schematized dataset.

- It has *Schema* (an instance of an `ISchema` interface) that contains the information about the data view's columns.
  - Each column has a *Name*, a *Type*, and an arbitrary set of *metadata* associated with it.
  - The column's *metadata* contains information like slot names of a vector column and the like. The metadata itself is represented as another one-row *data* that is unique to each column.
  - The data view is a source of *cursors*. Think SQL cursors: A cursor is an object that iterates through the data, one row at a time, and presents the available data.
  - Naturally, data can have as many active cursors over it as needed. Since data itself is immutable, cursors are truly independent.
  - Cursors typically access only a subset of columns: For efficiency, ML.NET computes only the values of columns that are needed by the cursor.

## Transformer

A transformer is a component that takes data, does some work on it, and return new transformed data.

Most transformers in ML.NET tend to operate on one *input column* at a time, and produce the *output column*. For example, a `new HashTransformer("foo", "bar")` takes the values from column "foo", hash them, and put them into column "bar". 

It's also common that the input and output column names are the same. In this case, the old column is replaced with the new one. For example, a `new HashTransformer("foo")` takes the values from column "foo", hash them, and put them back into "foo". 

Any transformer, of course, produces a new data view when `Transform` is called. Remember, data views are immutable.

Another important consideration is that, because data is lazily evaluated, *transformers are lazy too*. Essentially, after you call

```csharp
var newData = transformer.Transform(oldData)
```

no actual computation happens. Only after you get a cursor from `newData` and start consuming the value does `newData` invoke the `transformer` transformation logic (and even that only if `transformer` in question is needed to produce the requested columns).

### Transformer chains

A useful property of a transformer is that *you can phrase a sequential application of transformers as yet another transformer*:

```csharp
var fullTransformer = transformer1.Append(transformer2).Append(transformer3);
```

This property is commonly used in ML.NET: typically, the trained ML.NET model is a chain of transformers, which is, for all intents and purposes, a *transformer*. 

## Data reader

The data reader is ML.NET component to 'create' data: it takes an instance of `T` and returns data out of it.

An interesting property to note is that you can create a data reader by attaching a transformer to an existing data reader. This way you can have a reader with transformation behavior baked in:

```c#
var newReader = reader.Append(transformer1).Append(transformer2)
```

Another similarity to transformers is that, since data is lazily evaluated, *readers are lazy*: no (or minimal) actual 'reading' happens when you call `dataReader.Read()`: only when a cursor is requested on the resulting data does the reader begin to work.

## Estimator

The *estimator* is an object that learns from data. The result of the learning is a *transformer*.

In ML.NET, use this property to create learning pipelines that chain together different estimators:

```csharp
MLContext mlContext = new MLContext(seed: 0);

var pipeline = new CopyColumnsEstimator(mlContext, "FareAmount", "Label")
.Append(mlContextml.Transforms.Categorical.OneHotEncoding(mlContext, "VendorId"))
.Append(mlContextml.Transforms.Categorical.OneHotEncoding(mlContext, "RateCode"))
.Append(mlContextml.Transforms.Categorical.OneHotEncoding(mlContext, "PaymentType"))
.Append(new ColumnConcatenatingEstimator(mlContext, "Features", "VendorId", "RateCode", "PassengerCount", "TripTime", "TripDistance", "PaymentType"))
.Append(mlContext.Regression.Trainers.FastTree("Label", "Features"));

var model = pipeline.Fit(dataView);
```

One important property of estimators is that *estimators are eager, not lazy*: every call to `Fit` is causing learning to happen, which is potentially a time-consuming operation.

## Prediction function

The prediction function can be seen as a machine that applies a transformer to one row.

Once you get the model (a *transformer* either trained via `Fit()`, or loaded from somewhere), you can use it to make predictions using the normal calls to `model.Transform(data)`. However, when you use this model in a real-life scenario, you often don't have many examples to predict on. Instead, you have one example at a time, and you need to make timely predictions on them immediately.

Of course, you can reduce this to the batch prediction:

- Create a data view with exactly one row.
- Call `model.Transform(data)` to get the predicted data view.
- Get a cursor over the resulting data.
- Advance the cursor one step to get to the first (and only) row.
- Extract the predicted values out of it.

The preceding algorithm can be implemented using the [schema comprehension](https://github.com/dotnet/machinelearning/blob/master/docs/code/SchemaComprehension.md), with two user-defined objects `InputExample` and `OutputPrediction` as follows:

```c#
var inputData = env.CreateDataView(new InputExample[] { example });
var outputData = model.Transform(inputData);
var output = outputData.AsDynamic.AsEnumerable<OutputPrediction>(env, reuseRowObject: false).Single();
```

But this is cumbersome and incurs performance costs. 
Instead, a prediction function object performs the same work, but faster and more convenient, via an extension method `MakePredictionFunction`:

```c#
var predictionFunc = model.MakePredictionFunction<InputExample, OutputPrediction>(env);
var output = predictionFunc.Predict(example);
```

The prediction function is *not re-entrant / thread-safe*. If you want to conduct predictions simultaneously with multiple threads, you need to have a prediction function per thread.
