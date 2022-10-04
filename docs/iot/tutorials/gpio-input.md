---
title: Use GPIO for binary input
description: Learn how to use GPIO for binary input with the .NET IoT Libraries.
author: camsoper
ms.author: casoper
ms.date: 10/04/2022
ms.topic: tutorial
ms.prod: dotnet
recommendations: false
---

# Use GPIO for binary input

General-purpose I/O (GPIO) pins can be configured to receive electrical signals as input. At its most basic level, this is useful for scenarios that detect the opening/closing of a circuit. Such circuits might include push buttons, toggle switches, reed switches, pressure switches, and other devices that represent binary (on/off) values by completing a circuit.

In this tutorial, you'll use .NET and your Raspberry Pi's GPIO pins to detect the opening and closing of a circuit.

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- Jumper wires
- Breadboard (optional)
- Raspberry Pi GPIO breakout board (optional)
- [!INCLUDE [tutorial-prereq-dotnet](../includes/tutorial-prereq-dotnet.md)]

[!INCLUDE [ensure-ssh](../includes/ensure-ssh.md)]

## Prepare the hardware

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="https://via.placeholder.com/200" alt-text="A Fritzing diagram showing a circuit that connects a ground pin to pin 21." lightbox="https://via.placeholder.com/500":::

The image above depicts a direct connection between a ground pin and pin 21.

> [!NOTE]
> The diagram uses a breadboard and GPIO breakout for illustrative purposes, but feel free to just jumper a ground pin and pin 21. Use the diagram below if needed.

[!INCLUDE [tutorial-rpi-gpio](../includes/tutorial-rpi-gpio.md)]

## Create the app

Complete the following steps in your preferred development environment:

1. Create a new .NET Console App using either the [.NET CLI](../../core/tools/dotnet-new.md) or [Visual Studio](../../core/tutorials/with-visual-studio.md). Name it *InputTutorial*.

    ```dotnetcli
    dotnet new console -o InputTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    :::code language="csharp" source="~/iot-samples/tutorials/InputTutorial/Program.cs" :::

    In the preceding code:

    - A [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations) creates an instance of `GpioController`. The `using` declaration ensures the object is disposed and hardware resources are released properly.
    - GPIO pin 21 is opened in mode `InputPullUp`.
    - **TODO**

1. [!INCLUDE [tutorial-build](../includes/tutorial-build.md)]
1. [!INCLUDE [tutorial-deploy](../includes/tutorial-deploy.md)]
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./InputTutorial
    ```

1. **TODO**

1. Terminate the program by pressing <kbd>Ctrl</kbd>+<kbd>C</kbd>.

Congratulations! You've **TODO**

## Other applications

There are many uses for this type of input. Some examples are described below.

### Reed switch/contact sensor

**TODO**

### Laser tripwire

**TODO**

## Get the source code

The source for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/main/tutorials/InputTutorial).

## Next steps

> [!div class="nextstepaction"]
> [Learn how to read environmental conditions from a sensor](../tutorials/temp-sensor.md)
