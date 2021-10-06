using System;
using System.Collections.Generic;
using System.Linq;

namespace index
{

    interface IMyInterface
    {
        string GetName(int ID);
    }

    class MyClass : IMyInterface
    {
        byte numA = 0xA;

        //<GetName>
        public string GetName(int ID)
        {
            if (ID < names.Length)
                return names[ID];
            else
                return String.Empty;
        }
        private string[] names = { "Spencer", "Sally", "Doug" };
        //</GetName>
    }

    //<Coords>
    public struct Coords
    {
        public int x, y;

        public Coords(int p1, int p2)
        {
            x = p1;
            y = p2;
        }
    }
    //</Coords>

    //<EnumFileMode>
    public enum FileMode
    {
        CreateNew = 1,
        Create = 2,
        Open = 3,
        OpenOrCreate = 4,
        Truncate = 5,
        Append = 6,
    }
    //</EnumFileMode>


    class Program
    {
        static void Main(string[] args)
        {
            // <ConstantByte>
            // constant field on type byte.
            byte b = byte.MaxValue;
            // </ConstantByte>

            // <NonAggregateTypes>
            byte num = 0xA;
            int i = 5;
            char c = 'Z';
            // </NonAggregateTypes>

            //<ConvertTypes>
            string s = "The answer is " + 5.ToString();
            // Outputs: "The answer is 5"
            Console.WriteLine(s);

            Type type = 12345.GetType();
            // Outputs: "System.Int32"
            Console.WriteLine(type);
            //</ConvertTypes>

            /*
            // <GenericType>
            List<string> stringList = new List<string>();
            stringList.Add("String example");
            // compile time error adding a type other than a string:
            stringList.Add(4);
            // </GenericType>
            */

            // <CompileTimeType>
            string message = "This is a string of characters";
            // </CompileTimeType>

            // <RuntimeTypes>
            object anotherMessage = "This is another string of characters";
            IEnumerable<char> someCharacters = "abcdefghijklmnopqrstuvwxyz";
            // </RuntimeTypes>
        }

        static void TypeSafeExample()
        {
            /*
            //<TypeSafeExample>
            int a = 5;
            int b = a + 2; //OK

            bool test = true;

            // Error. Operator '+' cannot be applied to operands of type 'int' and 'bool'.
            int c = a + test;
            //</TypeSafeExample>
            */
        }

        static void Declarations()
        {
            //<Declarations>
            // Declaration only:
            float temperature;
            string name;
            MyClass myClass;

            // Declaration with initializers (four examples):
            char firstLetter = 'C';
            var limit = 3;
            int[] source = { 0, 1, 2, 3, 4, 5 };
            var query = from item in source
                        where item <= limit
                        select item;
            //</Declarations>
        }

        static void DeclarationAndAssignment()
        {
            // <DeclarationAndAssignment>
            MyClass myClass = new MyClass();
            MyClass myClass2 = myClass;
            // </DeclarationAndAssignment>
        }

        static void InterfaceAssignment()
        {
            // <InterfaceDeclaration>
            MyClass myClass = new MyClass();

            // Declare and assign using an existing value.
            IMyInterface myInterface = myClass;

            // Or create and assign a value in a single statement.
            IMyInterface myInterface2 = new MyClass();
            // </InterfaceDeclaration>
        }

        static void ArrayDeclaration()
        {
            //<ArrayDeclaration>
            // Declare and initialize an array of integers.
            int[] nums = { 1, 2, 3, 4, 5 };

            // Access an instance property of System.Array.
            int len = nums.Length;
            //</ArrayDeclaration>
        }
    }
}
