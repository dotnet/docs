---
title: Quickstart - Use .NET to drive a Raspberry Pi Sense HAT
description: Get started with .NET IoT Libraries in 5 minutes using a Sense HAT, an add-on board for Raspberry Pi.
author: camsoper
ms.author: casoper
ms.date: 12/05/2022
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

> [!VIDEO https://learn-video.azurefd.net/vod/player?show=dotnet-iot-for-beginners&ep=intro-to-dotnet-iot-with-single-board-computers-and-raspberry-pi-dotnet-iot-for-beginners#time=4m45s]

## Prerequisites

- [!INCLUDE [prereq-rpi](../includes/prereq-rpi.md)]
- Sense HAT

## Prepare the Raspberry Pi

Use the `raspi-config` command to ensure your SBC is configured to support the following services:

- SSH
- I2C

For more information on `raspi-config`, refer to the [Raspberry Pi documentation](https://www.raspberrypi.com/documentation/computers/configuration.html).

## Attach the Sense HAT

With the Raspberry Pi device powered off, attach the Sense HAT. Power on the Raspberry Pi and launch the Bash shell once it boots. You may use SSH or connect the Raspberry Pi to a display.

## Install Git

From the shell, ensure the latest version of Git is installed on your Raspberry Pi. Run the following commands:

```bash
sudo apt update
sudo apt install git
```

The commands use the Advanced Package Tool command to:

- Download package information from all configured sources.
- Install the **Git** command line tool.

## Run the quickstart

From the shell, run the following command:

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

The source for this quickstart is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/main/quickstarts/SenseHat.Quickstart).

## Next steps

> [!div class="nextstepaction"]
> [Learn to use General Purpose Input/Output to blink an LED](../tutorials/blink-led.md)
