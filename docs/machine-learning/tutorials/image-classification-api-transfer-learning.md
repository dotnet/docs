---
title: 'Tutorial: Automated visual inspection using transfer learning'
description: This tutorial illustrates how to use transfer learning to train a TensorFlow deep learning model in ML.NET using the image detection API to classify images.
author: luisquintanilla
ms.author: luquinta
ms.date: 09/26/2019
ms.topic: tutorial
ms.custom: mvc
#Customer intent: As a developer, I want to use ML.NET so that I can use transfer learning in an image classification scenario to classify images using a pretrained TensorFlow model and ML.NET's Image Classification API.
---

# Tutorial: Automated visual inspection using transfer learning with ML.NET's Image Classification API

Learn to train a custom deep learning model using transfer learning and ML.NET's Image Classification API to classify images.

In this tutorial, you learn how to:
> [!div class="checklist"]
>
> - Understand the problem
> - Learn about ML.NET Image Classification API
> - Understand the pretrained model
> - Use transfer learning to train a custom image classification model
> - Classify images with the custom model

## Image Classification Transfer Learning Sample Overview

This sample is a .NET Core console application that classifies images using a pretrained deep learning TensorFlow model. The code for this sample can be found ont he [dotnet/machinelearning-samples repository](https://github.com/dotnet/machinelearning-samples) on GitHub.

## Understand the problem

Image classification is a computer vision problem. Image classification takes an image as input and categorizes into a prescribed label. Some scenarios where image classification is useful include:

- Facial Recognition
- Emotion detection
- Medical diagnosis
- Landmark detection

## ML.NET Image Classification API

ML.NET provides various ways of performing image classification. This tutorial focuses on the Image Classification API. The API makes use of TensorFlow.NET, a low-level library that provides C# bindings for the TensorFlow C++ API.

![](./media/image-classification-api-transfer-learning/architecture.png)

### What is transfer learning?

Training a deep learning model from scratch requires setting several parameters, a large amount of labeled training data and a vast amount of compute resources (hundreds of GPU hours). Using a pre-trained model allows you to shortcut the training process. 

### Training process

The Image Classification API starts initializes the training process by loading a pre-trained image classification model. the training process consists of two steps:

1. Bottleneck phase
2. Training phase

![](./media/image-classification-api-transfer-learning/training.png)

#### Bottleneck Phase

During the bottleneck step, the set of training images is loaded and transformed into a format expected by the model. These transformations include resizing the image and extracting the pixels into a tensor. A tensor can be thought of as a container that stores data in N-dimensions. Once pre-processed, the data is used as input for the frozen layers of the model. The frozen layers include all of the layers in the neural network, except the penultimate (bottleneck) layer. These layers are referred to as frozen because no training will occur on these layers. The larger the number of layers, the more computationally intensive this step is. Fortunately though, since this is a straight-through one-time calculation, the results can be cached and used in later runs when experimenting with different parameters.   

#### Training phase

Once the image is featurized and the values from the frozen layers are computed, they are used as input to retrain the bottleneck layer. This process is iterative and runs for the number of times specified. During each run, the loss and accuracy are evaluated and the appropriate adjustments are made to improve the model with the goal of minimizing the loss and maximizing the accuracy. Once training is finished, two models are output. One of them is the `.pb` version of the model and the other is the `.zip` ML.NET serialized version of the model. When working in environemnts supported by ML.NET, it is preferrable to use the `.zip` version of the model is recommended. However, in scenarios where ML.NET is not supported such as ARM, you have the option of using the `.pb` version.

## Understand the pretrained model

The pretrained model used in this sample is the 101-layer variant of the Residual Network (ResNet) v2. The original model takes a tensor input image of 224 x 224 and outputs the class probabilities for each of the classes it was trained on.

## Set up .NET Core Project

### Create console application

### Prepare your data

### Create classes and define paths

### Initialize variables

## Train the model

### Define the pipeline

### Evaluate the model

## Use the model

## Improve the model

If you're not satisfied with the results of your model, you can try to improve its performance by trying some of the following approaches:

- **More Data**
- **Augment the data**
- **Train for a longer time**
- **Experiment with the hyper-parameters**
- **Use a different model architecture**

