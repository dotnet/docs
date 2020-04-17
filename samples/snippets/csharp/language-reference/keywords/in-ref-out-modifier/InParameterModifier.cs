using System;
using System.Collections.Generic;
using System.Text;

namespace InRefOutModifier
{
    public class InParameterModifier
    {

        public static void Examples()
        {
            FirstInExample();
        }
        private static void FirstInExample()
        {
            // <Snippet1>
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            Console.WriteLine(readonlyArgument);     // value is still 44

            void InArgExample(in int number)
            {
                // Uncomment the following line to see error CS8331
                //number = 19;
            }
            // </Snippet1>
        }
    }

    // <Snippet2>
    class InOverloadExample
    {
        public void SampleMethod(int i) { }
        public void SampleMethod(in int i) { }
    }
    // </Snippet2>
}
