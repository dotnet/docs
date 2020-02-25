---
title: Model Builder Azure Training Resources
description: A guide of resources for Azure Machine Learning
ms.topic: reference
ms.date: 02/25/2020
---

# Model Builder Azure Training Resources

The following is a guide to help you learn more about resources used to train models in Azure with Model Builder.

## What is an Azure Machine Learning workspace?

A workspace is an Azure Machine Learning resource that provides a central place for all Azure Machine Learning resources and artifacts created as part of training job. 

To create an Azure Machine Learning workspace, the following are required:

    

## What is an Azure Machine Learning compute?

An Azure Machine Learning compute is a cloud-based GPU optimized Linux VM used for training. Model Builder provides the following compute types:

| Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | GPU | GPU memory: GiB | Max data disks | Max NICs |
|---|---|---|---|---|---|---|---|
| Standard_NC12   | 12 | 112 | 680  | 2 | 24 | 48 | 2 |
| Standard_NC24   | 24 | 224 | 1440 | 4 | 48 | 64 | 4 |

When creating a compute, the following restrictions apply:

    - No special characters, including hyphens.

## What is an experiment?

An experiment is the collection of runs for a specific training job. An experiment requires

## Training

## Model

