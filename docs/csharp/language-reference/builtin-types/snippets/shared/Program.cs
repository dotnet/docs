using System;

namespace builtin_types
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("======== Unmanaged types =========");
            UnmanagedTypes.Main();
            Console.WriteLine();

            Console.WriteLine("====== Nullable value types ======");
            NullableValueTypes.Examples();
            Console.WriteLine();

            Console.WriteLine("============ char type ===========");
            CharType.Examples();
            Console.WriteLine();

            Console.WriteLine("============ bool type ===========");
            BoolType.Examples();
            Console.WriteLine();

            Console.WriteLine("========= Enumeration types ======");
            EnumType.Examples();
            Console.WriteLine();

            Console.WriteLine("============ Value types =========");
            ValueTypes.Examples();
            Console.WriteLine();

            Console.WriteLine("============= void type ==========");
            VoidType.Examples();
            Console.WriteLine();

            Console.WriteLine("========== Structure types =======");
            StructType.Examples();
            Console.WriteLine();

            Console.WriteLine("========== Records ===============");
            RecordType.Examples();
            Console.WriteLine();

            Console.WriteLine("===== Nullable reference types ===");
            NullableReferenceTypes.Examples();
            Console.WriteLine();

            Console.WriteLine("=========== Value tuples =========");
            ValueTuples.Examples();
            Console.WriteLine();

            Console.WriteLine("====== Native integer types ======");
            NativeIntegerTypes.Examples();
            Console.WriteLine();
        }
    }
}
