---
title: 'Tutorial: Categorize iris flowers - k-means clustering'
description: Learn how to use ML.NET in a clustering scenario
author: pkulikov
ms.date: 11/11/2021
ms.topic: tutorial
ms.custom: mvc, title-hack-0516
recommendations: false
#Customer intent: As a developer, I want to use ML.NET so that I can build a k-means clustering model to categorize iris flowers based on its parameters.
---
# Tutorial: Categorize iris flowers using k-means clustering with ML.NET

This tutorial illustrates how to use ML.NET to build a [clustering model](../resources/tasks.md#clustering) for the [iris flower data set](https://en.wikipedia.org/wiki/Iris_flower_data_set).

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Understand the problem
> - Select the appropriate machine learning task
> - Prepare the data
> - Load and transform the data
> - Choose a learning algorithm
> - Train the model
> - Use the model for predictions

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).

## Understand the problem

This problem is about dividing the set of iris flowers in different groups based on the flower features. Those features are the length and width of a sepal and the length and width of a petal. For this tutorial, assume that the type of each flower is unknown. You want to learn the structure of a data set from the features and predict how a data instance fits this structure.

## Select the appropriate machine learning task

As you don't know to which group each flower belongs to, you choose the [unsupervised machine learning](../resources/glossary.md#unsupervised-machine-learning) task. To divide a data set in groups in such a way that elements in the same group are more similar to each other than to those in other groups, use a [clustering](../resources/tasks.md#clustering) machine learning task.

## Create a console application

1. Create a C# **Console Application** called "IrisFlowerClustering". Click the **Next** button.

1. Choose .NET 6 as the framework to use. Click the **Create** button.

1. Create a directory named *Data* in your project to store the data set and model files:

    In **Solution Explorer**, right-click the project and select **Add** > **New Folder**. Type "Data" and hit Enter.

1. Install the **Microsoft.ML** NuGet package:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML** and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare the data

