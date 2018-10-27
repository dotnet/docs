---
title: Use ML.NET to cluster iris flowers (clustering)
description: Learn how to use ML.NET in a clustering scenario
author: pkulikov
ms.author: johalex
ms.date: 07/02/2018
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can build a model to cluster iris flowers based on its parameters.
---
# Tutorial: Use ML.NET to cluster iris flowers (clustering)

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

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "IrisClustering" and then select the **OK** button.

1. Create a directory named *Data* in your project to store the data set and model files:

    In **Solution Explorer**, right-click the project and select **Add** > **New Folder**. Type "Data" and hit Enter.

1. Install the **Microsoft.ML** NuGet package:

    In **Solution Explorer**, right-click the project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the **Browse** tab, search for **Microsoft.ML**, select that package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.

## Prepare the data

1. Download the [iris.data](https://github.com/dotnet/machinelearning/blob/master/test/data/iris.data) data set and save it to the *Data* folder you've created at the previous step. For more information about the iris data set, see the [Iris flower data set](https://en.wikipedia.org/wiki/Iris_flower_data_set) Wikipedia page and the [Iris Data Set](http://archive.ics.uci.edu/ml/datasets/Iris) page, which is the source of the data set.

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

   [!code-csharp[Add necessary usings](../../../samples/machine-learning/tutorials/IrisClustering/IrisData.cs#1)]

Remove the existing class definition and add the following code, which defines the classes `IrisData` and `ClusterPrediction`, to the *IrisData.cs* file:

[!code-csharp[Define data classes](../../../samples/machine-learning/tutorials/IrisClustering/IrisData.cs#2)]

`IrisData` is the input data class and has definitions for each feature from the data set. Use the [Column](xref:Microsoft.ML.Runtime.Api.ColumnAttribute) attribute to specify the indices of the source columns in the data set file.

The `ClusterPrediction` class represents the output of the clustering model applied to an `IrisData` instance. Use the [ColumnName](xref:Microsoft.ML.Runtime.Api.ColumnNameAttribute) attribute to bind the `PredictedClusterId` and `Distances` fields to the **PredictedLabel** and **Score** columns respectively. In case of the clustering task those columns have the following meaning:

- **PredictedLabel** column contains the ID of the predicted cluster.
- **Score** column contains an array with squared Euclidean distances to the cluster centroids. The array length is equal to the number of clusters.

> [!NOTE]
> Use the `float` type to represent floating-point values in the input and prediction data classes.

## Define data and model paths

Go back to the *Program.cs* file and add two fields to hold the paths to the data set file and to the file to save the model:

- `_dataPath` contains the path to the file with the data set used to train the model.
- `_modelPath` contains the path to the file where the trained model is stored.

Add the following code right above the `Main` method to specify those paths:

[!code-csharp[Initialize paths](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#1)]

To make the preceding code compile, add the following `using` directives at the top of the *Program.cs* file:

[!code-csharp[Add usings for paths](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#2)]

## Create a learning pipeline

Add the following additional `using` directives to the top of the *Program.cs* file:

[!code-csharp[Add Microsoft.ML usings](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#3)]

In the `Main` method, replace the `Console.WriteLine("Hello World!")` with the following code:

[!code-csharp[Call the Train method](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#4)]

The `Train` method trains the model. Create that method just below the `Main` method, using the following code:

```csharp
private static PredictionModel<IrisData, ClusterPrediction> Train()
{

}
```

The learning pipeline loads all of the data and algorithms necessary to train the model. Add the following code into the `Train` method:

[!code-csharp[Initialize pipeline](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#5)]

## Load and transform data

The first step to perform is to load the training data set. In our case, the training data set is stored in the text file with a path defined by the `_dataPath` field. Columns in the file are separated by the comma (","). Add the following code into the `Train` method:

[!code-csharp[Add step to load data](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#6)]

The next step is to combine all of the feature columns into the **Features** column using the <xref:Microsoft.ML.Legacy.Transforms.ColumnConcatenator> transformation class. By default, a learning algorithm processes only features from the **Features** column. Add the following code:

[!code-csharp[Add step to concatenate columns](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#7)]

## Choose a learning algorithm

After adding the data to the pipeline and transforming it into the correct input format, you select a learning algorithm (**learner**). The learner trains the model. ML.NET provides a <xref:Microsoft.ML.Legacy.Trainers.KMeansPlusPlusClusterer> learner that implements [k-means algorithm](https://en.wikipedia.org/wiki/K-means_clustering) with an improved method for choosing the initial cluster centroids.

Add the following code into the `Train` method following the data processing code added in the previous step:

[!code-csharp[Add a learner step](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#8)]

Use the <xref:Microsoft.ML.Legacy.Trainers.KMeansPlusPlusClusterer.K?displayProperty=nameWithType> property to specify number of clusters. The code above specifies that the data set should be split in three clusters.

## Train the model

The steps added in the preceding sections prepared the pipeline for training, however, none have been executed. The `pipeline.Train<TInput, TOutput>` method produces the model that takes in an instance of the `TInput` type and outputs an instance of the `TOutput` type. Add the following code into the `Train` method:

[!code-csharp[Train the model and return](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#9)]

### Save the model

At this point, you have a model that can be integrated into any of your existing or new .NET applications. To save your model to a .zip file, add the following code to the `Main` method below the call to the `Train` method:

[!code-csharp[Save the model](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#10)]

Using `await` in the `Main` method means the `Main` method must have the `async` modifier and return a `Task`:

[!code-csharp[Make the Main method async](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#11)]

You also need to add the following `using` directive at the top of the *Program.cs* file:

[!code-csharp[Add System.Threading.Tasks using](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#12)]

Because the `async Main` method is the feature added in C# 7.1 and the default language version of the project is C# 7.0, you need to change the language version to C# 7.1 or higher. To do that, right-click the project node in **Solution Explorer** and select **Properties**. Select the **Build** tab and select the **Advanced** button. In the dropdown, select  **C# 7.1** (or a higher version). Select the **OK** button.

## Use the model for predictions

Create the `TestIrisData` class to house test data instances:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *TestIrisData.cs*. Then, select the **Add** button.
1. Modify the class to be static like in the following example:

   [!code-csharp[Make class static](../../../samples/machine-learning/tutorials/IrisClustering/TestIrisData.cs#1)]

This tutorial introduces one iris data instance within this class. You can add other scenarios to experiment with the model. Add the following code into the `TestIrisData` class:

[!code-csharp[Test data](../../../samples/machine-learning/tutorials/IrisClustering/TestIrisData.cs#2)]

To find out the cluster to which the specified item belongs to, go back to the *Program.cs* file and add the following code into the `Main` method:

[!code-csharp[Predict and output results](../../../samples/machine-learning/tutorials/IrisClustering/Program.cs#13)]

Run the program to see which cluster contains the specified data instance and squared distances from that instance to the cluster centroids. Your results should be similar to the following. As the pipeline processes, it might display warnings or processing messages. These have been removed from the following output for clarity.

```text
Cluster: 2
Distances: 0.4192338 0.0008847713 0.9660053
```

Congratulations! You've now successfully built a machine learning model for iris clustering and used it to make predictions. You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/IrisClustering) GitHub repository.

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
