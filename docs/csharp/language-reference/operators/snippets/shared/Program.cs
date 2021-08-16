using System;
using System.Threading.Tasks;

namespace operators
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("============== Overview ========================");
            Overview.Examples();
            Console.WriteLine();

            Console.WriteLine("======== Arithmetic operators examples =========");
            ArithmeticOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("============= == and != operators examples =====");
            EqualityOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("======== Logical operators examples ============");
            BooleanLogicalOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("==== Bitwise and shift operators examples ======");
            BitwiseAndShiftOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("====== >, <, >=, and <= operators examples =====");
            ComparisonOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("========= Member access operators examples =====");
            MemberAccessOperators.Examples();
            MemberAccessOperators2.NullConditionalShortCircuiting.Main();
            Console.WriteLine();

            Console.WriteLine("======= Pointer related operators examples =====");
            PointerOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("= Type-testing and conversion operators examples");
            TypeTestingAndConversionOperators.Examples();
            Console.WriteLine();

            Console.WriteLine("============== = operator examples =============");
            AssignmentOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("============== + operator examples =============");
            AdditionOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("============== - operator examples =============");
            SubtractionOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("============== ?: operator examples ============");
            ConditionalOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("========== ?? and ??= operators examples =======");
            NullCoalescingOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("============== => operator examples ============");
            LambdaOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("=============== await operator examples ========");
            await AwaitOperator.Main();
            Console.WriteLine();

            Console.WriteLine("=========== default operator examples ==========");
            DefaultOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("========== delegate operator examples ==========");
            DelegateOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("=========== nameof operator examples ===========");
            NameOfOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("============= new operator examples ============");
            NewOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("=============== sizeof operator examples =======");
            SizeOfOperator.Main();
            Console.WriteLine();

            Console.WriteLine("============ stackalloc operator examples ======");
            StackallocOperator.Examples();
            Console.WriteLine();

            Console.WriteLine("========= true and false operators examples ====");
            LaunchStatusTest.Main();
            Console.WriteLine();

            Console.WriteLine("========= operator overloading example =========");
            OperatorOverloading.Main();
            Console.WriteLine();

            Console.WriteLine("========= conversion operators example =========");
            UserDefinedConversions.Main();
            Console.WriteLine();

            Console.WriteLine("========= switch expression example ============");
            SwitchExpressions.Examples();
            Console.WriteLine();

            Console.WriteLine("============= is operator example ==============");
            IsOperator.Examples();
            Console.WriteLine();
        }
    }
}
