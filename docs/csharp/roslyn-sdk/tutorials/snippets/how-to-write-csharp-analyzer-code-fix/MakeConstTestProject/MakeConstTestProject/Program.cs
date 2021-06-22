using System;

namespace MakeConstTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            int j = 2;
            int k = i + j;

            // uncomment for analyzer test:
            //int x = "abc";

            object s = "abc";

            string s2 = "abc";

            var item = "xyz";
        }
    }
}
