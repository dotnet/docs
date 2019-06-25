---
title: 'Tutorial: Detect objects using deep learning with ONNX and ML.NET'
description: This tutorial illustrates how to use a pre-trained ONNX deep learning model in ML.NET to detect objects in images.
author: luisquintanilla
ms.author: luquinta
ms.date: 06/10/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can use a pre-trained model in an object detection scenario to detect objects in images using ONNX.
---

# Tutorial: Detect objects using deep learning with ONNX

Learn how to use a pre-trained ONNX model in ML.NET to detect objects. 

In this tutorial, you learn how to:
> [!div class="checklist"]
> * Understand the problem
> * Reuse and tune the pre-trained model
> * Classify Images

## Pre-requisites

- [Visual Studio 2017 15.6 or later](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2017) with the ".NET Core cross-platform development" workload installed.
- [Microsoft.ML NuGet Package](https://www.nuget.org/packages/Microsoft.ML/)
- [Microsoft.ML.ImageAnalytics NuGet Package](https://www.nuget.org/packages/Microsoft.ML.ImageAnalytics/)
- [Microsoft.ML.OnnxTransformer 0.13.0 NuGet Package](https://www.nuget.org/packages/Microsoft.ML.OnnxTransformer/)
- [Tiny YOLOv2 pre-trained model](https://github.com/onnx/models/tree/master/tiny_yolov2)
- [Netron](https://github.com/lutzroeder/netron) (optional)

## ONNX object detection sample overview

This sample creates a .NET core console application that detects objects within an image using a pre-trained deep learning ONNX model. The code for this sample can be found on the [dotnet/machinelearning-samples repository](https://github.com/dotnet/machinelearning-samples) on GitHub.

### What is object detection

Object detection is a computer vision problem. While closely related to image classification, object detection performs image classification at a more granular scale. When an image is processed, there is first a check on whether there is an object present or not. If so, the detected object is classified and using localization, the location of that object is returned along with the class. Typically, you want to use this approach on images where there are multiple objects of different types so that each is individually recognized. 

![](./media/object-detection-onnx/img-classification-obj-detection.PNG)

Some use cases for object detection include:

- Self-Driving Cars
- Robotics
- Face Detection
- Workplace Safety
- Object Counting
- Activity Recognition

### What is ONNX

The Open Neural Network Exchange (ONNX) is an open source format for AI models. The framework supports interoperability between frameworks. To learn more, visit the [ONNX website](https://onnx.ai/). 

![](./media/object-detection-onnx/onnx-frameworks.png)

## Understand the problem

## Create console application

1. Create a **.NET Core Console Application** called "DeepLearning_ObjectDetection_Onnx".

2. Install the **Microsoft.ML NuGet Package**:

    In Solution Explorer, right-click on your project and select **Manage NuGet Packages**. Choose "nuget.org" as the Package source, select the Browse tab, search for **Microsoft.ML**. Click on the **Version** drop-down, select the **1.1.0** package in the list, and select the **Install** button. Select the **OK** button on the **Preview Changes** dialog and then select the **I Accept** button on the **License Acceptance** dialog if you agree with the license terms for the packages listed. Repeat these steps for **Microsoft.ML.ImageAnalytics v1.1.0** and **Microsoft.ML.OnnxTransformer v0.13.0**.

## Prepare the data and models

1. Download [The project assets directory zip file](https://download.microsoft.com/download/0/E/5/0E5E0136-21CE-4C66-AC18-9917DED8A4AD/image-classifier-assets.zip), and unzip.
1. Copy the `assets` directory into your *DeepLearning_ObjectDetection_Onnx* project directory. This directory and its subdirectories contain the data and support files (except for the Tiny YOLOv2 model, which you'll download and add in the next step) needed for this tutorial.

3. Download the [Tiny YOLOv2 model](https://storage.googleapis.com/download.tensorflow.org/models/inception5h.zip), and unzip.

  - Open the command shell and enter the following command:

    ```shell
    tar -xvzf tiny_yolov2.tar.gz 
    ```

4. Copy the extracted `model.onnx` file from the directory just unzipped into your *DeepLearning_ObjectDetection_Onnx* project `assets\Model` directory. This directory contains the model needed for this tutorial.

5. In Solution Explorer, right-click each of the files in the asset directory and subdirectories and select **Properties**. Under **Advanced**, change the value of **Copy to Output Directory** to **Copy if newer**.

### Create Data Models

1. Create a `DataStructures` directory in your *DeepLearning_ObjectDetection_Onnx* project.
1. Create a class called `ImageNetData`.

    Add the following using statements.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetData.cs#L1)]

    Then, add the following code to define your `ImageNetData` class.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetData.cs#L5-L12)]

    Finally, add the following code to define your `ImageNetProbability` class.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetData.cs#L14-L18)]

1. Create a class called `ImageNetPrediction`

    Add the following using statements.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetPrediction.cs#L1)]

    Then, add the following code to define your `ImageNetPrediction` class.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetData.cs#L5-L9)]

## Use pre-trained ONNX model

ML.NET supports scoring, or making predictions, with pre-trained ONNX models. The [ONNX Model Zoo](https://github.com/onnx/models) hosts several pre-trained models for tasks such as image classification, object detection, machine translation, and speech processing.

Since this sample is meant to detect objects, the model used is Tiny YOLOv2. 

### About the model

Tiny YOLOv2 is a smaller version of the YOLOv2 model, a real-time object detection system trained on the Pascal VOC dataset. For more details on YOLOv2, see the paper [*YOLO9000: Better, Faster, Stronger (Redmon,Farhadi 2016)*](https://arxiv.org/pdf/1612.08242.pdf).  

Tiny YOLOv2 can detect 20 different classes of objects.

### Inspecting the model

**PLACEHOLDER**
Explain in this section how to use Netron to inspect models 

## Use Model For Scoring

In order to score using the pre-trained ONNX model, create a helper class called `OnnxModelScorer`

1. In Solution Explorer, right-click the project, and then select Add > New Item.
1. In the Add New Item dialog box, select Class and change the Name field to *OnnxModelScorer.cs*. Then, select the Add button.
1. When the *OnnxModelScorer.cs* file opens in the code editor. Add the following using statement to the top of *OnnxModelScorer.cs*:

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L1-L7)]

1. Next, inside the `OnnxModelScorer` class, define global variables that will be used during scoring. 

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L13-L18)]

    - *imagesFolder* is the path where the images are stored.
    - *modelLocation* is the path where the pre-trained ONNX model is stored.
    - *mlContext* is the `MLContext` object to be used in the application.
    - *_boundingBoxes* stores the post-processed data output by the `YoloWinMlParser`.
    - *_parser* is an instance of another helper class `YoloWinMlParser` that post-processes the scored data output by the `ApplyOnnxTransform`.

1. Initialize the `imagesFolder`, `modelLocation` and `mlContext` variables inside the constructor

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L20-L25)]

1. Create a struct called `ImageNetSettings` to contain the size and height of the images expected by the model.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L27-L31)]

1. Additionally, create a struct called `TinyYoloModelSettings` to contain the name of the name of the input and output layers of the model.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L33-L44)]

1. Add the `Score` method below the most recently created structs.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L46-L51)]

    The `Score` method loads the model for predictions using the `LoadModel` method and then uses it to make predictions with the `PredictDataUsingModel` method.

