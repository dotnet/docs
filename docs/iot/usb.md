---
title: Use .NET IoT Libraries on Windows, Linux, and macOS computers
description: Learn how to develop GPIO, I2C, and SPI code with .NET on PCs.
author: camsoper
ms.date: 07/31/2024
ms.topic: how-to
ms.custom: linux-related-content
---

# Use .NET IoT Libraries on Windows, Linux, and macOS computers

The .NET IoT libraries are commonly used to develop code for Raspberry Pi and other IoT devices. However, you can also use them to develop code for Windows, Linux, and macOS PCs using a USB-to-serial adapter such as the [FTDI FT232H](https://www.adafruit.com/product/2264). This article shows you how to use the .NET IoT libraries to communicate with devices connected to the FT232H adapter.

> [!TIP]
> This article uses an FTDI FT232H adapter, but you can use any USB-to-serial adapter that is supported by the .NET IoT libraries, such as the FT2232H, FT4232H, and FT4222. Check the [list of supported device bindings](https://github.com/dotnet/iot/blob/main/src/devices/README.md#usb-devices) for more information.

## Prerequisites

Ensure you have installed the D2XX drivers for your USB-to-serial adapter, which are found on the [FTDI website](https://ftdichip.com/drivers/d2xx-drivers/).

> [!NOTE]
> Windows devices may automatically install the drivers when you plug in the adapter. Check Device Manager for a device named *USB Serial Converter* listed under *Universal Serial Bus controllers*. The device's driver provider should be *FTDI*.

## List available devices

Before you can create a GPIO, I<sup>2</sup>C, or SPI device, you must identify the connected USB-to-serial adapter. The following code lists the connected FTDI devices:

:::code language="csharp" source="~/iot-samples/tutorials/ft232h/ft232h.list/Program.cs" highlight="3" :::

In the preceding code, the `FtCommon.GetDevices()` method returns a list of all connected FTDI devices.

## Use a GPIO device

Here's a hardware implementation of the [Blink an LED](tutorials/blink-led.md) tutorial that uses the FTDI FT232H adapter to control an LED:

:::image type="content" source="./media/usb-to-gpio-thumb.png" alt-text="A picture of a breadboard with an FT232H adapter, a resister, an LED, and connecting wires." lightbox="./media/usb-to-gpio.png":::

In the preceding image, the LED circuit is very similar to the original tutorial. The only difference is that the LED is connected to pin *D7* on the FT232H adapter instead of pin *18* on the Raspberry Pi.

The code for the tutorial is also similar to the original tutorial:

:::code language="csharp" source="~/iot-samples/tutorials/ft232h/ft232h.gpio/Program.cs" highlight="7-10" :::

In the preceding code:

- An instance `Ft232HDevice` is created by passing the first device ID returned by `FtCommon.GetDevices()` to the constructor.
- An instance of `GpioController` named *controller* is created by calling `CreateGpioController()` on the `Ft232HDevice` instance. This `GpioController` instance performs the same functions as the `GpioController` instance in the original tutorial.
- The integer value of the pin is retrieved by calling `GetPinNumberFromString()` on the `Ft232HDevice` instance and passing in the alphanumeric pin name *D7*.
- The rest of the code is identical to the original tutorial.

## Use an I<sup>2</sup>C device

For I<sup>2</sup>C communication, the *D0* and *D1* pins on the FT232H adapter are used for the SDL and SCA lines, respectively. The *I2C* selector switch on the FT232H adapter must be set to *On*.

Here's a hardware implementation of the [Read environmental conditions from a sensor](tutorials/temp-sensor.md) tutorial that uses the FTDI FT232H adapter to read temperature, humidity, and barometric pressure from a BME280 sensor:

:::image type="content" source="./media/usb-to-i2c-thumb.png" alt-text="A picture of a breadboard with an FT232H adapter, a BME280 breakout board, and connecting wires." lightbox="./media/usb-to-i2c.png":::

In the preceding image:

- The *D0* and *D1* pins on the FT232H adapter are connected to the *SDL* and *SCA* pins on the BME280 breakout board, respectively.
- The *I2C* selector switch on the BME280 breakout board is set to *On*.

:::code language="csharp" source="~/iot-samples/tutorials/ft232h/ft232h.i2c/Program.cs" highlight="7-10" :::

In the preceding code:

- An instance `Ft232HDevice` is created by passing the first device ID returned by `FtCommon.GetDevices()` to the constructor.
- An instance of `I2cDevice` is created by calling `CreateI2cDevice()` on the `Ft232HDevice` instance. This `I2cDevice` instance performs the same functions as the `I2cDevice` instance in the original tutorial.
- The rest of the code is identical to the original tutorial.

## Use an SPI device

For SPI communication, the *D0*, *D1*, *D2*, and *D3* pins on the FT232H adapter are used for the SCK, MOSI, MISO, and CS lines, respectively. The *I2C* selector switch on the FT232H adapter must be set to *Off*.

:::image type="content" source="./media/usb-spi-pins-thumb.png" alt-text="A picture of the back of the FT232H breakout depicting the SPI pins." lightbox="./media/usb-spi-pins.png":::

Here's a hardware implementation of the [Read values from an analog-to-digital converter](tutorials/adc.md) tutorial that uses the FTDI FT232H adapter to read values from an MCP3008 ADC:

:::image type="content" source="./media/usb-to-spi-thumb.png" alt-text="A picture of a breadboard with an FT232H adapter, an MCP3008 chip, and connecting wires." lightbox="./media/usb-to-spi.png":::

In the preceding image:

- The *D0*, *D1*, *D2*, and *D3* pins on the FT232H adapter are connected to the *CLK*, *DIN*,  *DOUT*,and *CS/SHDN* pins on the MCP3008, respectively.
- The *I2C* selector switch on the MCP3008 breakout board is set to *Off*.

:::code language="csharp" source="~/iot-samples/tutorials/ft232h/ft232h.spi/Program.cs" highlight="7-10" :::

In the preceding code:

- An instance `Ft232HDevice` is created by passing the first device ID returned by `FtCommon.GetDevices()` to the constructor.
- An instance of `SpiDevice` is created by calling `CreateSpiDevice()` on the `Ft232HDevice` instance. This `SpiDevice` instance performs the same functions as the `SpiDevice` instance in the original tutorial.
- The rest of the code is identical to the original tutorial.

## Get the code

The code for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/main/tutorials/ft232h).
