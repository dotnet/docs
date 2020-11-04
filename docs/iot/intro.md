---
title: Develop apps for IoT devices with the .NET IoT Libraries
description: Learn how .NET can be used to build applications for IoT devices and scenarios.
author: camsoper
ms.author: casoper
ms.date: 11/2/2020
ms.topic: overview
ms.prod: dotnet
---

# Develop apps for IoT devices with the .NET IoT Libraries

.NET runs on a variety of platforms and architectures. Common IoT boards, including Raspberry Pi and Hummingboard, are supported. IoT apps typically interact with specialized hardware, such as sensors, analog-to-digital converters, and LCD devices. The .NET IoT Libraries enable these scenarios.

<!--markdownlint-disable MD034 -->
> [!VIDEO https://channel9.msdn.com/Series/IoT-101/Intro-to-IOT-with-NET-Core-1-of-9/player]

## Libraries

The .NET IoT Libraries are composed of two NuGet packages, [System.Device.Gpio](https://www.nuget.org/packages/System.Device.Gpio/) and [Iot.Device.Bindings](https://www.nuget.org/packages/Iot.Device.Bindings/).

### System.Device.Gpio

System.Device.Gpio supports a variety of techniques and protocols for interacting with low-level hardware pins to control devices. These include:

- General-purpose I/O (GPIO)
- Inter-Integrated Circuit (I2C)
- Serial Peripheral Interface (SPI)
- Pulse Width Modulation (PWM)

### Iot.Device.Bindings

Iot.Device.Bindings streamlines app development for devices and sensors using the protocols supported by System.Device.Gpio. Iot.Device.Bindings is optional since it wraps lower-level functionality found in System.Device.Gpio.

#### Available bindings

As Iot.Device.Bindings is open-source, the community contributes device bindings. Additional bindings are added continually.

Find more information about supported devices on Github:

- [Device bindings list](https://github.com/dotnet/iot/blob/master/src/devices/README.md)
- [Device bindings source with samples](https://github.com/dotnet/iot/tree/master/src/devices)

## Supported operating systems

System.Device.Gpio is supported on Linux and Windows 10 IoT Core. For Raspberry Pi, Raspberry Pi OS (formerly Raspbian) is recommended.

## Supported hardware platforms

System.Device.Gpio is compatible with most single-board platforms. Recommended platforms are Raspberry Pi (3 and greater) and Hummingboard. Other platforms known to be compatible are BeagleBoard and ODROID.

PC platforms are supported via the use of a USB to SPI/I2C bridge.

> [!IMPORTANT]
> .NET is not supported on ARMv6 architecture devices, including Raspberry Pi Zero and Raspberry Pi devices prior to Raspberry Pi 2.

## Resources

- [.NET IoT Libraries on Github](https://github.com/dotnet/iot)
