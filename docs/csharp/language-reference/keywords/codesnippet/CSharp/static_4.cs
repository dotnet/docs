    class Test
    {
       static int x = y;
       static int y = 5;

       static void Main()
       {
          Console.WriteLine(Test.x);
          Console.WriteLine(Test.y);

          Test.x = 99;
          Console.WriteLine(Test.x);
       }
    }
    /*
    Output:
        0
        5
        99
    */