---
title: How to install GPU support in Model Builder
description: Learn how to install GPU support in Model Builder
ms.date: 09/02/2021
author: luisquintanilla
ms.author: luquinta
ms.topic: how-to
#Customer intent: As a developer, I want to learn how to install GPU support for Model Builder
---

# How to install GPU support in Model Builder

Learn how to install the GPU drivers to use your GPU with Model Builder.

## Prerequisites

- Model Builder Visual Studio extension. The extension is built into Visual Studio as of version 16.6.1.
- [Model Builder Visual Studio GPU support extension](https://marketplace.visualstudio.com/items?itemName=MLNET.ModelBuilderGPU).
- At least one CUDA compatible GPU. For a list of compatible GPUs, see [NVIDIA's guide](https://developer.nvidia.com/cuda-gpus).
- NVIDIA developer account. If you don't have one, [create a free account](https://developer.nvidia.com/developer-program).
- Make sure the appropriate [driver](https://www.nvidia.com/drivers) is installed for the GPU.

## Install dependencies

1. Install [CUDA v10.1](https://developer.nvidia.com/cuda-10.1-download-archive-update2). Make sure you install CUDA v10.1, not any other newer version.  
1. Install [cuDNN v7.6.4 for CUDA 10.1](https://developer.nvidia.com/rdp/cudnn-download). You cannot have multiple versions of cuDNN installed. After downloading cuDNN v7.6.4 zip file and unpacking it, copy `<CUDNN_zip_files_path>\cuda\bin\cudnn64_7.dll` to `<YOUR_DRIVE>\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.1\bin`.

## Troubleshooting

**How do I know what GPU I have?**

Follow instructions provided:

1. Right-click on desktop
1. If you see "NVIDIA Control Panel" or "NVIDIA Display" in the pop-up window, you have an NVIDIA GPU
1. Click on "NVIDIA Control Panel" or "NVIDIA Display" in the pop-up window
1. Look at "Graphics Card Information"
1. You will see the name of your NVIDIA GPU

**I don't see NVIDIA Control Panel (or it fails to open) but I know I have an NVIDIA GPU.**

1. Open Device Manager
1. Look at Display adapters
1. Install appropriate [driver](https://www.nvidia.com/drivers) for your GPU.

**How do I see what version of CUDA I have?**

1. Open a PowerShell or command line window
1. Type in `nvcc --version`
