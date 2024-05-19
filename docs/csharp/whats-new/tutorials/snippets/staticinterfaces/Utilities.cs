﻿using System.Numerics;

public static class Utilities
{
    // <MidPoint>
    public static T MidPoint<T>(T left, T right)
        where T : INumber<T> => (left + right) / T.CreateChecked(2);  // note: the addition of left and right may overflow here; it's just for demonstration purposes
    // </MidPoint>
}
