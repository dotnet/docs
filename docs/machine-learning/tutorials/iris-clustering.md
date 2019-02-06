---
title: Cluster iris flowers using a clustering learner - ML.NET
description: Learn how to use ML.NET in a clustering scenario
author: pkulikov
ms.author: johalex
ms.date: 01/11/2019
ms.topic: tutorial
ms.custom: mvc, seodec18
#Customer intent: As a developer, I want to use ML.NET so that I can build a model to cluster iris flowers based on its parameters.
---
# Tutorial: Cluster iris flowers using a clustering learner with ML.NET

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, see the [ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This tutorial illustrates how to use ML.NET to build a [clustering model](../resources/tasks.md#clustering) for the [iris flower data set](https://en.wikipedia.org/wiki/Iris_flower_data_set).

In this tutorial, you learn how to:
> [!div class="checklist"]
> - Understand the problem
> - Select the appropriate machine learning task
> - Prepare the data
> - Load and transform the data
> - Choose a learning algorithm
> - Train the model
> - Use the model for predictions

## Prerequisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

## Understand the problem

This problem is about dividing the set of iris flowers in different groups based on the flower features. Those features are the length and width of a sepal and the length and width of a petal. For this tutorial, assume that the type of each flower is unknown. You want to learn the structure of a data set from the features and predict how a data instance fits this structure.

## Select the appropriate machine learning task

As you don't know to which group each flower belongs to, you choose the [unsupervised machine learning](../resources/glossary.md#unsupervised-machine-learning) task. To divide a data set in groups in such a way that elements in the same group are more similar to each other than to those in other groups, use a [clustering](../resources/tasks.md#clustering) machine learning task.

## Create a console application

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "IrisFlowerClustering" and then select the **OK** button.

1. Create a directory named *Data* in your project to store the data set and model files:

    In **Solution Explorer**, right-click the project and select **Add** > **New Folder**. Type "Data" and hit Enter.

1. Install the **Microsoft.ML** NuGet package:

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare the data

1. Download the [iris.data](https://github.com/dotnet/machinelearning/blob/master/test/data/iris.data) data set and save it to the *Data* folder you've created at the previous step. For more information about the iris data set, see the [Iris flower data set](https://en.wikipedia.org/wiki/Iris_flower_data_set) Wikipedia page and the [Iris Data Set](https://archive.ics.uci.edu/ml/datasets/Iris) page, which is the source of the data set.

1. In **Solution Explorer**, right-click the *iris.data* file and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

The *iris.data* file contains five columns that represent:

- sepal length in centimetres
- sepal width in centimetres
- petal length in centimetres
- petal width in centimetres
- type of iris flower

For the sake of the clustering example, this tutorial ignores the last column.

## Create data classes

Create classes for the input data and the predictions:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *IrisData.cs*. Then, select the **Add** button.
1. Add the following `using` directive to the new file:

   [!code-csharp[Add necessary usings](~/samples/machine-learning/tutorials/IrisFlowerClustering/IrisData.cs#Usings)]

Remove the existing class definition and add the following code, which defines the classes `IrisData` and `ClusterPrediction`, to the *IrisData.cs* file:

[!code-csharp[Define data classes](~/samples/machine-learning/tutorials/IrisFlowerClustering/IrisData.cs#ClassDefinitions)]

`IrisData` is the input data class and has definitions for each feature from the data set. Use the [Column](xref:Microsoft.ML.Data.ColumnAttribute) attribute to specify the indices of the source columns in the data set file.

The `ClusterPrediction` class represents the output of the clustering model applied to an `IrisData` instance. Use the [ColumnName](xref:Microsoft.ML.Data.ColumnNameAttribute) attribute to bind the `PredictedClusterId` and `Distances` fields to the **PredictedLabel** and **Score** columns respectively. In case of the clustering task those columns have the following meaning:

- **PredictedLabel** column contains the ID of the predicted cluster.
- **Score** column contains an array with squared Euclidean distances to the cluster centroids. The array length is equal to the number of clusters.

> [!NOTE]
> Use the `float` type to represent floating-point values in the input and prediction data classes.

## Define data and model paths

Go back to the *Program.cs* file and add two fields to hold the paths to the data set file and to the file to save the model:

- `_dataPath` contains the path to the file with the data set used to train the model.
- `_modelPath` contains the path to the file where the trained model is stored.

Add the following code right above the `Main` method to specify those paths:

[!code-csharp[Initialize paths](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#Paths)]

To make the preceding code compile, add the following `using` directives at the top of the *Program.cs* file:

[!code-csharp[Add usings for paths](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#UsingsForPaths)]

## Create ML context

Add the following additional `using` directives to the top of the *Program.cs* file:

[!code-csharp[Add Microsoft.ML usings](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#MLUsings)]

In the `Main` method, replace the `Console.WriteLine("Hello World!");` line with the following code:

[!code-csharp[Create ML context](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#CreateContext)]

The <xref:Microsoft.ML.MLContext?displayProperty=nameWithType> class represents the machine learning environment and provides mechanisms for logging and entry points for data loading, model training, prediction, and other tasks. This is comparable conceptually to using `DbContext` in Entity Framework.

## Setup data loading

Add the following code to the `Main` method to setup the way to load data:

[!code-csharp[Create text loader](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#SetupTextLoader)]

Note that the column names and indices match the schema defined by the `IrisData` class. The <xref:Microsoft.ML.Data.DataKind.R4?displayProperty=nameWithType> value specifies the `float` type.

Use instantiated <xref:Microsoft.ML.Data.TextLoader> instance to create an <xref:Microsoft.ML.Data.IDataView> instance, which represents the data source for the training data set:

[!code-csharp[Create IDataView](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#CreateDataView)]

## Create a learning pipeline

For this tutorial, the learning pipeline of the clustering task comprises two following steps:

- concatenate loaded columns into one **Features** column, which is used by a clustering trainer;
- use a <xref:Microsoft.ML.Trainers.KMeans.KMeansPlusPlusTrainer> trainer to train the model using the k-means++ clustering algorithm.

Add the following code to the `Main` method:

[!code-csharp[Create pipeline](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#CreatePipeline)]

The code specifies that the data set should be split in three clusters.

## Train the model

The steps added in the preceding sections prepared the pipeline for training, however, none have been executed. Add the following line to the `Main` method to perform data loading and model training:

[!code-csharp[Train the model](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#TrainModel)]

### Save the model

At this point, you have a model that can be integrated into any of your existing or new .NET applications. To save your model to a .zip file, add the following code to the `Main` method:

[!code-csharp[Save the model](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#SaveModel)]

## Use the model for predictions

To make predictions, use the <xref:Microsoft.ML.PredictionEngine%602> class that takes instances of the input type through the transformer pipeline and produces instances of the output type. Add the following line to the `Main` method to create an instance of that class:

[!code-csharp[Create predictor](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#Predictor)]

Create the `TestIrisData` class to house test data instances:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TestIrisData.cs*. Then, select the **Add** button.
1. Modify the class to be static like in the following example:

   [!code-csharp[Make class static](~/samples/machine-learning/tutorials/IrisFlowerClustering/TestIrisData.cs#Static)]

This tutorial introduces one iris data instance within this class. You can add other scenarios to experiment with the model. Add the following code into the `TestIrisData` class:

[!code-csharp[Test data](~/samples/machine-learning/tutorials/IrisFlowerClustering/TestIrisData.cs#TestData)]

To find out the cluster to which the specified item belongs to, go back to the *Program.cs* file and add the following code into the `Main` method:

[!code-csharp[Predict and output results](~/samples/machine-learning/tutorials/IrisFlowerClustering/Program.cs#PredictionExample)]

Run the program to see which cluster contains the specified data instance and squared distances from that instance to the cluster centroids. Your results should be similar to the following:

```text
Cluster: 2
Distances: 11.69127 0.02159119 25.59896
```

Congratulations! You've now successfully built a machine learning model for iris clustering and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/IrisFlowerClustering) GitHub repository.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
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
