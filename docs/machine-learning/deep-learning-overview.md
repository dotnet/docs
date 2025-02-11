---
title: Deep Learning overview
description: Learn what deep learning is and components in ML.NET
ms.date: 11/10/2022
ms.topic: overview
ms.custom: mvc
---

# What is deep learning?

Deep learning is an umbrella term for machine-learning techniques that make use of "deep" neural networks. Today, deep learning is one of the most visible areas of machine learning because of its success in areas like computer vision, natural language processing, and&mdash;when applied to reinforcement learning&mdash;scenarios like game playing, decision making, and simulation.

A crucial element to the success of deep learning has been the availability of data, compute, software frameworks, and runtimes that facilitate the creation of neural network models and their execution for inference. Examples of such frameworks include TensorFlow, (Py)Torch, and ONNX.

ML.NET provides access to some of these frameworks. As a result, ML.NET users can take advantage of deep learning models without having to start from scratch.

## Deep learning vs machine learning

Deep learning relies on neural network algorithms. This is in contrast with traditional or classical machine learning techniques, which use a wider variety of algorithms such as generalized linear models, decision trees, or Support Vector Machines (SVM). The most immediate, practical implication of this difference is that deep learning methods can be better suited for some kinds of data. In some cases, classical machine learning techniques such as gradient-boosted trees (XGBoost, LightGBM and CatBoost) seem to have an edge for tabular data. For less structured data like text and images, neural networks tend to perform better. The best approach is always to experiment with your particular data source and use case to determine for yourself which techniques work best for your problem.

For classical machine learning tasks, ML.NET simplifies this experimentation process through Automated Machine Learning (AutoML). For more information on AutoML, see [What is Automated Machine Learning (AutoML)?](automated-machine-learning-mlnet.md).

## Neural network architectures

One of the main differentiating characteristics of deep learning is the use of artificial neural network algorithms. At a high-level, you can think of neural networks as a configuration of "processing units" where the output of each unit constitutes the input of another. Each of these units can take one or many inputs, and essentially carries out a weighted sum of its inputs, applies an offset (or "bias") followed by a non-linear transformation function (called "activation"). Different arrangements of these components have been used to describe decision boundaries in classification, regression functions, and other structures central to machine learning tasks.

:::image type="content" source="media/single-layer-neural-net.png" alt-text="Diagram representing single layer in neural network" lightbox="media/single-layer-neural-net.png":::

The past decade has seen an increase in cases, applications, and techniques of deep learning. This increase is driven in part by an increasing variety of operations that can be incorporated into neural networks, a richer set of arrangements that these operations can be configured in, and improved computational support for these improvements. In general, neural network architectures can be grouped into the following categories:

* Feed-forward neural network
* Convolutional neural network
* Recurrent neural network
* Generative adversarial network
* Transformers

For more details, see the [artificial neural networks guide](/azure/machine-learning/concept-deep-learning-vs-machine-learning).

## What can I use deep learning for?

Deep learning architectures have shown good performance in tasks involving unstructured data, such as images, audio, and free-form text. As a result, deep learning has been used to solve problems like:

* Image classification
* Audio classification
* Translation
* Text generation
* Text classification

## Deep learning in ML.NET

Training a deep learning model from scratch requires setting several parameters, a large amount of labeled training data, and a vast amount of compute resources (hundreds of GPU hours). ML.NET enables you to shortcut this process by using pretrained models and knowledge transfer techniques such as transfer learning and fine-tuning.

ML.NET also enables you to import models trained in other frameworks and consume them within your .NET applications.

Depending on the scenario, you can use local GPU as well as Azure GPU compute resources to train and consume deep learning models.

### Train custom models

ML.NET provides APIs to train custom deep learning models and use them to make predictions inside your .NET application.

