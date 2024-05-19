---
title: 'Tutorial: ML.NET prediction to detect objects in images from a Custom Vision ONNX model'
description: Learn how to detect objects in images using an ONNX model from the Custom Vision service in ML.NET. 
ms.date: 06/05/2022
ms.topic: tutorial
ms.custom: mvc, title-hack-0612
recommendations: false
#Customer intent: As a developer, I want to use ML.NET to categorize images using an ONNX model trained in the Custom Vision service.
---
# Tutorial: Categorize an image in ML.NET from Custom Vision ONNX model

Learn how to use ML.NET to detect objects in images using an ONNX model trained in the Microsoft Custom Vision service.

The Microsoft Custom Vision service is an AI service that allows you to upload your own images and it will train a model for you. You can then export the model to ONNX format and use it in ML.NET to make predictions.

In this tutorial, you will learn how to:
> [!div class="checklist"]
>
> * Understand the problem
> * Use the Custom Vision service to create an ONNX model
> * Incorporate the ONNX model into the ML.NET pipeline
> * Train the ML.NET model
> * Detect stop signs in test images

A sample for the ML.NET pipeline and testing of an image can be found [here]().

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).
* [Download the dataset](https://aka.ms/mlnet-object-detection-tutorial-dataset) of 50 stop sign images.
* Azure account. If you don't have one, [create a free Azure account](https://aka.ms/AMLFree).

## Select the right machine learning task

## Create the Model

### Create the Custom Vision Project

Log into the [Microsoft Custom Vision service](https://www.customvision.ai/) and select "New Project".

In the "New Project" dialog, fill out the following required items:

- Set the "Name" of the Custom Vision project as **StopSignDetection**.
- Select the "Resource" you will use. This is an Azure resource that will be created for the Custom Vision project. If none is listed, one can be created by selecting the **Create new** link.
- Set the "Project type" as **Object Detection**.
- Set the "Classification Types" as **Multiclass** since there will be one class per image.
- Set the "Domain" as **General (compact) [S1]**. The compact domain will allow you to download the ONNX model.
- For "Export capabilities" select **Basic platforms** to allow the export of the ONNX model.

Once the above fields are filled out click the **Create project** button.

### Add images

With the project created, click on the **Add images** button to start adding images for the model to train on. Select the stop sign images that was downloaded in the file browser.

Select the first image that is shown. You will be able to select objects that are in the image that you want the model to detect. Select the stop sign in the image. A popup will display and set the tag as **stop-sign**. Do this for all of the remaining images. Some images will have more than one stop sign in it so be sure to mark all that are in the images.

### Train the model

With the images uploaded and tagged the model can now be trained. Click on the **Train** button.

A popup will display asking what type of training to use. Select **Quick training** and click the **Train** button.

### Download the ONNX model

Once training is completed click on the "Export" button. When the popup displays click on the "ONNX" selection to download the ONNX model.

## Inspect ONNX model

Unzip the ONNX file since it downloads as a zip file. The folder will contain several files, but the two that we will use in this tutorial are the following:

- **labels.txt** is a text file containing the labels that were defined in the Custom Vision service.
- **model.onnx** is the ONNX model that we will use to make predictions in ML.NET.

In order to build our ML.NET pipeline you will need the names of the input and output column names. To get this information use Netron, a [web](https://netron.app/) and [desktop](https://github.com/lutzroeder/netron/releases/) app that can analyze ONNX models and show their architecture.

1. When using either the web or desktop app of Netron, open the ONNX model in the app. Once it opens it will display a graph. This graph will tell you a few things that you will need in order to build the ML.NET pipeline for predictions.

    - **Input column name** - The input column name required when applying the ONNX model in ML.NET.

        ![Netron Input Column](./media/object-detection-custom-vision/netron-input-column.png)

    - **Output column name** - The output column name required when applying the ONNX model in ML.NET.

        ![Netron Output Column](./media/object-detection-custom-vision/netron-output-columns.png)

    - **Image size** - The size required when resizing images in the ML.NET pipeline.

        ![Netron Image Size](./media/object-detection-custom-vision/netron-image-size.png)

## Create a C# console project

1. Create a C# **Console Application** called "StopSignDetection". Click the **Next** button.

1. Choose .NET 6 as the framework to use. Click the **Create** button.

1. Install the **Microsoft.ML NuGet Package**:

    [!INCLUDE [mlnet-current-nuget-version](../../../includes/mlnet-current-nuget-version.md)]

    - In Solution Explorer, right-click on your project and select **Manage NuGet Packages**.
    - Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**.
    - Select the **Install** button.
    - Select the **OK** button on the **Preview Changes** dialog.
    - Select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed.
    - Repeat these steps for **Microsoft.ML.ImageAnalytics**, and **Microsoft.Onnx.Transformer**.

## Reference the ONNX model

Reference the two files from the ONNX model in the Visual Studio solution - **labels.txt** and **model.onnx**. Right click them and in the properties set the **Copy to output directory** setting to "Copy if newer".

## Create input and prediction classes

1. Add a new class to your project and name it 'StopSignInput'. Then add the following struct to the class.

    ```csharp
    public struct ImageSettings
    {
        public const int imageHeight = 320;
        public const int imageWidth = 320;
    }
    ```

1. Next, add the following property to the class.

    ```csharp
    public class StopSignInput
    {
        [ImageType(ImageSettings.imageHeight, ImageSettings.imageWidth)]
        public Bitmap Image { get; set; }
    }
    ```

    The `Image` property contains the bitmap of the image used for prediction. And the `ImageType` attribute tells ML.NET that the property is an image with dimensions of 320 and 320 which was determined by what we saw in Netron when analyzing the model.

1. Add another class to your project and name it 'StopSignPrediction'. Then add the following property to the class.

    ```csharp
    public class StopSignPrediction
    {
        [ColumnName("detected_classes")]
        public long[] PredictedLabels { get; set; }

        [ColumnName("detected_boxes")]
        public float[] BoundingBoxes { get; set; }

        [ColumnName("detected_scores")]
        public float[] Scores { get; set; }
    }
    ```

    The `PredictedLabels` property contains the predictions of labels for each detected object. The type is a float array, so each item in the array will be the prediction of each label. The `ColumnName` attribute tells ML.NET that this column in the model is the name given, which is `detected_classes`.

    The `BoundingBoxes` property contains the bounding boxes for each detected object. The type is a float array and each detected object will come in with four items in the array for the bounding box. The `ColumnName` attribute tells ML.NET that this column in the model is the name give, which is `detected_boxes`.

    The `Scores` property contains the confidence scores of each predicted object and its label. The type is a float array, so each item in the array will be the confidence score of each label. The `ColumnName` attribute tells ML.NET that this column in the model is the name give, which is `detected_scores`.

## Use the model to make predictions

### Add using statements

In the *Program.cs* file, add the following usings to the top of the file.

```csharp
using Microsoft.ML;
using Microsoft.ML.Transforms.Image;
using System.Drawing;
using WeatherRecognition;
```

### Create objects

1. Below the using statements create the `MLContext` object.

    ```csharp
    var context = new MLContext();
    ```

1. Create an `IDataView` with an new empty `StopSignInput` list.

    ```csharp
    var data = context.Data.LoadFromEnumerable(new List<StopSignInput>());
    ```

1. For consistency, save the predicted images to the assembly path.

    ```csharp
    var root = new FileInfo(typeof(Program).Assembly.Location);
    var assemblyFolderPath = root.Directory.FullName;
    ```

## Build the pipeline

With the empty `IDataView` created the pipeline can be built to do the predictions of any new images. The pipeline will consist of several steps.

1. Resize the incoming images.

The image being sent to the model for prediction will often be in a different aspect ratio as the images that were trained on the model. To keep the image consistent for accurate predictions, resize the image to 320x320. To do so, use the `ResizeImages` method and set the `imageColumnName` as the name of the `StopSignInput.Image` property. 

```csharp
var pipeline = context.Transforms.ResizeImages(resizing: ImageResizingEstimator.ResizingKind.Fill, outputColumnName: "image_tensor", imageWidth: ImageSettings.imageWidth, imageHeight: ImageSettings.imageHeight, inputColumnName: nameof(StopSignInput.Image))
```

1. Extract the pixels of the image

Once the image has been resized, you need to extract the pixels of the image. Append the `ExtractPixels` method to your pipeline and specify the name of the column to output the pixels to using the `outputColumnName` parameter. 

```csharp
.Append(context.Transforms.ExtractPixels(outputColumnName: "image_tensor"))
```

1. Apply the ONNX model to the image to make a prediction. This takes a few parameters:

    - **modelFile** - The path to the ONNX model file
    - **outputColumnNames** - A string array containing the names of all of the output column names, which can be found when analyzing the ONNX model in Netron.
    - **inputColumnNames** - A string array containing the names of all of the input column name, which can also be found when analyzing the ONNX model in Netron.

```csharp
.Append(context.Transforms.ApplyOnnxModel(outputColumnNames: new string[] { "detected_boxes", "detected_scores", "detected_classes" }, inputColumnNames: new string[] { "image_tensor" }, modelFile: "./Model/model.onnx"));
```

## Fit the model

Now that you've defined a pipeline, use it to build the ML.NET model. Use the `Fit` method on the pipeline and pass in the empty `IDataView`.

```csharp
var model = pipeline.Fit(data);
```

Next, to make predictions, use the model to create a prediction engine. This is a generic method, so it takes in the `StopSignInput` and `StopSignPrediction` classes that were created earlier. 

```csharp
var predictionEngine = context.Model.CreatePredictionEngine<StopSignInput, StopSignPrediction>(model);
```

## Extract the labels

To map the model outputs to its labels, you need to extract the labels provided by Custom Vision. These labels are in the **labels.txt** file that was included in the zip file along with the ONNX model.

Use the `ReadAllLines` method to read all the labels form the file. 

```csharp
var labels = File.ReadAllLines("./model/labels.txt");
```

## Predict on a test image

Now you can use the model to predict on new images. In the project, there is a *test* folder that you can use to make predictions. This folder contains two random images with a stop sign in it from [Unsplash](https://unsplash.com/). One image has one stop sign while the other has two stop signs. Use the `GetFiles` method to read the file paths of the images in the directory.

```csharp
var testFiles = Directory.GetFiles("./test");
```

Loop through the file paths to make a prediction with the model and output the result.

1. Create a for-loop to loop through the test images.

    ```csharp
    Bitmap testImage;
    
    foreach (var image in testFiles)
    {
        
    }
    ```

In the following code blocks, we will be adding within the `foreach` loop.

1. First, generate the predicted image name based on the name of the original test image.

    ```csharp
    var predictedImage = $"{Path.GetFileName(image)}-predicted.jpg";
    ```

1. Next, create a `FileStream` of the image and convert it to a `Bitmap`.

    ```csharp
    using (var stream = new FileStream(image, FileMode.Open))
    {
        testImage = (Bitmap)Image.FromStream(stream);
    }
    ```

1. Now call the `Predict` method on the prediction engine.

    ```csharp
    var prediction = predictionEngine.Predict(new StopSignInput { Image = testImage });
    ```

1. With the prediction, you can get the bounding boxes. Use the `Chunk` LINQ method to determine how many objects the model has detected. Do this by taking the count of the predicted bounding boxes and divide that by the number of labels that were predicted. For example, if you had three objects detected in an image, there would be 12 items in the `BoundingBoxes` array and three labels predicted. The `Chunk` method would then give you three arrays of four to represent the bounding boxes for each object.

    ```csharp
    var boundingBoxes = prediction.BoundingBoxes.Chunk(prediction.BoundingBoxes.Count() / prediction.PredictedLabels.Count());
    ```

1. Next, capture the original width and height of the images used for prediction.

    ```csharp
    var originalWidth = testImage.Width;
    var originalHeight = testImage.Height;
    ```

1. With the bounding boxes chunk, loop through those to calculate where in the image to draw the boxes. For that, create a `for` loop based on the count of the bounding boxes chunk.

    ```csharp
    for (int i = 0; i < boundingBoxes.Count(); i++)
    {
    }
    ```

1. Within the `for` loop calculate the position of the x, and y coordinates as well as the width, and height of the box to draw on the image. The first thing you need to do is get the set of bounding boxes using the `ElementAt` method.

    ```csharp
    var boundingBox = boundingBoxes.ElementAt(i);
    ```

1. With the current bounding box, you can now calculate where to draw the box. Use the original image width for the first and third elements of the bounding box, and the original image height for the second and fourth elements.

    ```csharp
    var left = boundingBox[0] * originalWidth;
    var top = boundingBox[1] * originalHeight;
    var right = boundingBox[2] * originalWidth;
    var bottom = boundingBox[3] * originalHeight;
    ```

1. Calculate the width and the height of the box to draw around the detected object within the image. The x and y items will be the `left` and `top` variables from the previous calculation. Use the `Math.Abs` method to get the absolute value from the width and height calculations in case it is negative.

    ```csharp
    var x = left;
    var y = top;
    var width = Math.Abs(right - left);
    var height = Math.Abs(top - bottom);
    ```

1. Next, get the predicted label from the array of labels.

    ```csharp
    var label = labels[prediction.PredictedLabels[i]];
    ```

1. Create a graphic based on the test image using the `Graphics.FromImage` method.

    ```csharp
    using var graphics = Graphics.FromImage(testImage);
    ```

1. Draw on the image using the bounding box information. First, draw the rectangle around the detected objects using the `DrawRectangle` method that takes in a `Pen` object to determine the color and width of the rectangle, and pass in the `x`, `y`, `width`, and `height` variables.

    ```csharp
    graphics.DrawRectangle(new Pen(Color.NavajoWhite, 8), x, y, width, height);
    ```

1. Then, display the predicted label inside the box with the `DrawString` method that takes in the string to print out and a `Font` object to determine how to draw the string and where to place it.

    ```csharp
    graphics.DrawString(label, new Font(FontFamily.Families[0], 18f), Brushes.NavajoWhite, x + 5, y + 5);
    ```

Exit the `for` loop.

1. After the `for` loop, check if the predicted file already exists. If it does, delete it. Then, save it to the defined output path.

    ```csharp
    if (File.Exists(predictedImage))
    {
        File.Delete(predictedImage);
    }

    testImage.Save(Path.Combine(assemblyFolderPath, predictedImage));
    ```

## Next steps

In this tutorial you learned how to:

> [!div class="checklist"]
>
> * Understand the problem
> * Use the Custom Vision service to create an ONNX model
> * Incorporate the ONNX model into the ML.NET pipeline
> * Train the ML.NET model
> * Classify a test image

Try one of the other image classification tutorials:

- [Image Classification with Transfer Learning](image-classification-api-transfer-learning.md)
- [Image Classification with Model Builder](image-classification-model-builder.md)
- [Image CLassification with Tensorflow Model](image-classification.md)
