---
title: Read values from an analog-to-digital converter
description: Learn how to read variable voltage values using an analog-to-digital converter.
author: camsoper
ms.author: casoper
ms.date: 10/06/2021
ms.topic: tutorial
ms.prod: dotnet
recommendations: false
---
<!--markdownlint-disable DOCSMD011 -->
# Read values from an analog-to-digital converter

An analog-to-digital converter (ADC) is a device that can read an analog input voltage value and convert it into a digital value. ADCs are used for reading values from thermistors, potentiometers, and other devices that change resistance based on certain conditions.

In this topic, you will use .NET to read values from an ADC as you modulate the input voltage with a potentiometer.

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- [MCP3008](https://www.microchip.com/wwwproducts/MCP3008) analog-to-digital converter
- Three-pin potentiometer
- Breadboard
- Jumper wires
- Raspberry Pi GPIO breakout board (optional/recommended)
- [!INCLUDE [tutorial-prereq-dotnet](../includes/tutorial-prereq-dotnet.md)]

[!INCLUDE [prepare-pi-spi](../includes/prepare-pi-spi.md)]

## Prepare the hardware

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="../media/rpi-trimpot_spi-thumb.png" alt-text="A Fritzing diagram showing a circuit with an MCP3008 ADC and a potentiometer" lightbox="../media/rpi-trimpot_spi.png":::

The MCP3008 uses Serial Peripheral Interface (SPI) to communicate. The following are the connections from the MCP3008 to the Raspberry Pi and potentiometer:

- V<sub>DD</sub> to 3.3V (shown in red)
- V<sub>REF</sub> to 3.3V (red)
- AGND to ground (black)
- CLK to SCLK (orange)
- D<sub>OUT</sub> to MISO (orange)
- D<sub>IN</sub> to MOSI (orange)
- CS/SHDN to CE0 (green)
- DGND to ground (black)
- CH0 to variable (middle) pin on potentiometer (yellow)

Supply 3.3V and ground to the outer pins on the potentiometer. Order is unimportant.

Refer to the following pinout diagrams as needed:

| MCP3008  | Raspberry Pi GPIO |
|----------|-------------------|
| :::image type="content" source="../media/mcp3008-diagram-thumb.png" alt-text="A diagram showing the pinout of the MCP3008" lightbox="../media/mcp3008-diagram.png"::: | :::image type="content" source="../media/gpio-pinout-diagram-thumb.png" alt-text="A diagram showing the pinout of the Raspberry Pi GPIO header. Image courtesy Raspberry Pi Foundation." lightbox="../media/gpio-pinout-diagram.png":::<br />[Image courtesy Raspberry Pi Foundation](https://www.raspberrypi.com/documentation/computers/os.html#gpio-and-the-40-pin-header).
 |

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

## Create the app

Complete the following steps in your preferred development environment:

1. Create a new .NET Console App using either the [.NET CLI](../../core/tools/dotnet-new.md) or [Visual Studio](../../core/tutorials/with-visual-studio.md). Name it *AdcTutorial*.

    ```dotnetcli
    dotnet new console -o AdcTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    :::code language="csharp" source="~/iot-samples/tutorials/AdcTutorial/Program.cs" :::

    In the preceding code:

    - `hardwareSpiSettings` is set to a new instance of `SpiConnectionSettings`. The constructor sets the `busId` parameter to 0 and the `chipSelectLine` parameter to 0.
    - A [using declaration](../../csharp/whats-new/csharp-8.md#using-declarations) creates an instance of `SpiDevice` by calling `SpiDevice.Create` and passing in `hardwareSpiSettings`. This `SpiDevice` represents the SPI bus. The `using` declaration ensures the object is disposed and hardware resources are released properly.
    - Another `using` declaration creates an instance of `Mcp3008` and passes the `SpiDevice` into the constructor.
    - A `while` loop runs indefinitely. Each iteration:
        1. Reads the value of CH0 on the ADC by calling `mcp.Read(0)`.
        1. Divides the value by 10.24. The MCP3008 is a 10-bit ADC, which means it returns 1024 possible values ranging 0-1023. Dividing the value by 10.24 represents the value as a percentage.
        1. Rounds the value to the nearest integer.
        1. Writes the value to the console formatted as a percentage.
        1. Sleeps 500 ms.

1. [!INCLUDE [tutorial-build](../includes/tutorial-build.md)]
1. [!INCLUDE [tutorial-deploy](../includes/tutorial-deploy.md)]
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./AdcTutorial
    ```

    Observe the output as you rotate the potentiometer dial. This is due to the potentiometer varying the voltage supplied to CH0 on the ADC. The ADC compares the input voltage on CH0 to the reference voltage supplied to V<sub>REF</sub> to generate a value.

1. Terminate the program by pressing <kbd>Ctrl+C</kbd>.

Congratulations! You've used SPI to read values from an analog-to-digital converter.

## Get the source code

The source for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/master/tutorials/AdcTutorial).

## Next steps

> [!div class="nextstepaction"]
> [Learn to use General Purpose Input/Output to blink an LED](../tutorials/blink-led.md)
