module NDP_UE_FS

//<Snippet1>
// Example for the Exception.HelpLink, Exception.Source,
// Exception.StackTrace, and Exception.TargetSite properties.
open System
        
let overflowMessage = "The log table has overflowed."

// Derive an exception; the constructor sets the HelpLink and
// Source properties.
type LogTableOverflowException(auxMessage, inner) as this =
    inherit Exception($"%s{overflowMessage} - %s{auxMessage}", inner)

    do
        this.HelpLink <- "https://docs.microsoft.com"
        this.Source <- "Exception_Class_Samples"

type LogTable(numElements) =
    let logArea = Array.zeroCreate<string> numElements
    let mutable elemInUse = 0

    // The AddRecord method throws a derived exception if
    // the array bounds exception is caught.
    member this.AddRecord(newRecord) =
        try
            logArea[elemInUse] <- newRecord
            elemInUse <- elemInUse + 1
            elemInUse - 1 
        with e ->
            raise (LogTableOverflowException($"Record \"{newRecord}\" was not logged.", e) )

// Create a log table and force an overflow.
let log = LogTable 4 

printfn
    """This example of
   Exception.Message, 
   Exception.HelpLink, 
   Exception.Source, 
   Exception.StackTrace, and
   Exception.TargetSite 
   generates the following output."""

try
    for count = 1 to 1000000 do
        log.AddRecord $"Log record number {count}"
        |> ignore
with ex ->
    printfn $"\nMessage ---\n{ex.Message}"
    printfn $"\nHelpLink ---\n{ex.HelpLink}"
    printfn $"\nSource ---\n{ex.Source}"
    printfn $"\nStackTrace ---\n{ex.StackTrace}"
    printfn $"\nTargetSite ---\n{ex.TargetSite}"

// This example of
//    Exception.Message,
//    Exception.HelpLink,
//    Exception.Source,
//    Exception.StackTrace, and
//    Exception.TargetSite
// generates the following output.

// Message ---
// The log table has overflowed. - Record "Log record number 5" was not logged.

// HelpLink ---
// https://docs.microsoft.com

// Source ---
// Exception_Class_Samples

// StackTrace ---
//    at NDP_UE_FS.LogTable.AddRecord(String newRecord)
//    at <StartupCode$fs>.$NDP_UE_FS.main@()

// TargetSite ---
// Int32 AddRecord(System.String)
//</Snippet1>