1. Download the [iris.data](https://github.com/dotnet/machinelearning/blob/main/test/data/iris.data) data set and save it to the *Data* folder you've created at the previous step. For more information about the iris data set, see the [Iris flower data set](https://en.wikipedia.org/wiki/Iris_flower_data_set) Wikipedia page and the [Iris Data Set](http://archive.ics.uci.edu/ml/datasets/Iris) page, which is the source of the data set.

1. In **Solution Explorer**, right-click the *iris.data* file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

The *iris.data* file contains five columns that represent:

- sepal length in centimeters
- sepal width in centimeters
- petal length in centimeters
- petal width in centimeters
- type of iris flower

For the sake of the clustering example, this tutorial ignores the last column.

## Create data classes

Create classes for the input data and the predictions:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *IrisData.cs*. Then, select the **Add** button.
1. Add the following `using` directive to the new file:

   [!code-csharp[Add necessary usings](./snippets/iris-clustering/csharp/IrisData.cs#Usings)]

Remove the existing class definition and add the following code, which defines the classes `IrisData` and `ClusterPrediction`, to the *IrisData.cs* file:

[!code-csharp[Define data classes](./snippets/iris-clustering/csharp/IrisData.cs#ClassDefinitions)]

`IrisData` is the input data class and has definitions for each feature from the data set. Use the [LoadColumn](xref:Microsoft.ML.Data.LoadColumnAttribute) attribute to specify the indices of the source columns in the data set file.

The `ClusterPrediction` class represents the output of the clustering model applied to an `IrisData` instance. Use the [ColumnName](xref:Microsoft.ML.Data.ColumnNameAttribute) attribute to bind the `PredictedClusterId` and `Distances` fields to the **PredictedLabel** and **Score** columns respectively. In case of the clustering task those columns have the following meaning:

- **PredictedLabel** column contains the ID of the predicted cluster.
- **Score** column contains an array with squared Euclidean distances to the cluster centroids. The array length is equal to the number of clusters.

> [!NOTE]
> Use the `float` type to represent floating-point values in the input and prediction data classes.

## Define data and model paths

Go back to the *Program.cs* file and add two fields to hold the paths to the data set file and to the file to save the model:

- `_dataPath` contains the path to the file with the data set used to train the model.
- `_modelPath` contains the path to the file where the trained model is stored.

Add the following code under the using statements to specify those paths:

[!code-csharp[Initialize paths](./snippets/iris-clustering/csharp/Program.cs#Paths)]

## Create ML context

Add the following additional `using` directives to the top of the *Program.cs* file:

[!code-csharp[Add Microsoft.ML usings](./snippets/iris-clustering/csharp/Program.cs#MLUsings)]

Replace the `Console.WriteLine("Hello World!");` line with the following code:

[!code-csharp[Create ML context](./snippets/iris-clustering/csharp/Program.cs#CreateContext)]

The <xref:Microsoft.ML.MLContext?displayProperty=nameWithType> class represents the machine learning environment and provides mechanisms for logging and entry points for data loading, model training, prediction, and other tasks. This is comparable conceptually to using `DbContext` in Entity Framework.

## Set up data loading

Add the following code below the `MLContext` to set up the way to load data:

[!code-csharp[Create text loader](./snippets/iris-clustering/csharp/Program.cs#CreateDataView)]

The generic [`MLContext.Data.LoadFromTextFile` extension method](xref:Microsoft.ML.TextLoaderSaverCatalog.LoadFromTextFile%60%601%28Microsoft.ML.DataOperationsCatalog,System.String,System.Char,System.Boolean,System.Boolean,System.Boolean,System.Boolean%29) infers the data set schema from the provided `IrisData` type and returns <xref:Microsoft.ML.IDataView> which can be used as input for transformers.

## Create a learning pipeline

For this tutorial, the learning pipeline of the clustering task comprises two following steps:

- concatenate loaded columns into one **Features** column, which is used by a clustering trainer;
- use a <xref:Microsoft.ML.Trainers.KMeansTrainer> trainer to train the model using the k-means++ clustering algorithm.

Add the following after loading the data:

[!code-csharp[Create pipeline](./snippets/iris-clustering/csharp/Program.cs#CreatePipeline)]

The code specifies that the data set should be split in three clusters.

## Train the model

The steps added in the preceding sections prepared the pipeline for training, however, none have been executed. Add the following line at the bottom of the file to perform data loading and model training:

[!code-csharp[Train the model](./snippets/iris-clustering/csharp/Program.cs#TrainModel)]

### Save the model

At this point, you have a model that can be integrated into any of your existing or new .NET applications. To save your model to a .zip file, add the following code below calling the `Fit` method:

[!code-csharp[Save the model](./snippets/iris-clustering/csharp/Program.cs#SaveModel)]

## Use the model for predictions

To make predictions, use the <xref:Microsoft.ML.PredictionEngine%602> class that takes instances of the input type through the transformer pipeline and produces instances of the output type. Add the following line to create an instance of that class:

[!code-csharp[Create predictor](./snippets/iris-clustering/csharp/Program.cs#Predictor)]

The [PredictionEngine](xref:Microsoft.ML.PredictionEngine%602) is a convenience API, which allows you to perform a prediction on a single instance of data. [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) is not thread-safe. It's acceptable to use in single-threaded or prototype environments. For improved performance and thread safety in production environments, use the `PredictionEnginePool` service, which creates an [`ObjectPool`](xref:Microsoft.Extensions.ObjectPool.ObjectPool%601) of [`PredictionEngine`](xref:Microsoft.ML.PredictionEngine%602) objects for use throughout your application. See this guide on how to [use `PredictionEnginePool` in an ASP.NET Core Web API](../how-to-guides/serve-model-web-api-ml-net.md#register-predictionenginepool-for-use-in-the-application).

> [!NOTE]
> `PredictionEnginePool` service extension is currently in preview.

Create the `TestIrisData` class to house test data instances:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TestIrisData.cs*. Then, select the **Add** button.
1. Modify the class to be static like in the following example:

   [!code-csharp[Make class static](./snippets/iris-clustering/csharp/TestIrisData.cs#Static)]

This tutorial introduces one iris data instance within this class. You can add other scenarios to experiment with the model. Add the following code into the `TestIrisData` class:

[!code-csharp[Test data](./snippets/iris-clustering/csharp/TestIrisData.cs#TestData)]

To find out the cluster to which the specified item belongs to, go back to the *Program.cs* file and add the following code at the bottom of the file:

[!code-csharp[Predict and output results](./snippets/iris-clustering/csharp/Program.cs#PredictionExample)]

Run the program to see which cluster contains the specified data instance and squared distances from that instance to the cluster centroids. Your results should be similar to the following:

```text
Cluster: 2
Distances: 11.69127 0.02159119 25.59896
```

Congratulations! You've now successfully built a machine learning model for iris clustering and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/IrisFlowerClustering) GitHub repository.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> - Understand the problem
> - Select the appropriate machine learning task
> - Prepare the data
> - Load and transform the data
> - Choose a learning algorithm
> - Train the model
> - Use the model for predictions

Check out our GitHub repository to continue learning and find more samples.
> [!div class="nextstepaction"]
> [dotnet/machinelearning GitHub repository](https://github.com/dotnet/machinelearning/)
