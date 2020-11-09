using System;

namespace with_expression
{
    class Program
    {
        static void Main(string[] args)
        {
            WithExpressionBasicExample.Main();
            Console.WriteLine();
            ExampleWithReferenceType.Main();
            Console.WriteLine();
            UserDefinedCopyConstructorExample.Main();
        }
    }
}
