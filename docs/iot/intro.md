---
title: Develop apps for IoT devices with the .NET IoT Libraries
description: Learn how .NET can be used to build applications for IoT devices and scenarios.
author: camsoper
ms.author: casoper
ms.date: 10/14/2022
ms.topic: overview
ms.prod: dotnet
---

# Develop apps for IoT devices with the .NET IoT Libraries

.NET runs on various platforms and architectures. Common Internet of things (IoT) boards, such as Raspberry Pi and Hummingboard, are supported. IoT apps typically interact with specialized hardware, such as sensors, analog-to-digital converters, and LCD devices. The .NET IoT Libraries enable these scenarios.

## Libraries

The .NET IoT Libraries are composed of two NuGet packages:

- [System.Device.Gpio](https://www.nuget.org/packages/System.Device.Gpio/)
- [Iot.Device.Bindings](https://www.nuget.org/packages/Iot.Device.Bindings/)

### System.Device.Gpio

`System.Device.Gpio` supports various protocols for interacting with low-level hardware pins to control devices. These include:

- General-purpose I/O (GPIO)
- Inter-Integrated Circuit (I<sup>2</sup>C)
- Serial Peripheral Interface (SPI)
- Pulse Width Modulation (PWM)
- Serial port

### Iot.Device.Bindings

The `Iot.Device.Bindings` package:

* Contains [device bindings](https://github.com/dotnet/iot/blob/main/src/devices/README.md) to streamline app development by wrapping System.Device.Gpio.
* Is community-supported, and additional bindings are added continually.

The [complete list of available device bindings](https://github.com/dotnet/iot/blob/main/src/devices/README.md) is maintained on GitHub.

Some commonly used device bindings include:

- [CharacterLcd - LCD character display](https://github.com/dotnet/iot/tree/main/src/devices/CharacterLcd)
- [SN74HC595 - 8-bit shift register](https://github.com/dotnet/iot/tree/main/src/devices/Sn74hc595)
- [BrickPi3](https://github.com/dotnet/iot/tree/main/src/devices/BrickPi3)
- [Max7219 - LED Matrix driver](https://github.com/dotnet/iot/tree/main/src/devices/Max7219)
- [RGBLedMatrix - RGB LED Matrix](https://github.com/dotnet/iot/tree/main/src/devices/RGBLedMatrix)

## Supported operating systems

`System.Device.Gpio` is supported on any operating system that supports .NET, including most versions of Linux that support ARM/ARM64 and Windows 10 IoT Core.

> [!TIP]
> For Raspberry Pi, [Raspberry Pi OS (64-bit)](https://www.raspberrypi.com/documentation/computers/getting-started.html#installing-the-operating-system) is recommended. No desktop is required, so Raspberry Pi OS Lite can be used to reduce the size of the operating system.
>
> :::image type="content" source="media/rpi-imager-64bit.gif" alt-text="Animated GIF showing the Raspberry Pi Imager tool. The user selects 'RASPBERRY PI OS LITE (64-BIT) from the list of available operating systems.":::

## Supported hardware platforms

`System.Device.Gpio` is compatible with most single-board platforms. Recommended platforms are Raspberry Pi (2 and greater) and Hummingboard. Other platforms known to be compatible are BeagleBoard and ODROID.

PC platforms are supported via the use of a USB to SPI/I<sup>2</sup>C bridge.

> [!IMPORTANT]
> .NET is not supported on ARMv6 architecture devices, including Raspberry Pi Zero and Raspberry Pi devices prior to Raspberry Pi 2.

## Resources

- [.NET IoT Libraries on GitHub](https://github.com/dotnet/iot)
