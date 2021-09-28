﻿using System;
using System.Runtime.InteropServices;

//<Snippet31>
// Declares a managed structure for each unmanaged structure.
[StructLayout(LayoutKind.Sequential)]
public struct MyPoint
{
    public int X;
    public int Y;

    public MyPoint(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MyPerson
{
    public string First;
    public string Last;

    public MyPerson(string first, string last)
    {
        this.First = first;
        this.Last = last;
    }
}

internal static class NativeMethods
{
    // Declares a managed prototype for an array of integers by value.
    // The array size cannot be changed, but the array is copied back.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfInts(
        [In, Out] int[] array, int size);

    // Declares a managed prototype for an array of integers by reference.
    // The array size can change, but the array is not copied back
    // automatically because the marshaler does not know the resulting size.
    // The copy must be performed manually.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestRefArrayOfInts(
        ref IntPtr array, ref int size);

    // Declares a managed prototype for a matrix of integers by value.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestMatrixOfInts(
        [In, Out] int[,] pMatrix, int row);

    // Declares a managed prototype for an array of strings by value.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfstrings(
        [In, Out] string[] stringArray, int size);

    // Declares a managed prototype for an array of structures with integers.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfStructs(
        [In, Out] MyPoint[] pointArray, int size);

    // Declares a managed prototype for an array of structures with strings.
    [DllImport("..\\LIB\\PinvokeLib.dll", CallingConvention = CallingConvention.Cdecl)]
    internal static extern int TestArrayOfStructs2(
        [In, Out] MyPerson[] personArray, int size);
}
//</Snippet31>

//<Snippet32>
public class App
{
    public static void Main()
    {
        // array ByVal
        int[] array1 = new int[10];
        Console.WriteLine("Integer array passed ByVal before call:");
        for (int i = 0; i < array1.Length; i++)
        {
            array1[i] = i;
            Console.Write(" " + array1[i]);
        }

        int sum1 = NativeMethods.TestArrayOfInts(array1, array1.Length);
        Console.WriteLine("\nSum of elements:" + sum1);
        Console.WriteLine("\nInteger array passed ByVal after call:");

        foreach (int i in array1)
        {
            Console.Write(" " + i);
        }

        // array ByRef
        int[] array2 = new int[10];
        int size = array2.Length;
        Console.WriteLine("\n\nInteger array passed ByRef before call:");
        for (int i = 0; i < array2.Length; i++)
        {
            array2[i] = i;
            Console.Write(" " + array2[i]);
        }

        IntPtr buffer = Marshal.AllocCoTaskMem(Marshal.SizeOf(size)
           * array2.Length);
        Marshal.Copy(array2, 0, buffer, array2.Length);

        int sum2 = NativeMethods.TestRefArrayOfInts(ref buffer, ref size);
        Console.WriteLine("\nSum of elements:" + sum2);
        if (size > 0)
        {
            int[] arrayRes = new int[size];
            Marshal.Copy(buffer, arrayRes, 0, size);
            Marshal.FreeCoTaskMem(buffer);
            Console.WriteLine("\nInteger array passed ByRef after call:");
            foreach (int i in arrayRes)
            {
                Console.Write(" " + i);
            }
        }
        else
        {
            Console.WriteLine("\nArray after call is empty");
        }

        // matrix ByVal
        const int DIM = 5;
        int[,] matrix = new int[DIM, DIM];

        Console.WriteLine("\n\nMatrix before call:");
        for (int i = 0; i < DIM; i++)
        {
            for (int j = 0; j < DIM; j++)
            {
                matrix[i, j] = j;
                Console.Write(" " + matrix[i, j]);
            }

            Console.WriteLine("");
        }

        int sum3 = NativeMethods.TestMatrixOfInts(matrix, DIM);
        Console.WriteLine("\nSum of elements:" + sum3);
        Console.WriteLine("\nMatrix after call:");
        for (int i = 0; i < DIM; i++)
        {
            for (int j = 0; j < DIM; j++)
            {
                Console.Write(" " + matrix[i, j]);
            }

            Console.WriteLine("");
        }

        // string array ByVal
        string[] strArray = { "one", "two", "three", "four", "five" };
        Console.WriteLine("\n\nstring array before call:");
        foreach (string s in strArray)
        {
            Console.Write(" " + s);
        }

        int lenSum = NativeMethods.TestArrayOfstrings(strArray, strArray.Length);
        Console.WriteLine("\nSum of string lengths:" + lenSum);
        Console.WriteLine("\nstring array after call:");
        foreach (string s in strArray)
        {
            Console.Write(" " + s);
        }

        // struct array ByVal
        MyPoint[] points = { new MyPoint(1, 1), new MyPoint(2, 2), new MyPoint(3, 3) };
        Console.WriteLine("\n\nPoints array before call:");
        foreach (MyPoint p in points)
        {
            Console.WriteLine($"X = {p.X}, Y = {p.Y}");
        }

        int allSum = NativeMethods.TestArrayOfStructs(points, points.Length);
        Console.WriteLine("\nSum of points:" + allSum);
        Console.WriteLine("\nPoints array after call:");
        foreach (MyPoint p in points)
        {
            Console.WriteLine($"X = {p.X}, Y = {p.Y}");
        }

        // struct with strings array ByVal
        MyPerson[] persons =
        {
            new MyPerson("Kim", "Akers"),
            new MyPerson("Adam", "Barr"),
            new MyPerson("Jo", "Brown")
        };

        Console.WriteLine("\n\nPersons array before call:");
        foreach (MyPerson pe in persons)
        {
            Console.WriteLine($"First = {pe.First}, Last = {pe.Last}");
        }

        int namesSum = NativeMethods.TestArrayOfStructs2(persons, persons.Length);
        Console.WriteLine("\nSum of name lengths:" + namesSum);
        Console.WriteLine("\n\nPersons array after call:");
        foreach (MyPerson pe in persons)
        {
            Console.WriteLine($"First = {pe.First}, Last = {pe.Last}");
        }
    }
}
//</Snippet32>
