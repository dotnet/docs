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
    
- Name: A name for your workspace between 3-33 characters. Names may only contain alphanumeric characters and hyphens. 
- Region: The geographic location of the datacenter where your workspace and resources are deployed to. It is recommended that you choose a location close to where you or your customers are. 
- Resource group: A container that contains all related resources for an Azure solution.

## What is an Azure Machine Learning compute?

An Azure Machine Learning compute is a cloud-based GPU optimized Linux VM used for training. 

To create an Azure Machine Learning workspace, the following are required:

- Name: A name for your workspace between 2-16 characters. Names may only contain alphanumeric characters and hyphens.
- Compute size

    Model Builder provides the following compute types:
    
    | Size | vCPU | Memory: GiB | Temp storage (SSD) GiB | GPU | GPU memory: GiB | Max data disks | Max NICs |
    |---|---|---|---|---|---|---|---|
    | Standard_NC12   | 12 | 112 | 680  | 2 | 24 | 48 | 2 |
    | Standard_NC24   | 24 | 224 | 1440 | 4 | 48 | 64 | 4 |

    Visit the [NC-series Linux VM documentation](https://docs.microsoft.com/azure/virtual-machines/nc-series?toc=/azure/virtual-machines/linux/toc.json&bc=/azure/virtual-machines/linux/breadcrumb/toc.json) for more details on GPU optimized compute types.

## What is an experiment?

An experiment is the collection of runs for a specific training job. Experiments belong to a specific workspace. The first time an experiment is created, it's name is registered in the workspace. Any subsequent runs, if the same name is used, those runs are logged as part of the same experiment. Otherwise, a new experiment is created.

## Training
