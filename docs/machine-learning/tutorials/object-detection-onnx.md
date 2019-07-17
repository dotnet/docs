---
title: 'Tutorial: Detect objects using deep learning with ONNX and ML.NET'
description: This tutorial illustrates how to use a pre-trained ONNX deep learning model in ML.NET to detect objects in images.
author: luisquintanilla
ms.author: luquinta
ms.date: 07/10/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can use a pre-trained model in an object detection scenario to detect objects in images using ONNX.
---

# Tutorial: Detect objects using ONNX in ML.NET

Learn how to use a pre-trained ONNX model in ML.NET to detect objects. The pre-trained model was trained to localize and classify objects in an image.

Training an object detection model from scratch requires setting millions of parameters, a large amount of labeled training data and a vast amount of compute resources (hundreds of GPU hours). Using a pre-trained model allows you to shortcut the training process.

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse the pre-trained model
> * Detect objects with a loaded model

## Pre-requisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.
- [Microsoft.ML NuGet Package](https://www.nuget.org/packages/Microsoft.ML/)
- [Microsoft.ML.ImageAnalytics NuGet Package](https://www.nuget.org/packages/Microsoft.ML.ImageAnalytics/)
- [Microsoft.ML.OnnxTransformer NuGet Package](https://www.nuget.org/packages/Microsoft.ML.OnnxTransformer/)
- [Tiny YOLOv2 pre-trained model](https://github.com/onnx/models/tree/master/tiny_yolov2)
- [Netron](https://github.com/lutzroeder/netron) (optional)

## ONNX object detection sample overview

This sample creates a .NET core console application that detects objects within an image using a pre-trained deep learning ONNX model. The code for this sample can be found on the [dotnet/machinelearning-samples repository](https://github.com/dotnet/machinelearning-samples/tree/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx) on GitHub.

## What is object detection

Object detection is a computer vision problem. While closely related to image classification, object detection performs image classification at a more granular scale. When an image is processed, there is first a check on whether there is an object present or not. If so, the detected object is classified and using localization, the location of that object is returned along with the class. Typically, you want to use this approach on images where there are multiple objects of different types so that each is individually recognized. 

![](./media/object-detection-onnx/img-classification-obj-detection.PNG)

Some use cases for object detection include:

- Self-Driving Cars
- Robotics
- Face Detection
- Workplace Safety
- Object Counting
- Activity Recognition

## Select the appropriate machine learning task 

Deep learning is a subset of machine learning. To train deep learning models, large quantities of data are required. Patterns in the data are represented by a series of layers. The relationships in the data are encoded as connections between the layers contanining weights. The higher the weight, the stronger the relationship. Collectively, this series of layers and connections are known as artificial neural networks. The more layers in a network, the "deeper" it is, making it a deep neural network. 

There are different types of neural networks, each more suitable than the other for cetrain tasks. The most common types of neural networks are Multi-Layered Perceptron (MLP), Convolutional Neural Network (CNN) and Recurrent Neural Network (RNN). The most basic is the MLP which maps a set of inputs to a set of outputs. This neural network is good when the data does not have a spatial or time component. The CNN as implied by the name makes use of convolutional layers which take into account spatial information contained in the data. A good use case for CNNs is image processing when trying to detect the presence of a particular feature in a region of an image (i.e. is there a nose in the center of an image?). Finally, RNNs allow for the persistence of state or memory to be used as input therefore making it a good candidates for time-series analysis where the sequential ordering and context of events is important. 

Object detection is an image processing task. Therefore, most deep learning models trained to solve this problem are CNNs. The model used in this tutorial is the Tiny YOLOv2 model, a more compact version of the YOLOv2 model described in the paper: ["YOLO9000: Better, Faster, Stronger" by Redmon and Fadhari](https://arxiv.org/pdf/1612.08242.pdf). Tiny YOLOv2 is trained on the Pascal VOC dataset and is made up of 15 layers that can predict 20 different classes of objects. Because Tiny YOLOv2 is a condensed version of the original YOLOv2 model, a tradeoff is made between speed and accuracy. 

The model is stored in ONNX format. The Open Neural Network Exchange (ONNX) is an open source format for AI models. ONNX supports interoperability between frameworks. This means you can train a model in one of the many popular machine learning frameworks like PyTorch, convert it into ONNX format and consume the ONNX model in a different framework like ML.NET. To learn more, visit the [ONNX website](https://onnx.ai/). 

![](./media/object-detection-onnx/onnx-frameworks.png)

## Create console application

### Create a project

1. Create a **.NET Core Console Application** called "ObjectDetection".

1. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**. Select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. Repeat these steps for **Microsoft.ML.ImageAnalytics** and **Microsoft.ML.OnnxTransformer**.

### Prepare your data and pre-trained model

1. Download [The project assets directory zip file](https://download.microsoft.com/download/0/E/5/0E5E0136-21CE-4C66-AC18-9917DED8A4AD/image-classifier-assets.zip) and unzip.

1. Copy the `assets` directory into your *ObjectDetection* project directory. This directory and its subdirectories contain the image files (except for the Tiny YOLOv2 model, which you'll download and add in the next step) needed for this tutorial.

1. Download the [Tiny YOLOv2 model](https://storage.googleapis.com/download.tensorflow.org/models/inception5h.zip) from the [ONNX Model Zoo](https://github.com/onnx/models#object-detection--image-segmentation-), and unzip.

    Open the command prompt and enter the following command:

    ```shell
    tar -xvzf tiny_yolov2.tar.gz 
    ```

1. Copy the extracted `model.onnx` file from the directory just unzipped into your *ObjectDetection* project `assets\Model` directory and rename it to `TinyYolo2_model.onnx`. This directory contains the model needed for this tutorial.

1. In Solution Explorer, right-click each of the files in the asset directory and subdirectories and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create classes and define paths

Open the *Program.cs* file and add the following additional `using` statements to the top of the file:

```csharp
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using Microsoft.ML;
using ObjectDetection.YoloParser;
using ObjectDetection.DataStructures;
```

Next, define the paths of the various assets. 

1. First, add the `GetAbsolutePath` method below the `Main` method in the `Program` class. 

    ```csharp
    public static string GetAbsolutePath(string relativePath)
    {
        FileInfo _dataRoot = new FileInfo(typeof(Program).Assembly.Location);
        string assemblyFolderPath = _dataRoot.Directory.FullName;

        string fullPath = Path.Combine(assemblyFolderPath, relativePath);

        return fullPath;
    }
    ``` 

1. Then, inside the `Main` method, create fields to store the location of your assets:

    ```csharp
    var assetsRelativePath = @"../../../assets";
    string assetsPath = GetAbsolutePath(assetsRelativePath);
    var modelFilePath = Path.Combine(assetsPath, "Model", "TinyYolo2_model.onnx");
    var imagesFolder = Path.Combine(assetsPath, "images");
    var outputFolder = Path.Combine(assetsPath, "images", "output");
    ```

Add a new directory to your project to store your input data and prediction classes.

    In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**. When the new folder appears in the Solution Explorer, name it "DataStructures".

Create your input data class in the newly created *DataStructures* directory.

1. In **Solution Explorer**, right-click the *DataStructures* directory, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImageNetData.cs*. Then, select the **Add** button.
     
    The *ImageNetData.cs* file opens in the code editor. Add the following `using` statement to the top of *ImageNetData.cs*:

    ```csharp
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Microsoft.ML.Data;
    ```

    Remove the existing class definition and add the following code for the `ImageNetData` class to the *ImageNetData.cs* file:
    
    ```csharp
    public class ImageNetData
    {
        [LoadColumn(0)]
        public string ImagePath;
    
        [LoadColumn(1)]
        public string Label;
    
        public static IEnumerable<ImageNetData> ReadFromFile(string imageFolder)
        {
            return Directory
                .GetFiles(imageFolder)
                .Where(filePath => Path.GetExtension(filePath) != ".md")
                .Select(filePath => new ImageNetData { ImagePath = filePath, Label = Path.GetFileName(filePath) });
        }
    }
    ```

    `ImageData` is the input image data class and has the following <xref:System.String> fields:

    - `ImagePath` contains the path where the image is stored.
    - `Label` contains the name of the file.

    Additionally, `ImageData` contains a method `ReadFromFile` which loads multiple image files stored in the `imageFolder` path specified and returns them as a collection of `ImageNetData` objects.

Create your prediction class in the *DataStructures* directory.

1. In **Solution Explorer**, right-click the *DataStructures* directory, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *ImageNetPrediction.cs*. Then, select the **Add** button.

    The *ImageNetPrediction.cs* file opens in the code editor. Add the following `using` statement to the top of *ImageNetPrediction.cs*:

    ```csharp
    using Microsoft.ML.Data;
    ```

    Remove the existing class definition and add the following code for the `ImageNetPrediction` class to the *ImageNetPrediction.cs* file:

    ```csharp
    public class ImageNetPrediction
    {
        [ColumnName("grid")]
        public float[] PredictedLabels;
    }
    ```

    `ImageNetPrediction` is the prediction data class and has the following `float[]` field:

    - `PredictedLabel` contains the dimensions, objectness score and class probabilities for each of the bounding boxes detected in an image.

### Initialize variables in Main

The [MLContext class](xref:Microsoft.ML.MLContext) is a starting point for all ML.NET operations, and initializing `mlContext` creates a new ML.NET environment that can be shared across the model creation workflow objects. It's similar, conceptually, to `DBContext` in Entity Framework.

Initialize the `mlContext` variable with a new instance of `MLContext` by adding the following line to the `Main` method of *Program.cs* below the `outputFolder` field.

```csharp
MLContext mlContext = new MLContext();
```

### Add Helper Methods

After the model has scored an image and the outputs have been processed, the bounding boxes have to be drawn on the image. To do so, add a method called `DrawBoundingBox` below the `GetAbsolutePath` method insode of *Program.cs*.

```csharp
private static void DrawBoundingBox(string inputImageLocation, string outputImageLocation, string imageName, IList<YoloBoundingBox> filteredBoundingBoxes)
{
}
```

First, load the image and get the height and width dimensions in the `DrawBoundingBox` method.

```csharp
Image image = Image.FromFile(Path.Combine(inputImageLocation, imageName));

var originalImageHeight = image.Height;
var originalImageWidth = image.Width;
```

Then, create a for-each loop to iterate over each of the bounding boxes detected by the model.

```csharp
foreach (var box in filteredBoundingBoxes)
{
}
```

Inside of the for-each loop, get the dimensions of the bounding box.

```csharp
// Get Bounding Box Dimensions
var x = (uint)Math.Max(box.Dimensions.X, 0);
var y = (uint)Math.Max(box.Dimensions.Y, 0);
var width = (uint)Math.Min(originalImageWidth - x, box.Dimensions.Width);
var height = (uint)Math.Min(originalImageHeight - y, box.Dimensions.Height);
```

Because the dimensions of the bounding box correspond to the model input of `416 x 416`, scale the bounding box dimensions to match the actual size of the image.

```csharp
x = (uint)originalImageWidth * x / 416;
y = (uint)originalImageHeight * y / 416;
width = (uint)originalImageWidth * width / 416;
height = (uint)originalImageHeight * height / 416;
```

Then, define a template for text that will apear above each bounding box. The text will contain the class of the object inside of the respective bounding box as well as the confidence.

```csharp
string text = $"{box.Label} ({(box.Confidence * 100).ToString("0")}%)";
```

In order to draw on the image, convert it to a [`Graphics`](xref:System.Drawing.Graphics) object.

```csharp
using (Graphics thumbnailGraphic = Graphics.FromImage(image))
{
}
```

Inside the `using` code block, tune the graphic's [`Graphics`](xref:System.Drawing.Graphics) object settings.

```csharp
thumbnailGraphic.CompositingQuality = CompositingQuality.HighQuality;
thumbnailGraphic.SmoothingMode = SmoothingMode.HighQuality;
thumbnailGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
```

Below that, set the font and color options for the text and bounding box.

```csharp
Font drawFont = new Font("Arial", 12, FontStyle.Bold);
SizeF size = thumbnailGraphic.MeasureString(text, drawFont);
SolidBrush fontBrush = new SolidBrush(Color.Black);
Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);

Pen pen = new Pen(box.BoxColor, 3.2f);
SolidBrush colorBrush = new SolidBrush(box.BoxColor);
```

Create and fill a rectangle above the bounding box to contain the text using the [`FillRectangle`](xref:System.Drawing.Graphics.FillRectangle*) method. This will help contrast the text and improve readability.

```csharp
thumbnailGraphic.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
```

Then, Draw the text and bounding box on the image using the [`DrawString`](xref:System.Drawing.Graphics.DrawString*) and [`DrawRectangle`](xref:System.Drawing.Graphics.DrawRectangle*) methods.

```csharp
thumbnailGraphic.DrawString(text, drawFont, fontBrush, atPoint);

thumbnailGraphic.DrawRectangle(pen, x, y, width, height);
```

Outside of the for-each loop, add code to save the images in the `outputDirectory`.

```csharp
if (!Directory.Exists(outputImageLocation))
{
    Directory.CreateDirectory(outputImageLocation);
}

image.Save(Path.Combine(outputImageLocation, imageName));
```

To get additional feedback that the application is making predictions as expected at runtime, add a method called `LogDetectedObjects` below the `DrawBoundingBox` method in the *Program.cs* file to output the detected objects to the console.

```csharp
private static void LogDetectedObjects(string imageName, IList<YoloBoundingBox> boundingBoxes)
{
    Console.WriteLine($".....The objects in the image {imageName} are detected as below....");

    foreach (var box in boundingBoxes)
    {
        Console.WriteLine($"{box.Label} and its Confidence score: {box.Confidence}");
    }

    Console.WriteLine("");
}
```

Both of these methods will be useful when the model has produced outputs and those have been processed. First though, create the functionality to process the model outputs.

## Create a parser to post-process model outputs

The expected output generated by the pre-trained ONNX model is a tensor of shape `125 x 13 x 13` that is returned as a one-dimensional `float[]` of 21125 elements. In order to extract the predictions generated by the model, some post-processing work is required. To do so, create a set of classes to help parse the output.

Add a new directory to your project to organize the set of parser classes.

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Folder**. When the new folder appears in the Solution Explorer, name it "YoloParser".

### Create bounding boxes and dimensions

Localization is a core component of object detection. As such, much of the data output by the model contains coordinates and dimensions of the bounding boxes of objects within the image. Create a base class for dimensions.

1. In **Solution Explorer**, right-click the *YoloParser* directory, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *DimensionsBase.cs*. Then, select the **Add** button.

    The *DimensionsBase.cs* file opens in the code editor. Remove all `using` statements and existing class definition. 

    Add the following code for the `DimensionsBase` class to the *DimensionsBase.cs* file:

    ```csharp
    public class DimensionsBase
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
    }
    ```

    `DimensionsBase` has the following `float` fields:

    - `X` contains the position of the object along the x-axis.
    - `Y` contains the position of the object along the y-axis.
    - `Height` contains the height of the object.
    - `Width` contains the width of the object.

Next, create a class for your bounding boxes.

1. In **Solution Explorer**, right-click the *YoloParser* directory, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *YoloBoundingBox.cs*. Then, select the **Add** button.

    The *YoloBoundingBox.cs* file opens in the code editor. Add the following `using` statement to the top of *YoloBoundingBox.cs*:

    ```csharp
    using System.Drawing;
    ```

    Just above the existing class definition, add a new class definition called `BoundingBoxDimensions` which inherits from the `DimensionsBase` class to contain the dimensions of the respective bounding box.

    ```csharp
    public class BoundingBoxDimensions : DimensionsBase { }
    ```

    Remove the existing `YoloBoundingBox` class definition and add the following code for the `YoloBoundingBox` class to the *YoloBoundingBox.cs* file:

    ```csharp
    public class YoloBoundingBox
    {
        public BoundingBoxDimensions Dimensions { get; set; }

        public string Label { get; set; }

        public float Confidence { get; set; }

        public RectangleF Rect
        {
            get { return new RectangleF(Dimensions.X, Dimensions.Y, Dimensions.Width, Dimensions.Height); }
        }

        public Color BoxColor { get; set; }
    }
    ```

    `DimensionsBase` has the following fields:

    - `Dimensions` contains dimensions of the bounding box.
    - `Label` contains the class of object detected within the bounding box.
    - `Confidence` contains the confidence of the class.
    - `Rect` contains the rectangle representation of the bounding box's dimensions.
    - `BoxColor` contains the color associated with the respective class used to draw on the image.

### Create parser

Now that the classes for dimensions and bounding boxes are created, it's time to create the parser.

1. In **Solution Explorer**, right-click the *YoloParser* directory, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *YoloWinMlParser.cs*. Then, select the **Add** button.

    The *YoloWinMlParser.cs* file opens in the code editor. Add the following `using` statement to the top of *YoloWinMlParser.cs*:

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    ```

    Inside the existing `YoloWinMlParser` class definition, add a nested class that contains the dimensions of each of the cells in the image. Add the following code for the `CellDimensions` class which inherits from the `DimensionsBase` class at the top of the `YoloOutputParser` class definition.

    ```csharp
    class CellDimensions : DimensionsBase { }
    ```

1. Define constant and fields.

    ```csharp
    public const int ROW_COUNT = 13;
    public const int COL_COUNT = 13;
    public const int CHANNEL_COUNT = 125;
    public const int BOXES_PER_CELL = 5;
    public const int BOX_INFO_FEATURE_COUNT = 5;
    public const int CLASS_COUNT = 20;
    public const float CELL_WIDTH = 32;
    public const float CELL_HEIGHT = 32;

    private int channelStride = ROW_COUNT * COL_COUNT;
    ```

    - `ROW_COUNT` is the number of rows in the grid the image is divided into.
    - `COL_COUNT` is the number of columns in the grid the image is divided into.
    - `CHANNEL_COUNT` is the total number of values contained in one cell of the grid.
    - `BOXES_PER_CELL` is the number of bounding boxes in a cell,
    - `BOX_INFO_FEATURE_COUNT` is the number of features contained within a box (x,y,height,width,confidence).
    - `CLASS_COUNT` is the number of class predictions contained in each bounding box.
    - `CELL_WIDTH` is the width of one cell in the image grid.
    - `CELL_HEIGHT` is the height of one cell in the image grid.
    - `channelStride` is the starting position of the current cell in the grid.


    When the model scores an image, it divides the `416px x 416px`input into a grid of cells the size of `13 x 13`. Each cell contains is `32px x 32px`. Within each cell, there are 5 bounding boxes each containing 5 features (x, y, width, height, confidence). In addition, each bounding box contains the probability of each of the classes which in this case is 20. Therefore, each cell contains 125 pieces of information (5 features + 20 class probabilities). 

Create a list of anchors below `channelStride` for all 5 bounding boxes:

```csharp
private float[] anchors = new float[]
{
    1.08F, 1.19F, 3.42F, 4.41F, 6.63F, 11.38F, 9.42F, 5.11F, 16.62F, 10.52F
};
```

Anchors are pre-defined height and width ratios of bounding boxes. Most object or classes detected by a model have similar ratios. This is valuable when it comes to creating bounding boxes. Instead of predicting the bounding boxes, the offset from the pre-defined dimensions is calculated therefore reducing the computation required to predict the bounding box. Typically these anchor ratios are calculated based on the dataset used. In this case because the dataset is known and the values have been pre-computed, the anchors can be hard-coded.

Next, define the labels or classes that the model will predict. This model predicts 20 classes which is a subset of the total number of classes predicted by the original YOLOv2 model.

Add your list of labels below the `anchors`. 

```csharp
private string[] labels = new string[]
{
    "aeroplane", "bicycle", "bird", "boat", "bottle",
    "bus", "car", "cat", "chair", "cow",
    "diningtable", "dog", "horse", "motorbike", "person",
    "pottedplant", "sheep", "sofa", "train", "tvmonitor"
};
```

There are colors associated with each of the classes. Assign your class colors below your `labels`:

```csharp
private static Color[] classColors = new Color[]
{
    Color.Khaki,
    Color.Fuchsia,
    Color.Silver,
    Color.RoyalBlue,
    Color.Green,
    Color.DarkOrange,
    Color.Purple,
    Color.Gold,
    Color.Red,
    Color.Aquamarine,
    Color.Lime,
    Color.AliceBlue,
    Color.Sienna,
    Color.Orchid,
    Color.Tan,
    Color.LightPink,
    Color.Yellow,
    Color.HotPink,
    Color.OliveDrab,
    Color.SandyBrown,
    Color.DarkTurquoise
};
```

### Create Helper Functions

There are a series of steps involved in the post-processing phase. To help with that, several helper methods can be employed. 

The helper methods used in by the parser are:

- `Sigmoid` applies the sigmoid function that outputs a number between 0 and 1.
- `Softmax` normalizes an input vector into a probability distribution.
- `GetOffset` maps elements in the one-dimensional model output to the corresponding position in a `125 x 13 x 13` tensor.
- `ExtractBoundingBoxes` extracts the bounding box dimensions using the `GetOffset` method from the model output.
- `GetConfidence` extracts the confidence value which states how sure the model is that it has detected an object and uses the `Sigmoid` function to turn it into a percentage.
- `MapBoundingBoxToCell` uses the bounding box dimensions and maps them onto its respective cell within the image.
- `ExtractClasses` extracts the class predictions for the bounding box from the model output using the `GetOffset` method and turns them into a probability distribution using the `Softmax` method.
- `GetTopResult` selects the class from the list of predicted classes with the highest probability.
- `IntersectionOverUnion` utilizes non-maximum suppression to filter overlapping bounding boxes with lower probabilities.

Add the code for all the helper methods below your list of `classColors`.

```csharp
private float Sigmoid(float value)
{
    var k = (float)Math.Exp(value);
    return k / (1.0f + k);
}

private float[] Softmax(float[] values)
{
    var maxVal = values.Max();
    var exp = values.Select(v => Math.Exp(v - maxVal));
    var sumExp = exp.Sum();

    return exp.Select(v => (float)(v / sumExp)).ToArray();
}

private int GetOffset(int x, int y, int channel)
{
    return (channel * this.channelStride) + (y * COL_COUNT) + x;
}

private BoundingBoxDimensions ExtractBoundingBoxDimensions(float[] modelOutput, int x, int y, int channel)
{
    return new BoundingBoxDimensions
    {
        X = modelOutput[GetOffset(x, y, channel)],
        Y = modelOutput[GetOffset(x, y, channel + 1)],
        Width = modelOutput[GetOffset(x, y, channel + 2)],
        Height = modelOutput[GetOffset(x, y, channel + 3)]
    };
}

private float GetConfidence(float[] modelOutput, int x, int y, int channel)
{
    return Sigmoid(modelOutput[GetOffset(x, y, channel + 4)]);
}

private CellDimensions MapBoundingBoxToCell(int x, int y, int box, BoundingBoxDimensions boxDimensions)
{
    return new CellDimensions
    {
        X = ((float)x + Sigmoid(boxDimensions.X)) * CELL_WIDTH,
        Y = ((float)y + Sigmoid(boxDimensions.Y)) * CELL_HEIGHT,
        Width = (float)Math.Exp(boxDimensions.Width) * CELL_WIDTH * anchors[box * 2],
        Height = (float)Math.Exp(boxDimensions.Height) * CELL_HEIGHT * anchors[box * 2 + 1],
    };
}

public float[] ExtractClasses(float[] modelOutput, int x, int y, int channel)
{
    float[] predictedClasses = new float[CLASS_COUNT];
    int predictedClassOffset = channel + BOX_INFO_FEATURE_COUNT;
    for (int predictedClass = 0; predictedClass < CLASS_COUNT; predictedClass++)
    {
        predictedClasses[predictedClass] = modelOutput[GetOffset(x, y, predictedClass + predictedClassOffset)];
    }
    return Softmax(predictedClasses);
}

private ValueTuple<int, float> GetTopResult(float[] predictedClasses)
{
    return predictedClasses
        .Select((predictedClass, index) => (Index: index, Value: predictedClass))
        .OrderByDescending(result => result.Value)
        .First();
}

private float IntersectionOverUnion(RectangleF boundingBoxA, RectangleF boundingBoxB)
{
    var areaA = boundingBoxA.Width * boundingBoxA.Height;

    if (areaA <= 0)
        return 0;

    var areaB = boundingBoxB.Width * boundingBoxB.Height;

    if (areaB <= 0)
        return 0;

    var minX = Math.Max(boundingBoxA.Left, boundingBoxB.Left);
    var minY = Math.Max(boundingBoxA.Top, boundingBoxB.Top);
    var maxX = Math.Min(boundingBoxA.Right, boundingBoxB.Right);
    var maxY = Math.Min(boundingBoxA.Bottom, boundingBoxB.Bottom);

    var intersectionArea = Math.Max(maxY - minY, 0) * Math.Max(maxX - minX, 0);

    return intersectionArea / (areaA + areaB - intersectionArea);
}
```

Once you have defined all of the helper methods, it's time to use them to process the model output.

Below the `IntersectionOverUnion` method, create the `ParseOutputs` method to process the output generated by the model.

```csharp
public IList<YoloBoundingBox> ParseOutputs(float[] yoloModelOutputs, float threshold = .3F)
{

}
```
    
Create a list to store your bounding boxes and define variables inside the `ParseOutputs` method.

```csharp
var boxes = new List<YoloBoundingBox>();
```

Each image is divided into a grid of `13 x 13` cells. Each cell contains five bounding boxes. Below the `boxes` variable, add code to process all of the boxes in each of the cells.

```csharp
for (int row = 0; row < ROW_COUNT; row++)
{
    for (int column = 0; column < COL_COUNT; column++)
    {
        for (int box = 0; box < BOXES_PER_CELL; box++)
        {

        }
    }
}
```

Inside the inner-most loop, calculate the starting position of the current box within the one-dimensional model output.

```csharp
var channel = (box * (CLASS_COUNT + BOX_INFO_FEATURE_COUNT));
```

Directly below that, use the `ExtractBoundingBoxDimensions` method to get the dimensions of the current bounding box.

```csharp
BoundingBoxDimensions boundingBoxDimensions = ExtractBoundingBoxDimensions(yoloModelOutputs, row, column, channel);
```

Then, use the `GetConfidence` method to get the confidence for the current bounding box.

```csharp
float confidence = GetConfidence(yoloModelOutputs, row, column, channel);
```

After that, use the `MapBoundingBoxToCell` method to map the current bounding box to the current cell being processed.

```csharp
CellDimensions mappedBoundingBox = MapBoundingBoxToCell(row, column, box, boundingBoxDimensions);
```

Before doing any further processing, check whether your confidence value is greater than the threshold provided. If not, process the next bounding box.

```csharp
if (confidence < threshold)
    continue;
```

Otherwise, continue processing the output. The next step is to get the probability distribution of the predicted classes for the current bounding box using the `ExtractClasses` method.

```csharp
float[] predictedClasses = ExtractClasses(yoloModelOutputs, row, column, channel);
```

Then, use the `GetTopResult` method to get the value and index of the class with the highest probability for the current box and compute its score.

```csharp
var (topResultIndex, topResultScore) = GetTopResult(predictedClasses);
var topScore = topResultScore * confidence;
```

Use the `topScore` to once again keep only those bounding boxes that are above the specified threshold.

```csharp
if (topScore < threshold)
    continue;
```

Finally, if the current bounding box exceeds the threshold, create a new `BoundingBox` object and add it to the `boxes` list.

```csharp
boxes.Add(new YoloBoundingBox()
{
    Dimensions = new BoundingBoxDimensions
    {
        X = (mappedBoundingBox.X - mappedBoundingBox.Width / 2),
        Y = (mappedBoundingBox.Y - mappedBoundingBox.Height / 2),
        Width = mappedBoundingBox.Width,
        Height = mappedBoundingBox.Height,
    },
    Confidence = topScore,
    Label = labels[topResultIndex],
    BoxColor = classColors[topResultIndex]
});
```

Once all cells in the image have been processed, return the `boxes` list. Add the following return statement below the outer-most for-loop in the `ParseOutputs` method.

```csharp
return boxes;
```

### Filter overlapping boxes

Now that all of the highly confident bounding boxes have been extracted from the model output, additional filtering needs to be done to remove overlapping images. Add a method called `FilterBoundingBoxes` below the `ParseOutputs` method:

```csharp
public IList<YoloBoundingBox> FilterBoundingBoxes(IList<YoloBoundingBox> boxes, int limit, float threshold)
{
}
```

Inside the `FilterBoundingBoxes` method, start off by creating an array equal to the size of detected boxes and marking all slots as active or ready for processing.

```csharp
var activeCount = boxes.Count;
var isActiveBoxes = new bool[boxes.Count];

for (int i = 0; i < isActiveBoxes.Length; i++)
    isActiveBoxes[i] = true;
```

Then, sort the list containing your bounding boxes in descending order based on confidence.

```csharp
var sortedBoxes = boxes.Select((b, i) => new { Box = b, Index = i })
                    .OrderByDescending(b => b.Box.Confidence)
                    .ToList();
```

After that, create a list to hold the filtered results.

```csharp
var results = new List<YoloBoundingBox>();
```

Begin processing each bounding box by iterating over each of the bounding boxes.

```csharp
for (int i = 0; i < boxes.Count; i++)
{

}
```

Inside of this for-loop, check whether the current bounding box can be processed.

```csharp
if (isActiveBoxes[i])
{
    
}
```

If so, add the bounding box to the list of results. If the results exceeds the specified limit of boxes to be extracted, break out of the loop. Add the following code inside the if-statement.

```csharp
if (results.Count >= limit)
    break;
```

Otherwise, look at the adjacent bounding boxes. Add the following code below the box limit check.

```csharp
for (var j = i + 1; j < boxes.Count; j++)
{

}
```

Like the first box, if the adjacent box is active or ready to be processed, use the `IntersectionOverUnion` method to check whether the first box and the second box exceed the specified threshold. Add the following code to your for-loop.

```csharp
if (isActiveBoxes[j])
{
    var boxB = sortedBoxes[j].Box;

    if (IntersectionOverUnion(boxA.Rect, boxB.Rect) > threshold)
    {
        isActiveBoxes[j] = false;
        activeCount--;

        if (activeCount <= 0)
            break;
    }
}
```

Outside of the for-loop that checks adjacent bounding boxes, check whether there are any remaining bounding boxes to be processed. If not, break out of the for-loop.

```csharp
if (activeCount <= 0)
    break;
```

Finally, outside of the initial for-loop of the `FilterBoundingBoxes` method, return the results:

```chsarp
return results;
```

Great! Now it's time to leverage this code along with the model for scoring.

## Use the model for scoring

Just like with post-processing, there are a few steps in the scoring steps. To help with this, add a class that will contain the scoring logic to your project.

1. In **Solution Explorer**, right-click the project, and then select **Add** > **New Item**.
1. In the **Add New Item** dialog box, select **Class** and change the **Name** field to *OnnxModelScorer.cs*. Then, select the **Add** button.

    The *OnnxModelScorer.cs* file opens in the code editor. Add the following `using` statement to the top of *OnnxModelScorer.cs*:

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.ML;
    using Microsoft.ML.Data;
    using ObjectDetection.DataStructures;
    using ObjectDetection.YoloParser;
    ```

    Inside the `OnnxModelScorer` class definition add the following variables.

    ```csharp
    private readonly string imagesFolder;
    private readonly string modelLocation;
    private readonly MLContext mlContext;

    private IList<YoloBoundingBox> _boundingBoxes = new List<YoloBoundingBox>();
    ```

    Directly below that, create a constructor for the `OnnxModelScorer` class that will initialize the previously defined variables.

    ```csharp
    public OnnxModelScorer(string imagesFolder, string modelLocation, MLContext mlContext)
    {
        this.imagesFolder = imagesFolder;
        this.modelLocation = modelLocation;
        this.mlContext = mlContext;
    }
    ```

    Once you have created the constructor, define a couple of structs that contain variables related to the image and model settings. Create a struct called `ImageNetSettings` to contain the height and width expected as input for the model.

    ```csharp
    public struct ImageNetSettings
    {
        public const int imageHeight = 416;
        public const int imageWidth = 416;
    }    
    ```

    After that, create another struct called `TinyYoloModelSettings` which contains the names of the input and output layers of the model. To visualize the name of the input and output layers of the model you can use a tool like [Netron](https://github.com/lutzroeder/netron).

    ```csharp
    public struct TinyYoloModelSettings
    {
        // for checking Tiny yolo2 Model input and  output  parameter names,
        //you can use tools like Netron, 
        // which is installed by Visual Studio AI Tools

        // input tensor name
        public const string ModelInput = "image";

        // output tensor name
        public const string ModelOutput = "grid";
    }    
    ```


    Next, create the first set of methods use for scoring. Create the `LoadModel` method inside of your `OnnxModelScorer` class.

    ```csharp
    private ITransformer LoadModel(string modelLocation)
    {
    }
    ```

    Inside the `LoadModel` method, add the following code for logging.

    ```csharp
    Console.WriteLine("Read model");
    Console.WriteLine($"Model location: {modelLocation}");
    Console.WriteLine($"Default parameters: image size=({ImageNetSettings.imageWidth},{ImageNetSettings.imageHeight})");
    ```

    ML.NET pipelines typically expect data to operate on when the [`Fit`](xref:Microsoft.ML.IEstimator%601.Fit*) method is called. In this case, a process similar to training will be used. However, because no actual training is happening, it is acceptable to use an empty [`IDataView`](xref:Microsoft.ML.IDataView). Create a new [`IDataView`](xref:Microsoft.ML.IDataView) for the pipeline from an empty list.

    ```csharp
    var data = _mlContext.Data.LoadFromEnumerable(new List<ImageNetData>());
    ```

    Below that, define the pipeline. The pipeline will consist of four transforms.

    - [`LoadImages`](xref:Microsoft.ML.ImageEstimatorsCatalog.LoadImages*) loads the image as a Bitmap.
    - [`ResizeImages`](xref:Microsoft.ML.ImageEstimatorsCatalog.ResizeImages*) rescales the image to the size specified (in this case, `416 x 416`).
    - [`ExtractPixels`](xref:Microsoft.ML.ImageEstimatorsCatalog.ExtractPixels*) changes the pixel representation of the image from a Bitmap to a numerical vector.
    - [`ApplyOnnxModel`](xref:Microsoft.ML.OnnxCatalog.ApplyOnnxModel*) loads the ONNX model and uses it to score on the data provided.

    Define your pipeline in the `LoadModel` method below the `data` variable.

    ```csharp
    var pipeline = _mlContext.Transforms.LoadImages(outputColumnName: "image", imageFolder: "", inputColumnName: nameof(ImageNetData.ImagePath))
                .Append(_mlContext.Transforms.ResizeImages(outputColumnName: "image", imageWidth: ImageNetSettings.imageWidth, imageHeight: ImageNetSettings.imageHeight, inputColumnName: "image"))
                .Append(_mlContext.Transforms.ExtractPixels(outputColumnName: "image"))
                .Append(_mlContext.Transforms.ApplyOnnxModel(modelFile: modelLocation, outputColumnNames: new[] { TinyYoloModelSettings.ModelOutput }, inputColumnNames: new[] { TinyYoloModelSettings.ModelInput }));
    ```

    Now it's time to instantiate the model for scoring. Call the [`Fit`](xref:Microsoft.ML.IEstimator%601.Fit*) method on the pipeline and return it for further processing.

    ```csharp
    var model = pipeline.Fit(data);

    return model;
    ```

Once the model is loaded, it can then be used to make predictions. To facilitate that process, create a method called `PredictDataUsingModel` below the `LoadModel` method.

```csharp
private IEnumerable<float[]> PredictDataUsingModel(IDataView testData, ITransformer model)
{
}
```

Inside the `PredictDataUsingModel` add the following code for logging.

```csharp
Console.WriteLine($"Images location: {imagesFolder}");
Console.WriteLine("");
Console.WriteLine("=====Identify the objects in the images=====");
Console.WriteLine("");
```

Then, use the [`Transform`](xref:Microsoft.ML.ITransformer.Transform*) method to score the data.

```csharp
IDataView scoredData = model.Transform(testData);
```

Extract the predicted probabilities and return them for additional processing.

```csharp
IEnumerable<float[]> probabilities = scoredData.GetColumn<float[]>(TinyYoloModelSettings.ModelOutput);

return probabilities;
```

Now that both steps are set up, combine them into a single method. Below the `PredictDataUsingModel` method, add a new method called `Score`.

```csharp
public IEnumerable<float[]> Score(IDataView data)
{
    var model = LoadModel(_modelLocation);

    return PredictDataUsingModel(data, model);
}
```

Almost there! Now it's time to put it all to use.

## Detect Objects

Now that all of the setup is complete, it's time to detect some objects. Inside the `Main` method of your *Program.cs* class, add a try-catch statement.

```csharp
try
{

}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
```

Inside of the `try` block, start implementing the object detection logic. First, load the data into an [`IDataView`](xref:Microsoft.ML.IDataView).

```csharp
IEnumerable<ImageNetData> images = ImageNetData.ReadFromFile(imagesFolder);
IDataView imageDataView = mlContext.Data.LoadFromEnumerable(images);
```

Then, create an instance of `OnnxModelScorer` and use it to score the loaded data.

```csharp
var modelScorer = new OnnxModelScorer(imagesFolder, modelFilePath, mlContext);

IEnumerable<float[]> probabilities = modelScorer.Score(imageDataView);
```

Now it's time for the post-processing step. Create an instance of `YoloOutputParser` and use it to process the model output.

```csharp
YoloOutputParser parser = new YoloOutputParser();

var boundingBoxes =
    probabilities
    .Select(probability => parser.ParseOutputs(probability))
    .Select(boxes => parser.FilterBoundingBoxes(boxes, 5, .5F));
```

Once the model output has been processed, it's time to draw the bounding boxes on the images. Create a for-loop to iterate over each of the scored images.

```csharp
for (var i = 0; i < images.Count(); i++)
{
}
```

Inside of the for-loop, get the name of the image file and the bounding boxes associated with it.

```csharp
string imageFileName = images.ElementAt(i).Label;
IList<YoloBoundingBox> detectedObjects = boundingBoxes.ElementAt(i);
```

Below that, use the `DrawBoundingBox` method to draw the bounding boxes on the image.

```csharp
DrawBoundingBox(imagesFolder, outputFolder, imageFileName, detectedObjects);
```

Lastly, add some logging logic with the `LogDetectedObjects` method.

```csharp
LogDetectedObjects(imageFileName, detectedObjects);
```

After the try-catch statement, add additional logic to indicate the process is done running.

```csharp
Console.WriteLine("========= End of Process..Hit any Key ========");
Console.ReadLine();
```

That's it! 

## Results 

After following the previous steps, run your console app (Ctrl + F5). Your results should be similar to the following output. You may see warnings or processing messages, but these messages have been removed from the following results for clarity.

```console
=====Identify the objects in the images=====

.....The objects in the image image1.jpg are detected as below....
car and its Confidence score: 0.9697262
car and its Confidence score: 0.6674225
person and its Confidence score: 0.5226039
car and its Confidence score: 0.5224892
car and its Confidence score: 0.4675332

.....The objects in the image image2.jpg are detected as below....
cat and its Confidence score: 0.6461141
cat and its Confidence score: 0.6400049

.....The objects in the image image3.jpg are detected as below....
chair and its Confidence score: 0.840578
chair and its Confidence score: 0.796363
diningtable and its Confidence score: 0.6056048
diningtable and its Confidence score: 0.3737402

.....The objects in the image image4.jpg are detected as below....
dog and its Confidence score: 0.7608147
person and its Confidence score: 0.6321323
dog and its Confidence score: 0.5967442
person and its Confidence score: 0.5730394
person and its Confidence score: 0.5551759

========= End of Process..Hit any Key ========
```

To see the images with bounding boxes, navigate to the `assets/images/output/` directory. Below is a sample from one of the processed images. 

![](./media/object-detection-onnx/image3.jpg)

Congratulations! You've now successfully built a machine learning model for object detection by reusing a pre-trained `ONNX` model in ML.NET.

You can find the source code for this tutorial at the [dotnet/samples](https://github.com/dotnet/machinelearning-samples/tree/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx) repository.

In this tutorial, you learned how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse and tune the pre-trained model
> * Detect objects with a loaded model

Check out the Machine Learning samples GitHub repository to explore an expanded object detection sample.
> [!div class="nextstepaction"]
> [dotnet/machinelearning-samples GitHub repository](https://github.com/dotnet/machinelearning-samples/tree/master/samples/csharp/end-to-end-apps/DeepLearning_ObjectDetection_Onnx)