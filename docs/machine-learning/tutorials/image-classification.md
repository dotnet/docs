---
title: Build an ML.NET custom image classifier with TensorFlow
description: Discover how to build an ML.NET custom image classifier in a TensorFlow transfer learning scenario to classify images by reusing a pre-trained TensorFlow model.
ms.date: 03/22/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to reuse a pre-trained TensorFlow model with ML.NET so that I can classify images with a small amount of training data.
---
# Tutorial: Build an ML.NET custom image classifier with TensorFlow

This sample tutorial illustrates how you can use an already trained Image Classifier `TensorFlow` model to build a new custom Image Classifier model. What if you could reuse a model that's already been pre trained to solve a similar problem and retrain either all or some of the layers of that model to make it solve your problem? This technique of re-using part of an already trained model to build a new model is known as [transfer learning](https://en.wikipedia.org/wiki/Transfer_learning).

Training an [Image Classification](https://en.wikipedia.org/wiki/Outline_of_object_recognition) model from scratch requires setting millions of parameters, a ton of labeled training data and a vast amount of compute resources (hundreds of GPU hours). While not as effective as training a custom model from scratch, transfer learning allows you to shortcut this process by working with thousands of images vs. millions of labeled images and build a customized model fairly quickly (within an hour on a machine without a GPU).

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse and tune the pre-trained model
> * Classify Images

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This tutorial and related sample are currently using **ML.NET version 0.10**. For more information, see the release notes at the [dotnet/machinelearning GitHub repo](https://github.com/dotnet/machinelearning/tree/master/docs/release-notes)

## Image classification sample overview

The sample is a console app that uses ML.NET to build an image classifier by reusing a pre-trained model to classify images with a small amount of training data.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TransferLearningTF) repository.

## Machine learning workflow

Use the following steps to accomplish your task, and any other ML.NET task (depending on the task some steps may be combined):

1. Load your data
2. Build and train your model (In this case, you will reuse and tune (re-train) the pre-trained model instead)
3. Evaluate your model
4. Use your model

## Prerequisites

* [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.

* Microsoft.ML 0.10.0 Nuget package
* Microsoft.ML.ImageAnalytics 0.10.0 Nuget package
* Microsoft.ML.TensorFlow 0.10.0 Nuget package

* The tutorial assets .ZIP file

## Select the appropriate machine learning task

[Deep learning](https://en.wikipedia.org/wiki/Deep_learning) is a subset of AI and machine learning that teaches programs to learn by example, just like humans. A deep learning [model](../resources/glossary.md#model) learns to perform object detection and classification tasks directly from images, sound or text. It can perform resource intensive tasks such as speech recognition and language translation.  Deep learning is different from traditional machine learning approaches that need [feature engineering](../resources/glossary.md#feature-engineering) and data processing.

Deep learning models are trained by using large sets of [labeled data](https://en.wikipedia.org/wiki/Labeled_data) and [neural networks](https://en.wikipedia.org/wiki/Artificial_neural_network) that contain multiple learning layers. Deep learning:

* Performs better on some tasks like Computer Vision.

* Takes advantage of huge amounts of available data (and requires that volume to perform well).

Image Classification is a common Machine Learning task which allows us to automatically classify images into multiple categories e.g. take an image and help us detect whether there is a human face in or not. Cats vs. dogs etc. Or as in the following images, pizza or teddy bear or toaster?

![pizza image](./media/TransferLearningTF/pizza.jpg)
![teddy bear image](./media/TransferLearningTF/teddy2.jpg)
![toaster image](./media/TransferLearningTF/toaster.jpg)

Image citations are following.

Transfer learning includes a few strategies, such as *retrain all layers* and *penultimate layer*. This tutorial will explain and show how to use the *penultimate layer strategy*. The *penultimate layer strategy* reuses a model that's already been pre-trained to solve a specific problem and then retrain the final layer of that model to make it solve a new problem. Reusing the pre-trained model as part of your new model will save a lot of time and resources.

Your image classification model reuses the [Inception model](https://storage.googleapis.com/download.tensorflow.org/models/inception5h.zip), a very popular image recognition model trained on the `ImageNet` dataset where the TensorFlow model tries to classify entire images into a thousand classes, like “Umbrella”, “Jersey”, and “Dishwasher”.

The `Inception v3 model` can be classified as a [deep convolutional neural network](https://en.wikipedia.org/wiki/Convolutional_neural_network) and can achieve reasonable performance on hard visual recognition tasks, matching or exceeding human performance in some domains. The model/algorithm was developed by multiple researchers and based on the original paper: ["Rethinking the Inception Architecture for Computer Vision” by Szegedy, et. al.](https://arxiv.org/abs/1512.00567)

Because the `Inception model` has already been pre trained on thousands of different images, it contains the [image features](https://en.wikipedia.org/wiki/Feature_(computer_vision)) needed for image identification. The lower image feature layers recognize simple features (such as edges) and the higher layers recognize more complex features (such as shapes). You train the final layer against a much smaller set of data because you're starting with a pre trained model that already understands how to classify images. As your model allows you to classify more than two categories, this is an example of a [multi-class classifier](../resources/tasks.md#multiclass-classification).

 Since this is a Multi-class classification problem, you're going to retrain the final layer of that model with a `Logistic regression` algorithm using a set of four categories:

* Broccoli
* Pizza
* Toaster
* Teddy

## DataSet

There are two data sources: the `.tsv` file, and the image files.  The `tags.tsv` file contains two columns: the first one is defined as `ImagePath` and the second one is the `Label` corresponding to the image. The following example file doesn't have a header row, and looks like this:

```tsv
broccoli.jpg	broccoli
pizza.jpg	pizza
pizza2.jpg	pizza
teddy2.jpg	teddy
teddy3.jpg	teddy
teddy4.jpg	teddy
toaster.jpg	toaster
toaster2.png	toaster
```

The training and testing images are located in the assets folders that you'll download in a zip file. These images belong to Wikimedia Commons.
> *[Wikimedia Commons](https://commons.wikimedia.org/w/index.php?title=Main_Page&oldid=313158208), the free media repository.* Retrieved 10:48, October 17, 2018 from:  
> https://commons.wikimedia.org/wiki/Pizza  
> https://commons.wikimedia.org/wiki/Toaster  
> https://commons.wikimedia.org/wiki/Teddy_bear  

## Create a console application

### Create a project

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "TransferLearningTF" and then select the **OK** button.

2. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**. Click on the **Version** drop down, select the **0.10.0** package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. Repeat these steps for **Microsoft.ML.ImageAnalytics v0.10.0** and **Microsoft.ML.TensorFlow v0.10.0**.

  > [!NOTE]
  > This tutorial uses **Microsoft.ML v0.10.0**, **Microsoft.ML.ImageAnalytics v0.10.0**, and **Microsoft.ML.TensorFlow v0.10.0**.

### Prepare your data

1. Download [The project assets zip file](https://archive.ics.uci.edu/ml/machine-learning-databases/00331/sentiment%20labelled%20sentences.zip), and unzip.

2. Copy the `assets` directory into your *TransferLearningTF* project directory. This directory and its subdirectories contain the data and support files (including the Inception model) needed for this tutorial.

3. In Solution Explorer, right-click each of the files in the asset directory and subdirectories and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

Add the following additional `using` statements to the top of the *Program.cs* file:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#AddUsings)]

Create global fields to hold the paths to the various assets, and global variables for the `LabelTokey`,`ImageReal`, and  `PredictedLabelValue`:

* `_assetsPath` has the path to the assets.
* `_trainTagsTsv` has the path to the training image data tags tsv file.
* `_predictTagsTsv` has the path to the prediction image data tags tsv file.
* `_trainImagesFolder` has the path to the images used to train the model.
* `_predictImagesFolder` has the path to the images to be classified by the trained model.
* `_inceptionPb` has the path to the pre-trained model to be reused to train the model.
* `_inputImageClassifierZip` has the path where the trained model is loaded from.
* `_outputImageClassifierZip` has the path where the trained model is saved.
* `LabelTokey` is the `Label` value mapped to a key.
* `ImageReal`  is the column containing the predicted label value. 
* `PredictedLabelValue` is the column containing the predicted label value.

Add the following code to the line right above the `Main` method to specify those paths and the other variables:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#DeclareGlobalVariables)]

Create some classes for your input data, and predictions. Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImageData.cs*. Then, select the **Add** button.

    The *ImageData.cs* file opens in the code editor. Add the following `using` statement to the top of *ImageData.cs*:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TransferLearningTF/ImageData.cs#AddUsings)]

Remove the existing class definition and add the following code for the `ImageData` class to the *ImageData.cs* file:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TransferLearningTF/ImageData.cs#DeclareTypes)]

`ImageData` is the input image data class and has the following <xref:System.String> fields:

* `ImagePath` contains the image file name.
* `Label` contains a value for the image label.

Add a new class to your project for `ImagePrediction`:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImagePrediction.cs*. Then, select the **Add** button.

    The *ImagePrediction.cs* file opens in the code editor. Remove both the `System.Collections.Generic` and the `System.Text` `using` statements at the top of *ImagePrediction.cs*:

Remove the existing class definition and add the following code, which has the `ImagePrediction` class, to the *ImagePrediction.cs* file:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TransferLearningTF/ImagePrediction.cs#DeclareTypes)]

`ImagePrediction` is the image prediction class and has the following fields:

* `Score` contains the confidence percentage for a given image classification.
* `PredictedLabelValue` contains a value for the predicted image classification label.

`ImagePrediction` is the class used for prediction after the model has been trained. It has a `string` (`ImagePath`) for the image path. The `Label` is used to reuse and re-train the model. The `PredictedLabelValue` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations, and initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

### Initialize variables in Main

Initialize the `mlContext` variable with a new instance of `MLContext`.  Replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[CreateMLContext](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CreateMLContext)]

### Create a struct for default parameters

The Inception model has several default parameters you need to pass in. Create a struct to map the default parameter values to friendly names with the following code, just after the `Main()` method:

[!code-csharp[InceptionSettings](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#InceptionSettings)]

### Create a display utility method

You need to pair and display the image data and the related predictions more than once, and you don't want to duplicate code. Create a display utility method to handle pairing and displaying the image and prediction results.

The `PairAndDisplayResults()` method executes the following tasks:

* Combines data and predictions for reporting.
* Displays the predicted results.

Create the `PairAndDisplayResults()` method, just after the `InceptionSettings` struct, using the following code:

```csharp
private static void PairAndDisplayResults(IEnumerable<ImageNetData> imageData, IEnumerable<ImageNetPrediction> imagePredictionData)
{

}
```

Before displaying the predicted results, combine the `imageData` and `imagePrediction` together to see the original `Image Path` with its predicted category. The following code uses the <xref:System.Linq.Enumerable.Zip%2A?displayProperty=nameWithType> method to make that happen, so add it as the first line of the `PairAndDisplayResults()` method:

[!code-csharp[BuildImagePredictionPairs](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#BuildImagePredictionPairs)]

Now that you've combined the `imageData` and `imageData` into a class, you can display the results using the <xref:System.Console.WriteLine?displayProperty=nameWithType> method:

[!code-csharp[DisplayPredictions](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#DisplayPredictions)]

You'll call the `PairAndDisplayResults()` method in the next two methods.

### Create a .tsv file utility method

The `ReadFromTsv()` method executes the following tasks:

* Reads the image data `tags.tsv` file.
* Adds the file path to the image file name.
* Loads the file data into an IEnumerable`ImageData` object.

Create the `ReadFromTsv()` method, just after the `PairAndDisplayResults()` method, using the following code:

```csharp
public static IEnumerable<ImageData> ReadFromTsv(string file, string folder)
{

}
```

The following code parses through the `tags.tsv` file to add the file path to the image file name for the `ImagePath` property and load it and the `Label` into an `ImageData` object. Add it as the first line of the `ReadFromTsv()` method.  You need the fully qualified file path to display the prediction results.

[!code-csharp[ReadFromTsv](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ReadFromTsv)]
There are three major concepts in ML.NET: [Data](../basic-concepts-model-training-in-mldotnet.md#data), [Transformers](../basic-concepts-model-training-in-mldotnet.md#transformer), and [Estimators](../basic-concepts-model-training-in-mldotnet.md#estimator).

## Reuse and tune pre-trained model

Add the following call to the `ReuseAndTuneInceptionModel()`method as the next line of code in the `Main()` method:

[!code-csharp[CallReuseAndTuneInceptionModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallReuseAndTuneInceptionModel)]

The `ReuseAndTuneInceptionModel()` method executes the following tasks:

* Loads the data
* Extracts and transforms the data.
* Scores the TensorFlow model.
* Tunes (re-trains) the model.
* Displays model results.
* Evaluates the model.
* Saves the model.

Create the `ReuseAndTuneInceptionModel()` method, just after the `InceptionSettings` struct and just before the `PairAndDisplayResults()` method, using the following code:

```csharp
public static void ReuseAndTuneInceptionModel(MLContext mlContext, string dataLocation, string imagesFolder, string inputModelLocation, string outputModelLocation)
{

}
```

### Load the data

Data in ML.NET is represented as an [IDataView class](xref:Microsoft.Data.DataView.IDataView). `IDataView` is a flexible, efficient way of describing tabular data (numeric and text). Data can be loaded from a text file or in real time (for example, SQL database or log files) to an `IDataView` object.

Load the data using the `MLContext.Data.ReadFromTextFile` wrapper. Add the following code as the next line in the `ReuseAndTuneInceptionModel()` method:

[!code-csharp[LoadData](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#LoadData "Load the data")]

### Extract Features and transform the data

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning.  Using data without these modeling tasks can produce misleading results.

ML.NET's transform pipelines compose a custom `transforms`set that is applied to your data before training or testing. The transforms' primary purpose is data [featurization](../resources/glossary.md#feature-engineering). Machine learning algorithms understand [featurized](../resources/glossary.md#feature) data, and when dealing with deep neural networks you must adapt the images to the format expected by the network. That format is a [numeric vector](../resources/glossary.md#numerical-feature-vector).

When the model is trained and evaluated, by default, the values in the **Label** column are considered as correct values to be predicted. As you are using a pre-trained model you need to map fields to the new model. To do that, use the `MLContext.Transforms.Conversion.MapValueToKey()`.  Name this `estimator` as you will then append the trainer to it. Add the next line of code:

[!code-csharp[MapValueToKey1](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#MapValueToKey1)]

Your image processing estimator uses pre-trained [Deep Neural Network(DNN)](https://en.wikipedia.org/wiki/Deep_learning#Deep_neural_networks) featurizers for feature extraction. Usually, when dealing with deep neural networks, you must adapt the images to the format expected by the network. This is the reason you use several image transforms to get the image data in the form expected by the model:

1. The `LoadImages`transform images are loaded in memory as a Bitmap type.
2. The `Resize` transform resizes the images as the pre-trained model has a defined input image width and height.
3. The `ImagePixelExtractingEstimator` transform extracts the pixels from the input images and converts them into a numeric vector.

Add these image transforms as the next lines of code:

[!code-csharp[ImageTransforms](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ImageTransforms)]

`TensorFlow` is a popular deep learning and machine learning toolkit that enables training deep neural networks (and general numeric computations), and is implemented as a `transformer` in ML.NET. For this tutorial, it's used to reuse the `Inception model`.

As shown in the following diagram, you add a reference to the ML.NET NuGet packages in your .NET Core or .NET Framework applications. Under the covers, ML.NET includes and references the native `TensorFlow` library which allows you to write code that loads an existing trained `TensorFlow` model file for scoring.  

![TensorFlow transform ML.NET Arch diagram](./media/TransferLearningTF/TF-diagram.png)

The `TensorFlowTransform` extracts specified outputs (the model's image features `softmax2_pre_activation`), and scores a dataset using the pre-trained `TensorFlow` model.

`softmax2_pre_activation` assists the model with determining which class the images belongs to. `softmax2_pre_activation` returns a probability for each of the categories for an image, and all of those probabilities must add up to 1. It assumes that an image will belong to only one category, as shown in the following example:

| Class         | Probability   |
| ------------- | ------------- |
| `Brocolli`    |  0.001        |
| `Pizza`       |  0.95         |
| `Teddy`       |  0.06         |
| `Toaster`     |  0.005        |

Append the `TensorFlowTransform` to the `estimator` with the following line of code: 

[!code-csharp[ScoreTensorFlowModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ScoreTensorFlowModel)]

### Choose a learning algorithm

To add the learning algorithm, call the `mlContext.MulticlassClassification.Trainers.LogisticRegression()` wrapper method.  The `LogisticRegression` is appended to the `estimator` and accepts the Inception image features (`softmax2_pre_activation`) and the `Label` input parameters to learn from the historic data.  Add the trainer with the following code:

[!code-csharp[AddTrainer](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#AddTrainer)]

You also need to map the predictedlabel to the predictedlabelvalue:

[!code-csharp[MapValueToKey2](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#MapValueToKey2)]

The [Fit()](xref:Microsoft.ML.Trainers.MatrixFactorizationTrainer.Fit%28Microsoft.Data.DataView.IDataView,Microsoft.Data.DataView.IDataView%29) method trains your model with the provided training dataset. It executes the `Estimator` definitions by transforming the data and applying the training, and it returns back the trained model, which is a `Transformer`. The experiment is not executed until the `.Fit()` method runs. Fit the model to the `Train` data and return the trained model by adding the following as the next line of code in the `ReuseAndTuneInceptionModel()` method:

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#TrainModel)]

The [Transform()](xref:Microsoft.ML.ITransformer.Transform%2A) method makes predictions for multiple provided input rows of a test dataset.  Transform the `Training` data by adding the following code to `ReuseAndTuneInceptionModel()`:

[!code-csharp[TransformData](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#TransformData)]

Now that you have your image data and prediction `DataViews`, convert them into strongly-typed `IEnumerables` to pair them both for easier display. Use the `MLContext.CreateEnumerable()` method to do that, using the following code:

[!code-csharp[EnumerateDataViews](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#EnumerateDataViews)]

To pair and display your data and predictions, add the following code to call the `PairAndDisplayResults()` method previously created as the next line in the `ReuseAndTuneInceptionModel()` method:

[!code-csharp[CallPairAndDisplayResults1](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallPairAndDisplayResults1)]

Once you have the prediction set, the [Evaluate()](xref:Microsoft.ML.RecommendationCatalog.Evaluate%2A) method assesses the model, which compares the predicted values with the actual `Labels` in the dataset and returns metrics on how the model is performing. Add the following code to the `ReuseAndTuneInceptionModel()` method as the next line:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#Evaluate)]

The following metrics are evaluated for image classification:

* `Log-loss` - see [Log Loss](../resources/glossary.md#log-loss). You want Log-loss to be as close to zero as possible.

* `Per class Log-loss`. You want per class Log-loss to be as close to zero as possible.

Use the following code to display the metrics, share the results, and then act on them:

[!code-csharp[DisplayMetrics](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#DisplayMetrics)]

`mlContext.Model.Save` saves your trained model to a .zip file (in the "assets/outputs" folder), which can be used in other .NET applications to make predictions. Add the following code to the `ReuseAndTuneInceptionModel()` method as the next line:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#SaveModel)]

## Classify images with a loaded model

Add the following call to the `ClassifyImages()` method as the next line of code in the `Main` method:

[!code-csharp[CallClassifyImages](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallClassifyImages)]

The `ClassifyImages()` method executes the following tasks:

* Loads the model.
* Reads .csv file into List.
* Predicts image classifications based on test data.

Create the `ClassifyImages()` method, just after the `ReuseAndTuneInceptionModel()` method and just before the `PairAndDisplayResults()` method, using the following code:

```csharp
public static void ClassifyImages(MLContext mlContext, string dataLocation, string imagesFolder, string outputModelLocation)
{

}
```

First, load the model that you saved previously with the following code:

[!code-csharp[LoadModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#LoadModel)]

Call the `ImageNetData.ReadFromCsv()` method to create an `INumerable<ImageNetData>` class that contains the fully qualified path for each `ImagePath`. You need that file path to pair your data and prediction results. You also need to convert the `INumerable<ImageNetData>` class to an `IDataView` that you will use to predict. Add the following code as the next two lines in the `ClassifyImages()` method:

[!code-csharp[ReadFromCSV](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ReadFromCSV)]

As you did previously with the training image data, predict the category of the test image data using the [Transform()](xref:Microsoft.ML.ITransformer.Transform%2A) method. Add the following code to the `ClassifyImages()` method for the predictions and to convert the `predictions` `IDataView` into an `IEnumerable` for pairing and display:

[!code-csharp[Predict](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#Predict)]

To pair and display your test image data and predictions, add the following code to call the `PairAndDisplayResults()` method previously created as the next line in the `ClassifyImages()` method:

[!code-csharp[CallPairAndDisplayResults2](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallPairAndDisplayResults2)]

## Results

After following the previous steps, run your console app (Ctrl + F5). Your results should be similar to the following output.  You may see warnings or processing messages, but these messages have been removed from the following results for clarity.

```console
Images folder: C:\Tutorial\TransferLearningTF\TransferLearningTF\bin\Debug\netcoreapp2.2\assets\inputs-train\data
Training file: C:\Tutorial\TransferLearningTF\TransferLearningTF\bin\Debug\netcoreapp2.2\assets\inputs-train\data\tags.tsv
Default parameters: image size=(224,224), image mean: 117
2019-03-18 20:18:15.235693: I tensorflow/core/platform/cpu_feature_guard.cc:141] Your CPU supports instructions that this TensorFlow binary was not compiled to use: AVX2
=============== Training classification model ===============
ImagePath: pizza.jpg predicted as: pizza with score: 0.9844866
ImagePath: pizza2.jpg predicted as: pizza with score: 0.9481499
ImagePath: teddy2.jpg predicted as: teddy with score: 0.9762651
ImagePath: teddy3.jpg predicted as: teddy with score: 0.9821286
ImagePath: teddy4.jpg predicted as: teddy with score: 0.9862462
ImagePath: toaster.jpg predicted as: toaster with score: 0.977837
ImagePath: toaster2.png predicted as: toaster with score: 0.9796767
=============== Classification metrics ===============
LogLoss is: 0.0239608645879546
PerClassLogLoss is: 0.0344388607695228 , 0.0186344570300533 , 0.0214724797432381
=============== Save model to local file ===============
Model saved: C:\Tutorial\TransferLearningTF\TransferLearningTF\bin\Debug\netcoreapp2.2\assets\outputs\imageClassifier.zip
=============== Loading model ===============
Model loaded: C:\Tutorial\TransferLearningTF\TransferLearningTF\bin\Debug\netcoreapp2.2\assets\outputs\imageClassifier.zip
=============== Making classifications ===============
ImagePath: broccoli.png predicted as: teddy with score: 0.5549887
ImagePath: pizza3.jpg predicted as: pizza with score: 0.9718443
ImagePath: teddy6.jpg predicted as: teddy with score: 0.9809543
ImagePath: toaster3.jpg predicted as: toaster with score: 0.9649727
Press any key to continue . . .
```

Congratulations! You've now successfully built a machine learning model for image classification by reusing a pre-trained `TensorFlow` model in ML.NET.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TransferLearningTF) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse and tune the pre-trained model
> * Classify images with a loaded model

Check out the Machine Learning samples GitHub repository to explore an expanded image classification sample.
> [!div class="nextstepaction"]
> [dotnet/machinelearning-samples GitHub repository](https://github.com/dotnet/machinelearning/)