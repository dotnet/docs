---
title: How to install GPU support in Model Builder
description: Learn how to install GPU support in Model Builder
ms.date: 11/25/2025
author: luisquintanilla
ms.author: luquinta
ms.topic: how-to
#Customer intent: As a developer, I want to learn how to install GPU support for Model Builder
---

# How to install GPU support in Model Builder

Learn how to install the GPU drivers to use your GPU with Model Builder.

## Hardware requirements

- At least one CUDA-compatible GPU. For a list of compatible GPUs, see [NVIDIA's guide](https://developer.nvidia.com/cuda-gpus).
- At least 6 GB of dedicated GPU memory.

## Prerequisites

- [Model Builder Visual Studio extension](install-model-builder.md). The extension is built into Visual Studio as of version 16.6.1.
- Make sure the appropriate [driver](https://www.nvidia.com/drivers) is installed for the GPU.

### Image classification and object detection

- NVIDIA developer account. If you don't have one, [create a free account](https://developer.nvidia.com/developer-program).
- Install dependencies:

  - Install [CUDA **v11.8 or later**](https://developer.nvidia.com/cuda-downloads).

    > [!NOTE]
    > Using older CUDA versions such as 10.1 may cause *"no kernel found"* or similar errors when running object detection models in Model Builder.  
    > CUDA 11.8 or newer provides better compatibility with the TensorFlow GPU runtime used by Model Builder.

  - Install the corresponding **cuDNN** library version for your installed CUDA version from the [cuDNN archive](https://developer.nvidia.com/rdp/cudnn-archive).  
    After downloading and unpacking the cuDNN zip file, copy  
    `\<CUDNN_zip_files_path>\cuda\bin\cudnn64_*.dll`  
    to  
    `\<YOUR_DRIVE>\Program Files\NVIDIA GPU Computing Toolkit\CUDA\v11.x\bin`.

    > [!TIP]
    > You cannot have multiple versions of cuDNN installed simultaneously.  
    > Ensure only one version matching your CUDA installation is present in your system path.

---

## Troubleshooting

**What if I don't have a GPU installed locally?**

Deep learning scenarios tend to run faster on GPUs.  
Some scenarios, such as image classification, support training on **Azure GPU VMs**.  
However, if local GPUs or Azure are not an option, these scenarios can still run on CPU — though training times are significantly longer.

---

**How do I know what GPU I have?**

***Check GPU from Settings***

1. Right-click the Windows start menu icon and select **Settings**.
2. Select **System**.
3. Choose **Display**, then scroll to **Related settings**.
4. Select **Advanced display**. Your GPU's make and model appear under **Display information**.

***Check GPU from Task Manager***

1. Right-click the Windows start menu icon and select **Task Manager**.
2. Go to the **Performance** tab.
3. In the last pane, select **GPU** (usually at the bottom).
4. The top-right corner displays information about your GPU.

---

**I don't see my GPU in Settings or Task Manager, but I know I have an NVIDIA GPU.**

1. Open **Device Manager**.
2. Expand **Display adapters**.
3. Install the appropriate [driver](https://www.nvidia.com/drivers) for your GPU.

---

**How do I see what version of CUDA I have?**

1. Open a PowerShell or Command Prompt window.
2. Run the command:

   ```bash
   nvcc --version
