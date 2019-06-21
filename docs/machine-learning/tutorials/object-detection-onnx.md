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
1.



1. Create a class called `ImageNetPrediction`

~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/OnnxModelScorer.cs#L59-L62

## Use pre-trained ONNX model

ML.NET supports scoring, or making predictions, with pre-trained ONNX models. The [ONNX Model Zoo](https://github.com/onnx/models) hosts several pre-trained models for tasks such as image classification, object detection, machine translation, and speech processing.

Since this sample is meant to detect objects, the model used is Tiny YOLOv2. 

### About the model

Tiny YOLOv2 is a smaller version of the YOLOv2 model, a real-time object detection system trained on the Pascal VOC dataset. For more details on YOLOv2, see the paper [*YOLO9000: Better, Faster, Stronger (Redmon,Farhadi 2016)*](https://arxiv.org/pdf/1612.08242.pdf).  

Tiny YOLOv2 can detect 20 different classes of objects.

### Inspecting the model

1. Open the Tiny


Using line numbers: 

[!code-csharp [](~/machinelearning-samples/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/OnnxModelScorer.cs#L59-L62)]

Using code comment snippets:

[!code-csharp [](~/machinelearning-samples/blob/fbb1e81629936c089535568d668137ef138acc95/samples/csharp/getting-started/DeepLearning_ObjectDetection_Onnx/ObjectDetectionConsoleApp/DataStructures/ImageNetData.cs#ImageNetDataUsings)]

## Detect objects
