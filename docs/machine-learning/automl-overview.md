---
title: Automated machine learning with ML.NET
description: Overview of automatic model selection and training
author: natke
ms.date: 05/01/2019
ms.topic: overview
ms.custom: mvc
ms.author: nakersha
author: natke
#Customer intent: As a developer, I want to use ML.NET CLI to automatically select and train a model. 
---
# Automated machine learning with ML.NET

Automated machine learning is a feature of ML.NET that performs automatic model selection and training. You specify the machine learning task and supply a dataset, and automated ML chooses the model with the best metrics. It outputs:
- a model file that can be loaded into your prediction application
- application code to make predictions
- the source code used for feature selection and model training (to understand the model)

> [!NOTE]
> This feature is currently in Preview, and material may be subject to change. 

Automated ML is currently limited to the machine learning [tasks](resources/tasks.md) of binary classification, multiclass classification, and regression. The other machine learning tasks will be supported in future releases.

There are three ways to use automated ML:
1. With a graphical user interface, with the [ML.NET Model Builder](automate-training-with-model-builder.md)
1. On the command line, with the [ML.NET CLI](automate-training-with-cli.md)
1. Via an application, with the [automated ML API](how-to-guides/how-to-use-the-automl-api.md)
