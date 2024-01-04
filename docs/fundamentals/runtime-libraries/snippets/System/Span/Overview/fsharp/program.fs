open System
open System.Runtime.InteropServices

let createSpanFromArray () =
    // <Snippet1>
    // Create a span over an array.
    let array = Array.zeroCreate<byte> 100
    let arraySpan = Span<byte> array

    let mutable data = 0uy
    for i = 0 to arraySpan.Length - 1 do
        arraySpan[i] <- data
        data <- data + 1uy

    let mutable arraySum = 0
    for value in array do
        arraySum <- arraySum + int value

    printfn $"The sum is {arraySum}"
    // Output:  The sum is 4950
    // </Snippet1>

let createSpanFromNativeMemory () =
    // <Snippet2>
    // Create a span from native memory.
    let native = Marshal.AllocHGlobal 100
    let nativeSpan = Span<byte>(native.ToPointer(), 100)

    let mutable data = 0uy
    for i = 0 to nativeSpan.Length - 1 do
        nativeSpan[i] <- data
        data <- data + 1uy

    let mutable nativeSum = 0
    for value in nativeSpan do
        nativeSum <- nativeSum + int value

    printfn $"The sum is {nativeSum}"
    Marshal.FreeHGlobal native
    // Output:  The sum is 4950
    // </Snippet2>

let createSpanFromStack () =
    // <Snippet3>
    // Create a span on the stack.
    let mutable data = 0uy
    let stackSpan = 
        let p = NativeInterop.NativePtr.stackalloc<byte> 100 |> NativeInterop.NativePtr.toVoidPtr
        Span<byte>(p, 100)

    for i = 0 to stackSpan.Length - 1 do
        stackSpan[i] <- data
        data <- data + 1uy

    let mutable stackSum = 0
    for value in stackSpan do
        stackSum <- stackSum + int value

    printfn $"The sum is {stackSum}"
// Output:  The sum is 4950
// </Snippet3>

module Program2 =
    // <Snippet4>
    open System
    open System.Runtime.InteropServices
    open FSharp.NativeInterop

    // Package FSharp.NativeInterop.NativePtr.stackalloc for reuse.
    let inline stackalloc<'a when 'a: unmanaged> length : Span<'a> =
        let voidPointer = NativePtr.stackalloc<'a> length |> NativePtr.toVoidPtr
        Span<'a>(voidPointer, length)

    let initializeSpan (span: Span<byte>) =
        let mutable value = 0uy
        for i = 0 to span.Length - 1 do
            span[i] <- value
            value <- value + 1uy

    let computeSum (span: Span<byte>) =
        let mutable sum = 0
        for value in span do
            sum <- sum + int value
        sum

    let workWithSpans () =
        // Create a span over an array.
        let array = Array.zeroCreate<byte> 100
        let arraySpan = Span<byte> array

        initializeSpan arraySpan
        printfn $"The sum is {computeSum arraySpan:N0}"

        // Create an array from native memory.
        let native = Marshal.AllocHGlobal 100
        let nativeSpan = Span<byte>(native.ToPointer(), 100)

        initializeSpan nativeSpan
        printfn $"The sum is {computeSum nativeSpan:N0}"

        Marshal.FreeHGlobal native

        // Create a span on the stack.
        let stackSpan = stackalloc 100

        initializeSpan stackSpan
        printfn $"The sum is {computeSum stackSpan:N0}"

    // The example displays the following output:
    //    The sum is 4,950
    //    The sum is 4,950
    //    The sum is 4,950
    // </Snippet4>

createSpanFromArray ()
printfn "-----"
createSpanFromNativeMemory ()
printfn "-----"
createSpanFromStack ()
printfn "-----"
Program2.workWithSpans ()
