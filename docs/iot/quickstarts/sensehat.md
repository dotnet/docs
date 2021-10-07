---
title: Quickstart - Use .NET to drive a Raspberry Pi Sense HAT
description: Get started with .NET IoT Libraries in 5 minutes using a Sense HAT, an add-on board for Raspberry Pi.
author: camsoper
ms.author: casoper
ms.date: 10/06/2021
ms.topic: quickstart
ms.prod: dotnet
recommendations: false
---

# Quickstart - Use .NET to drive a Raspberry Pi Sense HAT

The Raspberry Pi [Sense HAT](https://www.raspberrypi.com/products/sense-hat/) (**H**ardware **A**ttached on **T**op) is an add-on board for Raspberry Pi. The Sense HAT is equipped with an 8×8 RGB LED matrix, a five-button joystick, and includes the following sensors:

- Gyroscope
- Accelerometer
- Magnetometer
- Temperature
- Barometric pressure
- Humidity

This quickstart uses .NET to retrieve sensor values from the Sense HAT, respond to joystick input, and drive the LED matrix.

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- Sense HAT

[!INCLUDE [prepare-pi-i2c](../includes/prepare-pi-i2c.md)]

## Install Git

Ensure the latest version of Git is installed on your Raspberry Pi. Run the following commands:

```bash
sudo apt update
sudo apt install git
```

The commands use the Advanced Package Tool command to:

- Download package information from all configured sources.
- Install the **Git** command line tool.

## Run the quickstart

Attach the Sense HAT to your Raspberry Pi. From a Bash prompt on the Raspberry Pi (local or remote), run the following command:

```bash
. <(wget -q -O - https://aka.ms/dotnet-iot-sensehat-quickstart)
```

The command downloads and runs a script. The script:

- Installs the .NET SDK.
- Clones a GitHub repository that includes the Sense HAT quickstart project.
- Builds the project.
- Runs the project.

Observe the console output as sensor data is displayed. The LED matrix displays a yellow pixel on a field of blue. Holding the joystick in any direction moves the yellow pixel in that direction. Clicking the center joystick button causes the background to switch from blue to red.

## Get the source code

The source for this quickstart is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/master/quickstarts/SenseHat.Quickstart).

## Next steps

> [!div class="nextstepaction"]
> [Learn to use General Purpose Input/Output to blink an LED](../tutorials/blink-led.md)
