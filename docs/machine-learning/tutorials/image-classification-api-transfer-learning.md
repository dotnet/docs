---
title: 'Tutorial: Automated visual inspection using transfer learning'
description: This tutorial illustrates how to use transfer learning to train a TensorFlow deep learning model in ML.NET using the image detection API to classify images of concrete surfaces as cracked or not cracked.
author: luisquintanilla
ms.author: luquinta
ms.date: 10/03/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can use transfer learning in an image classification scenario to classify images using a pretrained TensorFlow model and ML.NET's Image Classification API.
---

# Tutorial: Automated visual inspection using transfer learning with ML.NET's Image Classification API

Learn to train a custom deep learning model using transfer learning and the ML.NET Image Classification API to classify images of concrete surfaces as cracked or uncracked.

> [!NOTE]
> The ML.NET Image Classification API is currently in preview.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Understand the problem
> - Learn about ML.NET Image Classification API
> - Understand the pretrained model
> - Use transfer learning to train a custom TensorFlow image classification model
> - Classify images with the custom model

## Image Classification Transfer Learning Sample Overview

This sample is a .NET Core console application that classifies images using a pre-trained deep learning TensorFlow model. The code for this sample can be found on the [dotnet/machinelearning-samples repository](https://github.com/dotnet/machinelearning-samples) on GitHub.

## Understand the problem

Image classification is a computer vision problem. Image classification takes an image as input and categorizes it into a prescribed class. Some scenarios where image classification is useful include:

- Facial Recognition
- Emotion detection
- Medical diagnosis
- Landmark detection

This tutorial trains a custom image classification model to perform automated visual inspection of bridge decks to identify structures that are damaged by cracks.

## ML.NET Image Classification API

ML.NET provides various ways of performing image classification. This tutorial focuses on the Image Classification API. The Image Classification API makes use of [TensorFlow.NET](https://github.com/SciSharp/TensorFlow.NET), a low-level library that provides C# bindings for the TensorFlow C++ API.

![](./media/image-classification-api-transfer-learning/architecture.png)

### What is transfer learning?

Transfer learning is the process of using knowledge gained while solving one problem and applying it to a different but related problem.

Training a deep learning model from scratch requires setting several parameters, a large amount of labeled training data and a vast amount of compute resources (hundreds of GPU hours). Using a pre-trained model along with transfer learning allows you to shortcut the training process. 

### Training process

The Image Classification API starts the training process by loading a pre-trained TensorFlow model. The training process consists of two steps:

1. Bottleneck phase
2. Training phase

![](./media/image-classification-api-transfer-learning/training.png)

#### Bottleneck Phase

During the bottleneck phase, the set of training images is loaded and transformed into a format expected by the pre-trained model. These transformations include resizing the image and extracting the pixels into a tensor. A tensor can be thought of as a container that stores data in N-dimensions. Once pre-processed, the data is used as input, or features, for the frozen layers of the model. The frozen layers include all of the layers in the neural network, except the penultimate (bottleneck) layer. These layers are referred to as frozen because no training will occur on these layers and operations are pass-through. The larger the number of layers, the more computationally intensive this step is. Fortunately, since this is a one-time calculation, the results can be cached and used in later runs when experimenting with different parameters.

#### Training phase

Once the values from the frozen layers are computed, they are used as input to retrain the bottleneck layer. This process is iterative and runs for the number of times specified by model parameters. During each run, the loss and accuracy are evaluated and the appropriate adjustments are made to improve the model with the goal of minimizing the loss and maximizing the accuracy. Once training is finished, two models are output. One of them is the `.pb` version of the model and the other is the `.zip` ML.NET serialized version of the model. When working in environemnts supported by ML.NET, it is recommended to use the `.zip` version of the model. However, in environemnts where ML.NET is not supported, you have the option of using the `.pb` version.

## Understand the pretrained model

The pre-trained model used in this tutorial is the 101-layer variant of the Residual Network (ResNet) v2 model. The original model takes an input image of size 224 x 224 and outputs the class probabilities for each of the classes it's trained on.

## Create console application

Now that you have a general understanding of transfer learning and the Image Classification API, it's time to build the application

1. Create a **.NET Core Console Application** called "DeepLearning_ImageClassification_API"
1. Install the **Microsoft.ML 1.4.0-preview** NuGet Package:
    1. In Solution Explorer, right-click on your project and select **Manage NuGet Packages**.
    1. Choose "nuget.org" as the Package source.
    1. Select the **Browse** tab.
    1. Check the **Include prerelease** checkbox.
    1. search for **Microsoft.ML**.
    1. Select the **Install** button.
    1. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.
    1. Repeat these steps for **Microsoft.ML.Dnn 0.16.0-preview** and **Microsoft.ML.ImageAnalytics 1.4.0-preview**.

### Prepare and understand the data

> [!NOTE]
> The datasets for this tutorial are from Maguire, Marc; Dorafshan, Sattar; and Thomas, Robert J., "SDNET2018: A concrete crack image dataset for machine learning applications" (2018). Browse all Datasets. Paper 48. https://digitalcommons.usu.edu/all_datasets/48

SDNET2018 is an image dataset that contains annotations for cracked and non-cracked concrete structures (bridge decks, walls, and pavement). 

![](./media/image-classification-api-transfer-learning/crackeddeck.jpg)

The data is organized in three sub-directories:

- D contains bridge deck images
- P contains pavement images
- W contains wall images

Each of these subdirectories contains two additional pre-fixed sub-directories:

- C is the prefix used for cracked surfaces
- U is the prefix used for uncracked surfaces

In this tutorial, only bridge deck images are used.

1. Download the [SDNET2018](https://digitalcommons.usu.edu/cgi/viewcontent.cgi?filename=2&article=1047&context=all_datasets&type=additional) dataset and unzip.
1. Create a directory named "assets" in your project to save your data set files.
1. Copy all the sub-directories inside the *D* sub-directory of the recently unzipped *SDNET2018* directory.

### Create inut and output classes

1. Open the *Program.cs* file and add the following additional using statements to the top of the file:

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using Microsoft.ML;
    using Microsoft.ML.Data;
    using static Microsoft.ML.DataOperationsCatalog;
    using Microsoft.ML.Transforms;
    ```

1. Create classes for your input and output data

    1. Below the `Program` class in *Program.cs*, define the schema of your input data in a new class called `ModelInput`.

        ```csharp
        class ModelInput
        {
            public string ImagePath { get; set; }

            public string Label { get; set; }
        }
        ```

    `ModelInput` contains the following properties:

    - `ImagePath` is the fully-qualified path where the image is stored.
    - `Label` is the category the image belongs to. This is the value to predict.

    1. Then, below the `ModelInput` class, define the schema of your output data in a new class called `ModelOutput`. 

        ```csharp
        class ModelOutput
        {
            public string Label { get; set; }

            public UInt32 PredictedLabel { get; set; }
        }
        ```

    `ModelOutput` contains the following properties:

    - `Label` is the original category the image belongs to. This is the value to predict. 
    - `PredictedLabel` is the index of the predicted label. The pre-trained model returns a list of class probabilities and the `PredictedLabel` is the index of the class with the highest probability. 

### Define paths and initialize variables

1. Inside the `Main` method, create a field to store the location of your assets.

    ```csharp
    var assetsRelativePath = "../../../assets";
    ```

1. Then, initialize the `mlContext` variable with a new instance of [MLContext](xref:Microsoft.ML.MLContext).

    ```csharp
    MLContext mlContext = new MLContext();
    ```

The [MLContext](xref:Microsoft.ML.MLContext) class is a starting point for all ML.NET operations, and initializing mlContext creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

## Load the data

### Create data loading utility method

The images are stored in two sub-directories. Before loading the data, it needs to be format into a list if `ImageInput` objects. To do so, create the `LoadImagesFromDirectory` method below the `Main` method.

```csharp
public static IEnumerable<ModelInput> LoadImagesFromDirectory(string folder, bool useFolderNameAsLabel = true)
{

}
```

1. Inside the `LoadImagesDirectory` add the following code to get all of the file paths from the sub-directories.

    ```csharp
    var files = Directory.GetFiles(folder, "*",
        searchOption: SearchOption.AllDirectories);
    ```

1. Then, iterate through each of the files using a `foreach` statement

    ```csharp
    foreach (var file in files)
    {

    }
    ```

1. Inside the `foreach` statement, check that the file extensions are supported. The Image Classification API supports JPEG and PNG formats.

    ```csharp
    if ((Path.GetExtension(file) != ".jpg") && (Path.GetExtension(file) != ".png"))
        continue;
    ```

1. Then, get the label for the file. If the `useFolderNameAsLabel` parameter is set to `true`, then the parent directory where the file is saved is used as the label. Otherwise, it expects the label to be a prefix of the file name or the file name itself.

    ```csharp
    var label = Path.GetFileName(file);
    if (useFolderNameAsLabel)
        label = Directory.GetParent(file).Name;
    else
    {
        for (int index = 0; index < label.Length; index++)
        {
            if (!char.IsLetter(label[index]))
            {
                label = label.Substring(0, index);
                break;
            }
        }
    }
    ```

1. Finally, create a new instance of `ModelInput`

    ```csharp
    yield return new ModelInput()
    {
        ImagePath = file,
        Label = label
    };
    ```

### Prepare the data

1. Back in the `Main` method, use the `LoadFromDirectory` utility method to get the list of images used for training.

    ```csharp
    IEnumerable<ModelInput> images = LoadImagesFromDirectory(folder: assetsRelativePath, useFolderNameAsLabel: true);
    ```

1. Then, load the images into an [`IDataView`](xref:Microsoft.ML.IDataView) using the [`LoadFromEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.LoadFromEnumerable*) method,

    ```csharp
    IDataView imageData = mlContext.Data.LoadFromEnumerable(images);
    ```

1. The way in which the data is loaded is in the order it was read from the directories. To balance the data, shuffle it using the [`ShuffleRows`](xref:Microsoft.ML.DataOperationsCatalog.ShuffleRows*) method.

    ```csharp
    IDataView shuffledData = mlContext.Data.ShuffleRows(imageData);
    ```

1. It's good practice to split the data into a trianing and validation set. The model is trained on the training set of data and how well it makes predictions on unseen data is measured by the performance against the validation set. Split your data 

    ```csharp
    TrainTestData dataSplit = mlContext.Data.TrainTestSplit(shuffledData);
    IDataView trainSet = dataSplit.TrainSet;
    IDataView validationSet = dataSplit.TestSet;
    ```

### Define the training pipeline

Model training consist of a couple of steps. First, the original text labels need to be mapped to a `KeyValue` type. Then, the Image Classification API is used to train the model.

1. In the main method, define the `MapValueToKey` estimator to map the string values in the `Label` column to the `LabelAsKey` column.

    ```csharp
    var mapLabelEstimator = mlContext.Transforms.Conversion.MapValueToKey
        (outputColumnName: "LabelAsKey",
            inputColumnName: "Label",
            keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue);
    ```

1. Then, apply the validation set to the `mapLabelEstimator` using the [`Fit`](xref:Microsoft.ML.ConversionsExtensionsCatalog.MapValueToKey*) method, followed by the [`Transform`](xref:Microsoft.ML.ITransformer.Transform*) method to get the transformed [`IDataView`](xref:Microsoft.ML.IDataView).

    ```csharp
    IDataView transformedValidationData = mapLabelEstimator
                                            .Fit(validationSet)
                                            .Transform(validationSet);
    ```

1. Then, define the training [`EstimatorChain`](xref:Microsoft.ML.Data.EstimatorChain%601) pipeline that consists of both the `mapLabelEstimator` and the `ImageClassification` estimators.

    ```csharp
    var trainingPipeline =
        mapLabelEstimator
        .Append(mlContext.Model.ImageClassification(
            featuresColumnName: "ImagePath",
            labelColumnName: "LabelAsKey",
            arch: ImageClassificationEstimator.Architecture.ResnetV2101,
            epoch: 100,
            batchSize: 20,
            testOnTrainSet: false,
            metricsCallback: (metrics) => Console.WriteLine(metrics),
            validationSet: transformedValidationData,
            reuseTrainSetBottleneckCachedValues: true,
            reuseValidationSetBottleneckCachedValues: true));
    ```

    The `ImageClassification` estimator takes in several parameters:

    - `featuresColumnName` is the column that is used as input for the model.
    - `labelColumnName` is the column for the value to predict.
    - `arch` defines which of the pre-trained model architectures to use. This tutorial uses the 101-layer variant of the ResNetv2 model.
    - `epoch` specifies the number of iterations over the entire dataset throughout the training process. The higher the number, the longer the model trains for an potentially the better model that is produced.
    - `batchSize` is the number of samples to use at a time for training. During one epoch, multiple batches equal to the batchSize are used to train and update the model. The lower the number, the less memory required when each batch is processed.
    - `testOnTrainSet` tells the model to measure performance against the training set when no validation set is present.
    - `metricsCallback` binds a function to track the progress during training.
    - `validationSet` is the [`IDataView`](xref:Microsoft.ML.IDataView) containing the validation data.
    - `reuseTrainSetBottleneckCachedValues` tells the model whether to use the cached values from the bottleneck phase in subsequent runs. The bottleneck phase is a one-time pass-through computation that is computationally intensive the first time it is performed. If the training data does not change and you want to experiment using a different number of epochs or batch size, using the cached values significantly reduces the amount of time required to train a model.
    - `reuseValidationSetBottleneckCachedValues` is similar to `reuseTrainSetBottleneckCachedValues` only that in this case it's for the validation dataset.

1. Use the [`Fit`](xref:Microsoft.ML.IEstimator%601.Fit*) method to train your model.

    ```csharp
    ITransformer trainedModel = trainingPipeline.Fit(trainSet);
    ```

## Use the model

### Get original label values

Predictions made by the model output the index of the class with the highest probability. Therefore you need to map the index back to a value. Do so with the `GetKeyMappings` utility method.

Create a new method called `GetKeyMappings` under the `LoadFromImageDirectory` method.

```csharp
private static ReadOnlyMemory<char>[] GetKeyMappings(IDataView predictions)
{
    VBuffer<ReadOnlyMemory<char>> keys = default;
    predictions.Schema["LabelAsKey"].GetKeyValues(ref keys);
    var originalValues = keys.DenseValues().ToArray();
    return originalValues;
}
```

The `GetKeyMappings` method gets the original key values from the `LabelAsKey` column of the [`IDataView`](xref:Microsoft.ML.IDataView) containing the predictions. Then, it converts and returns these values into an array that can be accessed by index.

### Classify images

Create a new method called `ClassifyImages` below the `Main` method to make and output image predictions.

```csharp
public static void ClassifyImages(MLContext mlContext, IDataView data, ITransformer trainedModel)
{

}
```

1. Start off by generating an [`IDataView`](xref:Microsoft.ML.IDataView) containing the predictions by using the [`Transform`](xref:Microsoft.ML.ITransformer.Transform*) method. Add the following code inside the `ClassifyImages` method.

    ```csharp
    IDataView predictionData = trainedModel.Transform(data);
    ```

1. Then, use the `GetKeyMappings` utility method to get the original label values.

    ```csharp
    var keyMappings = GetKeyMappings(predictionData);
    ```

1. In order to iterate over the predictions, convert the `predictionData` [`IDataView`](xref:Microsoft.ML.IDataView) into an [`IEnumerable`](xref:System.Collections.Generic.IEnumerable%601) using the [`CreateEnumerable`](xref:Microsoft.ML.DataOperationsCatalog.CreateEnumerable*) method and then get the first ten rows.

    ```csharp
    IEnumerable<ModelOutput> predictions = mlContext.Data.CreateEnumerable<ModelOutput>(predictionData, reuseRowObject: true).Take(10);
    ```

1. Iterate and output the original and predicted labels for the predictions.

    ```csharp
    foreach (var prediction in predictions)
    {
        var predictedLabelValue = keyMappings[prediction.PredictedLabel];
        Console.WriteLine($"Actual Value: {prediction.Label} | Predicted Value: {predictedLabelValue}");
    }
    ```

1. Finally, inside the `Main` method, call `ClassifyImages`.

    ```csharp
    ClassifyImages(mlContext, validationSet, trainedModel);
    ```

## Run the application

Run your console app. The output should be similar to that below. You may see warnings or processing messages, but these messages have been removed from the following results for clarity. For brevity, the output has been condensed.

Bottleneck phase

```test
Phase: Bottleneck Computation, Dataset used:      Train, Image Index: 367, Image Name: ../../../Data\CD\7005-191.jpg
Phase: Bottleneck Computation, Dataset used:      Train, Image Index: 368, Image Name: ../../../Data\UD\7001-82.jpg
Phase: Bottleneck Computation, Dataset used: Validation, Image Index:   1, Image Name: ../../../Data\UD\7001-69.jpg
Phase: Bottleneck Computation, Dataset used: Validation, Image Index:   2, Image Name: ../../../Data\UD\7001-218.jpg
```

Training phase

```text
Phase: Training, Dataset used: Validation, Batch Processed Count:   1, Epoch:  94, Accuracy:       0.85
Phase: Training, Dataset used: Validation, Batch Processed Count:   1, Epoch:  95, Accuracy:        0.8
Phase: Training, Dataset used: Validation, Batch Processed Count:   1, Epoch:  96, Accuracy:        0.8
Phase: Training, Dataset used: Validation, Batch Processed Count:   1, Epoch:  97, Accuracy:       0.85
```

Classify images output

```text
Actual Value: UD | Predicted Value: CD
Actual Value: UD | Predicted Value: UD
Actual Value: CD | Predicted Value: CD
Actual Value: CD | Predicted Value: UD
Actual Value: CD | Predicted Value: CD
Actual Value: UD | Predicted Value: UD
Actual Value: UD | Predicted Value: UD
Actual Value: UD | Predicted Value: CD
Actual Value: CD | Predicted Value: UD
Actual Value: CD | Predicted Value: CD
```

Congratulations! You've now successfully built a deep learning model for classifying images.

## Next steps

In this tutorial, you learned how to:
> [!div class="checklist"]
>
> - Understand the problem
> - Learn about ML.NET Image Classification API
> - Understand the pretrained model
> - Use transfer learning to train a custom TensorFlow image classification model
> - Classify images with the custom model

### Improve the model

If you're not satisfied with the results of your model, you can try to improve its performance by trying some of the following approaches:

- **More Data**: The more examples a model learns from, the better it performs. 
- **Augment the data**: A common technique to add variety to the data is to augment the data by taking an image and applying different transforms (rotate, flip, shift, crop). This adds more varied examples for the model to learn from. 
- **Train for a longer time**: The longer you train, the more tuned the model will be. Increasing the number of epochs may improve the performance of your model.
- **Experiment with the hyper-parameters**: In addition to the parameters used in this tutorial, other parameters can be tuned to potentially improve performance. Changing the learning rate, which determines the magnitude of updates made to the model after each epoch may improve performance.
- **Use a different model architecture**: Depending on what your data looks like, the model that can best learn its features may differ. If you're not satisfied with the performance of your model, try changing the architecture. 