These APIs are powered by [TorchSharp](https://github.com/dotnet/TorchSharp) and [TensorFlow.NET](https://github.com/SciSharp/TensorFlow.NET).

#### Image classification

In ML.NET you can use the <xref:Microsoft.ML.VisionCatalog.ImageClassification*> set of APIs to train custom image classification models.

An image classification training pipeline in ML.NET might look like the following:

```csharp
//Append ImageClassification trainer to the pipeline containing any preprocessing transforms.
pipeline
    .Append(mlContext.MulticlassClassification.Trainers.ImageClassification(featureColumnName: "Image")
    .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel");

// Train the model.
var model = pipeline.Fit(trainingData);

// Use the model for inferencing.
var predictedData = model.Transform(newData).GetColumn<string>("PredictedLabel");
```

To get started training custom image classification models in ML.NET, see [Train an image classification model in Azure using Model Builder](tutorials/image-classification-model-builder.md).

#### Object detection

ML.NET enables you to train custom object detection models in Model Builder using Azure Machine Learning. All you need is a labeled dataset containing bounding box information and the categories the objects in the bounding boxes belong to.

The result of the training process is an ONNX model which can then be used with the <xref:Microsoft.ML.OnnxCatalog.ApplyOnnxModel*> transform for to make predictions.

At this time, there is no local support for object detection in ML.NET.

To train custom object detection models with ML.NET, see [Detect stop signs in images with Model Builder tutorial](tutorials/object-detection-model-builder.md).

#### Text classification

Classifying free-form text, whether that's customer reviews or business memos is an important part of many processes.

In ML.NET, you can use the <xref:Microsoft.ML.TorchSharp.NasBert.TextClassificationTrainer> set of APIs to train custom text classification models. The technique used to train custom text classification models in ML.NET is known as fine-tuning. Fine-tuning enables you to take a pretrained model and retrain the layers specific to your domain or problem using your own data. This gives you the benefit of having a model that's more tailored to solve your problem without having to go through the process of training the entire model from scratch. The pretrained model used by the Text Classification API is a TorchSharp implementation of [NAS-BERT](https://dl.acm.org/doi/abs/10.1145/3447548.3467262).

A text classification training pipeline in ML.NET might look like the following:

```csharp
// Define training pipeline using TextClassification trainer
var pipeline =
    mlContext.Transforms.Conversion.MapValueToKey("Label","Sentiment")
        .Append(mlContext.MulticlassClassification.Trainers.TextClassification(sentence1ColumnName: "Text"))
        .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

// Train the model
var model = pipeline.Fit(trainingData);

// Use your model to make predictions
var predictedData = model.Transform(newData).GetColumn<string>("PredictedLabel");
```

To get started training text classification models with ML.NET, see the [Analyze sentiment of website comments in a web application using ML.NET Model Builder](tutorials/sentiment-analysis-model-builder.md) tutorial.

#### Sentence similarity

Tasks such as semantic search rely on the determination of how similar two sentences or passages of text are to each other.

ML.NET provides the <xref:Microsoft.ML.TorchSharp.NasBert.SentenceSimilarityTrainer> set of APIs that use the same underlying model and fine-tuning techniques as the <xref:Microsoft.ML.TorchSharp.NasBert.TextClassificationTrainer>. However, instead of producing a category as output, it produces a numerical value representing how similar two passages are.

A training and inference pipeline for sentence similarity in ML.NET might look like the following:

```csharp
// Define the pipeline.
var pipeline = mlContext.Regression.Trainers.SentenceSimilarity(sentence1ColumnName: "Sentence", sentence2ColumnName: "Sentence2");

// Train the model
var model = pipeline.Fit(trainingData);

// Use the model to make predictions and extract their similarity values.
var score = model.Transform(newData).GetColumn<float>("Score");
```

To get started with sentence similarity, see the samples in the [dotnet/machinelearning-samples repo](https://github.com/dotnet/machinelearning-samples/tree/main/samples/csharp/getting-started/MLNET2).

### Consume pretrained models

ML.NET provides APIs to consume models in other formats like TensorFlow and ONNX and use them to make predictions inside your .NET application.

These APIs are powered by [TensorFlow.NET](https://github.com/SciSharp/TensorFlow.NET) and the [ONNX Runtime](https://onnxruntime.ai/).

#### TensorFlow

[TensorFlow](https://www.tensorflow.org/) is a deep learning framework with a rich ecosystem and a variety of pretrained models available in the [TensorFlow Hub](https://www.tensorflow.org/hub).

With ML.NET, you can take these pretrained TensorFlow models and use them for inferencing inside your .NET applications.

An inference pipeline using a pretrained TensorFlow model might look like the following:

```csharp
// Load TensorFlow model
TensorFlowModel tensorFlowModel = mlContext.Model.LoadTensorFlowModel(_modelPath);

//Append ScoreTensorFlowModel transform to your pipeline containing any preprocessing transforms
pipeline.Append(tensorFlowModel.ScoreTensorFlowModel(outputColumnName: "Prediction/Softmax", inputColumnName:"Features"))

// Create ML.NET model from pipeline
ITransformer model = pipeline.Fit(dataView);

var predictions = model.Transform(dataView).GetColumn<float>("Prediction/Softmax");
```

To get started consuming pretrained TensorFlow models with ML.NET, see the [Movie reviews sentiment analysis using a pretrained TensorFlow model in ML.NET](tutorials/text-classification-tf.md) tutorial.

#### ONNX

The [Open Neural Network Exchange (ONNX)](https://onnx.ai/) is an open-source format designed to enable interoperability between machine-learning and deep-learning frameworks. This means you can train a model in one of the many popular machine-learning frameworks like PyTorch, convert it into ONNX format, and consume the ONNX model in a different framework like ML.NET.

The [ONNX model repository](https://github.com/onnx/models) hosts several pretrained ONNX models you can use for inferencing in a wide variety of tasks.

With ML.NET, you can take these pretrained ONNX models and use them for inferencing inside your .NET applications.

An inference pipeline using a pretrained ONNX model might look like the following:

```csharp
// Append ApplyOnnxModel transform to pipeline containing any preprocessing transforms
pipeline.Append((modelFile: modelLocation, outputColumnNames: new[] { TinyYoloModelSettings.ModelOutput }, inputColumnNames: new[] { TinyYoloModelSettings.ModelInput })

// Create ML.NET model from pipeline
var model = pipeline.Fit(data);

// Use the model to make predictions
var predictions = pipeline.Fit(data).GetColumn<float[]>(TinyYoloModelSettings.ModelOutput);
```

To get started consuming pretrained ONNX models with ML.NET, see the [Object detection using ONNX in ML.NET](tutorials/object-detection-onnx.md) tutorial.
