---
title: Use ML.NET in a TensorFlow transfer learning scenario for image classification
description: Discover how to use ML.NET in a TensorFlow transfer learning scenario to classify images by reusing a pre-trained TensorFlow model.
ms.date: 03/20/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to reuse a pre-trained TensorFlow model with ML.NET so that I can classify images with a small amount of training data.
---
# Tutorial: Use ML.NET in a TensorFlow transfer learning scenario for image classification

This sample tutorial illustrates using ML.NET to reuse a pre-trained TensorFlow model to classify images with a small amount of training data via a .NET Core console application using C# in Visual Studio 2017. In the world of machine learning, this is called transfer learning.

> [!NOTE]
> This topic refers to ML.NET, which is currently in Preview, and material may be subject to change. For more information, visit [the ML.NET introduction](https://www.microsoft.com/net/learn/apps/machine-learning-and-ai/ml-dotnet).

This tutorial and related sample are currently using **ML.NET version 0.10**. For more information, see the release notes at the [dotnet/machinelearning GitHub repo](https://github.com/dotnet/machinelearning/tree/master/docs/release-notes)

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Build and Train the model
> * Predict with the trained model
> * Deploy and Predict with a loaded model

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TransferLearningTF) repository.

## Understand the problem

Image classification is a common Machine Learning problem which has well-known solutions. This tutorial uses an approach that mixes new techniques (deep learning) and traditional (Logistic Regression) techniques.

This model uses the [Inception model](https://storage.googleapis.com/download.tensorflow.org/models/inception5h.zip) as a *featurizer* (the model is already stored in the [assets folder](./ImageClassification.Train/assets/inputs/inception/)). This means that the model processes input images through the neural network, using the tensor output before classification. This tensor contains the *image features*, used for image identification.

Finally, these image features will be fed to an SDCA algorithm which will learn how to classify different sets of image features.

## DataSet

There are two data sources: the `tsv` file and the image files.  The tags.tsv file contains two columns: the first one is defined as `ImagePath` and the second one is the `Label` corresponding to the image. The following example file does not have a header row, and looks like this:

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

The training and testing images are located in the assets folders. These images belong to Wikimedia Commons.
> *[Wikimedia Commons](https://commons.wikimedia.org/w/index.php?title=Main_Page&oldid=313158208), the free media repository.* Retrieved 10:48, October 17, 2018 from:  
> https://commons.wikimedia.org/wiki/Pizza  
> https://commons.wikimedia.org/wiki/Toaster  
> https://commons.wikimedia.org/wiki/Teddy_bear  

## ML Task - [Image Classification](https://en.wikipedia.org/wiki/Outline_of_object_recognition)

To solve this problem, first you'll build an ML model. Then, train the model on existing data, evaluate the model quality, and consume the model to classify a new image.

## Create a console application

### Create a project

1. Open Visual Studio 2017. Select **File** > **New** > **Project** from the menu bar. In the **New Project** dialog, select the **Visual C#** node followed by the **.NET Core** node. Then select the **Console App (.NET Core)** project template. In the **Name** text box, type "TransferLearningTF" and then select the **OK** button.

2. Create a directory named *Data* in your project to save your data set files:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "Data" and hit Enter.

3. Create a directory named *Models* in your project to save your model:

    In **Solution Explorer**, right-click on your project and select **Add** > **New Folder**. Type "Models" and hit Enter.

4. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**. Click on the **Version** drop down, select the **0.10.0** package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. Repeat these steps for **Microsoft.ML.ImageAnalytics v0.10.0** and **Microsoft.ML.TensorFlow v0.10.0**.

  > [!NOTE]
  > This tutorial uses **Microsoft.ML v0.10.0**, **Microsoft.ML.ImageAnalytics v0.10.0**, and **Microsoft.ML.TensorFlow v0.10.0**.

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

Create some classes for your input data, inspections, and predictions. Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImageNetData.cs*. Then, select the **Add** button.

    The *ImageNetData.cs* file opens in the code editor. Add the following `using` statement to the top of *ImageNetData.cs*:

[!code-csharp[AddUsings](../../../samples/machine-learning/tutorials/TransferLearningTF/ImageNetData.cs#AddUsings)]

Remove the existing class definition and add the following code, which has two classes `ImageNetData` and `ImageNetPipeline`, to the *ImageNetData.cs* file:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TransferLearningTF/ImageNetData.cs#DeclareTypes)]

`ImageNetData` is the input image data class and has the following <xref:System.String> fields:

* `ImagePath` contains the path for the image file
* `Label` contains a value for the image label

`ImageNetData` also has a method (`ReadFromCsv`) to read the image data `.csv` file and load it into an `ImageNetData` object.

`ImageNetPipeline` is the class used for inspecting column values after the model has been trained. It has a `string` (`ImagePath`) for the image path. The `Label` is used to create and train the model, and it's also used to evaluate the model. The `PredictedLabelValue` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

Add a new class to your project:

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.

1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImageNetPrediction.cs*. Then, select the **Add** button.

    The *ImageNetPrediction.cs* file opens in the code editor. Remove both the `System.Collections.Generic` and the `System.Text` `using` statements at the top of *ImageNetPrediction.cs*:

Remove the existing class definition and add the following code, which has the `ImageNetPrediction` class, to the *ImageNetPrediction.cs* file:

[!code-csharp[DeclareGlobalVariables](../../../samples/machine-learning/tutorials/TransferLearningTF/ImageNetPrediction.cs#DeclareTypes)]

`ImageNetPrediction` is the image prediction class and has the following fields:

* `Score` contains the confidence percentage for a given image classification.
* `PredictedLabelValue` contains a value for the predicted image classification label.

`IssuePrediction` is the class used for prediction after the model has been trained. It has a `string` (`ImagePath`) for the image path. The `Label` is used to create and train the model, and it's also used with a second dataset to evaluate the model. The `PredictedLabelValue` is used during prediction and evaluation. For evaluation, an input with training data, the predicted values, and the model are used.

When building a model with ML.NET, you start by creating an <xref:Microsoft.ML.MLContext>. `MLContext` is comparable conceptually to using `DbContext` in Entity Framework. The environment provides a context for your ML job that can be used for exception tracking and logging.

### Initialize variables in Main

Initialize the `_mlContext` global variable  with a new instance of `MLContext`.  Replace the `Console.WriteLine("Hello World!")` line with the following code in the `Main` method:

[!code-csharp[CreateMLContext](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CreateMLContext)]

## Load the data

 As the input and output of [`Transforms`](../basic-concepts-model-training-in-mldotnet.md#transformer), a `DataView` is the fundamental data pipeline type, comparable to `IEnumerable` for `LINQ`.

In ML.NET, data is similar to a `SQL view`. It is lazily evaluated, schematized, and heterogenous. The object is the first part of the pipeline, and loads the data. For this tutorial, it loads a dataset with issue titles, descriptions, and corresponding area GitHub label. The `DataView` is used to create and train the model.

Since your previously created `ImageNetData` data model type matches the dataset schema, you can combine the initialization, mapping, and dataset loading into one line of code.

Load the data using the `MLContext.Data.ReadFromTextFile` wrapper. It returns a
<xref:Microsoft.Data.DataView.IDataView> which infers the dataset schema from the `ImageNetData` data model type.

## Build and Train the model

Add the following call to the `BuildAndTrainModel`method as the next line of code in the `Main` method:

[!code-csharp[CallBuildAndTrainModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallBuildAndTrainModel)]

The `BuildAndTrainModel` method executes the following tasks:

* Loads the data
* Extracts and transforms the data.
* Scores the TensorFlow model.
* Trains the model.
* Displays model results.
* Evaluates the model.
* Saves the model.

Create the `BuildAndTrainModel` method, just after the `Main` method, using the following code:

```csharp
public static void BuildAndTrainModel(MLContext mlContext, string dataLocation, string imagesFolder, string inputModelLocation, string outputModelLocation)
{

}
```

## Extract Features and transform the data

Pre-processing and cleaning data are important tasks that occur before a dataset is used effectively for machine learning. Raw data is often noisy and unreliable, and may be missing values. Using data without these modeling tasks can produce misleading results.

ML.NET's transform pipelines compose a custom `transforms`set that is applied to your data before training or testing. The transforms' primary purpose is data [featurization](../resources/glossary.md#feature-engineering). Machine learning algorithms understand [featurized](../resources/glossary.md#feature) data, so the next step is to transform our textual data into a format that our ML algorithms recognize. That format is a [numeric vector](../resources/glossary.md#numerical-feature-vector).

In the next steps, we refer to the columns by the names defined in the `GitHubIssue` class.

When the model is trained and evaluated, by default, the values in the **Label** column are considered as correct values to be predicted. As you are using a pretrained model you need to map fields to the new model.. To do that, use the `MLContext.Transforms.Conversion.MapValueToKey`, which is a wrapper for the <xref:Microsoft.ML.ConversionsExtensionsCatalog.ValueToKeyMappingEstimator%2A> transformation class.  The `MapValueToKey` returns an <xref:Microsoft.ML.Data.EstimatorChain%601> that will effectively be a pipeline. Name this `pipeline` as you will then append the trainer to it. Add the next line of code:

[!code-csharp[MapValueToKey1](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#MapValueToKey1)]



[!code-csharp[ImageTransforms](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ImageTransforms)]



[!code-csharp[ScoreTensorFlowModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ScoreTensorFlowModel)]

### Choose a learning algorithm

To add the learning algorithm, call the `mlContext.MulticlassClassification.Trainers.LogisticRegression` wrapper method.  The `LogisticRegression` is appended to the `pipeline` and accepts the featurized `Title` and `Description` (`Features`) and the `Label` input parameters to learn from the historic data. You also need to map the label to the value to return to its original readable state. Do both of those actions with the following code:

[!code-csharp[AddTrainer](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#AddTrainer)]

You also need to map the predictedlabel to the predictedlabelvalue:

[!code-csharp[MapValueToKey2](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#MapValueToKey2)]

You train the model, <xref:Microsoft.ML.Data.TransformerChain%601>, based on the dataset that has been loaded and transformed. Once the estimator has been defined, you train your model using the <xref:Microsoft.ML.Data.EstimatorChain%601.Fit%2A> method while providing the already loaded training data. This returns a model to use for predictions. `pipeline.Fit()` trains the pipeline and returns a `Transformer` based on the `DataView` passed in. The experiment is not executed until the `.Fit()` method runs.

[!code-csharp[TrainModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#TrainModel)]

Notice the use of the `Transform` method of the machine learning `model` (a transformer) to input the features and return predictions.

[!code-csharp[TransformData](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#TransformData)]



[!code-csharp[EnumerateModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#EnumerateModel)]




[!code-csharp[DisplayInfo](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#DisplayInfo)]

The <xref:Microsoft.ML.MulticlassClassificationCatalog.Evaluate%2A> method computes the quality metrics for the model using the specified dataset. It returns a <xref:Microsoft.ML.Data.MultiClassClassifierMetrics> object that contains the overall metrics computed by multiclass classification evaluators.
To display the metrics to determine the quality of the model, you need to get them first. Add the following code to the `Evaluate` method as the next line:

[!code-csharp[Evaluate](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#Evaluate)]

The following metrics are evaluated for image classification:

* Log-loss - see [Log Loss](../resources/glossary.md#log-loss). You want Log-loss to be as close to zero as possible.

* Per class Log-loss . You want per class Log-loss to be as close to zero as possible.

Use the following code to display the metrics, share the results, and then act on them:

[!code-csharp[DisplayMetrics](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#DisplayMetrics)]

The `ITransformer` has a <xref:Microsoft.ML.Data.TransformerChain%601.SaveTo(Microsoft.ML.IHostEnvironment,System.IO.Stream)> method that takes in the `outputModelLocation` parameter and a <xref:System.IO.Stream>. To save this model as a zip file, you'll create the `FileStream` immediately before calling the `SaveTo` method. Add the following code to the `BuildAndTrainModel` method as the next line:

[!code-csharp[SaveModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#SaveModel)]

## Classify images with a loaded model

Add the following call to the `ClassifyImages` method as the next line of code in the `Main` method:

[!code-csharp[CallClassifyImages](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CallClassifyImages)]

The `ClassifyImages` method executes the following tasks:

* Loads the model.
* Reads .csv file into List.
* Predicts image classifications based on test data.

Create the `ClassifyImages` method, just after the `BuildAndTrainModel` method, using the following code:

```csharp
public static void ClassifyImages(MLContext mlContext, string dataLocation, string imagesFolder, string outputModelLocation)
{

}
```

First, load the model that you saved previously with the following code:

[!code-csharp[LoadModel](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#LoadModel)]

While the `model` is a `transformer` that operates on many rows of data, a very common production scenario is classifying individual examples. The <xref:Microsoft.ML.PredictionEngine%602> is a wrapper that is returned from the `CreatePredictionEngine` method. Add the following code to create the `PredictionEngine` as the next line:

[!code-csharp[CreatePredictionEngine](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#CreatePredictionEngine)]



[!code-csharp[ReadFromCSV2](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#ReadFromCSV2)]



[!code-csharp[Classifications](../../../samples/machine-learning/tutorials/TransferLearningTF/Program.cs#Classifications)]

## Results

Your results should be similar to the following output. As the pipeline processes, it displays messages. You may see warnings, or processing messages. These have been removed from the following results for clarity.

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

Congratulations! You've now successfully built a machine learning model for image classification by reusing a pre-trained TensorFlow model.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/samples/tree/master/machine-learning/tutorials/TransferLearningTF) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Build and Train the model
> * Predict with the trained model
> * Deploy and Predict with a loaded model

Check out the Machine Learning samples GitHub repository to explore an expanded image classification sample.
> [!div class="nextstepaction"]
> [dotnet/machinelearning-samples GitHub repository](https://github.com/dotnet/machinelearning/)