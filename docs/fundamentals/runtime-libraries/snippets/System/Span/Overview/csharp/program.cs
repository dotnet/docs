﻿using System;
using System.Runtime.InteropServices;
using static Program2;

class Program
{
    static void Main()
    {
        CreateSpanFromArray();
        Console.WriteLine("-----");
        CreateSpanFromNativeMemory();
        Console.WriteLine("-----");
        CreateSpanFromStack();
        WorkWithSpans();
        Console.WriteLine("-----");
        Program2.WorkWithSpans();
    }

    private static void CreateSpanFromArray()
    {
        // <Snippet1>
        // Create a span over an array.
        var array = new byte[100];
        var arraySpan = new Span<byte>(array);

        byte data = 0;
        for (int ctr = 0; ctr < arraySpan.Length; ctr++)
            arraySpan[ctr] = data++;

        int arraySum = 0;
        foreach (var value in array)
            arraySum += value;

        Console.WriteLine($"The sum is {arraySum}");
        // Output:  The sum is 4950
        // </Snippet1>
    }

    private static void CreateSpanFromNativeMemory()
    {
        // <Snippet2>
        // Create a span from native memory.
        var native = Marshal.AllocHGlobal(100);
        Span<byte> nativeSpan;
        unsafe
        {
            nativeSpan = new Span<byte>(native.ToPointer(), 100);
        }
        byte data = 0;
        for (int ctr = 0; ctr < nativeSpan.Length; ctr++)
            nativeSpan[ctr] = data++;

        int nativeSum = 0;
        foreach (var value in nativeSpan)
            nativeSum += value;

        Console.WriteLine($"The sum is {nativeSum}");
        Marshal.FreeHGlobal(native);
        // Output:  The sum is 4950
        // </Snippet2>
    }

    private static void CreateSpanFromStack()
    {
        // <Snippet3>
        // Create a span on the stack.
        byte data = 0;
        Span<byte> stackSpan = stackalloc byte[100];
        for (int ctr = 0; ctr < stackSpan.Length; ctr++)
            stackSpan[ctr] = data++;

        int stackSum = 0;
        foreach (var value in stackSpan)
            stackSum += value;

        Console.WriteLine($"The sum is {stackSum}");
        // Output:  The sum is 4950
        // </Snippet3>
    }
}

public class Program2
{
    // <Snippet4>
    public static void WorkWithSpans()
    {
        // Create a span over an array.
        var array = new byte[100];
        var arraySpan = new Span<byte>(array);

        InitializeSpan(arraySpan);
        Console.WriteLine($"The sum is {ComputeSum(arraySpan):N0}");

        // Create an array from native memory.
        var native = Marshal.AllocHGlobal(100);
        Span<byte> nativeSpan;
        unsafe
        {
            nativeSpan = new Span<byte>(native.ToPointer(), 100);
        }

        InitializeSpan(nativeSpan);
        Console.WriteLine($"The sum is {ComputeSum(nativeSpan):N0}");

        Marshal.FreeHGlobal(native);

        // Create a span on the stack.
        Span<byte> stackSpan = stackalloc byte[100];

        InitializeSpan(stackSpan);
        Console.WriteLine($"The sum is {ComputeSum(stackSpan):N0}");
    }

    public static void InitializeSpan(Span<byte> span)
    {
        byte value = 0;
        for (int ctr = 0; ctr < span.Length; ctr++)
            span[ctr] = value++;
    }

    public static int ComputeSum(Span<byte> span)
    {
        int sum = 0;
        foreach (var value in span)
            sum += value;

        return sum;
    }
    // The example displays the following output:
    //    The sum is 4,950
    //    The sum is 4,950
    //    The sum is 4,950
    // </Snippet4>
}
