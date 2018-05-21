
namespace AccessibilityDomainNamespace
{
    public class T1
    {
        public static int publicInt;
        internal static int internalInt;
        private static int privateInt = 0;
        static T1()
        {
            // T1 can access public or internal members
            // in a public or private (or internal) nested class
            M1.publicInt = 1;
            M1.internalInt = 2;
            M2.publicInt = 3;
            M2.internalInt = 4;

            // Cannot access the private member privateInt
            // in either class:
            // M1.privateInt = 2; //CS0122
        }

        public class M1
        {
            public static int publicInt;
            internal static int internalInt;
            private static int privateInt = 0;
        }

        private class M2
        {
            public static int publicInt = 0;
            internal static int internalInt = 0;
            private static int privateInt = 0;
        }
    }

    class MainClass
    {
        static void Main()
        {
            // Access is unlimited:
            T1.publicInt = 1;

            // Accessible only in current assembly:
            T1.internalInt = 2;

            // Error CS0122: inaccessible outside T1:
            // T1.privateInt = 3;  

            // Access is unlimited:
            T1.M1.publicInt = 1;

            // Accessible only in current assembly:
            T1.M1.internalInt = 2;

            // Error CS0122: inaccessible outside M1:
            //    T1.M1.privateInt = 3; 

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.publicInt = 1;

            // Error CS0122: inaccessible outside T1:
            //    T1.M2.internalInt = 2;

            // Error CS0122: inaccessible outside M2:
            //    T1.M2.privateInt = 3;



            // Keep the console open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}