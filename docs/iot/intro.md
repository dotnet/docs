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

.NET runs on a variety of platforms and architectures. Common IoT boards, such as Raspberry Pi and Hummingboard, are supported. IoT apps typically interact with specialized hardware, such as sensors, analog-to-digital converters, and LCD devices. The .NET IoT Libraries enable these scenarios.

## Video overview

<!--markdownlint-disable MD034 -->
> [!VIDEO https://channel9.msdn.com/Series/IoT-101/Intro-to-IOT-with-NET-Core-1-of-9/player]

## Libraries

The .NET IoT Libraries are composed of two NuGet packages:

- [System.Device.Gpio](https://www.nuget.org/packages/System.Device.Gpio/)
- [Iot.Device.Bindings](https://www.nuget.org/packages/Iot.Device.Bindings/).

### System.Device.Gpio

System.Device.Gpio supports a variety of protocols for interacting with low-level hardware pins to control devices. These include:

- General-purpose I/O (GPIO)
- Inter-Integrated Circuit (I2C)
- Serial Peripheral Interface (SPI)
- Pulse Width Modulation (PWM)
- Serial port

### Iot.Device.Bindings

Iot.Device.Bindings contains [device bindings](https://github.com/dotnet/iot/blob/master/src/devices/README.md) to streamline app development by wrapping System.Device.Gpio. Iot.Device.Bindings is community-supported, and additional bindings are added continually.

Common device bindings include:

- Adding
- Items
- as
- Suggested
- by
- Rich

## Supported operating systems

System.Device.Gpio is supported on Linux and Windows 10 IoT Core. For Raspberry Pi, Raspberry Pi OS (formerly Raspbian) is recommended.

## Supported hardware platforms

System.Device.Gpio is compatible with most single-board platforms. Recommended platforms are Raspberry Pi (2 and greater) and Hummingboard. Other platforms known to be compatible are BeagleBoard and ODROID.

PC platforms are supported via the use of a USB to SPI/I2C bridge.

> [!IMPORTANT]
> .NET is not supported on ARMv6 architecture devices, including Raspberry Pi Zero and Raspberry Pi devices prior to Raspberry Pi 2.

## Resources

- [.NET IoT Libraries on Github](https://github.com/dotnet/iot)
