---
title: FormatFromRawValue function (Unmanaged API Reference)
description: The FormatFromRawValue function converts raw performance data to a specified format.
ms.date: "11/21/2017"
api_name: 
  - "FormatFromRawValue"
api_location: 
  - "PerfCounter.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "FormatFromRawValue"
helpviewer_keywords: 
  - "FormatFromRawValue function [.NET WMI and performance counters]"
topic_type: 
  - "Reference"
---
# FormatFromRawValue function

Converts one raw performance data value to the specified format, or two raw performance data values if the format conversion is time-based.

[!INCLUDE[internalonly-unmanaged](../../../../includes/internalonly-unmanaged.md)]

## Syntax

```cpp
int FormatFromRawValue (
   [in] uint                    dwCounterType,
   [in] uint                    dwFormat,
   [in] long*                   pTimeBase,
   [in] PDH_RAW_COUNTER*        pRawValue1,
   [in] PDH_RAW_COUNTER*        pRawValue2,
   [out] PDH_FMT_COUNTERVALUE*  pFmtValue
);
```

## Parameters

`dwCounterType`\
[in] The counter type. For a list of counter types, see [WMI Performance Counter Types](/windows/desktop/WmiSdk/wmi-performance-counter-types). `dwCounterType` can be any counter type except for `PERF_LARGE_RAW_FRACTION` and `PERF_LARGE_RAW_BASE`.

`dwFormat`\
[in] The format to which to convert the raw performance data. It can be one of the following values:

|Constant  |Value  |Description |
|---------|---------|---------|
| `PDH_FMT_DOUBLE` |0x00000200 | Return the calculated value as a double-precision floating point value. |
| `PDH_FMT_LARGE` | 0x00000400 | Return the calculated value as a 64-bit integer. |
| `PDH_FMT_LONG` | 0x00000100 | Return the calculated value as a 32-bit integer. |

One of the previous values can be ORed with one of the following scaling flags:

|Constant  |Value  |Description |
|---------|---------|---------|
| `PDH_FMT_NOSCALE` | 0x00001000 | Do not apply the counter's scaling factors. |
| `PDH_FMT_1000` | 0x00002000 | Multiply the final value by 1,000. |

`pTimeBase`\
[in] A pointer to the time base, if necessary for the format conversion. If time base information is not necessary for the format conversion, the value of this parameter is ignored.

`pRawValue1`\
[in] A pointer to a [`PDH_RAW_COUNTER`](/windows/win32/api/pdh/ns-pdh-pdh_raw_counter) structure that represents a raw performance value.

`pRawValue2`\
[in] A pointer to a [`PDH_RAW_COUNTER`](/windows/win32/api/pdh/ns-pdh-pdh_raw_counter) structure that represents a second raw performance value. If a second raw performance value is not necessary, this parameter should be `null`.

`pFmtValue`\
[out] A pointer to a [`PDH_FMT_COUNTERVALUE`](/windows/win32/api/pdh/ns-pdh-pdh_fmt_countervalue) structure that receives the formatted performance value.

## Return value

The following values are returned by this function:

|Constant  |Value  |Description  |
|---------|---------|---------|
| `ERROR_SUCCESS` | 0 | The function call is successful. |
| `PDH_INVALID_ARGUMENT` | 0xC0000BBD | A required argument is missing or incorrect. |
| `PDH_INVALID_HANDLE` | 0xC0000BBC | The handle is not a valid PDH object. |

## Remarks

This function wraps a call to the [FormatFromRawValue](/previous-versions/ms231047(v=vs.85)) function.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Library:** PerfCounter.dll

 **.NET Framework Versions:** [!INCLUDE[net_current_v472plus](../../../../includes/net-current-v472plus.md)]

## See also

- [WMI and Performance Counters (Unmanaged API Reference)](index.md)
