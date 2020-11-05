---
title: GPIO - Blink an LED
description: Learn how .NET can be used to build applications for IoT devices and scenarios.
author: camsoper
ms.author: casoper
ms.date: 11/2/2020
ms.topic: overview
ms.prod: dotnet
---

# GPIO - Blink an LED

GPIO pins can be controlled individually. This is useful for controlling LEDs, relays, and other stateful devices. 

In this topic, you will use .NET to power an LED and blink it repeatedly.

## Prerequisites

- Raspberry Pi (2 or greater) with [Raspberry Pi OS installed](https://www.raspberrypi.org/documentation/installation/installing-images/README.md)
- 5 mm LED
- 330 Ω resistor
- Breadboard
- Jumper wires
- Raspberry Pi GPIO breakout board (optional/recommended)
- [.NET SDK](https://dotnet.microsoft.com/download) version .NET Core 3.1 or later

[!INCLUDE [ensure-ssh](../includes/ensure-ssh.md)]

## Prepare the hardware

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="../media/rpi-led_bb-thumb.png" alt-text="A Fritzing diagram showing a circuit with an LED and a resistor" lightbox="../media/rpi-led_bb.png":::

The following are the connections depicted above:

<!--markdownlint-disable MD033 -->
- GPIO 18 to LED anode (longer, positive lead)
- LED cathode (shorter, negative lead) to 330 Ω resistor (either end)
- 330 Ω resistor (other end) to ground

Refer to the following pinout diagram as needed:

:::image type="content" source="../media/gpio-pinout-diagram-thumb.png" alt-text="A diagram showing the pinout of the Raspberry Pi GPIO header. Image courtesy Raspberry Pi Foundation." lightbox="../media/gpio-pinout-diagram.png":::
[Image courtesy Raspberry Pi Foundation](https://www.raspberrypi.org/documentation/usage/gpio/).

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

Once all the connections are made, power on the Raspberry Pi.

## Create the app

Complete the following steps on your development computer:

1. Create a new .NET Console App using either the [.NET CLI](/dotnet/core/tools/dotnet-new) or [Visual Studio](/dotnet/core/tutorials/with-visual-studio). Name it *BlinkTutorial*.

    ```dotnetcli
    dotnet new console -o BlinkTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    ```csharp
    using System;
    using System.Device.Gpio;
    using System.Threading;

    int pin = 18;
    bool ledOn = true;
    Console.WriteLine("Blinking LED. Press Ctrl+C to end.");

    using GpioController controller = new GpioController();
    controller.OpenPin(pin, PinMode.Output);
    while (true)
    {
        controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
        Thread.Sleep(1000);
        ledOn = !ledOn;
    }
    ```

    In the preceding code:

    - A [using declaration](/dotnet/csharp/whats-new/csharp-8#using-declarations) creates an instance of `GpioController`. The `using` declaration ensures the object is disposed and hardware resources are released properly.
    - GPIO pin 18 is opened for output
    - A `while` loop runs indefinitely. Each iteration:
        1. Writes a value to GPIO pin 18. If `ledOn` is true, it writes `PinValue.High` (on). Otherwise, it writes `PinValue.Low`.
        1. Sleeps 1000 ms.
        1. Toggles the value of `ledOn`.

1. Build the app by running `dotnet build` if using the .NET CLI. To build in Visual Studio, press <kbd>Ctrl+Shift+B</kbd>.
1. Deploy the app to the Raspberry Pi as a self-contained app. For instructions, see [Deploy .NET apps to Raspberry Pi](../deployment.md#deploying-a-self-contained-app). Make sure to give the executable *execute* permission using `chmod +x`.
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./BlinkTutorial
    ```

    Observe the output as you turn the potentiometer up and down.

1. Terminate the program by pressing <kbd>Ctrl+C</kbd>.

Congratulations! You've used GPIO to blink an LED.
