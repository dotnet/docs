// <Snippet9>
using System;

public class Example3
{
    public static void Main()
    {
        Random2 rnd = new Random2();
        Byte[] bytes = new Byte[10000];
        int[] total = new int[101];
        rnd.NextBytes(bytes, 0, 101);

        // Calculate how many of each value we have.
        foreach (var value in bytes)
            total[value]++;

        // Display the results.
        for (int ctr = 0; ctr < total.Length; ctr++)
        {
            Console.Write("{0,3}: {1,-3}   ", ctr, total[ctr]);
            if ((ctr + 1) % 5 == 0) Console.WriteLine();
        }
    }
}

public class Random2 : Random
{
    public Random2() : base()
    { }

    public Random2(int seed) : base(seed)
    { }

    public void NextBytes(byte[] bytes, byte minValue, byte maxValue)
    {
        for (int ctr = bytes.GetLowerBound(0); ctr <= bytes.GetUpperBound(0); ctr++)
            bytes[ctr] = (byte)Next(minValue, maxValue);
    }
}
// The example displays output like the following:
//         0: 115     1: 119     2: 92      3: 98      4: 92
//         5: 102     6: 103     7: 84      8: 93      9: 116
//        10: 91     11: 98     12: 106    13: 91     14: 92
//        15: 101    16: 100    17: 96     18: 97     19: 100
//        20: 101    21: 106    22: 112    23: 82     24: 85
//        25: 102    26: 107    27: 98     28: 106    29: 102
//        30: 109    31: 108    32: 94     33: 101    34: 107
//        35: 101    36: 86     37: 100    38: 101    39: 102
//        40: 113    41: 95     42: 96     43: 89     44: 99
//        45: 81     46: 89     47: 105    48: 100    49: 85
//        50: 103    51: 103    52: 93     53: 89     54: 91
//        55: 97     56: 105    57: 97     58: 110    59: 86
//        60: 116    61: 94     62: 117    63: 98     64: 110
//        65: 93     66: 102    67: 100    68: 105    69: 83
//        70: 81     71: 97     72: 85     73: 70     74: 98
//        75: 100    76: 110    77: 114    78: 83     79: 90
//        80: 96     81: 112    82: 102    83: 102    84: 99
//        85: 81     86: 100    87: 93     88: 99     89: 118
//        90: 95     91: 124    92: 108    93: 96     94: 104
//        95: 106    96: 99     97: 99     98: 92     99: 99
//       100: 108
// </Snippet9>
