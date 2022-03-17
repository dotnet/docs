---
title: 'Tutorial: ML.NET prediction to categorize images from Custom Vision ONNX model'
description: Learn how to categorize images using an ONNX model from the Custom Vision service in ML.NET. 
ms.date: 03/20/2022
ms.topic: tutorial
ms.custom: mvc, title-hack-0612
recommendations: false
#Customer intent: As a developer, I want to use ML.NET to categorize images using an ONNX model trained in the Custom Vision service.
---
# Tutorial: Categorize an image in ML.NET from Custom Vision ONNX model

Learn how to use ML.NET to categorize images using an ONNX model trained in the Microsoft Custom Vision service.

The Microsoft Custom Vision service is an AI service that allows you to upload your own images and it will train a model for you. You can then export the model to ONNX format and use it in ML.NET to make predictions.

In this tutorial, you will learn how to:
> [!div class="checklist"]
>
> * Understand the problem
> * Use the Custom Vision service to create an ONNX model
> * Incorporate the ONNX model into the ML.NET pipeline
> * Train and evaluate the ML.NET model
> * Classify a test image

## Prerequisites

* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/).

## Select the right machine learning task

### Data

The images we will upload to the Custom Vision service is a set of images of flowers. The data can be found on [Kaggle](https://www.kaggle.com/alxmamaev/flowers-recognition). The data consists of five folders indicating what flower the images inside the folder indicate, such as rose, tulip, and sunflower.

## Create the Model

Log into the [Microsoft Custom Vision service](https://www.customvision.ai/) and select "New Project".

In the "New Project" dialog, fill out the following required items:

- Name: The name of the Custom Vision project
- Resource: This is the Azure resource that will be created for the Custom Vision project. If none is listed, one can be created by selecting the "Create" link.
- Project Type: Select "Classification"
- Classification Types: Select "Multiclass" since there will be one class per image.
- Domains: Select "General (compact)". The compact domain will allow you to download the ONNX model.
- Export capabilities: Select "Basic platforms" to allow the export of the ONNX model.

Once the above fields are filed out click the "Create project" button.

