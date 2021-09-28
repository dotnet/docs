﻿using System;

namespace RangesIndexes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========          Starting Index and Range Samples.          ==========");
            var indexSamples = new IndicesAndRanges();
            Console.WriteLine("          ==========          Last Index.            ==========");
            indexSamples.Syntax_LastIndex();
            Console.WriteLine("          ==========          Range.                 ==========");
            indexSamples.Syntax_Range();
            Console.WriteLine("          ==========          Last Range.            ==========");
            indexSamples.Syntax_LastRange();
            Console.WriteLine("          ==========          Partial Range.         ==========");
            indexSamples.Syntax_PartialRange();
            Console.WriteLine("          ==========          Index and Range types. ==========");
            indexSamples.Syntax_IndexRangeType();
            Console.WriteLine("          ==========          Why this syntax.       ==========");
            indexSamples.Syntax_WhyChosenSemantics();
            Console.WriteLine("          ==========          Scenario.              ==========");
            indexSamples.ComputeMovingAverages();
            Console.WriteLine("          ==========          Jageged arrays.        ==========");
            indexSamples.JaggedArrays();
        }
    }
}