### Create Scoring Pipeline

The next set of methods consolidate the pipeline creation and scoring logic. 

1. Below the `Score` method, create the `LoadModel` method.

    [!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L53-L71)]

    The `LoadModel` method creates the model pipeline and returns a `PredictionEngine`. The training pipeline contains the following steps:  

    1. Uses the [`LoadImages`](xref:Microsoft.ML.ImageEstimatorsCatalog.LoadImages*) transform to load the images in the `imagesFolder`. 
    1. Resizes the image to the expected input size of 416 x 416 using the [`ResizeImages`](xref:Microsoft.ML.ImageEstimatorsCatalog.ResizeImages*) transform.
    1. Convert image into pixels to be input into the model using the [`ExtractPixels`](xref:Microsoft.ML.ImageEstimatorsCatalog.ExtractPixels*) transform.
    1. Uses the ONNX pre-trained model to detect objects in the image using the [`ApplyOnnxModel`](xref:Microsoft.ML.OnnxCatalog.ApplyOnnxModel*) transform.

### Make Predictions

The logic to make predictions is contained within the `PredictDataUsingModel` method.

Below the `LoadModel` method definition, add a new method called `PredictDataUsingModel` with the following signature.

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L73)]

Inside the `PredictDataUsingModel` method, add the following content for logging purposes.

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L75-L78)]

