---
title: How to install GPU support in Model Builder
description: Learn how to install GPU support in Model Builder
ms.date: 12/08/2022
author: luisquintanilla
ms.author: luquinta
ms.topic: how-to
#Customer intent: As a developer, I want to learn how to install GPU support for Model Builder
---

# How to install GPU support in Model Builder

Learn how to install the GPU drivers to use your GPU with Model Builder.

## Hardware requirements

- At least one CUDA compatible GPU. For a list of compatible GPUs, see [NVIDIA's guide](https://developer.nvidia.com/cuda-gpus).
- At least 6GB of dedicated GPU memory.

## Prerequisites

- [Model Builder Visual Studio extension](install-model-builder.md). The extension is built into Visual Studio as of version 16.6.1.
- Make sure the appropriate [driver](https://www.nvidia.com/drivers) is installed for the GPU.

### Image classification only

- [Model Builder Visual Studio GPU support extension](https://marketplace.visualstudio.com/items?itemName=MLNET.ModelBuilderGPU2022)
- NVIDIA developer account. If you don't have one, [create a free account](https://developer.nvidia.com/developer-program).
- Install dependencies
  - Install [CUDA v10.1](https://developer.nvidia.com/cuda-10.1-download-archive-update2). Make sure you install CUDA v10.1, not any other newer version.
  - Install [cuDNN v7.6.4 for CUDA 10.1](https://developer.nvidia.com/rdp/cudnn-download). You cannot have multiple versions of cuDNN installed. After downloading cuDNN v7.6.4 zip file and unpacking it, copy `<CUDNN_zip_files_path>\cuda\bin\cudnn64_7.dll` to `<YOUR_DRIVE>\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.1\bin`.

## Troubleshooting

**What if I don't have a GPU installed locally?**

Deep learning scenarios tend to run faster on GPUs.

Some scenarios like image classification support training on Azure GPU VMs.

However, if local GPUs or Azure are not an option for you, these scenarios also run on CPU. Note however that training times are significantly longer.  

**How do I know what GPU I have?**

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

**cuda is not available, please confirm you have a cuda-supported gpu**

1. Open the [GeForce Experience](https://www.nvidia.com/en-us/geforce/geforce-experience/) app.
1. The application should show installed and available driver updates. If you have trouble seeing updates, you can get the latest drivers from [https://www.nvidia.com/geforce/drivers/](https://www.nvidia.com/Download/index.aspx).
1. Install the latest drivers.
