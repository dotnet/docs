---
title: How to use GPU in Model Builder
description: Learn how to install and enable GPU with Model Builder
ms.date: 07/17/2020
author: luisquintanilla
ms.author: luquinta
ms.custom: how-to
---

# How to use GPU in Model Builder

Learn how to install dependencies 

## Prerequisites

- Model Builder Visual Studio extension
- Model Builder Visual Studio GPU extension
- At least one CUDA compatible GPU. For a list of compatible GPUs see [Nvidia's guide](https://developer.nvidia.com/cuda-gpus).
- NVIDIA developer account. If you don't have one, [create a free account](https://developer.nvidia.com/developer-program).

## Install dependencies

1. Install [CUDA v10.0](https://developer.nvidia.com/cuda-10.0-download-archive). Make sure you install CUDA v10.0, not any other newer version. You cannot have multiple versions of CUDA installed.
1. Install [cuDNN v7.6.4 for CUDA 10.0](https://developer.nvidia.com/rdp/cudnn-download). You cannot have multiple versions of cuDNN installed.
1. After downloading cuDNN v7.6.4 .zip file and unpacking it, you need to do the following steps:

    Copy `<CUDNN_zip_files_path>\cuda\bin\cudnn64_7.dll` to `<YOUR_DRIVE>\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v10.0\bin`.

## Troubleshooting

How do I know what GPU I have?

Follow instructions provided by NVIDIA:

1. Right-click on desktop
1. If you see "NVIDIA Control Panel" or "NVIDIA Display" in the pop-up window, you have an NVIDIA GPU
1. Click on "NVIDIA Control Panel" or "NVIDIA Display" in the pop-up window
1. Look at "Graphics Card Information"
1. You will see the name of your NVIDIA GPU

I don't see NVIDIA Control Panel (or it fails to open) but I know I have an NVIDIA GPU.

1. Open Device Manager
1. Look at Display adapters
1. Install appropriate [driver](https://www.nvidia.com/drivers) for your GPU.