Then, load the images that will be scored using the `GetImagesData` method which creates a list of `ImageNetData` objects by loading the files in the specified `imagesFolder` Directory. Add the `GetImagesData` method after the `PredictDataUsingModel` method.

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L103-L113)]

Once all of the images are loaded, use the model's `PredictionEngine` to execute the steps in the pipeline for each of the loaded images.

Start off by creating a for-loop to iterate over each of the loaded images.

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L82)]

Inside the for-loop, use the `PredictionEngine.Predict` method to have the model process the image and detect objects. 

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/ONNXModelScorer.cs#L84)]

Once the model generates results for the respective image, it needs to be post-processed. Post-processing will be done by the `_parser`. The first step in the post-processing phase is to map the model outputs to the image. This is done by the `ParseOutputs` method of the `YoloWinMLParser`. 

## Post-Processing Model Outputs

The shape of the output is a 1-dimensional vector of x elements. However, the data is structured in 13 x 13 x 125. As a result, the model output needs to be processed to extract the information stored in the output. 

To do so, create a new directory called `YoloParser`.

When the model is applied to images, it looks throughout different blocks in the image, detects objects and tries to pinpoint where int he image the object was detected. This data is stored as part of the model output. 

### Build domain classes

1. Create a new class called `DimensionsBase.cs`.
2. When `DimensionsBase.cs` opens in the text editor, add the following code:

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/DimensionsBase.cs#L1-L10)]

The dimensions in the model output correspond to bounding boxes. Bounding boxes can be thought of as rectangular regions containing cartesian coordinates, height and width within a plane. In this case, it's relative to the section of the image that was analyzed by the model. 

1. To define a bounding box, create a new class called `YoloBoundingBox.cs`.
1. When `YoloBoundingBox.cs` opens in the editor, add the following usings:

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloBoundingBox.cs#L1-L2)]

1. Add the following class definition 

    [!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloBoundingBox.cs#L6-L20)]

    Below the definition for `YoloBoundingBox` class, create another class called `BondingBoxDimensions` which inherits from `DimensionsBase` class.

### Build Parser

Once the classes used by the parser are set up, it's time to set up the parser.

Inside the `YoloParser` directory, create a new class called `YoloWinMlParser.cs`.

When `YoloWinMlParser.cs` opens in the editor, add the following usings:

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloWinMlParser.cs#L1-L5)]

When the image is being processed, it is divided into 13 x 13 cells or regions. These regions each are of 32px x 32px dimensions. As part of post-processing, the dimensions of the bounding boxes extracted from each of the cells has to be mapped into the grid. Therefore, you need to know what the dimensions of the respective cell being analyzed are respective to the image itself.

Inside the `YoloWinMlParser` class, create a new class called `CellDimensions` which inherits from `DimensionsBase`.

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloWinMlParser.cs#L12)]

Next, create constants to be used by the parser during post-processing.

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloWinMlParser.cs#L14-L21)]

As mentioned previously, the 416 x 416 image is divided into 13 x 13 regions. The height and width of each of these regions is 32 x 32, each of which 5 bounding boxes. Each bounding box contains 5 features (x,y,height,width and confidence). Additionally, the probabilities for each of the 20 classes. As a result, a total of 125 values need to be extracted from each of the image regions. 

Although the regions can be thought of as 13 x 13, the original output of the models is one-dimensional. Therefore, they need to 

[!code-csharp [](~/machinelearning-samples/blob/master/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/YoloParser/YoloWinMlParser.cs#L23)]