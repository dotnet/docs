    static int DivideByTwo(int num) 
    {
        // If num is an odd number, throw an ArgumentException.
        if ((num & 1) == 1)
            throw new ArgumentException("Number must be even", "num");

        // num is even, return half of its value.
        return num / 2;
    }