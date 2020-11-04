---
title: SPI - Read values from an analog-to-digital converter
description: Learn how .NET can be used to build applications for IoT devices and scenarios.
author: camsoper
ms.author: casoper
ms.date: 11/2/2020
ms.topic: tutorial
ms.prod: dotnet
---

# SPI - Read values from an analog-to-digital converter

An analog-to-digital converter (ADC) is a device that can read an analog input voltage value and convert it into a digital value. ADCs are used for reading various sensors, potentiometers, and other devices that change resistance based on certain conditions.

In this topic, you will use .NET to read values from an ADC as you modulate the input voltage with a potentiometer.

## Prerequisites

- Raspberry Pi (2 or greater) with [Raspberry Pi OS installed](https://www.raspberrypi.org/documentation/installation/installing-images/README.md)
- An [MCP3008](https://www.microchip.com/wwwproducts/en/MCP3008) ADC
- A 3-pin potentiometer
- A breadboard
- Jumper wires
- Raspberry Pi GPIO breakout board (optional/recommended)
- [.NET SDK](https://dotnet.microsoft.com/download)

[!INCLUDE [prepare-pi-spi](../includes/prepare-pi-spi.md)]

## Prepare the circuit

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="../media/rpi-trimpot_spi-thumb.png" alt-text="A Fritzing diagram showing a circuit with an MCP3008 ADC and a potentiometer" lightbox="../media/rpi-trimpot_spi.png":::

The following are the connections from the MCP3008:

<!--markdownlint-disable MD033 -->
- V<sub>DD</sub> to 3.3V power (shown in red)
- V<sub>REF</sub> to 3.3V power (red)
- AGND to ground (black)
- CLK to SCLK (orange)
- D<sub>OUT</sub> to MISO (orange)
- D<sub>IN</sub> to MOSI (orange)
- CS/SHDN to CE0 (orange)
- DGND to ground (black)
- CH0 to variable (middle) pin on potentiometer (yellow)

Supply 3.3V and ground to the outer pins on the potentiometer. Order is unimportant.

Refer to the following pinout diagrams as needed:

| MCP3008  | Raspberry Pi GPIO |
|----------|-------------------|
| :::image type="content" source="../media/mcp3008-diagram-thumb.png" alt-text="A diagram showing the pinout of the MCP3008" lightbox="../media/mcp3008-diagram.png"::: | :::image type="content" source="../media/gpio-pinout-diagram-thumb.png" alt-text="A diagram showing the pinout of the Raspberry Pi GPIO header. Image courtesy Raspberry Pi Foundation." lightbox="../media/gpio-pinout-diagram.png":::<br />[Image courtesy Raspberry Pi Foundation](https://www.raspberrypi.org/documentation/usage/gpio/).
 |

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

Once all the connections are made, power on the Raspberry Pi.

## Create the app

1.