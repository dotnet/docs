using System;
using System.Data;
using System.Data.Common;

namespace ConBuilderEquivalentToCS
{
    class Program
    {
        // <Snippet1>
        static void Main()
        {
            DbConnectionStringBuilder builder1 =
                new DbConnectionStringBuilder();
            builder1.ConnectionString =
                "Value1=SomeValue;Value2=20;Value3=30;Value4=40";
            Console.WriteLine("builder1 = " + builder1.ConnectionString);

            DbConnectionStringBuilder builder2 =
                new DbConnectionStringBuilder();
            builder2.ConnectionString =
                "value2=20;value3=30;VALUE4=40;Value1=SomeValue";
            Console.WriteLine("builder2 = " + builder2.ConnectionString);

            DbConnectionStringBuilder builder3 =
                new DbConnectionStringBuilder();
            builder3.ConnectionString =
                "value2=20;value3=30;VALUE4=40;Value1=SOMEVALUE";
            Console.WriteLine("builder3 = " + builder3.ConnectionString);

            // builder1 and builder2 contain the same
            // keys and values, in different order, and the 
            // keys are not consistently cased. They are equivalent.
            Console.WriteLine("builder1.EquivalentTo(builder2) = " +
                builder1.EquivalentTo(builder2).ToString());

            // builder2 and builder3 contain the same key/value pairs in the 
            // the same order, but the value casing is different, so they're
            // not equivalent.
            Console.WriteLine("builder2.EquivalentTo(builder3) = " +
                builder2.EquivalentTo(builder3).ToString());

            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
        // </Snippet1>
    }
}
