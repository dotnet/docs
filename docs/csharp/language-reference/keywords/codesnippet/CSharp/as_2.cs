    class ClassA { }
    class ClassB { }

    class MainClass
    {
        static void Main()
        {
            object[] objArray = new object[6];
            objArray[0] = new ClassA();
            objArray[1] = new ClassB();
            objArray[2] = "hello";
            objArray[3] = 123;
            objArray[4] = 123.4;
            objArray[5] = null;

            for (int i = 0; i < objArray.Length; ++i)
            {
                string s = objArray[i] as string;
                Console.Write("{0}:", i);
                if (s != null)
                {
                    Console.WriteLine("'" + s + "'");
                }
                else
                {
                    Console.WriteLine("not a string");
                }
            }
        }
    }
    /*
    Output:
    0:not a string
    1:not a string
    2:'hello'
    3:not a string
    4:not a string
    5:not a string
    */