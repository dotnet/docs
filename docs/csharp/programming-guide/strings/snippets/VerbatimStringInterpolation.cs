using System;

namespace StringExamples;
public static class VerbatimInterpolation
{
    public static void VerbatimInterpolationExample()
    {
        // <VerbatimStringInterpolation>
        var jh = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
        Console.WriteLine($@"{jh.firstName} {jh.lastName}
            was an African American poet born in {jh.born}.");
        Console.WriteLine(@$"He was first published in {jh.published}
        at the age of {jh.published - jh.born}.");

        // Output:
        // Jupiter Hammon
        //     was an African American poet born in 1711.
        // He was first published in 1761
        // at the age of 50.
        // </VerbatimStringInterpolation>
    }
}
