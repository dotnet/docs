---
title: Data Decoding
description: Data Decoding (POS for .NET v1.14 SDK Documentation)
ms.date: 03/03/2014
ms.topic: how-to
ms.custom: "pos-restored-from-archive,UpdateFrequency5"
---

# Data Decoding (POS for .NET v1.14 SDK Documentation)

The <xref:Microsoft.PointOfService.BaseServiceObjects.ScannerBase> class provides two methods, **DecodeDataLabel** and **DecodeScanDataType** for decoding incoming date. These methods are called when the properties **ScanDataLabel** and **ScanDataType**, respectively, are accessed. The **ScannerBase** class defers data decoding until the application accesses the data properties and the decoded data will be cached for future reads.

The **ScannerBase** class implements the **ScannerBase.DecodeData** attribute as required by the Unified Point Of Service (UnifiedPOS) specification. If **DecodeData** is not set to **true** when the application reads the **ScanDataLabel** property, an empty byte array will be returned. Similarly, **ScanDataType** returns **BarCodeSymbology.Unknown**. This functionality is implemented in the **ScannerBase** class and is transparent to both the application and the Service Object.

## To implement DecodeScanDataLabel

1. Override the protected, virtual **ScannerBasic** member **DecodeScanDataLabel**.

2. **DecodeScanData** takes an argument, ***scanData***, which contains the complete data buffer. There is no need to cache any additional data in the Service Object code.

3. **DecodeScanData** should process the scanned data to remove header and type information at the start and end of the data buffer. The modified buffer will be returned in a byte array.

## To implement DecodeScanDataType

1. Override the protected, virtual **ScannerBasic** member **DecodeScanDataType**.

2. Like **DecodeScanDataLabel**, **DecodeScanDataType** receives an argument containing the complete scanned buffer.

3. **DecodeScanDataType** examines the buffer to find the data type of the scanned data and returns the appropriate **BarCodeSymbology** value.

## Example

The following code demonstrates a typical method the Service Object developer could implement in order to extract label and data values from a scanned buffer. Note that this code is demonstrative of a particular device. Different Service Objects will require device-specific decoding.

```csharp
// Decode the incoming scanner data, removing header and
// type information.
override protected byte[] DecodeScanDataLabel(
                byte[] scanData)
{
    int i;
    int len = 0;

    // Get length of label data.
    for (i = 5; i < (int)scanData[1]
                && (int)scanData[i] > 31; i++)
    {
        len++;
    }

    // Copy label data into buffer.
    byte[] label = new byte[len];
    len = 0;

    for (i = 5; i < (int)scanData[1]
                && (int)scanData[i] > 31; i++)
    {
        label[len++] = scanData[i];
    }

    return label;
}

// Process the incoming scanner data to find the data type.
override protected BarCodeSymbology DecodeScanDataType(
                byte[] scanData)
{
    int i;

    for (i = 5; i < (int)scanData[1]
                && (int)scanData[i] > 31; i++)
    {
    }

    // last 3 (or 1) bytes indicate symbology.
    if (i + 2 <= (int)ScanData[1])
    {
        return GetSymbology(
                ScanData[i],
                ScanData[i + 1],
                ScanData[i + 2]);
    }
    else
    {
        return GetSymbology(ScanData[i], 0, 0);
    }
}

// This method determines the data type by examining
// the end of the scanned data buffer. Either 1 byte
// or 3 byte is used to determine the type, depending on
// the incoming buffer.
static private BarCodeSymbology GetSymbology(
            byte b1,
            byte b2,
            byte b3)
{
    if (b1 == 0 && b3 == 11)
    {
        // Use all 3 bytes to determine the date type.
        switch (b2)
        {
            case 10:
                return BarCodeSymbology.Code39;
            case 13:
                return BarCodeSymbology.Itf;
            case 14:
                return BarCodeSymbology.Codabar;
            case 24:
                return BarCodeSymbology.Code128;
            case 25:
                return BarCodeSymbology.Code93;
            case 37:
                return BarCodeSymbology.Ean128;
            case 255:
                return BarCodeSymbology.Rss14;
            default:
                break;
        }

    }
    else if (b2 == 0 && b3 == 0)
    {
        // Only use the first byte to determine the data type.
        switch (b1)
        {
            case 13:
                return BarCodeSymbology.Upca;
            case 22:
                return BarCodeSymbology.EanJan13;
            case 12:
                return BarCodeSymbology.EanJan8;
            default:
                break;
        }
    }

    return BarCodeSymbology.Other;
}
```

Additional details about how label and type data should be extracted from a scanned data buffer can be found in the UPOS specification.

## Compiling the Code

- For additional information about creating and compiling a Service Object project, see [Service Object Samples: Getting Started](service-object-samples-getting-started.md).

## See Also

#### Reference

- <xref:Microsoft.PointOfService.BaseServiceObjects.ScannerBase.DecodeScanDataLabel(System.Byte[])>
- <xref:Microsoft.PointOfService.BaseServiceObjects.ScannerBase.DecodeScanDataType(System.Byte[])>

#### Other Resources

- [Scanner Implementation](scanner-implementation.md)
