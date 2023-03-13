using System;
using System.Threading.Tasks;

namespace Keywords
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=================    Generic Where Constraints Examples ======================");
            GenericWhereConstraints.Examples();
            Console.WriteLine("=================    readonly Keyword Examples ======================");
            ReadonlyKeywordExamples.Examples();
            Console.WriteLine("=================    try-catch Keyword Examples ======================");
            await AsyncExceptionExamples.Examples();
            Console.WriteLine("=================    pass by value / reference Keyword Examples ======================");
            TestClassAndStruct.Main();
            ParameterModifiers.PassValueByValue();
            ParameterModifiers.PassingValueByReference();
            ParameterModifiers.PassingReferenceByValue();
            ParameterModifiers.PassingReferenceByReference();

        }
    }

    // <ShadowsFileScopedType>
    // In File2.cs:
    // Doesn't conflict with HiddenWidget
    // declared in File1.cs
    public class HiddenWidget
    {
        public void RunTask()
        {
            // omitted
        }
    }
    // </ShadowsFileScopedType>
}
