    namespace TestReferenceEquality
    {
        struct TestStruct
        {
            public int Num { get; private set; }
            public string Name { get; private set; }

            public TestStruct(int i, string s) : this()
            {
                Num = i;
                Name = s;
            }
        }

        class TestClass
        {
            public int Num { get; set; }
            public string Name { get; set; }
        }

        class Program
        {
            static void Main()
            {
                // Demonstrate reference equality with reference types.
                #region ReferenceTypes

                // Create two reference type instances that have identical values.
                TestClass tcA = new TestClass() { Num = 1, Name = "New TestClass" };
                TestClass tcB = new TestClass() { Num = 1, Name = "New TestClass" };

                Console.WriteLine("ReferenceEquals(tcA, tcB) = {0}",
                                    Object.ReferenceEquals(tcA, tcB)); // false

                // After assignment, tcB and tcA refer to the same object. 
                // They now have reference equality. 
                tcB = tcA;
                Console.WriteLine("After asignment: ReferenceEquals(tcA, tcB) = {0}",
                                    Object.ReferenceEquals(tcA, tcB)); // true

                // Changes made to tcA are reflected in tcB. Therefore, objects
                // that have reference equality also have value equality.
                tcA.Num = 42;
                tcA.Name = "TestClass 42";
                Console.WriteLine("tcB.Name = {0} tcB.Num: {1}", tcB.Name, tcB.Num);
                #endregion

                // Demonstrate that two value type instances never have reference equality.
                #region ValueTypes

                TestStruct tsC = new TestStruct( 1, "TestStruct 1");

                // Value types are copied on assignment. tsD and tsC have 
                // the same values but are not the same object.
                TestStruct tsD = tsC;
                Console.WriteLine("After asignment: ReferenceEquals(tsC, tsD) = {0}",
                                    Object.ReferenceEquals(tsC, tsD)); // false
                #endregion

                #region stringRefEquality
                // Constant strings within the same assembly are always interned by the runtime.
                // This means they are stored in the same location in memory. Therefore, 
                // the two strings have reference equality although no assignment takes place.
                string strA = "Hello world!";
                string strB = "Hello world!";
                Console.WriteLine("ReferenceEquals(strA, strB) = {0}",
                                 Object.ReferenceEquals(strA, strB)); // true

                // After a new string is assigned to strA, strA and strB
                // are no longer interned and no longer have reference equality.
                strA = "Goodbye world!";
                Console.WriteLine("strA = \"{0}\" strB = \"{1}\"", strA, strB);
                
                Console.WriteLine("After strA changes, ReferenceEquals(strA, strB) = {0}",
                                Object.ReferenceEquals(strA, strB)); // false
                
                // A string that is created at runtime cannot be interned.
                StringBuilder sb = new StringBuilder("Hello world!");
                string stringC = sb.ToString(); 
                // False:
                Console.WriteLine("ReferenceEquals(stringC, strB) = {0}",
                                Object.ReferenceEquals(stringC, strB));

                // The string class overloads the == operator to perform an equality comparison.
                Console.WriteLine("stringC == strB = {0}", stringC == strB); // true

                #endregion

                // Keep the console open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }

    /* Output:
        ReferenceEquals(tcA, tcB) = False
        After asignment: ReferenceEquals(tcA, tcB) = True
        tcB.Name = TestClass 42 tcB.Num: 42
        After asignment: ReferenceEquals(tsC, tsD) = False
        ReferenceEquals(strA, strB) = True
        strA = "Goodbye world!" strB = "Hello world!"
        After strA changes, ReferenceEquals(strA, strB) = False
    */
