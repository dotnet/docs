using System;
using System.Collections.Generic;

namespace ExpressionTreeSamples
{
    public class Program
    {
        private static List<Sample> allSamples = new List<Sample>
        {
            new ExpressionTreeClassesSampleOne(),
            new ExpressionTreeClassesSampleTwo(),
            new ExpressionTreeExecutionSampleOne(),
            new ExpressionTreeExecutionSampleTwo(),
            new ExpressionTreeInterpretingSampleOne(),
            new ExpressionTreeInterpretingSampleTwo(),
            new ExpressionTreeInterpretingSampleThree(),
            new ExpressionTreeInterpretingSampleFour(),
            new ExpressionTreeBuildingSampleOne(),
            new ExpressionTreeBuildingSampleTwo(),
            new ExpressionTreeTranslationSampleOne(),
            new ExpressionTreeTranslationSampleTwo(),
            new ExpressionTreeTranslationSampleThree()
        };
        
        public static void Main(string[] args)
        {
            foreach (var sample in allSamples)
            {
                Console.WriteLine("==========          ==========          ==========          ==========");
                Console.WriteLine($"Running Sample {sample.Name}");
                sample.Run();
            }
        }
    }
}
