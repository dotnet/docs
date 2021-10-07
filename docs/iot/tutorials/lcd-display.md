---
title: Display text on an LCD
description: Learn how to display characters on a liquid crystal display with the .NET IoT Libraries.
author: camsoper
ms.author: casoper
ms.date: 10/06/2021
ms.topic: tutorial
ms.prod: dotnet
recommendations: false
---
<!--markdownlint-disable DOCSMD011 -->
# Display text on an LCD

LCD character displays are useful for displaying information without the need for an external monitor. Common LCD character displays can be connected directly to the GPIO pins, but such an approach requires the use of up to 10 GPIO pins. For scenarios that require connecting to a combination of devices, devoting so much of the GPIO header to a character display is often impractical.

Many manufacturers sell 20x4 LCD character displays with an integrated GPIO expander. The character display connects directly to the GPIO expander, which then connects to the Raspberry Pi via the Inter-Integrated Circuit (I2C) serial protocol.

In this topic, you will use .NET to display text on an LCD character display using an I2C GPIO expander.

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- [20x4 LCD Character Display with I2C interface](https://www.bing.com/images/search?q=20x4+lcd+display+with+i2c)
- Jumper wires
- Breadboard (optional/recommended)
- Raspberry Pi GPIO breakout board (optional/recommended)
- [!INCLUDE [tutorial-prereq-dotnet](../includes/tutorial-prereq-dotnet.md)]

> [!NOTE]
> There are many manufacturers of LCD character displays. Most designs are identical, and the manufacturer shouldn't make any difference to the functionality. For reference, this tutorial was developed with the [SunFounder LCD2004](https://www.sunfounder.com/lcd2004-module.html).

[!INCLUDE [prepare-pi-i2c](../includes/prepare-pi-i2c.md)]

## Prepare the hardware

Use jumper wires to connect the four pins on the I2C GPIO expander to the Raspberry Pi as follows:

- GND to ground
- VCC to 5V
- SDA to SDA (GPIO 2)
- SCL to SCL (GPIO 3)

Refer to the following figures as needed:

| I2C interface (back of display) | Raspberry Pi GPIO |
|---------------------------------|-------------------|
| :::image type="content" source="../media/character-display-i2c-thumb.png" alt-text="An image of the back of the character display showing the I2C GPIO expander." lightbox="../media/character-display-i2c.png"::: | :::image type="content" source="../media/gpio-pinout-diagram-thumb.png" alt-text="A diagram showing the pinout of the Raspberry Pi GPIO header. Image courtesy Raspberry Pi Foundation." lightbox="../media/gpio-pinout-diagram.png":::<br />[Image courtesy Raspberry Pi Foundation](https://www.raspberrypi.com/documentation/computers/os.html#gpio-and-the-40-pin-header).
 |

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

## Create the app

Complete the following steps in your preferred development environment:

1. Create a new .NET Console App using either the [.NET CLI](../../core/tools/dotnet-new.md) or [Visual Studio](../../core/tutorials/with-visual-studio.md). Name it *LcdTutorial*.

    ```dotnetcli
    dotnet new console -o LcdTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    :::code language="csharp" source="~/iot-samples/tutorials/LcdTutorial/Program.cs" :::

    In the preceding code:

    - A [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations) creates an instance of `I2cDevice` by calling `I2cDevice.Create` and passing in a new `I2cConnectionSettings` with the `busId` and `deviceAddress` parameters. This `I2cDevice` represents the I2C bus. The `using` declaration ensures the object is disposed and hardware resources are released properly.

        > [!WARNING]
        > The device address for the GPIO expander depends on the chip used by the manufacturer. GPIO expanders equipped with a PCF8574 use the address `0x27`, while those using PCF8574A chips use `0x3F`. Consult your LCD's documentation.

    - Another `using` declaration creates an instance of `Pcf8574` and passes the `I2cDevice` into the constructor. This instance represents the GPIO expander.
    - Another `using` declaration creates an instance of `Lcd2004` to represent the display. Several parameters are passed to the constructor describing the settings to use to communicate with the GPIO expander. The GPIO expander is passed as the `controller` parameter.
    - A `while` loop runs indefinitely. Each iteration:
        1. Clears the display.
        1. Sets the cursor position to the first position on the current line.
        1. Writes the current time to the display at the current cursor position.
        1. Iterates the current line counter.
        1. Sleeps 1000 ms.

1. [!INCLUDE [tutorial-build](../includes/tutorial-build.md)]
1. [!INCLUDE [tutorial-deploy](../includes/tutorial-deploy.md)]
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./LcdTutorial
    ```

    Observe the LCD character display as the current time displays on each line.

    > [!TIP]
    > If the display is lit but you don't see any text, try adjusting the contrast dial on the back of the display.

1. Terminate the program by pressing <kbd>Ctrl+C</kbd>.

Congratulations! You've displayed text on an LCD using a I2C and a GPIO expander!

## Get the source code

The source for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/master/tutorials/LcdTutorial).

## Next steps

> [!div class="nextstepaction"]
> [Learn to use General Purpose Input/Output to blink an LED](../tutorials/blink-led.md)
