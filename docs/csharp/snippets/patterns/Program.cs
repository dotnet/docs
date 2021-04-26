using System;

namespace patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            NullCheck();

            NullReferenceCheck();

            TypeCheckDisposable();
        }

        private static void TypeCheckDisposable()
        {
            object? heldReference = default;

            // <TypeCheckDisposable>
            if (heldReference is IDisposable disposable)
            {
                disposable.Dispose();
            }
            heldReference = null;
            // </TypeCheckDisposable>
        }

        private static void NullReferenceCheck()
        {
            // <NullReferenceCheck>
            string? message = "This is not the null string";

            if (message is not null)
            {
                Console.WriteLine(message);
            }
            // </NullReferenceCheck>
        }


        private static void NullCheck()
        {
            // <NullableCheck>
            int? maybe = 12;

            if (maybe is int number)
            {
                Console.WriteLine($"The nullable int 'maybe' has the value {number}");
            }
            else
            {
                Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
            }
            // </NullableCheck>
        }
    }
}
