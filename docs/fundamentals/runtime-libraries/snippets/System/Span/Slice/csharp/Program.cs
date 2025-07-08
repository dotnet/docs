using System;

var array = new int[] { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };
var slice = new Span<int>(array, 2, 5);
for (int ctr = 0; ctr < slice.Length; ctr++)
    slice[ctr] *= 2;

// Examine the original array values.
foreach (var value in array)
    Console.Write($"{value}  ");
Console.WriteLine();

// The example displays the following output:
//      2  4  12  16  20  24  28  16  18  20
