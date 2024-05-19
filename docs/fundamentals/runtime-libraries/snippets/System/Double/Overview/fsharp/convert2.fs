module convert2

// <Snippet21>
open System
open Checked

let values = 
    [| Double.MinValue; -67890.1234; -12345.6789
       12345.6789; 67890.1234; Double.MaxValue
       Double.NaN; Double.PositiveInfinity;
       Double.NegativeInfinity |]

for value in values do
    try
        let lValue = int64 value
        printfn $"{value} ({value.GetType().Name}) --> {lValue} (0x{lValue:X16}) ({lValue.GetType().Name})"
    with :? OverflowException ->
        printfn $"Unable to convert {value} to Int64."
    try
        let ulValue = uint64 value
        printfn $"{value} ({value.GetType().Name}) --> {ulValue} (0x{ulValue:X16}) ({ulValue.GetType().Name})"
    with :? OverflowException ->
        printfn $"Unable to convert {value} to UInt64."
    try
        let dValue = decimal value
        printfn $"{value} ({value.GetType().Name}) --> {dValue} ({dValue.GetType().Name})"
    with :? OverflowException ->
        printfn $"Unable to convert {value} to Decimal."
    try
        let sValue = float32 value
        printfn $"{value} ({value.GetType().Name}) --> {sValue} ({sValue.GetType().Name})"
    with :? OverflowException ->
        printfn $"Unable to convert {value} to Single."
    printfn ""
// The example displays the following output for conversions performed
// in a checked context:
//       Unable to convert -1.79769313486232E+308 to Int64.
//       Unable to convert -1.79769313486232E+308 to UInt64.
//       Unable to convert -1.79769313486232E+308 to Decimal.
//       -1.79769313486232E+308 (Double) --> -Infinity (Single)
//
//       -67890.1234 (Double) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
//       Unable to convert -67890.1234 to UInt64.
//       -67890.1234 (Double) --> -67890.1234 (Decimal)
//       -67890.1234 (Double) --> -67890.13 (Single)
//
//       -12345.6789 (Double) --> -12345 (0xFFFFFFFFFFFFCFC7) (Int64)
//       Unable to convert -12345.6789 to UInt64.
//       -12345.6789 (Double) --> -12345.6789 (Decimal)
//       -12345.6789 (Double) --> -12345.68 (Single)
//
//       12345.6789 (Double) --> 12345 (0x0000000000003039) (Int64)
//       12345.6789 (Double) --> 12345 (0x0000000000003039) (UInt64)
//       12345.6789 (Double) --> 12345.6789 (Decimal)
//       12345.6789 (Double) --> 12345.68 (Single)
//
//       67890.1234 (Double) --> 67890 (0x0000000000010932) (Int64)
//       67890.1234 (Double) --> 67890 (0x0000000000010932) (UInt64)
//       67890.1234 (Double) --> 67890.1234 (Decimal)
//       67890.1234 (Double) --> 67890.13 (Single)
//
//       Unable to convert 1.79769313486232E+308 to Int64.
//       Unable to convert 1.79769313486232E+308 to UInt64.
//       Unable to convert 1.79769313486232E+308 to Decimal.
//       1.79769313486232E+308 (Double) --> Infinity (Single)
//
//       Unable to convert NaN to Int64.
//       Unable to convert NaN to UInt64.
//       Unable to convert NaN to Decimal.
//       NaN (Double) --> NaN (Single)
//
//       Unable to convert Infinity to Int64.
//       Unable to convert Infinity to UInt64.
//       Unable to convert Infinity to Decimal.
//       Infinity (Double) --> Infinity (Single)
//
//       Unable to convert -Infinity to Int64.
//       Unable to convert -Infinity to UInt64.
//       Unable to convert -Infinity to Decimal.
//       -Infinity (Double) --> -Infinity (Single)
// The example displays the following output for conversions performed
// in an unchecked context:
//       -1.79769313486232E+308 (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       -1.79769313486232E+308 (Double) --> 9223372036854775808 (0x8000000000000000) (UInt64)
//       Unable to convert -1.79769313486232E+308 to Decimal.
//       -1.79769313486232E+308 (Double) --> -Infinity (Single)
//
//       -67890.1234 (Double) --> -67890 (0xFFFFFFFFFFFEF6CE) (Int64)
//       -67890.1234 (Double) --> 18446744073709483726 (0xFFFFFFFFFFFEF6CE) (UInt64)
//       -67890.1234 (Double) --> -67890.1234 (Decimal)
//       -67890.1234 (Double) --> -67890.13 (Single)
//
//       -12345.6789 (Double) --> -12345 (0xFFFFFFFFFFFFCFC7) (Int64)
//       -12345.6789 (Double) --> 18446744073709539271 (0xFFFFFFFFFFFFCFC7) (UInt64)
//       -12345.6789 (Double) --> -12345.6789 (Decimal)
//       -12345.6789 (Double) --> -12345.68 (Single)
//
//       12345.6789 (Double) --> 12345 (0x0000000000003039) (Int64)
//       12345.6789 (Double) --> 12345 (0x0000000000003039) (UInt64)
//       12345.6789 (Double) --> 12345.6789 (Decimal)
//       12345.6789 (Double) --> 12345.68 (Single)
//
//       67890.1234 (Double) --> 67890 (0x0000000000010932) (Int64)
//       67890.1234 (Double) --> 67890 (0x0000000000010932) (UInt64)
//       67890.1234 (Double) --> 67890.1234 (Decimal)
//       67890.1234 (Double) --> 67890.13 (Single)
//
//       1.79769313486232E+308 (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       1.79769313486232E+308 (Double) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert 1.79769313486232E+308 to Decimal.
//       1.79769313486232E+308 (Double) --> Infinity (Single)
//
//       NaN (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       NaN (Double) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert NaN to Decimal.
//       NaN (Double) --> NaN (Single)
//
//       Infinity (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       Infinity (Double) --> 0 (0x0000000000000000) (UInt64)
//       Unable to convert Infinity to Decimal.
//       Infinity (Double) --> Infinity (Single)
//
//       -Infinity (Double) --> -9223372036854775808 (0x8000000000000000) (Int64)
//       -Infinity (Double) --> 9223372036854775808 (0x8000000000000000) (UInt64)
//       Unable to convert -Infinity to Decimal.
//       -Infinity (Double) --> -Infinity (Single)
// </Snippet21>