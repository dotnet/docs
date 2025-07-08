using System;
using System.Threading.Tasks;
using MethodParameters;

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
            Console.WriteLine("=================    pass by value / reference Keyword Examples ======================");
            PassTypesByValue.TestPassTypesByValue();
            Console.WriteLine("====");
            PassTypesByReference.TestPassTypesByReference();
            Console.WriteLine("====");
            PassByValueReassignment.TestPassByValueReassignment();
            Console.WriteLine("====");
            PassByReferenceReassignment.TestPassByReferenceReassignment();
            Console.WriteLine("====");
            ParameterModifiers.ParamPassingExamples();
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
