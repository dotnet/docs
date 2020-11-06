---
title: Read environmental conditions from a sensor
description: Learn how .NET can be used to build applications for IoT devices and scenarios.
author: camsoper
ms.author: casoper
ms.date: 11/2/2020
ms.topic: overview
ms.prod: dotnet
---

# Read environmental conditions from a sensor

One of the most common scenarios for IoT devices is detection of environmental conditions. A variety of sensors are available to monitor temperature, humidity, barometric pressure, and more.

In this topic, you will use .NET to read environmental conditions from a sensor.

## Prerequisites

- Raspberry Pi (2 or greater) with [Raspberry Pi OS installed](https://www.raspberrypi.org/documentation/installation/installing-images/README.md)
- [BME280](https://learn.adafruit.com/adafruit-bme280-humidity-barometric-pressure-temperature-sensor-breakout) humidity/barometric pressure/temperature sensor breakout
- Jumper wires
- Breadboard (optional)
- Raspberry Pi GPIO breakout board (optional)
- [.NET SDK](https://dotnet.microsoft.com/download) version 5.0.100 or later

> [!IMPORTANT]
> There are many manufacturers of BME280 breakouts. Most designs are similar, and the manufacturer shouldn't make any difference to the functionality. This tutorial attempts to account for variations. Ensure your BME280 breakout includes an Inter-Integrated Circuit (I2C) interface.

[!INCLUDE [prepare-pi-i2c](../includes/prepare-pi-i2c.md)]

## Prepare the hardware

Use the hardware components to build the circuit as depicted in the following diagram:

:::image type="content" source="../media/rpi-bmp280_i2c-thumb.png" alt-text="A Fritzing diagram showing the connection from Raspberry Pi to BME280 breakout board" lightbox="../media/rpi-bmp280_i2c.png":::

The following are the connections from the Raspberry Pi to the BME280 breakout:

- 3.3V to VIN *OR* 3V3 (shown in red)
- Ground to GND (black)
- SDA (GPIO 2) to SDI *OR* SDA (blue)
- SCL (GPIO 3) to SCK *OR* SCL (orange)

Refer to the following pinout diagram as needed:

:::image type="content" source="../media/gpio-pinout-diagram-thumb.png" alt-text="A diagram showing the pinout of the Raspberry Pi GPIO header. Image courtesy Raspberry Pi Foundation." lightbox="../media/gpio-pinout-diagram.png":::<br />[Image courtesy Raspberry Pi Foundation](https://www.raspberrypi.org/documentation/usage/gpio/).

[!INCLUDE [gpio-breakout](../includes/gpio-breakout.md)]

## Create the app

Complete the following steps in your preferred development environment:

1. Create a new .NET Console App using either the [.NET CLI](/dotnet/core/tools/dotnet-new) or [Visual Studio](/dotnet/core/tutorials/with-visual-studio). Name it *SensorTutorial*.

    ```dotnetcli
    dotnet new console -o SensorTutorial
    ```

1. [!INCLUDE [tutorial-add-packages](../includes/tutorial-add-packages.md)]
1. Replace the contents of *Program.cs* with the following code:

    ```csharp
    using System;
    using System.Device.I2c;
    using System.Threading;
    using Iot.Device.Bmxx80;
    using Iot.Device.Bmxx80.PowerMode;

    I2cConnectionSettings i2cSettings = new I2cConnectionSettings(1, Bme280.DefaultI2cAddress);
    using I2cDevice i2cDevice = I2cDevice.Create(i2cSettings);
    using Bme280 bme280 = new Bme280(i2cDevice);

    int measurementTime = bme280.GetMeasurementDuration();

    while (true)
    {
        Console.Clear();

        bme280.SetPowerMode(Bmx280PowerMode.Forced);
        Thread.Sleep(measurementTime);

        bme280.TryReadTemperature(out var tempValue);
        bme280.TryReadPressure(out var preValue);
        bme280.TryReadHumidity(out var humValue);
        bme280.TryReadAltitude(out var altValue);

        Console.WriteLine($"Temperature: {tempValue.DegreesCelsius:0.#}\u00B0C");
        Console.WriteLine($"Pressure: {preValue.Hectopascals:#.##} hPa");
        Console.WriteLine($"Relative humidity: {humValue.Percent:#.##}%");
        Console.WriteLine($"Estimated altitude: {altValue.Meters:#} m");

        Thread.Sleep(1000);
    }
    ```

    In the preceding code:

    - `i2cSettings` is set to a new instance of `I2cConnectionSettings`. The constructor sets the `busId` parameter to 1 and the `deviceAddress` parameter to `Bme280.DefaultI2cAddress`.

        > [!IMPORTANT]
        > Some BME280 breakout manufacturers use the secondary address value. For those devices, use `Bme280.SecondaryI2cAddress`.

    - A [using declaration](/dotnet/csharp/whats-new/csharp-8#using-declarations) creates an instance of `I2cDevice` by calling `I2cDevice.Create` and passing in `i2cSettings`. This `I2cDevice` represents the I2C bus. The `using` declaration ensures the object is disposed and hardware resources are released properly.
    - Another `using` declaration creates an instance of `Bme280` to represent the sensor. The `I2cDevice` is passed in the constructor.
    - The time required for the chip to take measurements with the chip's current (default) settings is retrieved by calling `GetMeasurementDuration`.
    - A `while` loop runs indefinitely. Each iteration:
        1. Clears the console.
        1. Sets the power mode to `Bmx280PowerMode.Forced`. This forces the chip to perform one measurement, store the results, and then sleep.
        1. Reads the values for temperature, pressure, humidity, and altitude.

            > [!NOTE]
            > Altitude is calculated by the device binding. This overload of `TryReadAltitude` uses mean sea level pressure to generate an estimate.

        1. Writes the current environmental conditions to the console.
        1. Sleeps 1000 ms.

1. Build the app by running `dotnet build` if using the .NET CLI. To build in Visual Studio, press <kbd>Ctrl+Shift+B</kbd>.
1. Deploy the app to the Raspberry Pi as a self-contained app. For instructions, see [Deploy .NET apps to Raspberry Pi](../deployment.md#deploying-a-self-contained-app). Make sure to give the executable *execute* permission using `chmod +x`.
1. Run the app on the Raspberry Pi by switching to the deployment directory and running the executable.

    ```bash
    ./SensorTutorial
    ```

    Observe the sensor output in the console.

1. Terminate the program by pressing <kbd>Ctrl+C</kbd>.

Congratulations! You've used I2C to read values from a temperature/humidity/barometric pressure sensor!

## Get the source code

The source for this tutorial is [available on GitHub](https://github.com/MicrosoftDocs/dotnet-iot-assets/tree/master/tutorials/SensorTutorial).
