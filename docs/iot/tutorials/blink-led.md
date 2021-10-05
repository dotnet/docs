---
title: Blink an LED
description: Learn how to blink an LED with the .NET IoT Libraries.
author: camsoper
ms.author: casoper
ms.date: 10/06/2021
ms.topic: tutorial
ms.prod: dotnet
recommendations: false
---

# Blink an LED

General-purpose I/O (GPIO) pins can be controlled individually. This is useful for controlling LEDs, relays, and other stateful devices. In this topic, you will use .NET and your Raspberry Pi's GPIO pins to power an LED and blink it repeatedly.

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- 5 mm LED
- 330 Ω resistor
- Breadboard
- Jumper wires
- Raspberry Pi GPIO breakout board (optional/recommended)
- [!INCLUDE [tutorial-prereq-dotnet](../includes/tutorial-prereq-dotnet.md)]

[!INCLUDE [ensure-ssh](../includes/ensure-ssh.md)]

## Prepare the hardware

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="../media/rpi-led_bb-thumb.png" alt-text="A Fritzing diagram showing a circuit with an LED and a resistor" lightbox="../media/rpi-led_bb.png":::

The image above depicts the following connections:

- GPIO 18 to LED anode (longer, positive lead)
- LED cathode (shorter, negative lead) to 330 Ω resistor (either end)
- 330 Ω resistor (other end) to ground

[!INCLUDE [tutorial-rpi-gpio](../includes/tutorial-rpi-gpio.md)]

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

## Create the app

Complete the following steps in your preferred development environment:

1. Create a new .NET Console App using either the [.NET CLI](../../core/tools/dotnet-new.md) or [Visual Studio](../../core/tutorials/with-visual-studio.md). Name it *BlinkTutorial*.

    ```dotnetcli
    dotnet new console -o BlinkTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    :::code language="csharp" source="~/iot-samples/tutorials/BlinkTutorial/Program.cs" :::

    In the preceding code:

    - A [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations) creates an instance of `GpioController`. The `using` declaration ensures the object is disposed and hardware resources are released properly.
    - GPIO pin 18 is opened for output
    - A `while` loop runs indefinitely. Each iteration:
        1. Writes a value to GPIO pin 18. If `ledOn` is true, it writes `PinValue.High` (on). Otherwise, it writes `PinValue.Low`.
        1. Sleeps 1000 ms.
        1. Toggles the value of `ledOn`.

1. [!INCLUDE [tutorial-build](../includes/tutorial-build.md)]
1. [!INCLUDE [tutorial-deploy](../includes/tutorial-deploy.md)]
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./BlinkTutorial
    ```

    The LED blinks off and on every second.

1. Terminate the program by pressing <kbd>Ctrl+C</kbd>.

Congratulations! You've used GPIO to blink an LED.

## Get the source code

The source for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/master/tutorials/BlinkTutorial).

## Next steps

> [!div class="nextstepaction"]
> [Learn how to read environmental conditions from a sensor](../tutorials/temp-sensor.md)
