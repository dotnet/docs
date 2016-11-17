    class SimpleStringTest 
    {
       static void Main()
       {
          string a = "\u0068ello ";
          string b = "world";
          Console.WriteLine( a + b );
          Console.WriteLine( a + b == "Hello World" ); // == performs a case-sensitive comparison
       }
    }
    /* Output:
        hello world
        False
     */