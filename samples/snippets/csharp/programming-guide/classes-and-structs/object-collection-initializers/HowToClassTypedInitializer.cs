using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace object_collection_initializers
{
    // <SnippetHowToClassTypedInitializer>
    public class HowToClassTypedInitializer
    {
        public class EmbeddedClassTypeA
        {
            public int I { get; set; }
            public bool B { get; set; }
            public string S { get; set; }
            public EmbeddedClassTypeB ClassB { get; set; }

            public override string ToString() => $"{I}|{B}|{S}|||{ClassB}";

            public EmbeddedClassTypeA()
            {
                I = 3;
                B = true;
                S = "abc";
                ClassB = new() { BB = true, BI = 43 };
            }
        }

        public class EmbeddedClassTypeB
        {
            public int BI { get; set; }
            public bool BB { get; set; }
            public string BS { get; set; }

            public override string ToString() => $"{BI}|{BB}|{BS}";

            public EmbeddedClassTypeB()
            {
                BI = 23;
                BB = false;
                BS = "BBBabc";
            }
        }

        public static void Main()
        {
            var a = new EmbeddedClassTypeA
            {
                I = 103,
                B = false,
                ClassB = { BI = 100003 }
            };
            Console.WriteLine(a);

            var a2 = new EmbeddedClassTypeA
            {
                I = 103,
                B = false,
                ClassB = new() { BI = 100003 } //New instance
            };
            Console.WriteLine(a2);
        }

        // Output:
        //103|False|abc|||100003|True|BBBabc
        //103|False|abc|||100003|False|BBBabc
    }

    // </SnippetHowToClassTypedInitializer>
}
