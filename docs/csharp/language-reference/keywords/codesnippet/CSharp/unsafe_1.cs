    // compile with: /unsafe

    class UnsafeTest
    {
       // Unsafe method: takes pointer to int:
       unsafe static void SquarePtrParam(int* p)
       {
          *p *= *p;
       }

       unsafe static void Main()
       {
          int i = 5;
          // Unsafe method: uses address-of operator (&):
          SquarePtrParam(&i);
          Console.WriteLine(i);
       }
    }
    // Output: 25
